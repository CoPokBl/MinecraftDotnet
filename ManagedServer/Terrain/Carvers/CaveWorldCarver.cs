using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CaveWorldCarver</c>: the branching tunnels, and the rooms some of them open with.
/// </summary>
/// <remarks>
/// A cave is one to four tunnels from a shared start, and the count of caves is
/// <c>nextInt(nextInt(nextInt(bound) + 1) + 1)</c>: three nested draws, so most source chunks that pass
/// the probability roll still start none and a few start a dozen. That is what makes cave systems
/// clustered rather than evenly spread.
/// <p/>
/// A tunnel splits once, at a point drawn from its own seed, into two tunnels leaving at right angles
/// and <b>returns</b> rather than continuing, so a tunnel is a binary tree and never a trunk with
/// branches hanging off it.
/// </remarks>
public class CaveWorldCarver : WorldCarver<CaveCarverConfiguration> {
    public override bool IsStartChunk(CaveCarverConfiguration configuration, RandomSource random) {
        return random.NextFloat() <= configuration.Probability;
    }

    public override void Carve(CarvingContext context, CaveCarverConfiguration configuration,
        RandomSource random, int sourceChunkX, int sourceChunkZ) {

        int maxDistance = (Range * 2 - 1) * 16;
        int caveCount = random.NextInt(random.NextInt(random.NextInt(CaveBound) + 1) + 1);

        for (int cave = 0; cave < caveCount; cave++) {
            double x = sourceChunkX * 16 + random.NextInt(16);
            double y = configuration.Y.Sample(random, context.Heights);
            double z = sourceChunkZ * 16 + random.NextInt(16);

            double horizontalRadiusMultiplier = configuration.HorizontalRadiusMultiplier.Sample(random);
            double verticalRadiusMultiplier = configuration.VerticalRadiusMultiplier.Sample(random);
            double floorLevel = configuration.FloorLevel.Sample(random);

            CarveSkipChecker skipChecker = (_, xd, yd, zd, _) => ShouldSkip(xd, yd, zd, floorLevel);

            int tunnels = 1;

            if (random.NextInt(4) == 0) {
                double yScale = configuration.YScale.Sample(random);
                float roomThickness = 1.0f + random.NextFloat() * 6.0f;

                CreateRoom(context, configuration, x, y, z, roomThickness, yScale, skipChecker);
                tunnels += random.NextInt(4);
            }

            for (int i = 0; i < tunnels; i++) {
                float horizontalRotation = random.NextFloat() * (float)(Math.PI * 2);
                float verticalRotation = (random.NextFloat() - 0.5f) / 4.0f;
                float thickness = GetThickness(random);
                int distance = maxDistance - random.NextInt(maxDistance / 4);

                CreateTunnel(context, configuration, random.NextLong(), x, y, z,
                    horizontalRadiusMultiplier, verticalRadiusMultiplier, thickness, horizontalRotation,
                    verticalRotation, 0, distance, YScale, skipChecker);
            }
        }
    }

    /// <summary>The bound of the outermost of the three nested draws that decide how many caves start.</summary>
    protected virtual int CaveBound => 15;

    protected virtual float GetThickness(RandomSource random) {
        float thickness = random.NextFloat() * 2.0f + random.NextFloat();

        // One tunnel in ten is widened by a product of two more draws, which is where the large
        // chambers in a cave system come from.
        if (random.NextInt(10) == 0) {
            thickness *= random.NextFloat() * random.NextFloat() * 3.0f + 1.0f;
        }

        return thickness;
    }

    /// <summary>How much taller than wide a tunnel is. The nether's caves are five times as tall.</summary>
    protected virtual double YScale => 1.0;

    /// <summary>
    /// The chamber a quarter of caves open with: a single ellipsoid, one block east of the start.
    /// </summary>
    /// <remarks>
    /// The <c>sin</c> is of a right angle, so it is one and the radius is <c>1.5 + thickness</c>. It is
    /// kept because it is the same expression the tunnel evaluates per step, with the step ratio pinned
    /// at its midpoint.
    /// </remarks>
    private void CreateRoom(CarvingContext context, CaveCarverConfiguration configuration, double x,
        double y, double z, float thickness, double yScale, CarveSkipChecker skipChecker) {

        double horizontalRadius = 1.5 + Mth.Sin(Math.PI / 2) * thickness;
        double verticalRadius = horizontalRadius * yScale;

        CarveEllipsoid(context, configuration, x + 1.0, y, z, horizontalRadius, verticalRadius, skipChecker);
    }

    /// <summary>
    /// One tunnel: a walk that steps a block at a time, turning by an amount that is itself a random
    /// walk.
    /// </summary>
    /// <remarks>
    /// The two rotation deltas are damped every step and then nudged, which is what gives a tunnel a
    /// long sweeping curve rather than a jitter. The vertical damping is the one thing a
    /// <c>steep</c> tunnel changes: 0.92 against 0.7, so a steep tunnel keeps its climb for far longer.
    /// <p/>
    /// <b>The random comes from the seed, not from the caller.</b> Every tunnel is reseeded from a long
    /// drawn by its parent, so a tunnel's shape does not depend on how many ellipsoids the tunnels
    /// before it cut, and this chunk gets the same tunnel as the chunk the tunnel started in.
    /// </remarks>
    private void CreateTunnel(CarvingContext context, CaveCarverConfiguration configuration, long tunnelSeed,
        double x, double y, double z, double horizontalRadiusMultiplier, double verticalRadiusMultiplier,
        float thickness, float horizontalRotation, float verticalRotation, int step, int distance,
        double yScale, CarveSkipChecker skipChecker) {

        RandomSource random = new LegacyRandomSource(tunnelSeed);

        int splitPoint = random.NextInt(distance / 2) + distance / 4;
        bool steep = random.NextInt(6) == 0;

        float yRota = 0.0f;
        float xRota = 0.0f;

        for (int currentStep = step; currentStep < distance; currentStep++) {
            double horizontalRadius = 1.5 + Mth.Sin((float)Math.PI * currentStep / distance) * thickness;
            double verticalRadius = horizontalRadius * yScale;

            float cosX = Mth.Cos(verticalRotation);
            x += Mth.Cos(horizontalRotation) * cosX;
            y += Mth.Sin(verticalRotation);
            z += Mth.Sin(horizontalRotation) * cosX;

            verticalRotation *= steep ? 0.92f : 0.7f;
            verticalRotation += xRota * 0.1f;
            horizontalRotation += yRota * 0.1f;
            xRota *= 0.9f;
            yRota *= 0.75f;
            xRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 2.0f;
            yRota += (random.NextFloat() - random.NextFloat()) * random.NextFloat() * 4.0f;

            if (currentStep == splitPoint && thickness > 1.0f) {
                // Both branches carry on from this step's index rather than from zero, so the pair
                // finish where the parent would have and the whole tree is the same length.
                CreateTunnel(context, configuration, random.NextLong(), x, y, z,
                    horizontalRadiusMultiplier, verticalRadiusMultiplier,
                    random.NextFloat() * 0.5f + 0.5f, horizontalRotation - (float)(Math.PI / 2),
                    verticalRotation / 3.0f, currentStep, distance, 1.0, skipChecker);

                CreateTunnel(context, configuration, random.NextLong(), x, y, z,
                    horizontalRadiusMultiplier, verticalRadiusMultiplier,
                    random.NextFloat() * 0.5f + 0.5f, horizontalRotation + (float)(Math.PI / 2),
                    verticalRotation / 3.0f, currentStep, distance, 1.0, skipChecker);

                return;
            }

            // Three steps in four cut something. The draw happens whatever the outcome, so skipping a
            // step does not shift the walk.
            if (random.NextInt(4) == 0) {
                continue;
            }

            if (!CanReach(context.ChunkX, context.ChunkZ, x, z, currentStep, distance, thickness)) {
                return;
            }

            CarveEllipsoid(context, configuration, x, y, z, horizontalRadius * horizontalRadiusMultiplier,
                verticalRadius * verticalRadiusMultiplier, skipChecker);
        }
    }

    /// <summary>
    /// The cave's cross section: a sphere, flattened off below the floor level so a tunnel has
    /// something to walk on rather than being a tube.
    /// </summary>
    private static bool ShouldSkip(double xd, double yd, double zd, double floorLevel) {
        return yd <= floorLevel || xd * xd + yd * yd + zd * zd >= 1.0;
    }
}

/// <summary>
/// <c>NetherWorldCarver</c>: the same tunnels, cut five times as tall and filled without an aquifer.
/// </summary>
/// <remarks>
/// The block rule is the whole difference beyond the three numbers: there is no aquifer question, no
/// grass fix-up, and the substance is decided by height alone. It writes <b>cave air</b> rather than
/// air, which is vanilla's marker for a carved position and is what stops the nether's lava seas being
/// treated as an open sky.
/// </remarks>
public sealed class NetherWorldCarver : CaveWorldCarver {
    /// <summary>How far above the bottom of the world the nether's lava sea reaches.</summary>
    private const int LavaDepth = 31;

    protected override int CaveBound => 10;

    protected override double YScale => 5.0;

    protected override float GetThickness(RandomSource random) {
        return (random.NextFloat() * 2.0f + random.NextFloat()) * 2.0f;
    }

    protected override bool CarveBlock(CarvingContext context, CaveCarverConfiguration configuration,
        int blockX, int blockY, int blockZ, ref bool hasGrass) {

        uint existing = context.GetBlock(blockX, blockY, blockZ);

        if (!configuration.Replaceable.Contains(context.Registry.Blocks.GetByStateId(existing).Identifier)) {
            return false;
        }

        context.SetBlock(blockX, blockY, blockZ,
            blockY <= context.MinGenY + LavaDepth ? Block.Lava.StateId : Block.CaveAir.StateId);

        return true;
    }
}
