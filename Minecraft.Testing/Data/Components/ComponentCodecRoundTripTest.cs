using System.Text;
using Minecraft.Data.Components;
using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using Newtonsoft.Json.Linq;

namespace Minecraft.Testing.Data.Components;

/// <summary>
/// Reads every default component value vanilla reported and writes it back, so a codec that names a
/// key wrong or leaves a field off is a failure here.
/// </summary>
/// <remarks>
/// <b>The input is vanilla's own encoder output, which is what makes this worth running.</b> A codec
/// checked against itself passes just as happily with the wrong key name in both directions.
/// <p/>
/// Compared as parsed values rather than text: the report's keys are alphabetised and a codec's
/// field order is not, and a float printed at full precision is not the text vanilla wrote.
/// </remarks>
[TestFixture]
public class ComponentCodecRoundTripTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    [Test]
    public void RoundTripsEveryReportedValue() {
        List<string> failures = [];
        int checked_ = 0;

        foreach (ReportedComponent entry in VanillaComponentReport.Require()) {
            if (!Registry.DataComponents.Contains(entry.Component)) {
                failures.Add($"{entry.Item}: no component called {entry.Component}");
                continue;
            }

            IDataComponent component = Registry.DataComponents[entry.Component];

            if (!component.HasNbtForm) {
                continue;
            }

            try {
                object value = component.FromNbt(JsonNbt.FromJson(entry.Value, entry.Component), Registry);
                JToken written = INbtTag.ToJson(component.ToNbt(value, Registry));
                JToken expected = JToken.Parse(entry.Value.GetRawText());

                if (!Same(expected, written)) {
                    failures.Add($"{entry.Item} {entry.Component}:"
                        + $"\n      vanilla {expected.ToString(Newtonsoft.Json.Formatting.None)}"
                        + $"\n      ours    {written.ToString(Newtonsoft.Json.Formatting.None)}");
                }
            } catch (Exception e) {
                failures.Add($"{entry.Item} {entry.Component}: {e.GetType().Name}: {e.Message}");
            }

            checked_++;
        }

        Assert.That(checked_, Is.GreaterThan(0), "nothing was checked, so this proves nothing");
        Assert.That(failures, Is.Empty, () => Describe(failures));
    }

    /// <summary>
    /// Which components the report reaches at all, so a codec landing without one is visible as the
    /// unpinned thing it is.
    /// </summary>
    [Test]
    public void ReportsWhatIsNotCovered() {
        HashSet<Identifier> covered = VanillaComponentReport.Require()
            .Select(entry => entry.Component)
            .ToHashSet();

        string[] uncovered = Registry.DataComponents.All
            .Where(component => component.HasNbtForm && !covered.Contains(component.Identifier))
            .Select(component => component.Identifier.ToString())
            .Order(StringComparer.Ordinal)
            .ToArray();

        TestContext.Out.WriteLine($"{covered.Count} components have a reported value; "
            + $"{uncovered.Length} have a codec that nothing here pins:");

        foreach (string component in uncovered) {
            TestContext.Out.WriteLine("  " + component);
        }

        Assert.Pass();
    }

    /// <summary>
    /// Equal as values. Numbers compare loosely because a float that went through a tag comes back
    /// wider than the text vanilla printed, and the two are the same number.
    /// </summary>
    private static bool Same(JToken expected, JToken actual) {
        switch (expected.Type) {
            case JTokenType.Object: {
                JObject left = (JObject)expected;

                if (actual is not JObject right || left.Count != right.Count) {
                    return false;
                }

                foreach ((string key, JToken? value) in left) {
                    if (right[key] is not { } other || !Same(value!, other)) {
                        return false;
                    }
                }

                return true;
            }

            case JTokenType.Array: {
                JArray left = (JArray)expected;

                if (actual is not JArray right || left.Count != right.Count) {
                    return false;
                }

                return !left.Where((value, i) => !Same(value, right[i])).Any();
            }

            case JTokenType.Integer:
            case JTokenType.Float: {
                if (actual.Type is not (JTokenType.Integer or JTokenType.Float)) {
                    return false;
                }

                double left = expected.Value<double>();
                double right = actual.Value<double>();
                return Math.Abs(left - right) <= 1e-6 * Math.Max(1d, Math.Abs(left));
            }

            case JTokenType.Boolean:
                return actual.Type == JTokenType.Boolean
                    && expected.Value<bool>() == actual.Value<bool>();

            default:
                return JToken.DeepEquals(expected, actual);
        }
    }

    private static string Describe(IReadOnlyList<string> failures) {
        StringBuilder message = new();
        message.AppendLine($"{failures.Count} values did not survive a round trip:");

        foreach (string failure in failures.Take(40)) {
            message.AppendLine("  " + failure);
        }

        if (failures.Count > 40) {
            message.AppendLine($"  ... and {failures.Count - 40} more");
        }

        return message.ToString();
    }
}
