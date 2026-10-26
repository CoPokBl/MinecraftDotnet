namespace ClientLib.Parsing.Packrat;

/// <summary>Vanilla's <c>Term</c>.</summary>
public interface ITerm<S> {
    bool Parse(IParseState<S> state, Scope scope, IControl control);
}

/// <summary>The static half of vanilla's <c>Term</c>, with its records nested as there.</summary>
public static class Term {
    public static ITerm<S> Marker<S, T>(Atom<T> name, T value) => new MarkerTerm<S, T>(name, value);

    public static ITerm<S> Sequence<S>(params ITerm<S>[] terms) => new SequenceTerm<S>(terms);

    public static ITerm<S> Alternative<S>(params ITerm<S>[] terms) => new AlternativeTerm<S>(terms);

    public static ITerm<S> Optional<S>(ITerm<S> term) => new Maybe<S>(term);

    public static ITerm<S> Repeated<S, T>(INamedRule<S, T> element, Atom<List<T>> listName, int minRepetitions = 0) =>
        new RepeatedTerm<S, T>(element, listName, minRepetitions);

    public static ITerm<S> RepeatedWithTrailingSeparator<S, T>(INamedRule<S, T> element, Atom<List<T>> listName, ITerm<S> separator, int minRepetitions = 0) =>
        new RepeatedWithSeparator<S, T>(element, listName, separator, minRepetitions, true);

    public static ITerm<S> PositiveLookahead<S>(ITerm<S> term) => new LookAhead<S>(term, true);

    public static ITerm<S> Cut<S>() => new CutTerm<S>();

    public static ITerm<S> Fail<S>(object message) => new FailTerm<S>(message);

    private sealed class CutTerm<S> : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            control.Cut();
            return true;
        }

        public override string ToString() => "^";
    }

    private sealed class FailTerm<S>(object message) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            state.ErrorCollector.Store(state.Mark(), message);
            return false;
        }

        public override string ToString() => "fail";
    }

    /// <summary><c>Term.Alternative</c>.</summary>
    public sealed class AlternativeTerm<S>(ITerm<S>[] elements) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            IControl controlForThis = state.AcquireControl();
            try {
                int mark = state.Mark();
                scope.SplitFrame();
                foreach (ITerm<S> element in elements) {
                    if (element.Parse(state, scope, controlForThis)) {
                        scope.MergeFrame();
                        return true;
                    }
                    scope.ClearFrameValues();
                    state.Restore(mark);
                    if (controlForThis.HasCut()) {
                        break;
                    }
                }
                scope.PopFrame();
                return false;
            }
            finally {
                state.ReleaseControl();
            }
        }
    }

    /// <summary><c>Term.LookAhead</c>.</summary>
    public sealed class LookAhead<S>(ITerm<S> term, bool positive) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            int mark = state.Mark();
            bool result = term.Parse(state.Silent(), scope, control);
            state.Restore(mark);
            return positive == result;
        }
    }

    /// <summary><c>Term.Marker</c>.</summary>
    public sealed class MarkerTerm<S, T>(Atom<T> name, T value) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            scope.Put(name, value);
            return true;
        }
    }

    /// <summary><c>Term.Maybe</c>.</summary>
    public sealed class Maybe<S>(ITerm<S> term) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            int mark = state.Mark();
            if (!term.Parse(state, scope, control)) {
                state.Restore(mark);
            }
            return true;
        }
    }

    /// <summary><c>Term.Repeated</c>.</summary>
    public sealed class RepeatedTerm<S, T>(INamedRule<S, T> element, Atom<List<T>> listName, int minRepetitions) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            int mark = state.Mark();
            List<T> elements = new(minRepetitions);
            while (true) {
                int entryMark = state.Mark();
                T? parsedElement = state.Parse(element);
                if (parsedElement == null) {
                    state.Restore(entryMark);
                    if (elements.Count < minRepetitions) {
                        state.Restore(mark);
                        return false;
                    }
                    scope.Put(listName, elements);
                    return true;
                }
                elements.Add(parsedElement);
            }
        }
    }

    /// <summary><c>Term.RepeatedWithSeparator</c>.</summary>
    public sealed class RepeatedWithSeparator<S, T>(
        INamedRule<S, T> element,
        Atom<List<T>> listName,
        ITerm<S> separator,
        int minRepetitions,
        bool allowTrailingSeparator) : ITerm<S> {

        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            int listMark = state.Mark();
            List<T> elements = new(minRepetitions);
            bool first = true;
            while (true) {
                int markBeforeSeparator = state.Mark();
                if (!first && !separator.Parse(state, scope, control)) {
                    state.Restore(markBeforeSeparator);
                    break;
                }
                int markAfterSeparator = state.Mark();
                T? parsedElement = state.Parse(element);
                if (parsedElement == null) {
                    if (first) {
                        state.Restore(markAfterSeparator);
                    }
                    else {
                        if (!allowTrailingSeparator) {
                            state.Restore(listMark);
                            return false;
                        }
                        state.Restore(markAfterSeparator);
                    }
                    break;
                }
                elements.Add(parsedElement);
                first = false;
            }
            if (elements.Count < minRepetitions) {
                state.Restore(listMark);
                return false;
            }
            scope.Put(listName, elements);
            return true;
        }
    }

    /// <summary><c>Term.Sequence</c>.</summary>
    public sealed class SequenceTerm<S>(ITerm<S>[] elements) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            int mark = state.Mark();
            foreach (ITerm<S> element in elements) {
                if (!element.Parse(state, scope, control)) {
                    state.Restore(mark);
                    return false;
                }
            }
            return true;
        }
    }
}
