using ManagedServer.Commands.Arguments;
using ManagedServer.Entities.Types;

namespace ManagedServer.Commands;

public class CommandSyntax {
    public required Action<PlayerEntity, CommandContext> Executor { get; init; }
    public required IArgument[] Arguments { get; init; }
    public required Func<PlayerEntity, bool> Condition { get; init; }
}
