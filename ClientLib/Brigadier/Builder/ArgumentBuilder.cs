namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>ArgumentBuilder</c>.</summary>
public abstract class ArgumentBuilder<TSource> {
    private readonly RootCommandNode<TSource> _arguments = new();

    public Command<TSource>? Command { get; private set; }
    public Func<TSource, bool> Requirement { get; private set; } = _ => true;
    public CommandNode<TSource>? Target { get; private set; }

    public IEnumerable<CommandNode<TSource>> Arguments => _arguments.Children;

    public ArgumentBuilder<TSource> Then(CommandNode<TSource> argument) {
        if (Target != null) {
            throw new InvalidOperationException("Cannot add children to a redirected node");
        }
        _arguments.AddChild(argument);
        return this;
    }

    public ArgumentBuilder<TSource> Executes(Command<TSource> command) {
        Command = command;
        return this;
    }

    public ArgumentBuilder<TSource> Requires(Func<TSource, bool> requirement) {
        Requirement = requirement;
        return this;
    }

    /// <summary><c>redirect</c>, which brigadier routes through <c>forward</c>.</summary>
    public ArgumentBuilder<TSource> Redirect(CommandNode<TSource> target) {
        if (_arguments.Children.Count > 0) {
            throw new InvalidOperationException("Cannot forward a node with children");
        }
        Target = target;
        return this;
    }

    public abstract CommandNode<TSource> Build();

    protected CommandNode<TSource> AddArguments(CommandNode<TSource> result) {
        foreach (CommandNode<TSource> argument in Arguments) {
            result.AddChild(argument);
        }
        return result;
    }
}

/// <summary>Brigadier's <c>LiteralArgumentBuilder</c>.</summary>
public sealed class LiteralArgumentBuilder<TSource>(string literal) : ArgumentBuilder<TSource> {
    public string Literal { get; } = literal;

    public static LiteralArgumentBuilder<TSource> LiteralOf(string name) => new(name);

    public override CommandNode<TSource> Build() => AddArguments(new LiteralCommandNode<TSource>(Literal, Command, Requirement, Target));
}

/// <summary>Brigadier's <c>RequiredArgumentBuilder</c>.</summary>
public sealed class RequiredArgumentBuilder<TSource>(string name, IArgumentType type) : ArgumentBuilder<TSource> {
    public string Name { get; } = name;
    public IArgumentType Type { get; } = type;
    public SuggestionProvider<TSource>? SuggestionsProvider { get; private set; }

    public static RequiredArgumentBuilder<TSource> Argument(string name, IArgumentType type) => new(name, type);

    public RequiredArgumentBuilder<TSource> Suggests(SuggestionProvider<TSource>? provider) {
        SuggestionsProvider = provider;
        return this;
    }

    public override CommandNode<TSource> Build() =>
        AddArguments(new ArgumentCommandNode<TSource>(Name, Type, Command, Requirement, Target, SuggestionsProvider));
}
