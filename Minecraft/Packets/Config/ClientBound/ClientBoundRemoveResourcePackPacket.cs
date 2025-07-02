namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundRemoveResourcePackPacket : ClientBoundPacket {
    public Guid? Uuid;

    protected override byte[] GetData() {
        return new DataWriter()
            .WritePrefixedOptional(Uuid, (uid, wr) => wr.WriteUuid(uid))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundRemoveResourcePackPacket {
        Uuid = r.ReadPrefixedOptional(rdr => rdr.ReadUuid())
    };
}
