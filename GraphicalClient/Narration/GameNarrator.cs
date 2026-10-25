using System.Collections.Concurrent;
using System.Diagnostics;
using ClientLib;
using Minecraft.Schemas.Sound;
using Minecraft.Text;

namespace GraphicalClient.Narration;

/// <summary><c>NarratorStatus</c>, by its stored id.</summary>
public enum NarratorStatus {
    Off,
    All,
    Chat,
    System
}

public static class NarratorStatusExtensions {
    public static bool ShouldNarrateChat(this NarratorStatus status) => status is NarratorStatus.All or NarratorStatus.Chat;

    public static bool ShouldNarrateSystem(this NarratorStatus status) => status is NarratorStatus.All or NarratorStatus.System;

    public static bool ShouldNarrateSystemOrChat(this NarratorStatus status) => status != NarratorStatus.Off;

    public static string TranslationKey(this NarratorStatus status) => "options.narrator." + status.ToString().ToLowerInvariant();
}

/// <summary>
/// The speech vanilla gets from its text to speech library, from whichever of speech-dispatcher's
/// <c>spd-say</c> and <c>espeak-ng</c> is on the path; without either it is inactive, as vanilla's narrator
/// is where the library will not load. Messages are spoken one after another off the game thread.
/// </summary>
public sealed class TtsNarrator : IDisposable {
    private readonly string? _command;
    private readonly BlockingCollection<(string Text, float Volume)> _queue = new();
    private readonly object _lock = new();
    private Process? _speaking;

    public TtsNarrator() {
        _command = Find("spd-say") ?? Find("espeak-ng");
        if (_command != null) {
            new Thread(Speak) { IsBackground = true, Name = "Narrator" }.Start();
        }
    }

    public bool Active => _command != null;

    private static string? Find(string name) =>
        (Environment.GetEnvironmentVariable("PATH") ?? "").Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries)
        .Select(dir => Path.Combine(dir, name)).FirstOrDefault(File.Exists);

    /// <summary><c>Narrator.say</c>: interrupting drops whatever is queued or being spoken first.</summary>
    /// <param name="volume">0 to 1.</param>
    public void Say(string text, bool interrupt, float volume) {
        if (!Active) {
            return;
        }
        if (interrupt) {
            Clear();
        }
        _queue.Add((text, volume));
    }

    /// <summary><c>Narrator.clear</c>.</summary>
    public void Clear() {
        if (!Active) {
            return;
        }
        while (_queue.TryTake(out _)) {
        }
        lock (_lock) {
            Kill(_speaking);
            _speaking = null;
        }
        if (IsSpeechDispatcher) {
            Run(["-C"])?.WaitForExit(1000);
        }
    }

    private bool IsSpeechDispatcher => _command!.EndsWith("spd-say", StringComparison.Ordinal);

    private void Speak() {
        foreach ((string text, float volume) in _queue.GetConsumingEnumerable()) {
            // spd-say waits for the daemon to finish with -w; espeak-ng speaks itself, reading the text from stdin.
            Process? process = IsSpeechDispatcher
                ? Run(["-w", "-i", ((int)MathF.Round(volume * 200.0F - 100.0F)).ToString(), "--", text])
                : Run(["-a", ((int)MathF.Round(volume * 100.0F)).ToString(), "--stdin"], text);
            if (process == null) {
                continue;
            }
            lock (_lock) {
                _speaking = process;
            }
            process.WaitForExit();
            lock (_lock) {
                _speaking = null;
            }
        }
    }

    private Process? Run(IEnumerable<string> arguments, string? input = null) {
        ProcessStartInfo info = new(_command!) {
            UseShellExecute = false,
            RedirectStandardInput = input != null,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        foreach (string argument in arguments) {
            info.ArgumentList.Add(argument);
        }
        try {
            Process? process = Process.Start(info);
            if (process != null && input != null) {
                process.StandardInput.Write(input);
                process.StandardInput.Close();
            }
            return process;
        }
        catch (Exception e) when (e is System.ComponentModel.Win32Exception or IOException) {
            return null;
        }
    }

    private static void Kill(Process? process) {
        try {
            process?.Kill();
        }
        catch (InvalidOperationException) {
        }
    }

    public void Dispose() {
        _queue.CompleteAdding();
        Clear();
    }
}

/// <summary><c>GameNarrator</c>: what the narrator option lets through, spoken at the voice volume.</summary>
public sealed class GameNarrator(TtsNarrator narrator, GameSettings settings) {
    private NarratorStatus Status => settings.Narrator;

    public bool IsActive => narrator.Active;

    public void SayChatQueued(TextComponent message) {
        if (Status.ShouldNarrateChat()) {
            NarrateNotInterruptingMessage(message);
        }
    }

    public void SaySystemChatQueued(TextComponent message) {
        if (Status.ShouldNarrateSystemOrChat()) {
            NarrateNotInterruptingMessage(message);
        }
    }

    public void SaySystemQueued(TextComponent message) {
        if (Status.ShouldNarrateSystem()) {
            NarrateNotInterruptingMessage(message);
        }
    }

    private void NarrateNotInterruptingMessage(TextComponent message) {
        string text = TextFlattener.Plain(message);
        if (text.Length > 0) {
            NarrateMessage(text, false);
        }
    }

    public void SaySystemNow(TextComponent message) => SaySystemNow(TextFlattener.Plain(message));

    public void SaySystemNow(string message) {
        if (Status.ShouldNarrateSystem() && message.Length > 0 && narrator.Active) {
            narrator.Clear();
            NarrateMessage(message, true);
        }
    }

    /// <summary><c>getFinalSoundSourceVolume(VOICE)</c>: the voice slider under the master one.</summary>
    private void NarrateMessage(string message, bool interrupt) =>
        narrator.Say(message, interrupt, settings.Volumes[(int)SoundCategory.Master] * settings.Volumes[(int)SoundCategory.Voice]);

    /// <summary>Where <see cref="UpdateNarratorStatus"/> puts its toast; none before the window has a GUI.</summary>
    public Gui.ToastManager? Toasts { get; set; }

    /// <summary>
    /// <c>updateNarratorStatus</c>, the option's change action: says the new setting whatever it is, and shows it
    /// in a toast, which says instead that there is no narrator when the speech engine is missing.
    /// </summary>
    public void UpdateNarratorStatus(NarratorStatus status) {
        Clear();
        NarrateMessage($"{Translations.Get("options.narrator") ?? "Narrator"} : {Translations.Get(status.TranslationKey()) ?? status.ToString()}", true);
        if (Toasts == null) {
            return;
        }
        if (!narrator.Active) {
            Gui.SystemToast.AddOrUpdate(Toasts, Gui.SystemToastId.NarratorToggle, TextComponent.Translatable("narrator.toast.disabled"),
                TextComponent.Translatable("options.narrator.notavailable"));
        }
        else if (status == NarratorStatus.Off) {
            Gui.SystemToast.AddOrUpdate(Toasts, Gui.SystemToastId.NarratorToggle, TextComponent.Translatable("narrator.toast.disabled"), null);
        }
        else {
            Gui.SystemToast.AddOrUpdate(Toasts, Gui.SystemToastId.NarratorToggle, TextComponent.Translatable("narrator.toast.enabled"),
                TextComponent.Translatable(status.TranslationKey()));
        }
    }

    public void Clear() {
        if (Status != NarratorStatus.Off && narrator.Active) {
            narrator.Clear();
        }
    }

    /// <summary>The narrator option's label: the setting, or that there is no narrator to set.</summary>
    public string OptionLabel(NarratorStatus status) =>
        Translations.Get(narrator.Active ? status.TranslationKey() : "options.narrator.notavailable") ?? status.ToString();
}

/// <summary><c>NarratedElementType</c>, the order a screen's narration is read in.</summary>
public enum NarratedElementType {
    Title,
    Position,
    Hint,
    Usage
}

/// <summary><c>NarrationElementOutput</c>: where a screen and its widgets put what is to be said.</summary>
public interface INarrationOutput {
    void Add(NarratedElementType type, TextComponent contents);

    /// <summary>The output for something nested inside, read after the same kind of entry here.</summary>
    INarrationOutput Nest();
}

/// <summary>
/// <c>ScreenNarrationCollector</c>: each update's entries by kind and depth, and which of them have been
/// said, so a repeat of an unchanged screen only says what changed.
/// </summary>
public sealed class ScreenNarrationCollector {
    private int _generation;
    private readonly SortedDictionary<(NarratedElementType Type, int Depth), Entry> _entries = new();

    private sealed class Entry {
        private string _contents = "";
        public int Generation = -1;
        public bool AlreadyNarrated;

        public string Contents => _contents;

        public void Update(int generation, string contents) {
            if (_contents != contents) {
                _contents = contents;
                AlreadyNarrated = false;
            }
            else if (Generation + 1 != generation) {
                AlreadyNarrated = false;
            }
            Generation = generation;
        }
    }

    private sealed class Output(ScreenNarrationCollector collector, int depth) : INarrationOutput {
        public void Add(NarratedElementType type, TextComponent contents) {
            if (!collector._entries.TryGetValue((type, depth), out Entry? entry)) {
                collector._entries[(type, depth)] = entry = new Entry();
            }
            entry.Update(collector._generation, TextFlattener.Plain(contents));
        }

        public INarrationOutput Nest() => new Output(collector, depth + 1);
    }

    public void Update(Action<INarrationOutput> updater) {
        _generation++;
        updater(new Output(this, 0));
    }

    /// <summary><c>collectNarrationText</c>: the current entries joined with ". ", only those not yet said unless forced.</summary>
    public string CollectNarrationText(bool force) {
        List<string> parts = [];
        foreach (Entry entry in _entries.Values) {
            if (entry.Generation == _generation && (force || !entry.AlreadyNarrated)) {
                parts.Add(entry.Contents);
                entry.AlreadyNarrated = true;
            }
        }
        return string.Join(". ", parts);
    }
}
