using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSpawnEntityPacket(
    int id, Guid uuid, int type, Vec3 position, Angle pitch, 
    Angle yaw, Angle headYaw, int data, SVec3 velocity) : MinecraftPacket {
    
    public int Id = id;
    public Guid Uuid = uuid;
    public int EntityType = type;
    public Vec3 Position = position;
    public Angle Pitch = pitch;
    public Angle Yaw = yaw;
    public Angle HeadYaw = headYaw;
    public int Data = data;
    public SVec3 Velocity = velocity;

    public ClientBoundSpawnEntityPacket() : 
        this(0, Guid.Empty, 0, Vec3.Zero, Angle.Zero, Angle.Zero, Angle.Zero, 0, SVec3.Zero) { }
    
    public override int GetPacketId() {
        return 0x01;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(Id)
            .WriteUuid(Uuid)
            .WriteVarInt(EntityType)
            .WriteVec3(Position)
            .WriteAngle(Pitch)
            .WriteAngle(Yaw)
            .WriteAngle(HeadYaw)
            .WriteVarInt(Data)
            .WriteVec3(Velocity)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Id = r.ReadVarInt();
        Uuid = r.ReadUuid();
        EntityType = r.ReadVarInt();
        Position = r.ReadVec3();
        Pitch = r.ReadAngle();
        Yaw = r.ReadAngle();
        HeadYaw = r.ReadAngle();
        Data = r.ReadVarInt();
        Velocity = r.ReadSVec3();
        return this;
    }
}