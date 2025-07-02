using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundHurtAnimationPacket : ClientBoundPacket {
    public required int EntityId;
    public required Angle Yaw;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteFloat((float)Yaw.Degrees)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundHurtAnimationPacket {
        EntityId = r.ReadVarInt(),
        Yaw = Angle.FromDegrees(r.ReadFloat())
    };
}
