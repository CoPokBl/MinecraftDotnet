using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundInitialiseWorldBorderPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:initialize_border";
    
    public required double X { get; init; }
    public required double Z { get; init; }
    public required double OldDiameter { get; init; }
    public required double NewDiameter { get; init; }
    public required long Speed { get; init; }
    public required int PortalTeleportBoundary { get; init; }
    public required int WarningBlocks { get; init; }
    public required int WarningTime { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteDouble(X)
            .WriteDouble(Z)
            .WriteDouble(OldDiameter)
            .WriteDouble(NewDiameter)
            .WriteVarLong(Speed)
            .WriteVarInt(PortalTeleportBoundary)
            .WriteVarInt(WarningBlocks)
            .WriteVarInt(WarningTime);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundInitialiseWorldBorderPacket {
        X = r.ReadDouble(),
        Z = r.ReadDouble(),
        OldDiameter = r.ReadDouble(),
        NewDiameter = r.ReadDouble(),
        Speed = r.ReadVarLong(),
        PortalTeleportBoundary = r.ReadVarInt(),
        WarningBlocks = r.ReadVarInt(),
        WarningTime = r.ReadVarInt()
    };
}
