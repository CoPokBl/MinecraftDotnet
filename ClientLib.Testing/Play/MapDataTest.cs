using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;

namespace ClientLib.Testing.Play;

/// <summary><c>handleMapItemData</c>: a map made on its first packet, then patched in place.</summary>
public class MapDataTest {
    private static ClientBoundMapDataPacket Packet(ClientBoundMapDataPacket.Decoration[]? decorations, ClientBoundMapDataPacket.ColorPatch? patch) => new() {
        MapId = 7, Scale = 2, Locked = true, Decorations = decorations, Patch = patch
    };

    [Test]
    public void TestThePatchLandsInRowsAtItsCorner() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        client.HandleMapData(Packet(null, new ClientBoundMapDataPacket.ColorPatch(10, 20, 2, 3, [1, 2, 3, 4, 5, 6])));
        ClientMapData data = client.MapData(7)!;
        Assert.That(data.Scale, Is.EqualTo(2));
        Assert.That(data.Locked, Is.True);
        Assert.That(data.Colors[10 + 20 * 128], Is.EqualTo(1));
        Assert.That(data.Colors[11 + 20 * 128], Is.EqualTo(2));
        Assert.That(data.Colors[10 + 22 * 128], Is.EqualTo(5));
        Assert.That(data.Colors[11 + 22 * 128], Is.EqualTo(6));
        Assert.That(data.Colors[12 + 20 * 128], Is.Zero);
    }

    [Test]
    public void TestALaterPacketKeepsTheMapAndOnlyReplacesWhatItCarries() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientBoundMapDataPacket.Decoration marker = new(MapDecorationType.Player, 4, -6, 3);
        client.HandleMapData(Packet([marker], new ClientBoundMapDataPacket.ColorPatch(0, 0, 1, 1, [9])));
        ClientMapData first = client.MapData(7)!;
        int version = first.Version;
        client.HandleMapData(Packet(null, new ClientBoundMapDataPacket.ColorPatch(1, 0, 1, 1, [8])));
        Assert.That(client.MapData(7), Is.SameAs(first));
        Assert.That(first.Decorations, Is.EqualTo(new[] { marker }));
        Assert.That(first.Colors[0], Is.EqualTo(9));
        Assert.That(first.Colors[1], Is.EqualTo(8));
        Assert.That(first.Version, Is.GreaterThan(version));
        client.HandleMapData(Packet([], null));
        Assert.That(first.Decorations, Is.Empty);
        Assert.That(client.MapData(8), Is.Null);
    }
}
