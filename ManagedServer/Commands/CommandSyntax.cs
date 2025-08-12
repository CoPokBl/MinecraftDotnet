using ManagedServer.Commands.Arguments;
using ManagedServer.Entities.Types;

namespace ManagedServer.Commands;

public record CommandSyntax(Action<PlayerEntity, CommandContext> Executor, Func<PlayerEntity, bool>? Condition = null, params IArgument[] Arguments) {

    public CommandSyntax(Action<PlayerEntity, CommandContext> Executor, params IArgument[] Arguments) 
        : this(Executor, null, Arguments) { }
    
    public Func<PlayerEntity, bool> Condition { get; init; } = Condition ?? (_ => true);
}
