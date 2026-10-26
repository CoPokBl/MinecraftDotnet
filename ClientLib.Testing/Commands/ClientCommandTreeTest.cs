using ClientLib.Brigadier;
using ClientLib.Commands;
using Minecraft.Commands;
using Minecraft.Commands.NodeTypes;
using Minecraft.Data.ArgumentParsers;
using Minecraft.Data.ArgumentParsers.Types;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace ClientLib.Testing.Commands;

public class ClientCommandTreeTest {
    private static readonly Identifier SummonableEntities = "minecraft:summonable_entities";

    private static CommandBuildContext Context() => new(VanillaRegistry.Data, new Dictionary<Identifier, Dictionary<Identifier, int[]>>(), []);

    private static ClientBoundCommandsPacket Packet() {
        const CommandNodeFlag argument = CommandNodeFlag.ArgumentType;
        return new ClientBoundCommandsPacket {
            RootIndex = 0,
            Nodes = [
                new RootNode(CommandNodeFlag.RootType, [1, 2, 6], null, null),
                new LiteralNode(CommandNodeFlag.LiteralType, [3], null, "give", null),
                new LiteralNode(CommandNodeFlag.LiteralType, [5], null, "summon", null),
                new ArgumentNode(argument, [4], null, "targets", new EntityArgumentType(false, true), null),
                new ArgumentNode(argument | CommandNodeFlag.IsExecutable, [], null, "item", new ItemStackArgumentType(), null),
                new ArgumentNode(argument | CommandNodeFlag.IsExecutable | CommandNodeFlag.HasSuggestionsType, [], null, "entity",
                    new ResourceArgumentType("minecraft:entity_type"), SummonableEntities),
                new LiteralNode(CommandNodeFlag.LiteralType | CommandNodeFlag.HasRedirect, [], 0, "execute", null)
            ]
        };
    }

    [Test]
    public void EveryArgumentTypeInstantiates() {
        CommandBuildContext context = Context();
        foreach (IArgumentParser parser in VanillaRegistry.Data.CommandArgumentTypes.All) {
            IArgumentParser template = parser is RegistryTokenArgumentType registryBound
                ? registryBound with { Registry = "minecraft:item" }
                : parser;
            Assert.DoesNotThrow(() => ArgumentTypeInfos.Instantiate(template, context), template.Identifier.ToString());
        }
    }

    [Test]
    public void TreeFromThePacketParsesAndRedirects() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        CommandDispatcher<ClientSuggestionProvider> dispatcher = new(ClientCommandTree.GetRoot(Packet(), Context()));

        ParseResults<ClientSuggestionProvider> parse = dispatcher.Parse("execute give Steve minecraft:diamond", client.SuggestionsProvider);
        Assert.Multiple(() => {
            Assert.That(parse.Reader.CanRead(), Is.False);
            Assert.That(parse.Exceptions, Is.Empty);
            Assert.That(parse.Context.LastChild.Command, Is.Not.Null);
            Assert.That(parse.Context.LastChild.Arguments.Keys, Is.EqualTo(new[] { "targets", "item" }));
        });
    }

    [Test]
    public void ServerSuggestionsMatchTheNewestRequest() {
        MinecraftClient client = new(new ClientOptions { Username = "Test" });
        CommandDispatcher<ClientSuggestionProvider> dispatcher = new(ClientCommandTree.GetRoot(Packet(), Context()));

        Task<Suggestions> first = dispatcher.GetCompletionSuggestions(dispatcher.Parse("summon p", client.SuggestionsProvider));
        Task<Suggestions> second = dispatcher.GetCompletionSuggestions(dispatcher.Parse("summon pi", client.SuggestionsProvider));
        Assert.That(first.IsCompleted || second.IsCompleted, Is.False);

        StringRange range = StringRange.Between(7, 9);
        client.SuggestionsProvider.CompleteCustomSuggestions(0, new Suggestions(range, [new Suggestion(range, "minecraft:pig")]));
        Assert.That(second.IsCompleted, Is.False, "an answer to the superseded request is dropped");

        client.SuggestionsProvider.CompleteCustomSuggestions(1, new Suggestions(range, [new Suggestion(range, "minecraft:pig")]));
        Assert.Multiple(() => {
            Assert.That(second.IsCompletedSuccessfully, Is.True);
            Assert.That(second.Result.List.Single().Text, Is.EqualTo("minecraft:pig"));
            Assert.That(first.IsCompleted, Is.False, "the cancelled request's merge never completes, as brigadier's does not");
        });
    }

    [Test]
    public void AnImpossibleTreeIsRefused() {
        ClientBoundCommandsPacket packet = new() {
            RootIndex = 0,
            Nodes = [
                new RootNode(CommandNodeFlag.RootType, [1], null, null),
                new LiteralNode(CommandNodeFlag.LiteralType | CommandNodeFlag.HasRedirect, [], 2, "a", null),
                new LiteralNode(CommandNodeFlag.LiteralType | CommandNodeFlag.HasRedirect, [], 1, "b", null)
            ]
        };
        Assert.Throws<InvalidOperationException>(() => ClientCommandTree.GetRoot(packet, Context()));
    }
}
