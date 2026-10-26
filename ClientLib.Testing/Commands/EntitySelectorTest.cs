using ClientLib.Brigadier;
using ClientLib.Commands.Arguments;
using Minecraft.Data.Generated;
using StringReader = ClientLib.Brigadier.StringReader;

namespace ClientLib.Testing.Commands;

public class EntitySelectorTest {
    [Test]
    public void TestSelectorWithOptionsConsumesExactlyTheSelector() {
        StringReader reader = new("@e[type=cow,limit=1,distance=..5] rest");
        EntitySelector selector = new EntitySelectorParser(reader, true).Parse();

        Assert.Multiple(() => {
            Assert.That(reader.Cursor, Is.EqualTo("@e[type=cow,limit=1,distance=..5]".Length));
            Assert.That(selector.MaxResults, Is.EqualTo(1));
            Assert.That(selector.IncludesEntities, Is.True);
            Assert.That(selector.Type?.Identifier, Is.EqualTo(EntityType.Cow.Identifier));
            Assert.That(selector.Range?.Max, Is.EqualTo(5.0));
            Assert.That(selector.Range?.Min, Is.Null);
            Assert.That(selector.IsWorldLimited, Is.True);
            Assert.That(selector.UsesSelector, Is.True);
        });
    }

    [Test]
    public void TestUnknownOptionRewindsToTheKey() {
        StringReader reader = new("@e[limit=2,foo=1]");
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new EntitySelectorParser(reader, true).Parse())!;

        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(EntitySelectorOptions.ErrorUnknownOption));
            Assert.That(e.Cursor, Is.EqualTo("@e[limit=2,".Length));
        });
    }

    [Test]
    public void TestRepeatedLimitIsInapplicable() {
        StringReader reader = new("@e[limit=2,limit=3]");
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new EntitySelectorParser(reader, true).Parse())!;
        Assert.That(e.Type, Is.SameAs(EntitySelectorOptions.ErrorInapplicableOption));
    }

    [Test]
    public void TestOptionNamesAreSuggestedAfterTheOpeningBracket() {
        StringReader reader = new("@e[");
        EntitySelectorParser parser = new(reader, true);
        Assert.Throws<CommandSyntaxException>(() => parser.Parse());

        Suggestions suggestions = parser.FillSuggestions(new SuggestionsBuilder("@e[", 0), _ => { }).Result;
        List<string> texts = suggestions.List.Select(s => s.Text).ToList();

        Assert.Multiple(() => {
            Assert.That(suggestions.Range.Start, Is.EqualTo(3));
            Assert.That(texts, Does.Not.Contain("]"), "parseOptions replaces suggestOptionsKeyOrClose before reading anything");
            Assert.That(texts, Does.Contain("limit="));
            Assert.That(texts, Does.Contain("type="));
            Assert.That(texts, Does.Contain("distance="));
        });
    }

    [Test]
    public void TestLimitIsNotOfferedOnTheCurrentEntity() {
        StringReader reader = new("@s[");
        EntitySelectorParser parser = new(reader, true);
        Assert.Throws<CommandSyntaxException>(() => parser.Parse());

        List<string> texts = parser.FillSuggestions(new SuggestionsBuilder("@s[", 0), _ => { }).Result.List.Select(s => s.Text).ToList();
        Assert.That(texts, Does.Not.Contain("limit="));
    }

    [Test]
    public void TestPlayerNameParse() {
        StringReader reader = new("Steve rest");
        EntitySelector selector = new EntitySelectorParser(reader, false).Parse();

        Assert.Multiple(() => {
            Assert.That(reader.Cursor, Is.EqualTo(5));
            Assert.That(selector.PlayerName, Is.EqualTo("Steve"));
            Assert.That(selector.IncludesEntities, Is.False);
            Assert.That(selector.MaxResults, Is.EqualTo(1));
            Assert.That(selector.UsesSelector, Is.False);
        });
    }

    [Test]
    public void TestLooseUuidNamesAnEntity() {
        EntitySelector selector = new EntitySelectorParser(new StringReader("1-2-3-4-5"), false).Parse();

        Assert.Multiple(() => {
            Assert.That(selector.EntityUuid, Is.EqualTo(Guid.Parse("00000001-0002-0003-0004-000000000005")));
            Assert.That(selector.IncludesEntities, Is.True);
        });
    }

    [Test]
    public void TestSelectorsRefusedWithoutPermission() {
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new EntitySelectorParser(new StringReader("@a"), false).Parse())!;
        Assert.That(e.Type, Is.SameAs(EntitySelectorParser.ErrorSelectorsNotAllowed));
    }

    [Test]
    public void TestSingleEntityArgumentRejectsAllEntitiesAtTheStartOfTheInput() {
        StringReader reader = new("tp @e");
        reader.Cursor = 3;
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new EntityArgument(true, false).Parse(reader))!;

        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(EntityArgument.ErrorNotSingleEntity));
            Assert.That(e.Cursor, Is.EqualTo(0));
        });
    }

    [Test]
    public void TestSwappedRangeIsRefusedAtItsStart() {
        StringReader reader = new("5..3");
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new RangeArgument.Ints().Parse(reader))!;

        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(MinMaxBounds.ErrorSwapped));
            Assert.That(e.Cursor, Is.EqualTo(0));
        });
    }

    [Test]
    public void TestDecimalInIntRangeFailsAsAnInvalidInteger() {
        StringReader reader = new("x 1.5..");
        reader.Cursor = 2;
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => new RangeArgument.Ints().Parse(reader))!;

        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(CommandSyntaxException.BuiltInExceptions.ReaderInvalidInt));
            Assert.That(e.Cursor, Is.EqualTo(2));
        });
    }
}
