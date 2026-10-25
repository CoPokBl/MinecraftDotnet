using GraphicalClient.Audio;
using Minecraft.Schemas.Sound;

namespace GraphicalClient;

/// <summary><c>MusicToastDisplayState</c>: where the song playing is named.</summary>
public enum MusicToastDisplayState {
    Never,
    Pause,
    PauseAndToast
}

public static class MusicToastDisplayStates {
    /// <summary>The values in their order, as the option's button cycles them.</summary>
    public static readonly MusicToastDisplayState[] All = [MusicToastDisplayState.Never, MusicToastDisplayState.Pause, MusicToastDisplayState.PauseAndToast];

    public static bool RenderInPauseScreen(this MusicToastDisplayState state) => state != MusicToastDisplayState.Never;

    public static bool RenderToast(this MusicToastDisplayState state) => state == MusicToastDisplayState.PauseAndToast;

    /// <summary><c>getSerializedName</c>, what <c>options.txt</c> stores.</summary>
    public static string SerializedName(this MusicToastDisplayState state) => state switch {
        MusicToastDisplayState.Pause => "pause",
        MusicToastDisplayState.PauseAndToast => "pause_and_toast",
        _ => "never"
    };

    public static string TranslationKey(this MusicToastDisplayState state) => state switch {
        MusicToastDisplayState.Pause => "options.musicToast.pauseMenu",
        MusicToastDisplayState.PauseAndToast => "options.musicToast.pauseMenuAndToast",
        _ => "options.musicToast.never"
    };
}

/// <summary>The music options from the sound screen's last row.</summary>
public sealed partial class GameSettings {
    /// <summary><c>musicFrequency</c>.</summary>
    public MusicFrequency MusicFrequency { get; set; } = MusicFrequency.Default;

    /// <summary><c>musicToast</c>.</summary>
    public MusicToastDisplayState MusicToast { get; set; } = MusicToastDisplayState.Never;

    /// <summary><c>Options.getFinalSoundSourceVolume</c>: a category's slider times the master slider.</summary>
    public float FinalSoundSourceVolume(SoundCategory source) =>
        source == SoundCategory.Master ? Volumes[(int)source] : Volumes[(int)source] * Volumes[(int)SoundCategory.Master];

    /// <summary>The music lines; null for a key that is neither. Both are enum codecs, stored as JSON strings.</summary>
    private bool? ReadMusic(string key, string value) {
        switch (key) {
            case "musicFrequency":
                if (MusicFrequency.All.FirstOrDefault(frequency => frequency.Name == value.Trim('"')) is not { } frequency) {
                    return false;
                }
                MusicFrequency = frequency;
                return true;
            case "musicToast":
                if (Array.FindIndex(MusicToastDisplayStates.All, state => state.SerializedName() == value.Trim('"')) is not (>= 0 and var index)) {
                    return false;
                }
                MusicToast = MusicToastDisplayStates.All[index];
                return true;
        }
        return null;
    }

    private IEnumerable<string> MusicLines() => [
        $"musicFrequency:\"{MusicFrequency.Name}\"",
        $"musicToast:\"{MusicToast.SerializedName()}\""
    ];
}
