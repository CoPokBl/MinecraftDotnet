using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>DeltaFeature</c>: a patch of one block with a rim of another offset from it.
/// </summary>
/// <remarks>
/// The rim is the same patch drawn twice, once in place and once shifted by the rim size, so the rim
/// shows only on the sides the shift moved away from. That is why a basalt delta's magma patches have
/// blackstone along two edges and not all four.
/// <p/>
/// <c>isClear</c> is what keeps it on the floor: every neighbour must be solid <b>except</b> the one
/// above, which must be air. A position with air beside it is a wall or a ledge and is skipped.
/// </remarks>
public sealed record DeltaFeature(uint Contents, uint Rim, IIntProvider Size, IIntProvider RimSize)
    : ConfiguredFeature {

    private static readonly Identifier[] CannotReplace = [
        "minecraft:bedrock", "minecraft:nether_bricks", "minecraft:nether_brick_fence",
        "minecraft:nether_brick_stairs", "minecraft:nether_wart", "minecraft:chest", "minecraft:spawner"
    ];

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        bool spawnRim = random.NextDouble() < 0.9;
        int rimX = spawnRim ? RimSize.Sample(random) : 0;
        int rimZ = spawnRim ? RimSize.Sample(random) : 0;
        bool hasRim = spawnRim && rimX != 0 && rimZ != 0;

        int radiusX = Size.Sample(random);
        int radiusZ = Size.Sample(random);
        int limit = Math.Max(radiusX, radiusZ);

        bool anyPlaced = false;

        // Vanilla walks a manhattan iterator ordered by distance and stops past the limit, so the
        // positions reached are the box intersected with the diamond. Nothing in the body draws from
        // the random, so the set is the whole of what matters.
        for (int dx = -radiusX; dx <= radiusX; dx++) {
            for (int dz = -radiusZ; dz <= radiusZ; dz++) {
                if (Math.Abs(dx) + Math.Abs(dz) > limit) {
                    continue;
                }

                int x = origin.X + dx;
                int z = origin.Z + dz;

                if (!IsClear(level, x, origin.Y, z)) {
                    continue;
                }

                if (hasRim) {
                    anyPlaced = true;
                    level.SetState(x, origin.Y, z, Rim);
                }

                if (IsClear(level, x + rimX, origin.Y, z + rimZ)) {
                    anyPlaced = true;
                    level.SetState(x + rimX, origin.Y, z + rimZ, Contents);
                }
            }
        }

        return anyPlaced;
    }

    private bool IsClear(IFeatureLevel level, int x, int y, int z) {
        uint state = level.GetState(x, y, z);
        IBlock block = level.Registry.Blocks.GetByStateId(state);

        if (state == Contents || CannotReplace.Contains(block.Identifier)) {
            return false;
        }

        foreach (BlockFace face in FeatureUtil.AllDirections) {
            Vec3<int> step = Placement.PlacementParser.Step(face);
            bool isAir = level.IsAir(x + step.X, y + step.Y, z + step.Z);

            if (isAir != (face == BlockFace.PosY)) {
                return false;
            }
        }

        return true;
    }
}
