using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntityAnimationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:animate";
    
    public required int EntityId { get; init; }
    public required AnimationType Animation { get; init; }

    /// <summary>Swings are not among these: they travel as <see cref="ClientBoundSwingAnimationPacket"/>.</summary>
    public enum AnimationType {
        LeaveBed = 0,
        CriticalEffect = 1,
        MagicCriticalEffect = 2
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
