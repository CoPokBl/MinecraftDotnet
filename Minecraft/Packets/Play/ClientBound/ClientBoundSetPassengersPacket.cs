using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetPassengersPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_passengers";

    public required int VehicleEntityId { get; init; }
    public required int[] PassengerEntityIds { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(VehicleEntityId)
            .WritePrefixedArray(PassengerEntityIds, (id, writer) => writer.WriteVarInt(id));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetPassengersPacket {
        VehicleEntityId = r.ReadVarInt(),
        PassengerEntityIds = r.ReadPrefixedArray(reader => reader.ReadVarInt())
    };
}
