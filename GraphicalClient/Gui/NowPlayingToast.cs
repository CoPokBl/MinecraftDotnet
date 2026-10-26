using ClientLib;
using GraphicalClient.Rendering.Entities.Vanilla;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>NowPlayingToast</c>: the song playing, named beside a note icon whose colour cycles, in the top left
/// corner. As a toast it slides in for five seconds when a song starts; the pause screen draws the same
/// face in the same place for as long as the song plays.
/// </summary>
public sealed class NowPlayingToast(Func<string?> currentSong) : Toast {
    private const int Padding = 7, MusicNotesSize = 16, ToastHeight = 30, MusicNotesSpace = 30, VisibilityDuration = 5000;
    private const long MusicColorChangeFrequencyMs = 25;

    /// <summary><c>DyeColor.LIGHT_GRAY.getTextColor</c>.</summary>
    private const uint TextColor = 0xFFD3D3D3;

    /// <summary>What a song of the built in sounds is called, there being no language entry for it.</summary>
    private const string BuiltInSongKey = "mcdotnet_dev.music";

    private static int _musicNoteColorTick;
    private static long _lastMusicNoteColorChange;
    private static uint _musicNoteColor = 0xFFFFFFFF;

    private bool _updateToast;
    private double _notificationDisplayTimeMultiplier;
    private ToastVisibility _wantedVisibility = ToastVisibility.Hide;
    private int _width = MusicNotesSpace + Padding;

    public override ToastVisibility WantedVisibility => _wantedVisibility;
    public override int Width => _width;
    public override int Height => ToastHeight;

    public override float XPos(int screenWidth, float visiblePortion) => Width * visiblePortion - Width;

    public override float YPos(int firstSlotIndex) => 0.0F;

    public override void Measure(TextRenderer text) => _width = GetWidth(currentSong(), text);

    /// <summary><c>showToast</c>: in again for the full display time.</summary>
    public void ShowToast(double notificationDisplayTimeMultiplier) {
        _updateToast = true;
        _notificationDisplayTimeMultiplier = notificationDisplayTimeMultiplier;
        _wantedVisibility = ToastVisibility.Show;
    }

    public void SetWantedVisibility(ToastVisibility visibility) => _wantedVisibility = visibility;

    public override void Update(ToastManager manager, long fullyVisibleForMs) {
        if (_updateToast) {
            _wantedVisibility = fullyVisibleForMs < VisibilityDuration * _notificationDisplayTimeMultiplier ? ToastVisibility.Show : ToastVisibility.Hide;
            TickMusicNotes(currentSong());
        }
    }

    public override void OnFinishedRendering() => _updateToast = false;

    public override void Render(GuiContext context, float x, float y, long fullyVisibleForMs) => Draw(context, currentSong(), x, y);

    /// <summary><c>extractToast</c>: nothing while no song plays.</summary>
    public static void Draw(GuiContext context, string? song, float x, float y) {
        if (song == null) {
            return;
        }
        string name = NowPlayingString(song);
        context.Sprites.NineSliced(context.Gui, "toast/now_playing", x, y, MusicNotesSpace + context.Text.Width(name) + Padding, ToastHeight, 4);
        context.Sprites.AnimatedSprite(context.Gui, "icon/music_notes", Environment.TickCount64 / 50, x + Padding, y + Padding, MusicNotesSize,
            MusicNotesSize, _musicNoteColor);
        context.Text.Draw(name, x + MusicNotesSpace, y + ToastHeight / 2 - 9 / 2, TextColor);
    }

    /// <summary>
    /// <c>tickMusicNotes</c>: the notes move one step round their colours at most every 25 ms, so once a frame
    /// under the toast and once a tick under the pause screen.
    /// </summary>
    public static void TickMusicNotes(string? song) {
        if (song == null) {
            return;
        }
        long now = Environment.TickCount64;
        if (now > _lastMusicNoteColorChange + MusicColorChangeFrequencyMs) {
            _musicNoteColorTick++;
            _lastMusicNoteColorChange = now;
            _musicNoteColor = ColorLerper.GetLerpedMusicNoteColor(_musicNoteColorTick);
        }
    }

    private static int GetWidth(string? song, TextRenderer text) =>
        MusicNotesSpace + (song == null ? 0 : text.Width(NowPlayingString(song))) + Padding;

    private static (string Key, int Generation, string Name)? _lastName;

    /// <summary>The song's name in the current language, kept from frame to frame while the song and language stay.</summary>
    private static string NowPlayingString(string songKey) {
        if (_lastName is { } last && ReferenceEquals(last.Key, songKey) && last.Generation == Translations.Generation) {
            return last.Name;
        }
        string key = songKey.Replace('/', '.');
        string name = Translations.Get(key)
            ?? (key.StartsWith(Audio.Sound.DevNamespace + ".", StringComparison.Ordinal) ? Translations.Get(BuiltInSongKey) : null)
            ?? key;
        _lastName = (songKey, Translations.Generation, name);
        return name;
    }
}
