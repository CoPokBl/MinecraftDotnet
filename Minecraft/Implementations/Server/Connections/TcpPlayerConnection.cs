using System.Collections.Concurrent;
using System.Net.Sockets;
using Minecraft.Packets;
using Org.BouncyCastle.Crypto.IO;

namespace Minecraft.Implementations.Server.Connections;

public class TcpPlayerConnection(TcpClient client, bool packetQueuing = false) : PlayerConnection, IDisposable {
    private readonly CancellationTokenSource _cts = new();
    private readonly ConcurrentQueue<MinecraftPacket> _packetQueue = new();
    private readonly object _sendLock = new();
    
    private NetworkStream NetStream => client.GetStream();
    private CipherStream? _cipherStream;
    private Stream Stream => Encryption ? _cipherStream.ThrowIfNull() : NetStream;

    protected override void InitialiseEncryption() {
        _cipherStream = new CipherStream(NetStream, Decryptor, Encryptor);
    }

    protected override Task SendPacketInternal(MinecraftPacket packet) {
        if (packetQueuing) {
            _packetQueue.Enqueue(packet);
            return Task.CompletedTask;
        }

        if (!client.Connected) {
            Disconnect();
            return Task.CompletedTask;
        }

        lock (_sendLock) {
            return Stream.WriteAsync(packet.Serialise(State, Compression), _cts.Token).AsTask();
        }
    }

    private async Task PacketSending() {
        while (!_cts.IsCancellationRequested) {
            await Task.Yield();
            if (!_packetQueue.TryDequeue(out MinecraftPacket? packet)) {
                continue;
            }
            
            // Send it
            await Stream.WriteAsync(packet.Serialise(State, Compression), _cts.Token);
        }
    }
    
    public override async Task HandlePackets() {
        Log("Handling new client");
        if (packetQueuing) _ = PacketSending();

        byte[] buffer = new byte[short.MaxValue];
        try {
            while (!_cts.IsCancellationRequested) {
                // Read the packet size first
                int packetSize = await Stream.ReadVarInt();
                if (packetSize > buffer.Length) {
                    Log($"Packet size {packetSize} exceeds buffer size {buffer.Length}, disconnecting");
                    throw new Exception("Packet size exceeds buffer size");
                }
                int offset = 0;
                while (offset < packetSize) {
                    int bytesRead = await Stream.ReadAsync(buffer.AsMemory(offset, packetSize - offset), _cts.Token);
                    if (bytesRead == 0) {
                        // connection dropped
                        Log("Zero bytes, connection dropped");
                        throw new Exception("Received no data, broken connection?");
                    }
                    offset += bytesRead;
                }
                
                // buffer now contains the full packet
                // prepend the packet size varint, TODO: remove this requirement
                DataWriter data = new();
                data.WriteVarInt(packetSize);
                data.Write(buffer[..packetSize]);
                
                MinecraftPacket packet;
                try {
                    bool compressed = CompressionThreshold != -1;
                    packet = MinecraftPacket.Deserialise(data.ToArray(), false, State, compressed);
                }
                catch (NotImplementedException e) {
                    Log(e.ToString());
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
            InvokeDisconnected();
        }
    }

    public override void Disconnect() {
        // disconnect the player
        _cts.Cancel();
    }

    public void Dispose() {
        _cts.Dispose();
        _cipherStream?.Dispose();
        client.Dispose();
    }
}
