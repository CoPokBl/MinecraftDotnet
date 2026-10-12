using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetBorderLerpSizePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_border_lerp_size";

    public required double OldDiameter { get; init; }
    public required double NewDiameter { get; init; }

    /// <summary>Ticks the border takes to grow or shrink to the new diameter.</summary>
    public required long Speed { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteDouble(OldDiameter)
            .WriteDouble(NewDiameter)
            .WriteVarLong(Speed);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetBorderLerpSizePacket {
        OldDiameter = r.ReadDouble(),
        NewDiameter = r.ReadDouble(),
        Speed = r.ReadVarLong()
    };
}
