using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Server.Terrain.Providers;

/// <summary>
/// A provider written as one question per position: what block is at this coordinate?
/// </summary>
/// <remarks>
/// The simplest thing that works, and the slowest way in: it asks about every position in the chunk
/// whether or not the answer varies, which for a 384 high world is 98,304 calls to produce a floor
/// four blocks thick.
/// <p/>
/// <b>New generators should implement <see cref="IGenerator"/> and go through
/// <see cref="GeneratorTerrainProvider"/></b>, where a fill is a palette write rather than a loop, a
/// column can be handed over whole, and coordinates are game y rather than protocol y.
/// <p/>
/// It stays on protocol y because a good deal of the test suite is written against it and encodes
/// floors at particular protocol heights.
/// </remarks>
public abstract class PerBlockTerrainProvider : ITerrainProvider, IGenerator {
    private readonly GeneratorTerrainProvider _inner;

    protected PerBlockTerrainProvider(MinecraftRegistry? registry = null) {
        _inner = new GeneratorTerrainProvider(this, registry);
    }

    /// <summary>
    /// The block at a position. <paramref name="x"/> and <paramref name="z"/> are absolute;
    /// <paramref name="y"/> is <b>protocol</b> y, counting up from the bottom of the world rather than
    /// from zero.
    /// </summary>
    public abstract uint GetBlock(int x, int y, int z);

    public void Generate(IGenerationUnit unit) {
        int minY = unit.MinY;
        unit.Modifier.SetAllStates((x, y, z) => GetBlock(x, y - minY, z));
    }

    public void GetChunk(ref ChunkData chunk) {
        _inner.GetChunk(ref chunk);
    }

    public void Attach(ITerrainHost host) {
        _inner.Attach(host);
    }
}
