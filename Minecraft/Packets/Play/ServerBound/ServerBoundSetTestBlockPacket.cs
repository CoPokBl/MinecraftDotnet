using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator saves a test block's settings.</summary>
public class ServerBoundSetTestBlockPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_test_block";

    public required Vec3<int> Location { get; init; }
    public required TestBlockMode Mode { get; init; }

    /// <summary>Text the block logs or fails with, depending on the mode.</summary>
    public required string Message { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WritePosition(Location)
            .WriteVarInt((int)Mode)
            .WriteString(Message);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetTestBlockPacket {
        Location = r.ReadPosition(),
        Mode = (TestBlockMode)r.ReadVarInt(),
        Message = r.ReadString()
    };

    public enum TestBlockMode {
        Start = 0,
        Log = 1,
        Fail = 2,
        Accept = 3
    }
}
