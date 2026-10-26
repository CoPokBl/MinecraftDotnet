using ClientLib;
using ClientLib.Chat;
using GraphicalClient.Gui.Inventory;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary>
/// The font half of vanilla's <c>ChatComponent</c>: the client's messages cut into lines, the scroll position,
/// the history Up and Down walk, and the unsent draft. A new connection's messages replace the old ones; the
/// history and the draft stay, as they belong to the window in vanilla too.
/// </summary>
public sealed class ChatComponent {
    private const int MaxChatHistory = 100, TooltipMaxWidth = 210, MessageTagMarginLeft = 4;
    private const string QueueExpandId = "minecraft:internal/expand_chat_queue", GoToRestrictionsScreen = "minecraft:internal/go_to_restrictions_screen";

    /// <summary>A wrapped line of a message, <c>GuiMessage.Line</c>.</summary>
    private sealed record Line(GuiMessage Parent, List<TextRun> Content, bool EndOfEntry);

    private readonly CommandHistory _commandHistory = new(GameWindow.ClientDirectory);
    private readonly List<string> _recentChat = [];
    private readonly List<Line> _trimmedMessages = [];
    private ChatMessages? _messages;
    private GuiContext? _context;
    private (double Width, double Scale, double Focused, double Unfocused, double Opacity, double Background) _rescaledFor;
    private int _chatScrollbarPos;
    private bool _newMessageSinceScroll;
    private (string Text, ChatMethod Method)? _latestDraft;

    public ChatComponent() => _recentChat.AddRange(_commandHistory.History);

    /// <summary><c>ChatComponent.ChatMethod</c>: what the chat key opens with.</summary>
    public enum ChatMethod {
        Message,
        Command
    }

    /// <summary><c>DisplayMode</c>.</summary>
    public enum DisplayMode {
        Background,
        Foreground,
        ForegroundRestricted
    }

    public IReadOnlyList<string> RecentChat => _recentChat;

    /// <summary>Whether a chat screen is open, which <c>isChatFocused</c> asks of the screen in vanilla.</summary>
    public bool Focused { get; set; }

    private GameSettings Settings => _context!.Settings!;

    /// <summary>Follows the context's client and the options that rescale chat, as their change actions would.</summary>
    public void Bind(GuiContext context) {
        _context = context;
        ChatMessages messages = context.Client.ChatMessages;
        if (messages != _messages) {
            if (_messages != null) {
                _messages.Added -= AddMessageToDisplayQueue;
                _messages.Refreshed -= RefreshTrimmedMessages;
            }
            _messages = messages;
            messages.Added += AddMessageToDisplayQueue;
            messages.Refreshed += RefreshTrimmedMessages;
            // Hud.onDisconnected's clearMessages(true): the history goes back to the saved commands.
            _recentChat.Clear();
            _recentChat.AddRange(_commandHistory.History);
            RescaleChat();
        }
        GameSettings s = Settings;
        if (_rescaledFor != (s.ChatWidth, s.ChatScale, s.ChatHeightFocused, s.ChatHeightUnfocused, s.ChatOpacity, s.TextBackgroundOpacity)) {
            RescaleChat();
        }
    }

    public void RescaleChat() {
        GameSettings s = Settings;
        _rescaledFor = (s.ChatWidth, s.ChatScale, s.ChatHeightFocused, s.ChatHeightUnfocused, s.ChatOpacity, s.TextBackgroundOpacity);
        ResetChatScroll();
        RefreshTrimmedMessages();
    }

    private void RefreshTrimmedMessages() {
        _trimmedMessages.Clear();
        if (_messages == null || _context == null) {
            return;
        }
        for (int i = _messages.All.Count - 1; i >= 0; i--) {
            if (_messages.IsVisible(_messages.All[i])) {
                AddMessageToDisplayQueue(_messages.All[i]);
            }
        }
    }

    private void AddMessageToDisplayQueue(GuiMessage message) {
        if (_context == null) {
            return;
        }
        int maxWidth = (int)Math.Floor(Width / Settings.ChatScale);
        List<List<TextRun>> lines = SplitLines(message, maxWidth);
        for (int i = 0; i < lines.Count; i++) {
            if (Focused && _chatScrollbarPos > 0) {
                _newMessageSinceScroll = true;
                ScrollChat(1);
            }
            _trimmedMessages.Insert(0, new Line(message, lines[i], i == lines.Count - 1));
        }
        if (_trimmedMessages.Count > MaxChatHistory) {
            _trimmedMessages.RemoveRange(MaxChatHistory, _trimmedMessages.Count - MaxChatHistory);
        }
    }

    /// <summary>
    /// <c>GuiMessage.splitLines</c> through <c>ComponentRenderUtils.wrapComponents</c>: room is left for a tag's
    /// icon, a wrapped line starts with a space, and without the colours option section sign codes are taken out.
    /// </summary>
    private List<List<TextRun>> SplitLines(GuiMessage message, int maxWidth) {
        if (message.Tag?.Icon != null) {
            maxWidth -= GuiMessageTag.IconWidth + MessageTagMarginLeft + 2;
        }
        List<TextRun> runs = TextFlattener.Flatten(message.Content);
        if (!Settings.ChatColors) {
            runs = runs.Select(run => run with { Text = StripFormatting(run.Text) }).ToList();
        }
        List<List<TextRun>> result = [];
        _context!.Text.Splitter.SplitLines(TextFlattener.Decode(runs), maxWidth, (line, wrapped) => {
            if (wrapped) {
                line.Insert(0, new TextRun(" ", TextFlattener.DefaultRgb));
            }
            result.Add(line);
        });
        return result.Count == 0 ? [[]] : result;
    }

    /// <summary><c>ChatFormatting.stripFormatting</c>.</summary>
    private static string StripFormatting(string input) =>
        System.Text.RegularExpressions.Regex.Replace(input, "(?i)\u00a7[0-9A-FK-OR]", "");

    public void AddRecentChat(string message) {
        if (_recentChat.Count == 0 || _recentChat[^1] != message) {
            if (_recentChat.Count >= MaxChatHistory) {
                _recentChat.RemoveAt(0);
            }
            _recentChat.Add(message);
        }
        if (message.StartsWith('/')) {
            _commandHistory.AddCommand(message);
        }
    }

    public void ResetChatScroll() {
        _chatScrollbarPos = 0;
        _newMessageSinceScroll = false;
    }

    public void ScrollChat(int dir) {
        _chatScrollbarPos += dir;
        int max = _trimmedMessages.Count;
        if (_chatScrollbarPos > max - LinesPerPage) {
            _chatScrollbarPos = max - LinesPerPage;
        }
        if (_chatScrollbarPos <= 0) {
            _chatScrollbarPos = 0;
            _newMessageSinceScroll = false;
        }
    }

    private int Width => (int)Math.Floor(Settings.ChatWidth * 280.0 + 40.0);

    private int Height => (int)Math.Floor((Focused ? Settings.ChatHeightFocused : Settings.ChatHeightUnfocused) * 160.0 + 20.0);

    public int LinesPerPage => Height / LineHeight;

    private int LineHeight => (int)(9.0 * (Settings.ChatLineSpacing + 1.0));

    public void SaveAsDraft(string text) => _latestDraft = (text, text.StartsWith('/') ? ChatMethod.Command : ChatMethod.Message);

    public void DiscardDraft() => _latestDraft = null;

    /// <summary><c>createScreen</c>: the draft when the method takes it, a command draft only for the command key.</summary>
    public T CreateScreen<T>(ChatMethod chatMethod, Func<string, bool, T> chat) where T : ChatScreen =>
        _latestDraft is { } draft && (chatMethod == ChatMethod.Message || draft.Method == chatMethod)
            ? chat(draft.Text, true)
            : chat(chatMethod == ChatMethod.Command ? "/" : "", false);

    /// <summary><c>AlphaCalculator.timeBased</c>.</summary>
    private static float TimeBasedAlpha(int currentTickTime, Line message) {
        double t = (currentTickTime - message.Parent.AddedTime) / 200.0;
        t = 1.0 - t;
        t *= 10.0;
        t = Math.Clamp(t, 0.0, 1.0);
        t *= t;
        return (float)t;
    }

    /// <summary>
    /// <c>extractRenderState</c>. In a foreground mode the text under the cursor is looked up, its hover event and
    /// any tag's text being returned for the caller to draw last, as vanilla defers tooltips to the end of the frame.
    /// </summary>
    public Action? Render(GuiContext context, int ticks, float mouseX, float mouseY, DisplayMode displayMode) {
        Bind(context);
        Action? tooltip = null;
        Walk(context, ticks, displayMode, mouseX, mouseY, draw: true, onTooltip: t => tooltip = t, out _);
        return tooltip;
    }

    /// <summary><c>captureClickableText</c> with <c>ClickableStyleFinder</c>: the run with a click event under the point, or with an insertion when asked.</summary>
    public TextRun? FindClickable(GuiContext context, int ticks, float x, float y, DisplayMode displayMode, bool includeInsertions) {
        Bind(context);
        Walk(context, ticks, displayMode, x, y, draw: false, onTooltip: _ => { }, out List<TextRun> hits);
        TextRun? result = null;
        foreach (TextRun run in hits) {
            if (run.Click != null || includeInsertions && run.Insertion != null) {
                result = run;
            }
        }
        return result;
    }

    private void Walk(GuiContext context, int ticks, DisplayMode displayMode, float mouseX, float mouseY, bool draw, Action<Action> onTooltip,
        out List<TextRun> hits) {
        hits = [];
        bool isForeground = displayMode != DisplayMode.Background;
        bool isRestricted = displayMode == DisplayMode.ForegroundRestricted;
        int total = _trimmedMessages.Count;
        if (total == 0 && !isRestricted) {
            return;
        }
        GameSettings settings = Settings;
        float scale = (float)settings.ChatScale;
        int maxWidth = (int)Math.Ceiling(Width / scale);
        int chatBottom = (int)Math.Floor((context.Height - 40) / scale);
        float textOpacity = (float)settings.ChatOpacity * 0.9F + 0.1F;
        float backgroundOpacity = (float)settings.TextBackgroundOpacity;
        const int messageHeight = 9;
        double chatLineSpacing = settings.ChatLineSpacing;
        int entryHeight = (int)(messageHeight * (chatLineSpacing + 1.0));
        int entryBottomToMessageY = (int)Math.Round(8.0 * (chatLineSpacing + 1.0) - 4.0 * chatLineSpacing);
        long queueSize = context.Client.ChatListener.QueueSize;
        // The pose is scaled, then moved four right; the mouse is taken into it the other way.
        float localX = mouseX / scale - 4, localY = mouseY / scale;
        Rendering.GuiRenderer gui = context.Gui;
        float previousZoom = gui.Zoom;
        gui.Zoom = previousZoom * scale;
        void Fill(int x0, int y0, int x1, int y1, uint color) {
            if (draw) {
                gui.Rect(Math.Min(x0, x1) + 4, Math.Min(y0, y1), Math.Abs(x1 - x0), Math.Abs(y1 - y0), color);
            }
        }
        List<TextRun> found = hits;
        bool HandleMessage(int textTop, float opacity, List<TextRun> message) {
            TextRun? hovered = isForeground || !draw ? context.Text.RunAt(message, 0, textTop, localX, localY) : null;
            if (draw) {
                context.Text.Draw(message, 4, textTop, (byte)Math.Floor(Math.Clamp(opacity, 0.0F, 1.0F) * 255.0F));
            }
            else if (hovered is { } run) {
                found.Add(run);
            }
            if (draw && isForeground && hovered?.Hover is { } hover) {
                onTooltip(() => HoverEffects.Draw(context, hover, mouseX, mouseY));
            }
            return hovered != null;
        }
        bool IsMouseOver(int left, int top, int right, int bottom) => localX >= left && localX < right && localY >= top && localY < bottom;
        void ShowTooltip(GuiMessageTag tag) {
            if (tag.Text is { } text) {
                onTooltip(() => Tooltips.Draw(context, context.Text.Wrap(TextFlattener.Flatten(text), TooltipMaxWidth), mouseX, mouseY));
            }
        }

        int perPage = LinesPerPage;
        int first = Math.Min(total - _chatScrollbarPos, perPage) - 1;
        Func<Line, float> alphaOf = isForeground ? _ => 1.0F : line => TimeBasedAlpha(ticks, line);
        int count = 0;
        for (int i = first; i >= 0; i--) {
            float alpha = alphaOf(_trimmedMessages[i + _chatScrollbarPos]);
            if (alpha > 1.0E-5F) {
                count++;
                int entryBottom = chatBottom - i * entryHeight;
                Fill(-4, entryBottom - entryHeight, maxWidth + 4 + 4, entryBottom, Black(alpha * backgroundOpacity));
            }
        }
        int lineAboveMessagesY = chatBottom - (count + 1) * entryHeight;
        if (queueSize > 0L) {
            Fill(-2, chatBottom, maxWidth + 4, chatBottom + messageHeight, Black(backgroundOpacity));
        }
        if (isRestricted) {
            Fill(-2, lineAboveMessagesY, maxWidth + 4 + 4, lineAboveMessagesY + entryHeight, Black(backgroundOpacity));
        }

        bool hoveredOverCurrentMessage = false;
        for (int i = first; i >= 0; i--) {
            Line line = _trimmedMessages[i + _chatScrollbarPos];
            float alpha = alphaOf(line);
            if (alpha <= 1.0E-5F) {
                continue;
            }
            int entryBottom = chatBottom - i * entryHeight;
            int entryTop = entryBottom - entryHeight;
            int textTop = entryBottom - entryBottomToMessageY;
            hoveredOverCurrentMessage |= HandleMessage(textTop, alpha * textOpacity, line.Content);
            bool forceIconRendering = false;
            if (line.EndOfEntry) {
                forceIconRendering = hoveredOverCurrentMessage;
                hoveredOverCurrentMessage = false;
            }
            if (line.Parent.Tag is not { } tag) {
                continue;
            }
            Fill(-4, entryTop, -2, entryBottom, (uint)Math.Floor(alpha * textOpacity * 255.0F) << 24 | (uint)tag.IndicatorColor & 0xFFFFFF);
            if (isForeground && draw && IsMouseOver(-4, entryTop, -2, entryBottom)) {
                ShowTooltip(tag);
            }
            if (tag.Icon != null && isForeground && draw) {
                int iconLeft = context.Text.Width(line.Content) + MessageTagMarginLeft;
                int iconBottom = textTop + messageHeight;
                int iconTop = iconBottom - GuiMessageTag.IconHeight - 1;
                bool over = IsMouseOver(iconLeft, iconTop, iconLeft + GuiMessageTag.IconWidth, iconBottom);
                if (over) {
                    ShowTooltip(tag);
                }
                if (forceIconRendering || over) {
                    context.Sprites.Sprite(gui, "icon/chat_modified", iconLeft + 4, iconTop, GuiMessageTag.IconWidth, GuiMessageTag.IconHeight);
                }
            }
        }
        if (queueSize > 0L) {
            TextComponent queue = TextComponent.Translatable("chat.queue", with: [TextComponent.Text(queueSize.ToString())])
                .WithClickEvent(new ClickEvent("custom", ("id", new NBT.Tags.StringTag(QueueExpandId))))
                .WithHoverEvent(HoverEvent.ShowText(TextComponent.Translatable("chat.queue.tooltip")));
            HandleMessage(chatBottom + messageHeight - 8, 0.5F * textOpacity, TextFlattener.Flatten(queue));
        }
        if (isRestricted) {
            TextComponent restricted = TextComponent.Translatable("chat_screen.restricted").WithColor(TextColor.Red).WithUnderlined()
                .WithClickEvent(new ClickEvent("custom", ("id", new NBT.Tags.StringTag(GoToRestrictionsScreen))));
            List<TextRun> runs = TextFlattener.Flatten(restricted);
            if (context.Text.Width(runs) > maxWidth) {
                // ComponentRenderUtils.clipText, the hover saying it all.
                restricted.WithHoverEvent(HoverEvent.ShowText(TextComponent.Translatable("chat_screen.restricted")));
                runs = Clip(context, TextFlattener.Flatten(restricted), maxWidth);
            }
            HandleMessage(lineAboveMessagesY + entryHeight - entryBottomToMessageY - 1, textOpacity, runs);
        }
        if (total > 0 && isForeground) {
            int chatHeight = count * entryHeight;
            int virtualHeight = total * entryHeight;
            int y = _chatScrollbarPos * chatHeight / total - chatBottom;
            int height = chatHeight * chatHeight / virtualHeight;
            if (virtualHeight != chatHeight) {
                uint alpha = y > 0 ? 170u : 96u;
                uint color = _newMessageSinceScroll ? 0xCC3333u : 0x3333AAu;
                int scrollBarStartX = maxWidth + 4;
                Fill(scrollBarStartX, -y, scrollBarStartX + 2, -y - height, alpha << 24 | color);
                Fill(scrollBarStartX + 2, -y, scrollBarStartX + 1, -y - height, alpha << 24 | 0xCCCCCC);
            }
        }
        gui.Zoom = previousZoom;
    }

    public static bool IsQueueExpand(ClickEvent click) => click.Action == "custom" && CustomId(click) == QueueExpandId;

    public static bool IsGoToRestrictions(ClickEvent click) => click.Action == "custom" && CustomId(click) == GoToRestrictionsScreen;

    private static string? CustomId(ClickEvent click) => click.Fields.FirstOrDefault(f => f.Key == "id").Tag is NBT.Tags.StringTag id
        ? id.Value.Contains(':') ? id.Value : "minecraft:" + id.Value
        : null;

    private static uint Black(float alpha) => (uint)Math.Floor(Math.Clamp(alpha, 0.0F, 1.0F) * 255.0F) << 24;

    /// <summary><c>ComponentRenderUtils.clipText</c>: what fits before an ellipsis, then the ellipsis.</summary>
    private static List<TextRun> Clip(GuiContext context, List<TextRun> runs, int width) {
        int room = width - context.Text.Width("...");
        List<TextRun> clipped = [];
        float used = 0;
        foreach (TextRun run in runs) {
            string text = "";
            foreach (char c in run.Text) {
                float advance = context.Text.Advance(c, run.Bold);
                if (used + advance > room) {
                    break;
                }
                used += advance;
                text += c;
            }
            clipped.Add(run with { Text = text });
            if (text.Length < run.Text.Length) {
                break;
            }
        }
        clipped.Add(new TextRun("...", TextFlattener.DefaultRgb));
        return clipped;
    }
}

/// <summary><c>CommandHistory</c>: the last fifty commands, kept in <c>command_history.txt</c>.</summary>
public sealed class CommandHistory {
    private const int MaxPersistedCommandHistory = 50;
    private readonly string _commandsPath;
    private readonly List<string> _lastCommands = [];

    public CommandHistory(string gameFolder) {
        _commandsPath = Path.Combine(gameFolder, "command_history.txt");
        try {
            if (File.Exists(_commandsPath)) {
                _lastCommands.AddRange(File.ReadAllLines(_commandsPath));
            }
        }
        catch (IOException e) {
            Console.Error.WriteLine($"Failed to read command_history.txt, command history will be missing: {e.Message}");
        }
    }

    public IReadOnlyList<string> History => _lastCommands;

    public void AddCommand(string command) {
        if (_lastCommands.Count > 0 && _lastCommands[^1] == command) {
            return;
        }
        if (_lastCommands.Count >= MaxPersistedCommandHistory) {
            _lastCommands.RemoveAt(0);
        }
        _lastCommands.Add(command);
        try {
            Directory.CreateDirectory(Path.GetDirectoryName(_commandsPath)!);
            File.WriteAllLines(_commandsPath, _lastCommands);
        }
        catch (IOException e) {
            Console.Error.WriteLine($"Failed to write command_history.txt, command history will be missing: {e.Message}");
        }
    }
}
