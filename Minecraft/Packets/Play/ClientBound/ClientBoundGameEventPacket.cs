using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundGameEventPacket : ClientBoundPacket {
    public required GameEvent Event;
    public required float Value;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUnsignedByte((byte)Event)
            .WriteFloat(Value)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundGameEventPacket {
        Event = (GameEvent)r.Read(),
        Value = r.ReadFloat()
    };
}
