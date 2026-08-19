using ManagedServer.Terrain.Features;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>ScatteredFeaturePiece</c>: the base for the small surface structures that are one hut or temple
/// sitting on the ground.
/// </summary>
/// <remarks>
/// Its job is finding the height to sit at, which cannot happen when the piece is built: a structure
/// decides where it is from a source chunk, and the ground it stands on may be in a chunk that is not
/// generated yet. So the box is built at a placeholder height and dropped to the real one by
/// <see cref="UpdateAverageGroundHeight"/> the first time the piece is placed.
/// <p/>
/// <b>The answer is kept on the piece, so the first chunk to place a straddling temple decides where
/// the whole of it sits.</b> That is upstream's arrangement and it is why the box moves once rather
/// than per chunk: a start is stored there and shared by every chunk it reaches, and it is shared here
/// too, by the pass's start cache. It is also the one thing on a start that is not a pure function of
/// the seed and the source chunk, so which chunk gets there first is visible in the result. Vanilla
/// has the same dependence for the same reason, and neither side can be made to agree with a
/// recomputation: <see cref="UpdateAverageGroundHeight"/> reads only the columns inside the chunk
/// being written, and the offset a caller passes is usually drawn per chunk, so a second opinion is a
/// different height rather than the same one confirmed.
/// <p/>
/// <b>That is what <c>decorationparity.sh</c> cannot measure about these pieces.</b> The harness lays
/// a start out again for every scene, so its piece is fresh in each and answers from that chunk's
/// share alone, while this one and a real server both answer once. A desert pyramid across a chunk
/// border reads as hundreds of differing writes there and is neither side being wrong.
/// </remarks>
public abstract class ScatteredFeaturePiece : StructurePiece {
    protected readonly int Width;
    protected readonly int Height;
    protected readonly int Depth;

    /// <summary>The ground height once found, or -1 while the piece is still at its placeholder.</summary>
    private int _heightPosition = -1;

    protected ScatteredFeaturePiece(int west, int floor, int north, int width, int height, int depth,
        Direction direction)
        : base(0, MakeBoundingBox(west, floor, north, direction, width, height, depth)) {

        Width = width;
        Height = height;
        Depth = depth;
        Orientation = direction;
    }

    /// <summary>
    /// Drops the piece to the mean ground height under the part of it inside the chunk, and answers
    /// whether there was any of it there to measure.
    /// </summary>
    protected bool UpdateAverageGroundHeight(IFeatureLevel level, BoundingBox chunkBox, int offset) {
        if (_heightPosition >= 0) {
            return true;
        }

        int total = 0;
        int count = 0;

        for (int z = BoundingBox.MinZ; z <= BoundingBox.MaxZ; z++) {
            for (int x = BoundingBox.MinX; x <= BoundingBox.MaxX; x++) {
                // At a y inside the world, since the test is only about the column being in the
                // chunk. Vanilla uses 64 for the same reason.
                if (!chunkBox.IsInside(x, 64, z)) {
                    continue;
                }

                total += level.GetHeight(HeightmapType.MotionBlockingNoLeaves, x, z);
                count++;
            }
        }

        if (count == 0) {
            return false;
        }

        _heightPosition = total / count;
        BoundingBox.Move(0, _heightPosition - BoundingBox.MinY + offset, 0);
        return true;
    }

    /// <summary>
    /// The same, but taking the lowest ground height over the whole footprint rather than the mean of
    /// the part in this chunk, so a piece on a slope sinks to its lowest corner.
    /// </summary>
    protected bool UpdateHeightPositionToLowestGroundHeight(IFeatureLevel level, int offset) {
        if (_heightPosition >= 0) {
            return true;
        }

        int lowest = level.MaxY + 1;

        for (int z = BoundingBox.MinZ; z <= BoundingBox.MaxZ; z++) {
            for (int x = BoundingBox.MinX; x <= BoundingBox.MaxX; x++) {
                lowest = Math.Min(lowest, level.GetHeight(HeightmapType.MotionBlockingNoLeaves, x, z));
            }
        }

        _heightPosition = lowest;
        BoundingBox.Move(0, _heightPosition - BoundingBox.MinY + offset, 0);
        return true;
    }
}
