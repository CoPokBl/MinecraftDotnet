using System.Diagnostics;
using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Gui;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Pipeline;
using GraphicalClient.Rendering.Weather;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Silk.NET.Maths;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>What <see cref="GameRenderer.Prepare"/> worked out for <see cref="GameRenderer.Submit"/> to draw.</summary>
public readonly record struct FramePlan(bool InWorld, float PartialTick, bool Underwater, Vector2D<int> Size) {
    /// <summary><c>DeltaTracker.getGameTimeDeltaTicks</c>: the ticks the frame took.</summary>
    public float DeltaTicks { get; init; }
}

/// <summary>The render resources built from the resource packs, and the world's half of each frame.</summary>
public sealed class GameRenderer : IDisposable {
    private readonly GL _gl;
    private MinecraftClient _client;
    private readonly LaunchOptions _options;
    private readonly GameSettings _settings;
    private readonly FrameProfiler _profiler;
    private readonly Stopwatch _clock;
    private PackResources _pack = null!;
    private readonly ShadowCamera _shadows = new();
    private RenderPipeline _pipeline = null!;

    private Matrix4x4 _previousViewProjection;
    private Vec3d _previousCameraPosition;
    private double _previousFrameSeconds;
    private long _frameNumber;
    private Vector2 _easedEyeLight = new(-1);
    private WeatherView _weather;
    private SkyState _sky;

    public Camera Camera { get; } = new();
    public PlayerCamera View { get; } = new();
    public bool HideGui { get; set; }
    public PackFiles? PackFiles => _pack.Packs;
    public WorldRenderer World => _pack.World;
    public Lighting Lighting { get; }
    public GpuTimers GpuTimers { get; }
    public WorldScene Scene => _pack.Scene;
    public GuiRenderer Gui { get; }
    public TextRenderer Text => _pack.Text;
    public GuiSprites Sprites => _pack.Sprites;
    public HudIcons Icons => _pack.Icons;
    public ItemAtlas Items => _pack.Items;
    public ItemModelResolver ItemModels => _pack.ItemModels;
    public EnchantmentGlint Glint => _pack.Glint;
    public GuiEntityRenderer GuiEntities => _pack.GuiEntities;
    public int BlockTextureCount => _pack.Models.Textures.Count;
    public string? PipelineReport => _pipeline?.GpuReport();

    public GameRenderer(GL gl, MinecraftClient client, LaunchOptions options, GameSettings settings, FrameProfiler profiler, Stopwatch clock, PackFiles? packs) {
        _gl = gl;
        _client = client;
        _options = options;
        _settings = settings;
        _profiler = profiler;
        _clock = clock;
        Lighting = new Lighting(gl);
        GpuTimers = new GpuTimers(gl);
        Gui = new GuiRenderer(gl);
        Swap(Build(packs, FontOptions()));
        LoadPipeline();
    }

    /// <summary>The <c>Options</c> font settings a <see cref="Build"/> reads, taken on the render thread.</summary>
    public HashSet<string> FontOptions() {
        HashSet<string> fontOptions = [];
        if (_settings.ForceUnicodeFont) {
            fontOptions.Add("uniform");
        }
        if (_settings.JapaneseGlyphVariants) {
            fontOptions.Add("jp");
        }
        return fontOptions;
    }

    /// <summary>
    /// Builds everything drawn from the resource packs, the packs' half of vanilla's resource reload. Nothing the
    /// frame draws from is touched, so it may run on another thread with a context sharing this one's objects.
    /// </summary>
    public PackResources Build(PackFiles? packs, IReadOnlySet<string> fontOptions) {
        MinecraftClient client = _client;
        DevArtSource art = new(VanillaRegistry.Data);
        ResourcePackSource? pack = null;
        BiomeColours.ColourMaps? colourMaps = null;
        if (packs != null) {
            pack = new ResourcePackSource(packs, art);
            colourMaps = pack.ColourMaps();
            Console.WriteLine($"Resource packs: {string.Join(", ", packs.Names)}");
        }
        IResourceSource source = (IResourceSource?)pack ?? art;
        BlockModels models = new(VanillaRegistry.Data, source, (keys, pixels, levels) => new TextureArray(_gl, keys, pixels, levels));
        if (pack is { Warnings.Count: > 0 }) {
            Console.WriteLine($"Resource pack problems ({pack.Warnings.Count}): {string.Join("; ", pack.Warnings.Take(10))}");
        }
        TextureAnimator animator = new(_gl, models.Textures, models.Animations);
        WorldRenderer world = new(_gl, models, (int)Block.Water.StateId) {
            RenderDistance = _options.ViewDistance, LodDistance = _options.LodDistance, ColourMaps = colourMaps
        };
        Font font = (pack != null ? Font.FromPack(_gl, packs!, pack, fontOptions) : null) ?? Font.BuiltIn(_gl);
        GuiSprites sprites = new(_gl, pack);
        EnchantmentGlint glint = new(_gl, pack);
        ItemModelResolver itemModels = new(source, client);
        WorldScene scene = new(_gl, client, Camera, world, models, animator, pack, art, glint, itemModels, font);
        return new PackResources {
            Packs = packs, Client = client, Models = models, Animator = animator, World = world, Text = new TextRenderer(Gui, font),
            Sprites = sprites, Icons = new HudIcons(_gl, sprites), Glint = glint, ItemModels = itemModels,
            Items = new ItemAtlas(_gl, VanillaRegistry.Data, source, itemModels, glint), Scene = scene,
            GuiEntities = new GuiEntityRenderer(_gl, client, scene.Entities, scene.Textures, scene.Flames, Lighting.UiLightmapTexture),
            EndPortalColours = EndPortalPalette.Read(packs)
        };
    }

    /// <summary>
    /// Puts a <see cref="Build"/> in use and drops what the last one built, remeshing every section as
    /// <c>LevelRenderer.allChanged</c> does. The caller owns the packs and closes the old ones once nothing reads them.
    /// </summary>
    public void Swap(PackResources built) {
        PackResources? old = _pack;
        _pack = built;
        EndPortalPalette.Colours = built.EndPortalColours;
        if (old == null) {
            return;
        }
        old.Scene.UnhookClient();
        old.World.SetLevel(null);
        World.Materials = old.World.Materials;
        old.Dispose();
        if (built.Client != _client) {
            ItemModels.Client = _client;
            GuiEntities.Attach(_client);
            Scene.Attach(_client);
        }
        else {
            Scene.HookClient();
        }
        World.SetLevel(_client.Level);
    }

    public void HookClient() {
        _client.LevelChanged += level => World.SetLevel(level);
        Scene.HookClient();
        _client.PlayerSectionReady = PlayerSectionReady;
    }

    /// <summary>
    /// Moves everything drawn from the client onto a fresh connection, dropping the old one's sections and
    /// pickups. The pack's textures and models stay, as vanilla keeps its resources across a disconnect.
    /// </summary>
    public void Attach(MinecraftClient client) {
        _client = client;
        Camera.AttributeProbe.Reset();
        World.SetLevel(null);
        ItemModels.Client = client;
        GuiEntities.Attach(client);
        _client.LevelChanged += level => World.SetLevel(level);
        Scene.Attach(client);
        _client.PlayerSectionReady = PlayerSectionReady;
    }

    private bool PlayerSectionReady() {
        if (_client.Player is not { } player || _client.Level is not { } level) {
            return false;
        }
        int x = (int)Math.Floor(player.Position.X) >> 4;
        int z = (int)Math.Floor(player.Position.Z) >> 4;
        int y = ((int)Math.Floor(player.Position.Y) - level.MinY) >> 4;
        return World.IsSectionReady(x, Math.Clamp(y, 0, level.SectionCount - 1), z);
    }

    /// <summary>
    /// The pack named by <c>--shaders</c>, or the built in one. A pack that fails to load or compile
    /// leaves the one already running, or the built in one, and says why in the console, so F7 can be
    /// pressed again after a fix.
    /// </summary>
    public void LoadPipeline() {
        RenderPipeline? previous = _pipeline;
        try {
            ShaderPack pack = _options.Shaders != null ? ShaderPack.FromDirectory(_options.Shaders) : ShaderPack.BuiltIn();
            BlockMaterials materials = BlockMaterials.Build(pack.Materials, VanillaRegistry.Data, Block.Water.StateId, Block.Lava.StateId, Console.WriteLine);
            _pipeline = new RenderPipeline(_gl, pack);
            World.Materials = materials;
            _shadows.Invalidate();
            Console.WriteLine($"Shader pack: {pack.Name}");
        }
        catch (Exception e) when (e is InvalidDataException or IOException or Newtonsoft.Json.JsonException) {
            Console.WriteLine($"Shader pack failed: {e.Message}");
            if (previous != null) {
                return;
            }
            _pipeline = new RenderPipeline(_gl, ShaderPack.BuiltIn());
            World.Materials = BlockMaterials.None;
        }
        previous?.Dispose();
    }

    public void TickAnimations() {
        _pack.Animator.Tick();
        Scene.Flames.Update();
        Scene.CameraOverlays.Update();
        Scene.ScreenEffects.Update();
    }

    /// <summary><c>GameRenderer.tick</c>: the lightmap's flicker, the camera's tick, which samples the biomes round it, and the boss overlay.</summary>
    public void Tick() {
        Scene.Tick();
        ClientLevel? level = _client.Level;
        Lighting.Tick(level is { TickRateManager.RunsNormally: true }, _client.BossOverlay.ShouldDarkenScreen());
        if (_client.CameraEntity is { } camera && level != null) {
            Camera.AttributeProbe.Tick(level.Environment.Attributes, level.Environment,
                new Minecraft.Schemas.Vec.Vec3<double>(Camera.Position.X, Camera.Position.Y, Camera.Position.Z));
        }
        View.Tick(_client.CameraEntity, _client.Player, (float)_settings.FovEffectScale);
        if (_client.CameraEntity is { } entity && level != null) {
            Scene.CameraOverlays.Tick(entity, level, level.SkyDarken);
        }
    }

    /// <summary><c>Camera.extractRenderState</c>'s <c>smartCull</c>: off for a spectator whose camera is inside a block that fills its cube.</summary>
    private bool SmartCull(ClientLevel level, LocalPlayer player) {
        if (!player.IsSpectator) {
            return true;
        }
        Vec3d position = Camera.Position;
        Minecraft.Data.Blocks.IBlock block = level.GetBlock((int)Math.Floor(position.X), (int)Math.Floor(position.Y), (int)Math.Floor(position.Z));
        return !(block.Occludes && Minecraft.Placement.Helpers.ShapeSupport.IsShapeFullBlock(block.OcclusionShape));
    }

    /// <summary><c>Options.getEffectiveRenderDistance</c>: the option, or the server's view distance if that is nearer.</summary>
    private int EffectiveRenderDistance => _client.ServerViewDistance > 0 ? Math.Min(_options.ViewDistance, _client.ServerViewDistance) : _options.ViewDistance;

    /// <summary>The CPU half of a frame: the camera, the world's bookkeeping and the overlay geometry. No GL calls.</summary>
    public FramePlan Prepare(float partialTick, Vector2D<int> size, bool disconnected, float deltaTicks = 0.0F) {
        Glint.Update(_clock.ElapsedMilliseconds, _settings.GlintSpeed, _settings.GlintStrength);
        LocalPlayer? player = _client.Player;
        ClientLevel? level = _client.Level;
        if (player == null || level == null || disconnected) {
            return new FramePlan(false, partialTick, false, size);
        }

        float aspect = size.Y == 0 ? 1 : (float)size.X / size.Y;
        ClientEntity cameraEntity = _client.CameraEntity ?? player;
        // Camera.getCameraEntityPartialTicks: a frozen entity is drawn where its last tick left it.
        float cameraPartialTick = level.TickRateManager.IsEntityFrozen(cameraEntity) ? 1.0F : partialTick;
        View.Setup(Camera, cameraEntity, player, level, cameraPartialTick, partialTick, (float)_settings.ScreenEffectScale, _settings.Fov, (float)_settings.FovEffectScale, aspect,
            _options.ViewDistance * 16.0F * 1.5F + 64.0F);
        _client.Interactions.Pick(partialTick);

        Vec3d position = Camera.Position;
        _weather = WeatherView.Of(level, _options.TestWeather);
        level.Environment.WeatherOverride = _options.TestWeather != null && level.CanHaveWeather ? (_weather.Rain, _weather.Thunder) : null;
        level.Environment.HideLightningFlash = _settings.HideLightningFlashes;
        Lighting.Update(new LightingFrame(_client, level, player, cameraEntity, Camera, partialTick, deltaTicks, EffectiveRenderDistance, _weather,
            _client.BossOverlay.ShouldCreateWorldFog(), _settings));
        bool underwater = Lighting.FogType == FogType.Water;
        _profiler.Begin("sky");
        PrepareSky(level, partialTick);
        _sky = SkyStateFor(level, player, cameraEntity, partialTick, _client.BossOverlay.ShouldCreateWorldFog());

        _profiler.Begin("schedule");
        World.Schedule(new Vector3((float)position.X, (float)position.Y, (float)position.Z));
        _profiler.Begin("walk");
        World.Walk(Camera, SmartCull(level, player));
        _profiler.Begin("overlays");
        // LevelExtractor.extractVisibleEntities' Entity.setViewScale, on the effective render distance.
        Entities.EntityRenderer.ViewScale =
            Math.Clamp(Math.Min(_options.ViewDistance, _client.ServerViewDistance) / 8.0, 1.0, 2.5) * _settings.EntityDistanceScaling;
        Scene.LineWidth = Math.Max(2.5F, size.X / 1920.0F * 2.5F);
        Scene.ShowEntityShadows = _settings.EntityShadows;
        Scene.SkyDarken = Lighting.SkyDarkening;
        World.AmbientOcclusion = _settings.AmbientOcclusion;
        // TextDisplayRenderer's default background, at getBackgroundOpacity(0.25F).
        Scene.DefaultTextBackground = _settings.BackgroundColor(0x3F000000);
        Scene.ShadowCasterLight = _pipeline.Pack.DrawsEntitiesFromShadowCamera ? ShadowCamera.LightDirection(SunDirection) : null;
        Scene.Collect(level, partialTick, cameraEntity, View.FirstPerson, HideGui);
        return new FramePlan(true, partialTick, underwater, size);
    }

    /// <summary>The clouds and the rain or snow for this frame. The clouds fade out by <c>FogData.cloudEnd</c>.</summary>
    private void PrepareSky(ClientLevel level, float partialTick) {
        float tickPartial = level.TickRateManager.RunsNormally ? partialTick : 0.0F;
        Scene.Weather.Prepare(level, Camera.Position, partialTick, _weather.Rain, _settings.WeatherRadius, _weather.ForceSnow);
        Scene.Clouds.Prepare(Camera.Position, level.GameTime, tickPartial, _settings.Clouds, Lighting.CloudColour, Lighting.CloudHeight, Lighting.Fog.CloudEnd);
    }

    /// <summary><c>SkyRenderer.extractRenderState</c>'s level half and <c>LevelRenderer.addSkyPass</c>'s conditions.</summary>
    private SkyState SkyStateFor(ClientLevel level, LocalPlayer player, ClientEntity cameraEntity, float partialTick, bool bossFog) {
        bool fluidBlocksSky = Lighting.FogType is FogType.Lava or FogType.PowderSnow;
        bool effectBlocksSky = cameraEntity.IsLiving && (cameraEntity.HasEffect(PotionEffectType.Blindness) || cameraEntity.HasEffect(PotionEffectType.Darkness));
        double horizon = level.IsFlat ? level.MinY : 63.0;
        bool darkDisc = ClientLib.Interaction.Picking.EyePosition(player, partialTick).Y - horizon < 0.0 && !player.IsUnderWater;
        EndFlashState? flash = level.Environment.EndFlash;
        return new SkyState(level.DimensionType.Skybox, bossFog || fluidBlocksSky || effectBlocksSky, darkDisc,
            flash?.GetIntensity(partialTick) ?? 0.0F, flash?.XAngle ?? 0.0F, flash?.YAngle ?? 0.0F);
    }

    private static Minecraft.Data.Biomes.IBiome BiomeAt(ClientLevel level, int x, int y, int z) =>
        level.Registry.Biomes[Math.Min(level.GetBiome(x, y, z), (int)level.Registry.Biomes.Count - 1)];

    /// <summary>The GL half of a frame's world: uploads, culling and the pack's passes, over a cleared screen.</summary>
    public void Submit(FramePlan plan) {
        _gl.Viewport(0, 0, (uint)plan.Size.X, (uint)plan.Size.Y);
        _gl.ClearColor(0, 0, 0, 1);
        _gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        if (!plan.InWorld || _client.Level is not { } level) {
            return;
        }
        _profiler.Begin("upload");
        Lighting.Upload();
        _pack.Animator.Upload();
        World.UploadFinished(2.0);
        Scene.Upload();
        _profiler.Begin("cull");
        GpuTimers.Begin("cull");
        World.Cull(Camera);
        Matrix4x4 shadowView = default, shadowProjection = default;
        bool drawShadows = false;
        ShaderPack pack = _pipeline.Pack;
        if (pack.UsesShadowCamera) {
            World.ShadowReach = (int)MathF.Ceiling(pack.ShadowDistance / 16) + 2;
            drawShadows = _shadows.Update(Camera, SunDirection, pack.ShadowDistance, _pipeline.ShadowMapSize, World.ShadowGeometryVersion,
                pack.ShadowUpdate == "always", out shadowView, out shadowProjection);
            if (drawShadows) {
                World.PrepareShadow(Camera, pack.ShadowDistance, shadowView * shadowProjection);
            }
        }
        World.Commit();
        GpuTimers.End();
        _profiler.Begin("passes");
        FrameUniforms frame = FrameFor(level, plan.PartialTick, plan.Underwater);
        frame.ShadowView = shadowView;
        frame.ShadowProjection = shadowProjection;
        Scene.Sky.Update(_sky, frame);
        _pipeline.Execute(ref frame, Scene, _pack.Models.Textures.Handle, Lighting.LightmapTexture, Scene.Textures.Handle,
            Scene.EndSkyTexture, Scene.EndPortalTexture, Glint.ItemTexture, Glint.ArmorTexture, plan.Size.X, plan.Size.Y, drawShadows);
    }

    private Vector3 SunDirection => ShadowCamera.SunDirection(Lighting.SunDirection, _pipeline.Pack.SunPathRotation);

    private FrameUniforms FrameFor(ClientLevel level, float partialTick, bool underwater) {
        Matrix4x4 viewProjection = Camera.View * Camera.RenderProjection;
        Matrix4x4.Invert(Camera.View, out Matrix4x4 inverseView);
        Matrix4x4.Invert(Camera.RenderProjection, out Matrix4x4 inverseProjection);
        Matrix4x4.Invert(viewProjection, out Matrix4x4 inverseViewProjection);

        double now = _clock.Elapsed.TotalSeconds;
        float frameSeconds = _frameNumber == 0 ? 0 : (float)(now - _previousFrameSeconds);
        Vec3d motion = _frameNumber == 0 ? new Vec3d(0, 0, 0) : Camera.Position - _previousCameraPosition;
        Matrix4x4 previousViewProjection = _frameNumber == 0 ? viewProjection : _previousViewProjection;
        _previousViewProjection = viewProjection;
        _previousCameraPosition = Camera.Position;
        _previousFrameSeconds = now;
        _frameNumber++;

        int bx = (int)Math.Floor(Camera.Position.X), by = (int)Math.Floor(Camera.Position.Y), bz = (int)Math.Floor(Camera.Position.Z);
        Vector2 eyeLight = new(level.GetBlockLight(bx, by, bz) / 15.0F, level.GetSkyLight(bx, by, bz) / 15.0F);
        // Halves the gap each second, so walking into a cave takes a few seconds to adjust to.
        _easedEyeLight = _easedEyeLight.X < 0 ? eyeLight : Vector2.Lerp(eyeLight, _easedEyeLight, MathF.Pow(0.5F, Math.Min(frameSeconds, 1.0F)));

        Minecraft.Data.Biomes.IBiome biome = BiomeAt(level, bx, by, bz);
        double dayTime = level.DefaultClockTimeAt(partialTick);
        FogData fog = Lighting.Fog;
        // A pack reading one fog range gets the pair that ends nearer, which is the one vanilla's fog is all but
        // decided by: the render distance's in the open, the environment's in water, lava, snow or a blinding effect.
        (float fogStart, float fogEnd) = fog.EnvironmentalEnd < fog.RenderDistanceEnd
            ? (fog.EnvironmentalStart, fog.EnvironmentalEnd)
            : (fog.RenderDistanceStart, fog.RenderDistanceEnd);
        float timeOfDay = Lighting.SunAngle / 360.0F - MathF.Floor(Lighting.SunAngle / 360.0F);
        bool nether = level.DimensionType.CardinalLight == Minecraft.Data.DimensionType.CardinalLight.Nether;
        float gameTime = level.TickRateManager.RunsNormally ? level.GameTime % 24000 + partialTick : level.GameTime % 24000;
        return new FrameUniforms {
            View = Camera.View,
            Projection = Camera.RenderProjection,
            ViewProjection = viewProjection,
            InverseView = inverseView,
            InverseProjection = inverseProjection,
            InverseViewProjection = inverseViewProjection,
            CameraPosition = new Vector4((float)Camera.Position.X, (float)Camera.Position.Y, (float)Camera.Position.Z, underwater ? 1 : 0),
            SunDirection = new Vector4(SunDirection, Lighting.Daylight),
            SkyColour = new Vector4(Lighting.SkyColour, 1),
            FogColour = fog.Color,
            FogRange = new Vector4(fogStart, fogEnd, EffectiveRenderDistance * 16, level.DimensionType.HasSkyLight ? 1 : 0),
            Time = new Vector4(timeOfDay, level.GameTime / 20.0F, (float)_clock.Elapsed.TotalSeconds, partialTick),
            Weather = new Vector4(_weather.Rain, _weather.Thunder, Lighting.Daylight, level.DimensionType.AmbientLight),
            PreviousViewProjection = previousViewProjection,
            CameraMotion = new Vector4((float)motion.X, (float)motion.Y, (float)motion.Z, frameSeconds),
            Counters = new Vector4(_frameNumber & 0xFFFF, (float)((dayTime % 24000 + 24000) % 24000), (int)Lighting.MoonPhase, gameTime),
            EyeLight = new Vector4(eyeLight, _easedEyeLight.X, _easedEyeLight.Y),
            HeldLight = new Vector4(HeldLight(Hand.MainHand), HeldLight(Hand.OffHand), 0, 0),
            Biome = new Vector4(biome.Temperature, biome.Downfall, biome.HasPrecipitation ? 1 : 0, 0),
            ClipPlanes = new Vector4(Camera.NearPlane, Camera.FarPlane, 0, 0),
            CardinalLight0 = nether ? new Vector4(0.9F, 0.9F, 0.8F, 0.8F) : new Vector4(0.5F, 1.0F, 0.8F, 0.8F),
            CardinalLight1 = new Vector4(0.6F, 0.6F, 0, 0),
            DiffuseLight0 = new Vector4(DiffuseLight0, 0),
            DiffuseLight1 = new Vector4(nether ? NetherDiffuseLight1 : DiffuseLight1, 0),
            FogDistances = new Vector4(fog.EnvironmentalStart, fog.EnvironmentalEnd, fog.RenderDistanceStart, fog.RenderDistanceEnd),
            FogSkyClouds = new Vector4(fog.SkyEnd, fog.CloudEnd, 0, 0),
            SunriseColour = Lighting.SunriseColour,
            Celestial = new Vector4(Lighting.SunAngle, Lighting.MoonAngle, Lighting.StarAngle, Lighting.StarBrightness)
        };
    }

    // Lighting's DIFFUSE_LIGHT_0 and _1, and the nether's second, which points down.
    private static readonly Vector3 DiffuseLight0 = Vector3.Normalize(new Vector3(0.2F, 1.0F, -0.7F));
    private static readonly Vector3 DiffuseLight1 = Vector3.Normalize(new Vector3(-0.2F, 1.0F, 0.7F));
    private static readonly Vector3 NetherDiffuseLight1 = Vector3.Normalize(new Vector3(-0.2F, -1.0F, 0.7F));

    /// <summary>The light the block an item places gives off, which is what a pack lights a held torch by.</summary>
    private float HeldLight(Hand hand) {
        if (_client.Player?.ItemInHand(hand).Type.CorrespondingBlock is not { } block) {
            return 0;
        }
        return VanillaRegistry.Data.Blocks.Contains(block) ? VanillaRegistry.Data.Blocks.Get(block).LightEmission : 0;
    }

    public void Dispose() {
        _pack.Dispose();
        Lighting.Dispose();
        _pipeline.Dispose();
        Gui.Dispose();
    }
}
