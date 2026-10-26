using ClientLib.Brigadier;

namespace ClientLib.Commands;

/// <summary>Vanilla's <c>BrigadierExceptions</c>.</summary>
public sealed class BrigadierExceptions : IBuiltInExceptionProvider {
    public Dynamic2CommandExceptionType DoubleTooLow { get; } = new((found, min) => Component.TranslatableEscape("argument.double.low", min, found));
    public Dynamic2CommandExceptionType DoubleTooHigh { get; } = new((found, max) => Component.TranslatableEscape("argument.double.big", max, found));
    public Dynamic2CommandExceptionType FloatTooLow { get; } = new((found, min) => Component.TranslatableEscape("argument.float.low", min, found));
    public Dynamic2CommandExceptionType FloatTooHigh { get; } = new((found, max) => Component.TranslatableEscape("argument.float.big", max, found));
    public Dynamic2CommandExceptionType IntegerTooLow { get; } = new((found, min) => Component.TranslatableEscape("argument.integer.low", min, found));
    public Dynamic2CommandExceptionType IntegerTooHigh { get; } = new((found, max) => Component.TranslatableEscape("argument.integer.big", max, found));
    public Dynamic2CommandExceptionType LongTooLow { get; } = new((found, min) => Component.TranslatableEscape("argument.long.low", min, found));
    public Dynamic2CommandExceptionType LongTooHigh { get; } = new((found, max) => Component.TranslatableEscape("argument.long.big", max, found));
    public DynamicCommandExceptionType LiteralIncorrect { get; } = new(expected => Component.TranslatableEscape("argument.literal.incorrect", expected));
    public SimpleCommandExceptionType ReaderExpectedStartOfQuote { get; } = new(Component.Translatable("parsing.quote.expected.start"));
    public SimpleCommandExceptionType ReaderExpectedEndOfQuote { get; } = new(Component.Translatable("parsing.quote.expected.end"));
    public DynamicCommandExceptionType ReaderInvalidEscape { get; } = new(character => Component.TranslatableEscape("parsing.quote.escape", character));
    public DynamicCommandExceptionType ReaderInvalidBool { get; } = new(value => Component.TranslatableEscape("parsing.bool.invalid", value));
    public DynamicCommandExceptionType ReaderInvalidInt { get; } = new(value => Component.TranslatableEscape("parsing.int.invalid", value));
    public SimpleCommandExceptionType ReaderExpectedInt { get; } = new(Component.Translatable("parsing.int.expected"));
    public DynamicCommandExceptionType ReaderInvalidLong { get; } = new(value => Component.TranslatableEscape("parsing.long.invalid", value));
    public SimpleCommandExceptionType ReaderExpectedLong { get; } = new(Component.Translatable("parsing.long.expected"));
    public DynamicCommandExceptionType ReaderInvalidDouble { get; } = new(value => Component.TranslatableEscape("parsing.double.invalid", value));
    public SimpleCommandExceptionType ReaderExpectedDouble { get; } = new(Component.Translatable("parsing.double.expected"));
    public DynamicCommandExceptionType ReaderInvalidFloat { get; } = new(value => Component.TranslatableEscape("parsing.float.invalid", value));
    public SimpleCommandExceptionType ReaderExpectedFloat { get; } = new(Component.Translatable("parsing.float.expected"));
    public SimpleCommandExceptionType ReaderExpectedBool { get; } = new(Component.Translatable("parsing.bool.expected"));
    public DynamicCommandExceptionType ReaderExpectedSymbol { get; } = new(symbol => Component.TranslatableEscape("parsing.expected", symbol));
    public SimpleCommandExceptionType DispatcherUnknownCommand { get; } = new(Component.Translatable("command.unknown.command"));
    public SimpleCommandExceptionType DispatcherUnknownArgument { get; } = new(Component.Translatable("command.unknown.argument"));
    public SimpleCommandExceptionType DispatcherExpectedArgumentSeparator { get; } = new(Component.Translatable("command.expected.separator"));
    public DynamicCommandExceptionType DispatcherParseException { get; } = new(message => Component.TranslatableEscape("command.exception", message));
}
