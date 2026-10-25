using ClientLib;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Audio;
using GraphicalClient.Rendering;

namespace GraphicalClient;

/// <summary>The sound engine and everything that plays through it, wired to the client and heard from the camera.</summary>
public sealed class GameAudio : IDisposable {
    private readonly SoundEngine _engine;
    private readonly Camera _camera;
    private readonly GameSettings _settings;
    private MusicManager _music = null!;
    private LocalPlayerAmbience _ambience = null!;
    private WeatherEffectSounds _weather = null!;
    private WorldSounds _world = null!;
    private LocalPlayerSounds _player = null!;
    private ItemUseSounds _itemUse = null!;

    public ClientSounds Sounds { get; private set; } = null!;
    public int Playing => _engine.Playing;

    /// <summary>Where the music manager tells of songs starting and stopping.</summary>
    public Gui.ToastManager? Toasts {
        get => _music.Toasts;
        set => _music.Toasts = value;
    }

    public GameAudio(PackFiles? packs, MinecraftClient client, Camera camera, GameSettings settings) {
        _settings = settings;
        _engine = new SoundEngine(packs);
        _camera = camera;
        Attach(client);
        settings.Volumes.CopyTo(_engine.CategoryVolumes);
        Console.WriteLine(_engine.Available ? $"Sound: {_engine.Registry.Count} events from the packs, the rest built in" : "Sound: no audio device");
    }

    /// <summary>
    /// Wires every sound to a connection, the first or a fresh one after a disconnect, which stops whatever
    /// was playing as <c>Minecraft.disconnect</c> does. The engine and its loaded sounds stay.
    /// </summary>
    public void Attach(MinecraftClient client) {
        _engine.StopAll();
        Func<(double X, double Y, double Z)> listener = () => (_camera.Position.X, _camera.Position.Y, _camera.Position.Z);
        Sounds = new ClientSounds(_engine, client, listener);
        client.PacketReceived += Sounds.Handle;
        _music = new MusicManager(_engine, client, listener) { Frequency = _settings.MusicFrequency, Toasts = _music?.Toasts };
        Sounds.Music = _music;
        _ambience = new LocalPlayerAmbience(Sounds, client);
        _weather = new WeatherEffectSounds(Sounds, client, listener, () => _settings.WeatherRadius);
        // Minecraft.updateLevelInEngines: a new level stops every sound.
        client.LevelChanged += _ => _engine.StopAll();
        _world = new WorldSounds(Sounds, client, listener);
        client.PacketReceived += _world.Handle;
        _player = new LocalPlayerSounds(Sounds, client);
        _ = new GameModeSounds(Sounds, client);
        _itemUse = new ItemUseSounds(Sounds, client);
        client.PacketReceived += _itemUse.Handle;
    }

    /// <inheritdoc cref="SoundEngine.Apply"/>
    public void Apply(PackFiles? packs, SoundRegistry registry) => _engine.Apply(packs, registry);

    /// <summary>The local player's own sounds, which run ahead of the client's tick.</summary>
    public void TickPlayer() {
        _player.Tick();
        _itemUse.Tick();
    }

    public void Tick() {
        _world.Tick();
        _ambience.Tick();
        if (_settings.MusicFrequency != _music.Frequency) {
            _music.SetMinutesBetweenSongs(_settings.MusicFrequency);
        }
        _music.Tick();
        _engine.Tick();
        _weather.Tick();
    }

    public void UpdateListener(Camera camera) {
        _engine.UpdateListener(new System.Numerics.Vector3((float)camera.Position.X, (float)camera.Position.Y, (float)camera.Position.Z), camera.Forward, camera.Up);
    }

    public void Dispose() => _engine.Dispose();
}
