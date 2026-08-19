using System.Text.Json;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Noise;
using ManagedServer.Terrain.Surface;
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
/// A block state goes through <c>SurfaceRuleParser</c>, which is the same <c>BlockState</c> codec the
/// surface rules read, so a property name is resolved once and in one place.
/// </remarks>
public sealed class BlockParser(MinecraftRegistry registry) {
    private readonly SurfaceRuleParser _states = new(registry);

    public MinecraftRegistry Registry => registry;

    /// <summary>A block state, as an <see cref="IBlock"/> rather than an id.</summary>
    public IBlock ParseState(JsonElement element) {
        return registry.Blocks.GetByStateId(_states.ParseBlockState(element));
    }

    public uint ParseStateId(JsonElement element) => _states.ParseBlockState(element);

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

    public BlockStateProvider ParseProvider(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        switch (type) {
            case "simple_state_provider":
                return new BlockStateProvider.Simple(ParseState(element.GetProperty("state")));

            case "weighted_state_provider":
                return new BlockStateProvider.Weighted(
                    ValueParser.ParseWeightedList(element.GetProperty("entries"), ParseState));

            case "rotated_block_provider":
                return new BlockStateProvider.Rotated(ParseState(element.GetProperty("state")));

            case "randomized_int_state_provider": {
                string property = element.GetProperty("property").GetString()!;
                if (property != "age") {
                    // Every use in the vanilla data is "age", which resolves through the generated
                    // IAged interface. Going through WithState(CompoundTag) instead would silently
                    // ignore a name the block does not have, so a new one upstream fails here.
                    throw new FormatException(
                        $"randomized_int_state_provider can only redraw \"age\", not \"{property}\".");
                }

                return new BlockStateProvider.RandomizedAge(ParseProvider(element.GetProperty("source")),
                    ValueParser.ParseInt(element.GetProperty("values")));
            }

            case "rule_based_state_provider": {
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

            case "noise_threshold_provider":
                return new BlockStateProvider.NoiseThreshold(
                    element.GetProperty("seed").GetInt64(),
                    ParseNoiseParameters(element.GetProperty("noise")),
                    element.GetProperty("scale").GetSingle(),
                    element.GetProperty("threshold").GetSingle(),
                    element.GetProperty("high_chance").GetSingle(),
                    ParseState(element.GetProperty("default_state")),
                    ParseStates(element.GetProperty("low_states")),
                    ParseStates(element.GetProperty("high_states")));

            case "noise_provider":
                return new BlockStateProvider.Noise(
                    element.GetProperty("seed").GetInt64(),
                    ParseNoiseParameters(element.GetProperty("noise")),
                    element.GetProperty("scale").GetSingle(),
                    ParseStates(element.GetProperty("states")));

            case "dual_noise_provider": {
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
        if (!element.TryGetProperty("offset", out JsonElement offset)) {
            return new Vec3<int>(0, 0, 0);
        }

        return new Vec3<int>(offset[0].GetInt32(), offset[1].GetInt32(), offset[2].GetInt32());
    }

    /// <summary>
    /// A <c>HolderSet</c> of blocks or fluids: a single id, a list of ids, or a <c>#tag</c> reference.
    /// </summary>
    /// <remarks>
    /// Only the block form ever carries a tag in the vanilla data, and it is resolved through the
    /// block tag registry here so a tag of fluids would fail rather than silently matching nothing.
    /// </remarks>
    public IReadOnlySet<Identifier> ParseIdentifierSet(JsonElement element) {
        HashSet<Identifier> ids = [];

        if (element.ValueKind == JsonValueKind.String) {
            AddIdentifier(ids, element.GetString()!);
            return ids;
        }

        foreach (JsonElement entry in element.EnumerateArray()) {
            AddIdentifier(ids, entry.GetString()!);
        }

        return ids;
    }

    private void AddIdentifier(HashSet<Identifier> ids, string value) {
        if (!value.StartsWith('#')) {
            ids.Add(Identifier.Parse(value));
            return;
        }

        Identifier tag = Identifier.Parse(value[1..]);
        if (!registry.Blocks.Tags.Contains(tag)) {
            throw new FormatException($"No block tag registered as \"{tag}\".");
        }

        foreach (Identifier member in registry.Blocks.Tags[tag].GetValueIds(registry)) {
            ids.Add(member);
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

    /// <summary>Inline noise parameters, the same shape the noise registry files use.</summary>
    public static NoiseParameters ParseNoiseParameters(JsonElement element) {
        List<double> amplitudes = [];
        foreach (JsonElement amplitude in element.GetProperty("amplitudes").EnumerateArray()) {
            amplitudes.Add(amplitude.GetDouble());
        }

        return new NoiseParameters(element.GetProperty("firstOctave").GetInt32(), amplitudes);
    }
}
