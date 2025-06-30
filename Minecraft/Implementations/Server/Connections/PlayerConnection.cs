using System.Security.Cryptography;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Registry;
using Minecraft.Schemas;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Minecraft.Implementations.Server.Connections;

public abstract class PlayerConnection : ITaggable {
    public ConnectionState State = ConnectionState.None;
    public bool Compression => CompressionThreshold >= 0;
    public int CompressionThreshold = -1;
    public bool Encryption = false;
    public BufferedBlockCipher? Decryptor;
    public BufferedBlockCipher? Encryptor;
    public ServerBoundHandshakePacket? Handshake;
    public event Action? Disconnected;
    public readonly Dictionary<string, object?> Data = new();
    public EventNode<IServerEvent> Events = new();  // its parent should be the server's

    protected static readonly Type[] DontLog = [
        typeof(ServerBoundClientTickEndPacket),
        typeof(ServerBoundKeepAlivePacket),
        typeof(ServerBoundSetPlayerPositionPacket),
        typeof(ServerBoundSetPlayerRotationPacket),
        typeof(ServerBoundSetPlayerPosAndRotPacket)
    ];

    protected void Log(string s) {
        Console.WriteLine($"[{State}] {s}");
    }

    public void HandlePacket(MinecraftPacket packet) {
        if (DontLog.All(p => p != packet.GetType())) {
            Log($"Got full packet: {PacketRegistry.GetPacketId(packet.GetType(), State)}, {packet.GetType().FullName}");
        }
        
        // Handle connection state changes. Do this before handling because client will have already updated.
        switch (packet) {
            // handshake
            case ServerBoundHandshakePacket hs:
                Handshake = hs;
                Log($"Got handshake from {hs.ProtocolVersion} client, intent: {hs.Intent}");

                State = hs.Intent switch {
                    ServerBoundHandshakePacket.Intention.Status => ConnectionState.Status,
                    ServerBoundHandshakePacket.Intention.Login => ConnectionState.Login,
                    ServerBoundHandshakePacket.Intention.Transfer => throw new NotImplementedException(
                        "Transfer is not yet supported"),
                    _ => throw new ArgumentOutOfRangeException()
                };
                break;

            // LOGIN
            case ServerBoundLoginAcknowledgedPacket: {
                State = ConnectionState.Configuration; // we are done login now
                break;
            }
                        
            // CONFIG
            case ServerBoundAcknowledgeFinishConfigurationPacket: {
                // okay so they're ready to continue
                Log("Client acknowledged finish configuration, switching to play state");
                State = ConnectionState.Play;
                break;
            }
        }
        
        PacketReceiveEvent receiveEvent = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEventCatchErrors(receiveEvent);

        if (receiveEvent.Cancelled) {
            return;
        }

        // Now send the cancelable handle event
        PacketHandleEvent handleEvent = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEventCatchErrors(handleEvent);
    }

    protected void InvokeDisconnected() {
        Disconnected?.Invoke();
    }

    public async Task Kick(TextComponent msg) {  // works in all connection states because amazing code design
        await SendPacket(new ClientBoundDisconnectPacket {
            Reason = msg
        });
        Disconnect();
    }

    public async Task SetCompression(int minSize) {
        if (State != ConnectionState.Login) {
            throw new Exception("Connection must be in login state to enable compression.");
        }

        await SendPacket(new ClientBoundSetCompressionPacket {
            Threshold = minSize
        });
        CompressionThreshold = minSize;
    }

    public async Task EnableEncryption() {
        RSA rsa = RSA.Create(1024);
        
        // get public key encoded in ASN.1 DER format
        byte[] publicKey = rsa.ExportSubjectPublicKeyInfo();
        byte[] verifyToken = RandomNumberGenerator.GetBytes(4);
        await SendPacket(new ClientBoundEncryptionRequestPacket {
            ServerId = "dotnet",
            ShouldAuthenticate = false,
            PublicKey = publicKey,
            VerifyToken = verifyToken
        });
        
        // Use PacketReceiveEvent to wait for the response so it runs before it gets handled by other code
        Events.OnFirstWhere<PacketReceiveEvent>(e => e.Packet is ServerBoundEncryptionResponsePacket, e => {
            ServerBoundEncryptionResponsePacket packet = (ServerBoundEncryptionResponsePacket)e.Packet;
            
            // Decrypt the shared secret using our private key
            byte[] sharedSecret = rsa.Decrypt(packet.SharedSecret, RSAEncryptionPadding.Pkcs1);
            byte[] decryptedToken = rsa.Decrypt(packet.VerifyToken, RSAEncryptionPadding.Pkcs1);
            
            if (!decryptedToken.SequenceEqual(verifyToken)) {
                throw new Exception("Verify token does not match, encryption failed.");
            }

            Encryption = true;
            Log("Encryption enabled, shared secret established.");
            
            // Create the encryptor and decryptor using the shared secret
            Encryptor = CreateSymAes(sharedSecret, true);
            Decryptor = CreateSymAes(sharedSecret, false);
            
            // Set the encryptor/decryptor in the streams
            // or at least tell the implementation that they should start using them
            InitialiseEncryption();
        });
    }
    
    private BufferedBlockCipher CreateSymAes(byte[] sharedSecret, bool encrypt) {
        // Create a CFB8 cipher with AES
        BufferedBlockCipher cipher = new (new CfbBlockCipher(new AesEngine(), 8));
        cipher.Init(encrypt, new ParametersWithIV(new KeyParameter(sharedSecret), sharedSecret));
        return cipher;
    }

    public async Task SendPackets(bool sequentially, params MinecraftPacket[] packets) {
        foreach (MinecraftPacket packet in packets) {
            if (sequentially) {
                await SendPacket(packet);
            }
            else {
                _ = SendPacket(packet);
            }
        }
    }
        
    public Task SendPackets(params MinecraftPacket[] packets) {
        return SendPackets(true, packets);
    }

    public Task SendPacket(MinecraftPacket packet) {
        PacketSendingEvent e = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEvent(e);

        if (e.Cancelled) {
            return Task.CompletedTask;
        }
        
        // Send it
        return SendPacketInternal(packet);
    }
    
    public T GetTag<T>(Tag<T> tag) {
        return (T)Data[tag.Id]!;
    }

    public bool HasTag<T>(Tag<T> tag) {
        return Data.ContainsKey(tag.Id);
    }

    public void SetTag<T>(Tag<T> tag, T value) {
        Data[tag.Id] = value;
    }

    protected abstract Task SendPacketInternal(MinecraftPacket packet);
    protected abstract void InitialiseEncryption();
    public abstract Task HandlePackets();
    public abstract void Disconnect();
}