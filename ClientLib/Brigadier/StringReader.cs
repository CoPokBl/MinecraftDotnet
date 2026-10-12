using System.Text;

namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>ImmutableStringReader</c>.</summary>
public interface IImmutableStringReader {
    string String { get; }
    int RemainingLength { get; }
    int TotalLength { get; }
    int Cursor { get; }
    string Remaining { get; }
    bool CanRead(int length);
    bool CanRead();
    char Peek();
    char Peek(int offset);
}

/// <summary>Brigadier's <c>StringReader</c>.</summary>
public class StringReader : IImmutableStringReader {
    private const char SyntaxEscape = '\\';

    private readonly string _string;

    public StringReader(StringReader other) {
        _string = other._string;
        Cursor = other.Cursor;
    }

    public StringReader(string @string) {
        _string = @string;
    }

    public string String => _string;
    public int Cursor { get; set; }
    public int RemainingLength => _string.Length - Cursor;
    public int TotalLength => _string.Length;
    public string Remaining => _string[Cursor..];

    public bool CanRead(int length) => Cursor + length <= _string.Length;
    public bool CanRead() => CanRead(1);
    public char Peek() => _string[Cursor];
    public char Peek(int offset) => _string[Cursor + offset];

    public char ReadChar() => _string[Cursor++];

    public void Skip() => Cursor++;

    public static bool IsAllowedNumber(char c) => c is >= '0' and <= '9' or '.' or '-';

    public static bool IsQuotedStringStart(char c) => c is '"' or '\'';

    public void SkipWhitespace() {
        while (CanRead() && JavaText.IsWhitespace(Peek())) {
            Skip();
        }
    }

    private string ReadNumberToken() {
        int start = Cursor;
        while (CanRead() && IsAllowedNumber(Peek())) {
            Skip();
        }
        return _string[start..Cursor];
    }

    public int ReadInt() => ReadNumber<int>(JavaText.TryParseInt, Errors.ReaderExpectedInt, Errors.ReaderInvalidInt);

    public long ReadLong() => ReadNumber<long>(JavaText.TryParseLong, Errors.ReaderExpectedLong, Errors.ReaderInvalidLong);

    public double ReadDouble() => ReadNumber<double>(JavaText.TryParseDouble, Errors.ReaderExpectedDouble, Errors.ReaderInvalidDouble);

    public float ReadFloat() => ReadNumber<float>(JavaText.TryParseFloat, Errors.ReaderExpectedFloat, Errors.ReaderInvalidFloat);

    private static IBuiltInExceptionProvider Errors => CommandSyntaxException.BuiltInExceptions;

    private delegate bool NumberParser<T>(string s, out T value);

    /// <summary>The shared body of brigadier's four <c>readInt</c>, <c>readLong</c>, <c>readDouble</c> and <c>readFloat</c>.</summary>
    private T ReadNumber<T>(NumberParser<T> parse, SimpleCommandExceptionType expected, DynamicCommandExceptionType invalid) {
        int start = Cursor;
        string number = ReadNumberToken();
        if (number.Length == 0) {
            throw expected.CreateWithContext(this);
        }
        if (!parse(number, out T value)) {
            Cursor = start;
            throw invalid.CreateWithContext(this, number);
        }
        return value;
    }

    public static bool IsAllowedInUnquotedString(char c) => c is >= '0' and <= '9' or >= 'A' and <= 'Z' or >= 'a' and <= 'z' or '_' or '-' or '.' or '+';

    public string ReadUnquotedString() {
        int start = Cursor;
        while (CanRead() && IsAllowedInUnquotedString(Peek())) {
            Skip();
        }
        return _string[start..Cursor];
    }

    public string ReadStringUntil(char terminator) {
        StringBuilder result = new();
        bool escaped = false;
        while (CanRead()) {
            char c = ReadChar();
            if (escaped) {
                if (c != terminator && c != SyntaxEscape) {
                    Cursor--;
                    throw Errors.ReaderInvalidEscape.CreateWithContext(this, c.ToString());
                }
                result.Append(c);
                escaped = false;
            }
            else if (c == SyntaxEscape) {
                escaped = true;
            }
            else {
                if (c == terminator) {
                    return result.ToString();
                }
                result.Append(c);
            }
        }
        throw Errors.ReaderExpectedEndOfQuote.CreateWithContext(this);
    }

    public string ReadString() {
        if (!CanRead()) {
            return "";
        }
        char next = Peek();
        if (IsQuotedStringStart(next)) {
            Skip();
            return ReadStringUntil(next);
        }
        return ReadUnquotedString();
    }

    public bool ReadBoolean() {
        int start = Cursor;
        string value = ReadString();
        if (value.Length == 0) {
            throw Errors.ReaderExpectedBool.CreateWithContext(this);
        }
        if (value == "true") {
            return true;
        }
        if (value == "false") {
            return false;
        }
        Cursor = start;
        throw Errors.ReaderInvalidBool.CreateWithContext(this, value);
    }

    public void Expect(char c) {
        if (!CanRead() || Peek() != c) {
            throw Errors.ReaderExpectedSymbol.CreateWithContext(this, c.ToString());
        }
        Skip();
    }
}
