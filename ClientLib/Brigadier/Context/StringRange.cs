namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>StringRange</c>.</summary>
public readonly record struct StringRange(int Start, int End) {
    public static StringRange At(int pos) => new(pos, pos);

    public static StringRange Between(int start, int end) => new(start, end);

    public static StringRange Encompassing(StringRange a, StringRange b) => new(Math.Min(a.Start, b.Start), Math.Max(a.End, b.End));

    public bool IsEmpty => Start == End;
}

/// <summary>Brigadier's <c>ParsedArgument</c>.</summary>
public sealed class ParsedArgument<TSource>(int start, int end, object? result) {
    public StringRange Range { get; } = StringRange.Between(start, end);
    public object? Result { get; } = result;
}

/// <summary>Brigadier's <c>ParsedCommandNode</c>.</summary>
public sealed record ParsedCommandNode<TSource>(CommandNode<TSource> Node, StringRange Range);

/// <summary>Brigadier's <c>SuggestionContext</c>.</summary>
public sealed class SuggestionContext<TSource>(CommandNode<TSource> parent, int startPos) {
    public readonly CommandNode<TSource> Parent = parent;
    public readonly int StartPos = startPos;
}
