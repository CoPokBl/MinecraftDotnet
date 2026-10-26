using System.Net.Sockets;
using Minecraft.Packets;
using Org.BouncyCastle.Crypto.IO;

namespace Minecraft.Implementations.Server.Connections;

public class TcpPlayerConnection(TcpClient client) : PlayerConnection, IDisposable {
    private readonly CancellationTokenSource _cts = new();
    private readonly object _sendLock = new();

    /// <summary>Set by whichever thread gets to tear the connection down, so only one does.</summary>
    private int _disconnecting;

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

        byte[] buff = packet.Serialise(State, CompressionThreshold);

        bool failed;
        lock (_sendLock) {
            // Re-checked under the lock: another thread may have torn the connection down while this
            // one was serialising, and writing to a closed stream is what raised the failure we are
            // about to handle in the first place.
            if (_cts.IsCancellationRequested) {
                return;
            }

            try {
                Stream.Write(buff);
                failed = false;
            }
            catch (Exception) {
                failed = true;
            }
        }

        // A write that fails means the socket is gone, so the connection is closed rather than only
        // announced as closed. Announcing alone left it open: every later send found it still
        // uncancelled, tried again, failed again and announced again, and the second announcement is
        // what ran a player's whole teardown a second time against an entity that no longer had a
        // manager. Outside the send lock, because the handlers do a great deal more than send.
        if (failed) {
            Disconnect();
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
        // Interlocked rather than a read of the token: the read loop and a failed broadcast notice the
        // same dead socket at the same moment, and both used to get past a plain check and close the
        // client twice.
        if (Interlocked.Exchange(ref _disconnecting, 1) == 1) {
            return;
        }

        // Cancelled first, so a send racing this one drops its packet instead of writing to a stream
        // that is about to close.
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
