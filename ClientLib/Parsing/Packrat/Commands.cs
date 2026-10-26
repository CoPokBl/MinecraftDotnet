using System.Text.RegularExpressions;
using ClientLib.Brigadier;
using ClientLib.Commands;
using ClientLib.Nbt;
using Minecraft.Schemas;
using NBT;

namespace ClientLib.Parsing.Packrat;

/// <summary>Vanilla's <c>StringReaderParserState</c>.</summary>
public sealed class StringReaderParserState(IErrorCollector<StringReader> errorCollector, StringReader input) : CachedParseState<StringReader>(errorCollector) {
    public override StringReader Input { get; } = input;

    public override int Mark() => Input.Cursor;

    public override void Restore(int mark) => Input.Cursor = mark;
}

/// <summary>Vanilla's <c>StringReaderTerms</c>.</summary>
public static class StringReaderTerms {
    public static ITerm<StringReader> Character(char value) => new LambdaTerminalCharacters([value], v => v == value);

    public static ITerm<StringReader> Characters(char v1, char v2) => new LambdaTerminalCharacters([v1, v2], v => v == v1 || v == v2);

    public static StringReader CreateReader(string contents, int cursor) => new(contents) { Cursor = cursor };

    private sealed class LambdaTerminalCharacters(char[] values, Func<char, bool> accepted) : TerminalCharacters(values) {
        protected override bool IsAccepted(char value) => accepted(value);
    }

    /// <summary><c>StringReaderTerms.TerminalCharacters</c>.</summary>
    public abstract class TerminalCharacters : ITerm<StringReader> {
        private readonly IDelayedException<CommandSyntaxException> _error;
        private readonly ISuggestionSupplier<StringReader> _suggestions;

        protected TerminalCharacters(char[] values) {
            string joinedValues = string.Join("|", values.Select(c => c.ToString()));
            _error = DelayedException.Create(CommandSyntaxException.BuiltInExceptions.LiteralIncorrect, joinedValues);
            _suggestions = SuggestionSupplier.Of<StringReader>(_ => values.Select(c => c.ToString()));
        }

        public bool Parse(IParseState<StringReader> state, Scope scope, IControl control) {
            state.Input.SkipWhitespace();
            int cursor = state.Mark();
            if (state.Input.CanRead() && IsAccepted(state.Input.ReadChar())) {
                return true;
            }
            state.ErrorCollector.Store(cursor, _suggestions, _error);
            return false;
        }

        protected abstract bool IsAccepted(char value);
    }
}

/// <summary>Vanilla's <c>CommandArgumentParser</c>.</summary>
public interface ICommandArgumentParser<T> {
    T ParseForCommands(StringReader reader);

    Task<Suggestions> ParseForSuggestions(SuggestionsBuilder suggestionsBuilder);
}

/// <summary>The default methods of vanilla's <c>CommandArgumentParser</c>; <c>withCodec</c> is not ported, as the client holds none of the codecs.</summary>
public static class CommandArgumentParser {
    public static ICommandArgumentParser<TOut> MapResult<T, TOut>(this ICommandArgumentParser<T> parser, Func<T, TOut> mapper) =>
        new MappedParser<T, TOut>(parser, mapper);

    private sealed class MappedParser<TIn, TOut>(ICommandArgumentParser<TIn> inner, Func<TIn, TOut> mapper) : ICommandArgumentParser<TOut> {
        public TOut ParseForCommands(StringReader reader) => mapper(inner.ParseForCommands(reader));

        public Task<Suggestions> ParseForSuggestions(SuggestionsBuilder suggestionsBuilder) => inner.ParseForSuggestions(suggestionsBuilder);
    }
}

/// <summary>Vanilla's packrat <c>Grammar</c>.</summary>
public sealed class Grammar<T> : ICommandArgumentParser<T> {
    public Grammar(Dictionary<StringReader> rules, INamedRule<StringReader, T> top) {
        rules.CheckAllBound();
        Top = top;
    }

    public INamedRule<StringReader, T> Top { get; }

    public T? Parse(IParseState<StringReader> state) => state.ParseTopRule(Top);

    public T ParseForCommands(StringReader reader) {
        ErrorCollector.LongestOnly<StringReader> errorCollector = new();
        StringReaderParserState state = new(errorCollector, reader);
        T? result = Parse(state);
        if (result != null) {
            return result;
        }
        List<ErrorEntry<StringReader>> errorEntries = errorCollector.Entries();
        List<Exception> exceptions = [];
        foreach (ErrorEntry<StringReader> entry in errorEntries) {
            if (entry.Reason is IDelayedException<Exception> delayedException) {
                exceptions.Add(delayedException.Create(reader.String, entry.Cursor));
            }
            else if (entry.Reason is Exception exception) {
                exceptions.Add(exception);
            }
        }
        foreach (Exception exception in exceptions) {
            if (exception is CommandSyntaxException cse) {
                throw cse;
            }
        }
        if (exceptions.Count == 1) {
            throw exceptions[0];
        }
        throw new InvalidOperationException("Failed to parse: " + string.Join(", ", errorEntries.Select(e => e.ToString())));
    }

    public Task<Suggestions> ParseForSuggestions(SuggestionsBuilder suggestionsBuilder) {
        StringReader reader = new(suggestionsBuilder.Input) { Cursor = suggestionsBuilder.Start };
        ErrorCollector.LongestOnly<StringReader> errorCollector = new();
        StringReaderParserState state = new(errorCollector, reader);
        Parse(state);
        List<ErrorEntry<StringReader>> errorEntries = errorCollector.Entries();
        if (errorEntries.Count == 0) {
            return suggestionsBuilder.BuildFuture();
        }
        SuggestionsBuilder offsetBuilder = suggestionsBuilder.CreateOffset(errorCollector.Cursor());
        foreach (ErrorEntry<StringReader> entry in errorEntries) {
            if (entry.Suggestions is IResourceSuggestion resourceSuggestionTerm) {
                SharedSuggestionProvider.SuggestResource(resourceSuggestionTerm.PossibleResources(), offsetBuilder);
            }
            else {
                SharedSuggestionProvider.Suggest(entry.Suggestions.PossibleValues(state), offsetBuilder);
            }
        }
        return offsetBuilder.BuildFuture();
    }
}

/// <summary>Vanilla's <c>GreedyPatternParseRule</c>.</summary>
public sealed class GreedyPatternParseRule(Regex pattern, IDelayedException<CommandSyntaxException> error) : IRule<StringReader, string> {
    public string? Parse(IParseState<StringReader> state) {
        StringReader input = state.Input;
        string fullString = input.String;
        Match matcher = pattern.Match(fullString, input.Cursor);
        if (!matcher.Success || matcher.Index != input.Cursor) {
            state.ErrorCollector.Store(state.Mark(), error);
            return null;
        }
        input.Cursor = matcher.Index + matcher.Length;
        return matcher.Value;
    }
}

/// <summary>Vanilla's <c>GreedyPredicateParseRule</c>.</summary>
public abstract class GreedyPredicateParseRule(int minSize, int maxSize, IDelayedException<CommandSyntaxException> error) : IRule<StringReader, string> {
    public string? Parse(IParseState<StringReader> state) {
        StringReader input = state.Input;
        string fullString = input.String;
        int start = input.Cursor;
        int pos = start;
        while (pos < fullString.Length && IsAccepted(fullString[pos]) && pos - start < maxSize) {
            pos++;
        }
        int length = pos - start;
        if (length < minSize) {
            state.ErrorCollector.Store(state.Mark(), error);
            return null;
        }
        input.Cursor = pos;
        return fullString[start..pos];
    }

    protected abstract bool IsAccepted(char c);
}

/// <summary>Vanilla's <c>IdentifierParseRule</c>.</summary>
public sealed class IdentifierParseRule : IRule<StringReader, Identifier?> {
    public static readonly IRule<StringReader, Identifier?> Instance = new IdentifierParseRule();

    private IdentifierParseRule() {
    }

    public Identifier? Parse(IParseState<StringReader> state) {
        state.Input.SkipWhitespace();
        try {
            return Identifiers.ReadNonEmpty(state.Input);
        }
        catch (CommandSyntaxException) {
            return null;
        }
    }
}

/// <summary>Vanilla's <c>NumberRunParseRule</c>.</summary>
public abstract class NumberRunParseRule(
    IDelayedException<CommandSyntaxException> noValueError,
    IDelayedException<CommandSyntaxException> underscoreNotAllowedError) : IRule<StringReader, string> {

    public string? Parse(IParseState<StringReader> state) {
        StringReader input = state.Input;
        input.SkipWhitespace();
        string fullString = input.String;
        int start = input.Cursor;
        int pos = start;
        while (pos < fullString.Length && IsAccepted(fullString[pos])) {
            pos++;
        }
        int length = pos - start;
        if (length == 0) {
            state.ErrorCollector.Store(state.Mark(), noValueError);
            return null;
        }
        if (fullString[start] != '_' && fullString[pos - 1] != '_') {
            input.Cursor = pos;
            return fullString[start..pos];
        }
        state.ErrorCollector.Store(state.Mark(), underscoreNotAllowedError);
        return null;
    }

    protected abstract bool IsAccepted(char c);
}

/// <summary>Vanilla's <c>ParserBasedArgument</c>.</summary>
public abstract class ParserBasedArgument<T>(ICommandArgumentParser<T> parser) : ArgumentType<T> {
    public override T Parse(StringReader reader) => parser.ParseForCommands(reader);

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) => parser.ParseForSuggestions(builder);
}

/// <summary>Vanilla's <c>ResourceSuggestion</c>.</summary>
public interface IResourceSuggestion : ISuggestionSupplier<StringReader> {
    IEnumerable<Identifier> PossibleResources();

    IEnumerable<string> ISuggestionSupplier<StringReader>.PossibleValues(IParseState<StringReader> state) => PossibleResources().Select(id => id.ToString());
}

/// <summary>Vanilla's <c>ResourceLookupRule</c>.</summary>
public abstract class ResourceLookupRule<C, V> : IRule<StringReader, V>, IResourceSuggestion {
    private readonly INamedRule<StringReader, Identifier?> _idParser;
    protected readonly C Context;
    private readonly IDelayedException<CommandSyntaxException> _error;

    protected ResourceLookupRule(INamedRule<StringReader, Identifier?> idParser, C context) {
        _idParser = idParser;
        Context = context;
        _error = DelayedException.Create(Identifiers.ErrorInvalid);
    }

    public V? Parse(IParseState<StringReader> state) {
        state.Input.SkipWhitespace();
        int mark = state.Mark();
        Identifier? id = state.Parse(_idParser);
        if (id != null) {
            try {
                return ValidateElement(state.Input, id.Value);
            }
            catch (Exception e) {
                state.ErrorCollector.Store(mark, this, e);
                return default;
            }
        }
        state.ErrorCollector.Store(mark, this, _error);
        return default;
    }

    protected abstract V ValidateElement(IImmutableStringReader reader, Identifier id);

    public abstract IEnumerable<Identifier> PossibleResources();
}

/// <summary>Vanilla's <c>TagParseRule</c>, yielding the tag where vanilla wraps it in a <c>Dynamic</c> over <c>NbtOps</c>.</summary>
public sealed class TagParseRule : IRule<StringReader, INbtTag> {
    private readonly TagParser _parser = TagParser.Create();

    public INbtTag? Parse(IParseState<StringReader> state) {
        state.Input.SkipWhitespace();
        int mark = state.Mark();
        try {
            return _parser.ParseAsArgument(state.Input);
        }
        catch (Exception e) {
            state.ErrorCollector.Store(mark, e);
            return null;
        }
    }
}

/// <summary>Vanilla's <c>UnquotedStringParseRule</c>.</summary>
public sealed class UnquotedStringParseRule(int minSize, IDelayedException<CommandSyntaxException> error) : IRule<StringReader, string> {
    public string? Parse(IParseState<StringReader> state) {
        state.Input.SkipWhitespace();
        int cursor = state.Mark();
        string value = state.Input.ReadUnquotedString();
        if (value.Length < minSize) {
            state.ErrorCollector.Store(cursor, error);
            return null;
        }
        return value;
    }
}
