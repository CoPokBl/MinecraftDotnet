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
/// generated yet. So the box is built at a placeholder height and dropped to the real one the first
/// time the piece is placed, and kept: a start is shared by every chunk it reaches, so the box moves
/// once rather than per chunk. Only the desert pyramid ever reaches past its source chunk, and it
/// decides in <see cref="StructurePiece.SettleOnce"/> for that reason; a temple or hut fits inside
/// its source chunk, so only that chunk ever places it.
/// <p/>
/// <b><c>decorationparity.sh</c> cannot measure the pyramid's other chunks.</b> The harness lays a
/// start out again for every scene, so its piece is fresh in each and decides from that chunk's own
/// draw and its own share of the footprint, while this one and a real server both decide once. A
/// pyramid across a chunk border reads there as hundreds of differing writes outside its source
/// chunk, and that is neither side being wrong.
/// </remarks>
public abstract class ScatteredFeaturePiece : StructurePiece {
    protected readonly int Width;
    protected readonly int Height;
    protected readonly int Depth;

    /// <summary>The ground height once found, or -1 while the piece is still at its placeholder.</summary>
    private int _heightPosition = -1;

    /// <summary>Held while the height is decided, since neighbouring chunks place a piece at once.</summary>
    private readonly Lock _settle = new();

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
        lock (_settle) {
            return UpdateAverageGroundHeightLocked(level, chunkBox, offset);
        }
    }

    private bool UpdateAverageGroundHeightLocked(IFeatureLevel level, BoundingBox chunkBox, int offset) {
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
        lock (_settle) {
            return UpdateHeightPositionToLowestGroundHeightLocked(level, offset);
        }
    }

    private bool UpdateHeightPositionToLowestGroundHeightLocked(IFeatureLevel level, int offset) {
        if (_heightPosition >= 0) {
            return true;
        }

        // Vanilla's getMaxY() + 1, which is this level's exclusive top.
        int lowest = level.MaxY;

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
