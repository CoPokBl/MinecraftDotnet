using System.Collections.Concurrent;
using System.Net.Sockets;
using Minecraft.Packets;
using Minecraft.Packets.Registry;
using Org.BouncyCastle.Crypto.IO;

namespace Minecraft.Implementations.Client;

public class TcpServerConnection(TcpClient client, bool packetQueuing = false) : ServerConnection {
    private readonly CancellationTokenSource _cts = new();
    private readonly ConcurrentQueue<MinecraftPacket> _packetQueue = new();
    private readonly object _sendLock = new();
    private NetworkStream NetStream {
        get {
            try {
                return client.GetStream();
            }
            catch (Exception) {
                Disconnect();
            }
            return null!;
        }
    }
    
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

        lock (_sendLock) {
            return Stream.WriteAsync(packet.Serialise(State, Compression), _cts.Token).AsTask();
        }
    }

    private async Task PacketSending() {
        while (!_cts.IsCancellationRequested && client.Connected) {
            await Task.Yield();
            if (!_packetQueue.TryDequeue(out MinecraftPacket? packet)) {
                continue;
            }
            
            // Send it
            try {
                await Stream.WriteAsync(packet.Serialise(State, Compression), _cts.Token);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                await _cts.CancelAsync();
            }
        }
    }
    
    public override async Task HandlePackets() {
        Log("Handling server");
        if (packetQueuing) _ = PacketSending();

        byte[] buffer = new byte[short.MaxValue];
        try {
            while (!_cts.IsCancellationRequested && client.Connected) {
                // Read a packet
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
                    packet = MinecraftPacket.Deserialise(data.ToArray(), true, State, compressed);
                }
                catch (NotImplementedException e) {
                    Log(e.ToString());
                    continue;
                }

                if (!DontLog.Any(p => p.GetType().FullName!.Equals(packet.GetType().FullName))) {
                    Log($"Got full packet: {PacketRegistry.GetPacketId(packet.GetType(), State)}, {packet.GetType().FullName}");
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
        // disconnect from the server
        _cts.Cancel();
    }
}
