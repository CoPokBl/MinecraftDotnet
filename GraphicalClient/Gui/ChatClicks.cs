using System.Diagnostics;
using ClientLib;
using ClientLib.Chat;
using GraphicalClient.Gui.Inventory;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Schemas.Items;
using Minecraft.Text;
using NBT;
using NBT.Tags;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary><c>GuiGraphicsExtractor.componentHoverEffect</c>: the tooltip a hovered piece of text asks for.</summary>
public static class HoverEffects {
    public static void Draw(GuiContext context, HoverEvent hover, float mouseX, float mouseY) {
        switch (hover.Action) {
            case "show_text" when Field(hover.Fields, "value") is { } value:
                Tooltips.Draw(context, context.Text.Wrap(TextFlattener.Flatten(TextComponent.FromTag(value)), Math.Max(context.Width / 2, 200)), mouseX, mouseY);
                break;
            case "show_item" when ItemOf(context, hover) is { } stack:
                Tooltips.Draw(context, Tooltips.Lines(stack), mouseX, mouseY);
                break;
            case "show_entity" when context.Settings?.AdvancedItemTooltips == true:
                Tooltips.Draw(context, EntityTooltipLines(hover).Select(line => TextFlattener.Flatten(line)).ToList(), mouseX, mouseY);
                break;
        }
    }

    /// <summary><c>HoverEvent.ShowItem</c>'s <c>ItemStackTemplate</c>, its fields inline; null for an item this client cannot read.</summary>
    private static ItemStack? ItemOf(GuiContext context, HoverEvent hover) {
        try {
            return ItemStack.FromNbt(new CompoundTag(hover.Fields.Select(f => (f.Key, f.Tag)).ToArray()), context.Client.Registry);
        }
        catch (Exception e) when (e is InvalidOperationException or KeyNotFoundException or InvalidCastException or ArgumentException) {
            return null;
        }
    }

    /// <summary><c>EntityTooltipInfo.getTooltipLines</c>: the name if it has one, the type, then the UUID.</summary>
    private static List<TextComponent> EntityTooltipLines(HoverEvent hover) {
        List<TextComponent> lines = [];
        if (Field(hover.Fields, "name") is { } name) {
            lines.Add(TextComponent.FromTag(name));
        }
        if (Field(hover.Fields, "id") is StringTag id) {
            string type = id.Value.Contains(':') ? id.Value : "minecraft:" + id.Value;
            lines.Add(TextComponent.Translatable("gui.entity_tooltip.type", with: [TextComponent.Translatable("entity." + type.Replace(':', '.'))]));
        }
        if (Uuid(Field(hover.Fields, "uuid")) is { } uuid) {
            lines.Add(TextComponent.Text(uuid.ToString()));
        }
        return lines;
    }

    /// <summary><c>UUIDUtil.LENIENT_CODEC</c>: four ints, or a string.</summary>
    private static Guid? Uuid(INbtTag? tag) {
        switch (tag) {
            case ArrayTag<int> ints when ints.Values.Length == 4:
                byte[] bytes = new byte[16];
                for (int i = 0; i < 4; i++) {
                    System.Buffers.Binary.BinaryPrimitives.WriteInt32BigEndian(bytes.AsSpan(i * 4), ints.Values[i]);
                }
                return new Guid(bytes, bigEndian: true);
            case StringTag s when Guid.TryParse(s.Value, out Guid parsed):
                return parsed;
            default:
                return null;
        }
    }

    internal static INbtTag? Field((string Key, INbtTag Tag)[] fields, string key) => fields.FirstOrDefault(f => f.Key == key).Tag;
}

/// <summary><c>Screen.defaultHandleGameClickEvent</c> and what it runs, for chat and books.</summary>
public static class ClickEvents {
    /// <summary><c>defaultHandleGameClickEvent</c>.</summary>
    public static void HandleGameClickEvent(GuiContext context, ClickEvent click, Screen? activeScreen) {
        switch (click.Action) {
            case "run_command":
                ClickCommandAction(context, StringField(click, "command"), activeScreen);
                break;
            case "show_dialog":
                // This client has no dialog screen, so a dialog a click asks for is not shown.
                break;
            case "custom":
                if (HoverEffects.Field(click.Fields, "id") is StringTag id) {
                    context.Client.Send(new ServerBoundCustomClickActionPacket { Id = id.Value, Payload = HoverEffects.Field(click.Fields, "payload") });
                }
                break;
            default:
                HandleClickEvent(context, click, activeScreen);
                break;
        }
    }

    /// <summary>
    /// <c>defaultHandleClickEvent</c>. None of these replaces the screen except the link prompt, which puts the
    /// active screen back itself, so the closing <c>setScreen(activeScreen)</c> is left out.
    /// </summary>
    public static void HandleClickEvent(GuiContext context, ClickEvent click, Screen? activeScreen) {
        switch (click.Action) {
            case "open_url":
                ClickUrlAction(context, activeScreen, StringField(click, "url"));
                break;
            case "suggest_command":
                activeScreen?.InsertText(StringField(click, "command"), true);
                break;
            case "copy_to_clipboard":
                context.WriteClipboard?.Invoke(StringField(click, "value"));
                break;
            default:
                // open_file is not allowed from a server, whose component vanilla refuses to decode.
                Console.WriteLine($"Don't know how to handle click event {click.Action}");
                break;
        }
    }

    private static string StringField(ClickEvent click, string key) => HoverEffects.Field(click.Fields, key) is StringTag tag ? tag.Value : "";

    /// <summary>
    /// <c>clickUrlAction</c>. Vanilla refuses a link that is not http or https when the component is decoded;
    /// here it is refused on the click.
    /// </summary>
    public static bool ClickUrlAction(GuiContext context, Screen? screen, string url) {
        if (context.Settings is not { ChatLinks: true } settings) {
            return false;
        }
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) || uri.Scheme is not ("http" or "https")) {
            return false;
        }
        if (settings.ChatLinksPrompt) {
            context.Open?.Invoke(new ConfirmLinkScreen(result => {
                if (result) {
                    OpenUri(url);
                }
                context.Open?.Invoke(screen);
            }, url, false));
        }
        else {
            OpenUri(url);
        }
        return true;
    }

    /// <summary><c>Util.getPlatform().openUri</c>.</summary>
    public static void OpenUri(string uri) {
        string opener = OperatingSystem.IsWindows() ? "rundll32" : OperatingSystem.IsMacOS() ? "open" : "xdg-open";
        string arguments = OperatingSystem.IsWindows() ? "url.dll,FileProtocolHandler " + uri : uri;
        try {
            Process.Start(new ProcessStartInfo(opener) { ArgumentList = { arguments }, UseShellExecute = false })?.Dispose();
        }
        catch (Exception e) when (e is System.ComponentModel.Win32Exception or InvalidOperationException) {
            Console.Error.WriteLine($"Couldn't open location '{uri}': {e.Message}");
        }
    }

    /// <summary><c>clickCommandAction</c> through <c>ClientPacketListener.sendUnattendedCommand</c>.</summary>
    public static void ClickCommandAction(GuiContext context, string command, Screen? screenAfterCommand) {
        // Commands.trimOptionalPrefix.
        command = command.StartsWith('/') ? command[1..] : command;
        MinecraftClient client = context.Client;
        switch (client.VerifyCommand(command)) {
            case CommandCheckResult.NoIssues:
                client.SendUnattendedCommand(command);
                context.Open?.Invoke(screenAfterCommand);
                break;
            case CommandCheckResult.ParseErrors:
                OpenCommandSendConfirmationWindow(context, command, "multiplayer.confirm_command.parse_errors", screenAfterCommand);
                break;
            case CommandCheckResult.SignatureRequired:
                OpenSignedCommandSendConfirmationWindow(context, command, screenAfterCommand);
                break;
            case CommandCheckResult.PermissionsRequired:
                OpenCommandSendConfirmationWindow(context, command, "multiplayer.confirm_command.permissions_required", screenAfterCommand);
                break;
        }
    }

    private static void OpenSendConfirmationWindow(GuiContext context, string command, string messageKey, string acceptButton, Action onAccept) {
        Screen? currentScreen = context.CurrentScreen();
        TextComponent message = TextComponent.Translatable(messageKey, with: [TextComponent.Text(command).WithColor(TextColor.Yellow)]);
        context.Open?.Invoke(new ConfirmScreen(result => {
            if (result) {
                onAccept();
            }
            else {
                context.Open?.Invoke(currentScreen);
            }
        }, TextComponent.Translatable("multiplayer.confirm_command.title"), message, acceptButton, Menus.T(currentScreen != null ? "gui.back" : "gui.cancel")));
    }

    private static void OpenCommandSendConfirmationWindow(GuiContext context, string command, string messageKey, Screen? screenAfterCommand) =>
        OpenSendConfirmationWindow(context, command, messageKey, Menus.T("multiplayer.confirm_command.run_command"), () => {
            context.Client.SendUnattendedCommand(command);
            context.Open?.Invoke(screenAfterCommand);
        });

    private static void OpenSignedCommandSendConfirmationWindow(GuiContext context, string command, Screen? screenAfterCommand) {
        const string messageKey = "multiplayer.confirm_command.signature_required";
        bool canOpenChatScreen = screenAfterCommand == null && context.Client.Player != null && context.Client.ChatAbilities.CanSendCommands;
        if (canOpenChatScreen) {
            OpenSendConfirmationWindow(context, command, messageKey, Menus.T("multiplayer.confirm_command.suggest_command"),
                () => context.OpenChat?.Invoke(ChatComponent.ChatMethod.Command, command));
        }
        else {
            OpenSendConfirmationWindow(context, command, messageKey, Menus.T("chat.copy"), () => {
                context.WriteClipboard?.Invoke("/" + command);
                context.Open?.Invoke(screenAfterCommand);
            });
        }
    }
}

/// <summary><c>ConfirmLinkScreen</c>: open, copy, or leave a link a click asked for, with the warning for an untrusted one.</summary>
public sealed class ConfirmLinkScreen(Action<bool> callback, string url, bool trusted) : Screen {
    private const int ButtonWidth = 100;

    public override bool ShowsHud => false;
    public override bool CloseOnEscape => false;

    /// <summary>The constructor taking only the link: <c>confirmMessage</c> is the title, the link the message.</summary>
    private TextComponent Message => TextComponent.Text(url);

    private (List<List<TextRun>> Lines, float Top) Layout(GuiContext context) {
        List<List<TextRun>> lines = context.Text.Wrap(TextFlattener.Flatten(Message), context.Width - 50).Take(15).ToList();
        // The title, the message, the warning when there is one, then the buttons 16 below, all 8 apart.
        float total = 9 + 8 + lines.Count * 9 + (trusted ? 0 : 8 + 9) + 8 + 16 + 20;
        return (lines, (context.Height - total) / 2);
    }

    protected override void Init(GuiContext context, int width, int height) {
        (List<List<TextRun>> lines, float top) = Layout(context);
        float y = top + 9 + 8 + lines.Count * 9 + (trusted ? 0 : 8 + 9) + 8 + 16;
        float left = width / 2.0F - (3 * ButtonWidth + 2 * 4) / 2.0F;
        Add(new Button(Menus.T(trusted ? "chat.link.open" : "gui.yes"), left, y, ButtonWidth, () => callback(true)));
        Add(new Button(Menus.T("chat.copy"), left + ButtonWidth + 4, y, ButtonWidth, () => {
            context.WriteClipboard?.Invoke(url);
            callback(false);
        }));
        Add(new Button(Menus.T(trusted ? "gui.cancel" : "gui.no"), left + 2 * (ButtonWidth + 4), y, ButtonWidth, () => callback(false)));
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        Menus.Background(context);
        (List<List<TextRun>> lines, float top) = Layout(context);
        context.Text.DrawCentred(TextFlattener.Flatten(TextComponent.Translatable(trusted ? "chat.link.confirmTrusted" : "chat.link.confirm")),
            context.Width / 2.0F, top);
        float y = top + 9 + 8;
        foreach (List<TextRun> line in lines) {
            context.Text.DrawCentred(line, context.Width / 2.0F, y);
            y += 9;
        }
        if (!trusted) {
            context.Text.DrawCentred(Menus.T("chat.link.warning"), context.Width / 2.0F, y + 8, 0xFFFFCCCC);
        }
        RenderWidgets(context);
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (key == Key.Escape) {
            callback(false);
        }
    }
}

/// <summary><c>RestrictionsScreen</c>: why chat is restricted, what may be done about it, and what the player can still do.</summary>
public sealed class RestrictionsScreen(Screen previousScreen, ChatAbilities chatAbilities) : Screen {
    public override bool ShowsHud => false;

    private List<(List<TextRun>? Text, ChatRestriction? Action)> Body(GuiContext context) {
        List<(List<TextRun>?, ChatRestriction?)> body = [];
        foreach (ChatRestriction restriction in chatAbilities.Restrictions) {
            TextComponent display = TextComponent.Translatable(ChatAbilities.TranslationKey(restriction)).WithBold().WithColor(TextColor.Red);
            foreach (List<TextRun> line in context.Text.Wrap(TextFlattener.Flatten(display), 250)) {
                body.Add((line, null));
            }
            if (restriction is ChatRestriction.ChatAndCommandsDisabledByOptions or ChatRestriction.ChatDisabledByOptions or ChatRestriction.DisabledByProfile) {
                body.Add((null, restriction));
            }
        }
        if (chatAbilities.HasAnyRestrictions) {
            body.Add(([], null));
        }
        foreach ((bool allowed, string id) in new[] {
                     (chatAbilities.CanSendMessages, "send_messages"), (chatAbilities.CanSendCommands, "send_commands"),
                     (chatAbilities.CanReceiveSystemMessages, "receive_system_messages"), (chatAbilities.CanReceivePlayerMessages, "receive_player_messages")
                 }) {
            TextComponent status = TextComponent.Translatable($"restrictions_screen.permission.{id}.{(allowed ? "allowed" : "denied")}")
                .WithColor(allowed ? TextColor.Green : TextColor.Red);
            foreach (List<TextRun> line in context.Text.Wrap(TextFlattener.Flatten(status), 250)) {
                body.Add((line, null));
            }
        }
        return body;
    }

    protected override void Init(GuiContext context, int width, int height) {
        float y = 33 + 4;
        foreach ((List<TextRun>? text, ChatRestriction? action) in Body(context)) {
            if (action is { } restriction) {
                bool settings = restriction != ChatRestriction.DisabledByProfile;
                Add(new Button(Menus.T(settings ? "chat_restriction.chat_disabled_by_options.action" : "chat_restriction.disabled_by_profile.action"),
                    width / 2.0F - 100, y, 200, () => {
                        if (settings) {
                            context.Open?.Invoke(new ChatOptionsScreen(previousScreen));
                        }
                        else {
                            context.Open?.Invoke(new ConfirmLinkScreen(open => {
                                if (open) {
                                    ClickEvents.OpenUri(AccountSettings);
                                }
                                context.Open?.Invoke(previousScreen);
                            }, AccountSettings, true));
                        }
                    }));
                y += 20;
            }
            else {
                y += text!.Count == 0 ? 10 : 9;
            }
        }
        Add(new Button(Menus.T("gui.done"), width / 2.0F - 100, height - 27, 200, () => Close(context)));
    }

    /// <summary><c>CommonLinks.ACCOUNT_SETTINGS</c>.</summary>
    private const string AccountSettings = "https://aka.ms/JavaAccountSettings";

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        Menus.Background(context);
        context.Text.DrawCentred(Menus.T("restrictions_screen.title"), context.Width / 2.0F, 15);
        float y = 33 + 4;
        foreach ((List<TextRun>? text, ChatRestriction? action) in Body(context)) {
            if (action != null) {
                y += 20;
            }
            else if (text!.Count == 0) {
                y += 10;
            }
            else {
                context.Text.DrawCentred(text, context.Width / 2.0F, y);
                y += 9;
            }
        }
        RenderWidgets(context);
    }

    public override void Close(GuiContext context) => context.Open?.Invoke(previousScreen);
}
