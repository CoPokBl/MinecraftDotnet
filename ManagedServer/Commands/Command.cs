using ManagedServer.Entities.Types;

namespace ManagedServer.Commands;

public class Command {
    public required string CommandName { get; init; }
    public required CommandSyntax[] Syntax { get; init; }
    public required Command[] Subcommands { get; init; }
    public required Action<PlayerEntity, CommandContext> Executor { get; init; }
    public required Func<PlayerEntity, bool> Condition { get; init; }
}

public class CommandBuilder(string command) {
    private Action<PlayerEntity, CommandContext> _executor = (_, _) => { };
    private List<CommandSyntax> _syntax = [];
    private List<Command> _subcommands = [];
    private Func<PlayerEntity, bool> _condition = _ => true;

    public Command Build() {
        return new Command {
            Executor = _executor,
            CommandName = command,
            Syntax = _syntax.ToArray(),
            Subcommands = _subcommands.ToArray(),
            Condition = _condition
        };
    }
    
    public CommandBuilder WithExecutor(Action<PlayerEntity, CommandContext> executor) {
        _executor = executor;
        return this;
    }
    
    public CommandBuilder WithSyntaxes(CommandSyntax[] syntax) {
        _syntax = new List<CommandSyntax>(syntax);
        return this;
    }
    
    public CommandBuilder WithSyntax(CommandSyntax syntax) {
        _syntax.Add(syntax);
        return this;
    }

    public CommandBuilder WithDefaultSyntax(Action<PlayerEntity, CommandContext> executor, Func<PlayerEntity, bool> condition) {
        _syntax.Add(new CommandSyntax(executor, condition));
        return this;
    }
    
    public CommandBuilder WithSubcommands(Command[] subcommands) {
        _subcommands = new List<Command>(subcommands);
        return this;
    }
    
    public CommandBuilder WithSubcommand(Command subcommand) {
        _subcommands.Add(subcommand);
        return this;
    }
    
    public CommandBuilder WithCondition(Func<PlayerEntity, bool> condition) {
        _condition = condition;
        return this;
    }
}
