using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundFeatureFlagsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_enabled_features";
    
    public required Identifier[] Flags;
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePrefixedArray(Flags, (s, wr) => wr.WriteString(s));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundFeatureFlagsPacket {
        Flags = r.ReadPrefixedArray(re => (Identifier)re.ReadString())
    };
}
