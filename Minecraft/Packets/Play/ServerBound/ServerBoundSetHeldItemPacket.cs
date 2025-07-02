namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetHeldItemPacket : ServerBoundPacket {
    public required short Slot;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUShort((ushort)Slot)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetHeldItemPacket {
        Slot = (short)r.ReadUShort()
    };
}
