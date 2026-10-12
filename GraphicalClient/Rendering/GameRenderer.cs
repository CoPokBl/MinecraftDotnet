using System.Diagnostics;
using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Gui;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Pipeline;
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
    private readonly MinecraftClient _client;
    private readonly LaunchOptions _options;
    private readonly GameSettings _settings;
    private readonly FrameProfiler _profiler;
    private readonly Stopwatch _clock;
    private readonly BlockModels _models;
    private readonly TextureAnimator _animator;
    private readonly ShadowCamera _shadows = new();
    private RenderPipeline _pipeline = null!;

    private Matrix4x4 _previousViewProjection;
    private Vec3d _previousCameraPosition;
    private double _previousFrameSeconds;
    private long _frameNumber;
    private Vector2 _easedEyeLight = new(-1);

    public Camera Camera { get; } = new();
    public PlayerCamera View { get; } = new();
    public bool HideGui { get; set; }
    public PackFiles? PackFiles { get; }
    public WorldRenderer World { get; }
    public Lighting Lighting { get; }
    public GpuTimers GpuTimers { get; }
    public WorldScene Scene { get; }
    public GuiRenderer Gui { get; }
    public TextRenderer Text { get; }
    public GuiSprites Sprites { get; }
    public HudIcons Icons { get; }
    public ItemAtlas Items { get; }
    public ItemModelResolver ItemModels { get; }
    public EnchantmentGlint Glint { get; }
    public GuiEntityRenderer GuiEntities { get; }
    public int BlockTextureCount => _models.Textures.Count;
    public string? PipelineReport => _pipeline?.GpuReport();

    public GameRenderer(GL gl, MinecraftClient client, LaunchOptions options, GameSettings settings, FrameProfiler profiler, Stopwatch clock) {
        _gl = gl;
        _client = client;
        _options = options;
        _settings = settings;
        _profiler = profiler;
        _clock = clock;

        DevArtSource art = new(VanillaRegistry.Data);
        ResourcePackSource? pack = null;
        BiomeColours.ColourMaps? colourMaps = null;
        if (options.ResourcePacks.Count > 0) {
            PackFiles = new PackFiles(options.ResourcePacks);
            if (options.VanillaAssets is { } vanillaAssets) {
                PackFiles.AddLowest(vanillaAssets);
            }
            pack = new ResourcePackSource(PackFiles, art);
            colourMaps = pack.ColourMaps();
            Console.WriteLine($"Resource packs: {string.Join(", ", PackFiles.Names)}");
            Translations.Load(PackFiles.ReadEach("assets/minecraft/lang/en_us.json")
                .Select(json => Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(System.Text.Encoding.UTF8.GetString(json))!));
        }
        EndPortalPalette.Load(PackFiles);
        IResourceSource source = (IResourceSource?)pack ?? art;
        _models = new BlockModels(VanillaRegistry.Data, source, (keys, pixels) => new TextureArray(gl, keys, pixels));
        if (pack is { Warnings.Count: > 0 }) {
            Console.WriteLine($"Resource pack problems ({pack.Warnings.Count}): {string.Join("; ", pack.Warnings.Take(10))}");
        }
        _animator = new TextureAnimator(gl, _models.Textures, _models.Animations);
        World = new WorldRenderer(gl, _models, (int)Block.Water.StateId) {
            RenderDistance = options.ViewDistance, LodDistance = options.LodDistance, ColourMaps = colourMaps
        };
        Lighting = new Lighting(gl);
        GpuTimers = new GpuTimers(gl);
        LoadPipeline();
        Gui = new GuiRenderer(gl);
        Font font = (pack != null ? Font.FromPack(gl, PackFiles!, pack) : null) ?? Font.BuiltIn(gl);
        Text = new TextRenderer(Gui, font);
        Sprites = new GuiSprites(gl, pack);
        Icons = new HudIcons(gl, Sprites);
        Glint = new EnchantmentGlint(gl, pack);
        ItemModels = new ItemModelResolver(source, client);
        Items = new ItemAtlas(gl, VanillaRegistry.Data, source, ItemModels, Glint);
        Scene = new WorldScene(gl, client, Camera, World, _models, _animator, pack, art, Glint, ItemModels, font);
        GuiEntities = new GuiEntityRenderer(gl, client, Scene.Entities, Scene.Textures, Scene.Flames, Lighting.LightmapTexture);
    }

    public void HookClient() {
        _client.LevelChanged += level => World.SetLevel(level);
        Scene.HookClient();
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
        _animator.Tick();
        Scene.Flames.Update();
        Scene.CameraOverlays.Update();
        Scene.ScreenEffects.Update();
    }

    public void Tick() {
        Scene.Tick();
        if (_client.Level is { TickRateManager.RunsNormally: true }) {
            Lighting.TickBossOverlay(_client.BossOverlay.ShouldDarkenScreen());
        }
        View.Tick(_client.CameraEntity, _client.Player, (float)_settings.FovEffectScale);
        if (_client.CameraEntity is { } camera && _client.Level is { } level) {
            Scene.CameraOverlays.Tick(camera, level, Lighting.SkyDarkening);
        }
    }

    /// <summary>The CPU half of a frame: the camera, the world's bookkeeping and the overlay geometry. No GL calls.</summary>
    public FramePlan Prepare(float partialTick, Vector2D<int> size, bool disconnected) {
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
        int cx = (int)Math.Floor(position.X), cy = (int)Math.Floor(position.Y), cz = (int)Math.Floor(position.Z);
        bool underwater = level.GetBlock(cx, cy, cz).Fluid?.Key is "water" or "flowing_water";
        Minecraft.Data.Biomes.IBiome biome = BiomeAt(level, cx, cy, cz);
        Lighting.Update(level, partialTick, _options.ViewDistance, underwater,
            BiomeColours.Environment(level, biome, EnvironmentAttribute.VisualSkyColor, 0x78A7FF),
            BiomeColours.Environment(level, biome, EnvironmentAttribute.VisualFogColor, 0xC0D8FF),
            BiomeColours.Environment(level, biome, EnvironmentAttribute.VisualWaterFogColor, 0x050533),
            _client.BossOverlay.ShouldCreateWorldFog());

        _profiler.Begin("schedule");
        World.Schedule(new Vector3((float)position.X, (float)position.Y, (float)position.Z));
        _profiler.Begin("walk");
        World.Walk(Camera);
        _profiler.Begin("overlays");
        // LevelExtractor.extractVisibleEntities' Entity.setViewScale, on the effective render distance.
        Entities.EntityRenderer.ViewScale =
            Math.Clamp(Math.Min(_options.ViewDistance, _client.ServerViewDistance) / 8.0, 1.0, 2.5) * _settings.EntityDistanceScaling;
        Scene.Collect(level, partialTick, cameraEntity, View.FirstPerson, HideGui);
        return new FramePlan(true, partialTick, underwater, size);
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
        _animator.Upload();
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
        _pipeline.Execute(ref frame, Scene, _models.Textures.Handle, Lighting.LightmapTexture, Scene.Textures.Handle,
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
        float gameTime = level.TickRateManager.RunsNormally ? level.GameTime % 24000 + partialTick : level.GameTime % 24000;
        return new FrameUniforms {
            View = Camera.View,
            Projection = Camera.RenderProjection,
            ViewProjection = viewProjection,
            InverseView = inverseView,
            InverseProjection = inverseProjection,
            InverseViewProjection = inverseViewProjection,
            CameraPosition = new Vector4((float)Camera.Position.X, (float)Camera.Position.Y, (float)Camera.Position.Z, underwater ? 1 : 0),
            SunDirection = new Vector4(SunDirection, Lighting.SkyDarken),
            SkyColour = new Vector4(Lighting.SkyColour, 1),
            FogColour = new Vector4(Lighting.FogColour, 1),
            FogRange = new Vector4(Lighting.FogStart, Lighting.FogEnd, _options.ViewDistance * 16, level.DimensionType.HasSkyLight ? 1 : 0),
            Time = new Vector4(Lighting.TimeOfDay(dayTime), level.GameTime / 20.0F, (float)_clock.Elapsed.TotalSeconds, partialTick),
            Weather = new Vector4(level.RainLevel, level.ThunderLevel, Lighting.SkyDarken, level.DimensionType.AmbientLight),
            PreviousViewProjection = previousViewProjection,
            CameraMotion = new Vector4((float)motion.X, (float)motion.Y, (float)motion.Z, frameSeconds),
            Counters = new Vector4(_frameNumber & 0xFFFF, (float)((dayTime % 24000 + 24000) % 24000), (int)(((long)Math.Floor(dayTime / 24000) % 8 + 8) % 8),
                gameTime),
            EyeLight = new Vector4(eyeLight, _easedEyeLight.X, _easedEyeLight.Y),
            HeldLight = new Vector4(HeldLight(Hand.MainHand), HeldLight(Hand.OffHand), 0, 0),
            Biome = new Vector4(biome.Temperature, biome.Downfall, biome.HasPrecipitation ? 1 : 0, 0),
            ClipPlanes = new Vector4(Camera.NearPlane, Camera.FarPlane, 0, 0)
        };
    }

    /// <summary>The light the block an item places gives off, which is what a pack lights a held torch by.</summary>
    private float HeldLight(Hand hand) {
        if (_client.Player?.ItemInHand(hand).Type.CorrespondingBlock is not { } block) {
            return 0;
        }
        return VanillaRegistry.Data.Blocks.Contains(block) ? VanillaRegistry.Data.Blocks.Get(block).LightEmission : 0;
    }

    public void Dispose() {
        World.Dispose();
        Scene.Dispose();
        GuiEntities.Dispose();
        Lighting.Dispose();
        _pipeline.Dispose();
        Text.Dispose();
        Icons.Dispose();
        Items.Dispose();
        Glint.Dispose();
        Sprites.Dispose();
        Gui.Dispose();
        _models.Textures.Dispose();
    }
}
