using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.GameTests;

/// <summary>
/// The conditions a game test runs under - time of day, weather, difficulty, game rules and so on.
/// </summary>
/// <remarks>
/// The client synchronises this registry even though nothing on its side runs tests, so a server
/// still has to send it.
/// </remarks>
public interface ITestEnvironment : IProtocolType {
    public TestEnvironmentDefinition Definition { get; }

    public INbtTag ToNbt() {
        return Definition.ToNbt();
    }

    public static ITestEnvironment FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleTestEnvironment(ident, TestEnvironmentDefinition.FromNbt(tag));
    }
}

/// <summary>One thing an environment sets up before a test runs.</summary>
public abstract record TestEnvironmentDefinition {
    public abstract Identifier Type { get; }

    protected abstract (string, INbtTag)[] Fields { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [("type", new StringTag(Type.ToString()))];
        children.AddRange(Fields);
        return new CompoundTag(children.ToArray());
    }

    public static TestEnvironmentDefinition FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        Identifier type = compound["type"]!.GetString();

        return type.ToString() switch {
            "minecraft:all_of" => new AllOf(compound["definitions"]!.AsList()
                .Select(TestEnvironmentReference.FromNbt)
                .ToArray()),

            "minecraft:clock_time" => new ClockTime(
                compound["clock"]!.GetString(),
                compound["time"]!.AsInt()),

            "minecraft:difficulty" => new SetDifficulty(
                DifficultyExtensions.ParseDifficulty(compound["difficulty"]!.GetString())),

            "minecraft:function" => new Functions(
                compound.Contains("setup") ? (Identifier?)compound["setup"]!.GetString() : null,
                compound.Contains("teardown") ? (Identifier?)compound["teardown"]!.GetString() : null),

            "minecraft:game_rules" => new SetGameRules(((CompoundTag)compound["rules"]!).Children
                .ToDictionary(c => c.Item1, c => c.Item2)),

            "minecraft:timeline_attributes" => new Timelines(compound["timelines"]!.AsList()
                .Select(t => (Identifier)t.GetString())
                .ToArray()),

            "minecraft:weather" => new SetWeather(
                TestWeatherExtensions.ParseTestWeather(compound["weather"]!.GetString())),

            _ => throw new ArgumentException($"Unknown test environment type {type}", nameof(tag))
        };
    }

    /// <summary>Applies several definitions in order.</summary>
    public record AllOf(TestEnvironmentReference[] Definitions) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:all_of";

        protected override (string, INbtTag)[] Fields => [
            ("definitions", new ListTag<INbtTag>(Definitions.Select(d => d.ToNbt()).ToArray()))
        ];

        public virtual bool Equals(AllOf? other) {
            return other != null && Definitions.SequenceEqual(other.Definitions);
        }

        public override int GetHashCode() => Definitions.Length;
    }

    /// <summary>Pins a world clock to a fixed value.</summary>
    public record ClockTime(Identifier Clock, int Time) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:clock_time";

        protected override (string, INbtTag)[] Fields => [
            ("clock", new StringTag(Clock.ToString())),
            ("time", new IntegerTag(Time))
        ];
    }

    public record SetDifficulty(Difficulty Difficulty) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:difficulty";

        protected override (string, INbtTag)[] Fields => [
            ("difficulty", new StringTag(Difficulty.ToProtocolString()))
        ];
    }

    /// <summary>Runs mcfunctions around the test.</summary>
    public record Functions(Identifier? Setup, Identifier? Teardown) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:function";

        protected override (string, INbtTag)[] Fields {
            get {
                List<(string, INbtTag)> fields = [];

                if (Setup != null) {
                    fields.Add(("setup", new StringTag(Setup.Value.ToString())));
                }

                if (Teardown != null) {
                    fields.Add(("teardown", new StringTag(Teardown.Value.ToString())));
                }

                return fields.ToArray();
            }
        }
    }

    /// <param name="Rules">
    /// Game rule values keyed by rule name, kept as they were read. Game rules aren't a registry on
    /// our side, so there's nothing to resolve their names or value types against.
    /// </param>
    public record SetGameRules(IReadOnlyDictionary<string, INbtTag> Rules) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:game_rules";

        protected override (string, INbtTag)[] Fields => [
            ("rules", new CompoundTag(Rules.Select(r => (r.Key, r.Value)).ToArray()))
        ];

        public virtual bool Equals(SetGameRules? other) {
            return other != null && Rules.Count == other.Rules.Count
                   && Rules.All(r => other.Rules.TryGetValue(r.Key, out INbtTag? v) && Equals(v, r.Value));
        }

        public override int GetHashCode() => Rules.Count;
    }

    public record Timelines(Identifier[] TimelineIds) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:timeline_attributes";

        protected override (string, INbtTag)[] Fields => [
            ("timelines", new ListTag<StringTag>(TimelineIds
                .Select(t => new StringTag(t.ToString()))
                .ToArray()))
        ];

        public virtual bool Equals(Timelines? other) {
            return other != null && TimelineIds.SequenceEqual(other.TimelineIds);
        }

        public override int GetHashCode() => TimelineIds.Length;
    }

    public record SetWeather(TestWeather Weather) : TestEnvironmentDefinition {
        public override Identifier Type => "minecraft:weather";

        protected override (string, INbtTag)[] Fields => [
            ("weather", new StringTag(Weather.ToProtocolString()))
        ];
    }
}

/// <summary>
/// One of the definitions an <see cref="TestEnvironmentDefinition.AllOf"/> pulls in: either the
/// name of another registry entry, or a definition written out in place.
/// </summary>
public abstract record TestEnvironmentReference {

    public abstract INbtTag ToNbt();

    public static TestEnvironmentReference FromNbt(INbtTag tag) {
        return tag is CompoundTag compound
            ? new Inline(TestEnvironmentDefinition.FromNbt(compound))
            : new Named(tag.GetString());
    }

    public record Named(Identifier Environment) : TestEnvironmentReference {
        public override INbtTag ToNbt() => new StringTag(Environment.ToString());
    }

    public record Inline(TestEnvironmentDefinition Definition) : TestEnvironmentReference {
        public override INbtTag ToNbt() => Definition.ToNbt();
    }
}

public enum Difficulty {
    Peaceful,
    Easy,
    Normal,
    Hard
}

public static class DifficultyExtensions {
    public static string ToProtocolString(this Difficulty difficulty) => difficulty switch {
        Difficulty.Peaceful => "peaceful",
        Difficulty.Easy => "easy",
        Difficulty.Normal => "normal",
        Difficulty.Hard => "hard",
        _ => throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null)
    };

    public static Difficulty ParseDifficulty(string value) => value switch {
        "peaceful" => Difficulty.Peaceful,
        "easy" => Difficulty.Easy,
        "normal" => Difficulty.Normal,
        "hard" => Difficulty.Hard,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown difficulty")
    };
}

public enum TestWeather {
    Clear,
    Rain,
    Thunder
}

public static class TestWeatherExtensions {
    public static string ToProtocolString(this TestWeather weather) => weather switch {
        TestWeather.Clear => "clear",
        TestWeather.Rain => "rain",
        TestWeather.Thunder => "thunder",
        _ => throw new ArgumentOutOfRangeException(nameof(weather), weather, null)
    };

    public static TestWeather ParseTestWeather(string value) => value switch {
        "clear" => TestWeather.Clear,
        "rain" => TestWeather.Rain,
        "thunder" => TestWeather.Thunder,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown test weather")
    };
}
