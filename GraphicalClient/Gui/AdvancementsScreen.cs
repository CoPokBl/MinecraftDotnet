using ClientLib;
using ClientLib.Advancements;
using GraphicalClient.Gui.Inventory;
using Minecraft.Schemas;
using Minecraft.Schemas.Advancements;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>AdvancementsScreen</c>: a 252 by 140 window round a 234 by 113 view of one tab's tree, which drags and
/// scrolls, with the tabs round the window's edges when there is more than one. Opening it tells the server
/// which tab is shown and closing it tells it the screen is gone, as vanilla does both.
/// </summary>
public sealed class AdvancementsScreen : Screen, IClientAdvancementsListener {
    private const int WindowWidth = 252, WindowHeight = 140;
    private const int InsideX = 9, InsideY = 18, InsideWidth = 234, InsideHeight = 113;
    private const int TitleX = 8, TitleY = 6;
    private const double ScrollSpeed = 16.0;

    private readonly ClientAdvancements _advancements;
    private readonly Screen? _lastScreen;
    private readonly OrderedDictionary<Identifier, AdvancementTab> _tabs = new();
    private AdvancementTab? _selectedTab;
    private bool _leftDown;
    private bool _isScrolling;
    private float _lastDragX, _lastDragY;
    private int _width;

    /// <summary>
    /// <c>init</c>'s first run, done here so the tab is chosen and the server told when the screen is opened,
    /// in the tick the key was pressed in, rather than when it is first drawn.
    /// </summary>
    public AdvancementsScreen(GuiContext context, ClientAdvancements advancements, Screen? lastScreen = null) {
        _advancements = advancements;
        _lastScreen = lastScreen;
        _width = context.Width;
        advancements.SetListener(this);
        if (_selectedTab == null && _tabs.Count > 0) {
            advancements.SetSelectedTab(_tabs.GetAt(0).Value.RootNode, true);
        }
        else {
            advancements.SetSelectedTab(_selectedTab?.RootNode, true);
        }
    }

    protected override string NarrationTitle => Menus.T("gui.advancements");

    private int LeftPos => (_width - WindowWidth) / 2;

    protected override void Init(GuiContext context, int width, int height) {
        _width = width;
        Add(new Button(Menus.T("gui.done"), width / 2.0F - 100, height - 27, 200, () => Close(context)));
    }

    /// <summary><c>onClose</c>: back to the screen it was opened from, the pause menu or none.</summary>
    public override void Close(GuiContext context) => context.Open?.Invoke(_lastScreen);

    public override void Removed(GuiContext context) {
        _advancements.SetListener(null);
        _advancements.ScreenClosed();
    }

    public override void Tick(GuiContext context) {
        _width = context.Width;
        int top = (context.Height - WindowHeight) / 2;
        _selectedTab?.Tick((int)context.MouseX - LeftPos - InsideX, (int)context.MouseY - top - InsideY);
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (context.Settings?.Keys.Advancements.Matches(key) == true) {
            context.Open?.Invoke(null);
            return;
        }
        base.KeyDown(context, key, control);
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        if (button == MouseButton.Left) {
            _leftDown = true;
            _lastDragX = x;
            _lastDragY = y;
            int xo = (context.Width - WindowWidth) / 2, yo = (context.Height - WindowHeight) / 2;
            foreach (AdvancementTab tab in _tabs.Values) {
                if (tab.IsMouseOver(xo, yo, x, y)) {
                    _advancements.SetSelectedTab(tab.RootNode, true);
                    break;
                }
            }
        }
        base.MouseDown(context, x, y, button);
    }

    /// <summary><c>mouseDragged</c>: the first move with the button down only starts the drag; the ones after move the tree.</summary>
    public override void MouseMove(GuiContext context, float x, float y) {
        base.MouseMove(context, x, y);
        if (!_leftDown) {
            return;
        }
        if (!_isScrolling) {
            _isScrolling = true;
        }
        else {
            _selectedTab?.Scroll(x - _lastDragX, y - _lastDragY);
        }
        _lastDragX = x;
        _lastDragY = y;
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        if (button == MouseButton.Left) {
            _leftDown = false;
            _isScrolling = false;
        }
        base.MouseUp(context, x, y, button);
    }

    public override void Scroll(GuiContext context, float delta) => _selectedTab?.Scroll(0.0, delta * ScrollSpeed);

    public override void Render(GuiContext context, float partialTick) {
        _width = context.Width;
        Menus.Background(context);
        context.Text.DrawCentred(Menus.T("gui.advancements"), context.Width / 2.0F, 12, 0xFFFFFFFF);
        RenderWidgets(context);
        int left = (context.Width - WindowWidth) / 2, top = (context.Height - WindowHeight) / 2;
        RenderInside(context, left, top);
        RenderWindow(context, left, top);
        RenderTooltips(context, left, top);
    }

    private void RenderInside(GuiContext context, int left, int top) {
        if (_selectedTab is not { } tab) {
            context.Gui.Rect(left + InsideX, top + InsideY, InsideWidth, InsideHeight, 0xFF000000);
            float midX = left + InsideX + InsideWidth / 2;
            context.Text.DrawCentred(Menus.T("advancements.empty"), midX, top + InsideY + 56 - 9 / 2);
            context.Text.DrawCentred(Menus.T("advancements.sad_label"), midX, top + InsideY + InsideHeight - 9);
            return;
        }
        tab.RenderContents(context, left + InsideX, top + InsideY);
    }

    private void RenderWindow(GuiContext context, int left, int top) {
        if (!context.Sprites.Stretched(context.Gui, "gui/advancements/window", left, top, WindowWidth, WindowHeight, 0, 0, WindowWidth / 256.0F, WindowHeight / 256.0F)) {
            AdvancementArt.Window(context.Gui, left, top);
        }
        if (_tabs.Count > 1) {
            foreach (AdvancementTab tab in _tabs.Values) {
                tab.RenderTab(context, left, top, tab == _selectedTab);
            }
            foreach (AdvancementTab tab in _tabs.Values) {
                tab.RenderIcon(context, left, top);
            }
        }
        if (_selectedTab != null) {
            context.Text.Draw(_selectedTab.WindowTitle(context.Text), left + TitleX, top + TitleY, 255, false);
        }
        else {
            context.Text.Draw(Menus.T("gui.advancements"), left + TitleX, top + TitleY, 0xFF404040, false);
        }
    }

    private void RenderTooltips(GuiContext context, int left, int top) {
        _selectedTab?.RenderTooltips(context, left, top, left + InsideX, top + InsideY);
        if (_tabs.Count > 1) {
            foreach (AdvancementTab tab in _tabs.Values) {
                if (tab.IsMouseOver(left, top, context.MouseX, context.MouseY)) {
                    Tooltips.Draw(context, [Menus.Runs(tab.Display.Title)], context.MouseX, context.MouseY);
                }
            }
        }
    }

    public void OnAddAdvancementRoot(AdvancementNode root) {
        if (AdvancementTab.Create(this, _tabs.Count, root) is { } tab) {
            _tabs[root.Id] = tab;
        }
    }

    public void OnRemoveAdvancementRoot(AdvancementNode root) {
    }

    public void OnAddAdvancementTask(AdvancementNode task) => TabOf(task)?.AddAdvancement(task);

    public void OnRemoveAdvancementTask(AdvancementNode task) {
    }

    public void OnUpdateAdvancementProgress(AdvancementNode advancement, AdvancementProgress progress) =>
        TabOf(advancement)?.GetWidget(advancement.Id)?.SetProgress(progress);

    public void OnSelectedTabChanged(AdvancementNode? selectedTab) =>
        _selectedTab = selectedTab != null ? _tabs.GetValueOrDefault(selectedTab.Id) : null;

    public void OnAdvancementsCleared() {
        _tabs.Clear();
        _selectedTab = null;
    }

    private AdvancementTab? TabOf(AdvancementNode node) => _tabs.GetValueOrDefault(node.Root.Id);

    /// <summary><c>AdvancementTabType</c>: where a tab sits round the window, in the order tabs fill them.</summary>
    private sealed record TabType(string Side, string First, string Middle, string Last, int Width, int Height, int Max) {
        public static readonly TabType Above = new("above", "left", "middle", "right", 28, 32, 8);
        public static readonly TabType Below = new("below", "left", "middle", "right", 28, 32, 8);
        public static readonly TabType Left = new("left", "top", "middle", "bottom", 32, 28, 5);
        public static readonly TabType Right = new("right", "top", "middle", "bottom", 32, 28, 5);
        public static readonly TabType[] Values = [Above, Below, Left, Right];

        public string Sprite(int index, bool selected) {
            string part = index == 0 ? First : index == Max - 1 ? Last : Middle;
            return $"advancements/tab_{Side}_{part}{(selected ? "_selected" : "")}";
        }

        public int GetX(int index) => this == Left ? -Width + 4 : this == Right ? 248 : (Width + 4) * index;

        public int GetY(int index) => this == Above ? -Height + 4 : this == Below ? 136 : Height * index;

        public (int X, int Y) IconOffset => this == Above ? (6, 9) : this == Below ? (6, 6) : this == Left ? (10, 5) : (6, 5);

        public bool IsMouseOver(int xo, int yo, int index, double mx, double my) {
            int x = xo + GetX(index), y = yo + GetY(index);
            return mx > x && mx < x + Width && my > y && my < y + Height;
        }
    }

    /// <summary><c>AdvancementTab</c>: one root's tree, its scroll, and the darkening that comes up while something is hovered.</summary>
    private sealed class AdvancementTab {
        private readonly AdvancementsScreen _screen;
        private readonly TabType _type;
        private readonly int _index;
        private readonly AdvancementWidget _root;
        private readonly OrderedDictionary<Identifier, AdvancementWidget> _widgets = new();
        private double _scrollX, _scrollY;
        private int _minX = int.MaxValue, _minY = int.MaxValue, _maxX = int.MinValue, _maxY = int.MinValue;
        private float _fade;
        private bool _centered;
        private AdvancementWidget? _hovered;
        private readonly List<AdvancementWidget> _drawOrder = [];

        private AdvancementTab(AdvancementsScreen screen, TabType type, int index, AdvancementNode rootNode, AdvancementDisplay display) {
            _screen = screen;
            _type = type;
            _index = index;
            RootNode = rootNode;
            Display = display;
            _root = new AdvancementWidget(this, rootNode, display);
            AddWidget(_root, rootNode.Id);
        }

        public AdvancementNode RootNode { get; }
        public AdvancementDisplay Display { get; }

        private TextRenderer? _titleFor;
        private List<TextRun> _title = [];

        /// <summary>The title in the window's dark grey, flattened once per font rather than every frame.</summary>
        public List<TextRun> WindowTitle(TextRenderer text) {
            if (_titleFor != text) {
                _titleFor = text;
                _title = Menus.Runs(Display.Title, 0x404040);
            }
            return _title;
        }
        public int ScreenWidth => _screen._width;

        /// <summary><c>create</c>: the first eight above, eight below, five left and five right; any more get no tab.</summary>
        public static AdvancementTab? Create(AdvancementsScreen screen, int index, AdvancementNode root) {
            if (root.Display is not { } display) {
                return null;
            }
            foreach (TabType type in TabType.Values) {
                if (index < type.Max) {
                    return new AdvancementTab(screen, type, index, root, display);
                }
                index -= type.Max;
            }
            return null;
        }

        public void Tick(int relativeMouseX, int relativeMouseY) {
            bool hovering = false;
            if (relativeMouseX > 0 && relativeMouseX < InsideWidth && relativeMouseY > 0 && relativeMouseY < InsideHeight) {
                int scrollX = (int)Math.Floor(_scrollX), scrollY = (int)Math.Floor(_scrollY);
                foreach (AdvancementWidget widget in _widgets.Values) {
                    if (widget.IsMouseOver(scrollX, scrollY, relativeMouseX, relativeMouseY)) {
                        hovering = true;
                        _hovered = widget;
                        break;
                    }
                }
            }
            if (hovering) {
                _fade = Math.Clamp(_fade + 0.06F, 0.0F, 0.3F);
            }
            else {
                _fade = Math.Clamp(_fade - 0.12F, 0.0F, 1.0F);
                _hovered = null;
            }
        }

        public void RenderTab(GuiContext context, int xo, int yo, bool selected) {
            int x = xo + _type.GetX(_index), y = yo + _type.GetY(_index);
            if (!context.Sprites.Sprite(context.Gui, _type.Sprite(_index, selected), x, y, _type.Width, _type.Height)) {
                AdvancementArt.Tab(context.Gui, x, y, _type.Width, _type.Height, selected);
            }
        }

        public void RenderIcon(GuiContext context, int xo, int yo) {
            (int dx, int dy) = _type.IconOffset;
            GuiItems.Icon(context, Display.Icon, xo + _type.GetX(_index) + dx, yo + _type.GetY(_index) + dy);
        }

        public void RenderContents(GuiContext context, int windowLeft, int windowTop) {
            if (!_centered) {
                _scrollX = 117 - (_maxX + _minX) / 2;
                _scrollY = 56 - (_maxY + _minY) / 2;
                _centered = true;
            }
            context.Gui.EnableScissor(windowLeft, windowTop, windowLeft + InsideWidth, windowTop + InsideHeight);
            int scrollX = (int)Math.Floor(_scrollX), scrollY = (int)Math.Floor(_scrollY);
            int left = scrollX % 16, top = scrollY % 16;
            // Vanilla blits 17 by 10 tiles of the 16 pixel background; one repeating quad over the same span draws the same.
            float x0 = windowLeft + left - 16, y0 = windowTop + top - 16;
            bool drawn = Display.Background is { } background
                && context.Sprites.StretchedTexture(context.Gui, background, x0, y0, 17 * 16, 10 * 16, 0, 0, 17, 10);
            if (!drawn) {
                AdvancementArt.Background(context.Gui, windowLeft, windowTop, InsideWidth, InsideHeight, left, top);
            }
            _root.RenderConnectivity(context.Gui, windowLeft + scrollX, windowTop + scrollY, true);
            _root.RenderConnectivity(context.Gui, windowLeft + scrollX, windowTop + scrollY, false);
            // Every frame, then every icon: two texture changes rather than two a widget. Frames never reach
            // into another widget's icon, so the picture is the same as drawing them widget by widget.
            _drawOrder.Clear();
            _root.CollectDrawn(_drawOrder);
            foreach (AdvancementWidget widget in _drawOrder) {
                widget.RenderFrame(context, windowLeft + scrollX, windowTop + scrollY);
            }
            foreach (AdvancementWidget widget in _drawOrder) {
                widget.RenderIcon(context, windowLeft + scrollX, windowTop + scrollY);
            }
            context.Gui.DisableScissor();
        }

        public void RenderTooltips(GuiContext context, int screenXo, int screenYo, int windowLeft, int windowTop) {
            context.Gui.Rect(windowLeft, windowTop, InsideWidth, InsideHeight, (uint)Math.Floor(_fade * 255.0F) << 24);
            if (_hovered != null) {
                int scrollX = (int)Math.Floor(_scrollX), scrollY = (int)Math.Floor(_scrollY);
                _hovered.RenderHover(context, windowLeft, windowTop, scrollX, scrollY, screenXo);
            }
        }

        public bool IsMouseOver(int xo, int yo, double mx, double my) => _type.IsMouseOver(xo, yo, _index, mx, my);

        /// <summary><c>Mth.clamp</c> on each axis that has room to scroll; the far bound is the right or bottom edge's.</summary>
        public void Scroll(double x, double y) {
            if (_maxX - _minX > InsideWidth) {
                _scrollX = Clamp(_scrollX + x, -(_maxX - InsideWidth), 0.0);
            }
            if (_maxY - _minY > InsideHeight) {
                _scrollY = Clamp(_scrollY + y, -(_maxY - InsideHeight), 0.0);
            }
        }

        private static double Clamp(double value, double min, double max) => value < min ? min : Math.Min(value, max);

        public void AddAdvancement(AdvancementNode node) {
            if (node.Display is { } display) {
                AddWidget(new AdvancementWidget(this, node, display), node.Id);
            }
        }

        private void AddWidget(AdvancementWidget widget, Identifier id) {
            _widgets[id] = widget;
            _minX = Math.Min(_minX, widget.X);
            _maxX = Math.Max(_maxX, widget.X + 28);
            _minY = Math.Min(_minY, widget.Y);
            _maxY = Math.Max(_maxY, widget.Y + 27);
            foreach (AdvancementWidget other in _widgets.Values) {
                other.AttachToParent();
            }
        }

        public AdvancementWidget? GetWidget(Identifier id) => _widgets.GetValueOrDefault(id);
    }

    /// <summary><c>AdvancementWidget</c>: one advancement's frame and icon, and the box that opens out of it on hover.</summary>
    private sealed class AdvancementWidget {
        private static readonly int[] TestSplitOffsets = [0, 10, -10, 25, -25];
        private const int TitleMaxWidth = 163, TitleMinWidth = 80;

        private readonly AdvancementTab _tab;
        private readonly AdvancementNode _node;
        private readonly AdvancementDisplay _display;
        private readonly List<AdvancementWidget> _children = [];
        private AdvancementWidget? _parent;
        private AdvancementProgress? _progress;
        private TextRenderer? _measuredWith;
        private List<List<TextRun>> _titleLines = [];
        private List<List<TextRun>> _description = [];
        private int _width;

        public AdvancementWidget(AdvancementTab tab, AdvancementNode node, AdvancementDisplay display) {
            _tab = tab;
            _node = node;
            _display = display;
            X = (int)Math.Floor(display.X * 28.0F);
            Y = (int)Math.Floor(display.Y * 27.0F);
        }

        public int X { get; }
        public int Y { get; }

        private bool Shown => !_display.Hidden || _progress is { IsDone: true };

        public void SetProgress(AdvancementProgress progress) => _progress = progress;

        /// <summary>
        /// The title wrapped at 163, and the description broken to whichever of five widths near the title bar's
        /// own comes within ten pixels of it, in the frame's chat colour where it has none of its own.
        /// </summary>
        private void Measure(TextRenderer text) {
            if (_measuredWith == text) {
                return;
            }
            _measuredWith = text;
            _titleLines = text.Wrap(Menus.Runs(_display.Title), TitleMaxWidth);
            int titleWidth = Math.Max(_titleLines.Select(text.Width).DefaultIfEmpty(0).Max(), TitleMinWidth);
            int longest = 29 + titleWidth + MaxProgressWidth(text);
            int chatColour = _display.Frame == AdvancementFrame.Challenge ? 0xAA00AA : 0x55FF55;
            _description = FindOptimalLines(text, TextFlattener.Decode(Menus.Runs(_display.Description, chatColour)), longest);
            foreach (List<TextRun> line in _description) {
                longest = Math.Max(longest, text.Width(line));
            }
            _width = longest + 3 + 5;
        }

        private int MaxProgressWidth(TextRenderer text) {
            int required = _node.Advancement.Requirements.Length;
            if (required <= 1) {
                return 0;
            }
            TextComponent fake = TextComponent.Translatable("advancements.progress", with: [TextComponent.Text(required.ToString()), TextComponent.Text(required.ToString())]);
            return text.Width(Menus.Runs(fake)) + 8;
        }

        private static List<List<TextRun>> FindOptimalLines(TextRenderer text, IReadOnlyList<TextRun> input, int preferredWidth) {
            List<List<TextRun>>? best = null;
            float bestDistance = float.MaxValue;
            foreach (int margin in TestSplitOffsets) {
                List<List<TextRun>> split = text.Splitter.SplitLines(input, preferredWidth - margin);
                float widest = split.Select(line => text.Splitter.StringWidth(line)).DefaultIfEmpty(0.0F).Max();
                float distance = Math.Abs(widest - preferredWidth);
                if (distance <= 10.0F) {
                    return split;
                }
                if (distance < bestDistance) {
                    bestDistance = distance;
                    best = split;
                }
            }
            return best!;
        }

        /// <summary><c>getFirstVisibleParent</c>: past any ancestor without a display, which has no widget.</summary>
        private AdvancementWidget? FirstVisibleParent() {
            AdvancementNode? node = _node;
            do {
                node = node.Parent;
            } while (node != null && node.Display == null);
            return node != null ? _tab.GetWidget(node.Id) : null;
        }

        public void AttachToParent() {
            if (_parent == null && _node.Parent != null) {
                _parent = FirstVisibleParent();
                _parent?._children.Add(this);
            }
        }

        /// <summary>
        /// <c>extractConnectivity</c>: each child joined to its parent by an elbow, first three pixels wide in black,
        /// then one wide in white over it. The coordinates are the widgets' own plus the scroll and window.
        /// </summary>
        public void RenderConnectivity(Rendering.GuiRenderer gui, int xo, int yo, bool background) {
            if (_parent != null) {
                int depX = xo + _parent.X + 13;
                int splitX = xo + _parent.X + 26 + 4;
                int depY = yo + _parent.Y + 13;
                int myX = xo + X + 13;
                int myY = yo + Y + 13;
                uint colour = background ? 0xFF000000 : 0xFFFFFFFF;
                if (background) {
                    HorizontalLine(gui, splitX, depX, depY - 1, colour);
                    HorizontalLine(gui, splitX + 1, depX, depY, colour);
                    HorizontalLine(gui, splitX, depX, depY + 1, colour);
                    HorizontalLine(gui, myX, splitX - 1, myY - 1, colour);
                    HorizontalLine(gui, myX, splitX - 1, myY, colour);
                    HorizontalLine(gui, myX, splitX - 1, myY + 1, colour);
                    VerticalLine(gui, splitX - 1, myY, depY, colour);
                    VerticalLine(gui, splitX + 1, myY, depY, colour);
                }
                else {
                    HorizontalLine(gui, splitX, depX, depY, colour);
                    HorizontalLine(gui, myX, splitX, myY, colour);
                    VerticalLine(gui, splitX, myY, depY, colour);
                }
            }
            foreach (AdvancementWidget child in _children) {
                child.RenderConnectivity(gui, xo, yo, background);
            }
        }

        /// <summary><c>GuiGraphicsExtractor.horizontalLine</c>: both ends included.</summary>
        private static void HorizontalLine(Rendering.GuiRenderer gui, int x0, int x1, int y, uint argb) {
            if (x1 < x0) {
                (x0, x1) = (x1, x0);
            }
            gui.Rect(x0, y, x1 + 1 - x0, 1, argb);
        }

        /// <summary>
        /// <c>GuiGraphicsExtractor.verticalLine</c>: both ends left out, through <c>fill</c>, which takes its corners in
        /// either order, so ends on the same row still draw that one pixel.
        /// </summary>
        private static void VerticalLine(Rendering.GuiRenderer gui, int x, int y0, int y1, uint argb) {
            if (y1 < y0) {
                (y0, y1) = (y1, y0);
            }
            int a = y0 + 1;
            if (y1 != a) {
                gui.Rect(x, Math.Min(a, y1), 1, Math.Abs(y1 - a), argb);
            }
        }

        /// <summary>The widgets <c>extractRenderState</c> draws, in its order: this one if shown, then each child's.</summary>
        public void CollectDrawn(List<AdvancementWidget> into) {
            if (Shown) {
                into.Add(this);
            }
            foreach (AdvancementWidget child in _children) {
                child.CollectDrawn(into);
            }
        }

        private static string FrameSprite(AdvancementFrame frame, bool obtained) => frame switch {
            AdvancementFrame.Challenge => obtained ? "advancements/challenge_frame_obtained" : "advancements/challenge_frame_unobtained",
            AdvancementFrame.Goal => obtained ? "advancements/goal_frame_obtained" : "advancements/goal_frame_unobtained",
            _ => obtained ? "advancements/task_frame_obtained" : "advancements/task_frame_unobtained"
        };

        private static void Frame(GuiContext context, AdvancementFrame frame, bool obtained, int x, int y) {
            if (!context.Sprites.Sprite(context.Gui, FrameSprite(frame, obtained), x, y, 26, 26)) {
                AdvancementArt.Frame(context.Gui, frame, obtained, x, y);
            }
        }

        public void RenderFrame(GuiContext context, int xo, int yo) {
            float amount = _progress?.Percent ?? 0.0F;
            Frame(context, _display.Frame, amount >= 1.0F, xo + X + 3, yo + Y);
        }

        public void RenderIcon(GuiContext context, int xo, int yo) => GuiItems.Icon(context, _display.Icon, xo + X + 8, yo + Y + 5);

        /// <summary>
        /// <c>extractHover</c>: the title bar, filled from the left as far as the advancement has got, opens to the
        /// right of the frame or, where that would leave the screen, to its left; the description hangs below it
        /// or, where that would leave the tab, above.
        /// </summary>
        public void RenderHover(GuiContext context, int windowLeft, int windowTop, int scrollX, int scrollY, int screenXo) {
            Measure(context.Text);
            TextRenderer text = context.Text;
            int xo = scrollX, yo = scrollY;
            int titleBarHeight = 9 * _titleLines.Count + 9 + 8;
            int titleTop = yo + Y + (26 - titleBarHeight) / 2;
            int titleBarBottom = titleTop + titleBarHeight;
            int descriptionTextHeight = _description.Count * 9;
            int descriptionHeight = 6 + descriptionTextHeight;
            bool leftSide = screenXo + xo + X + _width + 26 >= _tab.ScreenWidth;
            List<TextRun>? progressRuns = ProgressRuns(text);
            int progressWidth = progressRuns == null ? 0 : text.Width(progressRuns);
            bool topSide = titleBarBottom + descriptionHeight >= InsideHeight;
            float amount = _progress?.Percent ?? 0.0F;
            int firstHalfWidth = (int)Math.Floor(amount * _width);
            bool firstHalf, secondHalf, iconFrame;
            if (amount >= 1.0F) {
                firstHalfWidth = _width / 2;
                (firstHalf, secondHalf, iconFrame) = (true, true, true);
            }
            else if (firstHalfWidth < 2) {
                firstHalfWidth = _width / 2;
                (firstHalf, secondHalf, iconFrame) = (false, false, false);
            }
            else if (firstHalfWidth > _width - 2) {
                firstHalfWidth = _width / 2;
                (firstHalf, secondHalf, iconFrame) = (true, true, false);
            }
            else {
                (firstHalf, secondHalf, iconFrame) = (true, false, false);
            }
            int secondBarWidth = _width - firstHalfWidth;
            int titleLeft = leftSide ? xo + X - _width + 26 + 6 : xo + X;
            int backgroundHeight = titleBarHeight + descriptionHeight;
            if (_description.Count > 0) {
                int boxTop = topSide ? titleBarBottom - backgroundHeight : titleTop;
                if (!context.Sprites.NineSliced(context.Gui, "advancements/title_box", windowLeft + titleLeft, windowTop + boxTop, _width, backgroundHeight, 10)) {
                    AdvancementArt.TitleBox(context.Gui, windowLeft + titleLeft, windowTop + boxTop, _width, backgroundHeight);
                }
            }
            if (firstHalf != secondHalf) {
                BarPart(context, firstHalf, titleBarHeight, 0, windowLeft + titleLeft, windowTop + titleTop, firstHalfWidth);
                BarPart(context, secondHalf, titleBarHeight, 200 - secondBarWidth, windowLeft + titleLeft + firstHalfWidth, windowTop + titleTop, secondBarWidth);
            }
            else if (!context.Sprites.NineSliced(context.Gui, BoxSprite(firstHalf), windowLeft + titleLeft, windowTop + titleTop, _width, titleBarHeight, 10)) {
                AdvancementArt.Box(context.Gui, firstHalf, windowLeft + titleLeft, windowTop + titleTop, _width, titleBarHeight);
            }
            Frame(context, _display.Frame, iconFrame, windowLeft + xo + X + 3, windowTop + yo + Y);
            int descriptionLeft = titleLeft + 5;
            if (leftSide) {
                DrawLines(text, _titleLines, windowLeft + descriptionLeft, windowTop + titleTop + 9);
                if (progressRuns != null) {
                    text.Draw(progressRuns, windowLeft + xo + X - progressWidth, windowTop + titleTop + 9);
                }
            }
            else {
                DrawLines(text, _titleLines, windowLeft + xo + X + 32, windowTop + titleTop + 9);
                if (progressRuns != null) {
                    text.Draw(progressRuns, windowLeft + xo + X + _width - progressWidth - 5, windowTop + titleTop + 9);
                }
            }
            DrawLines(text, _description, windowLeft + descriptionLeft, windowTop + (topSide ? titleTop - descriptionTextHeight + 1 : titleBarBottom));
            GuiItems.Icon(context, _display.Icon, windowLeft + xo + X + 8, windowTop + yo + Y + 5);
        }

        private (AdvancementProgress? Progress, TextRenderer? Text, List<TextRun>? Runs) _progressRuns;

        private List<TextRun>? ProgressRuns(TextRenderer text) {
            if (_progressRuns.Progress != _progress || _progressRuns.Text != text) {
                _progressRuns = (_progress, text, _progress?.ProgressText is { } progressText ? Menus.Runs(progressText) : null);
            }
            return _progressRuns.Runs;
        }

        private static string BoxSprite(bool obtained) => obtained ? "advancements/box_obtained" : "advancements/box_unobtained";

        /// <summary>
        /// <c>blitSprite</c> of a slice of a nine sliced sprite: the whole 200 wide box drawn shifted left by
        /// <paramref name="u"/> and cut to the slice, so the two halves of the bar meet as one box.
        /// </summary>
        private static void BarPart(GuiContext context, bool obtained, int height, int u, int x, int y, int width) {
            if (width <= 0) {
                return;
            }
            context.Gui.EnableScissor(x, y, x + width, y + height);
            if (!context.Sprites.NineSliced(context.Gui, BoxSprite(obtained), x - u, y, 200, height, 10)) {
                AdvancementArt.Box(context.Gui, obtained, x - u, y, 200, height);
            }
            context.Gui.DisableScissor();
        }

        private static void DrawLines(TextRenderer text, List<List<TextRun>> lines, int x, int y) {
            for (int i = 0; i < lines.Count; i++) {
                text.Draw(lines[i], x, y + i * 9);
            }
        }

        public bool IsMouseOver(int xo, int yo, int mouseX, int mouseY) {
            if (!Shown) {
                return false;
            }
            int x0 = xo + X, y0 = yo + Y;
            return mouseX >= x0 && mouseX <= x0 + 26 && mouseY >= y0 && mouseY <= y0 + 26;
        }
    }
}

/// <summary>
/// The advancement screen's own art, drawn where no pack supplies the vanilla sprites: flat shapes at the
/// sprites' sizes, so the layout is the same with or without them.
/// </summary>
internal static class AdvancementArt {
    private const uint Outline = 0xFF000000, Light = 0xFFC6C6C6, Shade = 0xFF555555, Highlight = 0xFFFFFFFF;

    /// <summary>The window's frame round the 234 by 113 view, which it leaves open.</summary>
    public static void Window(Rendering.GuiRenderer gui, int x, int y) {
        gui.Rect(x, y, 252, 18, Light);
        gui.Rect(x, y + 131, 252, 9, Light);
        gui.Rect(x, y + 18, 9, 113, Light);
        gui.Rect(x + 243, y + 18, 9, 113, Light);
        gui.Rect(x, y, 252, 1, Outline);
        gui.Rect(x, y + 139, 252, 1, Outline);
        gui.Rect(x, y, 1, 140, Outline);
        gui.Rect(x + 251, y, 1, 140, Outline);
        gui.Rect(x + 8, y + 17, 236, 1, Shade);
        gui.Rect(x + 8, y + 131, 236, 1, Highlight);
        gui.Rect(x + 8, y + 17, 1, 115, Shade);
        gui.Rect(x + 243, y + 17, 1, 115, Highlight);
    }

    public static void Tab(Rendering.GuiRenderer gui, int x, int y, int w, int h, bool selected) {
        gui.Rect(x, y, w, h, Outline);
        gui.Rect(x + 1, y + 1, w - 2, h - 2, selected ? Light : 0xFF8B8B8B);
    }

    /// <summary>Slate tiles moving with the scroll, for a tab whose background the packs do not have.</summary>
    public static void Background(Rendering.GuiRenderer gui, int x, int y, int w, int h, int offsetX, int offsetY) {
        gui.Rect(x, y, w, h, 0xFF2B2D33);
        for (int lineX = x + (offsetX % 16 + 16) % 16; lineX < x + w; lineX += 16) {
            gui.Rect(lineX, y, 1, h, 0xFF33363D);
        }
        for (int lineY = y + (offsetY % 16 + 16) % 16; lineY < y + h; lineY += 16) {
            gui.Rect(x, lineY, w, 1, 0xFF33363D);
        }
    }

    /// <summary>A task is a square, a goal a square with its corners cut, a challenge a square with a spike on each side.</summary>
    public static void Frame(Rendering.GuiRenderer gui, AdvancementFrame frame, bool obtained, int x, int y) {
        uint rim = obtained ? 0xFFE8B83A : 0xFF9A9A9A, fill = obtained ? 0xFF7A5A12 : 0xFF3A3A3A;
        switch (frame) {
            case AdvancementFrame.Goal:
                gui.Rect(x + 4, y + 1, 18, 24, rim);
                gui.Rect(x + 1, y + 4, 24, 18, rim);
                gui.Rect(x + 2, y + 2, 22, 22, rim);
                gui.Rect(x + 4, y + 3, 18, 20, fill);
                gui.Rect(x + 3, y + 4, 20, 18, fill);
                break;
            case AdvancementFrame.Challenge:
                gui.Rect(x + 11, y, 4, 26, rim);
                gui.Rect(x, y + 11, 26, 4, rim);
                gui.Rect(x + 2, y + 2, 22, 22, rim);
                gui.Rect(x + 4, y + 4, 18, 18, fill);
                break;
            default:
                gui.Rect(x + 1, y + 1, 24, 24, rim);
                gui.Rect(x + 3, y + 3, 20, 20, fill);
                break;
        }
    }

    public static void Box(Rendering.GuiRenderer gui, bool obtained, int x, int y, int w, int h) {
        gui.Rect(x, y, w, h, Outline);
        gui.Rect(x + 1, y + 1, w - 2, h - 2, obtained ? 0xFFC08A1E : 0xFF1F5E96);
        gui.Rect(x + 1, y + 1, w - 2, 1, obtained ? 0xFFE8B83A : 0xFF3C82C0);
    }

    public static void TitleBox(Rendering.GuiRenderer gui, int x, int y, int w, int h) {
        gui.Rect(x, y, w, h, Outline);
        gui.Rect(x + 1, y + 1, w - 2, h - 2, 0xFF5A5A5A);
        gui.Rect(x + 2, y + 2, w - 4, h - 4, 0xFF212121);
    }
}
