using ClientLib;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Audio;
using GraphicalClient.Rendering;

namespace GraphicalClient;

/// <summary>The sound engine and everything that plays through it, wired to the client and heard from the camera.</summary>
public sealed class GameAudio : IDisposable {
    private readonly SoundEngine _engine;
    private readonly MusicManager _music;
    private readonly LocalPlayerAmbience _ambience;
    private readonly WeatherEffectSounds _weather;
    private readonly WorldSounds _world;
    private readonly LocalPlayerSounds _player;
    private readonly ItemUseSounds _itemUse;

    public ClientSounds Sounds { get; }
    public int Playing => _engine.Playing;

    public GameAudio(PackFiles? packs, MinecraftClient client, Camera camera, GameSettings settings) {
        Func<(double X, double Y, double Z)> listener = () => (camera.Position.X, camera.Position.Y, camera.Position.Z);
        _engine = new SoundEngine(packs);
        Sounds = new ClientSounds(_engine, client, listener);
        client.PacketReceived += Sounds.Handle;
        _music = new MusicManager(_engine, client, listener);
        _ambience = new LocalPlayerAmbience(Sounds, client);
        _weather = new WeatherEffectSounds(Sounds, client, listener);
        // Minecraft.updateLevelInEngines: a new level stops every sound.
        client.LevelChanged += _ => _engine.StopAll();
        _world = new WorldSounds(Sounds, client, listener);
        client.PacketReceived += _world.Handle;
        _player = new LocalPlayerSounds(Sounds, client);
        _ = new GameModeSounds(Sounds, client);
        _itemUse = new ItemUseSounds(Sounds, client);
        client.PacketReceived += _itemUse.Handle;
        settings.Volumes.CopyTo(_engine.CategoryVolumes);
        Console.WriteLine(_engine.Available ? $"Sound: {_engine.Registry.Count} events from the packs, the rest built in" : "Sound: no audio device");
    }

    /// <summary>The local player's own sounds, which run ahead of the client's tick.</summary>
    public void TickPlayer() {
        _player.Tick();
        _itemUse.Tick();
    }

    public void Tick() {
        _world.Tick();
        _ambience.Tick();
        _music.Tick();
        _engine.Tick();
        _weather.Tick();
    }

    public void UpdateListener(Camera camera) {
        _engine.UpdateListener(new System.Numerics.Vector3((float)camera.Position.X, (float)camera.Position.Y, (float)camera.Position.Z), camera.Forward, camera.Up);
    }

    public void Dispose() => _engine.Dispose();
}
