using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Interaction;

/// <summary>
/// The delays <c>Minecraft</c> and <c>MultiPlayerGameMode</c> put between actions, which hold however
/// the keys are pressed: <c>destroyDelay</c> after a break, <c>rightClickDelay</c> between uses and
/// <c>missTime</c> after a swing at nothing.
/// </summary>
public class InteractionDelayTest {
    private const int Floor = 16;

    private sealed class Rig(MinecraftClient client, LocalPlayer player) {
        public readonly MinecraftClient Client = client;
        public readonly LocalPlayer Player = player;
        public readonly List<(int Tick, MinecraftPacket Packet)> Sent = [];
        public int Ticks;
        public KeyMappings Keys => Client.Interactions.Keys;

        public void Tick(int ticks = 1) {
            for (int i = 0; i < ticks; i++) {
                Ticks++;
                Client.Interactions.Tick();
                Client.Tick();
            }
        }

        public List<int> TicksOf(ServerBoundPlayerActionPacket.Status status) =>
            Sent.Where(s => s.Packet is ServerBoundPlayerActionPacket action && action.ActionStatus == status).Select(s => s.Tick).ToList();

        public List<int> TicksOf<T>() => Sent.Where(s => s.Packet is T).Select(s => s.Tick).ToList();
    }

    /// <summary>A column of dirt under the player, who looks straight down at it.</summary>
    private static Rig DirtColumn(GameMode mode = GameMode.Survival) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort dirt = (ushort)Block.Dirt.StateId;
        for (int cx = -2; cx <= 2; cx++) {
            for (int cz = -2; cz <= 2; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = level.MinY + i * 16 < Floor ? new ClientSection(dirt, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        player.XRot = 90.0F;
        player.XRotO = 90.0F;
        player.GameMode = mode;
        player.UpdateAbilities(mode);
        Rig rig = new(client, player);
        client.PacketSent += packet => rig.Sent.Add((rig.Ticks, packet));
        rig.Tick(2);
        return rig;
    }

    private static List<int> Gaps(List<int> ticks) => ticks.Zip(ticks.Skip(1), (a, b) => b - a).ToList();

    [Test]
    public void TestHeldAttackStartsTheNextBlockSixTicksAfterABreak() {
        Rig rig = DirtColumn();
        rig.Keys.Attack.Press();
        for (int i = 0; i < 80; i++) {
            // Pressing a button that is already down is no click, so it cannot start the next block early.
            rig.Keys.Attack.Press();
            rig.Tick();
        }
        List<int> finished = rig.TicksOf(ServerBoundPlayerActionPacket.Status.FinishedDigging);
        List<int> started = rig.TicksOf(ServerBoundPlayerActionPacket.Status.StartedDigging);
        Assert.That(finished, Has.Count.GreaterThanOrEqualTo(2));
        // destroyDelay is 5 after a break and counts down one continueDestroyBlock a tick; the sixth starts the next.
        foreach (int tick in finished.Take(finished.Count - 1)) {
            Assert.That(started.First(start => start > tick) - tick, Is.EqualTo(6));
        }
    }

    [Test]
    public void TestAFreshClickStartsTheNextBlockAtOnceAsVanillasDoes() {
        Rig rig = DirtColumn();
        rig.Keys.Attack.Press();
        int broke = -1;
        for (int i = 0; i < 40 && broke < 0; i++) {
            rig.Tick();
            if (rig.TicksOf(ServerBoundPlayerActionPacket.Status.FinishedDigging) is [var first, ..]) {
                broke = first;
            }
        }
        Assert.That(broke, Is.GreaterThan(0));
        // Let go and press again before the next tick: startAttack calls startDestroyBlock, which has no delay.
        rig.Keys.Attack.SetDown(false);
        rig.Keys.Attack.Press();
        rig.Tick();
        Assert.That(rig.TicksOf(ServerBoundPlayerActionPacket.Status.StartedDigging).Last(), Is.EqualTo(broke + 1));
    }

    [Test]
    public void TestCreativeBreaksEverySixTicksWhileHeld() {
        Rig rig = DirtColumn(GameMode.Creative);
        rig.Keys.Attack.Press();
        rig.Tick(40);
        List<int> started = rig.TicksOf(ServerBoundPlayerActionPacket.Status.StartedDigging);
        Assert.That(started, Has.Count.GreaterThanOrEqualTo(4));
        Assert.That(Gaps(started), Is.All.EqualTo(6));
    }

    [Test]
    public void TestHeldUseRepeatsEveryFourTicks() {
        Rig rig = DirtColumn();
        rig.Player.XRot = rig.Player.XRotO = -90.0F;
        rig.Client.Inventory.SetInventorySlot(0, new ItemStack(Item.Stick, 1));
        rig.Keys.Use.Press();
        for (int i = 0; i < 30; i++) {
            rig.Keys.Use.Press();
            rig.Tick();
        }
        List<int> uses = rig.TicksOf<ServerBoundUseItemPacket>();
        Assert.That(uses, Has.Count.GreaterThanOrEqualTo(5));
        Assert.That(Gaps(uses), Is.All.EqualTo(4));
    }

    [Test]
    public void TestASwingAtNothingHoldsTheAttackBackTenTicks() {
        Rig rig = DirtColumn();
        rig.Player.XRot = rig.Player.XRotO = -90.0F;
        rig.Keys.Attack.Press();
        rig.Tick();
        int swung = rig.Ticks;
        Assert.That(rig.TicksOf<ServerBoundSwingArmPacket>(), Is.EqualTo(new[] { swung }));

        rig.Player.XRot = rig.Player.XRotO = 90.0F;
        rig.Tick(15);
        // missTime is 10 and counts down after handleKeybinds, so the held button digs on the tenth tick after the swing.
        Assert.That(rig.TicksOf(ServerBoundPlayerActionPacket.Status.StartedDigging), Is.EqualTo(new[] { swung + 10 }));
    }

    [Test]
    public void TestDropAndSwapGoOutInTheTickBeforeTheMove() {
        Rig rig = DirtColumn();
        rig.Client.Inventory.SetInventorySlot(0, new ItemStack(Item.Stick, 2));
        rig.Player.Input = new PlayerInput(Forward: true);
        rig.Sent.Clear();
        rig.Keys.Drop.Press();
        rig.Keys.SwapOffhand.Press();
        Assert.That(rig.Sent, Is.Empty);
        rig.Tick();
        List<MinecraftPacket> sent = rig.Sent.Select(s => s.Packet).ToList();
        int swap = sent.FindIndex(p => p is ServerBoundPlayerActionPacket { ActionStatus: ServerBoundPlayerActionPacket.Status.SwapItem });
        int drop = sent.FindIndex(p => p is ServerBoundPlayerActionPacket { ActionStatus: ServerBoundPlayerActionPacket.Status.DropItem });
        int swing = sent.FindIndex(p => p is ServerBoundSwingArmPacket);
        int move = sent.FindIndex(p => p is ServerBoundSetPlayerPositionPacket or ServerBoundSetPlayerPosAndRotPacket);
        Assert.That(new[] { swap, drop, swing, move }, Is.Ordered.And.All.GreaterThanOrEqualTo(0));
        Assert.That(rig.Client.Inventory.MainHand.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestDroppingFromAnEmptyHandSendsTheDropWithoutASwing() {
        Rig rig = DirtColumn();
        rig.Sent.Clear();
        rig.Keys.Drop.Press();
        rig.Tick();
        Assert.That(rig.TicksOf(ServerBoundPlayerActionPacket.Status.DropItem), Has.Count.EqualTo(1));
        Assert.That(rig.TicksOf<ServerBoundSwingArmPacket>(), Is.Empty);
    }
}
