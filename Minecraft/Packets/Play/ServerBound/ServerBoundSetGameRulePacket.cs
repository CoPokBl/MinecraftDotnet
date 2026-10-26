using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSetGameRulePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_game_rule";

    /// <summary>
    /// The value of each rule is sent as its string representation, so it needs
    /// parsing based on the type of the rule being set.
    /// </summary>
    public record Entry(Identifier GameRule, string Value);

    public required Entry[] Rules { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedArray(Rules, (entry, wr) => wr
            .WriteString(entry.GameRule)
            .WriteString(entry.Value));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ServerBoundSetGameRulePacket {
        Rules = r.ReadPrefixedArray(re => new Entry(
            re.Read<Identifier>(reg),
            re.ReadString()
        ))
    };
}
