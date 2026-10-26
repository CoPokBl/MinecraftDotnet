using System.Numerics;

namespace GraphicalClient.Rendering;

/// <summary>
/// An orthographic view along the light, sun by day and moon by night, centred on a point that
/// follows the camera in steps of a section. Between steps the view stays fixed in the world, so a
/// shadow map stays valid while the camera moves and is only drawn again when the light, the
/// centre or the terrain changes. The centre is also snapped to the map's texel grid, so a step
/// does not make the shadows of things that stand still crawl.
/// </summary>
public sealed class ShadowCamera {
    /// <summary>What a rendered shadow map depends on; while it is unchanged the last one is reused.</summary>
    private readonly record struct Key(long X, long Y, long Z, Vector3 Light, int Geometry, int MapSize, float Distance);

    private Key? _rendered;

    /// <summary>Forgets the last map, so the next frame draws one.</summary>
    public void Invalidate() => _rendered = null;

    /// <summary>The sun's direction, tilted about the east west axis by a pack's sun path rotation.</summary>
    public static Vector3 SunDirection(Vector3 sun, float rotationDegrees) {
        float tilt = rotationDegrees * MathF.PI / 180.0F;
        return tilt == 0 ? sun : new Vector3(sun.X, sun.Y * MathF.Cos(tilt), -sun.Y * MathF.Sin(tilt));
    }

    /// <summary>The unit vector toward the light the map is drawn along: the sun by day, the moon by night.</summary>
    public static Vector3 LightDirection(Vector3 sun) {
        Vector3 light = sun.Y >= 0 ? sun : -sun;
        // A light at the horizon would stretch shadows across the whole map; hold it a little above.
        return light.Y < 0.15F ? Vector3.Normalize(new Vector3(light.X, 0.15F, light.Z)) : light;
    }

    /// <returns>Whether the map needs drawing this frame: always when <paramref name="always"/>, otherwise only when it is stale.</returns>
    public bool Update(Camera camera, Vector3 sun, float distance, int mapSize, int geometryVersion, bool always, out Matrix4x4 view, out Matrix4x4 projection) {
        Vector3 light = LightDirection(sun);
        Vector3 up = Math.Abs(light.Y) > 0.99F ? Vector3.UnitZ : Vector3.UnitY;
        Matrix4x4 lookAt = Matrix4x4.CreateLookAt(light * distance * 2, Vector3.Zero, up);

        long cx = (long)Math.Floor(camera.Position.X / 16) * 16 + 8;
        long cy = (long)Math.Floor(camera.Position.Y / 16) * 16 + 8;
        long cz = (long)Math.Floor(camera.Position.Z / 16) * 16 + 8;
        float texel = distance * 2 / mapSize;
        Vector3 worldOrigin = new(-(cx % 4096), -(cy % 4096), -(cz % 4096));
        Vector3 projected = Vector3.Transform(worldOrigin, lookAt);
        float snapX = projected.X - MathF.Floor(projected.X / texel) * texel;
        float snapY = projected.Y - MathF.Floor(projected.Y / texel) * texel;

        // Positions arrive camera relative; moving them to centre relative first keeps the view fixed in the world.
        view = Matrix4x4.CreateTranslation((float)(camera.Position.X - cx), (float)(camera.Position.Y - cy), (float)(camera.Position.Z - cz))
            * lookAt * Matrix4x4.CreateTranslation(-snapX, -snapY, 0);
        projection = Frustum.Orthographic(distance, distance * 4);
        Key key = new(cx, cy, cz, light, geometryVersion, mapSize, distance);
        if (!always && _rendered == key) {
            return false;
        }
        _rendered = key;
        return true;
    }
}
