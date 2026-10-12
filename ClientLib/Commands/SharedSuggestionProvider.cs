using ClientLib.Brigadier;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ClientLib.Commands;

/// <summary>What <c>HolderLookup</c> answers for suggestions: the ids of a registry's elements and tags.</summary>
public interface IRegistryLookup {
    Identifier Key { get; }
    IEnumerable<Identifier> ListElementIds();
    IEnumerable<Identifier> ListTagIds();
}

/// <summary>Vanilla's <c>SharedSuggestionProvider</c>, the source a client side command parse runs as.</summary>
public interface ISharedSuggestionProvider {
    IPermissionSet Permissions { get; }

    IReadOnlyCollection<string> OnlinePlayerNames { get; }

    IReadOnlyCollection<string> CustomTabSuggestions => OnlinePlayerNames;

    IReadOnlyCollection<string> SelectedEntities => [];

    IReadOnlyCollection<string> AllTeams { get; }

    IEnumerable<Identifier> AvailableSounds { get; }

    Task<Suggestions> CustomSuggestion<TSource>(CommandContext<TSource> context);

    IReadOnlyCollection<SharedSuggestionProvider.TextCoordinates> RelevantCoordinates => [SharedSuggestionProvider.TextCoordinates.DefaultGlobal];

    IReadOnlyCollection<SharedSuggestionProvider.TextCoordinates> AbsoluteCoordinates => [SharedSuggestionProvider.TextCoordinates.DefaultGlobal];

    IReadOnlyCollection<Identifier> Levels { get; }

    /// <summary><c>registryAccess().lookup(key)</c>: null for a registry this side does not hold.</summary>
    IRegistryLookup? Lookup(Identifier registryKey);

    IReadOnlyCollection<Identifier> EnabledFeatures { get; }

    void SuggestRegistryElements(IRegistryLookup registry, SharedSuggestionProvider.ElementSuggestionType elements, SuggestionsBuilder builder) {
        if (elements.ShouldSuggestTags()) {
            SharedSuggestionProvider.SuggestResource(registry.ListTagIds(), builder, "#");
        }
        if (elements.ShouldSuggestElements()) {
            SharedSuggestionProvider.SuggestResource(registry.ListElementIds(), builder);
        }
    }

    Task<Suggestions> SuggestRegistryElements<TSource>(Identifier key, SharedSuggestionProvider.ElementSuggestionType elements, SuggestionsBuilder builder,
        CommandContext<TSource> context);
}

/// <summary>The static half of vanilla's <c>SharedSuggestionProvider</c>.</summary>
public static class SharedSuggestionProvider {
    private static readonly char[] MatchSplitter = ['.', '_', '/'];

    public enum ElementSuggestionType { Tags, Elements, All }

    public static bool ShouldSuggestTags(this ElementSuggestionType type) => type is ElementSuggestionType.Tags or ElementSuggestionType.All;

    public static bool ShouldSuggestElements(this ElementSuggestionType type) => type is ElementSuggestionType.Elements or ElementSuggestionType.All;

    public sealed record TextCoordinates(string X, string Y, string Z) {
        public static readonly TextCoordinates DefaultLocal = new("^", "^", "^");
        public static readonly TextCoordinates DefaultGlobal = new("~", "~", "~");
    }

    public static Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder, Identifier registryKey,
        ElementSuggestionType type) {
        return context.Source is ISharedSuggestionProvider suggestionProvider
            ? suggestionProvider.SuggestRegistryElements(registryKey, type, builder, context)
            : builder.BuildFuture();
    }

    public static void FilterResources<T>(IEnumerable<T> values, string contents, Func<T, Identifier> converter, Action<T> consumer) {
        bool hasNamespace = contents.Contains(':');
        foreach (T value in values) {
            Identifier id = converter(value);
            if (hasNamespace) {
                if (MatchesSubStr(contents, id.ToString())) {
                    consumer(value);
                }
            }
            else if (MatchesSubStr(contents, id.Namespace) || MatchesSubStr(contents, id.Key)) {
                consumer(value);
            }
        }
    }

    public static void FilterResources<T>(IEnumerable<T> values, string contents, string prefix, Func<T, Identifier> converter, Action<T> consumer) {
        if (contents.Length == 0) {
            foreach (T value in values) {
                consumer(value);
            }
            return;
        }
        string commonPrefix = CommonPrefix(contents, prefix);
        if (commonPrefix.Length > 0) {
            FilterResources(values, contents[commonPrefix.Length..], converter, consumer);
        }
    }

    /// <summary>Guava's <c>Strings.commonPrefix</c>, which never splits a surrogate pair.</summary>
    private static string CommonPrefix(string a, string b) {
        int maxPrefixLength = Math.Min(a.Length, b.Length);
        int p = 0;
        while (p < maxPrefixLength && a[p] == b[p]) {
            p++;
        }
        if (p > 0 && (char.IsHighSurrogate(a[p - 1]) && p < a.Length && char.IsLowSurrogate(a[p])
                      || char.IsHighSurrogate(b[p - 1]) && p < b.Length && char.IsLowSurrogate(b[p]))) {
            p--;
        }
        return a[..p];
    }

    public static Task<Suggestions> SuggestResource(IEnumerable<Identifier> values, SuggestionsBuilder builder, string prefix) {
        string contents = JavaText.ToLowerRoot(builder.Remaining);
        FilterResources(values, contents, prefix, t => t, v => builder.Suggest(prefix + v));
        return builder.BuildFuture();
    }

    public static Task<Suggestions> SuggestResource(IEnumerable<Identifier> values, SuggestionsBuilder builder) {
        string contents = JavaText.ToLowerRoot(builder.Remaining);
        FilterResources(values, contents, t => t, v => builder.Suggest(v.ToString()));
        return builder.BuildFuture();
    }

    public static Task<Suggestions> SuggestResource<T>(IEnumerable<T> values, SuggestionsBuilder builder, Func<T, Identifier> id, Func<T, TextComponent?> tooltip) {
        string contents = JavaText.ToLowerRoot(builder.Remaining);
        FilterResources(values, contents, id, v => builder.Suggest(id(v).ToString(), tooltip(v)));
        return builder.BuildFuture();
    }

    public static Task<Suggestions> SuggestCoordinates(string currentInput, IEnumerable<TextCoordinates> allSuggestions, SuggestionsBuilder builder,
        Func<string, bool> validator) {
        List<string> result = [];
        if (string.IsNullOrEmpty(currentInput)) {
            foreach (TextCoordinates coordinate in allSuggestions) {
                string fullValue = coordinate.X + " " + coordinate.Y + " " + coordinate.Z;
                if (validator(fullValue)) {
                    result.Add(coordinate.X);
                    result.Add(coordinate.X + " " + coordinate.Y);
                    result.Add(fullValue);
                }
            }
        }
        else {
            string[] fields = JavaSplit(currentInput);
            if (fields.Length == 1) {
                foreach (TextCoordinates coordinate in allSuggestions) {
                    string fullValue = fields[0] + " " + coordinate.Y + " " + coordinate.Z;
                    if (validator(fullValue)) {
                        result.Add(fields[0] + " " + coordinate.Y);
                        result.Add(fullValue);
                    }
                }
            }
            else if (fields.Length == 2) {
                foreach (TextCoordinates coordinate in allSuggestions) {
                    string fullValue = fields[0] + " " + fields[1] + " " + coordinate.Z;
                    if (validator(fullValue)) {
                        result.Add(fullValue);
                    }
                }
            }
        }
        return Suggest(result, builder);
    }

    public static Task<Suggestions> Suggest2DCoordinates(string currentInput, IEnumerable<TextCoordinates> allSuggestions, SuggestionsBuilder builder,
        Func<string, bool> validator) {
        List<string> result = [];
        if (string.IsNullOrEmpty(currentInput)) {
            foreach (TextCoordinates coordinate in allSuggestions) {
                string fullValue = coordinate.X + " " + coordinate.Z;
                if (validator(fullValue)) {
                    result.Add(coordinate.X);
                    result.Add(fullValue);
                }
            }
        }
        else {
            string[] fields = JavaSplit(currentInput);
            if (fields.Length == 1) {
                foreach (TextCoordinates coordinate in allSuggestions) {
                    string fullValue = fields[0] + " " + coordinate.Z;
                    if (validator(fullValue)) {
                        result.Add(fullValue);
                    }
                }
            }
        }
        return Suggest(result, builder);
    }

    /// <summary><c>String.split(" ")</c>, which drops trailing empty strings.</summary>
    private static string[] JavaSplit(string s) {
        List<string> parts = [..s.Split(' ')];
        while (parts.Count > 1 && parts[^1].Length == 0) {
            parts.RemoveAt(parts.Count - 1);
        }
        if (parts.Count == 1 && parts[0].Length == 0 && s.Length > 0) {
            return [];
        }
        return parts.ToArray();
    }

    public static Task<Suggestions> Suggest(IEnumerable<string> values, SuggestionsBuilder builder) {
        string lowerPrefix = JavaText.ToLowerRoot(builder.Remaining);
        foreach (string name in values) {
            if (MatchesSubStr(lowerPrefix, JavaText.ToLowerRoot(name))) {
                builder.Suggest(name);
            }
        }
        return builder.BuildFuture();
    }

    public static Task<Suggestions> Suggest<T>(IEnumerable<T> values, SuggestionsBuilder builder, Func<T, string> toString, Func<T, TextComponent?> tooltip) {
        string lowerPrefix = JavaText.ToLowerRoot(builder.Remaining);
        foreach (T value in values) {
            string name = toString(value);
            if (MatchesSubStr(lowerPrefix, JavaText.ToLowerRoot(name))) {
                builder.Suggest(name, tooltip(value));
            }
        }
        return builder.BuildFuture();
    }

    public static bool MatchesSubStr(string pattern, string input) {
        int index = 0;
        while (!input.AsSpan(index).StartsWith(pattern, StringComparison.Ordinal)) {
            int indexOfSplitter = input.IndexOfAny(MatchSplitter, index);
            if (indexOfSplitter < 0) {
                return false;
            }
            index = indexOfSplitter + 1;
        }
        return true;
    }
}
