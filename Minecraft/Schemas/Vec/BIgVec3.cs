using System.Numerics;

namespace Minecraft.Schemas.Vec;

public readonly struct BigVec3(BigInteger x, BigInteger y, BigInteger z) : IEquatable<BigVec3> {
    public BigInteger X { get; init; } = x;
    public BigInteger Y { get; init; } = y;
    public BigInteger Z { get; init; } = z;
    
    // This is the default anyway.
    public static readonly BigVec3 Zero = new(0, 0, 0);
    
#region combined_params
// ReSharper disable InconsistentNaming
    public BigVec3 XXX => new(X, X, X);
    public BigVec3 XXY => new(X, X, Y);
    public BigVec3 XXZ => new(X, X, Z);
    public BigVec3 XYX => new(X, Y, X);
    public BigVec3 XYY => new(X, Y, Y);
    public BigVec3 XYZ => new(X, Y, Z);
    public BigVec3 XZX => new(X, Z, X);
    public BigVec3 XZY => new(X, Z, Y);
    public BigVec3 XZZ => new(X, Z, Z);
    public BigVec3 YXX => new(Y, X, X);
    public BigVec3 YXY => new(Y, X, Y);
    public BigVec3 YXZ => new(Y, X, Z);
    public BigVec3 YYX => new(Y, Y, X);
    public BigVec3 YYY => new(Y, Y, Y);
    public BigVec3 YYZ => new(Y, Y, Z);
    public BigVec3 YZX => new(Y, Z, X);
    public BigVec3 YZY => new(Y, Z, Y);
    public BigVec3 YZZ => new(Y, Z, Z);
    public BigVec3 ZXX => new(Z, X, X);
    public BigVec3 ZXY => new(Z, X, Y);
    public BigVec3 ZXZ => new(Z, X, Z);
    public BigVec3 ZYX => new(Z, Y, X);
    public BigVec3 ZYY => new(Z, Y, Y);
    public BigVec3 ZYZ => new(Z, Y, Z);
    public BigVec3 ZZX => new(Z, Z, X);
    public BigVec3 ZZY => new(Z, Z, Y);
    public BigVec3 ZZZ => new(Z, Z, Z);
// ReSharper restore InconsistentNaming
#endregion

    public void Deconstruct(out BigInteger x, out BigInteger y, out BigInteger z) {
        x = X;
        y = Y;
        z = Z;
    }

    public override string ToString() {
        return $"{X}, {Y}, {Z}";
    }

    public override bool Equals(object? obj) {
        return obj is BigVec3 other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y, Z);
    }

    public static bool operator ==(BigVec3 left, BigVec3 right) {
        return left.Equals(right);
    }

    public static bool operator !=(BigVec3 left, BigVec3 right) {
        return !(left == right);
    }

    public bool Equals(BigVec3 other) {
        return X == other.X && Y == other.Y && Z == other.Z;
    }
}
