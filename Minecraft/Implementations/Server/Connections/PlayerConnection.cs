using System.Security.Cryptography;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Exceptions;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Implementations.Server.Connections;

public abstract class PlayerConnection : MinecraftConnection {
    /// <summary>
    /// The handshake received from the client.
    /// This will only be set if <see cref="MinecraftConnection.State"/> is not <see cref="ConnectionState.None"/>.
    /// </summary>
    public ServerBoundHandshakePacket? Handshake;
    public EventNode<IServerEvent> Events = new();  // its parent should be the server's

    public static readonly Type[] DontLog = [
        typeof(ServerBoundClientTickEndPacket),
        typeof(ServerBoundKeepAlivePacket),
        typeof(ServerBoundSetPlayerPositionPacket),
        typeof(ServerBoundSetPlayerRotationPacket),
        typeof(ServerBoundSetPlayerPosAndRotPacket)
    ];

    public void HandlePacket(MinecraftPacket packet) {
        if (DontLog.All(p => p != packet.GetType())) {
            Log($"Got full packet: {Registry.Packets.GetPacketId(State, packet)}, {packet.GetType().FullName}");
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
                    ServerBoundHandshakePacket.Intention.Transfer => ConnectionState.Login,  // transfer is the same as login
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

    /// <summary>
    /// Sends a kick packet to the client with the specified <see cref="msg"/> and immediately terminates the connection.
    /// </summary>
    /// <param name="msg">The message to send to the client.</param>
    /// <remarks>This packet works in all regular connection states (login/config/play), so it can be used at any time to disconnect the client.</remarks>
    public void Kick(TextComponent msg) {
        if (State is ConnectionState.None or ConnectionState.Status) {
            throw new Exception("Cannot kick a player that is not in either play, login, or config states.");
        }
        
        MinecraftPacket packet;
        if (State == ConnectionState.Login) {  // For some reason the disconnect packet is different in login state
            packet = new ClientBoundLoginDisconnectPacket {
                Reason = msg
            };
        }
        else {
            packet = new ClientBoundDisconnectPacket {
                Reason = msg
            };
        }
        SendPacket(packet);
        Disconnect();
    }

    /// <summary>
    /// Informs the client that compression should be enabled for packets larger than <paramref name="minSize"/> bytes
    /// and sets the <see cref="MinecraftConnection.CompressionThreshold"/> to that value.
    /// </summary>
    /// <param name="minSize"></param>
    /// <exception cref="ConnectionStateException">When <see cref="MinecraftConnection.State"/> is not <see cref="ConnectionState.Login"/>.</exception>
    public void SetCompression(int minSize) {
        if (State != ConnectionState.Login) {
            throw new ConnectionStateException(ConnectionState.Login, State, "Connection must be in login state to enable compression.");
        }

        SendPacket(new ClientBoundSetCompressionPacket {
            Threshold = minSize
        });
        CompressionThreshold = minSize;
    }

    /// <summary>
    /// Generates the necessary keys and performs the encryption handshake with the client.
    /// </summary>
    /// <param name="requestAuthentication">Whether to set <see cref="ClientBoundEncryptionRequestPacket.ShouldAuthenticate"/> to true.</param>
    /// <exception cref="ConnectionStateException">When <see cref="MinecraftConnection.State"/> is not <see cref="ConnectionState.Login"/>.</exception>
    public void EnableEncryption(bool requestAuthentication = false) {
        if (State != ConnectionState.Login) {
            throw new ConnectionStateException(ConnectionState.Login, State, "Connection must be in login state to enable encryption.");
        }
        
        RSA rsa = RSA.Create(1024);
        
        // get public key encoded in ASN.1 DER format
        byte[] publicKey = rsa.ExportSubjectPublicKeyInfo();
        byte[] verifyToken = RandomNumberGenerator.GetBytes(4);
        SendPacket(new ClientBoundEncryptionRequestPacket {
            ServerId = "dotnet",
            ShouldAuthenticate = requestAuthentication,
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

            EncryptionEnabled = true;
            SharedSecret = sharedSecret;
            Log("Encryption enabled, shared secret established.");
            
            // Create the encryptor and decryptor using the shared secret
            Encryptor = CreateSymAes(sharedSecret, true);
            Decryptor = CreateSymAes(sharedSecret, false);
            
            // Set the encryptor/decryptor in the streams
            // or at least tell the implementation that they should start using them
            InitialiseEncryption();
        });
    }

    public override void SendPacket(MinecraftPacket packet) {
        PacketSendingEvent e = new() {
            Connection = this,
            Packet = packet
        };
        Events.CallEvent(e);

        if (e.Cancelled) {
            return;
        }
        
        // Send it
        SendPacketInternal(packet);
    }
}
