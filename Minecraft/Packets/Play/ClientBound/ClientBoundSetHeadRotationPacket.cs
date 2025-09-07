using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHeadRotationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:rotate_head";
    
    public required int EntityId { get; init; }
    public required Angle Yaw { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteAngle(Yaw);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetHeadRotationPacket {
        EntityId = r.ReadVarInt(),
        Yaw = r.ReadAngle()
    };
}
