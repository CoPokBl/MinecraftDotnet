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

    protected override void SendPacketInternal(MinecraftPacket packet) {
        if (_cts.IsCancellationRequested) {
            return;
        }
        
        if (!client.Connected) {
            Disconnect();
            return;
        }

        // Stopwatch sw = Stopwatch.StartNew();
        byte[] buff = packet.Serialise(State, CompressionThreshold);
        // Console.WriteLine("Serialised packet in " + sw.ElapsedMilliseconds + "ms, size: " + buff.Length);
        lock (_sendLock) {
            // packet.WriteTo(Stream, State, CompressionThreshold);
            // Stopwatch ssw = Stopwatch.StartNew();
            Stream.Write(buff);
            // Console.WriteLine("Wrote packet in " + ssw.ElapsedMilliseconds + "ms, size: " + buff.Length);
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
            Disconnect();
        } catch (Exception e) {
            Log("Packet listener encountered exception:");
            Log(e.ToString());
            Log("Listening has now stopped");
            Disconnect();
        }
    }

    public override void Disconnect() {
        if (_cts.IsCancellationRequested) {
            return;  // already disconnected
        }
        
        // disconnect the player
        _cts.Cancel();
        try {
            client.Close();
        }
        catch (Exception) {
            // who cares
        }
        InvokeDisconnected();
        Dispose();
    }

    public void Dispose() {
    }
}
