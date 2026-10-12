using ClientLib.Brigadier;
using ClientLib.Nbt;
using ClientLib.Parsing.Packrat;
using Minecraft.Schemas;
using NBT;

namespace ClientLib.Commands.Arguments;

/// <summary>
/// Vanilla's <c>ResourceOrIdArgument</c>: an element's id, or the element inline. The client has no
/// codecs for these elements, so it is not generic over them and an inline value stays a tag.
/// </summary>
public sealed class ResourceOrIdArgument : ArgumentType<ResourceOrIdArgument.IResult?> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012", "{}", "true"];

    public static readonly Dynamic2CommandExceptionType ErrorNoSuchElement =
        new((id, registry) => Component.TranslatableEscape("argument.resource_or_id.no_such_element", id, registry));

    // Registries the client does not hold.
    private static readonly Identifier LootTableRegistry = "minecraft:loot_table";
    private static readonly Identifier PredicateRegistry = "minecraft:predicate";
    private static readonly Identifier ItemModifierRegistry = "minecraft:item_modifier";

    private readonly IRegistryLookup? _elementLookup;
    private readonly Grammar<IResult> _grammar;
    private readonly Identifier _registryKey;

    private ResourceOrIdArgument(CommandBuildContext context, Identifier registryKey) {
        _elementLookup = context.Lookup(registryKey);
        _registryKey = registryKey;
        _grammar = CreateGrammar(registryKey);
    }

    public static ResourceOrIdArgument LootTable(CommandBuildContext context) => new(context, LootTableRegistry);

    public static ResourceOrIdArgument LootModifier(CommandBuildContext context) => new(context, ItemModifierRegistry);

    public static ResourceOrIdArgument LootPredicate(CommandBuildContext context) => new(context, PredicateRegistry);

    public static ResourceOrIdArgument Dialog(CommandBuildContext context) => new(context, context.Registry.Dialogs.RegistryId);

    /// <summary><c>ResourceOrIdArgument.createGrammar</c>.</summary>
    public static Grammar<IResult> CreateGrammar(Identifier registryKey) {
        Grammar<INbtTag> inlineValueGrammar = SnbtGrammar.CreateParser();
        Dictionary<StringReader> rules = new();
        Atom<IResult> result = Atom<IResult>.Of("result");
        Atom<Identifier?> id = Atom<Identifier?>.Of("id");
        Atom<INbtTag> value = Atom<INbtTag>.Of("value");
        rules.Put(id, IdentifierParseRule.Instance);
        rules.Put(value, inlineValueGrammar.Top.Value);
        INamedRule<StringReader, IResult> topRule = rules.Put(result, Term.Alternative(rules.Named(id), rules.Named(value)), scope => {
            Identifier? parsedId = scope.Get(id);
            if (parsedId != null) {
                return new ReferenceResult(registryKey, parsedId.Value);
            }
            return new InlineResult(scope.GetOrThrow(value));
        });
        return new Grammar<IResult>(rules, topRule);
    }

    /// <summary>Null when the client does not hold the registry, as vanilla's client returns for loot tables, predicates and item modifiers.</summary>
    public override IResult? Parse(StringReader reader) {
        IResult contents = _grammar.ParseForCommands(reader);
        if (_elementLookup == null) {
            return null;
        }
        contents.Parse(reader, _elementLookup);
        return contents;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.ListSuggestions(context, builder, _registryKey, SharedSuggestionProvider.ElementSuggestionType.Elements);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    /// <summary><c>ResourceOrIdArgument.Result</c>.</summary>
    public interface IResult {
        void Parse(IImmutableStringReader reader, IRegistryLookup elementLookup);
    }

    /// <summary>
    /// <c>ResourceOrIdArgument.InlineResult</c>. Vanilla decodes the value and raises
    /// <c>argument.resource_or_id.failed_to_parse</c>; the client lacks the dialog codec, so it is unchecked.
    /// </summary>
    public sealed record InlineResult(INbtTag Value) : IResult {
        public void Parse(IImmutableStringReader reader, IRegistryLookup elementLookup) {
        }
    }

    /// <summary><c>ResourceOrIdArgument.ReferenceResult</c>.</summary>
    public sealed record ReferenceResult(Identifier Registry, Identifier Key) : IResult {
        public void Parse(IImmutableStringReader reader, IRegistryLookup elementLookup) {
            if (!elementLookup.ListElementIds().Contains(Key)) {
                throw ErrorNoSuchElement.CreateWithContext(reader, Key, Registry);
            }
        }
    }
}
