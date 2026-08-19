using ManagedServer.Placement;
using ManagedServer.Terrain.Structures;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>MonsterRoomFeature</c>: the cobblestone dungeon, a hollow room with a spawner in the middle and
/// up to two chests against its walls.
/// </summary>
/// <remarks>
/// The room declines unless its floor and ceiling are solid all the way across and between one and
/// five of its wall positions open onto air, which is what puts a dungeon on the side of a cave rather
/// than buried in stone.
/// <p/>
/// <b>The spawner and the chests are placed and their contents are not.</b> Both live on a block
/// entity and there is no port of one, so a dungeon comes out with an inert spawner and empty chests.
/// <b>Their draws are still taken</b>, on <c>StructurePiece.ConsumeLootSeed</c>'s reasoning: vanilla
/// draws the chest's loot seed from the same random the second chest's position comes out of, and the
/// mob's from the same one again, so skipping either moves the rest of the feature.
/// </remarks>
public sealed record MonsterRoomFeature : ConfiguredFeature {
    public static readonly MonsterRoomFeature Instance = new();

    private static readonly Identifier CannotReplace = "minecraft:features_cannot_replace";

    /// <summary>
    /// What the room is hollowed out with, which is <b>cave air</b> rather than air.
    /// </summary>
    /// <remarks>
    /// <c>MonsterRoomFeature.AIR</c> is <c>Blocks.CAVE_AIR</c>. The two are the same to everything that
    /// reads a block and different to anything comparing states, so writing plain air here is a room
    /// that looks right and disagrees with vanilla at every position it cleared.
    /// </remarks>
    private static uint CaveAir => Block.CaveAir.StateId;

    public override bool Place(FeaturePlaceContext context) {
        RandomSource random = context.Random;
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        int xRadius = random.NextInt(2) + 2;
        int minX = -xRadius - 1;
        int maxX = xRadius + 1;

        int zRadius = random.NextInt(2) + 2;
        int minZ = -zRadius - 1;
        int maxZ = zRadius + 1;

        int openings = 0;

        for (int x = minX; x <= maxX; x++) {
            for (int y = -1; y <= 4; y++) {
                for (int z = minZ; z <= maxZ; z++) {
                    int atX = origin.X + x;
                    int atY = origin.Y + y;
                    int atZ = origin.Z + z;

                    bool solid = level.Blocks.IsSolid(level.GetState(atX, atY, atZ));

                    // The floor and the ceiling have to hold the room up, so one soft position
                    // anywhere in either declines before anything is written.
                    if (y == -1 && !solid) {
                        return false;
                    }

                    if (y == 4 && !solid) {
                        return false;
                    }

                    if ((x == minX || x == maxX || z == minZ || z == maxZ)
                        && y == 0
                        && level.Blocks.IsAir(level.GetState(atX, atY, atZ))
                        && level.Blocks.IsAir(level.GetState(atX, atY + 1, atZ))) {

                        openings++;
                    }
                }
            }
        }

        if (openings < 1 || openings > 5) {
            return false;
        }

        // Top down, so a wall position whose support was taken out lower in the same column is opened
        // rather than walled.
        for (int x = minX; x <= maxX; x++) {
            for (int y = 3; y >= -1; y--) {
                for (int z = minZ; z <= maxZ; z++) {
                    int atX = origin.X + x;
                    int atY = origin.Y + y;
                    int atZ = origin.Z + z;

                    uint state = level.GetState(atX, atY, atZ);

                    // The y == 4 arm is vanilla's and unreachable: the loop tops out at three.
                    if (x == minX || y == -1 || z == minZ || x == maxX || y == 4 || z == maxZ) {
                        if (atY >= level.MinY
                            && !level.Blocks.IsSolid(level.GetState(atX, atY - 1, atZ))) {

                            level.SetState(atX, atY, atZ, CaveAir);
                        } else if (level.Blocks.IsSolid(state) && !IsChest(level, state)) {
                            // The floor is three quarters mossy, and the draw is taken for the floor
                            // alone rather than for every wall block.
                            uint wall = y == -1 && random.NextInt(4) != 0
                                ? Block.MossyCobblestone.StateId
                                : Block.Cobblestone.StateId;

                            SafeSetBlock(level, atX, atY, atZ, wall);
                        }
                    } else if (!IsChest(level, state) && !IsSpawner(level, state)) {
                        SafeSetBlock(level, atX, atY, atZ, CaveAir);
                    }
                }
            }
        }

        // Two chests, each given three tries at a position with exactly one solid neighbour, which is
        // what puts one flat against a wall rather than in a corner or out in the room.
        for (int chest = 0; chest < 2; chest++) {
            for (int attempt = 0; attempt < 3; attempt++) {
                int x = origin.X + random.NextInt(xRadius * 2 + 1) - xRadius;
                int y = origin.Y;
                int z = origin.Z + random.NextInt(zRadius * 2 + 1) - zRadius;

                if (!level.Blocks.IsAir(level.GetState(x, y, z))) {
                    continue;
                }

                int walls = 0;
                foreach (BlockFace face in Directions.Horizontal) {
                    (int nx, int nz) = Step(face);

                    if (level.Blocks.IsSolid(level.GetState(x + nx, y, z + nz))) {
                        walls++;
                    }
                }

                if (walls != 1) {
                    continue;
                }

                SafeSetBlock(level, x, y, z,
                    StructurePiece.Reorient(level, x, y, z, Block.Chest.StateId));

                // setBlockEntityLootTable draws only where the container it wrote is really there, so
                // this asks the same question the only way it can be asked here.
                if (IsChest(level, level.GetState(x, y, z))) {
                    random.NextLong();
                }

                break;
            }
        }

        SafeSetBlock(level, origin.X, origin.Y, origin.Z, Block.Spawner.StateId);

        // SpawnerBlockEntity.setEntityId picks the mob, and vanilla reaches it only where the spawner
        // it wrote is really there. Nothing here holds the answer; the draw is what the sequence
        // needs, and it is the last thing the feature does either way.
        if (IsSpawner(level, level.GetState(origin.X, origin.Y, origin.Z))) {
            random.NextInt(MobCount);
        }

        return true;
    }

    /// <summary>How many entity types <c>MonsterRoomFeature.MOBS</c> holds.</summary>
    private const int MobCount = 4;

    private static bool IsChest(IFeatureLevel level, uint state) {
        return level.Registry.Blocks.GetByStateId(state).Identifier.Equals(Block.Chest.Identifier);
    }

    private static bool IsSpawner(IFeatureLevel level, uint state) {
        return level.Registry.Blocks.GetByStateId(state).Identifier.Equals(Block.Spawner.Identifier);
    }

    /// <summary><c>Feature.safeSetBlock</c> against <c>features_cannot_replace</c>.</summary>
    private static void SafeSetBlock(IFeatureLevel level, int x, int y, int z, uint state) {
        if (level.Blocks.IsIn(CannotReplace, level.GetState(x, y, z))) {
            return;
        }

        level.SetState(x, y, z, state);
    }

    private static (int, int) Step(BlockFace face) => face switch {
        BlockFace.NegZ => (0, -1),
        BlockFace.PosZ => (0, 1),
        BlockFace.NegX => (-1, 0),
        _ => (1, 0)
    };
}
