using ClientLib.Brigadier;
using ClientLib.Parsing.Packrat;
using Minecraft.Schemas;
using NBT;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>ComponentPredicateParser</c>.</summary>
public static class ComponentPredicateParser {
    /// <summary>Vanilla's <c>Optional</c>, as a value a packrat rule can return.</summary>
    public sealed record Optional<T>(T? Value);

    /// <summary>Vanilla's <c>Unit</c>.</summary>
    public sealed class Unit {
        public static readonly Unit Instance = new();

        private Unit() {
        }
    }

    public static Grammar<List<T>> CreateGrammar<T, C, P>(IContext<T, C, P> context) where T : class where C : class where P : class {
        Atom<List<T>> top = Atom<List<T>>.Of("top");
        Atom<Optional<T>> type = Atom<Optional<T>>.Of("type");
        Atom<Unit> anyType = Atom<Unit>.Of("any_type");
        Atom<T> elementType = Atom<T>.Of("element_type");
        Atom<T> tagType = Atom<T>.Of("tag_type");
        Atom<List<T>> conditions = Atom<List<T>>.Of("conditions");
        Atom<List<T>> alternatives = Atom<List<T>>.Of("alternatives");
        Atom<T> term = Atom<T>.Of("term");
        Atom<T> negation = Atom<T>.Of("negation");
        Atom<T> test = Atom<T>.Of("test");
        Atom<C> componentType = Atom<C>.Of("component_type");
        Atom<P> predicateType = Atom<P>.Of("predicate_type");
        Atom<Identifier?> id = Atom<Identifier?>.Of("id");
        Atom<INbtTag> tag = Atom<INbtTag>.Of("tag");
        Dictionary<StringReader> rules = new();
        INamedRule<StringReader, Identifier?> idRule = rules.Put(id, IdentifierParseRule.Instance);
        INamedRule<StringReader, List<T>> topRule = rules.Put(top,
            Term.Alternative(
                Term.Sequence(
                    rules.Named(type), StringReaderTerms.Character('['), Term.Cut<StringReader>(), Term.Optional(rules.Named(conditions)),
                    StringReaderTerms.Character(']')),
                rules.Named(type)),
            scope => {
                List<T> builder = [];
                if (scope.GetOrThrow(type).Value is { } parsedType) {
                    builder.Add(parsedType);
                }
                List<T>? parsedConditions = scope.Get(conditions);
                if (parsedConditions != null) {
                    builder.AddRange(parsedConditions);
                }
                return builder;
            });
        rules.Put(type,
            Term.Alternative(
                rules.Named(elementType),
                Term.Sequence(StringReaderTerms.Character('#'), Term.Cut<StringReader>(), rules.Named(tagType)),
                rules.Named(anyType)),
            scope => new Optional<T>(scope.GetAny(elementType, tagType)));
        rules.Put(anyType, StringReaderTerms.Character('*'), _ => Unit.Instance);
        rules.Put(elementType, new LookupRule<T>(idRule, context.ForElementType, context.ListElementTypes));
        rules.Put(tagType, new LookupRule<T>(idRule, context.ForTagType, context.ListTagTypes));
        rules.Put(conditions,
            Term.Sequence(rules.Named(alternatives),
                Term.Optional(Term.Sequence(StringReaderTerms.Character(','), rules.Named(conditions)))),
            scope => {
                T parsedCondition = context.AnyOf(scope.GetOrThrow(alternatives));
                List<T>? rest = scope.Get(conditions);
                return rest != null ? [parsedCondition, ..rest] : [parsedCondition];
            });
        rules.Put(alternatives,
            Term.Sequence(rules.Named(term), Term.Optional(Term.Sequence(StringReaderTerms.Character('|'), rules.Named(alternatives)))),
            scope => {
                T alternative = scope.GetOrThrow(term);
                List<T>? rest = scope.Get(alternatives);
                return rest != null ? [alternative, ..rest] : [alternative];
            });
        rules.Put(term,
            Term.Alternative(rules.Named(test), Term.Sequence(StringReaderTerms.Character('!'), rules.Named(negation))),
            scope => scope.GetAnyOrThrow(test, negation));
        rules.Put(negation, rules.Named(test), scope => context.Negate(scope.GetOrThrow(test)));
        rules.PutComplex(test,
            Term.Alternative(
                Term.Sequence(rules.Named(componentType), StringReaderTerms.Character('='), Term.Cut<StringReader>(), rules.Named(tag)),
                Term.Sequence(rules.Named(predicateType), StringReaderTerms.Character('~'), Term.Cut<StringReader>(), rules.Named(tag)),
                rules.Named(componentType)),
            state => {
                Scope scope = state.Scope;
                P? predicate = scope.Get(predicateType);
                try {
                    if (predicate != null) {
                        INbtTag value = scope.GetOrThrow(tag);
                        return context.CreatePredicateTest(state.Input, predicate, value);
                    }
                    C component = scope.GetOrThrow(componentType);
                    INbtTag? componentValue = scope.Get(tag);
                    return componentValue != null
                        ? context.CreateComponentTest(state.Input, component, componentValue)
                        : context.CreateComponentTest(state.Input, component);
                }
                catch (CommandSyntaxException e) {
                    state.ErrorCollector.Store(state.Mark(), e);
                    return null;
                }
            });
        rules.Put(componentType, new LookupRule<C>(idRule, context.LookupComponentType, context.ListComponentTypes));
        rules.Put(predicateType, new LookupRule<P>(idRule, context.LookupPredicateType, context.ListPredicateTypes));
        rules.Put(tag, new TagParseRule());
        return new Grammar<List<T>>(rules, topRule);
    }

    /// <summary><c>ComponentPredicateParser.Context</c>.</summary>
    public interface IContext<T, C, P> {
        T ForElementType(IImmutableStringReader reader, Identifier id);

        IEnumerable<Identifier> ListElementTypes();

        T ForTagType(IImmutableStringReader reader, Identifier id);

        IEnumerable<Identifier> ListTagTypes();

        C LookupComponentType(IImmutableStringReader reader, Identifier id);

        IEnumerable<Identifier> ListComponentTypes();

        T CreateComponentTest(IImmutableStringReader reader, C componentType, INbtTag value);

        T CreateComponentTest(IImmutableStringReader reader, C componentType);

        P LookupPredicateType(IImmutableStringReader reader, Identifier id);

        IEnumerable<Identifier> ListPredicateTypes();

        T CreatePredicateTest(IImmutableStringReader reader, P predicateType, INbtTag value);

        T Negate(T value);

        T AnyOf(List<T> alternatives);
    }

    /// <summary>Vanilla's element, tag, component and predicate lookup rules, which differ only in the context methods they call.</summary>
    private sealed class LookupRule<V>(INamedRule<StringReader, Identifier?> idParser, Func<IImmutableStringReader, Identifier, V> validate,
        Func<IEnumerable<Identifier>> list) : ResourceLookupRule<object?, V>(idParser, null) {
        protected override V ValidateElement(IImmutableStringReader reader, Identifier id) => validate(reader, id);

        public override IEnumerable<Identifier> PossibleResources() => list();
    }
}
