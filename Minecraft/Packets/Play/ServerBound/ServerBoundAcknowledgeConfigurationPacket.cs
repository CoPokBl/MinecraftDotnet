using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundAcknowledgeConfigurationPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:configuration_acknowledged";
    
    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundAcknowledgeConfigurationPacket();
}
