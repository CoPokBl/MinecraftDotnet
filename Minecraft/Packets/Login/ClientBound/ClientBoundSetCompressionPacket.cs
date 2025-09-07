using Minecraft.Schemas;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundSetCompressionPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:login_compression";
    
    public required int Threshold { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(Threshold);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetCompressionPacket {
        Threshold = r.ReadVarInt()
    };
}
