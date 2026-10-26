using System.Numerics;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// <c>TextureTransform.OffsetTextureTransform</c> over a repeating texture, the energy swirl's and the
/// breeze wind's: a model's quads with their texture coordinates moved by an offset of less than one
/// repeat each way. Drawn whole from <paramref name="tiled"/>, the texture three by three, when it is
/// ready; cut at each repeat of the texture itself until then.
/// </summary>
public sealed class ScrollingSink(EntityBatch batch, Vector2 offset, EntityTexture? tiled) : IModelSink {
    public const int Tiles = 3;

    public void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw) {
        if (tiled == null) {
            batch.RepeatingQuad(corners, [uvs[0] + offset, uvs[1] + offset, uvs[2] + offset, uvs[3] + offset], normal, draw);
            return;
        }
        // A model's coordinates lie within its texture, so with the offset they lie within one repeat either side.
        Vector2 shift = offset + Vector2.One;
        batch.Quad(corners, [(uvs[0] + shift) / Tiles, (uvs[1] + shift) / Tiles, (uvs[2] + shift) / Tiles, (uvs[3] + shift) / Tiles], normal,
            draw with { Texture = tiled });
    }
}
