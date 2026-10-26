using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetSimulationDistancePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_simulation_distance";

    /// <summary>Distance in chunks that the client should simulate entities within.</summary>
    public required int SimulationDistance { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(SimulationDistance);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetSimulationDistancePacket {
        SimulationDistance = r.ReadVarInt()
    };
}
