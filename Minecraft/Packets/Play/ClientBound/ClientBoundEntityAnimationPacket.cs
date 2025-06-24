namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntityAnimationPacket : ClientBoundPacket {
    public required int EntityId;
    public required AnimationType Animation;

    public enum AnimationType {
        SwingMainArm = 0,
        LeaveBed = 2,
        SwingOffhand = 3,
        CriticalEffect = 4,
        MagicCriticalEffect = 5
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(EntityId)
            .WriteUnsignedByte((byte)Animation)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundEntityAnimationPacket {
        EntityId = r.ReadVarInt(),
        Animation = (AnimationType)r.Read()
    };
}
