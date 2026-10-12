using ClientLib;
using GraphicalClient.Rendering;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>What a screen draws with and acts on. The settable members are filled in by the window.</summary>
public sealed class GuiContext(GuiRenderer gui, TextRenderer text, HudIcons icons, ItemAtlas items, MinecraftClient client, GuiSprites sprites) {
    public GuiRenderer Gui { get; } = gui;

    /// <summary>A resource pack's GUI art, where there is one; every draw falls back to the built in art.</summary>
    public GuiSprites Sprites { get; } = sprites;
    public TextRenderer Text { get; } = text;
    public HudIcons Icons { get; } = icons;
    public ItemAtlas Items { get; } = items;
    public MinecraftClient Client { get; } = client;
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

    /// <summary>Draws an entity into a box of the screen, as <c>GuiGraphicsExtractor.entity</c> does.</summary>
    public Rendering.Entities.GuiEntityRenderer? EntityRenderer { get; set; }

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

    protected void LayOut(GuiContext context) {
        if (_laidOutFor == (context.Width, context.Height)) {
            return;
        }
        _laidOutFor = (context.Width, context.Height);
        _widgets.Clear();
        _dragging = null;
        Init(context, context.Width, context.Height);
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
