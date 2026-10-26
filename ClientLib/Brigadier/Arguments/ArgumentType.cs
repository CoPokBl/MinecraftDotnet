namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>ArgumentType</c> without its result type, as a command node holds one. Implement <see cref="ArgumentType{T}"/>.</summary>
public interface IArgumentType {
    object? Parse(StringReader reader);

    object? Parse<TSource>(StringReader reader, TSource source);

    Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder);

    IReadOnlyCollection<string> Examples { get; }
}

/// <summary>Brigadier's <c>ArgumentType</c>.</summary>
public abstract class ArgumentType<T> : IArgumentType {
    public abstract T Parse(StringReader reader);

    public virtual T Parse<TSource>(StringReader reader, TSource source) => Parse(reader);

    public virtual Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) => Suggestions.Empty();

    public virtual IReadOnlyCollection<string> Examples => [];

    object? IArgumentType.Parse(StringReader reader) => Parse(reader);

    object? IArgumentType.Parse<TSource>(StringReader reader, TSource source) => Parse(reader, source);
}
