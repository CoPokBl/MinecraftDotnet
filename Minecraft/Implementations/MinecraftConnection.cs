using Minecraft.Data.Generated;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Registry;
using Minecraft.Schemas;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Minecraft.Implementations;

/// <summary>
/// Represents a connection to or from a Minecraft server.
/// Supports sending and receiving packets.
/// </summary>
public abstract class MinecraftConnection : MappedTaggable {
    /// <summary>
    /// The protocol state of the connection. None means we are pre handshake.
    /// </summary>
    public ConnectionState State = ConnectionState.None;
    
    /// <summary>
    /// Whether compression is enabled.
    /// To enable compression set <see cref="CompressionThreshold"/> to a value >= 0.
    /// To disable compression set <see cref="CompressionThreshold"/> to -1.
    /// </summary>
    public bool CompressionEnabled => CompressionThreshold >= 0;
    
    /// <summary>
    /// The minimum size of a packet before compression is used.
    /// </summary>
    /// <remarks>
    /// This setting should not be enabled without negotiating it with the other party.
    /// Otherwise, the other party will not know to compress/decompress the packets.
    /// </remarks>
    public int CompressionThreshold = -1;
    
    /// <summary>
    /// Whether packets should be encrypted.
    /// If this is true, the <see cref="Decryptor"/> and <see cref="Encryptor"/> must be set.
    /// They can be set using <see cref="CreateSymAes"/>.
    /// </summary>
    /// <remarks>
    /// This setting should not be enabled without negotiating it with the other party.
    /// Otherwise, the other party will not be able to decrypt the packets.
    /// </remarks>
    public bool EncryptionEnabled = false;
    public BufferedBlockCipher? Decryptor;
    public BufferedBlockCipher? Encryptor;
    public byte[]? SharedSecret;
    public byte[]? ServerPubKey;  // The public key of the server, needed for authentication. Make sure this is set.
    
    /// <summary>
    /// Whether to allow unknown packets to be received without throwing an exception.
    /// </summary>
    /// <seealso cref="UnknownPacket"/>
    public bool AllowUnknownPackets = false;

    /// <summary>
    /// The registry used for this connection.
    /// </summary>
    public MinecraftRegistry Registry = VanillaRegistry.Data;
    
    /// <summary>
    /// What to do with debug log messages.
    /// </summary>
    private static readonly Action<string> NoLog = _ => { };

    public Action<string> DebugLog = NoLog;
    
    /// <summary>
    /// Raised once, when the connection is finished with. Everything hanging off a connection cleans
    /// itself up here: the player despawns, the world lets go of their chunk view, the server drops
    /// them from its lists.
    /// <p/>
    /// A handler added after the connection has already gone runs <b>immediately</b>, on the thread
    /// that added it. Registration is racy by nature: a consumer subscribing from a login event is
    /// doing so on the network thread while the socket may already be dead, and the old behaviour
    /// left that handler on a list nothing would ever call again. A minigame's "take them out of the
    /// queue" cleanup silently never running is how a lobby ends up starting a game for somebody who
    /// left.
    /// </summary>
    public event Action? Disconnected {
        add {
            if (value == null) {
                return;
            }

            lock (_disconnectLock) {
                if (!_disconnected) {
                    _disconnectedHandlers += value;
                    return;
                }
            }

            value();
        }

        remove {
            if (value == null) {
                return;
            }

            lock (_disconnectLock) {
                _disconnectedHandlers -= value;
            }
        }
    }

    private readonly object _disconnectLock = new();
    private Action? _disconnectedHandlers;
    private volatile bool _disconnected;

    /// <summary>
    /// Whether <see cref="Disconnected"/> has fired. A send after this point goes nowhere, so
    /// anything expensive to build can be skipped.
    /// </summary>
    public bool IsDisconnected => _disconnected;

    /// <summary>
    /// Runs the <see cref="Disconnected"/> handlers, <b>at most once for the life of the
    /// connection</b>. Implementations call this when the connection is finished with.
    /// <p/>
    /// Firing once is the whole point. Two threads can notice the same dead socket in the same
    /// moment, the read loop and whichever thread was mid broadcast, and the teardown a handler does
    /// is not something that can be done twice: the second pass reaches an entity that no longer has
    /// a manager or a world.
    /// <p/>
    /// Handlers are also independent of each other. They were a multicast delegate, so the first one
    /// to throw took the rest of the teardown with it, and the leak that leaves (a player still in
    /// the world's list, still holding a chunk view, still being sent packets) is far worse than
    /// whatever threw. Failures are collected and rethrown together once everything has run.
    /// </summary>
    protected void InvokeDisconnected() {
        Action? handlers;
        lock (_disconnectLock) {
            if (_disconnected) {
                return;
            }

            _disconnected = true;
            handlers = _disconnectedHandlers;
            _disconnectedHandlers = null;
        }

        if (handlers == null) {
            return;
        }

        List<Exception>? failures = null;
        foreach (Delegate handler in handlers.GetInvocationList()) {
            try {
                ((Action)handler)();
            }
            catch (Exception e) {
                (failures ??= []).Add(e);
            }
        }

        if (failures != null) {
            throw new AggregateException("One or more disconnect handlers failed.", failures);
        }
    }
    
    /// <summary>
    /// Create a symmetric AES cipher for use with the Minecraft protocol.
    /// </summary>
    /// <param name="sharedSecret">The shared secret generated by the client.</param>
    /// <param name="encrypt">Whether the cipher should be for encrypting, else for decrypting.</param>
    /// <returns>The cipher.</returns>
    public static BufferedBlockCipher CreateSymAes(byte[] sharedSecret, bool encrypt) {
        // Create a CFB8 cipher with AES
        BufferedBlockCipher cipher = new (new CfbBlockCipher(new AesEngine(), 8));
        cipher.Init(encrypt, new ParametersWithIV(new KeyParameter(sharedSecret), sharedSecret));
        return cipher;
    }
    
#region packets
    public void SendPackets(params MinecraftPacket[] packets) {
        foreach (MinecraftPacket packet in packets) {
            SendPacket(packet);
        }
    }
    
    public void SendPackets(IEnumerable<MinecraftPacket> packets) {
        foreach (MinecraftPacket packet in packets) {
            SendPacket(packet);
        }
    }

    public virtual void SendPacket(MinecraftPacket packet) {
        SendPacketInternal(packet);
    }
#endregion
    
#region util_methods
    /// <summary>
    /// Whether anything is listening. Callers on a hot path should test this before building their
    /// message, since the argument is evaluated whether or not it goes anywhere.
    /// </summary>
    protected bool LoggingEnabled => DebugLog != NoLog;

    protected void Log(string s) {
        if (!LoggingEnabled) {
            return;
        }
        DebugLog($"[{GetType().FullName}] [{State}] {s}");
    }
#endregion

#region implementation_methods

    protected abstract void SendPacketInternal(MinecraftPacket packet);
    
    /// <summary>
    /// Tell the implementation to initialise the encryption streams.
    /// After encryption is enabled and the Encryptor and Decryptor are set,
    /// this method should be invoked.
    /// </summary>
    public abstract void InitialiseEncryption();
        
    /// <summary>
    /// Start handling incoming packets from the client.
    /// </summary>
    /// <returns></returns>
    public abstract Task HandlePackets();
        
    /// <summary>
    /// Terminates the connection. This will not send any packets to the client.
    /// </summary>
    public abstract void Disconnect();

#endregion
}
