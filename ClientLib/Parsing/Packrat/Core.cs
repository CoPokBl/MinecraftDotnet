using ClientLib.Brigadier;

namespace ClientLib.Parsing.Packrat;

/// <summary>
/// Vanilla's <c>Atom</c>, compared by reference as vanilla's are. A null result is how a rule fails, so
/// an atom for a struct value is declared over its nullable form.
/// </summary>
public sealed class Atom<T>(string name) {
    public string Name { get; } = name;

    public static Atom<T> Of(string name) => new(name);

    public override string ToString() => "<" + Name + ">";
}

/// <summary>Vanilla's <c>Control</c>.</summary>
public interface IControl {
    public static readonly IControl Unbound = new UnboundControl();

    void Cut();

    bool HasCut();

    private sealed class UnboundControl : IControl {
        public void Cut() {
        }

        public bool HasCut() => false;
    }
}

/// <summary>Vanilla's <c>DelayedException</c>: an error built only once the parse has failed for good.</summary>
public interface IDelayedException<out T> where T : Exception {
    T Create(string contents, int position);
}

/// <summary>The static half of vanilla's <c>DelayedException</c>.</summary>
public static class DelayedException {
    private sealed class Lambda(Func<string, int, CommandSyntaxException> create) : IDelayedException<CommandSyntaxException> {
        public CommandSyntaxException Create(string contents, int position) => create(contents, position);
    }

    public static IDelayedException<CommandSyntaxException> Create(SimpleCommandExceptionType type) =>
        new Lambda((contents, position) => type.CreateWithContext(StringReaderTerms.CreateReader(contents, position)));

    public static IDelayedException<CommandSyntaxException> Create(DynamicCommandExceptionType type, string argument) =>
        new Lambda((contents, position) => type.CreateWithContext(StringReaderTerms.CreateReader(contents, position), argument));
}

/// <summary>Vanilla's <c>SuggestionSupplier</c>.</summary>
public interface ISuggestionSupplier<S> {
    IEnumerable<string> PossibleValues(IParseState<S> state);
}

/// <summary>The static half of vanilla's <c>SuggestionSupplier</c>.</summary>
public static class SuggestionSupplier {
    private sealed class EmptySupplier<S> : ISuggestionSupplier<S> {
        public static readonly EmptySupplier<S> Instance = new();

        public IEnumerable<string> PossibleValues(IParseState<S> state) => [];
    }

    private sealed class Lambda<S>(Func<IParseState<S>, IEnumerable<string>> values) : ISuggestionSupplier<S> {
        public IEnumerable<string> PossibleValues(IParseState<S> state) => values(state);
    }

    public static ISuggestionSupplier<S> Empty<S>() => EmptySupplier<S>.Instance;

    public static ISuggestionSupplier<S> Of<S>(Func<IParseState<S>, IEnumerable<string>> values) => new Lambda<S>(values);
}

/// <summary>Vanilla's <c>ErrorEntry</c>.</summary>
public sealed record ErrorEntry<S>(int Cursor, ISuggestionSupplier<S> Suggestions, object Reason);

/// <summary>Vanilla's <c>ErrorCollector</c>.</summary>
public interface IErrorCollector<S> {
    void Store(int cursor, ISuggestionSupplier<S> suggestions, object reason);

    void Store(int cursor, object reason) => Store(cursor, SuggestionSupplier.Empty<S>(), reason);

    void Finish(int finalCursor);
}

/// <summary>The implementations nested in vanilla's <c>ErrorCollector</c>.</summary>
public static class ErrorCollector {
    /// <summary><c>ErrorCollector.LongestOnly</c>: keeps only the errors of the parse that got furthest.</summary>
    public sealed class LongestOnly<S> : IErrorCollector<S> {
        private MutableErrorEntry[] _entries = new MutableErrorEntry[16];
        private int _nextErrorEntry;
        private int _lastCursor = -1;

        private void DiscardErrorsFromShorterParse(int cursor) {
            if (cursor > _lastCursor) {
                _lastCursor = cursor;
                _nextErrorEntry = 0;
            }
        }

        public void Finish(int finalCursor) => DiscardErrorsFromShorterParse(finalCursor);

        public void Store(int cursor, ISuggestionSupplier<S> suggestions, object reason) {
            DiscardErrorsFromShorterParse(cursor);
            if (cursor == _lastCursor) {
                AddErrorEntry(suggestions, reason);
            }
        }

        private void AddErrorEntry(ISuggestionSupplier<S> suggestions, object reason) {
            int currentSize = _entries.Length;
            if (_nextErrorEntry >= currentSize) {
                int newSize = Util.GrowByHalf(currentSize, _nextErrorEntry + 1);
                Array.Resize(ref _entries, newSize);
            }
            int entryIndex = _nextErrorEntry++;
            MutableErrorEntry? entry = _entries[entryIndex];
            if (entry == null) {
                entry = new MutableErrorEntry();
                _entries[entryIndex] = entry;
            }
            entry.Suggestions = suggestions;
            entry.Reason = reason;
        }

        public List<ErrorEntry<S>> Entries() {
            int errorCount = _nextErrorEntry;
            List<ErrorEntry<S>> result = new(errorCount);
            for (int i = 0; i < errorCount; i++) {
                MutableErrorEntry entry = _entries[i];
                result.Add(new ErrorEntry<S>(_lastCursor, entry.Suggestions, entry.Reason));
            }
            return result;
        }

        public int Cursor() => _lastCursor;

        private sealed class MutableErrorEntry {
            public ISuggestionSupplier<S> Suggestions = SuggestionSupplier.Empty<S>();
            public object Reason = "empty";
        }
    }

    /// <summary><c>ErrorCollector.Nop</c>.</summary>
    public sealed class Nop<S> : IErrorCollector<S> {
        public void Store(int cursor, ISuggestionSupplier<S> suggestions, object reason) {
        }

        public void Finish(int finalCursor) {
        }
    }
}

/// <summary>Vanilla's <c>NamedRule</c>.</summary>
public interface INamedRule<S, T> {
    Atom<T> Name { get; }

    IRule<S, T> Value { get; }
}

/// <summary>Vanilla's <c>Rule</c>. A null result is a failed parse.</summary>
public interface IRule<S, T> {
    T? Parse(IParseState<S> state);
}

/// <summary>The static half of vanilla's <c>Rule</c>.</summary>
public static class Rule {
    /// <summary><c>Rule.RuleAction</c>.</summary>
    public delegate T? RuleAction<S, T>(IParseState<S> state);

    /// <summary><c>Rule.SimpleRuleAction</c>.</summary>
    public delegate T? SimpleRuleAction<T>(Scope ruleScope);

    public static IRule<S, T> FromTerm<S, T>(ITerm<S> child, RuleAction<S, T> action) => new WrappedTerm<S, T>(action, child);

    public static IRule<S, T> FromTerm<S, T>(ITerm<S> child, SimpleRuleAction<T> action) => new WrappedTerm<S, T>(state => action(state.Scope), child);

    /// <summary><c>Rule.WrappedTerm</c>.</summary>
    public sealed class WrappedTerm<S, T>(RuleAction<S, T> action, ITerm<S> child) : IRule<S, T> {
        public T? Parse(IParseState<S> state) {
            Scope scope = state.Scope;
            scope.PushFrame();
            try {
                if (!child.Parse(state, scope, IControl.Unbound)) {
                    return default;
                }
                return action(state);
            }
            finally {
                scope.PopFrame();
            }
        }
    }
}

/// <summary>Vanilla's <c>ParseState</c>.</summary>
public interface IParseState<S> {
    Scope Scope { get; }

    IErrorCollector<S> ErrorCollector { get; }

    T? ParseTopRule<T>(INamedRule<S, T> rule) {
        T? result = Parse(rule);
        if (result != null) {
            ErrorCollector.Finish(Mark());
        }
        if (!Scope.HasOnlySingleFrame()) {
            throw new InvalidOperationException("Malformed scope: " + Scope);
        }
        return result;
    }

    T? Parse<T>(INamedRule<S, T> rule);

    S Input { get; }

    int Mark();

    void Restore(int mark);

    IControl AcquireControl();

    void ReleaseControl();

    IParseState<S> Silent();
}

/// <summary>Bits of vanilla's <c>Util</c> the packrat parser uses.</summary>
internal static class Util {
    /// <summary><c>Util.growByHalf</c>.</summary>
    public static int GrowByHalf(int currentSize, int minimalNewSize) {
        return (int)Math.Max(Math.Min((long)currentSize + (currentSize >> 1), 2147483639L), minimalNewSize);
    }
}
