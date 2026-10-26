using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>IcebergFeature</c>: a berg of packed or blue ice floating in a frozen ocean.
/// </summary>
/// <remarks>
/// Two shapes share the code. The <b>round</b> one is a stack of jittered circles and comes out
/// craggy; the <b>ellipse</b> one is a stack of rotated ellipses and comes out as a smooth shard. Which
/// is drawn decides the height range, the taper, the cut out chance and whether the jitter is applied
/// at all, so almost every line here branches on it.
/// <p/>
/// <b>The random draws are structural.</b> The radius helpers draw per column per layer, and several
/// of the tests short circuit past a draw, so the sequence depends on the shape of the berg being
/// built. Reordering or hoisting any of them gives a different, still plausible, berg.
/// <p/>
/// Built at the sea level rather than at the position the placement chain chose, so only the column
/// matters.
/// </remarks>
public sealed record IcebergFeature(uint State) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = new(context.Origin.X, level.SeaLevel, context.Origin.Z);

        bool snowOnTop = random.NextDouble() > 0.7;
        double shapeAngle = random.NextDouble() * 2.0 * Math.PI;
        int ellipseA = 11 - random.NextInt(5);
        int ellipseC = 3 + random.NextInt(3);
        bool isEllipse = random.NextDouble() > 0.7;

        int aboveWater = isEllipse ? random.NextInt(6) + 6 : random.NextInt(15) + 3;

        // The rare tall round berg, which is where the ones towering over the ocean come from.
        if (!isEllipse && random.NextDouble() > 0.9) {
            aboveWater += random.NextInt(19) + 7;
        }

        int belowWater = Math.Min(aboveWater + random.NextInt(11), 18);
        int width = Math.Min(aboveWater + random.NextInt(7) - random.NextInt(5), 11);
        int reach = isEllipse ? ellipseA : 11;

        for (int dx = -reach; dx < reach; dx++) {
            for (int dz = -reach; dz < reach; dz++) {
                for (int dy = 0; dy < aboveWater; dy++) {
                    int radius = isEllipse
                        ? RadiusEllipse(dy, aboveWater, width)
                        : RadiusRound(random, dy, aboveWater, width);

                    if (isEllipse || dx < radius) {
                        GenerateBlock(level, random, origin, aboveWater, dx, dy, dz, radius, reach,
                            isEllipse, ellipseC, shapeAngle, snowOnTop);
                    }
                }
            }
        }

        Smooth(level, origin, width, aboveWater, isEllipse, ellipseA);

        for (int dx = -reach; dx < reach; dx++) {
            for (int dz = -reach; dz < reach; dz++) {
                for (int dy = -1; dy > -belowWater; dy--) {
                    int layerReach = isEllipse
                        ? (int)Math.Ceiling(reach * (1.0f - (float)Math.Pow(dy, 2.0) / (belowWater * 8.0f)))
                        : reach;

                    int radius = RadiusSteep(random, -dy, belowWater, width);

                    if (dx < radius) {
                        GenerateBlock(level, random, origin, belowWater, dx, dy, dz, radius, layerReach,
                            isEllipse, ellipseC, shapeAngle, snowOnTop);
                    }
                }
            }
        }

        bool cutOut = isEllipse ? random.NextDouble() > 0.1 : random.NextDouble() > 0.7;

        if (cutOut) {
            GenerateCutOut(level, random, width, aboveWater, origin, isEllipse, ellipseA, shapeAngle,
                ellipseC);
        }

        return true;
    }

    /// <summary>
    /// The notch taken out of one side, which is what stops every berg being a solid lump.
    /// </summary>
    /// <remarks>
    /// Above the water it carves to air and takes any snow layer left floating with it; below the
    /// water it carves back to water.
    /// </remarks>
    private void GenerateCutOut(IFeatureLevel level, RandomSource random, int width, int height,
        Vec3<int> origin, bool isEllipse, int ellipseA, double shapeAngle, int ellipseC) {

        int signX = random.NextBoolean() ? -1 : 1;
        int signZ = random.NextBoolean() ? -1 : 1;

        int offsetX = random.NextInt(Math.Max(width / 2 - 2, 1));
        if (random.NextBoolean()) {
            offsetX = width / 2 + 1 - random.NextInt(Math.Max(width - width / 2 - 1, 1));
        }

        int offsetZ = random.NextInt(Math.Max(width / 2 - 2, 1));
        if (random.NextBoolean()) {
            offsetZ = width / 2 + 1 - random.NextInt(Math.Max(width - width / 2 - 1, 1));
        }

        // The ellipse berg overwrites both offsets with one draw, so its notch is always on a
        // diagonal. All the draws above still happen.
        if (isEllipse) {
            offsetX = offsetZ = random.NextInt(Math.Max(ellipseA - 5, 1));
        }

        Vec3<int> local = new(signX * offsetX, 0, signZ * offsetZ);
        double angle = isEllipse ? shapeAngle + Math.PI / 2 : random.NextDouble() * 2.0 * Math.PI;

        for (int dy = 0; dy < height - 3; dy++) {
            int radius = RadiusRound(random, dy, height, width);
            Carve(level, radius, dy, origin, false, angle, local, ellipseA, ellipseC);
        }

        for (int dy = -1; dy > -height + random.NextInt(5); dy--) {
            int radius = RadiusSteep(random, -dy, height, width);
            Carve(level, radius, dy, origin, true, angle, local, ellipseA, ellipseC);
        }
    }

    private void Carve(IFeatureLevel level, int radius, int dy, Vec3<int> origin, bool underWater,
        double angle, Vec3<int> local, int ellipseA, int ellipseC) {

        int a = radius + 1 + ellipseA / 3;
        int c = Math.Min(radius - 3, 3) + ellipseC / 2 - 1;

        for (int dx = -a; dx < a; dx++) {
            for (int dz = -a; dz < a; dz++) {
                if (!(SignedDistanceEllipse(dx, dz, local, a, c, angle) < 0.0)) {
                    continue;
                }

                int x = origin.X + dx;
                int y = origin.Y + dy;
                int z = origin.Z + dz;

                IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

                if (!IsIcebergBlock(block) && !block.Identifier.Equals(Block.SnowBlock.Identifier)) {
                    continue;
                }

                if (underWater) {
                    level.SetState(x, y, z, Block.Water.StateId);
                    continue;
                }

                level.SetState(x, y, z, Block.Air.StateId);

                if (level.Registry.Blocks.GetByStateId(level.GetState(x, y + 1, z)).Identifier
                    .Equals(Block.Snow.Identifier)) {

                    level.SetState(x, y + 1, z, Block.Air.StateId);
                }
            }
        }
    }

    private void GenerateBlock(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height,
        int dx, int dy, int dz, int radius, int a, bool isEllipse, int ellipseC, double shapeAngle,
        bool snowOnTop) {

        double distance = isEllipse
            ? SignedDistanceEllipse(dx, dz, Vec3<int>.Zero, a, EllipseC(dy, height, ellipseC), shapeAngle)
            : SignedDistanceCircle(dx, dz, radius, random);

        if (!(distance < 0.0)) {
            return;
        }

        double threshold = isEllipse ? -0.5 : -6 - random.NextInt(3);

        // The pitting near the surface: a block just inside the boundary is dropped one time in ten,
        // and the second draw only happens for the blocks that got that far.
        if (distance > threshold && random.NextDouble() > 0.9) {
            return;
        }

        SetIcebergBlock(level, random, origin.X + dx, origin.Y + dy, origin.Z + dz, height - dy, height,
            isEllipse, snowOnTop);
    }

    /// <summary>
    /// Snow on the upper part of the berg and ice below it, where the boundary is drawn per block.
    /// </summary>
    private void SetIcebergBlock(IFeatureLevel level, RandomSource random, int x, int y, int z,
        int fromTop, int height, bool isEllipse, bool snowOnTop) {

        IBlock existing = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
        bool isWater = existing.Identifier.Equals(Block.Water.Identifier);

        if (!existing.Air && !existing.Identifier.Equals(Block.SnowBlock.Identifier)
            && !existing.Identifier.Equals(Block.Ice.Identifier) && !isWater) {

            return;
        }

        // Short circuits for the round berg, so only the ellipse one pays this draw.
        bool jitter = !isEllipse || random.NextDouble() > 0.05;
        int divisor = isEllipse ? 3 : 2;

        if (snowOnTop && !isWater
            && fromTop <= random.NextInt(Math.Max(1, height / divisor)) + height * 0.6 && jitter) {

            level.SetState(x, y, z, Block.SnowBlock.StateId);
            return;
        }

        level.SetState(x, y, z, State);
    }

    /// <summary>
    /// Pulls the top three layers of an ellipse berg in, which is what gives it a point rather than a
    /// flat top.
    /// </summary>
    private static int EllipseC(int dy, int height, int ellipseC) {
        return dy > 0 && height - dy <= 3 ? ellipseC - (4 - (height - dy)) : ellipseC;
    }

    /// <summary>
    /// A circle whose radius is jittered per block, which is the whole of why a round berg is craggy.
    /// </summary>
    private static double SignedDistanceCircle(int dx, int dz, int radius, RandomSource random) {
        float offset = 10.0f * Math.Clamp(random.NextFloat(), 0.2f, 0.8f) / radius;
        return offset + Math.Pow(dx, 2.0) + Math.Pow(dz, 2.0) - Math.Pow(radius, 2.0);
    }

    private static double SignedDistanceEllipse(int dx, int dz, Vec3<int> origin, int a, int c,
        double angle) {

        double x = dx - origin.X;
        double z = dz - origin.Z;

        return Math.Pow((x * Math.Cos(angle) - z * Math.Sin(angle)) / a, 2.0)
            + Math.Pow((x * Math.Sin(angle) + z * Math.Cos(angle)) / c, 2.0)
            - 1.0;
    }

    /// <summary>
    /// The round berg's taper. A tall one takes the second branch, which halves the height of the
    /// lower layers and so gives it a broad skirt under a narrow spire.
    /// </summary>
    private static int RadiusRound(RandomSource random, int dy, int height, int width) {
        float k = 3.5f - random.NextFloat();
        float scale = (1.0f - (float)Math.Pow(dy, 2.0) / (height * k)) * width;

        // Drawn whether or not the branch is taken, so the sequence does not depend on the height.
        if (height > 15 + random.NextInt(5)) {
            int flattened = dy < 3 + random.NextInt(6) ? dy / 2 : dy;
            scale = (1.0f - flattened / (height * k * 0.4f)) * width;
        }

        return (int)MathF.Ceiling(scale / 2.0f);
    }

    private static int RadiusEllipse(int dy, int height, int width) {
        float scale = (1.0f - (float)Math.Pow(dy, 2.0) / (height * 1.0f)) * width;
        return (int)MathF.Ceiling(scale / 2.0f);
    }

    /// <summary>Linear rather than square, which is what makes the underwater half a steep cone.</summary>
    private static int RadiusSteep(RandomSource random, int dy, int height, int width) {
        float k = 1.0f + random.NextFloat() / 2.0f;
        float scale = (1.0f - dy / (height * k)) * width;
        return (int)MathF.Ceiling(scale / 2.0f);
    }

    /// <summary>
    /// Takes the loose blocks off: anything hanging over air goes, and anything with three or more of
    /// its four sides exposed goes.
    /// </summary>
    private void Smooth(IFeatureLevel level, Vec3<int> origin, int width, int height, bool isEllipse,
        int ellipseA) {

        int a = isEllipse ? ellipseA : width / 2;

        for (int dx = -a; dx <= a; dx++) {
            for (int dz = -a; dz <= a; dz++) {
                for (int dy = 0; dy <= height; dy++) {
                    int x = origin.X + dx;
                    int y = origin.Y + dy;
                    int z = origin.Z + dz;

                    IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));
                    bool iceberg = IsIcebergBlock(block);

                    if (!iceberg && !block.Identifier.Equals(Block.Snow.Identifier)) {
                        continue;
                    }

                    if (level.IsAir(x, y - 1, z)) {
                        level.SetState(x, y, z, Block.Air.StateId);
                        level.SetState(x, y + 1, z, Block.Air.StateId);
                        continue;
                    }

                    if (!iceberg) {
                        continue;
                    }

                    int exposed = 0;

                    // West, east, north, south.
                    foreach ((int sx, int sz) in Sides) {
                        if (!IsIcebergBlock(
                            level.Registry.Blocks.GetByStateId(level.GetState(x + sx, y, z + sz)))) {

                            exposed++;
                        }
                    }

                    if (exposed >= 3) {
                        level.SetState(x, y, z, Block.Air.StateId);
                    }
                }
            }
        }
    }

    private static readonly (int X, int Z)[] Sides = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    private static bool IsIcebergBlock(IBlock block) {
        return block.Identifier.Equals(Block.PackedIce.Identifier)
            || block.Identifier.Equals(Block.SnowBlock.Identifier)
            || block.Identifier.Equals(Block.BlueIce.Identifier);
    }
}
