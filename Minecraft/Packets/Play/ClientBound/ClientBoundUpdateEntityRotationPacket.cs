using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateEntityRotationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:move_entity_rot";
    
    public required int EntityId;
    public required Angle Yaw;
    public required Angle Pitch;
    public required bool OnGround;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteAngle(Yaw)
            .WriteAngle(Pitch)
            .WriteBoolean(OnGround);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateEntityRotationPacket {
        EntityId = r.ReadVarInt(),
        Yaw = r.ReadAngle(),
        Pitch = r.ReadAngle(),
        OnGround = r.ReadBoolean()
    };
}
