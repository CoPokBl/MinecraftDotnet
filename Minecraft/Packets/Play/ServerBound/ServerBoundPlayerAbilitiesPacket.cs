using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// Sent when the player starts or stops flying. Only the flying bit is meaningful here; the
/// rest of the ability flags are the server's to decide.
/// </summary>
public class ServerBoundPlayerAbilitiesPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:player_abilities";

    private const byte FlyingFlag = 0x02;

    public required bool Flying { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteUnsignedByte(Flying ? FlyingFlag : (byte)0);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPlayerAbilitiesPacket {
        Flying = (r.Read() & FlyingFlag) != 0
    };
}
