using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>SculkPatchFeature</c>: the deep dark's floor, grown out of a charge that walks and spends itself.
/// </summary>
/// <remarks>
/// Not a shape drawn at a position like every other feature here. A charge is dropped at the origin
/// and walks from block to block, turning what it stands on into sculk, hanging veins off the faces
/// around it and occasionally paying for a sensor or a shrieker, until it has decayed to nothing. So
/// the result is a function of every draw the walk made, which is why it is transcribed whole rather
/// than approximated: there is no shape to get roughly right.
/// </remarks>
public sealed record SculkPatchFeature(int ChargeCount, int AmountPerCharge, int SpreadAttempts,
    int SpreadRounds, int GrowthRounds) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;
        RandomSource random = context.Random;

        if (!CanSpreadFrom(level, origin)) {
            return false;
        }

        SculkSpreader spreader = SculkSpreader.WorldGen();
        int rounds = SpreadRounds + GrowthRounds;

        for (int round = 0; round < rounds; round++) {
            for (int i = 0; i < ChargeCount; i++) {
                spreader.AddCursors(origin, AmountPerCharge);
            }

            bool spreadVeins = round < SpreadRounds;

            for (int i = 0; i < SpreadAttempts; i++) {
                spreader.UpdateCursors(level, origin, random, spreadVeins);
            }

            spreader.Clear();
        }

        return true;
    }

    /// <summary>
    /// Whether a charge dropped here has anything to eat: sculk already, or an open position with a
    /// full block beside it. Water counts, but only a source.
    /// </summary>
    private static bool CanSpreadFrom(IFeatureLevel level, Vec3<int> origin) {
        uint state = level.GetState(origin.X, origin.Y, origin.Z);

        if (SculkSpreader.BehaviourOf(level, state) != SculkBehaviourKind.None) {
            return true;
        }

        // A water source only: the block has to be water and the fluid in it has to be a source, so
        // flowing water beside a spring is not somewhere a charge starts.
        bool open = level.Blocks.IsAir(state)
            || (Named(level, state).Equals(Block.Water.Identifier) && IsSource(level, state));

        if (!open) {
            return false;
        }

        foreach (BlockFace face in SculkSpreader.Faces) {
            Vec3<int> beside = origin + SculkSpreader.Step(face);
            if (IsFullBlock(level, beside)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Whether the water here is a source, which is <c>level</c> zero. Water's level has no generated
    /// property interface, so the record is named directly.
    /// </summary>
    internal static bool IsSource(IFeatureLevel level, uint state) {
        return level.Registry.Blocks.GetByStateId(state) is not WaterBlock water || water.Level == 0;
    }

    internal static Identifier Named(IFeatureLevel level, uint state) {
        return level.Registry.Blocks.GetByStateId(state).Identifier;
    }

    /// <summary>
    /// A shrieker that can summon, which is what world generation places and a live catalyst does not.
    /// <c>can_summon</c> has no generated property interface, so the record is named directly.
    /// </summary>
    internal static uint Shrieker(bool canSummon) {
        return ((SculkShriekerBlock)Block.SculkShrieker) with { CanSummon = canSummon } is { } shrieker
            ? shrieker.StateId
            : Block.SculkShrieker.StateId;
    }

    internal static bool IsFullBlock(IFeatureLevel level, Vec3<int> pos) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
        return ShapeSupport.IsShapeFullBlock(block.CollisionShape);
    }

    internal static bool IsFaceSturdy(IFeatureLevel level, Vec3<int> pos, BlockFace face) {
        return ShapeSupport.IsFaceSturdy(
            level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z)), face);
    }
}

/// <summary>Which of the three <c>SculkBehaviour</c> implementations a block has.</summary>
internal enum SculkBehaviourKind {
    /// <summary>Not sculk at all, which gets vanilla's <c>SculkBehaviour.DEFAULT</c>.</summary>
    None,
    Sculk,
    Vein
}

/// <summary>
/// <c>SculkSpreader</c>: the charges walking out from a catalyst, and what each does where it stands.
/// </summary>
/// <remarks>
/// The world generation spreader is a different set of numbers from the one a catalyst uses in a live
/// world, and they are not interchangeable: it replaces a wider tag, pays fifty for a growth rather
/// than ten, and refuses to leave a fifteen block cylinder around where it started.
/// <p/>
/// Only the world generation half is here. A live catalyst needs a block entity, an entity dying near
/// it, and a tick to spread on, none of which this build has.
/// </remarks>
internal sealed class SculkSpreader {
    private const int MaxCursors = 32;
    private const int MaxCharge = 1000;
    private const int MaxGrowthRateRadius = 24;

    /// <summary><c>Direction.values()</c>, which is the order every unshuffled walk over faces takes.</summary>
    internal static readonly BlockFace[] Faces = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    private static readonly Identifier SculkReplaceableWorldGen = "minecraft:sculk_replaceable_world_gen";
    private static readonly Identifier SculkReplaceable = "minecraft:sculk_replaceable";
    private static readonly Identifier FireTag = "minecraft:fire";

    /// <summary>
    /// The 18 neighbours that share a face or an edge, which is every offset of the three by three
    /// cube except its corners and the middle. Built in vanilla's own order, since it is shuffled.
    /// </summary>
    private static readonly Vec3<int>[] NonCornerNeighbours = BuildNonCornerNeighbours();

    private readonly Identifier _replaceable;
    private readonly int _growthSpawnCost;
    private readonly int _noGrowthRadius;
    private readonly int _chargeDecayRate;
    private readonly int _additionalDecayRate;

    private List<ChargeCursor> _cursors = [];

    private SculkSpreader(Identifier replaceable, int growthSpawnCost, int noGrowthRadius,
        int chargeDecayRate, int additionalDecayRate) {

        _replaceable = replaceable;
        _growthSpawnCost = growthSpawnCost;
        _noGrowthRadius = noGrowthRadius;
        _chargeDecayRate = chargeDecayRate;
        _additionalDecayRate = additionalDecayRate;
    }

    public static SculkSpreader WorldGen() {
        return new SculkSpreader(SculkReplaceableWorldGen, 50, 1, 5, 10);
    }

    public void Clear() => _cursors.Clear();

    public void AddCursors(Vec3<int> start, int charge) {
        while (charge > 0) {
            int current = Math.Min(charge, MaxCharge);

            if (_cursors.Count < MaxCursors) {
                _cursors.Add(new ChargeCursor(start, current));
            }

            charge -= current;
        }
    }

    /// <summary>
    /// One tick of every charge.
    /// </summary>
    /// <remarks>
    /// <b>The merge is skipped during world generation</b>, so two charges standing on the same block
    /// stay two charges. That is upstream's own branch and not a simplification: merging is what stops
    /// a live catalyst's charges multiplying, and doing it here would halve the patch.
    /// </remarks>
    public void UpdateCursors(IFeatureLevel level, Vec3<int> origin, RandomSource random,
        bool spreadVeins) {

        if (_cursors.Count == 0) {
            return;
        }

        List<ChargeCursor> processed = [];
        Dictionary<Vec3<int>, ChargeCursor> byPosition = [];

        foreach (ChargeCursor cursor in _cursors) {
            if (Chessboard(cursor.Position, origin) > 1024) {
                continue;
            }

            cursor.Update(level, origin, random, this, spreadVeins);

            if (cursor.Charge <= 0) {
                continue;
            }

            if (!byPosition.TryGetValue(cursor.Position, out ChargeCursor? existing)) {
                byPosition[cursor.Position] = cursor;
                processed.Add(cursor);
                continue;
            }

            processed.Add(cursor);
            if (cursor.Charge < existing.Charge) {
                byPosition[cursor.Position] = cursor;
            }
        }

        _cursors = processed;
    }

    public Identifier Replaceable => _replaceable;
    public int GrowthSpawnCost => _growthSpawnCost;
    public int NoGrowthRadius => _noGrowthRadius;
    public int ChargeDecayRate => _chargeDecayRate;
    public int AdditionalDecayRate => _additionalDecayRate;

    /// <summary><c>BlockPos.distChessboard</c>: the largest of the three axis distances.</summary>
    private static int Chessboard(Vec3<int> a, Vec3<int> b) {
        return Math.Max(Math.Abs(a.X - b.X), Math.Max(Math.Abs(a.Y - b.Y), Math.Abs(a.Z - b.Z)));
    }

    /// <summary><c>Vec3i.closerThan</c>, which measures from block centre to block centre.</summary>
    internal static bool CloserThan(Vec3<int> a, Vec3<int> b, double distance) {
        double dx = a.X - b.X, dy = a.Y - b.Y, dz = a.Z - b.Z;
        return dx * dx + dy * dy + dz * dz < distance * distance;
    }

    internal static Vec3<int> Step(BlockFace face) => face switch {
        BlockFace.NegY => new Vec3<int>(0, -1, 0),
        BlockFace.PosY => new Vec3<int>(0, 1, 0),
        BlockFace.NegZ => new Vec3<int>(0, 0, -1),
        BlockFace.PosZ => new Vec3<int>(0, 0, 1),
        BlockFace.NegX => new Vec3<int>(-1, 0, 0),
        _ => new Vec3<int>(1, 0, 0)
    };

    internal static BlockFace Opposite(BlockFace face) => face switch {
        BlockFace.NegY => BlockFace.PosY,
        BlockFace.PosY => BlockFace.NegY,
        BlockFace.NegZ => BlockFace.PosZ,
        BlockFace.PosZ => BlockFace.NegZ,
        BlockFace.NegX => BlockFace.PosX,
        _ => BlockFace.NegX
    };

    internal static SculkBehaviourKind BehaviourOf(IFeatureLevel level, uint state) {
        Identifier id = SculkPatchFeature.Named(level, state);

        if (id.Equals(Block.Sculk.Identifier)) {
            return SculkBehaviourKind.Sculk;
        }

        return id.Equals(Block.SculkVein.Identifier) ? SculkBehaviourKind.Vein : SculkBehaviourKind.None;
    }

    private static Vec3<int>[] BuildNonCornerNeighbours() {
        List<Vec3<int>> offsets = [];

        // BlockPos.betweenClosedStream varies x fastest, then y, then z, and the shuffle below is over
        // that order, so it is not free to build these any other way: a different order here is a
        // different walk for the same draws, and the patch comes out somewhere else.
        for (int z = -1; z <= 1; z++) {
            for (int y = -1; y <= 1; y++) {
                for (int x = -1; x <= 1; x++) {
                    if ((x == 0 || y == 0 || z == 0) && (x != 0 || y != 0 || z != 0)) {
                        offsets.Add(new Vec3<int>(x, y, z));
                    }
                }
            }
        }

        return offsets.ToArray();
    }

    /// <summary>One charge: where it is, how much is left, and how long until it may act again.</summary>
    internal sealed class ChargeCursor(Vec3<int> position, int charge) {
        public Vec3<int> Position { get; private set; } = position;
        public int Charge { get; private set; } = charge;

        private int _updateDelay;
        private int _decayDelay = 1;

        /// <summary>The faces of the vein it is standing on, or null when it is not on one.</summary>
        private List<BlockFace>? _facings;

        public void Update(IFeatureLevel level, Vec3<int> origin, RandomSource random,
            SculkSpreader spreader, bool spreadVeins) {

            if (Charge <= 0) {
                return;
            }

            if (_updateDelay > 0) {
                _updateDelay--;
                return;
            }

            uint state = level.GetState(Position.X, Position.Y, Position.Z);
            SculkBehaviourKind behaviour = BehaviourOf(level, state);

            if (spreadVeins && AttemptSpreadVein(level, Position, state, behaviour, _facings)) {
                if (behaviour != SculkBehaviourKind.Sculk) {
                    state = level.GetState(Position.X, Position.Y, Position.Z);
                    behaviour = BehaviourOf(level, state);
                }
            }

            Charge = AttemptUseCharge(level, origin, random, spreader, spreadVeins, behaviour);

            if (Charge <= 0) {
                OnDischarged(level, state, Position, behaviour);
                return;
            }

            // A world generation cursor with nowhere to move discharges where it stands; one that
            // could only move outside the twelve block cylinder around its origin has nowhere to move.
            if (ValidMovementPosition(level, Position, random, origin) is not { } next) {
                OnDischarged(level, state, Position, behaviour);
                Charge = 0;
                return;
            }

            OnDischarged(level, state, Position, behaviour);
            Position = next;
            state = level.GetState(next.X, next.Y, next.Z);

            if (BehaviourOf(level, state) != SculkBehaviourKind.None) {
                _facings = AvailableFaces(level, state);
            }

            _decayDelay = behaviour == SculkBehaviourKind.None ? Math.Max(_decayDelay - 1, 0) : 1;
            _updateDelay = 1;
        }

        private int AttemptUseCharge(IFeatureLevel level, Vec3<int> origin, RandomSource random,
            SculkSpreader spreader, bool spreadVeins, SculkBehaviourKind behaviour) {

            return behaviour switch {
                SculkBehaviourKind.Sculk => SculkCharge(level, origin, random, spreader),
                SculkBehaviourKind.Vein => VeinCharge(level, random, spreader, spreadVeins),
                _ => _decayDelay > 0 ? Charge : 0
            };
        }

        /// <summary><c>SculkBlock.attemptUseCharge</c>: pay for a growth, or decay by distance.</summary>
        private int SculkCharge(IFeatureLevel level, Vec3<int> origin, RandomSource random,
            SculkSpreader spreader) {

            if (Charge == 0 || random.NextInt(spreader.ChargeDecayRate) != 0) {
                return Charge;
            }

            bool nearOrigin = CloserThan(Position, origin, spreader.NoGrowthRadius);

            if (!nearOrigin && CanPlaceGrowth(level, Position)) {
                int cost = spreader.GrowthSpawnCost;

                if (random.NextInt(cost) < Charge) {
                    Vec3<int> above = Position.WithY(Position.Y + 1);
                    level.SetState(above.X, above.Y, above.Z, RandomGrowth(level, above, random));
                }

                return Math.Max(0, Charge - cost);
            }

            if (random.NextInt(spreader.AdditionalDecayRate) != 0) {
                return Charge;
            }

            return Charge - (nearOrigin ? 1 : DecayPenalty(spreader, Position, origin, Charge));
        }

        /// <summary>
        /// How much a charge loses for being far from its origin, which is what stops a patch running
        /// on forever. The square root and the squares are vanilla's and are float throughout.
        /// </summary>
        private static int DecayPenalty(SculkSpreader spreader, Vec3<int> pos, Vec3<int> origin,
            int charge) {

            int radius = spreader.NoGrowthRadius;
            double dx = pos.X - origin.X, dy = pos.Y - origin.Y, dz = pos.Z - origin.Z;

            float outer = (float)(Math.Sqrt(dx * dx + dy * dy + dz * dz) - radius);
            outer *= outer;

            int reach = (MaxGrowthRateRadius - radius) * (MaxGrowthRateRadius - radius);
            float factor = Math.Min(1.0f, outer / reach);

            return Math.Max(1, (int)(charge * factor * 0.5f));
        }

        /// <summary><c>SculkVeinBlock.attemptUseCharge</c>: turn what the vein clings to into sculk.</summary>
        private int VeinCharge(IFeatureLevel level, RandomSource random, SculkSpreader spreader,
            bool spreadVeins) {

            if (spreadVeins && AttemptPlaceSculk(level, Position, random, spreader)) {
                return Charge - 1;
            }

            return random.NextInt(spreader.ChargeDecayRate) == 0 ? (int)Math.Floor(Charge * 0.5f) : Charge;
        }

        private static bool CanPlaceGrowth(IFeatureLevel level, Vec3<int> pos) {
            Vec3<int> above = pos.WithY(pos.Y + 1);
            uint state = level.GetState(above.X, above.Y, above.Z);

            bool open = level.Blocks.IsAir(state)
                || (SculkPatchFeature.Named(level, state).Equals(Block.Water.Identifier)
                    && level.Blocks.HasFluidAt(state));

            if (!open) {
                return false;
            }

            int growths = 0;

            for (int x = pos.X - 4; x <= pos.X + 4; x++) {
                for (int y = pos.Y; y <= pos.Y + 2; y++) {
                    for (int z = pos.Z - 4; z <= pos.Z + 4; z++) {
                        Identifier id = SculkPatchFeature.Named(level, level.GetState(x, y, z));

                        if (id.Equals(Block.SculkSensor.Identifier)
                            || id.Equals(Block.SculkShrieker.Identifier)) {

                            growths++;
                        }

                        if (growths > 2) {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>A shrieker one time in eleven, a sensor otherwise, waterlogged where it is wet.</summary>
        private static uint RandomGrowth(IFeatureLevel level, Vec3<int> pos, RandomSource random) {
            IBlock state = random.NextInt(11) == 0
                ? level.Registry.Blocks.GetByStateId(SculkPatchFeature.Shrieker(true))
                : Block.SculkSensor;

            if (state is IWaterlogged waterlogged
                && level.Blocks.HasFluidAt(level.GetState(pos.X, pos.Y, pos.Z))) {

                return waterlogged.WithWaterlogged(true).StateId;
            }

            return state.StateId;
        }

        private bool AttemptPlaceSculk(IFeatureLevel level, Vec3<int> pos, RandomSource random,
            SculkSpreader spreader) {

            uint state = level.GetState(pos.X, pos.Y, pos.Z);

            foreach (BlockFace support in FeatureUtil.Shuffled(Faces, random)) {
                if (!HasFace(level, state, support)) {
                    continue;
                }

                Vec3<int> supportPos = pos + Step(support);
                uint supportState = level.GetState(supportPos.X, supportPos.Y, supportPos.Z);

                if (!level.Blocks.IsIn(spreader.Replaceable, supportState)) {
                    continue;
                }

                level.SetState(supportPos.X, supportPos.Y, supportPos.Z, Block.Sculk.StateId);
                MultifaceSpreader.SpreadAll(level, Block.Sculk.StateId, supportPos);

                BlockFace skip = Opposite(support);

                foreach (BlockFace face in Faces) {
                    if (face == skip) {
                        continue;
                    }

                    Vec3<int> veinPos = supportPos + Step(face);
                    uint veinState = level.GetState(veinPos.X, veinPos.Y, veinPos.Z);

                    if (SculkPatchFeature.Named(level, veinState).Equals(Block.SculkVein.Identifier)) {
                        OnDischarged(level, veinState, veinPos, SculkBehaviourKind.Vein);
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// <c>SculkVeinBlock.onDischarged</c>: a vein loses every face that has become sculk, and goes
        /// away entirely once it has none left.
        /// </summary>
        private static void OnDischarged(IFeatureLevel level, uint state, Vec3<int> pos,
            SculkBehaviourKind behaviour) {

            if (behaviour != SculkBehaviourKind.Vein) {
                return;
            }

            IBlock block = level.Registry.Blocks.GetByStateId(state);
            if (block is not IFaceConnected connected) {
                return;
            }

            foreach (BlockFace face in Faces) {
                if (!connected.Connected(face)) {
                    continue;
                }

                Vec3<int> beside = pos + Step(face);
                if (SculkPatchFeature.Named(level, level.GetState(beside.X, beside.Y, beside.Z))
                    .Equals(Block.Sculk.Identifier)) {

                    connected = (IFaceConnected)connected.WithConnection(face, false);
                }
            }

            bool anyFace = Faces.Any(connected.Connected);

            uint replacement = anyFace
                ? connected.StateId
                : level.Blocks.HasFluidAt(state) ? Block.Water.StateId : Block.Air.StateId;

            level.SetState(pos.X, pos.Y, pos.Z, replacement);
        }

        /// <summary>
        /// <c>attemptSpreadVein</c>. A null face set means the charge has never stood on a vein, which
        /// is what a fresh charge is, and it grows one in place instead of regrowing a remembered one.
        /// </summary>
        private static bool AttemptSpreadVein(IFeatureLevel level, Vec3<int> pos, uint state,
            SculkBehaviourKind behaviour, List<BlockFace>? facings) {

            if (behaviour != SculkBehaviourKind.None) {
                return MultifaceSpreader.SpreadAll(level, state, pos) > 0;
            }

            if (facings == null) {
                return MultifaceSpreader.SpreadAllSameSpace(level, pos) > 0;
            }

            if (facings.Count == 0) {
                return MultifaceSpreader.SpreadAll(level, state, pos) > 0;
            }

            bool open = level.Blocks.IsAir(state) || level.Blocks.HasFluidAt(state);
            return open && Regrow(level, pos, state, facings);
        }

        /// <summary><c>SculkVeinBlock.regrow</c>: put a vein back on whichever faces still hold it.</summary>
        private static bool Regrow(IFeatureLevel level, Vec3<int> pos, uint existing,
            List<BlockFace> faces) {

            IBlock vein = Block.SculkVein;
            if (vein is not IFaceConnected connected) {
                return false;
            }

            bool any = false;

            foreach (BlockFace face in faces) {
                if (!CanAttachTo(level, pos, face)) {
                    continue;
                }

                connected = (IFaceConnected)connected.WithConnection(face, true);
                any = true;
            }

            if (!any) {
                return false;
            }

            IBlock placed = connected;
            if (level.Blocks.HasFluidAt(existing) && placed is IWaterlogged waterlogged) {
                placed = waterlogged.WithWaterlogged(true);
            }

            level.SetState(pos.X, pos.Y, pos.Z, placed.StateId);
            return true;
        }

        private static List<BlockFace> AvailableFaces(IFeatureLevel level, uint state) {
            List<BlockFace> faces = [];

            if (level.Registry.Blocks.GetByStateId(state) is IFaceConnected connected) {
                foreach (BlockFace face in Faces) {
                    if (connected.Connected(face)) {
                        faces.Add(face);
                    }
                }
            }

            return faces;
        }

        /// <summary>
        /// Where the charge steps next: a neighbour that is already sculk, preferring one whose vein
        /// still has something replaceable behind it.
        /// </summary>
        /// <remarks>
        /// The loop keeps the last candidate it saw rather than the first, and only stops early on a
        /// vein with substrate. So a walk over several sculk neighbours ends on whichever the shuffle
        /// put last, which is what makes the patch wander.
        /// </remarks>
        private static Vec3<int>? ValidMovementPosition(IFeatureLevel level, Vec3<int> pos,
            RandomSource random, Vec3<int> origin) {

            Vec3<int> chosen = pos;

            foreach (Vec3<int> offset in FeatureUtil.Shuffled(NonCornerNeighbours, random)) {
                Vec3<int> neighbour = pos + offset;

                // canMoveToPos, which only world generation applies.
                int dx = origin.X - neighbour.X;
                int dz = origin.Z - neighbour.Z;
                if (dx * dx + dz * dz > 144) {
                    continue;
                }

                uint state = level.GetState(neighbour.X, neighbour.Y, neighbour.Z);

                if (BehaviourOf(level, state) == SculkBehaviourKind.None
                    || !MovementUnobstructed(level, pos, neighbour)) {

                    continue;
                }

                chosen = neighbour;

                if (HasSubstrateAccess(level, state, neighbour)) {
                    break;
                }
            }

            return chosen == pos ? null : chosen;
        }

        private static bool HasSubstrateAccess(IFeatureLevel level, uint state, Vec3<int> pos) {
            if (!SculkPatchFeature.Named(level, state).Equals(Block.SculkVein.Identifier)) {
                return false;
            }

            foreach (BlockFace face in Faces) {
                if (!HasFace(level, state, face)) {
                    continue;
                }

                Vec3<int> beside = pos + Step(face);
                if (level.Blocks.IsIn(SculkReplaceable,
                    level.GetState(beside.X, beside.Y, beside.Z))) {

                    return true;
                }
            }

            return false;
        }

        /// <summary>Whether a diagonal step has an open side to go round, rather than cutting a corner.</summary>
        private static bool MovementUnobstructed(IFeatureLevel level, Vec3<int> from, Vec3<int> to) {
            Vec3<int> delta = to - from;

            if (Math.Abs(delta.X) + Math.Abs(delta.Y) + Math.Abs(delta.Z) == 1) {
                return true;
            }

            BlockFace x = delta.X < 0 ? BlockFace.NegX : BlockFace.PosX;
            BlockFace y = delta.Y < 0 ? BlockFace.NegY : BlockFace.PosY;
            BlockFace z = delta.Z < 0 ? BlockFace.NegZ : BlockFace.PosZ;

            if (delta.X == 0) {
                return Unobstructed(level, from, y) || Unobstructed(level, from, z);
            }

            return delta.Y == 0
                ? Unobstructed(level, from, x) || Unobstructed(level, from, z)
                : Unobstructed(level, from, x) || Unobstructed(level, from, y);
        }

        private static bool Unobstructed(IFeatureLevel level, Vec3<int> from, BlockFace face) {
            Vec3<int> at = from + Step(face);
            return !SculkPatchFeature.IsFaceSturdy(level, at, Opposite(face));
        }

        internal static bool HasFace(IFeatureLevel level, uint state, BlockFace face) {
            return level.Registry.Blocks.GetByStateId(state) is IFaceConnected connected
                && connected.Connected(face);
        }

        internal static bool CanAttachTo(IFeatureLevel level, Vec3<int> pos, BlockFace towards) {
            Vec3<int> neighbour = pos + Step(towards);
            IBlock block = level.Registry.Blocks
                .GetByStateId(level.GetState(neighbour.X, neighbour.Y, neighbour.Z));

            BlockFace against = Opposite(towards);
            return ShapeSupport.IsFaceFull(block.SupportShape, against)
                || ShapeSupport.IsFaceFull(block.CollisionShape, against);
        }
    }
}
