using Minecraft.Schemas;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>SetOnceOptionState</c>.</summary>
public sealed class SetOnceOptionState {
    private bool _hasValue;

    public bool CanParse() => !_hasValue;

    public void MarkParsed() => _hasValue = true;
}

/// <summary>Vanilla's <c>InvertableSetOptionState</c>.</summary>
public sealed class InvertableSetOptionState {
    private enum Limitation { None, Single, Multiple }

    private Limitation _state = Limitation.None;
    private readonly HashSet<Identifier> _tags = [];

    public bool CanParsePositiveElement() => _state == Limitation.None;

    public bool CanParseNegativeElement() => _state != Limitation.Single;

    public bool CanParseAnyTag() => _state != Limitation.Single;

    public bool CanParseTag(Identifier tag) => CanParseAnyTag() && !_tags.Contains(tag);

    public bool CanParseAny() => _state != Limitation.Single;

    public bool CanParseElement(bool inverted) => inverted ? CanParseNegativeElement() : CanParsePositiveElement();

    public void MarkParsedTag(Identifier tag) {
        _state = Limitation.Multiple;
        _tags.Add(tag);
    }

    public void MarkParsedElement(bool inverted) => _state = inverted ? Limitation.Multiple : Limitation.Single;
}
