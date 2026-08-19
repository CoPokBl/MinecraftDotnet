using ManagedServer.Placement;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>The four shell thicknesses of a geode, as inverse squared distances.</summary>
/// <remarks>
/// Larger means <b>thinner</b>: each is turned into a threshold by one over its square root, and the
/// thresholds are compared against a sum of inverse distances, so the numbers run the opposite way to
/// the radii they describe.
/// </remarks>
public sealed record GeodeLayerSettings(double Filling, double InnerLayer, double MiddleLayer,
    double OuterLayer);

/// <summary>How likely a geode is to be cracked open, and how wide the crack is.</summary>
public sealed record GeodeCrackSettings(double GenerateCrackChance, double BaseCrackSize,
    int CrackPointOffset);

/// <summary>
/// <c>GeodeFeature</c>: the amethyst geode, and the only feature built out of a distance field.
/// </summary>
/// <remarks>
/// The shape is a metaball. Three to four points are scattered inside the volume and every position is
/// scored by the sum of the inverse distances to them, so the shells are smooth blobs joining the
/// points rather than a sphere. The score decides which of the five layers a block belongs to, and the
/// noise term added to every distance is what roughens the shells.
/// <p/>
/// <b>The distance sum uses the fast inverse square root</b>, which is approximate. That is vanilla's
/// and not an optimisation to swap for an accurate one: the error is what the thresholds were tuned
/// against, and an exact reciprocal moves every shell boundary.
/// <p/>
/// The crack is a second, much smaller metaball built from three points off one side, subtracted from
/// the first. That is why a cracked geode opens along a face rather than having a hole punched in it.
/// <p/>
/// The noise is seeded from the <b>world seed alone</b>, so it is the same field everywhere and two
/// geodes in different chunks are cut from one continuous roughness.
/// </remarks>
public sealed record GeodeFeature(BlockStateProvider FillingProvider, BlockStateProvider InnerLayerProvider,
    BlockStateProvider AlternateInnerLayerProvider, BlockStateProvider MiddleLayerProvider,
    BlockStateProvider OuterLayerProvider, IReadOnlyList<IBlock> InnerPlacements,
    IReadOnlySet<Identifier> CannotReplace, IReadOnlySet<Identifier> InvalidBlocks,
    GeodeLayerSettings Layers, GeodeCrackSettings Crack, double UsePotentialPlacementsChance,
    double UseAlternateLayer0Chance, bool PlacementsRequireLayer0Alternate, IIntProvider OuterWallDistance,
    IIntProvider DistributionPoints, IIntProvider PointOffset, int MinGenOffset, int MaxGenOffset,
    double NoiseMultiplier, int InvalidBlocksThreshold) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int pointCount = DistributionPoints.Sample(random);

        NormalNoise noise = NormalNoise.Create(new LegacyRandomSource(level.Seed),
            new NoiseParameters(-4, [1.0]));

        // More points inside the same wall distance means a bigger blob, so the shells are thinned to
        // compensate and a busy geode does not come out solid.
        double crackSizeAdjustment = (double)pointCount / OuterWallDistance.MaxInclusive;

        double innerAir = 1.0 / Math.Sqrt(Layers.Filling);
        double innermostBlockLayer = 1.0 / Math.Sqrt(Layers.InnerLayer + crackSizeAdjustment);
        double innerCrust = 1.0 / Math.Sqrt(Layers.MiddleLayer + crackSizeAdjustment);
        double outerCrust = 1.0 / Math.Sqrt(Layers.OuterLayer + crackSizeAdjustment);

        double crackSize = 1.0 / Math.Sqrt(Crack.BaseCrackSize + random.NextDouble() / 2.0
            + (pointCount > 3 ? crackSizeAdjustment : 0.0));

        bool generateCrack = random.NextFloat() < Crack.GenerateCrackChance;

        List<(Vec3<int> Pos, int Offset)> points = [];
        int invalidPoints = 0;

        for (int i = 0; i < pointCount; i++) {
            int x = OuterWallDistance.Sample(random);
            int y = OuterWallDistance.Sample(random);
            int z = OuterWallDistance.Sample(random);

            Vec3<int> pos = new(origin.X + x, origin.Y + y, origin.Z + z);
            IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));

            // A geode reaching into open space or into something it must not cut is abandoned, which
            // is what keeps them buried.
            if ((state.Air || InvalidBlocks.Contains(state.Identifier))
                && ++invalidPoints > InvalidBlocksThreshold) {

                return false;
            }

            points.Add((pos, PointOffset.Sample(random)));
        }

        List<Vec3<int>> crackPoints = [];

        if (generateCrack) {
            // The crack always runs up the same three heights; only which corner it leaves by is drawn.
            int corner = random.NextInt(4);
            int offset = pointCount * 2 + 1;

            (int X, int Z) side = corner switch {
                0 => (offset, 0),
                1 => (0, offset),
                2 => (offset, offset),
                _ => (0, 0)
            };

            foreach (int y in (int[])[7, 5, 1]) {
                crackPoints.Add(new Vec3<int>(origin.X + side.X, origin.Y + y, origin.Z + side.Z));
            }
        }

        List<Vec3<int>> potentialCrystals = [];

        // BlockPos.betweenClosed walks x fastest, then y, then z, and the order is what decides which
        // position each draw below lands on. Walking the same box any other way spends the same
        // numbers and paints a different geode.
        for (int dz = MinGenOffset; dz <= MaxGenOffset; dz++) {
            for (int dy = MinGenOffset; dy <= MaxGenOffset; dy++) {
                for (int dx = MinGenOffset; dx <= MaxGenOffset; dx++) {
                    int x = origin.X + dx;
                    int y = origin.Y + dy;
                    int z = origin.Z + dz;

                    double noiseOffset = noise.GetValue(x, y, z) * NoiseMultiplier;

                    double shell = 0.0;
                    foreach ((Vec3<int> point, int pointOffset) in points) {
                        shell += Mth.InvSqrt(DistanceSquared(x, y, z, point) + pointOffset)
                            + noiseOffset;
                    }

                    double crackField = 0.0;
                    foreach (Vec3<int> point in crackPoints) {
                        crackField += Mth.InvSqrt(DistanceSquared(x, y, z, point) + Crack.CrackPointOffset)
                            + noiseOffset;
                    }

                    if (shell < outerCrust) {
                        continue;
                    }

                    if (generateCrack && crackField >= crackSize && shell < innerAir) {
                        // The crack is cut out of the shell rather than filled, so the geode opens.
                        // Vanilla also schedules a fluid tick on each neighbour so water floods in;
                        // there is no block tick scheduler here, so a cracked geode stays dry.
                        SafeSetBlock(level, x, y, z, Block.Air.StateId);
                        continue;
                    }

                    if (shell >= innerAir) {
                        SafeSetBlock(level, x, y, z, FillingProvider.GetState(level, random, x, y, z).StateId);
                        continue;
                    }

                    if (shell >= innermostBlockLayer) {
                        bool alternate = random.NextFloat() < UseAlternateLayer0Chance;

                        BlockStateProvider provider = alternate
                            ? AlternateInnerLayerProvider
                            : InnerLayerProvider;

                        SafeSetBlock(level, x, y, z, provider.GetState(level, random, x, y, z).StateId);

                        // Buds only grow off budding amethyst, which is what the alternate layer is,
                        // so the flag is what stops crystals sprouting from plain amethyst.
                        if ((!PlacementsRequireLayer0Alternate || alternate)
                            && random.NextFloat() < UsePotentialPlacementsChance) {

                            potentialCrystals.Add(new Vec3<int>(x, y, z));
                        }

                        continue;
                    }

                    if (shell >= innerCrust) {
                        SafeSetBlock(level, x, y, z,
                            MiddleLayerProvider.GetState(level, random, x, y, z).StateId);
                        continue;
                    }

                    SafeSetBlock(level, x, y, z, OuterLayerProvider.GetState(level, random, x, y, z).StateId);
                }
            }
        }

        PlaceCrystals(level, random, potentialCrystals);

        return true;
    }

    /// <summary>
    /// The buds on the inside face. One block is drawn per site and then the six directions are tried
    /// in order until one has room, so a bud always points into the cavity.
    /// </summary>
    private void PlaceCrystals(IFeatureLevel level, RandomSource random,
        IReadOnlyList<Vec3<int>> potentialCrystals) {

        if (InnerPlacements.Count == 0) {
            return;
        }

        foreach (Vec3<int> site in potentialCrystals) {
            IBlock crystal = InnerPlacements[random.NextInt(InnerPlacements.Count)];

            foreach (BlockFace face in FeatureUtil.AllDirections) {
                if (crystal is IDirectional directional) {
                    crystal = directional.WithFacing(face.ToCardinal());
                }

                Vec3<int> pos = site + Placement.PlacementParser.Step(face);
                IBlock existing = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));

                if (crystal is IWaterlogged waterloggable) {
                    crystal = waterloggable.WithWaterlogged(IsWaterSource(level, pos));
                }

                if (!CanClusterGrowAt(level, existing, pos)) {
                    continue;
                }

                SafeSetBlock(level, pos.X, pos.Y, pos.Z, crystal.StateId);
                break;
            }
        }
    }

    /// <summary><c>BuddingAmethystBlock.canClusterGrowAtState</c>: air, or a full block of water.</summary>
    private static bool CanClusterGrowAt(IFeatureLevel level, IBlock state, Vec3<int> pos) {
        return state.Air || IsWaterSource(level, pos);
    }

    private static bool IsWaterSource(IFeatureLevel level, Vec3<int> pos) {
        Fluids.FluidState fluid = Fluids.FluidState.Of(
            level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z)));

        return fluid.Kind == Fluids.FluidKind.Water && fluid.Amount == 8;
    }

    /// <summary>Writes unless the block there is on the list a geode may not cut through.</summary>
    private void SafeSetBlock(IFeatureLevel level, int x, int y, int z, uint state) {
        IBlock existing = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

        if (CannotReplace.Contains(existing.Identifier)) {
            return;
        }

        level.SetState(x, y, z, state);
    }

    private static double DistanceSquared(int x, int y, int z, Vec3<int> to) {
        double dx = x - to.X;
        double dy = y - to.Y;
        double dz = z - to.Z;

        return dx * dx + dy * dy + dz * dz;
    }
}
