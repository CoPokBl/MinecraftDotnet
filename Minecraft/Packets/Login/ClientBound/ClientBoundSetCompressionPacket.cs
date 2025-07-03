using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundSetCompressionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login_compression";
    
    public required int Threshold;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteVarInt(Threshold)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetCompressionPacket {
        Threshold = r.ReadVarInt()
    };
}
