using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Player;

/// <summary>
/// What the player's state does to the view: <c>isScoping</c>, <c>getFieldOfViewModifier</c>, the frozen
/// ticks behind the powder snow overlay, <c>getViewBlockingState</c>, and <c>getUseDuration</c>.
/// </summary>
public class LocalPlayerCameraTest {
    private const int Floor = 16;

    private static (MinecraftClient Client, LocalPlayer Player) World(Func<int, int, int, uint> blocks, ItemStack? held = null) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        for (int cx = -1; cx <= 1; cx++) {
            for (int cz = -1; cz <= 1; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    int baseY = level.MinY + i * 16;
                    biomes[i] = new ushort[64];
                    uint[] states = new uint[ClientSection.Volume];
                    for (int y = 0; y < 16; y++) {
                        for (int z = 0; z < 16; z++) {
                            for (int x = 0; x < 16; x++) {
                                states[y << 8 | z << 4 | x] = blocks(cx * 16 + x, baseY + y, cz * 16 + z);
                            }
                        }
                    }
                    sections[i] = new ClientSection(states, level.IsAir);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }
        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        if (held != null) {
            client.Inventory.SetInventorySlot(0, held);
        }
        return (client, player);
    }

    /// <summary>A stone floor, with <paramref name="feet"/> where the player stands and <paramref name="head"/> above it.</summary>
    private static Func<int, int, int, uint> StandingIn(uint feet = 0, uint head = 0) => (x, y, z) =>
        y < Floor ? Block.Stone.StateId
        : x == 0 && z == 0 && y == Floor ? feet
        : x == 0 && z == 0 && y == Floor + 1 ? head
        : 0;

    /// <summary>One <c>Minecraft.tick</c> with the use button held.</summary>
    private static void HoldUse(MinecraftClient client, int ticks) {
        for (int i = 0; i < ticks; i++) {
            client.Interactions.Keys.Use.SetDown(true);
            client.Interactions.Tick();
            client.Tick();
        }
    }

    [Test]
    public void ASpyglassInUseScopesForTwelveHundredTicks() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(), new ItemStack(Item.Spyglass, 1));
        Assert.That(player.IsScoping, Is.False);
        HoldUse(client, 1);
        Assert.That(player.IsScoping, Is.True);
        Assert.That(player.UseDuration, Is.EqualTo(1200));
        Assert.That(player.UseItemRemainingTicks, Is.EqualTo(1199));
        Assert.That(player.TicksUsingItem, Is.EqualTo(1));
    }

    /// <summary><c>SpyglassItem.ZOOM_FOV_MODIFIER</c>, in first person only, whatever the effect scale.</summary>
    [Test]
    public void ScopingNarrowsTheFirstPersonViewToATenth() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(), new ItemStack(Item.Spyglass, 1));
        HoldUse(client, 1);
        Assert.That(player.FieldOfViewModifier(true, 1.0F), Is.EqualTo(0.1F));
        Assert.That(player.FieldOfViewModifier(true, 0.0F), Is.EqualTo(0.1F));
        Assert.That(player.FieldOfViewModifier(false, 1.0F), Is.EqualTo(1.0F));
    }

    /// <summary>Movement speed 0.1 over walking speed 0.1, averaged with 1: no change.</summary>
    [Test]
    public void StandingStillLeavesTheViewAlone() {
        (_, LocalPlayer player) = World(StandingIn());
        Assert.That(player.FieldOfViewModifier(true, 1.0F), Is.EqualTo(1.0F));
    }

    /// <summary>
    /// Sprinting is 0.1 times 1.3, over the walking speed 0.1: (1.3 + 1) / 2 = 1.15. Flying multiplies 1.1
    /// in, and the effect scale lerps from 1 towards the modifier.
    /// </summary>
    [Test]
    public void SprintingAndFlyingWidenTheView() {
        (_, LocalPlayer player) = World(StandingIn());
        player.SetSprinting(true);
        Assert.That(player.FieldOfViewModifier(true, 1.0F), Is.EqualTo(1.15F).Within(1e-6));
        Assert.That(player.FieldOfViewModifier(true, 0.5F), Is.EqualTo(1.075F).Within(1e-6));
        Assert.That(player.FieldOfViewModifier(true, 0.0F), Is.EqualTo(1.0F));
        player.Flying = true;
        Assert.That(player.FieldOfViewModifier(true, 1.0F), Is.EqualTo(1.265F).Within(1e-6));
    }

    /// <summary>Ten ticks of a bow's pull is half of twenty: 1 - 0.5 squared times 0.15 = 0.9625.</summary>
    [Test]
    public void DrawingABowNarrowsTheView() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(), new ItemStack(Item.Bow, 1));
        HoldUse(client, 10);
        Assert.That(player.TicksUsingItem, Is.EqualTo(10));
        Assert.That(player.FieldOfViewModifier(true, 1.0F), Is.EqualTo(0.9625F).Within(1e-6));
        HoldUse(client, 30);
        Assert.That(player.FieldOfViewModifier(true, 1.0F), Is.EqualTo(0.85F).Within(1e-6));
    }

    [Test]
    public void UseDurationsAreTheItemsOwn() {
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Spyglass, 1)), Is.EqualTo(1200));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Brush, 1)), Is.EqualTo(200));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Bundle, 1)), Is.EqualTo(200));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.RedBundle, 1)), Is.EqualTo(200));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Bow, 1)), Is.EqualTo(72000));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Crossbow, 1)), Is.EqualTo(72000));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Shield, 1)), Is.EqualTo(72000));
        // The ponder horn's use_duration is 7 seconds.
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.GoatHorn, 1)), Is.EqualTo(140));
        // Food's consume_seconds is 1.6 by default.
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Bread, 1)), Is.EqualTo(32));
        Assert.That(UsePrediction.UseDuration(new ItemStack(Item.Stone, 1)), Is.Zero);
    }

    [Test]
    public void PercentFrozenIsTheTicksOverOneHundredAndForty() {
        (_, LocalPlayer player) = World(StandingIn());
        Assert.That(player.TicksFrozen, Is.Zero);
        Assert.That(player.PercentFrozen, Is.Zero);
        player.Metadata[EntityDataFields.Entity.TicksFrozen.Index] = new MetaField<int>(MetaFieldType.VarInt, 70);
        Assert.That(player.PercentFrozen, Is.EqualTo(0.5F));
        Assert.That(player.IsFullyFrozen, Is.False);
        player.Metadata[EntityDataFields.Entity.TicksFrozen.Index] = new MetaField<int>(MetaFieldType.VarInt, 300);
        Assert.That(player.PercentFrozen, Is.EqualTo(1.0F));
        Assert.That(player.IsFullyFrozen, Is.True);
    }

    /// <summary>The <c>FREEZE</c> effect runs on the client's copy too, a tick at a time up to the full freeze.</summary>
    [Test]
    public void PowderSnowFreezesATickAtATime() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.PowderSnow.StateId, Block.PowderSnow.StateId));
        client.Tick();
        Assert.That(player.TicksFrozen, Is.EqualTo(1));
        for (int i = 0; i < 200; i++) {
            client.Tick();
        }
        Assert.That(player.TicksFrozen, Is.EqualTo(140));
    }

    /// <summary><c>LivingEntity.canFreeze</c>: leather worn anywhere is <c>freeze_immune_wearables</c>.</summary>
    [Test]
    public void LeatherKeepsTheFrostOut() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.PowderSnow.StateId, Block.PowderSnow.StateId));
        client.Inventory.SetInventorySlot(39, new ItemStack(Item.LeatherHelmet, 1));
        client.Tick();
        Assert.That(player.TicksFrozen, Is.Zero);
    }

    /// <summary>Fire's <c>CLEAR_FREEZE</c> thaws the player at once.</summary>
    [Test]
    public void FireThaws() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(Block.Fire.StateId));
        player.Metadata[EntityDataFields.Entity.TicksFrozen.Index] = new MetaField<int>(MetaFieldType.VarInt, 100);
        client.Tick();
        Assert.That(player.TicksFrozen, Is.Zero);
    }

    [Test]
    public void EyesInStoneAreBlinded() {
        (_, LocalPlayer player) = World(StandingIn(head: Block.Stone.StateId));
        Assert.That(player.ViewBlockingState()?.Identifier, Is.EqualTo(Block.Stone.Identifier));
    }

    [Test]
    public void EyesInTheOpenSeeClearly() {
        (_, LocalPlayer player) = World(StandingIn());
        Assert.That(player.ViewBlockingState(), Is.Null);
    }

    /// <summary>A barrier blocks the view, but its render shape is invisible, so nothing is drawn.</summary>
    [Test]
    public void ABarrierDrawsNothingOverTheEyes() {
        (_, LocalPlayer player) = World(StandingIn(head: Block.Barrier.StateId));
        Assert.That(player.ViewBlockingState(), Is.Null);
    }

    /// <summary>Glass is <c>isViewBlocking(never)</c>.</summary>
    [Test]
    public void GlassDoesNotBlockTheView() {
        (_, LocalPlayer player) = World(StandingIn(head: Block.Glass.StateId));
        Assert.That(player.ViewBlockingState(), Is.Null);
    }

    /// <summary>
    /// The corners are 0.24 either side of the player's middle, so standing at x 0.3 the corners reach
    /// back to x 0.06 and forward to 0.54: still the one block. At 0.2 they reach into the block behind.
    /// </summary>
    [Test]
    public void TheCornersReachIntoTheNextBlock() {
        (_, LocalPlayer player) = World((x, y, z) => y < Floor ? Block.Stone.StateId : x == -1 && y == Floor + 1 ? Block.Stone.StateId : 0);
        player.Position = new Vec3d(0.3, Floor, 0.5);
        Assert.That(player.ViewBlockingState(), Is.Null);
        player.Position = new Vec3d(0.2, Floor, 0.5);
        Assert.That(player.ViewBlockingState()?.Identifier, Is.EqualTo(Block.Stone.Identifier));
    }

    [Test]
    public void ASpectatorIsNeverBlinded() {
        (MinecraftClient client, LocalPlayer player) = World(StandingIn(head: Block.Stone.StateId));
        player.GameMode = Minecraft.Schemas.GameMode.Spectator;
        client.Tick();
        Assert.That(player.ViewBlockingState(), Is.Null);
    }
}
