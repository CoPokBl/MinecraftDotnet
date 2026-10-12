using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

using Minecraft.Data.Generated;

namespace Minecraft.Placement;

/// <summary>
/// What one vanilla block class does about being placed, and about its neighbours changing.
/// <p/>
/// One rule per vanilla class, named after it, transcribing that class's overrides. The patterns the
/// classes share (waterlogging, the half from the click point, the attachment search) are helpers in
/// <c>Minecraft.Placement.Helpers</c> that the transcriptions call, exactly as vanilla shares
/// them: by copying the line, not by composing objects. That is deliberate. Vanilla has a single
/// <c>getStateForPlacement</c> per block, so modelling the shared lines as separately registered
/// rules would need an ordering between them that vanilla does not have.
/// <p/>
/// Every member is defaulted, so a rule writes only what its class actually overrides. A block with
/// no rule at all places its default state, which is what <c>Block.getStateForPlacement</c> does.
/// </summary>
public interface IBlockPlacementRule {
    /// <summary>
    /// The vanilla class this transcribes, its simple name (<c>StairBlock</c>, <c>SlabBlock</c>).
    /// <p/>
    /// Resolution walks the block's class chain from <c>BlockClasses</c> nearest first and takes the
    /// first class with a rule, which is Java's own virtual dispatch: a rule on
    /// <c>FaceAttachedHorizontalDirectionalBlock</c> covers buttons and levers because that is where
    /// vanilla's override lives, and one on <c>BaseRailBlock</c> covers all three rails.
    /// </summary>
    public BlockClass VanillaClass { get; }

    /// <summary>
    /// <c>Block.getStateForPlacement</c>: the state to place, or null to refuse. A door returns null
    /// when there is no room above it, and an attachable block returns null when nothing it could
    /// attach to survives.
    /// </summary>
    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) => block;

    /// <summary>
    /// <c>BlockBehaviour.canBeReplaced(state, context)</c>, asked of the block <b>already there</b>,
    /// not of the one being placed. This is what doubles a slab and what stacks a candle.
    /// <p/>
    /// The default is vanilla's: replaceable, and not being clicked with its own item. That second
    /// clause is what stops clicking grass with grass doing nothing at all.
    /// </summary>
    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        return DefaultCanBeReplaced(existing, context);
    }

    /// <summary>
    /// <c>BlockBehaviour.canSurvive</c>: whether the state can exist at that position. Checked at
    /// placement, and again by every shape update, which is how a torch falls off a wall that goes.
    /// </summary>
    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) => true;

    /// <summary>
    /// <c>BlockBehaviour.updateShape</c>: the state this block becomes now that the neighbour across
    /// <paramref name="toNeighbour"/> has changed. Returning an air block destroys it.
    /// <p/>
    /// A fence recomputes exactly the one side that changed, and a stair recomputes its corner. This
    /// has to agree with the same rule's <see cref="GetStateForPlacement"/> or a block will change
    /// the instant anything is placed beside it.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) => block;

    /// <summary>
    /// <c>Block.setPlacedBy</c>, run after the block is in the world. Where the second half of a door
    /// or a bed is written, so it happens after the first half exists.
    /// </summary>
    public void OnPlaced(IBlock placed, IBlockPlaceContext context) { }

    /// <summary>
    /// <c>BlockBehaviour.canBeReplaced(state, context)</c>'s default body, exposed so a rule that
    /// only widens it can still fall back to it.
    /// </summary>
    public static bool DefaultCanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        return existing.Replaceable
               && (context.ItemInHand.IsAir() || context.ItemInHand.Type.Identifier != existing.Item);
    }
}
