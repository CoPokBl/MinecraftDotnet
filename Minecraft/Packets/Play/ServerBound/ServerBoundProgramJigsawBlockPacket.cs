using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator saves a jigsaw block's settings.</summary>
public class ServerBoundProgramJigsawBlockPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_jigsaw_block";

    public required Vec3<int> Location { get; init; }

    /// <summary>The name other jigsaws target to connect to this one.</summary>
    public required Identifier Name { get; init; }

    /// <summary>The name this jigsaw looks for when connecting.</summary>
    public required Identifier Target { get; init; }

    /// <summary>The template pool the connected structure is drawn from.</summary>
    public required Identifier Pool { get; init; }

    /// <summary>Block state the jigsaw turns into once the structure is placed.</summary>
    public required string FinalState { get; init; }

    public required JigsawJointType Joint { get; init; }

    /// <summary>How strongly this jigsaw is preferred when picking which to expand next.</summary>
    public required int SelectionPriority { get; init; }

    /// <summary>How early the connected piece is placed relative to its siblings.</summary>
    public required int PlacementPriority { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .Write(Name)
            .Write(Target)
            .Write(Pool)
            .WriteString(FinalState)
            .WriteString(Joint == JigsawJointType.Rollable ? "rollable" : "aligned")
            .WriteVarInt(SelectionPriority)
            .WriteVarInt(PlacementPriority);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundProgramJigsawBlockPacket {
        Location = r.ReadPosition(),
        Name = r.ReadString(),
        Target = r.ReadString(),
        Pool = r.ReadString(),
        FinalState = r.ReadString(),
        // Anything the client can't name falls back to aligned, as vanilla does.
        Joint = r.ReadString() == "rollable" ? JigsawJointType.Rollable : JigsawJointType.Aligned,
        SelectionPriority = r.ReadVarInt(),
        PlacementPriority = r.ReadVarInt()
    };

    public enum JigsawJointType {
        /// <summary>The connected piece may be rotated around the connection.</summary>
        Rollable,

        /// <summary>The connected piece keeps its orientation.</summary>
        Aligned
    }
}
