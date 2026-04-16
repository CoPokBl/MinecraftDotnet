using ManagedServer.Commands.Arguments;
using ManagedServer.Entities.Types;

namespace ManagedServer.Commands;

public record CommandSyntax(Action<Player, CommandContext> Executor, Func<Player, bool>? Condition = null, params IArgument[] Arguments) {

    public CommandSyntax(Action<Player, CommandContext> Executor, params IArgument[] Arguments) 
        : this(Executor, null, Arguments) { }
    
    public Func<Player, bool> Condition { get; init; } = Condition ?? (_ => true);
}
