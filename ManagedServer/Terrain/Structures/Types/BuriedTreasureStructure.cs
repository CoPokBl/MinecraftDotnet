using ManagedServer.Placement;
using ManagedServer.Terrain.Features;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>BuriedTreasureStructure</c>: one chest under the sand, in nine chunks out of every thousand.
/// </summary>
/// <remarks>
/// Its placement is a spacing of one with a frequency of a hundredth, so every chunk is a candidate
/// and the roll does all the thinning. That is why it uses a legacy reducer with a constant salt.
/// </remarks>
public sealed class BuriedTreasureStructure(Structure.StructureSettings settings) : Structure(settings) {
    protected override GenerationStub FindGenerationPoint(StructureGenerationContext context) {
        return OnTopOfChunkCenter(context, HeightmapType.OceanFloorWorldgen, builder =>
            builder.AddPiece(new BuriedTreasurePiece(
                (context.ChunkX << 4) + 9, 90, (context.ChunkZ << 4) + 9)));
    }
}

/// <summary>
/// <c>BuriedTreasurePiece</c>: walks down a column until it finds stone, and puts a chest on it.
/// </summary>
/// <remarks>
/// The block that goes around the chest depends on what is beside it: a neighbour that is itself open
/// gets the stone from below, and everything else gets whatever was already there, or sand. That is
/// what stops the chest sitting in an open pocket of a cave with nothing holding it.
/// <p/>
/// The chest is placed and its loot table is not, on <c>StructurePiece.CreateChest</c>'s reasoning:
/// a loot table lives on a block entity and there is no port of one.
/// </remarks>
public sealed class BuriedTreasurePiece(int x, int y, int z)
    : StructurePiece(0, new BoundingBox(x, y, z)) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        int surfaceY = level.GetHeight(HeightmapType.OceanFloorWorldgen, BoundingBox.MinX,
            BoundingBox.MinZ);

        int posX = BoundingBox.MinX;
        int posZ = BoundingBox.MinZ;

        for (int posY = surfaceY; posY > level.MinY; posY--) {
            uint current = level.GetState(posX, posY, posZ);
            uint below = level.GetState(posX, posY - 1, posZ);

            if (!IsAnchor(level, below)) {
                continue;
            }

            uint soft = !level.Blocks.IsAir(current) && !IsLiquid(level, current)
                ? current
                : Block.Sand.StateId;

            foreach (BlockFace face in Directions.All) {
                (int nx, int ny, int nz) = Offset(posX, posY, posZ, face);
                uint neighbour = level.GetState(nx, ny, nz);

                if (!level.Blocks.IsAir(neighbour) && !IsLiquid(level, neighbour)) {
                    continue;
                }

                uint underNeighbour = level.GetState(nx, ny - 1, nz);
                bool openBelow = level.Blocks.IsAir(underNeighbour) || IsLiquid(level, underNeighbour);

                // Anything with a hole under it gets the hard block, so the chest ends up standing
                // on a plug of stone rather than over a cave.
                level.SetState(nx, ny, nz, openBelow && face != BlockFace.PosY ? below : soft);
            }

            BoundingBox = new BoundingBox(posX, posY, posZ);
            CreateChest(level, chunkBox, random, posX, posY, posZ);
            return;
        }
    }

    /// <summary>The five blocks the chest is allowed to rest on.</summary>
    private static bool IsAnchor(IFeatureLevel level, uint stateId) {
        Identifier block = level.Registry.Blocks.GetByStateId(stateId).Identifier;

        return block.Equals(Block.Sandstone.Identifier)
            || block.Equals(Block.Stone.Identifier)
            || block.Equals(Block.Andesite.Identifier)
            || block.Equals(Block.Granite.Identifier)
            || block.Equals(Block.Diorite.Identifier);
    }

    private static bool IsLiquid(IFeatureLevel level, uint stateId) {
        Identifier block = level.Registry.Blocks.GetByStateId(stateId).Identifier;
        return block.Equals(Block.Water.Identifier) || block.Equals(Block.Lava.Identifier);
    }

    private static (int, int, int) Offset(int x, int y, int z, BlockFace face) {
        return face switch {
            BlockFace.NegY => (x, y - 1, z),
            BlockFace.PosY => (x, y + 1, z),
            BlockFace.NegZ => (x, y, z - 1),
            BlockFace.PosZ => (x, y, z + 1),
            BlockFace.NegX => (x - 1, y, z),
            _ => (x + 1, y, z)
        };
    }
}
