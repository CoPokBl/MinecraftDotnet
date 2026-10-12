using System.Text.Json;
using ManagedServer.Fluids;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Placement;
using ManagedServer.Terrain.Features.Trees;
using ManagedServer.Terrain.Features.Types;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Fluids;

namespace ManagedServer.Terrain.Features;

/// <summary>
/// Raised when a configured feature names a type that is deliberately not ported.
/// </summary>
/// <remarks>
/// Separate from <see cref="FormatException"/> because the two mean opposite things. A format
/// exception is a datapack this build does not understand, which has to fail the load; this is a
/// feature this build knows it has not transcribed, which is a named gap the loader records and skips.
/// </remarks>
public sealed class FeatureNotPortedException(string type)
    : Exception($"The \"{type}\" feature type is not transcribed.") {

    public string FeatureType => type;
}

/// <summary>
/// The <c>ConfiguredFeature</c> codec, as a parser.
/// </summary>
/// <remarks>
/// <b>An unknown type throws and a known but untranscribed one is skipped</b>, and the difference is
/// the point. A feature silently reading as nothing produces a world that generates and is missing
/// something, which is far harder to notice than a failure at load, so only the names on
/// <see cref="NotTranscribed"/> may be absent and everything else fails the build's own data.
/// </remarks>
public sealed class FeatureParser(BlockParser blocks, PlacementParser placement,
    Func<Identifier, PlacedFeature?> resolvePlaced, Func<Identifier, ConfiguredFeature?> resolveConfigured,
    StructureTemplateManager templates, ProcessorLists processorLists) {

    /// <summary>
    /// The feature types this build does not transcribe, each with why.
    /// </summary>
    /// <remarks>
    /// Every one of these needs a subsystem that does not exist here rather than being merely long:
    /// a structure template loader, a block entity, or a dimension whose terrain is not generated.
    /// <p/>
    /// A biome asking for one of these loses that feature and keeps the rest of its list, and the
    /// global feature order is unaffected because it is keyed on the placed features that did load.
    /// </remarks>
    public static readonly IReadOnlyDictionary<string, string> NotTranscribed = new Dictionary<string, string> {
        ["bonus_chest"] = "needs a chest block entity and a loot table roll at generation time",
        ["end_gateway"] = "needs an end gateway block entity",
        ["end_spike"] = "needs the ender crystal entity and its block entity",
        ["end_platform"] = "the end is not generated",
        ["end_island"] = "the end is not generated",
        ["void_start_platform"] = "only reachable in the void world preset",
        ["chorus_plant"] = "the end is not generated",
    };

    /// <summary>
    /// The types dropped out of a selector or a sequence since this was last drained.
    /// </summary>
    /// <remarks>
    /// A nested entry that cannot be built is dropped rather than failing its parent, which is what
    /// lets a selector lose one branch and keep the rest. Without this the drop is <b>silent</b>: the
    /// parent parses, the world generates, and one of the things it should have contained is simply
    /// absent, which is the failure this build's whole reporting discipline exists to prevent.
    /// <p/>
    /// Drained by the loader once the feature holding them has parsed, since only the loader knows
    /// which feature that was.
    /// </remarks>
    public readonly List<string> DroppedNested = [];

    public ConfiguredFeature Parse(JsonElement element) {
        string type = ValueParser.TypeOf(element);
        JsonElement config = element.TryGetProperty("config", out JsonElement c) ? c : default;

        if (NotTranscribed.ContainsKey(type)) {
            throw new FeatureNotPortedException(type);
        }

        switch (type) {
            case "no_op":
                return NoOpFeature.Instance;

            case "desert_well":
                return DesertWellFeature.Instance;

            case "monster_room":
                return MonsterRoomFeature.Instance;

            case "fossil":
                return new FossilFeature(templates,
                    Identifiers(config.GetProperty("fossil_structures")),
                    Identifiers(config.GetProperty("overlay_structures")),
                    Processors(config.GetProperty("fossil_processors")),
                    Processors(config.GetProperty("overlay_processors")),
                    config.GetProperty("max_empty_corners_allowed").GetInt32());

            case "template":
                return new TemplateFeature(templates, ParseTemplateEntries(config));

            case "freeze_top_layer":
                return SnowAndFreezeFeature.Instance;

            case "simple_block":
                return new SimpleBlockFeature(blocks.ParseProvider(config.GetProperty("to_place")));

            case "random_selector": {
                List<(float, PlacedFeature)> features = [];
                foreach (JsonElement entry in config.GetProperty("features").EnumerateArray()) {
                    if (ParseNested(entry.GetProperty("feature")) is { } nested) {
                        features.Add((entry.GetProperty("chance").GetSingle(), nested));
                    }
                }

                PlacedFeature? fallback = ParseNested(config.GetProperty("default"));
                if (fallback is null) {
                    throw new FeatureNotPortedException("random_selector default");
                }

                return new RandomSelectorFeature(features, fallback);
            }

            case "simple_random_selector":
                return new SimpleRandomSelectorFeature(
                    ParseNestedList(config.GetProperty("features"), "simple_random_selector"));

            case "random_boolean_selector": {
                PlacedFeature? ifTrue = ParseNested(config.GetProperty("feature_true"));
                PlacedFeature? ifFalse = ParseNested(config.GetProperty("feature_false"));

                if (ifTrue is null || ifFalse is null) {
                    throw new FeatureNotPortedException("random_boolean_selector branch");
                }

                return new RandomBooleanSelectorFeature(ifTrue, ifFalse);
            }

            case "sequence":
                return new SequenceFeature(ParseNestedList(config.GetProperty("features"), "sequence"));

            case "ore":
                return new OreFeature(config.GetProperty("size").GetInt32(),
                    ValueParser.OptionalFloat(config, "discard_chance_on_air_exposure", 0.0f),
                    ParseOreTargets(config.GetProperty("targets")));

            case "sculk_patch":
                return new SculkPatchFeature(config.GetProperty("charge_count").GetInt32(),
                    config.GetProperty("amount_per_charge").GetInt32(),
                    config.GetProperty("spread_attempts").GetInt32(),
                    config.GetProperty("spread_rounds").GetInt32(),
                    config.GetProperty("growth_rounds").GetInt32(),
                    config.GetProperty("catalyst_chance").GetSingle(),
                    ValueParser.ParseInt(config.GetProperty("extra_rare_growths")));

            case "scattered_ore":
                return new ScatteredOreFeature(config.GetProperty("size").GetInt32(),
                    ValueParser.OptionalFloat(config, "discard_chance_on_air_exposure", 0.0f),
                    ParseOreTargets(config.GetProperty("targets")));

            case "disk":
                return new DiskFeature(blocks.ParseProvider(config.GetProperty("state_provider")),
                    blocks.ParsePredicate(config.GetProperty("target")),
                    ValueParser.ParseInt(config.GetProperty("radius")),
                    config.GetProperty("half_height").GetInt32());

            case "block_pile":
                return new BlockPileFeature(blocks.ParseProvider(config.GetProperty("state_provider")));

            case "vegetation_patch":
            case "waterlogged_vegetation_patch":
                return ParseVegetationPatch(type, config);

            case "tree":
                return new TreeFeature(ParseTree(config));

            case "spring_feature":
                return new SpringFeature(ParseFluidStateAsBlock(config.GetProperty("state")),
                    ValueParser.OptionalBool(config, "requires_block_below", true),
                    ValueParser.OptionalInt(config, "rock_count", 4),
                    ValueParser.OptionalInt(config, "hole_count", 1),
                    blocks.ParseIdentifierSet(config.GetProperty("valid_blocks")));

            case "block_column":
                return new BlockColumnFeature(ParseColumnLayers(config.GetProperty("layers")),
                    BlockParser.ParseDirection(config.GetProperty("direction").GetString()!),
                    blocks.ParsePredicate(config.GetProperty("allowed_placement")),
                    config.GetProperty("prioritize_tip").GetBoolean());

            case "vines":
                return VinesFeature.Instance;

            case "block_blob":
                return new BlockBlobFeature(blocks.ParseStateId(config.GetProperty("state")),
                    blocks.ParsePredicate(config.GetProperty("can_place_on")));

            case "netherrack_replace_blobs":
                return new ReplaceBlobsFeature(
                    blocks.ParseState(config.GetProperty("target")).Identifier,
                    blocks.ParseStateId(config.GetProperty("state")),
                    ValueParser.ParseInt(config.GetProperty("radius")));

            case "glowstone_blob":
                return GlowstoneFeature.Instance;

            case "blue_ice":
                return BlueIceFeature.Instance;

            case "basalt_pillar":
                return BasaltPillarFeature.Instance;

            case "spike":
                return new SpikeFeature(blocks.ParseStateId(config.GetProperty("state")),
                    blocks.ParsePredicate(config.GetProperty("can_place_on")),
                    blocks.ParsePredicate(config.GetProperty("can_replace")));

            case "geode": {
                JsonElement geodeBlocks = config.GetProperty("blocks");
                JsonElement layers = config.GetProperty("layers");
                JsonElement crack = config.GetProperty("crack");

                List<IBlock> placements = [];
                foreach (JsonElement state in geodeBlocks.GetProperty("inner_placements").EnumerateArray()) {
                    placements.Add(blocks.ParseState(state));
                }

                return new GeodeFeature(
                    blocks.ParseProvider(geodeBlocks.GetProperty("filling_provider")),
                    blocks.ParseProvider(geodeBlocks.GetProperty("inner_layer_provider")),
                    blocks.ParseProvider(geodeBlocks.GetProperty("alternate_inner_layer_provider")),
                    blocks.ParseProvider(geodeBlocks.GetProperty("middle_layer_provider")),
                    blocks.ParseProvider(geodeBlocks.GetProperty("outer_layer_provider")),
                    placements,
                    blocks.ParseIdentifierSet(geodeBlocks.GetProperty("cannot_replace")),
                    blocks.ParseIdentifierSet(geodeBlocks.GetProperty("invalid_blocks")),
                    new GeodeLayerSettings(ValueParser.OptionalDouble(layers, "filling", 1.7),
                        ValueParser.OptionalDouble(layers, "inner_layer", 2.2),
                        ValueParser.OptionalDouble(layers, "middle_layer", 3.2),
                        ValueParser.OptionalDouble(layers, "outer_layer", 4.2)),
                    new GeodeCrackSettings(ValueParser.OptionalDouble(crack, "generate_crack_chance", 1.0),
                        ValueParser.OptionalDouble(crack, "base_crack_size", 2.0),
                        ValueParser.OptionalInt(crack, "crack_point_offset", 2)),
                    ValueParser.OptionalDouble(config, "use_potential_placements_chance", 0.35),
                    ValueParser.OptionalDouble(config, "use_alternate_layer0_chance", 0.0),
                    ValueParser.OptionalBool(config, "placements_require_layer0_alternate", true),
                    config.TryGetProperty("outer_wall_distance", out JsonElement wall)
                        ? ValueParser.ParseInt(wall)
                        : new IntProviders.Uniform(4, 5),
                    config.TryGetProperty("distribution_points", out JsonElement dist)
                        ? ValueParser.ParseInt(dist)
                        : new IntProviders.Uniform(3, 4),
                    config.TryGetProperty("point_offset", out JsonElement point)
                        ? ValueParser.ParseInt(point)
                        : new IntProviders.Uniform(1, 2),
                    ValueParser.OptionalInt(config, "min_gen_offset", -16),
                    ValueParser.OptionalInt(config, "max_gen_offset", 16),
                    ValueParser.OptionalDouble(config, "noise_multiplier", 0.05),
                    config.GetProperty("invalid_blocks_threshold").GetInt32());
            }

            case "large_dripstone":
                return new LargeDripstoneFeature(
                    ValueParser.OptionalInt(config, "floor_to_ceiling_search_range", 30),
                    ValueParser.ParseInt(config.GetProperty("column_radius")),
                    ValueParser.ParseFloat(config.GetProperty("height_scale")),
                    config.GetProperty("max_column_radius_to_cave_height_ratio").GetSingle(),
                    ValueParser.ParseFloat(config.GetProperty("stalactite_bluntness")),
                    ValueParser.ParseFloat(config.GetProperty("stalagmite_bluntness")),
                    ValueParser.ParseFloat(config.GetProperty("wind_speed")),
                    config.GetProperty("min_radius_for_wind").GetInt32(),
                    config.GetProperty("min_bluntness_for_wind").GetSingle(),
                    blocks.ParseIdentifierSet(config.GetProperty("replaceable_blocks")));

            case "speleothem":
                return new SpeleothemFeature(blocks.ParseStateId(config.GetProperty("base_block")),
                    blocks.ParseStateId(config.GetProperty("pointed_block")),
                    blocks.ParseIdentifierSet(config.GetProperty("replaceable_blocks")),
                    ValueParser.OptionalFloat(config, "chance_of_taller_generation", 0.2f),
                    ValueParser.OptionalFloat(config, "chance_of_directional_spread", 0.7f),
                    ValueParser.OptionalFloat(config, "chance_of_spread_radius2", 0.5f),
                    ValueParser.OptionalFloat(config, "chance_of_spread_radius3", 0.5f));

            case "speleothem_cluster":
                return new SpeleothemClusterFeature(blocks.ParseStateId(config.GetProperty("base_block")),
                    blocks.ParseStateId(config.GetProperty("pointed_block")),
                    blocks.ParseIdentifierSet(config.GetProperty("replaceable_blocks")),
                    config.GetProperty("floor_to_ceiling_search_range").GetInt32(),
                    ValueParser.ParseInt(config.GetProperty("height")),
                    ValueParser.ParseInt(config.GetProperty("radius")),
                    config.GetProperty("max_stalagmite_stalactite_height_diff").GetInt32(),
                    ValueParser.ParseInt(config.GetProperty("speleothem_block_layer_thickness")),
                    ValueParser.ParseFloat(config.GetProperty("density")),
                    ValueParser.ParseFloat(config.GetProperty("wetness")),
                    config.GetProperty("chance_of_speleothem_at_max_distance_from_center").GetSingle(),
                    config.GetProperty("max_distance_from_edge_affecting_chance_of_speleothem").GetInt32(),
                    config.GetProperty("max_distance_from_center_affecting_height_bias").GetInt32(),
                    config.GetProperty("height_deviation").GetSingle());

            case "huge_fungus":
                return new HugeFungusFeature(blocks.ParseStateId(config.GetProperty("valid_base_block")),
                    blocks.ParseStateId(config.GetProperty("stem_state")),
                    blocks.ParseStateId(config.GetProperty("hat_state")),
                    blocks.ParseStateId(config.GetProperty("decor_state")),
                    blocks.ParsePredicate(config.GetProperty("replaceable_blocks")),
                    ValueParser.OptionalBool(config, "planted", false));

            case "fallen_tree":
                return new FallenTreeFeature(blocks.ParseProvider(config.GetProperty("trunk_provider")),
                    ValueParser.ParseInt(config.GetProperty("log_length")),
                    ParseDecorators(config, "stump_decorators"),
                    ParseDecorators(config, "log_decorators"));

            case "iceberg":
                return new IcebergFeature(blocks.ParseStateId(config.GetProperty("state")));

            case "basalt_columns":
                return new BasaltColumnsFeature(ValueParser.ParseInt(config.GetProperty("reach")),
                    ValueParser.ParseInt(config.GetProperty("height")));

            case "delta_feature":
                return new DeltaFeature(blocks.ParseStateId(config.GetProperty("contents")),
                    blocks.ParseStateId(config.GetProperty("rim")),
                    ValueParser.ParseInt(config.GetProperty("size")),
                    ValueParser.ParseInt(config.GetProperty("rim_size")));

            case "coral_tree":
                return CoralTreeFeature.Instance;

            case "coral_claw":
                return CoralClawFeature.Instance;

            case "coral_mushroom":
                return CoralMushroomFeature.Instance;

            case "weighted_random_selector": {
                List<(PlacedFeature, int)> weighted = [];
                foreach (JsonElement entry in config.GetProperty("features").EnumerateArray()) {
                    if (ParseNested(entry.GetProperty("data")) is { } nested) {
                        weighted.Add((nested, entry.GetProperty("weight").GetInt32()));
                    }
                }

                return new WeightedRandomSelectorFeature(weighted);
            }

            case "nether_forest_vegetation":
                return new NetherForestVegetationFeature(
                    blocks.ParseProvider(config.GetProperty("state_provider")),
                    config.GetProperty("spread_width").GetInt32(),
                    config.GetProperty("spread_height").GetInt32());

            case "twisting_vines":
                return new TwistingVinesFeature(config.GetProperty("spread_width").GetInt32(),
                    config.GetProperty("spread_height").GetInt32(),
                    config.GetProperty("max_height").GetInt32());

            case "weeping_vines":
                return WeepingVinesFeature.Instance;

            case "huge_brown_mushroom":
                return new HugeBrownMushroomFeature(blocks.ParseProvider(config.GetProperty("cap_provider")),
                    blocks.ParseProvider(config.GetProperty("stem_provider")),
                    ValueParser.OptionalInt(config, "foliage_radius", 2),
                    blocks.ParsePredicate(config.GetProperty("can_place_on")));

            case "huge_red_mushroom":
                return new HugeRedMushroomFeature(blocks.ParseProvider(config.GetProperty("cap_provider")),
                    blocks.ParseProvider(config.GetProperty("stem_provider")),
                    ValueParser.OptionalInt(config, "foliage_radius", 2),
                    blocks.ParsePredicate(config.GetProperty("can_place_on")));

            case "lake":
                return new LakeFeature(blocks.ParseProvider(config.GetProperty("fluid")),
                    blocks.ParseProvider(config.GetProperty("barrier")),
                    blocks.ParsePredicate(config.GetProperty("can_place_feature")),
                    blocks.ParsePredicate(config.GetProperty("can_replace_with_air_or_fluid")),
                    blocks.ParsePredicate(config.GetProperty("can_replace_with_barrier")));

            case "root_system":
                return new RootSystemFeature(
                    ParseNestedOrThrow(config.GetProperty("feature")),
                    config.GetProperty("required_vertical_space_for_tree").GetInt32(),
                    config.GetProperty("root_radius").GetInt32(),
                    blocks.ParseIdentifierSet(config.GetProperty("root_replaceable")),
                    blocks.ParseProvider(config.GetProperty("root_state_provider")),
                    config.GetProperty("root_placement_attempts").GetInt32(),
                    config.GetProperty("root_column_max_height").GetInt32(),
                    config.GetProperty("hanging_root_radius").GetInt32(),
                    config.GetProperty("hanging_roots_vertical_span").GetInt32(),
                    blocks.ParseProvider(config.GetProperty("hanging_root_state_provider")),
                    config.GetProperty("hanging_root_placement_attempts").GetInt32(),
                    config.GetProperty("allowed_vertical_water_for_tree").GetInt32(),
                    blocks.ParsePredicate(config.GetProperty("allowed_tree_position")),
                    config.GetProperty("level_test_distance").GetInt32(),
                    config.GetProperty("max_level_deviation").GetInt32());

            case "multiface_growth":
                return new MultifaceGrowthFeature(
                    blocks.Registry.Blocks[Identifier.Parse(config.GetProperty("block").GetString()!)],
                    ValueParser.OptionalInt(config, "search_range", 10),
                    ValueParser.OptionalBool(config, "can_place_on_floor", false),
                    ValueParser.OptionalBool(config, "can_place_on_ceiling", false),
                    ValueParser.OptionalBool(config, "can_place_on_wall", false),
                    ValueParser.OptionalFloat(config, "chance_of_spreading", 0.5f),
                    blocks.ParseIdentifierSet(config.GetProperty("can_be_placed_on")));

            case "seagrass":
                return new SeagrassFeature(config.GetProperty("probability").GetDouble());

            case "kelp":
                return KelpFeature.Instance;

            case "sea_pickle":
                return new SeaPickleFeature(ValueParser.ParseInt(config.GetProperty("count")));

            case "bamboo":
                return new BambooFeature(config.GetProperty("probability").GetSingle());

            case "underwater_magma":
                return new UnderwaterMagmaFeature(config.GetProperty("floor_search_range").GetInt32(),
                    config.GetProperty("placement_radius_around_floor").GetInt32(),
                    config.GetProperty("placement_probability_per_valid_position").GetSingle());

            default:
                throw new FormatException($"Unknown configured feature type \"{type}\".");
        }
    }

    /// <summary>
    /// A <b>fluid</b> state, as the block that holds it. Only <c>spring_feature</c> carries one.
    /// </summary>
    /// <remarks>
    /// Not a block state, though it is spelled like one: <c>minecraft:water</c> here names the fluid,
    /// whose properties are <c>falling</c> and <c>level</c> rather than the block's single
    /// <c>level</c>. Reading it with <see cref="BlockParser.ParseState"/> would find a block of the
    /// same name and <b>silently drop</b> both, since <c>WithState</c> ignores a key the block does
    /// not have, so a falling spring would come out as a source.
    /// <p/>
    /// The conversion is <c>FlowingFluid.getLegacyLevel</c>, shared with the fluid simulation rather
    /// than written out again here.
    /// </remarks>
    private uint ParseFluidStateAsBlock(JsonElement element) {
        string name = element.GetProperty("Name").GetString()!;

        bool falling = false;
        int amount = 8;

        if (element.TryGetProperty("Properties", out JsonElement properties)) {
            if (properties.TryGetProperty("falling", out JsonElement fallingValue)) {
                falling = fallingValue.GetString() == "true";
            }

            if (properties.TryGetProperty("level", out JsonElement levelValue)) {
                amount = int.Parse(levelValue.GetString()!);
            }
        }

        // The flowing form of a fluid is a separate registry entry from its source, and which one it
        // is decides the level outright.
        bool source = !name.Contains("flowing_");

        FluidKind kind = name.Replace("flowing_", "") switch {
            "minecraft:water" => FluidKind.Water,
            "minecraft:lava" => FluidKind.Lava,
            _ => throw new FormatException($"Unknown fluid \"{name}\".")
        };

        int level = new FluidState(kind, source, amount, falling).ToLegacyLevel;

        return kind == FluidKind.Water
            ? ((WaterBlock)Block.Water with { Level = level }).StateId
            : ((LavaBlock)Block.Lava with { Level = level }).StateId;
    }

    private List<BlockColumnLayer> ParseColumnLayers(JsonElement element) {
        List<BlockColumnLayer> layers = [];

        foreach (JsonElement layer in element.EnumerateArray()) {
            layers.Add(new BlockColumnLayer(ValueParser.ParseInt(layer.GetProperty("height")),
                blocks.ParseProvider(layer.GetProperty("provider"))));
        }

        return layers;
    }

    private List<OreTarget> ParseOreTargets(JsonElement element) {
        List<OreTarget> targets = [];

        foreach (JsonElement entry in element.EnumerateArray()) {
            targets.Add(new OreTarget(ParseRuleTest(entry.GetProperty("target")),
                blocks.ParseState(entry.GetProperty("state"))));
        }

        return targets;
    }

    /// <summary>
    /// A <c>RuleTest</c>, which is the ore features' own predicate type rather than a
    /// <c>BlockPredicate</c>.
    /// </summary>
    /// <remarks>
    /// It is keyed on <c>predicate_type</c> and not <c>type</c>, and it tests a state it is handed
    /// rather than a position. Mapped onto a <see cref="BlockPredicate"/> at the position because the
    /// only difference that makes is which block it reads, and it reads the one it is asked about.
    /// <p/>
    /// <c>random_block_match</c> and <c>random_blockstate_match</c> take a probability, and vanilla
    /// draws it <b>after</b> the block test. Getting the order wrong changes how much random every
    /// later ore in the chunk gets.
    /// </remarks>
    private BlockPredicate ParseRuleTest(JsonElement element) {
        string type = Identifier.Parse(element.GetProperty("predicate_type").GetString()!).Key;

        switch (type) {
            case "always_true":
                return BlockPredicate.True.Instance;

            case "block_match":
                return new BlockPredicate.MatchingBlocks(new Vec3<int>(0, 0, 0),
                    new HashSet<Identifier> { Identifier.Parse(element.GetProperty("block").GetString()!) });

            case "blockstate_match":
                return new BlockPredicate.MatchingBlocks(new Vec3<int>(0, 0, 0),
                    new HashSet<Identifier> {
                        blocks.ParseState(element.GetProperty("block_state")).Identifier
                    });

            case "tag_match":
                return new BlockPredicate.MatchingBlockTag(new Vec3<int>(0, 0, 0),
                    Identifier.Parse(element.GetProperty("tag").GetString()!));

            default:
                throw new FormatException($"Unknown rule test type \"{type}\".");
        }
    }

    private ConfiguredFeature ParseVegetationPatch(string type, JsonElement config) {
        PlacedFeature? vegetation = ParseNested(config.GetProperty("vegetation_feature"));
        if (vegetation is null) {
            throw new FeatureNotPortedException($"{type} vegetation");
        }

        Identifier replaceable = Identifier.Parse(config.GetProperty("replaceable").GetString()!.TrimStart('#'));
        BlockStateProvider ground = blocks.ParseProvider(config.GetProperty("ground_state"));
        bool ceiling = config.GetProperty("surface").GetString() == "ceiling";
        IIntProvider depth = ValueParser.ParseInt(config.GetProperty("depth"));
        float extraBottom = config.GetProperty("extra_bottom_block_chance").GetSingle();
        int verticalRange = config.GetProperty("vertical_range").GetInt32();
        float vegetationChance = config.GetProperty("vegetation_chance").GetSingle();
        IIntProvider xzRadius = ValueParser.ParseInt(config.GetProperty("xz_radius"));
        float extraEdge = config.GetProperty("extra_edge_column_chance").GetSingle();

        if (type == "waterlogged_vegetation_patch") {
            return new WaterloggedVegetationPatchFeature(replaceable, ground, vegetation, ceiling, depth,
                extraBottom, verticalRange, vegetationChance, xzRadius, extraEdge);
        }

        return new VegetationPatchFeature(replaceable, ground, vegetation, ceiling, depth, extraBottom,
            verticalRange, vegetationChance, xzRadius, extraEdge);
    }

    // --- trees --------------------------------------------------------------

    /// <summary>A named list of tree decorators, which trees and fallen trees both carry.</summary>
    private List<TreeDecorator> ParseDecorators(JsonElement config, string field) {
        List<TreeDecorator> decorators = [];

        foreach (JsonElement decorator in config.GetProperty(field).EnumerateArray()) {
            decorators.Add(ParseDecorator(decorator));
        }

        return decorators;
    }

    private TreeConfiguration ParseTree(JsonElement config) {
        List<TreeDecorator> decorators = ParseDecorators(config, "decorators");

        return new TreeConfiguration(
            blocks.ParseProvider(config.GetProperty("trunk_provider")),
            ParseTrunkPlacer(config.GetProperty("trunk_placer")),
            blocks.ParseProvider(config.GetProperty("foliage_provider")),
            ParseFoliagePlacer(config.GetProperty("foliage_placer")),
            config.TryGetProperty("root_placer", out JsonElement root) ? ParseRootPlacer(root) : null,
            // Absent for a tree that leaves the ground alone, which is every nether and mushroom one.
            config.TryGetProperty("below_trunk_provider", out JsonElement below)
                ? blocks.ParseProvider(below)
                : new BlockStateProvider.RuleBased(null, []),
            ParseFeatureSize(config.GetProperty("minimum_size")),
            decorators,
            ValueParser.OptionalBool(config, "ignore_vines", false),
            ValueParser.OptionalBool(config, "force_dirt", false));
    }

    private TrunkPlacer ParseTrunkPlacer(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        int baseHeight = element.GetProperty("base_height").GetInt32();
        int randA = element.GetProperty("height_rand_a").GetInt32();
        int randB = element.GetProperty("height_rand_b").GetInt32();

        switch (type) {
            case "straight_trunk_placer":
                return new TrunkPlacers.Straight(baseHeight, randA, randB);

            case "forking_trunk_placer":
                return new TrunkPlacers.Forking(baseHeight, randA, randB);

            case "giant_trunk_placer":
                return new TrunkPlacers.Giant(baseHeight, randA, randB);

            case "mega_jungle_trunk_placer":
                return new TrunkPlacers.MegaJungle(baseHeight, randA, randB);

            case "dark_oak_trunk_placer":
                return new TrunkPlacers.DarkOak(baseHeight, randA, randB);

            case "fancy_trunk_placer":
                return new TrunkPlacers.Fancy(baseHeight, randA, randB);

            case "bending_trunk_placer":
                return new TrunkPlacers.Bending(baseHeight, randA, randB,
                    ValueParser.OptionalInt(element, "min_height_for_leaves", 1),
                    ValueParser.ParseInt(element.GetProperty("bend_length")));

            case "upwards_branching_trunk_placer":
                return new TrunkPlacers.UpwardsBranching(baseHeight, randA, randB,
                    ValueParser.ParseInt(element.GetProperty("extra_branch_steps")),
                    element.GetProperty("place_branch_per_log_probability").GetSingle(),
                    ValueParser.ParseInt(element.GetProperty("extra_branch_length")),
                    Identifier.Parse(element.GetProperty("can_grow_through").GetString()!.TrimStart('#')));

            case "cherry_trunk_placer": {
                JsonElement start = element.GetProperty("branch_start_offset_from_top");
                return new TrunkPlacers.Cherry(baseHeight, randA, randB,
                    ValueParser.ParseInt(element.GetProperty("branch_count")),
                    ValueParser.ParseInt(element.GetProperty("branch_horizontal_length")),
                    new IntProviders.Uniform(start.GetProperty("min_inclusive").GetInt32(),
                        start.GetProperty("max_inclusive").GetInt32()),
                    ValueParser.ParseInt(element.GetProperty("branch_end_offset_from_top")));
            }

            default:
                throw new FormatException($"Unknown trunk placer type \"{type}\".");
        }
    }

    private static FoliagePlacer ParseFoliagePlacer(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        IIntProvider radius = ValueParser.ParseInt(element.GetProperty("radius"));
        IIntProvider offset = ValueParser.ParseInt(element.GetProperty("offset"));

        switch (type) {
            case "blob_foliage_placer":
                return new FoliagePlacers.Blob(radius, offset, element.GetProperty("height").GetInt32());

            case "bush_foliage_placer":
                return new FoliagePlacers.Bush(radius, offset, element.GetProperty("height").GetInt32());

            case "fancy_foliage_placer":
                return new FoliagePlacers.Fancy(radius, offset, element.GetProperty("height").GetInt32());

            case "jungle_foliage_placer":
                return new FoliagePlacers.MegaJungle(radius, offset, element.GetProperty("height").GetInt32());

            case "spruce_foliage_placer":
                return new FoliagePlacers.Spruce(radius, offset,
                    ValueParser.ParseInt(element.GetProperty("trunk_height")));

            case "pine_foliage_placer":
                return new FoliagePlacers.Pine(radius, offset,
                    ValueParser.ParseInt(element.GetProperty("height")));

            case "acacia_foliage_placer":
                return new FoliagePlacers.Acacia(radius, offset);

            case "dark_oak_foliage_placer":
                return new FoliagePlacers.DarkOak(radius, offset);

            case "mega_pine_foliage_placer":
                return new FoliagePlacers.MegaPine(radius, offset,
                    ValueParser.ParseInt(element.GetProperty("crown_height")));

            case "random_spread_foliage_placer":
                return new FoliagePlacers.RandomSpread(radius, offset,
                    ValueParser.ParseInt(element.GetProperty("foliage_height")),
                    element.GetProperty("leaf_placement_attempts").GetInt32());

            case "cherry_foliage_placer":
                return new FoliagePlacers.Cherry(radius, offset,
                    ValueParser.ParseInt(element.GetProperty("height")),
                    element.GetProperty("wide_bottom_layer_hole_chance").GetSingle(),
                    element.GetProperty("corner_hole_chance").GetSingle(),
                    element.GetProperty("hanging_leaves_chance").GetSingle(),
                    element.GetProperty("hanging_leaves_extension_chance").GetSingle());

            default:
                throw new FormatException($"Unknown foliage placer type \"{type}\".");
        }
    }

    private RootPlacer ParseRootPlacer(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        if (type != "mangrove_root_placer") {
            throw new FormatException($"Unknown root placer type \"{type}\".");
        }

        JsonElement mangrove = element.GetProperty("mangrove_root_placement");

        AboveRootPlacement? above = null;
        if (element.TryGetProperty("above_root_placement", out JsonElement abovePlacement)) {
            above = new AboveRootPlacement(
                blocks.ParseProvider(abovePlacement.GetProperty("above_root_provider")),
                abovePlacement.GetProperty("above_root_placement_chance").GetSingle());
        }

        return new MangroveRootPlacer(
            ValueParser.ParseInt(element.GetProperty("trunk_offset_y")),
            blocks.ParseProvider(element.GetProperty("root_provider")),
            above,
            mangrove.GetProperty("max_root_width").GetInt32(),
            mangrove.GetProperty("max_root_length").GetInt32(),
            mangrove.GetProperty("random_skew_chance").GetSingle(),
            Identifier.Parse(mangrove.GetProperty("can_grow_through").GetString()!.TrimStart('#')),
            blocks.ParseIdentifierSet(mangrove.GetProperty("muddy_roots_in")),
            blocks.ParseProvider(mangrove.GetProperty("muddy_roots_provider")));
    }

    private static FeatureSize ParseFeatureSize(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        int? minClipped = element.TryGetProperty("min_clipped_height", out JsonElement clipped)
            ? clipped.GetInt32()
            : null;

        switch (type) {
            case "two_layers_feature_size":
                return new FeatureSize.TwoLayers(ValueParser.OptionalInt(element, "limit", 1),
                    ValueParser.OptionalInt(element, "lower_size", 0),
                    ValueParser.OptionalInt(element, "upper_size", 1), minClipped);

            case "three_layers_feature_size":
                return new FeatureSize.ThreeLayers(ValueParser.OptionalInt(element, "limit", 1),
                    ValueParser.OptionalInt(element, "upper_limit", 1),
                    ValueParser.OptionalInt(element, "lower_size", 0),
                    ValueParser.OptionalInt(element, "middle_size", 1),
                    ValueParser.OptionalInt(element, "upper_size", 1), minClipped);

            default:
                throw new FormatException($"Unknown feature size type \"{type}\".");
        }
    }

    private TreeDecorator ParseDecorator(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        switch (type) {
            case "trunk_vine":
                return TreeDecorator.TrunkVine.Instance;

            case "leave_vine":
                return new TreeDecorator.LeaveVine(element.GetProperty("probability").GetSingle());

            case "cocoa":
                return new TreeDecorator.Cocoa(element.GetProperty("probability").GetSingle());

            case "beehive":
                return new TreeDecorator.Beehive(element.GetProperty("probability").GetSingle());

            case "alter_ground":
                return new TreeDecorator.AlterGround(blocks.ParseProvider(element.GetProperty("provider")));

            case "place_on_ground":
                return new TreeDecorator.PlaceOnGround(ValueParser.OptionalInt(element, "tries", 128),
                    ValueParser.OptionalInt(element, "radius", 2),
                    ValueParser.OptionalInt(element, "height", 1),
                    blocks.ParseProvider(element.GetProperty("block_state_provider")));

            case "attached_to_logs": {
                List<Vec3<int>> directions = [];
                foreach (JsonElement direction in element.GetProperty("directions").EnumerateArray()) {
                    directions.Add(PlacementParser.Step(BlockParser.ParseDirection(direction.GetString()!)));
                }

                return new TreeDecorator.AttachedToLogs(element.GetProperty("probability").GetSingle(),
                    blocks.ParseProvider(element.GetProperty("block_provider")), directions);
            }

            case "attached_to_leaves": {
                List<Vec3<int>> directions = [];
                foreach (JsonElement direction in element.GetProperty("directions").EnumerateArray()) {
                    directions.Add(PlacementParser.Step(BlockParser.ParseDirection(direction.GetString()!)));
                }

                return new TreeDecorator.AttachedToLeaves(
                    element.GetProperty("probability").GetSingle(),
                    element.GetProperty("exclusion_radius_xz").GetInt32(),
                    element.GetProperty("exclusion_radius_y").GetInt32(),
                    blocks.ParseProvider(element.GetProperty("block_provider")),
                    element.GetProperty("required_empty_blocks").GetInt32(),
                    directions);
            }

            case "creaking_heart":
                return new TreeDecorator.CreakingHeart(element.GetProperty("probability").GetSingle());

            case "pale_moss":
                return new TreeDecorator.PaleMoss(
                    element.GetProperty("leaves_probability").GetSingle(),
                    element.GetProperty("trunk_probability").GetSingle(),
                    element.GetProperty("ground_probability").GetSingle(),
                    () => resolveConfigured("minecraft:pale_moss_patch"));

            default:
                throw new FormatException($"Unknown tree decorator type \"{type}\".");
        }
    }

    // --- nested placed features ---------------------------------------------

    /// <summary>
    /// A nested placed feature, which is either a registry id or an inline
    /// <c>{feature, placement}</c> pair.
    /// </summary>
    /// <remarks>
    /// Null when the feature behind it is one of the untranscribed types, so the selector or sequence
    /// holding it can drop that branch rather than the whole tree failing.
    /// </remarks>
    /// <summary>
    /// A nested placed feature whose absence is fatal to the feature holding it.
    /// </summary>
    /// <remarks>
    /// Unlike <see cref="ParseNested"/> this does not swallow the failure, so the type that could not
    /// be built is the one reported rather than the outer feature. A selector can drop an entry and
    /// still mean something; a feature whose only job is to place the nested one cannot.
    /// </remarks>
    private PlacedFeature ParseNestedOrThrow(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            Identifier id = Identifier.Parse(element.GetString()!);
            return resolvePlaced(id) ?? throw new FeatureNotPortedException($"feature {id}");
        }

        ConfiguredFeature feature = ParseInlineConfigured(element.GetProperty("feature"));
        return new PlacedFeature(feature, placement.ParseAll(element.GetProperty("placement")));
    }

    private PlacedFeature? ParseNested(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            return resolvePlaced(Identifier.Parse(element.GetString()!));
        }

        try {
            ConfiguredFeature feature = ParseInlineConfigured(element.GetProperty("feature"));
            return new PlacedFeature(feature, placement.ParseAll(element.GetProperty("placement")));
        } catch (FeatureNotPortedException notPorted) {
            DroppedNested.Add(notPorted.FeatureType);
            return null;
        }
    }

    /// <summary>
    /// The <c>feature</c> field of an inline placed feature, which names a <b>configured</b> feature
    /// rather than a placed one. The two registries have overlapping names, so reading one as the
    /// other silently applies a placement chain that was never meant to run here.
    /// </summary>
    private ConfiguredFeature ParseInlineConfigured(JsonElement element) {
        if (element.ValueKind != JsonValueKind.String) {
            return Parse(element);
        }

        Identifier id = Identifier.Parse(element.GetString()!);
        return resolveConfigured(id) ?? throw new FeatureNotPortedException($"feature {id}");
    }

    /// <summary>
    /// A list of nested placed features, dropping the ones that are not transcribed.
    /// </summary>
    /// <remarks>
    /// A list that ends up <b>empty</b> is not a feature that places nothing, it is one whose whole
    /// content was skipped, so it is reported as untranscribed rather than left to draw from a list of
    /// nothing at generation time.
    /// </remarks>
    private List<PlacedFeature> ParseNestedList(JsonElement element, string owner) {
        List<PlacedFeature> features = [];
        foreach (JsonElement entry in element.EnumerateArray()) {
            if (ParseNested(entry) is { } nested) {
                features.Add(nested);
            }
        }

        if (features.Count == 0) {
            throw new FeatureNotPortedException($"{owner} entries");
        }

        return features;
    }

    /// <summary>A list of ids, which several of the template driven features carry.</summary>
    private static List<Identifier> Identifiers(JsonElement element) {
        return element.EnumerateArray().Select(entry => Identifier.Parse(entry.GetString()!)).ToList();
    }

    /// <summary>
    /// A processor list, written either as an id or inline.
    /// </summary>
    /// <remarks>
    /// The inline form is <c>{"processors": [...]}</c> rather than a bare array, which is the same
    /// shape a processor list file has.
    /// </remarks>
    private IReadOnlyList<IStructureProcessor> Processors(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            return processorLists.Get(Identifier.Parse(element.GetString()!));
        }

        return new ProcessorParser(blocks.Registry).ParseList(element);
    }

    /// <summary>
    /// A template feature's weighted list of templates, each with the turns it allows.
    /// </summary>
    /// <remarks>
    /// The template's own key is <c>id</c> rather than <c>template</c>, and <c>rotations</c> defaults
    /// to all four rather than to none: an entry allowing no rotation could never be drawn from.
    /// </remarks>
    private static WeightedList<TemplateFeatureEntry> ParseTemplateEntries(JsonElement config) {
        List<(TemplateFeatureEntry Value, int Weight)> entries = [];

        foreach (JsonElement entry in config.GetProperty("templates").EnumerateArray()) {
            JsonElement data = entry.GetProperty("data");

            List<BlockRotation> rotations = data.TryGetProperty("rotations", out JsonElement written)
                ? written.EnumerateArray().Select(rotation => ParseRotation(rotation.GetString()!))
                    .ToList()
                : AllRotations;

            if (rotations.Count == 0) {
                throw new FormatException("A template feature entry allows no rotations.");
            }

            entries.Add((new TemplateFeatureEntry(
                    Identifier.Parse(data.GetProperty("id").GetString()!), rotations),
                entry.TryGetProperty("weight", out JsonElement weight) ? weight.GetInt32() : 1));
        }

        return new WeightedList<TemplateFeatureEntry>(entries);
    }

    private static readonly List<BlockRotation> AllRotations = [
        BlockRotation.None, BlockRotation.Clockwise90, BlockRotation.Clockwise180,
        BlockRotation.CounterClockwise90
    ];

    private static BlockRotation ParseRotation(string value) {
        return value switch {
            "none" => BlockRotation.None,
            "clockwise_90" => BlockRotation.Clockwise90,
            "180" => BlockRotation.Clockwise180,
            "counterclockwise_90" => BlockRotation.CounterClockwise90,
            _ => throw new FormatException($"Unknown rotation \"{value}\".")
        };
    }
}
