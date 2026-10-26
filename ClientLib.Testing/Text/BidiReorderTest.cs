
namespace ClientLib.Testing.Text;

/// <summary>The implicit bidirectional algorithm's visual order, worked by hand from its rules.</summary>
public class BidiReorderTest {
    private static string Visual(string text, bool rtl = false) => string.Concat(BidiReorder.Reorder([new TextRun(text, 0xFFFFFF)], rtl).Select(r => r.Text));

    [Test]
    public void TestLeftToRightIsUntouched() {
        IReadOnlyList<TextRun> runs = [new TextRun("abc", 0xFFFFFF)];
        Assert.That(BidiReorder.Reorder(runs, false), Is.SameAs(runs));
    }

    [Test]
    public void TestHebrewReverses() => Assert.That(Visual("\u05D0\u05D1\u05D2"), Is.EqualTo("\u05D2\u05D1\u05D0"));

    [Test]
    public void TestHebrewInsideEnglish() =>
        // The spaces sit between an L and an R, so N2 gives them the paragraph's left to right level.
        Assert.That(Visual("abc \u05D0\u05D1 def"), Is.EqualTo("abc \u05D1\u05D0 def"));

    [Test]
    public void TestNumbersKeepTheirOrderInRightToLeftText() =>
        // Levels 1 1 1 2 2 2: the number is one run at level 2, then the whole line is reversed.
        Assert.That(Visual("\u05D0\u05D1 123"), Is.EqualTo("123 \u05D1\u05D0"));

    [Test]
    public void TestBracketsMirror() => Assert.That(Visual("\u05D0(\u05D1)"), Is.EqualTo("(\u05D1)\u05D0"));

    [Test]
    public void TestRightToLeftLanguageWithoutLetters() {
        // No strong letter, so the right to left default holds; the space between two numbers counts as R.
        Assert.That(Visual("12 34", true), Is.EqualTo("34 12"));
        Assert.That(Visual("hello world", true), Is.EqualTo("hello world"));
    }

    [Test]
    public void TestStylesFollowTheirCharacters() {
        IReadOnlyList<TextRun> visual = BidiReorder.Reorder([new TextRun("abc ", 0xFF0000), new TextRun("\u05D0\u05D1", 0x0000FF)], false);
        Assert.That(visual, Is.EqualTo(new[] { new TextRun("abc ", 0xFF0000), new TextRun("\u05D1\u05D0", 0x0000FF) }));
    }

    [Test]
    public void TestArabicLettersTakeTheirJoinedForms() {
        Assert.That(BidiReorder.Shape("\u0628\u0628"), Is.EqualTo("\uFE91\uFE90"), "initial beh then final beh");
        Assert.That(BidiReorder.Shape("\u0628\u0628\u0628"), Is.EqualTo("\uFE91\uFE92\uFE90"));
        Assert.That(BidiReorder.Shape("\u0627\u0628"), Is.EqualTo("\uFE8D\uFE8F"), "alef joins nothing after it");
        Assert.That(BidiReorder.Shape("\u0644\u0627"), Is.EqualTo("\uFEFB"), "lam alef ligature");
        Assert.That(BidiReorder.Shape("\u0628\u0644\u0627"), Is.EqualTo("\uFE91\uFEFC"));
        Assert.That(BidiReorder.Shape("\u0621\u0628"), Is.EqualTo("\uFE80\uFE8F"), "hamza joins neither way");
    }
}
