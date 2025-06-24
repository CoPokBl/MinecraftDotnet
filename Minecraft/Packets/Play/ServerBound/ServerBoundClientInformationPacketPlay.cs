using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundClientInformationPacketPlay : ServerBoundPacket {
    public required ParticleStatus ParticleStatus;
    public required bool AllowServerListing;
    public required bool EnableTextFiltering;
    public required DominantHand MainHand;
    public required SkinParts DisplayedSkinParts;
    public required bool ChatColors;
    public required ChatMode TextChatMode;
    public required byte ViewDistance;
    public required string Locale;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(Locale)
            .WriteByte(ViewDistance)
            .WriteVarInt((int)TextChatMode)
            .WriteBoolean(ChatColors)
            .WriteUnsignedByte((byte)DisplayedSkinParts)
            .WriteVarInt((int)MainHand)
            .WriteBoolean(EnableTextFiltering)
            .WriteBoolean(AllowServerListing)
            .WriteVarInt((int)ParticleStatus)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundClientInformationPacketPlay {
        Locale = r.ReadString(),
        ViewDistance = (byte)r.ReadByte(),
        TextChatMode = (ChatMode)r.ReadVarInt(),
        ChatColors = r.ReadBoolean(),
        DisplayedSkinParts = (SkinParts)r.Read(),
        MainHand = (DominantHand)r.ReadVarInt(),
        EnableTextFiltering = r.ReadBoolean(),
        AllowServerListing = r.ReadBoolean(),
        ParticleStatus = (ParticleStatus)r.ReadVarInt()
    };
}