using ClientLib.Brigadier;
using Minecraft.Commands;
using Minecraft.Commands.NodeTypes;
using Minecraft.Data.ArgumentParsers;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;

namespace ClientLib.Commands;

/// <summary>Vanilla's <c>SuggestionProviders</c>, as the client resolves a node's suggestions id.</summary>
public static class SuggestionProviders {
    private static readonly Identifier IdAvailableSounds = "minecraft:available_sounds";

    private static Task<Suggestions> AskServer<TSource>(CommandContext<TSource> c, SuggestionsBuilder p) =>
        ((ISharedSuggestionProvider)c.Source!).CustomSuggestion(c);

    private static Task<Suggestions> AvailableSounds<TSource>(CommandContext<TSource> c, SuggestionsBuilder p) =>
        SharedSuggestionProvider.SuggestResource(((ISharedSuggestionProvider)c.Source!).AvailableSounds, p);

    /// <summary>
    /// <c>getProvider</c>: an unknown id asks the server. Vanilla suggests <c>summonable_entities</c>
    /// locally by <c>canSummon</c>, which the entity type data lacks, so that asks the server too.
    /// </summary>
    public static SuggestionProvider<TSource> GetProvider<TSource>(Identifier name) => name == IdAvailableSounds ? AvailableSounds : AskServer;
}

/// <summary>
/// The client half of <c>ClientboundCommandsPacket</c>: <c>validateEntries</c>, <c>NodeResolver</c> and
/// <c>ClientPacketListener.COMMAND_NODE_BUILDER</c>.
/// </summary>
public static class ClientCommandTree {
    private const byte MaskType = 3;
    private const byte FlagExecutable = 4;
    private const byte FlagRedirect = 8;
    private const byte FlagRestricted = 32;
    private const byte TypeLiteral = 1;
    private const byte TypeArgument = 2;

    public static RootCommandNode<ClientSuggestionProvider> GetRoot(ClientBoundCommandsPacket packet, CommandBuildContext context) {
        ValidateEntries(packet.Nodes);
        return (RootCommandNode<ClientSuggestionProvider>)new NodeResolver(context, packet.Nodes).Resolve(packet.RootIndex);
    }

    private static void ValidateEntries(ICommandNode[] entries, Func<ICommandNode, HashSet<int>, bool> validator) {
        HashSet<int> elementsToCheck = [..Enumerable.Range(0, entries.Length)];
        while (elementsToCheck.Count > 0) {
            bool worked = elementsToCheck.RemoveWhere(index => validator(entries[index], elementsToCheck)) > 0;
            if (!worked) {
                throw new InvalidOperationException("Server sent an impossible command tree");
            }
        }
    }

    private static void ValidateEntries(ICommandNode[] entries) {
        ValidateEntries(entries, CanBuild);
        ValidateEntries(entries, CanResolve);
    }

    private static int FlagsOf(ICommandNode entry) => (byte)entry.Flags;

    private static bool CanBuild(ICommandNode entry, HashSet<int> unbuiltNodes) =>
        (FlagsOf(entry) & FlagRedirect) == 0 || !unbuiltNodes.Contains(entry.RedirectNode!.Value);

    private static bool CanResolve(ICommandNode entry, HashSet<int> unresolvedNodes) => !entry.ChildrenIndexes.Any(unresolvedNodes.Contains);

    /// <summary><c>ClientPacketListener.COMMAND_NODE_BUILDER.configure</c>.</summary>
    private static ArgumentBuilder<ClientSuggestionProvider> Configure(ArgumentBuilder<ClientSuggestionProvider> builder, bool executable, bool restricted) {
        if (executable) {
            builder.Executes(_ => 0);
        }
        if (restricted) {
            builder.Requires(source => source.Permissions.HasPermission(Permissions.RestrictedCommand));
        }
        return builder;
    }

    private sealed class NodeResolver(CommandBuildContext context, ICommandNode[] entries) {
        private readonly CommandNode<ClientSuggestionProvider>?[] _nodes = new CommandNode<ClientSuggestionProvider>?[entries.Length];

        public CommandNode<ClientSuggestionProvider> Resolve(int index) {
            CommandNode<ClientSuggestionProvider>? currentNode = _nodes[index];
            if (currentNode != null) {
                return currentNode;
            }
            ICommandNode entry = entries[index];
            int flags = FlagsOf(entry);
            CommandNode<ClientSuggestionProvider> result;
            ArgumentBuilder<ClientSuggestionProvider>? resultBuilder = (flags & MaskType) switch {
                TypeLiteral => LiteralArgumentBuilder<ClientSuggestionProvider>.LiteralOf(((LiteralNode)entry).Name),
                TypeArgument => CreateArgument((ArgumentNode)entry),
                _ => null
            };
            if (resultBuilder == null) {
                result = new RootCommandNode<ClientSuggestionProvider>();
            }
            else {
                if ((flags & FlagRedirect) != 0) {
                    resultBuilder.Redirect(Resolve(entry.RedirectNode!.Value));
                }
                bool isExecutable = (flags & FlagExecutable) != 0;
                bool isRestricted = (flags & FlagRestricted) != 0;
                result = Configure(resultBuilder, isExecutable, isRestricted).Build();
            }
            _nodes[index] = result;
            foreach (int childId in entry.ChildrenIndexes) {
                CommandNode<ClientSuggestionProvider> child = Resolve(childId);
                if (child is not RootCommandNode<ClientSuggestionProvider>) {
                    result.AddChild(child);
                }
            }
            return result;
        }

        /// <summary><c>ArgumentNodeStub.build</c> then <c>COMMAND_NODE_BUILDER.createArgument</c>.</summary>
        private ArgumentBuilder<ClientSuggestionProvider> CreateArgument(ArgumentNode node) {
            IArgumentType type = ArgumentTypeInfos.Instantiate(node.Parser, context);
            RequiredArgumentBuilder<ClientSuggestionProvider> builder = RequiredArgumentBuilder<ClientSuggestionProvider>.Argument(node.Name, type);
            if (node.SuggestionsType is { } suggestionId) {
                builder.Suggests(SuggestionProviders.GetProvider<ClientSuggestionProvider>(suggestionId));
            }
            return builder;
        }
    }
}

/// <summary>Vanilla's <c>Commands.getParseException</c>.</summary>
public static class CommandsUtil {
    public static CommandSyntaxException? GetParseException<TSource>(ParseResults<TSource> parse) {
        if (!parse.Reader.CanRead()) {
            return null;
        }
        if (parse.Exceptions.Count == 1) {
            return parse.Exceptions.Values.First();
        }
        return parse.Context.Range.IsEmpty
            ? CommandSyntaxException.BuiltInExceptions.DispatcherUnknownCommand.CreateWithContext(parse.Reader)
            : CommandSyntaxException.BuiltInExceptions.DispatcherUnknownArgument.CreateWithContext(parse.Reader);
    }
}

/// <summary>Vanilla's <c>ArgumentVisitor</c>.</summary>
public static class ArgumentVisitor {
    public delegate void Output<TSource>(CommandContextBuilder<TSource> context, ArgumentCommandNode<TSource> argument, ParsedArgument<TSource>? value);

    public static void VisitArguments<TSource>(ParseResults<TSource> command, Output<TSource> output, bool rejectRootRedirects) {
        CommandContextBuilder<TSource> rootContext = command.Context;
        CommandContextBuilder<TSource> context = rootContext;
        VisitNodeArguments(rootContext, output);
        CommandContextBuilder<TSource>? child;
        while ((child = context.Child) != null && (!rejectRootRedirects || child.RootNode != rootContext.RootNode)) {
            VisitNodeArguments(child, output);
            context = child;
        }
    }

    private static void VisitNodeArguments<TSource>(CommandContextBuilder<TSource> context, Output<TSource> output) {
        OrderedDictionary<string, ParsedArgument<TSource>> values = context.Arguments;
        foreach (ParsedCommandNode<TSource> node in context.Nodes) {
            if (node.Node is ArgumentCommandNode<TSource> argument) {
                output(context, argument, values.GetValueOrDefault(argument.Name));
            }
        }
    }
}
