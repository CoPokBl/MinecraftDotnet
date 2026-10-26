using System.Text.Json;
using ManagedServer.Terrain.Noise;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Terrain.Density;

/// <summary>
/// Where a reference to a registered density function or noise is looked up.
/// </summary>
public interface IDensityFunctionSource {
    /// <summary>The function registered under an id. Called lazily, the first time a reference is used.</summary>
    IDensityFunction Resolve(Identifier id);

    /// <summary>The noise registered under an id, or null when there is none.</summary>
    NormalNoise? ResolveNoise(Identifier id);
}

/// <summary>
/// Reads vanilla's <c>worldgen/density_function</c> JSON, the port of <c>DensityFunctions.DIRECT_CODEC</c>
/// and the node codecs.
/// </summary>
/// <remarks>
/// A number is a float constant, a string is a reference into the registry, kept as a reference rather
/// than inlined because a reference has its own identity to the compiler's cache deduplication, and an
/// object carries a <c>type</c>. An unknown type or missing field throws: a function that silently read
/// as zero would give a world that generates and is wrong everywhere.
/// </remarks>
public sealed class DensityFunctionParser(IDensityFunctionSource source) {
    public IDensityFunction Parse(JsonElement element) {
        return element.ValueKind switch {
            JsonValueKind.Number => new ConstantFunction(NoiseValue(element)),
            JsonValueKind.String => new DensityFunctionReference(Identifier.Parse(element.GetString()!), source.Resolve),
            JsonValueKind.Object => ParseTyped(element),
            _ => throw new FormatException($"A density function must be a number, a reference or an object, got {element.ValueKind}.")
        };
    }

    private IDensityFunction ParseTyped(JsonElement element) {
        if (!element.TryGetProperty("type", out JsonElement typeElement)) {
            throw new FormatException("A density function object needs a \"type\".");
        }

        string type = Identifier.Parse(typeElement.GetString()!).Key;
        switch (type) {
            case "constant":
                return new ConstantFunction(NoiseValue(Field(element, "value")));
            case "blend_alpha":
                return SimpleDensityFunction.BlendAlpha;
            case "blend_offset":
                return SimpleDensityFunction.BlendOffset;
            case "beardifier":
                return SimpleDensityFunction.Beardifier;
            case "noise":
                return new NoiseFunction(ParseNoise(Field(element, "noise")), Field(element, "xz_scale").GetDouble(),
                    Field(element, "y_scale").GetDouble(), OptionalChild(element, "shift_x"), OptionalChild(element, "shift_y"),
                    OptionalChild(element, "shift_z"));
            case "end_outer_islands":
                return new EndIslandFunction();
            case "distance_to_point": {
                JsonElement[] point = Field(element, "point").EnumerateArray().ToArray();
                if (point.Length != 3) {
                    throw new FormatException("distance_to_point needs a point of three ints.");
                }

                return new DistanceToPointFunction(point[0].GetInt32(), point[1].GetInt32(), point[2].GetInt32(),
                    ParseMetric(Field(element, "metric").GetString()!));
            }
            case "gradient":
                return ParseGradient(element);
            case "shift_a":
                return new ShiftNoiseFunction(ShiftNoiseFunction.ShiftKind.ShiftA, ParseNoise(Field(element, "noise")));
            case "shift_b":
                return new ShiftNoiseFunction(ShiftNoiseFunction.ShiftKind.ShiftB, ParseNoise(Field(element, "noise")));
            case "shift":
                return new ShiftNoiseFunction(ShiftNoiseFunction.ShiftKind.Shift, ParseNoise(Field(element, "noise")));
            case "pow":
                return new PowFunction(Child(element, "base"), Child(element, "exponent"));
            case "spline":
                return new SplineFunction(ParseSpline(Field(element, "spline")));
            case "lerp":
                return new LerpFunction(Child(element, "alpha"), Child(element, "first"), Child(element, "second"));
            case "clamp": {
                float min = NoiseValue(Field(element, "min"));
                float max = NoiseValue(Field(element, "max"));
                if (max < min) {
                    throw new FormatException($"min ({min}) must be less than or equal to max ({max})");
                }

                return new ClampFunction(Child(element, "input"), min, max);
            }
            case "range_choice":
                return new RangeChoiceFunction(Child(element, "input"), NoiseValue(Field(element, "min_inclusive")),
                    NoiseValue(Field(element, "max_exclusive")), Child(element, "when_in_range"), Child(element, "when_out_of_range"));
            case "interval_select":
                return ParseIntervalSelect(element);
            case "cache":
                return new CacheFunction(Child(element, "input"));
            case "blend_density":
                return new BlendDensityFunction(Child(element, "input"));
            case "interpolated":
                return new InterpolatedFunction(Child(element, "input"), PositiveInt(element, "cell_size_xz"),
                    PositiveInt(element, "cell_size_y"));
            case "slice":
                return new SliceFunction(AxisExtensions.FromString(Field(element, "axis").GetString()!),
                    Field(element, "coordinate").GetInt32(), Child(element, "input"));
            case "find_top_surface":
                return new FindTopSurfaceFunction(Child(element, "density"), Child(element, "upper_bound"),
                    Field(element, "lower_bound").GetInt32(), PositiveInt(element, "cell_height"));
            case "old_blended_noise":
                return new BlendedNoise(Field(element, "xz_scale").GetDouble(), Field(element, "y_scale").GetDouble(),
                    Field(element, "xz_factor").GetDouble(), Field(element, "y_factor").GetDouble(),
                    Field(element, "smear_scale_multiplier").GetDouble());
        }

        if (UnaryTypes.TryGetValue(type, out UnaryType unary)) {
            return new UnaryFunction(unary, Child(element, "input"));
        }

        if (RoundTypes.TryGetValue(type, out RoundType round)) {
            IDensityFunction multiple = element.TryGetProperty("multiple", out JsonElement multipleElement)
                ? Parse(multipleElement)
                : new ConstantFunction(1.0F);
            return new RoundFunction(round, Child(element, "input"), multiple);
        }

        if (BinaryTypes.TryGetValue(type, out BinaryType binary)) {
            return new BinaryFunction(binary, Child(element, "left"), Child(element, "right"));
        }

        throw new FormatException($"Unknown density function type \"{type}\".");
    }

    private static readonly Dictionary<string, UnaryType> UnaryTypes = new() {
        ["abs"] = UnaryType.Abs,
        ["square"] = UnaryType.Square,
        ["cube"] = UnaryType.Cube,
        ["sqrt"] = UnaryType.Sqrt,
        ["half_negative"] = UnaryType.HalfNegative,
        ["quarter_negative"] = UnaryType.QuarterNegative,
        ["reciprocal"] = UnaryType.Reciprocal,
        ["negate"] = UnaryType.Negate,
        ["squeeze"] = UnaryType.Squeeze,
        ["log"] = UnaryType.Log,
        ["sign"] = UnaryType.Sign
    };

    private static readonly Dictionary<string, RoundType> RoundTypes = new() {
        ["floor"] = RoundType.Floor,
        ["round"] = RoundType.Round,
        ["ceil"] = RoundType.Ceil,
        ["truncate"] = RoundType.Truncate
    };

    private static readonly Dictionary<string, BinaryType> BinaryTypes = new() {
        ["add"] = BinaryType.Add,
        ["sub"] = BinaryType.Sub,
        ["mul"] = BinaryType.Mul,
        ["div"] = BinaryType.Div,
        ["min"] = BinaryType.Min,
        ["max"] = BinaryType.Max
    };

    private static JsonElement Field(JsonElement element, string name) {
        if (!element.TryGetProperty(name, out JsonElement field)) {
            throw new FormatException($"Density function is missing \"{name}\".");
        }

        return field;
    }

    private IDensityFunction Child(JsonElement element, string name) => Parse(Field(element, name));

    private IDensityFunction OptionalChild(JsonElement element, string name) {
        return element.TryGetProperty(name, out JsonElement child) ? Parse(child) : ConstantFunction.Zero;
    }

    private static int PositiveInt(JsonElement element, string name) {
        int value = Field(element, name).GetInt32();
        if (value <= 0) {
            throw new FormatException($"\"{name}\" must be positive, was {value}.");
        }

        return value;
    }

    /// <summary><c>NOISE_VALUE_CODEC</c>: a float in [-1e6, 1e6].</summary>
    private static float NoiseValue(JsonElement element) {
        float value = element.GetSingle();
        if (!(value >= -1000000.0F && value <= 1000000.0F)) {
            throw new FormatException($"Value {value} outside of range [-1000000.0:1000000.0]");
        }

        return value;
    }

    private static DistanceMetric ParseMetric(string name) {
        return name switch {
            "euclidean" => DistanceMetric.Euclidean,
            "euclidean_squared" => DistanceMetric.EuclideanSquared,
            "manhattan" => DistanceMetric.Manhattan,
            "chebyshev" => DistanceMetric.Chebyshev,
            _ => throw new FormatException($"Unknown distance metric \"{name}\".")
        };
    }

    private static IDensityFunction ParseGradient(JsonElement element) {
        TilingMode tiling = TilingMode.ClampToEdge;
        if (element.TryGetProperty("tiling", out JsonElement tilingElement)) {
            tiling = tilingElement.GetString() switch {
                "clamp_to_edge" => TilingMode.ClampToEdge,
                "repeat" => TilingMode.Repeat,
                "mirrored_repeat" => TilingMode.MirroredRepeat,
                string other => throw new FormatException($"Unknown tiling mode \"{other}\"."),
                null => throw new FormatException("Tiling mode must be a string.")
            };
        }

        int from = Field(element, "from_coordinate").GetInt32();
        int to = Field(element, "to_coordinate").GetInt32();
        if (from == to) {
            throw new FormatException("from_coordinate cannot be equal to to_coordinate");
        }

        return new GradientFunction(AxisExtensions.FromString(Field(element, "axis").GetString()!), tiling, from, to,
            NoiseValue(Field(element, "from_value")), NoiseValue(Field(element, "to_value")));
    }

    private IDensityFunction ParseIntervalSelect(JsonElement element) {
        float[] thresholds = Field(element, "thresholds").EnumerateArray().Select(NoiseValue).ToArray();
        IDensityFunction[] functions = Field(element, "functions").EnumerateArray().Select(Parse).ToArray();
        if (functions.Length < 2) {
            throw new FormatException("interval_select needs at least two functions.");
        }

        if (thresholds.Length != functions.Length - 1) {
            throw new FormatException($"Expected {functions.Length - 1} thresholds for {functions.Length} functions, but got {thresholds.Length}");
        }

        for (int i = 1; i < thresholds.Length; i++) {
            if (thresholds[i - 1].CompareTo(thresholds[i]) > 0) {
                throw new FormatException("Threshold values must be ordered from smallest to largest");
            }
        }

        return new IntervalSelectFunction(Child(element, "input"), thresholds, functions);
    }

    /// <summary><c>NormalNoise.CODEC</c>: a registry id, or parameters written inline.</summary>
    public NoiseHolder ParseNoise(JsonElement element) {
        if (element.ValueKind == JsonValueKind.String) {
            Identifier id = Identifier.Parse(element.GetString()!);
            NormalNoise noise = source.ResolveNoise(id) ?? throw new FormatException($"No noise registered for \"{id}\".");
            return new NoiseHolder(id, noise);
        }

        return new NoiseHolder(null, new NormalNoise(ParseNoiseParameters(element)));
    }

    /// <summary><c>NormalNoise.Parameters.CODEC</c>.</summary>
    public static NoiseParameters ParseNoiseParameters(JsonElement element) {
        double baseAmplitude = element.TryGetProperty("base_amplitude", out JsonElement amplitude) ? amplitude.GetDouble() : 1.0;
        int baseOctave = Field(element, "base_octave").GetInt32();
        int octaveCount = element.TryGetProperty("octave_count", out JsonElement count) ? count.GetInt32() : 1;
        NoiseNormalization normalize = NoiseNormalization.Enabled;
        if (element.TryGetProperty("normalize", out JsonElement normalizeElement)) {
            normalize = normalizeElement.ValueKind switch {
                JsonValueKind.True => NoiseNormalization.Enabled,
                JsonValueKind.False => NoiseNormalization.Disabled,
                JsonValueKind.String when normalizeElement.GetString() == "legacy" => NoiseNormalization.Legacy,
                _ => throw new FormatException($"Invalid normalization type: {normalizeElement}")
            };
        }

        double[] modifiers = element.TryGetProperty("amplitude_modifiers", out JsonElement modifiersElement)
            ? modifiersElement.EnumerateArray().Select(modifier => modifier.GetDouble()).ToArray()
            : [];

        if (!(baseAmplitude >= 1.0E-5F && baseAmplitude <= 1000000.0) || baseOctave is < -32 or > 32 || octaveCount is < 1 or > 32
            || modifiers.Length > 32 || modifiers.Any(modifier => !(modifier >= 0.0 && modifier <= 1000000.0))) {
            throw new FormatException("Noise parameters out of range.");
        }

        if (modifiers.Length != 0 && modifiers.Length != octaveCount) {
            throw new FormatException($"amplitude_modifiers had size {modifiers.Length}, but octave_count was {octaveCount}");
        }

        return new NoiseParameters(baseAmplitude, baseOctave, octaveCount, normalize, modifiers);
    }

    /// <summary>A spline: a float, or a coordinate function and knots whose values are splines again.</summary>
    private CubicSpline<IDensityFunction> ParseSpline(JsonElement element) {
        if (element.ValueKind == JsonValueKind.Number) {
            return CubicSpline<IDensityFunction>.Constant(element.GetSingle());
        }

        IDensityFunction coordinate = Child(element, "coordinate");
        List<float> locations = [];
        List<CubicSpline<IDensityFunction>> values = [];
        List<float> derivatives = [];
        foreach (JsonElement point in Field(element, "points").EnumerateArray()) {
            locations.Add(Field(point, "location").GetSingle());
            values.Add(ParseSpline(Field(point, "value")));
            derivatives.Add(Field(point, "derivative").GetSingle());
        }

        if (locations.Count == 0) {
            throw new FormatException("Cannot create a multipoint spline with no points");
        }

        for (int i = 0; i < locations.Count - 1; i++) {
            if (locations[i] >= locations[i + 1]) {
                throw new FormatException("Input locations are not monotonically increasing");
            }
        }

        return CubicSpline<IDensityFunction>.Multipoint(coordinate, locations.ToArray(), values, derivatives.ToArray());
    }
}
