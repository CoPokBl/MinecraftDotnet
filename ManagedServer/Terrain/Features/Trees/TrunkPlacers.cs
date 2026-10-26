using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Placement;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Trees;

/// <summary>
/// Every <c>TrunkPlacer</c> in the vanilla data.
/// </summary>
/// <remarks>
/// A placer's job is two things at once, and both matter: it writes the wood, and it returns the
/// points the foliage placer will grow leaves from. A transcription that gets the wood right and the
/// attachments wrong gives a tree with its canopy in the wrong place.
/// </remarks>
public static class TrunkPlacers {
    /// <summary>
    /// <c>Direction.Plane.HORIZONTAL</c>, in the order <c>getRandomDirection</c> indexes.
    /// </summary>
    /// <remarks>
    /// Compass order, which is <b>not</b> the horizontal half of <c>Direction.values()</c>: that is
    /// north, south, west, east, and using it here turns every drawn direction into a different one
    /// for the same draw, so a tree comes out leaning the wrong way with the random untouched.
    /// </remarks>
    internal static readonly Vec3<int>[] Horizontal = [
        new(0, 0, -1),  // north
        new(1, 0, 0),   // east
        new(0, 0, 1),   // south
        new(-1, 0, 0)   // west
    ];

    internal static Vec3<int> RandomHorizontal(RandomSource random) {
        return Horizontal[random.NextInt(Horizontal.Length)];
    }

    internal static Vec3<int> Opposite(Vec3<int> direction) {
        return new Vec3<int>(-direction.X, -direction.Y, -direction.Z);
    }

    /// <summary>
    /// <c>trySetValue(AXIS, ...)</c> as a state modifier, which is how a branch comes out lying down.
    /// </summary>
    internal static IBlock WithAxis(IBlock state, Axis axis) {
        return state is IAxisAligned aligned ? aligned.WithAxis(axis) : state;
    }

    internal static Axis AxisOf(Vec3<int> direction) {
        if (direction.X != 0) {
            return Axis.X;
        }

        return direction.Z != 0 ? Axis.Z : Axis.Y;
    }

    /// <summary><c>StraightTrunkPlacer</c>: a column, one attachment on top.</summary>
    public sealed record Straight(int BaseHeight, int HeightRandA, int HeightRandB)
        : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            PlaceBelowTrunkBlock(level, writer, random, origin.WithY(origin.Y - 1), config);

            for (int y = 0; y < treeHeight; y++) {
                PlaceLog(level, writer, random, origin.WithY(origin.Y + y), config);
            }

            return [new FoliageAttachment(origin.WithY(origin.Y + treeHeight), 0, false)];
        }
    }

    /// <summary>
    /// <c>ForkingTrunkPlacer</c>: an oak that leans partway up, plus a second stub in another
    /// direction.
    /// </summary>
    /// <remarks>
    /// The second branch is skipped entirely when its direction comes out the same as the lean, which
    /// is a draw that has already happened either way, so the shape varies but the random does not.
    /// </remarks>
    public sealed record Forking(int BaseHeight, int HeightRandA, int HeightRandB)
        : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            PlaceBelowTrunkBlock(level, writer, random, origin.WithY(origin.Y - 1), config);

            List<FoliageAttachment> attachments = [];
            Vec3<int> lean = RandomHorizontal(random);
            int leanHeight = treeHeight - random.NextInt(4) - 1;
            int leanSteps = 3 - random.NextInt(3);

            int tx = origin.X;
            int tz = origin.Z;
            int? top = null;

            for (int offset = 0; offset < treeHeight; offset++) {
                int y = origin.Y + offset;
                if (offset >= leanHeight && leanSteps > 0) {
                    tx += lean.X;
                    tz += lean.Z;
                    leanSteps--;
                }

                if (PlaceLog(level, writer, random, new Vec3<int>(tx, y, tz), config)) {
                    top = y + 1;
                }
            }

            if (top is { } topY) {
                attachments.Add(new FoliageAttachment(new Vec3<int>(tx, topY, tz), 1, false));
            }

            tx = origin.X;
            tz = origin.Z;

            Vec3<int> branch = RandomHorizontal(random);
            if (branch == lean) {
                return attachments;
            }

            int branchStart = leanHeight - random.NextInt(2) - 1;
            int branchSteps = 1 + random.NextInt(3);
            top = null;

            for (int offset = branchStart; offset < treeHeight && branchSteps > 0; branchSteps--, offset++) {
                if (offset < 1) {
                    continue;
                }

                int y = origin.Y + offset;
                tx += branch.X;
                tz += branch.Z;

                if (PlaceLog(level, writer, random, new Vec3<int>(tx, y, tz), config)) {
                    top = y + 1;
                }
            }

            if (top is { } branchTop) {
                attachments.Add(new FoliageAttachment(new Vec3<int>(tx, branchTop, tz), 0, false));
            }

            return attachments;
        }
    }

    /// <summary>
    /// <c>GiantTrunkPlacer</c>: the two by two trunk of a mega spruce or jungle tree.
    /// </summary>
    /// <remarks>
    /// The top layer is one column rather than four, which is what tapers the trunk into the canopy.
    /// </remarks>
    public record Giant(int BaseHeight, int HeightRandA, int HeightRandB)
        : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            Vec3<int> below = origin.WithY(origin.Y - 1);
            PlaceBelowTrunkBlock(level, writer, random, below, config);
            PlaceBelowTrunkBlock(level, writer, random, below + new Vec3<int>(1, 0, 0), config);
            PlaceBelowTrunkBlock(level, writer, random, below + new Vec3<int>(0, 0, 1), config);
            PlaceBelowTrunkBlock(level, writer, random, below + new Vec3<int>(1, 0, 1), config);

            for (int y = 0; y < treeHeight; y++) {
                PlaceLogIfFree(level, writer, random, origin + new Vec3<int>(0, y, 0), config);

                if (y < treeHeight - 1) {
                    PlaceLogIfFree(level, writer, random, origin + new Vec3<int>(1, y, 0), config);
                    PlaceLogIfFree(level, writer, random, origin + new Vec3<int>(1, y, 1), config);
                    PlaceLogIfFree(level, writer, random, origin + new Vec3<int>(0, y, 1), config);
                }
            }

            return [new FoliageAttachment(origin.WithY(origin.Y + treeHeight), 0, true)];
        }
    }

    /// <summary>
    /// <c>MegaJungleTrunkPlacer</c>: the giant trunk plus branches spiralling off it.
    /// </summary>
    /// <remarks>
    /// The branch offsets go through <see cref="Mth"/>'s sine table rather than accurate trig, as
    /// vanilla's do, so a branch lands on the block vanilla picks at the diagonals.
    /// </remarks>
    public sealed record MegaJungle(int BaseHeight, int HeightRandA, int HeightRandB)
        : Giant(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            List<FoliageAttachment> attachments = [..base.PlaceTrunk(level, writer, random, treeHeight, origin, config)];

            for (int branchHeight = treeHeight - 2 - random.NextInt(4);
                branchHeight > treeHeight / 2;
                branchHeight -= 2 + random.NextInt(4)) {

                float angle = random.NextFloat() * (float)(Math.PI * 2);
                int bx = 0;
                int bz = 0;

                for (int step = 0; step < 5; step++) {
                    bx = (int)(1.5f + Mth.Cos(angle) * step);
                    bz = (int)(1.5f + Mth.Sin(angle) * step);
                    PlaceLog(level, writer, random,
                        origin + new Vec3<int>(bx, branchHeight - 3 + step / 2, bz), config);
                }

                attachments.Add(new FoliageAttachment(
                    origin + new Vec3<int>(bx, branchHeight, bz), -2, false));
            }

            return attachments;
        }
    }

    /// <summary>
    /// <c>DarkOakTrunkPlacer</c>: a two by two trunk that leans, with a scatter of stubby side
    /// branches under the canopy.
    /// </summary>
    public sealed record DarkOak(int BaseHeight, int HeightRandA, int HeightRandB)
        : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            List<FoliageAttachment> attachments = [];

            Vec3<int> below = origin.WithY(origin.Y - 1);
            PlaceBelowTrunkBlock(level, writer, random, below, config);
            PlaceBelowTrunkBlock(level, writer, random, below + new Vec3<int>(1, 0, 0), config);
            PlaceBelowTrunkBlock(level, writer, random, below + new Vec3<int>(0, 0, 1), config);
            PlaceBelowTrunkBlock(level, writer, random, below + new Vec3<int>(1, 0, 1), config);

            Vec3<int> lean = RandomHorizontal(random);
            int leanHeight = treeHeight - random.NextInt(4);
            int leanSteps = 2 - random.NextInt(3);

            int tx = origin.X;
            int tz = origin.Z;
            int topY = origin.Y + treeHeight - 1;

            for (int dy = 0; dy < treeHeight; dy++) {
                if (dy >= leanHeight && leanSteps > 0) {
                    tx += lean.X;
                    tz += lean.Z;
                    leanSteps--;
                }

                Vec3<int> pos = new(tx, origin.Y + dy, tz);
                if (!TreeFeature.IsAirOrLeaves(level, pos)) {
                    continue;
                }

                PlaceLog(level, writer, random, pos, config);
                PlaceLog(level, writer, random, pos + new Vec3<int>(1, 0, 0), config);
                PlaceLog(level, writer, random, pos + new Vec3<int>(0, 0, 1), config);
                PlaceLog(level, writer, random, pos + new Vec3<int>(1, 0, 1), config);
            }

            attachments.Add(new FoliageAttachment(new Vec3<int>(tx, topY, tz), 0, true));

            for (int ox = -1; ox <= 2; ox++) {
                for (int oz = -1; oz <= 2; oz++) {
                    // The four cells of the trunk itself are skipped, so the branches only grow off
                    // the ring around it.
                    if (ox is >= 0 and <= 1 && oz is >= 0 and <= 1) {
                        continue;
                    }

                    if (random.NextInt(3) > 0) {
                        continue;
                    }

                    int length = random.NextInt(3) + 2;
                    for (int branchY = 0; branchY < length; branchY++) {
                        PlaceLog(level, writer, random,
                            new Vec3<int>(origin.X + ox, topY - branchY - 1, origin.Z + oz), config);
                    }

                    attachments.Add(new FoliageAttachment(
                        new Vec3<int>(origin.X + ox, topY, origin.Z + oz), 0, false));
                }
            }

            return attachments;
        }
    }

    /// <summary>
    /// <c>BendingTrunkPlacer</c>: the mangrove's arching trunk, which turns horizontal at the top.
    /// </summary>
    public sealed record Bending(int BaseHeight, int HeightRandA, int HeightRandB, int MinHeightForLeaves,
        IIntProvider BendLength) : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            Vec3<int> direction = RandomHorizontal(random);
            int logHeight = treeHeight - 1;
            Vec3<int> pos = origin;

            PlaceBelowTrunkBlock(level, writer, random, origin.WithY(origin.Y - 1), config);

            List<FoliageAttachment> attachments = [];

            for (int i = 0; i <= logHeight; i++) {
                // The draw happens on every step whether the branch bends or not, so it cannot be
                // folded into the comparison's short circuit.
                if (i + 1 >= logHeight + random.NextInt(2)) {
                    pos += direction;
                }

                if (TreeFeature.ValidTreePos(level, pos)) {
                    PlaceLog(level, writer, random, pos, config);
                }

                if (i >= MinHeightForLeaves) {
                    attachments.Add(new FoliageAttachment(pos, 0, false));
                }

                pos = pos.WithY(pos.Y + 1);
            }

            int bend = BendLength.Sample(random);
            for (int i = 0; i <= bend; i++) {
                if (TreeFeature.ValidTreePos(level, pos)) {
                    PlaceLog(level, writer, random, pos, config);
                }

                attachments.Add(new FoliageAttachment(pos, 0, false));
                pos += direction;
            }

            return attachments;
        }
    }

    /// <summary>
    /// <c>UpwardsBranchingTrunkPlacer</c>: the azalea tree and the tall mangrove, which throw a branch
    /// off any log with a roll.
    /// </summary>
    /// <remarks>
    /// <c>canGrowThrough</c> widens <c>validTreePos</c>, which is what lets the tall mangrove's trunk
    /// pass through the roots it has already placed.
    /// </remarks>
    public sealed record UpwardsBranching(int BaseHeight, int HeightRandA, int HeightRandB,
        IIntProvider ExtraBranchSteps, float PlaceBranchPerLogProbability, IIntProvider ExtraBranchLength,
        Identifier CanGrowThrough) : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override bool ValidTreePos(IFeatureLevel level, Vec3<int> pos) {
            return base.ValidTreePos(level, pos)
                || level.Blocks.IsIn(CanGrowThrough, level.GetState(pos.X, pos.Y, pos.Z));
        }

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            List<FoliageAttachment> attachments = [];

            for (int offset = 0; offset < treeHeight; offset++) {
                int y = origin.Y + offset;
                Vec3<int> logPos = new(origin.X, y, origin.Z);

                if (PlaceLog(level, writer, random, logPos, config) && offset < treeHeight - 1
                    && random.NextFloat() < PlaceBranchPerLogProbability) {

                    Vec3<int> branchDir = RandomHorizontal(random);
                    int branchLength = ExtraBranchLength.Sample(random);
                    int branchStart = Math.Max(0, branchLength - ExtraBranchLength.Sample(random) - 1);
                    int branchSteps = ExtraBranchSteps.Sample(random);

                    PlaceBranch(level, writer, random, treeHeight, config, attachments, logPos, y,
                        branchDir, branchStart, branchSteps);
                }

                if (offset == treeHeight - 1) {
                    attachments.Add(new FoliageAttachment(new Vec3<int>(origin.X, y + 1, origin.Z), 0, false));
                }
            }

            return attachments;
        }

        private void PlaceBranch(IFeatureLevel level, ITreeWriter writer, RandomSource random, int treeHeight,
            TreeConfiguration config, List<FoliageAttachment> attachments, Vec3<int> logPos, int currentHeight,
            Vec3<int> branchDir, int branchStart, int branchSteps) {

            int heightAlongBranch = currentHeight + branchStart;
            int logX = logPos.X;
            int logZ = logPos.Z;

            for (int index = branchStart; index < treeHeight && branchSteps > 0; index++, branchSteps--) {
                if (index < 1) {
                    continue;
                }

                int placementHeight = currentHeight + index;
                logX += branchDir.X;
                logZ += branchDir.Z;
                heightAlongBranch = placementHeight;

                Vec3<int> pos = new(logX, placementHeight, logZ);
                if (PlaceLog(level, writer, random, pos, config)) {
                    heightAlongBranch = placementHeight + 1;
                }

                attachments.Add(new FoliageAttachment(pos, 0, false));
            }

            if (heightAlongBranch - currentHeight > 1) {
                Vec3<int> foliagePos = new(logX, heightAlongBranch, logZ);
                attachments.Add(new FoliageAttachment(foliagePos, 0, false));
                attachments.Add(new FoliageAttachment(foliagePos.WithY(foliagePos.Y - 2), 0, false));
            }
        }
    }

    /// <summary>
    /// <c>CherryTrunkPlacer</c>: a trunk with one, two or three branches that arch out and up.
    /// </summary>
    /// <remarks>
    /// The second branch's offset range is one shorter than the first's and is bumped past it on a
    /// tie, which is what stops both branches leaving the trunk at the same height.
    /// </remarks>
    public sealed record Cherry(int BaseHeight, int HeightRandA, int HeightRandB, IIntProvider BranchCount,
        IIntProvider BranchHorizontalLength, IntProviders.Uniform BranchStartOffsetFromTop,
        IIntProvider BranchEndOffsetFromTop) : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        private readonly IntProviders.Uniform _secondBranchStartOffsetFromTop = new(
            BranchStartOffsetFromTop.MinInclusive, BranchStartOffsetFromTop.MaxInclusive - 1);

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            PlaceBelowTrunkBlock(level, writer, random, origin.WithY(origin.Y - 1), config);

            int firstBranch = Math.Max(0, treeHeight - 1 + BranchStartOffsetFromTop.Sample(random));
            int secondBranch = Math.Max(0, treeHeight - 1 + _secondBranchStartOffsetFromTop.Sample(random));
            if (secondBranch >= firstBranch) {
                secondBranch++;
            }

            int branchCount = BranchCount.Sample(random);
            bool hasMiddleBranch = branchCount == 3;
            bool hasBothSideBranches = branchCount >= 2;

            int trunkHeight;
            if (hasMiddleBranch) {
                trunkHeight = treeHeight;
            } else if (hasBothSideBranches) {
                trunkHeight = Math.Max(firstBranch, secondBranch) + 1;
            } else {
                trunkHeight = firstBranch + 1;
            }

            for (int y = 0; y < trunkHeight; y++) {
                PlaceLog(level, writer, random, origin.WithY(origin.Y + y), config);
            }

            List<FoliageAttachment> attachments = [];
            if (hasMiddleBranch) {
                attachments.Add(new FoliageAttachment(origin.WithY(origin.Y + trunkHeight), 0, false));
            }

            Vec3<int> treeDirection = RandomHorizontal(random);
            Axis sidewaysAxis = AxisOf(treeDirection);

            attachments.Add(GenerateBranch(level, writer, random, treeHeight, origin, config, sidewaysAxis,
                treeDirection, firstBranch, firstBranch < trunkHeight - 1));

            if (hasBothSideBranches) {
                attachments.Add(GenerateBranch(level, writer, random, treeHeight, origin, config, sidewaysAxis,
                    Opposite(treeDirection), secondBranch, secondBranch < trunkHeight - 1));
            }

            return attachments;
        }

        /// <summary>
        /// One branch: two or three horizontal steps away from the trunk, then a walk towards the end
        /// point choosing up or sideways by how far each still is.
        /// </summary>
        private FoliageAttachment GenerateBranch(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            int treeHeight, Vec3<int> origin, TreeConfiguration config, Axis sidewaysAxis,
            Vec3<int> branchDirection, int offsetFromOrigin, bool middleContinuesUpwards) {

            Vec3<int> logPos = origin.WithY(origin.Y + offsetFromOrigin);

            int branchEndOffset = treeHeight - 1 + BranchEndOffsetFromTop.Sample(random);
            bool extendAway = middleContinuesUpwards || branchEndOffset < offsetFromOrigin;
            int distance = BranchHorizontalLength.Sample(random) + (extendAway ? 1 : 0);

            Vec3<int> branchEnd = new(origin.X + branchDirection.X * distance,
                origin.Y + branchEndOffset, origin.Z + branchDirection.Z * distance);

            int steps = extendAway ? 2 : 1;
            for (int i = 0; i < steps; i++) {
                logPos += branchDirection;
                PlaceLog(level, writer, random, logPos, config, state => WithAxis(state, sidewaysAxis));
            }

            int verticalStep = branchEnd.Y > logPos.Y ? 1 : -1;

            while (true) {
                int manhattan = Math.Abs(branchEnd.X - logPos.X) + Math.Abs(branchEnd.Y - logPos.Y)
                    + Math.Abs(branchEnd.Z - logPos.Z);

                if (manhattan == 0) {
                    return new FoliageAttachment(branchEnd.WithY(branchEnd.Y + 1), 0, false);
                }

                float chanceToGrowVertically = (float)Math.Abs(branchEnd.Y - logPos.Y) / manhattan;
                bool growVertically = random.NextFloat() < chanceToGrowVertically;

                logPos = growVertically
                    ? logPos.WithY(logPos.Y + verticalStep)
                    : logPos + branchDirection;

                PlaceLog(level, writer, random, logPos, config,
                    growVertically ? null : state => WithAxis(state, sidewaysAxis));
            }
        }
    }

    /// <summary>
    /// <c>FancyTrunkPlacer</c>: the big oak, built as a set of foliage clusters with limbs drawn back
    /// to a central trunk.
    /// </summary>
    /// <remarks>
    /// The magic numbers are vanilla's and each one shapes the tree: <c>0.618</c> is how much of the
    /// height is bare trunk, <c>1.382</c> plus a square decides how many clusters a layer gets,
    /// <c>0.381</c> is how far a limb drops per block of reach, and <c>0.328</c> keeps a cluster off
    /// the trunk.
    /// <p/>
    /// The cluster count is <c>Math.min(1, ...)</c>, which is one whatever the height. That reads like
    /// a <c>max</c> that was written the wrong way round upstream, and it is transcribed as it stands
    /// because it is what decides how dense a fancy oak is.
    /// </remarks>
    public sealed record Fancy(int BaseHeight, int HeightRandA, int HeightRandB)
        : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        private const double TrunkHeightScale = 0.618;
        private const double ClusterDensityMagic = 1.382;
        private const double BranchSlope = 0.381;
        private const double BranchLengthMagic = 0.328;

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            int height = treeHeight + 2;
            int trunkHeight = Mth.Floor(height * TrunkHeightScale);

            PlaceBelowTrunkBlock(level, writer, random, origin.WithY(origin.Y - 1), config);

            int clustersPerY = Math.Min(1, Mth.Floor(ClusterDensityMagic + Math.Pow(1.0 * height / 13.0, 2.0)));
            int trunkTop = origin.Y + trunkHeight;

            List<(FoliageAttachment Attachment, int BranchBase)> clusters = [];
            int relativeY = height - 5;
            clusters.Add((new FoliageAttachment(origin.WithY(origin.Y + relativeY), 0, false), trunkTop));

            for (; relativeY >= 0; relativeY--) {
                float shape = TreeShape(height, relativeY);
                if (shape < 0.0f) {
                    continue;
                }

                for (int i = 0; i < clustersPerY; i++) {
                    double radius = 1.0 * shape * (random.NextFloat() + BranchLengthMagic);
                    double angle = random.NextFloat() * 2.0f * Math.PI;
                    double x = radius * Math.Sin(angle) + 0.5;
                    double z = radius * Math.Cos(angle) + 0.5;

                    Vec3<int> checkStart = origin + new Vec3<int>(Mth.Floor(x), relativeY - 1, Mth.Floor(z));
                    Vec3<int> checkEnd = checkStart.WithY(checkStart.Y + 5);

                    if (!MakeLimb(level, writer, random, checkStart, checkEnd, false, config)) {
                        continue;
                    }

                    int dx = origin.X - checkStart.X;
                    int dz = origin.Z - checkStart.Z;
                    double branchHeight = checkStart.Y - Math.Sqrt(dx * dx + dz * dz) * BranchSlope;
                    int branchTop = branchHeight > trunkTop ? trunkTop : (int)branchHeight;

                    Vec3<int> branchBase = new(origin.X, branchTop, origin.Z);
                    if (MakeLimb(level, writer, random, branchBase, checkStart, false, config)) {
                        clusters.Add((new FoliageAttachment(checkStart, 0, false), branchBase.Y));
                    }
                }
            }

            MakeLimb(level, writer, random, origin, origin.WithY(origin.Y + trunkHeight), true, config);
            MakeBranches(level, writer, random, height, origin, clusters, config);

            List<FoliageAttachment> attachments = [];
            foreach ((FoliageAttachment attachment, int branchBase) in clusters) {
                if (TrimBranches(height, branchBase - origin.Y)) {
                    attachments.Add(attachment);
                }
            }

            return attachments;
        }

        /// <summary>
        /// Walks a straight line of logs between two positions, or tests that the line is clear
        /// without writing anything.
        /// </summary>
        private bool MakeLimb(IFeatureLevel level, ITreeWriter writer, RandomSource random, Vec3<int> start,
            Vec3<int> end, bool doPlace, TreeConfiguration config) {

            if (!doPlace && start == end) {
                return true;
            }

            Vec3<int> delta = end - start;
            int steps = Math.Max(Math.Abs(delta.X), Math.Max(Math.Abs(delta.Y), Math.Abs(delta.Z)));
            if (steps == 0) {
                return true;
            }

            float dx = (float)delta.X / steps;
            float dy = (float)delta.Y / steps;
            float dz = (float)delta.Z / steps;

            for (int i = 0; i <= steps; i++) {
                Vec3<int> pos = start + new Vec3<int>(Mth.Floor(0.5f + i * dx), Mth.Floor(0.5f + i * dy),
                    Mth.Floor(0.5f + i * dz));

                if (doPlace) {
                    Axis axis = LogAxis(start, pos);
                    PlaceLog(level, writer, random, pos, config, state => WithAxis(state, axis));
                } else if (!IsFree(level, pos)) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The axis a limb's log lies along: whichever of x and z it has travelled furthest in, and y
        /// when it has travelled in neither.
        /// </summary>
        private static Axis LogAxis(Vec3<int> start, Vec3<int> pos) {
            int dx = Math.Abs(pos.X - start.X);
            int dz = Math.Abs(pos.Z - start.Z);
            int max = Math.Max(dx, dz);

            if (max == 0) {
                return Axis.Y;
            }

            return dx == max ? Axis.X : Axis.Z;
        }

        private static bool TrimBranches(int height, int localY) => localY >= height * 0.2;

        private void MakeBranches(IFeatureLevel level, ITreeWriter writer, RandomSource random, int height,
            Vec3<int> origin, List<(FoliageAttachment Attachment, int BranchBase)> clusters,
            TreeConfiguration config) {

            foreach ((FoliageAttachment attachment, int branchBase) in clusters) {
                Vec3<int> baseCoord = new(origin.X, branchBase, origin.Z);
                if (baseCoord != attachment.Pos && TrimBranches(height, branchBase - origin.Y)) {
                    MakeLimb(level, writer, random, baseCoord, attachment.Pos, true, config);
                }
            }
        }

        /// <summary>
        /// How wide the tree is at a height: the lower third has no clusters at all, and above that it
        /// is a half circle.
        /// </summary>
        private static float TreeShape(int height, int y) {
            if (y < height * 0.3f) {
                return -1.0f;
            }

            float radius = height / 2.0f;
            float adjacent = radius - y;
            float distance = Mth.Sqrt(radius * radius - adjacent * adjacent);

            if (adjacent == 0.0f) {
                distance = radius;
            } else if (Math.Abs(adjacent) >= radius) {
                return 0.0f;
            }

            return distance * 0.5f;
        }
    }

    /// <summary>
    /// <c>PoplarTrunkPlacer</c>: a straight column with a ring of sideways logs some way below the top,
    /// and the foliage attached at that ring rather than at the top.
    /// </summary>
    /// <remarks>
    /// <b>Every level draws a full shuffle of <c>Direction.values()</c></b>, five <c>nextInt</c>s, even
    /// though only the branch level reads it, and the branch amount is drawn after that level's
    /// shuffle. The branches take the shuffle's horizontal entries in shuffled order.
    /// </remarks>
    public sealed record Poplar(int BaseHeight, int HeightRandA, int HeightRandB,
        IIntProvider TrunkHeightAboveBranches, IIntProvider BranchAmount)
        : TrunkPlacer(BaseHeight, HeightRandA, HeightRandB) {

        public override IReadOnlyList<FoliageAttachment> PlaceTrunk(IFeatureLevel level, ITreeWriter writer,
            RandomSource random, int treeHeight, Vec3<int> origin, TreeConfiguration config) {

            PlaceBelowTrunkBlock(level, writer, random, origin.WithY(origin.Y - 1), config);
            int trunkHeightUpToFoliageBranches = treeHeight - TrunkHeightAboveBranches.Sample(random);

            for (int y = 0; y < treeHeight; y++) {
                Vec3<int> pos = origin.WithY(origin.Y + y);
                PlaceLog(level, writer, random, pos, config);

                List<BlockFace> directions = FeatureUtil.Shuffled(FeatureUtil.AllDirections, random)
                    .Where(Directions.IsHorizontal).ToList();

                if (trunkHeightUpToFoliageBranches - 1 != y) {
                    continue;
                }

                int branches = BranchAmount.Sample(random);

                for (int x = 0; x < branches; x++) {
                    Vec3<int> step = Placement.PlacementParser.Step(directions[x]);
                    Axis axis = AxisOf(step);
                    PlaceLog(level, writer, random, pos + step, config, state => WithAxis(state, axis));
                }
            }

            return [new FoliageAttachment(origin.WithY(origin.Y + trunkHeightUpToFoliageBranches), 0, false)];
        }
    }
}
