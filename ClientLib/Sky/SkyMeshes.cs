using System.Numerics;
using Minecraft.Schemas;

namespace ClientLib.Sky;

/// <summary>A vertex of one of the sky's meshes: where it is before the draw's transform, its texture coordinate, and its ARGB colour.</summary>
public readonly record struct SkyVertex(Vector3 Position, Vector2 Uv, uint Colour);

/// <summary>
/// The vertex buffers <c>SkyRenderer</c> builds once, vertex for vertex and in vanilla's order, with its float
/// arithmetic: the star field's positions decide which pixels light up, so they are held to the jar bit for bit.
/// What each mesh is drawn with, and where, is the renderer's.
/// </summary>
public static class SkyMeshes {
    /// <summary><c>SKY_DISC_RADIUS</c>.</summary>
    public const float SkyDiscRadius = 512.0F;

    /// <summary><c>STAR_COUNT</c>: how many stars are tried. Those whose draw falls outside the shell are left out.</summary>
    public const int StarCount = 1500;

    /// <summary>The seed <c>buildStars</c> draws from, the same every run.</summary>
    public const long StarSeed = 10842L;

    /// <summary><c>buildEndSky</c>'s colour, a dark grey.</summary>
    public const uint EndSkyColour = 0xFF282828;

    /// <summary>
    /// <c>buildSkyDisc</c>: a triangle fan of ten, the centre then nine points round the rim from -180 to 180
    /// degrees, the first and last the same. Below the camera the x axis is mirrored, which turns the winding
    /// round so the disc faces the camera from either side.
    /// </summary>
    public static Vector3[] SkyDisc(float yy) {
        Vector3[] vertices = new Vector3[10];
        float x = MathF.Sign(yy) * SkyDiscRadius;
        vertices[0] = new Vector3(0.0F, yy, 0.0F);
        int n = 1;
        for (int i = -180; i <= 180; i += 45) {
            vertices[n++] = new Vector3(x * Mth.Cos(i * (float)(Math.PI / 180.0)), yy, SkyDiscRadius * Mth.Sin(i * (float)(Math.PI / 180.0)));
        }
        return vertices;
    }

    /// <summary>
    /// <c>buildSunriseFan</c>: a fan from a white centre 100 up to a transparent ring of sixteen steps, the first
    /// and last the same, tipped 40 toward the camera along z at the top and away from it at the bottom.
    /// </summary>
    public static SkyVertex[] SunriseFan() {
        SkyVertex[] vertices = new SkyVertex[18];
        vertices[0] = new SkyVertex(new Vector3(0.0F, 100.0F, 0.0F), Vector2.Zero, 0xFFFFFFFF);
        for (int i = 0; i <= 16; i++) {
            float angle = i * (float)(Math.PI * 2) / 16.0F;
            float sin = Mth.Sin(angle);
            float cos = Mth.Cos(angle);
            vertices[i + 1] = new SkyVertex(new Vector3(sin * 120.0F, cos * 120.0F, -cos * 40.0F), Vector2.Zero, 0x00FFFFFF);
        }
        return vertices;
    }

    /// <summary>
    /// <c>buildStars</c>: quads round a shell 100 out, each a quarter to a half block across, facing the centre and
    /// turned about its own axis. A point drawn too near the centre or outside the unit sphere is skipped, though
    /// its size was drawn, so the generator's stream is what fixes which stars exist.
    /// </summary>
    public static Vector3[] Stars() {
        LegacyRandomSource random = new(StarSeed);
        List<Vector3> vertices = new(StarCount * 4);
        for (int i = 0; i < StarCount; i++) {
            float x = random.NextFloat() * 2.0F - 1.0F;
            float y = random.NextFloat() * 2.0F - 1.0F;
            float z = random.NextFloat() * 2.0F - 1.0F;
            float starSize = 0.15F + random.NextFloat() * 0.1F;
            float lengthSq = x * x + y * y + z * z;
            if (lengthSq <= 0.010000001F || lengthSq >= 1.0F) {
                continue;
            }
            // Vector3f.normalize(100): JOML's fma is a multiply and an add unless joml.useMathFma is set, which it is not.
            float scalar = InvSqrt(x * x + (y * y + z * z)) * 100.0F;
            Vector3 centre = new(x * scalar, y * scalar, z * scalar);
            float zRot = (float)(random.NextDouble() * (float)Math.PI * 2.0);
            Matrix3 rotation = Matrix3.Identity.RotateTowards(-centre.X, -centre.Y, -centre.Z, 0.0F, 1.0F, 0.0F).RotateZ(-zRot);
            vertices.Add(rotation.Transform(starSize, -starSize, 0.0F) + centre);
            vertices.Add(rotation.Transform(starSize, starSize, 0.0F) + centre);
            vertices.Add(rotation.Transform(-starSize, starSize, 0.0F) + centre);
            vertices.Add(rotation.Transform(-starSize, -starSize, 0.0F) + centre);
        }
        return vertices.ToArray();
    }

    /// <summary>
    /// <c>buildEndSky</c>: six quads 100 out, the bottom one and the same turned onto each other face of the box,
    /// the texture repeating sixteen times across each.
    /// </summary>
    public static SkyVertex[] EndSky() {
        SkyVertex[] vertices = new SkyVertex[24];
        for (int i = 0; i < 6; i++) {
            Matrix4 pose = i switch {
                1 => Matrix4.RotationX((float)(Math.PI / 2)),
                2 => Matrix4.RotationX((float)(-Math.PI / 2)),
                3 => Matrix4.RotationX((float)Math.PI),
                4 => Matrix4.RotationZ((float)(Math.PI / 2)),
                5 => Matrix4.RotationZ((float)(-Math.PI / 2)),
                _ => Matrix4.Identity
            };
            vertices[i * 4] = new SkyVertex(pose.TransformPosition(-100.0F, -100.0F, -100.0F), new Vector2(0.0F, 0.0F), EndSkyColour);
            vertices[i * 4 + 1] = new SkyVertex(pose.TransformPosition(-100.0F, -100.0F, 100.0F), new Vector2(0.0F, 16.0F), EndSkyColour);
            vertices[i * 4 + 2] = new SkyVertex(pose.TransformPosition(100.0F, -100.0F, 100.0F), new Vector2(16.0F, 16.0F), EndSkyColour);
            vertices[i * 4 + 3] = new SkyVertex(pose.TransformPosition(100.0F, -100.0F, -100.0F), new Vector2(16.0F, 0.0F), EndSkyColour);
        }
        return vertices;
    }

    /// <summary><c>buildCelestialQuad</c>, for the sun and the end flash: a unit square in the xz plane with the sprite laid on it.</summary>
    public static SkyVertex[] CelestialQuad(float u0, float v0, float u1, float v1) => [
        new(new Vector3(-1.0F, 0.0F, -1.0F), new Vector2(u0, v0), 0xFFFFFFFF),
        new(new Vector3(1.0F, 0.0F, -1.0F), new Vector2(u1, v0), 0xFFFFFFFF),
        new(new Vector3(1.0F, 0.0F, 1.0F), new Vector2(u1, v1), 0xFFFFFFFF),
        new(new Vector3(-1.0F, 0.0F, 1.0F), new Vector2(u0, v1), 0xFFFFFFFF)
    ];

    /// <summary>One phase of <c>buildMoonPhases</c>: the same square with the sprite turned half round, as the moon faces the sun.</summary>
    public static SkyVertex[] MoonQuad(float u0, float v0, float u1, float v1) => [
        new(new Vector3(-1.0F, 0.0F, -1.0F), new Vector2(u1, v1), 0xFFFFFFFF),
        new(new Vector3(1.0F, 0.0F, -1.0F), new Vector2(u0, v1), 0xFFFFFFFF),
        new(new Vector3(1.0F, 0.0F, 1.0F), new Vector2(u0, v0), 0xFFFFFFFF),
        new(new Vector3(-1.0F, 0.0F, 1.0F), new Vector2(u1, v0), 0xFFFFFFFF)
    ];

    /// <summary>JOML's <c>Math.invsqrt</c> outside fast math.</summary>
    private static float InvSqrt(float r) => 1.0F / (float)Math.Sqrt(r);

    /// <summary>JOML's <c>Math.cosFromSin</c> outside fast math: the cosine from the sine, its sign from the angle's quadrant.</summary>
    private static float CosFromSin(float sin, float angle) {
        float cos = (float)Math.Sqrt(1.0F - sin * sin);
        float a = angle + (float)(Math.PI / 2);
        float b = a - (int)(a / (float)(Math.PI * 2)) * (float)(Math.PI * 2);
        if (b < 0.0) {
            b += (float)(Math.PI * 2);
        }
        return b >= (float)Math.PI ? -cos : cos;
    }

    /// <summary>The parts of JOML's <c>Matrix3f</c> the star field uses, element <c>mCR</c> being column C, row R.</summary>
    private readonly record struct Matrix3(float M00, float M01, float M02, float M10, float M11, float M12, float M20, float M21, float M22) {
        public static Matrix3 Identity => new(1, 0, 0, 0, 1, 0, 0, 0, 1);

        public Matrix3 RotateTowards(float dirX, float dirY, float dirZ, float upX, float upY, float upZ) {
            float invDirLength = InvSqrt(dirX * dirX + dirY * dirY + dirZ * dirZ);
            float ndirX = dirX * invDirLength;
            float ndirY = dirY * invDirLength;
            float ndirZ = dirZ * invDirLength;
            float leftX = upY * ndirZ - upZ * ndirY;
            float leftY = upZ * ndirX - upX * ndirZ;
            float leftZ = upX * ndirY - upY * ndirX;
            float invLeftLength = InvSqrt(leftX * leftX + leftY * leftY + leftZ * leftZ);
            leftX *= invLeftLength;
            leftY *= invLeftLength;
            leftZ *= invLeftLength;
            float upnX = ndirY * leftZ - ndirZ * leftY;
            float upnY = ndirZ * leftX - ndirX * leftZ;
            float upnZ = ndirX * leftY - ndirY * leftX;
            return new Matrix3(
                M00 * leftX + M10 * leftY + M20 * leftZ, M01 * leftX + M11 * leftY + M21 * leftZ, M02 * leftX + M12 * leftY + M22 * leftZ,
                M00 * upnX + M10 * upnY + M20 * upnZ, M01 * upnX + M11 * upnY + M21 * upnZ, M02 * upnX + M12 * upnY + M22 * upnZ,
                M00 * ndirX + M10 * ndirY + M20 * ndirZ, M01 * ndirX + M11 * ndirY + M21 * ndirZ, M02 * ndirX + M12 * ndirY + M22 * ndirZ);
        }

        public Matrix3 RotateZ(float angle) {
            float sin = (float)Math.Sin(angle);
            float cos = CosFromSin(sin, angle);
            float rm10 = -sin;
            return new Matrix3(
                M00 * cos + M10 * sin, M01 * cos + M11 * sin, M02 * cos + M12 * sin,
                M00 * rm10 + M10 * cos, M01 * rm10 + M11 * cos, M02 * rm10 + M12 * cos,
                M20, M21, M22);
        }

        /// <summary><c>Vector3f.mul(Matrix3fc)</c>.</summary>
        public Vector3 Transform(float x, float y, float z) => new(
            M00 * x + (M10 * y + M20 * z),
            M01 * x + (M11 * y + M21 * z),
            M02 * x + (M12 * y + M22 * z));
    }

    /// <summary>The rotations of JOML's <c>Matrix4f</c> the end sky uses; none has a translation.</summary>
    private readonly record struct Matrix4(float M00, float M01, float M02, float M10, float M11, float M12, float M20, float M21, float M22, bool IsIdentity) {
        public static Matrix4 Identity => new(1, 0, 0, 0, 1, 0, 0, 0, 1, true);

        public static Matrix4 RotationX(float angle) {
            float sin = (float)Math.Sin(angle);
            float cos = CosFromSin(sin, angle);
            return new Matrix4(1, 0, 0, 0, cos, sin, 0, -sin, cos, false);
        }

        public static Matrix4 RotationZ(float angle) {
            float sin = (float)Math.Sin(angle);
            float cos = CosFromSin(sin, angle);
            return new Matrix4(cos, sin, 0, -sin, cos, 0, 0, 0, 1, false);
        }

        /// <summary><c>transformPosition</c>, which leaves the point alone for a matrix flagged as the identity.</summary>
        public Vector3 TransformPosition(float x, float y, float z) => IsIdentity ? new Vector3(x, y, z) : new Vector3(
            M00 * x + (M10 * y + (M20 * z + 0.0F)),
            M01 * x + (M11 * y + (M21 * z + 0.0F)),
            M02 * x + (M12 * y + (M22 * z + 0.0F)));
    }
}
