using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundStartConfigurationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:start_configuration";
    
    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundStartConfigurationPacket();
}
