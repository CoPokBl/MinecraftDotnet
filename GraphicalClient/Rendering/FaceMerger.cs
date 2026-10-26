using static GraphicalClient.Rendering.BlockFaces;
using static GraphicalClient.Rendering.SectionMesher;

namespace GraphicalClient.Rendering;

/// <summary>
/// Greedy meshing of a mesher's buckets: coplanar whole block faces that look the same are replaced by
/// rectangles over them, the texture repeating across. Only faces with one light level, occlusion and
/// tint at every corner qualify, so smooth lighting draws exactly what the separate faces would have;
/// open ground, sea floor and the sea's surface are mostly that. A merged edge can meet the corner of
/// a smaller neighbour mid side; the positions are exact in floating point, which keeps the rasteriser
/// from opening a crack there. Holds scratch buffers, so one per mesher.
/// </summary>
internal sealed class FaceMerger {
    /// <summary>
    /// What two whole block faces must share to become one quad: the plane they lie in, everything a
    /// vertex carries, the order their corners were written in, and how the texture lies on them.
    /// </summary>
    private readonly record struct MergeKey(int Axis, ushort Plane, byte Face, byte Flags, ushort Layer, byte Sky, byte Block, uint Colour, int CornerOrder, int Uv);

    private readonly Dictionary<MergeKey, List<int>> _groups = new();
    private readonly Stack<List<int>> _cellLists = new();
    private readonly List<BlockVertex> _merged = new(1024);
    private readonly bool[] _cells = new bool[256];
    private readonly List<(int Key, int Quad)> _sortKeys = [];

    /// <param name="unmerged">Bit per shader pack material whose faces are left as they are.</param>
    public void Merge(List<BlockVertex> bucket, ulong unmerged) {
        if (bucket.Count < 8) {
            return;
        }
        foreach (List<int> cells in _groups.Values) {
            cells.Clear();
            _cellLists.Push(cells);
        }
        _groups.Clear();
        _merged.Clear();

        Span<BlockVertex> quad = stackalloc BlockVertex[4];
        for (int i = 0; i < bucket.Count; i += 4) {
            for (int k = 0; k < 4; k++) {
                quad[k] = bucket[i + k];
            }
            if ((unmerged >> (quad[0].Flags >> MaterialShift) & 1) != 0 || !TryMergeKey(quad, out MergeKey key, out int cell)) {
                for (int k = 0; k < 4; k++) {
                    _merged.Add(quad[k]);
                }
                continue;
            }
            if (!_groups.TryGetValue(key, out List<int>? group)) {
                group = _cellLists.TryPop(out List<int>? pooled) ? pooled : [];
                _groups[key] = group;
            }
            group.Add(cell);
        }

        foreach ((MergeKey key, List<int> cells) in _groups) {
            foreach (int cell in cells) {
                _cells[cell] = true;
            }
            foreach (int first in cells) {
                if (!_cells[first]) {
                    continue;
                }
                int c1 = first & 15, c2 = first >> 4;
                int width = 1;
                while (c1 + width < 16 && _cells[c2 << 4 | (c1 + width)]) {
                    width++;
                }
                int height = 1;
                while (c2 + height < 16 && RowFilled(c1, c2 + height, width)) {
                    height++;
                }
                for (int b = c2; b < c2 + height; b++) {
                    for (int a = c1; a < c1 + width; a++) {
                        _cells[b << 4 | a] = false;
                    }
                }
                EmitMerged(key, c1, c2, width, height);
            }
        }

        bucket.Clear();
        bucket.AddRange(_merged);
    }

    private bool RowFilled(int c1, int c2, int width) {
        for (int a = c1; a < c1 + width; a++) {
            if (!_cells[c2 << 4 | a]) {
                return false;
            }
        }
        return true;
    }

    private static ushort Coordinate(in BlockVertex v, int axis) => axis switch { 0 => v.X, 1 => v.Y, _ => v.Z };

    private static bool TryMergeKey(ReadOnlySpan<BlockVertex> quad, out MergeKey key, out int cell) {
        key = default;
        cell = 0;
        ref readonly BlockVertex v0 = ref quad[0];
        for (int k = 1; k < 4; k++) {
            ref readonly BlockVertex other = ref quad[k];
            if (other.Sky != v0.Sky || other.Block != v0.Block || other.Colour != v0.Colour || other.Layer != v0.Layer || other.Flags != v0.Flags || other.Face != v0.Face) {
                return false;
            }
        }
        int axis = -1;
        for (int a = 0; a < 3 && axis < 0; a++) {
            ushort c = Coordinate(v0, a);
            if (Coordinate(quad[1], a) == c && Coordinate(quad[2], a) == c && Coordinate(quad[3], a) == c) {
                axis = a;
            }
        }
        if (axis < 0) {
            return false;
        }
        int t1 = (axis + 1) % 3, t2 = (axis + 2) % 3;
        int min1 = int.MaxValue, min2 = int.MaxValue;
        for (int k = 0; k < 4; k++) {
            min1 = Math.Min(min1, Coordinate(quad[k], t1));
            min2 = Math.Min(min2, Coordinate(quad[k], t2));
        }
        if (min1 % 1024 != 0 || min2 % 1024 != 0) {
            return false;
        }
        int c1 = min1 / 1024 - 16, c2 = min2 / 1024 - 16;
        if ((uint)c1 > 15 || (uint)c2 > 15) {
            return false;
        }

        // Each corner's place on the face, and the texture coordinate there.
        Span<int> u = stackalloc int[4];
        Span<int> v = stackalloc int[4];
        int seen = 0, order = 0;
        for (int k = 0; k < 4; k++) {
            int s1 = Coordinate(quad[k], t1) - min1, s2 = Coordinate(quad[k], t2) - min2;
            if (s1 is not (0 or 1024) || s2 is not (0 or 1024)) {
                return false;
            }
            int corner = (s1 >> 10) << 1 | s2 >> 10;
            seen |= 1 << corner;
            order |= corner << (k * 2);
            u[corner] = quad[k].U;
            v[corner] = quad[k].V;
        }
        if (seen != 15) {
            return false;
        }
        // The whole texture once, square to the face, however it is turned or mirrored.
        int du1 = u[2] - u[0], dv1 = v[2] - v[0], du2 = u[1] - u[0], dv2 = v[1] - v[0];
        if (u[3] != u[0] + du1 + du2 || v[3] != v[0] + dv1 + dv2) {
            return false;
        }
        if (u[0] is not (0 or UvUnit) || v[0] is not (0 or UvUnit)) {
            return false;
        }
        bool alongU = Math.Abs(du1) == UvUnit && dv1 == 0 && du2 == 0 && Math.Abs(dv2) == UvUnit;
        bool alongV = Math.Abs(dv1) == UvUnit && du1 == 0 && dv2 == 0 && Math.Abs(du2) == UvUnit;
        if (!alongU && !alongV) {
            return false;
        }
        int uv = u[0] / UvUnit | v[0] / UvUnit << 1 | (du1 / UvUnit + 1) << 2 | (dv1 / UvUnit + 1) << 4 | (du2 / UvUnit + 1) << 6 | (dv2 / UvUnit + 1) << 8;

        key = new MergeKey(axis, Coordinate(v0, axis), v0.Face, v0.Flags, v0.Layer, v0.Sky, v0.Block, v0.Colour, order, uv);
        cell = c2 << 4 | c1;
        return true;
    }

    private void EmitMerged(MergeKey key, int c1, int c2, int width, int height) {
        int u0 = (key.Uv & 1) * UvUnit, v0 = (key.Uv >> 1 & 1) * UvUnit;
        int du1 = ((key.Uv >> 2 & 3) - 1) * UvUnit, dv1 = ((key.Uv >> 4 & 3) - 1) * UvUnit;
        int du2 = ((key.Uv >> 6 & 3) - 1) * UvUnit, dv2 = ((key.Uv >> 8 & 3) - 1) * UvUnit;
        int t1 = (key.Axis + 1) % 3, t2 = (key.Axis + 2) % 3;
        // A mirrored texture runs negative across a wide face; the texture repeats, so a whole number of
        // repeats can be added to bring it back into range.
        int shift1 = du1 < 0 || du2 < 0 ? 16 * UvUnit : 0;
        int shift2 = dv1 < 0 || dv2 < 0 ? 16 * UvUnit : 0;
        Span<ushort> position = stackalloc ushort[3];
        for (int k = 0; k < 4; k++) {
            int corner = key.CornerOrder >> (k * 2) & 3;
            int s1 = corner >> 1, s2 = corner & 1;
            position[key.Axis] = key.Plane;
            position[t1] = (ushort)((16 + c1 + s1 * width) * 1024);
            position[t2] = (ushort)((16 + c2 + s2 * height) * 1024);
            _merged.Add(new BlockVertex {
                X = position[0], Y = position[1], Z = position[2],
                Face = key.Face,
                Flags = key.Flags,
                U = (ushort)(u0 + du1 * s1 * width + du2 * s2 * height + shift1),
                V = (ushort)(v0 + dv1 * s1 * width + dv2 * s2 * height + shift2),
                Layer = key.Layer,
                Sky = key.Sky,
                Block = key.Block,
                Colour = key.Colour
            });
        }
    }

    /// <summary>
    /// Orders a translucent bucket furthest first along its facing. A face is only seen from the side
    /// it faces, so of two that overlap on screen the one further back along that axis is behind, as
    /// water is under the ice on it; blended in the other order the ice takes the water's colour.
    /// </summary>
    public void SortBackToFront(List<BlockVertex> bucket, int face) {
        int quads = bucket.Count / 4;
        if (quads < 2) {
            return;
        }
        int axis = Axis(face);
        int sign = (face & 1) != 0 ? 1 : -1;
        _sortKeys.Clear();
        for (int q = 0; q < quads; q++) {
            int sum = 0;
            for (int k = 0; k < 4; k++) {
                sum += Coordinate(bucket[q * 4 + k], axis);
            }
            _sortKeys.Add((sum * sign, q));
        }
        _sortKeys.Sort();
        _merged.Clear();
        foreach ((int _, int q) in _sortKeys) {
            for (int k = 0; k < 4; k++) {
                _merged.Add(bucket[q * 4 + k]);
            }
        }
        bucket.Clear();
        bucket.AddRange(_merged);
    }
}
