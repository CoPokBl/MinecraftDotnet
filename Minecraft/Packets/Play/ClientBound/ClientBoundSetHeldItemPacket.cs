namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetHeldItemPacket : ClientBoundPacket {
    public required int Slot;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(Slot)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSetHeldItemPacket {
        Slot = r.ReadVarInt()
    };
}
