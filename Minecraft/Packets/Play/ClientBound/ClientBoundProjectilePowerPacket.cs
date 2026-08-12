using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundProjectilePowerPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:projectile_power";

    public required int EntityId { get; init; }
    public required double AccelerationPower { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteDouble(AccelerationPower);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundProjectilePowerPacket {
        EntityId = r.ReadVarInt(),
        AccelerationPower = r.ReadDouble()
    };
}
