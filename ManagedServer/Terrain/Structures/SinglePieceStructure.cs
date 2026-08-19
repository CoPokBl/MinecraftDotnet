using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>SinglePieceStructure</c>: a structure that is one piece sitting on the ground, built at the
/// centre of its source chunk.
/// </summary>
/// <remarks>
/// The footprint is given rather than read off the piece, because the sea level test happens
/// <b>before</b> the piece is built: a temple whose lowest corner is under water declines without
/// laying anything out. Note that the test is the <b>lowest</b> of the four corners, so a temple half
/// on a beach is refused rather than half drowned.
/// <p/>
/// The swamp hut is deliberately not one of these despite being a single piece: it has no sea level
/// test upstream, which is what lets it stand in the water on its stilts.
/// </remarks>
public abstract class SinglePieceStructure(
    SinglePieceStructure.PieceConstructor constructor,
    int width,
    int depth,
    Structure.StructureSettings settings) : Structure(settings) {

    /// <summary>Builds the piece at a source chunk's minimum corner.</summary>
    public delegate StructurePiece PieceConstructor(RandomSource random, int west, int north);

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        if (LowestY(context, width, depth) < context.SeaLevel) {
            return null;
        }

        return OnTopOfChunkCenter(context, HeightmapType.WorldSurfaceWorldgen, builder =>
            builder.AddPiece(constructor(context.Random, context.ChunkX << 4, context.ChunkZ << 4)));
    }
}
