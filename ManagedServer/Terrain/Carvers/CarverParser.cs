using System.Text.Json;
using ManagedServer.Terrain.Features.Values;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// The <c>WorldCarver</c> codecs, as a parser. Vanilla registers two types and both are here, so an
/// unknown type throws rather than becoming a world quietly missing its caves.
/// </summary>
public static class CarverParser {
    public static IWorldCarver Parse(JsonElement element) {
        string type = ValueParser.TypeOf(element);
        switch (type) {
            case "cave":
                return new CaveWorldCarver(
                    Probability(element),
                    ValueParser.ParseHeight(element.GetProperty("y")),
                    ValueParser.ParseInt(element.GetProperty("count")),
                    ValueParser.ParseFloat(element.GetProperty("thickness")),
                    ValueParser.OptionalBool(element, "weird_thickness_bias", false),
                    ValueParser.ParseFloat(element.GetProperty("room_vertical_radius_multiplier")),
                    ValueParser.ParseFloat(element.GetProperty("horizontal_radius_multiplier")),
                    ValueParser.ParseFloat(element.GetProperty("vertical_radius_multiplier")),
                    element.TryGetProperty("start_vertical_radius_multiplier", out JsonElement start)
                        ? ValueParser.ParseFloat(start)
                        : new FloatProviders.Constant(1.0F),
                    ValueParser.ParseFloat(element.GetProperty("floor_level")));

            case "canyon": {
                JsonElement shape = element.GetProperty("shape");
                int widthSmoothness = shape.GetProperty("width_smoothness").GetInt32();
                if (widthSmoothness <= 0) {
                    throw new FormatException($"width_smoothness must be positive, was {widthSmoothness}.");
                }

                return new CanyonWorldCarver(
                    Probability(element),
                    ValueParser.ParseHeight(element.GetProperty("y")),
                    ValueParser.ParseFloat(element.GetProperty("vertical_rotation")),
                    new CanyonShape(
                        ValueParser.ParseFloat(shape.GetProperty("distance_factor")),
                        ValueParser.ParseFloat(shape.GetProperty("thickness")),
                        widthSmoothness,
                        ValueParser.ParseFloat(shape.GetProperty("horizontal_radius_factor")),
                        shape.GetProperty("vertical_radius_default_factor").GetSingle(),
                        shape.GetProperty("vertical_radius_center_factor").GetSingle(),
                        ValueParser.ParseFloat(shape.GetProperty("y_scale"))));
            }

            default:
                throw new FormatException($"Unknown carver type \"{type}\".");
        }
    }

    private static float Probability(JsonElement element) {
        float probability = element.GetProperty("probability").GetSingle();
        if (!(probability >= 0.0F && probability <= 1.0F)) {
            throw new FormatException($"Carver probability {probability} outside of range [0.0:1.0]");
        }

        return probability;
    }
}
