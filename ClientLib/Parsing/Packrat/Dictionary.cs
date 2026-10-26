namespace ClientLib.Parsing.Packrat;

/// <summary>Vanilla's packrat <c>Dictionary</c>: the rules of a grammar, by atom.</summary>
public sealed class Dictionary<S> {
    private readonly System.Collections.Generic.Dictionary<object, IEntry> _terms = new(ReferenceEqualityComparer.Instance);

    private interface IEntry {
        object Name { get; }
        bool IsBound { get; }
    }

    public INamedRule<S, T> Put<T>(Atom<T> name, IRule<S, T> entry) {
        Entry<T> holder = GetOrCreateEntry(name);
        if (holder.RuleValue != null) {
            throw new ArgumentException("Trying to override rule: " + name);
        }
        holder.RuleValue = entry;
        return holder;
    }

    public INamedRule<S, T> PutComplex<T>(Atom<T> name, ITerm<S> term, Rule.RuleAction<S, T> action) => Put(name, Rule.FromTerm(term, action));

    public INamedRule<S, T> Put<T>(Atom<T> name, ITerm<S> term, Rule.SimpleRuleAction<T> action) => Put(name, Rule.FromTerm<S, T>(term, action));

    public void CheckAllBound() {
        List<object> unboundNames = _terms.Where(e => !e.Value.IsBound).Select(e => e.Key).ToList();
        if (unboundNames.Count > 0) {
            throw new InvalidOperationException("Unbound names: [" + string.Join(", ", unboundNames) + "]");
        }
    }

    public INamedRule<S, T> Forward<T>(Atom<T> name) => GetOrCreateEntry(name);

    private Entry<T> GetOrCreateEntry<T>(Atom<T> name) {
        if (!_terms.TryGetValue(name, out IEntry? entry)) {
            entry = new Entry<T>(name);
            _terms[name] = entry;
        }
        return (Entry<T>)entry;
    }

    public ITerm<S> Named<T>(Atom<T> name) => new Reference<T>(GetOrCreateEntry(name), name);

    public ITerm<S> NamedWithAlias<T>(Atom<T> nameToParse, Atom<T> nameToStore) => new Reference<T>(GetOrCreateEntry(nameToParse), nameToStore);

    private sealed class Entry<T>(Atom<T> name) : INamedRule<S, T>, IEntry {
        public IRule<S, T>? RuleValue;

        public Atom<T> Name { get; } = name;

        public IRule<S, T> Value => RuleValue ?? throw new NullReferenceException("Unbound rule " + Name);

        object IEntry.Name => Name;

        public bool IsBound => RuleValue != null;
    }

    private sealed class Reference<T>(Entry<T> ruleToParse, Atom<T> nameToStore) : ITerm<S> {
        public bool Parse(IParseState<S> state, Scope scope, IControl control) {
            T? result = state.Parse(ruleToParse);
            if (result == null) {
                return false;
            }
            scope.Put(nameToStore, result);
            return true;
        }
    }
}

/// <summary>Vanilla's <c>CachedParseState</c>: memoises each rule's result at each position.</summary>
public abstract class CachedParseState<S> : IParseState<S> {
    private PositionCache?[] _positionCache = new PositionCache?[256];
    private readonly IErrorCollector<S> _errorCollector;
    private readonly Scope _scope = new();
    private SimpleControl?[] _controlCache = new SimpleControl?[16];
    private int _nextControlToReturn;
    private readonly SilentState _silent;

    protected CachedParseState(IErrorCollector<S> errorCollector) {
        _errorCollector = errorCollector;
        _silent = new SilentState(this);
    }

    public Scope Scope => _scope;

    public IErrorCollector<S> ErrorCollector => _errorCollector;

    public abstract S Input { get; }

    public abstract int Mark();

    public abstract void Restore(int mark);

    public T? Parse<T>(INamedRule<S, T> rule) {
        int markBeforeParse = Mark();
        PositionCache positionCache = GetCacheForPosition(markBeforeParse);
        int entryIndex = positionCache.FindKeyIndex(rule.Name);
        if (entryIndex != -1) {
            CacheEntry? value = positionCache.GetValue(entryIndex);
            if (value != null) {
                if (ReferenceEquals(value, CacheEntry.Negative)) {
                    return default;
                }
                Restore(value.MarkAfterParse);
                return (T?)value.Value;
            }
        }
        else {
            entryIndex = positionCache.AllocateNewEntry(rule.Name);
        }

        T? result = rule.Value.Parse(this);
        CacheEntry entry = result == null ? CacheEntry.Negative : new CacheEntry(result, Mark());
        positionCache.SetValue(entryIndex, entry);
        return result;
    }

    private PositionCache GetCacheForPosition(int index) {
        int currentSize = _positionCache.Length;
        if (index >= currentSize) {
            int newSize = Util.GrowByHalf(currentSize, index + 1);
            Array.Resize(ref _positionCache, newSize);
        }
        PositionCache? result = _positionCache[index];
        if (result == null) {
            result = new PositionCache();
            _positionCache[index] = result;
        }
        return result;
    }

    public IControl AcquireControl() {
        int currentSize = _controlCache.Length;
        if (_nextControlToReturn >= currentSize) {
            int newSize = Util.GrowByHalf(currentSize, _nextControlToReturn + 1);
            Array.Resize(ref _controlCache, newSize);
        }
        int controlIndex = _nextControlToReturn++;
        SimpleControl? entry = _controlCache[controlIndex];
        if (entry == null) {
            entry = new SimpleControl();
            _controlCache[controlIndex] = entry;
        }
        else {
            entry.Reset();
        }
        return entry;
    }

    public void ReleaseControl() {
        _nextControlToReturn--;
    }

    public IParseState<S> Silent() => _silent;

    private sealed class CacheEntry(object? value, int markAfterParse) {
        public static readonly CacheEntry Negative = new(null, -1);

        public readonly object? Value = value;
        public readonly int MarkAfterParse = markAfterParse;
    }

    private sealed class PositionCache {
        private const int EntryStride = 2;
        private object?[] _atomCache = new object?[16];
        private int _nextKey;

        public int FindKeyIndex(object key) {
            for (int i = 0; i < _nextKey; i += EntryStride) {
                if (ReferenceEquals(_atomCache[i], key)) {
                    return i;
                }
            }
            return -1;
        }

        public int AllocateNewEntry(object key) {
            int newKeyIndex = _nextKey;
            _nextKey += EntryStride;
            int newValueIndex = newKeyIndex + 1;
            int currentSize = _atomCache.Length;
            if (newValueIndex >= currentSize) {
                int newSize = Util.GrowByHalf(currentSize, newValueIndex + 1);
                Array.Resize(ref _atomCache, newSize);
            }
            _atomCache[newKeyIndex] = key;
            return newKeyIndex;
        }

        public CacheEntry? GetValue(int keyIndex) => (CacheEntry?)_atomCache[keyIndex + 1];

        public void SetValue(int keyIndex, CacheEntry entry) => _atomCache[keyIndex + 1] = entry;
    }

    private sealed class SilentState(CachedParseState<S> outer) : IParseState<S> {
        private readonly IErrorCollector<S> _silentCollector = new ErrorCollector.Nop<S>();

        public IErrorCollector<S> ErrorCollector => _silentCollector;
        public Scope Scope => outer.Scope;
        public T? Parse<T>(INamedRule<S, T> rule) => outer.Parse(rule);
        public S Input => outer.Input;
        public int Mark() => outer.Mark();
        public void Restore(int mark) => outer.Restore(mark);
        public IControl AcquireControl() => outer.AcquireControl();
        public void ReleaseControl() => outer.ReleaseControl();
        public IParseState<S> Silent() => this;
    }

    private sealed class SimpleControl : IControl {
        private bool _hasCut;

        public void Cut() => _hasCut = true;

        public bool HasCut() => _hasCut;

        public void Reset() => _hasCut = false;
    }
}
