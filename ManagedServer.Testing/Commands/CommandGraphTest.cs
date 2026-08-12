using ManagedServer.Commands;
using ManagedServer.Features.Basic;
using Minecraft;
using Minecraft.Commands;
using Minecraft.Commands.NodeTypes;

namespace ManagedServer.Testing.Commands;

public class CommandGraphTest {

    [Test]
    public void TestAliasesBecomeRedirectNodes() {
        Command cmd = new CommandBuilder("teleport")
            .WithAliases("tp", "tpa")
            .WithDefaultSyntax((_, _) => { }, _ => true)
            .WithSubcommand(new CommandBuilder("here")
                .WithAlias("hither")
                .WithDefaultSyntax((_, _) => { }, _ => true)
                .Build())
            .Build();

        List<ICommandNode> graph = [];
        int[] indexes = CommandsFeature.BuildCommand(cmd, null!, graph);

        // the command itself plus one node per alias
        Assert.That(indexes, Has.Length.EqualTo(3));

        LiteralNode root = (LiteralNode)graph[indexes[0]];
        Assert.That(root.Name, Is.EqualTo("teleport"));
        Assert.That(root.Flags.HasFlag(CommandNodeFlag.HasRedirect), Is.False);
        Assert.That(root.ChildrenIndexes, Has.Length.EqualTo(2));  // here and hither

        foreach ((int index, string name) in new[] { (indexes[1], "tp"), (indexes[2], "tpa") }) {
            LiteralNode alias = (LiteralNode)graph[index];
            Assert.That(alias.Name, Is.EqualTo(name));
            Assert.That(alias.Flags.HasFlag(CommandNodeFlag.HasRedirect));
            Assert.That(alias.Flags.HasFlag(CommandNodeFlag.IsExecutable));
            Assert.That(alias.RedirectNode, Is.EqualTo(indexes[0]));
            Assert.That(alias.ChildrenIndexes, Is.Empty);
        }

        // subcommand aliases redirect too, and hang off the parent
        LiteralNode subAlias = (LiteralNode)graph[root.ChildrenIndexes[1]];
        Assert.That(subAlias.Name, Is.EqualTo("hither"));
        Assert.That(subAlias.RedirectNode, Is.EqualTo(root.ChildrenIndexes[0]));
    }

    [Test]
    public void TestRedirectNodeRoundTrips() {
        LiteralNode node = new(CommandNodeFlag.LiteralType | CommandNodeFlag.IsExecutable | CommandNodeFlag.HasRedirect,
            [], 7, "tp", null);

        DataWriter writer = new();
        node.WriteData(writer, null!);
        LiteralNode read = (LiteralNode)ICommandNode.ReadData(new DataReader(writer.ToArray()), null!);

        Assert.That(read.Name, Is.EqualTo("tp"));
        Assert.That(read.Flags, Is.EqualTo(node.Flags));
        Assert.That(read.RedirectNode, Is.EqualTo(7));
        Assert.That(read.ChildrenIndexes, Is.Empty);
        Assert.That(read.SuggestionsType, Is.Null);
    }
}
