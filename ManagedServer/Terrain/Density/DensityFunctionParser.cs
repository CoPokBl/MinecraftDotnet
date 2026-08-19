using System.Text.Json;
using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// Where a density function reference is resolved, and where a named noise's parameters come from.
/// </summary>
public interface IDensityFunctionSource {
    /// <summary>The function registered under an id, built on first use.</summary>
    IDensityFunction Resolve(Identifier id);

    /// <summary>Whether a noise is registered, so an unknown name fails at parse rather than at sample.</summary>
    bool HasNoise(Identifier id);
}

/// <summary>
/// Reads vanilla's <c>worldgen/density_function</c> JSON into a tree.
/// </summary>
/// <remarks>
/// The JSON is the datapack format verbatim, so this is the port of vanilla's codecs rather than of a
/// format of our own. Three shapes stand for a function: a <b>number</b> is a constant, a
/// <b>string</b> is a reference into the density function registry, and an <b>object</b> carries a
/// <c>type</c>. Getting that wrong is silent, since every number in the tree is also a valid constant.
/// <p/>
/// Nodes are built through the <see cref="DensityFunctions"/> factories, never by constructor, because
/// those compute the value range from the arguments and pick the specialised implementation. A tree
/// built around them has wrong ranges, and a wrong range shows up as terrain with sections missing
/// rather than as an error.
/// <p/>
/// An unknown <c>type</c> throws. There is no permissive fallback on purpose: a density function that
/// silently reads as zero produces a world that generates, looks plausible in places and is wrong
/// everywhere, which is far harder to notice than a failure at load.
/// </remarks>
public sealed class DensityFunctionParser(IDensityFunctionSource source) {
    public IDensityFunction Parse(JsonElement element) {
        switch (element.ValueKind) {
            case JsonValueKind.Number:
                return DensityFunctions.Of(element.GetDouble());

            case JsonValueKind.String:
                return source.Resolve(Identifier.Parse(element.GetString()!));

            case JsonValueKind.Object:
                return ParseTyped(element);

            default:
                throw new FormatException(
                    $"A density function must be a number, a reference or an object, got {element.ValueKind}.");
        }
    }

    private IDensityFunction ParseTyped(JsonElement element) {
        if (!element.TryGetProperty("type", out JsonElement typeElement)) {
            throw new FormatException("A density function object needs a \"type\".");
        }

        string type = Identifier.Parse(typeElement.GetString()!).Key;

        return type switch {
            "constant" => DensityFunctions.Of(Argument(element).GetDouble()),
            "blend_alpha" => DensityFunctions.BlendAlpha.Instance,
            "blend_offset" => DensityFunctions.BlendOffset.Instance,
            "beardifier" => DensityFunctions.Beardifier.Instance,
            "old_blended_noise" => ParseOldBlendedNoise(element),
            "end_islands" => new DensityFunctions.EndIslands(0L),

            "interpolated" => DensityFunctions.Interpolated(ParseChild(element, "argument")),
            "flat_cache" => DensityFunctions.FlatCache(ParseChild(element, "argument")),
            "cache_2d" => DensityFunctions.Cache2D(ParseChild(element, "argument")),
            "cache_once" => DensityFunctions.CacheOnce(ParseChild(element, "argument")),
            "cache_all_in_cell" => DensityFunctions.CacheAllInCell(ParseChild(element, "argument")),
            "blend_density" => DensityFunctions.BlendDensity(ParseChild(element, "argument")),

            "add" => DensityFunctions.Add(ParseChild(element, "argument1"), ParseChild(element, "argument2")),
            "mul" => DensityFunctions.Mul(ParseChild(element, "argument1"), ParseChild(element, "argument2")),
            "min" => DensityFunctions.Min(ParseChild(element, "argument1"), ParseChild(element, "argument2")),
            "max" => DensityFunctions.Max(ParseChild(element, "argument1"), ParseChild(element, "argument2")),

            "abs" => Mapped(MappedType.Abs, element),
            "square" => Mapped(MappedType.Square, element),
            "cube" => Mapped(MappedType.Cube, element),
            "half_negative" => Mapped(MappedType.HalfNegative, element),
            "quarter_negative" => Mapped(MappedType.QuarterNegative, element),
            "invert" => Mapped(MappedType.Invert, element),
            "squeeze" => Mapped(MappedType.Squeeze, element),

            "noise" => new DensityFunctions.Noise(ParseNoise(element, "noise"),
                element.GetProperty("xz_scale").GetDouble(), element.GetProperty("y_scale").GetDouble()),

            "shifted_noise" => new DensityFunctions.ShiftedNoise(
                ParseChild(element, "shift_x"), ParseChild(element, "shift_y"), ParseChild(element, "shift_z"),
                element.GetProperty("xz_scale").GetDouble(), element.GetProperty("y_scale").GetDouble(),
                ParseNoise(element, "noise")),

            // The argument of the three shift nodes is a noise name, not a nested function. They read
            // the same in JSON as a reference to another density function does.
            "shift" => new DensityFunctions.Shift(NoiseArgument(element)),
            "shift_a" => new DensityFunctions.ShiftA(NoiseArgument(element)),
            "shift_b" => new DensityFunctions.ShiftB(NoiseArgument(element)),

            "clamp" => new DensityFunctions.Clamp(ParseChild(element, "input"),
                element.GetProperty("min").GetDouble(), element.GetProperty("max").GetDouble()),

            "range_choice" => new DensityFunctions.RangeChoice(ParseChild(element, "input"),
                element.GetProperty("min_inclusive").GetDouble(),
                element.GetProperty("max_exclusive").GetDouble(),
                ParseChild(element, "when_in_range"), ParseChild(element, "when_out_of_range")),

            "interval_select" => ParseIntervalSelect(element),

            "y_clamped_gradient" => new DensityFunctions.YClampedGradient(
                element.GetProperty("from_y").GetInt32(), element.GetProperty("to_y").GetInt32(),
                element.GetProperty("from_value").GetDouble(), element.GetProperty("to_value").GetDouble()),

            "spline" => new DensityFunctions.SplineFunction(ParseSpline(element.GetProperty("spline"))),

            "find_top_surface" => new DensityFunctions.FindTopSurface(
                ParseChild(element, "density"), ParseChild(element, "upper_bound"),
                element.GetProperty("lower_bound").GetInt32(),
                element.GetProperty("cell_height").GetInt32()),

            _ => throw new FormatException($"Unknown density function type \"{type}\".")
        };
    }

    private static JsonElement Argument(JsonElement element) => element.GetProperty("argument");

    private IDensityFunction ParseChild(JsonElement element, string name) {
        if (!element.TryGetProperty(name, out JsonElement child)) {
            throw new FormatException($"Density function is missing \"{name}\".");
        }

        return Parse(child);
    }

    private IDensityFunction Mapped(MappedType type, JsonElement element) {
        return DensityFunctions.Mapped.Create(type, Parse(Argument(element)));
    }

    private NoiseHolder ParseNoise(JsonElement element, string name) {
        return MakeNoiseHolder(Identifier.Parse(element.GetProperty(name).GetString()!));
    }

    private NoiseHolder NoiseArgument(JsonElement element) {
        return MakeNoiseHolder(Identifier.Parse(Argument(element).GetString()!));
    }

    private NoiseHolder MakeNoiseHolder(Identifier id) {
        if (!source.HasNoise(id)) {
            // An unbound holder reads as flat zero, so letting this through would trade a load error
            // for terrain that is quietly missing one of its noises.
            throw new FormatException($"No noise parameters registered for \"{id}\".");
        }

        return new NoiseHolder(id);
    }

    private static IDensityFunction ParseOldBlendedNoise(JsonElement element) {
        return BlendedNoise.CreateUnseeded(
            element.GetProperty("xz_scale").GetDouble(),
            element.GetProperty("y_scale").GetDouble(),
            element.GetProperty("xz_factor").GetDouble(),
            element.GetProperty("y_factor").GetDouble(),
            element.GetProperty("smear_scale_multiplier").GetDouble());
    }

    private IDensityFunction ParseIntervalSelect(JsonElement element) {
        List<double> thresholds = [];
        foreach (JsonElement threshold in element.GetProperty("thresholds").EnumerateArray()) {
            thresholds.Add(threshold.GetDouble());
        }

        List<IDensityFunction> functions = [];
        foreach (JsonElement function in element.GetProperty("functions").EnumerateArray()) {
            functions.Add(Parse(function));
        }

        return new DensityFunctions.IntervalSelect(ParseChild(element, "input"), thresholds, functions);
    }

    /// <summary>
    /// A spline: a coordinate function and a list of knots whose values are themselves either a plain
    /// float or another spline.
    /// </summary>
    private CubicSpline<DensityFunctions.SplineCoordinate, IFunctionContext> ParseSpline(JsonElement element) {
        if (element.ValueKind == JsonValueKind.Number) {
            return CubicSpline<DensityFunctions.SplineCoordinate, IFunctionContext>.Constant(element.GetSingle());
        }

        DensityFunctions.SplineCoordinate coordinate = new(Parse(element.GetProperty("coordinate")));

        List<CubicSpline<DensityFunctions.SplineCoordinate, IFunctionContext>.Point> points = [];
        foreach (JsonElement point in element.GetProperty("points").EnumerateArray()) {
            points.Add(new CubicSpline<DensityFunctions.SplineCoordinate, IFunctionContext>.Point(
                point.GetProperty("location").GetSingle(),
                ParseSpline(point.GetProperty("value")),
                point.GetProperty("derivative").GetSingle()));
        }

        return CubicSpline<DensityFunctions.SplineCoordinate, IFunctionContext>.Multipoint(coordinate, points);
    }
}
