using System.Numerics;

namespace GraphicalClient.Rendering;

/// <summary>The six planes of a view projection, for rejecting boxes that cannot be on screen.</summary>
public struct Frustum {
    private Vector4 _p0, _p1, _p2, _p3, _p4, _p5;

    /// <summary>
    /// A perspective projection for GL's clip space, where depth runs from -1 to 1. The
    /// <see cref="Matrix4x4"/> factory targets 0 to 1, which GL would not clip at the near plane.
    /// </summary>
    public static Matrix4x4 Perspective(float fovY, float aspect, float near, float far) {
        float f = 1.0F / MathF.Tan(fovY / 2.0F);
        return new Matrix4x4(
            f / aspect, 0, 0, 0,
            0, f, 0, 0,
            0, 0, (far + near) / (near - far), -1,
            0, 0, 2 * far * near / (near - far), 0);
    }

    /// <summary>A square orthographic projection for GL's clip space, <paramref name="halfSize"/> each way, depth 0 to far.</summary>
    public static Matrix4x4 Orthographic(float halfSize, float far) {
        return new Matrix4x4(
            1 / halfSize, 0, 0, 0,
            0, 1 / halfSize, 0, 0,
            0, 0, -2 / far, 0,
            0, 0, -1, 1);
    }

    public static Frustum FromMatrix(Matrix4x4 m) {
        // Gribb and Hartmann's extraction, for System.Numerics' row vector convention.
        Frustum f = new() {
            _p0 = Normalize(new Vector4(m.M14 + m.M11, m.M24 + m.M21, m.M34 + m.M31, m.M44 + m.M41)),
            _p1 = Normalize(new Vector4(m.M14 - m.M11, m.M24 - m.M21, m.M34 - m.M31, m.M44 - m.M41)),
            _p2 = Normalize(new Vector4(m.M14 + m.M12, m.M24 + m.M22, m.M34 + m.M32, m.M44 + m.M42)),
            _p3 = Normalize(new Vector4(m.M14 - m.M12, m.M24 - m.M22, m.M34 - m.M32, m.M44 - m.M42)),
            _p4 = Normalize(new Vector4(m.M14 + m.M13, m.M24 + m.M23, m.M34 + m.M33, m.M44 + m.M43)),
            _p5 = Normalize(new Vector4(m.M14 - m.M13, m.M24 - m.M23, m.M34 - m.M33, m.M44 - m.M43))
        };
        return f;
    }

    /// <summary>The planes as (normal, distance), each facing inward.</summary>
    public readonly void CopyPlanes(Span<Vector4> planes) {
        planes[0] = _p0;
        planes[1] = _p1;
        planes[2] = _p2;
        planes[3] = _p3;
        planes[4] = _p4;
        planes[5] = _p5;
    }

    private static Vector4 Normalize(Vector4 plane) {
        float length = new Vector3(plane.X, plane.Y, plane.Z).Length();
        return plane / length;
    }

    /// <summary>Whether a box, given relative to the camera, is at least partly inside.</summary>
    public readonly bool Intersects(Vector3 min, Vector3 max) {
        return Inside(_p0, min, max) && Inside(_p1, min, max) && Inside(_p2, min, max)
               && Inside(_p3, min, max) && Inside(_p4, min, max) && Inside(_p5, min, max);
    }

    private static bool Inside(Vector4 plane, Vector3 min, Vector3 max) {
        Vector3 positive = new(plane.X >= 0 ? max.X : min.X, plane.Y >= 0 ? max.Y : min.Y, plane.Z >= 0 ? max.Z : min.Z);
        return plane.X * positive.X + plane.Y * positive.Y + plane.Z * positive.Z + plane.W >= 0;
    }
}
