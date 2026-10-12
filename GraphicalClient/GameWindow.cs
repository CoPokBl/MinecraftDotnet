using System.Diagnostics;
using ClientLib;
using GraphicalClient.Gui;
using GraphicalClient.Rendering;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace GraphicalClient;

/// <summary>
/// The window and the frame loop. Each frame handles queued packets, runs however many client ticks
/// are due, then draws, which is the order <c>Minecraft.runTick</c> keeps.
/// </summary>
public sealed class GameWindow : IDisposable {
    private const float TickMillis = 50.0F;

    private readonly LaunchOptions _options;
    private readonly GameSettings _settings;
    private readonly MinecraftClient _client;
    private readonly Hud _hud = new();
    private readonly DebugOverlay _debug = new();
    private readonly FrameProfiler _profiler = new();
    private readonly Stopwatch _clock = new();
    private readonly ScreenManager _screens;
    private readonly LaunchScript _script;
    private IWindow _window = null!;
    private GL _gl = null!;
    private GameRenderer _renderer = null!;
    private GuiLayer _guiLayer = null!;
    private GameAudio _audio = null!;
    private GameInput _input = null!;
    private GuiContext _context = null!;
    private Task? _connecting;
    private bool _presentPending;
    private bool _closed;
    private double _tickResidual;
    private int _frames, _fps;
    private double _fpsTimer, _frameMs;
    private int[] _gcCounts = [0, 0, 0];
    private TimeSpan _gcPause;

    public int ExitCode { get; private set; }

    public GameWindow(LaunchOptions options, ClientOptions clientOptions) {
        _options = options;
        _settings = GameSettings.Load(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mcdotnet-client", "options.txt"));
        if (options.Fov is { } fov) {
            _settings.Fov = fov;
        }
        if (options.MouseSensitivity is { } sensitivity) {
            _settings.Sensitivity = sensitivity;
        }
        foreach ((Minecraft.Schemas.Sound.SoundCategory category, float volume) in options.Volumes) {
            _settings.Volumes[(int)category] = volume;
        }
        _debug.Visible = options.DebugOverlay;
        _client = new MinecraftClient(clientOptions);
        _client.Log += message => Console.WriteLine(message);
        _screens = new ScreenManager(_client, _hud);
        _script = new LaunchScript(options, _client, _clock);
        if (options.LogSent) {
            _client.PacketSent += packet => LaunchScript.LogSent(_client, packet);
        }
    }

    public void Run() {
        WindowOptions options = WindowOptions.Default with {
            Size = new Vector2D<int>(_options.Width, _options.Height),
            Title = "Minecraft Client",
            API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Core,
#if DEBUG
                ContextFlags.ForwardCompatible | ContextFlags.Debug,
#else
                ContextFlags.ForwardCompatible,
#endif
                new APIVersion(4, 5)),
            VSync = _options.VSync,
            FramesPerSecond = _options.MaxFps ?? 0,
            ShouldSwapAutomatically = false,
            UpdatesPerSecond = 0,
            WindowState = _options.Fullscreen ? WindowState.Fullscreen : WindowState.Normal,
            PreferredDepthBufferBits = 24
        };
        _window = Window.Create(options);
        _window.Load += OnLoad;
        _window.Render += OnRender;
        _window.Closing += OnClosing;
        _window.Run();
    }

    private void OnLoad() {
        _gl = GL.GetApi(_window);
        string rendererName = _gl.GetStringS(StringName.Renderer);
        Console.WriteLine($"OpenGL {_gl.GetStringS(StringName.Version)} on {rendererName}");
#if DEBUG
        GlDebug.Enable(_gl);
#endif
        if (!_options.VSync && _options.MaxFps == null) {
            int refresh = _window.Monitor?.VideoMode.RefreshRate ?? 0;
            _window.FramesPerSecond = refresh > 0 ? refresh : 144;
        }

        Stopwatch timer = Stopwatch.StartNew();
        _renderer = new GameRenderer(_gl, _client, _options, _settings, _profiler, _clock);
        _audio = new GameAudio(_renderer.PackFiles, _client, _renderer.Camera, _settings);
        Console.WriteLine($"Built {_renderer.BlockTextureCount} block textures and the item icons in {timer.ElapsedMilliseconds} ms");

        _input = new GameInput(_window.CreateInput(), _client, _options, _settings, _screens, _renderer, _debug, () => _window.Close());
        _context = new GuiContext(_renderer.Gui, _renderer.Text, _renderer.Icons, _renderer.Items, _client, _renderer.Sprites) {
            ReadClipboard = () => _input.Clipboard,
            WriteClipboard = text => _input.Clipboard = text,
            Sounds = _audio.Sounds,
            Settings = _settings,
            Open = _screens.Set,
            EntityRenderer = _renderer.GuiEntities
        };
        _screens.Context = _context;
        _guiLayer = new GuiLayer(_renderer, _client, _hud, _debug, rendererName);
        _input.CaptureMouse(true);

        _renderer.HookClient();
        _screens.HookClient();
        _connecting = _client.Connect(_options.Host, _options.Port);
        _clock.Start();
    }

    private void OnRender(double delta) {
        if (_connecting is { IsFaulted: true }) {
            Console.WriteLine($"Could not connect: {_connecting.Exception?.GetBaseException().Message}");
            ExitCode = 1;
            _connecting = null;
            _screens.Set(new DisconnectedScreen($"Could not connect: {_client.DisconnectReason}"));
        }

        Stopwatch frame = Stopwatch.StartNew();
        double now = _clock.Elapsed.TotalSeconds;
        _profiler.Begin("packets");
        _client.ProcessPackets();
        _input.TurnPlayer();
        _script.Spin(delta);
        _screens.Update();
        _profiler.Begin("ticks");

        // DeltaTracker.Timer.advanceGameTime: ticks beyond ten in one frame are dropped.
        float deltaTicks = (float)(delta * 1000.0 / _client.TickTargetMillis(TickMillis));
        _tickResidual += deltaTicks;
        int ticks = (int)_tickResidual;
        _tickResidual -= ticks;
        for (int i = 0; i < Math.Min(10, ticks); i++) {
            Tick();
        }
        float partialTick = (float)_tickResidual;
        _script.CheckJoined(now, _screens);

        FramePlan plan = _renderer.Prepare(partialTick, _window.FramebufferSize, _screens.Current is DisconnectedScreen) with { DeltaTicks = deltaTicks };
        if (plan.InWorld) {
            _audio.UpdateListener(_renderer.Camera);
        }
        // The previous frame goes to the screen only now, so everything above ran while the GPU was
        // still drawing it rather than after.
        _profiler.Begin("swap");
        if (_presentPending) {
            _window.SwapBuffers();
        }
        _renderer.Submit(plan);
        _profiler.Begin("hud");
        _renderer.GpuTimers.Begin("hud");
        _guiLayer.Render(_context, plan, _screens.Current, _input.TabHeld, _input.MouseInGui(), _fps, _frameMs);
        _renderer.GpuTimers.FrameDone();
        _gl.Flush();
        _presentPending = true;
        _profiler.FrameDone();
        _frameMs = _frameMs * 0.9 + frame.Elapsed.TotalMilliseconds * 0.1;

        _frames++;
        _fpsTimer += delta;
        if (_fpsTimer >= 1.0) {
            _fps = _frames;
            _frames = 0;
            _fpsTimer -= 1.0;
            UpdateTitle();
        }

        _script.AfterFrame(now, _input, out string? screenshot, out bool exit);
        if (screenshot != null) {
            SaveScreenshot(screenshot);
        }
        if (exit) {
            _window.Close();
        }
    }

    private void Tick() {
        _profiler.Begin("tick:animator");
        _renderer.TickAnimations();
        _profiler.Begin("tick:input");
        if (_client.Player is { } player) {
            player.Input = _script.HeldKeys(_screens) ?? _input.Movement();
        }
        _input.TickInteractions(_script.HoldsUse(_input));
        _profiler.Begin("tick:client");
        _audio.TickPlayer();
        _client.Tick();
        _profiler.Begin("tick:renderers");
        _renderer.Tick();
        _audio.Tick();
        _screens.Tick();
        _profiler.Begin("ticks");
        _script.SendCommands();
    }

    private void UpdateTitle() {
        string where = _client.Player is { } player ? $"{player.Position.X:F1} {player.Position.Y:F1} {player.Position.Z:F1}" : _client.Phase.ToString();
        _window.Title = $"Minecraft Client - {_fps} fps - {where}";
        if (!_options.Verbose) {
            return;
        }
        TimeSpan pause = GC.GetTotalPauseDuration();
        string gc = $"gc {GC.CollectionCount(0) - _gcCounts[0]}/{GC.CollectionCount(1) - _gcCounts[1]}/{GC.CollectionCount(2) - _gcCounts[2]} paused {(pause - _gcPause).TotalMilliseconds:F1} ms heap {GC.GetTotalMemory(false) >> 20} MB";
        _gcCounts = [GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2)];
        _gcPause = pause;
        (double lightTotal, double lightLongest) = _client.Level?.Light.TakeMilliseconds() ?? (0, 0);
        gc += $" light {lightTotal:F0} ms/s (longest {lightLongest:F1}) entities {_client.Entities.Count} sounds {_audio.Playing}";
        if (_client.Level is { } level) {
            gc += $" day time {level.DefaultClockTime} game time {level.GameTime} tick rate {level.TickRateManager.TickRate}{(level.TickRateManager.IsFrozen ? " frozen" : "")}";
        }
        WorldRenderer world = _renderer.World;
        Console.WriteLine($"{_window.Title} - sections {world.VisibleSections}/{world.LoadedSections} (+{world.PendingSections}) - {gc} - {_profiler.Report()} walk {world.Timings[0] / Math.Max(1, _fps):F2} {_renderer.PipelineReport} {_renderer.GpuTimers.Report()} quads {world.QuadsDrawn.Main} ({world.LayerQuadsReport}) + shadow {world.QuadsDrawn.Shadow}");
        Array.Clear(world.Timings);
    }

    private unsafe void SaveScreenshot(string path) {
        Vector2D<int> size = _window.FramebufferSize;
        byte[] pixels = new byte[size.X * size.Y * 4];
        fixed (byte* p = pixels) {
            _gl.ReadPixels(0, 0, (uint)size.X, (uint)size.Y, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        PngWriter.Write(path, size.X, size.Y, pixels);
        Console.WriteLine($"Saved screenshot to {Path.GetFullPath(path)}");
    }

    /// <summary>GL objects go here, while the context still exists; after <c>Run</c> returns it does not.</summary>
    private void OnClosing() {
        if (_closed) {
            return;
        }
        _closed = true;
        _client.Disconnect("Quit");
        _renderer.Dispose();
        _audio.Dispose();
    }

    /// <summary>
    /// The window is left to the process: Silk refuses to reset a window whose loop was closed from
    /// inside a frame, and nothing outlives the process anyway.
    /// </summary>
    public void Dispose() {
    }
}
