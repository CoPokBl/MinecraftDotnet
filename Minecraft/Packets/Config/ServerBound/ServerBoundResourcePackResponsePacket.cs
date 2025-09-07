using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundResourcePackResponsePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:resource_pack";
    
    public required Guid PackId { get; init; }
    public required PackResponse Result { get; init; }
    
    public enum PackResponse {
        SuccessfulDownload = 0,
        Declined = 1,
        FailedDownload = 2,
        Accepted = 3,
        Downloaded = 4,
        InvalidUrl = 5,
        FailedToReload = 6,
        Discarded = 7
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUuid(PackId)
            .WriteVarInt((int)Result);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundResourcePackResponsePacket {
        PackId = r.ReadUuid(),
        Result = (PackResponse)r.ReadVarInt()
    };
}
