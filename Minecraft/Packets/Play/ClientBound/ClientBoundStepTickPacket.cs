using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Advances a frozen world by a number of ticks.</summary>
public class ClientBoundStepTickPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:ticking_step";

    public required int TickSteps { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(TickSteps);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundStepTickPacket {
        TickSteps = r.ReadVarInt()
    };
}
