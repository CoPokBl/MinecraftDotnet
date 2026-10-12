using ClientLib.Brigadier;
using Minecraft.Data.Blocks;
using NBT.Tags;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>BlockPredicateArgument</c>, without the <c>test</c> against a block that only the server runs.</summary>
public sealed class BlockPredicateArgument(CommandBuildContext context) : ArgumentType<BlockPredicateArgument.IResult> {
    private static readonly string[] ExampleValues = ["stone", "minecraft:stone", "stone[foo=bar]", "#stone", "#stone[foo=bar]{baz=nbt}"];

    private readonly BlockLookup _blocks = new(context);

    public override IResult Parse(StringReader reader) => Parse(_blocks, reader);

    public static IResult Parse(BlockLookup blocks, StringReader reader) {
        return BlockStateParser.ParseForTesting(blocks, reader, true) switch {
            BlockStateParser.BlockResult block => new BlockPredicateResult(block.BlockState, block.Properties.Keys.ToList(), block.Nbt),
            BlockStateParser.TagResult tag => new TagPredicate(tag.Tag, tag.VagueProperties, tag.Nbt),
            var other => throw new InvalidOperationException($"Unexpected block parse result {other}")
        };
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return BlockStateParser.FillSuggestions(_blocks, builder, true, true);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    /// <summary><c>BlockPredicateArgument.BlockPredicate</c>.</summary>
    public sealed record BlockPredicateResult(IBlock State, IReadOnlyCollection<string> Properties, CompoundTag? Nbt) : IResult {
        public bool RequiresNbt => Nbt != null;
    }

    /// <summary><c>BlockPredicateArgument.TagPredicate</c>.</summary>
    public sealed record TagPredicate(IReadOnlyList<IBlock> Tag, IReadOnlyDictionary<string, string> VagueProperties, CompoundTag? Nbt) : IResult {
        public bool RequiresNbt => Nbt != null;
    }

    /// <summary><c>BlockPredicateArgument.Result</c>.</summary>
    public interface IResult {
        bool RequiresNbt { get; }
    }
}
