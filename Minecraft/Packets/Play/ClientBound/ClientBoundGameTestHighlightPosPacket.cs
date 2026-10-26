using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Highlights a block in the game test debug overlay.</summary>
public class ClientBoundGameTestHighlightPosPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:game_test_highlight_pos";

    /// <summary>The position in world coordinates.</summary>
    public required Vec3<int> AbsolutePosition { get; init; }

    /// <summary>The same position relative to the test instance's origin.</summary>
    public required Vec3<int> RelativePosition { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(AbsolutePosition)
            .WritePosition(RelativePosition);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundGameTestHighlightPosPacket {
        AbsolutePosition = r.ReadPosition(),
        RelativePosition = r.ReadPosition()
    };
}
