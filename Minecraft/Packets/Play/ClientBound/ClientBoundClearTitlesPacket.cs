using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundClearTitlesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:clear_titles";
    
    public required bool Reset;
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteBoolean(Reset);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundClearTitlesPacket {
        Reset = r.ReadBoolean()
    };
}
