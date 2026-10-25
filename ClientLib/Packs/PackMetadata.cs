using Minecraft.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientLib.Packs;

/// <summary><c>PackFormat</c>: a major format and a minor one within it.</summary>
public readonly record struct PackFormat(int Major, int Minor) : IComparable<PackFormat> {
    /// <summary>
    /// <c>SharedConstants.getCurrentVersion().packVersion(PackType.CLIENT_RESOURCES)</c>: <c>version.json</c>'s
    /// <c>pack_version.resource_major</c> and <c>resource_minor</c>, which a version bump changes.
    /// </summary>
    public static readonly PackFormat Current = new(88, 0);

    /// <summary><c>PackFormat.lastPreMinorVersion(PackType.CLIENT_RESOURCES)</c>.</summary>
    public const int LastPreMinorVersion = 64;

    public int CompareTo(PackFormat other) => Major != other.Major ? Major.CompareTo(other.Major) : Minor.CompareTo(other.Minor);

    public static bool operator <(PackFormat a, PackFormat b) => a.CompareTo(b) < 0;

    public static bool operator >(PackFormat a, PackFormat b) => a.CompareTo(b) > 0;

    public override string ToString() => Minor == int.MaxValue ? $"{Major}.*" : $"{Major}.{Minor}";
}

/// <summary><c>PackCompatibility</c>.</summary>
public enum PackCompatibility {
    TooOld,
    TooNew,
    Unknown,
    Compatible
}

/// <summary><c>LanguageInfo</c>.</summary>
public sealed record LanguageInfo(string Region, string Name, bool Bidirectional) {
    /// <summary><c>LanguageInfo.toComponent</c>.</summary>
    public string Display => $"{Name} ({Region})";
}

/// <summary>
/// What <c>Pack.readPackMetadata</c> takes from a pack's <c>pack.mcmeta</c>: the description, how the pack's
/// declared formats compare with this version's, and the overlay folders that apply to this version.
/// </summary>
/// <param name="Overlays"><c>OverlayMetadataSection.overlaysForVersion</c>: in the order listed, each above the ones before it and the pack's own root.</param>
public sealed record PackMetadata(TextComponent Description, PackCompatibility Compatibility, IReadOnlyList<string> Overlays) {
    public PackMetadata(TextComponent description, PackCompatibility compatibility) : this(description, compatibility, []) {
    }

    /// <summary>
    /// <c>Pack.readPackMetadata</c> for client resources: null for a pack with no <c>pack</c> section or a file
    /// that does not parse, which vanilla leaves out of the pack list. A <c>pack</c> section whose formats do
    /// not validate falls back to its description alone, which reads as an unknown format. An <c>overlays</c>
    /// section that does not validate leaves the whole pack out, as its exception escapes to the same catch.
    /// </summary>
    public static PackMetadata? Read(byte[]? mcmeta) => Read(mcmeta, PackFormat.Current);

    /// <inheritdoc cref="Read(byte[])"/>
    public static PackMetadata? Read(byte[]? mcmeta, PackFormat game) {
        if (Parse(mcmeta) is not { } root || root["pack"] is not JObject section) {
            return null;
        }
        if (ReadDescription(section) is not { } description) {
            return null;
        }
        PackCompatibility compatibility = SupportedFormats(section) is { } range ? ForVersion(range, game) : PackCompatibility.Unknown;
        List<string> overlays = [];
        if (root["overlays"] is { } overlaySection) {
            if (OverlayEntries(overlaySection) is not { } entries) {
                return null;
            }
            overlays.AddRange(entries.Where(e => e.Min.CompareTo(game) <= 0 && game.CompareTo(e.Max) <= 0).Select(e => e.Directory));
        }
        return new PackMetadata(description, compatibility, overlays);
    }

    /// <summary>
    /// <c>OverlayMetadataSection</c>'s codec over <c>entries</c>, through <c>PackFormat.validateHolderList</c>: the
    /// entries with their format ranges, null where the codec reports an error. An entry naming no format at all is
    /// skipped; once any entry reaches back to format 64 or below, every entry needs the old <c>formats</c> field.
    /// </summary>
    private static List<(PackFormat Min, PackFormat Max, string Directory)>? OverlayEntries(JToken section) {
        if (section is not JObject sectionObject || sectionObject["entries"] is not JArray list) {
            return null;
        }
        List<(PackFormat? Min, PackFormat? Max, (int Min, int Max)? Supported, string Directory)> parsed = [];
        foreach (JToken token in list) {
            if (token is not JObject entry || entry["directory"] is not { Type: JTokenType.String } directoryToken ||
                !ValidOverlayDirectory(directoryToken.Value<string>()!) ||
                !OptionalFormat(entry["min_format"], 0, out PackFormat? min) || !OptionalFormat(entry["max_format"], int.MaxValue, out PackFormat? max) ||
                !OptionalRange(entry["formats"], out (int Min, int Max)? supported)) {
                return null;
            }
            parsed.Add((min, max, supported, directoryToken.Value<string>()!));
        }
        const int last = PackFormat.LastPreMinorVersion;
        // IntermediaryFormat.effectiveMinMajorVersion.
        int minVersion = parsed.Select(e => e.Min is { } m ? e.Supported is { } s ? Math.Min(m.Major, s.Min) : m.Major : e.Supported?.Min ?? int.MaxValue)
            .DefaultIfEmpty(int.MaxValue).Min();
        bool requireOldField = minVersion <= last;
        List<(PackFormat, PackFormat, string)> result = [];
        foreach ((PackFormat? min, PackFormat? max, (int Min, int Max)? supported, string directory) in parsed) {
            if (min == null && max == null && supported == null) {
                Console.Error.WriteLine($"Unknown or broken overlay entry {directory}");
                continue;
            }
            if (min.HasValue != max.HasValue || requireOldField && supported == null) {
                return null;
            }
            if (min is { } minFormat && max is { } maxFormat) {
                if (minFormat > maxFormat) {
                    return null;
                }
                if (minFormat.Major > last && !requireOldField) {
                    if (supported != null) {
                        return null;
                    }
                }
                else if (supported is not { } old || old.Min != minFormat.Major || old.Max != maxFormat.Major && old.Max != last) {
                    return null;
                }
                result.Add((minFormat, maxFormat, directory));
            }
            else if (supported is { } range) {
                if (range.Max > last) {
                    return null;
                }
                result.Add((new PackFormat(range.Min, 0), new PackFormat(range.Max, 0), directory));
            }
        }
        return result;
    }

    /// <summary><c>OverlayMetadataSection.DIR_VALIDATOR</c>.</summary>
    private static bool ValidOverlayDirectory(string directory) =>
        directory.Length > 0 && directory.All(c => c is '-' or '_' or '.' or >= 'a' and <= 'z' or >= 'A' and <= 'Z' or >= '0' and <= '9');

    /// <summary><c>LanguageManager.extractLanguages</c>' read of one pack: null when it has none, or the section does not parse.</summary>
    public static IReadOnlyDictionary<string, LanguageInfo>? Languages(byte[]? mcmeta) {
        if (Parse(mcmeta)?["language"] is not JObject section) {
            return null;
        }
        Dictionary<string, LanguageInfo> languages = new();
        foreach ((string code, JToken? value) in section) {
            if (code.Length is < 1 or > 16 || value is not JObject info || NonEmptyString(info["region"]) is not { } region ||
                NonEmptyString(info["name"]) is not { } name) {
                return null;
            }
            bool bidirectional = false;
            if (info["bidirectional"] is { } flag) {
                if (flag.Type != JTokenType.Boolean) {
                    return null;
                }
                bidirectional = flag.Value<bool>();
            }
            languages[code] = new LanguageInfo(region, name, bidirectional);
        }
        return languages;
    }

    /// <summary><c>PackCompatibility.forVersion</c>.</summary>
    public static PackCompatibility ForVersion((PackFormat Min, PackFormat Max) declared, PackFormat game) {
        if (declared.Min.Major == int.MaxValue) {
            return PackCompatibility.Unknown;
        }
        if (declared.Max < game) {
            return PackCompatibility.TooOld;
        }
        return game < declared.Min ? PackCompatibility.TooNew : PackCompatibility.Compatible;
    }

    private static JObject? Parse(byte[]? mcmeta) {
        if (mcmeta == null) {
            return null;
        }
        try {
            return JToken.Parse(System.Text.Encoding.UTF8.GetString(mcmeta)) as JObject;
        }
        catch (JsonException) {
            return null;
        }
    }

    private static string? NonEmptyString(JToken? token) => token?.Type == JTokenType.String && token.Value<string>() is { Length: > 0 } s ? s : null;

    /// <summary><c>ComponentSerialization.CODEC</c> over JSON: a string, a list or an object.</summary>
    private static TextComponent? ReadDescription(JObject section) {
        if (section["description"] is not { } description) {
            return null;
        }
        try {
            return TextComponent.FromTag(NBT.INbtTag.FromJson(description.ToString(Formatting.None)));
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            return null;
        }
    }

    /// <summary>
    /// <c>PackFormat.packCodec</c>'s read of the <c>pack</c> section and <c>IntermediaryFormat.validate</c> as a
    /// pack's own section calls it; null where vanilla's codec reports an error.
    /// </summary>
    private static (PackFormat Min, PackFormat Max)? SupportedFormats(JObject section) {
        if (!OptionalFormat(section["min_format"], 0, out PackFormat? min) || !OptionalFormat(section["max_format"], int.MaxValue, out PackFormat? max) ||
            !OptionalInt(section["pack_format"], out int? format) || !OptionalRange(section["supported_formats"], out (int Min, int Max)? supported)) {
            return null;
        }
        const int last = PackFormat.LastPreMinorVersion;
        if (min.HasValue != max.HasValue) {
            return null;
        }
        if (min is { } minFormat && max is { } maxFormat) {
            int majorMin = minFormat.Major, majorMax = maxFormat.Major;
            if (minFormat > maxFormat) {
                return null;
            }
            if (majorMin > last) {
                if (supported != null || format is { } f && !PackFormatInRange(f, majorMin, majorMax)) {
                    return null;
                }
            }
            else {
                if (supported is not { } old || old.Min != majorMin || old.Max != majorMax && old.Max != last) {
                    return null;
                }
                if (format is not { } f || !PackFormatInRange(f, majorMin, majorMax)) {
                    return null;
                }
            }
            return (minFormat, maxFormat);
        }
        if (supported is { } range) {
            if (range.Max > last || format is not { } f || !PackFormatInRange(f, range.Min, range.Max)) {
                return null;
            }
            return (new PackFormat(range.Min, 0), new PackFormat(range.Max, 0));
        }
        if (format is { } only) {
            return only > last ? null : (new PackFormat(only, 0), new PackFormat(only, 0));
        }
        return null;
    }

    /// <summary><c>validatePackFormatForRange</c>: whether it passes.</summary>
    private static bool PackFormatInRange(int format, int min, int max) => format >= min && format <= max && format >= 15;

    private static bool OptionalInt(JToken? token, out int? value) {
        value = null;
        if (token == null) {
            return true;
        }
        if (token.Type is not (JTokenType.Integer or JTokenType.Float)) {
            return false;
        }
        value = (int)token.Value<double>();
        return true;
    }

    /// <summary><c>PackFormat.fullCodec</c>: a major alone, or a list of one to 256 non-negative integers whose first two are the major and minor.</summary>
    private static bool OptionalFormat(JToken? token, int defaultMinor, out PackFormat? value) {
        value = null;
        if (token == null) {
            return true;
        }
        List<int> list = [];
        if (token is JArray array) {
            if (array.Count is < 1 or > 256) {
                return false;
            }
            foreach (JToken element in array) {
                if (!NonNegativeInt(element, out int n)) {
                    return false;
                }
                list.Add(n);
            }
        }
        else if (NonNegativeInt(token, out int single)) {
            list.Add(single);
        }
        else {
            return false;
        }
        value = new PackFormat(list[0], list.Count > 1 ? list[1] : defaultMinor);
        return true;
    }

    private static bool NonNegativeInt(JToken token, out int value) {
        value = 0;
        if (token.Type is not (JTokenType.Integer or JTokenType.Float)) {
            return false;
        }
        value = (int)token.Value<double>();
        return value >= 0;
    }

    /// <summary><c>InclusiveRange.codec(Codec.INT)</c>: one integer, a pair, or <c>min_inclusive</c> and <c>max_inclusive</c>.</summary>
    private static bool OptionalRange(JToken? token, out (int Min, int Max)? value) {
        value = null;
        if (token == null) {
            return true;
        }
        int min, max;
        switch (token) {
            case JArray { Count: 2 } pair when OptionalInt(pair[0], out int? a) && OptionalInt(pair[1], out int? b):
                (min, max) = (a!.Value, b!.Value);
                break;
            case JObject range when range["min_inclusive"] is { } lo && range["max_inclusive"] is { } hi && OptionalInt(lo, out int? a) && OptionalInt(hi, out int? b):
                (min, max) = (a!.Value, b!.Value);
                break;
            case JValue when OptionalInt(token, out int? single):
                (min, max) = (single!.Value, single.Value);
                break;
            default:
                return false;
        }
        if (min > max) {
            return false;
        }
        value = (min, max);
        return true;
    }
}
