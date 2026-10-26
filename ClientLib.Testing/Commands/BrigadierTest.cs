using ClientLib.Brigadier;
using ClientLib.Commands;
using ClientLib.Commands.Arguments;
using StringReader = ClientLib.Brigadier.StringReader;

namespace ClientLib.Testing.Commands;

/// <summary>
/// Expected values follow brigadier 1.3.10 and vanilla's argument types read by hand: where the cursor
/// lands after a parse or an error is what the chat screen colours and points at.
/// </summary>
public class BrigadierTest {
    private static CommandDispatcher<object> Dispatcher() {
        CommandDispatcher<object> dispatcher = new();
        CommandNode<object> teleport = LiteralArgumentBuilder<object>.LiteralOf("teleport")
            .Then(RequiredArgumentBuilder<object>.Argument("x", new IntegerArgumentType(-10, 10))
                .Then(RequiredArgumentBuilder<object>.Argument("y", new IntegerArgumentType())
                    .Executes(_ => 0).Build()).Build())
            .Build();
        dispatcher.Root.AddChild(teleport);
        dispatcher.Root.AddChild(LiteralArgumentBuilder<object>.LiteralOf("tell")
            .Then(RequiredArgumentBuilder<object>.Argument("message", StringArgumentType.GreedyString()).Executes(_ => 0).Build())
            .Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<object>.LiteralOf("time").Executes(_ => 0).Build());
        dispatcher.Root.AddChild(LiteralArgumentBuilder<object>.LiteralOf("execute")
            .Then(LiteralArgumentBuilder<object>.LiteralOf("run").Redirect(dispatcher.Root).Build())
            .Build());
        return dispatcher;
    }

    [Test]
    public void ParseConsumesEveryArgument() {
        ParseResults<object> parse = Dispatcher().Parse("teleport 5 -3", new object());
        Assert.Multiple(() => {
            Assert.That(parse.Reader.CanRead(), Is.False);
            Assert.That(parse.Exceptions, Is.Empty);
            Assert.That(parse.Context.Command, Is.Not.Null);
            Assert.That(parse.Context.Arguments["x"].Range, Is.EqualTo(new StringRange(9, 10)));
            Assert.That(parse.Context.Arguments["y"].Result, Is.EqualTo(-3));
        });
    }

    [Test]
    public void ArgumentBelowMinimumPointsAtItsStart() {
        ParseResults<object> parse = Dispatcher().Parse("teleport -11 0", new object());
        CommandSyntaxException e = parse.Exceptions.Values.Single();
        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(CommandSyntaxException.BuiltInExceptions.IntegerTooLow));
            Assert.That(e.Cursor, Is.EqualTo(9));
            Assert.That(parse.Reader.Cursor, Is.EqualTo(9));
        });
    }

    [Test]
    public void UnknownCommandIsReportedAtTheStart() {
        ParseResults<object> parse = Dispatcher().Parse("nope", new object());
        CommandSyntaxException? e = CommandsUtil.GetParseException(parse);
        Assert.Multiple(() => {
            Assert.That(parse.Exceptions, Is.Empty);
            Assert.That(e!.Type, Is.SameAs(CommandSyntaxException.BuiltInExceptions.DispatcherUnknownCommand));
            Assert.That(e.Cursor, Is.EqualTo(0));
            Assert.That(e.Context, Is.EqualTo("<--[HERE]"));
        });
    }

    [Test]
    public void LiteralCompletionsAreSortedAndReplaceTheWord() {
        CommandDispatcher<object> dispatcher = Dispatcher();
        Suggestions suggestions = dispatcher.GetCompletionSuggestions(dispatcher.Parse("t", new object())).Result;
        Assert.Multiple(() => {
            Assert.That(suggestions.List.Select(s => s.Text), Is.EqualTo(new[] { "teleport", "tell", "time" }));
            Assert.That(suggestions.Range, Is.EqualTo(new StringRange(0, 1)));
        });
    }

    [Test]
    public void SuggestionsAfterARedirectComeFromItsTarget() {
        CommandDispatcher<object> dispatcher = Dispatcher();
        Suggestions suggestions = dispatcher.GetCompletionSuggestions(dispatcher.Parse("execute run te", new object())).Result;
        Assert.That(suggestions.List.Select(s => s.Text), Is.EqualTo(new[] { "teleport", "tell" }));
        Assert.That(suggestions.Range, Is.EqualTo(new StringRange(12, 14)));
    }

    [Test]
    public void SmartUsageListsAlternativesAndOptionalTails() {
        CommandDispatcher<object> dispatcher = Dispatcher();
        Dictionary<string, string> usage = dispatcher.GetSmartUsage(dispatcher.Root, new object())
            .ToDictionary(e => e.Key.Name, e => e.Value);
        Assert.Multiple(() => {
            Assert.That(usage["teleport"], Is.EqualTo("teleport <x> <y>"));
            Assert.That(usage["tell"], Is.EqualTo("tell <message>"));
            Assert.That(usage["time"], Is.EqualTo("time"));
            Assert.That(usage["execute"], Is.EqualTo("execute run ..."));
        });
    }

    [Test]
    public void QuotedStringEscapes() {
        StringReader reader = new("\"a\\\"b\\\\c\" rest");
        Assert.That(reader.ReadString(), Is.EqualTo("a\"b\\c"));
        Assert.That(reader.Cursor, Is.EqualTo(9));

        StringReader bad = new("\"a\\x\"");
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => bad.ReadString())!;
        Assert.That(e.Cursor, Is.EqualTo(3));
    }

    [Test]
    public void InvalidNumberResetsTheCursor() {
        StringReader reader = new("1.2.3");
        CommandSyntaxException e = Assert.Throws<CommandSyntaxException>(() => reader.ReadDouble())!;
        Assert.Multiple(() => {
            Assert.That(e.Type, Is.SameAs(CommandSyntaxException.BuiltInExceptions.ReaderInvalidDouble));
            Assert.That(e.Cursor, Is.EqualTo(0));
        });
    }

    [Test]
    public void JavaNumberPrinting() {
        Assert.Multiple(() => {
            Assert.That(JavaText.ToString(1.0), Is.EqualTo("1.0"));
            Assert.That(JavaText.ToString(0.001), Is.EqualTo("0.001"));
            Assert.That(JavaText.ToString(1e7), Is.EqualTo("1.0E7"));
            Assert.That(JavaText.ToString(1.5e-4), Is.EqualTo("1.5E-4"));
            Assert.That(JavaText.ToString(-1234.5f), Is.EqualTo("-1234.5"));
            Assert.That(JavaText.ToString(-double.MaxValue), Is.EqualTo("-1.7976931348623157E308"));
            Assert.That(JavaText.FormatFixed(1.005, 2), Is.EqualTo("1.01"));
            Assert.That(JavaText.Round(2.5f), Is.EqualTo(3));
            Assert.That(JavaText.Round(-2.5f), Is.EqualTo(-2));
            Assert.That(JavaText.Round(0.49999997f), Is.EqualTo(0));
        });
    }

    [Test]
    public void TimeUnitsAndTheirSuggestions() {
        TimeArgument time = new(0);
        Assert.That(time.Parse(new StringReader("1.5d")), Is.EqualTo(36000));
        Assert.That(time.Parse(new StringReader("3")), Is.EqualTo(3));
        StringReader bad = new("2x");
        Assert.Throws<CommandSyntaxException>(() => time.Parse(bad));

        CommandContext<object> context = new CommandContextBuilder<object>(new CommandDispatcher<object>(), new object(), new RootCommandNode<object>(), 0).Build("5");
        Suggestions units = time.ListSuggestions(context, new SuggestionsBuilder("5", 0)).Result;
        Assert.That(units.List.Select(s => s.Text), Is.EqualTo(new[] { "d", "s", "t" }));
        Assert.That(units.Range, Is.EqualTo(new StringRange(1, 1)));
    }

    [Test]
    public void BlockPositions() {
        BlockPosArgument pos = new();
        StringReader reader = new("~ ~1 5 tail");
        ICoordinates coordinates = pos.Parse(reader);
        Assert.Multiple(() => {
            Assert.That(reader.Cursor, Is.EqualTo(6));
            Assert.That(coordinates.IsXRelative && coordinates.IsYRelative && !coordinates.IsZRelative, Is.True);
        });

        CommandSyntaxException incomplete = Assert.Throws<CommandSyntaxException>(() => pos.Parse(new StringReader("1 2")))!;
        Assert.Multiple(() => {
            Assert.That(incomplete.Type, Is.SameAs(Vec3Argument.ErrorNotComplete));
            Assert.That(incomplete.Cursor, Is.EqualTo(0));
        });

        CommandSyntaxException mixed = Assert.Throws<CommandSyntaxException>(() => pos.Parse(new StringReader("^ ~ ^")))!;
        Assert.That(mixed.Type, Is.SameAs(Vec3Argument.ErrorMixedType));
    }

    [Test]
    public void Vec3CentresWholeHorizontalCoordinates() {
        WorldCoordinates coordinates = (WorldCoordinates)new Vec3Argument(true).Parse(new StringReader("1 2 3.0"));
        Assert.Multiple(() => {
            Assert.That(coordinates.X.Value, Is.EqualTo(1.5));
            Assert.That(coordinates.Y.Value, Is.EqualTo(2.0));
            Assert.That(coordinates.Z.Value, Is.EqualTo(3.0));
        });
    }

    [Test]
    public void UuidsParseAsJavaDoes() {
        UuidArgument uuid = new();
        StringReader reader = new("1-2-3-4-5 x");
        Assert.That(uuid.Parse(reader), Is.EqualTo(Guid.Parse("00000001-0002-0003-0004-000000000005")));
        Assert.That(reader.Cursor, Is.EqualTo(9));
        Assert.Throws<CommandSyntaxException>(() => uuid.Parse(new StringReader("1-2-3-4")));
    }

    [Test]
    public void ResourceFilteringMatchesAfterSplitters() {
        Assert.Multiple(() => {
            Assert.That(SharedSuggestionProvider.MatchesSubStr("st", "stone"), Is.True);
            Assert.That(SharedSuggestionProvider.MatchesSubStr("st", "mossy_stone_bricks"), Is.True);
            Assert.That(SharedSuggestionProvider.MatchesSubStr("ton", "stone"), Is.False);
        });
        SuggestionsBuilder builder = new("#mine", 0);
        // Without a colon the text matches the namespace too, so both tags pass.
        Suggestions tags = SharedSuggestionProvider.SuggestResource(["minecraft:mineable/pickaxe", "minecraft:logs"], builder, "#").Result;
        Assert.That(tags.List.Select(s => s.Text), Is.EqualTo(new[] { "#minecraft:logs", "#minecraft:mineable/pickaxe" }));
    }
}
