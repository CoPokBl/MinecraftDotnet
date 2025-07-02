namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundClearTitlesPacket : ClientBoundPacket {
    public required bool Reset;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WriteBoolean(Reset)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundClearTitlesPacket {
        Reset = r.ReadBoolean()
    };
}
