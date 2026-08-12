using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBorderWarningDelayPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_border_warning_delay";

    /// <summary>Seconds before the border reaches the player at which the warning shows.</summary>
    public required int WarningTime { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(WarningTime);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetBorderWarningDelayPacket {
        WarningTime = r.ReadVarInt()
    };
}
