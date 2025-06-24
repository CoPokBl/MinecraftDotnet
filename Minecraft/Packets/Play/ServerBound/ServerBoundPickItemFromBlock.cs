using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromBlock : ServerBoundPacket {
    public required BlockPosition Location;
    public required bool IncludeData;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteBoolean(IncludeData)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPickItemFromBlock {
        Location = r.ReadPosition(),
        IncludeData = r.ReadBoolean()
    };
}
