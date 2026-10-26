using Minecraft.Text;

namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>Suggestions</c>. A future waiting on the server completes on the thread that handles its answer.</summary>
public sealed class Suggestions(StringRange range, List<Suggestion> suggestions) {
    private static readonly Suggestions EmptySuggestions = new(StringRange.At(0), []);

    public StringRange Range { get; } = range;
    public List<Suggestion> List { get; } = suggestions;

    public bool IsEmpty => List.Count == 0;

    public static Task<Suggestions> Empty() => Task.FromResult(EmptySuggestions);

    public static Suggestions Merge(string command, ICollection<Suggestions> input) {
        if (input.Count == 0) {
            return EmptySuggestions;
        }
        if (input.Count == 1) {
            return input.First();
        }
        HashSet<Suggestion> texts = [];
        foreach (Suggestions suggestions in input) {
            texts.UnionWith(suggestions.List);
        }
        return Create(command, texts);
    }

    /// <summary>
    /// Ties under <c>compareToIgnoreCase</c> keep set order, which is not Java's <c>HashSet</c> order, so two
    /// suggestions differing only in case can swap relative to vanilla; nothing else can tie.
    /// </summary>
    public static Suggestions Create(string command, ICollection<Suggestion> suggestions) {
        if (suggestions.Count == 0) {
            return EmptySuggestions;
        }
        int start = int.MaxValue;
        int end = int.MinValue;
        foreach (Suggestion suggestion in suggestions) {
            start = Math.Min(suggestion.Range.Start, start);
            end = Math.Max(suggestion.Range.End, end);
        }
        StringRange range = new(start, end);
        HashSet<Suggestion> texts = [];
        foreach (Suggestion suggestion in suggestions) {
            texts.Add(suggestion.Expand(command, range));
        }
        List<Suggestion> sorted = texts.OrderBy(s => s, Comparer<Suggestion>.Create((a, b) => a.CompareToIgnoreCase(b))).ToList();
        return new Suggestions(range, sorted);
    }
}

/// <summary>Brigadier's <c>SuggestionsBuilder</c>.</summary>
public sealed class SuggestionsBuilder {
    private readonly string _inputLowerCase;
    private readonly List<Suggestion> _result = [];

    public string Input { get; }
    public int Start { get; }
    public string Remaining { get; }
    public string RemainingLowerCase { get; }

    public SuggestionsBuilder(string input, string inputLowerCase, int start) {
        Input = input;
        _inputLowerCase = inputLowerCase;
        Start = start;
        Remaining = input[start..];
        RemainingLowerCase = inputLowerCase[start..];
    }

    public SuggestionsBuilder(string input, int start) : this(input, JavaText.ToLowerRoot(input), start) {
    }

    public Suggestions Build() => Suggestions.Create(Input, _result);

    public Task<Suggestions> BuildFuture() => Task.FromResult(Build());

    public SuggestionsBuilder Suggest(string text, TextComponent? tooltip = null) {
        if (text == Remaining) {
            return this;
        }
        _result.Add(new Suggestion(StringRange.Between(Start, Input.Length), text, tooltip));
        return this;
    }

    public SuggestionsBuilder Suggest(int value, TextComponent? tooltip = null) {
        _result.Add(new IntegerSuggestion(StringRange.Between(Start, Input.Length), value, tooltip));
        return this;
    }

    public SuggestionsBuilder Add(SuggestionsBuilder other) {
        _result.AddRange(other._result);
        return this;
    }

    public SuggestionsBuilder CreateOffset(int start) => new(Input, _inputLowerCase, start);
}
