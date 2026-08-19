using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>SwampHutStructure</c>: the witch hut, which is one piece on stilts.
/// </summary>
public sealed class SwampHutStructure(Structure.StructureSettings settings) : Structure(settings) {
    protected override GenerationStub FindGenerationPoint(StructureGenerationContext context) {
        return OnTopOfChunkCenter(context, HeightmapType.WorldSurfaceWorldgen, builder =>
            builder.AddPiece(new SwampHutPiece(context.Random, context.ChunkX << 4,
                context.ChunkZ << 4)));
    }
}

/// <summary>
/// <c>SwampHutPiece</c>: the hut itself, seven by nine and four tall on four oak log legs.
/// </summary>
/// <remarks>
/// The witch and the cat are not spawned. Both need a live entity added at generation time, and the
/// generator has no world to add one to. The hut is otherwise complete, cauldron and crafting table
/// included.
/// </remarks>
public sealed class SwampHutPiece(RandomSource random, int west, int north)
    : ScatteredFeaturePiece(west, 64, north, 7, 7, 9, RandomHorizontalDirection(random)) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (!UpdateAverageGroundHeight(level, chunkBox, 0)) {
            return;
        }

        uint planks = Block.SprucePlanks.StateId;
        uint log = Block.OakLog.StateId;
        uint fence = Block.OakFence.StateId;

        GenerateBox(level, chunkBox, 1, 1, 1, 5, 1, 7, planks, planks, false);
        GenerateBox(level, chunkBox, 1, 4, 2, 5, 4, 7, planks, planks, false);
        GenerateBox(level, chunkBox, 2, 1, 0, 4, 1, 0, planks, planks, false);
        GenerateBox(level, chunkBox, 2, 2, 2, 3, 3, 2, planks, planks, false);
        GenerateBox(level, chunkBox, 1, 2, 3, 1, 3, 6, planks, planks, false);
        GenerateBox(level, chunkBox, 5, 2, 3, 5, 3, 6, planks, planks, false);
        GenerateBox(level, chunkBox, 2, 2, 7, 4, 3, 7, planks, planks, false);

        GenerateBox(level, chunkBox, 1, 0, 2, 1, 3, 2, log, log, false);
        GenerateBox(level, chunkBox, 5, 0, 2, 5, 3, 2, log, log, false);
        GenerateBox(level, chunkBox, 1, 0, 7, 1, 3, 7, log, log, false);
        GenerateBox(level, chunkBox, 5, 0, 7, 5, 3, 7, log, log, false);

        PlaceBlock(level, fence, 2, 3, 2, chunkBox);
        PlaceBlock(level, fence, 3, 3, 7, chunkBox);
        PlaceBlock(level, Block.Air.StateId, 1, 3, 4, chunkBox);
        PlaceBlock(level, Block.Air.StateId, 5, 3, 4, chunkBox);
        PlaceBlock(level, Block.Air.StateId, 5, 3, 5, chunkBox);
        PlaceBlock(level, Block.PottedRedMushroom.StateId, 1, 3, 5, chunkBox);
        PlaceBlock(level, Block.CraftingTable.StateId, 3, 2, 6, chunkBox);
        PlaceBlock(level, Block.Cauldron.StateId, 4, 2, 6, chunkBox);
        PlaceBlock(level, fence, 1, 2, 1, chunkBox);
        PlaceBlock(level, fence, 5, 2, 1, chunkBox);

        uint north = Stairs(Direction.North, StairShape.Straight);
        uint east = Stairs(Direction.East, StairShape.Straight);
        uint west = Stairs(Direction.West, StairShape.Straight);
        uint south = Stairs(Direction.South, StairShape.Straight);

        GenerateBox(level, chunkBox, 0, 4, 1, 6, 4, 1, north, north, false);
        GenerateBox(level, chunkBox, 0, 4, 2, 0, 4, 7, east, east, false);
        GenerateBox(level, chunkBox, 6, 4, 2, 6, 4, 7, west, west, false);
        GenerateBox(level, chunkBox, 0, 4, 8, 6, 4, 8, south, south, false);

        // The four roof corners, which are the only stairs in the game a structure places with a
        // shape other than straight.
        PlaceBlock(level, Stairs(Direction.North, StairShape.OuterRight), 0, 4, 1, chunkBox);
        PlaceBlock(level, Stairs(Direction.North, StairShape.OuterLeft), 6, 4, 1, chunkBox);
        PlaceBlock(level, Stairs(Direction.South, StairShape.OuterLeft), 0, 4, 8, chunkBox);
        PlaceBlock(level, Stairs(Direction.South, StairShape.OuterRight), 6, 4, 8, chunkBox);

        for (int z = 2; z <= 7; z += 5) {
            for (int x = 1; x <= 5; x += 4) {
                FillColumnDown(level, log, x, -1, z, chunkBox);
            }
        }
    }

    private static uint Stairs(Direction facing, StairShape shape) {
        IHorizontalFacing stairs = (IHorizontalFacing)Block.SpruceStairs;
        return ((IStairShaped)stairs.WithFacing(facing)).WithShape(shape).StateId;
    }
}
