namespace ClientLib.Brigadier;

/// <summary>Brigadier's <c>BoolArgumentType</c>.</summary>
public sealed class BoolArgumentType : ArgumentType<bool> {
    public static BoolArgumentType Bool() => new();

    public override bool Parse(StringReader reader) => reader.ReadBoolean();

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        if ("true".StartsWith(builder.RemainingLowerCase, StringComparison.Ordinal)) {
            builder.Suggest("true");
        }
        if ("false".StartsWith(builder.RemainingLowerCase, StringComparison.Ordinal)) {
            builder.Suggest("false");
        }
        return builder.BuildFuture();
    }
}

/// <summary>The bounds check every numeric brigadier type runs after reading: the cursor goes back to the number's start.</summary>
internal static class NumberBounds {
    public static T Check<T>(StringReader reader, int start, T result, T minimum, T maximum,
        Dynamic2CommandExceptionType tooLow, Dynamic2CommandExceptionType tooHigh) where T : IComparable<T> {
        if (result.CompareTo(minimum) < 0) {
            reader.Cursor = start;
            throw tooLow.CreateWithContext(reader, result, minimum);
        }
        if (result.CompareTo(maximum) > 0) {
            reader.Cursor = start;
            throw tooHigh.CreateWithContext(reader, result, maximum);
        }
        return result;
    }
}

/// <summary>Brigadier's <c>IntegerArgumentType</c>.</summary>
public sealed class IntegerArgumentType(int minimum = int.MinValue, int maximum = int.MaxValue) : ArgumentType<int> {
    public override int Parse(StringReader reader) {
        int start = reader.Cursor;
        IBuiltInExceptionProvider errors = CommandSyntaxException.BuiltInExceptions;
        return NumberBounds.Check(reader, start, reader.ReadInt(), minimum, maximum, errors.IntegerTooLow, errors.IntegerTooHigh);
    }
}

/// <summary>Brigadier's <c>LongArgumentType</c>.</summary>
public sealed class LongArgumentType(long minimum = long.MinValue, long maximum = long.MaxValue) : ArgumentType<long> {
    public override long Parse(StringReader reader) {
        int start = reader.Cursor;
        IBuiltInExceptionProvider errors = CommandSyntaxException.BuiltInExceptions;
        return NumberBounds.Check(reader, start, reader.ReadLong(), minimum, maximum, errors.LongTooLow, errors.LongTooHigh);
    }
}

/// <summary>Brigadier's <c>FloatArgumentType</c>.</summary>
public sealed class FloatArgumentType(float minimum = -float.MaxValue, float maximum = float.MaxValue) : ArgumentType<float> {
    public override float Parse(StringReader reader) {
        int start = reader.Cursor;
        IBuiltInExceptionProvider errors = CommandSyntaxException.BuiltInExceptions;
        return NumberBounds.Check(reader, start, reader.ReadFloat(), minimum, maximum, errors.FloatTooLow, errors.FloatTooHigh);
    }
}

/// <summary>Brigadier's <c>DoubleArgumentType</c>.</summary>
public sealed class DoubleArgumentType(double minimum = -double.MaxValue, double maximum = double.MaxValue) : ArgumentType<double> {
    public override double Parse(StringReader reader) {
        int start = reader.Cursor;
        IBuiltInExceptionProvider errors = CommandSyntaxException.BuiltInExceptions;
        return NumberBounds.Check(reader, start, reader.ReadDouble(), minimum, maximum, errors.DoubleTooLow, errors.DoubleTooHigh);
    }
}

/// <summary>Brigadier's <c>StringArgumentType</c>.</summary>
public sealed class StringArgumentType : ArgumentType<string> {
    public enum StringType {
        SingleWord,
        QuotablePhrase,
        GreedyPhrase
    }

    private StringArgumentType(StringType type) {
        Type = type;
    }

    public StringType Type { get; }

    public static StringArgumentType Word() => new(StringType.SingleWord);
    public static StringArgumentType String() => new(StringType.QuotablePhrase);
    public static StringArgumentType GreedyString() => new(StringType.GreedyPhrase);

    public override string Parse(StringReader reader) {
        if (Type == StringType.GreedyPhrase) {
            string text = reader.Remaining;
            reader.Cursor = reader.TotalLength;
            return text;
        }
        return Type == StringType.SingleWord ? reader.ReadUnquotedString() : reader.ReadString();
    }

    public override string ToString() => "string()";
}
