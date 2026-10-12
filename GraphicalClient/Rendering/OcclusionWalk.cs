using ClientLib.World;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>SectionOcclusionGraph.runUpdates</c> without the distant ray check: breadth first from the camera's
/// section, never doubling back along an axis, and leaving a section only through a face that some face it
/// was entered by can see. It runs on flat arrays over the box of sections in range, because a walk visits
/// every one of them up to six times. <see cref="Prepare"/> copies what it reads on the game thread, so
/// <see cref="Run"/> can go on a worker while the last walk's result is drawn.
/// </summary>
internal sealed class OcclusionWalk {
    private SectionRender?[] _sections = [];
    private ulong[] _visibility = [];
    private byte[] _directions = [];
    private byte[] _sources = [];
    private int[] _stamp = [];
    private int[] _queue = [];
    private bool[] _loaded = [];
    private int _stampValue;
    private int _width, _height, _start;

    /// <summary>The sections the last <see cref="Run"/> reached, nearest first.</summary>
    public List<SectionRender> Reachable { get; } = new(8192);

    /// <summary>Copies the camera relative grid of sections, their visibility and which columns are loaded.</summary>
    /// <param name="range">Sections from the camera's column to the edge of the grid.</param>
    public void Prepare(ClientLevel level, Dictionary<long, SectionRender>.ValueCollection sections, Dictionary<long, ulong> visibility, int camX, int camY, int camZ, int range) {
        int width = range * 2 + 1;
        int height = level.SectionCount;
        int columns = width * width;
        int cells = columns * height;
        if (_visibility.Length < cells) {
            _visibility = new ulong[cells];
            _directions = new byte[cells];
            _sources = new byte[cells];
            _stamp = new int[cells];
            _queue = new int[cells];
            _loaded = new bool[columns];
            _sections = new SectionRender?[cells];
        }
        Array.Clear(_sections, 0, cells);
        foreach (SectionRender section in sections) {
            if (Cell(section.X - camX + range, section.Y, section.Z - camZ + range) is int cell) {
                _sections[cell] = section;
            }
        }
        Array.Fill(_visibility, VisibilityGraph.AllVisible, 0, cells);
        foreach ((long key, ulong seen) in visibility) {
            (int x, int y, int z) = WorldRenderer.Unpack(key);
            if (Cell(x - camX + range, y, z - camZ + range) is int cell) {
                _visibility[cell] = seen;
            }
        }
        for (int gz = 0; gz < width; gz++) {
            for (int gx = 0; gx < width; gx++) {
                _loaded[gz * width + gx] = level.HasChunk(camX + gx - range, camZ + gz - range);
            }
        }
        _stampValue++;
        _width = width;
        _height = height;
        _start = (Math.Clamp(camY, 0, height - 1) * width + range) * width + range;

        int? Cell(int gx, int y, int gz) =>
            (uint)gx < (uint)width && (uint)gz < (uint)width && (uint)y < (uint)height ? (y * width + gz) * width + gx : null;
    }

    /// <summary>The flood itself. Reads only what <see cref="Prepare"/> copied.</summary>
    public void Run() {
        Reachable.Clear();
        int width = _width, height = _height, columns = width * width, stamp = _stampValue;
        _stamp[_start] = stamp;
        _directions[_start] = 0;
        _sources[_start] = 0;
        int head = 0, tail = 0;
        _queue[tail++] = _start;

        while (head < tail) {
            int cell = _queue[head++];
            int gx = cell % width, gz = cell / width % width, y = cell / columns;
            if (_sections[cell] is { } found) {
                Reachable.Add(found);
            }
            byte directions = _directions[cell];
            byte sources = _sources[cell];
            ulong visibility = _visibility[cell];

            for (int d = 0; d < 6; d++) {
                if ((directions & (1 << (d ^ 1))) != 0) {
                    continue;
                }
                if (sources != 0) {
                    bool seen = false;
                    for (int i = 0; i < 6 && !seen; i++) {
                        seen = (sources & (1 << i)) != 0 && (visibility & (1UL << ((i ^ 1) * 6 + d))) != 0;
                    }
                    if (!seen) {
                        continue;
                    }
                }
                (int dx, int dy, int dz) = BlockFaces.Steps[d];
                int nx = gx + dx, ny = y + dy, nz = gz + dz;
                if ((uint)ny >= (uint)height || (uint)nx >= (uint)width || (uint)nz >= (uint)width || !_loaded[nz * width + nx]) {
                    continue;
                }
                int neighbour = (ny * width + nz) * width + nx;
                if (_stamp[neighbour] == stamp) {
                    _sources[neighbour] |= (byte)(1 << d);
                    continue;
                }
                _stamp[neighbour] = stamp;
                _directions[neighbour] = (byte)(directions | 1 << d);
                _sources[neighbour] = (byte)(1 << d);
                _queue[tail++] = neighbour;
            }
        }
    }
}
