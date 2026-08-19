using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Trees;

/// <summary>
/// <c>FoliagePlacer</c>: grows the leaves from an attachment the trunk placer handed back.
/// </summary>
/// <remarks>
/// A placer works in rows: a horizontal square of a given radius at a y relative to the attachment,
/// with <see cref="ShouldSkipLocation"/> punching the corners out. That is what gives every vanilla
/// canopy its shape, and it is also where most of the random draws in a tree happen.
/// </remarks>
public abstract record FoliagePlacer(IIntProvider Radius, IIntProvider Offset) {
    public void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
        int leafRadius) {

        CreateFoliage(level, writer, random, config, treeHeight, attachment, foliageHeight, leafRadius,
            Offset.Sample(random));
    }

    protected abstract void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
        int leafRadius, int offset);

    public abstract int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config);

    public virtual int FoliageRadius(RandomSource random, int trunkHeight) => Radius.Sample(random);

    /// <summary>
    /// Whether a position in a row is a hole. The offsets arrive already made positive, so a placer
    /// only ever compares against the radius rather than against both signs of it.
    /// </summary>
    protected abstract bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz, int currentRadius,
        bool doubleTrunk);

    /// <summary>
    /// The signed form, which is what folds a two by two trunk's rows: with a double trunk the
    /// distance is measured from whichever of the two columns is nearer.
    /// </summary>
    protected virtual bool ShouldSkipLocationSigned(RandomSource random, int dx, int y, int dz,
        int currentRadius, bool doubleTrunk) {

        int minDx;
        int minDz;

        if (doubleTrunk) {
            minDx = Math.Min(Math.Abs(dx), Math.Abs(dx - 1));
            minDz = Math.Min(Math.Abs(dz), Math.Abs(dz - 1));
        } else {
            minDx = Math.Abs(dx);
            minDz = Math.Abs(dz);
        }

        return ShouldSkipLocation(random, minDx, y, minDz, currentRadius, doubleTrunk);
    }

    /// <summary>
    /// One horizontal square of leaves. A double trunk's square is one wider on the positive side, so
    /// it stays centred over a two by two.
    /// </summary>
    protected void PlaceLeavesRow(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        TreeConfiguration config, Vec3<int> origin, int currentRadius, int y, bool doubleTrunk) {

        int extra = doubleTrunk ? 1 : 0;

        for (int dx = -currentRadius; dx <= currentRadius + extra; dx++) {
            for (int dz = -currentRadius; dz <= currentRadius + extra; dz++) {
                if (!ShouldSkipLocationSigned(random, dx, y, dz, currentRadius, doubleTrunk)) {
                    TryPlaceLeaf(level, writer, random, config, origin + new Vec3<int>(dx, y, dz));
                }
            }
        }
    }

    /// <summary>
    /// A row plus the strands that hang off its edge, which is the cherry tree's whole look.
    /// </summary>
    /// <remarks>
    /// The walk goes round the edge of the square, and a strand only starts under a leaf this tree
    /// actually placed, which is why the setter has to answer what it has already written.
    /// </remarks>
    protected void PlaceLeavesRowWithHangingLeavesBelow(IFeatureLevel level, ITreeWriter writer,
        RandomSource random, TreeConfiguration config, Vec3<int> origin, int currentRadius, int y,
        bool doubleTrunk, float hangingLeavesChance, float hangingLeavesExtensionChance) {

        PlaceLeavesRow(level, writer, random, config, origin, currentRadius, y, doubleTrunk);

        int extra = doubleTrunk ? 1 : 0;
        Vec3<int> logPos = origin.WithY(origin.Y - 1);

        foreach (Vec3<int> alongEdge in TrunkPlacers.Horizontal) {
            Vec3<int> toEdge = ClockWise(alongEdge);

            // The positive facing sides sit one further out, matching the extra column a double
            // trunk's row has.
            int offsetToEdge = IsPositive(toEdge) ? currentRadius + extra : currentRadius;

            Vec3<int> pos = origin.WithY(origin.Y + y - 1)
                + toEdge * offsetToEdge
                + alongEdge * -currentRadius;

            for (int offsetAlongEdge = -currentRadius; offsetAlongEdge < currentRadius + extra;
                offsetAlongEdge++, pos += alongEdge) {

                if (!writer.IsFoliageSet(pos.WithY(pos.Y + 1))) {
                    continue;
                }

                if (TryPlaceExtension(level, writer, random, config, hangingLeavesChance, logPos, pos)) {
                    TryPlaceExtension(level, writer, random, config, hangingLeavesExtensionChance, logPos,
                        pos.WithY(pos.Y - 1));
                }
            }
        }
    }

    /// <summary>
    /// One block of a hanging strand. The manhattan limit is seven, which is the distance at which
    /// leaves decay, so a strand can never outlive the tree.
    /// </summary>
    private static bool TryPlaceExtension(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        TreeConfiguration config, float chance, Vec3<int> logPos, Vec3<int> pos) {

        int manhattan = Math.Abs(pos.X - logPos.X) + Math.Abs(pos.Y - logPos.Y) + Math.Abs(pos.Z - logPos.Z);
        if (manhattan >= 7) {
            return false;
        }

        if (random.NextFloat() > chance) {
            return false;
        }

        return TryPlaceLeaf(level, writer, random, config, pos);
    }

    /// <summary>
    /// One leaf. A persistent leaf block is never overwritten, so a player placed canopy survives a
    /// tree growing into it.
    /// </summary>
    protected static bool TryPlaceLeaf(IFeatureLevel level, ITreeWriter writer, RandomSource random,
        TreeConfiguration config, Vec3<int> pos) {

        uint existing = level.GetState(pos.X, pos.Y, pos.Z);
        if (level.Registry.Blocks.GetByStateId(existing) is IPersistent { Persistent: true }) {
            return false;
        }

        if (!TreeFeature.ValidTreePos(level, pos)) {
            return false;
        }

        IBlock foliage = config.FoliageProvider.GetState(level, random, pos.X, pos.Y, pos.Z);
        if (foliage is IWaterlogged waterloggable) {
            foliage = waterloggable.WithWaterlogged(FeatureFluids.IsWaterSource(level, existing));
        }

        writer.SetFoliage(pos, foliage);
        return true;
    }

    /// <summary><c>Direction.getClockWise</c> over the horizontal plane.</summary>
    private static Vec3<int> ClockWise(Vec3<int> direction) {
        return new Vec3<int>(-direction.Z, 0, direction.X);
    }

    /// <summary><c>Direction.getAxisDirection() == POSITIVE</c>.</summary>
    private static bool IsPositive(Vec3<int> direction) => direction.X > 0 || direction.Z > 0;
}

/// <summary>Every <c>FoliagePlacer</c> in the vanilla data.</summary>
public static class FoliagePlacers {
    /// <summary>
    /// <c>BlobFoliagePlacer</c>: the oak and birch canopy, a ball that narrows every second row.
    /// </summary>
    public record Blob(IIntProvider Radius, IIntProvider Offset, int Height)
        : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            for (int y = offset; y >= offset - foliageHeight; y--) {
                int currentRadius = Math.Max(leafRadius + attachment.RadiusOffset - 1 - y / 2, 0);
                PlaceLeavesRow(level, writer, random, config, attachment.Pos, currentRadius, y,
                    attachment.DoubleTrunk);
            }
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return Height;
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return dx == currentRadius && dz == currentRadius && (random.NextInt(2) == 0 || y == 0);
        }
    }

    /// <summary>
    /// <c>BushFoliagePlacer</c>: a blob that narrows every row rather than every second one, and whose
    /// corners are a coin flip rather than being solid at the widest row.
    /// </summary>
    public sealed record Bush(IIntProvider Radius, IIntProvider Offset, int Height)
        : Blob(Radius, Offset, Height) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            for (int y = offset; y >= offset - foliageHeight; y--) {
                int currentRadius = leafRadius + attachment.RadiusOffset - 1 - y;
                PlaceLeavesRow(level, writer, random, config, attachment.Pos, currentRadius, y,
                    attachment.DoubleTrunk);
            }
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return dx == currentRadius && dz == currentRadius && random.NextInt(2) == 0;
        }
    }

    /// <summary>
    /// <c>FancyFoliagePlacer</c>: the big oak's clusters, a squat blob whose middle rows are one wider.
    /// </summary>
    /// <remarks>
    /// The skip test is a circle rather than a corner check, and it is offset by half a block on both
    /// axes, which is what rounds a cluster rather than squaring it.
    /// </remarks>
    public sealed record Fancy(IIntProvider Radius, IIntProvider Offset, int Height)
        : Blob(Radius, Offset, Height) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            for (int y = offset; y >= offset - foliageHeight; y--) {
                int currentRadius = leafRadius + (y != offset && y != offset - foliageHeight ? 1 : 0);
                PlaceLeavesRow(level, writer, random, config, attachment.Pos, currentRadius, y,
                    attachment.DoubleTrunk);
            }
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return Mth.Square(dx + 0.5f) + Mth.Square(dz + 0.5f) > currentRadius * currentRadius;
        }
    }

    /// <summary>
    /// <c>SpruceFoliagePlacer</c>: rings that grow and reset, which is what makes a spruce tiered.
    /// </summary>
    public sealed record Spruce(IIntProvider Radius, IIntProvider Offset, IIntProvider TrunkHeight)
        : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            int currentRadius = random.NextInt(2);
            int maxRadius = 1;
            int minRadius = 0;

            for (int y = offset; y >= -foliageHeight; y--) {
                PlaceLeavesRow(level, writer, random, config, attachment.Pos, currentRadius, y,
                    attachment.DoubleTrunk);

                if (currentRadius >= maxRadius) {
                    currentRadius = minRadius;
                    minRadius = 1;
                    maxRadius = Math.Min(maxRadius + 1, leafRadius + attachment.RadiusOffset);
                } else {
                    currentRadius++;
                }
            }
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return Math.Max(4, treeHeight - TrunkHeight.Sample(random));
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return dx == currentRadius && dz == currentRadius && currentRadius > 0;
        }
    }

    /// <summary>
    /// <c>PineFoliagePlacer</c>: a single cone at the top, with the radius drawn against how tall the
    /// bare trunk came out.
    /// </summary>
    public sealed record Pine(IIntProvider Radius, IIntProvider Offset, IIntProvider Height)
        : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            int currentRadius = 0;

            for (int y = offset; y >= offset - foliageHeight; y--) {
                PlaceLeavesRow(level, writer, random, config, attachment.Pos, currentRadius, y,
                    attachment.DoubleTrunk);

                if (currentRadius >= 1 && y == offset - foliageHeight + 1) {
                    currentRadius--;
                } else if (currentRadius < leafRadius + attachment.RadiusOffset) {
                    currentRadius++;
                }
            }
        }

        public override int FoliageRadius(RandomSource random, int trunkHeight) {
            return base.FoliageRadius(random, trunkHeight)
                + random.NextInt(Math.Max(trunkHeight + 1, 1));
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return Height.Sample(random);
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return dx == currentRadius && dz == currentRadius && currentRadius > 0;
        }
    }

    /// <summary>
    /// <c>AcaciaFoliagePlacer</c>: three flat rows, not a blob, which is what makes an acacia's canopy
    /// a plate.
    /// </summary>
    /// <remarks>
    /// The foliage height is zero, so the rows are placed at fixed offsets rather than through a
    /// loop, and the skip test has a separate branch for the middle row.
    /// </remarks>
    public sealed record Acacia(IIntProvider Radius, IIntProvider Offset) : FoliagePlacer(Radius, Offset) {
        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            bool doubleTrunk = attachment.DoubleTrunk;
            Vec3<int> pos = attachment.Pos.WithY(attachment.Pos.Y + offset);

            PlaceLeavesRow(level, writer, random, config, pos, leafRadius + attachment.RadiusOffset,
                -1 - foliageHeight, doubleTrunk);
            PlaceLeavesRow(level, writer, random, config, pos, leafRadius - 1, -foliageHeight, doubleTrunk);
            PlaceLeavesRow(level, writer, random, config, pos, leafRadius + attachment.RadiusOffset - 1, 0,
                doubleTrunk);
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return 0;
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            if (y == 0) {
                return (dx > 1 || dz > 1) && dx != 0 && dz != 0;
            }

            return dx == currentRadius && dz == currentRadius && currentRadius > 0;
        }
    }

    /// <summary>
    /// <c>MegaJungleFoliagePlacer</c>: the crown of a jungle giant, and the small clumps its branches
    /// carry.
    /// </summary>
    /// <remarks>
    /// A branch's clump is one or two rows deep rather than the configured height, and only the main
    /// crown, which is the attachment sitting on the double trunk, gets the full depth.
    /// </remarks>
    public sealed record MegaJungle(IIntProvider Radius, IIntProvider Offset, int Height)
        : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            int leafHeight = attachment.DoubleTrunk ? foliageHeight : 1 + random.NextInt(2);

            for (int y = offset; y >= offset - leafHeight; y--) {
                int currentRadius = leafRadius + attachment.RadiusOffset + 1 - y;
                PlaceLeavesRow(level, writer, random, config, attachment.Pos, currentRadius, y,
                    attachment.DoubleTrunk);
            }
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return Height;
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return dx + dz >= 7 || dx * dx + dz * dz > currentRadius * currentRadius;
        }
    }

    /// <summary>
    /// <c>MegaPineFoliagePlacer</c>: the tall crown of a mega spruce, whose radius grows towards the
    /// bottom and gains a jagged extra block on alternate rows.
    /// </summary>
    public sealed record MegaPine(IIntProvider Radius, IIntProvider Offset, IIntProvider CrownHeight)
        : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            Vec3<int> pos = attachment.Pos;
            int previousRadius = 0;

            for (int y = pos.Y - foliageHeight + offset; y <= pos.Y + offset; y++) {
                int down = pos.Y - y;
                int smoothRadius = leafRadius + attachment.RadiusOffset
                    + Mth.Floor((float)down / foliageHeight * 3.5f);

                // The jag is on even world y rather than on an even row of the crown, so two crowns at
                // different heights are notched differently.
                int radius = down > 0 && smoothRadius == previousRadius && (y & 1) == 0
                    ? smoothRadius + 1
                    : smoothRadius;

                PlaceLeavesRow(level, writer, random, config, new Vec3<int>(pos.X, y, pos.Z), radius, 0,
                    attachment.DoubleTrunk);

                previousRadius = smoothRadius;
            }
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return CrownHeight.Sample(random);
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return dx + dz >= 7 || dx * dx + dz * dz > currentRadius * currentRadius;
        }
    }

    /// <summary>
    /// <c>DarkOakFoliagePlacer</c>: a flat two or three row slab, wider than it is tall.
    /// </summary>
    /// <remarks>
    /// The signed override is what cuts the two corners off the widest row of a double trunk, and it
    /// is the only placer that overrides it.
    /// </remarks>
    public sealed record DarkOak(IIntProvider Radius, IIntProvider Offset) : FoliagePlacer(Radius, Offset) {
        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            Vec3<int> pos = attachment.Pos.WithY(attachment.Pos.Y + offset);
            bool doubleTrunk = attachment.DoubleTrunk;

            if (doubleTrunk) {
                PlaceLeavesRow(level, writer, random, config, pos, leafRadius + 2, -1, true);
                PlaceLeavesRow(level, writer, random, config, pos, leafRadius + 3, 0, true);
                PlaceLeavesRow(level, writer, random, config, pos, leafRadius + 2, 1, true);

                if (random.NextBoolean()) {
                    PlaceLeavesRow(level, writer, random, config, pos, leafRadius, 2, true);
                }
            } else {
                PlaceLeavesRow(level, writer, random, config, pos, leafRadius + 2, -1, false);
                PlaceLeavesRow(level, writer, random, config, pos, leafRadius + 1, 0, false);
            }
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return 4;
        }

        protected override bool ShouldSkipLocationSigned(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            if (y == 0 && doubleTrunk && (dx == -currentRadius || dx >= currentRadius)
                && (dz == -currentRadius || dz >= currentRadius)) {

                return true;
            }

            return base.ShouldSkipLocationSigned(random, dx, y, dz, currentRadius, doubleTrunk);
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            if (y == -1 && !doubleTrunk) {
                return dx == currentRadius && dz == currentRadius;
            }

            return y == 1 && dx + dz > currentRadius * 2 - 2;
        }
    }

    /// <summary>
    /// <c>RandomSpreadFoliagePlacer</c>: the mangrove's canopy, scattered leaf by leaf rather than in
    /// rows.
    /// </summary>
    /// <remarks>
    /// Each attempt is three pairs of draws subtracted, so the spread is triangular and the middle is
    /// dense.
    /// </remarks>
    public sealed record RandomSpread(IIntProvider Radius, IIntProvider Offset, IIntProvider Height,
        int LeafPlacementAttempts) : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            Vec3<int> origin = attachment.Pos;

            for (int i = 0; i < LeafPlacementAttempts; i++) {
                Vec3<int> pos = origin + new Vec3<int>(
                    random.NextInt(leafRadius) - random.NextInt(leafRadius),
                    random.NextInt(foliageHeight) - random.NextInt(foliageHeight),
                    random.NextInt(leafRadius) - random.NextInt(leafRadius));

                TryPlaceLeaf(level, writer, random, config, pos);
            }
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return Height.Sample(random);
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            return false;
        }
    }

    /// <summary>
    /// <c>CherryFoliagePlacer</c>: a wide flat canopy with holes in the corners and strands hanging off
    /// the bottom two rows.
    /// </summary>
    public sealed record Cherry(IIntProvider Radius, IIntProvider Offset, IIntProvider Height,
        float WideBottomLayerHoleChance, float CornerHoleChance, float HangingLeavesChance,
        float HangingLeavesExtensionChance) : FoliagePlacer(Radius, Offset) {

        protected override void CreateFoliage(IFeatureLevel level, ITreeWriter writer, RandomSource random,
            TreeConfiguration config, int treeHeight, FoliageAttachment attachment, int foliageHeight,
            int leafRadius, int offset) {

            bool doubleTrunk = attachment.DoubleTrunk;
            Vec3<int> pos = attachment.Pos.WithY(attachment.Pos.Y + offset);
            int currentRadius = leafRadius + attachment.RadiusOffset - 1;

            PlaceLeavesRow(level, writer, random, config, pos, currentRadius - 2, foliageHeight - 3, doubleTrunk);
            PlaceLeavesRow(level, writer, random, config, pos, currentRadius - 1, foliageHeight - 4, doubleTrunk);

            for (int y = foliageHeight - 5; y >= 0; y--) {
                PlaceLeavesRow(level, writer, random, config, pos, currentRadius, y, doubleTrunk);
            }

            PlaceLeavesRowWithHangingLeavesBelow(level, writer, random, config, pos, currentRadius, -1,
                doubleTrunk, HangingLeavesChance, HangingLeavesExtensionChance);
            PlaceLeavesRowWithHangingLeavesBelow(level, writer, random, config, pos, currentRadius - 1, -2,
                doubleTrunk, HangingLeavesChance, HangingLeavesExtensionChance);
        }

        public override int FoliageHeight(RandomSource random, int treeHeight, TreeConfiguration config) {
            return Height.Sample(random);
        }

        protected override bool ShouldSkipLocation(RandomSource random, int dx, int y, int dz,
            int currentRadius, bool doubleTrunk) {

            if (y == -1 && (dx == currentRadius || dz == currentRadius)
                && random.NextFloat() < WideBottomLayerHoleChance) {

                return true;
            }

            bool corner = dx == currentRadius && dz == currentRadius;
            bool wideLayer = currentRadius > 2;

            if (wideLayer) {
                return corner || (dx + dz > currentRadius * 2 - 2 && random.NextFloat() < CornerHoleChance);
            }

            return corner && random.NextFloat() < CornerHoleChance;
        }
    }
}

