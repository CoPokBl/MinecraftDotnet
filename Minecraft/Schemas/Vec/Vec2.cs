using System.Numerics;
using Newtonsoft.Json;

namespace Minecraft.Schemas.Vec;

[JsonObject(MemberSerialization.OptIn)]
public readonly struct Vec2<T>(T x, T y) : IEquatable<Vec2<T>> where T : INumber<T>  {
    [JsonProperty]
    public readonly T X = x;
    
    [JsonProperty]
    public readonly T Y = y;
    
    public Vec2() : this(T.Zero, T.Zero) { }
    
    public Vec2(T num) : this(num, num) { }
    
    public static readonly Vec2<T> Zero = new(T.Zero, T.Zero);
    public static readonly Vec2<T> One = new(T.One, T.One);
    
    public T this[int index] => index switch {
        0 => X,
        1 => Y,
        _ => throw new IndexOutOfRangeException("Index must be 0 or 1.")
    };

    #region combined_params
    // ReSharper disable InconsistentNaming
    public Vec2<T> XY => new(X, Y);
    public Vec2<T> YX => new(Y, X);
    public Vec2<T> XX => new(X, X);
    public Vec2<T> YY => new(Y, Y);
    public Vec3<T> XXX => new(X, X, X);
    public Vec3<T> XXY => new(X, X, Y);
    public Vec3<T> XYX => new(X, Y, X);
    public Vec3<T> XYY => new(X, Y, Y);
    public Vec3<T> YXX => new(Y, X, X);
    public Vec3<T> YXY => new(Y, X, Y);
    public Vec3<T> YYX => new(Y, Y, X);
    public Vec3<T> YYY => new(Y, Y, Y);
    // ReSharper restore InconsistentNaming
    #endregion

    #region calculations

    /// <summary>
    /// Gets whether this vector is within the square radius of another vector.
    /// </summary>
    /// <param name="other">The other vector to calculate with.</param>
    /// <param name="radius">The radius.</param>
    /// <returns>True if within the radius.</returns>
    public bool IsWithinRadiusOf(Vec2<T> other, T radius) {
        return T.Abs(X - other.X) <= radius && T.Abs(Y - other.Y) <= radius;
    }

    public double DistanceTo(Vec2<T> other) {
        T absX = T.Abs(X - other.X);
        T absY = T.Abs(Y - other.Y);
        return Math.Sqrt((absX * absX + absY * absY).ToDouble());
    }

    #endregion

    #region operators

    public bool Equals(Vec2<T> other) {
        return EqualityComparer<T>.Default.Equals(X, other.X) && EqualityComparer<T>.Default.Equals(Y, other.Y);
    }

    public override bool Equals(object? obj) {
        return obj is Vec2<T> other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Vec2<T> left, Vec2<T> right) {
        return left.Equals(right);
    }

    public static bool operator !=(Vec2<T> left, Vec2<T> right) {
        return !(left == right);
    }
    
    public static Vec2<T> operator +(Vec2<T> left, Vec2<T> right) {
        return new Vec2<T>(left.X + right.X, left.Y + right.Y);
    }
    
    public static Vec2<T> operator -(Vec2<T> left, Vec2<T> right) {
        return new Vec2<T>(left.X - right.X, left.Y - right.Y);
    }
    
    public static Vec2<T> operator *(Vec2<T> left, Vec2<T> right) {
        return new Vec2<T>(left.X * right.X, left.Y * right.Y);
    }
    
    public static Vec2<T> operator /(Vec2<T> left, Vec2<T> right) {
        return new Vec2<T>(left.X / right.X, left.Y / right.Y);
    }
    
    public static Vec2<T> operator *(Vec2<T> left, T right) {
        return new Vec2<T>(left.X * right, left.Y * right);
    }
    
    public static Vec2<T> operator /(Vec2<T> left, T right) {
        return new Vec2<T>(left.X / right, left.Y / right);
    }
    
    public static Vec2<T> operator +(Vec2<T> left, T right) {
        return new Vec2<T>(left.X + right, left.Y + right);
    }
    
    public static Vec2<T> operator -(Vec2<T> left, T right) {
        return new Vec2<T>(left.X - right, left.Y - right);
    }
    
    public override string ToString() {
        return $"{X}, {Y}";
    }
    
    public static implicit operator Vec2<T>((T x, T y) tuple) {
        return new Vec2<T>(tuple.x, tuple.y);
    }
    
    public static implicit operator (T x, T y)(Vec2<T> vec) {
        return (vec.X, vec.Y);
    }

    #endregion

    #region modifications

    public Vec2<T> WithX(T x) {
        return new Vec2<T>(x, Y);
    }
    
    public Vec2<T> WithY(T y) {
        return new Vec2<T>(X, y);
    }
    
    public Vec2<T> AddX(T x) {
        return new Vec2<T>(X + x, Y);
    }
    
    public Vec2<T> AddY(T y) {
        return new Vec2<T>(X, Y + y);
    }
    
    public Vec2<T> SubtractX(T x) {
        return new Vec2<T>(X - x, Y);
    }
    
    public Vec2<T> SubtractY(T y) {
        return new Vec2<T>(X, Y - y);
    }
    
    public Vec2<T> MultiplyX(T x) {
        return new Vec2<T>(X * x, Y);
    }
    
    public Vec2<T> MultiplyY(T y) {
        return new Vec2<T>(X, Y * y);
    }
    
    public Vec2<T> DivideX(T x) {
        return new Vec2<T>(X / x, Y);
    }
    
    public Vec2<T> DivideY(T y) {
        return new Vec2<T>(X, Y / y);
    }

    #endregion
}
