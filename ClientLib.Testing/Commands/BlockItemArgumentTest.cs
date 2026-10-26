using ClientLib.Brigadier;
using ClientLib.Commands;
using ClientLib.Commands.Arguments;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using NBT.Tags;
using StringReader = ClientLib.Brigadier.StringReader;

namespace ClientLib.Testing.Commands;

public class BlockItemArgumentTest {
    private static CommandBuildContext Context() {
        Dictionary<Identifier, Dictionary<Identifier, int[]>> tags = new() {
            ["minecraft:block"] = new Dictionary<Identifier, int[]> {
                ["minecraft:logs"] = [
                    VanillaRegistry.Data.Blocks.GetProtocolId((Identifier)"minecraft:oak_log"),
                    VanillaRegistry.Data.Blocks.GetProtocolId((Identifier)"minecraft:birch_log")
                ]
            }
        };
        return new CommandBuildContext(VanillaRegistry.Data, tags, ["minecraft:vanilla"]);
    }

    private static List<string> Suggest(IArgumentType type, string input) {
        CommandContext<object?> context = new CommandContextBuilder<object?>(new CommandDispatcher<object?>(), null, new RootCommandNode<object?>(), 0).Build(input);
        Task<Suggestions> task = type.ListSuggestions(context, new SuggestionsBuilder(input, 0));
        Assert.That(task.IsCompletedSuccessfully, Is.True);
        return task.Result.List.Select(s => s.Text).ToList();
    }

    [Test]
    public void BlockStateConsumesExactlyTheState() {
        StringReader reader = new("oak_stairs[facing=north] rest");
        BlockInput input = new BlockStateArgument(Context()).Parse(reader);
        Assert.Multiple(() => {
            Assert.That(reader.Cursor, Is.EqualTo("oak_stairs[facing=north]".Length));
            Assert.That(input.State.Identifier, Is.EqualTo((Identifier)"minecraft:oak_stairs"));
            Assert.That(((StringTag)input.State.ToStateNbt()["facing"]!).Value, Is.EqualTo("north"));
            Assert.That(input.DefinedProperties, Is.EquivalentTo(new[] { "facing" }));
        });
    }

    [Test]
    public void SetsANonDefaultValue() {
        BlockInput input = new BlockStateArgument(Context()).Parse(new StringReader("minecraft:oak_stairs[half=top,waterlogged=true]"));
        Assert.Multiple(() => {
            Assert.That(((StringTag)input.State.ToStateNbt()["half"]!).Value, Is.EqualTo("top"));
            Assert.That(((StringTag)input.State.ToStateNbt()["waterlogged"]!).Value, Is.EqualTo("true"));
        });
    }

    [Test]
    public void SuggestsPropertyNamesAndTheEnd() {
        List<string> suggestions = Suggest(new BlockStateArgument(Context()), "oak_stairs[");
        Assert.That(suggestions, Is.EquivalentTo(new[] { "facing=", "half=", "shape=", "waterlogged=", "]" }));
    }

    [Test]
    public void SuggestsPropertyValuesInDeclarationOrder() {
        List<string> suggestions = Suggest(new BlockStateArgument(Context()), "oak_stairs[facing=");
        Assert.That(suggestions, Is.EquivalentTo(new[] { "north", "south", "west", "east" }));
    }

    [Test]
    public void IntegerPropertiesSuggestAsNumbers() {
        CommandContext<object?> context = new CommandContextBuilder<object?>(new CommandDispatcher<object?>(), null, new RootCommandNode<object?>(), 0).Build("wheat[age=");
        Suggestions suggestions = new BlockStateArgument(Context()).ListSuggestions(context, new SuggestionsBuilder("wheat[age=", 0)).Result;
        Assert.Multiple(() => {
            Assert.That(suggestions.List.Select(s => s.Text), Is.EqualTo(new[] { "0", "1", "2", "3", "4", "5", "6", "7" }));
            Assert.That(suggestions.List, Is.All.InstanceOf<IntegerSuggestion>());
            Assert.That(suggestions.Range.Start, Is.EqualTo("wheat[age=".Length));
        });
    }

    [Test]
    public void UnknownPropertyPointsAtTheKey() {
        StringReader reader = new("oak_stairs[foo=bar]");
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new BlockStateArgument(Context()).Parse(reader))!;
        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(BlockStateParser.ErrorUnknownProperty));
            Assert.That(e.Cursor, Is.EqualTo("oak_stairs[".Length));
            Assert.That(reader.Cursor, Is.EqualTo(0));
        });
    }

    [Test]
    public void InvalidValuePointsAtTheValue() {
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new BlockStateArgument(Context()).Parse(new StringReader("oak_stairs[facing=up]")))!;
        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(BlockStateParser.ErrorInvalidValue));
            Assert.That(e.Cursor, Is.EqualTo("oak_stairs[facing=".Length));
        });
    }

    [Test]
    public void BlockStateRefusesTags() {
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new BlockStateArgument(Context()).Parse(new StringReader("#minecraft:logs")))!;
        Assert.That(e.Type, Is.SameAs(BlockStateParser.ErrorNoTagsAllowed));
    }

    [Test]
    public void BlockPredicateReadsATagWithVagueProperties() {
        StringReader reader = new("#minecraft:logs[axis=y] x");
        BlockPredicateArgument.IResult result = new BlockPredicateArgument(Context()).Parse(reader);
        Assert.Multiple(() => {
            Assert.That(reader.Cursor, Is.EqualTo("#minecraft:logs[axis=y]".Length));
            Assert.That(result, Is.InstanceOf<BlockPredicateArgument.TagPredicate>());
            Assert.That(((BlockPredicateArgument.TagPredicate)result).VagueProperties["axis"], Is.EqualTo("y"));
        });
    }

    [Test]
    public void BlockPredicateSuggestsTheTagsProperties() {
        List<string> suggestions = Suggest(new BlockPredicateArgument(Context()), "#minecraft:logs[axis=");
        Assert.That(suggestions, Is.SupersetOf(new[] { "x", "y", "z", "]" }));
    }

    [Test]
    public void ItemWithComponentList() {
        StringReader reader = new("diamond_sword[damage=5,!enchantments] 3");
        ItemInput input = new ItemArgument(Context()).Parse(reader);
        Assert.Multiple(() => {
            Assert.That(reader.Cursor, Is.EqualTo("diamond_sword[damage=5,!enchantments]".Length));
            Assert.That(input.Item.Identifier, Is.EqualTo((Identifier)"minecraft:diamond_sword"));
            Assert.That(input.Components[DataComponent.Damage], Is.EqualTo(5));
            Assert.That(input.RemovedComponents, Is.EqualTo(new[] { DataComponent.Enchantments }));
        });
    }

    [Test]
    public void ItemSuggestsRemovalAndComponentNames() {
        List<string> suggestions = Suggest(new ItemArgument(Context()), "stick[");
        Assert.That(suggestions, Is.SupersetOf(new[] { "!", "minecraft:damage=" }));
        Assert.That(suggestions, Does.Not.Contain("minecraft:creative_slot_lock="));
    }

    [Test]
    public void RepeatedComponentIsRefused() {
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new ItemArgument(Context()).Parse(new StringReader("stick[damage=1,damage=2]")))!;
        Assert.That(e.Input, Is.Null);
    }

    [Test]
    public void UnknownItemPointsAtTheId() {
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new ItemArgument(Context()).Parse(new StringReader("not_an_item")))!;
        Assert.That(e.Cursor, Is.EqualTo(0));
    }
}
