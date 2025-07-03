using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBundleDelimiterPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:bundle_delimiter";

    protected override byte[] GetData() {
        return [];
    }

    public static PacketDataDeserialiser Deserialiser => (_, _) => new ClientBoundBundleDelimiterPacket();
}
