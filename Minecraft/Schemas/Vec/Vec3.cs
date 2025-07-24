using System.Diagnostics.Contracts;

namespace Minecraft.Schemas.Vec;

public readonly struct Vec3(double x, double y, double z) {
    public double X { get; init; } = x;
    public double Y { get; init; } = y;
    public double Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly Vec3 Zero = new(0.0, 0.0, 0.0);
    
    // ReSharper disable InconsistentNaming
    public Vec3 XXX => new(X, X, X);
    public Vec3 XXY => new(X, X, Y);
    public Vec3 XXZ => new(X, X, Z);
    public Vec3 XYX => new(X, Y, X);
    public Vec3 XYY => new(X, Y, Y);
    public Vec3 XYZ => new(X, Y, Z);
    public Vec3 XZX => new(X, Z, X);
    public Vec3 XZY => new(X, Z, Y);
    public Vec3 XZZ => new(X, Z, Z);
    public Vec3 YXX => new(Y, X, X);
    public Vec3 YXY => new(Y, X, Y);
    public Vec3 YXZ => new(Y, X, Z);
    public Vec3 YYX => new(Y, Y, X);
    public Vec3 YYY => new(Y, Y, Y);
    public Vec3 YYZ => new(Y, Y, Z);
    public Vec3 YZX => new(Y, Z, X);
    public Vec3 YZY => new(Y, Z, Y);
    public Vec3 YZZ => new(Y, Z, Z);
    public Vec3 ZXX => new(Z, X, X);
    public Vec3 ZXY => new(Z, X, Y);
    public Vec3 ZXZ => new(Z, X, Z);
    public Vec3 ZYX => new(Z, Y, X);
    public Vec3 ZYY => new(Z, Y, Y);
    public Vec3 ZYZ => new(Z, Y, Z);
    public Vec3 ZZX => new(Z, Z, X);
    public Vec3 ZZY => new(Z, Z, Y);
    public Vec3 ZZZ => new(Z, Z, Z);
    // ReSharper restore InconsistentNaming

    public Vec3(double num) : this(num, num, num) { }

    [Pure]
    public Vec3 Normalize() {
        double len = ComputeLength();
        if (len == 0) {
            return Zero;
        }

        return new Vec3(X / len, Y / len, Z / len);
    }

    [Pure]
    public double ComputeLength() {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    [Pure]
    public Vec3 Multiply(double scalar) {
        return new Vec3(X * scalar, Y * scalar, Z * scalar);
    }

    /// <summary>
    /// Gets the 2-dimensional distance to another vec3.
    /// This means that the Y value is ignored.
    /// </summary>
    /// <param name="other">The other Vec3.</param>
    /// <returns>The distance between the two Vec3s.</returns>
    [Pure]
    public double DistanceTo2D(Vec3 other) {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Z - other.Z, 2));
    }

    [Pure]
    public bool IsWithinRadiusOf(Vec3 other, int radius) {
        return Math.Abs(X - other.X) <= radius && Math.Abs(Z - other.Z) <= radius;
    }

    [Pure]
    public double DistanceTo(Vec3 other) {
        double distanceTopDown = Math.Sqrt(Math.Pow(Math.Abs(X - other.X), 2) + Math.Pow(Math.Abs(Z - other.Z), 2));
        return Math.Sqrt(Math.Pow(distanceTopDown, 2) + Math.Pow(Math.Abs(Y - other.Y), 2));
    }

    [Pure]
    public IVec3 ToBlockPos() {
        return new IVec3((int)Math.Floor(X), (int)Math.Floor(Y), (int)Math.Floor(Z));
    }

    [Pure]
    public Vec3 WithX(double x) {
        return new Vec3(x, Y, Z);
    }

    [Pure]
    public Vec3 WithY(double y) {
        return new Vec3(X, y, Z);
    }

    [Pure]
    public Vec3 WithZ(double z) {
        return new Vec3(X, Y, z);
    }
    
    [Pure]
    public Vec3 With(int axis, double val) {
        return axis switch {
            0 => new Vec3(val, Y, Z),
            1 => new Vec3(X, val, Z),
            2 => new Vec3(X, Y, val),
            _ => throw new IndexOutOfRangeException("Vec3 has 3 numbers")
        };
    }

    [Pure]
    public static Vec3 FromAxis(int axis, double value) {
        return axis switch {
            0 => new Vec3(value, 0, 0),
            1 => new Vec3(0, value, 0),
            2 => new Vec3(0, 0, value),
            _ => throw new IndexOutOfRangeException("Vec3 has 3 numbers")
        };
    }
    
    public static Vec3 operator +(Vec3 a, Vec3 b) {
        return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
    
    public static Vec3 operator -(Vec3 a, Vec3 b) {
        return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }
    
    public static Vec3 operator +(Vec3 a, double scalar) {
        return new Vec3(a.X + scalar, a.Y + scalar, a.Z + scalar);
    }
    
    public static Vec3 operator -(Vec3 a, double scalar) {
        return new Vec3(a.X - scalar, a.Y - scalar, a.Z - scalar);
    }
    
    public static Vec3 operator *(Vec3 a, double scalar) {
        return new Vec3(a.X * scalar, a.Y * scalar, a.Z * scalar);
    }
    
    public static Vec3 operator /(Vec3 a, double scalar) {
        if (scalar == 0) {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        
        return new Vec3(a.X / scalar, a.Y / scalar, a.Z / scalar);
    }
    
    public static Vec3 operator *(Vec3 a, Vec3 b) {
        return new Vec3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }
    
    public static Vec3 operator /(Vec3 a, Vec3 b) {
        if (b.X == 0 || b.Y == 0 || b.Z == 0) {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        
        return new Vec3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    }
    
    public double this[int index] => index switch {
        0 => X,
        1 => Y,
        2 => Z,
        _ => throw new IndexOutOfRangeException("Vec3 has 3 numbers")
    };

    public void Deconstruct(out double x, out double y, out double z) {
        x = X;
        y = Y;
        z = Z;
    }
    
    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }
}
