using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBorderCenterPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_border_center";

    public required double X { get; init; }
    public required double Z { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteDouble(X)
            .WriteDouble(Z);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetBorderCenterPacket {
        X = r.ReadDouble(),
        Z = r.ReadDouble()
    };
}
