using ClientLib;
using ClientLib.Multiplayer;
using Minecraft;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>What the menus outside a world need from the window.</summary>
public interface IMenuHost {
    /// <summary>Where <c>servers.dat</c> and the options live.</summary>
    string DataDirectory { get; }

    Silk.NET.OpenGL.GL Gl { get; }

    /// <summary><c>ConnectScreen.startConnecting</c>: drops whatever connection there was and joins on a fresh client.</summary>
    void Join(Screen parent, ServerData server);

    /// <summary>The connect screen's Cancel: the connection attempt is dropped and the screen goes back.</summary>
    void Abort(Screen parent);

    /// <summary><c>Minecraft.stop</c>.</summary>
    void Quit();

    void RenderPanorama(GuiContext context);

    /// <summary><c>SplashManager.getSplash</c>, which the title screen asks once.</summary>
    SplashRenderer? GetSplash();
}

/// <summary>Helpers the menus share.</summary>
public static class Menus {
    public static string T(string key) => Translations.Get(key) ?? key;

    public static List<TextRun> Runs(TextComponent component, int defaultRgb = TextFlattener.DefaultRgb) => TextFlattener.Flatten(component, defaultRgb);

    public static TextComponent Translatable(string key, params TextComponent[] with) => TextComponent.Translatable(key, with: with);

    /// <summary>
    /// <c>Screen.extractBackground</c> for a menu outside the game UI: the panorama while there is no level,
    /// then the menu background tile. Vanilla blurs between the two; this client does not.
    /// </summary>
    public static void Background(GuiContext context) {
        if (context.Client.Level != null) {
            // Screen.extractTransparentBackground's gradient, flattened.
            context.Gui.Rect(0, 0, context.Width, context.Height, 0xC8101010);
            return;
        }
        context.Host?.RenderPanorama(context);
        if (!context.Sprites.Tiled(context.Gui, "gui/menu_background", 0, 0, context.Width, context.Height, 32)) {
            context.Gui.Rect(0, 0, context.Width, context.Height, 0x80101010);
        }
    }
}

/// <summary>
/// <c>TitleScreen</c> with what this client has behind it: the server list, the options, the language and
/// accessibility screens, and quitting, under the logo and its splash. No singleplayer, Realms, friends or credits.
/// </summary>
public sealed class TitleScreen : Screen {
    private bool? _packLogo;
    private SplashRenderer? _splash;

    public override bool ShowsHud => false;
    public override bool CloseOnEscape => false;

    protected override void Init(GuiContext context, int width, int height) {
        _splash ??= context.Host?.GetSplash();
        int top = height / 4 + 48;
        Add(new Button(Menus.T("menu.multiplayer"), width / 2.0F - 100, top, 200, () => context.Open?.Invoke(
            context.Settings is { SkipMultiplayerWarning: true } ? new JoinMultiplayerScreen(this) : new SafetyScreen(this))));
        top += 24;
        List<(string Sprite, string Label, Func<Screen> Open)> icons = [
            ("icon/language", "options.language", () => new LanguageSelectScreen(this)),
            ("icon/accessibility", "options.accessibility", () => new AccessibilityOptionsScreen(this))
        ];
        for (int i = 0; i < icons.Count; i++) {
            (string sprite, string label, Func<Screen> open) = icons[i];
            Add(new IconButton(sprite, Menus.T(label), HorizontalPosition(i + 1, icons.Count, 20, width), top, () => context.Open?.Invoke(open())));
        }
        top += 24;
        Add(new Button(Menus.T("menu.options"), width / 2.0F - 100, top, 98, () => context.Open?.Invoke(new OptionsScreen(this))));
        Add(new Button(Menus.T("menu.quit"), width / 2.0F + 2, top, 98, () => context.Host?.Quit()));
    }

    /// <summary><c>getHorizontalPosition</c>: a row of small buttons centred, four apart.</summary>
    private static int HorizontalPosition(int button, int buttons, int buttonWidth, int width) {
        int total = buttons * buttonWidth + (buttons - 1) * 4;
        return width / 2 - total / 2 + (button - 1) * (buttonWidth + 4);
    }

    public override void Render(GuiContext context, float partialTick) {
        context.Host?.RenderPanorama(context);
        RenderWidgets(context);
        _packLogo ??= context.Sprites.Texture("gui/title/minecraft") is { Width: > 1 };
        RenderLogo(context, 30, _packLogo.Value);
        if (_splash != null && context.Settings is not { HideSplashTexts: true }) {
            _splash.Render(context, context.Width, 1.0F);
        }
        context.Text.Draw($"mcdotnet for {ProtocolConstants.CurrentVersionString}", 2, context.Height - 10);
    }

    /// <summary><c>LogoRenderer</c>: the pack's logo with the edition strip overlapping it by seven pixels, or this client's own lettering.</summary>
    private static void RenderLogo(GuiContext context, int heightOffset, bool packLogo) {
        int width = context.Width;
        if (packLogo && context.Sprites.Stretched(context.Gui, "gui/title/minecraft", width / 2.0F - 128, heightOffset, 256, 44, 0, 0, 1, 44 / 64.0F)) {
            context.Sprites.Stretched(context.Gui, "gui/title/edition", width / 2.0F - 64, heightOffset + 44 - 7, 128, 14, 0, 0, 1, 14 / 16.0F);
            return;
        }
        GuiRendererZoom(context, 4.0F, () => context.Text.DrawCentred("mcdotnet", width / 2.0F / 4.0F, (heightOffset + 6) / 4.0F, 0xFFE8E0C8));
        context.Text.DrawCentred(ProtocolConstants.CurrentVersionString, width / 2.0F, heightOffset + 44 - 4, 0xFFFFFF55);
    }

    private static void GuiRendererZoom(GuiContext context, float zoom, Action draw) {
        context.Gui.Zoom = zoom;
        draw();
        context.Gui.Zoom = 1.0F;
    }
}

/// <summary><c>SpriteIconButton</c> as <c>CommonButtons</c> makes it: a 20 square button with a 15 pixel icon, and its label as a tooltip.</summary>
public sealed class IconButton(string sprite, string label, float x, float y, Action onPress) : Widget(x, y, 20, 20) {
    public override void Render(GuiContext context, bool hovered) {
        Button.Draw(context, "", X, Y, W, H, hovered, Active);
        if (!context.Sprites.Sprite(context.Gui, sprite, X + 2, Y + 2, 15, 15)) {
            context.Text.DrawCentred(label[..1], X + W / 2, Y + 6);
        }
        if (hovered) {
            Inventory.Tooltips.Draw(context, [[TextRun.Of(label, new RunStyle(TextFlattener.DefaultRgb))]], context.MouseX, context.MouseY);
        }
    }

    public override void OnClick(GuiContext context, float mouseX) {
        Screen.PlayDownSound(context);
        onPress();
    }
}

/// <summary><c>Checkbox</c>: a 17 pixel box with its label four pixels to the right.</summary>
public sealed class Checkbox(string label, float x, float y, int labelWidth, uint labelColor) : Widget(x, y, 17 + 4 + labelWidth, 17) {
    public bool Selected { get; private set; }

    public override void Render(GuiContext context, bool hovered) {
        string sprite = Selected ? hovered ? "widget/checkbox_selected_highlighted" : "widget/checkbox_selected"
            : hovered ? "widget/checkbox_highlighted" : "widget/checkbox";
        if (!context.Sprites.Sprite(context.Gui, sprite, X, Y, 17, 17)) {
            context.Gui.Rect(X, Y, 17, 17, hovered ? 0xFFFFFFFF : 0xFFA0A0A0);
            context.Gui.Rect(X + 1, Y + 1, 15, 15, 0xFF000000);
            if (Selected) {
                context.Text.DrawCentred("x", X + 8.5F, Y + 4);
            }
        }
        context.Text.Draw(label, X + 17 + 4, Y + 17 / 2 - 9 / 2, labelColor);
    }

    public override void OnClick(GuiContext context, float mouseX) {
        Screen.PlayDownSound(context);
        Selected = !Selected;
    }
}

/// <summary><c>SafetyScreen</c>: the first time warning before the server list, which a ticked box stops for good.</summary>
public sealed class SafetyScreen(Screen previous) : Screen {
    private Checkbox _stopShowing = null!;

    public override bool ShowsHud => false;

    /// <summary><c>WarningScreen.init</c>: title, message padded 12 and at most 100 narrower than the screen, then the box and the buttons, 8 apart, centred.</summary>
    protected override void Init(GuiContext context, int width, int height) {
        List<List<TextRun>> message = context.Text.Wrap(Menus.Runs(Menus.Translatable("multiplayerWarning.message")), width - 100);
        string check = Menus.T("multiplayerWarning.check");
        float total = 9 + 8 + (message.Count * 9 + 24) + 8 + 17 + 8 + 20;
        float top = (height - total) / 2;
        float boxY = top + 9 + 8 + message.Count * 9 + 24 + 8;
        int checkWidth = 17 + 4 + context.Text.Width(check);
        _stopShowing = new Checkbox(check, width / 2.0F - checkWidth / 2.0F, boxY, context.Text.Width(check), 0xFFE0E0E0);
        Add(_stopShowing);
        float buttonsY = boxY + 17 + 8;
        Add(new Button(Menus.T("gui.proceed"), width / 2.0F - 154, buttonsY, 150, () => {
            if (_stopShowing.Selected && context.Settings != null) {
                context.Settings.SkipMultiplayerWarning = true;
                context.Settings.Save();
            }
            context.Open?.Invoke(new JoinMultiplayerScreen(previous));
        }));
        Add(new Button(Menus.T("gui.back"), width / 2.0F + 4, buttonsY, 150, () => Close(context)));
    }

    public override void Render(GuiContext context, float partialTick) {
        Menus.Background(context);
        int width = context.Width;
        List<List<TextRun>> message = context.Text.Wrap(Menus.Runs(Menus.Translatable("multiplayerWarning.message")), width - 100);
        float total = 9 + 8 + (message.Count * 9 + 24) + 8 + 17 + 8 + 20;
        float y = (context.Height - total) / 2;
        context.Text.DrawCentred(Menus.Runs(Menus.Translatable("multiplayerWarning.header").WithBold()), width / 2.0F, y);
        y += 9 + 8 + 12;
        foreach (List<TextRun> line in message) {
            context.Text.DrawCentred(line, width / 2.0F, y);
            y += 9;
        }
        RenderWidgets(context);
    }

    public override void Close(GuiContext context) => context.Open?.Invoke(previous);
}

/// <summary><c>ConfirmScreen</c>: a question with two answers, laid out down the middle; Escape answers no.</summary>
public class ConfirmScreen(Action<bool> callback, TextComponent title, TextComponent message, string yes, string no) : Screen {
    public override bool ShowsHud => false;
    public override bool CloseOnEscape => false;

    private (List<List<TextRun>> Message, float Top) Layout(GuiContext context) {
        List<List<TextRun>> lines = context.Text.Wrap(Menus.Runs(message), context.Width - 50).Take(15).ToList();
        float total = 9 + 8 + lines.Count * 9 + 8 + 16 + 20;
        return (lines, (context.Height - total) / 2);
    }

    protected override void Init(GuiContext context, int width, int height) {
        (List<List<TextRun>> lines, float top) = Layout(context);
        float y = top + 9 + 8 + lines.Count * 9 + 8 + 16;
        Add(new Button(yes, width / 2.0F - 152, y, 150, () => callback(true)));
        Add(new Button(no, width / 2.0F + 2, y, 150, () => callback(false)));
    }

    public override void Render(GuiContext context, float partialTick) {
        Menus.Background(context);
        (List<List<TextRun>> lines, float top) = Layout(context);
        context.Text.DrawCentred(Menus.Runs(title), context.Width / 2.0F, top);
        float y = top + 9 + 8;
        foreach (List<TextRun> line in lines) {
            context.Text.DrawCentred(line, context.Width / 2.0F, y);
            y += 9;
        }
        RenderWidgets(context);
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (key == Key.Escape) {
            callback(false);
        }
    }
}

/// <summary>
/// <c>ConnectScreen</c> while the connection is made and the login runs. It gives way to the HUD's
/// terrain message once the play phase starts, where vanilla's level loading screen takes over.
/// </summary>
public sealed class ConnectScreen(Screen parent, bool transferring) : Screen {
    public override bool ShowsHud => false;
    public override bool CloseOnEscape => false;

    protected override void Init(GuiContext context, int width, int height) =>
        Add(new Button(Menus.T("gui.cancel"), width / 2.0F - 100, height / 4.0F + 120 + 12, 200, () => context.Host?.Abort(parent)));

    public override void Tick(GuiContext context) {
        if (context.Client.Phase == ClientPhase.Play) {
            Close(context);
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        Menus.Background(context);
        RenderWidgets(context);
        string status = context.Client.Phase switch {
            ClientPhase.Login => "connect.authorizing",
            ClientPhase.Configuration => "connect.joining",
            _ => transferring ? "connect.transferring" : "connect.connecting"
        };
        context.Text.DrawCentred(Menus.T(status), context.Width / 2.0F, context.Height / 2.0F - 50);
    }
}
