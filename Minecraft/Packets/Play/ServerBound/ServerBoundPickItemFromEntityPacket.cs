namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromEntityPacket : ServerBoundPacket {
    public required int EntityId;
    public required bool IncludeData;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteBoolean(IncludeData)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPickItemFromEntityPacket {
        EntityId = r.ReadVarInt(),
        IncludeData = r.ReadBoolean()
    };
}
