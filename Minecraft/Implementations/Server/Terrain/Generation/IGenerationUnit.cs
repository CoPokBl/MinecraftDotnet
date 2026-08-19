using Minecraft.Registry;
using Minecraft.Schemas.Vec;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// An area a generator has been asked to fill.
/// </summary>
/// <remarks>
/// <b>Every coordinate on this type and on its <see cref="Modifier"/> is absolute game y</b>, negative
/// included, and never the protocol y a <c>ChunkData</c> is indexed by. A generator therefore needs no
/// <c>MinY</c> of its own, and confusing the two puts terrain a world's depth away from where it was
/// asked for, which looks exactly like the generator not having run.
/// <p/>
/// A unit's size is always a multiple of 16 on every axis, so it is made of whole sections.
/// </remarks>
public interface IGenerationUnit {
    IUnitModifier Modifier { get; }

    /// <summary>The unit's size in blocks, a multiple of 16 on every axis.</summary>
    Vec3<int> Size { get; }

    /// <summary>The lowest corner, inclusive.</summary>
    Vec3<int> AbsoluteStart { get; }

    /// <summary>One past the highest corner, exclusive.</summary>
    Vec3<int> AbsoluteEnd { get; }

    /// <summary>The world's lowest block y, its dimension's min y.</summary>
    int MinY { get; }

    /// <summary>One past the world's highest block y.</summary>
    int MaxY { get; }

    MinecraftRegistry Registry { get; }

    /// <summary>
    /// The smallest units this one is made of, one per section, so a generator can work a section at
    /// a time and use the relative setters. A unit that is already one section returns itself.
    /// </summary>
    IReadOnlyList<IGenerationUnit> Subdivide();

    /// <summary>
    /// An area outside this unit, written wherever it belongs: into this chunk if it lands here, into
    /// the target chunk if that is already loaded, and parked until the target is generated otherwise.
    /// Snapped outwards to whole sections.
    /// </summary>
    /// <remarks>
    /// What a feature spanning a chunk border needs, since a generator is only ever handed one chunk.
    /// A fork is <b>sparse</b>: it carries only the positions actually written, so the blocks around
    /// them are left alone rather than being overwritten with air.
    /// <p/>
    /// Blocks only. A fork has no sensible "unwritten" biome, so asking one for
    /// <see cref="IUnitModifier.SetBiome(int,int,int,Minecraft.Data.Biomes.IBiome)"/> throws rather
    /// than quietly doing nothing.
    /// </remarks>
    IGenerationUnit Fork(Vec3<int> start, Vec3<int> end);

    /// <summary>
    /// The same, sized from what actually gets written rather than declared up front. What a feature
    /// that does not know its own extent, a tree or an ore vein, wants.
    /// </summary>
    void Fork(Action<IBlockSetter> build);

    /// <summary>
    /// Replays the blocks a neighbouring chunk forked into this one before it was generated, and
    /// hands responsibility for them over. Returns whether there were any.
    /// </summary>
    /// <remarks>
    /// <b>Where a generator calls this is where those blocks land in its own order of passes</b>, and
    /// a generator with stages has to place it deliberately. Vanilla's answer is the chunk status
    /// boundary the writer crossed: a neighbour decorating writes into a chunk that has finished its
    /// carvers and not started its features, so those blocks are there to be read, overwritten or
    /// built on by everything this chunk's own decoration then does.
    /// <p/>
    /// A generator that never calls it loses nothing: what is left is merged into the finished chunk
    /// instead, which is where a fork arriving after generation lands anyway.
    /// <p/>
    /// Reading is destructive, so calling it twice replays nothing the second time, and calling it on
    /// a forked unit rather than on the chunk's own reads the chunk's.
    /// </remarks>
    bool ReadForkedWrites(ForkedBlock into);
}

/// <summary>A block a neighbouring chunk forked in, in absolute coordinates.</summary>
public delegate void ForkedBlock(int x, int y, int z, uint stateId);
