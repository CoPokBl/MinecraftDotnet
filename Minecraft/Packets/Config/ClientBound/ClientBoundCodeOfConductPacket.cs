using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

/// <summary>
/// Shows the server's code of conduct, which the player has to accept with
/// <c>ServerBoundAcceptCodeOfConductPacket</c> before configuration can finish.
/// </summary>
public class ClientBoundCodeOfConductPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:code_of_conduct";

    public required string CodeOfConduct { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteString(CodeOfConduct);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundCodeOfConductPacket {
        CodeOfConduct = r.ReadString()
    };
}
