using System.Collections.Concurrent;
using System.Net.Sockets;
using Minecraft.Packets;
using Minecraft.Packets.Registry;

namespace Minecraft.Implementations.Client;

public class TcpServerConnection(TcpClient client, bool packetQueuing = false) : ServerConnection {
    private readonly CancellationTokenSource _cts = new();
    private readonly ConcurrentQueue<MinecraftPacket> _packetQueue = new();
    private NetworkStream Stream {
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

    protected override async Task SendPacketInternal(MinecraftPacket packet) {
        if (packetQueuing) {
            _packetQueue.Enqueue(packet);
            return;
        }

        try {
            await Stream.WriteAsync(packet.Serialise(Compression), _cts.Token);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            await _cts.CancelAsync();
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
                await Stream.WriteAsync(packet.Serialise(Compression), _cts.Token);
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
                        packet = MinecraftPacket.Deserialise(reader.Read(lenOfPacketLen + packetLength), true, State, compressed);
                    }
                    catch (NotImplementedException e) {
                        Log(e.ToString());
                        continue;
                    }

                    if (!DontLog.Any(p => p.GetType().FullName!.Equals(packet.GetType().FullName))) {
                        Log($"Got full packet: {PacketRegistry.GetPacketId(packet.GetType())}, {packet.GetType().FullName}");
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
        // disconnect from the server
        _cts.Cancel();
    }
}