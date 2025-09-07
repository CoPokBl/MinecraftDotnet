using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPlayerInfoRemovePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_info_remove";
    
    public required Guid[] Uuids { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePrefixedArray(Uuids, (guid, writer) => writer.WriteUuid(guid));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPlayerInfoRemovePacket {
        Uuids = r.ReadPrefixedArray(reader => reader.ReadUuid())
    };
}
