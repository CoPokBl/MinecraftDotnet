using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundInitialiseWorldBorderPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:initialize_border";
    
    public required double X;
    public required double Z;
    public required double OldDiameter;
    public required double NewDiameter;
    public required long Speed;
    public required int PortalTeleportBoundary;
    public required int WarningBlocks;
    public required int WarningTime;

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
