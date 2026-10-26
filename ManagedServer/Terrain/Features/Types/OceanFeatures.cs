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
