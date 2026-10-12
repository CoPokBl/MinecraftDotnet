using ClientLib.Commands;
using Minecraft.Text;

namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>CommandExceptionType</c>: what an exception is, compared by reference.</summary>
public interface ICommandExceptionType;

/// <summary>Brigadier's <c>CommandSyntaxException</c>, with a component for its message as vanilla's are.</summary>
public class CommandSyntaxException : Exception {
    public const int ContextAmount = 10;

    /// <summary>Vanilla swaps in <c>BrigadierExceptions</c> at bootstrap, so brigadier's own messages are never shown.</summary>
    public static IBuiltInExceptionProvider BuiltInExceptions { get; set; } = new BrigadierExceptions();

    public ICommandExceptionType Type { get; }
    public TextComponent RawMessage { get; }
    public string? Input { get; }
    public int Cursor { get; }

    public CommandSyntaxException(ICommandExceptionType type, TextComponent message, string? input = null, int cursor = -1)
        : base(TextFlattener.Plain(message)) {
        Type = type;
        RawMessage = message;
        Input = input;
        Cursor = cursor;
    }

    public override string Message {
        get {
            string message = TextFlattener.Plain(RawMessage);
            return Context is { } context ? message + " at position " + Cursor + ": " + context : message;
        }
    }

    public string? Context {
        get {
            if (Input == null || Cursor < 0) {
                return null;
            }
            int cursor = Math.Min(Input.Length, Cursor);
            return (cursor > ContextAmount ? "..." : "") + Input[Math.Max(0, cursor - ContextAmount)..cursor] + "<--[HERE]";
        }
    }
}

/// <summary>Brigadier's <c>SimpleCommandExceptionType</c>.</summary>
public sealed class SimpleCommandExceptionType(TextComponent message) : ICommandExceptionType {
    public CommandSyntaxException Create() => new(this, message);

    public CommandSyntaxException CreateWithContext(IImmutableStringReader reader) => new(this, message, reader.String, reader.Cursor);

    public override string ToString() => TextFlattener.Plain(message);
}

/// <summary>Brigadier's <c>DynamicCommandExceptionType</c>.</summary>
public sealed class DynamicCommandExceptionType(Func<object, TextComponent> function) : ICommandExceptionType {
    public CommandSyntaxException Create(object arg) => new(this, function(arg));

    public CommandSyntaxException CreateWithContext(IImmutableStringReader reader, object arg) => new(this, function(arg), reader.String, reader.Cursor);
}

/// <summary>Brigadier's <c>Dynamic2CommandExceptionType</c>.</summary>
public sealed class Dynamic2CommandExceptionType(Func<object, object, TextComponent> function) : ICommandExceptionType {
    public CommandSyntaxException Create(object a, object b) => new(this, function(a, b));

    public CommandSyntaxException CreateWithContext(IImmutableStringReader reader, object a, object b) => new(this, function(a, b), reader.String, reader.Cursor);
}

/// <summary>Brigadier's <c>Dynamic3CommandExceptionType</c>.</summary>
public sealed class Dynamic3CommandExceptionType(Func<object, object, object, TextComponent> function) : ICommandExceptionType {
    public CommandSyntaxException Create(object a, object b, object c) => new(this, function(a, b, c));

    public CommandSyntaxException CreateWithContext(IImmutableStringReader reader, object a, object b, object c) =>
        new(this, function(a, b, c), reader.String, reader.Cursor);
}

/// <summary>Brigadier's <c>BuiltInExceptionProvider</c>.</summary>
public interface IBuiltInExceptionProvider {
    Dynamic2CommandExceptionType DoubleTooLow { get; }
    Dynamic2CommandExceptionType DoubleTooHigh { get; }
    Dynamic2CommandExceptionType FloatTooLow { get; }
    Dynamic2CommandExceptionType FloatTooHigh { get; }
    Dynamic2CommandExceptionType IntegerTooLow { get; }
    Dynamic2CommandExceptionType IntegerTooHigh { get; }
    Dynamic2CommandExceptionType LongTooLow { get; }
    Dynamic2CommandExceptionType LongTooHigh { get; }
    DynamicCommandExceptionType LiteralIncorrect { get; }
    SimpleCommandExceptionType ReaderExpectedStartOfQuote { get; }
    SimpleCommandExceptionType ReaderExpectedEndOfQuote { get; }
    DynamicCommandExceptionType ReaderInvalidEscape { get; }
    DynamicCommandExceptionType ReaderInvalidBool { get; }
    DynamicCommandExceptionType ReaderInvalidInt { get; }
    SimpleCommandExceptionType ReaderExpectedInt { get; }
    DynamicCommandExceptionType ReaderInvalidLong { get; }
    SimpleCommandExceptionType ReaderExpectedLong { get; }
    DynamicCommandExceptionType ReaderInvalidDouble { get; }
    SimpleCommandExceptionType ReaderExpectedDouble { get; }
    DynamicCommandExceptionType ReaderInvalidFloat { get; }
    SimpleCommandExceptionType ReaderExpectedFloat { get; }
    SimpleCommandExceptionType ReaderExpectedBool { get; }
    DynamicCommandExceptionType ReaderExpectedSymbol { get; }
    SimpleCommandExceptionType DispatcherUnknownCommand { get; }
    SimpleCommandExceptionType DispatcherUnknownArgument { get; }
    SimpleCommandExceptionType DispatcherExpectedArgumentSeparator { get; }
    DynamicCommandExceptionType DispatcherParseException { get; }
}
