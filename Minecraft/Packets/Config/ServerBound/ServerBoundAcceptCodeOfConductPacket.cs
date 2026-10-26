using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

/// <summary>
/// Sent when the player accepts the code of conduct shown by
/// <c>ClientBoundCodeOfConductPacket</c>.
/// </summary>
public class ServerBoundAcceptCodeOfConductPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:accept_code_of_conduct";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ServerBoundAcceptCodeOfConductPacket();
}
