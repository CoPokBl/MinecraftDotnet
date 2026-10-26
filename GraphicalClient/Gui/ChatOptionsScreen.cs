using System.Globalization;
using ClientLib;
using GraphicalClient.Gui.Inventory;
using Minecraft.Schemas;

namespace GraphicalClient.Gui;

/// <summary>
/// Vanilla's <c>ChatOptionsScreen</c>: its eighteen options two to a row, in its order, then this client's chat signing switch. Each takes effect as it
/// changes, as the option's change action does in vanilla; the client information goes out on the save.
/// </summary>
public sealed class ChatOptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.chat.title");

    protected override string NarrationTitle => Title;

    private readonly List<(Widget Widget, string Key)> _tooltips = [];

    /// <summary><c>OptionsList</c>'s scroll, in pixels: the rows run between the 33 pixel header and footer.</summary>
    private int _scroll;

    private const int Rows = 10, RowHeight = 25, HeaderHeight = 33;

    private void InitRows(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        MinecraftClient client = context.Client;
        _tooltips.Clear();
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        int index = 0;
        _scroll = Math.Clamp(_scroll, 0, MaxScroll(height));
        (float X, float Y) Next() {
            (float, float) cell = (index % 2 == 0 ? left : right, HeaderHeight + 4 + index / 2 * RowHeight - _scroll);
            index++;
            return cell;
        }
        void Boolean(string captionKey, bool value, Action<bool> set, string? tooltip = null) {
            (float x, float y) = Next();
            CycleButton<bool> button = OptionWidgets.Boolean(captionKey, value, x, y, set);
            Add(button);
            if (tooltip != null) {
                _tooltips.Add((button, tooltip));
            }
        }
        void UnitSlider(Func<double> get, Action<double> set, Func<double, string> label) {
            (float x, float y) = Next();
            Add(new Slider(x, y, 150, get, set, label));
        }

        (float vx, float vy) = Next();
        Add(new CycleButton<ChatMode>([ChatMode.Enabled, ChatMode.CommandsOnly, ChatMode.Hidden], settings.ChatVisibility,
            mode => OptionWidgets.Generic("options.chat.visibility", T(VisibilityKey(mode))), vx, vy, 150, mode => {
                settings.ChatVisibility = mode;
                client.Options.ChatMode = mode;
                client.RefreshChatAbilities();
            }));
        Boolean("options.chat.color", settings.ChatColors, on => settings.ChatColors = on);
        Boolean("options.chat.links", settings.ChatLinks, on => settings.ChatLinks = on);
        Boolean("options.chat.links.prompt", settings.ChatLinksPrompt, on => settings.ChatLinksPrompt = on);
        UnitSlider(() => settings.ChatOpacity, v => settings.ChatOpacity = v, v => Percent(T("options.chat.opacity"), v * 0.9 + 0.1));
        UnitSlider(() => settings.TextBackgroundOpacity, v => settings.TextBackgroundOpacity = v,
            v => Percent(T("options.accessibility.text_background_opacity"), v));
        UnitSlider(() => settings.ChatScale, v => settings.ChatScale = v,
            v => v == 0.0 ? OptionWidgets.Generic("options.chat.scale", T("options.off")) : Percent(T("options.chat.scale"), v));
        UnitSlider(() => settings.ChatLineSpacing, v => settings.ChatLineSpacing = v, v => Percent(T("options.chat.line_spacing"), v));
        (float dx, float dy) = Next();
        Add(OptionWidgets.IntRange(0, 60, dx, dy, () => (int)(settings.ChatDelay * 10.0), tenths => {
            settings.ChatDelay = tenths / 10.0;
            client.ChatListener.SetMessageDelay(settings.ChatDelay);
        }, DelayLabel));
        UnitSlider(() => settings.ChatWidth, v => settings.ChatWidth = v, v => Pixels("options.chat.width", (int)Math.Floor(v * 280.0 + 40.0)));
        UnitSlider(() => settings.ChatHeightFocused, v => settings.ChatHeightFocused = v,
            v => Pixels("options.chat.height.focused", (int)Math.Floor(v * 160.0 + 20.0)));
        UnitSlider(() => settings.ChatHeightUnfocused, v => settings.ChatHeightUnfocused = v,
            v => Pixels("options.chat.height.unfocused", (int)Math.Floor(v * 160.0 + 20.0)));
        (float nx, float ny) = Next();
        Add(NarratorButton = OptionWidgets.Narrator(context, nx, ny));
        Boolean("options.autoSuggestCommands", settings.AutoSuggestions, on => settings.AutoSuggestions = on);
        Boolean("options.hideMatchedNames", settings.HideMatchedNames, on => settings.HideMatchedNames = on, "options.hideMatchedNames.tooltip");
        Boolean("options.reducedDebugInfo", settings.ReducedDebugInfo, on => settings.ReducedDebugInfo = on);
        Boolean("options.onlyShowSecureChat", settings.OnlyShowSecureChat, on => settings.OnlyShowSecureChat = on, "options.onlyShowSecureChat.tooltip");
        Boolean("options.chat.drafts", settings.SaveChatDrafts, on => settings.SaveChatDrafts = on, "options.chat.drafts.tooltip");
        // This client's own: vanilla always signs when it has a key.
        Boolean("options.chat.signing", settings.ChatSigning, on => {
            settings.ChatSigning = on;
            client.SetChatSigning(on);
        }, "options.chat.signing.tooltip");
        AddDone(context, width, height);
    }

    private static int MaxScroll(int height) => Math.Max(0, HeaderHeight + 4 + Rows * RowHeight - (height - HeaderHeight));

    /// <summary>
    /// A row is added hidden when it is not wholly inside the list, where vanilla clips it at the list's edge.
    /// </summary>
    private new void Add(Widget widget) {
        widget.Visible = widget.Y >= HeaderHeight && widget.Y + widget.H <= _height - HeaderHeight;
        base.Add(widget);
    }

    private int _height;

    protected override void Init(GuiContext context, int width, int height) {
        _height = height;
        InitRows(context, width, height);
    }

    public override void Scroll(GuiContext context, float delta) {
        int scroll = Math.Clamp(_scroll - (int)(delta * RowHeight / 2), 0, MaxScroll(context.Height));
        if (scroll != _scroll) {
            _scroll = scroll;
            InvalidateLayout();
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        base.Render(context, partialTick);
        foreach ((Widget widget, string key) in _tooltips) {
            if (widget.Contains(context.MouseX, context.MouseY)) {
                Tooltips.Draw(context, context.Text.Wrap(Menus.Runs(Menus.Translatable(key)), 200), context.MouseX, context.MouseY);
            }
        }
    }

    /// <summary><c>ChatVisiblity.getKey</c>.</summary>
    public static string VisibilityKey(ChatMode mode) => mode switch {
        ChatMode.CommandsOnly => "options.chat.visibility.system",
        ChatMode.Hidden => "options.chat.visibility.hidden",
        _ => "options.chat.visibility.full"
    };

    /// <summary>The <c>chatDelay</c> label: none, or the seconds to one place.</summary>
    private static string DelayLabel(int tenths) => tenths <= 0
        ? T("options.chat.delay_none")
        : TextFlattener.Plain(Menus.Translatable("options.chat.delay", Minecraft.Text.TextComponent.Text((tenths / 10.0).ToString("0.0", CultureInfo.InvariantCulture))));

    /// <summary><c>Options.pixelValueLabel</c>.</summary>
    private static string Pixels(string captionKey, int pixels) => $"{T(captionKey)}: {pixels}px";
}
