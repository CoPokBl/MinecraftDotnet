using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;

namespace Minecraft.Placement.Rules;

/// <summary>
/// The block classes whose whole <c>getStateForPlacement</c> is the waterlog line.
/// <p/>
/// They are separate rules rather than one rule over a list of classes because that is how the jar
/// has them: seven classes, each with its own copy of the same statement, and each free to grow a
/// second line on a version bump without the others. Registering one and not another is also the
/// point of the per rule granularity.
/// <p/>
/// All seven also override <c>updateShape</c>, and in every case the override does nothing but
/// reschedule the water tick for a waterlogged state before delegating. Fluid ticks are the
/// <c>FluidSimulation</c>'s business here, not the shape cascade's, so none of these rules writes an
/// <c>UpdateShape</c>: leaving it out is the same answer vanilla's <c>super</c> call gives.
/// </summary>
public sealed class BarrierPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.BarrierBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }
}

/// <summary>
/// <c>HeavyCoreBlock</c>. The plain water test, like a barrier.
/// </summary>
public sealed class HeavyCorePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.HeavyCoreBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }
}

/// <summary>
/// <c>MangroveRootsBlock</c>. Waterlogs, and its <c>super</c> is plain <c>Block</c>, so that is all.
/// </summary>
public sealed class MangroveRootsPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.MangroveRootsBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }
}

/// <summary>
/// <c>SculkShriekerBlock</c>. Waterlogs.
/// </summary>
public sealed class SculkShriekerPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.SculkShriekerBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }
}

/// <summary>
/// <c>SculkSensorBlock</c>. Waterlogs. The calibrated one inherits this and adds a facing, so it has
/// its own rule rather than sharing this class.
/// </summary>
public sealed class SculkSensorPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.SculkSensorBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return PlacementHelpers.Waterlog(block, context);
    }
}

/// <summary>
/// <c>CalibratedSculkSensorBlock</c>. The sculk sensor's waterlog line, then
/// <c>getHorizontalDirection()</c> <b>as is</b>.
/// <p/>
/// One of the eleven classes that face the way the player does rather than back at them, which for a
/// calibrated sensor means its input side ends up pointing away from whoever placed it.
/// </summary>
public sealed class CalibratedSculkSensorPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.CalibratedSculkSensorBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = PlacementHelpers.Waterlog(block, context);
        return state is IHorizontalFacing sensor ? sensor.WithFacing(context.HorizontalDirection) : state;
    }
}

/// <summary>
/// <c>ConduitBlock</c>. Not the plain water test: it asks for a <b>full</b> water cell, so a conduit
/// placed into a thinning flow comes out dry.
/// </summary>
public sealed class ConduitPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.ConduitBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return block is IWaterlogged conduit
            ? conduit.WithWaterlogged(PlacementHelpers.IsFullWaterAt(context.World, context.PlacePos))
            : block;
    }
}
