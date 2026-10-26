using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns block_conversion.json into <c>BlockConversions</c>: copper's weathering stages and the
/// honeycomb's waxables, each with its inverse. What a tool turns a block into is not here: that is the
/// block_transformer registry, which a datapack decides.
/// </summary>
public static class BlockConversionCodeGen {
    private const string FileTemplate =
"""
using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>Vanilla's block to block conversion tables, keyed by the block being converted.</summary>
public static class BlockConversions {
    /// <summary><c>WeatheringCopper.NEXT_BY_BLOCK</c>: the stage a block weathers to.</summary>
    public static readonly IReadOnlyDictionary<Identifier, IBlock> WeatheringNext = new Dictionary<Identifier, IBlock> {
{next}    };

    /// <summary><c>WeatheringCopper.PREVIOUS_BY_BLOCK</c>: the stage before a block's.</summary>
    public static readonly IReadOnlyDictionary<Identifier, IBlock> WeatheringPrevious = new Dictionary<Identifier, IBlock> {
{previous}    };

    /// <summary><c>HoneycombItem.WAXABLES</c>: what a honeycomb waxes a block to.</summary>
    public static readonly IReadOnlyDictionary<Identifier, IBlock> Waxables = new Dictionary<Identifier, IBlock> {
{waxables}    };

    /// <summary><c>HoneycombItem.WAX_OFF_BY_BLOCK</c>: a waxed block without its wax.</summary>
    public static readonly IReadOnlyDictionary<Identifier, IBlock> WaxOff = new Dictionary<Identifier, IBlock> {
{waxOff}    };
}

""";

    public static void GenerateBlockConversionCode(JObject _) {
        JObject conversions = JObject.Parse(CodeGenUtils.ReadDumpFile("block_conversion.json"));
        (string From, string To)[] Pairs(string table) =>
            ((JObject)conversions[table]!).Properties().Select(p => (p.Name, p.Value.Value<string>()!)).ToArray();
        (string, string)[] weathering = Pairs("weathering");
        (string, string)[] waxables = Pairs("waxables");
        File.WriteAllText("BlockConversions.cs", FileTemplate
            .Replace("{next}", Entries(weathering))
            .Replace("{previous}", Entries(weathering.Select(p => (p.Item2, p.Item1))))
            .Replace("{waxables}", Entries(waxables))
            .Replace("{waxOff}", Entries(waxables.Select(p => (p.Item2, p.Item1)))));
    }

    private static string Entries(IEnumerable<(string From, string To)> pairs) {
        StringBuilder entries = new();
        foreach ((string from, string to) in pairs) {
            entries.Append("        { \"").Append(from).Append("\", Block.").Append(CodeGenUtils.NamespacedIdToPascalName(to)).Append(" },\n");
        }
        return entries.ToString();
    }
}
