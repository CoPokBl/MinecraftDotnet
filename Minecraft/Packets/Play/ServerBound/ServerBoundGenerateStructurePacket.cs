using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator presses "Generate" on a jigsaw block.</summary>
public class ServerBoundGenerateStructurePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:jigsaw_generate";

    public required Vec3<int> Location { get; init; }

    /// <summary>How many layers of jigsaw connections to expand.</summary>
    public required int Levels { get; init; }

    /// <summary>Whether the jigsaw blocks stay behind instead of being replaced.</summary>
    public required bool KeepJigsaws { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteVarInt(Levels)
            .WriteBoolean(KeepJigsaws);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundGenerateStructurePacket {
        Location = r.ReadPosition(),
        Levels = r.ReadVarInt(),
        KeepJigsaws = r.ReadBoolean()
    };
}
