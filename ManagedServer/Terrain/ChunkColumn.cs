using System.Buffers;
using ManagedServer.Terrain.Material;

namespace ManagedServer.Terrain;

/// <summary>
/// The chunk being generated, held as a flat array so it can be read back.
/// </summary>
/// <remarks>
/// The generation API writes into a staging buffer that a generator cannot read, and the surface pass
/// is the one part of terrain generation that has to read what the noise pass wrote: it walks each
/// column top down counting how deep into stone and how far under water it is. So this is the scratch
/// space that pass needs, committed through the API once it is finished.
/// <p/>
/// Laid out <b>column major</b>, x then z then y, the opposite of the generation API's own buffer.
/// That is deliberate: a whole column is contiguous, so committing one is a single
/// <c>SetColumnStates</c> over a span and the surface walk down a column is a linear scan.
/// <p/>
/// The heightmap is maintained as blocks are written, since it is vanilla's <c>WORLD_SURFACE_WG</c>
/// and both the surface builder and the badlands extension read it back mid pass.
/// </remarks>
public sealed class ChunkColumn : IMaterialColumn, IColumnStates {
    private readonly int _minY;
    private readonly int _maxY;
    private readonly uint _airState;
    private readonly int _height;

    /// <summary>
    /// Pooled: a world 384 tall needs 384KB here, which is over the large object heap threshold, so a
    /// fresh one per chunk is a gen2 collection every few hundred chunks.
    /// </summary>
    private uint[] _states;

    /// <summary>One above the highest non air block of each column, vanilla's <c>WORLD_SURFACE_WG</c>.</summary>
    private readonly int[] _heights = new int[16 * 16];

    private int _columnX;
    private int _columnZ;

    public ChunkColumn(int minY, int maxY, uint airState) {
        _minY = minY;
        _maxY = maxY;
        _airState = airState;
        _height = maxY - minY;

        // Always filled rather than only when air is not state zero: a rented array carries whatever
        // the last chunk left in it.
        _states = ArrayPool<uint>.Shared.Rent(16 * 16 * _height);
        _states.AsSpan(0, 16 * 16 * _height).Fill(airState);

        Array.Fill(_heights, minY);
    }

    /// <summary>
    /// Hands the buffer back. Called once the chunk has been committed, and the column is unusable
    /// afterwards.
    /// </summary>
    public void Release() {
        if (_states.Length == 0) {
            return;
        }

        ArrayPool<uint>.Shared.Return(_states);

        // Emptied rather than nulled so a read after the release is an index out of range here rather
        // than a null reference somewhere further along, and so the pooled array cannot be written
        // through by a column that outlived its chunk.
        _states = [];
    }

    private int IndexOf(int localX, int localZ, int blockY) {
        return (localX * 16 + localZ) * _height + (blockY - _minY);
    }

    /// <summary>Writes at an arbitrary position, which is what the noise pass does.</summary>
    public void Write(int localX, int blockY, int localZ, uint stateId) {
        if (blockY < _minY || blockY >= _maxY) {
            return;
        }

        _states[IndexOf(localX, localZ, blockY)] = stateId;

        if (stateId != _airState && blockY + 1 > _heights[localX * 16 + localZ]) {
            _heights[localX * 16 + localZ] = blockY + 1;
        }
    }

    /// <summary>
    /// Reads at an arbitrary position, which is what the feature pass does. Outside the world's y
    /// range this is air, matching <see cref="GetBlock"/>.
    /// </summary>
    public uint Read(int localX, int blockY, int localZ) {
        if (blockY < _minY || blockY >= _maxY) {
            return _airState;
        }

        return _states[IndexOf(localX, localZ, blockY)];
    }

    /// <summary>
    /// One past the highest non air block of a column, which is where the feature pass primes its own
    /// heightmaps from rather than scanning the whole world height.
    /// </summary>
    /// <remarks>
    /// The stored number only ever grows, so this is an upper bound rather than the answer. That is
    /// exactly what a scan downwards wants.
    /// </remarks>
    public int HighestWritten(int localX, int localZ) {
        return _heights[localX * 16 + localZ];
    }

    /// <summary>A whole column bottom to top, for handing to the generation API.</summary>
    public ReadOnlySpan<uint> Span(int localX, int localZ) {
        return _states.AsSpan((localX * 16 + localZ) * _height, _height);
    }

    /// <summary>
    /// Replaces a whole column, for a chunk whose terrain was computed once and kept.
    /// </summary>
    /// <remarks>
    /// The height comes in with the states rather than being recomputed: the stored number is an upper
    /// bound that only ever grows, so the one the terrain pass left is the one to carry.
    /// </remarks>
    public void FillColumn(int localX, int localZ, ReadOnlySpan<uint> states, int highest) {
        states[.._height].CopyTo(_states.AsSpan((localX * 16 + localZ) * _height, _height));
        _heights[localX * 16 + localZ] = highest;
    }

    /// <summary>
    /// The top block of the highest section holding anything, <c>getHighestFilledSectionIndex</c> as
    /// a y, or one below the world when nothing has been written. Read straight after the fill, where
    /// the stored heights are exact.
    /// </summary>
    public int HighestFilledSectionTopY() {
        int highest = _minY;
        foreach (int height in _heights) {
            highest = Math.Max(highest, height);
        }

        if (highest <= _minY) {
            return _minY - 1;
        }

        return ((highest - 1) >> 4 << 4) + 15;
    }

    // --- IMaterialColumn -----------------------------------------------------

    public void SetColumn(int blockX, int blockZ) {
        _columnX = blockX & 15;
        _columnZ = blockZ & 15;
    }

    public uint GetBlock(int blockY) {
        if (blockY < _minY || blockY >= _maxY) {
            return _airState;
        }

        return _states[IndexOf(_columnX, _columnZ, blockY)];
    }

    public void SetBlock(int blockY, uint stateId) {
        // Silently ignored outside the world, as vanilla's block column is: the material rules run over
        // a height range that can reach past the build limit.
        Write(_columnX, blockY, _columnZ, stateId);
    }

    /// <summary>
    /// Not simply the stored height: a rule that replaced the top block with air lowers the surface,
    /// and the stored value only ever grows. Vanilla's heightmap rescans for the same reason.
    /// </summary>
    public int GetGenerationHeight(int localX, int localZ) {
        int height = _heights[localX * 16 + localZ];

        while (height > _minY && _states[IndexOf(localX, localZ, height - 1)] == _airState) {
            height--;
        }

        _heights[localX * 16 + localZ] = height;
        return height - 1;
    }
}
