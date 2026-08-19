using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>SeagrassFeature</c>: one clump of seagrass, tall or short.
/// </summary>
/// <remarks>
/// The scatter is inside the feature rather than being a placement modifier, so a single placement
/// covers a sixteen block spread and lands on the ocean floor whatever the surface above it is doing.
/// </remarks>
public sealed record SeagrassFeature(double Probability) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int x = origin.X + random.NextInt(8) - random.NextInt(8);
        int z = origin.Z + random.NextInt(8) - random.NextInt(8);
        int y = level.GetHeight(HeightmapType.OceanFloor, x, z);

        if (!IsWater(level, x, y, z)) {
            return false;
        }

        // Drawn whether or not the position turned out to be water, so a clump costs the same either
        // way.
        bool tall = random.NextDouble() < Probability;
        IBlock state = tall ? Block.TallSeagrass : Block.Seagrass;

        if (!FeatureSurvival.CanSurvive(state, level, x, y, z)) {
            return false;
        }

        if (!tall) {
            level.SetState(x, y, z, state.StateId);
            return true;
        }

        // Both halves or neither: a lower half alone is a plant the client draws with no top.
        if (!IsWater(level, x, y + 1, z)) {
            return true;
        }

        level.SetState(x, y, z, state.StateId);

        if (state is IDoubleHalved halved) {
            level.SetState(x, y + 1, z, halved.WithHalf(BlockHalf.Upper).StateId);
        }

        return true;
    }

    private static bool IsWater(IFeatureLevel level, int x, int y, int z) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
            .Equals(Block.Water.Identifier);
    }
}

/// <summary>
/// <c>KelpFeature</c>: one stalk of kelp grown up from the ocean floor.
/// </summary>
/// <remarks>
/// The stalk is body blocks with a single head on top, and the head's age is drawn from
/// <c>20 + nextInt(4)</c> rather than from zero: kelp stops growing at age 25, so a generated stalk is
/// nearly finished and does not shoot to the surface the first time the chunk ticks.
/// <p/>
/// The loop has two ways out and they place the head in different cells. Running out of water lands
/// the head one block <b>below</b> the cursor, and only if nothing already caps the stalk under it.
/// </remarks>
public sealed record KelpFeature : ConfiguredFeature {
    public static readonly KelpFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int x = origin.X;
        int z = origin.Z;
        int y = level.GetHeight(HeightmapType.OceanFloor, x, z);

        if (!IsWater(level, x, y, z)) {
            return false;
        }

        IBlock body = Block.KelpPlant;
        int placed = 0;
        int height = 1 + random.NextInt(10);

        for (int step = 0; step <= height; step++) {
            bool room = IsWater(level, x, y, z) && IsWater(level, x, y + 1, z)
                && FeatureSurvival.CanSurvive(body, level, x, y, z);

            if (room) {
                if (step == height) {
                    level.SetState(x, y, z, Head(random).StateId);
                    placed++;
                } else {
                    level.SetState(x, y, z, body.StateId);
                }
            } else if (step > 0) {
                // Only a step that has already grown something caps the stalk and stops. The first
                // step finding no room falls through instead and walks on up the column, so a stalk
                // starting under an overhang still grows above it.
                if (FeatureSurvival.CanSurvive(Block.Kelp, level, x, y - 1, z)
                    && !Is(level, x, y - 2, z, Block.Kelp.Identifier)) {

                    level.SetState(x, y - 1, z, Head(random).StateId);
                    placed++;
                }

                break;
            }

            y++;
        }

        return placed > 0;
    }

    private static IBlock Head(RandomSource random) {
        IBlock kelp = Block.Kelp;
        return kelp is IAged aged ? aged.WithAge(random.NextInt(4) + 20) : kelp;
    }

    private static bool Is(IFeatureLevel level, int x, int y, int z, Identifier block) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier.Equals(block);
    }

    private static bool IsWater(IFeatureLevel level, int x, int y, int z) {
        return Is(level, x, y, z, Block.Water.Identifier);
    }
}

/// <summary>
/// <c>SeaPickleFeature</c>: a handful of pickles scattered over the ocean floor.
/// </summary>
/// <remarks>
/// The count is how many attempts are made, not how many land, and every attempt draws its offsets
/// and its pickle count whether or not the position takes one.
/// </remarks>
public sealed record SeaPickleFeature(IIntProvider Count) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        int placed = 0;
        int attempts = Count.Sample(random);

        for (int attempt = 0; attempt < attempts; attempt++) {
            int x = origin.X + random.NextInt(8) - random.NextInt(8);
            int z = origin.Z + random.NextInt(8) - random.NextInt(8);
            int y = level.GetHeight(HeightmapType.OceanFloor, x, z);

            IBlock pickle = Block.SeaPickle;
            if (pickle is IStackable stackable) {
                pickle = stackable.WithCount(random.NextInt(4) + 1);
            }

            if (!IsWater(level, x, y, z) || !FeatureSurvival.CanSurvive(pickle, level, x, y, z)) {
                continue;
            }

            level.SetState(x, y, z, pickle.StateId);
            placed++;
        }

        return placed > 0;
    }

    private static bool IsWater(IFeatureLevel level, int x, int y, int z) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
            .Equals(Block.Water.Identifier);
    }
}

/// <summary>
/// <c>BambooFeature</c>: one stalk of bamboo, and sometimes the podzol patch under it.
/// </summary>
/// <remarks>
/// The three blocks at the top are what give bamboo its taper, and they are only written for a stalk
/// that reached three blocks: large leaves capping it, large leaves below that, then small leaves.
/// A shorter stalk stays bare.
/// <p/>
/// The podzol is drawn and placed <b>before</b> the stalk, so the patch appears even where the stalk
/// itself is immediately blocked.
/// </remarks>
public sealed record BambooFeature(float Probability) : ConfiguredFeature {
    private static readonly Identifier BeneathBambooPodzolReplaceable =
        "minecraft:beneath_bamboo_podzol_replaceable";

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!level.IsEmptyBlock(origin.X, origin.Y, origin.Z)) {
            return false;
        }

        if (!FeatureSurvival.CanSurvive(Block.Bamboo, level, origin.X, origin.Y, origin.Z)) {
            // Vanilla still reports success here: the count is incremented outside the survival test
            // and only inside the "is this cell empty" one.
            return true;
        }

        int height = random.NextInt(12) + 5;

        if (random.NextFloat() < Probability) {
            int radius = random.NextInt(4) + 1;

            for (int x = origin.X - radius; x <= origin.X + radius; x++) {
                for (int z = origin.Z - radius; z <= origin.Z + radius; z++) {
                    int dx = x - origin.X;
                    int dz = z - origin.Z;

                    if (dx * dx + dz * dz > radius * radius) {
                        continue;
                    }

                    int y = level.GetHeight(HeightmapType.WorldSurface, x, z) - 1;
                    if (level.Blocks.IsIn(BeneathBambooPodzolReplaceable, level.GetState(x, y, z))) {
                        level.SetState(x, y, z, Block.Podzol.StateId);
                    }
                }
            }
        }

        int stalkY = origin.Y;
        uint trunk = Trunk().StateId;

        for (int grown = 0; grown < height && level.IsEmptyBlock(origin.X, stalkY, origin.Z); grown++) {
            level.SetState(origin.X, stalkY, origin.Z, trunk);
            stalkY++;
        }

        if (stalkY - origin.Y >= 3) {
            level.SetState(origin.X, stalkY, origin.Z, Leaves(BambooBlock.Leaves.Large, 1).StateId);
            level.SetState(origin.X, stalkY - 1, origin.Z, Leaves(BambooBlock.Leaves.Large, 0).StateId);
            level.SetState(origin.X, stalkY - 2, origin.Z, Leaves(BambooBlock.Leaves.Small, 0).StateId);
        }

        return true;
    }

    /// <summary>
    /// The bare stalk: age one so the client draws it thick, no leaves, and stage zero so it is still
    /// a growing tip.
    /// </summary>
    /// <remarks>
    /// Written against the generated record rather than through a property interface, because
    /// <c>leaves</c> is an enum nested in that record and an interface cannot name one. The same
    /// escape hatch the creaking heart decorator takes.
    /// </remarks>
    private static IBlock Trunk() {
        return Block.Bamboo is BambooBlock bamboo
            ? bamboo with { Age = 1, LeavesValue = BambooBlock.Leaves.None, Stage = 0 }
            : Block.Bamboo;
    }

    private static IBlock Leaves(BambooBlock.Leaves leaves, int stage) {
        return Trunk() is BambooBlock bamboo
            ? bamboo with { LeavesValue = leaves, Stage = stage }
            : Block.Bamboo;
    }
}
