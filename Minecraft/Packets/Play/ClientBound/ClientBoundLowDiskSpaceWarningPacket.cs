using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundLowDiskSpaceWarningPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:low_disk_space_warning";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundLowDiskSpaceWarningPacket();
}
