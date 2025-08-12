using System.Text;
using ManagedServer.Commands;
using ManagedServer.Commands.Arguments;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Viewables;
using Minecraft.Commands;
using Minecraft.Commands.NodeTypes;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Text;

namespace ManagedServer.Features.Basic;

public class CommandsFeature : ScopedFeature {
    
    public override void Register() {
        AddEventHandler<PlayerLoginEvent>(e => {
            e.Player.SendPacket(GenerateCommandsPacket(e.Player));
        });
        
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            string rawCmd;
            switch (e.Packet) {
                case ServerBoundChatCommandPacket chatCmdPacket:
                    rawCmd = chatCmdPacket.Command;
                    break;
                
                case ServerBoundSignedChatCommandPacket signedChatCmdPacket:
                    rawCmd = signedChatCmdPacket.Command;
                    break;
                
                default:
                    return;
            }
            
            HandlePlayerCommand(e.Player, rawCmd);
        });
    }

    private void HandlePlayerCommand(PlayerEntity player, string rawCmd) {
        string[] cmdAndArgs = rawCmd.Split(' ', 2);
        string cmd = cmdAndArgs[0];
        
        Command? command = Scope.Server.Commands.FirstOrDefault(c => c.CommandName.Equals(cmd, StringComparison.OrdinalIgnoreCase));
        if (command == null || !command.Condition(player)) {
            player.SendMessage(TextComponent.FromLegacyString("&cUnknown command: " + cmd));
            return;
        }

        string argsString = cmdAndArgs.Length > 1 ? cmdAndArgs[1].Trim() : string.Empty;
        if (argsString.Length == 0) {
            CommandSyntax? defaultSyntax = command.Syntax.FirstOrDefault(s => s.Arguments.Length == 0);
            if (defaultSyntax == null) {
                return;  // Invalid
            }
            
            // Execute the default syntax, so build a context
            CommandContext ctx = new(rawCmd, command.CommandName, []);
            defaultSyntax.Executor(player, ctx);
            command.Executor(player, ctx);
            return;
        }
        
        // Okay we have the arguments string.
        HandlePlayerCommand(player, command, argsString, rawCmd);
    }

    private bool HandlePlayerCommand(PlayerEntity player, Command command, string argsStr, string rawCmd) {
        string[] split = argsStr.Split(' ', 2);
        string? subCmdStr = split.Length > 0 ? split[0] : null;
        foreach (Command subCmd in command.Subcommands) {
            if (!subCmd.CommandName.Equals(subCmdStr, StringComparison.InvariantCultureIgnoreCase)) continue;
            
            string remainingArgs = split.Length > 1 ? split[1] : string.Empty;
            return HandlePlayerCommand(player, subCmd, remainingArgs, rawCmd);
        }

        bool handled = false;
        foreach (CommandSyntax syntax in command.Syntax) {
            Dictionary<string, object> parsedArgs = [];
            bool valid = true;
            foreach (IArgument arg in syntax.Arguments) {
                object val;
                try {
                    val = arg.Parser.GenericParse(ref argsStr, Scope.Server.Registry);
                }
                catch (Exception) {
                    valid = false;
                    break;  // Invalid
                }
                
                // okay that arg was valid
                parsedArgs[arg.Name] = val;
            }

            // All the arguments must be valid and there must be no remaining args
            if (!valid || argsStr.Length > 0) {
                continue;
            }
            
            // We have a valid syntax, so execute it
            CommandContext ctx = new(rawCmd, command.CommandName, parsedArgs);
            syntax.Executor(player, ctx);
            command.Executor(player, ctx);
            handled = true;
            break;
        }

        return handled;
    }
    
    public ClientBoundCommandsPacket GenerateCommandsPacket(PlayerEntity player) {
        List<ICommandNode> graph = [
            new RootNode(CommandNodeFlag.RootType, [], null, null)
        ];
        
        // base commands
        // List<LiteralNode> commandLiterals = [];
        List<int> rootCmdIndexes = [];
        foreach (Command command in Scope.Server.Commands) {
            if (!command.Condition(player)) {
                continue;
            }
            
            rootCmdIndexes.Add(BuildCommand(command, player, graph));
        }
        
        // Set the root node's children indexes
        graph[0] = (RootNode)graph[0] with {
            ChildrenIndexes = rootCmdIndexes.ToArray()
        };

        return new ClientBoundCommandsPacket {
            Nodes = graph.ToArray(),
            RootIndex = 0
        };
    }

    // returns the index of the comamnd's root node in the graph
    private int BuildCommand(Command command, PlayerEntity player, List<ICommandNode> graph) {
        // Add the root literal node for the command
        List<int> childrenIndexes = [];
        
        foreach (Command subCmd in command.Subcommands) {
            int subCmdIndex = BuildCommand(subCmd, player, graph);
            childrenIndexes.Add(subCmdIndex);
        }
        
        List<(CommandSyntax syntax, ArgumentNode[] argNodes)> syntaxNodes = [];
        foreach (CommandSyntax syntax in command.Syntax) {
            if (syntax.Arguments.Length == 0) {
                // This syntax has already been added (because it was the root node)
                continue;
            }
            
            syntaxNodes.Add(BuildSyntax(syntax, player));
        }
        
        // Build the children, add them to the graph and make them children
        int rootNodeIndex = graph.Count;
        graph.Add(null!);  // Add a placeholder for the root node

        foreach ((CommandSyntax syntax, ArgumentNode[] argNodes) syntaxNode in syntaxNodes) {
            int lastTreeIndex = graph.Count;
            childrenIndexes.Add(lastTreeIndex);
            graph.Add(syntaxNode.argNodes[0]);
            
            // Add the rest of that argument tree, but they're not children of the root node
            for (int i = 1; i < syntaxNode.argNodes.Length; i++) {
                graph[lastTreeIndex] = (ArgumentNode)graph[lastTreeIndex] with {
                    ChildrenIndexes = graph[lastTreeIndex].ChildrenIndexes.Append(graph.Count).ToArray()
                };
                lastTreeIndex = graph.Count;
                graph.Add(syntaxNode.argNodes[i]);
            }
        }

        // Now set that slot we reserved for the root node
        // and make sure all the children indexes are set
        CommandNodeFlag flags = CommandNodeFlag.LiteralType;
        if (command.Syntax.Any(s => s.Arguments.Length == 0)) {
            flags |= CommandNodeFlag.IsExecutable;
        }
        graph[rootNodeIndex] = new LiteralNode(flags, childrenIndexes.ToArray(), null, command.CommandName, null);

        return rootNodeIndex;
    }

    private (CommandSyntax syntax, ArgumentNode[] argNodes) BuildSyntax(CommandSyntax syntax, PlayerEntity player) {
        List<ArgumentNode> argNodes = [];
        for (int i = 0; i < syntax.Arguments.Length; i++) {
            IArgument arg = syntax.Arguments[i];
            ArgumentNodeBuilder builder = new(arg.Name, arg.Parser);
            if (i == syntax.Arguments.Length - 1) {
                // This is the last argument, so it can be executable
                builder.WithExecutable();
            }
            argNodes.Add(builder.Build());
        }

        return (syntax, argNodes.ToArray());
    }
}
