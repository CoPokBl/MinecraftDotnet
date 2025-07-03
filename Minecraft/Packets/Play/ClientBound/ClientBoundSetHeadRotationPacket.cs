using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHeadRotationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:rotate_head";
    
    public required int EntityId;
    public required Angle Yaw;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteAngle(Yaw)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetHeadRotationPacket {
        EntityId = r.ReadVarInt(),
        Yaw = r.ReadAngle()
    };
}
