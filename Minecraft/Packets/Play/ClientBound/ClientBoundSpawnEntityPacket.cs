using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSpawnEntityPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:add_entity";
    
    public required int Id;
    public required Guid Uuid;
    public required int EntityType;
    public required Vec3 Position;
    public required Angle Pitch;
    public required Angle Yaw;
    public required Angle HeadYaw;
    public required int Data;
    public required SVec3 Velocity;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(Id)
            .WriteUuid(Uuid)
            .WriteVarInt(EntityType)
            .WriteVec3(Position)
            .WriteAngle(Pitch)
            .WriteAngle(Yaw)
            .WriteAngle(HeadYaw)
            .WriteVarInt(Data)
            .WriteVec3(Velocity);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSpawnEntityPacket {
        Id = r.ReadVarInt(),
        Uuid = r.ReadUuid(),
        EntityType = r.ReadVarInt(),
        Position = r.ReadVec3(),
        Pitch = r.ReadAngle(),
        Yaw = r.ReadAngle(),
        HeadYaw = r.ReadAngle(),
        Data = r.ReadVarInt(),
        Velocity = r.ReadSVec3()
    };
}
