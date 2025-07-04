using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundGameEventPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:game_event";
    
    public required GameEvent Event;
    public required float Value;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUnsignedByte((byte)Event)
            .WriteFloat(Value);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundGameEventPacket {
        Event = (GameEvent)r.Read(),
        Value = r.ReadFloat()
    };
}
