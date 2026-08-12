using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundAttackPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:attack";

    public required int EntityId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundAttackPacket {
        EntityId = r.ReadVarInt()
    };
}
