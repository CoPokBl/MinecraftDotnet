using System.Buffers;
using System.Numerics;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using NBT;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// What one section of a unit is written into before it becomes a <see cref="ChunkSection"/>.
/// </summary>
/// <remarks>
/// Generation stages here rather than writing into the section, because a <see cref="Palette"/> is
/// immutable once built, which is what lets <see cref="ChunkSection.Clone"/> share one and makes
/// snapshotting a chunk per send cost nothing. Mutable palettes would trade this buffer for a lock on
/// every send, so <b>there must never be a <c>Palette.Set</c></b>.
/// <p/>
/// The buffer is flat in y then z then x, the order <see cref="IndirectPalette.Blocks"/> stores and
/// <see cref="ChunkSection.FillFlatStateIds"/> reads, so committing is one linear pass and a
/// <c>Span</c> loop over it has its bounds checks elided.
/// <p/>
/// A section holding one value allocates no buffer, and materialises only when something writes a
/// different value. That is what makes an air section and the middle of a
/// <see cref="IUnitModifier.FillHeightState"/> free.
/// </remarks>
internal sealed class GenerationSection {
    public const int Volume = ChunkSection.Size * ChunkSection.Size * ChunkSection.Size;
    public const int BiomeVolume = ChunkSection.BiomeDimension * ChunkSection.BiomeDimension
        * ChunkSection.BiomeDimension;

    private const int WrittenWords = Volume / 64;

    /// <summary>
    /// Whether this is a fork's overlay rather than a section of its own. A sparse section has no
    /// uniform value and tracks which positions it wrote, so committing it leaves everything else
    /// alone.
    /// </summary>
    private readonly bool _sparse;

    private uint _uniformBlock;
    private uint[]? _blocks;
    private bool _blocksTouched;

    /// <summary>
    /// One bit per position, for a fork. Keeps "wrote air" and "wrote nothing" apart without the
    /// <c>stateId + 1</c> offset every read site would have to remember, and scans a word at a time so
    /// an empty stretch costs nothing.
    /// </summary>
    private ulong[]? _written;

    private uint _uniformBiome;
    private uint[]? _biomes;
    private bool _biomesTouched;

    /// <summary>Keyed by the same flat index the blocks are.</summary>
    private Dictionary<int, (IBlockEntityType Type, INbtTag Data)>? _blockEntities;

    public GenerationSection(bool sparse = false) {
        _sparse = sparse;
    }

    /// <summary>Whether anything was written here at all, blocks or biomes or a block entity.</summary>
    public bool Touched => _blocksTouched || _biomesTouched || _blockEntities is { Count: > 0 };

    /// <summary>The flat index of a position local to this section.</summary>
    public static int Index(int x, int y, int z) => (y << 8) | (z << 4) | x;

    // --- writing -----------------------------------------------------------

    public void SetBlock(int x, int y, int z, uint state) {
        int index = Index(x, y, z);

        if (_blocks == null) {
            // Every position already holds this, so there is nothing to allocate. Never true of a
            // fork: what the target already holds is a fact about a chunk this overlay cannot see.
            if (!_sparse && state == _uniformBlock) {
                _blocksTouched = true;
                return;
            }

            Materialise();
        }

        _blocks![index] = state;
        _written?[index >> 6] |= 1UL << (index & 63);
    }

    /// <summary>A range of local y values, <paramref name="fromY"/> inclusive to <paramref name="toY"/>
    /// exclusive, across the whole section.</summary>
    public void SetRange(int fromY, int toY, uint state) {
        if (fromY >= toY) {
            return;
        }

        if (fromY == 0 && toY == ChunkSection.Size) {
            Fill(state);
            return;
        }

        if (_blocks == null) {
            Materialise();
        }

        int from = fromY << 8;
        int count = (toY - fromY) << 8;
        _blocks!.AsSpan(from, count).Fill(state);

        if (_written != null) {
            for (int i = from; i < from + count; i++) {
                _written[i >> 6] |= 1UL << (i & 63);
            }
        }
    }

    /// <summary>The whole section, in constant time when it is not a fork's overlay.</summary>
    public void Fill(uint state) {
        _blocksTouched = true;

        if (_sparse) {
            if (_blocks == null) {
                Materialise();
            }
            _blocks!.AsSpan(0, Volume).Fill(state);
            Array.Fill(_written!, ulong.MaxValue);
            return;
        }

        ReleaseBlocks();
        _uniformBlock = state;
    }

    public void SetColumn(int x, int z, int fromY, ReadOnlySpan<uint> states) {
        if (states.IsEmpty) {
            return;
        }

        if (_blocks == null) {
            Materialise();
        }

        for (int i = 0; i < states.Length; i++) {
            int index = Index(x, fromY + i, z);
            _blocks![index] = states[i];
            _written?[index >> 6] |= 1UL << (index & 63);
        }
    }

    /// <summary>
    /// The whole section from a supplier taking section local coordinates. Here rather than in the
    /// unit so the loop writes into the buffer directly, instead of through a setter that re-checks
    /// whether the buffer exists on every position.
    /// </summary>
    public void SetAllLocal(Func<int, int, int, uint> supplier) {
        if (_blocks == null) {
            Materialise();
        }

        uint[] blocks = _blocks!;
        int index = 0;
        for (int y = 0; y < ChunkSection.Size; y++) {
            for (int z = 0; z < ChunkSection.Size; z++) {
                for (int x = 0; x < ChunkSection.Size; x++) {
                    blocks[index++] = supplier(x, y, z);
                }
            }
        }

        if (_written != null) {
            Array.Fill(_written, ulong.MaxValue);
        }
    }

    public void SetBiome(int x, int y, int z, uint biomeId) {
        RequireDense("biomes");

        if (_biomes == null) {
            if (_biomesTouched && biomeId == _uniformBiome) {
                return;
            }
            if (!_biomesTouched && biomeId == _uniformBiome) {
                _biomesTouched = true;
                return;
            }

            _biomes = new uint[BiomeVolume];
            Array.Fill(_biomes, _uniformBiome);
            _biomesTouched = true;
        }

        _biomes[x + ChunkSection.BiomeDimension*z + ChunkSection.BiomeDimension*ChunkSection.BiomeDimension*y]
            = biomeId;
    }

    public void FillBiome(uint biomeId) {
        RequireDense("biomes");
        _biomes = null;
        _uniformBiome = biomeId;
        _biomesTouched = true;
    }

    public void SetBlockEntity(int x, int y, int z, IBlockEntityType type, INbtTag data) {
        RequireDense("block entities");
        _blockEntities ??= [];
        _blockEntities[Index(x, y, z)] = (type, data);
    }

    // --- committing --------------------------------------------------------

    /// <summary>
    /// The section becomes exactly what this holds. For anything a generator did not touch, the
    /// section is left as it was, which for a freshly built chunk is air.
    /// </summary>
    public void CommitTo(ChunkSection section, long stateCount, long biomeCount) {
        if (_blocksTouched) {
            if (_blocks == null) {
                section.Fill(_uniformBlock);
            } else {
                section.Palette = PaletteBuilder.FromFlat(_blocks.AsSpan(0, Volume), ChunkSection.Size,
                    ChunkSection.BlocksMaxBpe, ChunkSection.BlocksMinBpe, stateCount);
            }
        }

        if (_biomesTouched) {
            if (_biomes == null) {
                section.FillBiomes(_uniformBiome);
            } else {
                section.BiomesPalette = PaletteBuilder.FromFlat(_biomes, ChunkSection.BiomeDimension,
                    ChunkSection.BiomesMaxBpe, ChunkSection.BiomesMinBpe, biomeCount);
            }
        }
    }

    /// <summary>
    /// Overlays only the positions this wrote onto a section that already has contents, which is what
    /// a fork applying to a neighbour means.
    /// </summary>
    /// <remarks>
    /// Releases the overlay's buffer on the way out: it is applied exactly once, and may be parked for
    /// a long time first waiting for a chunk nobody has walked into.
    /// </remarks>
    public void MergeInto(ChunkSection section, long stateCount) {
        if (_written == null || _blocks == null) {
            return;
        }

        uint[] merged = ArrayPool<uint>.Shared.Rent(Volume);
        try {
            Span<uint> span = merged.AsSpan(0, Volume);
            section.FillFlatStateIds(span);

            for (int word = 0; word < WrittenWords; word++) {
                ulong bits = _written[word];
                while (bits != 0) {
                    int bit = BitOperations.TrailingZeroCount(bits);
                    bits &= bits - 1;

                    int index = (word << 6) | bit;
                    span[index] = _blocks[index];
                }
            }

            section.Palette = PaletteBuilder.FromFlat(span, ChunkSection.Size, ChunkSection.BlocksMaxBpe,
                ChunkSection.BlocksMinBpe, stateCount);
        } finally {
            ArrayPool<uint>.Shared.Return(merged);
            Release();
        }
    }

    /// <summary>
    /// Every position this overlay wrote, section local, for a caller that wants the blocks rather
    /// than a merged section. Leaves the buffer alone, unlike <see cref="MergeInto"/>.
    /// </summary>
    public void ForEachWrite(Action<int, int, int, uint> write) {
        if (_written == null || _blocks == null) {
            return;
        }

        for (int word = 0; word < WrittenWords; word++) {
            ulong bits = _written[word];
            while (bits != 0) {
                int bit = BitOperations.TrailingZeroCount(bits);
                bits &= bits - 1;

                int index = (word << 6) | bit;
                write(index & 15, index >> 8, (index >> 4) & 15, _blocks[index]);
            }
        }
    }

    /// <summary>The block entities written here, as flat index to payload. Empty for most sections.</summary>
    public IEnumerable<KeyValuePair<int, (IBlockEntityType Type, INbtTag Data)>> BlockEntities =>
        _blockEntities ?? Enumerable.Empty<KeyValuePair<int, (IBlockEntityType, INbtTag)>>();

    /// <summary>Whether this fork overlay wrote anything, so an empty one is not posted anywhere.</summary>
    public bool HasWrites {
        get {
            if (_written == null) {
                return false;
            }

            foreach (ulong word in _written) {
                if (word != 0) {
                    return true;
                }
            }

            return false;
        }
    }

    public void Release() {
        ReleaseBlocks();
        _blocksTouched = false;
        _written = null;
    }

    // --- internals ---------------------------------------------------------

    private void Materialise() {
        // 16 KB, comfortably under the large object heap threshold, but 24 of them per chunk across a
        // few hundred chunks on a join is worth not handing to the collector.
        _blocks = ArrayPool<uint>.Shared.Rent(Volume);
        Span<uint> span = _blocks.AsSpan(0, Volume);

        if (_sparse) {
            span.Clear();
            _written = new ulong[WrittenWords];
        } else {
            span.Fill(_uniformBlock);
        }

        _blocksTouched = true;
    }

    private void ReleaseBlocks() {
        if (_blocks != null) {
            ArrayPool<uint>.Shared.Return(_blocks);
            _blocks = null;
        }
    }

    private void RequireDense(string what) {
        if (_sparse) {
            throw new InvalidOperationException(
                $"A fork carries blocks only, so it cannot set {what}: it is a sparse overlay onto a " +
                "chunk it does not own, and there is no such thing as an unwritten one.");
        }
    }
}
