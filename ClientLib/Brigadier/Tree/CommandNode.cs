namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>CommandNode</c>, compared by reference: two children of one parent never compare equal anyway.</summary>
public abstract class CommandNode<TSource> {
    private readonly OrderedDictionary<string, CommandNode<TSource>> _children = new();
    private readonly OrderedDictionary<string, LiteralCommandNode<TSource>> _literals = new();
    private readonly OrderedDictionary<string, ArgumentCommandNode<TSource>> _arguments = new();

    protected CommandNode(Command<TSource>? command, Func<TSource, bool> requirement, CommandNode<TSource>? redirect) {
        Command = command;
        Requirement = requirement;
        Redirect = redirect;
    }

    public Command<TSource>? Command { get; private set; }
    public Func<TSource, bool> Requirement { get; }
    public CommandNode<TSource>? Redirect { get; }

    public ICollection<CommandNode<TSource>> Children => _children.Values;

    public bool CanUse(TSource source) => Requirement(source);

    public void AddChild(CommandNode<TSource> node) {
        if (node is RootCommandNode<TSource>) {
            throw new NotSupportedException("Cannot add a RootCommandNode as a child to any other CommandNode");
        }
        if (_children.TryGetValue(node.Name, out CommandNode<TSource>? child)) {
            if (node.Command != null) {
                child.Command = node.Command;
            }
            foreach (CommandNode<TSource> grandchild in node.Children) {
                child.AddChild(grandchild);
            }
            return;
        }
        _children[node.Name] = node;
        switch (node) {
            case LiteralCommandNode<TSource> literal:
                _literals[node.Name] = literal;
                break;
            case ArgumentCommandNode<TSource> argument:
                _arguments[node.Name] = argument;
                break;
        }
    }

    public abstract string Name { get; }

    public abstract string UsageText { get; }

    public abstract void Parse(StringReader reader, CommandContextBuilder<TSource> contextBuilder);

    public abstract Task<Suggestions> ListSuggestions(CommandContext<TSource> context, SuggestionsBuilder builder);

    public IEnumerable<CommandNode<TSource>> GetRelevantNodes(StringReader input) {
        if (_literals.Count <= 0) {
            return _arguments.Values;
        }
        int cursor = input.Cursor;
        while (input.CanRead() && input.Peek() != ' ') {
            input.Skip();
        }
        string text = input.String[cursor..input.Cursor];
        input.Cursor = cursor;
        return _literals.TryGetValue(text, out LiteralCommandNode<TSource>? literal) ? [literal] : _arguments.Values;
    }
}

/// <summary>Brigadier's <c>RootCommandNode</c>.</summary>
public sealed class RootCommandNode<TSource>() : CommandNode<TSource>(null, _ => true, null) {
    public override string Name => "";
    public override string UsageText => "";

    public override void Parse(StringReader reader, CommandContextBuilder<TSource> contextBuilder) {
    }

    public override Task<Suggestions> ListSuggestions(CommandContext<TSource> context, SuggestionsBuilder builder) => Suggestions.Empty();

    public override string ToString() => "<root>";
}

/// <summary>Brigadier's <c>LiteralCommandNode</c>.</summary>
public sealed class LiteralCommandNode<TSource> : CommandNode<TSource> {
    private readonly string _literalLowerCase;

    public LiteralCommandNode(string literal, Command<TSource>? command, Func<TSource, bool> requirement, CommandNode<TSource>? redirect)
        : base(command, requirement, redirect) {
        Literal = literal;
        _literalLowerCase = JavaText.ToLowerRoot(literal);
    }

    public string Literal { get; }
    public override string Name => Literal;
    public override string UsageText => Literal;

    public override void Parse(StringReader reader, CommandContextBuilder<TSource> contextBuilder) {
        int start = reader.Cursor;
        int end = Parse(reader);
        if (end <= -1) {
            throw CommandSyntaxException.BuiltInExceptions.LiteralIncorrect.CreateWithContext(reader, Literal);
        }
        contextBuilder.WithNode(this, StringRange.Between(start, end));
    }

    private int Parse(StringReader reader) {
        int start = reader.Cursor;
        if (reader.CanRead(Literal.Length)) {
            int end = start + Literal.Length;
            if (reader.String[start..end] == Literal) {
                reader.Cursor = end;
                if (!reader.CanRead() || reader.Peek() == ' ') {
                    return end;
                }
                reader.Cursor = start;
            }
        }
        return -1;
    }

    public override Task<Suggestions> ListSuggestions(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return _literalLowerCase.StartsWith(builder.RemainingLowerCase, StringComparison.Ordinal) ? builder.Suggest(Literal).BuildFuture() : Suggestions.Empty();
    }

    public override string ToString() => "<literal " + Literal + ">";
}

/// <summary>Brigadier's <c>ArgumentCommandNode</c>, untyped by the argument's result, which nothing reads back typed.</summary>
public sealed class ArgumentCommandNode<TSource> : CommandNode<TSource> {
    public ArgumentCommandNode(string name, IArgumentType type, Command<TSource>? command, Func<TSource, bool> requirement,
        CommandNode<TSource>? redirect, SuggestionProvider<TSource>? customSuggestions) : base(command, requirement, redirect) {
        Name = name;
        Type = type;
        CustomSuggestions = customSuggestions;
    }

    public IArgumentType Type { get; }
    public override string Name { get; }
    public override string UsageText => "<" + Name + ">";
    public SuggestionProvider<TSource>? CustomSuggestions { get; }

    public override void Parse(StringReader reader, CommandContextBuilder<TSource> contextBuilder) {
        int start = reader.Cursor;
        object? result = Type.Parse(reader, contextBuilder.Source);
        ParsedArgument<TSource> parsed = new(start, reader.Cursor, result);
        contextBuilder.WithArgument(Name, parsed);
        contextBuilder.WithNode(this, parsed.Range);
    }

    public override Task<Suggestions> ListSuggestions(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return CustomSuggestions == null ? Type.ListSuggestions(context, builder) : CustomSuggestions(context, builder);
    }

    public override string ToString() => "<argument " + Name + ":" + Type + ">";
}
