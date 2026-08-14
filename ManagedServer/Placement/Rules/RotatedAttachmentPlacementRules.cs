using NBT;
using NBT.Tags;
using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>StandingSignBlock</c>. Turned to one of sixteen steps from the player's yaw, plus a half turn
/// so the face points back at them, and waterlogged from what it replaced.
/// </summary>
public sealed class StandingSignPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.StandingSignBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IRotated rotated) {
            return block;
        }

        return PlacementHelpers.Waterlog(
            rotated.WithRotation(PlacementHelpers.RotationSegment(context.Rotation + 180.0f)), context);
    }

    /// <summary>
    /// Plain <c>isSolid()</c> on the block below, the same test the wall variants use on the block
    /// behind. Not a face test, so a sign stands on an upside down slab and not on a bottom one, and
    /// stands quite happily on a fence post.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return world.GetBlock(pos.WithY(pos.Y - 1)).Solid;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>BannerBlock</c>. The same half turn as a standing sign, without the waterlogging.
/// </summary>
public sealed class BannerPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BannerBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return block is IRotated rotated
            ? rotated.WithRotation(PlacementHelpers.RotationSegment(context.Rotation + 180.0f))
            : block;
    }

    /// <summary>Same <c>isSolid()</c> below as a standing sign.</summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return world.GetBlock(pos.WithY(pos.Y - 1)).Solid;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.NegY && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>SkullBlock</c>. Turned to sixteen steps like a sign, but with <b>no</b> half turn, so a skull
/// on the floor faces the same way the player does rather than back at them.
/// <p/>
/// The <c>powered</c> line comes from <c>AbstractSkullBlock</c>, which both skull rules call
/// <c>super</c> into. It goes through the <see cref="Redstone"/> stub, so it is always false for now;
/// it is written out rather than left implicit so the branch is visible where redstone will fill it
/// in. A powered skull is what makes a piglin head wail.
/// </summary>
public sealed class SkullPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.SkullBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = AbstractSkull(block, context);
        return state is IRotated rotated
            ? rotated.WithRotation(PlacementHelpers.RotationSegment(context.Rotation))
            : state;
    }

    /// <summary><c>AbstractSkullBlock.getStateForPlacement</c>, shared by both skull rules.</summary>
    internal static IBlock AbstractSkull(IBlock block, IBlockPlaceContext context) {
        return block is IPowered skull
            ? skull.WithPowered(Redstone.HasNeighbourSignal(context.World, context.PlacePos))
            : block;
    }
}

/// <summary>
/// <c>WallBannerBlock</c>. The attachment search, horizontals only, first one with a wall behind it.
/// </summary>
public sealed class WallBannerPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.WallBannerBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing banner) {
            return null;
        }

        return PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? banner.WithFacing(face.Opposite().ToDirection()) : null);
    }

    /// <summary>
    /// <c>WallBannerBlock.canSurvive</c> is <c>isSolid()</c> on the block behind, not a face test at
    /// all. A banner hangs off anything solid whatever shape its face is.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing banner) {
            return false;
        }

        return world.GetBlock(pos.GetBlockTowards(banner.Facing.ToFace().Opposite())).Solid;
    }

    /// <summary><c>direction == state.getValue(FACING).getOpposite()</c>: the wall behind it only.</summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return block is IHorizontalFacing banner
               && toNeighbour == banner.Facing.ToFace().Opposite()
               && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}

/// <summary>
/// <c>WallSkullBlock</c>. The attachment search with the test the other way round: it takes the first
/// horizontal whose neighbour <b>cannot</b> be replaced, rather than the first that survives.
/// <p/>
/// Not a paraphrase of the same thing. A skull will hang off anything solid enough not to be replaced,
/// which is a wider set than the sturdy faces the other wall blocks demand.
/// </summary>
public sealed class WallSkullPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.WallSkullBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing) {
            return null;
        }

        IBlock powered = SkullPlacementRule.AbstractSkull(block, context);
        IHorizontalFacing skull = (IHorizontalFacing)powered;

        foreach (BlockFace face in context.NearestLookingDirections) {
            if (!Directions.IsHorizontal(face)) {
                continue;
            }

            IBlock state = skull.WithFacing(face.Opposite().ToDirection());
            if (!context.CanReplaceAt(context.PlacePos.GetBlockTowards(face))) {
                return state;
            }
        }

        return null;
    }
}

/// <summary>
/// <c>LanternBlock</c>. Only the vertical faces are candidates: hanging when the look order reaches
/// up first, standing when it reaches down.
/// </summary>
public sealed class LanternPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.LanternBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        foreach (BlockFace face in context.NearestLookingDirections) {
            if (face is not (BlockFace.PosY or BlockFace.NegY)) {
                continue;
            }

            IBlock state = block is IHanging lantern ? lantern.WithHanging(face == BlockFace.PosY) : block;
            if (CanSurvive(state, context.World, context.PlacePos)) {
                return PlacementHelpers.Waterlog(state, context);
            }
        }

        return null;
    }

    /// <summary>
    /// <c>Block.canSupportCenter</c>, not the full face. A lantern hangs off a chain and stands on a
    /// fence post, neither of which presents a whole face.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        bool hanging = block.ToStateNbt()["hanging"].GetString() == "true";
        BlockFace towards = hanging ? BlockFace.PosY : BlockFace.NegY;
        return PlacementHelpers.SupportsCenter(world, pos.GetBlockTowards(towards), towards.Opposite());
    }

    /// <summary>
    /// <c>getConnectedDirection(state) == direction</c>, which for a lantern is up when it hangs and
    /// down when it stands. Only that one neighbour can drop it.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        bool hanging = block.ToStateNbt()["hanging"].GetString() == "true";
        BlockFace attached = hanging ? BlockFace.PosY : BlockFace.NegY;
        return toNeighbour == attached && !CanSurvive(block, world, pos) ? Block.Air : block;
    }
}

/// <summary>
/// <c>CocoaBlock</c>. The attachment search, but facing <b>along</b> the candidate rather than out of
/// it, because a cocoa pod grows out of the jungle log it faces.
/// </summary>
public sealed class CocoaPlacementRule : IBlockPlacementRule {
    private static readonly Identifier JungleLogs = "minecraft:jungle_logs";

    public BlockClass VanillaClass => BlockClass.CocoaBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IHorizontalFacing cocoa) {
            return null;
        }

        return PlacementHelpers.FirstSurviving(context, this, face =>
            Directions.IsHorizontal(face) ? cocoa.WithFacing(face.ToDirection()) : null);
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IHorizontalFacing cocoa) {
            return false;
        }

        IBlock host = world.GetBlock(pos.GetBlockTowards(cocoa.Facing.ToFace()));
        return PlacementHelpers.InTag(world.Server.Registry, JungleLogs, host.Identifier);
    }

    /// <summary>
    /// <c>direction == state.getValue(FACING)</c>, with <b>no</b> <c>getOpposite</c>, unlike every
    /// other attached block. A cocoa pod faces the log it grows on rather than away from it, so the
    /// direction that can drop it is its facing as written.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return block is IHorizontalFacing cocoa
               && toNeighbour == cocoa.Facing.ToFace()
               && !CanSurvive(block, world, pos)
            ? Block.Air
            : block;
    }
}
