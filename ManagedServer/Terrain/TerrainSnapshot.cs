namespace ManagedServer.Terrain;

/// <summary>Something a column of terrain can be read out of, whichever form it is held in.</summary>
public interface IColumnStates {
    uint Read(int localX, int blockY, int localZ);

    /// <summary>One past the highest non air block of a column, as an upper bound to scan down from.</summary>
    int HighestWritten(int localX, int localZ);
}

/// <summary>
/// A chunk's terrain as the carvers left it, held compactly so it can be kept for the neighbours that
/// read it.
/// </summary>
/// <remarks>
/// A chunk decorates through a region spanning the three by three around it, so a feature judges a
/// neighbouring column against the terrain that is really there. What it has to see is the neighbour's
/// <b>post carver, pre decoration</b> state, which a chunk holds between those two passes and nowhere
/// else: a chunk read back out of the world has been decorated as well.
/// <p/>
/// Compact because the point of it is keeping several hundred: a column of 384 blocks holds a handful
/// of distinct states after carving, so a byte index into a per chunk palette costs a quarter of what
/// the raw states do, and a chunk somehow holding more than 256 of them falls back to the raw form
/// rather than failing. Reads are rare next to that, since a feature reads its own chunk tens of
/// thousands of times and a neighbour a few hundred, all within a few blocks of the border.
/// </remarks>
public sealed class TerrainSnapshot : IColumnStates {
    private readonly int _minY;
    private readonly int _height;
    private readonly uint _airState;

    /// <summary>x then z then y, the order <see cref="ChunkColumn"/> stores.</summary>
    private readonly byte[]? _indices;
    private readonly uint[]? _palette;

    /// <summary>The raw states, for a chunk with more than 256 distinct ones.</summary>
    private readonly uint[]? _raw;

    private readonly int[] _highest;

    private TerrainSnapshot(int minY, int height, uint airState, byte[]? indices, uint[]? palette,
        uint[]? raw, int[] highest) {

        _minY = minY;
        _height = height;
        _airState = airState;
        _indices = indices;
        _palette = palette;
        _raw = raw;
        _highest = highest;
    }

    /// <summary>How much this is holding, which is what the cache is sized by.</summary>
    public int Bytes => (_indices?.Length ?? 0) + ((_raw?.Length ?? 0) * 4) + ((_palette?.Length ?? 0) * 4)
        + (_highest.Length * 4);

    public static TerrainSnapshot Of(ChunkColumn column, int minY, int height, uint airState) {
        int cells = 16 * 16 * height;
        int[] highest = new int[256];

        Dictionary<uint, byte> indexOf = [];
        List<uint> palette = [];
        byte[] indices = new byte[cells];
        uint[]? raw = null;

        int at = 0;

        // Terrain is layered, so a cell almost always repeats the one below it. Keeping the last answer
        // turns the common case into a comparison instead of a hash of every one of the 98,304 cells.
        uint lastState = 0;
        byte lastIndex = 0;
        bool haveLast = false;

        for (int localX = 0; localX < 16; localX++) {
            for (int localZ = 0; localZ < 16; localZ++) {
                highest[(localX << 4) | localZ] = column.HighestWritten(localX, localZ);

                ReadOnlySpan<uint> states = column.Span(localX, localZ);

                for (int i = 0; i < states.Length; i++, at++) {
                    if (raw is not null) {
                        raw[at] = states[i];
                        continue;
                    }

                    if (haveLast && states[i] == lastState) {
                        indices[at] = lastIndex;
                        continue;
                    }

                    if (indexOf.TryGetValue(states[i], out byte index)) {
                        indices[at] = index;
                        lastState = states[i];
                        lastIndex = index;
                        haveLast = true;
                        continue;
                    }

                    if (palette.Count == 256) {
                        // Past what a byte can name, so the whole chunk goes out raw. Nothing in a
                        // carved chunk gets near this, and the alternative is a wider index on every
                        // chunk to cover one that does not happen.
                        raw = new uint[cells];
                        for (int back = 0; back < at; back++) {
                            raw[back] = palette[indices[back]];
                        }

                        raw[at] = states[i];
                        continue;
                    }

                    index = (byte)palette.Count;
                    palette.Add(states[i]);
                    indexOf[states[i]] = index;
                    indices[at] = index;
                    lastState = states[i];
                    lastIndex = index;
                    haveLast = true;
                }
            }
        }

        return raw is not null
            ? new TerrainSnapshot(minY, height, airState, null, null, raw, highest)
            : new TerrainSnapshot(minY, height, airState, indices, palette.ToArray(), null, highest);
    }

    public uint Read(int localX, int blockY, int localZ) {
        if (blockY < _minY || blockY >= _minY + _height) {
            return _airState;
        }

        int at = (((localX * 16) + localZ) * _height) + (blockY - _minY);
        return _raw is not null ? _raw[at] : _palette![_indices![at]];
    }

    public int HighestWritten(int localX, int localZ) => _highest[(localX << 4) | localZ];

    /// <summary>Puts the terrain back into a column, which is what a chunk generating from a hit does.</summary>
    public void RestoreInto(ChunkColumn column) {
        uint[] scratch = new uint[_height];

        for (int localX = 0; localX < 16; localX++) {
            for (int localZ = 0; localZ < 16; localZ++) {
                int at = ((localX * 16) + localZ) * _height;

                if (_raw is not null) {
                    _raw.AsSpan(at, _height).CopyTo(scratch);
                } else {
                    for (int i = 0; i < _height; i++) {
                        scratch[i] = _palette![_indices![at + i]];
                    }
                }

                column.FillColumn(localX, localZ, scratch, _highest[(localX << 4) | localZ]);
            }
        }
    }
}
