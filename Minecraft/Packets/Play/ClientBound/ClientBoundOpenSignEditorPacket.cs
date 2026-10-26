using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundOpenSignEditorPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:open_sign_editor";

    public required Vec3<int> Location { get; init; }

    /// <summary>Whether the front of the sign is being edited, rather than the back.</summary>
    public required bool IsFrontText { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteBoolean(IsFrontText);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundOpenSignEditorPacket {
        Location = r.ReadPosition(),
        IsFrontText = r.ReadBoolean()
    };
}
