using System.Numerics;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// A 3x3 matrix applied to column vectors, as JOML's are, so the model baking reads in the order
/// vanilla's does. <see cref="Matrix4x4"/> is row vector and would invert every composition.
/// </summary>
public readonly struct Mat3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22) {
    public readonly float M00 = m00, M01 = m01, M02 = m02, M10 = m10, M11 = m11, M12 = m12, M20 = m20, M21 = m21, M22 = m22;

    public static readonly Mat3 Identity = new(1, 0, 0, 0, 1, 0, 0, 0, 1);

    public bool IsIdentity => this.Equals(Identity);

    /// <summary>Cosine and sine, exact at multiples of 90 degrees so rotated corners land exactly on block edges.</summary>
    private static (float Cos, float Sin) Trig(float degrees) {
        float normalised = ((degrees % 360) + 360) % 360;
        return normalised switch {
            0 => (1, 0),
            90 => (0, 1),
            180 => (-1, 0),
            270 => (0, -1),
            _ => (MathF.Cos(degrees * MathF.PI / 180), MathF.Sin(degrees * MathF.PI / 180))
        };
    }

    public static Mat3 RotationX(float degrees) {
        (float c, float s) = Trig(degrees);
        return new Mat3(1, 0, 0, 0, c, -s, 0, s, c);
    }

    public static Mat3 RotationY(float degrees) {
        (float c, float s) = Trig(degrees);
        return new Mat3(c, 0, s, 0, 1, 0, -s, 0, c);
    }

    public static Mat3 RotationZ(float degrees) {
        (float c, float s) = Trig(degrees);
        return new Mat3(c, -s, 0, s, c, 0, 0, 0, 1);
    }

    public static Mat3 operator *(Mat3 a, Mat3 b) => new(
        a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22,
        a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22,
        a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);

    public Vector3 Transform(Vector3 v) => new(
        M00 * v.X + M01 * v.Y + M02 * v.Z,
        M10 * v.X + M11 * v.Y + M12 * v.Z,
        M20 * v.X + M21 * v.Y + M22 * v.Z);

    /// <summary>The inverse of a rotation.</summary>
    public Mat3 Transposed => new(M00, M10, M20, M01, M11, M21, M02, M12, M22);

    /// <summary>This after a scale along each axis, JOML's <c>scale</c>.</summary>
    public Mat3 Scaled(Vector3 s) => new(M00 * s.X, M01 * s.Y, M02 * s.Z, M10 * s.X, M11 * s.Y, M12 * s.Z, M20 * s.X, M21 * s.Y, M22 * s.Z);
}

/// <summary>Directions in vanilla's order, which is also <see cref="Face"/>'s.</summary>
public static class Directions {
    public static readonly Vector3[] Normals = [new(0, -1, 0), new(0, 1, 0), new(0, 0, -1), new(0, 0, 1), new(-1, 0, 0), new(1, 0, 0)];
    public static readonly string[] Names = ["down", "up", "north", "south", "west", "east"];

    public static int? Parse(string? name) {
        int index = name == null ? -1 : Array.IndexOf(Names, name);
        return index < 0 ? null : index;
    }

    /// <summary><c>Direction.getApproximateNearest</c>: the direction most aligned with a vector.</summary>
    public static int Nearest(Vector3 v) {
        int best = 2;
        float bestDot = float.MinValue;
        for (int d = 0; d < 6; d++) {
            float dot = Vector3.Dot(v, Normals[d]);
            if (dot > bestDot) {
                bestDot = dot;
                best = d;
            }
        }
        return best;
    }

    /// <summary><c>FaceBakery.findClosestDirection</c>: like <see cref="Nearest"/>, but nothing for a degenerate or wholly negative vector.</summary>
    public static int? Closest(Vector3 v) {
        if (!float.IsFinite(v.X) || !float.IsFinite(v.Y) || !float.IsFinite(v.Z)) {
            return null;
        }
        int? best = null;
        float closest = 0;
        for (int d = 0; d < 6; d++) {
            float dot = Vector3.Dot(v, Normals[d]);
            if (dot >= 0 && dot > closest) {
                closest = dot;
                best = d;
            }
        }
        return best;
    }
}

/// <summary>
/// The JDK's <c>java.util.Random</c>, which vanilla's <c>LegacyRandomSource</c> is. Weighted model
/// variants are chosen with it from a seed of the block's position, so the same block picks the same
/// variant in this client as in the game.
/// </summary>
public struct JavaRandom {
    private const long Multiplier = 0x5DEECE66DL;
    private long _seed;

    public JavaRandom(long seed) {
        _seed = (seed ^ Multiplier) & ((1L << 48) - 1);
    }

    public void SetSeed(long seed) => _seed = (seed ^ Multiplier) & ((1L << 48) - 1);

    private int Next(int bits) {
        _seed = (_seed * Multiplier + 0xBL) & ((1L << 48) - 1);
        return (int)(_seed >>> (48 - bits));
    }

    public int NextInt(int bound) {
        if ((bound & -bound) == bound) {
            return (int)((bound * (long)Next(31)) >> 31);
        }
        int bits, value;
        do {
            bits = Next(31);
            value = bits % bound;
        } while (bits - value + (bound - 1) < 0);
        return value;
    }

    public long NextLong() => ((long)Next(32) << 32) + Next(32);

    public float NextFloat() => Next(24) * 5.9604645E-8F;

    /// <summary><c>Mth.getSeed</c>, the seed a block position's model choices start from.</summary>
    public static long PositionSeed(int x, int y, int z) {
        long seed = (long)(x * 3129871) ^ (long)z * 116129781L ^ y;
        seed = seed * seed * 42317861L + seed * 11L;
        return seed >> 16;
    }
}
