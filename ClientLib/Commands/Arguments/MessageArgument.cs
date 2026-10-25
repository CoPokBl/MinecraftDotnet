using ClientLib.Brigadier;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>MessageArgument</c>, the one argument a player signs.</summary>
public sealed class MessageArgument : ArgumentType<MessageArgument.Message>, Chat.ISignedArgument {
    private static readonly string[] ExampleValues = ["Hello world!", "foo", "@e", "Hello @p :)"];

    private static readonly Dynamic2CommandExceptionType TooLong =
        new((length, maxLength) => Component.TranslatableEscape("argument.message.too_long", length, maxLength));

    public override Message Parse(StringReader reader) => Message.ParseText(reader, true);

    public override Message Parse<TSource>(StringReader reader, TSource source) => Message.ParseText(reader, EntitySelectorParser.AllowSelectors(source));

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    public sealed record Message(string Text, Part[] Parts) {
        public static Message ParseText(StringReader reader, bool allowSelectors) {
            if (reader.RemainingLength > 256) {
                throw TooLong.Create(reader.RemainingLength, 256);
            }
            string text = reader.Remaining;
            if (!allowSelectors) {
                reader.Cursor = reader.TotalLength;
                return new Message(text, []);
            }
            List<Part> result = [];
            int offset = reader.Cursor;
            while (reader.CanRead()) {
                if (reader.Peek() != '@') {
                    reader.Skip();
                    continue;
                }
                int start = reader.Cursor;
                EntitySelector parse;
                try {
                    parse = new EntitySelectorParser(reader, true).Parse();
                }
                catch (CommandSyntaxException e) when (e.Type == EntitySelectorParser.ErrorMissingSelectorType
                                                       || e.Type == EntitySelectorParser.ErrorUnknownSelectorType) {
                    reader.Cursor = start + 1;
                    continue;
                }
                result.Add(new Part(start - offset, reader.Cursor - offset, parse));
            }
            return new Message(text, result.ToArray());
        }
    }

    public sealed record Part(int Start, int End, EntitySelector Selector);
}
