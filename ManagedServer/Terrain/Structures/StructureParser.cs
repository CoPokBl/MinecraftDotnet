using System.Text.Json;
using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures.Templates;
using ManagedServer.Terrain.Structures.Types;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// Reads the vanilla <c>structure</c> and <c>structure_set</c> files into the types beside this.
/// </summary>
/// <remarks>
/// <b>An unknown type throws and a named one is skipped.</b> <see cref="NotTranscribed"/> and
/// <see cref="NotYetTranscribed"/> name every structure type this build does not port with its reason,
/// and anything on neither fails the load. A structure reading as nothing would give a world that
/// generates and is missing something, which is far harder to notice than a failure at startup. Same
/// bargain as <c>FeatureParser.NotTranscribed</c> and <c>CarverParser</c>. Both lists are currently
/// empty, so every vanilla structure is built.
/// </remarks>
public sealed class StructureParser(MinecraftRegistry registry,
    StructureTemplateManager templates, TemplatePools pools) {
    /// <summary>
    /// The structure types this build does not transcribe, and why.
    /// </summary>
    /// <remarks>
    /// <b>Empty, and unlike <see cref="NotYetTranscribed"/> it has nowhere obvious to grow.</b> This
    /// half was the eight types built from NBT templates rather than from code, and it emptied when
    /// the template loader was written. A type landing here again would have to need something the
    /// build does not have at all.
    /// </remarks>
    public static readonly IReadOnlyDictionary<Identifier, string> NotTranscribed =
        new Dictionary<Identifier, string>();

    /// <summary>
    /// The code-built structure types that are transcribable and are not transcribed yet.
    /// </summary>
    /// <remarks>
    /// <b>Empty, and it should stay that way.</b> It is deliberately a separate list from
    /// <see cref="NotTranscribed"/>: one is a gap that closes by writing a port and the other a gap
    /// that closes by building a subsystem, and collapsing the two would make both look permanent.
    /// The split only means something while this half is empty, so a new code-built structure upstream
    /// goes here and comes straight back off again.
    /// </remarks>
    public static readonly IReadOnlyDictionary<Identifier, string> NotYetTranscribed =
        new Dictionary<Identifier, string>();

    /// <summary>Builds a structure, or null where its type is one of the skipped ones.</summary>
    public Structure? Parse(Identifier id, JsonElement root) {
        Identifier type = Identifier.Parse(root.GetProperty("type").GetString()!);

        if (NotTranscribed.ContainsKey(type) || NotYetTranscribed.ContainsKey(type)) {
            return null;
        }

        Structure.StructureSettings settings = ParseSettings(root);

        return type.Key switch {
            "buried_treasure" => new BuriedTreasureStructure(settings),
            "desert_pyramid" => new DesertPyramidStructure(settings),
            "fortress" => new NetherFortressStructure(settings),
            "jungle_temple" => new JungleTempleStructure(settings),
            "ocean_monument" => new OceanMonumentStructure(settings),
            "mineshaft" => new MineshaftStructure(settings, ParseMineshaftType(root)),
            "stronghold" => new StrongholdStructure(settings),
            "swamp_hut" => new SwampHutStructure(settings),

            "igloo" => new IglooStructure(settings, templates),
            "woodland_mansion" => new WoodlandMansionStructure(settings, templates),
            "end_city" => new EndCityStructure(settings, templates),

            "shipwreck" => new ShipwreckStructure(settings, templates,
                root.GetProperty("is_beached").GetBoolean()),

            "nether_fossil" => new NetherFossilStructure(settings, templates,
                ValueParser.ParseHeight(root.GetProperty("height"))),

            "ocean_ruin" => new OceanRuinStructure(settings, templates,
                ParseOceanRuinType(root.GetProperty("biome_temp").GetString()!),
                root.GetProperty("large_probability").GetSingle(),
                root.GetProperty("cluster_probability").GetSingle()),

            "ruined_portal" => new RuinedPortalStructure(settings, templates,
                root.GetProperty("setups").EnumerateArray().Select(ParseRuinedPortalSetup).ToList()),

            "jigsaw" => ParseJigsaw(settings, root),

            _ => throw new FormatException(
                $"The structure \"{id}\" has type \"{type}\", which is transcribed nowhere and is on "
                + $"neither {nameof(NotTranscribed)} nor {nameof(NotYetTranscribed)}.")
        };
    }

    /// <summary>
    /// The <c>mineshaft_type</c> field, which is the only piece of a structure file beyond the shared
    /// settings that this build reads.
    /// </summary>
    /// <remarks>
    /// It is what tells <c>minecraft:mineshaft</c> and <c>minecraft:mineshaft_mesa</c> apart, and they
    /// share the vanilla type, so it cannot be inferred from the registry id. Required rather than
    /// defaulted: vanilla's codec has no default for it either, and a mesa mineshaft silently reading
    /// as a normal one would bury it instead of putting it in the side of a plateau.
    /// </remarks>
    private static MineshaftType ParseMineshaftType(JsonElement root) {
        string value = root.GetProperty("mineshaft_type").GetString()!;

        return value switch {
            "normal" => MineshaftType.Normal,
            "mesa" => MineshaftType.Mesa,
            _ => throw new FormatException($"Unknown mineshaft type \"{value}\".")
        };
    }

    /// <summary>
    /// A jigsaw structure, which is almost entirely datapack.
    /// </summary>
    /// <remarks>
    /// <c>size</c> is the maximum depth and is capped at twenty upstream by the codec's own range; a
    /// pack asking for more is a pack asking for a structure that would never finish expanding.
    /// </remarks>
    private JigsawStructure ParseJigsaw(Structure.StructureSettings settings, JsonElement root) {
        MaxDistance maxDistance = ParseMaxDistance(root.GetProperty("max_distance_from_center"));

        JigsawPlacement.Settings placement = new(
            Identifier.Parse(root.GetProperty("start_pool").GetString()!),
            // Cast rather than a bare null: Identifier converts implicitly from string, so an
            // untyped null would be read as one and parsed.
            root.TryGetProperty("start_jigsaw_name", out JsonElement startJigsaw)
                ? Identifier.Parse(startJigsaw.GetString()!)
                : (Identifier?)null,
            root.GetProperty("size").GetInt32(),
            root.TryGetProperty("use_expansion_hack", out JsonElement hack) && hack.GetBoolean(),
            root.TryGetProperty("project_start_to_heightmap", out JsonElement heightmap)
                ? ParseHeightmap(heightmap.GetString()!)
                : null,
            maxDistance,
            root.TryGetProperty("dimension_padding", out JsonElement padding)
                ? ParsePadding(padding)
                : DimensionPadding.Zero,
            !root.TryGetProperty("liquid_settings", out JsonElement liquids)
                || PoolParser.ParseLiquidSettings(liquids.GetString()!));

        int edge = settings.TerrainAdaptation == TerrainAdjustment.None ? 0 : 12;

        if (maxDistance.Horizontal + edge > JigsawStructure.MaxTotalStructureRange) {
            throw new FormatException(
                "A jigsaw structure reaches further than 128 blocks including its terrain "
                + "adaptation, which the structure pass cannot replay.");
        }

        return new JigsawStructure(settings, templates, pools,
            ValueParser.ParseHeight(root.GetProperty("start_height")),
            root.TryGetProperty("pool_aliases", out JsonElement aliases)
                ? PoolAliasParser.ParseAll(aliases)
                : [],
            placement);
    }

    /// <summary>Either a pair or one number standing for both.</summary>
    private static MaxDistance ParseMaxDistance(JsonElement element) {
        if (element.ValueKind == JsonValueKind.Number) {
            int both = element.GetInt32();
            return new MaxDistance(both, both);
        }

        return new MaxDistance(element.GetProperty("horizontal").GetInt32(),
            element.GetProperty("vertical").GetInt32());
    }

    /// <summary>Either a pair or one number standing for both.</summary>
    private static DimensionPadding ParsePadding(JsonElement element) {
        if (element.ValueKind == JsonValueKind.Number) {
            int both = element.GetInt32();
            return new DimensionPadding(both, both);
        }

        return new DimensionPadding(element.GetProperty("bottom").GetInt32(),
            element.GetProperty("top").GetInt32());
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

    private static OceanRuinType ParseOceanRuinType(string value) {
        return value switch {
            "warm" => OceanRuinType.Warm,
            "cold" => OceanRuinType.Cold,
            _ => throw new FormatException($"Unknown ocean ruin biome temperature \"{value}\".")
        };
    }

    /// <summary>
    /// One weighted alternative of a ruined portal.
    /// </summary>
    /// <remarks>
    /// Every field is required, as vanilla's codec has it. A defaulted <c>mossiness</c> or
    /// <c>replace_with_blackstone</c> would give a portal that generates and looks like the wrong
    /// dimension's.
    /// </remarks>
    private static RuinedPortalSetup ParseRuinedPortalSetup(JsonElement element) {
        return new RuinedPortalSetup(
            ParseRuinedPortalPlacement(element.GetProperty("placement").GetString()!),
            element.GetProperty("air_pocket_probability").GetSingle(),
            element.GetProperty("mossiness").GetSingle(),
            element.GetProperty("overgrown").GetBoolean(),
            element.GetProperty("vines").GetBoolean(),
            element.GetProperty("can_be_cold").GetBoolean(),
            element.GetProperty("replace_with_blackstone").GetBoolean(),
            element.GetProperty("weight").GetSingle());
    }

    private static RuinedPortalPlacement ParseRuinedPortalPlacement(string value) {
        return value switch {
            "on_land_surface" => RuinedPortalPlacement.OnLandSurface,
            "partly_buried" => RuinedPortalPlacement.PartlyBuried,
            "on_ocean_floor" => RuinedPortalPlacement.OnOceanFloor,
            "in_mountain" => RuinedPortalPlacement.InMountain,
            "underground" => RuinedPortalPlacement.Underground,
            "in_nether" => RuinedPortalPlacement.InNether,
            _ => throw new FormatException($"Unknown ruined portal placement \"{value}\".")
        };
    }

    /// <summary>The reason a type was skipped, from whichever of the two lists names it.</summary>
    public static string? SkipReason(Identifier type) {
        if (NotTranscribed.TryGetValue(type, out string? needsSubsystem)) {
            return needsSubsystem;
        }

        return NotYetTranscribed.GetValueOrDefault(type);
    }

    private Structure.StructureSettings ParseSettings(JsonElement root) {
        return new Structure.StructureSettings(
            ParseBiomes(root.GetProperty("biomes")),
            ParseStep(root.GetProperty("step").GetString()!),
            root.TryGetProperty("terrain_adaptation", out JsonElement adaptation)
                ? ParseAdaptation(adaptation.GetString()!)
                : TerrainAdjustment.None);
    }

    /// <summary>
    /// The biome list, which every vanilla structure writes as a single tag reference.
    /// </summary>
    /// <remarks>
    /// Resolved to a flat set of ids at load, because the test is asked once per structure per
    /// candidate chunk and a tag walk per ask would be the most expensive thing in the placement
    /// path. The registry's tags are the datapack's own, so a consumer who has added a biome to
    /// <c>has_structure/...</c> gets it here.
    /// </remarks>
    private IReadOnlySet<Identifier> ParseBiomes(JsonElement biomes) {
        HashSet<Identifier> resolved = [];

        if (biomes.ValueKind == JsonValueKind.String) {
            AddBiome(resolved, biomes.GetString()!);
        } else {
            foreach (JsonElement entry in biomes.EnumerateArray()) {
                AddBiome(resolved, entry.GetString()!);
            }
        }

        return resolved;
    }

    private void AddBiome(HashSet<Identifier> into, string value) {
        if (!value.StartsWith('#')) {
            into.Add(Identifier.Parse(value));
            return;
        }

        Identifier tag = Identifier.Parse(value[1..]);

        if (!registry.Biomes.Tags.Contains(tag)) {
            throw new FormatException($"A structure names the biome tag \"{tag}\", which the registry "
                + "does not have.");
        }

        foreach (Identifier biome in registry.Biomes.Tags[tag].GetValueIds(registry)) {
            into.Add(biome);
        }
    }

    private static DecorationStep ParseStep(string value) {
        return value switch {
            "raw_generation" => DecorationStep.RawGeneration,
            "lakes" => DecorationStep.Lakes,
            "local_modifications" => DecorationStep.LocalModifications,
            "underground_structures" => DecorationStep.UndergroundStructures,
            "surface_structures" => DecorationStep.SurfaceStructures,
            "strongholds" => DecorationStep.Strongholds,
            "underground_ores" => DecorationStep.UndergroundOres,
            "underground_decoration" => DecorationStep.UndergroundDecoration,
            "fluid_springs" => DecorationStep.FluidSprings,
            "vegetal_decoration" => DecorationStep.VegetalDecoration,
            "top_layer_modification" => DecorationStep.TopLayerModification,
            _ => throw new FormatException($"Unknown decoration step \"{value}\".")
        };
    }

    private static TerrainAdjustment ParseAdaptation(string value) {
        return value switch {
            "none" => TerrainAdjustment.None,
            "bury" => TerrainAdjustment.Bury,
            "beard_thin" => TerrainAdjustment.BeardThin,
            "beard_box" => TerrainAdjustment.BeardBox,
            "encapsulate" => TerrainAdjustment.Encapsulate,
            _ => throw new FormatException($"Unknown terrain adaptation \"{value}\".")
        };
    }

    // ------------------------------------------------------------------- sets

    public StructureSet ParseSet(JsonElement root) {
        List<StructureSet.Entry> entries = [];

        foreach (JsonElement entry in root.GetProperty("structures").EnumerateArray()) {
            entries.Add(new StructureSet.Entry(
                Identifier.Parse(entry.GetProperty("structure").GetString()!),
                entry.GetProperty("weight").GetInt32()));
        }

        return new StructureSet(entries, ParsePlacement(root.GetProperty("placement")));
    }

    private StructurePlacement ParsePlacement(JsonElement placement) {
        Identifier type = Identifier.Parse(placement.GetProperty("type").GetString()!);

        if (type.Key == "dimension_origin") {
            return new DimensionOriginStructurePlacement();
        }

        Vec3<int> locateOffset = placement.TryGetProperty("locate_offset", out JsonElement offset)
            ? new Vec3<int>(offset[0].GetInt32(), offset[1].GetInt32(), offset[2].GetInt32())
            : new Vec3<int>(0, 0, 0);

        FrequencyReductionMethod reduction =
            placement.TryGetProperty("frequency_reduction_method", out JsonElement method)
                ? ParseReduction(method.GetString()!)
                : FrequencyReductionMethod.Default;

        float frequency = placement.TryGetProperty("frequency", out JsonElement value)
            ? value.GetSingle()
            : 1.0f;

        int salt = placement.GetProperty("salt").GetInt32();

        ExclusionZone? exclusionZone =
            placement.TryGetProperty("exclusion_zone", out JsonElement zone)
                ? new ExclusionZone(Identifier.Parse(zone.GetProperty("other_set").GetString()!),
                    zone.GetProperty("chunk_count").GetInt32())
                : null;

        return type.Key switch {
            "random_spread" => new RandomSpreadStructurePlacement(locateOffset, reduction, frequency,
                salt, exclusionZone,
                placement.GetProperty("spacing").GetInt32(),
                placement.GetProperty("separation").GetInt32(),
                placement.TryGetProperty("spread_type", out JsonElement spread)
                    ? ParseSpread(spread.GetString()!)
                    : RandomSpreadType.Linear),

            "concentric_rings" => new ConcentricRingsStructurePlacement(locateOffset, reduction,
                frequency, salt, exclusionZone,
                placement.GetProperty("distance").GetInt32(),
                placement.GetProperty("spread").GetInt32(),
                placement.GetProperty("count").GetInt32(),
                ParseBiomes(placement.GetProperty("preferred_biomes"))),

            _ => throw new FormatException($"Unknown structure placement type \"{type}\".")
        };
    }

    private static FrequencyReductionMethod ParseReduction(string value) {
        return value switch {
            "default" => FrequencyReductionMethod.Default,
            "legacy_type_1" => FrequencyReductionMethod.LegacyType1,
            "legacy_type_2" => FrequencyReductionMethod.LegacyType2,
            "legacy_type_3" => FrequencyReductionMethod.LegacyType3,
            _ => throw new FormatException($"Unknown frequency reduction method \"{value}\".")
        };
    }

    private static RandomSpreadType ParseSpread(string value) {
        return value switch {
            "linear" => RandomSpreadType.Linear,
            "triangular" => RandomSpreadType.Triangular,
            _ => throw new FormatException($"Unknown random spread type \"{value}\".")
        };
    }
}
