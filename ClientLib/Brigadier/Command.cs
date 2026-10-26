namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>Command</c>. The client only ever tests whether a node has one.</summary>
public delegate int Command<TSource>(CommandContext<TSource> context);

/// <summary>Brigadier's <c>SuggestionProvider</c>.</summary>
public delegate Task<Suggestions> SuggestionProvider<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder);

/// <summary>Brigadier's <c>ParseResults</c>.</summary>
public sealed class ParseResults<TSource>(
    CommandContextBuilder<TSource> context,
    IImmutableStringReader reader,
    IReadOnlyDictionary<CommandNode<TSource>, CommandSyntaxException> exceptions) {

    /// <summary>Insertion ordered, as brigadier's <c>LinkedHashMap</c> is: the usage line lists them in that order.</summary>
    public IReadOnlyDictionary<CommandNode<TSource>, CommandSyntaxException> Exceptions { get; } = exceptions;

    public CommandContextBuilder<TSource> Context { get; } = context;
    public IImmutableStringReader Reader { get; } = reader;

    public ParseResults(CommandContextBuilder<TSource> context) : this(context, new StringReader(""), new OrderedDictionary<CommandNode<TSource>, CommandSyntaxException>()) {
    }
}
