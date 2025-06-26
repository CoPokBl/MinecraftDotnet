using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundPickItemFromBlockPacket : ServerBoundPacket {
    public required BlockPosition Location;
    public required bool IncludeData;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePosition(Location)
            .WriteBoolean(IncludeData)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ServerBoundPickItemFromBlockPacket {
        Location = r.ReadPosition(),
        IncludeData = r.ReadBoolean()
    };
}
