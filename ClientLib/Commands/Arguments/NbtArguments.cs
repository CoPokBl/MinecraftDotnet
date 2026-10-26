using ClientLib.Brigadier;
using ClientLib.Nbt;
using ClientLib.Parsing.Packrat;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>NbtTagArgument</c>.</summary>
public sealed class NbtTagArgument() : ParserBasedArgument<INbtTag>(TagParserInstance) {
    private static readonly string[] ExampleValues = ["0", "0b", "0l", "0.0", "\"foo\"", "{foo=bar}", "[0]"];
    private static readonly ICommandArgumentParser<INbtTag> TagParserInstance = SnbtGrammar.CreateParser();

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>CompoundTagArgument</c>.</summary>
public sealed class CompoundTagArgument : ArgumentType<CompoundTag> {
    private static readonly string[] ExampleValues = ["{}", "{foo=bar}"];

    public override CompoundTag Parse(StringReader reader) => TagParser.ParseCompoundAsArgument(reader);

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>
/// Vanilla's <c>ComponentArgument</c>. The decode through <c>ComponentSerialization.CODEC</c> that raises
/// <c>argument.component.invalid</c> has no port, so a well formed tag that is not a component passes.
/// </summary>
public sealed class ComponentArgument(CommandBuildContext context) : ParserBasedArgument<INbtTag>(TagParserInstance) {
    private static readonly string[] ExampleValues = ["\"hello world\"", "'hello world'", "\"\"", "{text:\"hello world\"}", "[\"\"]"];

    private static readonly ICommandArgumentParser<INbtTag> TagParserInstance = SnbtGrammar.CreateParser();

    public CommandBuildContext Context { get; } = context;

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>
/// Vanilla's <c>StyleArgument</c>. As with <see cref="ComponentArgument"/>, the decode through
/// <c>Style.Serializer.CODEC</c> that raises <c>argument.style.invalid</c> is left to the server.
/// </summary>
public sealed class StyleArgument(CommandBuildContext context) : ParserBasedArgument<INbtTag>(TagParserInstance) {
    private static readonly string[] ExampleValues = ["{bold: true}", "{color: 'red'}", "{}"];

    private static readonly ICommandArgumentParser<INbtTag> TagParserInstance = SnbtGrammar.CreateParser();

    public CommandBuildContext Context { get; } = context;

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

public sealed record ParticleInput(Identifier Type, INbtTag Options);

/// <summary>Vanilla's <c>ParticleArgument</c>.</summary>
public sealed class ParticleArgument(CommandBuildContext registries) : ArgumentType<ParticleInput> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "particle{foo:bar}"];

    public static readonly DynamicCommandExceptionType ErrorUnknownParticle = new(value => Component.TranslatableEscape("particle.notFound", value));

    private static readonly TagParser ValueParser = TagParser.Create();

    public override ParticleInput Parse(StringReader reader) => ReadParticle(reader, registries);

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    /// <summary>
    /// <c>ParticleArgument.readParticle</c>. Vanilla then decodes the options with the type's codec,
    /// raising <c>particle.invalidOptions</c>; the client has no particle option codecs.
    /// </summary>
    public static ParticleInput ReadParticle(StringReader reader, CommandBuildContext lookup) {
        Identifier type = ReadParticleType(reader, lookup.Lookup(lookup.Registry.Particles.RegistryId));
        INbtTag extraData = reader.CanRead() && reader.Peek() == '{' ? ValueParser.ParseAsArgument(reader) : new CompoundTag();
        return new ParticleInput(type, extraData);
    }

    private static Identifier ReadParticleType(StringReader reader, IRegistryLookup? particles) {
        Identifier id = Identifiers.Read(reader);
        if (particles is ClientRegistryLookup lookup && !lookup.Contains(id)) {
            throw ErrorUnknownParticle.CreateWithContext(reader, id);
        }
        return id;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        IRegistryLookup? particles = registries.Lookup(registries.Registry.Particles.RegistryId);
        return SharedSuggestionProvider.SuggestResource(particles?.ListElementIds() ?? [], builder);
    }
}

/// <summary>Vanilla's <c>NbtPathArgument</c>, for its parse; the client never walks a path.</summary>
public sealed class NbtPathArgument : ArgumentType<NbtPathArgument.NbtPath> {
    private static readonly string[] ExampleValues = ["foo", "foo.bar", "foo[0]", "[0]", "[]", "{foo=bar}"];

    public static readonly SimpleCommandExceptionType ErrorInvalidNode = new(Component.Translatable("arguments.nbtpath.node.invalid"));

    private const char IndexMatchStart = '[';
    private const char IndexMatchEnd = ']';
    private const char KeyMatchStart = '{';
    private const char KeyMatchEnd = '}';
    private const char QuotedKeyStart = '"';
    private const char SingleQuotedKeyStart = '\'';

    public override NbtPath Parse(StringReader reader) {
        List<INode> nodes = [];
        int start = reader.Cursor;
        bool firstNode = true;
        while (reader.CanRead() && reader.Peek() != ' ') {
            nodes.Add(ParseNode(reader, firstNode));
            firstNode = false;
            if (reader.CanRead()) {
                char next = reader.Peek();
                if (next != ' ' && next != IndexMatchStart && next != KeyMatchStart) {
                    reader.Expect('.');
                }
            }
        }
        return new NbtPath(reader.String[start..reader.Cursor], nodes.ToArray());
    }

    private static INode ParseNode(StringReader reader, bool firstNode) {
        switch (reader.Peek()) {
            case QuotedKeyStart or SingleQuotedKeyStart:
                return ReadObjectNode(reader, reader.ReadString());
            case IndexMatchStart: {
                reader.Skip();
                int next = reader.Peek();
                if (next == KeyMatchStart) {
                    CompoundTag pattern = TagParser.ParseCompoundAsArgument(reader);
                    reader.Expect(IndexMatchEnd);
                    return new MatchElementNode(pattern);
                }
                if (next == IndexMatchEnd) {
                    reader.Skip();
                    return AllElementsNode.Instance;
                }
                int index = reader.ReadInt();
                reader.Expect(IndexMatchEnd);
                return new IndexedElementNode(index);
            }
            case KeyMatchStart: {
                if (!firstNode) {
                    throw ErrorInvalidNode.CreateWithContext(reader);
                }
                CompoundTag pattern = TagParser.ParseCompoundAsArgument(reader);
                return new MatchRootObjectNode(pattern);
            }
            default:
                return ReadObjectNode(reader, ReadUnquotedName(reader));
        }
    }

    private static INode ReadObjectNode(StringReader reader, string name) {
        if (name.Length == 0) {
            throw ErrorInvalidNode.CreateWithContext(reader);
        }
        if (reader.CanRead() && reader.Peek() == KeyMatchStart) {
            CompoundTag pattern = TagParser.ParseCompoundAsArgument(reader);
            return new MatchObjectNode(name, pattern);
        }
        return new CompoundChildNode(name);
    }

    private static string ReadUnquotedName(StringReader reader) {
        string name = ParserUtils.ReadWhile(reader, IsAllowedInUnquotedName);
        return name.Length > 0 ? name : throw ErrorInvalidNode.CreateWithContext(reader);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    private static bool IsAllowedInUnquotedName(char c) => c is not (' ' or '"' or '\'' or '[' or ']' or '.' or '{' or '}');

    /// <summary><c>NbtPathArgument.Node</c>.</summary>
    public interface INode;

    public sealed class AllElementsNode : INode {
        public static readonly AllElementsNode Instance = new();

        private AllElementsNode() {
        }
    }

    public sealed record CompoundChildNode(string Name) : INode;

    public sealed record IndexedElementNode(int Index) : INode;

    public sealed record MatchElementNode(CompoundTag Pattern) : INode;

    public sealed record MatchObjectNode(string Name, CompoundTag Pattern) : INode;

    public sealed record MatchRootObjectNode(CompoundTag Pattern) : INode;

    /// <summary><c>NbtPathArgument.NbtPath</c>.</summary>
    public sealed class NbtPath(string original, INode[] nodes) {
        public string Original { get; } = original;
        public IReadOnlyList<INode> Nodes { get; } = nodes;

        public override string ToString() => Original;
    }
}
