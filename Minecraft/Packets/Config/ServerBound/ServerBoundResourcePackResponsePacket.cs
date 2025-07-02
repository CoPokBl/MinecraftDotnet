namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundResourcePackResponsePacket : ServerBoundPacket {
    public required Guid PackId;
    public required PackResponse Result;
    
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

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUuid(PackId)
            .WriteVarInt((int)Result)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundResourcePackResponsePacket {
        PackId = r.ReadUuid(),
        Result = (PackResponse)r.ReadVarInt()
    };
}
