using ClientLib;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>SystemToast.SystemToastId</c>: what a system toast is about, so a second one about the same thing
/// updates the first rather than queueing behind it, and how long it stays after its last change.
/// </summary>
public sealed class SystemToastId(long displayTimeMs = 5000) {
    public static readonly SystemToastId NarratorToggle = new();
    public static readonly SystemToastId PackLoadFailure = new();
    public static readonly SystemToastId PackCopyFailure = new();
    public static readonly SystemToastId FileDropFailure = new();
    public static readonly SystemToastId PeriodicNotification = new();
    public static readonly SystemToastId UnsecureServerWarning = new(10000);

    public long DisplayTimeMs { get; } = displayTimeMs;
}

/// <summary><c>SystemToast</c>: a yellow title and a white message, as wide as the longer of them up to 200 pixels of text.</summary>
public sealed class SystemToast : Toast {
    private const int MaxLineSize = 200, LineSpacing = 12, TextXStart = 18;

    private readonly SystemToastId _id;
    private TextComponent _title;
    private TextComponent? _message;
    private TextRenderer? _measuredWith;
    private List<List<TextRun>> _titleLines = [];
    private List<List<TextRun>> _messageLines = [];
    private int _width = DefaultWidth;
    private long _lastChanged;
    private bool _changed;
    private bool _forceHide;
    private ToastVisibility _wantedVisibility = ToastVisibility.Hide;

    public SystemToast(SystemToastId id, TextComponent title, TextComponent? message) {
        _id = id;
        _title = title;
        _message = message;
    }

    public override object Token => _id;
    public override int Width => _width;
    public override int Height => 20 + (_titleLines.Count - 1) * LineSpacing + Math.Max(_messageLines.Count, 1) * LineSpacing;
    public override ToastVisibility WantedVisibility => _wantedVisibility;

    public override void Measure(TextRenderer text) {
        if (_measuredWith == text) {
            return;
        }
        _measuredWith = text;
        _titleLines = text.Wrap(Menus.Runs(_title, 0xFFFF00), MaxLineSize);
        _messageLines = _message == null ? [] : text.Wrap(Menus.Runs(_message, 0xFFFFFF), MaxLineSize);
        _width = Math.Max(DefaultWidth, _titleLines.Concat(_messageLines).Select(text.Width).DefaultIfEmpty(200).Max()) + 30;
    }

    public void ForceHide() => _forceHide = true;

    /// <summary><c>update</c>: shown until the id's display time has passed since the last change.</summary>
    public override void Update(ToastManager manager, long fullyVisibleForMs) {
        if (_changed) {
            _lastChanged = fullyVisibleForMs;
            _changed = false;
        }
        double displayTime = _id.DisplayTimeMs * manager.NotificationDisplayTimeMultiplier;
        _wantedVisibility = !_forceHide && fullyVisibleForMs - _lastChanged < displayTime ? ToastVisibility.Show : ToastVisibility.Hide;
    }

    /// <summary>
    /// <c>reset</c>: new text, and the display time starts over. The slot it holds stays the height it was
    /// given, as vanilla's does.
    /// </summary>
    public void Reset(TextComponent title, TextComponent? message) {
        _title = title;
        _message = message;
        _measuredWith = null;
        _changed = true;
    }

    public override void Render(GuiContext context, float x, float y, long fullyVisibleForMs) {
        int height = Height;
        // toast/system is nine sliced with a 17 pixel left and 30 pixel top border round its icon strip.
        if (!context.Sprites.NineSliced(context.Gui, "toast/system", x, y, _width, height, 17, 30, 4, 4)) {
            context.Gui.Rect(x, y, _width, height, 0xE0101010);
            context.Gui.Rect(x, y, 3, height, 0xFFE0C040);
        }
        if (_messageLines.Count == 0) {
            DrawLines(context, _titleLines, x, y + 12);
        }
        else {
            DrawLines(context, _titleLines, x, y + 7);
            DrawLines(context, _messageLines, x, y + 7 + _titleLines.Count * LineSpacing);
        }
    }

    private static void DrawLines(GuiContext context, List<List<TextRun>> lines, float x, float top) {
        for (int i = 0; i < lines.Count; i++) {
            context.Text.Draw(lines[i], x + TextXStart, top + i * LineSpacing, 255, false);
        }
    }

    public static void Add(ToastManager manager, SystemToastId id, TextComponent title, TextComponent? message) =>
        manager.Add(new SystemToast(id, title, message));

    /// <summary><c>addOrUpdate</c>: the one already up or waiting for this id gets the new text, else a new one is queued.</summary>
    public static void AddOrUpdate(ToastManager manager, SystemToastId id, TextComponent title, TextComponent? message) {
        if (manager.Get<SystemToast>(id) is { } toast) {
            toast.Reset(title, message);
        }
        else {
            Add(manager, id, title, message);
        }
    }

    public static void ForceHide(ToastManager manager, SystemToastId id) => manager.Get<SystemToast>(id)?.ForceHide();
}

/// <summary>
/// A system toast fed from state polled once a frame, as the server pack download keeps its own: each change
/// updates the toast, and the state going away hides it. A new run after that gets a new toast, as vanilla
/// gives each download batch its own id.
/// </summary>
public sealed class PolledSystemToast {
    private (TextComponent Title, TextComponent? Message)? _last;
    private SystemToastId _id = new();

    public void Follow(ToastManager manager, (TextComponent Title, TextComponent? Message)? current) {
        if (current is { } now ? _last is { } last && ReferenceEquals(now.Title, last.Title) && ReferenceEquals(now.Message, last.Message) : _last == null) {
            return;
        }
        _last = current;
        if (current is { } shown) {
            SystemToast.AddOrUpdate(manager, _id, shown.Title, shown.Message);
        }
        else {
            SystemToast.ForceHide(manager, _id);
            _id = new SystemToastId();
        }
    }
}
