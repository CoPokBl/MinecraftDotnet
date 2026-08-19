using System.Text.Json;
using ManagedServer.Terrain.Features.Blocks;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Generated;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// The <c>ConfiguredWorldCarver</c> codec, as a parser.
/// </summary>
/// <remarks>
/// <b>Every carver type is transcribed</b>, so unlike the feature parser this has no list of things it
/// declines: vanilla registers three and all three are here. An unknown type therefore throws, and on a
/// version bump a new carver upstream fails the load rather than becoming a world quietly missing its
/// caves.
/// <p/>
/// <c>yScale</c> is spelled in camel case in the data and <c>lava_level</c> is not, which is vanilla's
/// own inconsistency rather than a transcription slip.
/// </remarks>
public sealed class CarverParser(BlockParser blocks) {
    private static readonly CaveWorldCarver Cave = new();
    private static readonly NetherWorldCarver NetherCave = new();
    private static readonly CanyonWorldCarver Canyon = new();

    public ConfiguredWorldCarver Parse(JsonElement element) {
        string type = ValueParser.TypeOf(element);
        JsonElement config = element.GetProperty("config");

        switch (type) {
            case "cave":
                return new ConfiguredWorldCarver<CaveCarverConfiguration>(Cave, ParseCave(config));

            case "nether_cave":
                return new ConfiguredWorldCarver<CaveCarverConfiguration>(NetherCave, ParseCave(config));

            case "canyon":
                return new ConfiguredWorldCarver<CanyonCarverConfiguration>(Canyon, ParseCanyon(config));

            default:
                throw new FormatException($"Unknown carver type \"{type}\".");
        }
    }

    private CaveCarverConfiguration ParseCave(JsonElement config) {
        CarverConfiguration shared = ParseShared(config);

        return new CaveCarverConfiguration(shared.Probability, shared.Y, shared.YScale, shared.LavaLevel,
            shared.DebugSettings, shared.Replaceable,
            ValueParser.ParseFloat(config.GetProperty("horizontal_radius_multiplier")),
            ValueParser.ParseFloat(config.GetProperty("vertical_radius_multiplier")),
            ValueParser.ParseFloat(config.GetProperty("floor_level")));
    }

    private CanyonCarverConfiguration ParseCanyon(JsonElement config) {
        CarverConfiguration shared = ParseShared(config);
        JsonElement shape = config.GetProperty("shape");

        return new CanyonCarverConfiguration(shared.Probability, shared.Y, shared.YScale, shared.LavaLevel,
            shared.DebugSettings, shared.Replaceable,
            ValueParser.ParseFloat(config.GetProperty("vertical_rotation")),
            new CanyonShapeConfiguration(
                ValueParser.ParseFloat(shape.GetProperty("distance_factor")),
                ValueParser.ParseFloat(shape.GetProperty("thickness")),
                shape.GetProperty("width_smoothness").GetInt32(),
                ValueParser.ParseFloat(shape.GetProperty("horizontal_radius_factor")),
                shape.GetProperty("vertical_radius_default_factor").GetSingle(),
                shape.GetProperty("vertical_radius_center_factor").GetSingle()));
    }

    private CarverConfiguration ParseShared(JsonElement config) {
        return new CarverConfiguration(
            config.GetProperty("probability").GetSingle(),
            ValueParser.ParseHeight(config.GetProperty("y")),
            ValueParser.ParseFloat(config.GetProperty("yScale")),
            ValueParser.ParseAnchor(config.GetProperty("lava_level")),
            ParseDebugSettings(config),
            blocks.ParseIdentifierSet(config.GetProperty("replaceable")));
    }

    /// <summary>
    /// The debug settings, whose four states each default on their own. Absent altogether is the
    /// default settings, which is every vanilla file bar the three overworld carvers.
    /// </summary>
    private CarverDebugSettings ParseDebugSettings(JsonElement config) {
        if (!config.TryGetProperty("debug_settings", out JsonElement settings)) {
            return DefaultDebugSettings;
        }

        // Every one of the four falls back to DEFAULT's *air* state rather than to its own, so a
        // settings block naming only some of them reads as the button for the rest.
        return new CarverDebugSettings(
            ValueParser.OptionalBool(settings, "debug_mode", false),
            ParseState(settings, "air_state"),
            ParseState(settings, "water_state"),
            ParseState(settings, "lava_state"),
            ParseState(settings, "barrier_state"));
    }

    private uint ParseState(JsonElement settings, string name) {
        return settings.TryGetProperty(name, out JsonElement state)
            ? blocks.ParseStateId(state)
            : DefaultDebugSettings.AirState;
    }

    /// <summary><c>CarverDebugSettings.DEFAULT</c>, which is what a file with no settings block gets.</summary>
    private static CarverDebugSettings DefaultDebugSettings { get; } = new(false,
        Block.AcaciaButton.StateId, Block.Candle.StateId, Block.OrangeStainedGlass.StateId,
        Block.Glass.StateId);
}
