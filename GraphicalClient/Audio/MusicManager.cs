using ClientLib;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Gui;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Music = Minecraft.Data.EnvironmentAttributes.Music;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace GraphicalClient.Audio;

/// <summary><c>Musics</c>: the music vanilla picks in code rather than from an environment attribute.</summary>
public static class Musics {
    public static readonly Music Menu = new(new SoundEvent(SoundType.Menu, null), 20, 600, true);
    public static readonly Music Credits = new(new SoundEvent(SoundType.Credits, null), 0, 0, true);
    public static readonly Music EndBoss = new(new SoundEvent(SoundType.Dragon, null), 0, 0, true);
}

/// <summary>
/// <c>MusicManager</c>, with <c>Minecraft.getSituationalMusic</c> and <c>getMusicVolume</c> deciding what plays,
/// telling <see cref="Toasts"/> when a song starts and stops for the now playing toast.
/// </summary>
public sealed class MusicManager(SoundEngine engine, MinecraftClient client, Func<(double X, double Y, double Z)> camera) {
    private const int StartingDelay = 100;

    private static readonly Identifier End = "minecraft:the_end";

    private readonly LegacyRandom _random = new();
    private SoundInstance? _currentMusic;
    private float _currentGain = 1.0F;
    private int _nextSongDelay = StartingDelay;
    private Identifier? _dimension;
    private LocalPlayer? _player;
    private bool _toastShown;

    /// <summary><c>Options.musicFrequency</c>; set it through <see cref="SetMinutesBetweenSongs"/> once playing.</summary>
    public MusicFrequency Frequency { get; set; } = MusicFrequency.Default;

    public ToastManager? Toasts { get; set; }

    /// <summary><c>setMinutesBetweenSongs</c>: the option changed, and the wait for the next song is drawn again.</summary>
    public void SetMinutesBetweenSongs(MusicFrequency frequency) {
        Frequency = frequency;
        _nextSongDelay = frequency.NextSongDelay(SituationalMusic(), _random);
    }

    public void Tick() {
        // ClientPacketListener.handleRespawn stops the music when the respawn changes dimension. Its next song
        // delay is drawn for the new level at the old camera position, where vanilla's camera probe still holds
        // the old level for that one call; only the delay range can differ.
        if (client.Player != _player) {
            if (_player != null && client.Player != null && client.Level != null && !client.Level.Name.Equals(_dimension)) {
                StopPlaying();
            }
            _player = client.Player;
            _dimension = client.Level?.Name;
        }

        float volume = MusicVolume();
        if (_currentMusic != null && _currentGain != volume && !FadePlaying(volume)) {
            return;
        }

        Music? music = SituationalMusic();
        if (music == null) {
            _nextSongDelay = Math.Max(_nextSongDelay, StartingDelay);
        }
        else {
            if (_currentMusic != null) {
                if (CanReplace(music, _currentMusic)) {
                    engine.Stop(_currentMusic);
                    _nextSongDelay = _random.MthNextInt(0, music.MinDelay / 2);
                }
                if (!engine.IsActive(_currentMusic)) {
                    _currentMusic = null;
                    _nextSongDelay = Math.Min(_nextSongDelay, Frequency.NextSongDelay(music, _random));
                }
            }
            _nextSongDelay = Math.Min(_nextSongDelay, music.MaxDelay);
            // LevelLoadingScreen is up from a join or respawn until the client has loaded.
            bool levelLoading = client.Player != null && !client.ClientLoaded;
            if (_currentMusic == null && !levelLoading && --_nextSongDelay <= 0) {
                StartPlaying(music);
            }
        }
    }

    /// <summary>
    /// <c>Minecraft.getSituationalMusic</c>. Only <c>WinScreen</c> has screen music upstream, and this client
    /// skips the credits, so <see cref="Musics.Credits"/> never comes up.
    /// </summary>
    private Music? SituationalMusic() {
        LocalPlayer? player = client.Player;
        ClientLevel? level = client.Level;
        if (player == null || level == null) {
            return Musics.Menu;
        }
        if (level.Name.Equals(End) && client.BossOverlay.ShouldPlayMusic()) {
            return Musics.EndBoss;
        }
        (double x, double y, double z) = camera();
        BackgroundMusic backgroundMusic = AudioEnvironment.BackgroundMusic(level, x, y, z);
        return Select(backgroundMusic, player.InstaBuild && player.MayFly, player.IsUnderWater);
    }

    /// <summary><c>BackgroundMusic.select</c>.</summary>
    private static Music? Select(BackgroundMusic music, bool isCreative, bool isUnderwater) {
        if (isUnderwater && music.Underwater != null) {
            return music.Underwater;
        }
        return isCreative && music.Creative != null ? music.Creative : music.Default;
    }

    /// <summary><c>Minecraft.getMusicVolume</c>, read at the camera; with no level the attribute's default.</summary>
    private float MusicVolume() {
        if (client.Level is not { } level) {
            return 1.0F;
        }
        (double x, double y, double z) = camera();
        return AudioEnvironment.MusicVolume(level, x, y, z);
    }

    private static bool CanReplace(Music music, SoundInstance currentMusic) =>
        music.ReplaceCurrentMusic && !music.Sound.Type.Identifier.Equals(currentMusic.Identifier);

    private void StartPlaying(Music music) {
        _currentMusic = SoundInstance.ForMusic(music.Sound.Type.Identifier);
        switch (engine.Play(_currentMusic)) {
            case PlayResult.Started:
                Toasts?.ShowNowPlayingToast();
                _toastShown = true;
                break;
            case PlayResult.StartedSilently:
                _toastShown = false;
                break;
        }
        _nextSongDelay = int.MaxValue;
    }

    /// <summary>The music volume came up from nothing: a song that started silently gets its toast now.</summary>
    public void ShowNowPlayingToastIfNeeded() {
        if (!_toastShown) {
            Toasts?.ShowNowPlayingToast();
            _toastShown = true;
        }
    }

    private void StopPlaying() {
        if (_currentMusic != null) {
            engine.Stop(_currentMusic);
            _currentMusic = null;
            Toasts?.HideNowPlayingToast();
        }
        _nextSongDelay = Frequency.NextSongDelay(SituationalMusic(), _random) + StartingDelay;
    }

    /// <summary>
    /// <c>getCurrentMusicTranslationKey</c>: the key of the file the song resolved to rather than of its event, so
    /// the language names the track. Null while nothing plays.
    /// </summary>
    public string? CurrentMusicTranslationKey {
        get {
            if (_currentMusic?.Sound is not { } sound) {
                return null;
            }
            if (!ReferenceEquals(sound, _keyedSound)) {
                _keyedSound = sound;
                _key = sound.Location.Namespace == "minecraft" ? sound.Location.Key : $"{sound.Location.Namespace}.{sound.Location.Key}";
            }
            return _key;
        }
    }

    private Sound? _keyedSound;
    private string? _key;

    private bool FadePlaying(float volume) {
        if (_currentMusic == null) {
            return false;
        }
        if (_currentGain == volume) {
            return true;
        }
        if (_currentGain < volume) {
            _currentGain += Math.Clamp(_currentGain, 5.0E-4F, 0.005F);
            if (_currentGain > volume) {
                _currentGain = volume;
            }
        }
        else {
            _currentGain = 0.03F * volume + 0.97F * _currentGain;
            if (Math.Abs(_currentGain - volume) < 1.0E-4F || _currentGain < volume) {
                _currentGain = volume;
            }
        }
        _currentGain = Math.Clamp(_currentGain, 0.0F, 1.0F);
        if (_currentGain <= 1.0E-4F) {
            StopPlaying();
            return false;
        }
        engine.UpdateCategoryVolume(SoundCategory.Music, _currentGain);
        return true;
    }
}

/// <summary><c>MusicManager.MusicFrequency</c>: the longest wait between songs, in minutes.</summary>
public sealed class MusicFrequency {
    public static readonly MusicFrequency Default = new("DEFAULT", "options.music_frequency.default", 20);
    public static readonly MusicFrequency Frequent = new("FREQUENT", "options.music_frequency.frequent", 10);
    public static readonly MusicFrequency Constant = new("CONSTANT", "options.music_frequency.constant", 0);

    public static readonly MusicFrequency[] All = [Default, Frequent, Constant];

    private readonly int _maxFrequency;

    private MusicFrequency(string name, string caption, int maxFrequencyMinutes) {
        Name = name;
        Caption = caption;
        _maxFrequency = maxFrequencyMinutes * 1200;
    }

    /// <summary><c>getSerializedName</c>, what <c>options.txt</c> stores.</summary>
    public string Name { get; }

    /// <summary>The translation key of its name on the option's button.</summary>
    public string Caption { get; }

    /// <summary><c>getNextSongDelay</c>.</summary>
    public int NextSongDelay(Music? music, LegacyRandom random) {
        if (music == null) {
            return _maxFrequency;
        }
        if (this == Constant) {
            return 100;
        }
        int minFrequency = Math.Min(music.MinDelay, _maxFrequency);
        int maxFrequency = Math.Min(music.MaxDelay, _maxFrequency);
        return random.MthNextInt(minFrequency, maxFrequency);
    }
}
