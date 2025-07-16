using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

public readonly struct Quaternion(float x, float y, float z, float w) {
    public readonly float X = x;
    public readonly float Y = y;
    public readonly float Z = z;
    public readonly float W = w;
    
    public Quaternion(float x, float y, float z) : this(x, y, z, 1) { }
    
    public Quaternion(FVec3 vector, float w) : this(vector.X, vector.Y, vector.Z, w) { }
    
    public Quaternion() : this(0, 0, 0, 1) { }

    public static Quaternion Identity => new(0, 0, 0, 1);
    public static Quaternion Zero => new(0, 0, 0, 0);
    
    // operators
    public static Quaternion operator +(Quaternion a, Quaternion b) {
        return new Quaternion(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z,
            a.W + b.W
        );
    }
    
    public static Quaternion operator -(Quaternion a, Quaternion b) {
        return new Quaternion(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z,
            a.W - b.W
        );
    }
    
    public static Quaternion operator *(Quaternion a, Quaternion b) {
        return new Quaternion(
            a.X * b.W + a.W * b.X + a.Y * b.Z - a.Z * b.Y,
            a.Y * b.W + a.W * b.Y + a.Z * b.X - a.X * b.Z,
            a.Z * b.W + a.W * b.Z + a.X * b.Y - a.Y * b.X,
            a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z
        );
    }
    
    public static Quaternion operator *(Quaternion q, float scalar) {
        return new Quaternion(
            q.X * scalar,
            q.Y * scalar,
            q.Z * scalar,
            q.W * scalar
        );
    }
    
    public static Quaternion operator /(Quaternion q, float scalar) {
        return new Quaternion(
            q.X / scalar,
            q.Y / scalar,
            q.Z / scalar,
            q.W / scalar
        );
    }
    
    public static Quaternion operator -(Quaternion q) {
        return new Quaternion(-q.X, -q.Y, -q.Z, -q.W);
    }
    
    public static Quaternion FromAxisAngle(float x, float y, float z, float angle) {
        float halfAngle = angle / 2f;
        float sinHalfAngle = MathF.Sin(halfAngle);
        return new Quaternion(
            x * sinHalfAngle,
            y * sinHalfAngle,
            z * sinHalfAngle,
            MathF.Cos(halfAngle)
        );
    }

    public static Quaternion FromAngle(Angle angle) {
        float halfAngle = angle.RadiansF / 2f;
        float sinHalfAngle = MathF.Sin(halfAngle);
        return new Quaternion(
            0,
            0,
            sinHalfAngle,
            MathF.Cos(halfAngle)
        );
    }

    public Angle ToAngle() {
        float angle = 2f * MathF.Acos(W);
        if (angle > MathF.PI) {
            angle -= 2f * MathF.PI;
        }
        return Angle.FromRadians(angle);
    }
}
