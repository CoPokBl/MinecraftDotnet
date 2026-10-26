using System.Diagnostics;
using ClientLib;
using ClientLib.Packs;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Text;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>PackSelectionScreen</c> over <c>PackSelectionModel</c>: the available packs on the left, the selected ones
/// on the right with the highest first. Leaving it, by Done or Escape, commits the selection, which saves it
/// and reloads when it changed. Packs dropped on the window are copied into the folder after asking.
/// </summary>
public sealed class PackSelectionScreen(Screen lastScreen) : FocusScreen {
    private const int ListWidth = 200, EntryHeight = 36, IconSize = 32, ReloadCooldown = 20;
    private const int HeaderHeight = 4 + 9 + 4 + 9 + 4 + 15 + 4, FooterHeight = 33;

    /// <summary><c>PackEntry.MAX_DESCRIPTION_WIDTH_PIXELS</c>.</summary>
    private const int MaxDescriptionWidth = 157;

    private ClientResources _resources = null!;
    private Model _model = null!;
    private EditBox _search = null!;
    private TransferableList _available = null!, _selected = null!;
    private FileSystemWatcher? _watcher;
    private volatile bool _changed;
    private long _ticksToReload;
    private int _iconGeneration;

    protected override string NarrationTitle => Menus.T("resourcePack.title");

    public override bool ShowsHud => false;

    /// <summary><c>PackSelectionModel</c>: the selection top first, and the rest in the repository's order.</summary>
    private sealed class Model {
        private readonly ClientPackRepository _repository;
        public readonly List<ClientPack> Selected;
        public readonly List<ClientPack> Unselected;

        public Model(ClientPackRepository repository) {
            _repository = repository;
            Selected = repository.Selected.Reverse().ToList();
            Unselected = repository.Available.OrderBy(p => p.Id, StringComparer.Ordinal).Where(p => !Selected.Contains(p)).ToList();
        }

        public void UpdateRepoSelectedList() => _repository.SetSelected(Enumerable.Reverse(Selected).Select(p => p.Id).ToList());

        /// <summary><c>findNewPacks</c>.</summary>
        public void FindNewPacks() {
            _repository.Reload();
            HashSet<string> available = _repository.Available.Select(p => p.Id).ToHashSet();
            List<string> selectedIds = Selected.Where(p => available.Contains(p.Id)).Select(p => p.Id).ToList();
            Selected.Clear();
            Selected.AddRange(selectedIds.Select(id => _repository.Get(id)!));
            Unselected.Clear();
            Unselected.AddRange(_repository.Available.OrderBy(p => p.Id, StringComparer.Ordinal).Where(p => !selectedIds.Contains(p.Id)));
        }

        public bool IsSelected(ClientPack pack) => Selected.Contains(pack);

        public bool CanUnselect(ClientPack pack) => IsSelected(pack) && !pack.Required;

        /// <summary><c>EntryBase.toggleSelection</c>: into the other list at the pack's end, past the fixed packs there.</summary>
        public void ToggleSelection(ClientPack pack) {
            List<ClientPack> self = IsSelected(pack) ? Selected : Unselected;
            List<ClientPack> other = self == Selected ? Unselected : Selected;
            self.Remove(pack);
            ClientPackRepository.Insert(other, pack, pack.DefaultPosition, true);
            UpdateRepoSelectedList();
        }

        private List<ClientPack> SelfList(ClientPack pack) => IsSelected(pack) ? Selected : Unselected;

        public bool CanMoveUp(ClientPack pack) {
            List<ClientPack> list = SelfList(pack);
            int index = list.IndexOf(pack);
            return index > 0 && !list[index - 1].FixedPosition;
        }

        public bool CanMoveDown(ClientPack pack) {
            List<ClientPack> list = SelfList(pack);
            int index = list.IndexOf(pack);
            return index >= 0 && index < list.Count - 1 && !list[index + 1].FixedPosition;
        }

        public void Move(ClientPack pack, int direction) {
            List<ClientPack> list = SelfList(pack);
            int currentPos = list.IndexOf(pack);
            list.RemoveAt(currentPos);
            list.Insert(currentPos + direction, pack);
        }
    }

    /// <summary><c>TransferableSelectionList</c>: a header row then the packs, the rows filling the list's width.</summary>
    private sealed class TransferableList {
        public readonly SelectionList List;
        public readonly string Title;
        public readonly List<ClientPack> Packs = [];
        public bool Focused;

        public TransferableList(string title) {
            Title = title;
            List = new SelectionList(EntryHeight) {
                RowWidth = () => List!.Width - 4,
                ScrollBarXOverride = () => List!.Right - 6,
                EntryWidthOverride = () => List!.Width - 4 - (List.Scrollable ? 6 : 0)
            };
        }

        /// <summary><c>updateList</c>: the moved pack, when there is one, keeps the selection.</summary>
        public void Update(IEnumerable<ClientPack> packs, ClientPack? transferred) {
            List.Clear();
            Packs.Clear();
            List.Add((int)(9.0F * 1.5F));
            foreach (ClientPack pack in packs) {
                Packs.Add(pack);
                int row = List.Add();
                if (transferred == pack) {
                    List.Selected = row;
                    List.ScrollToEntry(row);
                    Focused = true;
                }
            }
            List.RefreshScrollAmount();
        }

        public ClientPack? PackAt(int row) => row >= 1 && row <= Packs.Count ? Packs[row - 1] : null;
    }

    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        _resources = context.Resources!;
        string filter = first ? "" : _search.Value;
        if (first) {
            _model = new Model(_resources.Repository);
            _available = new TransferableList(Menus.T("pack.available.title"));
            _selected = new TransferableList(Menus.T("pack.selected.title"));
            Directory.CreateDirectory(_resources.Repository.Folder);
            _watcher = Watch(_resources.Repository.Folder);
        }
        _search = AddChild(new EditBox(context.Text, width / 2 - 100, 4 + 9 + 4 + 9 + 4, 200, 15) {
            Hint = [new TextRun(Menus.T("gui.packSelection.search"), 0xAAAAAA, Italic: true)]
        });
        _search.SetResponder(value => UpdateFilteredEntries(value, null));
        int contentHeight = height - HeaderHeight - FooterHeight;
        _available.List.SetBounds(width / 2 - 15 - ListWidth, HeaderHeight, ListWidth, contentHeight);
        _selected.List.SetBounds(width / 2 + 15, HeaderHeight, ListWidth, contentHeight);
        int buttonsY = height - FooterHeight + (FooterHeight - 20) / 2;
        AddChild(new Button(Menus.T("pack.openFolder"), width / 2 - 154, buttonsY, 150, () => OpenFolder(_resources.Repository.Folder)));
        AddChild(new Button(Menus.T("gui.done"), width / 2 + 4, buttonsY, 150, () => Close(context)));
        if (first) {
            Reload();
        }
        else {
            _search.Value = filter;
            UpdateFilteredEntries(filter, null);
        }
        SetFocus(_search);
    }

    /// <summary><c>Util.getPlatform().openPath</c>.</summary>
    private static void OpenFolder(string folder) {
        try {
            string opener = OperatingSystem.IsWindows() ? "explorer" : OperatingSystem.IsMacOS() ? "open" : "xdg-open";
            Process.Start(new ProcessStartInfo(opener, $"\"{folder}\"") { UseShellExecute = false });
        }
        catch (Exception e) when (e is System.ComponentModel.Win32Exception or InvalidOperationException) {
            Console.Error.WriteLine($"Couldn't open {folder}: {e.Message}");
        }
    }

    /// <summary><c>Watcher</c>: any change in the folder, or in a pack folder directly in it.</summary>
    private FileSystemWatcher? Watch(string folder) {
        try {
            FileSystemWatcher watcher = new(folder) { IncludeSubdirectories = true, EnableRaisingEvents = true };
            watcher.Changed += (_, _) => _changed = true;
            watcher.Created += (_, _) => _changed = true;
            watcher.Deleted += (_, _) => _changed = true;
            watcher.Renamed += (_, _) => _changed = true;
            return watcher;
        }
        catch (Exception e) when (e is IOException or ArgumentException or PlatformNotSupportedException) {
            Console.Error.WriteLine($"Failed to initialize pack directory {folder} monitoring: {e.Message}");
            return null;
        }
    }

    public override void Tick(GuiContext context) {
        if (_changed) {
            _changed = false;
            _ticksToReload = ReloadCooldown;
        }
        if (_ticksToReload > 0L && --_ticksToReload == 0L) {
            Reload();
        }
    }

    private void Reload() {
        _model.FindNewPacks();
        PopulateLists(null);
        _ticksToReload = 0L;
        _iconGeneration++;
    }

    private void PopulateLists(ClientPack? transferred) => UpdateFilteredEntries(_search.Value, transferred);

    /// <summary><c>filterEntries</c>: by id, title or description, ignoring case.</summary>
    private void UpdateFilteredEntries(string value, ClientPack? transferred) {
        string lower = value.ToLowerInvariant();
        bool Matches(ClientPack pack) => string.IsNullOrWhiteSpace(value) || pack.Id.ToLowerInvariant().Contains(lower)
                                         || TextFlattener.Plain(pack.Title).ToLowerInvariant().Contains(lower)
                                         || TextFlattener.Plain(pack.Metadata.Description).ToLowerInvariant().Contains(lower);
        _selected.Update(_model.Selected.Where(Matches), transferred);
        _available.Update(_model.Unselected.Where(Matches), transferred);
    }

    /// <summary><c>onClose</c>: <c>PackSelectionModel.commit</c>, then <c>OptionsScreen.applyPacks</c>.</summary>
    public override void Close(GuiContext context) {
        _model.UpdateRepoSelectedList();
        _watcher?.Dispose();
        _watcher = null;
        _resources.UpdateResourcePacks();
        context.Open?.Invoke(lastScreen);
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        Menus.Background(context);
        int width = context.Width;
        context.Text.DrawCentred(Menus.T("resourcePack.title"), width / 2.0F, 4);
        context.Text.DrawCentred(Menus.T("pack.dropInfo"), width / 2.0F, 4 + 9 + 4, 0xFFAAAAAA);
        _search.Render(context);
        RenderList(context, _available);
        RenderList(context, _selected);
        RenderButtons(context);
        if (Inside(MouseX, MouseY, width / 2.0F - 154, context.Height - FooterHeight + (FooterHeight - 20) / 2, 150, 20)) {
            Inventory.Tooltips.Draw(context, context.Text.Wrap(Menus.Runs(TextComponent.Translatable("pack.folderInfo")), 170), MouseX, MouseY);
        }
    }

    private void RenderList(GuiContext context, TransferableList list) {
        list.List.Render(context, MouseX, MouseY, (row, x, y, w, h, hovered) => {
            if (row == 0) {
                List<TextRun> header = [new TextRun(list.Title, 0xFFFFFF, Bold: true, Underlined: true)];
                context.Text.DrawCentred(header, x + w / 2.0F, y + 2 + (h - 4) / 2 - 9 / 2);
                return;
            }
            RenderPack(context, list, list.PackAt(row)!, row, x + 2, y + 2, w - 4, h - 4, hovered);
        }, list.Focused);
    }

    /// <summary><c>PackEntry.extractContent</c>.</summary>
    private void RenderPack(GuiContext context, TransferableList list, ClientPack pack, int row, int x, int y, int w, int h, bool hovered) {
        Rendering.GuiRenderer gui = context.Gui;
        PackCompatibility compatibility = pack.Metadata.Compatibility;
        if (compatibility != PackCompatibility.Compatible) {
            gui.Rect(x - 1, y - 1, w + 2, h + 2, 0xFF770000);
        }
        if (!context.Sprites.Dynamic(gui, $"pack/{pack.Id}/{_iconGeneration}", () => Icon(pack), x, y, IconSize, IconSize)
            && !context.Sprites.Blit(gui, "misc/unknown_pack", x, y, IconSize, IconSize, 0, 0, IconSize, IconSize)) {
            gui.Rect(x, y, IconSize, IconSize, 0xFF3A3A3A);
        }
        List<TextRun> name = Menus.Runs(pack.Title);
        List<TextRun> description = Menus.Runs(pack.ExtendedDescription, 0x808080);
        if (ShowHoverOverlay(pack) && (hovered || list.List.Selected == row && list.Focused)) {
            gui.Rect(x, y, IconSize, IconSize, 0xA0909090);
            int relX = (int)MouseX - x, relY = (int)MouseY - y;
            if (compatibility != PackCompatibility.Compatible) {
                name = Menus.Runs(TextComponent.Translatable("pack.incompatible"));
                description = Menus.Runs(TextComponent.Translatable(CompatibilityKey(compatibility, false)).WithColor(TextColor.Gray), 0x808080);
            }
            if (!_model.IsSelected(pack)) {
                Overlay(context, MouseOverIcon(relX, relY) ? "transferable_list/select_highlighted" : "transferable_list/select", x, y);
            }
            else {
                if (_model.CanUnselect(pack)) {
                    Overlay(context, MouseOverLeftHalf(relX, relY) ? "transferable_list/unselect_highlighted" : "transferable_list/unselect", x, y);
                }
                if (_model.CanMoveUp(pack)) {
                    Overlay(context, MouseOverTopRightQuarter(relX, relY) ? "transferable_list/move_up_highlighted" : "transferable_list/move_up", x, y);
                }
                if (_model.CanMoveDown(pack)) {
                    Overlay(context, MouseOverBottomRightQuarter(relX, relY) ? "transferable_list/move_down_highlighted" : "transferable_list/move_down", x, y);
                }
            }
        }
        int maxWidth = MaxDescriptionWidth - (list.List.Scrollable ? 6 : 0);
        context.Text.Draw(Clip(context, name, maxWidth), x + IconSize + 2, y + 1);
        float lineY = y + 12;
        foreach (List<TextRun> line in DescriptionLines(context, description, maxWidth)) {
            context.Text.Draw(line, x + IconSize + 2, lineY);
            lineY += 9;
        }
    }

    private static string CompatibilityKey(PackCompatibility compatibility, bool confirm) =>
        (confirm ? "pack.incompatible.confirm." : "pack.incompatible.") + compatibility switch {
            PackCompatibility.TooOld => "old",
            PackCompatibility.TooNew => "new",
            _ => "unknown"
        };

    private static void Overlay(GuiContext context, string sprite, int x, int y) {
        if (!context.Sprites.Sprite(context.Gui, sprite, x, y, IconSize, IconSize)) {
            context.Gui.Rect(x + 8, y + 12, 16, 8, 0xC0FFFFFF);
        }
    }

    private static TextureImage? Icon(ClientPack pack) {
        if (pack.Icon() is not { } png) {
            return null;
        }
        try {
            return Png.Decode(png);
        }
        catch (Exception e) when (e is InvalidDataException or IndexOutOfRangeException or ArgumentException) {
            Console.Error.WriteLine($"Failed to load icon from pack {pack.Id}: {e.Message}");
            return null;
        }
    }

    private static bool ShowHoverOverlay(ClientPack pack) => !pack.FixedPosition || !pack.Required;

    private static bool MouseOverIcon(int relX, int relY) => relX >= 0 && relX < IconSize && relY >= 0 && relY < IconSize;

    private static bool MouseOverLeftHalf(int relX, int relY) => relX >= 0 && relX < IconSize / 2 && relY >= 0 && relY < IconSize;

    private static bool MouseOverTopRightQuarter(int relX, int relY) => relX >= IconSize / 2 && relX < IconSize && relY >= 0 && relY < IconSize / 2;

    private static bool MouseOverBottomRightQuarter(int relX, int relY) => relX >= IconSize / 2 && relX < IconSize && relY >= IconSize / 2 && relY < IconSize;

    /// <summary><c>ComponentRenderUtils.clipText</c>: cut to fit with an ellipsis, when it does not fit already.</summary>
    private static List<TextRun> Clip(GuiContext context, List<TextRun> runs, int maxWidth) =>
        context.Text.Width(runs) <= maxWidth ? runs : [.. Head(context, runs, maxWidth - context.Text.Width("...")), new TextRun("...", runs.LastOrDefault().Rgb)];

    /// <summary>
    /// <c>MultiLineLabel</c> with two rows at most: a description longer than that has its second row cut with an
    /// ellipsis in the description's style.
    /// </summary>
    private static List<List<TextRun>> DescriptionLines(GuiContext context, List<TextRun> runs, int maxWidth) {
        List<List<TextRun>> lines = context.Text.Wrap(runs, maxWidth);
        if (lines.Count <= 2) {
            return lines;
        }
        List<TextRun> last = lines[1];
        return [lines[0], [.. Head(context, last, context.Text.Width(last) - context.Text.Width("...")), new TextRun("...", 0x808080)]];
    }

    /// <summary><c>Font.substrByWidth</c> over styled runs.</summary>
    private static List<TextRun> Head(GuiContext context, List<TextRun> runs, int width) {
        List<TextRun> head = [];
        float used = 0;
        foreach (TextRun run in runs) {
            int end = 0;
            while (end < run.Text.Length) {
                float advance = context.Text.Advance(run.Text[end], run.Bold);
                if (used + advance > width) {
                    break;
                }
                used += advance;
                end++;
            }
            if (end > 0) {
                head.Add(run with { Text = run.Text[..end] });
            }
            if (end < run.Text.Length) {
                break;
            }
        }
        return head;
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        if (ClickChildren(context, x, y, button) || button != MouseButton.Left) {
            return;
        }
        foreach (TransferableList list in (TransferableList[])[_available, _selected]) {
            list.Focused = false;
        }
        foreach (TransferableList list in (TransferableList[])[_available, _selected]) {
            if (list.List.StartScrolling(x, y)) {
                return;
            }
            int row = list.List.EntryAt(x, y);
            if (row < 0) {
                continue;
            }
            SetFocus(null);
            list.Focused = true;
            list.List.Selected = row;
            if (list.PackAt(row) is { } pack) {
                PackClicked(context, pack, (int)x - (list.List.RowLeft + 2), (int)y - (list.List.RowTop(row) + 2));
            }
            return;
        }
    }

    /// <summary><c>PackEntry.mouseClicked</c>: the quarter of the icon under the click decides.</summary>
    private void PackClicked(GuiContext context, ClientPack pack, int relX, int relY) {
        if (!ShowHoverOverlay(pack)) {
            return;
        }
        if (!_model.IsSelected(pack) && MouseOverIcon(relX, relY)) {
            HandlePackSelection(context, pack);
        }
        else if (_model.CanUnselect(pack) && MouseOverLeftHalf(relX, relY)) {
            Transfer(pack);
        }
        else if (_model.IsSelected(pack) && _model.CanMoveUp(pack) && MouseOverTopRightQuarter(relX, relY)) {
            Move(pack, -1);
        }
        else if (_model.IsSelected(pack) && _model.CanMoveDown(pack) && MouseOverBottomRightQuarter(relX, relY)) {
            Move(pack, 1);
        }
    }

    private void Transfer(ClientPack pack) {
        _model.ToggleSelection(pack);
        PopulateLists(pack);
    }

    private void Move(ClientPack pack, int direction) {
        _model.Move(pack, direction);
        PopulateLists(pack);
    }

    /// <summary><c>handlePackSelection</c>: a pack of another format is only taken after the player confirms it.</summary>
    private void HandlePackSelection(GuiContext context, ClientPack pack) {
        if (pack.Metadata.Compatibility == PackCompatibility.Compatible) {
            Transfer(pack);
            return;
        }
        context.Open?.Invoke(new ConfirmScreen(accepted => {
            context.Open?.Invoke(this);
            if (accepted) {
                Transfer(pack);
            }
        }, TextComponent.Translatable("pack.incompatible.confirm.title"), TextComponent.Translatable(CompatibilityKey(pack.Metadata.Compatibility, true)),
            Menus.T("gui.yes"), Menus.T("gui.no")));
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        LayOut(context);
        float dy = y - MouseY;
        base.MouseMove(context, x, y);
        _available.List.Drag(y, dy);
        _selected.List.Drag(y, dy);
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        LayOut(context);
        base.MouseUp(context, x, y, button);
        _available.List.StopScrolling();
        _selected.List.StopScrolling();
    }

    public override void Scroll(GuiContext context, float delta) {
        LayOut(context);
        foreach (TransferableList list in (TransferableList[])[_available, _selected]) {
            if (list.List.IsMouseOver(MouseX, MouseY)) {
                list.List.Scroll(delta);
            }
        }
    }

    /// <summary>
    /// The focused list takes the arrows, Enter and Shift with an arrow, as <c>PackEntry.keyPressed</c> does:
    /// Enter selects or unselects, Shift moves within the selection.
    /// </summary>
    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        TransferableList? focused = _available.Focused ? _available : _selected.Focused ? _selected : null;
        if (focused != null && focused.List.Count > 1) {
            ClientPack? pack = focused.PackAt(focused.List.Selected);
            bool shift = Inventory.ContainerScreen.ShiftHeld();
            switch (key) {
                case Key.Enter or Key.KeypadEnter or Key.Space when pack != null:
                    if (!_model.IsSelected(pack)) {
                        HandlePackSelection(context, pack);
                    }
                    else if (_model.CanUnselect(pack)) {
                        Transfer(pack);
                    }
                    return;
                case Key.Up or Key.Down when shift && pack != null:
                    int direction = key == Key.Up ? -1 : 1;
                    if (_model.IsSelected(pack) && (direction < 0 ? _model.CanMoveUp(pack) : _model.CanMoveDown(pack))) {
                        Move(pack, direction);
                    }
                    return;
                case Key.Up or Key.Down:
                    int next = Math.Clamp(focused.List.Selected + (key == Key.Up ? -1 : 1), 1, focused.List.Count - 1);
                    focused.List.Selected = next;
                    focused.List.ScrollToEntry(next);
                    return;
            }
        }
        KeyToChildren(context, key, control);
    }

    /// <summary>
    /// <c>onFilesDrop</c>: asks, then copies each pack folder or zip into the packs folder and lists them; anything
    /// that is not a pack is named in a notice.
    /// </summary>
    public void FilesDropped(GuiContext context, IReadOnlyList<string> files) {
        string names = string.Join(", ", files.Select(Path.GetFileName));
        context.Open?.Invoke(new ConfirmScreen(accepted => {
            if (accepted) {
                List<string> candidates = files.Where(IsPack).ToList();
                List<string> leftovers = files.Except(candidates).ToList();
                if (candidates.Count > 0) {
                    CopyPacks(candidates, _resources.Repository.Folder);
                    Reload();
                }
                if (leftovers.Count > 0) {
                    context.Open?.Invoke(new ConfirmScreen(_ => context.Open?.Invoke(this), TextComponent.Translatable("pack.dropRejected.title"),
                        TextComponent.Translatable("pack.dropRejected.message", with: [string.Join(", ", leftovers.Select(Path.GetFileName))]),
                        Menus.T("gui.ok"), Menus.T("gui.back")));
                    return;
                }
            }
            context.Open?.Invoke(this);
        }, TextComponent.Translatable("pack.dropConfirm"), TextComponent.Text(names), Menus.T("gui.yes"), Menus.T("gui.no")));
    }

    /// <summary><c>PackDetector.detectPackResources</c>: a folder with a <c>pack.mcmeta</c>, or a <c>.zip</c>.</summary>
    private static bool IsPack(string path) =>
        Directory.Exists(path) ? File.Exists(Path.Combine(path, "pack.mcmeta")) : File.Exists(path) && path.EndsWith(".zip", StringComparison.Ordinal);

    private static void CopyPacks(IEnumerable<string> packs, string targetDir) {
        foreach (string pack in packs) {
            string target = Path.Combine(targetDir, Path.GetFileName(pack));
            try {
                if (Directory.Exists(pack)) {
                    foreach (string file in Directory.EnumerateFiles(pack, "*", SearchOption.AllDirectories)) {
                        string to = Path.Combine(target, Path.GetRelativePath(pack, file));
                        Directory.CreateDirectory(Path.GetDirectoryName(to)!);
                        File.Copy(file, to, true);
                    }
                }
                else {
                    File.Copy(pack, target, true);
                }
            }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) {
                Console.Error.WriteLine($"Failed to copy pack from {pack} to {targetDir}: {e.Message}");
            }
        }
    }
}
