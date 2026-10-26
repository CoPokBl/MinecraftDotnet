using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

/// <summary>
/// Closes the dialog opened by <see cref="ClientBoundShowDialogPacket"/>. Sent in both the
/// configuration and play states.
/// </summary>
public class ClientBoundClearDialogPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:clear_dialog";

    protected override DataWriter WriteData(DataWriter w) {
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (_, _) => new ClientBoundClearDialogPacket();
}
