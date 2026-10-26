using ClientLib.Brigadier;
using Minecraft.Data.Components;
using Minecraft.Data.Items;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>ItemInput</c> without <c>createItemStack</c>, whose overstack and malformed checks run on the server.</summary>
public sealed record ItemInput(IItem Item, IReadOnlyDictionary<IDataComponent, object> Components, IReadOnlyList<IDataComponent> RemovedComponents);

/// <summary>Vanilla's <c>ItemArgument</c>.</summary>
public sealed class ItemArgument(CommandBuildContext context) : ArgumentType<ItemInput> {
    private static readonly string[] ExampleValues = ["stick", "minecraft:stick", "stick{foo=bar}"];

    private readonly ItemParser _parser = new(context);

    public override ItemInput Parse(StringReader reader) => _parser.Parse(reader);

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return _parser.FillSuggestions(builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}
