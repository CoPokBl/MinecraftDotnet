using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundRemoveResourcePackPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:resource_pack_pop";

    public Guid? Uuid;

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePrefixedOptional(Uuid, (uid, wr) => wr.WriteUuid(uid));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundRemoveResourcePackPacket {
        Uuid = r.ReadPrefixedOptional(rdr => rdr.ReadUuid())
    };
}
