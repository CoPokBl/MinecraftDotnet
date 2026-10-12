using System.Buffers;
using System.Collections.Concurrent;
using System.IO.Compression;
using System.Net.Sockets;
using Minecraft;
using Minecraft.Implementations;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Org.BouncyCastle.Crypto;

namespace ClientLib.Network;

/// <summary>
/// A connection to a server, split the way vanilla's netty pipeline splits it: frames are read,
/// decrypted, decompressed and decoded on a reader thread, written on a writer thread, and handed to
/// the game thread through <see cref="TryDequeue"/>.
/// <p/>
/// Inbound and outbound protocol states are separate because they change at different moments. The
/// server stops sending one phase's packets when it sends the terminal packet of that phase, and only
/// starts reading the next phase after the client acknowledges it. A terminal packet therefore
/// <b>parks the reader</b> until the game thread has handled it and called
/// <see cref="SetInboundState"/>, which is what vanilla does by turning off auto read; decoding the
/// next frame first would read a play packet with the configuration table, or before the registries
/// it refers to exist.
/// </summary>
public sealed class ClientConnection : IDisposable {
    /// <summary>The largest frame vanilla accepts, a three byte VarInt.</summary>
    private const int MaxFrame = 2097151;

    /// <summary>Vanilla's <c>CompressionDecoder.MAXIMUM_UNCOMPRESSED_LENGTH</c>.</summary>
    private const int MaxUncompressed = 8388608;

    private readonly Socket _socket;
    private readonly BlockingCollection<Outgoing> _outgoing = new();
    private readonly ConcurrentQueue<MinecraftPacket> _incoming = new();
    private readonly SemaphoreSlim _resume = new(0);
    private readonly CancellationTokenSource _cts = new();
    private int _closed;

    // Not ICryptoTransform: .NET's CFB8 transform refuses any length that is not a whole AES block,
    // and a socket read is whatever length it is.
    private BufferedBlockCipher? _decryptor;
    private BufferedBlockCipher? _encryptor;

    /// <summary>What the next frame from the server is decoded as. Written by the reader for login, and by the game thread after a terminal packet.</summary>
    public volatile ConnectionState InboundState = ConnectionState.None;

    /// <summary>What packets handed to <see cref="Send"/> are encoded as. Game thread only, except during login.</summary>
    public volatile ConnectionState OutboundState = ConnectionState.None;

    /// <summary>Negative when compression is off. Set by the reader, from <c>login_compression</c>.</summary>
    public volatile int CompressionThreshold = -1;

    public MinecraftRegistry Registry { get; set; } = VanillaRegistry.Data;

    /// <summary>
    /// Runs on the reader thread for every decoded packet before it is queued, and may consume it by
    /// returning true. Login is handled here, as vanilla handles it on the netty thread, because
    /// compression and encryption change how the very next frame is read.
    /// </summary>
    public Func<MinecraftPacket, bool>? ReaderHook { get; set; }

    /// <summary>Raised once, from whichever thread noticed, with a reason for a person to read.</summary>
    public event Action<string>? Disconnected;

    /// <summary>Called with every packet that failed to decode. The frame is skipped and the connection stays up.</summary>
    public Action<string> Warn { get; set; } = Console.Error.WriteLine;

    public bool Connected => Volatile.Read(ref _closed) == 0;

    public string? DisconnectReason { get; private set; }

    public long BytesReceived;
    public long PacketsReceived;

    private ClientConnection(Socket socket) {
        _socket = socket;
    }

    public static async Task<ClientConnection> Connect(string host, int port, CancellationToken ct = default) {
        Socket socket = new(SocketType.Stream, ProtocolType.Tcp) {
            NoDelay = true,
            ReceiveBufferSize = 1 << 20
        };
        await socket.ConnectAsync(host, port, ct);
        return new ClientConnection(socket);
    }

    public void Start() {
        new Thread(ReadLoop) { Name = "Client network reader", IsBackground = true }.Start();
        new Thread(WriteLoop) { Name = "Client network writer", IsBackground = true }.Start();
    }

    public bool TryDequeue(out MinecraftPacket packet) => _incoming.TryDequeue(out packet!);

    /// <summary>
    /// Encodes the packet in the current outbound state, on the calling thread, so a state change
    /// made right after a send applies to the packets after it and not to it.
    /// </summary>
    public void Send(MinecraftPacket packet) {
        if (!Connected) {
            return;
        }

        byte[] frame = packet.Serialise(OutboundState, CompressionThreshold, Registry);
        try {
            _outgoing.Add(new Outgoing(frame, null));
        }
        catch (InvalidOperationException) {
            // Closed between the check and the add.
        }
    }

    /// <summary>
    /// Turns on AES/CFB8 in both directions. Outbound encryption starts after whatever is already
    /// queued, which is where the unencrypted encryption response sits.
    /// </summary>
    public void EnableEncryption(byte[] sharedSecret) {
        _decryptor = MinecraftConnection.CreateSymAes(sharedSecret, false);
        BufferedBlockCipher encryptor = MinecraftConnection.CreateSymAes(sharedSecret, true);
        _outgoing.Add(new Outgoing(null, () => _encryptor = encryptor));
    }

    /// <summary>Called by the game thread once it has handled a terminal packet, to let the reader carry on in the new state.</summary>
    public void SetInboundState(ConnectionState state) {
        InboundState = state;
        _resume.Release();
    }

    public void Close(string reason) {
        if (Interlocked.Exchange(ref _closed, 1) == 1) {
            return;
        }

        DisconnectReason = reason;
        _cts.Cancel();
        _outgoing.CompleteAdding();
        _resume.Release();
        try {
            _socket.Shutdown(SocketShutdown.Both);
        }
        catch (Exception) {
            // Already gone.
        }
        _socket.Close();
        Disconnected?.Invoke(reason);
    }

    public void Dispose() {
        Close("Disposed");
    }

    private void WriteLoop() {
        try {
            foreach (Outgoing item in _outgoing.GetConsumingEnumerable(_cts.Token)) {
                if (item.Control != null) {
                    item.Control();
                    continue;
                }

                byte[] data = item.Data!;
                _encryptor?.ProcessBytes(data, 0, data.Length, data, 0);
                int sent = 0;
                while (sent < data.Length) {
                    sent += _socket.Send(data, sent, data.Length - sent, SocketFlags.None);
                }
            }
        }
        catch (OperationCanceledException) {
            // Closing.
        }
        catch (Exception e) {
            Close($"Write failed: {e.Message}");
        }
    }

    private void ReadLoop() {
        // Grows to the largest frame seen. Data is decrypted in place as soon as it arrives, so
        // everything in [0, _filled) is plaintext.
        byte[] buffer = new byte[1 << 16];
        int start = 0;
        int filled = 0;

        try {
            while (Connected) {
                // Parse every complete frame already buffered.
                while (TryReadVarInt(buffer, start, filled, out int length, out int prefix)) {
                    if (length < 0 || length > MaxFrame) {
                        throw new InvalidDataException($"Frame of {length} bytes");
                    }
                    if (filled - start - prefix < length) {
                        break;
                    }

                    int bodyStart = start + prefix;
                    start = bodyStart + length;
                    Interlocked.Add(ref BytesReceived, length + prefix);
                    if (!HandleFrame(buffer.AsSpan(bodyStart, length))) {
                        return;
                    }
                }

                // Compact, then grow if a single frame cannot fit.
                if (start > 0) {
                    Buffer.BlockCopy(buffer, start, buffer, 0, filled - start);
                    filled -= start;
                    start = 0;
                }
                if (filled == buffer.Length) {
                    Array.Resize(ref buffer, Math.Min(buffer.Length * 2, MaxFrame + 3));
                }

                int read = _socket.Receive(buffer, filled, buffer.Length - filled, SocketFlags.None);
                if (read <= 0) {
                    Close("Connection closed by server");
                    return;
                }

                _decryptor?.ProcessBytes(buffer, filled, read, buffer, filled);
                filled += read;
            }
        }
        catch (Exception e) when (e is SocketException or ObjectDisposedException) {
            Close($"Connection lost: {e.Message}");
        }
        catch (Exception e) {
            Close($"Network error: {e}");
        }
    }

    /// <returns>False when the reader should stop.</returns>
    private bool HandleFrame(ReadOnlySpan<byte> frame) {
        byte[] body;
        int offset = 0;
        if (CompressionThreshold >= 0) {
            int uncompressed = ReadVarInt(frame, ref offset);
            if (uncompressed == 0) {
                body = frame[offset..].ToArray();
            }
            else {
                if (uncompressed > MaxUncompressed) {
                    throw new InvalidDataException($"Uncompressed length {uncompressed} is too large");
                }
                body = Inflate(frame[offset..], uncompressed);
            }
        }
        else {
            body = frame.ToArray();
        }

        ConnectionState state = InboundState;
        DataReader reader = new(body);
        int id = reader.ReadVarInt();
        PacketDataDeserialiser? deserialiser = Registry.Packets.GetDeserialiserOrDefault(state, true, id);
        if (deserialiser == null) {
            Warn($"No deserialiser for clientbound {state} packet 0x{id:X2}, skipped");
            return true;
        }

        MinecraftPacket packet;
        try {
            packet = deserialiser(reader, Registry);
        }
        catch (Exception e) {
            string where = string.Join(" <- ", (e.StackTrace ?? "").Split('\n').Where(l => l.Contains(" in ")).Take(3)
                .Select(l => l.Trim()[(l.Trim().IndexOf(' ') + 1)..]));
            Warn($"Failed to decode clientbound {state} packet 0x{id:X2} ({body.Length} bytes): {e.GetType().Name}: {e.Message} {where}");
            return true;
        }

        // Bytes a deserialiser left unread are a bug in it.
        if (reader.HasRemaining) {
            Warn($"{packet.GetType().Name} left {reader.Length - reader.Position} of {body.Length} bytes unread");
        }

        Interlocked.Increment(ref PacketsReceived);

        if (ReaderHook != null && ReaderHook(packet)) {
            return true;
        }

        _incoming.Enqueue(packet);

        if (IsTerminal(packet)) {
            _resume.Wait(_cts.Token);
        }
        return Connected;
    }

    private static bool IsTerminal(MinecraftPacket packet) {
        return packet is ClientBoundFinishConfigurationPacket or ClientBoundStartConfigurationPacket;
    }

    private static byte[] Inflate(ReadOnlySpan<byte> compressed, int length) {
        byte[] input = ArrayPool<byte>.Shared.Rent(compressed.Length);
        try {
            compressed.CopyTo(input);
            using MemoryStream source = new(input, 0, compressed.Length, false);
            using ZLibStream zlib = new(source, CompressionMode.Decompress);
            byte[] output = new byte[length];
            zlib.ReadExactly(output);
            return output;
        }
        finally {
            ArrayPool<byte>.Shared.Return(input);
        }
    }

    private static bool TryReadVarInt(byte[] buffer, int start, int end, out int value, out int size) {
        value = 0;
        size = 0;
        for (int i = 0; i < 3; i++) {
            if (start + i >= end) {
                return false;
            }
            byte b = buffer[start + i];
            value |= (b & 0x7F) << (7 * i);
            if ((b & 0x80) == 0) {
                size = i + 1;
                return true;
            }
        }
        throw new InvalidDataException("Frame length VarInt is longer than three bytes");
    }

    private static int ReadVarInt(ReadOnlySpan<byte> data, ref int offset) {
        int value = 0;
        for (int shift = 0; shift < 35; shift += 7) {
            byte b = data[offset++];
            value |= (b & 0x7F) << shift;
            if ((b & 0x80) == 0) {
                return value;
            }
        }
        throw new InvalidDataException("VarInt is too long");
    }

    private readonly record struct Outgoing(byte[]? Data, Action? Control);
}
