using ClientLib.Brigadier;
using ClientLib.Commands.Arguments;
using ClientLib.Nbt;
using NBT;
using NBT.Tags;
using StringReader = ClientLib.Brigadier.StringReader;

namespace ClientLib.Testing.Commands;

public class SnbtTest {
    private static INbtTag Parse(string snbt) => TagParser.Create().ParseFully(snbt);

    private static string TranslationKey(CommandSyntaxException e) {
        return e.RawMessage.Content.Fields.Single(f => f.Key == "translate").Tag.GetString();
    }

    [Test]
    public void TestCompoundWithTypedNumbers() {
        CompoundTag tag = (CompoundTag)Parse("{a:1b,b:2s,'c':3,\"d\":4L,e:1.5f,f:2.5,g:true,h:hello}");
        Assert.Multiple(() => {
            Assert.That(tag["a"], Is.EqualTo(new ByteTag(1)));
            Assert.That(tag["b"], Is.EqualTo(new ShortTag(2)));
            Assert.That(tag["c"], Is.EqualTo(new IntegerTag(3)));
            Assert.That(tag["d"], Is.EqualTo(new LongTag(4)));
            Assert.That(tag["e"], Is.EqualTo(new FloatTag(1.5f)));
            Assert.That(tag["f"], Is.EqualTo(new DoubleTag(2.5)));
            Assert.That(tag["g"], Is.EqualTo(new ByteTag(1)));
            Assert.That(tag["h"], Is.EqualTo(new StringTag("hello")));
        });
    }

    [Test]
    public void TestNumberForms() {
        Assert.Multiple(() => {
            Assert.That(Parse("0xFF"), Is.EqualTo(new IntegerTag(255)));
            Assert.That(Parse("0b101"), Is.EqualTo(new IntegerTag(5)));
            Assert.That(Parse("0xFFub"), Is.EqualTo(new ByteTag(-1)));
            Assert.That(Parse("1_000"), Is.EqualTo(new IntegerTag(1000)));
            Assert.That(Parse("-5sb"), Is.EqualTo(new ByteTag(-5)));
            Assert.That(Parse(".5"), Is.EqualTo(new DoubleTag(0.5)));
            Assert.That(Parse("1e3"), Is.EqualTo(new DoubleTag(1000)));
        });
    }

    [Test]
    public void TestArraysAndLists() {
        Assert.Multiple(() => {
            Assert.That(Parse("[I;1,2,3]"), Is.EqualTo(new ArrayTag<int>(1, 2, 3)));
            Assert.That(Parse("[B;1b,2b]"), Is.EqualTo(new ArrayTag<sbyte>(1, 2)));
            Assert.That(Parse("[L;1,2l]"), Is.EqualTo(new ArrayTag<long>(1, 2)));
            Assert.That(Parse("[1,2,3]"), Is.EqualTo(new ListTag(new IntegerTag(1), new IntegerTag(2), new IntegerTag(3))));
            Assert.That(Parse("[]"), Is.EqualTo(new ListTag()));
        });
    }

    [Test]
    public void TestMixedListWrapsElements() {
        ListTag list = (ListTag)Parse("[1,\"a\"]");
        Assert.Multiple(() => {
            Assert.That(list.Tags[0], Is.EqualTo(new CompoundTag(("", new IntegerTag(1)))));
            Assert.That(list.Tags[1], Is.EqualTo(new CompoundTag(("", new StringTag("a")))));
        });
    }

    [Test]
    public void TestEscapesAndBuiltins() {
        Assert.Multiple(() => {
            Assert.That(Parse("\"a\\nb\\u0041\""), Is.EqualTo(new StringTag("a\nbA")));
            Assert.That(Parse("bool(2)"), Is.EqualTo(new ByteTag(1)));
            Assert.That(Parse("uuid(\"00000001-0002-0003-0004-000000000005\")"), Is.EqualTo(new ArrayTag<int>(1, 2 << 16 | 3, 4 << 16, 5)));
        });
    }

    [Test]
    public void TestAsArgumentStopsAtTheValue() {
        StringReader reader = new("{a:1} rest");
        CompoundTag tag = TagParser.ParseCompoundAsArgument(reader);
        Assert.Multiple(() => {
            Assert.That(tag["a"], Is.EqualTo(new IntegerTag(1)));
            Assert.That(reader.Cursor, Is.EqualTo(5));
        });
    }

    /// <summary>Only the errors of the parse that got furthest survive, and the first of those is thrown.</summary>
    [Test]
    public void TestFurthestErrorIsThrownAtItsPosition() {
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => Parse("[B;300]"))!;
        Assert.Multiple(() => {
            Assert.That(TranslationKey(e), Is.EqualTo("snbt.parser.number_parse_failure"));
            Assert.That(e.Cursor, Is.EqualTo(7));
            Assert.That(e.Message, Does.Contain("Value out of range. Value:\"300\" Radix:10"));
        });
    }

    [Test]
    public void TestUnclosedCompoundSuggestsTheClose() {
        Suggestions suggestions = new NbtTagArgument().ListSuggestions<object>(null!, new SuggestionsBuilder("{a:1", 0)).Result;
        Assert.Multiple(() => {
            Assert.That(suggestions.Range.Start, Is.EqualTo(4));
            Assert.That(suggestions.List.Select(s => s.Text), Is.SupersetOf(new[] { ",", "}", ".", "e", "b", "L" }));
        });
    }

    [Test]
    public void TestExpectedCompound() {
        Assert.Throws<CommandSyntaxException>(() => new CompoundTagArgument().Parse(new StringReader("[1]")));
    }

    [Test]
    public void TestNbtPathNodes() {
        NbtPathArgument.NbtPath path = new NbtPathArgument().Parse(new StringReader("foo.bar[0].\"q k\"{x:1}[] next"));
        Assert.Multiple(() => {
            Assert.That(path.Original, Is.EqualTo("foo.bar[0].\"q k\"{x:1}[]"));
            Assert.That(path.Nodes, Has.Count.EqualTo(5));
            Assert.That(path.Nodes[2], Is.EqualTo(new NbtPathArgument.IndexedElementNode(0)));
        });
    }
}
