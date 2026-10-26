using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBorderSizePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_border_size";

    public required double Diameter { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteDouble(Diameter);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetBorderSizePacket {
        Diameter = r.ReadDouble()
    };
}
