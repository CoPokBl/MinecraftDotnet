using System.Net.Sockets;
using Minecraft.Packets;
using Org.BouncyCastle.Crypto.IO;

namespace Minecraft.Implementations.Client;

public class TcpServerConnection(TcpClient client) : ServerConnection {
    private readonly CancellationTokenSource _cts = new();
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
    private Stream Stream => EncryptionEnabled ? _cipherStream.ThrowIfNull() : NetStream;
    
    public override void InitialiseEncryption() {
        _cipherStream = new CipherStream(NetStream, Decryptor, Encryptor);
    }

    protected override void SendPacketInternal(MinecraftPacket packet) {
        if (_cts.IsCancellationRequested) {
            return;
        }
        
        lock (_sendLock) {
            Stream.Write(packet.Serialise(State, CompressionThreshold));
        }
    }
    
    public override async Task HandlePackets() {
        Log("Handling server");

        byte[] buffer = new byte[short.MaxValue];
        try {
            while (!_cts.IsCancellationRequested && client.Connected) {
                MinecraftPacket packet;
                try {
                    packet = await Stream.ReadMinecraftPacket(this, buffer, _cts.Token);
                }
                catch (NotImplementedException e) {
                    Log(e.ToString());
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
            return;
        }
        
        // disconnect from the server
        _cts.Cancel();
        try {
            client.Close();
        }
        catch (Exception) {
            // who cares
        }
        InvokeDisconnected();
    }
}
