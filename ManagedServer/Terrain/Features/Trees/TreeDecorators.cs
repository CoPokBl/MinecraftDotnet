using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Placement;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Trees;

/// <summary>
/// What a decorator can see of the tree that was just placed.
/// </summary>
/// <remarks>
/// The three lists are <b>sorted by y</b>, which several decorators depend on: the beehive and the
/// cocoa pods both work from the lowest log, and the pale moss patch grows under the lowest one.
/// </remarks>
public sealed class TreeDecoratorContext(PlacementContext placement, ITreeWriter writer, RandomSource random,
    IReadOnlyList<Vec3<int>> logs, IReadOnlyList<Vec3<int>> leaves, IReadOnlyList<Vec3<int>> roots) {

    private readonly IFeatureLevel level = placement.Level;

    /// <summary>
    /// Carried so a decorator can run a whole configured feature, which the pale moss one does for its
    /// ground patch.
    /// </summary>
    public PlacementContext PlacementContext => placement.Nested();

    public IFeatureLevel Level => level;
    public RandomSource Random => random;
    public IReadOnlyList<Vec3<int>> Logs => logs;
    public IReadOnlyList<Vec3<int>> Leaves => leaves;
    public IReadOnlyList<Vec3<int>> Roots => roots;

    public void SetBlock(Vec3<int> pos, IBlock state) => writer.SetDecoration(pos, state);

    public bool IsAir(Vec3<int> pos) => level.Blocks.IsAir(level.GetState(pos.X, pos.Y, pos.Z));

    public IBlock BlockAt(Vec3<int> pos) => level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));

    /// <summary><c>canBeReplaced</c> at the position.</summary>
    public bool IsReplaceable(Vec3<int> pos) => level.Blocks.IsReplaceable(level.GetState(pos.X, pos.Y, pos.Z));

    /// <summary>
    /// The water block at the position or at one of its four horizontal neighbours, asked east, west,
    /// north, south. The block, not the fluid: a waterlogged log does not count.
    /// </summary>
    public bool IsWaterOrWaterNearby(Vec3<int> pos) {
        return IsWaterBlock(pos) || IsWaterBlock(pos + new Vec3<int>(1, 0, 0))
            || IsWaterBlock(pos + new Vec3<int>(-1, 0, 0)) || IsWaterBlock(pos + new Vec3<int>(0, 0, -1))
            || IsWaterBlock(pos + new Vec3<int>(0, 0, 1));
    }

    private bool IsWaterBlock(Vec3<int> pos) => BlockAt(pos).Identifier.Equals(Block.Water.Identifier);

    /// <summary>A vine attached on one side, which is how both vine decorators place theirs.</summary>
    /// <remarks>
    /// The face is the one the vine holds onto, which is the opposite of the direction the decorator
    /// stepped in to reach the position.
    /// </remarks>
    public void PlaceVine(Vec3<int> pos, BlockFace attachedTo) {
        IBlock vine = Block.Vine;
        SetBlock(pos, vine is IFaceConnected connected ? connected.WithConnection(attachedTo, true) : vine);
    }
}

/// <summary>
/// <c>TreeDecorator</c>: what goes on the tree once its wood and leaves are down.
/// </summary>
public abstract record TreeDecorator {
    public abstract void Place(TreeDecoratorContext context);

    /// <summary><c>Util.shuffle</c>, shared with the other features that draw an order.</summary>
    protected static List<T> Shuffled<T>(IReadOnlyList<T> values, RandomSource random) {
        return FeatureUtil.Shuffled(values, random);
    }

    /// <summary>
    /// <c>TreeFeature.getLowestTrunkOrRootOfTree</c>: what a ground decorator measures from.
    /// </summary>
    /// <remarks>
    /// The three way split matters. With no roots it is the logs; with roots starting at the same y as
    /// the logs it is both; otherwise it is the roots alone, which is the mangrove standing on stilts.
    /// </remarks>
    protected static List<Vec3<int>> LowestTrunkOrRoot(TreeDecoratorContext context) {
        List<Vec3<int>> positions = [];

        if (context.Roots.Count == 0) {
            positions.AddRange(context.Logs);
        } else if (context.Logs.Count > 0 && context.Roots[0].Y == context.Logs[0].Y) {
            positions.AddRange(context.Logs);
            positions.AddRange(context.Roots);
        } else {
            positions.AddRange(context.Roots);
        }

        return positions;
    }

    /// <summary>
    /// <c>TrunkVineDecorator</c>: vines on two thirds of the trunk's exposed sides.
    /// </summary>
    /// <remarks>
    /// The four draws happen whether or not the side is free, so the shape of the trunk cannot change
    /// how much random the tree consumes.
    /// </remarks>
    public sealed record TrunkVine : TreeDecorator {
        public static readonly TrunkVine Instance = new();

        public override void Place(TreeDecoratorContext context) {
            foreach (Vec3<int> pos in context.Logs) {
                TryVine(context, pos, new Vec3<int>(-1, 0, 0), BlockFace.PosX);
                TryVine(context, pos, new Vec3<int>(1, 0, 0), BlockFace.NegX);
                TryVine(context, pos, new Vec3<int>(0, 0, -1), BlockFace.PosZ);
                TryVine(context, pos, new Vec3<int>(0, 0, 1), BlockFace.NegZ);
            }
        }

        private static void TryVine(TreeDecoratorContext context, Vec3<int> pos, Vec3<int> offset,
            BlockFace attachedTo) {

            if (context.Random.NextInt(3) <= 0) {
                return;
            }

            Vec3<int> target = pos + offset;
            if (context.IsAir(target)) {
                context.PlaceVine(target, attachedTo);
            }
        }
    }

    /// <summary>
    /// <c>LeaveVineDecorator</c>: vines hanging off the canopy, each falling up to four blocks.
    /// </summary>
    public sealed record LeaveVine(float Probability) : TreeDecorator {
        public override void Place(TreeDecoratorContext context) {
            foreach (Vec3<int> pos in context.Leaves) {
                TryVine(context, pos, new Vec3<int>(-1, 0, 0), BlockFace.PosX);
                TryVine(context, pos, new Vec3<int>(1, 0, 0), BlockFace.NegX);
                TryVine(context, pos, new Vec3<int>(0, 0, -1), BlockFace.PosZ);
                TryVine(context, pos, new Vec3<int>(0, 0, 1), BlockFace.NegZ);
            }
        }

        private void TryVine(TreeDecoratorContext context, Vec3<int> pos, Vec3<int> offset,
            BlockFace attachedTo) {

            if (!(context.Random.NextFloat() < Probability)) {
                return;
            }

            Vec3<int> target = pos + offset;
            if (!context.IsAir(target)) {
                return;
            }

            context.PlaceVine(target, attachedTo);

            Vec3<int> below = target.WithY(target.Y - 1);
            for (int remaining = 4; context.IsAir(below) && remaining > 0; remaining--) {
                context.PlaceVine(below, attachedTo);
                below = below.WithY(below.Y - 1);
            }
        }
    }

    /// <summary>
    /// <c>CocoaDecorator</c>: pods on the lowest three logs of a jungle tree.
    /// </summary>
    /// <remarks>
    /// The pod's facing is the direction the log was approached from, not the offset it sits at, which
    /// is why the two are opposites here.
    /// </remarks>
    public sealed record Cocoa(float Probability) : TreeDecorator {
        public override void Place(TreeDecoratorContext context) {
            RandomSource random = context.Random;
            if (random.NextFloat() >= Probability || context.Logs.Count == 0) {
                return;
            }

            int treeY = context.Logs[0].Y;

            foreach (Vec3<int> pos in context.Logs) {
                if (pos.Y - treeY > 2) {
                    continue;
                }

                foreach (Vec3<int> direction in TrunkPlacers.Horizontal) {
                    if (!(random.NextFloat() <= 0.25f)) {
                        continue;
                    }

                    Vec3<int> cocoaPos = pos - direction;
                    if (!context.IsAir(cocoaPos)) {
                        continue;
                    }

                    IBlock cocoa = Block.Cocoa;
                    if (cocoa is IAged aged) {
                        cocoa = aged.WithAge(random.NextInt(3));
                    }

                    if (cocoa is IHorizontalFacing facing) {
                        cocoa = facing.WithFacing(FaceOf(direction));
                    }

                    context.SetBlock(cocoaPos, cocoa);
                }
            }
        }

        private static Direction FaceOf(Vec3<int> direction) {
            if (direction.X > 0) {
                return Direction.East;
            }

            if (direction.X < 0) {
                return Direction.West;
            }

            return direction.Z > 0 ? Direction.South : Direction.North;
        }
    }

    /// <summary>
    /// <c>BeehiveDecorator</c>: a bee nest on the side of the trunk, just under the canopy.
    /// </summary>
    /// <remarks>
    /// The nest always faces south, because a hive needs the block in front of it free and worldgen
    /// only ever checks that one direction. The three candidate sides are therefore every horizontal
    /// except north, which would put the nest's face inside the trunk.
    /// <p/>
    /// <b>The nest is placed empty.</b> Vanilla fills it with two or three bees through the block
    /// entity, and there is no block entity for a beehive here. The two draws that would pick the bees
    /// are not made either, so the tree after it in the chunk gets vanilla's numbers.
    /// </remarks>
    public sealed record Beehive(float Probability) : TreeDecorator {
        /// <summary>
        /// <c>Plane.HORIZONTAL</c> with the opposite of the facing filtered out, which leaves east,
        /// south, west. The walk takes the first side that fits, so the order decides which one.
        /// </summary>
        private static readonly Vec3<int>[] SpawnDirections = [
            new(1, 0, 0),   // east
            new(0, 0, 1),   // south
            new(-1, 0, 0)   // west
        ];

        private static readonly Vec3<int> Facing = new(0, 0, 1);

        public override void Place(TreeDecoratorContext context) {
            if (context.Logs.Count == 0) {
                return;
            }

            RandomSource random = context.Random;
            if (random.NextFloat() >= Probability) {
                return;
            }

            int hiveY = context.Leaves.Count > 0
                ? Math.Max(context.Leaves[0].Y - 1, context.Logs[0].Y + 1)
                : Math.Min(context.Logs[0].Y + 1 + random.NextInt(3), context.Logs[^1].Y);

            List<Vec3<int>> placements = [];
            foreach (Vec3<int> log in context.Logs) {
                if (log.Y != hiveY) {
                    continue;
                }

                foreach (Vec3<int> direction in SpawnDirections) {
                    placements.Add(log + direction);
                }
            }

            if (placements.Count == 0) {
                return;
            }

            foreach (Vec3<int> candidate in Shuffled(placements, random)) {
                if (!context.IsAir(candidate) || !context.IsAir(candidate + Facing)) {
                    continue;
                }

                IBlock nest = Block.BeeNest;
                if (nest is IHorizontalFacing facing) {
                    nest = facing.WithFacing(Direction.South);
                }

                context.SetBlock(candidate, nest);
                return;
            }
        }
    }

    /// <summary>
    /// <c>AlterGroundDecorator</c>: the podzol under a spruce, in overlapping discs around the trunk.
    /// </summary>
    /// <remarks>
    /// The four fixed discs are the corners of the two by two trunk and the five random ones are drawn
    /// out of an eight by eight, kept only when they land on its edge. So the count of discs varies
    /// and the count of draws does not.
    /// </remarks>
    public sealed record AlterGround(BlockStateProvider Provider) : TreeDecorator {
        public override void Place(TreeDecoratorContext context) {
            List<Vec3<int>> positions = LowestTrunkOrRoot(context);
            if (positions.Count == 0) {
                return;
            }

            int minY = positions[0].Y;

            foreach (Vec3<int> pos in positions) {
                if (pos.Y != minY) {
                    continue;
                }

                PlaceCircle(context, pos + new Vec3<int>(-1, 0, -1));
                PlaceCircle(context, pos + new Vec3<int>(2, 0, -1));
                PlaceCircle(context, pos + new Vec3<int>(-1, 0, 2));
                PlaceCircle(context, pos + new Vec3<int>(2, 0, 2));

                for (int i = 0; i < 5; i++) {
                    int placement = context.Random.NextInt(64);
                    int x = placement % 8;
                    int z = placement / 8;

                    if (x == 0 || x == 7 || z == 0 || z == 7) {
                        PlaceCircle(context, pos + new Vec3<int>(-3 + x, 0, -3 + z));
                    }
                }
            }
        }

        /// <summary>A five by five with the corners taken off.</summary>
        private void PlaceCircle(TreeDecoratorContext context, Vec3<int> centre) {
            for (int x = -2; x <= 2; x++) {
                for (int z = -2; z <= 2; z++) {
                    if (Math.Abs(x) != 2 || Math.Abs(z) != 2) {
                        PlaceBlockAt(context, centre + new Vec3<int>(x, 0, z));
                    }
                }
            }
        }

        /// <summary>
        /// Walks down the column looking for something the provider will replace, giving up at the
        /// first solid block below the starting level.
        /// </summary>
        private void PlaceBlockAt(TreeDecoratorContext context, Vec3<int> pos) {
            for (int dy = 2; dy >= -3; dy--) {
                Vec3<int> cursor = pos.WithY(pos.Y + dy);

                IBlock? replacement = Provider.GetOptionalState(context.Level, context.Random,
                    cursor.X, cursor.Y, cursor.Z);

                if (replacement is not null) {
                    context.SetBlock(cursor, replacement);
                    return;
                }

                if (!context.IsAir(cursor) && dy < 0) {
                    return;
                }
            }
        }
    }

    /// <summary>
    /// <c>PlaceOnGroundDecorator</c>: scatters blocks on solid ground around the base of the tree,
    /// which is how the pale garden gets its moss and the mangrove its roots' cover.
    /// </summary>
    public sealed record PlaceOnGround(int Tries, int Radius, int Height, BlockStateProvider Provider)
        : TreeDecorator {

        public override void Place(TreeDecoratorContext context) {
            List<Vec3<int>> positions = LowestTrunkOrRoot(context);
            if (positions.Count == 0) {
                return;
            }

            Vec3<int> origin = positions[0];
            int minY = origin.Y;
            int minX = origin.X, maxX = origin.X, minZ = origin.Z, maxZ = origin.Z;

            foreach (Vec3<int> position in positions) {
                if (position.Y != minY) {
                    continue;
                }

                minX = Math.Min(minX, position.X);
                maxX = Math.Max(maxX, position.X);
                minZ = Math.Min(minZ, position.Z);
                maxZ = Math.Max(maxZ, position.Z);
            }

            RandomSource random = context.Random;

            for (int i = 0; i < Tries; i++) {
                Vec3<int> pos = new(
                    random.NextIntBetweenInclusive(minX - Radius, maxX + Radius),
                    random.NextIntBetweenInclusive(minY - Height, minY + Height),
                    random.NextIntBetweenInclusive(minZ - Radius, maxZ + Radius));

                AttemptToPlaceAbove(context, pos);
            }
        }

        /// <summary>
        /// The heightmap test is what keeps this out of a cave under the tree: the position has to be
        /// at or above the top of the terrain, not merely on something solid.
        /// </summary>
        private void AttemptToPlaceAbove(TreeDecoratorContext context, Vec3<int> pos) {
            Vec3<int> above = pos.WithY(pos.Y + 1);
            IFeatureLevel level = context.Level;

            bool aboveIsClear = context.IsAir(above)
                || context.BlockAt(above).Identifier.Equals(Block.Vine.Identifier);

            if (!aboveIsClear) {
                return;
            }

            // isSolidRender, which is the occlusion shape being a full block rather than the collision
            // one, so this settles on a barrel and not on a slab or on glass.
            if (!ShapeSupport.IsShapeFullBlock(context.BlockAt(pos).OcclusionShape)) {
                return;
            }

            if (level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.MotionBlockingNoLeaves, pos.X, pos.Z)
                > above.Y) {

                return;
            }

            context.SetBlock(above, Provider.GetState(level, context.Random, above.X, above.Y, above.Z));
        }
    }

    /// <summary>
    /// <c>AttachedToLogsDecorator</c>: something stuck to a log, which is what puts mushrooms on a
    /// fallen trunk.
    /// </summary>
    /// <remarks>
    /// Simpler than the leaves version and not a special case of it: there is no exclusion box and no
    /// clearance test, so two of these can end up side by side. The direction is drawn before the
    /// probability, so both are consumed for every log whatever the outcome.
    /// </remarks>
    public sealed record AttachedToLogs(float Probability, BlockStateProvider Provider,
        IReadOnlyList<Vec3<int>> Directions) : TreeDecorator {

        public override void Place(TreeDecoratorContext context) {
            RandomSource random = context.Random;

            foreach (Vec3<int> logPos in Shuffled(context.Logs, random)) {
                Vec3<int> placementPos = logPos + Directions[random.NextInt(Directions.Count)];

                if (!(random.NextFloat() <= Probability) || !context.IsAir(placementPos)) {
                    continue;
                }

                context.SetBlock(placementPos,
                    Provider.GetState(context.Level, random, placementPos.X, placementPos.Y, placementPos.Z));
            }
        }
    }

    /// <summary>
    /// <c>AttachedToLeavesDecorator</c>: something hanging off the canopy, spaced out by an exclusion
    /// box around each one it places.
    /// </summary>
    public sealed record AttachedToLeaves(float Probability, int ExclusionRadiusXz, int ExclusionRadiusY,
        BlockStateProvider Provider, int RequiredEmptyBlocks, IReadOnlyList<Vec3<int>> Directions)
        : TreeDecorator {

        public override void Place(TreeDecoratorContext context) {
            HashSet<Vec3<int>> excluded = [];
            RandomSource random = context.Random;

            foreach (Vec3<int> leafPos in Shuffled(context.Leaves, random)) {
                Vec3<int> direction = Directions[random.NextInt(Directions.Count)];
                Vec3<int> placementPos = leafPos + direction;

                if (excluded.Contains(placementPos) || !(random.NextFloat() < Probability)
                    || !HasRequiredEmptyBlocks(context, leafPos, direction)) {

                    continue;
                }

                for (int x = -ExclusionRadiusXz; x <= ExclusionRadiusXz; x++) {
                    for (int y = -ExclusionRadiusY; y <= ExclusionRadiusY; y++) {
                        for (int z = -ExclusionRadiusXz; z <= ExclusionRadiusXz; z++) {
                            excluded.Add(placementPos + new Vec3<int>(x, y, z));
                        }
                    }
                }

                context.SetBlock(placementPos, Provider.GetState(context.Level, random,
                    placementPos.X, placementPos.Y, placementPos.Z));
            }
        }

        private bool HasRequiredEmptyBlocks(TreeDecoratorContext context, Vec3<int> leafPos,
            Vec3<int> direction) {

            for (int i = 1; i <= RequiredEmptyBlocks; i++) {
                if (!context.IsAir(leafPos + direction * i)) {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// <c>CreakingHeartDecorator</c>: one heart buried in a pale oak, in a log surrounded by logs on
    /// all six sides.
    /// </summary>
    public sealed record CreakingHeart(float Probability) : TreeDecorator {
        private static readonly Vec3<int>[] AllDirections = [
            new(0, -1, 0), new(0, 1, 0), new(0, 0, -1), new(0, 0, 1), new(-1, 0, 0), new(1, 0, 0)
        ];

        public override void Place(TreeDecoratorContext context) {
            if (context.Logs.Count == 0 || context.Random.NextFloat() >= Probability) {
                return;
            }

            foreach (Vec3<int> candidate in Shuffled(context.Logs, context.Random)) {
                bool surrounded = true;

                foreach (Vec3<int> direction in AllDirections) {
                    Vec3<int> neighbour = candidate + direction;
                    if (!context.Level.Blocks.IsIn(TreeFeature.LogsTag,
                        context.Level.GetState(neighbour.X, neighbour.Y, neighbour.Z))) {

                        surrounded = false;
                        break;
                    }
                }

                if (!surrounded) {
                    continue;
                }

                // Written through the generated record rather than through an interface, because
                // "natural" is one block's property and has none. It has to be set: a heart that is
                // not natural is one a player built.
                IBlock heart = Block.CreakingHeart is CreakingHeartBlock creakingHeart
                    ? creakingHeart with { CreakingHeartState = CreakingHeartState.Dormant, Natural = true }
                    : Block.CreakingHeart;

                context.SetBlock(candidate, heart);
                return;
            }
        }
    }

    /// <summary>
    /// <c>PaleMossDecorator</c>: hanging moss off the trunk and the canopy, and a moss patch on the
    /// ground under the tree.
    /// </summary>
    /// <remarks>
    /// The ground patch runs the <c>pale_moss_patch</c> configured feature, so it is handed in rather
    /// than named here: a decorator that reached into the feature registry would have to know about
    /// the datapack.
    /// <p/>
    /// A hanger's length is a coin flip per block, and the loop always writes a tipped block at the
    /// end, so even a hanger that stops immediately places one.
    /// </remarks>
    public sealed record PaleMoss(float LeavesProbability, float TrunkProbability, float GroundProbability,
        Func<ConfiguredFeature?> GroundPatch) : TreeDecorator {

        public override void Place(TreeDecoratorContext context) {
            RandomSource random = context.Random;
            if (context.Logs.Count == 0) {
                return;
            }

            List<Vec3<int>> shuffled = Shuffled(context.Logs, random);

            Vec3<int> origin = shuffled[0];
            foreach (Vec3<int> log in shuffled) {
                if (log.Y < origin.Y) {
                    origin = log;
                }
            }

            if (random.NextFloat() < GroundProbability && GroundPatch() is { } patch) {
                patch.Place(new FeaturePlaceContext(context.PlacementContext, random,
                    origin.WithY(origin.Y + 1)));
            }

            foreach (Vec3<int> pos in context.Logs) {
                if (random.NextFloat() < TrunkProbability) {
                    Vec3<int> below = pos.WithY(pos.Y - 1);
                    if (context.IsAir(below)) {
                        AddHanger(below, context);
                    }
                }
            }

            foreach (Vec3<int> pos in context.Leaves) {
                if (random.NextFloat() < LeavesProbability) {
                    Vec3<int> below = pos.WithY(pos.Y - 1);
                    if (context.IsAir(below)) {
                        AddHanger(below, context);
                    }
                }
            }
        }

        private static void AddHanger(Vec3<int> pos, TreeDecoratorContext context) {
            while (context.IsAir(pos.WithY(pos.Y - 1)) && !(context.Random.NextFloat() < 0.5)) {
                context.SetBlock(pos, WithTip(false));
                pos = pos.WithY(pos.Y - 1);
            }

            context.SetBlock(pos, WithTip(true));
        }

        private static IBlock WithTip(bool tip) {
            IBlock moss = Block.PaleHangingMoss;
            return moss is ITipped tipped ? tipped.WithTip(tip) : moss;
        }
    }

    /// <summary>
    /// <c>ShelfMushroomDecorator</c>: shelf mushrooms on the side of a trunk or along a fallen log.
    /// </summary>
    /// <remarks>
    /// A log list whose first and last entries share a y is a fallen log, which is how the decorator
    /// tells the two apart; the lists arrive sorted by y. A standing tree picks one compass direction
    /// and its clockwise neighbour once, then for each log one to four above the base tries the two in
    /// that order at one in four each, stopping at the first that places. A fallen log tries both
    /// sides across its axis for every log. The age draw happens only when a mushroom is placed.
    /// </remarks>
    public sealed record ShelfMushroom(float Probability) : TreeDecorator {
        public override void Place(TreeDecoratorContext context) {
            RandomSource random = context.Random;
            if (random.NextFloat() >= Probability) {
                return;
            }

            IReadOnlyList<Vec3<int>> logs = context.Logs;
            if (logs.Count == 0) {
                return;
            }

            if (logs[0].Y == logs[^1].Y) {
                PlaceOnFallenLog(context, logs, random);
            } else {
                PlaceOnStandingTree(context, logs, random);
            }
        }

        private static void PlaceOnStandingTree(TreeDecoratorContext context, IReadOnlyList<Vec3<int>> logs,
            RandomSource random) {

            BlockFace first = Minecraft.Placement.Directions.Horizontal[random.NextInt(4)];
            BlockFace[] directions = [first, first.ToDirection().ClockWise().ToFace()];
            int treeBaseY = logs[0].Y;

            foreach (Vec3<int> logPos in logs) {
                int dy = logPos.Y - treeBaseY;
                if (dy < 1 || dy > 4) {
                    continue;
                }

                foreach (BlockFace facing in directions) {
                    if (!(random.NextFloat() > 0.25f) && TryPlaceOnStandingTree(context, logPos, facing, random)) {
                        break;
                    }
                }
            }
        }

        private static void PlaceOnFallenLog(TreeDecoratorContext context, IReadOnlyList<Vec3<int>> logs,
            RandomSource random) {

            BlockFace[] directions = logs[0].X != logs[^1].X
                ? [BlockFace.NegZ, BlockFace.PosZ]
                : [BlockFace.PosX, BlockFace.NegX];

            foreach (Vec3<int> logPos in logs) {
                foreach (BlockFace facing in directions) {
                    if (random.NextFloat() > 0.25f) {
                        continue;
                    }

                    Vec3<int> mushroomPos = logPos + Placement.PlacementParser.Step(facing);
                    if (IsReplaceableWithShelfMushroom(context, mushroomPos)
                        && !HasHorizontallyAdjacentShelfMushroom(context, mushroomPos)
                        && !HasHorizontallyAdjacentShelfMushroom(context, logPos)) {

                        PlaceMushroom(context, mushroomPos, facing, random);
                    }
                }
            }
        }

        private static bool TryPlaceOnStandingTree(TreeDecoratorContext context, Vec3<int> logPos, BlockFace facing,
            RandomSource random) {

            Vec3<int> mushroomPos = logPos + Placement.PlacementParser.Step(facing);
            if (!IsReplaceableWithShelfMushroom(context, mushroomPos)
                || IsShelfMushroom(context, mushroomPos.WithY(mushroomPos.Y - 1))) {
                return false;
            }

            PlaceMushroom(context, mushroomPos, facing, random);
            return true;
        }

        private static void PlaceMushroom(TreeDecoratorContext context, Vec3<int> pos, BlockFace facing,
            RandomSource random) {

            ShelfMushroomBlock mushroom = (ShelfMushroomBlock)Block.ShelfMushroom;
            context.SetBlock(pos, mushroom with { Age = random.NextInt(2), Facing = facing.ToDirection() });
        }

        private static bool IsShelfMushroom(TreeDecoratorContext context, Vec3<int> pos) {
            return context.BlockAt(pos).Identifier.Equals(Block.ShelfMushroom.Identifier);
        }

        private static bool HasHorizontallyAdjacentShelfMushroom(TreeDecoratorContext context, Vec3<int> pos) {
            foreach (BlockFace face in Minecraft.Placement.Directions.Horizontal) {
                if (IsShelfMushroom(context, pos + Placement.PlacementParser.Step(face))) {
                    return true;
                }
            }

            return false;
        }

        private static bool IsReplaceableWithShelfMushroom(TreeDecoratorContext context, Vec3<int> pos) {
            return context.IsReplaceable(pos) && !context.IsWaterOrWaterNearby(pos);
        }
    }
}
