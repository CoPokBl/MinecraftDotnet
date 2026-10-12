using GraphicalClient.Assets;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>VisGraph.resolve</c>: flood fill the cells of a section that are not solid, and record which pairs of
/// faces each connected pocket touches, bit <c>from * 6 + to</c> in <see cref="Face"/> order. The renderer
/// walks outward from the camera only through pairs that connect, which is what hides caves. Holds scratch
/// buffers, so one per mesher.
/// </summary>
internal sealed class VisibilityGraph {
    /// <summary>Every face sees every other, what an empty or barely filled section answers.</summary>
    public const ulong AllVisible = (1UL << 36) - 1;

    private readonly bool[] _visited = new bool[4096];
    private readonly int[] _queue = new int[4096];

    public ulong Resolve(SectionSnapshot snapshot, BlockModel[] models) {
        int opaque = 0;
        for (int i = 0; i < 4096; i++) {
            BlockModel model = models[snapshot.States[SectionSnapshot.Index(i & 15, i >> 8, (i >> 4) & 15)]];
            bool solid = model.OccludesFaces == 0x3F && model.Layer == RenderLayer.Solid && model.FullCube;
            _visited[i] = solid;
            opaque += solid ? 1 : 0;
        }
        if (opaque < 256) {
            return AllVisible;
        }
        if (opaque == 4096) {
            return 0;
        }

        ulong result = 0;
        for (int start = 0; start < 4096; start++) {
            int sx = start & 15, sz = (start >> 4) & 15, sy = start >> 8;
            bool edge = sx is 0 or 15 || sy is 0 or 15 || sz is 0 or 15;
            if (!edge || _visited[start]) {
                continue;
            }
            int faces = 0;
            int head = 0, tail = 0;
            _queue[tail++] = start;
            _visited[start] = true;
            while (head < tail) {
                int index = _queue[head++];
                int x = index & 15, z = (index >> 4) & 15, y = index >> 8;
                if (y == 0) faces |= 1 << (int)Face.Down;
                if (y == 15) faces |= 1 << (int)Face.Up;
                if (z == 0) faces |= 1 << (int)Face.North;
                if (z == 15) faces |= 1 << (int)Face.South;
                if (x == 0) faces |= 1 << (int)Face.West;
                if (x == 15) faces |= 1 << (int)Face.East;
                if (y > 0) Visit(index - 256, ref tail);
                if (y < 15) Visit(index + 256, ref tail);
                if (z > 0) Visit(index - 16, ref tail);
                if (z < 15) Visit(index + 16, ref tail);
                if (x > 0) Visit(index - 1, ref tail);
                if (x < 15) Visit(index + 1, ref tail);
            }
            for (int a = 0; a < 6; a++) {
                if ((faces & (1 << a)) != 0) {
                    result |= (ulong)faces << (a * 6);
                }
            }
        }
        return result;
    }

    private void Visit(int index, ref int tail) {
        if (!_visited[index]) {
            _visited[index] = true;
            _queue[tail++] = index;
        }
    }
}
