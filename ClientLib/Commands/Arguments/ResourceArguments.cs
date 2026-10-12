using ClientLib.Brigadier;
using Minecraft.Schemas;

namespace ClientLib.Commands.Arguments;

/// <summary>What the resource arguments keep of a parse: an element or tag of a registry, by id.</summary>
public sealed record ResourceOrTagResult(Identifier RegistryKey, Identifier Id, bool IsTag);

/// <summary>
/// Vanilla's <c>ResourceArgument</c>. For a registry the client does not hold, the id is accepted
/// unchecked and suggestions come from the server, where vanilla's client holds every such registry.
/// </summary>
public sealed class ResourceArgument(CommandBuildContext context, Identifier registryKey) : ArgumentType<ResourceOrTagResult> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012"];

    public static readonly Dynamic2CommandExceptionType ErrorUnknownResource =
        new((id, registry) => Component.TranslatableEscape("argument.resource.not_found", id, registry));

    private readonly ClientRegistryLookup? _registryLookup = context.Lookup(registryKey) as ClientRegistryLookup;

    public Identifier RegistryKey { get; } = registryKey;

    public override ResourceOrTagResult Parse(StringReader reader) => ReadElement(reader, RegistryKey, _registryLookup);

    internal static ResourceOrTagResult ReadElement(StringReader reader, Identifier registryKey, ClientRegistryLookup? lookup) {
        Identifier resourceId = Identifiers.Read(reader);
        if (lookup != null && !lookup.Contains(resourceId)) {
            throw ErrorUnknownResource.CreateWithContext(reader, resourceId, registryKey);
        }
        return new ResourceOrTagResult(registryKey, resourceId, false);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.ListSuggestions(context, builder, RegistryKey, SharedSuggestionProvider.ElementSuggestionType.Elements);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ResourceKeyArgument</c>.</summary>
public sealed class ResourceKeyArgument(Identifier registryKey) : ArgumentType<ResourceOrTagResult> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012"];

    public Identifier RegistryKey { get; } = registryKey;

    public override ResourceOrTagResult Parse(StringReader reader) => ResourceArgument.ReadElement(reader, RegistryKey, null);

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.ListSuggestions(context, builder, RegistryKey, SharedSuggestionProvider.ElementSuggestionType.Elements);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ResourceOrTagArgument</c>, checking what it can as <see cref="ResourceArgument"/> does.</summary>
public sealed class ResourceOrTagArgument(CommandBuildContext context, Identifier registryKey) : ArgumentType<ResourceOrTagResult> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012", "#skeletons", "#minecraft:skeletons"];

    private static readonly Dynamic2CommandExceptionType ErrorUnknownTag =
        new((id, registry) => Component.TranslatableEscape("argument.resource_tag.not_found", id, registry));

    private readonly ClientRegistryLookup? _registryLookup = context.Lookup(registryKey) as ClientRegistryLookup;

    public Identifier RegistryKey { get; } = registryKey;

    public override ResourceOrTagResult Parse(StringReader reader) => ReadElementOrTag(reader, RegistryKey, _registryLookup);

    internal static ResourceOrTagResult ReadElementOrTag(StringReader reader, Identifier registryKey, ClientRegistryLookup? lookup) {
        if (!reader.CanRead() || reader.Peek() != '#') {
            return ResourceArgument.ReadElement(reader, registryKey, lookup);
        }
        int cursor = reader.Cursor;
        try {
            reader.Skip();
            Identifier tagId = Identifiers.Read(reader);
            if (lookup != null && !lookup.ContainsTag(tagId)) {
                throw ErrorUnknownTag.CreateWithContext(reader, tagId, registryKey);
            }
            return new ResourceOrTagResult(registryKey, tagId, true);
        }
        catch (CommandSyntaxException) {
            reader.Cursor = cursor;
            throw;
        }
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.ListSuggestions(context, builder, RegistryKey, SharedSuggestionProvider.ElementSuggestionType.All);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ResourceOrTagKeyArgument</c>.</summary>
public sealed class ResourceOrTagKeyArgument(Identifier registryKey) : ArgumentType<ResourceOrTagResult> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012", "#skeletons", "#minecraft:skeletons"];

    public Identifier RegistryKey { get; } = registryKey;

    public override ResourceOrTagResult Parse(StringReader reader) => ResourceOrTagArgument.ReadElementOrTag(reader, RegistryKey, null);

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.ListSuggestions(context, builder, RegistryKey, SharedSuggestionProvider.ElementSuggestionType.All);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ResourceSelectorArgument</c>.</summary>
public sealed class ResourceSelectorArgument(CommandBuildContext context, Identifier registryKey) : ArgumentType<IReadOnlyList<Identifier>> {
    private static readonly string[] ExampleValues = ["minecraft:*", "*:asset", "*"];

    public static readonly Dynamic2CommandExceptionType ErrorNoMatches =
        new((selector, registry) => Component.TranslatableEscape("argument.resource_selector.not_found", selector, registry));

    private readonly IRegistryLookup? _registryLookup = context.Lookup(registryKey);

    public Identifier RegistryKey { get; } = registryKey;

    /// <summary>For a registry the client does not hold, the matches are left to the server.</summary>
    public override IReadOnlyList<Identifier> Parse(StringReader reader) {
        string pattern = EnsureNamespaced(ParserUtils.ReadWhile(reader, IsAllowedPatternCharacter));
        if (_registryLookup == null) {
            return [];
        }
        List<Identifier> results = _registryLookup.ListElementIds().Where(id => WildcardMatch(id.ToString(), pattern)).ToList();
        if (results.Count == 0) {
            throw ErrorNoMatches.CreateWithContext(reader, pattern, RegistryKey);
        }
        return results;
    }

    private static bool IsAllowedPatternCharacter(char character) => Identifiers.IsAllowedInIdentifier(character) || character is '*' or '?';

    private static string EnsureNamespaced(string input) => !input.Contains(':') ? "minecraft:" + input : input;

    /// <summary>Commons IO's <c>FilenameUtils.wildcardMatch</c>, case sensitive: '*' is any run, '?' any one character.</summary>
    public static bool WildcardMatch(string text, string pattern) {
        int t = 0, p = 0, starP = -1, starT = 0;
        while (t < text.Length) {
            if (p < pattern.Length && (pattern[p] == '?' || pattern[p] == text[t])) {
                t++;
                p++;
            }
            else if (p < pattern.Length && pattern[p] == '*') {
                starP = p++;
                starT = t;
            }
            else if (starP >= 0) {
                p = starP + 1;
                t = ++starT;
            }
            else {
                return false;
            }
        }
        while (p < pattern.Length && pattern[p] == '*') {
            p++;
        }
        return p == pattern.Length;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.ListSuggestions(context, builder, RegistryKey, SharedSuggestionProvider.ElementSuggestionType.Elements);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}
