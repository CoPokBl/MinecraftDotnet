using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator saves a command block's settings.</summary>
public class ServerBoundProgramCommandBlockPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_command_block";

    private const byte TrackOutputFlag = 0x01;
    private const byte ConditionalFlag = 0x02;
    private const byte AutomaticFlag = 0x04;

    public required Vec3<int> Location { get; init; }
    public required string Command { get; init; }
    public required CommandBlockMode Mode { get; init; }

    /// <summary>Whether the block keeps the last output for the operator to read.</summary>
    public required bool TrackOutput { get; init; }

    /// <summary>Whether the block only runs when the one behind it succeeded.</summary>
    public required bool Conditional { get; init; }

    /// <summary>Whether the block runs without redstone power.</summary>
    public required bool Automatic { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        byte flags = 0;
        if (TrackOutput) {
            flags |= TrackOutputFlag;
        }
        if (Conditional) {
            flags |= ConditionalFlag;
        }
        if (Automatic) {
            flags |= AutomaticFlag;
        }

        return w
            .WritePosition(Location)
            .WriteString(Command)
            .WriteVarInt((int)Mode)
            .WriteUnsignedByte(flags);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        Vec3<int> location = r.ReadPosition();
        string command = r.ReadString();
        CommandBlockMode mode = (CommandBlockMode)r.ReadVarInt();
        byte flags = (byte)r.Read();
        return new ServerBoundProgramCommandBlockPacket {
            Location = location,
            Command = command,
            Mode = mode,
            TrackOutput = (flags & TrackOutputFlag) != 0,
            Conditional = (flags & ConditionalFlag) != 0,
            Automatic = (flags & AutomaticFlag) != 0
        };
    };

    public enum CommandBlockMode {
        Sequence = 0,
        Auto = 1,
        Redstone = 2
    }
}
