using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundHurtAnimationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:hurt_animation";
    
    public required int EntityId { get; init; }
    public required Angle Yaw { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteFloat((float)Yaw.Degrees);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundHurtAnimationPacket {
        EntityId = r.ReadVarInt(),
        Yaw = Angle.FromDegrees(r.ReadFloat())
    };
}
