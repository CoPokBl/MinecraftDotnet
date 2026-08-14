using ManagedServer.Features.Basic;
using ManagedServer.Interaction;
using ManagedServer.Interaction.Rules;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace ManagedServer.Testing.Interaction;

/// <summary>
/// What the vanilla interaction rules actually answer, block by block.
/// <p/>
/// These go through the whole sequence rather than calling a rule, because most of what makes a rule
/// correct is which stage it is reached on: every rule here except the candle overrides
/// <c>useWithoutItem</c>, so all of them inherit the sneak rule and the main hand only retry from
/// <see cref="BlockInteraction"/>, and calling them directly would not measure that.
/// </summary>
[TestFixture]
public class VanillaBlockInteractionsTest {
    private static InteractionScene Vanilla() => new(new VanillaBlockInteractionsFeature());

    [Test]
    public void ADoorOpensAndCloses() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.OakDoor);
        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False, "the door started open");

        scene.RightClick(scene.Above);
        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.True, "the door did not open");

        scene.RightClick(scene.Above);
        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False, "the door did not close");
    }

    /// <summary>
    /// <c>BlockSetType.IRON.canOpenByHand()</c> is false. Nothing else in the game answers false for
    /// a block with an interaction hook, which is why <c>OpenableInteractions.OpensByHand</c> is two
    /// entries rather than a dumped table.
    /// </summary>
    [Test]
    public void AnIronDoorDoesNotOpenByHand() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.IronDoor);

        scene.RightClick(scene.Above);

        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False);
    }

    [Test]
    public void AnIronTrapdoorDoesNotOpenByHand() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.IronTrapdoor);

        scene.RightClick(scene.Above);

        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False);
    }

    [Test]
    public void ATrapdoorToggles() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.OakTrapdoor);

        scene.RightClick(scene.Above);

        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.True);
    }

    [Test]
    public void AFenceGateToggles() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.OakFenceGate);

        scene.RightClick(scene.Above);
        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.True);

        scene.RightClick(scene.Above);
        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False);
    }

    [Test]
    public void ALeverFlips() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.Lever);

        scene.RightClick(scene.Above);
        Assert.That(((IPowered)scene.BlockAt(scene.Above)).Powered, Is.True);

        scene.RightClick(scene.Above);
        Assert.That(((IPowered)scene.BlockAt(scene.Above)).Powered, Is.False);
    }

    /// <summary>
    /// A button presses and, with no block tick scheduler, stays pressed. The second click answers
    /// <c>CONSUME</c>, which is vanilla, so the click is still swallowed rather than falling through
    /// to the held item.
    /// </summary>
    [Test]
    public void AButtonPressesAndStaysPressed() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.StoneButton);

        scene.RightClick(scene.Above);
        Assert.That(((IPowered)scene.BlockAt(scene.Above)).Powered, Is.True);

        scene.RightClick(scene.Above);
        Assert.That(((IPowered)scene.BlockAt(scene.Above)).Powered, Is.True,
            "the second click un-pressed it, which needs a scheduler that does not exist");
    }

    /// <summary>
    /// A pressed button consumes the click, so a block held at the time is not placed against it.
    /// This is the branch that would be lost by answering <c>Pass</c> instead of <c>Consume</c>.
    /// </summary>
    [Test]
    public void APressedButtonStillSwallowsTheClick() {
        InteractionScene scene = new(new VanillaBlockInteractionsFeature(), new BlockPlacingFeature());
        scene.Set(scene.Above, ((IPowered)Block.StoneButton).WithPowered(true));
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));

        scene.RightClick(scene.Above, face: Minecraft.Schemas.BlockFace.NegY);

        Assert.That(scene.BlockAt(scene.Floor).Identifier, Is.EqualTo(Block.Stone.Identifier),
            "the floor should be untouched stone, not replaced");
    }

    /// <summary>
    /// The rules inherit the sneak branch from the sequence rather than each checking for it, so a
    /// crouching player with a block in hand builds against a door instead of opening it.
    /// </summary>
    [Test]
    public void CrouchingWithABlockDoesNotOpenADoor() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.OakDoor);
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));
        scene.Crouch();

        scene.RightClick(scene.Above);

        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False);
    }

    /// <summary>
    /// Doors override <c>useWithoutItem</c>, and that retry never runs for the offhand, so an
    /// offhand click does not open one.
    /// </summary>
    [Test]
    public void AnOffhandClickDoesNotOpenADoor() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, Block.OakDoor);

        scene.RightClick(scene.Above, Minecraft.Schemas.Hand.OffHand);

        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False);
    }

    /// <summary>
    /// The candle is the one rule on the <c>useItemOn</c> stage, and it only puts a candle out: it
    /// needs a bare hand, so holding anything leaves it lit.
    /// </summary>
    [Test]
    public void ALitCandleIsPutOutByABareHand() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, ((ILit)Block.Candle).WithLit(true));

        scene.RightClick(scene.Above);

        Assert.That(((ILit)scene.BlockAt(scene.Above)).Lit, Is.False);
    }

    [Test]
    public void ACandleIsNotPutOutWithSomethingInHand() {
        InteractionScene scene = Vanilla();
        scene.Set(scene.Above, ((ILit)Block.Candle).WithLit(true));
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));

        scene.RightClick(scene.Above);

        Assert.That(((ILit)scene.BlockAt(scene.Above)).Lit, Is.True);
    }

    /// <summary>Nothing is registered until the feature is, which is the opt in property.</summary>
    [Test]
    public void ADoorDoesNothingWithoutTheFeature() {
        InteractionScene scene = new();
        scene.Set(scene.Above, Block.OakDoor);

        scene.RightClick(scene.Above);

        Assert.That(((IOpenable)scene.BlockAt(scene.Above)).Open, Is.False);
    }

    /// <summary>
    /// One rule per vanilla class, and resolution walks the class chain, so a single
    /// <c>DoorBlock</c> rule speaks for every door including the copper ones that weather.
    /// </summary>
    [Test]
    public void OneRuleCoversEveryDoor() {
        InteractionScene scene = Vanilla();

        foreach (IBlock door in new IBlock[] {
                     Block.OakDoor, Block.WarpedDoor, Block.BambooDoor,
                     Block.CopperDoor, Block.WaxedOxidizedCopperDoor
                 }) {
            Assert.That(scene.Server.BlockInteractionRules.For(door, scene.World),
                Is.InstanceOf<DoorInteractionRule>(), door.Identifier.ToString());
        }
    }
}
