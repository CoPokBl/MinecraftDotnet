using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundFinishConfigurationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:finish_configuration";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundFinishConfigurationPacket();
}
