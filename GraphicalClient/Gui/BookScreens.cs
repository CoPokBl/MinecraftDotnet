using ClientLib;
using ClientLib.Inventory;
using GraphicalClient.Gui.Inventory;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Text;
using NBT;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>The art and text the three book screens share.</summary>
public static class Book {
    public const int ImageWidth = 192, ImageHeight = 192;
    public const uint Black = 0xFF000000;

    public static string Tr(string key) => Translations.Get(key) ?? key;

    public static int BackgroundLeft(int width) => (width - ImageWidth) / 2;

    public const int BackgroundTop = 2;

    public const int MenuControlsTop = BackgroundTop + ImageHeight + 2;

    /// <summary>The blit of <c>textures/gui/book.png</c>, or a cover and page of the client's own where there is no pack.</summary>
    public static void DrawBackground(GuiContext context, int left, int top) {
        context.Gui.Rect(0, 0, context.Width, context.Height, 0x80101010);
        if (context.Sprites.Region(context.Gui, "gui/book", left, top, 0, 0, ImageWidth, ImageHeight)) {
            return;
        }
        context.Gui.Rect(left + 20, top + 1, 152, 180, 0xFF5A3A1E);
        context.Gui.Rect(left + 24, top + 5, 146, 172, 0xFFF3E9CF);
        context.Gui.Rect(left + 24, top + 172, 146, 5, 0xFFD9CBA6);
    }

    /// <summary><c>book.pageIndicator</c> in black without shadow, aligned to end at <paramref name="right"/>.</summary>
    public static void DrawPageIndicator(GuiContext context, int page, int pageCount, int right, int y) {
        List<TextRun> pageMsg = TextFlattener.Flatten(TextComponent.Translatable("book.pageIndicator", null,
            [TextComponent.Text((page + 1).ToString()), TextComponent.Text(pageCount.ToString())]), 0x000000);
        context.Text.Draw(pageMsg, right - context.Text.Width(pageMsg), y, shadow: false);
    }
}

/// <summary><c>PageButton</c>: an arrow under a book's page, which turns it with a page turn sound instead of a click.</summary>
public sealed class PageButton(float x, float y, bool isForward, Action onPress, bool playTurnSound) : Widget(x, y, 23, 13) {
    public override void Render(GuiContext context, bool hovered) {
        string sprite = isForward ? hovered ? "widget/page_forward_highlighted" : "widget/page_forward"
            : hovered ? "widget/page_backward_highlighted" : "widget/page_backward";
        if (context.Sprites.Sprite(context.Gui, sprite, X, Y, W, H)) {
            return;
        }
        uint colour = hovered ? 0xFFB01818 : 0xFF6E4A28;
        for (int i = 0; i < 6; i++) {
            float column = isForward ? X + 11 + i * 2 : X + 10 - i * 2;
            context.Gui.Rect(column, Y + 1 + i, 2, H - 2 - 2 * i, colour);
        }
        context.Gui.Rect(isForward ? X + 3 : X + 12, Y + 5, 8, 3, colour);
    }

    public override void OnClick(GuiContext context, float mouseX) {
        PlayDownSound(context);
        onPress();
    }

    /// <summary><c>Button.onPress</c> from a key, which makes no sound.</summary>
    public void Press() => onPress();

    private void PlayDownSound(GuiContext context) {
        if (playTurnSound) {
            Screen.PlayUi(context, SoundType.BookPageTurn);
        }
    }
}

/// <summary>
/// <c>BookViewScreen</c>: a book's pages read one at a time, with its text's click and hover events. The
/// lectern's screen is this one turning pages through its menu.
/// </summary>
public class BookViewScreen : Screen {
    private const int TextWidth = 114, TextHeight = 128;
    private const int PageTextXOffset = 36, PageTextYOffset = 30, PageIndicatorXOffset = 148, PageIndicatorTextYOffset = 16;
    private const int PageButtonY = 157, PageBackButtonX = 43, PageForwardButtonX = 116;

    private List<TextComponent> _bookAccess;
    private int _currentPage;
    private List<List<TextRun>> _cachedPageComponents = [];
    private int _cachedPage = -1;
    private PageButton? _forwardButton;
    private PageButton? _backButton;
    private readonly bool _playTurnSound;

    public BookViewScreen(List<TextComponent> bookAccess) : this(bookAccess, true) {
    }

    protected BookViewScreen(List<TextComponent> bookAccess, bool playTurnSound) {
        _bookAccess = bookAccess;
        _playTurnSound = playTurnSound;
    }

    public override bool ShowsHud => false;

    private int NumPages => _bookAccess.Count;

    private TextComponent GetPage(int page) => page >= 0 && page < NumPages ? _bookAccess[page] : TextComponent.Text("");

    public void SetBookAccess(List<TextComponent> bookAccess) {
        _bookAccess = bookAccess;
        _currentPage = Math.Clamp(_currentPage, 0, bookAccess.Count);
        UpdateButtonVisibility();
        _cachedPage = -1;
    }

    public bool SetPage(int page) {
        // Mth.clamp, which unlike Math.Clamp takes the maximum when the range is empty.
        int clampedPage = Math.Min(Math.Max(page, 0), NumPages - 1);
        if (clampedPage == _currentPage) {
            return false;
        }
        _currentPage = clampedPage;
        UpdateButtonVisibility();
        _cachedPage = -1;
        return true;
    }

    protected virtual bool ForcePage(int page) => SetPage(page);

    protected override void Init(GuiContext context, int width, int height) {
        CreateMenuControls(context, width);
        int left = Book.BackgroundLeft(width), top = Book.BackgroundTop;
        _forwardButton = new PageButton(left + PageForwardButtonX, top + PageButtonY, true, PageForward, _playTurnSound);
        _backButton = new PageButton(left + PageBackButtonX, top + PageButtonY, false, PageBack, _playTurnSound);
        Add(_forwardButton);
        Add(_backButton);
        UpdateButtonVisibility();
    }

    protected virtual void CreateMenuControls(GuiContext context, int width) {
        Add(new Button(Book.Tr("gui.done"), (width - 200) / 2, Book.MenuControlsTop, 200, () => Close(context)));
    }

    protected virtual void PageBack() {
        if (_currentPage > 0) {
            _currentPage--;
        }
        UpdateButtonVisibility();
    }

    protected virtual void PageForward() {
        if (_currentPage < NumPages - 1) {
            _currentPage++;
        }
        UpdateButtonVisibility();
    }

    private void UpdateButtonVisibility() {
        if (_forwardButton == null || _backButton == null) {
            return;
        }
        _forwardButton.Visible = _currentPage < NumPages - 1;
        _backButton.Visible = _currentPage > 0;
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        switch (key) {
            case Key.PageUp:
                _backButton?.Press();
                return;
            case Key.PageDown:
                _forwardButton?.Press();
                return;
            default:
                base.KeyDown(context, key, control);
                return;
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        int left = Book.BackgroundLeft(context.Width), top = Book.BackgroundTop;
        Book.DrawBackground(context, left, top);
        RenderWidgets(context);
        VisitText(context, left, top);
    }

    /// <summary>The page's lines, cut to what fits, as <c>visitText</c> lays them out.</summary>
    private List<List<TextRun>> PageLines(GuiContext context) {
        if (_cachedPage != _currentPage) {
            // ComponentUtils.mergeStyles with PAGE_TEXT_STYLE: black under the page's own style, and no shadow.
            _cachedPageComponents = context.Text.Splitter.SplitLines(TextFlattener.Flatten(GetPage(_currentPage), 0x000000), TextWidth);
            _cachedPage = _currentPage;
        }
        return _cachedPageComponents;
    }

    private void VisitText(GuiContext context, int left, int top) {
        Book.DrawPageIndicator(context, _currentPage, Math.Max(NumPages, 1), left + PageIndicatorXOffset, top + PageIndicatorTextYOffset);
        List<List<TextRun>> lines = PageLines(context);
        int shownLines = Math.Min(TextHeight / 9, lines.Count);
        TextRun? hovered = null;
        for (int i = 0; i < shownLines; i++) {
            float x = left + PageTextXOffset, y = top + PageTextYOffset + i * 9;
            context.Text.Draw(lines[i], x, y, shadow: false);
            hovered = context.Text.RunAt(lines[i], x, y, context.MouseX, context.MouseY) ?? hovered;
        }
        if (hovered?.Hover is { Action: "show_text" } hover && hover.Fields.FirstOrDefault(f => f.Key == "value").Tag is { } value) {
            // GuiGraphicsExtractor.componentHoverEffect; show_item and show_entity tooltips are not ported.
            List<List<TextRun>> tooltip = context.Text.Splitter.SplitLines(TextFlattener.Flatten(TextComponent.FromTag(value)), Math.Max(context.Width / 2, 200));
            Tooltips.Draw(context, tooltip, context.MouseX, context.MouseY);
        }
    }

    /// <summary><c>mouseClicked</c>: a click on text with a click event runs it before the buttons get a turn.</summary>
    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (button == MouseButton.Left) {
            List<List<TextRun>> lines = PageLines(context);
            int left = Book.BackgroundLeft(context.Width), top = Book.BackgroundTop;
            ClickEvent? clicked = null;
            for (int i = 0; i < Math.Min(TextHeight / 9, lines.Count); i++) {
                if (context.Text.RunAt(lines[i], left + PageTextXOffset, top + PageTextYOffset + i * 9, x, y) is { Click: { } click }) {
                    clicked = click;
                }
            }
            if (clicked != null && HandleClickEvent(context, clicked)) {
                return;
            }
        }
        base.MouseDown(context, x, y, button);
    }

    /// <summary>
    /// <c>handleClickEvent</c>. A command runs without the confirmation vanilla asks for one it cannot parse
    /// or that needs signing, and links, files and dialogs are not opened.
    /// </summary>
    private bool HandleClickEvent(GuiContext context, ClickEvent clickEvent) {
        switch (clickEvent.Action) {
            case "change_page":
                ForcePage(Field(clickEvent, "page")?.GetInteger() - 1 ?? 0);
                break;
            case "run_command":
                CloseContainerOnServer(context);
                string command = Field(clickEvent, "command")?.GetString() ?? "";
                context.Client.SendChat("/" + (command.StartsWith('/') ? command[1..] : command));
                context.Open?.Invoke(null);
                break;
            case "copy_to_clipboard":
                context.WriteClipboard?.Invoke(Field(clickEvent, "value")?.GetString() ?? "");
                break;
        }
        return true;
    }

    private static INbtTag? Field(ClickEvent clickEvent, string key) => clickEvent.Fields.FirstOrDefault(f => f.Key == key).Tag;

    protected virtual void CloseContainerOnServer(GuiContext context) {
    }
}

/// <summary>
/// <c>LecternScreen</c>: the book on a lectern, its pages turned by the server. The menu listeners are
/// read each frame instead: a changed book resets the pages, a changed page property turns to it.
/// </summary>
public sealed class LecternScreen : BookViewScreen {
    private readonly MinecraftClient _client;
    private readonly LecternMenu _menu;
    private ItemStack? _shownBook;
    private int _shownPage = -1;

    public LecternScreen(MinecraftClient client, LecternMenu menu) : base([], false) {
        _client = client;
        _menu = menu;
    }

    public override bool IsAllowedInPortal => false;

    protected override void CreateMenuControls(GuiContext context, int width) {
        if (_client.Player?.GameMode is GameMode.Survival or GameMode.Creative) {
            int middle = width / 2;
            Add(new Button(Book.Tr("gui.done"), middle - 98 - 2, Book.MenuControlsTop, 98, () => Close(context)));
            Add(new Button(Book.Tr("lectern.take_book"), middle + 2, Book.MenuControlsTop, 98, () => SendButtonClick(LecternMenu.ButtonTakeBook)));
        }
        else {
            base.CreateMenuControls(context, width);
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        ItemStack book = _menu.Slots[0].Item.ToItemStack();
        if (!book.Equals(_shownBook)) {
            _shownBook = book;
            SetBookAccess(BookAccess.FromItem(book) ?? []);
        }
        if (_menu.Page != _shownPage) {
            _shownPage = _menu.Page;
            SetPage(_shownPage);
        }
        base.Render(context, partialTick);
    }

    protected override void PageBack() => SendButtonClick(LecternMenu.ButtonPreviousPage);

    protected override void PageForward() => SendButtonClick(LecternMenu.ButtonNextPage);

    protected override bool ForcePage(int page) {
        if (page == _menu.Page) {
            return false;
        }
        SendButtonClick(LecternMenu.ButtonPageBase + page);
        return true;
    }

    private void SendButtonClick(int button) => _client.ClickContainerButton(button);

    public override void Close(GuiContext context) {
        _client.CloseContainer();
        base.Close(context);
    }

    protected override void CloseContainerOnServer(GuiContext context) => _client.CloseContainer();
}

/// <summary>
/// <c>MultiLineEditBox</c> as the book uses it: no background, scroll bar or character count, black text
/// without shadow. The book's line limit keeps the text inside the box, so it never scrolls and the
/// scroll area is left out. A double click does not select a word: the window reports no click count.
/// </summary>
public sealed class MultiLineEditBox {
    private const int InnerPadding = 4;
    private const int LineHeight = 9;
    private const uint TextColor = Book.Black, CursorColor = Book.Black;

    private readonly TextRenderer _font;
    private readonly MultilineTextField _textField;
    private long _focusedTime = Environment.TickCount64;

    public MultiLineEditBox(TextRenderer font, int x, int y, int width, int height) {
        _font = font;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        _textField = new MultilineTextField(font.Splitter, width - InnerPadding * 2);
    }

    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }

    public MultilineTextField TextField => _textField;

    public string Value => _textField.Value;

    public bool IsMouseOver(float mouseX, float mouseY) => mouseX >= X && mouseY >= Y && mouseX < X + Width && mouseY < Y + Height;

    private int InnerLeft => X + InnerPadding;
    private int InnerTop => Y + InnerPadding;

    public void OnClick(float mouseX, float mouseY, bool shift) {
        _textField.Selecting = shift;
        SeekCursorScreen(mouseX, mouseY);
    }

    public void OnDrag(float mouseX, float mouseY, bool shift) {
        _textField.Selecting = true;
        SeekCursorScreen(mouseX, mouseY);
        _textField.Selecting = shift;
    }

    private void SeekCursorScreen(float x, float y) => _textField.SeekCursorToPoint(x - X - InnerPadding, y - Y - InnerPadding);

    public bool CharTyped(char c) {
        if (!MultilineTextField.IsAllowedChatCharacter(c)) {
            return false;
        }
        _textField.InsertText(c.ToString());
        return true;
    }

    /// <summary><c>MultilineTextField.keyPressed</c>. Ctrl stands for vanilla's platform edit modifier.</summary>
    public bool KeyPressed(GuiContext context, Key key, bool control, bool shift) {
        MultilineTextField field = _textField;
        field.Selecting = shift;
        if (control && !shift) {
            switch (key) {
                case Key.A:
                    field.SelectAll();
                    return true;
                case Key.C:
                    context.WriteClipboard?.Invoke(field.SelectedText);
                    return true;
                case Key.V:
                    field.InsertText(context.ReadClipboard?.Invoke() ?? "");
                    return true;
                case Key.X:
                    context.WriteClipboard?.Invoke(field.SelectedText);
                    field.InsertText("");
                    return true;
            }
        }
        switch (key) {
            case Key.Enter or Key.KeypadEnter:
                field.InsertText("\n");
                return true;
            case Key.Backspace:
                field.DeleteText(control ? field.PreviousWord.BeginIndex - field.Cursor : -1);
                return true;
            case Key.Delete:
                field.DeleteText(control ? field.NextWord.BeginIndex - field.Cursor : 1);
                return true;
            case Key.Right:
                if (control) {
                    field.SeekCursor(MultilineTextField.Whence.Absolute, field.NextWord.BeginIndex);
                }
                else {
                    field.SeekCursor(MultilineTextField.Whence.Relative, 1);
                }
                return true;
            case Key.Left:
                if (control) {
                    field.SeekCursor(MultilineTextField.Whence.Absolute, field.PreviousWord.BeginIndex);
                }
                else {
                    field.SeekCursor(MultilineTextField.Whence.Relative, -1);
                }
                return true;
            case Key.Down:
                if (!control) {
                    field.SeekCursorLine(1);
                }
                return true;
            case Key.Up:
                if (!control) {
                    field.SeekCursorLine(-1);
                }
                return true;
            case Key.PageUp:
                field.SeekCursor(MultilineTextField.Whence.Absolute, 0);
                return true;
            case Key.PageDown:
                field.SeekCursor(MultilineTextField.Whence.End, 0);
                return true;
            case Key.Home:
                field.SeekCursor(MultilineTextField.Whence.Absolute, control ? 0 : field.CursorLine.BeginIndex);
                return true;
            case Key.End:
                if (control) {
                    field.SeekCursor(MultilineTextField.Whence.End, 0);
                }
                else {
                    field.SeekCursor(MultilineTextField.Whence.Absolute, field.CursorLine.EndIndex);
                }
                return true;
            default:
                return false;
        }
    }

    /// <summary><c>extractContents</c>, always focused.</summary>
    public void Render(GuiContext context) {
        string value = _textField.Value;
        int cursor = _textField.Cursor;
        bool showCursor = (Environment.TickCount64 - _focusedTime) / 300L % 2L == 0L;
        bool insertCursor = cursor < value.Length;
        int cursorX = 0;
        int cursorY = 0;
        int drawTop = InnerTop;
        int innerLeft = InnerLeft;
        bool hasDrawnCursor = false;
        foreach (MultilineTextField.StringView lineView in _textField.Lines) {
            bool lineWithinVisibleBounds = WithinContentAreaTopBottom(drawTop, drawTop + LineHeight);
            if (!hasDrawnCursor && showCursor && insertCursor && cursor >= lineView.BeginIndex && cursor <= lineView.EndIndex) {
                if (lineWithinVisibleBounds) {
                    string textBeforeCursor = value[lineView.BeginIndex..cursor];
                    int textBeforeCursorPosRight = innerLeft + _font.Width(textBeforeCursor);
                    string textAfterCursor = value[cursor..lineView.EndIndex];
                    _font.Draw(textBeforeCursor, innerLeft, drawTop, TextColor, false);
                    _font.Draw(textAfterCursor, textBeforeCursorPosRight, drawTop, TextColor, false);
                    // TextCursorUtils.extractInsertCursor
                    context.Gui.Rect(textBeforeCursorPosRight, drawTop - 1, 1, LineHeight + 1 + 1, CursorColor);
                    hasDrawnCursor = true;
                }
            }
            else if (lineWithinVisibleBounds) {
                string substring = value[lineView.BeginIndex..lineView.EndIndex];
                _font.Draw(substring, innerLeft, drawTop, TextColor, false);
                if (showCursor && !insertCursor) {
                    cursorX = innerLeft + _font.Width(substring);
                    cursorY = drawTop;
                }
            }
            drawTop += LineHeight;
        }
        if (showCursor && !insertCursor && WithinContentAreaTopBottom(cursorY, cursorY + LineHeight)) {
            // TextCursorUtils.extractAppendCursor
            _font.Draw("_", cursorX, cursorY, CursorColor, false);
        }
        if (_textField.HasSelection) {
            MultilineTextField.StringView selection = _textField.Selected;
            int drawX = InnerLeft;
            drawTop = InnerTop;
            foreach (MultilineTextField.StringView lineView in _textField.Lines) {
                if (selection.BeginIndex > lineView.EndIndex) {
                    drawTop += LineHeight;
                    continue;
                }
                if (lineView.BeginIndex > selection.EndIndex) {
                    break;
                }
                if (WithinContentAreaTopBottom(drawTop, drawTop + LineHeight)) {
                    int drawBegin = _font.Width(value[lineView.BeginIndex..Math.Max(selection.BeginIndex, lineView.BeginIndex)]);
                    int drawEnd = selection.EndIndex > lineView.EndIndex
                        ? Width - InnerPadding
                        : _font.Width(value[lineView.BeginIndex..selection.EndIndex]);
                    EditBox.TextHighlight(context, drawX + drawBegin, drawTop, drawX + drawEnd, drawTop + LineHeight);
                }
                drawTop += LineHeight;
            }
        }
    }

    private bool WithinContentAreaTopBottom(int top, int bottom) => bottom >= Y && top <= Y + Height;
}

/// <summary><c>BookEditScreen</c>: a book and quill's pages, kept here until Done sends them or Sign moves on to the title.</summary>
public sealed class BookEditScreen : Screen {
    private const int TextWidth = 114, TextHeight = 126;
    private const int PageButtonY = 157, PageBackButtonX = 43, PageForwardButtonX = 116;
    private const int PageIndicatorTextYOffset = 16, PageIndicatorXOffset = 148;
    private const int MenuButtonSize = 98;
    private const int MaxPages = 100, MaxPageCharacters = 1024;

    private readonly MinecraftClient _client;
    private readonly ItemStack _book;
    private readonly Hand _hand;
    private readonly List<string> _pages = [];
    private readonly BookSignScreen _signScreen;
    private int _currentPage;
    private PageButton? _forwardButton;
    private PageButton? _backButton;
    private MultiLineEditBox? _page;
    private bool _dragging;

    public BookEditScreen(MinecraftClient client, ItemStack book, Hand hand, WritableBookContentComponent.Data content) {
        _client = client;
        _book = book;
        _hand = hand;
        _pages.AddRange(content.Contents.Select(page => page.Raw));
        if (_pages.Count == 0) {
            _pages.Add("");
        }
        _signScreen = new BookSignScreen(this, client, hand, _pages);
    }

    public override bool ShowsHud => false;

    private int NumPages => _pages.Count;

    protected override void Init(GuiContext context, int width, int height) {
        int left = Book.BackgroundLeft(width), top = Book.BackgroundTop;
        const int padding = 8;
        _page = new MultiLineEditBox(context.Text, (width - TextWidth) / 2 - padding, 28, 122, 134);
        _page.TextField.CharacterLimit = MaxPageCharacters;
        _page.TextField.LineLimit = TextHeight / 9;
        _page.TextField.ValueListener = value => _pages[_currentPage] = value;
        UpdatePageContent();
        _backButton = new PageButton(left + PageBackButtonX, top + PageButtonY, false, PageBack, true);
        _forwardButton = new PageButton(left + PageForwardButtonX, top + PageButtonY, true, PageForward, true);
        Add(_backButton);
        Add(_forwardButton);
        Add(new Button(Book.Tr("book.signButton"), width / 2 - MenuButtonSize - 2, Book.MenuControlsTop, MenuButtonSize, () => context.Open?.Invoke(_signScreen)));
        Add(new Button(Book.Tr("gui.done"), width / 2 + 2, Book.MenuControlsTop, MenuButtonSize, () => {
            context.Open?.Invoke(null);
            SaveChanges();
        }));
        UpdateButtonVisibility();
    }

    private void PageBack() {
        if (_currentPage > 0) {
            _currentPage--;
            UpdatePageContent();
        }
        UpdateButtonVisibility();
    }

    private void PageForward() {
        if (_currentPage < NumPages - 1) {
            _currentPage++;
        }
        else {
            AppendPageToBook();
            if (_currentPage < NumPages - 1) {
                _currentPage++;
            }
        }
        UpdatePageContent();
        UpdateButtonVisibility();
    }

    private void UpdatePageContent() => _page?.TextField.SetValue(_pages[_currentPage], true);

    private void UpdateButtonVisibility() {
        if (_backButton != null) {
            _backButton.Visible = _currentPage > 0;
        }
    }

    private void EraseEmptyTrailingPages() {
        while (_pages.Count > 0 && _pages[^1].Length == 0) {
            _pages.RemoveAt(_pages.Count - 1);
        }
    }

    private void SaveChanges() {
        EraseEmptyTrailingPages();
        int slot = UpdateLocalCopy();
        _client.EditBook(slot, _pages, null);
    }

    /// <summary><c>updateLocalCopy</c>: the held stack takes the pages until the server's copy arrives.</summary>
    private int UpdateLocalCopy() {
        int slot = _hand == Hand.MainHand ? _client.Inventory.SelectedSlot : 40;
        WritableBookContentComponent.Data content = new(_pages.Select(page => new WritableBookContentComponent.BookContent(page)).ToArray());
        _client.Inventory.SetInventorySlot(slot, _book.With(DataComponent.WritableBookContent, content));
        return slot;
    }

    private void AppendPageToBook() {
        if (NumPages < MaxPages) {
            _pages.Add("");
        }
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        switch (key) {
            case Key.PageUp:
                _backButton?.Press();
                return;
            case Key.PageDown:
                _forwardButton?.Press();
                return;
            case Key.Escape:
                base.KeyDown(context, key, control);
                return;
        }
        _page?.KeyPressed(context, key, control, ContainerScreen.ShiftHeld());
    }

    public override void Char(GuiContext context, char c) {
        LayOut(context);
        _page?.CharTyped(c);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (ClickWidgets(context, x, y, button)) {
            return;
        }
        if (button == MouseButton.Left && _page != null && _page.IsMouseOver(x, y)) {
            _page.OnClick(x, y, ContainerScreen.ShiftHeld());
            _dragging = true;
        }
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        base.MouseMove(context, x, y);
        if (_dragging) {
            _page?.OnDrag(x, y, ContainerScreen.ShiftHeld());
        }
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        base.MouseUp(context, x, y, button);
        if (button == MouseButton.Left) {
            _dragging = false;
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        int left = Book.BackgroundLeft(context.Width), top = Book.BackgroundTop;
        Book.DrawBackground(context, left, top);
        _page?.Render(context);
        RenderWidgets(context);
        Book.DrawPageIndicator(context, _currentPage, NumPages, left + PageIndicatorXOffset, top + PageIndicatorTextYOffset);
    }
}

/// <summary><c>BookSignScreen</c>: the title for a book about to be signed, and the warning that it cannot be edited after.</summary>
public sealed class BookSignScreen(BookEditScreen bookEditScreen, MinecraftClient client, Hand hand, List<string> pages) : Screen {
    private EditBox? _titleBox;
    private Button? _finalizeButton;
    private string _titleValue = "";

    public override bool ShowsHud => false;

    protected override void Init(GuiContext context, int width, int height) {
        Button finalizeButton = new(Book.Tr("book.finalizeButton"), width / 2 - 100, 196, 98, () => {
            SaveChanges();
            context.Open?.Invoke(null);
        }) {
            Active = false
        };
        _finalizeButton = finalizeButton;
        EditBox titleBox = new(context.Text, (width - 114) / 2 - 3, 50, 114, 20) {
            MaxLength = 15,
            Bordered = false,
            Centered = true,
            TextColor = Book.Black,
            TextShadow = false
        };
        titleBox.SetResponder(value => finalizeButton.Active = !string.IsNullOrWhiteSpace(value));
        titleBox.Value = _titleValue;
        titleBox.Focused = true;
        _titleBox = titleBox;
        Add(finalizeButton);
        Add(new Button(Book.Tr("gui.cancel"), width / 2 + 2, 196, 98, () => {
            _titleValue = titleBox.Value;
            context.Open?.Invoke(bookEditScreen);
        }));
    }

    private void SaveChanges() {
        int slot = hand == Hand.MainHand ? client.Inventory.SelectedSlot : 40;
        client.EditBook(slot, pages, _titleBox?.Value.Trim() ?? "");
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (_titleBox is { Focused: true } titleBox && titleBox.Value.Length > 0 && key is Key.Enter or Key.KeypadEnter) {
            SaveChanges();
            context.Open?.Invoke(null);
            return;
        }
        if (_titleBox?.KeyPressed(context, key, control, ContainerScreen.ShiftHeld()) == true) {
            return;
        }
        base.KeyDown(context, key, control);
    }

    public override void Char(GuiContext context, char c) {
        LayOut(context);
        _titleBox?.CharTyped(c);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (ClickWidgets(context, x, y, button)) {
            return;
        }
        if (button == MouseButton.Left && _titleBox != null && _titleBox.IsMouseOver(x, y)) {
            _titleBox.OnClick(x, ContainerScreen.ShiftHeld());
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        int xo = Book.BackgroundLeft(context.Width);
        Book.DrawBackground(context, xo, Book.BackgroundTop);
        RenderWidgets(context);
        _titleBox?.Render(context);
        string editTitleLabel = Book.Tr("book.editTitle");
        context.Text.Draw(editTitleLabel, xo + 36 + (114 - context.Text.Width(editTitleLabel)) / 2, 34, Book.Black, false);
        List<TextRun> ownerText = TextFlattener.Flatten(TextComponent.Translatable("book.byAuthor", null, [TextComponent.Text(client.Profile.Username)])
            .WithColor(TextColor.DarkGray));
        context.Text.Draw(ownerText, xo + 36 + (114 - context.Text.Width(ownerText)) / 2, 60, shadow: false);
        float y = 82;
        foreach (List<TextRun> line in context.Text.Wrap(TextFlattener.Formatted(Book.Tr("book.finalizeWarning"), 0x000000), 114)) {
            context.Text.Draw(line, xo + 36, y, shadow: false);
            y += 9;
        }
    }
}
