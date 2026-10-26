using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// <c>MultifaceBlock</c>: glow lichen, sculk vein, resin clump. One block occupying up to six faces
/// of the same cell, so placing one twice adds a face rather than replacing anything.
/// <p/>
/// Three hooks work together and none of them makes sense alone. <c>canBeReplaced</c> says yes to its
/// own item while any face is still vacant, which is what routes the second placement back into the
/// same cell; <c>getStateForPlacement</c> then reads the state that is already there and adds a face
/// to it; and <c>updateShape</c> takes faces away and turns the block to air when the last one goes.
/// </summary>
public class MultifacePlacementRule : IBlockPlacementRule {
    public virtual BlockClass VanillaClass => BlockClass.MultifaceBlock;

    /// <summary>
    /// Vanilla's <c>isFaceSupported</c>, true for all six here. It is a hook because
    /// <c>ResinClumpBlock</c> and friends could narrow it, and nothing in 26.2 does.
    /// </summary>
    protected virtual bool IsFaceSupported(BlockFace face) => true;

    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        bool sameItem = !context.ItemInHand.IsAir()
                        && context.ItemInHand.Type.Identifier == existing.Item;
        return !sameItem || HasAnyVacantFace(existing);
    }

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock oldState = context.World.GetBlock(context.PlacePos);

        foreach (BlockFace face in context.NearestLookingDirections) {
            IBlock? state = ForFace(block, oldState, context.World, context.PlacePos, face);
            if (state is not null) {
                return state;
            }
        }

        return null;
    }

    /// <summary>
    /// <c>getStateForPlacement(oldState, level, pos, direction)</c>, also reachable from outside so
    /// the growth code can use it. Null when that face is taken or has nothing behind it.
    /// </summary>
    private IBlock? ForFace(IBlock block, IBlock oldState, IPlacementLevel world, Vec3<int> pos, BlockFace face) {
        bool sameBlock = IBlock.SimilarTo(oldState, block);
        if (!IsFaceSupported(face)
            || (sameBlock && ((IFaceConnected)oldState).Connected(face))
            || !PlacementHelpers.CanAttachTo(world, pos, face)) {
            return null;
        }

        IBlock newState = block;
        if (sameBlock) {
            newState = oldState;
        }
        else if (PlacementHelpers.IsWaterSourceAt(world, pos) && block is IWaterlogged waterloggable) {
            // A source, not merely water: a multiface block placed into a flow comes out dry.
            newState = waterloggable.WithWaterlogged(true);
        }

        return ((IFaceConnected)newState).WithConnection(face, true);
    }

    /// <summary>
    /// Every face it has must still have something behind it, and it must have at least one. The
    /// second half is what turns the last face going into a break.
    /// </summary>
    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        bool hasAtLeastOneFace = false;

        foreach (BlockFace face in Directions.All) {
            if (!((IFaceConnected)block).Connected(face)) {
                continue;
            }

            if (!PlacementHelpers.CanAttachTo(world, pos, face)) {
                return false;
            }

            hasAtLeastOneFace = true;
        }

        return hasAtLeastOneFace;
    }

    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (!HasAnyFace(block)) {
            return Block.Air;
        }

        if (!((IFaceConnected)block).Connected(toNeighbour)
            || PlacementHelpers.CanAttachTo(world, pos, toNeighbour)) {
            return block;
        }

        // removeFace: taking the last face off is a break, not an empty block.
        IBlock removed = ((IFaceConnected)block).WithConnection(toNeighbour, false);
        return HasAnyFace(removed) ? removed : Block.Air;
    }

    private static bool HasAnyFace(IBlock block) {
        foreach (BlockFace face in Directions.All) {
            if (((IFaceConnected)block).Connected(face)) {
                return true;
            }
        }

        return false;
    }

    private static bool HasAnyVacantFace(IBlock block) {
        if (block is not IFaceConnected faces) {
            return false;
        }

        foreach (BlockFace face in Directions.All) {
            if (!faces.Connected(face)) {
                return true;
            }
        }

        return false;
    }
}

/// <summary>
/// <c>VineBlock</c>. Multiface in spirit and a separate class in the jar, with three differences that
/// all matter: it has no <c>down</c> property at all, it will hang off a vine directly above it with
/// nothing else holding it, and its <c>canBeReplaced</c> counts faces rather than asking about the
/// state being placed.
/// </summary>
public sealed class VinePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.VineBlock;

    /// <summary>The five faces a vine has a property for: everything but down.</summary>
    private static readonly BlockFace[] Faces = [
        BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        IBlock clicked = context.World.GetBlock(context.HitPos);
        if (!IBlock.SimilarTo(clicked, existing) || clicked is not IFaceConnected faces) {
            return IBlockPlacementRule.DefaultCanBeReplaced(existing, context);
        }

        return CountFaces(faces) < Faces.Length;
    }

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock clicked = context.World.GetBlock(context.PlacePos);
        bool clickedVine = IBlock.SimilarTo(clicked, block);
        IBlock result = clickedVine ? clicked : block;

        foreach (BlockFace face in context.NearestLookingDirections) {
            if (face == BlockFace.NegY) {
                continue;
            }

            bool faceOccupied = clickedVine && ((IFaceConnected)clicked).Connected(face);
            if (!faceOccupied && CanSupportAtFace(block, context.World, context.PlacePos, face)) {
                return ((IFaceConnected)result).WithConnection(face, true);
            }
        }

        // Adding to a vine that is already full is allowed and changes nothing; anywhere else refuses.
        return clickedVine ? result : null;
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        IBlock updated = UpdatedState(block, world, pos);
        return updated is IFaceConnected faces && CountFaces(faces) > 0;
    }

    /// <summary>
    /// The down face falls through to the base <c>updateShape</c>, ie. nothing, because a vine has no
    /// down property to recompute. Every other face recomputes the whole state.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (toNeighbour == BlockFace.NegY) {
            return block;
        }

        IBlock updated = UpdatedState(block, world, pos);
        return updated is IFaceConnected faces && CountFaces(faces) > 0 ? updated : Block.Air;
    }

    /// <summary>
    /// <c>VineBlock.canSupportAtFace</c>. A horizontal face is also supported by a vine directly
    /// above occupying the same face, which is what lets a vine grow down a sheer wall past the
    /// bottom of the block it started on.
    /// </summary>
    private static bool CanSupportAtFace(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace face) {
        if (face == BlockFace.NegY) {
            return false;
        }

        if (PlacementHelpers.CanAttachTo(world, pos, face)) {
            return true;
        }

        if (face == BlockFace.PosY) {
            return false;
        }

        IBlock above = world.GetBlock(pos.WithY(pos.Y + 1));
        return IBlock.SimilarTo(above, block) && ((IFaceConnected)above).Connected(face);
    }

    /// <summary>
    /// <c>VineBlock.getUpdatedState</c>, transcribed with its asymmetry intact. The up face is
    /// rechecked with <c>isAcceptableNeighbour(above, DOWN)</c>, which asks the block above for its
    /// <b>up</b> face rather than its down face; placement asks the other way round through
    /// <see cref="CanSupportAtFace"/>. It is not a slip here, it is what the jar does, and it means a
    /// vine on the underside of a slab stays after being placed and could not have been placed there.
    /// </summary>
    private static IBlock UpdatedState(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        Vec3<int> abovePos = pos.WithY(pos.Y + 1);
        IBlock state = block;

        if (((IFaceConnected)state).Connected(BlockFace.PosY)) {
            bool keep = PlacementHelpers.CanAttachTo(world.GetBlock(abovePos), BlockFace.NegY);
            state = ((IFaceConnected)state).WithConnection(BlockFace.PosY, keep);
        }

        IBlock? above = null;
        foreach (BlockFace face in Directions.Horizontal) {
            if (!((IFaceConnected)state).Connected(face)) {
                continue;
            }

            bool canSupport = CanSupportAtFace(block, world, pos, face);
            if (!canSupport) {
                above ??= world.GetBlock(abovePos);
                canSupport = IBlock.SimilarTo(above, block) && ((IFaceConnected)above).Connected(face);
            }

            state = ((IFaceConnected)state).WithConnection(face, canSupport);
        }

        return state;
    }

    private static int CountFaces(IFaceConnected faces) {
        int count = 0;
        foreach (BlockFace face in Faces) {
            if (faces.Connected(face)) {
                count++;
            }
        }

        return count;
    }
}

/// <summary>
/// <c>MossyCarpetBlock</c>: pale moss carpet. A carpet with four climbing sides, where the sides know
/// whether the carpet above and below them has sides of its own.
/// <p/>
/// Two states of the same block behave differently: the one with <c>bottom</c> set is the carpet on
/// the ground, and the one without is the tuft that grows up a wall from it and only survives while
/// the base is under it.
/// </summary>
public sealed class MossyCarpetPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.MossyCarpetBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return UpdatedState(block, context.World, context.PlacePos, true);
    }

    /// <summary>
    /// <c>setPlacedBy</c>: the carpet grows its own tuft above, keeping each side with even odds.
    /// Vanilla uses the level's random; there is no world random here, so this takes
    /// <c>Random.Shared</c>, which is the same distribution and not the same sequence. Nothing
    /// depends on the sequence: the tuft is decoration and the client is told what was written.
    /// </summary>
    public void OnPlaced(IBlock placed, IBlockPlaceContext context) {
        if (context.World.IsClientSide) {
            return;
        }

        Vec3<int> above = context.PlacePos.WithY(context.PlacePos.Y + 1);
        IBlock topper = Topper(placed, context.World, context.PlacePos);
        if (!topper.Air) {
            context.World.SetBlock(above, topper);
        }
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        if (IsBase(block)) {
            return !below.Air;
        }

        return IBlock.SimilarTo(below, block) && IsBase(below);
    }

    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (!CanSurvive(block, world, pos)) {
            return Block.Air;
        }

        IBlock updated = UpdatedState(block, world, pos, false);
        return HasFaces(updated) ? updated : Block.Air;
    }

    /// <summary>
    /// <c>getUpdatedState</c>. A side exists where there is something to climb; it goes tall when the
    /// carpet above has the same side; and a tuft loses a side the base below does not have, which is
    /// what keeps a column of tufts the same width all the way up.
    /// </summary>
    private static IBlock UpdatedState(IBlock block, IPlacementLevel world, Vec3<int> pos, bool createSides) {
        IBlock? aboveState = null;
        IBlock? belowState = null;
        createSides |= IsBase(block);

        IBlock state = block;
        foreach (BlockFace face in Directions.Horizontal) {
            WallSide side = CanSupportAtFace(world, pos, face)
                ? createSides ? WallSide.Low : ((IWallConnected)state).Side(face)
                : WallSide.None;

            if (side == WallSide.Low) {
                aboveState ??= world.GetBlock(pos.WithY(pos.Y + 1));
                if (IBlock.SimilarTo(aboveState, block)
                    && ((IWallConnected)aboveState).Side(face) != WallSide.None
                    && !IsBase(aboveState)) {
                    side = WallSide.Tall;
                }

                if (!IsBase(state)) {
                    belowState ??= world.GetBlock(pos.WithY(pos.Y - 1));
                    if (IBlock.SimilarTo(belowState, block)
                        && ((IWallConnected)belowState).Side(face) == WallSide.None) {
                        side = WallSide.None;
                    }
                }
            }

            state = ((IWallConnected)state).WithSide(face, side);
        }

        return state;
    }

    /// <summary><c>createTopperWithSideChance</c>, with the coin flip per side.</summary>
    private static IBlock Topper(IBlock carpet, IPlacementLevel world, Vec3<int> pos) {
        Vec3<int> above = pos.WithY(pos.Y + 1);
        IBlock previous = world.GetBlock(above);
        bool carpetAbove = IBlock.SimilarTo(previous, carpet);

        if (carpetAbove ? IsBase(previous) : !previous.Replaceable) {
            return Block.Air;
        }

        IBlock tuft = ((IBottomed)world.Registry.Blocks[carpet.Identifier]).WithBottom(false);
        IBlock aboveState = UpdatedState(tuft, world, above, true);

        foreach (BlockFace face in Directions.Horizontal) {
            if (((IWallConnected)aboveState).Side(face) != WallSide.None && Random.Shared.Next(2) == 0) {
                aboveState = ((IWallConnected)aboveState).WithSide(face, WallSide.None);
            }
        }

        return HasFaces(aboveState) && !aboveState.Equals(previous) ? aboveState : Block.Air;
    }

    /// <summary><c>canSupportAtFace</c>: never upwards, otherwise the multiface attachment test.</summary>
    private static bool CanSupportAtFace(IPlacementLevel world, Vec3<int> pos, BlockFace face) {
        return face != BlockFace.PosY && PlacementHelpers.CanAttachTo(world, pos, face);
    }

    private static bool HasFaces(IBlock block) {
        if (IsBase(block)) {
            return true;
        }

        foreach (BlockFace face in Directions.Horizontal) {
            if (((IWallConnected)block).Side(face) != WallSide.None) {
                return true;
            }
        }

        return false;
    }

    /// <summary>Vanilla calls the property <c>BASE</c>; on the wire it is <c>bottom</c>.</summary>
    private static bool IsBase(IBlock block) {
        return block is IBottomed { Bottom: true };
    }
}

/// <summary>
/// <c>ChorusPlantBlock</c>. Six connections, and a survival rule that is really a growth rule: a stem
/// is held up either from below, or sideways by exactly one neighbour that is itself rooted, and only
/// while nothing is sandwiching it.
/// </summary>
public sealed class ChorusPlantPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SupportsChorusPlant = "minecraft:supports_chorus_plant";

    public BlockClass VanillaClass => BlockClass.ChorusPlantBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return WithConnections(block, context.World, context.PlacePos);
    }

    /// <summary>
    /// <c>getStateWithConnections</c>. The down face is the only one that also accepts end stone,
    /// which is what makes the plant grow upwards from the ground and not sideways out of it.
    /// </summary>
    private static IBlock WithConnections(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        IBlock state = block;
        foreach (BlockFace face in Directions.All) {
            IBlock neighbour = world.GetBlock(pos.GetBlockTowards(face));
            bool connect = ConnectsTo(block, neighbour)
                           || (face == BlockFace.NegY && Roots(world, neighbour));
            state = ((IFaceConnected)state).WithConnection(face, connect);
        }

        return state;
    }

    public bool CanSurvive(IBlock block, IPlacementLevel world, Vec3<int> pos) {
        IBlock belowState = world.GetBlock(pos.WithY(pos.Y - 1));
        bool blockAboveOrBelow = !world.GetBlock(pos.WithY(pos.Y + 1)).Air && !belowState.Air;

        foreach (BlockFace face in Directions.Horizontal) {
            Vec3<int> neighbourPos = pos.GetBlockTowards(face);
            if (!IBlock.SimilarTo(world.GetBlock(neighbourPos), block)) {
                continue;
            }

            if (blockAboveOrBelow) {
                return false;
            }

            IBlock below = world.GetBlock(neighbourPos.WithY(neighbourPos.Y - 1));
            if (IBlock.SimilarTo(below, block) || Roots(world, below)) {
                return true;
            }
        }

        return IBlock.SimilarTo(belowState, block) || Roots(world, belowState);
    }

    /// <summary>
    /// A plant that has lost its footing schedules its own break upstream and is left alone by the
    /// shape hook, so this only recomputes the one connection whose neighbour changed.
    /// </summary>
    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (!CanSurvive(block, world, pos)) {
            return block;
        }

        bool connect = ConnectsTo(block, neighbourState)
                       || (toNeighbour == BlockFace.NegY && Roots(world, neighbourState));
        return ((IFaceConnected)block).WithConnection(toNeighbour, connect);
    }

    private static bool ConnectsTo(IBlock plant, IBlock neighbour) {
        return IBlock.SimilarTo(neighbour, plant)
               || BlockClasses.Is(neighbour.Identifier, BlockClass.ChorusFlowerBlock);
    }

    private static bool Roots(IPlacementLevel world, IBlock block) {
        return world.IsInBlockTag(SupportsChorusPlant, block.Identifier);
    }
}
