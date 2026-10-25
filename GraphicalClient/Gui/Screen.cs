using ClientLib;
using GraphicalClient.Rendering;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>What a screen draws with and acts on. The settable members are filled in by the window.</summary>
public sealed class GuiContext(GuiRenderer gui, TextRenderer text, HudIcons icons, ItemAtlas items, MinecraftClient client, GuiSprites sprites) {
    public GuiRenderer Gui { get; } = gui;

    /// <summary>A resource pack's GUI art, where there is one; every draw falls back to the built in art.</summary>
    public GuiSprites Sprites { get; set; } = sprites;
    public TextRenderer Text { get; set; } = text;
    public HudIcons Icons { get; set; } = icons;
    public ItemAtlas Items { get; set; } = items;
    public MinecraftClient Client { get; set; } = client;
    public int Width => Gui.ScaledWidth;
    public int Height => Gui.ScaledHeight;
    public Func<string>? ReadClipboard { get; set; }
    public Action<string>? WriteClipboard { get; set; }
    public Audio.ClientSounds? Sounds { get; set; }

    /// <summary>How far into the next game tick this frame is drawn.</summary>
    public float PartialTick { get; set; }
    public GameSettings? Settings { get; set; }

    /// <summary>Replaces the open screen, null for none.</summary>
    public Action<Screen?>? Open { get; set; }

    /// <summary><c>Gui.screen</c>: the screen open now.</summary>
    public Func<Screen?> CurrentScreen { get; set; } = () => null;

    /// <summary><c>Gui.openChatAndAddText</c>: the chat screen as the key opens it, with the text added.</summary>
    public Action<ChatComponent.ChatMethod, string>? OpenChat { get; set; }

    /// <summary>What the title screen and the server list ask of the window: joining, leaving, quitting, the panorama.</summary>
    public IMenuHost? Host { get; set; }

    /// <summary>Draws an entity into a box of the screen, as <c>GuiGraphicsExtractor.entity</c> does.</summary>
    public Rendering.Entities.GuiEntityRenderer? EntityRenderer { get; set; }

    /// <summary>Told the <c>rawMouseInput</c> option changed, which the window applies at once as vanilla's change action does.</summary>
    public Action? RawMouseInputChanged { get; set; }

    public Narration.GameNarrator? Narrator { get; set; }

    /// <summary>The toasts in the top right corner, which outlive any one connection.</summary>
    public ToastManager Toasts { get; } = new();

    /// <summary>The resource packs and languages, which the options screens choose from and reload.</summary>
    public ClientResources? Resources { get; set; }

    /// <summary>The cursor in HUD pixels as of this frame, as vanilla passes it to <c>extractRenderState</c>.</summary>
    public float MouseX { get; set; }

    /// <inheritdoc cref="MouseX"/>
    public float MouseY { get; set; }
}

/// <summary>
/// Something drawn over the game that takes the keyboard, as vanilla's <c>Screen</c> does. While one
/// is open the mouse is released and the player stops reading movement keys. Its widgets are added by
/// <see cref="Init"/>, which runs again whenever the GUI changes size.
/// </summary>
public abstract class Screen {
    private readonly List<Widget> _widgets = [];
    private (int Width, int Height)? _laidOutFor;
    private Slider? _dragging;

    public bool Closed { get; protected set; }

    /// <summary>Whether the HUD is still drawn underneath. Chat keeps it; a full screen menu hides it.</summary>
    public virtual bool ShowsHud => true;

    /// <summary><c>Screen.showsActiveEffects</c>: whether it lists the player's effects, so the HUD need not.</summary>
    public virtual bool ShowsActiveEffects(GuiContext context) => false;

    /// <summary>Whether Escape closes it. A death screen has to be answered.</summary>
    public virtual bool CloseOnEscape => true;

    /// <summary>
    /// <c>Screen.isAllowedInPortal</c>, which is <c>isPauseScreen</c> unless chat or the death screen
    /// overrides it: false for the screens that act on the game.
    /// </summary>
    public virtual bool IsAllowedInPortal => true;

    /// <summary>The cursor in HUD pixels, as the window last reported it.</summary>
    protected float MouseX { get; set; }

    /// <inheritdoc cref="MouseX"/>
    protected float MouseY { get; set; }

    protected virtual void Init(GuiContext context, int width, int height) {
    }

    protected void Add(Widget widget) => _widgets.Add(widget);

    /// <summary>Has <see cref="Init"/> lay the widgets out again before they are next used, as a scrolled list must.</summary>
    public void InvalidateLayout() => _laidOutFor = null;

    protected void LayOut(GuiContext context) {
        if (_laidOutFor == (context.Width, context.Height)) {
            return;
        }
        _laidOutFor = (context.Width, context.Height);
        _widgets.Clear();
        _dragging = null;
        Init(context, context.Width, context.Height);
        // Screen.init: what is there is said at once, then nothing more for two seconds.
        TriggerImmediateNarration(context, false);
        _narrationSuppressTime = Environment.TickCount64 + NarrateSuppressAfterInitTime;
    }

    /// <summary><c>Screen.removed</c>: the screen is being replaced, by another or by none.</summary>
    public virtual void Removed(GuiContext context) {
    }

    /// <summary><c>Screen.insertText</c>, which a <c>suggest_command</c> click calls with <paramref name="replace"/> set.</summary>
    public virtual void InsertText(string text, bool replace) {
    }

    /// <summary>Whether a text field has the keyboard, which keeps Ctrl+B from the narrator.</summary>
    public virtual bool HasFocusedEditBox => false;

    private const long NarrateSuppressAfterInitTime = 2000;
    private readonly Narration.ScreenNarrationCollector _narrationState = new();
    private long _narrationSuppressTime = long.MinValue, _nextNarrationTime = long.MaxValue;

    /// <summary><c>getNarrationMessage</c>: the title, said first.</summary>
    protected virtual string NarrationTitle => "";

    /// <summary><c>narratorButton</c>, which follows the narrator option when the hot key changes it.</summary>
    protected CycleButton<Narration.NarratorStatus>? NarratorButton { get; set; }

    private void ScheduleNarration(long delay, bool ignoreSuppression) {
        _nextNarrationTime = Environment.TickCount64 + delay;
        if (ignoreSuppression) {
            _narrationSuppressTime = long.MinValue;
        }
    }

    public void AfterMouseMove() => ScheduleNarration(750, false);

    public void AfterMouseAction() => ScheduleNarration(200, true);

    public void AfterKeyboardAction() => ScheduleNarration(200, true);

    public void UpdateNarratorStatus(bool wasDisabled, Narration.NarratorStatus status) {
        if (wasDisabled) {
            ScheduleNarration(NarrateSuppressAfterInitTime, false);
        }
        NarratorButton?.SetValue(status);
    }

    /// <summary><c>handleDelayedNarration</c>, once a frame: what changed since the last narration, once its delay is up.</summary>
    public void HandleDelayedNarration(GuiContext context) {
        if (context.Narrator is not { IsActive: true }) {
            return;
        }
        long now = Environment.TickCount64;
        if (now > _nextNarrationTime && now > _narrationSuppressTime) {
            RunNarration(context, true);
            _nextNarrationTime = long.MaxValue;
        }
    }

    public void TriggerImmediateNarration(GuiContext context, bool onlyChanged) {
        if (context.Narrator is { IsActive: true }) {
            RunNarration(context, onlyChanged);
        }
    }

    private void RunNarration(GuiContext context, bool onlyChanged) {
        _narrationState.Update(UpdateNarrationState);
        string narration = _narrationState.CollectNarrationText(!onlyChanged);
        if (narration.Length > 0) {
            context.Narrator!.SaySystemNow(narration);
        }
    }

    protected virtual void UpdateNarrationState(Narration.INarrationOutput output) {
        output.Add(Narration.NarratedElementType.Title, Minecraft.Text.TextComponent.Text(NarrationTitle));
        UpdateNarratedWidget(output);
    }

    /// <summary>
    /// <c>updateNarratedWidget</c> with the widget under the cursor, there being no keyboard focus here: its
    /// place among the active widgets and its own narration, or how to pick one when none is hovered.
    /// </summary>
    protected void UpdateNarratedWidget(Narration.INarrationOutput output) {
        List<Widget> active = _widgets.Where(w => w.Visible && w.Active).ToList();
        int index = active.FindIndex(w => w.Contains(MouseX, MouseY));
        if (index < 0) {
            output.Add(Narration.NarratedElementType.Usage, Minecraft.Text.TextComponent.Translatable("narrator.screen.usage"));
            return;
        }
        if (active.Count > 1) {
            output.Add(Narration.NarratedElementType.Position, Minecraft.Text.TextComponent.Translatable("narrator.position.screen", null,
                [Minecraft.Text.TextComponent.Text((index + 1).ToString()), Minecraft.Text.TextComponent.Text(active.Count.ToString())]));
        }
        active[index].UpdateNarration(output.Nest());
    }

    /// <summary><c>Screen.tick</c>, once a game tick while open.</summary>
    public virtual void Tick(GuiContext context) {
    }

    public virtual void Render(GuiContext context, float partialTick) => RenderWidgets(context);

    protected void RenderWidgets(GuiContext context) {
        LayOut(context);
        foreach (Widget widget in _widgets) {
            if (widget.Visible) {
                widget.Render(context, widget.Active && widget.Contains(MouseX, MouseY));
            }
        }
    }

    public virtual void KeyDown(GuiContext context, Key key, bool control) {
        if (key == Key.Escape && CloseOnEscape) {
            Close(context);
        }
    }

    /// <summary><c>keyReleased</c>.</summary>
    public virtual void KeyUp(GuiContext context, Key key) {
    }

    public virtual void Char(GuiContext context, char c) {
    }

    /// <summary>A click, in HUD pixels.</summary>
    public virtual void MouseDown(GuiContext context, float x, float y, MouseButton button) => ClickWidgets(context, x, y, button);

    /// <summary><c>Screen.mouseClicked</c> over the widgets: whether one took the click.</summary>
    protected bool ClickWidgets(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (button != MouseButton.Left) {
            return false;
        }
        foreach (Widget widget in _widgets) {
            if (widget.Visible && widget.Active && widget.Contains(x, y)) {
                _dragging = widget as Slider;
                widget.OnClick(context, x);
                return true;
            }
        }
        return false;
    }

    protected void SetMouse(float x, float y) {
        MouseX = x;
        MouseY = y;
    }

    public virtual void MouseMove(GuiContext context, float x, float y) {
        SetMouse(x, y);
        _dragging?.SetFromMouse(x);
    }

    /// <summary>A slider clicks when it is let go, not when it is pressed.</summary>
    public virtual void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        if (_dragging != null && button == MouseButton.Left) {
            _dragging = null;
            PlayDownSound(context);
        }
    }

    public virtual void Scroll(GuiContext context, float delta) {
    }

    public virtual void Close(GuiContext context) {
        Closed = true;
    }

    public static bool Inside(float mx, float my, float x, float y, float w, float h) => mx >= x && my >= y && mx < x + w && my < y + h;

    /// <summary>
    /// <c>AbstractWidget.mouseClicked</c> for a button drawn by hand: whether the click lands on it, playing
    /// its <c>playDownSound</c> when it does. An inactive button takes no click and makes no sound.
    /// </summary>
    protected static bool Pressed(GuiContext context, float mouseX, float mouseY, float x, float y, float w, float h, bool active = true) {
        if (!active || !Inside(mouseX, mouseY, x, y, w, h)) {
            return false;
        }
        PlayDownSound(context);
        return true;
    }

    /// <summary><c>AbstractWidget.playDownSound</c>.</summary>
    public static void PlayDownSound(GuiContext context) => PlayUi(context, Minecraft.Data.Generated.SoundType.ButtonClick);

    /// <summary><c>SimpleSoundInstance.forUI(sound, 1.0F)</c>, which is how screens play their own sounds.</summary>
    public static void PlayUi(GuiContext context, Minecraft.Data.Sounds.ISoundType sound) => context.Sounds?.PlayUi(sound, 1.0F);
}
