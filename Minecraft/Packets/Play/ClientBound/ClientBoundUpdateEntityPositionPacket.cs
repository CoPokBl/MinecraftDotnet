using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityPositionPacket(int entityId, SVec3 delta, bool onGround) : MinecraftPacket {
    public int EntityId = entityId;
    public SVec3 Delta = delta;
    public bool OnGround = onGround;
    
    public ClientBoundUpdateEntityPositionPacket() : this(0, SVec3.Zero, false) { }

    public override int GetPacketId() {
        return 0x2E;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteVec3(Delta)
            .WriteBoolean(OnGround)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        EntityId = r.ReadVarInt();
        Delta = r.ReadSVec3();
        OnGround = r.ReadBoolean();
        return this;
    }
}