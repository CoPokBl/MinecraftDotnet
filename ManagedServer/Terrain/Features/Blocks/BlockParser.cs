using System.Text.Json;
using ManagedServer.Terrain.Data;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Blocks;

/// <summary>
/// The <c>BlockPredicate</c> and <c>BlockStateProvider</c> codecs, plus the block state and block set
/// forms the two of them share.
/// </summary>
/// <remarks>
/// <b>A bare string means two different things depending on where it sits.</b> Where a block state is
/// read (<c>BlockState.CODEC</c>) it is a block's default state; where a provider is read it is a
/// <c>Holder</c> reference into the <c>worldgen/block_state_provider</c> registry, because the
/// provider codec's direct form only accepts a state as a full <c>{id, properties}</c> object.
/// Treating the second as the first turns every tree's <c>soil_beneath_tree</c> into a block that
/// does not exist, so the two entry points are kept apart.
/// </remarks>
public sealed class BlockParser(MinecraftRegistry registry, Func<Identifier, BlockStateProvider>? providers = null) {
    public MinecraftRegistry Registry => registry;

    /// <summary>A block state, as an <see cref="IBlock"/> rather than an id.</summary>
    public IBlock ParseState(JsonElement element) => StateParser.ReadJson(registry, element);

    public uint ParseStateId(JsonElement element) => ParseState(element).StateId;

    // --- block predicates ---------------------------------------------------

    public BlockPredicate ParsePredicate(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        switch (type) {
            case "true":
                return BlockPredicate.True.Instance;

            case "not":
                return new BlockPredicate.Not(ParsePredicate(element.GetProperty("predicate")));

            case "all_of":
                return new BlockPredicate.AllOf(ParsePredicates(element.GetProperty("predicates")));

            case "any_of":
                return new BlockPredicate.AnyOf(ParsePredicates(element.GetProperty("predicates")));

            case "matching_block_tag":
                return new BlockPredicate.MatchingBlockTag(ParseOffset(element),
                    Identifier.Parse(element.GetProperty("tag").GetString()!));

            case "matching_blocks":
                return new BlockPredicate.MatchingBlocks(ParseOffset(element),
                    ParseIdentifierSet(element.GetProperty("blocks")));

            case "matching_fluids":
                return new BlockPredicate.MatchingFluids(ParseOffset(element),
                    ParseIdentifierSet(element.GetProperty("fluids")));

            case "solid":
                return new BlockPredicate.Solid(ParseOffset(element));

            case "replaceable":
                return new BlockPredicate.Replaceable(ParseOffset(element));

            case "inside_world_bounds":
                return new BlockPredicate.InsideWorldBounds(ParseOffset(element));

            case "unobstructed":
                return new BlockPredicate.Unobstructed(ParseOffset(element));

            case "has_sturdy_face":
                return new BlockPredicate.HasSturdyFace(ParseOffset(element),
                    ParseDirection(element.GetProperty("direction").GetString()!));

            case "would_survive":
                return new BlockPredicate.WouldSurvive(ParseOffset(element),
                    ParseState(element.GetProperty("state")));

            case "height_range":
                return new BlockPredicate.HeightRange(
                    ValueParser.ParseAnchor(element.GetProperty("min_inclusive")),
                    ValueParser.ParseAnchor(element.GetProperty("max_inclusive")));

            case "volume_match": {
                Vec3<int> min = ParseVector(element.GetProperty("min"));
                Vec3<int> max = ParseVector(element.GetProperty("max"));

                if (min.X > max.X || min.Y > max.Y || min.Z > max.Z) {
                    throw new FormatException("volume_match has a min bound larger than its max bound.");
                }

                return new BlockPredicate.VolumeMatch(min, max, ParsePredicate(element.GetProperty("match")));
            }

            default:
                throw new FormatException($"Unknown block predicate type \"{type}\".");
        }
    }

    private List<BlockPredicate> ParsePredicates(JsonElement element) {
        List<BlockPredicate> predicates = [];
        foreach (JsonElement entry in element.EnumerateArray()) {
            predicates.Add(ParsePredicate(entry));
        }

        return predicates;
    }

    // --- block state providers ----------------------------------------------

    /// <summary>
    /// <c>BlockStateProvider.CODEC</c>: a registry reference, a full block state for a simple provider,
    /// or a typed provider.
    /// </summary>
    public BlockStateProvider ParseProvider(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            Identifier id = Identifier.Parse(element.GetString()!);
            if (providers is null) {
                throw new FormatException(
                    $"The block state provider \"{id}\" is a registry reference, and this parser has no registry.");
            }

            return providers(id);
        }

        // STATE_OR_PROVIDER_CODEC is an xor of a full state and a typed provider, so an object with no
        // type is the state.
        if (!element.TryGetProperty("type", out _)) {
            return new BlockStateProvider.Simple(ParseState(element));
        }

        string type = ValueParser.TypeOf(element);

        switch (type) {
            case "simple":
                return new BlockStateProvider.Simple(ParseState(element.GetProperty("state")));

            case "weighted":
                return new BlockStateProvider.Weighted(
                    ValueParser.ParseWeightedList(element.GetProperty("entries"), ParseState));

            case "rotated":
                return new BlockStateProvider.Rotated(ParseProvider(element.GetProperty("state")),
                    element.TryGetProperty("direction", out JsonElement direction)
                        ? ParseDirection(direction.GetString()!)
                        : null);

            case "randomized_int":
                return new BlockStateProvider.RandomizedInt(ParseProvider(element.GetProperty("source")),
                    element.GetProperty("property").GetString()!,
                    ValueParser.ParseInt(element.GetProperty("values")));

            case "rule_based": {
                List<(BlockPredicate, BlockStateProvider)> rules = [];
                foreach (JsonElement rule in element.GetProperty("rules").EnumerateArray()) {
                    rules.Add((ParsePredicate(rule.GetProperty("if_true")),
                        ParseProvider(rule.GetProperty("then"))));
                }

                BlockStateProvider? fallback = element.TryGetProperty("fallback", out JsonElement value)
                    ? ParseProvider(value)
                    : null;

                return new BlockStateProvider.RuleBased(fallback, rules);
            }

            case "copy_properties":
                return new BlockStateProvider.CopyProperties(ParseProvider(element.GetProperty("source")));

            case "random_block":
                return new BlockStateProvider.RandomBlock(ParseIdentifierList(element.GetProperty("blocks"))
                    .Select(id => registry.Blocks[id]).ToList());

            case "noise_threshold":
                return new BlockStateProvider.NoiseThreshold(
                    element.GetProperty("seed").GetInt64(),
                    ParseNoiseParameters(element.GetProperty("noise")),
                    element.GetProperty("scale").GetSingle(),
                    element.GetProperty("threshold").GetSingle(),
                    element.GetProperty("high_chance").GetSingle(),
                    ParseState(element.GetProperty("default_state")),
                    ParseStates(element.GetProperty("low_states")),
                    ParseStates(element.GetProperty("high_states")));

            case "noise":
                return new BlockStateProvider.Noise(
                    element.GetProperty("seed").GetInt64(),
                    ParseNoiseParameters(element.GetProperty("noise")),
                    element.GetProperty("scale").GetSingle(),
                    ParseStates(element.GetProperty("states")));

            case "dual_noise": {
                // An InclusiveRange, which is a two element array rather than the named pair every
                // other range in this format uses.
                JsonElement variety = element.GetProperty("variety");
                return new BlockStateProvider.DualNoise(
                    variety[0].GetInt32(), variety[1].GetInt32(),
                    ParseNoiseParameters(element.GetProperty("slow_noise")),
                    element.GetProperty("slow_scale").GetSingle(),
                    element.GetProperty("seed").GetInt64(),
                    ParseNoiseParameters(element.GetProperty("noise")),
                    element.GetProperty("scale").GetSingle(),
                    ParseStates(element.GetProperty("states")));
            }

            default:
                throw new FormatException($"Unknown block state provider type \"{type}\".");
        }
    }

    public List<IBlock> ParseStates(JsonElement element) {
        List<IBlock> states = [];
        foreach (JsonElement entry in element.EnumerateArray()) {
            states.Add(ParseState(entry));
        }

        return states;
    }

    // --- shared shapes ------------------------------------------------------

    /// <summary>
    /// The <c>offset</c> a state testing predicate carries, absent for the common "here" case.
    /// </summary>
    public static Vec3<int> ParseOffset(JsonElement element) {
        return element.TryGetProperty("offset", out JsonElement offset)
            ? ParseVector(offset)
            : new Vec3<int>(0, 0, 0);
    }

    /// <summary>A <c>Vec3i</c>, which is written as a three element array.</summary>
    public static Vec3<int> ParseVector(JsonElement element) {
        return new Vec3<int>(element[0].GetInt32(), element[1].GetInt32(), element[2].GetInt32());
    }

    /// <summary>
    /// A <c>HolderSet</c> of blocks or fluids: a single id, a list of ids, or a <c>#tag</c> reference.
    /// </summary>
    /// <remarks>
    /// Only the block form ever carries a tag in the vanilla data, and it is resolved through the
    /// block tag registry here so a tag of fluids would fail rather than silently matching nothing.
    /// </remarks>
    public IReadOnlySet<Identifier> ParseIdentifierSet(JsonElement element) {
        return ParseIdentifierList(element).ToHashSet();
    }

    /// <summary>
    /// The same holder set in its own order, for a caller that draws from it by index.
    /// </summary>
    /// <remarks>
    /// A tag keeps the order its file lists its entries in, a nested tag expanded where it is named,
    /// and a value already present is not added twice: vanilla's tag builder collects into an
    /// insertion ordered set. <c>random_block</c> indexes into it, so the order is the draw.
    /// </remarks>
    public IReadOnlyList<Identifier> ParseIdentifierList(JsonElement element) {
        List<Identifier> ids = [];
        HashSet<Identifier> seen = [];

        if (element.ValueKind == JsonValueKind.String) {
            AddIdentifier(ids, seen, element.GetString()!);
            return ids;
        }

        foreach (JsonElement entry in element.EnumerateArray()) {
            AddIdentifier(ids, seen, entry.GetString()!);
        }

        return ids;
    }

    private void AddIdentifier(List<Identifier> ids, HashSet<Identifier> seen, string value) {
        if (!value.StartsWith('#')) {
            Identifier id = Identifier.Parse(value);
            if (seen.Add(id)) {
                ids.Add(id);
            }

            return;
        }

        Identifier tag = Identifier.Parse(value[1..]);
        if (!registry.Blocks.Tags.Contains(tag)) {
            throw new FormatException($"No block tag registered as \"{tag}\".");
        }

        foreach (Identifier member in registry.Blocks.Tags[tag].GetValueIds(registry)) {
            if (seen.Add(member)) {
                ids.Add(member);
            }
        }
    }

    /// <summary><c>Direction</c> by name, as the datapack spells it.</summary>
    public static BlockFace ParseDirection(string value) {
        return value switch {
            "down" => BlockFace.NegY,
            "up" => BlockFace.PosY,
            "north" => BlockFace.NegZ,
            "south" => BlockFace.PosZ,
            "west" => BlockFace.NegX,
            "east" => BlockFace.PosX,
            _ => throw new FormatException($"Unknown direction \"{value}\".")
        };
    }

    /// <summary>Inline noise parameters, the <c>NormalNoise.Parameters</c> codec the noise registry files use.</summary>
    public static NoiseParameters ParseNoiseParameters(JsonElement element) {
        return Density.DensityFunctionParser.ParseNoiseParameters(element);
    }
}
