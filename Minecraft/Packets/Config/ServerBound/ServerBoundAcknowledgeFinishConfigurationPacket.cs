using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundAcknowledgeFinishConfigurationPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:finish_configuration";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundAcknowledgeFinishConfigurationPacket();
}
