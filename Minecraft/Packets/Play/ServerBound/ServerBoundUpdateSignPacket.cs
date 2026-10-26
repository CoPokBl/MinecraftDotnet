using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when the player finishes editing a sign.</summary>
public class ServerBoundUpdateSignPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:sign_update";

    public required Vec3<int> Location { get; init; }

    /// <summary>Whether the front of the sign was edited, rather than the back.</summary>
    public required bool IsFrontText { get; init; }

    /// <summary>The sign's four lines, as plain text.</summary>
    public required string[] Lines { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        AssertLength(Lines, 4);
        return w
            .WritePosition(Location)
            .WriteArray(Lines, (line, writer) => writer.WriteString(line))
            // SignTextSlot: BACK is 0 and FRONT is 1.
            .WriteVarInt(IsFrontText ? 1 : 0);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundUpdateSignPacket {
        Location = r.ReadPosition(),
        Lines = r.ReadArray(4, reader => reader.ReadString()),
        IsFrontText = r.ReadVarInt() == 1
    };
}
