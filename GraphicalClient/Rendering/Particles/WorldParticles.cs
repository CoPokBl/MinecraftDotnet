using System.Numerics;
using ClientLib;
using ClientLib.Particles;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Vanilla;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Particles;

/// <summary>
/// The drawing half of the particle engine: the quads, the item pickups and the elder guardian's curse. The
/// client's <see cref="ParticleEngine"/> simulates the quads; this enables it, colours it, and draws what it holds.
/// </summary>
public sealed class WorldParticles : IDisposable {
    private MinecraftClient _client;
    private readonly ParticleRenderer _quads;
    private readonly ItemPickupParticleGroup _pickups = new();
    private readonly EntityTextures _textures;
    private readonly ModelPart _elderGuardian = GuardianModel.CreateElderGuardianLayer().BakeRoot();
    private readonly ParticleColours _colours;
    private readonly bool _hasPack;
    private float _partialTick;

    public ParticleRenderer Quads => _quads;

    public WorldParticles(GL gl, MinecraftClient client, EntityTextures textures, BlockModels models, ItemRenderer items, ResourcePackSource? pack,
        BiomeColours.ColourMaps? colourMaps) {
        _client = client;
        _textures = textures;
        _hasPack = pack != null;
        _quads = new ParticleRenderer(gl, new ParticleSprites(textures, pack), textures, models, items);
        _colours = new ParticleColours(() => _client, colourMaps);
        Hook();
    }

    /// <summary>Takes up the connection a join makes; the old one's pickups go with it.</summary>
    public void Attach(MinecraftClient client) {
        ParticleEngine old = _client.Particles;
        old.BeforeTick = null;
        old.AfterTick = null;
        old.Clear();
        _client = client;
        _pickups.Clear();
        Hook();
    }

    private void Hook() {
        ParticleEngine engine = _client.Particles;
        engine.Enabled = true;
        engine.Colours = _colours;
        engine.Asynchronous = true;
        engine.BeforeTick = (joining, _) => _quads.Prepare(engine, joining, engine.CameraPosition ?? ClientLib.Maths.Vec3d.Zero);
        engine.AfterTick = _quads.Build;
    }

    /// <summary><c>ParticleEngine.setLevel</c> for the pickups; the engine clears its own.</summary>
    public void ClearPickups() => _pickups.Clear();

    public void AddPickup(ItemPickupParticle particle) => _pickups.Add(particle);

    /// <summary>After the client's tick, which has started the engine's: the pickups tick.</summary>
    public void Tick() {
        if (_client.Level is { TickRateManager.RunsNormally: true }) {
            _pickups.Tick();
        }
    }

    /// <summary>The frame's pickups and elder guardians, into the entity batches; the camera the engine measures distance from.</summary>
    public void Collect(EntityRenderContext context, EntityBatch translucent) {
        _client.Particles.CameraPosition = context.Camera.Position;
        _client.Particles.Publish();
        // DeltaTracker's world partial tick holds at 1 while the tick rate is frozen, so a still particle stays put.
        _partialTick = context.Level.TickRateManager.RunsNormally ? context.PartialTick : 1.0F;
        _pickups.Render(context, _partialTick);
        CollectElderGuardians(context, translucent);
    }

    /// <summary>
    /// <c>ElderGuardianParticleGroup</c>: the elder guardian's model swinging up in front of the camera, fading in and
    /// out, lit fully. It needs the model's texture, so the built in art draws nothing.
    /// </summary>
    private void CollectElderGuardians(EntityRenderContext context, EntityBatch batch) {
        if (!_hasPack || _textures.Get(ElderGuardianRenderer.GuardianElderLocation) is not { } texture || ReferenceEquals(texture, _textures.Pending)) {
            return;
        }
        Matrix4x4.Invert(context.Camera.View, out Matrix4x4 inverseView);
        foreach (ParticleState particle in _client.Particles.ElderGuardians) {
            float ageScale = (particle.Age + _partialTick) / particle.Lifetime;
            float alpha = 0.05F + 0.5F * MathF.Sin(ageScale * MathF.PI);
            PoseStack pose = new(inverseView);
            pose.RotateXDegrees(60.0F - 150.0F * ageScale);
            pose.Scale(0.42553192F, -0.42553192F, -0.42553192F);
            pose.Translate(0.0F, -0.56F, 3.5F);
            uint argb = (uint)Math.Clamp((int)(alpha * 255.0F), 0, 255) << 24 | 0xFFFFFF;
            _elderGuardian.Render(pose, batch, new ModelDrawState(texture, argb, 15, 15, 0));
        }
    }

    public void Upload(Camera camera) => _quads.Upload(camera.Position, _partialTick, _client.Particles.TickCount);

    public void Dispose() => _quads.Dispose();
}
