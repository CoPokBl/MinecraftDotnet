using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace ClientLib.Advancements;

/// <summary><c>ClientAdvancements.Listener</c>: the advancement screen while it is open.</summary>
public interface IClientAdvancementsListener : IAdvancementTreeListener {
    void OnUpdateAdvancementProgress(AdvancementNode advancement, AdvancementProgress progress);
    void OnSelectedTabChanged(AdvancementNode? selectedTab);
}

/// <summary>
/// <c>ClientAdvancements</c>: the advancements the server has sent, their progress, and the tab the screen
/// shows. One lives as long as the play phase it was made in, as vanilla's belongs to the packet listener.
/// </summary>
public sealed class ClientAdvancements {
    private readonly Action<MinecraftPacket> _send;
    private readonly Action<AdvancementNode> _toast;
    private readonly Dictionary<Identifier, AdvancementProgress> _progress = new();
    private IClientAdvancementsListener? _listener;

    /// <param name="send">Sends to the server, doing nothing when there is no connection.</param>
    /// <param name="toast">Shows the toast for an advancement just completed.</param>
    public ClientAdvancements(Action<MinecraftPacket> send, Action<AdvancementNode> toast) {
        _send = send;
        _toast = toast;
    }

    public AdvancementTree Tree { get; } = new();

    public AdvancementNode? SelectedTab { get; private set; }

    public AdvancementProgress? ProgressOf(Identifier id) => _progress.GetValueOrDefault(id);

    public event Action<string>? Log {
        add => Tree.Log += value;
        remove => Tree.Log -= value;
    }

    /// <summary>
    /// <c>update</c>. A completed advancement toasts whenever its progress comes in done outside a reset, so a
    /// server resending done progress toasts again, as it does in vanilla.
    /// </summary>
    public void Update(ClientBoundUpdateAdvancementsPacket packet) {
        if (packet.Reset) {
            Tree.Clear();
            _progress.Clear();
        }
        Tree.Remove(packet.Removed);
        Tree.AddAll(packet.Added);
        foreach ((Identifier id, Dictionary<string, DateTimeOffset?> criteria) in packet.Progress) {
            if (Tree.Get(id) is not { } node) {
                continue;
            }
            AdvancementProgress progress = new(new Dictionary<string, DateTimeOffset?>(criteria));
            progress.Update(node.Advancement.Requirements);
            _progress[id] = progress;
            _listener?.OnUpdateAdvancementProgress(node, progress);
            if (!packet.Reset && progress.IsDone && packet.ShowAdvancements && node.Display is { ShowToast: true }) {
                _toast(node);
            }
        }
    }

    /// <summary>
    /// <c>setSelectedTab</c>. Telling the server sends <c>opened_tab</c> even when the tab is already the
    /// selected one, which is what opening the screen does every time.
    /// </summary>
    public void SetSelectedTab(AdvancementNode? selectedTab, bool tellServer) {
        if (selectedTab != null && tellServer) {
            _send(ServerBoundSeenAdvancementsPacket.OpenedTab(selectedTab.Id));
        }
        if (SelectedTab != selectedTab) {
            SelectedTab = selectedTab;
            _listener?.OnSelectedTabChanged(selectedTab);
        }
    }

    /// <summary><c>handleSelectAdvancementsTab</c>: the server's choice, which it is not told back.</summary>
    public void HandleSelectTab(ClientBoundSelectAdvancementsTabPacket packet) =>
        SetSelectedTab(packet.Tab is { } id ? Tree.Get(id) : null, false);

    /// <summary><c>setListener</c>: a new listener hears the whole tree, every advancement's progress, then the selected tab.</summary>
    public void SetListener(IClientAdvancementsListener? listener) {
        _listener = listener;
        Tree.SetListener(listener);
        if (listener == null) {
            return;
        }
        foreach ((Identifier id, AdvancementProgress progress) in _progress) {
            if (Tree.Get(id) is { } node) {
                listener.OnUpdateAdvancementProgress(node, progress);
            }
        }
        listener.OnSelectedTabChanged(SelectedTab);
    }

    /// <summary><c>removed</c> on the advancement screen: the server stops thinking a tab is being looked at.</summary>
    public void ScreenClosed() => _send(ServerBoundSeenAdvancementsPacket.ClosedScreen());
}
