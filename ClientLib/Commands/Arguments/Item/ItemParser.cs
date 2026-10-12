using ClientLib.Brigadier;
using ClientLib.Nbt;
using Minecraft.Data.Components;
using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>ItemParser</c>.</summary>
public sealed class ItemParser {
    private static readonly DynamicCommandExceptionType ErrorUnknownItem = new(id => Component.TranslatableEscape("argument.item.id.invalid", id));
    private static readonly DynamicCommandExceptionType ErrorUnknownComponent = new(id => Component.TranslatableEscape("arguments.item.component.unknown", id));
    private static readonly Dynamic2CommandExceptionType ErrorMalformedComponent = new((type, message) => Component.TranslatableEscape("arguments.item.component.malformed", type, message));
    private static readonly SimpleCommandExceptionType ErrorExpectedComponent = new(Component.Translatable("arguments.item.component.expected"));
    private static readonly DynamicCommandExceptionType ErrorRepeatedComponent = new(id => Component.TranslatableEscape("arguments.item.component.repeated", id));

    public const char SyntaxStartComponents = '[';
    public const char SyntaxEndComponents = ']';
    public const char SyntaxComponentSeparator = ',';
    public const char SyntaxComponentAssignment = '=';
    public const char SyntaxRemovedComponent = '!';

    private static readonly Func<SuggestionsBuilder, Task<Suggestions>> SuggestNothing = builder => builder.BuildFuture();

    private readonly CommandBuildContext _registries;
    private readonly MinecraftRegistry _registryOps;
    private readonly TagParser _tagParser = TagParser.Create();

    public ItemParser(CommandBuildContext registries) {
        _registries = registries;
        _registryOps = registries.Registry;
    }

    public ItemInput Parse(StringReader reader) {
        IItem? itemResult = null;
        Dictionary<IDataComponent, object> set = new();
        List<IDataComponent> removed = [];
        Parse(reader, new DelegateVisitor(
            item => itemResult = item,
            (type, value) => set[type] = value,
            type => removed.Add(type)));
        IItem item = itemResult ?? throw new InvalidOperationException("Parser gave no item");
        return new ItemInput(item, set, removed);
    }

    public void Parse(StringReader reader, IVisitor visitor) {
        int cursor = reader.Cursor;
        try {
            new State(this, reader, visitor).Parse();
        }
        catch (CommandSyntaxException) {
            reader.Cursor = cursor;
            throw;
        }
    }

    public Task<Suggestions> FillSuggestions(SuggestionsBuilder builder) {
        StringReader reader = new(builder.Input) { Cursor = builder.Start };
        SuggestionsVisitor handler = new();
        try {
            new State(this, reader, handler).Parse();
        }
        catch (CommandSyntaxException) {
        }
        return handler.ResolveSuggestions(builder, reader);
    }

    private sealed class State(ItemParser parser, StringReader reader, IVisitor visitor) {
        public void Parse() {
            visitor.VisitSuggestions(SuggestItem);
            ReadItem();
            visitor.VisitSuggestions(SuggestStartComponents);
            if (reader.CanRead() && reader.Peek() == SyntaxStartComponents) {
                visitor.VisitSuggestions(SuggestNothing);
                ReadComponents();
            }
        }

        private void ReadItem() {
            int cursor = reader.Cursor;
            Identifier id = Identifiers.Read(reader);
            if (!parser._registryOps.Items.Contains(id)) {
                reader.Cursor = cursor;
                throw ErrorUnknownItem.CreateWithContext(reader, id);
            }
            visitor.VisitItem(parser._registryOps.Items[id]);
        }

        private void ReadComponents() {
            reader.Expect(SyntaxStartComponents);
            visitor.VisitSuggestions(SuggestComponentAssignmentOrRemoval);
            HashSet<IDataComponent> visitedComponents = new(ReferenceEqualityComparer.Instance);

            while (reader.CanRead() && reader.Peek() != SyntaxEndComponents) {
                reader.SkipWhitespace();
                if (reader.CanRead() && reader.Peek() == SyntaxRemovedComponent) {
                    reader.Skip();
                    visitor.VisitSuggestions(SuggestComponent);
                    IDataComponent componentType = ReadComponentType(parser._registryOps, reader);
                    if (!visitedComponents.Add(componentType)) {
                        throw ErrorRepeatedComponent.Create(componentType.Identifier.ToString());
                    }
                    visitor.VisitRemovedComponent(componentType);
                    visitor.VisitSuggestions(SuggestNothing);
                    reader.SkipWhitespace();
                }
                else {
                    IDataComponent componentType = ReadComponentType(parser._registryOps, reader);
                    if (!visitedComponents.Add(componentType)) {
                        throw ErrorRepeatedComponent.Create(componentType.Identifier.ToString());
                    }
                    visitor.VisitSuggestions(SuggestAssignment);
                    reader.SkipWhitespace();
                    reader.Expect(SyntaxComponentAssignment);
                    visitor.VisitSuggestions(SuggestNothing);
                    reader.SkipWhitespace();
                    ReadComponent(parser._tagParser, parser._registryOps, componentType);
                    reader.SkipWhitespace();
                }

                visitor.VisitSuggestions(SuggestNextOrEndComponents);
                if (!reader.CanRead() || reader.Peek() != SyntaxComponentSeparator) {
                    break;
                }
                reader.Skip();
                reader.SkipWhitespace();
                visitor.VisitSuggestions(SuggestComponentAssignmentOrRemoval);
                if (!reader.CanRead()) {
                    throw ErrorExpectedComponent.CreateWithContext(reader);
                }
            }

            reader.Expect(SyntaxEndComponents);
            visitor.VisitSuggestions(SuggestNothing);
        }

        /// <summary>A component with no persistent form is one vanilla marks transient, which is what it refuses here.</summary>
        public static IDataComponent ReadComponentType(MinecraftRegistry registry, StringReader reader) {
            if (!reader.CanRead()) {
                throw ErrorExpectedComponent.CreateWithContext(reader);
            }
            int cursor = reader.Cursor;
            Identifier id = Identifiers.Read(reader);
            IDataComponent? component = registry.DataComponents.Contains(id) ? registry.DataComponents[id] : null;
            if (component != null && component.HasNbtForm) {
                return component;
            }
            reader.Cursor = cursor;
            throw ErrorUnknownComponent.CreateWithContext(reader, id);
        }

        /// <summary>The decode is the component's <c>NbtCodec</c>, so a malformed value's message is this side's rather than vanilla's codec's.</summary>
        private void ReadComponent(TagParser tagParser, MinecraftRegistry registryOps, IDataComponent componentType) {
            int cursor = reader.Cursor;
            INbtTag tag = tagParser.ParseAsArgument(reader);
            object value;
            try {
                value = componentType.FromNbt(tag, registryOps);
            }
            catch (Exception e) when (e is not CommandSyntaxException) {
                reader.Cursor = cursor;
                throw ErrorMalformedComponent.CreateWithContext(reader, componentType.Identifier.ToString(), e.Message);
            }
            visitor.VisitComponent(componentType, value);
        }

        private Task<Suggestions> SuggestStartComponents(SuggestionsBuilder builder) {
            if (builder.Remaining.Length == 0) {
                builder.Suggest(SyntaxStartComponents.ToString());
            }
            return builder.BuildFuture();
        }

        private Task<Suggestions> SuggestNextOrEndComponents(SuggestionsBuilder builder) {
            if (builder.Remaining.Length == 0) {
                builder.Suggest(SyntaxComponentSeparator.ToString());
                builder.Suggest(SyntaxEndComponents.ToString());
            }
            return builder.BuildFuture();
        }

        private Task<Suggestions> SuggestAssignment(SuggestionsBuilder builder) {
            if (builder.Remaining.Length == 0) {
                builder.Suggest(SyntaxComponentAssignment.ToString());
            }
            return builder.BuildFuture();
        }

        private Task<Suggestions> SuggestItem(SuggestionsBuilder builder) {
            IEnumerable<Identifier> items = parser._registries.Lookup(parser._registryOps.Items.RegistryId)?.ListElementIds() ?? [];
            return SharedSuggestionProvider.SuggestResource(items, builder);
        }

        private Task<Suggestions> SuggestComponentAssignmentOrRemoval(SuggestionsBuilder builder) {
            builder.Suggest(SyntaxRemovedComponent.ToString());
            return SuggestComponent(builder, SyntaxComponentAssignment.ToString());
        }

        private Task<Suggestions> SuggestComponent(SuggestionsBuilder builder) => SuggestComponent(builder, "");

        private Task<Suggestions> SuggestComponent(SuggestionsBuilder builder, string suffix) {
            string contents = JavaText.ToLowerRoot(builder.Remaining);
            SharedSuggestionProvider.FilterResources(parser._registryOps.DataComponents.All, contents, entry => entry.Identifier, type => {
                if (type.HasNbtForm) {
                    builder.Suggest(type.Identifier + suffix);
                }
            });
            return builder.BuildFuture();
        }
    }

    private sealed class SuggestionsVisitor : IVisitor {
        private Func<SuggestionsBuilder, Task<Suggestions>> _suggestions = SuggestNothing;

        public void VisitSuggestions(Func<SuggestionsBuilder, Task<Suggestions>> suggestions) => _suggestions = suggestions;

        public Task<Suggestions> ResolveSuggestions(SuggestionsBuilder builder, StringReader reader) => _suggestions(builder.CreateOffset(reader.Cursor));
    }

    private sealed class DelegateVisitor(Action<IItem> item, Action<IDataComponent, object> component, Action<IDataComponent> removed) : IVisitor {
        public void VisitItem(IItem value) => item(value);

        public void VisitComponent(IDataComponent type, object value) => component(type, value);

        public void VisitRemovedComponent(IDataComponent type) => removed(type);
    }

    /// <summary><c>ItemParser.Visitor</c>.</summary>
    public interface IVisitor {
        void VisitItem(IItem item) {
        }

        void VisitComponent(IDataComponent type, object value) {
        }

        void VisitRemovedComponent(IDataComponent type) {
        }

        void VisitSuggestions(Func<SuggestionsBuilder, Task<Suggestions>> suggestions) {
        }
    }
}
