using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientLib.Multiplayer;

/// <summary><c>LanServer</c>: a game opened to LAN, heard announcing itself.</summary>
public sealed class LanServer(string motd, string address) {
    public string Motd { get; } = motd;
    public string Address { get; } = address;
    public long PingTime { get; private set; } = Stopwatch.GetTimestamp();

    public void UpdatePingTime() => PingTime = Stopwatch.GetTimestamp();
}

/// <summary><c>LanServerDetection.LanServerList</c>: what the detector heard, shared with the screen under a lock.</summary>
public sealed class LanServerList {
    private readonly List<LanServer> _servers = [];
    private bool _dirty;

    /// <summary>A copy of the list when a server has been added since the last call, else null.</summary>
    public IReadOnlyList<LanServer>? TakeDirtyServers() {
        lock (_servers) {
            if (!_dirty) {
                return null;
            }
            _dirty = false;
            return _servers.ToArray();
        }
    }

    public void AddServer(string pingData, IPAddress from) {
        string motd = ParseMotd(pingData);
        if (ParseAddress(pingData) is not { } port) {
            return;
        }
        string address = from + ":" + port;
        lock (_servers) {
            if (_servers.Find(s => s.Address == address) is { } known) {
                known.UpdatePingTime();
                return;
            }
            _servers.Add(new LanServer(motd, address));
            _dirty = true;
        }
    }

    /// <summary><c>LanServerPinger.parseMotd</c>.</summary>
    public static string ParseMotd(string ping) {
        int start = ping.IndexOf("[MOTD]", StringComparison.Ordinal);
        if (start < 0) {
            return "missing no";
        }
        int end = ping.IndexOf("[/MOTD]", start + "[MOTD]".Length, StringComparison.Ordinal);
        return end < start ? "missing no" : ping[(start + "[MOTD]".Length)..end];
    }

    /// <summary><c>LanServerPinger.parseAddress</c>: what follows the one <c>[/MOTD]</c> inside <c>[AD]</c>, which is a port.</summary>
    public static string? ParseAddress(string ping) {
        int endMotd = ping.IndexOf("[/MOTD]", StringComparison.Ordinal);
        if (endMotd < 0 || ping.IndexOf("[/MOTD]", endMotd + "[/MOTD]".Length, StringComparison.Ordinal) >= 0) {
            return null;
        }
        int start = ping.IndexOf("[AD]", endMotd + "[/MOTD]".Length, StringComparison.Ordinal);
        if (start < 0) {
            return null;
        }
        int end = ping.IndexOf("[/AD]", start + "[AD]".Length, StringComparison.Ordinal);
        return end < start ? null : ping[(start + "[AD]".Length)..end];
    }
}

/// <summary>
/// <c>LanServerDetection.LanServerDetector</c>: listens on the LAN multicast group for games announcing
/// themselves, on its own thread until <see cref="Interrupt"/>, which takes up to the five second receive
/// timeout to be noticed.
/// </summary>
public sealed class LanServerDetector {
    private const int PingPort = 4445;
    private static readonly IPAddress PingGroup = IPAddress.Parse("224.0.2.60");
    private static int _uniqueThreadId;

    private readonly LanServerList _list;
    private readonly Socket _socket;
    private readonly Thread _thread;
    private volatile bool _interrupted;

    /// <exception cref="SocketException">The port or the group could not be joined.</exception>
    public LanServerDetector(LanServerList list) {
        _list = list;
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        try {
            // MulticastSocket sets SO_REUSEADDR, so several clients on one machine can all listen.
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _socket.Bind(new IPEndPoint(IPAddress.Any, PingPort));
            _socket.ReceiveTimeout = 5000;
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(PingGroup));
        }
        catch {
            _socket.Dispose();
            throw;
        }
        _thread = new Thread(Run) { Name = $"LanServerDetector #{Interlocked.Increment(ref _uniqueThreadId)}", IsBackground = true };
    }

    public void Start() => _thread.Start();

    public void Interrupt() => _interrupted = true;

    private void Run() {
        byte[] buffer = new byte[1024];
        EndPoint from = new IPEndPoint(IPAddress.Any, 0);
        while (!_interrupted) {
            int length;
            try {
                length = _socket.ReceiveFrom(buffer, ref from);
            }
            catch (SocketException e) when (e.SocketErrorCode == SocketError.TimedOut) {
                continue;
            }
            catch (SocketException e) {
                Console.Error.WriteLine($"Couldn't ping server: {e.Message}");
                break;
            }
            _list.AddServer(Encoding.UTF8.GetString(buffer, 0, length), ((IPEndPoint)from).Address);
        }
        try {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, new MulticastOption(PingGroup));
        }
        catch (SocketException) {
        }
        _socket.Dispose();
    }
}
