using Minecraft.Implementations.Client.Tools;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Schemas;

namespace ClientLib;

/// <summary>What the client tells the server about itself, and who it logs in as.</summary>
public sealed class ClientOptions {
    public string Username { get; set; } = "Player";

    /// <summary>
    /// The account to authenticate with. Null joins offline mode servers only, as vanilla's offline
    /// mode would, under <see cref="Username"/>.
    /// </summary>
    public MicrosoftAuthenticator.MinecraftProfile? Account { get; set; }

    /// <summary>The <c>minecraft:brand</c> sent after login. Vanilla sends <c>vanilla</c>, and some servers treat anything else as a modded client.</summary>
    public string Brand { get; set; } = "mcdotnet";

    public string Locale { get; set; } = "en_us";
    public int ViewDistance { get; set; } = 12;
    public ChatMode ChatMode { get; set; } = ChatMode.Enabled;
    public bool ChatColors { get; set; } = true;
    public SkinParts SkinParts { get; set; } = SkinParts.All;
    public DominantHand MainHand { get; set; } = DominantHand.Right;
    public bool TextFiltering { get; set; }

    /// <summary>
    /// Whether chat is signed when there is an account to sign with. Off, the client behaves as vanilla does
    /// without a chat session; see <see cref="MinecraftClient.SetChatSigning"/> for a change mid connection.
    /// </summary>
    public bool ChatSigning { get; set; } = true;

    /// <summary>The account's flags from the services; <see cref="Profiles.UserApiService.OfflineProperties"/> without an account.</summary>
    public Profiles.UserFlags UserFlags { get; set; } = Profiles.UserApiService.OfflineProperties;
    public bool AllowServerListing { get; set; } = true;
    public ParticleStatus Particles { get; set; } = ParticleStatus.All;

    /// <summary>The server's <c>ServerData.ServerPackStatus</c>: whether its resource packs are taken, refused or asked about.</summary>
    public Multiplayer.ServerPackStatus ServerPackStatus { get; set; } = Multiplayer.ServerPackStatus.Prompt;

    /// <summary>Where server resource packs are cached, vanilla's <c>downloads</c> folder.</summary>
    public string DownloadsDirectory { get; set; } =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mcdotnet-client", "downloads");

    /// <summary>Respawn as soon as the player is dead, for clients with nobody to press the button.</summary>
    public bool AutoRespawn { get; set; }

    public ServerBoundClientInformationPacket BuildInformation() {
        return new ServerBoundClientInformationPacket {
            Locale = Locale,
            ViewDistance = (byte)Math.Clamp(ViewDistance, 2, 32),
            TextChatMode = ChatMode,
            ChatColors = ChatColors,
            DisplayedSkinParts = SkinParts,
            MainHand = MainHand,
            EnableTextFiltering = TextFiltering,
            AllowServerListing = AllowServerListing,
            ParticleStatus = Particles
        };
    }

    /// <summary><c>ClientInformation.equals</c>, the record's fields.</summary>
    public static bool SameInformation(ServerBoundClientInformationPacket a, ServerBoundClientInformationPacket b) =>
        a.Locale == b.Locale && a.ViewDistance == b.ViewDistance && a.TextChatMode == b.TextChatMode && a.ChatColors == b.ChatColors &&
        a.DisplayedSkinParts == b.DisplayedSkinParts && a.MainHand == b.MainHand && a.EnableTextFiltering == b.EnableTextFiltering &&
        a.AllowServerListing == b.AllowServerListing && a.ParticleStatus == b.ParticleStatus;
}
