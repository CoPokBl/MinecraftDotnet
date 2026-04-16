using ManagedServer.Entities.Types;

namespace ManagedServer.Commands;

public class Command {
    public required string CommandName { get; init; }
    public required CommandSyntax[] Syntax { get; init; }
    public required Command[] Subcommands { get; init; }
    public required Action<Player, CommandContext> Executor { get; init; }
    public required Func<Player, bool> Condition { get; init; }
}

public class CommandBuilder(string command) {
    private Action<Player, CommandContext> _executor = (_, _) => { };
    private List<CommandSyntax> _syntax = [];
    private List<Command> _subcommands = [];
    private Func<Player, bool> _condition = _ => true;

    public Command Build() {
        return new Command {
            Executor = _executor,
            CommandName = command,
            Syntax = _syntax.ToArray(),
            Subcommands = _subcommands.ToArray(),
            Condition = _condition
        };
    }
    
    public CommandBuilder WithExecutor(Action<Player, CommandContext> executor) {
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

    public CommandBuilder WithDefaultSyntax(Action<Player, CommandContext> executor, Func<Player, bool> condition) {
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
    
    public CommandBuilder WithCondition(Func<Player, bool> condition) {
        _condition = condition;
        return this;
    }
}
