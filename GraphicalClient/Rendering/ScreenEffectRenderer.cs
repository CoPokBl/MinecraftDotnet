using System.Numerics;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>ScreenEffectRenderer</c>: what is drawn over the view in first person. Vanilla submits its quads in
/// the hand's projection with no model view; here they are projected on the CPU and drawn through the
/// GUI renderer, under the HUD, with the same blending as <c>GUI_TEXTURED</c>.
/// </summary>
public sealed class ScreenEffectRenderer : IDisposable {
    // The quads lean away from the view, so their texture is not affine on screen. Each is cut into a
    // grid this fine and each cell drawn affine: the fire quads' depth changes by about 4% across a
    // cell, which puts a cell's middle within a fiftieth of a texel of where perspective puts it.
    private const int Grid = 8;

    private readonly GL _gl;
    private readonly EntityAtlasSprite _fire;
    private readonly EntityTextures _textures;
    private readonly TextureAnimator _animator;
    private readonly BlockModels _models;
    private readonly uint _atlas;
    private readonly uint _underwater;
    private readonly Dictionary<int, EntityAtlasSprite> _blockSprites = new();

    public ScreenEffectRenderer(GL gl, ResourcePackSource? pack, EntityAtlasSprite fire1, EntityTextures atlas, TextureAnimator animator, BlockModels models) {
        _gl = gl;
        _fire = fire1;
        _textures = atlas;
        _animator = animator;
        _models = models;
        _atlas = atlas.Handle;
        _underwater = CameraOverlays.LoadTexture(gl, pack, "assets/minecraft/textures/misc/underwater.png", DevArt.Underwater, false);
    }

    /// <summary>Brings the block sprites shown so far to the frame the texture array shows; after each animator tick.</summary>
    public void Update() {
        foreach (EntityAtlasSprite sprite in _blockSprites.Values) {
            sprite.Update();
        }
    }

    /// <summary><c>submit</c>, without the item activation animation, which this client does not play.</summary>
    /// <param name="skyDarkening"><c>Level.getSkyDarken</c>, which the underwater overlay's brightness takes.</param>
    public void Render(GuiRenderer gui, LocalPlayer player, ClientLevel level, Camera camera, bool isFirstPerson, bool isSleeping, int skyDarkening) {
        if (!isFirstPerson || isSleeping) {
            return;
        }
        Matrix4x4 projection = HudProjection(gui, camera.HudFovDegrees);
        if (player.ViewBlockingState() is { } blockState) {
            SubmitBlockSprite(gui, projection, BlockSprite(blockState.StateId).Texture, 0xFF191919);
        }
        if (!player.IsSpectator) {
            if (player.Fluids.EyeInWater) {
                SubmitWater(gui, projection, player, level, skyDarkening);
            }
            if (player.IsOnFire) {
                SubmitFire(gui, projection, _fire.Texture);
            }
        }
        gui.Flush();
    }

    /// <summary>The particle sprite of a block state, copied into the entity atlas the first time the eyes are in one.</summary>
    private EntityAtlasSprite BlockSprite(uint stateId) {
        (int Layer, TextureImage Image) particle = _models.Particle(stateId);
        if (!_blockSprites.TryGetValue(particle.Layer, out EntityAtlasSprite? sprite)) {
            sprite = new EntityAtlasSprite(_textures, _animator, _models, particle);
            _blockSprites[particle.Layer] = sprite;
        }
        return sprite;
    }

    /// <summary><c>Projection.setupPerspective(0.05, 100, hudFov, width, height)</c>.</summary>
    private static Matrix4x4 HudProjection(GuiRenderer gui, float fovDegrees) =>
        Matrix4x4.CreatePerspectiveFieldOfView(fovDegrees * (MathF.PI / 180.0F), (float)gui.Width / Math.Max(1, gui.Height), 0.05F, 100.0F);

    /// <summary><c>submitBlockSprite</c>.</summary>
    private void SubmitBlockSprite(GuiRenderer gui, Matrix4x4 projection, EntityTexture sprite, uint argb) =>
        BuildSpriteQuad(gui, projection, sprite, -1.0F, -1.0F, 1.0F, 1.0F, -0.5F, argb);

    /// <summary><c>submitWater</c>: the overlay tiles four times across and slides as the view turns.</summary>
    private void SubmitWater(GuiRenderer gui, Matrix4x4 projection, LocalPlayer player, ClientLevel level, int skyDarkening) {
        int x = (int)Math.Floor(player.Position.X), y = (int)Math.Floor(player.Position.Y + player.CurrentEyeHeight), z = (int)Math.Floor(player.Position.Z);
        float brightness = ClientLib.World.Lightmap.Brightness(level.DimensionType.AmbientLight, level.MaxLocalRawBrightness(x, y, z, skyDarkening));
        uint channel = (uint)(int)Math.Floor(brightness * 255.0F);
        uint color = (uint)(int)Math.Floor(0.1F * 255.0F) << 24 | channel << 16 | channel << 8 | channel;
        float u0 = -player.YRot / 64.0F;
        float v0 = player.XRot / 64.0F;
        BuildQuad(gui, _underwater, projection, -1.0F, -1.0F, 1.0F, 1.0F, -0.5F, u0 + 4.0F, v0 + 4.0F, u0, v0, color);
    }

    /// <summary><c>submitFire</c>.</summary>
    private void SubmitFire(GuiRenderer gui, Matrix4x4 projection, EntityTexture sprite) {
        Matrix4x4 pose = Matrix4x4.CreateRotationY(-MathF.PI / 18) * Matrix4x4.CreateTranslation(0.24F, -0.3F, 0.0F);
        BuildFireQuad(gui, sprite, pose * projection);
        pose = Matrix4x4.CreateRotationY(MathF.PI / 18) * Matrix4x4.CreateTranslation(-0.24F, -0.3F, 0.0F);
        BuildFireQuad(gui, sprite, pose * projection);
    }

    private void BuildFireQuad(GuiRenderer gui, EntityTexture sprite, Matrix4x4 transform) =>
        BuildSpriteQuad(gui, transform, sprite, -0.5F, -0.5F, 0.5F, 0.5F, -0.5F, 0xE5FFFFFF);

    private void BuildSpriteQuad(GuiRenderer gui, Matrix4x4 transform, EntityTexture sprite, float x0, float y0, float x1, float y1, float z, uint argb) =>
        BuildQuad(gui, _atlas, transform, x0, y0, x1, y1, z, sprite.U(1), sprite.V(1), sprite.U(0), sprite.V(0), argb);

    /// <summary><c>buildQuad</c>: (x0, y0) takes (u0, v0) and (x1, y1) takes (u1, v1).</summary>
    private static void BuildQuad(GuiRenderer gui, uint texture, Matrix4x4 transform, float x0, float y0, float x1, float y1, float z,
        float u0, float v0, float u1, float v1, uint argb) {
        Span<Vector2> corners = stackalloc Vector2[4];
        Span<Vector2> uvs = stackalloc Vector2[4];
        for (int j = 0; j < Grid; j++) {
            for (int i = 0; i < Grid; i++) {
                for (int c = 0; c < 4; c++) {
                    float s = (i + (c is 1 or 2 ? 1 : 0)) / (float)Grid;
                    float t = (j + (c is 2 or 3 ? 1 : 0)) / (float)Grid;
                    Vector4 clip = Vector4.Transform(new Vector4(x0 + (x1 - x0) * s, y0 + (y1 - y0) * t, z, 1.0F), transform);
                    corners[c] = new Vector2((clip.X / clip.W + 1.0F) * 0.5F * gui.Width, (1.0F - clip.Y / clip.W) * 0.5F * gui.Height);
                    uvs[c] = new Vector2(u0 + (u1 - u0) * s, v0 + (v1 - v0) * t);
                }
                gui.ScreenQuad(texture, corners, uvs, argb);
            }
        }
    }

    public void Dispose() => _gl.DeleteTexture(_underwater);
}
