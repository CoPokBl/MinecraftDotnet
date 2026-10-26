using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// A block atlas sprite copied into the entity atlas so entity geometry can draw it, kept on whatever
/// frame <see cref="TextureAnimator"/> shows in the texture array.
/// </summary>
public sealed class EntityAtlasSprite {
    private readonly EntityTextures _textures;
    private readonly TextureAnimator _animator;
    private readonly int _layer;
    private readonly bool _placed;
    private int _version;

    public EntityTexture Texture { get; }

    public EntityAtlasSprite(EntityTextures textures, TextureAnimator animator, BlockModels models, Minecraft.Schemas.Identifier sprite)
        : this(textures, animator, models, models.Sprite(sprite)) {
    }

    /// <param name="sprite">A layer of the block texture array, and its pixels before any animation.</param>
    public EntityAtlasSprite(EntityTextures textures, TextureAnimator animator, BlockModels models, (int Layer, TextureImage Still) sprite) {
        _textures = textures;
        _animator = animator;
        _layer = sprite.Layer;
        int size = models.Textures.Size;
        EntityTexture? placed = textures.GetNow("block_layer:" + sprite.Layer, () => sprite.Still.Resized(size));
        _placed = placed != null;
        Texture = placed ?? textures.Missing;
    }

    /// <summary>Copies the layer's frame across when it has moved on; once a frame, before the entity atlas uploads.</summary>
    public void Update() {
        (byte[]? pixels, int version) = _animator.Showing(_layer);
        if (!_placed || pixels == null || version == _version) {
            return;
        }
        _version = version;
        _textures.Replace(Texture, (byte[])pixels.Clone());
    }
}

/// <summary><c>FlameFeatureRenderer</c>: the fire round a burning entity, <c>fire_0</c> and <c>fire_1</c> stacked up its height.</summary>
public sealed class FlameFeatureRenderer(EntityAtlasSprite fire0, EntityAtlasSprite fire1) {
    /// <summary>Brings both sprites to the frame the texture array shows; after each animator tick.</summary>
    public void Update() {
        fire0.Update();
        fire1.Update();
    }

    /// <summary>
    /// <c>EntityRenderDispatcher.submit</c>'s flame, lit at full block light as <c>LightCoordsUtil.withBlock(lightCoords, 15)</c>
    /// lights it. <paramref name="pose"/> is at the entity's feet, render offset included, and turns here by the camera's yaw.
    /// </summary>
    public void Submit(PoseStack pose, float boundingBoxWidth, float boundingBoxHeight, float skyLight, Camera camera, EntityBatch batch) {
        pose.Push();
        float s = boundingBoxWidth * 1.4F;
        pose.Scale(s, s, s);
        float r = 0.5F;
        float h = boundingBoxHeight / s;
        float yo = 0.0F;
        pose.RotateY(MathF.PI - camera.Yaw * (MathF.PI / 180.0F));
        pose.Translate(0.0F, 0.0F, 0.3F - (int)h * 0.02F);
        float zo = 0.0F;
        Matrix4x4 matrix = pose.Matrix;
        // setNormal(pose, 0, 1, 0): up through the pose, which a GUI doll's turns.
        Vector3 normal = pose.TransformNormal(Vector3.UnitY);
        Span<Vector3> corners = stackalloc Vector3[4];
        Span<Vector2> uvs = stackalloc Vector2[4];
        for (int ss = 0; h > 0.0F; ss++) {
            EntityTexture tex = (ss % 2 == 0 ? fire0 : fire1).Texture;
            float u0 = 0, v0 = 0, u1 = 1, v1 = 1;
            if (ss / 2 % 2 == 0) {
                (u0, u1) = (u1, u0);
            }
            corners[0] = Vector3.Transform(new Vector3(-r - 0.0F, 0.0F - yo, zo), matrix);
            corners[1] = Vector3.Transform(new Vector3(r - 0.0F, 0.0F - yo, zo), matrix);
            corners[2] = Vector3.Transform(new Vector3(r - 0.0F, 1.4F - yo, zo), matrix);
            corners[3] = Vector3.Transform(new Vector3(-r - 0.0F, 1.4F - yo, zo), matrix);
            uvs[0] = new Vector2(u1, v1);
            uvs[1] = new Vector2(u0, v1);
            uvs[2] = new Vector2(u0, v0);
            uvs[3] = new Vector2(u1, v0);
            batch.Quad(corners, uvs, normal, new ModelDrawState(tex, 0xFFFFFFFF, skyLight, 15, 0));
            h -= 0.45F;
            yo -= 0.45F;
            r *= 0.9F;
            zo -= 0.03F;
        }
        pose.Pop();
    }
}
