using Minecraft.NBT.Text;

namespace Minecraft.Packets.Login.ClientBound;

public class ClientBoundDisconnectPacket : ClientBoundPacket {
    public required TextComponent Reason;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteNbt(Reason)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundDisconnectPacket {
        Reason = r.ReadText()
    };
}
