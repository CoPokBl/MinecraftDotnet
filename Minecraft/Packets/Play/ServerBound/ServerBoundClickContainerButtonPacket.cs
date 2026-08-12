using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// Sent for the buttons in containers that aren't slots, such as an enchanting table's three
/// options or a lectern's page arrows.
/// </summary>
public class ServerBoundClickContainerButtonPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:container_button_click";

    public required int WindowId { get; init; }

    /// <summary>Which button was pressed. The meaning depends on the container.</summary>
    public required int ButtonId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(ButtonId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundClickContainerButtonPacket {
        WindowId = r.ReadVarInt(),
        ButtonId = r.ReadVarInt()
    };
}
