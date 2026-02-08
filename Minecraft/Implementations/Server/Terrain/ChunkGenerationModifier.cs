using Minecraft.Data.Blocks;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain;

/// <summary>
/// A modifier that modifies blocks within a single chunk.
/// </summary>
internal class ChunkGenerationModifier : IGenerationModifier {
    private readonly ChunkData _chunk;
    private readonly int _chunkAbsoluteX;
    private readonly int _chunkAbsoluteZ;
    private readonly int _minY;
    private readonly int _maxY;

    public ChunkGenerationModifier(ChunkData chunk, int minY) {
        _chunk = chunk;
        _chunkAbsoluteX = chunk.ChunkX * ChunkSection.Size;
        _chunkAbsoluteZ = chunk.ChunkZ * ChunkSection.Size;
        _minY = minY;
        _maxY = minY + chunk.WorldHeight;
    }

    public void SetBlock(Vec3<int> position, IBlock block) {
        // Check if the position is within this chunk
        if (!IsInChunk(position)) {
            return;
        }

        // Convert to chunk-local coordinates using bitwise AND (ChunkSection.Size is 16, a power of 2)
        int localX = position.X & (ChunkSection.Size - 1);
        int localZ = position.Z & (ChunkSection.Size - 1);
        int localY = position.Y - _minY;

        if (localY < 0 || localY >= _chunk.WorldHeight) {
            return;
        }

        _chunk.SetBlock(localX, localY, localZ, block.StateId);
    }

    public void Fill(Vec3<int> start, Vec3<int> end, IBlock block) {
        // Clamp to chunk boundaries
        int startX = Math.Max(start.X, _chunkAbsoluteX);
        int startZ = Math.Max(start.Z, _chunkAbsoluteZ);
        int startY = Math.Max(start.Y, _minY);

        int endX = Math.Min(end.X, _chunkAbsoluteX + ChunkSection.Size);
        int endZ = Math.Min(end.Z, _chunkAbsoluteZ + ChunkSection.Size);
        int endY = Math.Min(end.Y, _maxY);

        for (int x = startX; x < endX; x++) {
            for (int y = startY; y < endY; y++) {
                for (int z = startZ; z < endZ; z++) {
                    SetBlock(new Vec3<int>(x, y, z), block);
                }
            }
        }
    }

    public void FillHeight(int minY, int maxY, IBlock block) {
        Fill(
            new Vec3<int>(_chunkAbsoluteX, minY, _chunkAbsoluteZ),
            new Vec3<int>(_chunkAbsoluteX + ChunkSection.Size, maxY, _chunkAbsoluteZ + ChunkSection.Size),
            block
        );
    }

    private bool IsInChunk(Vec3<int> position) {
        int localX = position.X - _chunkAbsoluteX;
        int localZ = position.Z - _chunkAbsoluteZ;
        return localX >= 0 && localX < ChunkSection.Size &&
               localZ >= 0 && localZ < ChunkSection.Size;
    }
}
