using System.Text.Json;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Material;

/// <summary>Where a referenced material rule or condition is looked up.</summary>
public interface IMaterialRuleSource {
    IMaterialRule ResolveRule(Identifier id);

    IMaterialCondition ResolveCondition(Identifier id);
}

/// <summary>
/// Reads <c>worldgen/material_rule</c> and <c>worldgen/material_condition</c> JSON, the port of
/// <c>MaterialRule.CODEC</c> and <c>MaterialCondition.CODEC</c>.
/// </summary>
/// <remarks>
/// Any rule or condition position may be a string naming a registry entry instead of an inline
/// object. An unknown type throws: a dropped rule is a biome that quietly generates as bare stone.
/// </remarks>
public sealed class MaterialRuleParser(MinecraftRegistry registry, DensityFunctionParser densityParser, IMaterialRuleSource source) {
    public IMaterialRule ParseRule(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            return new MaterialRuleReference(Identifier.Parse(element.GetString()!), source.ResolveRule);
        }

        string type = Identifier.Parse(Field(element, "type").GetString()!).Key;
        switch (type) {
            case "block":
                return new MaterialRules.Block(ParseBlockState(Field(element, "result_state")));
            case "bandlands":
                return MaterialRules.Bandlands.Instance;
            case "sequence": {
                IMaterialRule[] sequence = Field(element, "sequence").EnumerateArray().Select(ParseRule).ToArray();
                if (sequence.Length == 0) {
                    throw new FormatException("Need at least 1 rule for a sequence");
                }

                return new MaterialRules.Sequence(sequence);
            }
            case "condition":
                return new MaterialRules.Condition(ParseCondition(Field(element, "if_true")), ParseRule(Field(element, "then_run")));
            case "ore_vein": {
                float rawOreChance = Field(element, "raw_ore_chance").GetSingle();
                if (!(rawOreChance >= 0.0F && rawOreChance <= 1.0F)) {
                    throw new FormatException($"raw_ore_chance {rawOreChance} outside of range [0.0:1.0]");
                }

                return new MaterialRules.OreVein(ParseBlockState(Field(element, "ore_block")),
                    ParseBlockState(Field(element, "raw_ore_block")), ParseBlockState(Field(element, "filler_block")), rawOreChance,
                    densityParser.Parse(Field(element, "density")), densityParser.Parse(Field(element, "richness")),
                    densityParser.Parse(Field(element, "filler_gap")));
            }
            default:
                throw new FormatException($"Unknown material rule type \"{type}\".");
        }
    }

    public IMaterialCondition ParseCondition(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            return new MaterialConditionReference(Identifier.Parse(element.GetString()!), source.ResolveCondition);
        }

        string type = Identifier.Parse(Field(element, "type").GetString()!).Key;
        switch (type) {
            case "biome":
                return new MaterialConditions.Biome(ParseBiomeSet(Field(element, "biome_is")));
            case "noise_threshold":
                return new MaterialConditions.NoiseThreshold(Identifier.Parse(Field(element, "noise").GetString()!),
                    Field(element, "min_threshold").GetDouble(), Field(element, "max_threshold").GetDouble(),
                    element.TryGetProperty("is_3d", out JsonElement is3D) && is3D.GetBoolean());
            case "vertical_gradient":
                return new MaterialConditions.VerticalGradient(Identifier.Parse(Field(element, "random_name").GetString()!),
                    ValueParser.ParseAnchor(Field(element, "true_at_and_below")), ValueParser.ParseAnchor(Field(element, "false_at_and_above")));
            case "y_above":
                return new MaterialConditions.YAbove(ValueParser.ParseAnchor(Field(element, "anchor")),
                    SurfaceDepthMultiplier(element), Field(element, "add_stone_depth").GetBoolean());
            case "water":
                return new MaterialConditions.Water(Field(element, "offset").GetInt32(), SurfaceDepthMultiplier(element),
                    Field(element, "add_stone_depth").GetBoolean());
            case "temperature":
                return MaterialConditions.Temperature.Instance;
            case "steep":
                return MaterialConditions.Steep.Instance;
            case "not":
                return new MaterialConditions.Not(ParseCondition(Field(element, "invert")));
            case "hole":
                return MaterialConditions.Hole.Instance;
            case "above_preliminary_surface":
                return MaterialConditions.AbovePreliminarySurface.Instance;
            case "stone_depth":
                return new MaterialConditions.StoneDepth(Field(element, "offset").GetInt32(), Field(element, "add_surface_depth").GetBoolean(),
                    Field(element, "secondary_depth_range").GetInt32(), Field(element, "surface_type").GetString() switch {
                        "ceiling" => CaveSurface.Ceiling,
                        "floor" => CaveSurface.Floor,
                        string other => throw new FormatException($"Unknown cave surface \"{other}\"."),
                        null => throw new FormatException("surface_type must be a string.")
                    });
            default:
                throw new FormatException($"Unknown material condition type \"{type}\".");
        }
    }

    private static JsonElement Field(JsonElement element, string name) {
        if (!element.TryGetProperty(name, out JsonElement field)) {
            throw new FormatException($"Material rule is missing \"{name}\".");
        }

        return field;
    }

    private static int SurfaceDepthMultiplier(JsonElement element) {
        int value = Field(element, "surface_depth_multiplier").GetInt32();
        if (value is < -20 or > 20) {
            throw new FormatException($"surface_depth_multiplier {value} outside of range [-20:20]");
        }

        return value;
    }

    private uint ParseBlockState(JsonElement element) => StateParser.ReadJson(registry, element).StateId;

    /// <summary>A biome <c>HolderSet</c>: one id, a list of ids, or a <c>#tag</c>. Unknown biomes throw.</summary>
    private IReadOnlySet<Identifier> ParseBiomeSet(JsonElement element) {
        HashSet<Identifier> biomes = [];
        if (element.ValueKind == JsonValueKind.String) {
            AddBiome(biomes, element.GetString()!);
        } else {
            foreach (JsonElement entry in element.EnumerateArray()) {
                AddBiome(biomes, entry.GetString()!);
            }
        }

        return biomes;
    }

    private void AddBiome(HashSet<Identifier> into, string value) {
        if (value.StartsWith('#')) {
            Identifier tag = Identifier.Parse(value[1..]);
            if (!registry.Biomes.Tags.Contains(tag)) {
                throw new FormatException($"A material rule names the biome tag \"{tag}\", which the registry does not have.");
            }

            foreach (Identifier biome in registry.Biomes.Tags[tag].GetValueIds(registry)) {
                into.Add(biome);
            }

            return;
        }

        into.Add(Identifier.Parse(value));
    }
}
