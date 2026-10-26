using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>What a bed does when a player right clicks one here.</summary>
/// <param name="DestroyOnUse">Whether using the bed destroys it instead, which is the explosion outside the overworld.</param>
/// <param name="DestroyOnLeave">Whether getting up out of the bed destroys it, as a straw bed does.</param>
/// <param name="ErrorMessage">Shown when <see cref="CanSleep"/> refuses.</param>
public record BedRule(
    BedRuleCondition CanSleep,
    BedRuleCondition CanSetSpawn,
    bool DestroyOnUse,
    bool DestroyOnLeave,
    TextComponent? ErrorMessage) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("can_sleep", new StringTag(CanSleep.ToProtocolString())),
            ("can_set_spawn", new StringTag(CanSetSpawn.ToProtocolString()))
        ];

        if (DestroyOnUse) {
            children.Add(("destroy_on_use", new BooleanTag(true)));
        }

        if (DestroyOnLeave) {
            children.Add(("destroy_on_leave", new BooleanTag(true)));
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
            compound.Contains("destroy_on_use") && compound["destroy_on_use"]!.AsBool(),
            compound.Contains("destroy_on_leave") && compound["destroy_on_leave"]!.AsBool(),
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
