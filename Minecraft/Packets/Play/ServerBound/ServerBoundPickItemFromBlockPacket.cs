using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromBlockPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:pick_item_from_block";
    
    public required BlockPosition Location;
    public required bool IncludeData;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteBoolean(IncludeData);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPickItemFromBlockPacket {
        Location = r.ReadPosition(),
        IncludeData = r.ReadBoolean()
    };
}
