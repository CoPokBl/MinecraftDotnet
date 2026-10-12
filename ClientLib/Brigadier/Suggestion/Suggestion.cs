using System.Text;
using Minecraft.Text;

namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>Suggestion</c>.</summary>
public class Suggestion(StringRange range, string text, TextComponent? tooltip = null) : IEquatable<Suggestion> {
    public StringRange Range { get; } = range;
    public string Text { get; } = text;
    public TextComponent? Tooltip { get; } = tooltip;

    public string Apply(string input) {
        if (Range.Start == 0 && Range.End == input.Length) {
            return Text;
        }
        StringBuilder result = new();
        if (Range.Start > 0) {
            result.Append(input[..Range.Start]);
        }
        result.Append(Text);
        if (Range.End < input.Length) {
            result.Append(input[Range.End..]);
        }
        return result.ToString();
    }

    public virtual int CompareTo(Suggestion o) => JavaText.CompareTo(Text, o.Text);

    public virtual int CompareToIgnoreCase(Suggestion b) => JavaText.CompareToIgnoreCase(Text, b.Text);

    public Suggestion Expand(string command, StringRange range) {
        if (range == Range) {
            return this;
        }
        StringBuilder result = new();
        if (range.Start < Range.Start) {
            result.Append(command[range.Start..Range.Start]);
        }
        result.Append(Text);
        if (range.End > Range.End) {
            result.Append(command[Range.End..range.End]);
        }
        return new Suggestion(range, result.ToString(), Tooltip);
    }

    /// <summary>The tooltip compares by reference, as components have no value equality; keeping both duplicates is harmless.</summary>
    public virtual bool Equals(Suggestion? other) {
        return other is not null && other.GetType() == GetType() && Range == other.Range && Text == other.Text && ReferenceEquals(Tooltip, other.Tooltip);
    }

    public override bool Equals(object? obj) => obj is Suggestion s && Equals(s);

    public override int GetHashCode() => HashCode.Combine(Range, Text, Tooltip);

    public override string ToString() => $"Suggestion{{range={Range}, text='{Text}', tooltip='{Tooltip}'}}";
}

/// <summary>Brigadier's <c>IntegerSuggestion</c>.</summary>
public sealed class IntegerSuggestion(StringRange range, int value, TextComponent? tooltip = null)
    : Suggestion(range, value.ToString(System.Globalization.CultureInfo.InvariantCulture), tooltip) {
    public int Value { get; } = value;

    public override int CompareTo(Suggestion o) => o is IntegerSuggestion i ? Value.CompareTo(i.Value) : base.CompareTo(o);

    public override int CompareToIgnoreCase(Suggestion b) => CompareTo(b);

    public override bool Equals(Suggestion? other) => other is IntegerSuggestion i && i.Value == Value && base.Equals(other);

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Value);
}
