using ClientLib.Brigadier;
using Minecraft.Schemas;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>EntityArgument</c>.</summary>
public sealed class EntityArgument(bool single, bool playersOnly) : ArgumentType<EntitySelector> {
    private static readonly string[] ExampleValues = ["Player", "0123", "@e", "@e[type=foo]", "dd12be42-52a9-4a91-a8a1-11c01849e498"];

    public static readonly SimpleCommandExceptionType ErrorNotSingleEntity = new(Component.Translatable("argument.entity.toomany"));
    public static readonly SimpleCommandExceptionType ErrorNotSinglePlayer = new(Component.Translatable("argument.player.toomany"));
    public static readonly SimpleCommandExceptionType ErrorOnlyPlayersAllowed = new(Component.Translatable("argument.player.entities"));

    private static readonly Identifier EntityTypeRegistry = "minecraft:entity_type";

    public bool Single { get; } = single;
    public bool PlayersOnly { get; } = playersOnly;

    public override EntitySelector Parse(StringReader reader) => Parse(reader, true);

    public override EntitySelector Parse<TSource>(StringReader reader, TSource source) => Parse(reader, EntitySelectorParser.AllowSelectors(source));

    /// <summary>Vanilla rewinds to the start of the whole command, not of the argument, before each error.</summary>
    private EntitySelector Parse(StringReader reader, bool allowSelectors) {
        EntitySelector selector = new EntitySelectorParser(reader, allowSelectors).Parse();
        if (selector.MaxResults > 1 && Single) {
            reader.Cursor = 0;
            throw PlayersOnly ? ErrorNotSinglePlayer.CreateWithContext(reader) : ErrorNotSingleEntity.CreateWithContext(reader);
        }
        if (selector.IncludesEntities && PlayersOnly && !selector.IsSelfSelector) {
            reader.Cursor = 0;
            throw ErrorOnlyPlayersAllowed.CreateWithContext(reader);
        }
        return selector;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> contextBuilder, SuggestionsBuilder builder) {
        return ListSelectorSuggestions(contextBuilder, builder,
            source => PlayersOnly ? source.OnlinePlayerNames : source.OnlinePlayerNames.Concat(source.SelectedEntities));
    }

    internal static Task<Suggestions> ListSelectorSuggestions<TSource>(CommandContext<TSource> contextBuilder, SuggestionsBuilder builder,
        Func<ISharedSuggestionProvider, IEnumerable<string>> names) {
        if (contextBuilder.Source is not ISharedSuggestionProvider source) {
            return Suggestions.Empty();
        }
        StringReader reader = new(builder.Input) { Cursor = builder.Start };
        EntitySelectorParser parser = new(reader, source.Permissions.HasPermission(Permissions.CommandsEntitySelectors)) {
            EntityTypeTags = source.Lookup(EntityTypeRegistry)?.ListTagIds()
        };
        try {
            parser.Parse();
        }
        catch (CommandSyntaxException) {
        }
        return parser.FillSuggestions(builder, suggestions => SharedSuggestionProvider.Suggest(names(source), suggestions));
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ScoreHolderArgument</c>.</summary>
public sealed class ScoreHolderArgument(bool multiple) : ArgumentType<ScoreHolderArgument.Result> {
    private static readonly string[] ExampleValues = ["Player", "0123", "*", "@e"];

    /// <summary>What vanilla's lambda results resolve on the server: a selector, the wildcard, a <c>#</c> fake player, a UUID, or a name.</summary>
    public abstract record Result;

    public sealed record SelectorResult(EntitySelector Selector) : Result;

    public sealed record WildcardResult : Result;

    public sealed record NameOnlyResult(string Name) : Result;

    public sealed record UuidResult(Guid Uuid, string Text) : Result;

    public sealed record NameResult(string Name) : Result;

    public bool Multiple { get; } = multiple;

    public override Result Parse(StringReader reader) => Parse(reader, true);

    public override Result Parse<TSource>(StringReader reader, TSource source) => Parse(reader, EntitySelectorParser.AllowSelectors(source));

    private Result Parse(StringReader reader, bool allowSelectors) {
        if (reader.CanRead() && reader.Peek() == EntitySelectorParser.SyntaxSelectorStart) {
            EntitySelector selector = new EntitySelectorParser(reader, allowSelectors).Parse();
            if (!Multiple && selector.MaxResults > 1) {
                throw EntityArgument.ErrorNotSingleEntity.CreateWithContext(reader);
            }
            return new SelectorResult(selector);
        }
        string text = ParserUtils.ReadWhile(reader, c => c != ' ');
        if (text == "*") {
            return new WildcardResult();
        }
        if (text.StartsWith('#')) {
            return new NameOnlyResult(text);
        }
        return JavaUuid.TryParse(text, out Guid uuid) ? new UuidResult(uuid, text) : new NameResult(text);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>GameProfileArgument</c>.</summary>
public sealed class GameProfileArgument : ArgumentType<GameProfileArgument.Result> {
    private static readonly string[] ExampleValues = ["Player", "0123", "dd12be42-52a9-4a91-a8a1-11c01849e498", "@e"];

    /// <summary>What vanilla's result resolves on the server: a selector's players, or a name looked up in the profile cache.</summary>
    public abstract record Result;

    public sealed record SelectorResult(EntitySelector Selector) : Result;

    public sealed record NameResult(string Name) : Result;

    public override Result Parse<TSource>(StringReader reader, TSource source) => Parse(reader, EntitySelectorParser.AllowSelectors(source));

    public override Result Parse(StringReader reader) => Parse(reader, true);

    private static Result Parse(StringReader reader, bool allowSelectors) {
        if (reader.CanRead() && reader.Peek() == EntitySelectorParser.SyntaxSelectorStart) {
            EntitySelector parse = new EntitySelectorParser(reader, allowSelectors).Parse();
            if (parse.IncludesEntities) {
                throw EntityArgument.ErrorOnlyPlayersAllowed.CreateWithContext(reader);
            }
            return new SelectorResult(parse);
        }
        return new NameResult(ParserUtils.ReadWhile(reader, c => c != ' '));
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> contextBuilder, SuggestionsBuilder builder) {
        return EntityArgument.ListSelectorSuggestions(contextBuilder, builder, source => source.OnlinePlayerNames);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}
