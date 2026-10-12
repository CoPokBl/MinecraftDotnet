using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;

namespace ClientLib.Testing.Player;

/// <summary>
/// <c>LocalPlayer</c>'s item use against vanilla's movement rules: an item in use scales the input by
/// its <c>use_effects</c> speed multiplier and keeps a sprint from starting unless it says
/// <c>can_sprint</c>. Speeds are the fixed points of <c>v = (v + a) * f</c>, as in the movement tests.
/// </summary>
public class LocalPlayerItemUseTest {
    private const int Floor = 16;
    private const double WalkSpeed = 4.317;
    private const double SprintSpeed = 5.612;

    private static (MinecraftClient Client, LocalPlayer Player) FlatWorld(ItemStack held) {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        ClientLevel level = new(VanillaRegistry.Data, "minecraft:overworld",
            VanillaRegistry.Data.DimensionTypes["minecraft:overworld"], 63, true, 0);
        ushort stone = (ushort)Block.Stone.StateId;
        for (int cx = -4; cx <= 4; cx++) {
            for (int cz = -4; cz <= 4; cz++) {
                ClientSection[] sections = new ClientSection[level.SectionCount];
                ushort[][] biomes = new ushort[level.SectionCount][];
                for (int i = 0; i < sections.Length; i++) {
                    biomes[i] = new ushort[64];
                    sections[i] = level.MinY + i * 16 < Floor ? new ClientSection(stone, false) : new ClientSection(0, true);
                }
                level.AddChunk(new ClientChunk(cx, cz, sections, biomes));
            }
        }

        LocalPlayer player = client.StartOffline(level);
        player.Position = new Vec3d(0.5, Floor, 0.5);
        // Hungry, so food can be eaten at all.
        player.Food = 10;
        client.Inventory.SetInventorySlot(0, held);
        Tick(client, player, PlayerInput.None, false, 2);
        return (client, player);
    }

    /// <summary>One <c>Minecraft.tick</c>: the use button as the host passes it, then the player's tick.</summary>
    private static void Tick(MinecraftClient client, LocalPlayer player, PlayerInput input, bool useHeld, int ticks) {
        for (int i = 0; i < ticks; i++) {
            player.Input = input;
            client.Interactions.Keys.Use.SetDown(useHeld);
            client.Interactions.Tick();
            client.Tick();
        }
    }

    private static double Speed(MinecraftClient client, LocalPlayer player, PlayerInput input, bool useHeld) {
        Vec3d before = player.Position;
        Tick(client, player, input, useHeld, 1);
        return Math.Sqrt((player.Position - before).HorizontalDistanceSqr()) * 20;
    }

    private static readonly PlayerInput SprintForward = new(Forward: true, Sprint: true);

    [Test]
    public void HoldingUseStartsUsingAnItem() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        Tick(client, player, PlayerInput.None, true, 1);
        Assert.That(player.IsUsingItem, Is.True);
        Assert.That(client.Interactions.UsingItem, Is.EqualTo(Hand.MainHand));
        // Started and ticked once: getUseDuration less the one updatingUsingItem took.
        Assert.That(player.UseItemRemainingTicks, Is.EqualTo(31));
    }

    [Test]
    public void FoodIsNotEatenWhenFull() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        player.Food = 20;
        Tick(client, player, PlayerInput.None, true, 1);
        Assert.That(player.IsUsingItem, Is.False);
    }

    [Test]
    public void FoodThatCanAlwaysBeEatenIsEatenWhenFull() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.GoldenApple, 1));
        player.Food = 20;
        Tick(client, player, PlayerInput.None, true, 1);
        Assert.That(player.IsUsingItem, Is.True);
    }

    [Test]
    public void AnInvulnerablePlayerEatsWhenFull() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        player.Food = 20;
        player.Invulnerable = true;
        Tick(client, player, PlayerInput.None, true, 1);
        Assert.That(player.IsUsingItem, Is.True);
    }

    [Test]
    public void SprintCannotStartWhileUsingAnItem() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        Tick(client, player, SprintForward, true, 20);
        Assert.That(player.IsUsingItem, Is.True);
        Assert.That(player.Sprinting, Is.False);
    }

    /// <summary>
    /// <c>shouldStopRunSprinting</c> has no item use term, so a sprint that began before the use goes on,
    /// at the sprinting speed scaled by the item's multiplier.
    /// </summary>
    [Test]
    public void SprintStartedBeforeTheUseCarriesOn() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        Tick(client, player, SprintForward, false, 30);
        Assert.That(player.Sprinting, Is.True);
        Tick(client, player, SprintForward, true, 60);
        Assert.That(player.IsUsingItem, Is.True);
        Assert.That(player.Sprinting, Is.True);
        Assert.That(Speed(client, player, SprintForward, true), Is.EqualTo(SprintSpeed * 0.2).Within(0.001));
    }

    [Test]
    public void UsingAnItemScalesTheInputByItsMultiplier() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        PlayerInput forward = new(Forward: true);
        Tick(client, player, forward, true, 60);
        Assert.That(Speed(client, player, forward, true), Is.EqualTo(WalkSpeed * 0.2).Within(0.001));
    }

    [Test]
    public void UseEffectsSpeedMultiplierIsRead() {
        ItemStack bread = new ItemStack(Item.Bread, 4).With(DataComponent.UseEffects, new UseEffectsComponent.Data(SpeedMultiplier: 0.5F));
        (MinecraftClient client, LocalPlayer player) = FlatWorld(bread);
        PlayerInput forward = new(Forward: true);
        Tick(client, player, forward, true, 60);
        Assert.That(Speed(client, player, forward, true), Is.EqualTo(WalkSpeed * 0.5).Within(0.001));
    }

    /// <summary>A spear's <c>use_effects</c> is <c>can_sprint</c> at full speed.</summary>
    [Test]
    public void CanSprintItemKeepsSprint() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.IronSpear));
        Tick(client, player, SprintForward, true, 60);
        Assert.That(player.IsUsingItem, Is.True);
        Assert.That(player.Sprinting, Is.True);
        Assert.That(Speed(client, player, SprintForward, true), Is.EqualTo(SprintSpeed).Within(0.001));
    }

    [Test]
    public void ReleasingUseRestoresMovement() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        Tick(client, player, SprintForward, true, 20);
        Tick(client, player, SprintForward, false, 60);
        Assert.That(player.IsUsingItem, Is.False);
        Assert.That(player.Sprinting, Is.True);
        Assert.That(Speed(client, player, SprintForward, false), Is.EqualTo(SprintSpeed).Within(0.001));
    }

    /// <summary>The client never completes a use itself: the count runs past zero until the server's event 9.</summary>
    [Test]
    public void UseOutlastsItsDurationUntilTheServerCompletesIt() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        Tick(client, player, PlayerInput.None, true, 40);
        Assert.That(player.IsUsingItem, Is.True);
        Assert.That(player.UseItemRemainingTicks, Is.EqualTo(32 - 40));
        player.CompleteUsingItem();
        Assert.That(player.IsUsingItem, Is.False);
        Assert.That(player.UseItem.IsAir(), Is.True);
    }

    /// <summary><c>updatingUsingItem</c> stops a use whose hand no longer holds that item.</summary>
    [Test]
    public void SwitchingSlotStopsTheUse() {
        (MinecraftClient client, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        client.Inventory.SetInventorySlot(1, new ItemStack(Item.Stone, 1));
        Tick(client, player, PlayerInput.None, true, 5);
        Assert.That(player.IsUsingItem, Is.True);
        client.Inventory.SelectedSlot = 1;
        client.Tick();
        Assert.That(player.IsUsingItem, Is.False);
    }

    [Test]
    public void ServerFlagsStartAndStopTheUse() {
        (_, LocalPlayer player) = FlatWorld(new ItemStack(Item.Bread, 4));
        int index = EntityDataFields.LivingEntity.LivingEntityFlags.Index;
        player.Metadata[index] = new MetaField<sbyte>(MetaFieldType.Byte, 1);
        player.OnSyncedDataUpdated(index);
        Assert.That(player.IsUsingItem, Is.True);
        Assert.That(player.UsedItemHand, Is.EqualTo(Hand.MainHand));
        player.Metadata[index] = new MetaField<sbyte>(MetaFieldType.Byte, 0);
        player.OnSyncedDataUpdated(index);
        Assert.That(player.IsUsingItem, Is.False);
    }
}
