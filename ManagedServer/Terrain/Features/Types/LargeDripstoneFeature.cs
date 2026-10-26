using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>LargeDripstoneFeature</c>: the solid dripstone cones spanning a cave, as opposed to the pointed
/// blocks a cluster grows.
/// </summary>
/// <remarks>
/// The profile comes from <c>getSpeleothemHeight</c>, a log curve that gives a cone which is broad at
/// the base and tapers away sharply. <b>Bluntness</b> is the floor put under the radius before that
/// curve is evaluated, which is what makes a blunt cone stop short of a point.
/// <p/>
/// The pair is one radius and two independently drawn shapes, so a stalactite and the stalagmite under
/// it are the same width at the wall and different lengths.
/// <p/>
/// <b>The wind is what makes a large dripstone lean.</b> It is only applied when both halves are wide
/// and blunt enough, so a thin spike stays vertical and a fat cone can bend a long way.
/// </remarks>
public sealed record LargeDripstoneFeature(int FloorToCeilingSearchRange, IIntProvider ColumnRadius,
    IFloatProvider HeightScale, float MaxColumnRadiusToCaveHeightRatio, IFloatProvider StalactiteBluntness,
    IFloatProvider StalagmiteBluntness, IFloatProvider WindSpeed, int MinRadiusForWind,
    float MinBluntnessForWind, IReadOnlySet<Identifier> ReplaceableBlocks) : ConfiguredFeature {

    private static readonly Identifier BaseStoneOverworld = "minecraft:base_stone_overworld";

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!SpeleothemUtils.IsEmptyOrWater(level, origin.X, origin.Y, origin.Z)) {
            return false;
        }

        // The edge test accepts lava as well as stone, so a cone may hang over a lava lake.
        (int? floor, int? ceiling) = ScanForBaseOrLava(level, origin);

        // Needs both ends: a cone spans the cave, so an open column is no use to it.
        if (floor is not { } floorY || ceiling is not { } ceilingY) {
            return false;
        }

        int caveHeight = ceilingY - floorY - 1;

        if (caveHeight < 4) {
            return false;
        }

        int maxByHeight = (int)(caveHeight * MaxColumnRadiusToCaveHeightRatio);
        int maxRadius = Math.Clamp(maxByHeight, ColumnRadius.MinInclusive, ColumnRadius.MaxInclusive);
        int radius = Mth.RandomBetweenInclusive(random, ColumnRadius.MinInclusive, maxRadius);

        Dripstone stalactite = new(new Vec3<int>(origin.X, ceilingY - 1, origin.Z), false, radius,
            StalactiteBluntness.Sample(random), HeightScale.Sample(random));

        Dripstone stalagmite = new(new Vec3<int>(origin.X, floorY + 1, origin.Z), true, radius,
            StalagmiteBluntness.Sample(random), HeightScale.Sample(random));

        WindOffsetter wind = stalactite.IsSuitableForWind(MinRadiusForWind, MinBluntnessForWind)
            && stalagmite.IsSuitableForWind(MinRadiusForWind, MinBluntnessForWind)
                ? new WindOffsetter(origin.Y, random, WindSpeed, 16 - radius)
                : WindOffsetter.None;

        // Both are moved before either is placed, so the second one's search is not looking at blocks
        // the first one wrote.
        bool stalactiteEmbedded = stalactite.MoveBackUntilBaseIsInsideStone(level, wind);
        bool stalagmiteEmbedded = stalagmite.MoveBackUntilBaseIsInsideStone(level, wind);

        if (stalactiteEmbedded) {
            stalactite.PlaceBlocks(level, random, wind);
        }

        if (stalagmiteEmbedded) {
            stalagmite.PlaceBlocks(level, random, wind);
        }

        return true;
    }

    private (int? Floor, int? Ceiling) ScanForBaseOrLava(IFeatureLevel level, Vec3<int> origin) {
        return (Scan(level, origin, -1), Scan(level, origin, 1));
    }

    private int? Scan(IFeatureLevel level, Vec3<int> origin, int step) {
        int y = origin.Y;

        for (int i = 1; i < FloorToCeilingSearchRange
            && SpeleothemUtils.IsEmptyOrWater(level, origin.X, y, origin.Z); i++) {

            y += step;
        }

        return IsBaseOrLava(level, origin.X, y, origin.Z) ? y : null;
    }

    private bool IsBaseOrLava(IFeatureLevel level, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

        return block.Identifier.Equals(Block.DripstoneBlock.Identifier)
            || ReplaceableBlocks.Contains(block.Identifier)
            || block.Identifier.Equals(Block.Lava.Identifier);
    }

    /// <summary>
    /// One cone: where it is rooted, which way it points, and the two numbers that shape it.
    /// </summary>
    private sealed class Dripstone(Vec3<int> root, bool pointingUp, int radius, double bluntness,
        double scale) {

        private Vec3<int> _root = root;
        private int _radius = radius;

        public bool IsSuitableForWind(int minRadius, float minBluntness) {
            return _radius >= minRadius && bluntness >= minBluntness;
        }

        /// <summary>
        /// Backs the root into the wall until its whole circle is buried, halving the radius and trying
        /// again when it cannot be.
        /// </summary>
        /// <remarks>
        /// Without this a cone hangs off a lip with its wide end in mid air. Lava under the root stops
        /// the search outright rather than shrinking, since a cone growing out of lava is wrong at any
        /// width.
        /// </remarks>
        public bool MoveBackUntilBaseIsInsideStone(IFeatureLevel level, WindOffsetter wind) {
            while (_radius > 1) {
                Vec3<int> candidate = _root;
                int tries = Math.Min(10, HeightAtRadius(0.0f));

                for (int i = 0; i < tries; i++) {
                    if (level.Registry.Blocks.GetByStateId(
                        level.GetState(candidate.X, candidate.Y, candidate.Z)).Identifier
                        .Equals(Block.Lava.Identifier)) {

                        return false;
                    }

                    if (IsCircleMostlyEmbeddedInStone(level, wind.Offset(candidate), _radius)) {
                        _root = candidate;
                        return true;
                    }

                    candidate = candidate.WithY(candidate.Y + (pointingUp ? -1 : 1));
                }

                _radius /= 2;
            }

            return false;
        }

        public void PlaceBlocks(IFeatureLevel level, RandomSource random, WindOffsetter wind) {
            for (int dx = -_radius; dx <= _radius; dx++) {
                for (int dz = -_radius; dz <= _radius; dz++) {
                    float distance = MathF.Sqrt(dx * dx + dz * dz);

                    if (distance > _radius) {
                        continue;
                    }

                    int height = HeightAtRadius(distance);

                    if (height <= 0) {
                        continue;
                    }

                    // One column in five is cut short, which roughens the cone's surface.
                    if (random.NextFloat() < 0.2) {
                        height = (int)(height * (0.8f + random.NextFloat() * 0.2f));
                    }

                    Vec3<int> cursor = new(_root.X + dx, _root.Y, _root.Z + dz);

                    // A stalagmite stops at the terrain surface so it cannot punch out of the ground;
                    // a stalactite has no such limit.
                    int maxY = pointingUp
                        ? level.GetHeight(HeightmapType.WorldSurfaceWorldgen, cursor.X, cursor.Z)
                        : int.MaxValue;

                    bool leftStone = false;

                    for (int i = 0; i < height && cursor.Y < maxY; i++) {
                        Vec3<int> pos = wind.Offset(cursor);

                        if (IsEmptyOrWaterOrLava(level, pos.X, pos.Y, pos.Z)) {
                            leftStone = true;
                            level.SetState(pos.X, pos.Y, pos.Z, Block.DripstoneBlock.StateId);
                        } else if (leftStone
                            && level.Blocks.IsIn(BaseStoneOverworld, level.GetState(pos.X, pos.Y, pos.Z))) {

                            // Back into rock after having been out of it, so the column has crossed the
                            // cave and there is nothing left to draw.
                            break;
                        }

                        cursor = cursor.WithY(cursor.Y + (pointingUp ? 1 : -1));
                    }
                }
            }
        }

        private int HeightAtRadius(float checkRadius) {
            return (int)SpeleothemHeight(checkRadius, _radius, scale, bluntness);
        }
    }

    /// <summary>
    /// <c>SpeleothemUtils.getSpeleothemHeight</c>: the cone's profile.
    /// </summary>
    /// <remarks>
    /// The 0.384 is the curve's own maximum, so dividing by it normalises the shape before it is scaled
    /// back up by the radius. Bluntness enters as a floor on the radius rather than as a term, which is
    /// why it flattens the tip and leaves the flanks alone.
    /// </remarks>
    private static double SpeleothemHeight(double distanceFromCentre, double radius, double scale,
        double bluntness) {

        if (distanceFromCentre < bluntness) {
            distanceFromCentre = bluntness;
        }

        double r = distanceFromCentre / radius * 0.384;
        double height = scale * (0.75 * Math.Pow(r, 4.0 / 3.0) - Math.Pow(r, 2.0 / 3.0)
            - 1.0 / 3.0 * Math.Log(r));

        return Math.Max(height, 0.0) / 0.384 * radius;
    }

    /// <summary>
    /// Walks a circle of the given radius and asks whether every point of it is solid, which is what
    /// "the base is inside the wall" means.
    /// </summary>
    /// <remarks>
    /// The step is a fixed arc length rather than a fixed angle, so a wide circle is sampled at more
    /// points and the test does not get looser as the cone gets fatter.
    /// </remarks>
    private static bool IsCircleMostlyEmbeddedInStone(IFeatureLevel level, Vec3<int> centre, int radius) {
        if (IsEmptyOrWaterOrLava(level, centre.X, centre.Y, centre.Z)) {
            return false;
        }

        float increment = 6.0f / radius;

        for (float angle = 0.0f; angle < (float)(Math.PI * 2); angle += increment) {
            int dx = (int)(Mth.Cos(angle) * radius);
            int dz = (int)(Mth.Sin(angle) * radius);

            if (IsEmptyOrWaterOrLava(level, centre.X + dx, centre.Y, centre.Z + dz)) {
                return false;
            }
        }

        return true;
    }

    private static bool IsEmptyOrWaterOrLava(IFeatureLevel level, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

        return block.Air || block.Identifier.Equals(Block.Water.Identifier)
            || block.Identifier.Equals(Block.Lava.Identifier);
    }

    /// <summary>
    /// The horizontal lean, which grows with distance from the origin's height and is capped so a cone
    /// cannot walk out of its own chunk.
    /// </summary>
    private sealed class WindOffsetter {
        public static readonly WindOffsetter None = new();

        private readonly int _originY;
        private readonly double _windX;
        private readonly double _windZ;
        private readonly int _maxOffset;
        private readonly bool _active;

        private WindOffsetter() {
        }

        public WindOffsetter(int originY, RandomSource random, IFloatProvider windSpeed, int maxOffset) {
            _originY = originY;
            _maxOffset = maxOffset;
            _active = true;

            float speed = windSpeed.Sample(random);

            // Half a turn, not a full one: the direction and its opposite give the same pair of cones
            // leaning apart, so the other half would be a duplicate.
            float direction = random.NextFloat() * (float)Math.PI;

            _windX = Mth.Cos(direction) * speed;
            _windZ = Mth.Sin(direction) * speed;
        }

        public Vec3<int> Offset(Vec3<int> pos) {
            if (!_active) {
                return pos;
            }

            int dy = _originY - pos.Y;

            int dx = Math.Clamp((int)Math.Floor(_windX * dy), -_maxOffset, _maxOffset);
            int dz = Math.Clamp((int)Math.Floor(_windZ * dy), -_maxOffset, _maxOffset);

            return new Vec3<int>(pos.X + dx, pos.Y, pos.Z + dz);
        }
    }
}
