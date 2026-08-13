using ManagedServer.Fluids;
using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>InfestedRotatedPillarBlock</c>: infested deepslate. Takes its axis from the clicked face like
/// any pillar, and needs its own rule because it extends <c>InfestedBlock</c> rather than
/// <c>RotatedPillarBlock</c>, so it cannot reach that rule through the class chain.
/// </summary>
public sealed class InfestedRotatedPillarPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.InfestedRotatedPillarBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return block is IAxisAligned pillar
            ? pillar.WithAxis(ChainPlacementRule.AxisOf(context.ClickedFace))
            : block;
    }
}

/// <summary>
/// <c>RedstoneLampBlock</c>. Lit from <c>hasNeighborSignal</c>, so it goes through the
/// <see cref="Redstone"/> stub and always comes out unlit for now.
/// </summary>
public sealed class RedstoneLampPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.RedstoneLampBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return block is ILit lamp
            ? lamp.WithLit(Redstone.HasNeighbourSignal(context.World, context.PlacePos))
            : block;
    }
}

/// <summary>
/// <c>SnowyBlock</c>: grass, podzol and mycelium. The <c>snowy</c> flag is purely cosmetic and purely
/// a function of what is directly above, so it is set at placement and recomputed whenever the block
/// above changes.
/// </summary>
public sealed class SnowyPlacementRule : IBlockPlacementRule {
    private static readonly Identifier SnowTag = "minecraft:snow";

    public BlockClass VanillaClass => BlockClass.SnowyBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return WithSnowy(block, IsSnowySetting(context.World,
            context.World.GetBlock(context.PlacePos.WithY(context.PlacePos.Y + 1))));
    }

    /// <summary>Only the up face matters, so every other neighbour falls through unchanged.</summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour == BlockFace.PosY
            ? WithSnowy(block, IsSnowySetting(world, neighbourState))
            : block;
    }

    private static bool IsSnowySetting(World world, IBlock above) {
        return PlacementHelpers.InTag(world.Server.Registry, SnowTag, above.Identifier);
    }

    private static IBlock WithSnowy(IBlock block, bool snowy) {
        return PlacementHelpers.WithProperty(block, "snowy", snowy);
    }
}

/// <summary>
/// <c>NoteBlock</c>. Picks the instrument off its neighbours: a mob head above overrides everything,
/// otherwise the block below decides, and a mob head <b>below</b> is ignored and gives a harp.
/// <p/>
/// <c>worksAboveNoteBlock</c> is the whole rule. It is true for exactly the instruments that are not
/// a base block instrument, ie. the six mob heads and the custom head, which is why a note block on
/// top of a skeleton skull imitates a skeleton and a note block on top of sand still plays a
/// basedrum.
/// </summary>
public sealed class NoteBlockPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.NoteBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return SetInstrument(block, context.World, context.PlacePos);
    }

    /// <summary>
    /// Recomputed whenever the neighbour above or below changes, and only then. Vanilla tests the
    /// axis rather than the two faces, which is the same set.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return toNeighbour is BlockFace.PosY or BlockFace.NegY
            ? SetInstrument(block, world, pos)
            : block;
    }

    private static IBlock SetInstrument(IBlock block, World world, Vec3<int> pos) {
        NoteBlockInstrument above = world.GetBlock(pos.WithY(pos.Y + 1)).StateInfo.Instrument;
        if (above.WorksAboveNoteBlock()) {
            return With(block, above);
        }

        NoteBlockInstrument below = world.GetBlock(pos.WithY(pos.Y - 1)).StateInfo.Instrument;
        return With(block, below.WorksAboveNoteBlock() ? NoteBlockInstrument.Harp : below);
    }

    private static IBlock With(IBlock block, NoteBlockInstrument instrument) {
        return PlacementHelpers.WithProperty(block, "instrument", instrument.ToName());
    }
}

/// <summary>
/// <c>HugeMushroomBlock</c>. The six face booleans are the <b>skin</b>, not connections: a face is on
/// when there is no matching mushroom block against it, so a solid lump of mushroom is capped all
/// over and plain inside.
/// </summary>
public sealed class HugeMushroomPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.HugeMushroomBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IFaceConnected mushroom) {
            return block;
        }

        IBlock state = block;
        foreach (BlockFace face in Directions.All) {
            bool skin = !IBlock.SimilarTo(context.World.GetBlock(context.PlacePos.GetBlockTowards(face)), block);
            state = ((IFaceConnected)state).WithConnection(face, skin);
        }

        return state;
    }

    /// <summary>
    /// Only ever turns a face off. Vanilla's else branch is the plain <c>super</c>, so a mushroom
    /// block that loses the mushroom beside it keeps its bare side rather than growing a cap back.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return IBlock.SimilarTo(neighbourState, block) && block is IFaceConnected mushroom
            ? mushroom.WithConnection(toNeighbour, false)
            : block;
    }
}

/// <summary>
/// <c>TripWireBlock</c>. Four horizontal connections, each towards a hook facing back at it or
/// another length of wire.
/// </summary>
public sealed class TripWirePlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.TripWireBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = block;
        foreach (BlockFace face in Directions.Horizontal) {
            IBlock neighbour = context.World.GetBlock(context.PlacePos.GetBlockTowards(face));
            state = ((IFaceConnected)state).WithConnection(face, ShouldConnectTo(neighbour, face));
        }

        return state;
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return Directions.IsHorizontal(toNeighbour) && block is IFaceConnected wire
            ? wire.WithConnection(toNeighbour, ShouldConnectTo(neighbourState, toNeighbour))
            : block;
    }

    /// <summary>
    /// <c>TripWireBlock.shouldConnectTo</c>: a hook counts only when it points back along the wire,
    /// so a hook on the wrong wall is not an anchor.
    /// </summary>
    private static bool ShouldConnectTo(IBlock neighbour, BlockFace towards) {
        if (BlockClasses.Is(neighbour.Identifier, BlockClass.TripWireHookBlock)) {
            return neighbour is IHorizontalFacing hook
                   && hook.Facing == towards.Opposite().ToDirection();
        }

        return BlockClasses.Is(neighbour.Identifier, BlockClass.TripWireBlock);
    }
}

/// <summary>
/// <c>CreakingHeartBlock</c>. The axis comes from the clicked face; the state comes from whether the
/// two blocks along that axis are pale oak logs lying the same way.
/// <p/>
/// <b>Documented divergence.</b> Vanilla picks between <c>awake</c> and <c>dormant</c> from
/// <c>EnvironmentAttributes.CREAKING_ACTIVE</c>, which is true in the overworld at night. Our
/// dimension types carry no environment attributes at all, the same gap <c>FastLava</c> records, so
/// this always takes the <c>dormant</c> branch. That is the right answer by day and wrong by night,
/// and since placement is client predicted a heart placed into a finished pale oak frame after dark
/// will appear awake and then settle to dormant. Wiring it up is one call once environment
/// attributes exist.
/// </summary>
public sealed class CreakingHeartPlacementRule : IBlockPlacementRule {
    private static readonly Identifier PaleOakLogs = "minecraft:pale_oak_logs";

    public BlockClass VanillaClass => BlockClass.CreakingHeartBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = block is IAxisAligned heart
            ? heart.WithAxis(ChainPlacementRule.AxisOf(context.ClickedFace))
            : block;
        return UpdateState(state, context.World, context.PlacePos);
    }

    /// <summary>
    /// Vanilla schedules a tick from every neighbour change and does the work there. There is no
    /// block tick scheduler, so the recompute happens inline, which reaches the same state one tick
    /// earlier.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return UpdateState(block, world, pos);
    }

    private static IBlock UpdateState(IBlock block, World world, Vec3<int> pos) {
        bool uprooted = PlacementHelpers.PropertyOf(block, "creaking_heart_state") == "uprooted";
        if (!uprooted || !HasRequiredLogs(block, world, pos)) {
            return block;
        }

        return PlacementHelpers.WithProperty(block, "creaking_heart_state", "dormant");
    }

    /// <summary>
    /// Both blocks along the heart's own axis must be pale oak logs lying along that same axis. A
    /// frame built the wrong way round leaves the heart uprooted whatever it is made of.
    /// </summary>
    private static bool HasRequiredLogs(IBlock block, World world, Vec3<int> pos) {
        if (block is not IAxisAligned heart) {
            return false;
        }

        foreach (BlockFace face in FacesOf(heart.Axis)) {
            IBlock neighbour = world.GetBlock(pos.GetBlockTowards(face));
            if (!PlacementHelpers.InTag(world.Server.Registry, PaleOakLogs, neighbour.Identifier)) {
                return false;
            }

            if (neighbour is not IAxisAligned log || log.Axis != heart.Axis) {
                return false;
            }
        }

        return true;
    }

    /// <summary><c>Axis.getDirections</c>, negative first.</summary>
    private static BlockFace[] FacesOf(Axis axis) => axis switch {
        Axis.X => [BlockFace.NegX, BlockFace.PosX],
        Axis.Y => [BlockFace.NegY, BlockFace.PosY],
        _ => [BlockFace.NegZ, BlockFace.PosZ]
    };
}

/// <summary>
/// <c>PotentSulfurBlock</c>. Its state is a function of the water above and the block below, and it
/// is recomputed on every neighbour change with no scheduling in between.
/// <p/>
/// One line is deliberately left out: vanilla asks the block entity to reset its countdown when a
/// periodic geyser first becomes periodic. There are no block entities on this path, and the
/// countdown only affects when the geyser next erupts, not which state is written, so the state this
/// returns is the same either way.
/// </summary>
public sealed class PotentSulfurPlacementRule : IBlockPlacementRule {
    private static readonly Identifier Continuous = "minecraft:causes_continuous_geyser_eruptions";
    private static readonly Identifier Periodic = "minecraft:causes_periodic_geyser_eruptions";

    public BlockClass VanillaClass => BlockClass.PotentSulfurBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return ValidState(block, context.World, context.PlacePos);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return ValidState(block, world, pos);
    }

    private static IBlock ValidState(IBlock block, World world, Vec3<int> pos) {
        if (!PlacementHelpers.IsWaterSourceAt(world, pos.WithY(pos.Y + 1))) {
            return With(block, "dry");
        }

        IBlock below = world.GetBlock(pos.WithY(pos.Y - 1));
        bool sourceIfFluid = FluidState.Of(below) is { IsEmpty: true } or { Source: true };

        if (sourceIfFluid && PlacementHelpers.InTag(world.Server.Registry, Continuous, below.Identifier)) {
            return With(block, "continuous");
        }

        if (sourceIfFluid && PlacementHelpers.InTag(world.Server.Registry, Periodic, below.Identifier)) {
            return PlacementHelpers.PropertyOf(block, "potent_sulfur_state") == "erupting"
                ? block
                : With(block, "dormant");
        }

        return With(block, "wet");
    }

    private static IBlock With(IBlock block, string state) {
        return PlacementHelpers.WithProperty(block, "potent_sulfur_state", state);
    }
}

/// <summary>
/// <c>LeavesBlock</c>. Placed leaves are <c>persistent</c>, so they never decay, and they still get a
/// distance worked out from their neighbours because breaking the log beside them is not what clears
/// the flag.
/// <p/>
/// No <c>UpdateShape</c>: vanilla's does nothing but schedule the decay tick and hand the state back
/// unchanged. Without a block tick scheduler the distance stays as placed, which is what a persistent
/// leaf block does anyway; naturally generated leaves would never decay, and there is no world
/// generation putting any down.
/// </summary>
public sealed class LeavesPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.LeavesBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        IBlock state = PlacementHelpers.WithProperty(block, "persistent", true);
        state = state is IWaterlogged leaves
            ? leaves.WithWaterlogged(PlacementHelpers.IsWaterAt(context.World, context.PlacePos))
            : state;
        return UpdateDistance(state, context.World, context.PlacePos);
    }

    /// <summary>
    /// One more than the nearest neighbour's, capped at seven, and stopping the moment it reaches
    /// one. A leaf block touching a log gets distance one because a log reads as distance zero.
    /// </summary>
    private static IBlock UpdateDistance(IBlock block, World world, Vec3<int> pos) {
        int distance = 7;
        foreach (BlockFace face in Directions.All) {
            distance = Math.Min(distance, DistanceAt(world, world.GetBlock(pos.GetBlockTowards(face))) + 1);
            if (distance == 1) {
                break;
            }
        }

        return PlacementHelpers.WithProperty(block, "distance", distance.ToString());
    }

    /// <summary>
    /// <c>LeavesBlock.getOptionalDistanceAt</c>: zero for a log, the leaf's own distance for leaves,
    /// seven for anything else.
    /// </summary>
    private static int DistanceAt(World world, IBlock block) {
        if (BlockClasses.Is(block.Identifier, BlockClass.LeavesBlock)) {
            return int.Parse(PlacementHelpers.PropertyOf(block, "distance"));
        }

        return PlacementHelpers.InTag(world.Server.Registry, Logs, block.Identifier) ? 0 : 7;
    }

    private static readonly Identifier Logs = "minecraft:logs";
}

/// <summary>
/// <c>DirtPathBlock</c>. Refuses to be a path where a path could not survive and lays dirt instead,
/// which is why a grass path placed under a wall comes out as dirt rather than as nothing.
/// </summary>
public sealed class DirtPathPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.DirtPathBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return CanSurvive(block, context.World, context.PlacePos) ? block : Block.Dirt;
    }

    /// <summary>
    /// A path needs open sky, or something that is not solid, immediately above it. The fence gate
    /// carve out is vanilla's and is by class, not by shape, so a closed gate is fine and a closed
    /// door is not.
    /// </summary>
    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        IBlock above = world.GetBlock(pos.WithY(pos.Y + 1));
        return !above.Solid || BlockClasses.Is(above.Identifier, BlockClass.FenceGateBlock);
    }
}

/// <summary>
/// <c>FarmlandBlock</c>. The same shape as a dirt path, and the same fallback to plain dirt.
/// <p/>
/// Vanilla's <c>canSurvive</c> spares farmland that has a crop on it (<c>shouldMaintainFarmland</c>),
/// which is why a torch on tilled soil does not turn it back into dirt while wheat is growing. That
/// is transcribed: the tag it reads is <c>maintains_farmland</c> on the block above.
/// </summary>
public sealed class FarmlandPlacementRule : IBlockPlacementRule {
    private static readonly Identifier MaintainsFarmland = "minecraft:maintains_farmland";

    public BlockClass VanillaClass => BlockClass.FarmlandBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        return CanSurvive(block, context.World, context.PlacePos) ? block : Block.Dirt;
    }

    public bool CanSurvive(IBlock block, World world, Vec3<int> pos) {
        IBlock above = world.GetBlock(pos.WithY(pos.Y + 1));
        return !above.Solid || PlacementHelpers.InTag(world.Server.Registry, MaintainsFarmland, above.Identifier);
    }
}

/// <summary>
/// <c>ConcretePowderBlock</c>. Placed into or against water it lands as concrete, which is the whole
/// reason the block exists.
/// </summary>
public sealed class ConcretePowderPlacementRule : IBlockPlacementRule {
    public BlockClass VanillaClass => BlockClass.ConcretePowderBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        World world = context.World;
        Vec3<int> pos = context.PlacePos;
        bool solidify = CanSolidify(world.GetBlock(pos)) || TouchesLiquid(world, pos);
        return solidify ? Concrete(world, block) : block;
    }

    /// <summary>
    /// Vanilla checks only that it is touching liquid here, not that it was placed into it, so water
    /// flowing up against a column of powder turns the whole column as the cascade reaches it.
    /// </summary>
    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        return TouchesLiquid(world, pos) ? Concrete(world, block) : block;
    }

    /// <summary>
    /// <c>ConcretePowderBlock.touchesLiquid</c>, transcribed with its quirk intact: the loop reads
    /// the block at the <b>unmoved</b> position first and only offsets afterwards, so the downward
    /// direction is skipped unless the powder's own cell already holds water. That is not a
    /// paraphrase of "look at the six neighbours"; it is why a powder block resting on water does not
    /// set unless something else touches it.
    /// </summary>
    private static bool TouchesLiquid(World world, Vec3<int> pos) {
        foreach (BlockFace face in Directions.All) {
            if (face == BlockFace.NegY && !CanSolidify(world.GetBlock(pos))) {
                continue;
            }

            Vec3<int> neighbourPos = pos.GetBlockTowards(face);
            IBlock neighbour = world.GetBlock(neighbourPos);
            if (CanSolidify(neighbour)
                && !ShapeSupport.IsFaceSturdy(neighbour, face.Opposite())) {
                return true;
            }
        }

        return false;
    }

    private static bool CanSolidify(IBlock block) {
        return FluidState.Of(block).Kind == FluidKind.Water;
    }

    /// <summary>
    /// The concrete for this powder. Vanilla holds the pair as a field on the block; here the names
    /// differ by one suffix throughout, so it is looked up by identifier and the lookup failing is a
    /// generator problem rather than something to hide.
    /// </summary>
    private static IBlock Concrete(World world, IBlock powder) {
        Identifier id = powder.Identifier;
        return world.Server.Registry.Blocks[new Identifier(id.Namespace, id.Key.Replace("_powder", ""))];
    }
}
