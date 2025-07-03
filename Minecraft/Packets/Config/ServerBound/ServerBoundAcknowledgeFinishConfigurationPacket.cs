using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundAcknowledgeFinishConfigurationPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:finish_configuration";

    protected override byte[] GetData() {
        return [];
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundAcknowledgeFinishConfigurationPacket();
}
