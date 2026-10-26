using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// Turns a chunk into bytes and back. One half of storage; <see cref="IChunkBlobStore"/> is the other,
/// and the two are separate because format and location are independent choices: Anvil chunks in
/// region files, Anvil chunks in a database, and Polar chunks in one bundle are all the same two
/// pieces paired differently.
/// </summary>
/// <remarks>
/// <b>Work per palette entry, never per block.</b> A codec is handed the whole chunk so it can read
/// <see cref="ChunkSection.UniformState"/> and the section's palette directly and convert the handful
/// of distinct states rather than all 4096 positions. A codec that walks positions and converts each
/// one costs roughly thirty times what one that does not costs, which over a world save is the
/// difference between a stutter and a minute.
/// <p/>
/// Called from several threads at once, on chunks whose palettes are immutable. A codec holding
/// mutable state has to guard it; a cache keyed by state id does not, since the mapping is a pure
/// function of the registry.
/// </remarks>
public interface IChunkCodec {
    /// <summary>What this codec writes, so a store can refuse bytes another one produced.</summary>
    public Identifier Format { get; }

    public void Encode(ChunkData chunk, DataWriter writer);

    public ChunkData Decode(DataReader reader, ChunkCodecContext context);
}
