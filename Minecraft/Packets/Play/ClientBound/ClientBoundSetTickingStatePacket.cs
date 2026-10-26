using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetTickingStatePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:ticking_state";

    public required float TickRate { get; init; }
    public required bool IsFrozen { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(TickRate)
            .WriteBoolean(IsFrozen);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetTickingStatePacket {
        TickRate = r.ReadFloat(),
        IsFrozen = r.ReadBoolean()
    };
}
