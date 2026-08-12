using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.EnvironmentAttributes;

/// <summary>
/// The value of an environment attribute. Which case applies is decided by the attribute, not by
/// the data, see <see cref="IEnvironmentAttribute.ValueKind"/>, so reading one always needs the
/// attribute in hand.
/// </summary>
public abstract record EnvironmentAttributeValue {
    public abstract EnvironmentAttributeValueKind Kind { get; }

    public abstract INbtTag ToNbt();

    public static EnvironmentAttributeValue FromNbt(EnvironmentAttributeValueKind kind, INbtTag tag,
        MinecraftRegistry reg) {
        return kind switch {
            EnvironmentAttributeValueKind.Boolean => new Boolean(tag.GetBoolean()),
            EnvironmentAttributeValueKind.Float => new Float(tag.GetFloat()),
            EnvironmentAttributeValueKind.RgbColor => new RgbColor(PackedColor.Parse(tag.GetString())),
            EnvironmentAttributeValueKind.ArgbColor => new ArgbColor(PackedColor.Parse(tag.GetString())),
            EnvironmentAttributeValueKind.Activity => new Activity(tag.GetString()),
            EnvironmentAttributeValueKind.TriState =>
                new TriStateValue(TriStateExtensions.ParseTriState(tag.GetString())),
            EnvironmentAttributeValueKind.MoonPhase =>
                new MoonPhaseValue(MoonPhaseExtensions.ParseMoonPhase(tag.GetString())),
            EnvironmentAttributeValueKind.Particle => new Particle(ParticleValue.FromNbt(tag)),
            EnvironmentAttributeValueKind.AmbientParticles => new AmbientParticles(((ListTag)tag).Tags.ToArray()
                .Select(AmbientParticle.FromNbt)
                .ToArray()),
            EnvironmentAttributeValueKind.AmbientSounds =>
                new Sounds(EnvironmentAttributes.AmbientSounds.FromNbt(tag, reg)),
            EnvironmentAttributeValueKind.BackgroundMusic =>
                new Music(EnvironmentAttributes.BackgroundMusic.FromNbt(tag, reg)),
            EnvironmentAttributeValueKind.BedRule =>
                new Bed(EnvironmentAttributes.BedRule.FromNbt(tag)),
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
        };
    }

    public record Boolean(bool Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.Boolean;
        public override INbtTag ToNbt() => new BooleanTag(Value);
    }

    public record Float(float Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.Float;
        public override INbtTag ToNbt() => new FloatTag(Value);
    }

    public record RgbColor(int Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.RgbColor;
        public override INbtTag ToNbt() => new StringTag(PackedColor.ToRgbString(Value));
    }

    public record ArgbColor(int Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.ArgbColor;
        public override INbtTag ToNbt() => new StringTag(PackedColor.ToArgbString(Value));
    }

    public record Activity(Identifier Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.Activity;
        public override INbtTag ToNbt() => new StringTag(Value.ToString());
    }

    public record TriStateValue(TriState Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.TriState;
        public override INbtTag ToNbt() => new StringTag(Value.ToProtocolString());
    }

    public record MoonPhaseValue(MoonPhase Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.MoonPhase;
        public override INbtTag ToNbt() => new StringTag(Value.ToProtocolString());
    }

    public record Particle(ParticleValue Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.Particle;
        public override INbtTag ToNbt() => Value.ToNbt();
    }

    public record AmbientParticles(AmbientParticle[] Values) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.AmbientParticles;

        public override INbtTag ToNbt() {
            return new ListTag<CompoundTag>(Values.Select(v => (CompoundTag)v.ToNbt()).ToArray());
        }

        public virtual bool Equals(AmbientParticles? other) {
            return other != null && Values.SequenceEqual(other.Values);
        }

        public override int GetHashCode() => Values.Length;
    }

    public record Sounds(AmbientSounds Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.AmbientSounds;
        public override INbtTag ToNbt() => Value.ToNbt();
    }

    public record Music(BackgroundMusic Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.BackgroundMusic;
        public override INbtTag ToNbt() => Value.ToNbt();
    }

    public record Bed(BedRule Value) : EnvironmentAttributeValue {
        public override EnvironmentAttributeValueKind Kind => EnvironmentAttributeValueKind.BedRule;
        public override INbtTag ToNbt() => Value.ToNbt();
    }
}

public enum TriState {
    True,
    False,
    Default
}

public static class TriStateExtensions {
    public static string ToProtocolString(this TriState state) => state switch {
        TriState.True => "true",
        TriState.False => "false",
        TriState.Default => "default",
        _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
    };

    public static TriState ParseTriState(string value) => value switch {
        "true" => TriState.True,
        "false" => TriState.False,
        "default" => TriState.Default,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown tri state")
    };
}

public enum MoonPhase {
    FullMoon,
    WaningGibbous,
    ThirdQuarter,
    WaningCrescent,
    NewMoon,
    WaxingCrescent,
    FirstQuarter,
    WaxingGibbous
}

public static class MoonPhaseExtensions {
    public static string ToProtocolString(this MoonPhase phase) => phase switch {
        MoonPhase.FullMoon => "full_moon",
        MoonPhase.WaningGibbous => "waning_gibbous",
        MoonPhase.ThirdQuarter => "third_quarter",
        MoonPhase.WaningCrescent => "waning_crescent",
        MoonPhase.NewMoon => "new_moon",
        MoonPhase.WaxingCrescent => "waxing_crescent",
        MoonPhase.FirstQuarter => "first_quarter",
        MoonPhase.WaxingGibbous => "waxing_gibbous",
        _ => throw new ArgumentOutOfRangeException(nameof(phase), phase, null)
    };

    public static MoonPhase ParseMoonPhase(string value) => value switch {
        "full_moon" => MoonPhase.FullMoon,
        "waning_gibbous" => MoonPhase.WaningGibbous,
        "third_quarter" => MoonPhase.ThirdQuarter,
        "waning_crescent" => MoonPhase.WaningCrescent,
        "new_moon" => MoonPhase.NewMoon,
        "waxing_crescent" => MoonPhase.WaxingCrescent,
        "first_quarter" => MoonPhase.FirstQuarter,
        "waxing_gibbous" => MoonPhase.WaxingGibbous,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown moon phase")
    };
}
