using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Text;
using PlayerData = Minecraft.Packets.Play.ClientBound.ClientBoundPlayerInfoUpdatePacket.PlayerData;

namespace ClientLib;

public sealed record ChatLine(TextComponent Message, DateTime Received, int AddedTick);

public sealed class PlayerListEntry(Guid uuid, string name, ProfileProperty[]? properties = null) {
    public Guid Uuid { get; } = uuid;
    public string Name { get; } = name;

    /// <summary>The game profile's properties, its <c>textures</c> among them.</summary>
    public ProfileProperty[] Properties { get; } = properties ?? [];
    public GameMode GameMode { get; set; } = GameMode.Survival;
    public int Latency { get; set; }
    public bool Listed { get; set; }
    public TextComponent? DisplayName { get; set; }
    public int ListOrder { get; set; }
    public bool ShowHat { get; set; } = true;
}

/// <summary>Chat, titles, the action bar, the tab list, boss bars and the scoreboard.</summary>
public sealed partial class MinecraftClient {
    public List<ChatLine> Chat { get; } = [];
    public Dictionary<Guid, PlayerListEntry> PlayerList { get; } = new();
    public BossHealthOverlay BossOverlay { get; } = new();
    public Scoreboard Scoreboard { get; } = new();

    /// <summary><c>Entity.getTeam</c>: a player's team by its profile name, anything else's by its UUID.</summary>
    public Team? TeamOf(ClientEntity entity) =>
        Scoreboard.TeamOf(entity.Is(EntityClass.Player) && PlayerList.TryGetValue(entity.Uuid, out PlayerListEntry? entry) ? entry.Name : entity.Uuid.ToString());

    /// <summary><c>Entity.getTeamColor</c>, with <c>Display</c>'s glow colour override: white without a coloured team.</summary>
    public int TeamColour(ClientEntity entity) {
        if (entity.Is(EntityClass.Display) && entity.Get(EntityDataFields.Display.GlowColorOverride, -1) is var glow and not -1) {
            return glow;
        }
        return TeamOf(entity)?.Rgb ?? 0xFFFFFF;
    }

    public TextComponent? TabHeader { get; private set; }
    public TextComponent? TabFooter { get; private set; }
    public TextComponent? ActionBar { get; private set; }
    public int ActionBarTime { get; private set; }
    public TextComponent? Title { get; private set; }
    public TextComponent? Subtitle { get; private set; }
    public int TitleTime { get; private set; }
    public (int FadeIn, int Stay, int FadeOut) TitleTimes { get; private set; } = (10, 70, 20);

    public event Action<ChatLine>? ChatReceived;

    private bool HandleHudPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundSystemChatMessagePacket system:
                if (system.ActionBar) {
                    SetActionBar(system.Content);
                }
                else {
                    AddChat(system.Content);
                }
                return true;
            case ClientBoundPlayerChatMessagePacket chat:
                AddChat(ChatDecoration.Decorate(Registry, chat.ChatType, chat.UnsignedContent ?? TextComponent.Text(chat.Content)));
                return true;
            case ClientBoundDisguisedChatMessagePacket disguised:
                AddChat(ChatDecoration.Decorate(Registry, disguised.ChatType, disguised.Message));
                return true;
            case ClientBoundSetActionBarTextPacket actionBar:
                SetActionBar(actionBar.Text);
                return true;
            case ClientBoundSetTitleTextPacket title:
                Title = title.Text;
                TitleTime = TitleTimes.FadeIn + TitleTimes.Stay + TitleTimes.FadeOut;
                return true;
            case ClientBoundSetSubtitleTextPacket subtitle:
                Subtitle = subtitle.Text;
                return true;
            case ClientBoundSetTitleAnimationTimesPacket times:
                TitleTimes = (times.FadeIn, times.Stay, times.FadeOut);
                return true;
            case ClientBoundClearTitlesPacket:
                Title = null;
                Subtitle = null;
                TitleTime = 0;
                return true;
            case ClientBoundPlayerInfoUpdatePacket info:
                HandlePlayerInfo(info);
                return true;
            case ClientBoundPlayerInfoRemovePacket infoRemove:
                foreach (Guid uuid in infoRemove.Uuids) {
                    PlayerList.Remove(uuid);
                }
                return true;
            case ClientBoundSetTabListHeaderFooterPacket tab:
                TabHeader = tab.Header;
                TabFooter = tab.Footer;
                return true;
            case ClientBoundBossBarPacket boss:
                BossOverlay.Update(boss);
                return true;
            case ClientBoundUpdateObjectivePacket or ClientBoundUpdateScorePacket or ClientBoundResetScorePacket
                or ClientBoundDisplayObjectivePacket or ClientBoundUpdateTeamsPacket:
                Scoreboard.Handle(packet);
                return true;
            default:
                return false;
        }
    }

    private void HandlePlayerInfo(ClientBoundPlayerInfoUpdatePacket packet) {
        foreach ((Guid uuid, PlayerData.IPlayerAction[] actions) in packet.Data.Data) {
            foreach (PlayerData.IPlayerAction action in actions) {
                if (action is PlayerData.AddPlayer add) {
                    PlayerList[uuid] = new PlayerListEntry(uuid, add.Name, add.Properties);
                    continue;
                }
                if (!PlayerList.TryGetValue(uuid, out PlayerListEntry? entry)) {
                    continue;
                }
                switch (action) {
                    case PlayerData.UpdateGameMode gameMode:
                        entry.GameMode = gameMode.GameMode;
                        break;
                    case PlayerData.UpdateListed listed:
                        entry.Listed = listed.Listed;
                        break;
                    case PlayerData.UpdateLatency latency:
                        entry.Latency = latency.Latency;
                        break;
                    case PlayerData.UpdateDisplayName displayName:
                        entry.DisplayName = displayName.DisplayName;
                        break;
                    case PlayerData.UpdateListPriority priority:
                        entry.ListOrder = priority.Priority;
                        break;
                    case PlayerData.UpdateHat hat:
                        entry.ShowHat = hat.Visible;
                        break;
                }
            }
        }
    }

    private void SetActionBar(TextComponent text) {
        ActionBar = text;
        ActionBarTime = 60;
    }

    private void AddChat(TextComponent message) {
        ChatLine line = new(message, DateTime.Now, (int)ClientTicks);
        Chat.Add(line);
        if (Chat.Count > 100) {
            Chat.RemoveAt(0);
        }
        Info($"[chat] {TextFlattener.Plain(message)}");
        ChatReceived?.Invoke(line);
    }

    /// <summary>Sends a chat line, or a command when it starts with a slash, as an unsigned message.</summary>
    public void SendChat(string message) {
        message = message.Trim();
        if (message.Length == 0) {
            return;
        }
        if (message.StartsWith('/')) {
            // Vanilla signs a command whose parse has a message argument. This client has no chat session
            // to sign with, so a server enforcing secure chat rejects such a command.
            Send(new ServerBoundChatCommandPacket { Command = message[1..] });
            return;
        }
        Send(new ServerBoundChatMessagePacket {
            Message = message.Length > 256 ? message[..256] : message,
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            Salt = 0,
            Signature = null,
            MessageCount = 0,
            Acknowledged = new byte[3],
            Checksum = 0
        });
    }
}
