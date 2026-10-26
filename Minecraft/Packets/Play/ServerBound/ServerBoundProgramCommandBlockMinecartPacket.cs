using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator saves a command block minecart's settings.</summary>
public class ServerBoundProgramCommandBlockMinecartPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_command_minecart";

    public required int EntityId { get; init; }
    public required string Command { get; init; }

    /// <summary>Whether the minecart keeps the last output for the operator to read.</summary>
    public required bool TrackOutput { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteString(Command)
            .WriteBoolean(TrackOutput);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundProgramCommandBlockMinecartPacket {
        EntityId = r.ReadVarInt(),
        Command = r.ReadString(),
        TrackOutput = r.ReadBoolean()
    };
}
