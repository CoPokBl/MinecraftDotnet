using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// The blocks that stack in place: another of the same item adds one instead of putting a second
/// block down.
/// <p/>
/// Two halves that have to agree. <c>canBeReplaced</c> is what makes the context aim at the block
/// already there rather than the cell beyond it, and <c>getStateForPlacement</c> is what notices it
/// is standing on itself and adds one. Either alone does nothing useful.
/// <p/>
/// Candles, sea pickles, turtle eggs, pink petals and leaf litter all share the shape below. Snow is
/// different enough to be its own rule.
/// </summary>
public abstract class StackablePlacementRule : IBlockPlacementRule {
    public abstract BlockClass VanillaClass { get; }

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock existing = context.World.GetBlock(context.PlacePos);
        if (IBlock.SimilarTo(existing, block) && existing is IStackable stacked) {
            return stacked.WithCount(Math.Min(stacked.MaxCount, stacked.Count + 1));
        }

        return PlacementHelpers.Waterlog(block, context);
    }

    /// <summary>
    /// Not sneaking, holding the same item, and there is room for one more. Sneaking is what lets a
    /// player put a block down next to a candle rather than adding to it.
    /// </summary>
    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        if (!context.IsSecondaryUseActive
            && context.ItemInHand.Type.Identifier == existing.Item
            && existing is IStackable stacked
            && stacked.Count < stacked.MaxCount) {
            return true;
        }

        return IBlockPlacementRule.DefaultCanBeReplaced(existing, context);
    }

    /// <summary>
    /// Declared here, and virtual, only so that a subclass can be dispatched to.
    /// <p/>
    /// A base class that implements an interface fixes the interface's mapping at itself, so a
    /// subclass writing <c>public bool CanSurvive</c> without <c>override</c> adds a method nobody
    /// calls and the interface default answers instead. That is silent, and for a survival rule it is
    /// silently permissive, which is the worst way for it to fail: the block simply never dies.
    /// <see cref="ManagedServer.Testing"/>'s rule dispatch test is the backstop.
    /// </summary>
    public virtual bool CanSurvive(IBlock block, World world, Vec3<int> pos) => true;

    /// <inheritdoc cref="CanSurvive"/>
    public virtual IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) => block;
}

/// <summary>
/// <c>CandleBlock</c>. Asks for the centre column below, so a candle stands on a fence post.
/// <p/>
/// It has <b>no</b> shape update, unlike everything else with a survival rule: breaking what a candle
/// stands on leaves the candle floating. That reads like an omission and is not, so there is no
/// <c>UpdateShape</c> here to match.
/// </summary>
public sealed class CandlePlacementRule : StackablePlacementRule {
    public override BlockClass VanillaClass => BlockClass.CandleBlock;

    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.SupportsCenter(world, pos.WithY(pos.Y - 1), BlockFace.PosY);
    }
}

/// <summary>
/// <c>SeaPickleBlock</c>. Its <c>mayPlaceOn</c> is the loosest of the family: either the block below
/// has <b>anything at all</b> on its up face, or that face is whole. The first clause is what lets a
/// pickle sit on a bottom slab, whose up face is empty by the sturdiness test but whose collision
/// shape still reaches the top of the lower half.
/// </summary>
public sealed class SeaPicklePlacementRule : StackablePlacementRule {
    public override BlockClass VanillaClass => BlockClass.SeaPickleBlock;

    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        return ShapeSupport.FaceShape(below.CollisionShape, BlockFace.PosY).Length > 0
               || ShapeSupport.IsFaceSturdy(below, BlockFace.PosY);
    }

    public override IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// <c>TurtleEggBlock</c>, the one member of the family with no survival rule at all: it extends
/// <c>Block</c> rather than <c>VegetationBlock</c>, so eggs may be put down on anything and stay
/// there when it goes.
/// </summary>
public sealed class TurtleEggPlacementRule : StackablePlacementRule {
    public override BlockClass VanillaClass => BlockClass.TurtleEggBlock;
}

/// <summary>
/// Pink petals and wildflowers, vanilla's <c>FlowerBedBlock</c>. No survival rule of its own, so it
/// takes <c>VegetationBlock</c>'s: the block below has to be in <c>supports_vegetation</c>.
/// </summary>
public sealed class FlowerBedPlacementRule : StackablePlacementRule {
    public override BlockClass VanillaClass => BlockClass.FlowerBedBlock;

    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.SupportsVegetation(world, pos);
    }

    public override IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// <c>LeafLitterBlock</c>. Overrides <c>VegetationBlock</c>'s tag test with a shape one, so leaf
/// litter goes on any whole upward face and not only on soil.
/// </summary>
public sealed class LeafLitterPlacementRule : StackablePlacementRule {
    public override BlockClass VanillaClass => BlockClass.LeafLitterBlock;

    public override bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        return PlacementHelpers.FaceSturdy(world, pos.WithY(pos.Y - 1), BlockFace.PosY);
    }

    public override IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }
}

/// <summary>
/// <c>SnowLayerBlock</c>. Stacks to eight rather than four, does not waterlog, and its
/// <c>canBeReplaced</c> is the odd one out in two ways.
/// <p/>
/// Sneaking does not stop it, unlike the others. And a single layer of snow is replaceable by
/// <b>anything</b>, which is what lets a block be placed straight into thin snow cover instead of on
/// top of it, while two or more layers stop being walked through and have to be broken.
/// </summary>
public sealed class SnowLayerPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.SnowLayerBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock existing = context.World.GetBlock(context.PlacePos);
        if (IBlock.SimilarTo(existing, block) && existing is IStackable stacked) {
            return stacked.WithCount(Math.Min(8, stacked.Count + 1));
        }

        return block;
    }

    public bool CanBeReplaced(IBlock existing, IBlockPlaceContext context) {
        if (existing is not IStackable stacked) {
            return IBlockPlacementRule.DefaultCanBeReplaced(existing, context);
        }

        if (context.ItemInHand.Type.Identifier != existing.Item || stacked.Count >= 8) {
            // Anything at all may replace a single layer; deeper snow has to be broken first.
            return stacked.Count == 1;
        }

        return !context.ReplacingClickedOnBlock || context.ClickedFace == BlockFace.PosY;
    }

    /// <summary>
    /// Two tags either side of a shape test, in that order, and the order matters: a block in
    /// <c>cannot_support_snow_layer</c> is refused however solid it is, and a block in
    /// <c>support_override_snow_layer</c> is accepted however thin.
    /// <p/>
    /// The shape test is the odd one out in the whole placement port. It is <c>Block.isFaceFull</c>
    /// over the <b>collision</b> shape, not <c>isFaceSturdy</c> over the support shape, so snow reads
    /// a different shape from everything else that stands on something. That is why snow settles on
    /// leaves, which collide as a whole cube and support nothing.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        MinecraftRegistry registry = world.Server.Registry;

        if (PlacementHelpers.InTag(registry, CannotSupport, below.Identifier)) {
            return false;
        }

        if (PlacementHelpers.InTag(registry, SupportOverride, below.Identifier)) {
            return true;
        }

        return ShapeSupport.Contains(
                   ShapeSupport.FaceShape(below.CollisionShape, BlockFace.PosY), ShapeSupport.FullCube)
               || IBlock.SimilarTo(below, block) && below is IStackable { Count: 8 };
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return CanSurvive(block, world, pos) ? block : Block.Air;
    }

    private static readonly Identifier CannotSupport = "minecraft:cannot_support_snow_layer";
    private static readonly Identifier SupportOverride = "minecraft:support_override_snow_layer";
}
