namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundAcknowledgeBlockChangePacket : ClientBoundPacket {
    public required int SequenceId;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(SequenceId)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundAcknowledgeBlockChangePacket {
        SequenceId = r.ReadVarInt()
    };
}
