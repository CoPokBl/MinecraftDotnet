using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundFeatureFlagsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_enabled_features";
    
    public required string[] Flags;
    
    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedArray(Flags, (s, wr) => wr.WriteString(s))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundFeatureFlagsPacket {
        Flags = r.ReadPrefixedArray(re => re.ReadString())
    };
}
