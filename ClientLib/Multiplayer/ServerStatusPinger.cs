using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientLib.Multiplayer;

/// <summary>
/// <c>ServerStatusPinger</c>: the server list's status request and ping, and the pre-1.7 ping it falls back
/// to when the status connection ends without an answer.
/// </summary>
public sealed class ServerStatusPinger {
    /// <summary>Netty's connect timeout and the 30 second <c>ReadTimeoutHandler</c> vanilla puts on every connection.</summary>
    private const int TimeoutMillis = 30000;

    private static readonly NameAndId AnonymousPlayer = new(Guid.Empty, "Anonymous Player");

    private readonly List<Socket> _connections = [];

    private readonly record struct NameAndId(Guid Id, string Name);

    /// <summary>
    /// <c>pingServer</c>: resolves and connects on the calling thread, as vanilla does on its pinger pool,
    /// then talks to the server on a worker. The callbacks run on that worker; the caller hands them to its
    /// own thread as vanilla's <c>minecraft.execute</c> does.
    /// </summary>
    /// <exception cref="SocketException">The connection could not be made.</exception>
    public void PingServer(ServerData data, Action onPersistentDataChange, Action onPongResponse) {
        ServerAddress rawAddress = ServerAddress.Parse(data.Ip);
        if (ServerNameResolver.Resolve(rawAddress) is not { } resolved) {
            // ConnectScreen.UNKNOWN_HOST_MESSAGE, which only the log sees.
            OnPingFailed(data);
            return;
        }
        Socket socket = Connect(resolved.EndPoint);
        lock (_connections) {
            _connections.Add(socket);
        }
        data.Motd = TextComponent.Translatable("multiplayer.status.pinging");
        data.PlayerList = [];
        Task.Run(() => {
            bool success = false;
            try {
                success = Exchange(socket, rawAddress, data, onPersistentDataChange, onPongResponse);
            }
            catch (Exception) {
                // Whatever ends the connection, as a decode error or a dropped socket ends vanilla's.
            }
            finally {
                Close(socket);
            }
            // onDisconnect, which only acts on a connection that never got its status.
            if (!success && !Cancelled(socket)) {
                OnPingFailed(data);
                PingLegacyServer(resolved.EndPoint, rawAddress, data);
            }
        });
    }

    private readonly HashSet<Socket> _cancelled = [];

    private bool Cancelled(Socket socket) {
        lock (_connections) {
            return _cancelled.Remove(socket);
        }
    }

    private void Close(Socket socket) {
        lock (_connections) {
            _connections.Remove(socket);
        }
        socket.Dispose();
    }

    private static Socket Connect(IPEndPoint endPoint) {
        Socket socket = new(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp) { NoDelay = true, ReceiveTimeout = TimeoutMillis };
        try {
            using CancellationTokenSource timeout = new(TimeoutMillis);
            socket.ConnectAsync(endPoint, timeout.Token).AsTask().GetAwaiter().GetResult();
            return socket;
        }
        catch (OperationCanceledException) {
            socket.Dispose();
            throw new SocketException((int)SocketError.TimedOut);
        }
        catch {
            socket.Dispose();
            throw;
        }
    }

    /// <summary>The status connection's listener: true once the status came in, whatever happens after.</summary>
    private static bool Exchange(Socket socket, ServerAddress rawAddress, ServerData data, Action onPersistentDataChange, Action onPongResponse) {
        MinecraftRegistry registry = VanillaRegistry.Data;
        // initiateServerboundStatusConnection: the address as typed, not the one an SRV record led to.
        Send(socket, new ServerBoundHandshakePacket {
            ProtocolVersion = ProtocolConstants.ProtocolVersion,
            Hostname = rawAddress.Host,
            Port = (ushort)rawAddress.Port,
            Intent = ServerBoundHandshakePacket.Intention.Status
        }, ConnectionState.None);
        Send(socket, new ServerBoundStatusRequestPacket(), ConnectionState.Status);

        int statusId = registry.Packets[ConnectionState.Status, typeof(ClientBoundStatusResponsePacket)];
        int pongId = registry.Packets[ConnectionState.Status, typeof(ClientBoundPingResponsePacket)];
        bool success = false, receivedPing = false;
        long pingStart = 0;
        while (true) {
            DataReader frame = new(ReadFrame(socket));
            int id = frame.ReadVarInt();
            if (id == statusId) {
                if (receivedPing) {
                    // multiplayer.status.unrequested
                    return success;
                }
                receivedPing = true;
                ApplyStatus(data, ParseStatus(frame.ReadString()), onPersistentDataChange);
                pingStart = Millis();
                Send(socket, new ServerBoundPingRequestPacket { Payload = pingStart }, ConnectionState.Status);
                success = true;
            }
            else if (id == pongId) {
                data.Ping = Millis() - pingStart;
                onPongResponse();
                return success;
            }
            else {
                throw new InvalidDataException($"Unexpected status packet 0x{id:X2}");
            }
        }
    }

    /// <summary><c>Util.getMillis</c>, which is <c>System.nanoTime</c> in milliseconds: the ping request carries it.</summary>
    private static long Millis() => (long)(Stopwatch.GetTimestamp() * (1000.0 / Stopwatch.Frequency));

    private static void Send(Socket socket, MinecraftPacket packet, ConnectionState state) => socket.Send(packet.Serialise(state));

    private static byte[] ReadFrame(Socket socket) {
        int length = 0;
        for (int shift = 0; ; shift += 7) {
            if (shift >= 21) {
                throw new InvalidDataException("Frame length is longer than three bytes");
            }
            int b = ReadByte(socket);
            length |= (b & 0x7F) << shift;
            if ((b & 0x80) == 0) {
                break;
            }
        }
        byte[] body = new byte[length];
        for (int read = 0; read < length;) {
            int n = socket.Receive(body, read, length - read, SocketFlags.None);
            if (n <= 0) {
                throw new IOException("Connection closed");
            }
            read += n;
        }
        return body;
    }

    private static int ReadByte(Socket socket) {
        byte[] one = new byte[1];
        if (socket.Receive(one) <= 0) {
            throw new IOException("Connection closed");
        }
        return one[0];
    }

    /// <summary>What <c>ServerStatus.CODEC</c> reads: every field lenient, so one that does not parse is as if absent.</summary>
    public sealed record ServerStatus(TextComponent Description, ServerPlayers? Players, (string Name, int Protocol)? Version, byte[]? Favicon, bool EnforcesSecureChat);

    public static ServerStatus ParseStatus(string json) {
        JObject root = JsonConvert.DeserializeObject<JObject>(json) ?? throw new JsonException("Status is not an object");
        return new ServerStatus(
            Lenient(() => TextComponent.FromJson(root["description"]!)) ?? TextComponent.Empty(),
            Lenient(() => ParsePlayers((JObject)root["players"]!)),
            root["version"] is JObject version && version["name"] is JValue { Type: JTokenType.String } name && Int(version["protocol"]) is { } protocol
                ? ((string)name!, protocol) : null,
            root["favicon"] is JValue { Type: JTokenType.String } favicon ? ParseFavicon((string)favicon!) : null,
            root["enforcesSecureChat"] is JValue { Type: JTokenType.Boolean } secure && (bool)secure);
    }

    private static T? Lenient<T>(Func<T> parse) where T : class {
        try {
            return parse();
        }
        catch (Exception) {
            return null;
        }
    }

    private static int? Int(JToken? token) => token is JValue { Type: JTokenType.Integer or JTokenType.Float } value ? (int)(double)value : null;

    private static ServerPlayers ParsePlayers(JObject players) {
        int max = Int(players["max"]) ?? throw new FormatException("players.max");
        int online = Int(players["online"]) ?? throw new FormatException("players.online");
        List<(Guid, string)> sample = [];
        if (players["sample"] is JArray entries) {
            foreach (JToken entry in entries) {
                if (entry is not JObject { } profile || profile["id"] is not JValue { Type: JTokenType.String } id || !Guid.TryParse((string)id!, out Guid uuid)
                    || profile["name"] is not JValue { Type: JTokenType.String } name) {
                    sample.Clear();
                    break;
                }
                sample.Add((uuid, (string)name!));
            }
        }
        return new ServerPlayers(max, online, sample);
    }

    /// <summary><c>ServerStatus.Favicon.CODEC</c>: a PNG data URL, newlines dropped from its base64.</summary>
    private static byte[]? ParseFavicon(string text) {
        const string prefix = "data:image/png;base64,";
        return text.StartsWith(prefix, StringComparison.Ordinal) ? ServerData.DecodeBase64(text[prefix.Length..].Replace("\n", "")) : null;
    }

    /// <summary><c>handleStatusResponse</c>'s writes to the server's entry.</summary>
    public static void ApplyStatus(ServerData data, ServerStatus status, Action onPersistentDataChange) {
        data.Motd = status.Description;
        if (status.Version is { } version) {
            data.Version = TextComponent.Text(version.Name);
            data.Protocol = version.Protocol;
        }
        else {
            data.Version = TextComponent.Translatable("multiplayer.status.old");
            data.Protocol = 0;
        }
        if (status.Players is { } players) {
            data.Status = FormatPlayerCount(players.Online, players.Max);
            data.Players = players;
            if (players.Sample.Count > 0) {
                List<TextComponent> names = new(players.Sample.Count);
                foreach ((Guid id, string name) in players.Sample) {
                    names.Add(new NameAndId(id, name) == AnonymousPlayer
                        ? TextComponent.Translatable("multiplayer.status.anonymous_player")
                        : TextComponent.Text(name));
                }
                if (players.Sample.Count < players.Online) {
                    names.Add(TextComponent.Translatable("multiplayer.status.and_more", with: [TextComponent.Text((players.Online - players.Sample.Count).ToString())]));
                }
                data.PlayerList = names;
            }
            else {
                data.PlayerList = [];
            }
        }
        else {
            data.Status = TextComponent.Translatable("multiplayer.status.unknown").WithColor(TextColor.DarkGray);
        }
        if (status.Favicon is { } icon && !(data.IconBytes != null && icon.AsSpan().SequenceEqual(data.IconBytes))) {
            data.IconBytes = ServerData.ValidateIcon(icon);
            onPersistentDataChange();
        }
    }

    /// <summary><c>onPingFailed</c>: the state is left as it was, so a failed ping goes on showing as pinging.</summary>
    private static void OnPingFailed(ServerData data) {
        data.Motd = TextComponent.Translatable("multiplayer.status.cannot_connect").WithColor(TextColor.Hex("#FF0000"));
        data.Status = TextComponent.Empty();
    }

    /// <summary><c>pingLegacyServer</c> and <c>LegacyServerPinger</c>: an answer marks the server incompatible.</summary>
    private void PingLegacyServer(IPEndPoint endPoint, ServerAddress rawAddress, ServerData data) {
        try {
            using Socket socket = Connect(endPoint);
            socket.ReceiveTimeout = 0;
            lock (_connections) {
                _connections.Add(socket);
            }
            try {
                socket.Send(LegacyPingRequest(rawAddress));
                using MemoryStream response = new();
                byte[] buffer = new byte[4096];
                int read;
                while ((read = socket.Receive(buffer)) > 0) {
                    response.Write(buffer, 0, read);
                }
                if (ParseLegacyResponse(response.ToArray()) is { } legacy) {
                    data.State = ServerState.Incompatible;
                    data.Version = TextComponent.Text(legacy.Version);
                    data.Motd = TextComponent.Text(legacy.Motd);
                    data.Status = FormatPlayerCount(legacy.Players, legacy.MaxPlayers);
                    data.Players = new ServerPlayers(legacy.MaxPlayers, legacy.Players, []);
                }
            }
            finally {
                lock (_connections) {
                    _connections.Remove(socket);
                }
            }
        }
        catch (Exception e) when (e is SocketException or IOException or ObjectDisposedException) {
        }
    }

    /// <summary><c>LegacyServerPinger.channelActive</c>: the 1.6 server list ping with its <c>MC|PingHost</c> payload.</summary>
    public static byte[] LegacyPingRequest(ServerAddress address) {
        List<byte> bytes = [0xFE, 0x01, 0xFA];
        WriteLegacyString(bytes, "MC|PingHost");
        int sizeIndex = bytes.Count;
        bytes.AddRange([0, 0]);
        int payloadStart = bytes.Count;
        bytes.Add(127);
        WriteLegacyString(bytes, address.Host);
        bytes.AddRange([(byte)(address.Port >> 24), (byte)(address.Port >> 16), (byte)(address.Port >> 8), (byte)address.Port]);
        int payloadSize = bytes.Count - payloadStart;
        bytes[sizeIndex] = (byte)(payloadSize >> 8);
        bytes[sizeIndex + 1] = (byte)payloadSize;
        return bytes.ToArray();
    }

    /// <summary><c>LegacyProtocolUtils.writeLegacyString</c>: a short count of UTF-16 units, then the units big endian.</summary>
    private static void WriteLegacyString(List<byte> bytes, string text) {
        bytes.Add((byte)(text.Length >> 8));
        bytes.Add((byte)text.Length);
        bytes.AddRange(Encoding.BigEndianUnicode.GetBytes(text));
    }

    public sealed record LegacyStatus(int Protocol, string Version, string Motd, int Players, int MaxPlayers);

    /// <summary><c>LegacyServerPinger.channelRead0</c>: a kick packet holding six fields split by NUL, the first a section sign and 1.</summary>
    public static LegacyStatus? ParseLegacyResponse(byte[] response) {
        if (response.Length < 3 || response[0] != 255) {
            return null;
        }
        int length = response[1] << 8 | response[2];
        if (response.Length < 3 + length * 2) {
            return null;
        }
        string text = Encoding.BigEndianUnicode.GetString(response, 3, length * 2);
        // Splitter.on('\0').limit(6): the sixth part keeps any further separators.
        string[] split = text.Split('\0', 6);
        if (split.Length < 6 || split[0] != "\u00a71") {
            return null;
        }
        return new LegacyStatus(GetInt(split[1], 0), split[2], split[3], GetInt(split[4], -1), GetInt(split[5], -1));
    }

    /// <summary><c>Mth.getInt</c>.</summary>
    private static int GetInt(string text, int fallback) =>
        int.TryParse(text, System.Globalization.NumberStyles.AllowLeadingSign, System.Globalization.CultureInfo.InvariantCulture, out int value) ? value : fallback;

    public static TextComponent FormatPlayerCount(int current, int max) =>
        TextComponent.Translatable("multiplayer.status.player_count", with: [
            TextComponent.Text(current.ToString()).WithColor(TextColor.Gray), TextComponent.Text(max.ToString()).WithColor(TextColor.Gray)
        ]).WithColor(TextColor.DarkGray);

    /// <summary><c>removeAll</c>: every open status connection is dropped, and none of them falls back to the legacy ping.</summary>
    public void RemoveAll() {
        lock (_connections) {
            foreach (Socket socket in _connections) {
                _cancelled.Add(socket);
                try {
                    socket.Shutdown(SocketShutdown.Both);
                }
                catch (Exception e) when (e is SocketException or ObjectDisposedException) {
                }
                socket.Close();
            }
            _connections.Clear();
        }
    }
}
