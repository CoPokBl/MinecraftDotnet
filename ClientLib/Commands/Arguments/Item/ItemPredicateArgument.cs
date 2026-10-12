using ClientLib.Brigadier;
using ClientLib.Parsing.Packrat;
using Minecraft.Data.Components;
using Minecraft.Data.Components.Codecs;
using Minecraft.Schemas;
using NBT;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>ItemPredicateArgument</c>. The client never tests a stack, so the result is the parsed tests rather than a predicate.</summary>
public sealed class ItemPredicateArgument(CommandBuildContext registries)
    : ParserBasedArgument<ItemPredicateArgument.Result>(ComponentPredicateParser.CreateGrammar(new ItemPredicateContext(registries))
        .MapResult(predicates => new Result(predicates))) {

    private static readonly string[] ExampleValues = ["stick", "minecraft:stick", "#stick", "#stick{foo:'bar'}"];

    private static readonly DynamicCommandExceptionType ErrorUnknownItem = new(id => Component.TranslatableEscape("argument.item.id.invalid", id));
    private static readonly DynamicCommandExceptionType ErrorUnknownTag = new(tag => Component.TranslatableEscape("arguments.item.tag.unknown", tag));
    private static readonly DynamicCommandExceptionType ErrorUnknownComponent = new(id => Component.TranslatableEscape("arguments.item.component.unknown", id));
    private static readonly Dynamic2CommandExceptionType ErrorMalformedComponent =
        new((type, message) => Component.TranslatableEscape("arguments.item.component.malformed", type, message));
    private static readonly DynamicCommandExceptionType ErrorUnknownPredicate = new(id => Component.TranslatableEscape("arguments.item.predicate.unknown", id));

    private static readonly Identifier CountId = new("minecraft", "count");

    /// <summary><c>PSEUDO_COMPONENTS</c> and <c>PSEUDO_PREDICATES</c>, which are both just <c>count</c>.</summary>
    private static readonly Identifier[] PseudoIds = [CountId];

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    public sealed record Result(IReadOnlyList<Test> Tests);

    public abstract record Test {
        public sealed record Item(Identifier Id) : Test;

        public sealed record Tag(Identifier Id) : Test;

        public sealed record ComponentPresent(Identifier Component) : Test;

        public sealed record ComponentEquals(Identifier Component, INbtTag Value) : Test;

        public sealed record Predicate(Identifier Type, INbtTag Value) : Test;

        public sealed record Not(Test Value) : Test;

        public sealed record AnyOf(IReadOnlyList<Test> Alternatives) : Test;
    }

    /// <summary><c>ItemPredicateArgument.ComponentWrapper</c>, without the codec it would decode a value with.</summary>
    private sealed record ComponentWrapper(Identifier Id, IDataComponent? Type);

    /// <summary><c>ItemPredicateArgument.PredicateWrapper</c>.</summary>
    private sealed record PredicateWrapper(Identifier Id);

    /// <summary><c>ItemPredicateArgument.Context</c>.</summary>
    private sealed class ItemPredicateContext(CommandBuildContext registries) : ComponentPredicateParser.IContext<Test, ComponentWrapper, PredicateWrapper> {
        private readonly ClientRegistryLookup? _items = registries.Lookup(registries.Registry.Items.RegistryId) as ClientRegistryLookup;

        public Test ForElementType(IImmutableStringReader reader, Identifier id) {
            if (_items == null || !_items.Contains(id)) {
                throw ErrorUnknownItem.CreateWithContext(reader, id);
            }
            return new Test.Item(id);
        }

        public Test ForTagType(IImmutableStringReader reader, Identifier id) {
            if (_items == null || !_items.ContainsTag(id)) {
                throw ErrorUnknownTag.CreateWithContext(reader, id);
            }
            return new Test.Tag(id);
        }

        /// <summary>A component with no persistent form is refused as vanilla refuses its codec-less, transient ones.</summary>
        public ComponentWrapper LookupComponentType(IImmutableStringReader reader, Identifier componentId) {
            if (componentId == CountId) {
                return new ComponentWrapper(CountId, null);
            }
            if (!registries.Registry.DataComponents.Contains(componentId)) {
                throw ErrorUnknownComponent.CreateWithContext(reader, componentId);
            }
            IDataComponent componentType = registries.Registry.DataComponents[componentId];
            if (!componentType.HasNbtForm) {
                throw ErrorUnknownComponent.CreateWithContext(reader, componentId);
            }
            return new ComponentWrapper(componentId, componentType);
        }

        /// <summary>
        /// <c>ComponentWrapper.decode</c> through this client's codec, so a malformed value's message is
        /// that codec's. The <c>count</c> pseudo component's value is not checked: its codec has no port.
        /// </summary>
        public Test CreateComponentTest(IImmutableStringReader reader, ComponentWrapper componentType, INbtTag value) {
            if (componentType.Type != null) {
                try {
                    componentType.Type.FromNbt(value, registries.Registry);
                }
                catch (UnportedComponentException) {
                }
                catch (Exception e) {
                    throw ErrorMalformedComponent.CreateWithContext(reader, componentType.Id.ToString(), e.Message);
                }
            }
            return new Test.ComponentEquals(componentType.Id, value);
        }

        public Test CreateComponentTest(IImmutableStringReader reader, ComponentWrapper componentType) => new Test.ComponentPresent(componentType.Id);

        /// <summary>
        /// The client holds no <c>data_component_predicate_type</c> registry; every vanilla predicate type
        /// is named after the component it reads, so the component ids stand in for it.
        /// </summary>
        public PredicateWrapper LookupPredicateType(IImmutableStringReader reader, Identifier componentId) {
            if (componentId == CountId || registries.Registry.DataComponents.Contains(componentId)) {
                return new PredicateWrapper(componentId);
            }
            throw ErrorUnknownPredicate.CreateWithContext(reader, componentId);
        }

        /// <summary>Vanilla's <c>arguments.item.predicate.malformed</c> check needs the predicate codecs, which the client lacks.</summary>
        public Test CreatePredicateTest(IImmutableStringReader reader, PredicateWrapper predicateType, INbtTag value) => new Test.Predicate(predicateType.Id, value);

        public IEnumerable<Identifier> ListElementTypes() => _items?.ListElementIds() ?? [];

        public IEnumerable<Identifier> ListTagTypes() => _items?.ListTagIds() ?? [];

        public IEnumerable<Identifier> ListComponentTypes() => PseudoIds.Concat(ComponentIds().Where(id => registries.Registry.DataComponents[id].HasNbtForm));

        /// <summary>Vanilla lists the predicate type registry; without it, the components that stand in for it.</summary>
        public IEnumerable<Identifier> ListPredicateTypes() => PseudoIds.Concat(ComponentIds());

        private IEnumerable<Identifier> ComponentIds() => registries.Lookup(registries.Registry.DataComponents.RegistryId)?.ListElementIds() ?? [];

        public Test Negate(Test value) => new Test.Not(value);

        public Test AnyOf(List<Test> alternatives) => new Test.AnyOf(alternatives);
    }
}
