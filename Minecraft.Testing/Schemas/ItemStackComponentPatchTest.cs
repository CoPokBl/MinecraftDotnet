using Minecraft;
using Minecraft.Data.Components;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// The two halves of a stack's component patch: what it sets, and what it takes off the item's own
/// defaults. Removing one has to be visible to <see cref="ItemStack.Has{T}"/> as well as on the wire,
/// or a cosmetic shield would keep blocking on the server while doing nothing on the client.
/// </summary>
[TestFixture]
public class ItemStackComponentPatchTest {
    private static MinecraftRegistry Registry => VanillaRegistry.Data;

    [Test]
    public void TestItemDefaultsAreVisibleThroughTheStack() {
        ItemStack shield = new(Item.Shield);

        Assert.That(shield.Has(DataComponent.BlocksAttacks), Is.True);
        Assert.That(shield.Get(DataComponent.BlocksAttacks).BlockDelaySeconds, Is.EqualTo(0.25f));
    }

    [Test]
    public void TestWithoutHidesTheItemDefault() {
        ItemStack cosmetic = new ItemStack(Item.Shield).Without(DataComponent.BlocksAttacks);

        Assert.That(cosmetic.Has(DataComponent.BlocksAttacks), Is.False);
        Assert.That(cosmetic.GetOrNull(DataComponent.BlocksAttacks), Is.Null);
        Assert.Throws<KeyNotFoundException>(() => cosmetic.Get(DataComponent.BlocksAttacks));
    }

    /// <summary>
    /// A patch says either what a component is or that it is gone, never both, so the two calls have
    /// to undo each other rather than pile up.
    /// </summary>
    [Test]
    public void TestSettingAComponentBackTakesTheRemovalOff() {
        ItemStack shield = new ItemStack(Item.Shield)
            .Without(DataComponent.BlocksAttacks)
            .With(DataComponent.BlocksAttacks, BlocksAttacksComponent.Data.Default);

        Assert.That(shield.RemoveComponents, Is.Empty);
        Assert.That(shield.Has(DataComponent.BlocksAttacks), Is.True);
        Assert.That(shield.Get(DataComponent.BlocksAttacks).BlockDelaySeconds, Is.EqualTo(0f));
    }

    [Test]
    public void TestRemovingTwiceIsOneRemoval() {
        ItemStack cosmetic = new ItemStack(Item.Shield)
            .Without(DataComponent.BlocksAttacks)
            .Without(DataComponent.BlocksAttacks);

        Assert.That(cosmetic.RemoveComponents, Has.Count.EqualTo(1));
    }

    /// <summary>The removal has to travel, since the client applies the item's defaults itself.</summary>
    [Test]
    public void TestRemovalRoundTripsThroughTheWire() {
        ItemStack cosmetic = new ItemStack(Item.Shield).Without(DataComponent.BlocksAttacks);

        DataWriter writer = new();
        cosmetic.WriteData(writer, Registry);
        ItemStack read = ItemStack.ReadData(new DataReader(writer.ToArray()), Registry);

        Assert.That(read.Type.Identifier, Is.EqualTo(Item.Shield.Identifier));
        Assert.That(read.RemoveComponents.Select(c => c.Identifier.ToString()),
            Is.EqualTo(new[] { "minecraft:blocks_attacks" }));
        Assert.That(read.Has(DataComponent.BlocksAttacks), Is.False);
    }

    /// <summary>
    /// The components added by a patch round trip through the same codec the client reads, which is
    /// what <c>Conformance/run.sh</c> checks against the vanilla one.
    /// </summary>
    [Test]
    public void TestBlocksAttacksRoundTripsThroughTheWire() {
        BlocksAttacksComponent.Data data = new(0.25f, 0.5f,
            [BlocksAttacksComponent.DamageReduction.Everything],
            new BlocksAttacksComponent.ItemDamage(3f, 1f, 1f),
            null, SoundType.ShieldBlock, null);

        DataWriter writer = new();
        DataComponent.BlocksAttacks.WriteData(data, writer, Registry);
        object read = DataComponent.BlocksAttacks.ReadData(new DataReader(writer.ToArray()), Registry);

        Assert.That(read, Is.InstanceOf<BlocksAttacksComponent.Data>());
        BlocksAttacksComponent.Data actual = (BlocksAttacksComponent.Data)read;
        Assert.That(actual.BlockDelaySeconds, Is.EqualTo(0.25f));
        Assert.That(actual.DisableCooldownScale, Is.EqualTo(0.5f));
        Assert.That(actual.DamageReductions, Is.EqualTo(data.DamageReductions));
        Assert.That(actual.ItemDamage, Is.EqualTo(data.ItemDamage));
        Assert.That(actual.BypassedBy, Is.Null);
        Assert.That(actual.BlockSound!.Value1!.Identifier, Is.EqualTo(SoundType.ShieldBlock.Identifier));
        Assert.That(actual.DisableSound, Is.Null);
    }

    [Test]
    public void TestWeaponRoundTripsThroughTheWire() {
        WeaponComponent.Data data = new(2, WeaponComponent.AxeDisablesBlockingForSeconds);

        DataWriter writer = new();
        DataComponent.Weapon.WriteData(data, writer, Registry);

        Assert.That(DataComponent.Weapon.ReadData(new DataReader(writer.ToArray()), Registry), Is.EqualTo(data));
    }

    /// <summary>The two that make an axe an axe, straight off the generated item.</summary>
    [Test]
    public void TestAxeCarriesTheDisableBlockingSeconds() {
        WeaponComponent.Data weapon = new ItemStack(Item.DiamondAxe).Get(DataComponent.Weapon);

        Assert.That(weapon.DisableBlockingForSeconds, Is.EqualTo(WeaponComponent.AxeDisablesBlockingForSeconds));
        Assert.That(new ItemStack(Item.DiamondSword).Get(DataComponent.Weapon).DisableBlockingForSeconds,
            Is.EqualTo(0f));
    }
}
