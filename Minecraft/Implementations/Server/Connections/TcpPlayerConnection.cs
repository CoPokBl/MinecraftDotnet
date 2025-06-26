using System.Collections.Concurrent;
using System.Net.Sockets;
using Minecraft.Packets;

namespace Minecraft.Implementations.Server.Connections;

public class TcpPlayerConnection(TcpClient client, bool packetQueuing = false) : PlayerConnection {
    private readonly CancellationTokenSource _cts = new();
    private readonly ConcurrentQueue<MinecraftPacket> _packetQueue = new();
    private Stream Stream => client.GetStream();
    
    protected override Task SendPacketInternal(MinecraftPacket packet) {
        if (packetQueuing) {
            _packetQueue.Enqueue(packet);
            return Task.CompletedTask;
        }

        if (!client.Connected) {
            Disconnect();
            return null!;
        }
        
        return Stream.WriteAsync(packet.Serialise(State, Compression), _cts.Token).AsTask();
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
                int bytesRead = await Stream.ReadAsync(buffer, _cts.Token);
                if (bytesRead == 0) {
                    // connection dropped
                    Log("Zero bytes, connection dropped");
                    throw new Exception("Received no data, broken connection?");
                }

                DataReader reader = new(buffer[..bytesRead]);
                while (reader.HasRemaining) {
                    int startPos = reader.Pos;
                    int packetLength = reader.ReadVarInt();
                    int lenOfPacketLen = reader.Pos - startPos;

                    int neededBytes = packetLength - (bytesRead - lenOfPacketLen);
                    if (neededBytes > 0) {
                        Log($"partial packet, needed: {neededBytes}");
                        int bufferPos = bytesRead;
                        while (neededBytes > 0) {
                            int newBytes = await Stream.ReadAsync(buffer.AsMemory(bufferPos, buffer.Length - bufferPos), _cts.Token);
                            if (newBytes == 0) {
                                Log("No DATA, dropping connection");
                                throw new Exception("Received no data, broken connection?");
                            }

                            bytesRead += newBytes;
                            neededBytes -= newBytes;
                            bufferPos += newBytes;
                        }

                        reader.UpdateData(buffer[..bytesRead]);
                    }

                    reader.Pos = startPos;
                    MinecraftPacket packet;
                    try {
                        bool compressed = lenOfPacketLen + packetLength > CompressionThreshold && CompressionThreshold >= 0;
                        packet = MinecraftPacket.Deserialise(reader.Read(lenOfPacketLen + packetLength), false, State, compressed);
                    }
                    catch (NotImplementedException e) {
                        Log(e.ToString());
                        continue;
                    }
                    
                    HandlePacket(packet);
                }
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
}