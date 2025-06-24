namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundSetCompressionPacket : ClientBoundPacket {
    public required int Threshold;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(Threshold)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundSetCompressionPacket {
        Threshold = r.ReadVarInt()
    };
}
