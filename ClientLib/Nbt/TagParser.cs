using ClientLib.Brigadier;
using ClientLib.Commands;
using ClientLib.Parsing.Packrat;
using NBT;
using NBT.Tags;

namespace ClientLib.Nbt;

/// <summary>Vanilla's <c>TagParser</c>, always over <c>NbtOps</c>.</summary>
public sealed class TagParser {
    public static readonly SimpleCommandExceptionType ErrorTrailingData = new(Component.Translatable("argument.nbt.trailing"));
    public static readonly SimpleCommandExceptionType ErrorExpectedCompound = new(Component.Translatable("argument.nbt.expected.compound"));

    private static readonly TagParser NbtOpsParser = Create();

    private readonly Grammar<INbtTag> _grammar = SnbtGrammar.CreateParser();

    private TagParser() {
    }

    public static TagParser Create() => new();

    private static CompoundTag CastToCompoundOrThrow(StringReader reader, INbtTag result) =>
        result as CompoundTag ?? throw ErrorExpectedCompound.CreateWithContext(reader);

    public INbtTag ParseFully(string input) => ParseFully(new StringReader(input));

    public INbtTag ParseFully(StringReader reader) {
        INbtTag result = _grammar.ParseForCommands(reader);
        reader.SkipWhitespace();
        if (reader.CanRead()) {
            throw ErrorTrailingData.CreateWithContext(reader);
        }
        return result;
    }

    public INbtTag ParseAsArgument(StringReader reader) => _grammar.ParseForCommands(reader);

    public static CompoundTag ParseCompoundAsArgument(StringReader reader) => CastToCompoundOrThrow(reader, NbtOpsParser.ParseAsArgument(reader));
}
