using System.Diagnostics.Contracts;
using System.Numerics;

namespace Minecraft.Schemas.Vec;

public readonly struct Vec3<T>(T x, T y, T z) : IEquatable<Vec3<T>> where T : INumber<T> {
    public readonly T X = x;
    public readonly T Y = y;
    public readonly T Z = z;

    public Vec3() : this(T.Zero, T.Zero, T.Zero) { }
    
    public Vec3(T num) : this(num, num, num) { }
    
    public static readonly Vec3<T> Zero = new(T.Zero, T.Zero, T.Zero);
    public static readonly Vec3<T> One = new(T.One, T.One, T.One);
    
    public T this[int index] => index switch {
        0 => X,
        1 => Y,
        2 => Z,
        _ => throw new IndexOutOfRangeException("Vec3 has 3 numbers")
    };
    
    #region combined_params
    // ReSharper disable InconsistentNaming
    public Vec3<T> XXX => new(X, X, X);
    public Vec3<T> XXY => new(X, X, Y);
    public Vec3<T> XXZ => new(X, X, Z);
    public Vec3<T> XYX => new(X, Y, X);
    public Vec3<T> XYY => new(X, Y, Y);
    public Vec3<T> XYZ => new(X, Y, Z);
    public Vec3<T> XZX => new(X, Z, X);
    public Vec3<T> XZY => new(X, Z, Y);
    public Vec3<T> XZZ => new(X, Z, Z);
    public Vec3<T> YXX => new(Y, X, X);
    public Vec3<T> YXY => new(Y, X, Y);
    public Vec3<T> YXZ => new(Y, X, Z);
    public Vec3<T> YYX => new(Y, Y, X);
    public Vec3<T> YYY => new(Y, Y, Y);
    public Vec3<T> YYZ => new(Y, Y, Z);
    public Vec3<T> YZX => new(Y, Z, X);
    public Vec3<T> YZY => new(Y, Z, Y);
    public Vec3<T> YZZ => new(Y, Z, Z);
    public Vec3<T> ZXX => new(Z, X, X);
    public Vec3<T> ZXY => new(Z, X, Y);
    public Vec3<T> ZXZ => new(Z, X, Z);
    public Vec3<T> ZYX => new(Z, Y, X);
    public Vec3<T> ZYY => new(Z, Y, Y);
    public Vec3<T> ZYZ => new(Z, Y, Z);
    public Vec3<T> ZZX => new(Z, Z, X);
    public Vec3<T> ZZY => new(Z, Z, Y);
    public Vec3<T> ZZZ => new(Z, Z, Z);
    public Vec2<T> XY => new(X, Y);
    public Vec2<T> XZ => new(X, Z);
    public Vec2<T> YZ => new(Y, Z);
    public Vec2<T> YX => new(Y, X);
    public Vec2<T> ZX => new(Z, X);
    public Vec2<T> ZY => new(Z, Y);
    public Vec2<T> ZZ => new(Z, Z);
    public Vec2<T> XX => new(X, X);
    public Vec2<T> YY => new(Y, Y);
    // ReSharper restore InconsistentNaming
    #endregion

    #region computations

    [Pure]
    public Vec3<T> Normalize() {
        if (X is float) {
            float len = ComputeLengthF();
            if (len == 0) {
                return Zero;
            }

            return new Vec3<T>(X / (T)(object)len, Y / (T)(object)len, Z / (T)(object)len);
        }
        else {
            double len = ComputeLength();
            if (len == 0) {
                return Zero;
            }

            return new Vec3<T>(
                T.CreateTruncating(X.ToDouble() / len), 
                T.CreateTruncating(Y.ToDouble() / len), 
                T.CreateTruncating(Z.ToDouble() / len));
        }
    }
    
    public Vec3<int> GetBlockTowards(BlockFace face) {
        return face switch {
            BlockFace.NegY => new Vec3<T>(X, Y - T.One, Z).ToBlockPos(),
            BlockFace.PosY => new Vec3<T>(X, Y + T.One, Z).ToBlockPos(),
            BlockFace.NegZ => new Vec3<T>(X, Y, Z - T.One).ToBlockPos(),
            BlockFace.PosZ => new Vec3<T>(X, Y, Z + T.One).ToBlockPos(),
            BlockFace.NegX => new Vec3<T>(X - T.One, Y, Z).ToBlockPos(),
            BlockFace.PosX => new Vec3<T>(X + T.One, Y, Z).ToBlockPos(),
            _ => throw new ArgumentOutOfRangeException(nameof(face), face, null)
        };
    }

    [Pure]
    public double ComputeLength() {
        return Math.Sqrt((X * X + Y * Y + Z * Z).ToDouble());
    }
    
    [Pure]
    public float ComputeLengthF() {
        return MathF.Sqrt((X * X + Y * Y + Z * Z).ToFloat());
    }

    [Pure]
    public Vec3<T> Multiply(T scalar) {
        return new Vec3<T>(X * scalar, Y * scalar, Z * scalar);
    }

    /// <summary>
    /// Gets the 2-dimensional distance to another vec3.
    /// This means that the Y value is ignored.
    /// </summary>
    /// <param name="other">The other Vec3.</param>
    /// <returns>The distance between the two Vec3s.</returns>
    [Pure]
    public double DistanceTo2D(Vec3<T> other) {
        T absX = T.Abs(X - other.X);
        T absY = T.Abs(Z - other.Z);
        return Math.Sqrt((absX * absX + absY * absY).ToDouble());
    }

    /// <summary>
    /// Gets whether this vector is within the 2D square radius of another vector.
    /// </summary>
    /// <param name="other">The other vector to calculate with.</param>
    /// <param name="radius">The radius.</param>
    /// <returns>True if within the radius.</returns>
    [Pure]
    public bool IsWithinRadiusOf(Vec3<T> other, T radius) {
        return T.Abs(X - other.X) <= radius && T.Abs(Z - other.Z) <= radius;
    }

    [Pure]
    public double DistanceTo(Vec3<T> other) {
        double absX = T.Abs(X - other.X).ToDouble();
        double absY = T.Abs(Y - other.Y).ToDouble();
        double absZ = T.Abs(Z - other.Z).ToDouble();
        double distanceTopDown = Math.Sqrt(absX * absX + absZ * absZ);
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + absY*absY);
    }

    [Pure]
    public Vec3<int> ToBlockPos() {
        if (this is Vec3<int> vec3Int) {
            return vec3Int;
        }
        return new Vec3<int>((int)Math.Floor(X.ToFloat()), (int)Math.Floor(Y.ToFloat()), (int)Math.Floor(Z.ToFloat()));
    }
    
    [Pure]
    public Vec3<double> BlockPosToDouble() {
        return new Vec3<double>(X.ToDouble() + 0.5, Y.ToDouble() + 0.5, Z.ToDouble() + 0.5);
    }

#endregion

    #region mutations

    [Pure]
    public Vec3<T> WithX(T x) {
        return new Vec3<T>(x, Y, Z);
    }

    [Pure]
    public Vec3<T> WithY(T y) {
        return new Vec3<T>(X, y, Z);
    }
    
    [Pure]
    public Vec3<T> WithZ(T z) {
        return new Vec3<T>(X, Y, z);
    }
    
    [Pure]
    public Vec3<T> With(int axis, T val) {
        return axis switch {
            0 => new Vec3<T>(val, Y, Z),
            1 => new Vec3<T>(X, val, Z),
            2 => new Vec3<T>(X, Y, val),
            _ => throw new IndexOutOfRangeException("Vec3 has 3 numbers")
        };
    }

    #endregion

    #region operators

    [Pure]
    public static Vec3<T> FromAxis(int axis, T value) {
        return axis switch {
            0 => new Vec3<T>(value, T.Zero, T.Zero),
            1 => new Vec3<T>(T.Zero, value, T.Zero),
            2 => new Vec3<T>(T.Zero, T.Zero, value),
            _ => throw new IndexOutOfRangeException("Vec3 has 3 numbers")
        };
    }
    
    public static Vec3<T> operator +(Vec3<T> a, Vec3<T> b) {
        return new Vec3<T>(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
    
    public static Vec3<T> operator -(Vec3<T> a, Vec3<T> b) {
        return new Vec3<T>(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }
    
    public static Vec3<T> operator +(Vec3<T> a, T scalar) {
        return new Vec3<T>(a.X + scalar, a.Y + scalar, a.Z + scalar);
    }
    
    public static Vec3<T> operator -(Vec3<T> a, T scalar) {
        return new Vec3<T>(a.X - scalar, a.Y - scalar, a.Z - scalar);
    }
    
    public static Vec3<T> operator *(Vec3<T> a, T scalar) {
        return new Vec3<T>(a.X * scalar, a.Y * scalar, a.Z * scalar);
    }
    
    public static Vec3<T> operator /(Vec3<T> a, T scalar) {
        if (scalar == T.Zero) {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        
        return new Vec3<T>(a.X / scalar, a.Y / scalar, a.Z / scalar);
    }
    
    public static Vec3<T> operator *(Vec3<T> a, Vec3<T> b) {
        return new Vec3<T>(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }
    
    public static Vec3<T> operator /(Vec3<T> a, Vec3<T> b) {
        if (b.X == T.Zero || b.Y == T.Zero || b.Z == T.Zero) {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        
        return new Vec3<T>(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    }
    
    public static bool operator ==(Vec3<T> left, Vec3<T> right) {
        return left.Equals(right);
    }

    public static bool operator !=(Vec3<T> left, Vec3<T> right) {
        return !(left == right);
    }
    
    public static implicit operator Vec3<double>(Vec3<T> val) {
        return new Vec3<double>(val.X.ToDouble(), val.Y.ToDouble(), val.Z.ToDouble());
    }

    #endregion

    public void Deconstruct(out T x, out T y, out T z) {
        x = X;
        y = Y;
        z = Z;
    }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y, Z);
    }

    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }

    public bool Equals(Vec3<T> other) {
        return EqualityComparer<T>.Default.Equals(X, other.X) && 
               EqualityComparer<T>.Default.Equals(Y, other.Y) && 
               EqualityComparer<T>.Default.Equals(Z, other.Z);
    }

    public override bool Equals(object? obj) {
        return obj is Vec3<T> other && Equals(other);
    }
}
