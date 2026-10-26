using ManagedServer.Features.Basic;
using ManagedServer.Interaction;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace ManagedServer.Testing.Interaction;

/// <summary>
/// That right clicking a block runs vanilla's sequence rather than telling everyone at once.
/// <p/>
/// The bug this exists for: holding a block and clicking a chest used to open the chest <b>and</b>
/// place the block, because <c>BlockPlacingFeature</c> and the chest handler were two listeners on
/// one uncancellable packet event and both always ran. Every case below is a branch of
/// <c>ServerPlayerGameMode.useItemOn</c>, and several of them look wrong until you read the method.
/// </summary>
[TestFixture]
public class BlockInteractionSequenceTest {
    private static InteractionScene.ChestOpeningFeature Chest() => new(Block.Chest);

    /// <summary>A scene with a chest on the floor and the player holding stone.</summary>
    private static (InteractionScene Scene, InteractionScene.ChestOpeningFeature Chest) WithChest() {
        InteractionScene.ChestOpeningFeature chest = Chest();
        InteractionScene scene = new(new BlockPlacingFeature(), chest);
        scene.Set(scene.Floor, Block.Chest);
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));
        return (scene, chest);
    }

    /// <summary>The reported bug. Before the sequence existed this placed the stone as well.</summary>
    [Test]
    public void AChestBeatsABlock() {
        (InteractionScene scene, InteractionScene.ChestOpeningFeature chest) = WithChest();

        scene.RightClick(scene.Floor);

        Assert.Multiple(() => {
            Assert.That(chest.Opened, Is.EqualTo(1), "the chest did not open");
            Assert.That(scene.BlockAt(scene.Above).Air, Is.True,
                "the block was placed as well as the chest opening");
        });
    }

    /// <summary>
    /// The sneak branch, and the only way to build against an interactive block.
    /// <c>isSecondaryUseActive() &amp;&amp; handsNotEmpty</c> skips the block entirely.
    /// </summary>
    [Test]
    public void SneakingWithAFullHandPlacesTheBlock() {
        (InteractionScene scene, InteractionScene.ChestOpeningFeature chest) = WithChest();
        scene.Crouch();

        scene.RightClick(scene.Floor);

        Assert.Multiple(() => {
            Assert.That(chest.Opened, Is.EqualTo(0), "the chest opened despite the crouch");
            Assert.That(scene.BlockAt(scene.Above).Identifier, Is.EqualTo(Block.Stone.Identifier));
        });
    }

    /// <summary>
    /// The clause that is easy to drop. The skip is an <c>AND</c>, so crouching with nothing in
    /// either hand still reaches the block: a crouching bare handed player opens a chest.
    /// </summary>
    [Test]
    public void SneakingWithEmptyHandsStillOpensTheChest() {
        (InteractionScene scene, InteractionScene.ChestOpeningFeature chest) = WithChest();
        scene.HoldMainHand(ItemStack.Air);
        scene.Crouch();

        scene.RightClick(scene.Floor);

        Assert.That(chest.Opened, Is.EqualTo(1));
    }

    /// <summary>
    /// The retry is gated on the main hand, and <c>ChestBlock</c> only overrides
    /// <c>useWithoutItem</c>, so an offhand click never reaches a chest at all and the block in the
    /// offhand goes down. Counterintuitive, and exactly what vanilla does.
    /// </summary>
    [Test]
    public void AnOffhandBlockIsPlacedRatherThanOpeningTheChest() {
        (InteractionScene scene, InteractionScene.ChestOpeningFeature chest) = WithChest();
        scene.HoldMainHand(ItemStack.Air);
        scene.HoldOffHand(new ItemStack(Item.Stone, 64));

        scene.RightClick(scene.Floor, Hand.OffHand);

        Assert.Multiple(() => {
            Assert.That(chest.Opened, Is.EqualTo(0), "the offhand reached useWithoutItem");
            Assert.That(scene.BlockAt(scene.Above).Identifier, Is.EqualTo(Block.Stone.Identifier));
        });
    }

    /// <summary>
    /// The test that catches reading the packet's own hand instead of both hands. Crouching with a
    /// full main hand skips the block for an <b>offhand</b> click too, because <c>handsNotEmpty</c>
    /// never looks at which hand the packet named.
    /// </summary>
    [Test]
    public void AFullMainHandStopsTheChestForTheOffhandToo() {
        (InteractionScene scene, InteractionScene.ChestOpeningFeature chest) = WithChest();
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));
        scene.HoldOffHand(ItemStack.Air);
        scene.Crouch();

        scene.RightClick(scene.Floor, Hand.OffHand);

        Assert.That(chest.Opened, Is.EqualTo(0),
            "handsNotEmpty read the offhand alone rather than both hands");
    }

    /// <summary>
    /// The whole point of the design: the answer does not depend on which feature registered first.
    /// Under the old shape the chest handler ran after <c>BlockPlacingFeature</c> and lost.
    /// </summary>
    [Test]
    public void AConsumingInteractionStopsThePlacementWhateverTheRegistrationOrder() {
        InteractionScene.ChestOpeningFeature chest = Chest();

        // Deliberately the wrong way round: placement first, interaction second.
        InteractionScene scene = new(new BlockPlacingFeature());
        scene.AddFeature(chest);
        scene.Set(scene.Floor, Block.Chest);
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));

        scene.RightClick(scene.Floor);

        Assert.Multiple(() => {
            Assert.That(chest.Opened, Is.EqualTo(1));
            Assert.That(scene.BlockAt(scene.Above).Air, Is.True,
                "registration order decided the outcome");
        });
    }

    /// <summary>
    /// An interaction that only passes still lets the item run, which is the other half of the
    /// sequence and the reason a plain floor can still be built on.
    /// </summary>
    [Test]
    public void APassingInteractionLetsTheBlockThrough() {
        InteractionScene scene = new(new BlockPlacingFeature(), Chest());
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));

        // Stone floor, no chest: nothing consumes the click.
        scene.RightClick(scene.Floor);

        Assert.That(scene.BlockAt(scene.Above).Identifier, Is.EqualTo(Block.Stone.Identifier));
    }

    /// <summary>
    /// A non block item reaches the interaction stage. Before the sequence existed the handler
    /// returned at the "this item has no corresponding block" check, so a chest could only ever be
    /// opened while holding something placeable.
    /// </summary>
    [Test]
    public void AToolStillOpensTheChest() {
        (InteractionScene scene, InteractionScene.ChestOpeningFeature chest) = WithChest();
        scene.HoldMainHand(new ItemStack(Item.DiamondSword, 1));

        scene.RightClick(scene.Floor);

        Assert.That(chest.Opened, Is.EqualTo(1));
    }
}
