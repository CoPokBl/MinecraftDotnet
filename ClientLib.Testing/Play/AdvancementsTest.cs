using ClientLib.Advancements;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Advancements;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ClientLib.Testing.Play;

/// <summary><c>ClientAdvancements</c>, <c>AdvancementTree</c> and <c>AdvancementProgress</c>, and the packets on either side of them.</summary>
public class AdvancementsTest {
    private sealed class Recorder : IClientAdvancementsListener {
        public readonly List<string> Events = [];
        public void OnAddAdvancementRoot(AdvancementNode root) => Events.Add("root " + root.Id);
        public void OnRemoveAdvancementRoot(AdvancementNode root) => Events.Add("-root " + root.Id);
        public void OnAddAdvancementTask(AdvancementNode task) => Events.Add("task " + task.Id);
        public void OnRemoveAdvancementTask(AdvancementNode task) => Events.Add("-task " + task.Id);
        public void OnAdvancementsCleared() => Events.Add("cleared");
        public void OnUpdateAdvancementProgress(AdvancementNode advancement, AdvancementProgress progress) => Events.Add($"progress {advancement.Id} {progress.Percent}");
        public void OnSelectedTabChanged(AdvancementNode? selectedTab) => Events.Add("tab " + (selectedTab?.Id.ToString() ?? "none"));
    }

    private readonly List<MinecraftPacket> _sent = [];
    private readonly List<Identifier> _toasts = [];

    private ClientAdvancements New() => new(_sent.Add, node => _toasts.Add(node.Id));

    private static AdvancementDisplay Display(AdvancementFrame frame = AdvancementFrame.Task, bool toast = true, bool hidden = false) => new() {
        Title = TextComponent.Text("t"), Description = TextComponent.Text("d"), Icon = new ItemStack(Item.Stone, 1),
        Frame = frame, ShowToast = toast, Hidden = hidden, X = 0, Y = 0
    };

    private static Advancement Adv(string? parent, string[][]? requirements = null, AdvancementDisplay? display = null) => new() {
        Parent = parent == null ? (Identifier?)null : Identifier.Parse(parent),
        Display = display ?? Display(),
        Requirements = requirements ?? [["a"]]
    };

    private static ClientBoundUpdateAdvancementsPacket Packet(bool reset, Dictionary<Identifier, Advancement>? added = null, Identifier[]? removed = null,
        Dictionary<Identifier, Dictionary<string, DateTimeOffset?>>? progress = null, bool show = true) => new() {
        Reset = reset, Added = added ?? [], Removed = removed ?? [], Progress = progress ?? [], ShowAdvancements = show
    };

    private static Dictionary<string, DateTimeOffset?> Done(params string[] names) =>
        names.ToDictionary(name => name, _ => (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(1000));

    [Test]
    public void AChildSentBeforeItsParentGoesInOnTheNextPass() {
        ClientAdvancements advancements = New();
        Recorder recorder = new();
        advancements.SetListener(recorder);
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> {
            ["x:c"] = Adv("x:b"), ["x:b"] = Adv("x:a"), ["x:a"] = Adv(null), ["x:d"] = Adv("x:a")
        }));
        Assert.That(recorder.Events, Is.EqualTo(new[] { "tab none", "cleared", "root x:a", "task x:d", "task x:b", "task x:c" }));
        Assert.That(advancements.Tree.Get("x:c")!.Root.Id, Is.EqualTo((Identifier)"x:a"));
    }

    [Test]
    public void AnOrphanIsLeftOut() {
        ClientAdvancements advancements = New();
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> { ["x:a"] = Adv("x:missing"), ["x:r"] = Adv(null) }));
        Assert.That(advancements.Tree.Count, Is.EqualTo(1));
    }

    [Test]
    public void RemovingANodeTakesItsChildrenFirst() {
        ClientAdvancements advancements = New();
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> { ["x:a"] = Adv(null), ["x:b"] = Adv("x:a"), ["x:c"] = Adv("x:b") }));
        Recorder recorder = new();
        advancements.SetListener(recorder);
        recorder.Events.Clear();
        advancements.Update(Packet(false, removed: ["x:a"]));
        Assert.That(recorder.Events, Is.EqualTo(new[] { "-task x:c", "-task x:b", "-root x:a" }));
        Assert.That(advancements.Tree.Count, Is.Zero);
    }

    /// <summary>Requirements are an and of ors: done when every group has one done criterion.</summary>
    [Test]
    public void ProgressCountsGroupsNotCriteria() {
        ClientAdvancements advancements = New();
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> { ["x:a"] = Adv(null, [["a", "b"], ["c"], ["d"]]) },
            progress: new() { ["x:a"] = new Dictionary<string, DateTimeOffset?> { ["a"] = DateTimeOffset.UnixEpoch, ["b"] = DateTimeOffset.UnixEpoch, ["stale"] = DateTimeOffset.UnixEpoch } }));
        AdvancementProgress progress = advancements.ProgressOf("x:a")!;
        Assert.That(progress.IsDone, Is.False);
        Assert.That(progress.Percent, Is.EqualTo(1.0F / 3.0F));
        Assert.That(progress.Criteria.Keys, Is.EquivalentTo(new[] { "a", "b", "c", "d" }), "a criterion the requirements do not name is dropped");
        Assert.That(progress.ProgressText, Is.Not.Null);
    }

    [Test]
    public void ASingleGroupHasNoProgressText() {
        ClientAdvancements advancements = New();
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> { ["x:a"] = Adv(null, [["a", "b"]]) }, progress: new() { ["x:a"] = [] }));
        Assert.That(advancements.ProgressOf("x:a")!.ProgressText, Is.Null);
        Assert.That(advancements.ProgressOf("x:a")!.Percent, Is.EqualTo(0.0F), "no criteria from the server, but the requirements fill them in");
    }

    [Test]
    public void ToastsOnlyOutsideAResetWhenShownAndAllowed() {
        ClientAdvancements advancements = New();
        Dictionary<Identifier, Advancement> tree = new() {
            ["x:r"] = Adv(null), ["x:quiet"] = Adv("x:r", display: Display(toast: false)), ["x:loud"] = Adv("x:r", display: Display(AdvancementFrame.Challenge))
        };
        advancements.Update(Packet(true, tree, progress: new() { ["x:r"] = Done("a") }));
        Assert.That(_toasts, Is.Empty, "a reset never toasts");
        advancements.Update(Packet(false, progress: new() { ["x:quiet"] = Done("a"), ["x:loud"] = Done("a") }));
        Assert.That(_toasts, Is.EqualTo(new Identifier[] { "x:loud" }));
        advancements.Update(Packet(false, progress: new() { ["x:loud"] = Done("a") }, show: false));
        Assert.That(_toasts, Has.Count.EqualTo(1), "without show_advancements nothing toasts");
        advancements.Update(Packet(false, progress: new() { ["x:loud"] = Done("a") }));
        Assert.That(_toasts, Has.Count.EqualTo(2), "done progress sent again toasts again");
    }

    [Test]
    public void ANewListenerHearsTheTreeProgressAndTab() {
        ClientAdvancements advancements = New();
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> { ["x:r"] = Adv(null), ["x:b"] = Adv("x:r") }, progress: new() { ["x:b"] = Done("a") }));
        advancements.HandleSelectTab(new ClientBoundSelectAdvancementsTabPacket { Tab = "x:r" });
        Assert.That(_sent, Is.Empty, "the server's own choice is not sent back");
        Recorder recorder = new();
        advancements.SetListener(recorder);
        Assert.That(recorder.Events, Is.EqualTo(new[] { "root x:r", "task x:b", "progress x:b 1", "tab x:r" }));
    }

    [Test]
    public void OpeningATabAlwaysTellsTheServer() {
        ClientAdvancements advancements = New();
        advancements.Update(Packet(true, new Dictionary<Identifier, Advancement> { ["x:r"] = Adv(null) }));
        AdvancementNode root = advancements.Tree.Get("x:r")!;
        advancements.SetSelectedTab(root, true);
        advancements.SetSelectedTab(root, true);
        advancements.SetSelectedTab(null, true);
        advancements.ScreenClosed();
        Assert.That(_sent.Select(Describe), Is.EqualTo(new[] { "OpenedTab x:r", "OpenedTab x:r", "ClosedScreen " }));
    }

    private static string Describe(MinecraftPacket packet) {
        ServerBoundSeenAdvancementsPacket seen = (ServerBoundSeenAdvancementsPacket)packet;
        return $"{seen.Action} {seen.Tab?.ToString() ?? ""}";
    }

    /// <summary><c>ServerboundSeenAdvancementsPacket.write</c>: the action's ordinal, then the tab only for <c>OPENED_TAB</c>.</summary>
    [Test]
    public void SeenAdvancementsIsTheActionThenTheTab() {
        byte[] opened = ServerBoundSeenAdvancementsPacket.OpenedTab("minecraft:story/root").Serialise(ConnectionState.Play);
        byte[] closed = ServerBoundSeenAdvancementsPacket.ClosedScreen().Serialise(ConnectionState.Play);
        Assert.That(Body(opened), Is.EqualTo(new DataWriter().WriteVarInt(0).WriteString("minecraft:story/root").ToArray()));
        Assert.That(Body(closed), Is.EqualTo(new DataWriter().WriteVarInt(1).ToArray()));
    }

    /// <summary>The bytes after the length and packet id.</summary>
    private static byte[] Body(byte[] framed) {
        DataReader reader = new(framed);
        reader.ReadVarInt();
        reader.ReadVarInt();
        return reader.ReadRemaining();
    }

    /// <summary>
    /// <c>ClientboundUpdateAdvancementsPacket.write</c> laid out by hand: the reset flag, the holders (id,
    /// optional parent, optional <c>DisplayInfo</c>, requirements, telemetry flag), the removed ids, the progress
    /// map with each criterion's optional epoch milliseconds, and the show flag.
    /// </summary>
    [Test]
    public void UpdateAdvancementsReadsVanillasLayout() {
        DataWriter w = new DataWriter().WriteBoolean(false).WriteVarInt(1)
            .WriteString("minecraft:story/mine_stone")
            .WriteBoolean(true).WriteString("minecraft:story/root")
            .WriteBoolean(true).WriteNbt(TextComponent.Text("Stone Age")).WriteNbt(TextComponent.Text("Mine Stone"))
            .WriteVarInt(VanillaRegistry.Data.Items.GetProtocolId(Item.WoodenPickaxe)).WriteVarInt(1).WriteVarInt(0).WriteVarInt(0)
            .WriteVarInt(2).WriteInteger(0x1 | 0x2).WriteString("minecraft:gui/advancements/backgrounds/stone")
            .WriteVarInt(2).WriteVarInt(1).WriteString("a").WriteVarInt(2).WriteString("b").WriteString("c")
            .WriteBoolean(true)
            // PositionedAdvancement's position, after the advancement.
            .WriteFloat(1.0F).WriteFloat(-0.5F)
            .WriteVarInt(1).WriteString("minecraft:old")
            .WriteVarInt(1).WriteString("minecraft:story/mine_stone").WriteVarInt(2)
            .WriteString("a").WriteBoolean(true).WriteLong(1234567L)
            .WriteString("b").WriteBoolean(false)
            .WriteBoolean(true);
        DataReader reader = new(w.ToArray());
        ClientBoundUpdateAdvancementsPacket packet = (ClientBoundUpdateAdvancementsPacket)ClientBoundUpdateAdvancementsPacket.Deserialiser(reader, VanillaRegistry.Data);
        Assert.That(reader.HasRemaining, Is.False);
        Advancement advancement = packet.Added["minecraft:story/mine_stone"];
        Assert.That(advancement.Parent, Is.EqualTo((Identifier)"minecraft:story/root"));
        AdvancementDisplay display = advancement.Display!;
        Assert.That(display.Frame, Is.EqualTo(AdvancementFrame.Goal));
        Assert.That(display.Background, Is.EqualTo((Identifier)"minecraft:gui/advancements/backgrounds/stone"));
        Assert.That((display.ShowToast, display.Hidden), Is.EqualTo((true, false)));
        Assert.That((display.X, display.Y), Is.EqualTo((1.0F, -0.5F)));
        Assert.That(display.Icon.Type, Is.EqualTo(Item.WoodenPickaxe));
        Assert.That(advancement.Requirements, Is.EqualTo(new[] { new[] { "a" }, new[] { "b", "c" } }));
        Assert.That(advancement.SendsTelemetryEvent, Is.True);
        Assert.That(packet.Removed, Is.EqualTo(new Identifier[] { "minecraft:old" }));
        Dictionary<string, DateTimeOffset?> criteria = packet.Progress["minecraft:story/mine_stone"];
        Assert.That(criteria["a"], Is.EqualTo(DateTimeOffset.FromUnixTimeMilliseconds(1234567L)));
        Assert.That(criteria["b"], Is.Null);
        Assert.That(packet.ShowAdvancements, Is.True);
    }
}
