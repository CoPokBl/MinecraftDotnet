using ManagedServer.Entities.Types;

namespace ManagedServer.Commands;

public class Command {
    public required string CommandName { get; init; }
    public required CommandSyntax[] Syntax { get; init; }
    public required Action<PlayerEntity, CommandContext> Executor { get; init; }
}

public class CommandBuilder(string command) {
    private Action<PlayerEntity, CommandContext> _executor = (_, _) => { };
    private List<CommandSyntax> _syntax = [];

    public Command Build() {
        return new Command {
            Executor = _executor,
            CommandName = command,
            Syntax = _syntax.ToArray()
        };
    }
    
    public CommandBuilder SetExecutor(Action<PlayerEntity, CommandContext> executor) {
        _executor = executor;
        return this;
    }
    
    public CommandBuilder SetSyntax(CommandSyntax[] syntax) {
        _syntax = new List<CommandSyntax>(syntax);
        return this;
    }
    
    public CommandBuilder AddSyntax(CommandSyntax syntax) {
        _syntax.Add(syntax);
        return this;
    }
}
