using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace ClientLib.Testing.Play;

/// <summary>
/// The client half of sign editing, <c>handleOpenSignEditor</c> and the editor's reach test, and
/// <c>broadcastClientInformation</c>, which every options save goes through.
/// </summary>
public class SignEditTest {
    private static (MinecraftClient Client, LocalPlayer Player, List<MinecraftPacket> Sent) World() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld", VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level, 1);
        player.Position = new Vec3d(0.5, 10, 0.5);
        List<MinecraftPacket> sent = [];
        client.PacketSent += sent.Add;
        return (client, player, sent);
    }

    private static SignBlockEntity PlaceSign(MinecraftClient client, int x, int y, int z) {
        client.Dispatch(new ClientBoundBlockUpdatePacket { Location = new Vec3<int>(x, y, z), Block = Block.OakSign });
        return (SignBlockEntity)client.Level!.GetBlockEntity(x, y, z)!;
    }

    [Test]
    public void TestTheEditorOpensOnTheSignAndSide() {
        (MinecraftClient client, _, _) = World();
        SignBlockEntity sign = PlaceSign(client, 0, 11, 3);
        (SignBlockEntity Sign, bool Front)? opened = null;
        client.SignEditorOpened += (s, front) => opened = (s, front);
        client.Dispatch(new ClientBoundOpenSignEditorPacket { Location = new Vec3<int>(0, 11, 3), IsFrontText = false });
        Assert.That(opened, Is.EqualTo((sign, false)));
    }

    [Test]
    public void TestAnEditorForAnythingButASignIsIgnored() {
        (MinecraftClient client, _, _) = World();
        bool opened = false;
        client.SignEditorOpened += (_, _) => opened = true;
        client.Dispatch(new ClientBoundOpenSignEditorPacket { Location = new Vec3<int>(0, 11, 3), IsFrontText = true });
        Assert.That(opened, Is.False);
    }

    /// <summary>
    /// The eyes are at (0.5, 11.62, 0.5) and the reach is the default 4.5 plus the editor's 4. A sign at z 7 has
    /// its box 6.5 away; one at z 9 is 8.5 away, which is not strictly inside 8.5.
    /// </summary>
    [Test]
    public void TestTheEditorReachIsTheBlockRangePlusFour() {
        (MinecraftClient client, LocalPlayer player, _) = World();
        Assert.Multiple(() => {
            Assert.That(PlaceSign(client, 0, 11, 7).PlayerIsTooFarAwayToEdit(player), Is.False);
            Assert.That(PlaceSign(client, 0, 11, 9).PlayerIsTooFarAwayToEdit(player), Is.True);
            Assert.That(PlaceSign(client, 0, 11, 7).PlayerIsTooFarAwayToEdit(null), Is.True);
        });
    }

    [Test]
    public void TestTypingALineChangesBothCopiesOfIt() {
        SignText text = SignText.Empty.SetMessage(2, TextComponent.Text("hello"));
        Assert.Multiple(() => {
            Assert.That(TextFlattener.Plain(text.GetMessage(2, false)), Is.EqualTo("hello"));
            Assert.That(TextFlattener.Plain(text.GetMessage(2, true)), Is.EqualTo("hello"));
            Assert.That(TextFlattener.Plain(SignText.Empty.GetMessage(2, false)), Is.Empty);
        });
    }

    [Test]
    public void TestTheFirstSaveInPlaySendsTheInformationAndARepeatDoesNot() {
        (MinecraftClient client, _, List<MinecraftPacket> sent) = World();
        client.BroadcastClientInformation();
        client.BroadcastClientInformation();
        Assert.That(sent.OfType<ServerBoundClientInformationPacket>().Count(), Is.EqualTo(1));

        client.Options.MainHand = DominantHand.Left;
        client.Options.SkinParts = SkinParts.All & ~SkinParts.HatEnabled;
        client.BroadcastClientInformation();
        ServerBoundClientInformationPacket changed = sent.OfType<ServerBoundClientInformationPacket>().Last();
        Assert.Multiple(() => {
            Assert.That(sent.OfType<ServerBoundClientInformationPacket>().Count(), Is.EqualTo(2));
            Assert.That(changed.MainHand, Is.EqualTo(DominantHand.Left));
            Assert.That((int)changed.DisplayedSkinParts, Is.EqualTo(0x3F));
        });
    }
}
