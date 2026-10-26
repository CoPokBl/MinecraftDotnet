using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBorderWarningDistancePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_border_warning_distance";

    /// <summary>Distance from the border at which the warning shows.</summary>
    public required int WarningBlocks { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(WarningBlocks);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetBorderWarningDistancePacket {
        WarningBlocks = r.ReadVarInt()
    };
}
