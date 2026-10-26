using System.Globalization;
using ClientLib.Brigadier;
using Minecraft.Data.CustomStatistics;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ClientLib.Stats;

/// <summary><c>StatFormatter</c>, and which one each stat is made with in <c>Stats</c>.</summary>
public static class StatFormatter {
    /// <summary><c>NumberFormat.getIntegerInstance(Locale.US)</c>.</summary>
    public static string Default(int value) => value.ToString("#,0", CultureInfo.InvariantCulture);

    public static string DivideByTen(int value) => DecimalFormat(value * 0.1);

    public static string Distance(int cm) {
        double meters = cm / 100.0;
        double kilometers = meters / 1000.0;
        if (kilometers > 0.5) {
            return DecimalFormat(kilometers) + " km";
        }
        return meters > 0.5 ? DecimalFormat(meters) + " m" : cm + " cm";
    }

    public static string Time(int value) {
        double seconds = value / 20.0;
        double minutes = seconds / 60.0;
        double hours = minutes / 60.0;
        double days = hours / 24.0;
        double years = days / 365.0;
        if (years > 0.5) {
            return DecimalFormat(years) + " y";
        }
        if (days > 0.5) {
            return DecimalFormat(days) + " d";
        }
        if (hours > 0.5) {
            return DecimalFormat(hours) + " h";
        }
        return minutes > 0.5 ? DecimalFormat(minutes) + " min" : JavaText.ToString(seconds) + " s";
    }

    /// <summary>
    /// <c>new DecimalFormat("########0.00")</c>: two places, rounded half even on the double's exact value, which
    /// is what .NET's <c>F2</c> does. A custom <c>0.00</c> pattern would round 15 digits half up instead.
    /// </summary>
    public static string DecimalFormat(double value) => value.ToString("F2", CultureInfo.InvariantCulture);

    private static readonly HashSet<Identifier> TimeStats = Ids(
        CustomStatistic.PlayTime, CustomStatistic.TotalWorldTime, CustomStatistic.TimeSinceDeath, CustomStatistic.TimeSinceRest, CustomStatistic.SneakTime);

    private static readonly HashSet<Identifier> DistanceStats = Ids(
        CustomStatistic.WalkOneCm, CustomStatistic.CrouchOneCm, CustomStatistic.SprintOneCm, CustomStatistic.WalkOnWaterOneCm, CustomStatistic.FallOneCm,
        CustomStatistic.ClimbOneCm, CustomStatistic.FlyOneCm, CustomStatistic.WalkUnderWaterOneCm, CustomStatistic.MinecartOneCm, CustomStatistic.BoatOneCm,
        CustomStatistic.PigOneCm, CustomStatistic.HappyGhastOneCm, CustomStatistic.HorseOneCm, CustomStatistic.AviateOneCm, CustomStatistic.SwimOneCm,
        CustomStatistic.StriderOneCm, CustomStatistic.NautilusOneCm);

    private static readonly HashSet<Identifier> TenthStats = Ids(
        CustomStatistic.DamageDealt, CustomStatistic.DamageDealtAbsorbed, CustomStatistic.DamageDealtResisted, CustomStatistic.DamageTaken,
        CustomStatistic.DamageBlockedByShield, CustomStatistic.DamageAbsorbed, CustomStatistic.DamageResisted);

    private static HashSet<Identifier> Ids(params ICustomStatistic[] stats) => stats.Select(stat => stat.Identifier).ToHashSet();

    /// <summary>
    /// <c>Stat.format</c>. Only custom stats are made with a formatter of their own; every block, item and
    /// entity stat is <c>StatType.get</c>'s default.
    /// </summary>
    public static string Format(Stat stat, int value, MinecraftRegistry registry) {
        if (stat.Type.Identifier != StatisticType.Custom.Identifier || !registry.CustomStatistics.Contains(stat.Value)) {
            return Default(value);
        }
        Identifier id = registry.CustomStatistics[stat.Value].Identifier;
        return TimeStats.Contains(id) ? Time(value)
            : DistanceStats.Contains(id) ? Distance(value)
            : TenthStats.Contains(id) ? DivideByTen(value)
            : Default(value);
    }
}
