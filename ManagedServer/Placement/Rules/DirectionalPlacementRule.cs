using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// The six way facing blocks. <c>DirectionalBlock</c> declares the property and overrides nothing, so
/// each concrete class writes its own one-liner, and they split cleanly two ways.
/// <p/>
/// <see cref="FacesLookDirection"/> points back along the look vector, so a piston or a dispenser
/// fires away from you. <see cref="FacesClickedFace"/> points out of the surface it was put on, so an
/// amethyst cluster or an end rod grows out of the block it is attached to. Both include the vertical
/// faces, unlike the horizontal families.
/// </summary>
public abstract class DirectionalPlacementRule : IBlockPlacementRule {
    public abstract BlockClass VanillaClass { get; }

    /// <summary>Whether the facing comes from the look order rather than the clicked face.</summary>
    protected abstract bool FromLook { get; }

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IDirectional directional) {
            return block;
        }

        IBlock state = directional.WithFacing(FromLook
            ? context.NearestLookingDirection.Opposite().ToCardinal()
            : context.ClickedFace.ToCardinal());
        return PlacementHelpers.Waterlog(state, context);
    }

    /// <summary>
    /// Virtual only so a subclass can be dispatched to. A class that implements the interface fixes
    /// its mapping, so a subclass declaring the hook without <c>override</c> writes a method nothing
    /// calls and the interface default answers instead. <c>RuleDispatchTest</c> is the backstop.
    /// </summary>
    public virtual bool CanSurvive(IBlock block, World world, Vec3<int> pos) => true;

    /// <inheritdoc cref="CanSurvive"/>
    public virtual IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) => block;
}

/// <summary><c>getNearestLookingDirection().getOpposite()</c>: points away from the placer.</summary>
public abstract class FacesLookDirection : DirectionalPlacementRule {
    protected override bool FromLook => true;
}

/// <summary><c>getClickedFace()</c>: points out of whatever it was placed against.</summary>
public abstract class FacesClickedFace : DirectionalPlacementRule {
    protected override bool FromLook => false;
}

public sealed class PistonBasePlacementRule : FacesLookDirection {
    public override BlockClass VanillaClass => BlockClass.PistonBaseBlock;
}

/// <summary>Dispensers and droppers, vanilla's <c>DispenserBlock</c>.</summary>
public sealed class DispenserPlacementRule : FacesLookDirection {
    public override BlockClass VanillaClass => BlockClass.DispenserBlock;
}

public sealed class ObserverPlacementRule : FacesLookDirection {
    public override BlockClass VanillaClass => BlockClass.ObserverBlock;
}

public sealed class BarrelPlacementRule : FacesLookDirection {
    public override BlockClass VanillaClass => BlockClass.BarrelBlock;
}

public sealed class CommandPlacementRule : FacesLookDirection {
    public override BlockClass VanillaClass => BlockClass.CommandBlock;
}

public sealed class EndRodPlacementRule : FacesClickedFace {
    public override BlockClass VanillaClass => BlockClass.EndRodBlock;
}

public sealed class ShulkerBoxPlacementRule : FacesClickedFace {
    public override BlockClass VanillaClass => BlockClass.ShulkerBoxBlock;
}

/// <summary>
/// Amethyst clusters and the three bud sizes. Alone in this family it holds on to what it grew out
/// of, so it is the only one with a survival rule.
/// </summary>
public sealed class AmethystClusterPlacementRule : FacesClickedFace {
    public override BlockClass VanillaClass => BlockClass.AmethystClusterBlock;

    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        if (block is not IDirectional cluster) {
            return false;
        }

        BlockFace facing = cluster.Facing.ToFace();
        return PlacementHelpers.FaceSturdy(world, pos.GetBlockTowards(facing.Opposite()), facing);
    }

    /// <summary>
    /// Only the neighbour it grew out of can kill it. A cluster on a wall does not care what happens
    /// under it, so the direction test is not the tidying it looks like.
    /// </summary>
    public override IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (block is not IDirectional cluster || toNeighbour != cluster.Facing.ToFace().Opposite()) {
            return block;
        }

        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}
