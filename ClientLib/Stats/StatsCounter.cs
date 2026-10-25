using Minecraft.Data;
using Minecraft.Data.CustomStatistics;
using Minecraft.Data.Generated;
using Minecraft.Data.StatisticTypes;
using Minecraft.Registry;
using Minecraft.Registry.Templates;

namespace ClientLib.Stats;

/// <summary><c>Stat</c>: a stat type and the entry of that type's registry it counts, by protocol id.</summary>
public readonly record struct Stat(IStatisticType Type, int Value) {
    public static Stat Custom(ICustomStatistic statistic, MinecraftRegistry registry) =>
        new(StatisticType.Custom, registry.CustomStatistics.GetProtocolId(statistic));

    /// <summary>The registry the type's values index, as <c>Stats.makeRegistryStatType</c> pairs them.</summary>
    public static ISubRegistry RegistryOf(IStatisticType type, MinecraftRegistry registry) =>
        type.Identifier == StatisticType.Mined.Identifier ? registry.Blocks
        : type.Identifier == StatisticType.Killed.Identifier || type.Identifier == StatisticType.KilledBy.Identifier ? registry.EntityTypes
        : type.Identifier == StatisticType.Custom.Identifier ? registry.CustomStatistics
        : registry.Items;
}

/// <summary>
/// <c>StatsCounter</c>: what the server last said each stat was. A stat it never mentioned reads 0. One lives
/// as long as the login: a respawn keeps it.
/// </summary>
public sealed class StatsCounter {
    private readonly Dictionary<Stat, int> _values = new();

    public int GetValue(Stat stat) => _values.GetValueOrDefault(stat);

    public void SetValue(Stat stat, int value) => _values[stat] = value;

    public int GetValue(IStatisticType type, int value) => GetValue(new Stat(type, value));

    public IEnumerable<KeyValuePair<Stat, int>> All => _values;
}
