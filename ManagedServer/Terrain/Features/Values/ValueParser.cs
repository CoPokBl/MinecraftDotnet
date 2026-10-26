using System.Text.Json;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Features.Values;

/// <summary>
/// The <c>IntProvider</c>, <c>FloatProvider</c>, <c>HeightProvider</c> and <c>VerticalAnchor</c>
/// codecs, as a parser.
/// </summary>
/// <remarks>
/// Each of the four accepts a bare value as well as an object, which is vanilla's <c>Codec.either</c>
/// shorthand and is what lets <c>"count": 4</c> and <c>"count": {"type": ...}</c> both parse.
/// <p/>
/// Field names differ between the int and float forms of the same type, and it is not an oversight:
/// <c>uniform</c> is <c>min_inclusive</c>/<c>max_inclusive</c> over ints and
/// <c>min_inclusive</c>/<c>max_exclusive</c> over floats, and <c>clamped_normal</c> drops the
/// <c>_inclusive</c> suffix entirely over floats. Reading a float provider with the int names gives a
/// missing property rather than a wrong number, which is the reason to keep them apart.
/// </remarks>
public static class ValueParser {
    public static IIntProvider ParseInt(JsonElement element) {
        if (element.ValueKind == JsonValueKind.Number) {
            return new IntProviders.Constant(element.GetInt32());
        }

        string type = TypeOf(element);

        switch (type) {
            case "constant":
                return new IntProviders.Constant(element.GetProperty("value").GetInt32());

            case "uniform":
                return new IntProviders.Uniform(element.GetProperty("min_inclusive").GetInt32(),
                    element.GetProperty("max_inclusive").GetInt32());

            case "biased_to_bottom":
                return new IntProviders.BiasedToBottom(element.GetProperty("min_inclusive").GetInt32(),
                    element.GetProperty("max_inclusive").GetInt32());

            case "very_biased_to_bottom": {
                int min = element.GetProperty("min_inclusive").GetInt32();
                int max = element.GetProperty("max_inclusive").GetInt32();
                if (max < min) {
                    throw new FormatException($"very_biased_to_bottom has max {max} below min {min}.");
                }

                return new IntProviders.VeryBiasedToBottom(min, max);
            }

            case "clamped":
                return new IntProviders.Clamped(ParseInt(element.GetProperty("source")),
                    element.GetProperty("min_inclusive").GetInt32(),
                    element.GetProperty("max_inclusive").GetInt32());

            case "clamped_normal":
                return new IntProviders.ClampedNormal(element.GetProperty("mean").GetSingle(),
                    element.GetProperty("deviation").GetSingle(),
                    element.GetProperty("min_inclusive").GetInt32(),
                    element.GetProperty("max_inclusive").GetInt32());

            case "trapezoid":
                // The only int provider whose bounds are not "_inclusive", and its plateau is
                // required rather than defaulted. Both differ from the height provider of the same
                // name, which is why the two parsers do not share a case.
                return new IntProviders.Trapezoid(element.GetProperty("min").GetInt32(),
                    element.GetProperty("max").GetInt32(), element.GetProperty("plateau").GetInt32());

            case "weighted_list":
                return new IntProviders.WeightedList(
                    ParseWeightedList(element.GetProperty("distribution"), ParseInt));

            default:
                throw new FormatException($"Unknown int provider type \"{type}\".");
        }
    }

    public static IFloatProvider ParseFloat(JsonElement element) {
        if (element.ValueKind == JsonValueKind.Number) {
            return new FloatProviders.Constant(element.GetSingle());
        }

        string type = TypeOf(element);

        switch (type) {
            case "constant":
                return new FloatProviders.Constant(element.GetProperty("value").GetSingle());

            case "uniform":
                return new FloatProviders.Uniform(element.GetProperty("min_inclusive").GetSingle(),
                    element.GetProperty("max_exclusive").GetSingle());

            case "clamped_normal":
                return new FloatProviders.ClampedNormal(element.GetProperty("mean").GetSingle(),
                    element.GetProperty("deviation").GetSingle(),
                    element.GetProperty("min").GetSingle(), element.GetProperty("max").GetSingle());

            case "trapezoid":
                return new FloatProviders.Trapezoid(element.GetProperty("min").GetSingle(),
                    element.GetProperty("max").GetSingle(), element.GetProperty("plateau").GetSingle());

            default:
                throw new FormatException($"Unknown float provider type \"{type}\".");
        }
    }

    public static HeightProvider ParseHeight(JsonElement element) {
        // A vertical anchor rather than a provider is the shorthand for a constant height, and the two
        // are told apart by the anchor having no "type": every anchor is one of three named keys.
        if (!element.TryGetProperty("type", out _)) {
            return new HeightProvider.Constant(ParseAnchor(element));
        }

        string type = TypeOf(element);

        switch (type) {
            case "constant":
                return new HeightProvider.Constant(ParseAnchor(element.GetProperty("value")));

            case "uniform":
                return new HeightProvider.Uniform(ParseAnchor(element.GetProperty("min_inclusive")),
                    ParseAnchor(element.GetProperty("max_inclusive")));

            case "biased_to_bottom":
                return new HeightProvider.BiasedToBottom(ParseAnchor(element.GetProperty("min_inclusive")),
                    ParseAnchor(element.GetProperty("max_inclusive")), OptionalInt(element, "inner", 1));

            case "very_biased_to_bottom":
                return new HeightProvider.VeryBiasedToBottom(
                    ParseAnchor(element.GetProperty("min_inclusive")),
                    ParseAnchor(element.GetProperty("max_inclusive")), OptionalInt(element, "inner", 1));

            case "trapezoid":
                return new HeightProvider.Trapezoid(ParseAnchor(element.GetProperty("min_inclusive")),
                    ParseAnchor(element.GetProperty("max_inclusive")), OptionalInt(element, "plateau", 0));

            case "weighted_list":
                return new HeightProvider.WeightedList(
                    ParseWeightedList(element.GetProperty("distribution"), ParseHeight));

            default:
                throw new FormatException($"Unknown height provider type \"{type}\".");
        }
    }

    public static VerticalAnchor ParseAnchor(JsonElement element) {
        if (element.TryGetProperty("absolute", out JsonElement absolute)) {
            return new VerticalAnchor.Absolute(absolute.GetInt32());
        }

        if (element.TryGetProperty("above_bottom", out JsonElement aboveBottom)) {
            return new VerticalAnchor.AboveBottom(aboveBottom.GetInt32());
        }

        if (element.TryGetProperty("below_top", out JsonElement belowTop)) {
            return new VerticalAnchor.BelowTop(belowTop.GetInt32());
        }

        if (element.TryGetProperty("relative_to_sea_level", out JsonElement seaLevel)) {
            return new VerticalAnchor.RelativeToSeaLevel(seaLevel.GetInt32());
        }

        throw new FormatException("A vertical anchor needs one of absolute, above_bottom, below_top or "
            + $"relative_to_sea_level: {element}");
    }

    /// <summary>
    /// A <c>WeightedList</c>, whose entries are <c>{"data": ..., "weight": n}</c> with the weight
    /// defaulting to one.
    /// </summary>
    public static WeightedList<T> ParseWeightedList<T>(JsonElement element, Func<JsonElement, T> parseValue) {
        List<(T, int)> entries = [];
        foreach (JsonElement entry in element.EnumerateArray()) {
            entries.Add((parseValue(entry.GetProperty("data")), OptionalInt(entry, "weight", 1)));
        }

        if (entries.Count == 0) {
            throw new FormatException("A weighted list needs at least one entry.");
        }

        return new WeightedList<T>(entries);
    }

    public static string TypeOf(JsonElement element) {
        if (!element.TryGetProperty("type", out JsonElement type)) {
            throw new FormatException($"No \"type\" on {element}.");
        }

        return Identifier.Parse(type.GetString()!).Key;
    }

    public static int OptionalInt(JsonElement element, string name, int fallback) {
        return element.TryGetProperty(name, out JsonElement value) ? value.GetInt32() : fallback;
    }

    public static float OptionalFloat(JsonElement element, string name, float fallback) {
        return element.TryGetProperty(name, out JsonElement value) ? value.GetSingle() : fallback;
    }

    public static double OptionalDouble(JsonElement element, string name, double fallback) {
        return element.TryGetProperty(name, out JsonElement value) ? value.GetDouble() : fallback;
    }

    public static bool OptionalBool(JsonElement element, string name, bool fallback) {
        return element.TryGetProperty(name, out JsonElement value) ? value.GetBoolean() : fallback;
    }
}
