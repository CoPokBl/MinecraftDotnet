using ClientLib.Chat;
using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Text;
using PlayerData = Minecraft.Packets.Play.ClientBound.ClientBoundPlayerInfoUpdatePacket.PlayerData;

namespace ClientLib;

public sealed class PlayerListEntry(Guid uuid, string name, ProfileProperty[]? properties = null, bool enforcesSecureChat = false) {
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

    /// <summary><c>PlayerInfo.chatSession</c>: the session their messages are checked against, once validated.</summary>
    public RemoteChatSession? ChatSession { get; private set; }

    public SignedMessageValidator MessageValidator { get; private set; } = FallbackMessageValidator(enforcesSecureChat);

    public void SetChatSession(RemoteChatSession chatSession) {
        ChatSession = chatSession;
        MessageValidator = chatSession.CreateMessageValidator(ProfilePublicKey.ExpiryGracePeriod);
    }

    public void ClearChatSession(bool enforcesSecureChat) {
        ChatSession = null;
        MessageValidator = FallbackMessageValidator(enforcesSecureChat);
    }

    private static SignedMessageValidator FallbackMessageValidator(bool enforcesSecureChat) =>
        enforcesSecureChat ? SignedMessageValidator.RejectAll : SignedMessageValidator.AcceptUnsigned;
}

/// <summary>Chat, titles, the action bar, the tab list, boss bars and the scoreboard.</summary>
public sealed partial class MinecraftClient {
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

    private bool HandleHudPacket(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundSystemChatMessagePacket system:
                if (system.ActionBar) {
                    ChatListener.HandleOverlay(system.Content);
                }
                else {
                    ChatListener.HandleSystemMessage(system.Content, true);
                }
                return true;
            case ClientBoundPlayerChatMessagePacket chat:
                HandlePlayerChat(chat);
                return true;
            case ClientBoundDisguisedChatMessagePacket disguised:
                ChatListener.HandleDisguisedChatMessage(disguised.Message, disguised.ChatType);
                return true;
            case ClientBoundDeleteMessagePacket delete:
                HandleDeleteChat(delete);
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

    /// <summary><c>handlePlayerInfoUpdate</c>: a player already known keeps their entry when added again.</summary>
    private void HandlePlayerInfo(ClientBoundPlayerInfoUpdatePacket packet) {
        foreach ((Guid uuid, PlayerData.IPlayerAction[] actions) in packet.Data.Data) {
            if (actions.OfType<PlayerData.AddPlayer>().FirstOrDefault() is { } add) {
                PlayerList.TryAdd(uuid, new PlayerListEntry(uuid, add.Name, add.Properties, EnforcesSecureChat));
            }
        }
        foreach ((Guid uuid, PlayerData.IPlayerAction[] actions) in packet.Data.Data) {
            if (!PlayerList.TryGetValue(uuid, out PlayerListEntry? entry)) {
                continue;
            }
            foreach (PlayerData.IPlayerAction action in actions) {
                switch (action) {
                    case PlayerData.InitializeChat chat:
                        InitializeChatSession(chat, entry);
                        break;
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

    internal void SetActionBar(TextComponent text) {
        ActionBar = text;
        ActionBarTime = 60;
    }
}
