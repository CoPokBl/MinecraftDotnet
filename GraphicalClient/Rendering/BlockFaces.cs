using System.Numerics;

namespace GraphicalClient.Rendering;

/// <summary>The six faces of a block in <see cref="Assets.Face"/> order, which pairs opposites so a face's opposite is <c>face ^ 1</c>.</summary>
public static class BlockFaces {
    public static readonly (int X, int Y, int Z)[] Steps = [(0, -1, 0), (0, 1, 0), (0, 0, -1), (0, 0, 1), (-1, 0, 0), (1, 0, 0)];

    /// <summary>Each face's corners of the unit cube, wound counter clockwise seen from outside.</summary>
    public static readonly byte[,,] Corners = {
        { { 0, 0, 0 }, { 1, 0, 0 }, { 1, 0, 1 }, { 0, 0, 1 } },
        { { 0, 1, 0 }, { 0, 1, 1 }, { 1, 1, 1 }, { 1, 1, 0 } },
        { { 0, 0, 0 }, { 0, 1, 0 }, { 1, 1, 0 }, { 1, 0, 0 } },
        { { 0, 0, 1 }, { 1, 0, 1 }, { 1, 1, 1 }, { 0, 1, 1 } },
        { { 0, 0, 0 }, { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } },
        { { 1, 0, 0 }, { 1, 1, 0 }, { 1, 1, 1 }, { 1, 0, 1 } }
    };

    /// <summary>The axis a face is perpendicular to: 0 for x, 1 for y, 2 for z.</summary>
    public static int Axis(int face) => face < 2 ? 1 : face < 4 ? 2 : 0;

    public static float Component(Vector3 v, int axis) => axis switch { 0 => v.X, 1 => v.Y, _ => v.Z };
}
