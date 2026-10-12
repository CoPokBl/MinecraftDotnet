namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>CommandContext</c>, reduced to what suggestion providers read: the client never executes.</summary>
public sealed class CommandContext<TSource>(TSource source, string input) {
    public TSource Source { get; } = source;
    public string Input { get; } = input;
}

/// <summary>Brigadier's <c>CommandContextBuilder</c>.</summary>
public sealed class CommandContextBuilder<TSource> {
    private readonly OrderedDictionary<string, ParsedArgument<TSource>> _arguments = new();
    private readonly List<ParsedCommandNode<TSource>> _nodes = [];
    private Command<TSource>? _command;
    private CommandContextBuilder<TSource>? _child;

    public CommandContextBuilder(CommandDispatcher<TSource> dispatcher, TSource source, CommandNode<TSource> rootNode, int start) {
        RootNode = rootNode;
        Dispatcher = dispatcher;
        Source = source;
        Range = StringRange.At(start);
    }

    public TSource Source { get; }
    public CommandNode<TSource> RootNode { get; }
    public CommandDispatcher<TSource> Dispatcher { get; }
    public StringRange Range { get; private set; }

    /// <summary>In the order they were parsed, which is what the argument highlighting cycles its colours by.</summary>
    public OrderedDictionary<string, ParsedArgument<TSource>> Arguments => _arguments;

    public Command<TSource>? Command => _command;
    public List<ParsedCommandNode<TSource>> Nodes => _nodes;
    public CommandContextBuilder<TSource>? Child => _child;

    public CommandContextBuilder<TSource> WithArgument(string name, ParsedArgument<TSource> argument) {
        _arguments[name] = argument;
        return this;
    }

    public CommandContextBuilder<TSource> WithCommand(Command<TSource>? command) {
        _command = command;
        return this;
    }

    public CommandContextBuilder<TSource> WithNode(CommandNode<TSource> node, StringRange range) {
        _nodes.Add(new ParsedCommandNode<TSource>(node, range));
        Range = StringRange.Encompassing(Range, range);
        return this;
    }

    public CommandContextBuilder<TSource> Copy() {
        CommandContextBuilder<TSource> copy = new(Dispatcher, Source, RootNode, Range.Start);
        copy._command = _command;
        foreach ((string key, ParsedArgument<TSource> value) in _arguments) {
            copy._arguments[key] = value;
        }
        copy._nodes.AddRange(_nodes);
        copy._child = _child;
        copy.Range = Range;
        return copy;
    }

    public CommandContextBuilder<TSource> WithChild(CommandContextBuilder<TSource> child) {
        _child = child;
        return this;
    }

    public CommandContextBuilder<TSource> LastChild {
        get {
            CommandContextBuilder<TSource> result = this;
            while (result.Child != null) {
                result = result.Child;
            }
            return result;
        }
    }

    public CommandContext<TSource> Build(string input) => new(Source, input);

    public SuggestionContext<TSource> FindSuggestionContext(int cursor) {
        if (Range.Start > cursor) {
            throw new InvalidOperationException("Can't find node before cursor");
        }
        if (Range.End < cursor) {
            if (_child != null) {
                return _child.FindSuggestionContext(cursor);
            }
            if (_nodes.Count > 0) {
                ParsedCommandNode<TSource> last = _nodes[^1];
                return new SuggestionContext<TSource>(last.Node, last.Range.End + 1);
            }
            return new SuggestionContext<TSource>(RootNode, Range.Start);
        }

        CommandNode<TSource> prev = RootNode;
        foreach (ParsedCommandNode<TSource> node in _nodes) {
            StringRange nodeRange = node.Range;
            if (nodeRange.Start <= cursor && cursor <= nodeRange.End) {
                return new SuggestionContext<TSource>(prev, nodeRange.Start);
            }
            prev = node.Node;
        }
        return new SuggestionContext<TSource>(prev, Range.Start);
    }
}
