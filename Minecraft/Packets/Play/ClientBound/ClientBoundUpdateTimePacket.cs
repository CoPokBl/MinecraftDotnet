namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateTimePacket : ClientBoundPacket {
    public required long WorldAge;
    public required long TimeOfDay;
    public required bool ClientAdvanceTime;  // whether the client should advance time automatically
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteLong(WorldAge)
            .WriteLong(TimeOfDay)
            .WriteBoolean(ClientAdvanceTime)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateTimePacket {
        WorldAge = r.ReadLong(),
        TimeOfDay = r.ReadLong(),
        ClientAdvanceTime = r.ReadBoolean()
    };
}
