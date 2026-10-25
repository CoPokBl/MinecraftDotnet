using System.Net;
using System.Net.Sockets;
using System.Text;
using ClientLib.Multiplayer;
using Minecraft;
using Minecraft.Implementations.Storage;
using Minecraft.Text;
using NBT.Tags;

namespace ClientLib.Testing.Multiplayer;

/// <summary>
/// The server list: <c>ServerAddress</c> parsing, <c>servers.dat</c> as vanilla writes it, the status ping
/// on the wire and its legacy fallback, and the LAN announcement format.
/// </summary>
public class ServerListTest {
    [TestCase("localhost", "localhost", 25565)]
    [TestCase("play.example.com:25570", "play.example.com", 25570)]
    [TestCase("[::1]:1234", "::1", 1234)]
    [TestCase("::1", "::1", 25565)]
    [TestCase("host:", "host", 25565)]
    [TestCase("host:abc", "server.invalid", 25565)]
    [TestCase("host:70000", "server.invalid", 25565)]
    [TestCase("host:+5", "server.invalid", 25565)]
    [TestCase(":25565", "server.invalid", 25565)]
    public void TestParsesAsHostAndPortDoes(string input, string host, int port) {
        ServerAddress address = ServerAddress.Parse(input);
        Assert.That((address.Host, address.Port), Is.EqualTo((host, port)));
    }

    [TestCase("localhost", true)]
    [TestCase("my_server.example.com", true)]
    [TestCase("example.com.", true)]
    [TestCase("a..b", false)]
    [TestCase("", false)]
    [TestCase("host:99999", false)]
    public void TestValidAddressIsWhatIdnAccepts(string input, bool valid) => Assert.That(ServerAddress.IsValidAddress(input), Is.EqualTo(valid));

    [Test]
    public void TestCodeOfConductIsRememberedByJavaHashCode() {
        // "hello".hashCode() in Java.
        Assert.That(ServerData.JavaHashCode("hello"), Is.EqualTo(99162322));
        ServerData server = new("A", "b", ServerType.Other);
        server.AcceptCodeOfConduct("Be nice");
        Assert.That(((IntegerTag)server.Write()["acceptedCodeOfConduct"]!).Value, Is.EqualTo(ServerData.JavaHashCode("Be nice")));
        Assert.That(ServerData.Read(server.Write()).HasAcceptedCodeOfConduct("Be nice"), Is.True);
    }

    /// <summary>The bytes <c>NbtIo.write</c> gives for one shown server with no icon and the prompt policy.</summary>
    [Test]
    public void TestSavesUncompressedNamedRoot() {
        string directory = Directory.CreateTempSubdirectory().FullName;
        try {
            ServerList list = new(directory);
            list.Add(new ServerData("A", "b", ServerType.Other), false);
            list.Save();
            byte[] expected = [
                0x0A, 0, 0,
                0x09, 0, 7, .."servers"u8, 0x0A, 0, 0, 0, 1,
                0x08, 0, 4, .."name"u8, 0, 1, (byte)'A',
                0x08, 0, 2, .."ip"u8, 0, 1, (byte)'b',
                0x01, 0, 6, .."hidden"u8, 0,
                0,
                0
            ];
            Assert.That(File.ReadAllBytes(Path.Combine(directory, "servers.dat")), Is.EqualTo(expected));
        }
        finally {
            Directory.Delete(directory, true);
        }
    }

    [Test]
    public void TestRoundTripKeepsHiddenIconAndPolicy() {
        string directory = Directory.CreateTempSubdirectory().FullName;
        try {
            ServerList list = new(directory);
            list.Add(new ServerData("Shown", "shown.example", ServerType.Other) { ResourcePackStatus = ServerPackStatus.Enabled, IconBytes = [1, 2, 3] }, false);
            list.Add(new ServerData("Direct", "direct.example", ServerType.Other) { ResourcePackStatus = ServerPackStatus.Disabled }, true);
            list.Save();
            list.Save();
            Assert.That(File.Exists(Path.Combine(directory, "servers.dat_old")), Is.True);

            ServerList loaded = new(directory);
            loaded.Load();
            Assert.Multiple(() => {
                Assert.That(loaded.Count, Is.EqualTo(1));
                Assert.That(loaded[0].Name, Is.EqualTo("Shown"));
                Assert.That(loaded[0].IconBytes, Is.EqualTo(new byte[] { 1, 2, 3 }));
                Assert.That(loaded[0].ResourcePackStatus, Is.EqualTo(ServerPackStatus.Enabled));
                Assert.That(loaded.Get("direct.example")!.ResourcePackStatus, Is.EqualTo(ServerPackStatus.Disabled));
            });
            CompoundTag root = NbtRoot.Parse(File.ReadAllBytes(Path.Combine(directory, "servers.dat")));
            CompoundTag shown = (CompoundTag)((ListTag)root["servers"]!).Tags[0];
            Assert.Multiple(() => {
                Assert.That(((StringTag)shown["icon"]!).Value, Is.EqualTo("AQID"));
                Assert.That(((ByteTag)shown["acceptTextures"]!).Value, Is.EqualTo(1));
                Assert.That(shown["acceptedCodeOfConduct"], Is.Null);
            });

            Assert.That(loaded.Unhide("direct.example"), Is.Not.Null);
            Assert.That(loaded.Count, Is.EqualTo(2));
        }
        finally {
            Directory.Delete(directory, true);
        }
    }

    [Test]
    public void TestHiddenServersKeepTheNewestSixteen() {
        ServerList list = new(Path.GetTempPath());
        for (int i = 0; i < 20; i++) {
            list.Add(new ServerData("", $"s{i}", ServerType.Other), true);
        }
        Assert.Multiple(() => {
            Assert.That(list.Get("s19"), Is.Not.Null);
            Assert.That(list.Get("s4"), Is.Not.Null);
            Assert.That(list.Get("s3"), Is.Null);
        });
    }

    [Test]
    public void TestReadsAWrongTypedFieldAsAbsent() {
        ServerData server = ServerData.Read(new CompoundTag(("name", new IntegerTag(5)), ("ip", new StringTag("x")), ("acceptTextures", new IntegerTag(256)),
            ("icon", new StringTag("not base64!"))));
        Assert.Multiple(() => {
            Assert.That(server.Name, Is.EqualTo(""));
            // Codec.BOOL reads a number by its byteValue, so 256 is false.
            Assert.That(server.ResourcePackStatus, Is.EqualTo(ServerPackStatus.Disabled));
            Assert.That(server.IconBytes, Is.Null);
        });
    }

    [Test]
    public void TestAppliesStatusAsHandleStatusResponseDoes() {
        ServerData server = new("A", "b", ServerType.Other) { IconBytes = null };
        bool persisted = false;
        ServerStatusPinger.ApplyStatus(server, ServerStatusPinger.ParseStatus("""
            {"version":{"name":"26.2","protocol":776},"players":{"max":20,"online":3,"sample":[
              {"name":"Bob","id":"4566e69f-c907-48ee-8d71-d7ba5aa00d20"},{"name":"Anonymous Player","id":"00000000-0000-0000-0000-000000000000"}]},
             "description":{"text":"Hello"},"favicon":"data:image/png;base64,AQID\n"}
            """), () => persisted = true);
        Assert.Multiple(() => {
            Assert.That(TextFlattener.Plain(server.Motd!), Is.EqualTo("Hello"));
            Assert.That(TextFlattener.Plain(server.Status!), Is.EqualTo("3/20"));
            Assert.That(TextFlattener.Plain(server.Version), Is.EqualTo("26.2"));
            Assert.That(server.Protocol, Is.EqualTo(776));
            Assert.That(server.PlayerList.Select(TextFlattener.Plain), Is.EqualTo(new[] { "Bob", Translations.Get("multiplayer.status.anonymous_player"),
                string.Format(Translations.Get("multiplayer.status.and_more")!.Replace("%s", "{0}"), 1) }));
            // Not a PNG, so validateIcon drops it, but the change is still saved.
            Assert.That(server.IconBytes, Is.Null);
            Assert.That(persisted, Is.True);
        });
    }

    [Test]
    public void TestLenientFieldsReadAsAbsent() {
        ServerData server = new("A", "b", ServerType.Other);
        ServerStatusPinger.ApplyStatus(server, ServerStatusPinger.ParseStatus("""{"players":{"max":"many","online":1},"description":"Plain"}"""), () => { });
        Assert.Multiple(() => {
            Assert.That(server.Protocol, Is.EqualTo(0));
            Assert.That(TextFlattener.Plain(server.Version), Is.EqualTo(Translations.Get("multiplayer.status.old")));
            Assert.That(server.Players, Is.Null);
            Assert.That(TextFlattener.Plain(server.Motd!), Is.EqualTo("Plain"));
        });
    }

    /// <summary>The 1.6 ping's bytes for localhost on the default port, worked by hand.</summary>
    [Test]
    public void TestLegacyPingRequest() {
        byte[] request = ServerStatusPinger.LegacyPingRequest(ServerAddress.Parse("localhost"));
        byte[] expected = [
            0xFE, 0x01, 0xFA, 0x00, 0x0B, ..Encoding.BigEndianUnicode.GetBytes("MC|PingHost"),
            // 1 for the protocol byte, 2 + 18 for the host, 4 for the port.
            0x00, 0x19, 0x7F, 0x00, 0x09, ..Encoding.BigEndianUnicode.GetBytes("localhost"), 0x00, 0x00, 0x63, 0xDD
        ];
        Assert.That(request, Is.EqualTo(expected));
    }

    [Test]
    public void TestLegacyResponse() {
        string body = "\u00a71\u0000127\u00001.6.4\u0000Old \u00a7aserver\u00005\u000020";
        byte[] response = [0xFF, (byte)(body.Length >> 8), (byte)body.Length, ..Encoding.BigEndianUnicode.GetBytes(body)];
        Assert.That(ServerStatusPinger.ParseLegacyResponse(response), Is.EqualTo(new ServerStatusPinger.LegacyStatus(127, "1.6.4", "Old \u00a7aserver", 5, 20)));
        Assert.That(ServerStatusPinger.ParseLegacyResponse([0xFF, 0, 1, 0, (byte)'x']), Is.Null);
    }

    /// <summary>
    /// A ping against a server on a loopback socket: the handshake names the address as typed with the status
    /// intent, then the status request, then a ping request once the status is in.
    /// </summary>
    [Test]
    public void TestStatusPingOnTheWire() {
        using TcpListener listener = new(IPAddress.Loopback, 0);
        listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        List<byte[]> received = [];
        Task serverSide = Task.Run(() => {
            using Socket socket = listener.AcceptSocket();
            received.Add(ReadFrame(socket));
            received.Add(ReadFrame(socket));
            WriteFrame(socket, [0x00, ..WriteString("""{"version":{"name":"26.2","protocol":776},"players":{"max":5,"online":0},"description":"Hi"}""")]);
            byte[] ping = ReadFrame(socket);
            received.Add(ping);
            WriteFrame(socket, ping);
        });
        ServerData server = new("Test", $"127.0.0.1:{port}", ServerType.Other);
        TaskCompletionSource ponged = new();
        new ServerStatusPinger().PingServer(server, () => { }, () => ponged.SetResult());
        Assert.That(ponged.Task.Wait(5000), Is.True);
        serverSide.Wait(5000);

        DataWriter handshake = new DataWriter().WriteVarInt(0).WriteVarInt(ProtocolConstants.ProtocolVersion).WriteString("127.0.0.1").WriteUShort((ushort)port).WriteVarInt(1);
        Assert.Multiple(() => {
            Assert.That(received[0], Is.EqualTo(handshake.ToArray()));
            Assert.That(received[1], Is.EqualTo(new byte[] { 0x00 }));
            Assert.That(received[2][0], Is.EqualTo(0x01));
            Assert.That(received[2], Has.Length.EqualTo(9));
            Assert.That(TextFlattener.Plain(server.Motd!), Is.EqualTo("Hi"));
            Assert.That(server.Ping, Is.GreaterThanOrEqualTo(0));
        });
    }

    private static byte[] WriteString(string text) => new DataWriter().WriteString(text).ToArray();

    private static byte[] ReadFrame(Socket socket) {
        int length = 0;
        for (int shift = 0; ; shift += 7) {
            byte[] one = new byte[1];
            socket.Receive(one);
            length |= (one[0] & 0x7F) << shift;
            if ((one[0] & 0x80) == 0) {
                break;
            }
        }
        byte[] body = new byte[length];
        for (int read = 0; read < length;) {
            read += socket.Receive(body, read, length - read, SocketFlags.None);
        }
        return body;
    }

    private static void WriteFrame(Socket socket, byte[] body) => socket.Send([..new DataWriter().WriteVarInt(body.Length).ToArray(), ..body]);

    [Test]
    public void TestLanAnnouncement() {
        Assert.Multiple(() => {
            Assert.That(LanServerList.ParseMotd("[MOTD]My World[/MOTD][AD]41234[/AD]"), Is.EqualTo("My World"));
            Assert.That(LanServerList.ParseAddress("[MOTD]My World[/MOTD][AD]41234[/AD]"), Is.EqualTo("41234"));
            Assert.That(LanServerList.ParseMotd("no tags"), Is.EqualTo("missing no"));
            Assert.That(LanServerList.ParseAddress("[MOTD]a[/MOTD][/MOTD][AD]1[/AD]"), Is.Null);
        });
        LanServerList list = new();
        list.AddServer("[MOTD]World[/MOTD][AD]5000[/AD]", IPAddress.Parse("192.168.1.7"));
        list.AddServer("[MOTD]World[/MOTD][AD]5000[/AD]", IPAddress.Parse("192.168.1.7"));
        IReadOnlyList<LanServer>? servers = list.TakeDirtyServers();
        Assert.That(servers!.Select(s => (s.Motd, s.Address)), Is.EqualTo(new[] { ("World", "192.168.1.7:5000") }));
        Assert.That(list.TakeDirtyServers(), Is.Null);
    }

    /// <summary>A DNS answer naming its SRV target through a compression pointer back into the question.</summary>
    [Test]
    public void TestSrvAnswer() {
        byte[] query = ServerNameResolver.BuildQuery(0x1234, "_minecraft._tcp.example.com");
        List<byte> response = [..query];
        response[2] = 0x81;
        response[3] = 0x80;
        response[7] = 1;
        // The answer's name points at the question's (offset 12); the target is "mc" then the pointer to "example.com".
        int exampleOffset = 12 + 1 + "_minecraft".Length + 1 + "_tcp".Length;
        byte[] rdata = [0, 5, 0, 10, 0x63, 0xDE, 2, (byte)'m', (byte)'c', (byte)(0xC0 | exampleOffset >> 8), (byte)exampleOffset];
        response.AddRange([0xC0, 12, 0, 33, 0, 1, 0, 0, 1, 0, 0, (byte)rdata.Length, ..rdata]);
        Assert.That(ServerNameResolver.ParseSrv(response.ToArray()), Is.EqualTo(("mc.example.com.", 25566)));
    }
}
