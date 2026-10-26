using ManagedServer.Entities.Types;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Block = Minecraft.Data.Generated.Block;
using Minecraft.Placement;

namespace ManagedServer.Interaction.Rules;

/// <summary>
/// The blocks that toggle a state when you click them: doors, trapdoors, fence gates, levers and
/// buttons. All five override <c>useWithoutItem</c> rather than <c>useItemOn</c>, so all five are
/// only reached through the <c>TRY_WITH_EMPTY_HAND</c> retry, which means none of them fires for an
/// offhand click and none of them fires while crouching with something in hand.
/// <p/>
/// <b>Sounds are missing on four of the five, deliberately.</b> A door, trapdoor, fence gate and
/// button take their open and close sounds from the <c>BlockSetType</c> or <c>WoodType</c> passed to
/// their constructor in <c>Blocks.java</c>. <c>Dumper.java</c> reflects over
/// <c>BlockBehaviour.Properties</c>, <c>BlockState</c> and <c>EntityType</c>, so it cannot see a
/// constructor argument on the block instance and there is no generated table to read them from.
/// Guessing the family from the block's name would be exactly the string match the codebase forbids.
/// The lever is the one that has its sound, because <c>SoundEvents.LEVER_CLICK</c> is a constant
/// rather than a per block value. Dumping <c>BlockSetType</c> is the fix and it also removes the hand
/// table in <see cref="OpensByHand"/>.
/// </summary>
internal static class OpenableInteractions {
    /// <summary>
    /// <c>BlockSetType.canOpenByHand</c>, which stops an iron door being opened by clicking it.
    /// <p/>
    /// This is a <b>hand table</b>, for the reason given on the class: the flag is a constructor
    /// argument. Of the seventeen block set types only <c>iron</c> and <c>gold</c> answer false, and
    /// gold is used by nothing but a weighted pressure plate, which has no interaction hook. So the
    /// whole of the false side of the table is these two blocks.
    /// <p/>
    /// A new block set type upstream that cannot be opened by hand would silently become openable
    /// here. <c>OpenableInteractionTableTest</c> is the backstop, on the same reasoning as
    /// <c>VegetationSupportTableTest</c>.
    /// </summary>
    internal static bool OpensByHand(IBlock block) {
        return !IBlock.SimilarTo(block, Block.IronDoor) && !IBlock.SimilarTo(block, Block.IronTrapdoor);
    }

    /// <summary>
    /// <c>Level.playSound(player, ...)</c>, which sends to everyone <b>except</b> the player who
    /// caused it: their own client predicted the interaction and has already played it, so sending it
    /// back would play it twice.
    /// </summary>
    internal static void PlaySoundToOthers(World world, Player except, Vec3<int> pos, ISoundType sound,
        float volume, float pitch) {
        Vec3<double> at = new(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5);
        foreach (Player viewer in world.GetViewersOf(at)) {
            if (ReferenceEquals(viewer, except)) {
                continue;
            }

            viewer.PlaySound(sound, at, SoundCategory.Blocks, volume, pitch);
        }
    }
}

/// <summary>
/// <c>DoorBlock</c>. Covers all 21 doors, the copper ones and their waxed forms included.
/// </summary>
public sealed class DoorInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.DoorBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {
        if (!OpenableInteractions.OpensByHand(block)) {
            return InteractionResult.Pass;
        }

        if (block is not IOpenable door) {
            return InteractionResult.Pass;
        }

        // state.cycle(OPEN), then setBlock with vanilla's literal 10: tell the clients and re-render
        // at once, but do NOT run the neighbour change pass. The other half of the door still follows,
        // because 10 does not carry KnownShape and so the shape cascade runs and DoorBlock's own
        // updateShape copies OPEN across from the half that changed.
        IBlock opened = door.WithOpen(!door.Open);
        world.SetBlock(pos, opened, flags: BlockUpdateFlags.Clients | BlockUpdateFlags.Immediate);

        // playSound is missing here: see OpenableInteractions. level.gameEvent is not modelled at all.
        return InteractionResult.Success;
    }
}

/// <summary>
/// <c>TrapDoorBlock</c>. Covers all 21 trapdoors.
/// </summary>
public sealed class TrapDoorInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.TrapDoorBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {
        if (!OpenableInteractions.OpensByHand(block)) {
            return InteractionResult.Pass;
        }

        if (block is not IOpenable trapdoor) {
            return InteractionResult.Pass;
        }

        // Note the flags: TrapDoorBlock.toggle passes 2, not the 10 DoorBlock passes. A trapdoor has
        // no second half to keep in step, so it only needs the clients told.
        IBlock toggled = trapdoor.WithOpen(!trapdoor.Open);
        world.SetBlock(pos, toggled, flags: BlockUpdateFlags.Clients);

        // Vanilla also re-schedules the water tick when the trapdoor is waterlogged, so the fluid
        // recomputes around the new shape. There is no way to schedule a fluid tick from outside
        // FluidSimulation, and LiquidsFeature is opt in, so that is skipped: a waterlogged trapdoor
        // toggles without the water around it being re-examined until something else disturbs it.
        return InteractionResult.Success;
    }
}

/// <summary>
/// <c>FenceGateBlock</c>. Covers all 12 fence gates.
/// </summary>
public sealed class FenceGateInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.FenceGateBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {
        if (block is not IOpenable gate) {
            return InteractionResult.Pass;
        }

        IBlock state;
        if (gate.Open) {
            state = gate.WithOpen(false);
        }
        else {
            // Opening a gate that faces away from you turns it round first, so it always swings away
            // rather than through you. Vanilla only rewrites FACING when it is the exact opposite of
            // the player's direction, not whenever the two differ.
            Direction facing = Directions.FromYRot(player.Yaw.DegreesF);
            IBlock turned = block is IHorizontalFacing gated && gated.Facing == facing.Opposite()
                ? gated.WithFacing(facing)
                : block;

            state = ((IOpenable)turned).WithOpen(true);
        }

        world.SetBlock(pos, state, flags: BlockUpdateFlags.Clients | BlockUpdateFlags.Immediate);
        return InteractionResult.Success;
    }
}

/// <summary>
/// <c>LeverBlock</c>, whose <c>useWithoutItem</c> is <c>pull</c> on the server side.
/// </summary>
public sealed class LeverInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.LeverBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {
        if (block is not IPowered lever) {
            return InteractionResult.Pass;
        }

        // pull(): cycle(POWERED), setBlock 3, updateNeighbours, playSound. Flags 3 here, unlike the
        // door's 10, because a lever's whole purpose is the neighbour change pass. That pass is inert
        // without a redstone engine, so the flag is transcribed and currently does nothing;
        // updateNeighbours is the same story and is what Placement/Redstone.cs already stands in for.
        IBlock flipped = lever.WithPowered(!lever.Powered);
        world.SetBlock(pos, flipped, flags: BlockUpdateFlags.NeighborUpdates | BlockUpdateFlags.Clients);

        OpenableInteractions.PlaySoundToOthers(world, player, pos, SoundType.LeverClick, 0.3f,
            ((IPowered)flipped).Powered ? 0.6f : 0.5f);
        return InteractionResult.Success;
    }
}

/// <summary>
/// <c>ButtonBlock</c>. Covers all 14 buttons.
/// <p/>
/// <b>A pressed button never un-presses.</b> <c>press()</c> ends with
/// <c>level.scheduleTick(pos, this, ticksToStayPressed)</c> and there is no block tick scheduler, the
/// same gap the placement rules already document. Vanilla's own click while pressed answers
/// <c>CONSUME</c> and does nothing, which is transcribed, so the button ends up permanently down
/// rather than flickering. Doing it inline on a scheduler here would be inventing behaviour the rest
/// of the port does not have; when a block tick scheduler exists this becomes one line.
/// </summary>
public sealed class ButtonInteractionRule : IBlockInteractionRule {
    public BlockClass VanillaClass => BlockClass.ButtonBlock;

    public InteractionResult UseWithoutItem(IBlock block, World world, Vec3<int> pos, Player player,
        BlockHit hit) {
        if (block is not IPowered button) {
            return InteractionResult.Pass;
        }

        // Already pressed: vanilla consumes the click without doing anything, so the click does not
        // fall through to the held item either. CONSUME rather than SUCCESS, so there is no swing.
        if (button.Powered) {
            return InteractionResult.Consume;
        }

        world.SetBlock(pos, button.WithPowered(true),
            flags: BlockUpdateFlags.NeighborUpdates | BlockUpdateFlags.Clients);
        return InteractionResult.Success;
    }
}
