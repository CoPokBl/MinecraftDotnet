using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// The player swung at nothing with the main hand. The packet says nothing else: the swing is the
/// main hand item's attack animation, and an interaction's swing is started by the server itself.
/// </summary>
public class ServerBoundPunchPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:punch";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundPunchPacket();
}
