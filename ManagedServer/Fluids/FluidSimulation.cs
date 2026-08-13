using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT.Tags;
using Entry = ManagedServer.Fluids.FluidBlockData.Entry;

namespace ManagedServer.Fluids;

/// <summary>
/// A port of vanilla's <c>FlowingFluid</c>, <c>WaterFluid</c>, <c>LavaFluid</c> and the parts of
/// <c>LiquidBlock</c> that drive them, for one <see cref="World"/>.
/// <p/>
/// Vanilla splits the behaviour across a fluid instance per water/lava and per source/flowing; here it
/// is one class taking the <see cref="FluidKind"/> as an argument, because the only place the four
/// instances have to stay apart is tick scheduling, which <see cref="FluidTicks.Key"/> keeps.
/// <p/>
/// A change to any method here is only right if the vanilla one says so. Fluid spreading is one of the
/// few things a client predicts nothing about, so a wrong flow does not desync, it just looks wrong
/// forever.
/// </summary>
public sealed class FluidSimulation(World world) {
    /// <summary>
    /// Whether lava behaves the way it does in the nether: half the drop off, twice the range, three
    /// times the speed. Vanilla reads this off the dimension's <c>FAST_LAVA</c> environment attribute,
    /// which our dimension types don't carry, so it is a setting instead.
    /// </summary>
    public bool FastLava { get; set; }

    /// <summary>Vanilla's <c>waterSourceConversion</c> game rule, which makes two sources become three.</summary>
    public bool WaterSourceConversion { get; set; } = true;

    /// <summary>Vanilla's <c>lavaSourceConversion</c> game rule, off by default there too.</summary>
    public bool LavaSourceConversion { get; set; }

    /// <summary>
    /// Whether a block water washes away drops its item, which is vanilla's <c>beforeDestroyingBlock</c>.
    /// Off by default to match the rest of the framework, where breaking a block drops nothing.
    /// </summary>
    public bool DropDestroyedBlocks { get; set; }

    public World World { get; } = world;
    public FluidTicks Ticks { get; } = new();

    /// <summary>
    /// Whether the simulation is the one writing to the world right now, so that the block change
    /// listener can tell its own writes (which are followed up synchronously, the way vanilla's
    /// <c>setBlock</c> runs the neighbour updates inline) from everyone else's.
    /// </summary>
    public bool Writing { get; private set; }

    private MinecraftRegistry Registry => World.Server.Registry;

    // Block writes are meant to happen on the tick thread, but SetBlocksAsync does not, so the queue
    // between the world's change event and the next pass is guarded.
    private readonly List<Vec3<int>> _externalChanges = [];
    private readonly Lock _externalChangesLock = new();
    private ulong _currentTick;

    private const int FizzEvent = 1501;
    private const float LavaMinLevelCutoff = 0.44444445f;

    #region scheduling

    /// <summary>
    /// Records a block change made by something other than the simulation. It is picked up at the start
    /// of the next pass rather than now, because the world fires its change event before the write, so
    /// the block that is about to be there cannot be read yet.
    /// </summary>
    public void QueueExternalChange(Vec3<int> pos) {
        lock (_externalChangesLock) {
            _externalChanges.Add(pos);
        }
    }

    /// <summary>
    /// <c>LiquidBlock.onPlace</c>, <c>neighborChanged</c> and the <c>updateShape</c> of every
    /// waterloggable block: a liquid whose surroundings changed ticks again after its delay, unless it
    /// was lava that has just been quenched into stone.
    /// </summary>
    public void OnBlockChanged(Vec3<int> pos) {
        ScheduleIfLiquid(pos);
        foreach (BlockFace face in AllFaces) {
            ScheduleIfLiquid(FluidDirections.Relative(pos, face));
        }
    }

    private static readonly BlockFace[] AllFaces = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    private void ScheduleIfLiquid(Vec3<int> pos) {
        Entry state = GetState(pos);
        FluidState fluid = state.Fluid;
        if (fluid.IsEmpty) {
            return;
        }

        // The lava checks belong to LiquidBlock, so a waterlogged block skips them.
        if (!state.Container && !ShouldSpreadLiquid(pos, fluid)) {
            return;
        }

        Schedule(pos, fluid, GetTickDelay(fluid.Kind));
    }

    public void Schedule(Vec3<int> pos, FluidState fluid, int delay) {
        Ticks.Schedule(new FluidTicks.Key(pos, fluid.Kind, fluid.Source), _currentTick + (ulong)Math.Max(delay, 1));
    }

    /// <summary>
    /// <c>LiquidBlock.shouldSpreadLiquid</c>: lava touching water turns to stone instead of flowing, and
    /// lava over soul soil touching blue ice turns to basalt. Returns whether the lava survived.
    /// </summary>
    private bool ShouldSpreadLiquid(Vec3<int> pos, FluidState fluid) {
        if (fluid.Kind != FluidKind.Lava) {
            return true;
        }

        bool overSoulSoil = GetState(FluidDirections.Below(pos)).Block.Identifier.Equals(SoulSoil);

        // Vanilla walks POSSIBLE_FLOW_DIRECTIONS and looks at the block opposite each of them, which
        // reaches up rather than down.
        foreach (BlockFace face in PossibleFlowDirections) {
            Vec3<int> neighbourPos = FluidDirections.Relative(pos, FluidDirections.Opposite(face));
            Entry neighbour = GetState(neighbourPos);

            if (neighbour.Fluid.Kind == FluidKind.Water) {
                SetBlock(pos, fluid.Source ? Block.Obsidian : Block.Cobblestone);
                Fizz(pos);
                return false;
            }

            if (overSoulSoil && neighbour.Block.Identifier.Equals(BlueIce)) {
                SetBlock(pos, Block.Basalt);
                Fizz(pos);
                return false;
            }
        }

        return true;
    }

    private static readonly BlockFace[] PossibleFlowDirections = [
        BlockFace.NegY, BlockFace.PosZ, BlockFace.NegZ, BlockFace.PosX, BlockFace.NegX
    ];

    private static readonly Identifier SoulSoil = "minecraft:soul_soil";
    private static readonly Identifier BlueIce = "minecraft:blue_ice";

    #endregion

    #region ticking

    public void Tick(ulong currentTick) {
        _currentTick = currentTick;

        Vec3<int>[] changes;
        lock (_externalChangesLock) {
            changes = _externalChanges.ToArray();
            _externalChanges.Clear();
        }

        foreach (Vec3<int> pos in changes) {
            OnBlockChanged(pos);
        }

        foreach (FluidTicks.Key key in Ticks.TakeDue(currentTick)) {
            TickFluid(key);
        }
    }

    /// <summary><c>ServerLevel.tickFluid</c>: the block has to still hold the fluid that was scheduled.</summary>
    private void TickFluid(FluidTicks.Key key) {
        Entry state = GetState(key.Pos);
        FluidState fluid = state.Fluid;
        if (fluid.Kind != key.Kind || fluid.Source != key.Source) {
            return;
        }

        TickFluidState(key.Pos, state, fluid);
    }

    /// <summary><c>FlowingFluid.tick</c>.</summary>
    private void TickFluidState(Vec3<int> pos, Entry state, FluidState fluidState) {
        if (!fluidState.Source) {
            FluidState newFluidState = GetNewLiquid(fluidState.Kind, pos, state);
            int tickDelay = GetSpreadDelay(pos, fluidState, newFluidState);

            if (newFluidState.IsEmpty) {
                fluidState = newFluidState;
                SetBlock(pos, Block.Air);
                state = GetState(pos);
            }
            else if (newFluidState != fluidState) {
                fluidState = newFluidState;
                SetBlock(pos, newFluidState.ToBlock());
                state = GetState(pos);
                Schedule(pos, newFluidState, tickDelay);
            }
        }

        Spread(pos, state, fluidState);
    }

    /// <summary><c>FlowingFluid.spread</c>.</summary>
    private void Spread(Vec3<int> pos, Entry state, FluidState fluidState) {
        if (fluidState.IsEmpty) {
            return;
        }

        FluidKind kind = fluidState.Kind;
        Vec3<int> belowPos = FluidDirections.Below(pos);
        Entry belowState = GetState(belowPos);

        if (CanMaybePassThrough(kind, state, pos, BlockFace.NegY, belowState, belowPos)) {
            FluidState newBelowFluid = GetNewLiquid(kind, belowPos, belowState);
            if (CanBeReplacedWith(belowState.Fluid, belowPos, newBelowFluid.Kind, BlockFace.NegY) &&
                CanHoldSpecificFluid(belowState, newBelowFluid)) {
                SpreadTo(kind, belowPos, belowState, BlockFace.NegY, newBelowFluid);

                if (SourceNeighborCount(kind, pos) >= 3) {
                    SpreadToSides(pos, fluidState, state);
                }

                return;
            }
        }

        if (fluidState.Source || !IsWaterHole(kind, state, pos, belowState, belowPos)) {
            SpreadToSides(pos, fluidState, state);
        }
    }

    /// <summary><c>FlowingFluid.spreadToSides</c>.</summary>
    private void SpreadToSides(Vec3<int> pos, FluidState fluidState, Entry state) {
        FluidKind kind = fluidState.Kind;
        int neighbor = fluidState.Falling ? 7 : fluidState.Amount - GetDropOff(kind);
        if (neighbor <= 0) {
            return;
        }

        foreach ((BlockFace face, FluidState newNeighborFluid) in GetSpread(kind, pos, state)) {
            Vec3<int> neighborPos = FluidDirections.Relative(pos, face);
            SpreadTo(kind, neighborPos, GetState(neighborPos), face, newNeighborFluid);
        }
    }

    /// <summary><c>FlowingFluid.getNewLiquid</c>: what the fluid at a position should be.</summary>
    private FluidState GetNewLiquid(FluidKind kind, Vec3<int> pos, Entry state) {
        int highestNeighbor = 0;
        int neighbourSources = 0;

        foreach (BlockFace face in FluidDirections.Horizontal) {
            Vec3<int> relativePos = FluidDirections.Relative(pos, face);
            Entry relative = GetState(relativePos);
            FluidState fluid = relative.Fluid;
            if (!fluid.IsSame(kind) || !FluidBlockData.CanPassThroughWall(state, pos, relative, relativePos, face)) {
                continue;
            }

            if (fluid.Source) {
                neighbourSources++;
            }

            highestNeighbor = Math.Max(highestNeighbor, fluid.Amount);
        }

        if (neighbourSources >= 2 && CanConvertToSource(kind)) {
            Entry below = GetState(FluidDirections.Below(pos));
            if (below.Solid || IsSourceBlockOfThisType(kind, below.Fluid)) {
                return FluidState.SourceOf(kind, false);
            }
        }

        Vec3<int> abovePos = FluidDirections.Above(pos);
        Entry above = GetState(abovePos);
        if (above.Fluid.IsSame(kind) && FluidBlockData.CanPassThroughWall(state, pos, above, abovePos, BlockFace.PosY)) {
            return FluidState.Flowing(kind, 8, true);
        }

        int amount = highestNeighbor - GetDropOff(kind);
        return amount <= 0 ? FluidState.Empty : FluidState.Flowing(kind, amount, false);
    }

    /// <summary>
    /// <c>FlowingFluid.getSpread</c>: which sides the fluid moves to, being the ones that reach a hole
    /// soonest. Ties keep every direction, which is what makes a flat pour spread evenly.
    /// </summary>
    private List<(BlockFace Face, FluidState Fluid)> GetSpread(FluidKind kind, Vec3<int> pos, Entry state) {
        int lowest = 1000;
        List<(BlockFace, FluidState)> result = [];
        SpreadContext? context = null;

        foreach (BlockFace face in FluidDirections.Horizontal) {
            Vec3<int> testPos = FluidDirections.Relative(pos, face);
            Entry testState = GetState(testPos);
            if (!CanMaybePassThrough(kind, state, pos, face, testState, testPos)) {
                continue;
            }

            FluidState newFluid = GetNewLiquid(kind, testPos, testState);
            if (!CanHoldSpecificFluid(testState, newFluid)) {
                continue;
            }

            context ??= new SpreadContext(this);

            int distance = context.IsHole(kind, testPos) ? 0 : GetSlopeDistance(kind, testPos, 1, FluidDirections.Opposite(face), testState, context);

            if (distance < lowest) {
                result.Clear();
            }

            if (distance <= lowest) {
                if (CanBeReplacedWith(testState.Fluid, testPos, newFluid.Kind, face)) {
                    result.Add((face, newFluid));
                }

                lowest = distance;
            }
        }

        return result;
    }

    /// <summary><c>FlowingFluid.getSlopeDistance</c>: how many blocks away the nearest hole is.</summary>
    private int GetSlopeDistance(FluidKind kind, Vec3<int> pos, int pass, BlockFace from, Entry state, SpreadContext context) {
        int lowest = 1000;

        foreach (BlockFace face in FluidDirections.Horizontal) {
            if (face == from) {
                continue;
            }

            Vec3<int> testPos = FluidDirections.Relative(pos, face);
            Entry testState = context.GetState(testPos);
            if (!CanPassThrough(kind, state, pos, face, testState, testPos)) {
                continue;
            }

            if (context.IsHole(kind, testPos)) {
                return pass;
            }

            if (pass < GetSlopeFindDistance(kind)) {
                int found = GetSlopeDistance(kind, testPos, pass + 1, FluidDirections.Opposite(face), testState, context);
                if (found < lowest) {
                    lowest = found;
                }
            }
        }

        return lowest;
    }

    /// <summary><c>FlowingFluid.isWaterHole</c>: whether the fluid can fall out of this position.</summary>
    private bool IsWaterHole(FluidKind kind, Entry topState, Vec3<int> topPos, Entry bottomState, Vec3<int> bottomPos) {
        if (!FluidBlockData.CanPassThroughWall(topState, topPos, bottomState, bottomPos, BlockFace.NegY)) {
            return false;
        }

        return bottomState.Fluid.IsSame(kind) ||
               (bottomState.CanHoldAnyFluid && CanHoldSpecificFluid(bottomState, FluidState.Flowing(kind, 1, false)));
    }

    /// <summary><c>FlowingFluid.canPassThrough</c>.</summary>
    private static bool CanPassThrough(FluidKind kind, Entry state, Vec3<int> pos, BlockFace face, Entry testState, Vec3<int> testPos) {
        return CanMaybePassThrough(kind, state, pos, face, testState, testPos) &&
               CanHoldSpecificFluid(testState, FluidState.Flowing(kind, 1, false));
    }

    /// <summary><c>FlowingFluid.canMaybePassThrough</c>.</summary>
    private static bool CanMaybePassThrough(FluidKind kind, Entry state, Vec3<int> pos, BlockFace face, Entry testState, Vec3<int> testPos) {
        return !IsSourceBlockOfThisType(kind, testState.Fluid) &&
               testState.CanHoldAnyFluid &&
               FluidBlockData.CanPassThroughWall(state, pos, testState, testPos, face);
    }

    /// <summary>
    /// <c>FlowingFluid.canHoldSpecificFluid</c>. The only container we have is waterlogging, and
    /// <c>SimpleWaterloggedBlock.canPlaceLiquid</c> accepts the water <i>source</i> alone, so flowing
    /// water never waterlogs anything.
    /// </summary>
    private static bool CanHoldSpecificFluid(Entry state, FluidState fluid) {
        return !state.Container || (fluid.Kind == FluidKind.Water && fluid.Source);
    }

    private static bool IsSourceBlockOfThisType(FluidKind kind, FluidState state) {
        return state.IsSame(kind) && state.Source;
    }

    /// <summary><c>FlowingFluid.sourceNeighborCount</c>.</summary>
    private int SourceNeighborCount(FluidKind kind, Vec3<int> pos) {
        int count = 0;
        foreach (BlockFace face in FluidDirections.Horizontal) {
            if (IsSourceBlockOfThisType(kind, GetState(FluidDirections.Relative(pos, face)).Fluid)) {
                count++;
            }
        }

        return count;
    }

    /// <summary><c>FlowingFluid.spreadTo</c>, with <c>LavaFluid</c>'s override in front of it.</summary>
    private void SpreadTo(FluidKind kind, Vec3<int> pos, Entry state, BlockFace face, FluidState target) {
        // Lava falling into water makes stone rather than displacing it.
        if (kind == FluidKind.Lava && face == BlockFace.NegY && state.Fluid.Kind == FluidKind.Water) {
            if (state.Block is WaterBlock or LavaBlock) {
                SetBlock(pos, Block.Stone);
            }

            Fizz(pos);
            return;
        }

        if (state.Container) {
            PlaceLiquid(pos, state, target);
            return;
        }

        if (!state.Air) {
            BeforeDestroyingBlock(kind, pos, state);
        }

        SetBlock(pos, target.ToBlock());
    }

    /// <summary><c>SimpleWaterloggedBlock.placeLiquid</c>.</summary>
    public void PlaceLiquid(Vec3<int> pos, Entry state, FluidState target) {
        if (state.Waterlogged || target.Kind != FluidKind.Water) {
            return;
        }

        SetBlock(pos, state.Block.WithState(new CompoundTag(("waterlogged", new StringTag("true")))));
        Schedule(pos, target, GetTickDelay(target.Kind));
    }

    /// <summary>
    /// <c>WaterFluid.beforeDestroyingBlock</c> drops the block's loot, <c>LavaFluid</c>'s only fizzes.
    /// We have no loot tables, so the block's own item stands in for its drops.
    /// </summary>
    private void BeforeDestroyingBlock(FluidKind kind, Vec3<int> pos, Entry state) {
        if (kind == FluidKind.Lava) {
            Fizz(pos);
            return;
        }

        if (!DropDestroyedBlocks || state.Block.Item == null) {
            return;
        }

        World.DropItem(new Vec3<double>(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5),
            new ItemStack(Registry.Items[state.Block.Item.Value]));
    }

    private void Fizz(Vec3<int> pos) {
        World.GetAudienceOf(pos).SendPacket(new ClientBoundWorldEventPacket {
            Event = FizzEvent,
            Location = pos,
            Data = 0,
            DisableRelativeVolume = false
        });
    }

    #endregion

    #region fluid_constants

    /// <summary><c>FluidState.canBeReplacedWith</c>.</summary>
    private bool CanBeReplacedWith(FluidState state, Vec3<int> pos, FluidKind other, BlockFace face) {
        return state.Kind switch {
            FluidKind.Empty => true,
            FluidKind.Water => face == BlockFace.NegY && other != FluidKind.Water,
            _ => GetHeight(state, pos) >= LavaMinLevelCutoff && other == FluidKind.Water
        };
    }

    /// <summary><c>FlowingFluid.getHeight</c>: a fluid with the same one above it fills its block.</summary>
    private float GetHeight(FluidState state, Vec3<int> pos) {
        return GetState(FluidDirections.Above(pos)).Fluid.Kind == state.Kind ? 1.0f : state.OwnHeight;
    }

    private int GetDropOff(FluidKind kind) => kind == FluidKind.Water ? 1 : FastLava ? 1 : 2;

    private int GetSlopeFindDistance(FluidKind kind) => kind == FluidKind.Water ? 4 : FastLava ? 4 : 2;

    public int GetTickDelay(FluidKind kind) => kind == FluidKind.Water ? 5 : FastLava ? 10 : 30;

    private bool CanConvertToSource(FluidKind kind) =>
        kind == FluidKind.Water ? WaterSourceConversion : LavaSourceConversion;

    /// <summary>
    /// <c>LavaFluid.getSpreadDelay</c>: lava that is about to get deeper usually waits four times as
    /// long, which is what makes a lava pool fill in visible steps.
    /// </summary>
    private int GetSpreadDelay(Vec3<int> pos, FluidState oldFluidState, FluidState newFluidState) {
        int delay = GetTickDelay(oldFluidState.Kind);
        if (oldFluidState.Kind != FluidKind.Lava) {
            return delay;
        }

        if (!oldFluidState.IsEmpty && !newFluidState.IsEmpty && !oldFluidState.Falling && !newFluidState.Falling &&
            GetHeight(newFluidState, pos) > GetHeight(oldFluidState, pos) && Random.Shared.Next(4) != 0) {
            delay *= 4;
        }

        return delay;
    }

    #endregion

    #region world_access

    /// <summary>
    /// The state at a position, or a solid one for anything outside the world or in a chunk that is not
    /// loaded. Vanilla never ticks a fluid whose neighbours aren't loaded; treating them as walls keeps
    /// a pour at a chunk border from dragging the rest of the world in behind it.
    /// </summary>
    public Entry GetState(Vec3<int> pos) {
        return FluidBlockData.Get(Registry, World.GetBlockStateIdOr(pos.X, pos.Y, pos.Z, uint.MaxValue));
    }

    /// <summary>
    /// Writes a block and runs the neighbour updates that follow it, which is what vanilla's
    /// <c>setBlock</c> with flag 3 does inline. Doing it here rather than off the world's change event
    /// keeps a spread self consistent: every block it places has scheduled its neighbours before the
    /// next one is looked at.
    /// </summary>
    public void SetBlock(Vec3<int> pos, IBlock block) {
        if (!World.IsInBounds(new Vec3<double>(pos.X, pos.Y, pos.Z))) {
            return;
        }

        Writing = true;
        try {
            World.SetBlock(pos, block);
        }
        finally {
            Writing = false;
        }

        OnBlockChanged(pos);
    }

    #endregion

    /// <summary>
    /// <c>FlowingFluid.SpreadContext</c>: the slope search walks the same positions over and over, so
    /// the blocks it reads and the holes it found are remembered for the length of one search.
    /// </summary>
    private sealed class SpreadContext(FluidSimulation fluids) {
        private readonly Dictionary<Vec3<int>, Entry> _states = [];
        private readonly Dictionary<Vec3<int>, bool> _holes = [];

        public Entry GetState(Vec3<int> pos) {
            if (_states.TryGetValue(pos, out Entry? cached)) {
                return cached;
            }

            Entry state = fluids.GetState(pos);
            _states[pos] = state;
            return state;
        }

        public bool IsHole(FluidKind kind, Vec3<int> pos) {
            if (_holes.TryGetValue(pos, out bool cached)) {
                return cached;
            }

            Vec3<int> below = FluidDirections.Below(pos);
            bool hole = fluids.IsWaterHole(kind, GetState(pos), pos, fluids.GetState(below), below);
            _holes[pos] = hole;
            return hole;
        }
    }
}
