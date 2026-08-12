using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundGameRuleValuesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:game_rule_values";

    /// <summary>
    /// The value of each rule is sent as its string representation, so it needs
    /// parsing based on the type of the rule.
    /// </summary>
    public required Dictionary<Identifier, string> Values { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        w.WriteVarInt(Values.Count);
        foreach ((Identifier gameRule, string value) in Values) {
            w.WriteString(gameRule)
                .WriteString(value);
        }

        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        int count = r.ReadVarInt();
        Dictionary<Identifier, string> values = new();
        for (int i = 0; i < count; i++) {
            values[r.Read<Identifier>(reg)] = r.ReadString();
        }

        return new ClientBoundGameRuleValuesPacket {
            Values = values
        };
    };
}
