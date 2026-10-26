using System.Numerics;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>One quad for <see cref="IconRasterizer"/>: corners in item model space, 0 to 1 across the block, and what it is painted with.</summary>
public readonly record struct IconQuad(Vector3[] Positions, Vector2[] Uvs, TextureImage Image, uint Tint);

/// <summary>
/// Draws a model into a square image the way <c>GuiItemAtlas</c> draws an item into its slot: the
/// model's <c>gui</c> transform, an orthographic view, and the two directional lights vanilla's item
/// shaders mix (<c>Lighting</c>'s <c>ITEMS_3D</c> or <c>ITEMS_FLAT</c> pose). A small software
/// rasteriser, as the icons are drawn once at startup.
/// </summary>
public static class IconRasterizer {
    private static readonly (Vector3 A, Vector3 B) SideLights = Lights(
        Mat3Scale(1, -1, 1) * Mat3.RotationY(1.0821041F * 180 / MathF.PI) * Mat3.RotationX(3.2375858F * 180 / MathF.PI)
        * Mat3.RotationY(-22.5F) * Mat3.RotationX(135));

    private static readonly (Vector3 A, Vector3 B) FrontLights = Lights(Mat3.RotationY(-22.5F) * Mat3.RotationX(135));

    private static Mat3 Mat3Scale(float x, float y, float z) => new(x, 0, 0, 0, y, 0, 0, 0, z);

    private static (Vector3, Vector3) Lights(Mat3 pose) => (
        Vector3.Normalize(pose.Transform(Vector3.Normalize(new Vector3(0.2F, 1.0F, -0.7F)))),
        Vector3.Normalize(pose.Transform(Vector3.Normalize(new Vector3(-0.2F, 1.0F, 0.7F)))));

    public static TextureImage Render(List<IconQuad> quads, ItemTransform gui, bool sideLit, int size) {
        // ItemTransform.apply: translate, rotate by XYZ (JOML's rotationXYZ, so Z turns first), scale, then
        // move the block's centre to the origin. The slot's own scale flips y.
        Mat3 rotation = Mat3.RotationX(gui.Rotation.X) * Mat3.RotationY(gui.Rotation.Y) * Mat3.RotationZ(gui.Rotation.Z);
        Mat3 pose = rotation * Mat3Scale(gui.Scale.X, gui.Scale.Y, gui.Scale.Z);
        Mat3 flip = Mat3Scale(1, -1, 1);
        (Vector3 lightA, Vector3 lightB) = sideLit ? SideLights : FrontLights;

        byte[] rgba = new byte[size * size * 4];
        float[] depth = new float[size * size];
        Array.Fill(depth, float.NegativeInfinity);
        Span<Vector3> screen = stackalloc Vector3[4];
        foreach (IconQuad quad in quads) {
            for (int i = 0; i < 4; i++) {
                Vector3 view = gui.Translation + pose.Transform(quad.Positions[i] - new Vector3(0.5F));
                screen[i] = new Vector3(size / 2.0F + view.X * size, size / 2.0F - view.Y * size, view.Z);
            }
            Vector3 normal = Vector3.Cross(quad.Positions[1] - quad.Positions[0], quad.Positions[2] - quad.Positions[0]);
            Vector3 turned = Vector3.Normalize(rotation.Transform(normal));
            if (turned.Z <= 0) {
                continue;
            }
            // minecraft_mix_light, in the slot's flipped space where the light directions are given.
            Vector3 n = flip.Transform(turned);
            float light = Math.Min(1.0F, 0.4F + 0.6F * (Math.Max(0, Vector3.Dot(lightA, n)) + Math.Max(0, Vector3.Dot(lightB, n))));
            Triangle(screen[0], screen[1], screen[2], quad.Uvs[0], quad.Uvs[1], quad.Uvs[2], quad.Image, quad.Tint, light, rgba, depth, size);
            Triangle(screen[2], screen[3], screen[0], quad.Uvs[2], quad.Uvs[3], quad.Uvs[0], quad.Image, quad.Tint, light, rgba, depth, size);
        }
        return new TextureImage(size, size, rgba);
    }

    private static void Triangle(Vector3 a, Vector3 b, Vector3 c, Vector2 ua, Vector2 ub, Vector2 uc, TextureImage image, uint tint, float light,
        byte[] rgba, float[] depth, int size) {
        float area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        if (MathF.Abs(area) < 1e-6F) {
            return;
        }
        int minX = Math.Max(0, (int)MathF.Floor(MathF.Min(a.X, MathF.Min(b.X, c.X))));
        int maxX = Math.Min(size - 1, (int)MathF.Ceiling(MathF.Max(a.X, MathF.Max(b.X, c.X))));
        int minY = Math.Max(0, (int)MathF.Floor(MathF.Min(a.Y, MathF.Min(b.Y, c.Y))));
        int maxY = Math.Min(size - 1, (int)MathF.Ceiling(MathF.Max(a.Y, MathF.Max(b.Y, c.Y))));
        float tr = (tint >> 16 & 0xFF) / 255.0F * light, tg = (tint >> 8 & 0xFF) / 255.0F * light, tb = (tint & 0xFF) / 255.0F * light;
        for (int y = minY; y <= maxY; y++) {
            for (int x = minX; x <= maxX; x++) {
                float px = x + 0.5F, py = y + 0.5F;
                float w0 = ((b.X - px) * (c.Y - py) - (b.Y - py) * (c.X - px)) / area;
                float w1 = ((c.X - px) * (a.Y - py) - (c.Y - py) * (a.X - px)) / area;
                float w2 = 1 - w0 - w1;
                if (w0 < 0 || w1 < 0 || w2 < 0) {
                    continue;
                }
                float z = w0 * a.Z + w1 * b.Z + w2 * c.Z;
                int at = y * size + x;
                if (z < depth[at]) {
                    continue;
                }
                Vector2 uv = w0 * ua + w1 * ub + w2 * uc;
                int tx = Math.Clamp((int)(uv.X * image.Width), 0, image.Width - 1);
                int ty = Math.Clamp((int)(uv.Y * image.Height), 0, image.Height - 1);
                int t = (ty * image.Width + tx) * 4;
                int alpha = image.Rgba[t + 3];
                if (alpha == 0) {
                    continue;
                }
                int o = at * 4;
                float blend = alpha / 255.0F;
                rgba[o] = (byte)(image.Rgba[t] * tr * blend + rgba[o] * (1 - blend));
                rgba[o + 1] = (byte)(image.Rgba[t + 1] * tg * blend + rgba[o + 1] * (1 - blend));
                rgba[o + 2] = (byte)(image.Rgba[t + 2] * tb * blend + rgba[o + 2] * (1 - blend));
                rgba[o + 3] = (byte)Math.Min(255, alpha + rgba[o + 3] * (1 - blend));
                if (alpha == 255) {
                    depth[at] = z;
                }
            }
        }
    }
}
