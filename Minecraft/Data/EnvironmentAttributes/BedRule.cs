using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>What a bed does when a player right clicks one here.</summary>
/// <param name="Explodes">Whether using the bed blows it up instead.</param>
/// <param name="ErrorMessage">Shown when <see cref="CanSleep"/> refuses.</param>
public record BedRule(
    BedRuleCondition CanSleep,
    BedRuleCondition CanSetSpawn,
    bool Explodes,
    TextComponent? ErrorMessage) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("can_sleep", new StringTag(CanSleep.ToProtocolString())),
            ("can_set_spawn", new StringTag(CanSetSpawn.ToProtocolString()))
        ];

        if (Explodes) {
            children.Add(("explodes", new BooleanTag(true)));
        }

        if (ErrorMessage != null) {
            children.Add(("error_message", ErrorMessage.SerialiseToTag()));
        }

        return new CompoundTag(children.ToArray());
    }

    public static BedRule FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new BedRule(
            BedRuleConditionExtensions.ParseBedRuleCondition(compound["can_sleep"]!.GetString()),
            BedRuleConditionExtensions.ParseBedRuleCondition(compound["can_set_spawn"]!.GetString()),
            compound.Contains("explodes") && compound["explodes"]!.AsBool(),
            compound.Contains("error_message") ? TextComponent.FromTag(compound["error_message"]!) : null);
    }
}

public enum BedRuleCondition {
    Always,
    Never,
    WhenDark
}

public static class BedRuleConditionExtensions {
    public static string ToProtocolString(this BedRuleCondition condition) => condition switch {
        BedRuleCondition.Always => "always",
        BedRuleCondition.Never => "never",
        BedRuleCondition.WhenDark => "when_dark",
        _ => throw new ArgumentOutOfRangeException(nameof(condition), condition, null)
    };

    public static BedRuleCondition ParseBedRuleCondition(string value) => value switch {
        "always" => BedRuleCondition.Always,
        "never" => BedRuleCondition.Never,
        "when_dark" => BedRuleCondition.WhenDark,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown bed rule condition")
    };
}
