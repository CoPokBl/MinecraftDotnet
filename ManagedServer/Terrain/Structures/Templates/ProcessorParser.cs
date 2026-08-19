using System.Text.Json;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Surface;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// Reads a <c>worldgen/processor_list</c> file into the processors beside this.
/// </summary>
/// <remarks>
/// <b>Every type is transcribed and an unknown one throws.</b> There is no not-transcribed list here,
/// unlike the feature and carver parsers: a processor is a handful of lines each, and a dropped one
/// is a village whose houses keep their template's planks or a ruin that comes out intact. Both are
/// worlds that generate and are quietly wrong.
/// </remarks>
public sealed class ProcessorParser(MinecraftRegistry registry) {
    private readonly SurfaceRuleParser _states = new(registry);

    /// <summary>The <c>processors</c> array of a processor list file.</summary>
    public List<IStructureProcessor> ParseList(JsonElement root) {
        List<IStructureProcessor> processors = [];

        foreach (JsonElement entry in root.GetProperty("processors").EnumerateArray()) {
            processors.Add(Parse(entry));
        }

        return processors;
    }

    public IStructureProcessor Parse(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("processor_type").GetString()!).Key;

        switch (type) {
            case "nop":
                return NopProcessor.Instance;

            case "block_ignore":
                return new BlockIgnoreProcessor(element.GetProperty("blocks").EnumerateArray()
                    .Select(block => Identifier.Parse(block.GetProperty("Name").GetString()!))
                    .ToArray());

            case "block_rot":
                return new BlockRotProcessor(
                    element.TryGetProperty("rottable_blocks", out JsonElement rottable)
                        ? ParseBlockSetTag(rottable)
                        : null,
                    element.GetProperty("integrity").GetSingle());

            case "gravity":
                return new GravityProcessor(
                    element.TryGetProperty("heightmap", out JsonElement heightmap)
                        ? ParseHeightmap(heightmap.GetString()!)
                        : HeightmapType.WorldSurfaceWorldgen,
                    element.TryGetProperty("offset", out JsonElement offset)
                        ? offset.GetInt32()
                        : 0);

            case "protected_blocks":
                return new ProtectedBlockProcessor(ParseBlockSetTag(element.GetProperty("value"))
                    ?? throw new FormatException(
                        "A protected_blocks processor names a block list rather than a tag, which "
                        + "no vanilla list does and nothing here reads."));

            case "blackstone_replace":
                return BlackstoneReplaceProcessor.Instance;

            case "lava_submerged_block":
                return LavaSubmergedBlockProcessor.Instance;

            case "jigsaw_replacement":
                return JigsawReplacementProcessor.Instance;

            case "block_age":
                return new BlockAgeProcessor(element.GetProperty("mossiness").GetSingle());

            case "rule":
                return new RuleProcessor(element.GetProperty("rules").EnumerateArray()
                    .Select(ParseRule).ToList());

            case "capped":
                return new CappedProcessor(Parse(element.GetProperty("delegate")),
                    ValueParser.ParseInt(element.GetProperty("limit")));

            default:
                throw new FormatException($"Unknown structure processor type \"{type}\".");
        }
    }

    private ProcessorRule ParseRule(JsonElement element) {
        return new ProcessorRule(
            ParseRuleTest(element.GetProperty("input_predicate")),
            ParseRuleTest(element.GetProperty("location_predicate")),
            element.TryGetProperty("position_predicate", out JsonElement position)
                ? ParsePosRuleTest(position)
                : IPosRuleTest.AlwaysTrue.Instance,
            _states.ParseBlockState(element.GetProperty("output_state")),
            element.TryGetProperty("block_entity_modifier", out JsonElement modifier)
                ? ParseBlockEntityModifier(modifier)
                : IRuleBlockEntityModifier.Passthrough.Instance);
    }

    private IRuleTest ParseRuleTest(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("predicate_type").GetString()!).Key;

        return type switch {
            "always_true" => IRuleTest.AlwaysTrue.Instance,

            "block_match" => new IRuleTest.BlockMatch(
                Identifier.Parse(element.GetProperty("block").GetString()!)),

            "blockstate_match" => new IRuleTest.BlockStateMatch(
                _states.ParseBlockState(element.GetProperty("block_state"))),

            "tag_match" => new IRuleTest.TagMatch(
                Identifier.Parse(element.GetProperty("tag").GetString()!)),

            "random_block_match" => new IRuleTest.RandomBlockMatch(
                Identifier.Parse(element.GetProperty("block").GetString()!),
                element.GetProperty("probability").GetSingle()),

            "random_blockstate_match" => new IRuleTest.RandomBlockStateMatch(
                _states.ParseBlockState(element.GetProperty("block_state")),
                element.GetProperty("probability").GetSingle()),

            _ => throw new FormatException($"Unknown structure rule test type \"{type}\".")
        };
    }

    private static IPosRuleTest ParsePosRuleTest(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("predicate_type").GetString()!).Key;

        float minChance = Optional(element, "min_chance");
        float maxChance = Optional(element, "max_chance");
        int minDist = OptionalInt(element, "min_dist");
        int maxDist = OptionalInt(element, "max_dist");

        return type switch {
            "always_true" => IPosRuleTest.AlwaysTrue.Instance,

            "linear_pos" => new IPosRuleTest.LinearPos(minChance, maxChance, minDist, maxDist),

            "axis_aligned_linear_pos" => new IPosRuleTest.AxisAlignedLinearPos(minChance, maxChance,
                minDist, maxDist,
                element.TryGetProperty("axis", out JsonElement axis)
                    ? ParseAxis(axis.GetString()!)
                    : Axis.Y),

            _ => throw new FormatException($"Unknown structure position rule test type \"{type}\".")
        };
    }

    private static IRuleBlockEntityModifier ParseBlockEntityModifier(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("type").GetString()!).Key;

        return type switch {
            "passthrough" => IRuleBlockEntityModifier.Passthrough.Instance,
            "clear" => IRuleBlockEntityModifier.Clear.Instance,

            "append_loot" => new IRuleBlockEntityModifier.AppendLoot(
                Identifier.Parse(element.GetProperty("loot_table").GetString()!)),

            // The one member of this family that is only ever about a block entity's contents, which
            // there is no port of. No vanilla list uses it, so it fails rather than being read as a
            // tag whose values would then be dropped.
            "append_static" => throw new FormatException(
                "The append_static block entity modifier writes block entity contents, which this "
                + "build does not read."),

            _ => throw new FormatException(
                $"Unknown structure rule block entity modifier type \"{type}\".")
        };
    }

    /// <summary>
    /// A block set that every vanilla use of writes as a tag reference.
    /// </summary>
    /// <remarks>
    /// Null for an absent key, which <c>block_rot</c> reads as "everything rots". A literal list is
    /// possible in the format and appears nowhere, so it throws rather than being half supported: the
    /// tag membership test the processors use is by tag id.
    /// </remarks>
    private static Identifier? ParseBlockSetTag(JsonElement element) {
        if (element.ValueKind != JsonValueKind.String) {
            throw new FormatException(
                "A structure processor names a literal block list where this build reads a tag.");
        }

        string written = element.GetString()!;

        return written.StartsWith('#')
            ? Identifier.Parse(written[1..])
            : throw new FormatException(
                $"A structure processor names the block \"{written}\" where this build reads a tag.");
    }

    private static HeightmapType ParseHeightmap(string value) {
        return value switch {
            "WORLD_SURFACE_WG" => HeightmapType.WorldSurfaceWorldgen,
            "WORLD_SURFACE" => HeightmapType.WorldSurface,
            "OCEAN_FLOOR_WG" => HeightmapType.OceanFloorWorldgen,
            "OCEAN_FLOOR" => HeightmapType.OceanFloor,
            "MOTION_BLOCKING" => HeightmapType.MotionBlocking,
            "MOTION_BLOCKING_NO_LEAVES" => HeightmapType.MotionBlockingNoLeaves,
            _ => throw new FormatException($"Unknown heightmap \"{value}\".")
        };
    }

    private static Axis ParseAxis(string value) {
        return value switch {
            "x" => Axis.X,
            "y" => Axis.Y,
            "z" => Axis.Z,
            _ => throw new FormatException($"Unknown axis \"{value}\".")
        };
    }

    private static float Optional(JsonElement element, string name) {
        return element.TryGetProperty(name, out JsonElement value) ? value.GetSingle() : 0.0f;
    }

    private static int OptionalInt(JsonElement element, string name) {
        return element.TryGetProperty(name, out JsonElement value) ? value.GetInt32() : 0;
    }
}
