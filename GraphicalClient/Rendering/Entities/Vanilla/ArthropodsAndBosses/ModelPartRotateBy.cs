namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>ModelPart.rotateBy</c>: the ZYX Euler rotation turned by a quaternion and read back as ZYX angles, as
/// JOML's <c>Matrix3f</c> does. Matrices are JOML's column vector convention, so no <c>System.Numerics</c> type fits.
/// </summary>
public static class ModelPartRotateBy {
    /// <summary>A JOML <c>Quaternionf</c>.</summary>
    public readonly record struct Quat(float X, float Y, float Z, float W) {
        public static readonly Quat Identity = new(0, 0, 0, 1);

        /// <summary><c>setAngleAxis</c>, for an axis already of unit length.</summary>
        public static Quat AngleAxis(float angle, float x, float y, float z) {
            float s = MathF.Sin(angle * 0.5F);
            return new Quat(x * s, y * s, z * s, MathF.Cos(angle * 0.5F));
        }

        /// <summary><c>Axis.YP.rotationDegrees</c>.</summary>
        public static Quat RotationYDegrees(float degrees) => AngleAxis(degrees * (MathF.PI / 180.0F), 0, 1, 0);

        /// <summary>JOML's <c>mul</c>: this, then <paramref name="b"/> applied first to a vector.</summary>
        public Quat Mul(Quat b) => new(
            W * b.X + X * b.W + Y * b.Z - Z * b.Y,
            W * b.Y - X * b.Z + Y * b.W + Z * b.X,
            W * b.Z + X * b.Y - Y * b.X + Z * b.W,
            W * b.W - X * b.X - Y * b.Y - Z * b.Z);

        /// <summary><c>rotateAxis</c>, for an axis already of unit length.</summary>
        public Quat RotateAxis(float angle, float x, float y, float z) => Mul(AngleAxis(angle, x, y, z));

        /// <summary><c>rotateX</c>.</summary>
        public Quat RotateX(float angle) => Mul(AngleAxis(angle, 1, 0, 0));

        /// <summary><c>rotateY</c>.</summary>
        public Quat RotateY(float angle) => Mul(AngleAxis(angle, 0, 1, 0));

        /// <summary><c>rotateZ</c>.</summary>
        public Quat RotateZ(float angle) => Mul(AngleAxis(angle, 0, 0, 1));
    }

    public static void RotateBy(this ModelPart part, Quat q) {
        float[,] old = RotationZYX(part.ZRot, part.YRot, part.XRot);
        float[,] turn = {
            { 1 - 2 * (q.Y * q.Y + q.Z * q.Z), 2 * (q.X * q.Y - q.Z * q.W), 2 * (q.X * q.Z + q.Y * q.W) },
            { 2 * (q.X * q.Y + q.Z * q.W), 1 - 2 * (q.X * q.X + q.Z * q.Z), 2 * (q.Y * q.Z - q.X * q.W) },
            { 2 * (q.X * q.Z - q.Y * q.W), 2 * (q.Y * q.Z + q.X * q.W), 1 - 2 * (q.X * q.X + q.Y * q.Y) }
        };
        float[,] m = Multiply(old, turn);
        // Matrix3f.getEulerAnglesZYX.
        float x = MathF.Atan2(m[2, 1], m[2, 2]);
        float y = MathF.Atan2(-m[2, 0], MathF.Sqrt(1.0F - m[2, 0] * m[2, 0]));
        float z = MathF.Atan2(m[1, 0], m[0, 0]);
        part.SetRotation(x, y, z);
    }

    /// <summary><c>Matrix3f.rotationZYX</c>: Rz times Ry times Rx.</summary>
    private static float[,] RotationZYX(float z, float y, float x) {
        float cz = MathF.Cos(z), sz = MathF.Sin(z), cy = MathF.Cos(y), sy = MathF.Sin(y), cx = MathF.Cos(x), sx = MathF.Sin(x);
        float[,] rz = { { cz, -sz, 0 }, { sz, cz, 0 }, { 0, 0, 1 } };
        float[,] ry = { { cy, 0, sy }, { 0, 1, 0 }, { -sy, 0, cy } };
        float[,] rx = { { 1, 0, 0 }, { 0, cx, -sx }, { 0, sx, cx } };
        return Multiply(Multiply(rz, ry), rx);
    }

    private static float[,] Multiply(float[,] a, float[,] b) {
        float[,] r = new float[3, 3];
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                r[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j];
            }
        }
        return r;
    }
}
