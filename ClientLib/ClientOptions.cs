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
    public bool AllowServerListing { get; set; } = true;
    public ParticleStatus Particles { get; set; } = ParticleStatus.All;

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
}
