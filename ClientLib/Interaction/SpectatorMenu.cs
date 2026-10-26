using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ClientLib.Interaction;

/// <summary>What a spectator menu slot draws; the renderer picks the sprite or face for it.</summary>
public enum SpectatorIcon {
    None,
    Close,
    ScrollLeft,
    ScrollRight,
    TeleportToPlayer,
    TeleportToTeam,
    Player,
    Team
}

/// <summary><c>SpectatorMenuItem</c>.</summary>
public interface ISpectatorMenuItem {
    void SelectItem(SpectatorMenu menu);
    TextComponent Name { get; }
    bool IsEnabled { get; }
    SpectatorIcon Icon { get; }
}

/// <summary><c>SpectatorMenuCategory</c>.</summary>
public interface ISpectatorMenuCategory {
    IReadOnlyList<ISpectatorMenuItem> Items { get; }
    TextComponent Prompt { get; }
}

/// <summary><c>SpectatorMenu</c>: nine hotbar slots over a category's items, six to a page past the first.</summary>
public sealed class SpectatorMenu {
    public static readonly ISpectatorMenuItem EmptySlot = new Item(TextComponent.Text(""), false, SpectatorIcon.None, _ => { });

    private static readonly ISpectatorMenuItem CloseItem =
        new Item(TextComponent.Translatable("spectatorMenu.close"), true, SpectatorIcon.Close, menu => menu.Exit());
    private static readonly ISpectatorMenuItem ScrollLeft = new ScrollMenuItem(-1, true);
    private static readonly ISpectatorMenuItem ScrollRightEnabled = new ScrollMenuItem(1, true);
    private static readonly ISpectatorMenuItem ScrollRightDisabled = new ScrollMenuItem(1, false);

    private readonly Action<SpectatorMenu> _onClosed;
    private int _page;

    public ISpectatorMenuCategory SelectedCategory { get; private set; }
    public int SelectedSlot { get; private set; } = -1;

    public SpectatorMenu(MinecraftClient client, Action<SpectatorMenu> onClosed) {
        SelectedCategory = new RootSpectatorMenuCategory(client);
        _onClosed = onClosed;
    }

    public ISpectatorMenuItem GetItem(int slot) {
        int index = slot + _page * 6;
        if (_page > 0 && slot == 0) {
            return ScrollLeft;
        }
        if (slot == 7) {
            return index < SelectedCategory.Items.Count ? ScrollRightEnabled : ScrollRightDisabled;
        }
        if (slot == 8) {
            return CloseItem;
        }
        return index >= 0 && index < SelectedCategory.Items.Count ? SelectedCategory.Items[index] : EmptySlot;
    }

    public ISpectatorMenuItem SelectedItem => GetItem(SelectedSlot);

    /// <summary>The first press of a slot selects it, the second uses it.</summary>
    public void SelectSlot(int slot) {
        ISpectatorMenuItem item = GetItem(slot);
        if (item == EmptySlot) {
            return;
        }
        if (SelectedSlot == slot && item.IsEnabled) {
            item.SelectItem(this);
        }
        else {
            SelectedSlot = slot;
        }
    }

    public void Exit() => _onClosed(this);

    public void SelectCategory(ISpectatorMenuCategory category) {
        SelectedCategory = category;
        SelectedSlot = -1;
        _page = 0;
    }

    private sealed class Item(TextComponent name, bool enabled, SpectatorIcon icon, Action<SpectatorMenu> select) : ISpectatorMenuItem {
        public TextComponent Name => name;
        public bool IsEnabled => enabled;
        public SpectatorIcon Icon => icon;
        public void SelectItem(SpectatorMenu menu) => select(menu);
    }

    private sealed class ScrollMenuItem(int direction, bool enabled) : ISpectatorMenuItem {
        public TextComponent Name => TextComponent.Translatable(direction < 0 ? "spectatorMenu.previous_page" : "spectatorMenu.next_page");
        public bool IsEnabled => enabled;
        public SpectatorIcon Icon => direction < 0 ? SpectatorIcon.ScrollLeft : SpectatorIcon.ScrollRight;
        public void SelectItem(SpectatorMenu menu) => menu._page += direction;
    }
}

/// <summary><c>RootSpectatorMenuCategory</c>.</summary>
public sealed class RootSpectatorMenuCategory(MinecraftClient client) : ISpectatorMenuCategory {
    public IReadOnlyList<ISpectatorMenuItem> Items { get; } = [new TeleportToPlayerMenuCategory(client), new TeleportToTeamMenuCategory(client)];
    public TextComponent Prompt => TextComponent.Translatable("spectatorMenu.root.prompt");
}

/// <summary><c>TeleportToPlayerMenuCategory</c>: every listed player not spectating, in UUID order.</summary>
public sealed class TeleportToPlayerMenuCategory : ISpectatorMenuCategory, ISpectatorMenuItem {
    public TeleportToPlayerMenuCategory(MinecraftClient client) : this(client, client.PlayerList.Values.Where(entry => entry.Listed)) {
    }

    public TeleportToPlayerMenuCategory(MinecraftClient client, IEnumerable<PlayerListEntry> profiles) {
        Items = profiles.Where(entry => entry.GameMode != GameMode.Spectator)
            .OrderBy(entry => entry.Uuid, JavaUuidOrder.Instance)
            .Select(ISpectatorMenuItem (entry) => new PlayerMenuItem(client, entry))
            .ToList();
    }

    public IReadOnlyList<ISpectatorMenuItem> Items { get; }
    public TextComponent Prompt => TextComponent.Translatable("spectatorMenu.teleport.prompt");
    public void SelectItem(SpectatorMenu menu) => menu.SelectCategory(this);
    public TextComponent Name => TextComponent.Translatable("spectatorMenu.teleport");
    public bool IsEnabled => Items.Count > 0;
    public SpectatorIcon Icon => SpectatorIcon.TeleportToPlayer;
}

/// <summary><c>PlayerMenuItem</c>: teleports to the player, by the server's <c>teleport_to_entity</c>.</summary>
public sealed class PlayerMenuItem(MinecraftClient client, PlayerListEntry player) : ISpectatorMenuItem {
    public PlayerListEntry Player => player;
    public TextComponent Name { get; } = TextComponent.Text(player.Name);
    public bool IsEnabled => player.GameMode != GameMode.Spectator;
    public SpectatorIcon Icon => SpectatorIcon.Player;

    public void SelectItem(SpectatorMenu menu) {
        if (IsEnabled) {
            client.Send(new ServerBoundTeleportToEntityPacket { TargetPlayer = player.Uuid });
        }
    }
}

/// <summary>
/// <c>TeleportToTeamMenuCategory</c>: each team with a player not spectating. Vanilla lists teams in its
/// hash map's order; these come in the order the server made them.
/// </summary>
public sealed class TeleportToTeamMenuCategory : ISpectatorMenuCategory, ISpectatorMenuItem {
    public TeleportToTeamMenuCategory(MinecraftClient client) {
        List<ISpectatorMenuItem> items = [];
        foreach (Team team in client.Scoreboard.Teams.Values) {
            List<PlayerListEntry> players = [];
            foreach (string name in team.Members) {
                PlayerListEntry? info = client.PlayerList.Values.FirstOrDefault(entry => entry.Name == name);
                if (info != null && info.GameMode != GameMode.Spectator) {
                    players.Add(info);
                }
            }
            if (players.Count > 0) {
                items.Add(new TeamSelectionItem(client, team, players, players[Random.Shared.Next(players.Count)]));
            }
        }
        Items = items;
    }

    public IReadOnlyList<ISpectatorMenuItem> Items { get; }
    public TextComponent Prompt => TextComponent.Translatable("spectatorMenu.team_teleport.prompt");
    public void SelectItem(SpectatorMenu menu) => menu.SelectCategory(this);
    public TextComponent Name => TextComponent.Translatable("spectatorMenu.team_teleport");
    public bool IsEnabled => Items.Count > 0;
    public SpectatorIcon Icon => SpectatorIcon.TeleportToTeam;

    public sealed class TeamSelectionItem(MinecraftClient client, Team team, List<PlayerListEntry> players, PlayerListEntry iconPlayer) : ISpectatorMenuItem {
        public Team Team => team;

        /// <summary>The member whose face stands for the team, picked once when the menu opens.</summary>
        public PlayerListEntry IconPlayer => iconPlayer;

        public TextComponent Name => team.DisplayName ?? TextComponent.Text(team.Name);
        public bool IsEnabled => true;
        public SpectatorIcon Icon => SpectatorIcon.Team;
        public void SelectItem(SpectatorMenu menu) => menu.SelectCategory(new TeleportToPlayerMenuCategory(client, players));
    }
}

/// <summary><c>UUID.compareTo</c>: the high then the low 64 bits, each as a signed long.</summary>
internal sealed class JavaUuidOrder : IComparer<Guid> {
    public static readonly JavaUuidOrder Instance = new();

    public int Compare(Guid a, Guid b) {
        (long aHigh, long aLow) = Halves(a);
        (long bHigh, long bLow) = Halves(b);
        int high = aHigh.CompareTo(bHigh);
        return high != 0 ? high : aLow.CompareTo(bLow);
    }

    private static (long High, long Low) Halves(Guid uuid) {
        Span<byte> bytes = stackalloc byte[16];
        uuid.TryWriteBytes(bytes, bigEndian: true, out _);
        return (System.Buffers.Binary.BinaryPrimitives.ReadInt64BigEndian(bytes), System.Buffers.Binary.BinaryPrimitives.ReadInt64BigEndian(bytes[8..]));
    }
}

/// <summary>
/// <c>SpectatorGui</c>'s state: the menu the number keys and the wheel drive in spectator mode, and how
/// long since a key was last pressed, which fades the bar out after five seconds and closes it after seven.
/// </summary>
public sealed class SpectatorGui(MinecraftClient client) {
    private long _lastSelectionTime;

    public SpectatorMenu? Menu { get; private set; }

    public bool IsMenuActive => Menu != null;

    public void OnHotbarSelected(int slot) {
        _lastSelectionTime = Environment.TickCount64;
        if (Menu != null) {
            Menu.SelectSlot(slot);
        }
        else {
            Menu = new SpectatorMenu(client, OnSpectatorMenuClosed);
        }
    }

    public float HotbarAlpha {
        get {
            long delta = _lastSelectionTime - Environment.TickCount64 + 5000L;
            return Math.Clamp(delta / 2000.0F, 0.0F, 1.0F);
        }
    }

    /// <summary>The <c>menu.exit()</c> in <c>extractHotbar</c>, once the bar has faded out.</summary>
    public void CloseIfFaded() {
        if (Menu != null && HotbarAlpha <= 0.0F) {
            Menu.Exit();
        }
    }

    private void OnSpectatorMenuClosed(SpectatorMenu menu) {
        Menu = null;
        _lastSelectionTime = 0L;
    }

    /// <summary><c>onMouseScrolled</c>: steps over empty and disabled slots, and stops at either end.</summary>
    public void OnMouseScrolled(int wheel) {
        int newSlot = Menu!.SelectedSlot + wheel;
        while (newSlot >= 0 && newSlot <= 8 && (Menu.GetItem(newSlot) == SpectatorMenu.EmptySlot || !Menu.GetItem(newSlot).IsEnabled)) {
            newSlot += wheel;
        }
        if (newSlot >= 0 && newSlot <= 8) {
            Menu.SelectSlot(newSlot);
            _lastSelectionTime = Environment.TickCount64;
        }
    }

    public void OnHotbarActionKeyPressed() {
        _lastSelectionTime = Environment.TickCount64;
        if (Menu != null) {
            int selectedSlot = Menu.SelectedSlot;
            if (selectedSlot != -1) {
                Menu.SelectSlot(selectedSlot);
            }
        }
        else {
            Menu = new SpectatorMenu(client, OnSpectatorMenuClosed);
        }
    }
}
