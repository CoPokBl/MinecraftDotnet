using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundStartConfigurationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:start_configuration";
    
    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundStartConfigurationPacket();
}
