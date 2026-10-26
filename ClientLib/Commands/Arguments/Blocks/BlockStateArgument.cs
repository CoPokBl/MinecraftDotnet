using ClientLib.Brigadier;
using Minecraft.Data.Blocks;
using NBT.Tags;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>BlockInput</c>, without its <c>test</c> and <c>place</c>. The defined properties are by name.</summary>
public sealed record BlockInput(IBlock State, IReadOnlyCollection<string> DefinedProperties, CompoundTag? Tag);

/// <summary>Vanilla's <c>BlockStateArgument</c>.</summary>
public sealed class BlockStateArgument(CommandBuildContext context) : ArgumentType<BlockInput> {
    private static readonly string[] ExampleValues = ["stone", "minecraft:stone", "stone[foo=bar]", "foo{bar=baz}"];

    private readonly BlockLookup _blocks = new(context);

    public override BlockInput Parse(StringReader reader) {
        BlockStateParser.BlockResult result = BlockStateParser.ParseForBlock(_blocks, reader, true);
        return new BlockInput(result.BlockState, result.Properties.Keys.ToList(), result.Nbt);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return BlockStateParser.FillSuggestions(_blocks, builder, false, true);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}
