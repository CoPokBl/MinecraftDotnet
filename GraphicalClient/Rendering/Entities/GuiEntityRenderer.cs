using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Physics;
using Silk.NET.OpenGL;
using EntityPose = Minecraft.Schemas.Entities.EntityPose;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// <c>GuiEntityRenderer</c> with the <c>PictureInPictureRenderer</c> it extends: an entity drawn into a
/// texture the size of its box at the GUI scale, with a depth buffer of its own, then blitted into the GUI.
/// </summary>
public sealed unsafe class GuiEntityRenderer : IDisposable {
    // Lighting.INVENTORY_DIFFUSE_LIGHT_0 and _1, which the ENTITY_IN_UI entry holds untransformed.
    private static readonly Vector3 InventoryDiffuseLight0 = Vector3.Normalize(new Vector3(0.2F, -1.0F, 1.0F));
    private static readonly Vector3 InventoryDiffuseLight1 = Vector3.Normalize(new Vector3(-0.2F, -1.0F, 0.0F));

    private readonly GL _gl;
    private MinecraftClient _client;
    private readonly EntityRenderDispatcher _dispatcher;
    private readonly FlameFeatureRenderer _flames;
    private readonly uint _lightmap;
    private readonly EntityBatch _batch, _translucentBatch;
    private readonly ShaderProgram _shader;
    private readonly Camera _camera = new();
    private uint _framebuffer, _texture, _depth;
    private int _width, _height;

    public GuiEntityRenderer(GL gl, MinecraftClient client, EntityRenderDispatcher dispatcher, EntityTextures textures, FlameFeatureRenderer flames,
        uint lightmap) {
        _gl = gl;
        _client = client;
        _dispatcher = dispatcher;
        _flames = flames;
        _lightmap = lightmap;
        _batch = new EntityBatch(gl, textures);
        _translucentBatch = new EntityBatch(gl, textures);
        _shader = new ShaderProgram(gl, Shaders.EntityInUiVertex, Shaders.EntityInUiFragment);
    }

    /// <summary>Takes up the connection a join makes.</summary>
    public void Attach(MinecraftClient client) => _client = client;

    private EntityRenderContext Context(ClientLevel level) => new() {
        Client = _client, Level = level, Camera = _camera, Batch = _batch, TranslucentBatch = _translucentBatch, PartialTick = 1.0F, Flames = _flames
    };

    /// <summary>
    /// <c>InventoryScreen.extractRenderState</c>: the entity's render state at the end of its tick, or
    /// a bare living state for one drawn as developer art. Null without a level to take it in.
    /// </summary>
    public EntityRenderState? ExtractRenderState(ClientEntity entity) {
        if (_client.Level is not { } level) {
            return null;
        }
        EntityRenderState state = _dispatcher.RendererFor(entity) is { } renderer
            ? renderer.Extract(entity, 1.0F, Context(level))
            : new LivingEntityRenderState {
                Entity = entity, EntityType = entity.Type, BoundingBoxWidth = (float)entity.Width, BoundingBoxHeight = (float)entity.Height,
                Pose = entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing)
            };
        // getBbHeight is the pose's box, which only the local player tracks; anyone else keeps the
        // type's standing box, so a crouching or baby mob sits a little low in the frame.
        if (entity is LocalPlayer player) {
            Box box = player.BoundingBox;
            state.BoundingBoxWidth = (float)(box.MaxX - box.MinX);
            state.BoundingBoxHeight = (float)(box.MaxY - box.MinY);
        }
        return state;
    }

    /// <summary>
    /// <c>GuiGraphicsExtractor.entity</c>, <c>PictureInPictureRenderer.prepare</c> and
    /// <c>GuiEntityRenderer.renderToTexture</c>. <paramref name="cameraXRot"/> is the angle of the
    /// <c>overrideCameraAngle</c> turn about X every caller passes, in degrees.
    /// </summary>
    public void Entity(GuiRenderer gui, EntityRenderState state, float scale, Vector3 translation, Matrix4x4 rotation, float cameraXRot,
        float x0, float y0, float x1, float y1) {
        if (_client.Level is not { } level) {
            return;
        }
        state.SkyLight = 15;
        state.BlockLight = 15;
        int guiScale = gui.Scale;
        int width = (int)(x1 - x0) * guiScale;
        int height = (int)(y1 - y0) * guiScale;
        if (width <= 0 || height <= 0) {
            return;
        }
        gui.Flush();
        PrepareTextures(width, height);

        PoseStack pose = new();
        pose.Translate(width / 2.0F, height / 2.0F, 0.0F);
        float pixels = guiScale * scale;
        pose.Scale(pixels, pixels, -pixels);
        pose.Translate(translation);
        pose.Rotate(rotation);
        // CameraRenderState.orientation = conjugate(overrideCameraAngle).rotateY(PI), which is
        // rotationYXZ(PI, xRot, 0): a camera at yaw 0 and pitch -xRot.
        _camera.Update(Vec3d.Zero, 0.0F, -cameraXRot, 1.0F, 16.0F);
        if (_dispatcher.RendererFor(state.Entity) is { } renderer) {
            renderer.Submit(state, 0.0, 0.0, 0.0, pose, Context(level));
        }
        else if (state is LivingEntityRenderState living) {
            _dispatcher.Fallback.RenderPosed(state.Entity, pose.Matrix, _batch, 1.0F, living.BodyRot, living.BodyRot + living.YRot, living.XRot,
                state.SkyLight, state.BlockLight);
        }
        _batch.Upload();
        _translucentBatch.Upload();

        _gl.BindFramebuffer(FramebufferTarget.Framebuffer, _framebuffer);
        _gl.Viewport(0, 0, (uint)width, (uint)height);
        _gl.DepthMask(true);
        _gl.ClearColor(0, 0, 0, 0);
        _gl.ClearDepth(1.0);
        _gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        _gl.Enable(EnableCap.DepthTest);
        _gl.DepthFunc(DepthFunction.Lequal);
        _gl.Disable(EnableCap.CullFace);
        _gl.Disable(EnableCap.Blend);
        _shader.Use();
        _shader.Set("uSize", new Vector2(width, height));
        _shader.Set("uLight0", InventoryDiffuseLight0);
        _shader.Set("uLight1", InventoryDiffuseLight1);
        _shader.Set("uAtlas", 0);
        _shader.Set("uLightmap", 1);
        _gl.BindTextureUnit(0, _batch.Textures.Handle);
        _gl.BindTextureUnit(1, _lightmap);
        _batch.Draw();
        _gl.Enable(EnableCap.Blend);
        _gl.BlendFuncSeparate(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha, BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha);
        _translucentBatch.Draw();

        _gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        _gl.Viewport(0, 0, (uint)gui.Width, (uint)gui.Height);
        _gl.DepthFunc(DepthFunction.Less);
        _gl.Disable(EnableCap.DepthTest);
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        gui.TexturedPremultiplied(_texture, x0, y0, x1 - x0, y1 - y0, 0.0F, 1.0F, 1.0F, 0.0F);
    }

    private void PrepareTextures(int width, int height) {
        if (_framebuffer != 0 && _width == width && _height == height) {
            return;
        }
        DeleteTextures();
        _width = width;
        _height = height;
        _texture = _gl.CreateTexture(TextureTarget.Texture2D);
        _gl.TextureStorage2D(_texture, 1, SizedInternalFormat.Rgba8, (uint)width, (uint)height);
        _gl.TextureParameter(_texture, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        _gl.TextureParameter(_texture, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        _depth = _gl.CreateRenderbuffer();
        _gl.NamedRenderbufferStorage(_depth, InternalFormat.DepthComponent32f, (uint)width, (uint)height);
        _framebuffer = _gl.CreateFramebuffer();
        _gl.NamedFramebufferTexture(_framebuffer, FramebufferAttachment.ColorAttachment0, _texture, 0);
        _gl.NamedFramebufferRenderbuffer(_framebuffer, FramebufferAttachment.DepthAttachment, RenderbufferTarget.Renderbuffer, _depth);
    }

    private void DeleteTextures() {
        if (_framebuffer == 0) {
            return;
        }
        _gl.DeleteFramebuffer(_framebuffer);
        _gl.DeleteRenderbuffer(_depth);
        _gl.DeleteTexture(_texture);
        _framebuffer = 0;
    }

    public void Dispose() {
        DeleteTextures();
        _batch.Dispose();
        _translucentBatch.Dispose();
        _shader.Dispose();
    }
}
