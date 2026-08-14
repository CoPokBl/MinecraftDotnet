using ManagedServer.Features.Basic;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Items;

namespace ManagedServer.Testing.Interaction;

/// <summary>
/// That a server which asked for nothing gets nothing out of a right click.
/// <p/>
/// The sibling of <c>BareServerTest</c>, and it exists for the same reason: the <c>useItemOn</c>
/// sequence lives in core rather than in a feature, and core doing something on its own is exactly
/// the mistake that does not look like a bug. It looks like the framework being helpful.
/// <p/>
/// What core is allowed to do on a bare server is protocol bookkeeping and nothing else: tell the
/// client what the two blocks really are, and acknowledge the sequence. No block is placed, no
/// interaction runs, no item is consumed.
/// </summary>
[TestFixture]
public class BareInteractionTest {
    [Test]
    public void ASequenceWithNoListenersDoesNothing() {
        InteractionScene scene = new();
        scene.HoldMainHand(new ItemStack(Item.Stone, 64));
        scene.ClearSent();

        scene.RightClick(scene.Floor);

        Assert.Multiple(() => {
            Assert.That(scene.Server.BlockInteractionRules.IsEmpty, Is.True,
                "the interaction registry filled itself");
            Assert.That(scene.BlockAt(scene.Above).Air, Is.True, "a block was placed");
            Assert.That(scene.Player.GetItemInHand(Minecraft.Schemas.Hand.MainHand).Count,
                Is.EqualTo(64), "the item was consumed");
        });
    }

    /// <summary>
    /// Vanilla's <c>handleUseItemOn</c> ends with two unconditional block updates, for the clicked
    /// block and the one across the face that was clicked. That, not the acknowledgement, is what
    /// puts back a block the client predicted and the server did not place.
    /// </summary>
    [Test]
    public void TheClickedBlockAndTheOneAcrossItAreAlwaysResent() {
        InteractionScene scene = new();
        scene.ClearSent();

        scene.RightClick(scene.Floor);

        Assert.That(scene.CountSent<ClientBoundBlockUpdatePacket>(), Is.EqualTo(2));
    }

    /// <summary>
    /// Exactly one acknowledgement per packet, whatever happened. It used to be sent from the
    /// placement path, so a click that placed nothing and a click an interaction consumed both went
    /// unacknowledged and left the client's prediction open.
    /// </summary>
    [TestCase(false, false, TestName = "TheAckIsSentOnceOnABareServer")]
    [TestCase(true, false, TestName = "TheAckIsSentOnceOnASuccessfulPlace")]
    [TestCase(true, true, TestName = "TheAckIsSentOnceWhenAnInteractionConsumed")]
    public void TheAckIsSentOnceWhateverHappened(bool placing, bool consuming) {
        InteractionScene scene = placing
            ? new InteractionScene(new BlockPlacingFeature())
            : new InteractionScene();

        if (consuming) {
            scene.AddFeature(new InteractionScene.ChestOpeningFeature(Block.Chest));
            scene.Set(scene.Floor, Block.Chest);
        }

        scene.HoldMainHand(new ItemStack(Item.Stone, 64));
        scene.ClearSent();

        scene.RightClick(scene.Floor);

        Assert.That(scene.CountSent<ClientBoundAcknowledgeBlockChangePacket>(), Is.EqualTo(1));
    }

    /// <summary>
    /// A rejected placement is acknowledged too, and needs no bespoke rollback: the two block
    /// updates core always sends cover both cells the placement could have landed in, which is why
    /// <c>BlockPlacingFeature</c> no longer has a <c>Reject</c> of its own.
    /// </summary>
    [Test]
    public void ARejectedPlacementIsStillAcknowledgedAndCorrected() {
        InteractionScene scene = new(new BlockPlacingFeature());

        // Nothing placeable in hand, so the item stage passes without writing anything.
        scene.HoldMainHand(new ItemStack(Item.DiamondSword, 1));
        scene.ClearSent();

        scene.RightClick(scene.Floor);

        Assert.Multiple(() => {
            Assert.That(scene.BlockAt(scene.Above).Air, Is.True);
            Assert.That(scene.CountSent<ClientBoundAcknowledgeBlockChangePacket>(), Is.EqualTo(1));
            Assert.That(scene.CountSent<ClientBoundBlockUpdatePacket>(), Is.EqualTo(2));
        });
    }
}
