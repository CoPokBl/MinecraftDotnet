using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundRemoveEntitiesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:remove_entities";
    
    public required int[] Entities { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedArray(Entities, (i, writer) => writer.WriteVarInt(i));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundRemoveEntitiesPacket {
        Entities = r.ReadPrefixedArray(re => re.ReadVarInt())
    };
}
