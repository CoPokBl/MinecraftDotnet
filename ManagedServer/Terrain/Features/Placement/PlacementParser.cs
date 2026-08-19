using System.Text.Json;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Placement;

/// <summary>The <c>PlacementModifier</c> codec, as a parser.</summary>
public sealed class PlacementParser(BlockParser blocks) {
    public List<PlacementModifier> ParseAll(JsonElement element) {
        List<PlacementModifier> modifiers = [];
        foreach (JsonElement entry in element.EnumerateArray()) {
            modifiers.Add(Parse(entry));
        }

        return modifiers;
    }

    public PlacementModifier Parse(JsonElement element) {
        string type = ValueParser.TypeOf(element);

        switch (type) {
            case "count":
                return new PlacementModifier.CountTimes(ValueParser.ParseInt(element.GetProperty("count")));

            case "in_square":
                return PlacementModifier.InSquare.Instance;

            case "heightmap":
                return new PlacementModifier.Heightmap(
                    ParseHeightmap(element.GetProperty("heightmap").GetString()!));

            case "height_range":
                return new PlacementModifier.HeightRange(
                    ValueParser.ParseHeight(element.GetProperty("height")));

            case "random_offset":
                return new PlacementModifier.RandomOffset(
                    ValueParser.ParseInt(element.GetProperty("xz_spread")),
                    ValueParser.ParseInt(element.GetProperty("y_spread")));

            case "rarity_filter":
                return new PlacementModifier.RarityFilter(element.GetProperty("chance").GetInt32());

            case "biome":
                return PlacementModifier.BiomeFilter.Instance;

            case "block_predicate_filter":
                return new PlacementModifier.BlockPredicateFilter(
                    blocks.ParsePredicate(element.GetProperty("predicate")));

            case "surface_water_depth_filter":
                return new PlacementModifier.SurfaceWaterDepthFilter(
                    element.GetProperty("max_water_depth").GetInt32());

            case "surface_relative_threshold_filter":
                return new PlacementModifier.SurfaceRelativeThresholdFilter(
                    ParseHeightmap(element.GetProperty("heightmap").GetString()!),
                    ValueParser.OptionalInt(element, "min_inclusive", int.MinValue),
                    ValueParser.OptionalInt(element, "max_inclusive", int.MaxValue));

            case "noise_threshold_count":
                return new PlacementModifier.NoiseThresholdCount(
                    element.GetProperty("noise_level").GetDouble(),
                    element.GetProperty("below_noise").GetInt32(),
                    element.GetProperty("above_noise").GetInt32());

            case "noise_based_count":
                return new PlacementModifier.NoiseBasedCount(
                    element.GetProperty("noise_to_count_ratio").GetInt32(),
                    element.GetProperty("noise_factor").GetDouble(),
                    ValueParser.OptionalDouble(element, "noise_offset", 0.0));

            case "count_on_every_layer":
                return new PlacementModifier.CountOnEveryLayer(
                    ValueParser.ParseInt(element.GetProperty("count")));

            case "environment_scan":
                return new PlacementModifier.EnvironmentScan(
                    Step(BlockParser.ParseDirection(element.GetProperty("direction_of_search").GetString()!)),
                    blocks.ParsePredicate(element.GetProperty("target_condition")),
                    element.TryGetProperty("allowed_search_condition", out JsonElement allowed)
                        ? blocks.ParsePredicate(allowed)
                        : BlockPredicate.True.Instance,
                    element.GetProperty("max_steps").GetInt32());

            case "fixed_placement": {
                List<Vec3<int>> positions = [];
                foreach (JsonElement position in element.GetProperty("positions").EnumerateArray()) {
                    positions.Add(new Vec3<int>(position[0].GetInt32(), position[1].GetInt32(),
                        position[2].GetInt32()));
                }

                return new PlacementModifier.Fixed(positions);
            }

            default:
                throw new FormatException($"Unknown placement modifier type \"{type}\".");
        }
    }

    /// <summary>
    /// <c>Heightmap.Types</c> by its serialised name, which is the enum constant rather than a
    /// lowercase id.
    /// </summary>
    public static HeightmapType ParseHeightmap(string value) {
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

    /// <summary>A face as the unit step along it.</summary>
    public static Vec3<int> Step(BlockFace face) {
        return face switch {
            BlockFace.NegY => new Vec3<int>(0, -1, 0),
            BlockFace.PosY => new Vec3<int>(0, 1, 0),
            BlockFace.NegZ => new Vec3<int>(0, 0, -1),
            BlockFace.PosZ => new Vec3<int>(0, 0, 1),
            BlockFace.NegX => new Vec3<int>(-1, 0, 0),
            BlockFace.PosX => new Vec3<int>(1, 0, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(face), face, null)
        };
    }
}
