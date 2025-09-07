using Minecraft.Data.Entities;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSpawnEntityPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:add_entity";
    
    public required int Id { get; init; }
    public required Guid Uuid { get; init; }
    public required IEntityType EntityType { get; init; }
    public required Vec3<double> Position { get; init; }
    public required Angle Pitch { get; init; }
    public required Angle Yaw { get; init; }
    public required Angle HeadYaw { get; init; }
    public required int Data { get; init; }
    public required Vec3<short> Velocity { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(Id)
            .WriteUuid(Uuid)
            .WriteVarInt(EntityType.ProtocolId)
            .WriteVec3(Position)
            .WriteAngle(Pitch)
            .WriteAngle(Yaw)
            .WriteAngle(HeadYaw)
            .WriteVarInt(Data)
            .WriteVec3(Velocity);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundSpawnEntityPacket {
        Id = r.ReadVarInt(),
        Uuid = r.ReadUuid(),
        EntityType = reg.EntityTypes[r.ReadVarInt()],
        Position = r.ReadVec3(),
        Pitch = r.ReadAngle(),
        Yaw = r.ReadAngle(),
        HeadYaw = r.ReadAngle(),
        Data = r.ReadVarInt(),
        Velocity = r.ReadSVec3()
    };
}
