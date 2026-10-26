using System.Diagnostics;
using System.Numerics;
using ClientLib;
using ClientLib.Player;
using ClientLib.Recipes;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;
using Minecraft.Text;
using Silk.NET.Input;
using Slot = ClientLib.Inventory.Slot;

namespace GraphicalClient.Gui.Inventory;

/// <summary>
/// <c>AbstractRecipeBookScreen</c>: a container screen with the recipe book beside it, or over it when the GUI is
/// too narrow for both. The book takes clicks and keys before the container does, and a click on it is not a click
/// outside the container.
/// </summary>
public abstract class RecipeBookScreen : ContainerScreen {
    private const int ToggleWidth = 20, ToggleHeight = 18;

    private readonly RecipeBookComponent _book;
    private readonly RecipeBookWidget _widget;
    private bool _widthTooNarrow;
    private int _width, _height;
    private readonly Action _recipesUpdated;
    private readonly Action<RecipeDisplay> _ghostPlaced;

    protected RecipeBookScreen(MinecraftClient client, ContainerMenu menu) : base(client, menu) {
        _book = RecipeBookComponent.For(client, menu) ?? throw new ArgumentException($"{menu.GetType().Name} has no recipe book", nameof(menu));
        _widget = new RecipeBookWidget(_book);
        _recipesUpdated = _book.RecipesUpdated;
        _ghostPlaced = _book.FillGhostRecipe;
        client.RecipesUpdated += _recipesUpdated;
        client.GhostRecipePlaced += _ghostPlaced;
    }

    /// <summary><c>getRecipeBookButtonPosition</c>, from the container's left edge and the screen's height.</summary>
    protected abstract (float X, float Y) RecipeBookButtonPosition(int height);

    /// <summary><c>isBiggerResultSlot</c>: whether a ghost result is drawn over the 24 pixel frame of a big result slot.</summary>
    protected virtual bool IsBiggerResultSlot => true;

    protected virtual void OnRecipeBookButtonClick() {
    }

    protected override void Init(GuiContext context, int width, int height) {
        base.Init(context, width, height);
        _width = width;
        _height = height;
        _widthTooNarrow = width < 379;
        _widget.Attach(context);
        _book.Init(width, height, _widthTooNarrow);
        Left = _book.UpdateScreenPosition(width, ImageWidth);
    }

    public override void Removed(GuiContext context) {
        Client.RecipesUpdated -= _recipesUpdated;
        Client.GhostRecipePlaced -= _ghostPlaced;
        base.Removed(context);
    }

    /// <summary><c>containerTick</c>. A book the server opened or shut moves the container with it.</summary>
    public override void Tick(GuiContext context) {
        LayOut(context);
        bool wasVisible = _book.Visible;
        _book.Tick();
        if (_book.Visible != wasVisible) {
            Left = _book.UpdateScreenPosition(_width, ImageWidth);
        }
    }

    private bool Covered => _widthTooNarrow && _book.Visible;

    protected override bool DrawsContents => !Covered;

    protected override bool SlotsHoverable => !Covered;

    private (float X, float Y) ToggleButton => RecipeBookButtonPosition(_height);

    protected override void DrawOverlay(GuiContext context) {
        if (!Covered) {
            DrawGhostSlots(context);
            (float x, float y) = ToggleButton;
            bool hovered = Inside(MouseX, MouseY, x, y, ToggleWidth, ToggleHeight);
            if (!context.Sprites.Sprite(context.Gui, hovered ? "recipe_book/button_highlighted" : "recipe_book/button", x, y, ToggleWidth, ToggleHeight)) {
                RecipeBookWidget.DrawToggleFallback(context, x, y, hovered);
            }
        }
        _widget.Render(context, MouseX, MouseY);
    }

    /// <summary><c>GhostSlots.extractRenderState</c>: a red wash, the item, then a white wash over it.</summary>
    private void DrawGhostSlots(GuiContext context) {
        int index = _book.CurrentIndex;
        foreach ((Slot slot, RecipeBookComponent.GhostSlot ghost) in _book.GhostSlots) {
            float x = Left + slot.X, y = Top + slot.Y;
            if (ghost.IsResult && IsBiggerResultSlot) {
                context.Gui.Rect(x - 4, y - 4, 24, 24, 0x30FF0000);
            }
            else {
                context.Gui.Rect(x, y, 16, 16, 0x30FF0000);
            }
            ItemStack item = ghost.Item(index);
            GuiItems.Icon(context, item, x, y);
            context.Gui.Rect(x, y, 16, 16, 0x30FFFFFF);
            if (ghost.IsResult && item.Count > 1) {
                string count = item.Count.ToString();
                context.Text.Draw(count, x + 17 - context.Text.Width(count), y + 9);
            }
        }
    }

    protected override void DrawHoverTooltip(GuiContext context) {
        if (_widget.DrawTooltip(context, MouseX, MouseY)) {
            return;
        }
        if (_book.Visible && HoveredSlotNow is { } slot && _book.GhostSlots.TryGetValue(slot, out RecipeBookComponent.GhostSlot? ghost)) {
            ItemStack item = ghost.Item(_book.CurrentIndex);
            if (item.Count > 0) {
                Tooltips.Draw(context, Tooltips.Lines(item), MouseX, MouseY);
            }
        }
    }

    /// <summary>
    /// <c>mouseClicked</c>: the book first; a book covering the container takes every click; then the toggle
    /// button, which moves the container as it opens or closes the book.
    /// </summary>
    protected override bool WidgetClicked(GuiContext context, float x, float y, MouseButton button) {
        if (_widget.MouseClicked(x, y, button)) {
            return true;
        }
        if (Covered) {
            return true;
        }
        (float bx, float by) = ToggleButton;
        if (button == MouseButton.Left && Inside(x, y, bx, by, ToggleWidth, ToggleHeight)) {
            PlayDownSound(context);
            _book.ToggleVisibility();
            Left = _book.UpdateScreenPosition(_width, ImageWidth);
            OnRecipeBookButtonClick();
            return true;
        }
        return base.WidgetClicked(context, x, y, button);
    }

    protected override bool ClickedOutside(float x, float y) =>
        _book.HasClickedOutside(x, y, (int)Left, (int)Top, ImageWidth, ImageHeight) && base.ClickedOutside(x, y);

    protected override void OnSlotClicked(Slot? slot) => _book.SlotClicked(slot);

    public override bool HasFocusedEditBox => _widget.SearchFocused;

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (!_widget.KeyPressed(context, key, control)) {
            base.KeyDown(context, key, control);
        }
    }

    public override void KeyUp(GuiContext context, Key key) {
        _widget.KeyReleased();
        base.KeyUp(context, key);
    }

    public override void Char(GuiContext context, char c) => _widget.CharTyped(c);
}

/// <summary>
/// Draws a <see cref="RecipeBookComponent"/> and owns its search box. Art comes from the pack's
/// <c>recipe_book</c> sprites and texture, with this client's own drawn in where a pack has none.
/// </summary>
public sealed class RecipeBookWidget(RecipeBookComponent book) {
    private const uint Hint = 0xAAAAAA;

    private readonly Stopwatch _clock = Stopwatch.StartNew();
    private double _lastFrameMs;
    private EditBox? _search;
    private bool _ignoreTextInput;
    private GuiContext? _context;
    private (int Page, int Total, int Language, List<TextRun> Runs)? _pageText;

    public bool SearchFocused => book.TakesInput && _search is { Focused: true, Visible: true };

    /// <summary>Hooks the book to this context's sounds and fonts; the search box is made anew whenever the book lays out.</summary>
    public void Attach(GuiContext context) {
        _context = context;
        book.PlayClickSound = () => Screen.PlayDownSound(context);
        book.VisualsInitialized -= RecreateSearchBox;
        book.VisualsInitialized += RecreateSearchBox;
    }

    /// <summary><c>initVisuals</c>' new edit box: the old one's text, unfocused.</summary>
    private void RecreateSearchBox() {
        if (_context == null) {
            return;
        }
        string old = _search?.Value ?? "";
        (int x, int y, int w, int h) = book.SearchBox;
        _search = new EditBox(_context.Text, x, y, w, h) {
            MaxLength = 50,
            TextColor = 0xFFFFFFFF,
            Hint = [new TextRun(Menus.T("gui.recipebook.search_hint"), (int)Hint, Italic: true)]
        };
        _search.Value = old;
        _search.SetResponder(text => book.SearchText = text);
        book.SearchText = old;
    }

    public void Render(GuiContext context, float mouseX, float mouseY) {
        double now = _clock.Elapsed.TotalMilliseconds;
        float ticks = (float)((now - _lastFrameMs) / 50.0);
        _lastFrameMs = now;
        book.AdvanceTime(ticks, ContainerScreen.ControlHeld());
        if (!book.Visible) {
            return;
        }
        int xo = book.XOrigin, yo = book.YOrigin;
        if (!context.Sprites.Region(context.Gui, "gui/recipe_book", xo, yo, 1, 1, RecipeBookComponent.ImageWidth, RecipeBookComponent.ImageHeight)) {
            DrawBackgroundFallback(context, xo, yo);
        }
        _search?.Render(context);
        // Each sprite is its own texture and every change of texture is a draw call, so what shares one is drawn
        // together: the frames first, then every icon off the item atlas.
        foreach (RecipeBookComponent.TabButton tab in book.Tabs) {
            if (tab.Visible) {
                DrawTab(context, tab, false);
            }
        }
        foreach (RecipeBookComponent.TabButton tab in book.Tabs) {
            if (tab.Visible) {
                DrawTab(context, tab, true);
            }
        }
        DrawFilterButton(context, mouseX, mouseY);
        DrawPage(context, xo, yo, mouseX, mouseY);
        DrawOverlay(context, mouseX, mouseY);
    }

    private static void DrawTab(GuiContext context, RecipeBookComponent.TabButton tab, bool icons) {
        // The squeeze scales the tab up and down about a point on it, as RecipeBookTabButton's pose does.
        Matrix3x2 previous = context.Gui.Pose;
        if (tab.AnimationTime > 0) {
            float squeeze = 1.0F + 0.1F * MathF.Sin(tab.AnimationTime / 15.0F * MathF.PI);
            context.Gui.Pose = Scale(tab.X + 8, tab.Y + 12, 1.0F, squeeze) * previous;
        }
        int moveLeft = tab.Selected ? -2 : 0;
        if (!icons) {
            int x = tab.X + moveLeft;
            if (!context.Sprites.Sprite(context.Gui, tab.Selected ? "recipe_book/tab_selected" : "recipe_book/tab", x, tab.Y,
                    RecipeBookComponent.TabWidth, RecipeBookComponent.TabHeight)) {
                Panel.Draw(context, x, tab.Y, RecipeBookComponent.TabWidth, RecipeBookComponent.TabHeight);
                if (!tab.Selected) {
                    context.Gui.Rect(x + 1, tab.Y + 1, RecipeBookComponent.TabWidth - 2, RecipeBookComponent.TabHeight - 2, 0x40000000);
                }
            }
        }
        else if (tab.Info.SecondaryIcon is { } secondary) {
            GuiItems.Icon(context, new ItemStack(tab.Info.PrimaryIcon), tab.X + 3 + moveLeft, tab.Y + 5);
            GuiItems.Icon(context, new ItemStack(secondary), tab.X + 14 + moveLeft, tab.Y + 5);
        }
        else {
            GuiItems.Icon(context, new ItemStack(tab.Info.PrimaryIcon), tab.X + 9 + moveLeft, tab.Y + 5);
        }
        context.Gui.Pose = previous;
    }

    private void DrawFilterButton(GuiContext context, float mouseX, float mouseY) {
        (int x, int y, int w, int h) = book.FilterButton;
        bool filtering = book.IsFiltering;
        bool hovered = Screen.Inside(mouseX, mouseY, x, y, w, h);
        string prefix = book.IsFurnaceMenu ? "recipe_book/furnace_filter_" : "recipe_book/filter_";
        string sprite = prefix + (filtering ? "enabled" : "disabled") + (hovered ? "_highlighted" : "");
        if (context.Sprites.Sprite(context.Gui, sprite, x, y, w, h)) {
            return;
        }
        context.Gui.Rect(x, y, w, h, 0xFF000000);
        context.Gui.Rect(x + 1, y + 1, w - 2, h - 2, hovered ? 0xFFB8B8B8 : 0xFF8B8B8B);
        // Our own mark for the filter: a funnel, filled while it filters.
        uint mark = filtering ? 0xFF40C040 : 0xFF404040;
        context.Gui.Rect(x + 7, y + 4, 12, 2, mark);
        context.Gui.Rect(x + 9, y + 6, 8, 2, mark);
        context.Gui.Rect(x + 11, y + 8, 4, 4, mark);
    }

    private void DrawPage(GuiContext context, int xo, int yo, float mouseX, float mouseY) {
        if (book.TotalPages > 1) {
            if (_pageText is not { } pages || pages.Page != book.CurrentPage || pages.Total != book.TotalPages || pages.Language != Translations.Generation) {
                _pageText = pages = (book.CurrentPage, book.TotalPages, Translations.Generation, Menus.Runs(TextComponent.Translatable("gui.recipebook.page", null,
                    [TextComponent.Text((book.CurrentPage + 1).ToString()), TextComponent.Text(book.TotalPages.ToString())])));
            }
            int width = context.Text.Width(pages.Runs);
            context.Text.Draw(pages.Runs, xo - width / 2 + 73, yo + 141);
        }
        int index = book.CurrentIndex;
        foreach (string sprite in SlotSprites) {
            foreach (RecipeBookComponent.RecipeButton button in book.Buttons) {
                if (button.Visible && SlotSprite(button) == sprite) {
                    DrawRecipeButton(context, button, index, false);
                }
            }
        }
        foreach (RecipeBookComponent.RecipeButton button in book.Buttons) {
            if (button.Visible) {
                DrawRecipeButton(context, button, index, true);
            }
        }
        DrawPageArrow(context, book.ForwardButton, book.ForwardVisible, "recipe_book/page_forward", true, mouseX, mouseY);
        DrawPageArrow(context, book.BackButton, book.BackVisible, "recipe_book/page_backward", false, mouseX, mouseY);
    }

    private static void DrawPageArrow(GuiContext context, (int X, int Y, int W, int H) rect, bool visible, string sprite, bool forward, float mouseX, float mouseY) {
        if (!visible) {
            return;
        }
        bool hovered = Screen.Inside(mouseX, mouseY, rect.X, rect.Y, rect.W, rect.H);
        if (context.Sprites.Sprite(context.Gui, hovered ? sprite + "_highlighted" : sprite, rect.X, rect.Y, rect.W, rect.H)) {
            return;
        }
        uint colour = hovered ? 0xFFFFFFFF : 0xFFC6C6C6;
        // A stepped arrowhead, five columns deep, pointing the way the page turns.
        for (int column = 0; column < 5; column++) {
            int reach = forward ? column : 4 - column;
            float half = 7 - reach * 1.5F;
            context.Gui.Rect(rect.X + 3 + column, rect.Y + 8.5F - half, 1, half * 2, colour);
        }
    }

    private static readonly string[] SlotSprites = [
        "recipe_book/slot_craftable", "recipe_book/slot_uncraftable", "recipe_book/slot_many_craftable", "recipe_book/slot_many_uncraftable"
    ];

    private static string SlotSprite(RecipeBookComponent.RecipeButton button) =>
        SlotSprites[(button.Collection.HasCraftable ? 0 : 1) + (button.HasMultipleRecipes ? 2 : 0)];

    private static void DrawRecipeButton(GuiContext context, RecipeBookComponent.RecipeButton button, int index, bool icons) {
        Matrix3x2 previous = context.Gui.Pose;
        if (button.AnimationTime > 0) {
            float squeeze = 1.0F + 0.1F * MathF.Sin(button.AnimationTime / 15.0F * MathF.PI);
            context.Gui.Pose = Scale(button.X + 8, button.Y + 12, squeeze, squeeze) * previous;
        }
        if (!icons) {
            if (!context.Sprites.Sprite(context.Gui, SlotSprite(button), button.X, button.Y, RecipeBookComponent.ButtonSize, RecipeBookComponent.ButtonSize)) {
                DrawSlotFallback(context, button.X, button.Y, button.Collection.HasCraftable, button.HasMultipleRecipes);
            }
        }
        else {
            ItemStack stack = button.DisplayStack(index);
            int offset = 4;
            if (button.HasMultipleRecipes && button.AllRecipesHaveSameResultDisplay) {
                GuiItems.Icon(context, stack, button.X + offset + 1, button.Y + offset + 1);
                offset--;
            }
            GuiItems.Icon(context, stack, button.X + offset, button.Y + offset);
        }
        context.Gui.Pose = previous;
    }

    private void DrawOverlay(GuiContext context, float mouseX, float mouseY) {
        RecipeBookComponent.Overlay overlay = book.RecipeOverlay;
        if (!overlay.IsVisible) {
            return;
        }
        int count = overlay.Buttons.Count;
        int maxRow = count <= 16 ? 4 : 5;
        int width = Math.Min(count, maxRow), height = (int)MathF.Ceiling((float)count / maxRow);
        float w = width * 25 + 8, h = height * 25 + 8;
        if (!context.Sprites.NineSliced(context.Gui, "recipe_book/overlay_recipe", overlay.X, overlay.Y, w, h, 4)) {
            Panel.Draw(context, overlay.X, overlay.Y, w, h);
        }
        int index = book.CurrentIndex;
        string kind = book.IsFurnaceMenu ? "recipe_book/furnace_overlay" : "recipe_book/crafting_overlay";
        foreach (RecipeBookComponent.OverlayButton button in overlay.Buttons) {
            bool hovered = Screen.Inside(mouseX, mouseY, button.X, button.Y, 24, 24);
            string sprite = kind + (button.IsCraftable ? "" : "_disabled") + (hovered ? "_highlighted" : "");
            if (!context.Sprites.Sprite(context.Gui, sprite, button.X, button.Y, 24, 24)) {
                context.Gui.Rect(button.X, button.Y, 24, 24, 0xFF373737);
                context.Gui.Rect(button.X + 1, button.Y + 1, 22, 22,
                    button.IsCraftable ? hovered ? 0xFFB8B8B8 : 0xFF8B8B8B : hovered ? 0xFFB07070 : 0xFF8B5050);
            }
        }
        foreach (RecipeBookComponent.OverlayButton button in overlay.Buttons) {
            Matrix3x2 previous = context.Gui.Pose;
            foreach (RecipeBookComponent.OverlayButton.Pos pos in button.Slots) {
                // Three eighths size, centred on the ingredient's grid point.
                context.Gui.Pose = Scale(0, 0, 0.375F, 0.375F) * Matrix3x2.CreateTranslation(button.X + 2 + pos.X, button.Y + 2 + pos.Y) * previous;
                GuiItems.Icon(context, pos.Select(index), -8, -8);
            }
            context.Gui.Pose = previous;
        }
    }

    /// <summary>The tooltip for whatever of the book is under the cursor, true when there was one.</summary>
    public bool DrawTooltip(GuiContext context, float mouseX, float mouseY) {
        if (!book.Visible) {
            return false;
        }
        if (book.HoveredButton(mouseX, mouseY) is { } button) {
            ItemStack stack = button.DisplayStack(book.CurrentIndex);
            List<List<TextRun>> lines = Tooltips.Lines(stack);
            if (button.HasMultipleRecipes) {
                lines.Add([new TextRun(Menus.T("gui.recipebook.moreRecipes"), 0xFFFFFF)]);
            }
            Tooltips.Draw(context, lines, mouseX, mouseY);
            return true;
        }
        if (book.RecipeOverlay.IsVisible) {
            return false;
        }
        (int x, int y, int w, int h) = book.FilterButton;
        if (Screen.Inside(mouseX, mouseY, x, y, w, h)) {
            string key = book.IsFiltering ? book.FilterNameKey : "gui.recipebook.toggleRecipes.all";
            Tooltips.Draw(context, [[new TextRun(Menus.T(key), 0xFFFFFF)]], mouseX, mouseY);
            return true;
        }
        if (book.ForwardVisible && Screen.Inside(mouseX, mouseY, book.ForwardButton.X, book.ForwardButton.Y, book.ForwardButton.W, book.ForwardButton.H)) {
            Tooltips.Draw(context, [[new TextRun(Menus.T("gui.recipebook.next_page"), 0xFFFFFF)]], mouseX, mouseY);
            return true;
        }
        if (book.BackVisible && Screen.Inside(mouseX, mouseY, book.BackButton.X, book.BackButton.Y, book.BackButton.W, book.BackButton.H)) {
            Tooltips.Draw(context, [[new TextRun(Menus.T("gui.recipebook.previous_page"), 0xFFFFFF)]], mouseX, mouseY);
            return true;
        }
        return false;
    }

    public bool MouseClicked(float x, float y, MouseButton mouseButton) {
        int button = mouseButton switch {
            MouseButton.Left => 0,
            MouseButton.Right => 1,
            MouseButton.Middle => 2,
            _ => (int)mouseButton
        };
        bool taken = book.MouseClicked(x, y, button, ContainerScreen.ShiftHeld(), out bool? searchFocus);
        if (_search != null && searchFocus is { } focus) {
            _search.Focused = focus;
            if (focus && button == 0 && _search.IsMouseOver(x, y)) {
                _search.OnClick(x, ContainerScreen.ShiftHeld());
            }
        }
        return taken;
    }

    /// <summary>
    /// <c>keyPressed</c>. A focused search box takes every key but Escape, so typing never reaches the key mappings;
    /// the chat key focuses it, and Enter or Space places the last recipe again.
    /// </summary>
    public bool KeyPressed(GuiContext context, Key key, bool control) {
        _ignoreTextInput = false;
        if (!book.TakesInput || _search == null) {
            return false;
        }
        if (key == Key.Escape && book.CloseOnEscape()) {
            return true;
        }
        if (_search.KeyPressed(context, key, control, ContainerScreen.ShiftHeld())) {
            book.CheckSearchStringUpdate();
            return true;
        }
        if (_search.Focused && _search.Visible && key != Key.Escape) {
            return true;
        }
        if (context.Settings!.Keys.Chat.Matches(key) && !_search.Focused) {
            _ignoreTextInput = true;
            _search.Focused = true;
            return true;
        }
        if (key is Key.Enter or Key.Space or Key.KeypadEnter) {
            return book.PlaceLastRecipe(ContainerScreen.ShiftHeld());
        }
        return false;
    }

    public void KeyReleased() => _ignoreTextInput = false;

    public void CharTyped(char c) {
        if (_ignoreTextInput || !book.TakesInput || _search == null) {
            return;
        }
        if (_search.CharTyped(c)) {
            book.CheckSearchStringUpdate();
        }
    }

    private static Matrix3x2 Scale(float cx, float cy, float sx, float sy) =>
        Matrix3x2.CreateTranslation(-cx, -cy) * Matrix3x2.CreateScale(sx, sy) * Matrix3x2.CreateTranslation(cx, cy);

    /// <summary>The book's page without the pack's texture: a panel with an inset well behind the recipe grid.</summary>
    private static void DrawBackgroundFallback(GuiContext context, int xo, int yo) {
        Panel.Draw(context, xo, yo, RecipeBookComponent.ImageWidth, RecipeBookComponent.ImageHeight);
        context.Gui.Rect(xo + 9, yo + 29, 129, 104, 0xFF373737);
        context.Gui.Rect(xo + 10, yo + 30, 128, 103, Panel.Light);
        context.Gui.Rect(xo + 10, yo + 30, 127, 102, 0xFF8B8B8B);
    }

    private static void DrawSlotFallback(GuiContext context, float x, float y, bool craftable, bool many) {
        uint face = craftable ? 0xFFC6C6C6 : 0xFFC67070;
        if (many) {
            context.Gui.Rect(x + 3, y + 3, 22, 22, 0xFF373737);
        }
        context.Gui.Rect(x, y, many ? 22 : 25, many ? 22 : 25, 0xFF373737);
        context.Gui.Rect(x + 1, y + 1, many ? 20 : 23, many ? 20 : 23, face);
    }

    /// <summary>The toggle without the pack's sprite: a closed green book.</summary>
    public static void DrawToggleFallback(GuiContext context, float x, float y, bool hovered) {
        context.Gui.Rect(x, y, 20, 18, 0xFF000000);
        context.Gui.Rect(x + 1, y + 1, 18, 16, hovered ? 0xFF6FBF5A : 0xFF4E8A3E);
        context.Gui.Rect(x + 4, y + 3, 12, 12, 0xFFEFE6C8);
        context.Gui.Rect(x + 4, y + 3, 2, 12, hovered ? 0xFF6FBF5A : 0xFF4E8A3E);
    }
}
