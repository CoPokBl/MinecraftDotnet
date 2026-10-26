using System.Diagnostics;
using ClientLib;
using ClientLib.Multiplayer;
using Minecraft.Text;
using GraphicalClient.Gui;
using GraphicalClient.Rendering;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace GraphicalClient;

/// <summary>
/// The window and the frame loop. Each frame handles queued packets, runs however many client ticks
/// are due, then draws, which is the order <c>Minecraft.runTick</c> keeps. Every join is a fresh
/// <see cref="MinecraftClient"/>, which the renderers, sounds, input and screens are moved onto; what
/// the resource packs built stays for the window's life, as vanilla keeps its resources across servers.
/// </summary>
public sealed class GameWindow : IDisposable, IMenuHost {
    private const float TickMillis = 50.0F;

    private readonly LaunchOptions _options;
    private readonly GameSettings _settings;
    private readonly ClientOptions _clientOptions;
    private MinecraftClient _client;
    private readonly Hud _hud = new();
    private readonly DebugOverlay _debug = new();
    private readonly FrameProfiler _profiler = new();
    private readonly Stopwatch _clock = new();
    private readonly ScreenManager _screens;
    private readonly LaunchScript _script;
    private readonly ClientResources _resources;
    private IWindow _window = null!;
    private GL _gl = null!;
    private GameRenderer _renderer = null!;
    private GuiLayer _guiLayer = null!;
    private GameAudio _audio = null!;
    private GameInput _input = null!;
    private GuiContext _context = null!;
    private PanoramaRenderer _panorama = null!;
    private readonly SplashManager _splashes;
    private SharedGlContext _uploadContext = null!;
    private LoadingLogo _logo = null!;
    private CancellationTokenSource? _connectAbort;

    /// <summary>The entry the current connection was made from, and the screen a disconnect from it leads back to.</summary>
    private ServerData? _server;
    private Screen? _postDisconnect;
    private bool _disconnectHandled;
    private ClientPhase _livePhase;
    private float _realtimeDeltaTicks;
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
        _settings.ApplyOverrides(options.SettingOverrides);
        clientOptions.SkinParts = _settings.ModelParts;
        clientOptions.MainHand = _settings.MainHand;
        clientOptions.Locale = _settings.Language;
        clientOptions.ChatMode = _settings.ChatVisibility;
        clientOptions.ChatColors = _settings.ChatColors;
        clientOptions.ChatSigning = _settings.ChatSigning;
        clientOptions.Particles = _settings.Particles;
        _debug.Visible = options.DebugOverlay;
        _resources = new ClientResources(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mcdotnet-client"), options, _settings);
        _clientOptions = clientOptions;
        _splashes = new SplashManager(clientOptions.Account?.Username ?? clientOptions.Username);
        _splashes.Apply(SplashManager.Prepare(_resources.Files));
        _client = CreateClient();
        _settings.Saved += () => {
            _client.Options.ChatMode = _settings.ChatVisibility;
            _client.Options.ChatColors = _settings.ChatColors;
            _client.Options.SkinParts = _settings.ModelParts;
            _client.Options.MainHand = _settings.MainHand;
            _client.Options.Locale = _settings.Language;
            _client.Options.Particles = _settings.Particles;
            _client.BroadcastClientInformation();
        };
        _screens = new ScreenManager(_client, _hud);
        _script = new LaunchScript(options, _client, _clock);
    }

    public void Run() {
        WindowOptions options = WindowOptions.Default with {
            Size = new Vector2D<int>(_options.Width, _options.Height),
            Title = "mcdotnet",
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
        _renderer = new GameRenderer(_gl, _client, _options, _settings, _profiler, _clock, _resources.Files);
        _audio = new GameAudio(_renderer.PackFiles, _client, _renderer.Camera, _settings);
        Console.WriteLine($"Built {_renderer.BlockTextureCount} block textures and the item icons in {timer.ElapsedMilliseconds} ms");

        _input = new GameInput(_window.CreateInput(), _client, _options, _settings, _screens, _renderer, _debug, LeaveServer) {
            ToggleFullscreen = () => _window.WindowState = _window.WindowState == WindowState.Fullscreen ? WindowState.Normal : WindowState.Fullscreen
        };
        Narration.GameNarrator narrator = new(new Narration.TtsNarrator(), _settings);
        _input.Narrator = narrator;
        _context = new GuiContext(_renderer.Gui, _renderer.Text, _renderer.Icons, _renderer.Items, _client, _renderer.Sprites) {
            ReadClipboard = () => _input.Clipboard,
            WriteClipboard = text => _input.Clipboard = text,
            Sounds = _audio.Sounds,
            Settings = _settings,
            Open = _screens.Set,
            CurrentScreen = () => _screens.Current,
            OpenChat = _screens.OpenChatAndAddText,
            Narrator = narrator,
            RawMouseInputChanged = _input.ApplyCursorMode,
            EntityRenderer = _renderer.GuiEntities
        };
        _screens.Context = _context;
        narrator.Toasts = _context.Toasts;
        _audio.Toasts = _context.Toasts;
        _context.Toasts.CurrentMusic = () => _audio.Sounds.Music?.CurrentMusicTranslationKey;
        _uploadContext = new SharedGlContext(_window, _gl);
        _resources.Listeners = ReloadListeners;
        _logo = new LoadingLogo(_gl);
        _logo.Set(LoadingLogo.Read(_resources.VanillaFile(LoadingLogo.Location)));
        _resources.LogoTexture = () => _logo.Texture;
        _resources.InitScreen = () => _screens.Current?.InvalidateLayout();
        _input.OverlayOpen = () => _resources.Overlay != null;
        _context.Resources = _resources;
        _window.FileDrop += files => (_screens.Current as PackSelectionScreen)?.FilesDropped(_context, files);
        _guiLayer = new GuiLayer(_renderer, _client, _hud, _debug, rendererName) { Overlay = () => _resources.Overlay };
        PolledSystemToast packToast = new();
        MinecraftClient? warnedInsecure = null;
        _guiLayer.Toasts = context => {
            ToastManager toasts = context.Toasts;
            toasts.NotificationDisplayTimeMultiplier = _settings.NotificationDisplayTime;
            toasts.FollowMusicToastOption(_settings.MusicToast, _settings.FinalSoundSourceVolume(Minecraft.Schemas.Sound.SoundCategory.Music) > 0.0F);
            packToast.Follow(toasts, _resources.ServerPacks.Toast);
            if (_client.InsecureChatToast is { } insecure && warnedInsecure != _client) {
                warnedInsecure = _client;
                SystemToast.Add(toasts, SystemToastId.UnsecureServerWarning, insecure.Title, insecure.Message);
            }
            toasts.Update(context);
            // Hud.isHidden: F1 takes the toasts with the rest of the HUD.
            if (!_renderer.HideGui) {
                toasts.Render(context);
            }
        };
        _context.Host = this;
        _panorama = new PanoramaRenderer(_gl);
        _input.CaptureMouse(true);

        _renderer.HookClient();
        _screens.HookClient();
        if (_options.ServerGiven && !_options.Title) {
            JoinQuickPlay();
        }
        else {
            _screens.Set(new TitleScreen());
        }
        _clock.Start();
    }

    /// <summary>
    /// The loading logo, the sounds and the renderer, in that order after the language. All read the packs on workers,
    /// the renderer on <see cref="SharedGlContext"/>'s thread so its textures and buffers are made there too.
    /// </summary>
    private IReadOnlyList<ReloadListener> ReloadListeners() {
        HashSet<string> fontOptions = _renderer.FontOptions();
        Func<byte[]?> logo = _resources.VanillaFile(LoadingLogo.Location);
        return [
            new ReloadListener(_ => Task.Run<object>(() => new System.Runtime.CompilerServices.StrongBox<Assets.ResourcePacks.TextureImage?>(LoadingLogo.Read(logo))),
                prepared => _logo.Set(((System.Runtime.CompilerServices.StrongBox<Assets.ResourcePacks.TextureImage?>)prepared).Value)),
            new ReloadListener(files => Task.Run<object>(() => (files, new Audio.SoundRegistry(files))), prepared => {
                (Assets.ResourcePacks.PackFiles? files, Audio.SoundRegistry registry) = ((Assets.ResourcePacks.PackFiles?, Audio.SoundRegistry))prepared;
                _audio.Apply(files, registry);
            }),
            new ReloadListener(files => _uploadContext.Run<object>(() => _renderer.Build(files, fontOptions)), prepared => {
                _renderer.Swap((PackResources)prepared);
                (_context.Text, _context.Icons, _context.Items, _context.Sprites, _context.EntityRenderer) =
                    (_renderer.Text, _renderer.Icons, _renderer.Items, _renderer.Sprites, _renderer.GuiEntities);
                _screens.Current?.InvalidateLayout();
            }, prepared => ((PackResources)prepared).Dispose()),
            new ReloadListener(files => Task.Run<object>(() => SplashManager.Prepare(files)), prepared => _splashes.Apply((IReadOnlyList<string>)prepared))
        ];
    }

    private void OnRender(double delta) {
        Stopwatch frame = Stopwatch.StartNew();
        double now = _clock.Elapsed.TotalSeconds;
        _realtimeDeltaTicks = (float)(delta * 1000.0 / TickMillis);
        _profiler.Begin("resources");
        _resources.StartPendingReload();
        _profiler.Begin("packets");
        if (_client.Phase != ClientPhase.Disconnected) {
            _livePhase = _client.Phase;
        }
        _client.ProcessPackets();
        if (_client.Phase == ClientPhase.Disconnected && !_disconnectHandled) {
            _disconnectHandled = true;
            OnDisconnected();
        }
        _profiler.Begin("resources");
        _resources.RunTasks();
        _profiler.Begin("packets");
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
            player.SprintWindow = _settings.SprintWindow;
            player.AutoJumpOption = _settings.AutoJump;
        }
        _resources.Overlay?.Tick();
        _input.TickInteractions(_script.HoldsUse(_input), _script.HoldsAttack(_input));
        _profiler.Begin("tick:client");
        _audio.TickPlayer();
        _client.Tick();
        _profiler.Begin("tick:renderers");
        _renderer.Tick();
        _audio.Tick();
        _screens.Tick();
        _profiler.Begin("ticks");
        _script.SendCommands();
        _script.WatchHotbar();
    }

    private void UpdateTitle() {
        string where = _client.Player is { } player ? $"{player.Position.X:F1} {player.Position.Y:F1} {player.Position.Z:F1}" : _client.Phase.ToString();
        _window.Title = $"mcdotnet - {_fps} fps - {where}";
        if (!_options.Verbose) {
            return;
        }
        TimeSpan pause = GC.GetTotalPauseDuration();
        string gc = $"gc {GC.CollectionCount(0) - _gcCounts[0]}/{GC.CollectionCount(1) - _gcCounts[1]}/{GC.CollectionCount(2) - _gcCounts[2]} paused {(pause - _gcPause).TotalMilliseconds:F1} ms heap {GC.GetTotalMemory(false) >> 20} MB";
        _gcCounts = [GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2)];
        _gcPause = pause;
        (double lightTotal, double lightLongest) = _client.Level?.Light.TakeMilliseconds() ?? (0, 0);
        gc += $" light {lightTotal:F0} ms/s (longest {lightLongest:F1}) entities {_client.Entities.Count} sounds {_audio.Playing}";
        (int opaqueParticles, int translucentParticles) = _renderer.Scene.Particles.Quads.Drawn;
        gc += $" particles {opaqueParticles}+{translucentParticles}";
        if (_client.Level is { } level) {
            gc += $" day time {level.DefaultClockTime} game time {level.GameTime} tick rate {level.TickRateManager.TickRate}{(level.TickRateManager.IsFrozen ? " frozen" : "")}";
        }
        WorldRenderer world = _renderer.World;
        WorldScene scene = _renderer.Scene;
        scene.Entities.TimeByType = true;
        double frames = Math.Max(1, _fps), perFrame = 1000.0 / Stopwatch.Frequency / frames;
        gc += $" collect entities {scene.CollectTicks[0] * perFrame:F2} blockEntities {scene.CollectTicks[1] * perFrame:F2} particles {scene.CollectTicks[2] * perFrame:F2} ms/frame"
              + $" ({string.Join(", ", scene.Entities.TakeTimings().Take(6).Select(t => $"{t.Type.Identifier.Key} {t.Count / frames:F0}x {t.Milliseconds / frames:F2}"))})";
        Array.Clear(scene.CollectTicks);
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

    public string DataDirectory => ClientDirectory;

    /// <summary>Where the options, <c>servers.dat</c> and the cached sign in live.</summary>
    public static string ClientDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mcdotnet-client");

    public GL Gl => _gl;

    public void RenderPanorama(GuiContext context) => _panorama.Render(context, _realtimeDeltaTicks, _clock.Elapsed.TotalSeconds);

    public void Quit() => _window.Close();

    public SplashRenderer? GetSplash() => _splashes.GetSplash(DateTime.Now);

    private MinecraftClient CreateClient() {
        MinecraftClient client = new(_clientOptions);
        AttachPacks(client);
        client.Log += message => Console.WriteLine(message);
        client.ChatMessages.Logged += message => Console.WriteLine(message);
        client.ChatListener.OnlyShowSecureChat = () => _settings.OnlyShowSecureChat;
        client.ChatListener.SetMessageDelay(_settings.ChatDelay);
        client.AdvancementToast += node => _context?.Toasts.Add(new AdvancementToast(node));
        client.RecipeToastRequested += recipe => {
            if (_context != null) {
                RecipeToast.AddOrUpdate(_context.Toasts, recipe, client.SlotDisplayContext());
            }
        };
        client.RecipeSearchLines = stack => Gui.Inventory.Tooltips.Lines(stack).Select(line => string.Concat(line.Select(run => run.Text)).Trim());
        if (_options.LogSent) {
            client.PacketSent += packet => LaunchScript.LogSent(client, packet);
        }
        if (_options.LogInventory) {
            client.PacketReceived += packet => LaunchScript.LogInventory(client, packet);
        }
        return client;
    }

    /// <summary>
    /// Leaves the current connection for a fresh client: <c>Minecraft.disconnect</c>'s teardown, which drops
    /// the level, its sections, entities and sounds, with the old client's events left to go with it.
    /// </summary>
    private void SwapClient() {
        if (_client.Phase is not (ClientPhase.Idle or ClientPhase.Disconnected)) {
            _client.Disconnect("Quit");
        }
        _client = CreateClient();
        _context.Toasts.Clear();
        _disconnectHandled = false;
        _livePhase = ClientPhase.Idle;
        _renderer.Attach(_client);
        _audio.Attach(_client);
        _context.Sounds = _audio.Sounds;
        _context.Client = _client;
        _input.Attach(_client);
        _screens.Attach(_client);
        _guiLayer.Client = _client;
        _script.Attach(_client);
    }

    /// <summary>
    /// <c>QuickPlay.joinMultiplayerWorld</c> for <c>--server</c>: the saved entry with that address, then the
    /// join, with the HUD's own connecting message rather than a connect screen. Vanilla saves a hidden entry
    /// for an address it has not seen; a launch flag never writes to the saved files here, so an unknown
    /// address joins with an entry that lives for the run only.
    /// </summary>
    private void JoinQuickPlay() {
        ServerList servers = new(ClientDirectory);
        servers.Load();
        ServerData server = servers.Get(_options.ServerText)
            ?? new ServerData(Menus.T("selectServer.defaultName"), _options.ServerText, ServerType.Other);
        PrepareJoin(server, _options.Menus ? new JoinMultiplayerScreen(new TitleScreen()) : null);
        Observe(_client.Connect(_options.Host, _options.Port));
    }

    public void Join(Screen parent, ServerData server) => StartConnecting(parent, server, ServerAddress.Parse(server.Ip), null);

    /// <summary>
    /// <c>ConnectScreen.startConnecting</c>: the old connection dropped, then the join on a fresh client. A
    /// transfer carries the old client's cookies and says so in its handshake.
    /// </summary>
    private void StartConnecting(Screen? parent, ServerData server, ServerAddress address, MinecraftClient? transferredFrom) {
        if (_screens.Current is ConnectScreen) {
            Console.Error.WriteLine("Attempt to connect while already connecting");
            return;
        }
        SwapClient();
        if (transferredFrom != null) {
            foreach ((Minecraft.Schemas.Identifier key, byte[] value) in transferredFrom.Cookies) {
                _client.Cookies[key] = value;
            }
            _client.PendingTransferIntent = true;
        }
        PrepareJoin(server, parent);
        if (parent != null) {
            _screens.Set(new ConnectScreen(parent, transferredFrom != null));
        }
        Console.WriteLine($"Connecting to {address.Host}, {address.Port}");
        _connectAbort = new CancellationTokenSource();
        Observe(_client.Connect(address, _connectAbort.Token));
    }

    /// <summary>The server's pack policy, unless <c>--server-packs</c> overrides it, and the entry saved when a prompt changes it.</summary>
    private void PrepareJoin(ServerData server, Screen? postDisconnect) {
        _server = server;
        _postDisconnect = postDisconnect;
        if (_options.ServerPacks == null) {
            _clientOptions.ServerPackStatus = server.ResourcePackStatus;
        }
        _client.ServerPackStatusChanged += status => {
            // An answer --server-packs gave is for this run, so the entry keeps its own policy.
            if (_options.ServerPacks != null) {
                return;
            }
            server.ResourcePackStatus = status;
            _ = ServerList.SaveSingleServer(ClientDirectory, server);
        };
    }

    /// <summary>A failed connect is reported through the client's phase; the task's exception only needs seeing.</summary>
    private static void Observe(Task connecting) => connecting.ContinueWith(task => _ = task.Exception, TaskContinuationOptions.OnlyOnFaulted);

    public void Abort(Screen parent) {
        _connectAbort?.Cancel();
        SwapClient();
        _screens.Set(parent);
    }

    /// <summary>The pause menu's Disconnect: <c>Minecraft.disconnectFromWorld</c> where there is a server list to go to.</summary>
    private void LeaveServer() {
        if (!_options.Menus) {
            _window.Close();
            return;
        }
        SwapClient();
        _screens.Set(new JoinMultiplayerScreen(new TitleScreen()));
    }

    /// <summary>
    /// <c>ClientCommonPacketListenerImpl.onDisconnect</c> and the handshake listener's: a transfer goes on to
    /// its server, anything else shows why, titled by whether the login got through.
    /// </summary>
    private void OnDisconnected() {
        MinecraftClient client = _client;
        string reason = client.DisconnectReason ?? "Disconnected";
        Console.WriteLine($"Disconnected: {reason}");
        if (client.PendingTransfer is { } transfer && _server != null) {
            StartConnecting(_postDisconnect, _server, new ServerAddress(transfer.Host, transfer.Port), client);
            return;
        }
        bool loggedIn = _livePhase is ClientPhase.Configuration or ClientPhase.Play;
        if (client.Connection == null && !_options.Menus) {
            ExitCode = 1;
        }
        TextComponent title = TextComponent.Translatable(loggedIn ? "disconnect.lost" : "connect.failed");
        DisconnectedScreen screen = new(title, client.DisconnectReasonText ?? TextComponent.Text(reason), _options.Menus ? _postDisconnect : null);
        if (_options.Menus) {
            SwapClient();
        }
        _screens.Set(screen);
    }

    /// <summary>
    /// Gives a connection the window's server packs, which outlive it, and the pack prompt. <c>--server-packs</c>
    /// replaces the server's own policy, and with <c>decline</c> also answers no for the player when a required
    /// pack asks anyway.
    /// </summary>
    private void AttachPacks(MinecraftClient client) {
        client.ServerPacks = _resources.ServerPacks;
        if (_options.ServerPacks is { } policy) {
            client.Options.ServerPackStatus = policy;
        }
        client.ResourcePackPrompt += request => {
            if (_options.ServerPacks == ClientLib.Multiplayer.ServerPackStatus.Disabled) {
                client.AnswerPackPrompt([request.Request], request.Required, false);
            }
            else {
                _screens.Set(PackConfirmScreen.AddOrUpdate(_screens.Current, client, _screens.Set, request));
            }
        };
    }

    /// <summary>GL objects go here, while the context still exists; after <c>Run</c> returns it does not.</summary>
    private void OnClosing() {
        if (_closed) {
            return;
        }
        _closed = true;
        _resources.AbandonReload();
        _uploadContext.Dispose();
        _client.Disconnect("Quit");
        _panorama.Dispose();
        _logo.Dispose();
        _renderer.Dispose();
        _audio.Dispose();
        _resources.Dispose();
    }

    /// <summary>
    /// The window is left to the process: Silk refuses to reset a window whose loop was closed from
    /// inside a frame, and nothing outlives the process anyway.
    /// </summary>
    public void Dispose() {
    }
}
