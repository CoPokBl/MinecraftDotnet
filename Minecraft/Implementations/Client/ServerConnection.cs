using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Schemas;
using Org.BouncyCastle.Crypto;

namespace Minecraft.Implementations.Client;

public abstract class ServerConnection : ITaggable {
    public ConnectionState State = ConnectionState.None;
    public bool Compression => CompressionThreshold >= 0;
    public int CompressionThreshold = -1;
    public bool Encryption = false;
    public BufferedBlockCipher? Decryptor;
    public BufferedBlockCipher? Encryptor;
    public event Action? Disconnected;
    public EventNode<ClientEvent> Events = new();
    public readonly Dictionary<string, object?> Data = new();

    protected static readonly MinecraftPacket[] DontLog = [];

    protected void Log(string s) {
        // Console.WriteLine($"[{State}] {s}");
    }

    public void HandlePacket(MinecraftPacket packet) {
        PacketReceiveEvent receiveEvent = new() {
            Packet = packet
        };
        Events.CallEventCatchErrors(receiveEvent);

        if (receiveEvent.Cancelled) {
            return;
        }

        // Now send the cancelable handle event
        PacketHandleEvent handleEvent = new() {
            Packet = packet
        };
        Events.CallEventCatchErrors(handleEvent);
    }
    
    public async Task EnableEncryption() {
        throw new NotImplementedException("Encryption is not yet implemented in the client connection.");
        // RSA rsa = RSA.Create(1024);
        //
        // // get public key encoded in ASN.1 DER format
        // byte[] publicKey = rsa.ExportSubjectPublicKeyInfo();
        // byte[] verifyToken = RandomNumberGenerator.GetBytes(4);
        // await SendPacket(new ClientBoundEncryptionRequestPacket {
        //     ServerId = "dotnet",
        //     ShouldAuthenticate = false,
        //     PublicKey = publicKey,
        //     VerifyToken = verifyToken
        // });
        //
        // // Use PacketReceiveEvent to wait for the response so it runs before it gets handled by other code
        // Events.OnFirstWhere<PacketReceiveEvent>(e => e.Packet is ServerBoundEncryptionResponsePacket, e => {
        //     ServerBoundEncryptionResponsePacket packet = (ServerBoundEncryptionResponsePacket)e.Packet;
        //     
        //     // Decrypt the shared secret using our private key
        //     byte[] sharedSecret = rsa.Decrypt(packet.SharedSecret, RSAEncryptionPadding.Pkcs1);
        //     byte[] decryptedToken = rsa.Decrypt(packet.VerifyToken, RSAEncryptionPadding.Pkcs1);
        //     
        //     if (!decryptedToken.SequenceEqual(verifyToken)) {
        //         throw new Exception("Verify token does not match, encryption failed.");
        //     }
        //
        //     Encryption = true;
        //     Log("Encryption enabled, shared secret established.");
        //     
        //     // Create the encryptor and decryptor using the shared secret
        //     Encryptor = CreateSymAes(sharedSecret, true);
        //     Decryptor = CreateSymAes(sharedSecret, false);
        //     
        //     // Set the encryptor/decryptor in the streams
        //     // or at least tell the implementation that they should start using them
        //     InitialiseEncryption();
        // });
    }

    public Task<MinecraftPacket> WaitForPacket() {
        TaskCompletionSource<MinecraftPacket> tcs = new();
        Events.OnFirst<PacketHandleEvent>(e => tcs.SetResult(e.Packet));
        return tcs.Task;
    }

    protected void InvokeDisconnected() {
        Disconnected?.Invoke();
    }

    public void SetCompression(int minSize) {
        if (State != ConnectionState.Login) {
            throw new Exception("Connection must be in login state to enable compression.");
        }
        CompressionThreshold = minSize;
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