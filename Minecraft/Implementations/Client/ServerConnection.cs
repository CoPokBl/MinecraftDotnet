using System.Security.Cryptography;
using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Exceptions;
using Minecraft.Packets;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Registry;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Client;

public abstract class ServerConnection : MinecraftConnection {
    public EventNode<ClientEvent> Events = new();
    public byte[]? ServerPubKey;

    protected static readonly MinecraftPacket[] DontLog = [];

    public void HandlePacket(MinecraftPacket packet) {
        if (!DontLog.Any(p => p.GetType().FullName!.Equals(packet.GetType().FullName))) {
            Log($"Got full packet: {PacketRegistry.GetPacketId(packet.GetType(), State)}, {packet.GetType().FullName}");
        }
        
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
    
    public async Task<ServerBoundEncryptionResponsePacket> EnableEncryption(ClientBoundEncryptionRequestPacket er, bool sendResponse = true) {
        if (State != ConnectionState.Login) {
            throw new ConnectionStateException(ConnectionState.Login, State, "Connection must be in login state to enable encryption.");
        }
        
        // import the server's public key
        RSA rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(er.PublicKey, out _);
        
        // Generate a shared secret
        byte[] sharedSecret = new byte[16]; // AES-128
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(sharedSecret);
        
        // Encrypt the shared secret using the server's public key
        byte[] encryptedSharedSecret = rsa.Encrypt(sharedSecret, RSAEncryptionPadding.Pkcs1);
        byte[] encryptedVerifyToken = rsa.Encrypt(er.VerifyToken, RSAEncryptionPadding.Pkcs1);

        ServerBoundEncryptionResponsePacket packet = new() {
            SharedSecret = encryptedSharedSecret,
            VerifyToken = encryptedVerifyToken
        };

        if (sendResponse) {
            await SendPacket(packet);
        }

        EncryptionEnabled = true;
        SharedSecret = sharedSecret;
        ServerPubKey = er.PublicKey;
        Encryptor = CreateSymAes(sharedSecret, true);
        Decryptor = CreateSymAes(sharedSecret, false);
        InitialiseEncryption();

        return packet;
    }

    public Task<MinecraftPacket> WaitForPacket() {
        TaskCompletionSource<MinecraftPacket> tcs = new();
        Events.OnFirst<PacketHandleEvent>(e => tcs.SetResult(e.Packet));
        return tcs.Task;
    }

    public void SetCompression(int minSize) {
        if (State != ConnectionState.Login) {
            throw new ConnectionStateException(ConnectionState.Login, State, "Connection must be in login state to enable compression.");
        }
        CompressionThreshold = minSize;
    }

    public override Task SendPacket(MinecraftPacket packet) {
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
}
