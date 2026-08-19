using System.Text.Json;
using ManagedServer.Terrain.Data;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace ManagedServer.Terrain.Surface;

/// <summary>
/// Reads the <c>surface_rule</c> half of a noise settings file into a rule tree.
/// </summary>
/// <remarks>
/// Rules and conditions are two separate dispatches sharing one JSON shape, and a value is read as
/// whichever one its position calls for: <c>then_run</c> is a rule and <c>if_true</c> is a condition,
/// and no <c>type</c> appears in both tables. An unknown type throws rather than being skipped, since
/// a dropped rule is a biome that quietly generates as bare stone.
/// </remarks>
public sealed class SurfaceRuleParser(MinecraftRegistry registry) {
    public ISurfaceRuleSource ParseRule(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("type").GetString()!).Key;

        switch (type) {
            case "bandlands":
                return SurfaceRules.BandlandsRuleSource.Instance;

            case "block":
                return new SurfaceRules.BlockRuleSource(ParseBlockState(element.GetProperty("result_state")));

            case "sequence": {
                List<ISurfaceRuleSource> sequence = [];
                foreach (JsonElement rule in element.GetProperty("sequence").EnumerateArray()) {
                    sequence.Add(ParseRule(rule));
                }

                if (sequence.Count == 0) {
                    throw new FormatException("Need at least 1 rule for a sequence.");
                }

                return new SurfaceRules.SequenceRuleSource(sequence);
            }

            case "condition":
                return new SurfaceRules.TestRuleSource(ParseCondition(element.GetProperty("if_true")),
                    ParseRule(element.GetProperty("then_run")));

            default:
                throw new FormatException($"Unknown surface rule type \"{type}\".");
        }
    }

    public ISurfaceConditionSource ParseCondition(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("type").GetString()!).Key;

        switch (type) {
            case "biome":
                return new SurfaceRules.BiomeConditionSource(ParseBiomeSet(element.GetProperty("biome_is")));

            case "noise_threshold":
                return new SurfaceRules.NoiseThresholdConditionSource(
                    Identifier.Parse(element.GetProperty("noise").GetString()!),
                    element.GetProperty("min_threshold").GetDouble(),
                    element.GetProperty("max_threshold").GetDouble(),
                    // Optional upstream and absent from every vanilla file, so a missing key is a two
                    // dimensional sample rather than a malformed condition.
                    is3D: element.TryGetProperty("is_3d", out JsonElement is3D) && is3D.GetBoolean());

            case "vertical_gradient":
                return new SurfaceRules.VerticalGradientConditionSource(
                    Identifier.Parse(element.GetProperty("random_name").GetString()!),
                    ParseAnchor(element.GetProperty("true_at_and_below")),
                    ParseAnchor(element.GetProperty("false_at_and_above")));

            case "y_above":
                return new SurfaceRules.YConditionSource(ParseAnchor(element.GetProperty("anchor")),
                    element.GetProperty("surface_depth_multiplier").GetInt32(),
                    element.GetProperty("add_stone_depth").GetBoolean());

            case "water":
                return new SurfaceRules.WaterConditionSource(element.GetProperty("offset").GetInt32(),
                    element.GetProperty("surface_depth_multiplier").GetInt32(),
                    element.GetProperty("add_stone_depth").GetBoolean());

            case "stone_depth":
                return new SurfaceRules.StoneDepthCheck(element.GetProperty("offset").GetInt32(),
                    element.GetProperty("add_surface_depth").GetBoolean(),
                    element.GetProperty("secondary_depth_range").GetInt32(),
                    ceiling: element.GetProperty("surface_type").GetString() == "ceiling");

            case "not":
                return new SurfaceRules.NotConditionSource(ParseCondition(element.GetProperty("invert")));

            case "steep":
                return SurfaceRules.SteepConditionSource.Instance;

            case "hole":
                return SurfaceRules.HoleConditionSource.Instance;

            case "above_preliminary_surface":
                return SurfaceRules.AbovePreliminarySurfaceConditionSource.Instance;

            case "temperature":
                return SurfaceRules.TemperatureConditionSource.Instance;

            default:
                throw new FormatException($"Unknown surface condition type \"{type}\".");
        }
    }

    /// <summary>
    /// <c>biome_is</c> is a holder set, so it is either one name or a list of them. Both appear in the
    /// overworld file.
    /// </summary>
    private static HashSet<Identifier> ParseBiomeSet(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            return [Identifier.Parse(element.GetString()!)];
        }

        HashSet<Identifier> biomes = [];
        foreach (JsonElement biome in element.EnumerateArray()) {
            biomes.Add(Identifier.Parse(biome.GetString()!));
        }

        return biomes;
    }

    private static VerticalAnchor ParseAnchor(JsonElement element) {
        if (element.TryGetProperty("absolute", out JsonElement absolute)) {
            return VerticalAnchor.Absolute(absolute.GetInt32());
        }

        if (element.TryGetProperty("above_bottom", out JsonElement aboveBottom)) {
            return VerticalAnchor.AboveBottom(aboveBottom.GetInt32());
        }

        if (element.TryGetProperty("below_top", out JsonElement belowTop)) {
            return VerticalAnchor.BelowTop(belowTop.GetInt32());
        }

        throw new FormatException("A vertical anchor needs one of absolute, above_bottom or below_top.");
    }

    /// <summary>
    /// A block state in the datapack's own form: a name, and optionally the properties that differ
    /// from the block's default.
    /// </summary>
    public uint ParseBlockState(JsonElement element) {
        Identifier name = Identifier.Parse(element.GetProperty("Name").GetString()!);

        CompoundTag? properties = null;

        if (element.TryGetProperty("Properties", out JsonElement written)) {
            List<(string, NBT.INbtTag)> tags = [];
            foreach (JsonProperty property in written.EnumerateObject()) {
                tags.Add((property.Name, new StringTag(property.Value.GetString()!)));
            }

            properties = new CompoundTag(tags.ToArray());
        }

        return StateParser.Read(registry, name, properties).StateId;
    }
}
