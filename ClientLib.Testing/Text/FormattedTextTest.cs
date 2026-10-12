using Minecraft.Text;

namespace ClientLib.Testing.Text;

/// <summary>Section sign codes against <c>StringDecomposer.iterateFormatted</c> and <c>Style.applyLegacyFormat</c>.</summary>
public class FormattedTextTest {
    private const char S = StringDecomposer.SectionSign;

    [Test]
    public void TestColourAndDecorationsRunTogether() {
        List<TextRun> runs = TextFlattener.Formatted($"{S}cRed {S}lBold{S}r plain");
        Assert.That(runs, Is.EqualTo(new List<TextRun> {
            new("Red ", 0xFF5555),
            new("Bold", 0xFF5555, Bold: true),
            new(" plain", 0xFFFFFF)
        }));
    }

    [Test]
    public void TestColourClearsDecorations() {
        List<TextRun> runs = TextFlattener.Formatted($"{S}l{S}o{S}aX");
        Assert.That(runs, Is.EqualTo(new List<TextRun> { new("X", 0x55FF55) }));
    }

    [Test]
    public void TestCodesAreCaseInsensitive() {
        Assert.That(TextFlattener.Formatted($"{S}CX{S}KY"), Is.EqualTo(new List<TextRun> {
            new("X", 0xFF5555),
            new("Y", 0xFF5555, Obfuscated: true)
        }));
    }

    [Test]
    public void TestUnknownCodeAndTrailingSignAreDropped() {
        Assert.That(TextFlattener.Plain(TextComponent.Text($"a{S}zb{S}")), Is.EqualTo("ab"));
    }

    [Test]
    public void TestResetGoesBackToTheComponentStyle() {
        List<TextRun> runs = TextFlattener.Flatten(TextComponent.Text($"{S}lA{S}rB").WithColor(TextColor.Gold));
        Assert.That(runs, Is.EqualTo(new List<TextRun> { new("A", 0xFFAA00, Bold: true), new("B", 0xFFAA00) }));
    }

    [Test]
    public void TestCodeDoesNotReachTheNextComponent() {
        List<TextRun> runs = TextFlattener.Flatten(TextComponent.Text($"{S}cA").With(TextComponent.Text("B")));
        Assert.That(runs, Is.EqualTo(new List<TextRun> { new("A", 0xFF5555), new("B", 0xFFFFFF) }));
    }

    [Test]
    public void TestDecodeAppliesCodesLeftInRuns() {
        IReadOnlyList<TextRun> runs = TextFlattener.Decode([new TextRun($"x{S}9y", 0x123456, Italic: true)]);
        Assert.That(runs, Is.EqualTo(new List<TextRun> { new("x", 0x123456, Italic: true), new("y", 0x5555FF) }));
    }
}

/// <summary><c>StringSplitter</c> with every glyph 5 wide, a space 4, and bold one more.</summary>
public class StringSplitterTest {
    private static readonly StringSplitter Splitter = new((codepoint, style) => (codepoint == ' ' ? 4 : 5) + (style.Bold ? 1 : 0));

    private static List<(int Start, int End)> Lines(string text, int width) {
        List<(int, int)> lines = [];
        Splitter.SplitLines(text, width, StringSplitter.Empty, false, (_, start, end) => lines.Add((start, end)));
        return lines;
    }

    [Test]
    public void TestWidthCountsBoldAndSkipsCodes() {
        Assert.That(Splitter.StringWidth($"{StringDecomposer.SectionSign}lab c"), Is.EqualTo(6 + 6 + 5 + 6));
    }

    [Test]
    public void TestBreaksAtTheLastSpace() {
        Assert.That(Lines("aaa bbb", 20), Is.EqualTo(new List<(int, int)> { (0, 3), (4, 7) }));
    }

    [Test]
    public void TestLongWordBreaksInside() {
        Assert.That(Lines("aaaaaa", 12), Is.EqualTo(new List<(int, int)> { (0, 2), (2, 4), (4, 6) }));
    }

    [Test]
    public void TestNewlinesBreakAndBlankLinesStay() {
        Assert.That(Lines("a\n\nb", 100), Is.EqualTo(new List<(int, int)> { (0, 1), (2, 2), (3, 4) }));
    }

    [Test]
    public void TestRunsKeepTheirStylesAcrossABreak() {
        List<List<TextRun>> lines = Splitter.SplitLines([new TextRun("hello ", 0xFF0000), new TextRun("world", 0x0000FF)], 40);
        Assert.That(lines, Has.Count.EqualTo(2));
        Assert.That(lines[0], Is.EqualTo(new List<TextRun> { new("hello", 0xFF0000) }));
        Assert.That(lines[1], Is.EqualTo(new List<TextRun> { new("world", 0x0000FF) }));
    }

    [Test]
    public void TestTrailingNewlineGivesAnEmptyLine() {
        List<List<TextRun>> lines = Splitter.SplitLines([new TextRun("a\n", 0xFFFFFF)], 100);
        Assert.That(lines.Select(l => string.Concat(l.Select(r => r.Text))), Is.EqualTo(new[] { "a", "" }));
    }

    [Test]
    public void TestEmptyTextHasNoLines() {
        Assert.That(Splitter.SplitLines([], 100), Is.Empty);
    }

    [Test]
    public void TestPlainHeadByWidthStopsBeforeOverflow() {
        Assert.That(Splitter.PlainHeadByWidth("abcd", 14, StringSplitter.Empty), Is.EqualTo("ab"));
        Assert.That(Splitter.PlainTailByWidth("abcd", 14, StringSplitter.Empty), Is.EqualTo("cd"));
    }
}

/// <summary><c>MultilineTextField</c> over the same 5 wide glyphs, four to a 20 wide line.</summary>
public class MultilineTextFieldTest {
    private static MultilineTextField Field(int lineLimit = MultilineTextField.NoLimit) {
        MultilineTextField field = new(new StringSplitter((codepoint, _) => codepoint == ' ' ? 4 : 5), 20);
        field.LineLimit = lineLimit;
        return field;
    }

    [Test]
    public void TestLineLimitRefusesTheInsertThatOverflows() {
        MultilineTextField field = Field(2);
        field.InsertText("aaaa bbbb");
        Assert.That(field.LineCount, Is.EqualTo(2));
        field.InsertText(" cccc");
        Assert.That(field.Value, Is.EqualTo("aaaa bbbb"));
    }

    [Test]
    public void TestCharacterLimitCutsTheInsert() {
        MultilineTextField field = Field();
        field.CharacterLimit = 5;
        field.InsertText("abcdefg");
        Assert.That(field.Value, Is.EqualTo("abcde"));
    }

    [Test]
    public void TestSectionSignIsFilteredButNewlineKept() {
        MultilineTextField field = Field();
        field.InsertText($"a{StringDecomposer.SectionSign}c\nb");
        Assert.That(field.Value, Is.EqualTo("ac\nb"));
    }

    [Test]
    public void TestTrailingNewlineStartsAnEmptyLine() {
        MultilineTextField field = Field();
        field.InsertText("ab\n");
        Assert.That(field.Lines, Is.EqualTo(new[] { new MultilineTextField.StringView(0, 2), new MultilineTextField.StringView(3, 3) }));
        Assert.That(field.LineAtCursor, Is.EqualTo(1));
    }

    [Test]
    public void TestBackspaceAndSelectionReplace() {
        MultilineTextField field = Field();
        field.InsertText("hello");
        field.DeleteText(-1);
        Assert.That(field.Value, Is.EqualTo("hell"));
        field.SeekCursor(MultilineTextField.Whence.Absolute, 1);
        field.Selecting = true;
        field.SeekCursor(MultilineTextField.Whence.Absolute, 3);
        field.Selecting = false;
        field.InsertText("X");
        Assert.That(field.Value, Is.EqualTo("hXl"));
        Assert.That(field.Cursor, Is.EqualTo(2));
    }

    [Test]
    public void TestCursorLineKeepsTheColumn() {
        MultilineTextField field = Field();
        field.InsertText("abcd efgh");
        field.SeekCursor(MultilineTextField.Whence.Absolute, 2);
        field.SeekCursorLine(1);
        Assert.That(field.Cursor, Is.EqualTo(5 + 2));
    }

    [Test]
    public void TestWordsSkipWhitespace() {
        MultilineTextField field = Field();
        field.InsertText("one  two");
        Assert.That(field.PreviousWord, Is.EqualTo(new MultilineTextField.StringView(5, 8)));
        field.SeekCursor(MultilineTextField.Whence.Absolute, 0);
        Assert.That(field.NextWord, Is.EqualTo(new MultilineTextField.StringView(5, 8)));
    }
}
