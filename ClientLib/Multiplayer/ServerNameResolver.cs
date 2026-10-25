using System.Buffers.Binary;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ClientLib.Multiplayer;

/// <summary>
/// Where a connection goes, and the host name the handshake carries: vanilla sends
/// <c>InetAddress.getHostName</c> of the resolved address, which is the name it was looked up by, or a
/// reverse lookup of an address typed as one.
/// </summary>
public sealed record ResolvedServerAddress(IPEndPoint EndPoint, string HostName);

/// <summary>
/// <c>ServerNameResolver.DEFAULT</c>: the system resolver, then a <c>_minecraft._tcp</c> SRV record for an
/// address on the default port. Mojang's blocked server list (<c>AddressCheck</c>) is not consulted.
/// </summary>
public static class ServerNameResolver {
    /// <summary><c>resolveAddress</c>: null where vanilla's is empty.</summary>
    public static ResolvedServerAddress? Resolve(ServerAddress address) {
        ResolvedServerAddress? resolved = ResolveSystem(address);
        if (LookupRedirect(address) is { } redirected) {
            resolved = ResolveSystem(redirected);
        }
        return resolved;
    }

    /// <summary><c>ServerAddressResolver.SYSTEM</c>: <c>InetAddress.getByName</c>, which takes the first address, IPv4 ahead of IPv6.</summary>
    private static ResolvedServerAddress? ResolveSystem(ServerAddress address) {
        string host = address.Host;
        if (IPAddress.TryParse(host.Trim('[', ']'), out IPAddress? literal)) {
            return new ResolvedServerAddress(new IPEndPoint(literal, address.Port), ReverseLookup(literal));
        }
        try {
            IPAddress[] all = Dns.GetHostAddresses(host);
            IPAddress? first = all.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork) ?? all.FirstOrDefault();
            return first == null ? null : new ResolvedServerAddress(new IPEndPoint(first, address.Port), host);
        }
        catch (Exception e) when (e is SocketException or ArgumentException) {
            return null;
        }
    }

    /// <summary>
    /// <c>InetAddress.getHostName</c> of an address typed as one: the reverse lookup's name when looking that
    /// name up gives the address back, else the address as text.
    /// </summary>
    private static string ReverseLookup(IPAddress address) {
        try {
            string name = Dns.GetHostEntry(address).HostName;
            if (name.Length > 0 && Dns.GetHostAddresses(name).Contains(address)) {
                return name;
            }
        }
        catch (Exception e) when (e is SocketException or ArgumentException) {
        }
        return address.ToString();
    }

    /// <summary>
    /// <c>ServerRedirectHandler.createDnsSrvRedirectHandler</c>: the first SRV record's target, with JNDI's
    /// trailing dot, and port. One try per name server with JNDI's one second timeout.
    /// </summary>
    public static ServerAddress? LookupRedirect(ServerAddress address) {
        if (address.Port != ServerAddress.DefaultPort) {
            return null;
        }
        string name = "_minecraft._tcp." + address.Host;
        foreach (IPAddress server in NameServers()) {
            try {
                if (QuerySrv(server, name) is { } record) {
                    return new ServerAddress(record.Target, record.Port);
                }
                return null;
            }
            catch (Exception e) when (e is SocketException or InvalidDataException or IndexOutOfRangeException or ArgumentException) {
            }
        }
        return null;
    }

    private static IEnumerable<IPAddress> NameServers() {
        HashSet<IPAddress> seen = [];
        foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces()) {
            if (adapter.OperationalStatus != OperationalStatus.Up) {
                continue;
            }
            IPAddressCollection servers;
            try {
                servers = adapter.GetIPProperties().DnsAddresses;
            }
            catch (NetworkInformationException) {
                continue;
            }
            foreach (IPAddress server in servers) {
                if (seen.Add(server)) {
                    yield return server;
                }
            }
        }
    }

    /// <returns>Null for an answer without an SRV record.</returns>
    /// <exception cref="SocketException">No answer in time.</exception>
    private static (string Target, int Port)? QuerySrv(IPAddress server, string name) {
        ushort id = (ushort)Random.Shared.Next(65536);
        byte[] query = BuildQuery(id, name);
        using Socket socket = new(server.AddressFamily, SocketType.Dgram, ProtocolType.Udp) { ReceiveTimeout = 1000 };
        socket.Connect(new IPEndPoint(server, 53));
        socket.Send(query);
        byte[] response = new byte[4096];
        while (true) {
            int length = socket.Receive(response);
            if (length >= 12 && BinaryPrimitives.ReadUInt16BigEndian(response) == id) {
                return ParseSrv(response.AsSpan(0, length));
            }
        }
    }

    public static byte[] BuildQuery(ushort id, string name) {
        List<byte> query = [(byte)(id >> 8), (byte)id, 0x01, 0x00, 0, 1, 0, 0, 0, 0, 0, 0];
        foreach (string label in name.TrimEnd('.').Split('.')) {
            byte[] bytes = Encoding.ASCII.GetBytes(label);
            query.Add((byte)bytes.Length);
            query.AddRange(bytes);
        }
        query.AddRange([0, 0, 33, 0, 1]);
        return query.ToArray();
    }

    /// <summary>The first SRV answer, its target written as JNDI writes a domain name, with the root's dot.</summary>
    public static (string Target, int Port)? ParseSrv(ReadOnlySpan<byte> message) {
        int questions = BinaryPrimitives.ReadUInt16BigEndian(message[4..]);
        int answers = BinaryPrimitives.ReadUInt16BigEndian(message[6..]);
        int offset = 12;
        for (int i = 0; i < questions; i++) {
            ReadName(message, ref offset);
            offset += 4;
        }
        for (int i = 0; i < answers; i++) {
            ReadName(message, ref offset);
            int type = BinaryPrimitives.ReadUInt16BigEndian(message[offset..]);
            int length = BinaryPrimitives.ReadUInt16BigEndian(message[(offset + 8)..]);
            offset += 10;
            if (type == 33) {
                int port = BinaryPrimitives.ReadUInt16BigEndian(message[(offset + 4)..]);
                int target = offset + 6;
                return (ReadName(message, ref target) + ".", port);
            }
            offset += length;
        }
        return null;
    }

    private static string ReadName(ReadOnlySpan<byte> message, ref int offset) {
        StringBuilder name = new();
        int position = offset;
        bool jumped = false;
        for (int hops = 0; hops < 64; hops++) {
            int length = message[position];
            if (length == 0) {
                if (!jumped) {
                    offset = position + 1;
                }
                return name.ToString();
            }
            if ((length & 0xC0) == 0xC0) {
                if (!jumped) {
                    offset = position + 2;
                }
                jumped = true;
                position = (length & 0x3F) << 8 | message[position + 1];
                continue;
            }
            if (name.Length > 0) {
                name.Append('.');
            }
            name.Append(Encoding.ASCII.GetString(message.Slice(position + 1, length)));
            position += 1 + length;
        }
        throw new InvalidDataException("DNS name compression loops");
    }
}
