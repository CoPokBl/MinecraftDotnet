using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateTimePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_time";
    
    public required long WorldAge { get; init; }
    public required long TimeOfDay { get; init; }
    public required bool ClientAdvanceTime { get; init; }  // whether the client should advance time automatically
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteLong(WorldAge)
            .WriteLong(TimeOfDay)
            .WriteBoolean(ClientAdvanceTime);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateTimePacket {
        WorldAge = r.ReadLong(),
        TimeOfDay = r.ReadLong(),
        ClientAdvanceTime = r.ReadBoolean()
    };
}
