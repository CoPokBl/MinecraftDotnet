using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// The geometry a chunk is being decoded into. None of it is recoverable from the bytes: a stored
/// chunk says what is in it, and the world says how tall it is and where its floor sits.
/// </summary>
public readonly record struct ChunkCodecContext {
    public required Vec2<int> Position { get; init; }
    public required int WorldHeight { get; init; }
    public required int MinY { get; init; }

    public ChunkData NewChunk() => new(WorldHeight) {
        ChunkX = Position.X,
        ChunkZ = Position.Y,
        MinY = MinY
    };

    public static ChunkCodecContext Of(ChunkData chunk) => new() {
        Position = new Vec2<int>(chunk.ChunkX, chunk.ChunkZ),
        WorldHeight = chunk.WorldHeight,
        MinY = chunk.MinY
    };
}
