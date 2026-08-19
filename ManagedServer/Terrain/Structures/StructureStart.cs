using ManagedServer.Terrain.Features;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>StructureStart</c>: one instance of a structure, at the source chunk that decided it exists.
/// </summary>
/// <remarks>
/// A start is <b>a pure function of the world seed and its source chunk position</b>, which is what
/// lets the pass recompute one rather than store it. Nothing about a start depends on which chunk is
/// being generated, so two neighbours replaying the same source chunk build the same start and place
/// consistent halves of it.
/// </remarks>
public sealed class StructureStart(Structure structure, int chunkX, int chunkZ,
    PiecesContainer pieces) {
    private BoundingBox? _boundingBox;

    public Structure Structure => structure;

    public int ChunkX => chunkX;

    public int ChunkZ => chunkZ;

    public IReadOnlyList<StructurePiece> Pieces => pieces.Pieces;

    /// <summary>
    /// The box every piece fits in, grown by the terrain adaptation where there is one.
    /// </summary>
    /// <remarks>
    /// Cached because the pass asks for it once per replayed source chunk per chunk generated, which
    /// is the test that rejects almost all of them.
    /// </remarks>
    public BoundingBox BoundingBox {
        get => _boundingBox ??= structure.AdjustBoundingBox(pieces.CalculateBoundingBox());
    }

    /// <summary>
    /// Writes every piece that reaches the chunk, then gives the structure its after-place pass.
    /// </summary>
    /// <remarks>
    /// The reference position is the middle of the <b>first</b> piece at its floor, so it is the same
    /// for every chunk the structure spans however few pieces land in any one of them.
    /// </remarks>
    public void PlaceInChunk(IFeatureLevel level, PlacementContext features, RandomSource random,
        BoundingBox chunkBox, int targetChunkX, int targetChunkZ) {

        if (pieces.Pieces.Count == 0) {
            return;
        }

        BoundingBox first = pieces.Pieces[0].BoundingBox;
        Vec3<int> center = first.Center;
        Vec3<int> reference = new(center.X, first.MinY, center.Z);

        foreach (StructurePiece piece in pieces.Pieces) {
            if (!piece.BoundingBox.Intersects(chunkBox)) {
                continue;
            }

            // A jigsaw piece may hold a feature rather than a template, and the feature pass's own
            // context is the only thing that can run one. Set here rather than carried on the piece
            // from layout, because a start is shared by every chunk that replays it and the context
            // is per chunk.
            if (piece is PoolElementStructurePiece pool) {
                pool.Features = features;
            }

            piece.PostProcess(level, random, chunkBox, targetChunkX, targetChunkZ, reference);
        }

        structure.AfterPlace(level, random, chunkBox, targetChunkX, targetChunkZ, pieces);
    }
}
