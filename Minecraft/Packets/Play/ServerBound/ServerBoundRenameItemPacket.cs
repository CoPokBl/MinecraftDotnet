using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent as the player types in an anvil's name field.</summary>
public class ServerBoundRenameItemPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:rename_item";

    public required string Name { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteString(Name);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundRenameItemPacket {
        Name = r.ReadString()
    };
}
