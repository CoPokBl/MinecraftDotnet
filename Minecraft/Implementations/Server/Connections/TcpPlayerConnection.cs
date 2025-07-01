using System.Net.Sockets;
using Minecraft.Packets;
using Org.BouncyCastle.Crypto.IO;

namespace Minecraft.Implementations.Server.Connections;

public class TcpPlayerConnection(TcpClient client) : PlayerConnection, IDisposable {
    private readonly CancellationTokenSource _cts = new();
    private readonly object _sendLock = new();
    
    private NetworkStream NetStream => client.GetStream();
    private CipherStream? _cipherStream;
    private Stream Stream => EncryptionEnabled ? _cipherStream.ThrowIfNull() : NetStream;

    public override void InitialiseEncryption() {
        _cipherStream = new CipherStream(NetStream, Decryptor, Encryptor);
    }

    protected override Task SendPacketInternal(MinecraftPacket packet) {
        if (!client.Connected) {
            Disconnect();
            return Task.CompletedTask;
        }

        lock (_sendLock) {
            return Stream.WriteAsync(packet.Serialise(State, CompressionEnabled), _cts.Token).AsTask();
        }
    }
    
    public override async Task HandlePackets() {
        Log("Handling new client");

        byte[] buffer = new byte[short.MaxValue];
        try {
            while (!_cts.IsCancellationRequested) {
                MinecraftPacket packet;
                try {
                    packet = await Stream.ReadMinecraftPacket(this, buffer, _cts.Token);
                }
                catch (NotImplementedException e) {
                    Log("BAD PACKET: " + e.Message);
                    continue;
                }
                
                HandlePacket(packet);
            }
            
            // Cancellation requested
            InvokeDisconnected();
        } catch (Exception e) {
            Log("Packet listener encountered exception:");
            Log(e.ToString());
            Log("Listening has now stopped");
            Disconnect();
        }
    }

    public override void Disconnect() {
        // disconnect the player
        _cts.Cancel();
        Dispose();
    }

    public void Dispose() {
        _cts.Dispose();
        _cipherStream?.Dispose();
        client.Dispose();
    }
}
