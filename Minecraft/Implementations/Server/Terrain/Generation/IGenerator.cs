namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// Fills an area with blocks and biomes. The unit decides what area; a generator only writes.
/// </summary>
/// <remarks>
/// Wrap one in a <see cref="GeneratorTerrainProvider"/> to give it to a world.
/// <p/>
/// Called on a pool thread, one chunk at a time, and quite possibly for several chunks at once: a
/// player joining asks for a few hundred at once and the chunk store starts a task for each. So an
/// implementation has to be safe to call concurrently with itself, which for the usual shape of a
/// generator (a seed, some noise parameters, no mutable state) it already is. Nothing here runs on
/// the tick thread.
/// </remarks>
public interface IGenerator {
    void Generate(IGenerationUnit unit);
}
