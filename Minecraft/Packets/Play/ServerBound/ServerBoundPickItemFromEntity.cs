namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromEntity(int entityId, bool includeData) : MinecraftPacket {
    public int EntityId = entityId;
    public bool IncludeData = includeData;
    
    public ServerBoundPickItemFromEntity() : this(0, false) { }

    public override int GetPacketId() {
        return 0x23;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteBoolean(IncludeData)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        IncludeData = r.ReadBoolean();
        return this;
    }
}