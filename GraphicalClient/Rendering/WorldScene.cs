using ClientLib;
using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;
using GraphicalClient.Rendering.Particles;
using GraphicalClient.Rendering.Pipeline;
using GraphicalClient.Rendering.Weather;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Everything in the world besides the terrain, gathered on the CPU each frame into the batches the
/// shader pack's passes draw by geometry name.
/// </summary>
public sealed class WorldScene : IGeometryDrawer, IDisposable {
    private MinecraftClient _client;
    private readonly Camera _camera;
    private readonly WorldRenderer _world;
    private readonly OverlayRenderer _overlay;
    private readonly EntityBatch _entityBatch, _crumblingBatch, _translucentBatch, _additiveBatch, _waterMaskBatch, _handBatch, _glintBatch, _handGlintBatch, _outlineBatch;
    private readonly CrumblingRenderer _crumbling;
    private readonly EndPortalRenderer _endPortals;
    private readonly ItemInHandRenderer _itemInHand;

    /// <summary>What casts into a shadow map from out of view: entities beside the screen, and the player in first person.</summary>
    private readonly EntityBatch _casterBatch;
    private readonly TextDisplayBatch _textDisplays;
    private readonly EntityShadows _entityShadows;

    public EntityTextures Textures { get; }
    public EntityRenderDispatcher Entities { get; }
    public BlockEntityRenderDispatcher BlockEntities { get; }
    public FlameFeatureRenderer Flames { get; }
    public ScreenEffectRenderer ScreenEffects { get; }
    public CameraOverlays CameraOverlays { get; }
    public WorldParticles Particles { get; }
    public WeatherRenderer Weather { get; }
    public CloudRenderer Clouds { get; }
    public uint EndSkyTexture => _endPortals.SkyTexture;
    public uint EndPortalTexture => _endPortals.PortalTexture;

    /// <summary>
    /// The <c>entityShadows</c> option: the round shadows under entities, and entities drawn from the shadow
    /// camera at all. Off, both the <c>entity_shadows</c> geometry and <c>entities</c> seen from the shadow camera are empty.
    /// </summary>
    public bool ShowEntityShadows { get; set; } = true;

    /// <summary>
    /// The unit vector toward the light while a pass draws <c>entities</c> from the shadow camera, so entities out of
    /// view whose shadow may be in it are drawn for it too; null otherwise.
    /// </summary>
    public System.Numerics.Vector3? ShadowCasterLight { get; set; }

    /// <summary>The background of a text display that asks for the default one.</summary>
    public uint DefaultTextBackground {
        set => _textDisplays.DefaultBackground = value;
    }

    /// <summary><c>Window.getAppropriateLineWidth</c>, which the frame's lines are drawn at.</summary>
    public float LineWidth {
        get => _overlay.LineWidth;
        set => _overlay.LineWidth = value;
    }

    public WorldScene(GL gl, MinecraftClient client, Camera camera, WorldRenderer world, BlockModels models, TextureAnimator animator,
        ResourcePackSource? pack, DevArtSource art, EnchantmentGlint glint, ItemModelResolver resolver, Gui.Font font) {
        _client = client;
        _camera = camera;
        _world = world;
        _overlay = new OverlayRenderer(gl);
        Textures = new EntityTextures(gl, pack);
        Assets.Skins.SkinManager.Client = client;
        _glintBatch = new EntityBatch(gl, Textures) { Glint = glint };
        _handGlintBatch = new EntityBatch(gl, Textures) { Glint = glint };
        _outlineBatch = new EntityBatch(gl, Textures) { IsOutline = true };
        _entityBatch = new EntityBatch(gl, Textures) { Glints = _glintBatch, Outlines = _outlineBatch };
        _crumblingBatch = new EntityBatch(gl, Textures);
        _translucentBatch = new EntityBatch(gl, Textures) { Glints = _glintBatch, Outlines = _outlineBatch };
        _additiveBatch = new EntityBatch(gl, Textures);
        _waterMaskBatch = new EntityBatch(gl, Textures);
        _handBatch = new EntityBatch(gl, Textures) { Glints = _handGlintBatch };
        _casterBatch = new EntityBatch(gl, Textures);
        _textDisplays = new TextDisplayBatch(gl, font, Textures);
        _entityShadows = new EntityShadows(gl, Textures);
        _crumbling = new CrumblingRenderer(pack, Textures);
        _endPortals = new EndPortalRenderer(gl, pack);
        Weather = new WeatherRenderer(gl, pack);
        Clouds = new CloudRenderer(gl, pack);
        EntityAtlasSprite fire0 = new(Textures, animator, models, BlockModels.Fire0);
        EntityAtlasSprite fire1 = new(Textures, animator, models, BlockModels.Fire1);
        Flames = new FlameFeatureRenderer(fire0, fire1);
        ScreenEffects = new ScreenEffectRenderer(gl, pack, fire1, Textures, animator, models);
        CameraOverlays = new CameraOverlays(gl, pack, Textures, animator, models);
        ItemRenderer items = new(pack, art, Textures, resolver);
        // Models need the pack's textures; without them every mob is the built in art. Dropped items
        // still draw, as their icons.
        WorldText worldText = new(font, Textures);
        MapRenderer maps = new(Textures, worldText);
        Dictionary<IEntityType, EntityRenderer> renderers = pack != null
            ? EntityRenderers.CreateAll(new EntityRendererContext { Items = items, Blocks = new BlockModelRenderer(pack, Textures), Pack = pack, Maps = maps },
                Console.WriteLine)
            : new() { [EntityType.Item] = new ItemEntityRenderer(items), [EntityType.TextDisplay] = new DisplayRenderer.TextDisplayRenderer() };
        Entities = new EntityRenderDispatcher(renderers, new DevArtEntities(art));
        BlockEntities = new BlockEntityRenderDispatcher(BlockEntityRenderers.CreateAll(new BlockEntityRendererContext {
            Sprites = new EntityTextureSprites(Textures, sprite => pack?.LoadFirstFrame(sprite.PackPath) ?? DevArtSprites.Image(sprite)),
            Items = items, Blocks = new BlockModelRenderer(pack, Textures), Entities = Entities, Font = worldText,
            RenderDistance = () => _world.RenderDistance
        }));
        Particles = new WorldParticles(gl, client, Textures, models, items, pack, world.ColourMaps);
        _itemInHand = new ItemInHandRenderer(items, maps, () => _client.Player is { } local ? Entities.RendererFor(local) as IFirstPersonArmRenderer : null);
    }

    /// <summary>Takes up the connection a join makes; the old one's pickups go with it.</summary>
    public void Attach(MinecraftClient client) {
        _client = client;
        Assets.Skins.SkinManager.Client = client;
        Particles.Attach(client);
        HookClient();
    }

    public void HookClient() {
        _client.LevelChanged += ClearPickups;
        _client.EntityTaken += TakeEntity;
        _client.PacketReceived += HandleEntityEvent;
    }

    /// <summary>Lets go of the client, for a resource reload that replaces this scene.</summary>
    public void UnhookClient() {
        _client.LevelChanged -= ClearPickups;
        _client.EntityTaken -= TakeEntity;
        _client.PacketReceived -= HandleEntityEvent;
    }

    private void ClearPickups(ClientLevel _) => Particles.ClearPickups();

    private void HandleEntityEvent(Minecraft.Packets.MinecraftPacket packet) {
        if (packet is ClientBoundEntityEventPacket entityEvent) {
            Entities.HandleEntityEvent(_client, entityEvent.EntityId, (byte)entityEvent.Status);
        }
    }

    public void Tick() {
        Entities.Tick(_client);
        Particles.Tick();
        if (_client.Player is { } player) {
            _itemInHand.Tick(player);
        }
    }

    /// <summary>Entities, the hand, the block outline and dig cracks for this frame.</summary>
    /// <summary>Stopwatch ticks <see cref="Collect"/> has spent on entities, block entities and particles, for <c>--verbose</c> to read and clear.</summary>
    public long[] CollectTicks { get; } = new long[3];

    public void Collect(ClientLevel level, float partialTick, ClientEntity cameraEntity, bool firstPerson, bool hideGui) {
        _textDisplays.Begin(Frustum.FromMatrix(_camera.View * _camera.CullProjection));
        _entityShadows.Begin();
        EntityRenderContext context = new() {
            Client = _client, Level = level, Camera = _camera, Batch = _entityBatch, TranslucentBatch = _translucentBatch, PartialTick = partialTick,
            Flames = Flames, WaterMaskBatch = _waterMaskBatch, AdditiveBatch = _additiveBatch, Lines = _overlay,
            FirstPerson = firstPerson, Shadows = ShowEntityShadows ? _entityShadows : null, TextDisplays = _textDisplays, HideGui = hideGui
        };
        ShadowCasters? casters = ShowEntityShadows && ShadowCasterLight is { } light
            ? new ShadowCasters(new EntityRenderContext {
                Client = _client, Level = level, Camera = _camera, Batch = _casterBatch, TranslucentBatch = _casterBatch, PartialTick = partialTick,
                FirstPerson = firstPerson
            }, light)
            : null;
        long start = System.Diagnostics.Stopwatch.GetTimestamp();
        Entities.Render(context, cameraEntity, !firstPerson, casters);
        long entitiesDone = System.Diagnostics.Stopwatch.GetTimestamp();
        BlockEntities.Render(context);
        long blockEntitiesDone = System.Diagnostics.Stopwatch.GetTimestamp();
        Particles.Collect(context, _translucentBatch);
        CollectTicks[0] += entitiesDone - start;
        CollectTicks[1] += blockEntitiesDone - entitiesDone;
        CollectTicks[2] += System.Diagnostics.Stopwatch.GetTimestamp() - blockEntitiesDone;
        _endPortals.Collect(_world.EndPortals, _camera);
        if (firstPerson && !hideGui && _client.Player is { IsSpectator: false } handPlayer && !handPlayer.IsSleeping) {
            RenderHand(level, handPlayer, partialTick);
        }
        if (!hideGui && _client.Interactions.Target is BlockHitResult hit && _client.Player is { IsSpectator: false }) {
            BlockHighlight.Outline(_overlay, level, _camera, hit.X, hit.Y, hit.Z, Picking.HeldItem(cameraEntity));
        }
        if (_client.Interactions.DestroyingBlock is { } digging) {
            Crack(digging.X, digging.Y, digging.Z, _client.Interactions.DestroyStage);
        }
        foreach ((int x, int y, int z, int stage) in _client.DestroyStages.Values) {
            Crack(x, y, z, stage);
        }

        void Crack(int x, int y, int z, int stage) {
            if (!_crumbling.Render(level, _camera, _crumblingBatch, x, y, z, stage)) {
                BlockHighlight.Cracks(_overlay, _camera, x, y, z, stage);
            }
        }
    }

    /// <summary>
    /// <c>GameRenderer.renderItemInHand</c>. The hand is posed in view space, taken back to camera relative
    /// world space so the world's matrices draw it; that takes the camera's hurt tilt and bob with it, as
    /// vanilla applies both to the hand. Vanilla draws it at the HUD's field of view, which the first scale
    /// restores at the view's.
    /// </summary>
    private void RenderHand(ClientLevel level, LocalPlayer player, float partialTick) {
        float k = MathF.Tan(_camera.FovDegrees * MathF.PI / 360.0F) / MathF.Tan(_camera.HudFovDegrees * MathF.PI / 360.0F);
        System.Numerics.Matrix4x4.Invert(_camera.View, out System.Numerics.Matrix4x4 inverseView);
        PoseStack pose = new(System.Numerics.Matrix4x4.CreateScale(k, k, 1) * inverseView);
        int bx = (int)Math.Floor(_camera.Position.X), by = (int)Math.Floor(_camera.Position.Y), bz = (int)Math.Floor(_camera.Position.Z);
        float block = player.IsOnFire ? 15 : level.GetBlockLight(bx, by, bz);
        _itemInHand.SubmitHandsWithItems(partialTick, pose, _handBatch, player, _client, level.GetSkyLight(bx, by, bz), block);
    }

    /// <summary>The particle in <c>ClientPacketListener.handleTakeItemEntity</c>.</summary>
    private void TakeEntity(ClientEntity from, ClientEntity to) {
        // An entity drawn as developer art has no render state to take, so it vanishes rather than flies.
        if (_client.Level is not { } level || Entities.RendererFor(from) is not { } renderer) {
            return;
        }
        EntityRenderContext context = new() {
            Client = _client, Level = level, Camera = _camera, Batch = _entityBatch, TranslucentBatch = _translucentBatch, PartialTick = 1.0F,
            Flames = Flames
        };
        Particles.AddPickup(new ItemPickupParticle(renderer, renderer.Extract(from, 1.0F, context), to));
    }

    public void Upload() {
        _overlay.Upload();
        _entityBatch.Upload();
        _crumblingBatch.Upload();
        _translucentBatch.Upload();
        _additiveBatch.Upload();
        _waterMaskBatch.Upload();
        _handBatch.Upload();
        _glintBatch.Upload();
        _handGlintBatch.Upload();
        _outlineBatch.Upload();
        _casterBatch.Upload();
        _textDisplays.Upload();
        _entityShadows.Upload();
        _endPortals.Upload();
        Weather.Upload();
        Clouds.Upload();
        Particles.Upload(_camera);
    }

    public void Draw(string geometry, string camera) {
        switch (geometry) {
            case "terrain_solid": _world.DrawLayer(RenderLayer.Solid, camera == "shadow"); break;
            case "terrain_cutout": _world.DrawLayer(RenderLayer.Cutout, camera == "shadow"); break;
            case "terrain_translucent": _world.DrawLayer(RenderLayer.Translucent); break;
            case "entities" when camera == "shadow":
                if (ShowEntityShadows) {
                    _entityBatch.Draw();
                    _casterBatch.Draw();
                }
                break;
            case "entities": _entityBatch.Draw(); break;
            case "text": _textDisplays.DrawText(false); break;
            case "text_see_through": _textDisplays.DrawText(true); break;
            case "entity_shadows": _entityShadows.Draw(); break;
            case "crumbling": _crumblingBatch.Draw(); break;
            case "entities_translucent": _translucentBatch.Draw(); break;
            case "entities_additive": _additiveBatch.Draw(); break;
            case "water_mask": _waterMaskBatch.Draw(); break;
            case "hand": _handBatch.Draw(); break;
            case "glint": _glintBatch.Draw(); break;
            case "hand_glint": _handGlintBatch.Draw(); break;
            case "entity_outline": _outlineBatch.Draw(); break;
            case "end_portal": _endPortals.Draw(); break;
            case "lines": _overlay.DrawLines(); break;
            case "particles": Particles.Quads.Draw(false); break;
            case "particles_translucent": Particles.Quads.Draw(true); break;
            case "weather": Weather.Draw(); break;
            case "clouds": Clouds.Draw(); break;
        }
    }

    public bool IsEmpty(string geometry) => geometry switch {
        "entities" => _entityBatch.IsEmpty && _casterBatch.IsEmpty,
        "text" => _textDisplays.IsEmpty(false),
        "text_see_through" => _textDisplays.IsEmpty(true),
        "entity_shadows" => _entityShadows.IsEmpty,
        "crumbling" => _crumblingBatch.IsEmpty,
        "entities_translucent" => _translucentBatch.IsEmpty,
        "hand" => _handBatch.IsEmpty,
        "end_portal" => _endPortals.IsEmpty,
        "lines" => _overlay.IsEmpty,
        "water_mask" => _waterMaskBatch.IsEmpty,
        "entities_additive" => _additiveBatch.IsEmpty,
        "glint" => _glintBatch.IsEmpty,
        "hand_glint" => _handGlintBatch.IsEmpty,
        "entity_outline" => _outlineBatch.IsEmpty,
        "particles" => Particles.Quads.IsEmpty(false),
        "particles_translucent" => Particles.Quads.IsEmpty(true),
        "weather" => Weather.IsEmpty,
        "clouds" => Clouds.IsEmpty,
        _ => false
    };

    public void Dispose() {
        _overlay.Dispose();
        Particles.Dispose();
        _crumblingBatch.Dispose();
        _endPortals.Dispose();
        Weather.Dispose();
        Clouds.Dispose();
        CameraOverlays.Dispose();
        ScreenEffects.Dispose();
        _translucentBatch.Dispose();
        _additiveBatch.Dispose();
        _waterMaskBatch.Dispose();
        _handBatch.Dispose();
        _glintBatch.Dispose();
        _handGlintBatch.Dispose();
        _outlineBatch.Dispose();
        _casterBatch.Dispose();
        _textDisplays.Dispose();
        _entityShadows.Dispose();
        _entityBatch.Dispose();
        Textures.Dispose();
    }
}
