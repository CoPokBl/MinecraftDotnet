using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntityAnimationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:animate";
    
    public required int EntityId;
    public required AnimationType Animation;

    public enum AnimationType {
        SwingMainArm = 0,
        LeaveBed = 2,
        SwingOffhand = 3,
        CriticalEffect = 4,
        MagicCriticalEffect = 5
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteUnsignedByte((byte)Animation);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundEntityAnimationPacket {
        EntityId = r.ReadVarInt(),
        Animation = (AnimationType)r.Read()
    };
}
