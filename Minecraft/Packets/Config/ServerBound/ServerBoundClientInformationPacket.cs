using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundClientInformationPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:client_information";
    
    public required ParticleStatus ParticleStatus { get; init; }
    public required bool AllowServerListing { get; init; }
    public required bool EnableTextFiltering { get; init; }
    public required DominantHand MainHand { get; init; }
    public required SkinParts DisplayedSkinParts { get; init; }
    public required bool ChatColors { get; init; }
    public required ChatMode TextChatMode { get; init; }
    public required byte ViewDistance { get; init; }
    public required string Locale { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteString(Locale)
            .WriteByte(ViewDistance)
            .WriteVarInt((int)TextChatMode)
            .WriteBoolean(ChatColors)
            .WriteUnsignedByte((byte)DisplayedSkinParts)
            .WriteVarInt((int)MainHand)
            .WriteBoolean(EnableTextFiltering)
            .WriteBoolean(AllowServerListing)
            .WriteVarInt((int)ParticleStatus);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundClientInformationPacket {
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