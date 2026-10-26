using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Sockets;
using ClientLib;
using ClientLib.Multiplayer;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering;
using Minecraft;
using Minecraft.Text;
using Silk.NET.Input;
using Silk.NET.OpenGL;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>JoinMultiplayerScreen</c> and its <c>ServerSelectionList</c>: the saved servers, pinged as they come into
/// view, then a header for the LAN games heard, then those games. Narration is not ported.
/// </summary>
public sealed class JoinMultiplayerScreen(Screen lastScreen) : Screen {
    private const int HeaderHeight = 33, FooterHeight = 60, ItemHeight = 36, RowWidth = 305, IconSize = 32;

    /// <summary><c>ServerSelectionList.THREAD_POOL</c>: five pings resolve and connect at once.</summary>
    private static readonly SemaphoreSlim PingPool = new(5);

    private readonly ServerStatusPinger _pinger = new();
    private readonly LanServerList _lanServers = new();
    private readonly ConcurrentQueue<Action> _mainThread = new();
    private readonly List<Entry> _onlineServers = [];
    private readonly List<Entry> _networkServers = [];
    private readonly List<Entry> _entries = [];
    private readonly Entry _lanHeader = new();
    private LanServerDetector? _lanDetector;
    private ServerList _servers = null!;
    private ServerData _editingServer = null!;
    private Entry? _selected;
    private double _scroll;
    private bool _initialized, _scrolling;
    private Button _selectButton = null!, _editButton = null!, _deleteButton = null!;
    private (long Time, Entry Entry)? _lastClick;
    private GL? _gl;

    public override bool ShowsHud => false;

    /// <summary><c>ServerSelectionList.Entry</c> and its three kinds: a saved server, the LAN header, a LAN game.</summary>
    private sealed class Entry {
        public ServerData? Server;
        public LanServer? Lan;
        public byte[]? LastIconBytes;
        public uint Icon;
        public string? StatusIcon;
        public TextComponent? StatusIconTooltip;
        public IReadOnlyList<TextComponent>? OnlinePlayersTooltip;
    }

    private static string T(string key) => Menus.T(key);

    private int ListBottom(int height) => height - FooterHeight;

    private int RowLeft(int width) => width / 2 - RowWidth / 2;

    private int RowTop(int index) => HeaderHeight + 2 - (int)_scroll + index * ItemHeight;

    private int MaxScroll(int height) => Math.Max(0, _entries.Count * ItemHeight + 4 - (ListBottom(height) - HeaderHeight));

    protected override void Init(GuiContext context, int width, int height) {
        _gl = context.Host?.Gl;
        if (!_initialized) {
            _initialized = true;
            _servers = new ServerList(context.Host?.DataDirectory ?? ".");
            _servers.Load();
            try {
                _lanDetector = new LanServerDetector(_lanServers);
                _lanDetector.Start();
            }
            catch (SocketException e) {
                Console.Error.WriteLine($"Unable to start LAN server detection: {e.Message}");
            }
            UpdateOnlineServers();
        }
        // The footer's two rows of buttons, 4 apart, centred in its 60 pixels.
        float top = height - FooterHeight + (FooterHeight - 44) / 2.0F;
        float left = width / 2.0F - 154;
        _selectButton = new Button(T("selectServer.select"), left, top, 100, () => {
            if (_selected != null) {
                Join(context, _selected);
            }
        });
        Add(_selectButton);
        Add(new Button(T("selectServer.direct"), left + 104, top, 100, () => {
            _editingServer = new ServerData(T("selectServer.defaultName"), "", ServerType.Other);
            context.Open?.Invoke(new DirectJoinServerScreen(this, ok => DirectJoinCallback(context, ok), _editingServer));
        }));
        Add(new Button(T("selectServer.add"), left + 208, top, 100, () => {
            _editingServer = new ServerData("", "", ServerType.Other);
            context.Open?.Invoke(new ManageServerScreen(this, T("manageServer.add.title"), ok => AddServerCallback(context, ok), _editingServer));
        }));
        _editButton = new Button(T("selectServer.edit"), left, top + 24, 74, () => {
            if (_selected?.Server is { } current) {
                _editingServer = new ServerData(current.Name, current.Ip, ServerType.Other);
                _editingServer.CopyFrom(current);
                context.Open?.Invoke(new ManageServerScreen(this, T("manageServer.edit.title"), ok => EditServerCallback(context, ok), _editingServer));
            }
        });
        Add(_editButton);
        _deleteButton = new Button(T("selectServer.delete"), left + 78, top + 24, 74, () => {
            if (_selected?.Server is { Name: { } name }) {
                context.Open?.Invoke(new ConfirmScreen(ok => DeleteCallback(context, ok), Menus.Translatable("selectServer.deleteQuestion"),
                    Menus.Translatable("selectServer.deleteWarning", TextComponent.Text(name)), T("selectServer.deleteButton"), T("gui.cancel")));
            }
        });
        Add(_deleteButton);
        Add(new Button(T("selectServer.refresh"), left + 156, top + 24, 74, () => Refresh(context)));
        Add(new Button(T("gui.back"), left + 234, top + 24, 74, () => Close(context)));
        _scroll = Math.Clamp(_scroll, 0, MaxScroll(height));
        OnSelectedChange();
    }

    private void Refresh(GuiContext context) => context.Open?.Invoke(new JoinMultiplayerScreen(lastScreen));

    public override void Close(GuiContext context) => context.Open?.Invoke(lastScreen);

    public override void Tick(GuiContext context) {
        if (_lanServers.TakeDirtyServers() is { } lan) {
            UpdateNetworkServers(lan);
        }
    }

    /// <summary><c>removed</c>, which leaves LAN detection off when the screen comes back, as vanilla's does.</summary>
    public override void Removed(GuiContext context) {
        _lanDetector?.Interrupt();
        _lanDetector = null;
        _pinger.RemoveAll();
        foreach (Entry entry in _onlineServers) {
            DeleteIcon(entry);
            entry.LastIconBytes = null;
        }
    }

    /// <summary><c>updateOnlineServers</c>, whose new entries drop the old ones' icons.</summary>
    private void UpdateOnlineServers() {
        foreach (Entry entry in _onlineServers) {
            DeleteIcon(entry);
        }
        _onlineServers.Clear();
        for (int i = 0; i < _servers.Count; i++) {
            Entry entry = new() { Server = _servers[i] };
            RefreshStatus(entry);
            _onlineServers.Add(entry);
        }
        RefreshEntries();
    }

    private void UpdateNetworkServers(IReadOnlyList<LanServer> servers) {
        _networkServers.Clear();
        foreach (LanServer server in servers) {
            _networkServers.Add(new Entry { Lan = server });
        }
        RefreshEntries();
    }

    /// <summary><c>refreshEntries</c>: the selection follows the server it was on.</summary>
    private void RefreshEntries() {
        Entry? previous = _selected;
        _entries.Clear();
        _entries.AddRange(_onlineServers);
        _entries.Add(_lanHeader);
        _entries.AddRange(_networkServers);
        _selected = null;
        if (previous != null) {
            _selected = _entries.Find(entry => Matches(entry, previous));
        }
        if (_selectButton != null!) {
            OnSelectedChange();
        }
    }

    private static bool Matches(Entry entry, Entry other) =>
        entry == other || entry.Server != null && entry.Server == other.Server || entry.Lan != null && entry.Lan == other.Lan;

    private void SetSelected(Entry? entry) {
        _selected = entry;
        OnSelectedChange();
    }

    private void OnSelectedChange() {
        _selectButton.Active = _selected != null && _selected != _lanHeader;
        _editButton.Active = _deleteButton.Active = _selected?.Server != null;
    }

    private void Join(GuiContext context, Entry entry) {
        if (entry.Server != null) {
            Join(context, entry.Server);
        }
        else if (entry.Lan is { } lan) {
            Join(context, new ServerData(lan.Motd, lan.Address, ServerType.Lan));
        }
    }

    private void Join(GuiContext context, ServerData server) => context.Host?.Join(this, server);

    private void DeleteCallback(GuiContext context, bool result) {
        if (result && _selected?.Server is { } server) {
            _servers.Remove(server);
            _servers.Save();
            SetSelected(null);
            UpdateOnlineServers();
        }
        context.Open?.Invoke(this);
    }

    private void EditServerCallback(GuiContext context, bool result) {
        if (result && _selected?.Server is { } current) {
            current.Name = _editingServer.Name;
            current.Ip = _editingServer.Ip;
            current.CopyFrom(_editingServer);
            _servers.Save();
            UpdateOnlineServers();
        }
        context.Open?.Invoke(this);
    }

    private void AddServerCallback(GuiContext context, bool result) {
        if (result) {
            if (_servers.Unhide(_editingServer.Ip) is { } unhidden) {
                unhidden.CopyNameIconFrom(_editingServer);
            }
            else {
                _servers.Add(_editingServer, false);
            }
            _servers.Save();
            SetSelected(null);
            UpdateOnlineServers();
        }
        context.Open?.Invoke(this);
    }

    private void DirectJoinCallback(GuiContext context, bool result) {
        if (!result) {
            context.Open?.Invoke(this);
            return;
        }
        if (_servers.Get(_editingServer.Ip) is { } known) {
            Join(context, known);
            return;
        }
        _servers.Add(_editingServer, true);
        _servers.Save();
        Join(context, _editingServer);
    }

    /// <summary><c>OnlineServerEntry.refreshStatus</c>: the bars by ping, and which tooltips go with them.</summary>
    private static void RefreshStatus(Entry entry) {
        ServerData server = entry.Server!;
        entry.OnlinePlayersTooltip = null;
        switch (server.State) {
            case ServerState.Initial or ServerState.Pinging:
                entry.StatusIcon = "server_list/ping_1";
                entry.StatusIconTooltip = Menus.Translatable("multiplayer.status.pinging");
                break;
            case ServerState.Incompatible:
                entry.StatusIcon = "server_list/incompatible";
                entry.StatusIconTooltip = Menus.Translatable("multiplayer.status.incompatible");
                entry.OnlinePlayersTooltip = server.PlayerList;
                break;
            case ServerState.Unreachable:
                entry.StatusIcon = "server_list/unreachable";
                entry.StatusIconTooltip = Menus.Translatable("multiplayer.status.no_connection");
                break;
            case ServerState.Successful:
                entry.StatusIcon = PingSprite(server.Ping);
                entry.StatusIconTooltip = Menus.Translatable("multiplayer.status.ping", TextComponent.Text(server.Ping.ToString()));
                entry.OnlinePlayersTooltip = server.PlayerList;
                break;
        }
    }

    /// <summary>The bars for a ping: five under 150 ms, then one fewer at 300, 600 and 1000.</summary>
    public static string PingSprite(long ping) => ping switch {
        < 150 => "server_list/ping_5",
        < 300 => "server_list/ping_4",
        < 600 => "server_list/ping_3",
        < 1000 => "server_list/ping_2",
        _ => "server_list/ping_1"
    };

    /// <summary><c>LoadingDotsText.get</c>.</summary>
    public static string LoadingDots(long millis) => (string[])["O o o", "o O o", "o o O", "o O o"] is var frames ? frames[(int)(millis / 300 % frames.Length)] : "";

    /// <summary>The pinging animation's frame, which bounces from 1 to 5 and back with each entry two frames behind the one above.</summary>
    public static string PingingSprite(long millis, int index) {
        int frame = (int)(millis / 100L + index * 2 & 7L);
        if (frame > 4) {
            frame = 8 - frame;
        }
        return $"server_list/pinging_{frame + 1}";
    }

    private static long Millis() => (long)(Stopwatch.GetTimestamp() * (1000.0 / Stopwatch.Frequency));

    /// <summary>The ping, started the first frame a server's entry is drawn.</summary>
    private void StartPing(Entry entry) {
        ServerData server = entry.Server!;
        server.State = ServerState.Pinging;
        server.Motd = TextComponent.Empty();
        server.Status = TextComponent.Empty();
        Task.Run(async () => {
            await PingPool.WaitAsync();
            try {
                _pinger.PingServer(server, () => _mainThread.Enqueue(() => _servers.Save()), () => {
                    server.State = server.Protocol == ProtocolConstants.ProtocolVersion ? ServerState.Successful : ServerState.Incompatible;
                    _mainThread.Enqueue(() => RefreshStatus(entry));
                });
            }
            catch (Exception) {
                server.State = ServerState.Unreachable;
                server.Motd = Menus.Translatable("multiplayer.status.cannot_connect").WithColor(TextColor.Hex("#FF0000"));
                _mainThread.Enqueue(() => RefreshStatus(entry));
            }
            finally {
                PingPool.Release();
            }
        });
    }

    public override void Render(GuiContext context, float partialTick) {
        while (_mainThread.TryDequeue(out Action? task)) {
            task();
        }
        Menus.Background(context);
        LayOut(context);
        int width = context.Width, height = context.Height;
        context.Text.DrawCentred(T("multiplayer.title"), width / 2.0F, (HeaderHeight - 9) / 2.0F);
        RenderList(context, width, height);
        RenderWidgets(context);
    }

    private void RenderList(GuiContext context, int width, int height) {
        GuiRenderer gui = context.Gui;
        int top = HeaderHeight, bottom = ListBottom(height);
        if (!context.Sprites.Tiled(gui, "gui/menu_list_background", 0, top, width, bottom - top, 32)) {
            gui.Rect(0, top, width, bottom - top, 0x60000000);
        }
        int rowLeft = RowLeft(width);
        Entry? hovered = null;
        if (MouseY >= top && MouseY < bottom) {
            for (int i = 0; i < _entries.Count; i++) {
                if (Inside(MouseX, MouseY, rowLeft, RowTop(i), RowWidth, ItemHeight)) {
                    hovered = _entries[i];
                }
            }
        }
        gui.EnableScissor(0, top, width, bottom);
        (TextComponent? Tooltip, IReadOnlyList<TextComponent>? Players) tooltip = (null, null);
        for (int i = 0; i < _entries.Count; i++) {
            int y = RowTop(i);
            if (y + ItemHeight < top || y > bottom) {
                continue;
            }
            Entry entry = _entries[i];
            if (_selected == entry) {
                // extractSelection: a grey outline round black.
                gui.Rect(rowLeft, y, RowWidth, ItemHeight, 0xFF808080);
                gui.Rect(rowLeft + 1, y + 1, RowWidth - 2, ItemHeight - 2, 0xFF000000);
            }
            int x = rowLeft + 2, contentY = y + 2;
            if (entry.Server != null) {
                RenderServer(context, entry, i, x, contentY, hovered == entry, ref tooltip);
            }
            else if (entry.Lan is { } lan) {
                context.Text.Draw(T("lanServer.title"), x + 35, contentY + 1, 0xFFFFFFFF);
                context.Text.Draw(lan.Motd, x + 35, contentY + 12, 0xFF808080);
                context.Text.Draw(context.Settings is { HideServerAddress: true } ? T("selectServer.hiddenAddress") : lan.Address, x + 35, contentY + 23, 0xFF808080);
            }
            else {
                // LANHeader's LoadingDotsWidget, centred on the row.
                string scanning = T("lanServer.scanning");
                context.Text.DrawCentred(scanning, x + (RowWidth - 4) / 2.0F, contentY + 2);
                context.Text.DrawCentred(LoadingDots(Millis()), x + (RowWidth - 4) / 2.0F, contentY + 2 + 9 + 6, 0xFF808080);
            }
        }
        gui.DisableScissor();
        if (!context.Sprites.Stretched(gui, "gui/header_separator", 0, top - 2, width, 2, 0, 0, width / 32.0F, 1)) {
            gui.Rect(0, top - 2, width, 1, 0x40FFFFFF);
        }
        if (!context.Sprites.Stretched(gui, "gui/footer_separator", 0, bottom, width, 2, 0, 0, width / 32.0F, 1)) {
            gui.Rect(0, bottom + 1, width, 1, 0x40FFFFFF);
        }
        RenderScrollbar(context, rowLeft + RowWidth + 8, top, bottom - top);
        if (tooltip.Tooltip is { } single) {
            Inventory.Tooltips.Draw(context, [Menus.Runs(single)], MouseX, MouseY);
        }
        else if (tooltip.Players is { Count: > 0 } players) {
            Inventory.Tooltips.Draw(context, players.Select(p => Menus.Runs(p)).ToList(), MouseX, MouseY);
        }
    }

    /// <summary><c>AbstractScrollArea.extractScrollbar</c>, while there is anything to scroll.</summary>
    private void RenderScrollbar(GuiContext context, int x, int top, int height) {
        int max = MaxScroll(context.Height);
        if (max <= 0) {
            return;
        }
        int contentHeight = _entries.Count * ItemHeight + 4;
        int scrollerHeight = Math.Clamp((int)((float)(height * height) / contentHeight), 32, height - 8);
        int scrollerY = Math.Max(top, (int)_scroll * (height - scrollerHeight) / max + top);
        if (!context.Sprites.Sliced(context.Gui, "widget/scroller_background", x, top, 6, height, 1)) {
            context.Gui.Rect(x, top, 6, height, 0xFF000000);
        }
        if (!context.Sprites.Sprite(context.Gui, "widget/scroller", x, scrollerY, 6, scrollerHeight)) {
            context.Gui.Rect(x, scrollerY, 6, scrollerHeight, 0xFF808080);
            context.Gui.Rect(x, scrollerY, 5, scrollerHeight - 1, 0xFFC0C0C0);
        }
    }

    /// <summary><c>OnlineServerEntry.extractContent</c>.</summary>
    private void RenderServer(GuiContext context, Entry entry, int index, int x, int y, bool hovered,
        ref (TextComponent? Tooltip, IReadOnlyList<TextComponent>? Players) tooltip) {
        ServerData server = entry.Server!;
        if (server.State == ServerState.Initial) {
            StartPing(entry);
        }
        GuiRenderer gui = context.Gui;
        context.Text.Draw(server.Name, x + 35, y + 1, 0xFFFFFFFF);
        List<List<TextRun>> lines = context.Text.Wrap(Menus.Runs(server.Motd ?? TextComponent.Empty(), 0x808080), RowWidth - 4 - 32 - 2);
        for (int i = 0; i < Math.Min(lines.Count, 2); i++) {
            context.Text.Draw(lines[i], x + 35, y + 12 + 9 * i);
        }

        byte[]? icon = server.IconBytes;
        if (!(icon == null ? entry.LastIconBytes == null : entry.LastIconBytes != null && icon.AsSpan().SequenceEqual(entry.LastIconBytes))) {
            if (UploadIcon(entry, icon)) {
                entry.LastIconBytes = icon;
            }
            else {
                server.IconBytes = null;
                _servers.Save();
            }
        }
        if (entry.Icon != 0) {
            gui.Textured(entry.Icon, x, y, IconSize, IconSize, 0, 0, 1, 1);
        }
        else if (!context.Sprites.Stretched(gui, "misc/unknown_server", x, y, IconSize, IconSize, 0, 0, 1, 1)) {
            gui.Rect(x, y, IconSize, IconSize, 0xFF3A3A3A);
        }

        if (server.State == ServerState.Pinging) {
            entry.StatusIcon = PingingSprite(Millis(), index);
        }
        int statusIconX = x + RowWidth - 4 - 10 - 5;
        if (entry.StatusIcon != null && !context.Sprites.Sprite(gui, entry.StatusIcon, statusIconX, y, 10, 8)) {
            gui.Rect(statusIconX, y, 10, 8, server.State == ServerState.Successful ? 0xFF55FF55 : 0xFF808080);
        }
        TextComponent status = server.State == ServerState.Incompatible
            ? TextComponent.Empty().With(server.Version).WithColor(TextColor.Red)
            : server.Status ?? TextComponent.Empty();
        List<TextRun> statusRuns = Menus.Runs(status, 0x808080);
        int statusWidth = context.Text.Width(statusRuns);
        int statusX = statusIconX - statusWidth - 5;
        context.Text.Draw(statusRuns, statusX, y + 1);
        if (entry.StatusIconTooltip != null && MouseX >= statusIconX && MouseX <= statusIconX + 10 && MouseY >= y && MouseY <= y + 8) {
            tooltip = (entry.StatusIconTooltip, null);
        }
        else if (entry.OnlinePlayersTooltip != null && MouseX >= statusX && MouseX <= statusX + statusWidth && MouseY >= y && MouseY <= y - 1 + 9) {
            tooltip = (null, entry.OnlinePlayersTooltip);
        }

        if (hovered) {
            gui.Rect(x, y, IconSize, IconSize, 0xA0909090);
            int relX = (int)MouseX - x, relY = (int)MouseY - y;
            bool overJoin = relX >= IconSize / 2 && relX < IconSize && relY >= 0 && relY < IconSize;
            if (!context.Sprites.Sprite(gui, overJoin ? "server_list/join_highlighted" : "server_list/join", x, y, IconSize, IconSize)) {
                context.Text.DrawCentred(">", x + 24, y + 12, overJoin ? 0xFFFFFFFF : 0xFFA0A0A0);
            }
            if (index > 0) {
                bool overUp = relX >= 0 && relX < IconSize / 2 && relY >= 0 && relY < IconSize / 2;
                if (!context.Sprites.Sprite(gui, overUp ? "server_list/move_up_highlighted" : "server_list/move_up", x, y, IconSize, IconSize)) {
                    context.Text.DrawCentred("^", x + 8, y + 4, overUp ? 0xFFFFFFFF : 0xFFA0A0A0);
                }
            }
            if (index < _servers.Count - 1) {
                bool overDown = relX >= 0 && relX < IconSize / 2 && relY >= IconSize / 2 && relY < IconSize;
                if (!context.Sprites.Sprite(gui, overDown ? "server_list/move_down_highlighted" : "server_list/move_down", x, y, IconSize, IconSize)) {
                    context.Text.DrawCentred("v", x + 8, y + 20, overDown ? 0xFFFFFFFF : 0xFFA0A0A0);
                }
            }
        }
    }

    /// <summary><c>uploadServerIcon</c>: false for bytes that are not a picture, which vanilla then forgets.</summary>
    private bool UploadIcon(Entry entry, byte[]? bytes) {
        DeleteIcon(entry);
        if (bytes == null || _gl == null) {
            return bytes == null;
        }
        TextureImage image;
        try {
            image = Png.Decode(bytes);
        }
        catch (Exception e) when (e is InvalidDataException or IndexOutOfRangeException or ArgumentException) {
            Console.Error.WriteLine($"Invalid icon for server {entry.Server!.Name} ({entry.Server.Ip}): {e.Message}");
            return false;
        }
        // FaviconTexture.upload: a server icon is 64 square or nothing.
        if (image.Width != 64 || image.Height != 64) {
            Console.Error.WriteLine($"Invalid icon for server {entry.Server!.Name} ({entry.Server.Ip}): {image.Width}x{image.Height}");
            return false;
        }
        uint texture = _gl.GenTexture();
        _gl.BindTexture(TextureTarget.Texture2D, texture);
        unsafe {
            fixed (byte* p = image.Rgba) {
                _gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, 64, 64, 0, PixelFormat.Rgba, PixelType.UnsignedByte, p);
            }
        }
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        entry.Icon = texture;
        return true;
    }

    private void DeleteIcon(Entry entry) {
        if (entry.Icon != 0) {
            _gl?.DeleteTexture(entry.Icon);
            entry.Icon = 0;
        }
    }

    public override void MouseDown(GuiContext context, float x, float y, MouseButton button) {
        if (ClickWidgets(context, x, y, button) || button != MouseButton.Left) {
            return;
        }
        int width = context.Width, height = context.Height;
        int scrollbarX = RowLeft(width) + RowWidth + 8;
        if (MaxScroll(height) > 0 && x >= scrollbarX && x <= scrollbarX + 6 && y >= HeaderHeight && y < ListBottom(height)) {
            _scrolling = true;
            return;
        }
        if (y < HeaderHeight || y >= ListBottom(height)) {
            return;
        }
        for (int i = 0; i < _entries.Count; i++) {
            if (!Inside(x, y, RowLeft(width), RowTop(i), RowWidth, ItemHeight)) {
                continue;
            }
            Entry entry = _entries[i];
            long now = Millis();
            bool doubleClick = _lastClick is { } last && last.Entry == entry && now - last.Time < 250;
            _lastClick = (now, entry);
            if (EntryClicked(context, entry, i, (int)x - (RowLeft(width) + 2), (int)y - (RowTop(i) + 2), doubleClick)) {
                return;
            }
            SetSelected(entry);
            return;
        }
    }

    /// <summary><c>OnlineServerEntry.mouseClicked</c>: true when the click joined or moved, which leaves the selection be.</summary>
    private bool EntryClicked(GuiContext context, Entry entry, int index, int relX, int relY, bool doubleClick) {
        if (entry.Server != null) {
            if (relX >= IconSize / 2 && relX < IconSize && relY >= 0 && relY < IconSize) {
                SetSelected(entry);
                Join(context, entry);
                return true;
            }
            if (index > 0 && relX >= 0 && relX < IconSize / 2 && relY >= 0 && relY < IconSize / 2) {
                Swap(index, index - 1, context.Height);
                return true;
            }
            if (index < _servers.Count - 1 && relX >= 0 && relX < IconSize / 2 && relY >= IconSize / 2 && relY < IconSize) {
                Swap(index, index + 1, context.Height);
                return true;
            }
        }
        if (doubleClick && entry != _lanHeader) {
            SetSelected(entry);
            Join(context, entry);
            return true;
        }
        return false;
    }

    /// <summary><c>OnlineServerEntry.swap</c>: the file is saved, and the list follows the moved server.</summary>
    private void Swap(int from, int to, int height) {
        _servers.Swap(from, to);
        (_onlineServers[from], _onlineServers[to]) = (_onlineServers[to], _onlineServers[from]);
        RefreshEntries();
        ScrollTo(to, height);
    }

    public override void MouseMove(GuiContext context, float x, float y) {
        float dy = y - MouseY;
        base.MouseMove(context, x, y);
        if (_scrolling) {
            int height = ListBottom(context.Height) - HeaderHeight;
            int contentHeight = _entries.Count * ItemHeight + 4;
            int scrollerHeight = Math.Clamp((int)((float)(height * height) / contentHeight), 32, height - 8);
            double max = Math.Max(1, MaxScroll(context.Height));
            _scroll = Math.Clamp(_scroll + dy * Math.Max(1.0, max / (height - scrollerHeight)), 0, MaxScroll(context.Height));
        }
    }

    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        _scrolling = false;
        base.MouseUp(context, x, y, button);
    }

    public override void Scroll(GuiContext context, float delta) =>
        _scroll = Math.Clamp(_scroll - delta * (ItemHeight / 2), 0, MaxScroll(context.Height));

    public override void KeyDown(GuiContext context, Key key, bool control) {
        bool shift = Inventory.ContainerScreen.ShiftHeld();
        switch (key) {
            case Key.Escape:
                Close(context);
                return;
            case Key.F5:
                Refresh(context);
                return;
            case Key.Enter or Key.KeypadEnter or Key.Space when _selected != null:
                Join(context, _selected);
                return;
            case Key.Up or Key.Down:
                int index = _selected == null ? -1 : _entries.IndexOf(_selected);
                int delta = key == Key.Down ? 1 : -1;
                if (shift && _selected?.Server != null) {
                    if (key == Key.Down && index < _servers.Count - 1 || key == Key.Up && index > 0) {
                        Swap(index, index + delta, context.Height);
                    }
                    return;
                }
                int next = index < 0 ? delta > 0 ? 0 : _entries.Count - 1 : index + delta;
                if (next >= 0 && next < _entries.Count) {
                    SetSelected(_entries[next]);
                    ScrollTo(next, context.Height);
                }
                return;
        }
    }

    /// <summary><c>scrollToEntry</c>.</summary>
    private void ScrollTo(int index, int height) {
        int top = RowTop(index) - HeaderHeight - 2;
        if (top < 0) {
            _scroll += top;
        }
        int bottom = ListBottom(height) - RowTop(index) - ItemHeight - 2;
        if (bottom < 0) {
            _scroll -= bottom;
        }
        _scroll = Math.Clamp(_scroll, 0, MaxScroll(height));
    }
}

/// <summary><c>ManageServerScreen</c>: a server's name, address and resource pack policy, added or changed.</summary>
public sealed class ManageServerScreen(Screen lastScreen, string title, Action<bool> callback, ServerData serverData) : FocusScreen {
    private EditBox _nameEdit = null!, _ipEdit = null!;
    private Button _addButton = null!;

    public override bool ShowsHud => false;

    public override bool HasFocusedEditBox => true;

    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        string name = first ? serverData.Name : _nameEdit.Value, ip = first ? serverData.Ip : _ipEdit.Value;
        _nameEdit = AddChild(new EditBox(context.Text, width / 2 - 100, 66, 200, 20) { Value = name });
        _nameEdit.SetResponder(_ => UpdateAddButtonStatus());
        _ipEdit = AddChild(new EditBox(context.Text, width / 2 - 100, 106, 200, 20) { MaxLength = 128, Value = ip });
        _ipEdit.SetResponder(_ => UpdateAddButtonStatus());
        AddChild(new CycleButton<ServerPackStatus>([ServerPackStatus.Enabled, ServerPackStatus.Disabled, ServerPackStatus.Prompt], serverData.ResourcePackStatus,
            status => $"{Tr("manageServer.resourcePack")}: {Tr("manageServer.resourcePack." + status.ToString().ToLowerInvariant())}",
            width / 2.0F - 100, height / 4.0F + 72, 200, status => serverData.ResourcePackStatus = status));
        _addButton = AddChild(new Button(Tr("gui.done"), width / 2.0F - 100, height / 4.0F + 96 + 18, 200, OnAdd));
        AddChild(new Button(Tr("gui.cancel"), width / 2.0F - 100, height / 4.0F + 120 + 18, 200, () => callback(false)));
        SetFocus(_nameEdit);
        UpdateAddButtonStatus();
    }

    private void OnAdd() {
        string name = _nameEdit.Value;
        serverData.Name = name.Length == 0 ? Tr("selectServer.defaultName") : name;
        serverData.Ip = _ipEdit.Value;
        callback(true);
    }

    private void UpdateAddButtonStatus() {
        if (_addButton != null!) {
            _addButton.Active = ServerAddress.IsValidAddress(_ipEdit.Value);
        }
    }

    public override void Close(GuiContext context) => context.Open?.Invoke(lastScreen);

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        Menus.Background(context);
        int width = context.Width;
        RenderButtons(context);
        context.Text.DrawCentred(title, width / 2.0F, 17);
        context.Text.Draw(Tr("manageServer.enterName"), width / 2.0F - 100 + 1, 53, LabelColor);
        context.Text.Draw(Tr("manageServer.enterIp"), width / 2.0F - 100 + 1, 94, LabelColor);
        _nameEdit.Render(context);
        if (_nameEdit.Value.Length == 0 && !_nameEdit.Focused) {
            // setHint: the default name in grey where nothing is typed.
            context.Text.Draw(Tr("selectServer.defaultName"), _nameEdit.X + 4, _nameEdit.Y + (_nameEdit.Height - 8) / 2, 0xFF808080);
        }
        _ipEdit.Render(context);
    }
}

/// <summary><c>DirectJoinServerScreen</c>: an address to join once, remembered as the last one typed.</summary>
public sealed class DirectJoinServerScreen(Screen lastScreen, Action<bool> callback, ServerData serverData) : FocusScreen {
    private EditBox _ipEdit = null!;
    private Button _selectButton = null!;

    public override bool ShowsHud => false;

    public override bool HasFocusedEditBox => true;

    protected override void InitChildren(GuiContext context, int width, int height, bool first) {
        string ip = first ? context.Settings?.LastServer ?? "" : _ipEdit.Value;
        _ipEdit = AddChild(new EditBox(context.Text, width / 2 - 100, 116, 200, 20) { MaxLength = 128, Value = ip });
        _ipEdit.SetResponder(_ => UpdateSelectButtonStatus());
        _selectButton = AddChild(new Button(Tr("selectServer.select"), width / 2.0F - 100, height / 4.0F + 96 + 12, 200, OnSelect));
        AddChild(new Button(Tr("gui.cancel"), width / 2.0F - 100, height / 4.0F + 120 + 12, 200, () => callback(false)));
        SetFocus(_ipEdit);
        UpdateSelectButtonStatus();
    }

    private void OnSelect() {
        serverData.Ip = _ipEdit.Value;
        callback(true);
    }

    private void UpdateSelectButtonStatus() {
        if (_selectButton != null!) {
            _selectButton.Active = ServerAddress.IsValidAddress(_ipEdit.Value);
        }
    }

    public override void KeyDown(GuiContext context, Key key, bool control) {
        LayOut(context);
        if (_selectButton.Active && key is Key.Enter or Key.KeypadEnter) {
            OnSelect();
            return;
        }
        base.KeyDown(context, key, control);
    }

    public override void Close(GuiContext context) => context.Open?.Invoke(lastScreen);

    /// <summary><c>removed</c>: what was typed is kept as <c>lastServer</c>.</summary>
    public override void Removed(GuiContext context) {
        if (context.Settings is { } settings && _ipEdit != null!) {
            settings.LastServer = _ipEdit.Value;
            settings.Save();
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        LayOut(context);
        Menus.Background(context);
        int width = context.Width;
        RenderButtons(context);
        context.Text.DrawCentred(Tr("selectServer.direct"), width / 2.0F, 20);
        context.Text.Draw(Tr("manageServer.enterIp"), width / 2.0F - 100 + 1, 100, LabelColor);
        _ipEdit.Render(context);
    }
}
