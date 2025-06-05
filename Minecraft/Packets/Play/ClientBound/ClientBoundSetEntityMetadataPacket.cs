using Minecraft.Schemas.Entities.Meta;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetEntityMetadataPacket(int entityId, EntityMeta meta) : MinecraftPacket {
    public int EntityId = entityId;
    public EntityMeta Meta = meta;

    public ClientBoundSetEntityMetadataPacket() : this(0, null!) { }
    
    public override int GetPacketId() {
        return 0x5C;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .Write(Meta.Serialise)
            .Write(0xFF)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        throw new NotImplementedException();
    }
}