using ClientLib.Brigadier;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>MinMaxBounds</c>, as far as command parsing reads one.</summary>
public static class MinMaxBounds {
    public static readonly SimpleCommandExceptionType ErrorEmpty = new(Component.Translatable("argument.range.empty"));
    public static readonly SimpleCommandExceptionType ErrorSwapped = new(Component.Translatable("argument.range.swapped"));

    /// <summary>Java's <c>Function&lt;String, T&gt;</c> converter, failing where Java throws <c>NumberFormatException</c>.</summary>
    public delegate bool NumberConverter<T>(string s, out T value);

    /// <summary><c>MinMaxBounds.Bounds</c>.</summary>
    public readonly record struct Bounds<T>(T? Min, T? Max) where T : struct, IComparable<T> {
        public bool AreSwapped => Min is { } min && Max is { } max && min.CompareTo(max) > 0;

        public static Bounds<T> FromReader(StringReader reader, NumberConverter<T> converter, Func<DynamicCommandExceptionType> parseExc) {
            if (!reader.CanRead()) {
                throw ErrorEmpty.CreateWithContext(reader);
            }
            int start = reader.Cursor;
            try {
                T? min = ReadNumber(reader, converter, parseExc);
                T? max;
                if (reader.CanRead(2) && reader.Peek() == '.' && reader.Peek(1) == '.') {
                    reader.Skip();
                    reader.Skip();
                    max = ReadNumber(reader, converter, parseExc);
                }
                else {
                    max = min;
                }
                if (min == null && max == null) {
                    throw ErrorEmpty.CreateWithContext(reader);
                }
                return new Bounds<T>(min, max);
            }
            catch (CommandSyntaxException e) {
                // The rethrow keeps the message and moves the cursor back to the start of the range.
                reader.Cursor = start;
                throw new CommandSyntaxException(e.Type, e.RawMessage, e.Input!, start);
            }
        }

        public static Bounds<T> FromReaderUnswapped(StringReader reader, NumberConverter<T> converter, Func<DynamicCommandExceptionType> parseExc) {
            int start = reader.Cursor;
            Bounds<T> bounds = FromReader(reader, converter, parseExc);
            if (bounds.AreSwapped) {
                reader.Cursor = start;
                throw ErrorSwapped.CreateWithContext(reader);
            }
            return bounds;
        }

        private static T? ReadNumber(StringReader reader, NumberConverter<T> converter, Func<DynamicCommandExceptionType> parseExc) {
            int start = reader.Cursor;
            while (reader.CanRead() && IsAllowedInputChar(reader)) {
                reader.Skip();
            }
            string number = reader.String[start..reader.Cursor];
            if (number.Length == 0) {
                return null;
            }
            if (!converter(number, out T value)) {
                throw parseExc().CreateWithContext(reader, number);
            }
            return value;
        }

        private static bool IsAllowedInputChar(StringReader reader) {
            char c = reader.Peek();
            if (c is >= '0' and <= '9' or '-') {
                return true;
            }
            return c == '.' && (!reader.CanRead(2) || reader.Peek(1) != '.');
        }
    }

    /// <summary><c>MinMaxBounds.Doubles</c>.</summary>
    public sealed record Doubles(Bounds<double> Bounds) {
        public double? Min => Bounds.Min;
        public double? Max => Bounds.Max;

        public static Doubles FromReader(StringReader reader) => new(Bounds<double>.FromReaderUnswapped(reader, JavaText.TryParseDouble,
            () => CommandSyntaxException.BuiltInExceptions.ReaderInvalidDouble));
    }

    /// <summary><c>MinMaxBounds.FloatDegrees</c>. Unlike the other two it accepts swapped bounds: a rotation range may wrap.</summary>
    public sealed record FloatDegrees(Bounds<float> Bounds) {
        public float? Min => Bounds.Min;
        public float? Max => Bounds.Max;

        public static FloatDegrees FromReader(StringReader reader) => new(Bounds<float>.FromReader(reader, JavaText.TryParseFloat,
            () => CommandSyntaxException.BuiltInExceptions.ReaderInvalidFloat));
    }

    /// <summary><c>MinMaxBounds.Ints</c>.</summary>
    public sealed record Ints(Bounds<int> Bounds) {
        public int? Min => Bounds.Min;
        public int? Max => Bounds.Max;

        public static Ints FromReader(StringReader reader) => new(Bounds<int>.FromReaderUnswapped(reader, JavaText.TryParseInt,
            () => CommandSyntaxException.BuiltInExceptions.ReaderInvalidInt));
    }
}

/// <summary>Vanilla's <c>RangeArgument</c>.</summary>
public static class RangeArgument {
    /// <summary><c>RangeArgument.Floats</c>, which parses doubles despite its name.</summary>
    public sealed class Floats : ArgumentType<MinMaxBounds.Doubles> {
        private static readonly string[] ExampleValues = ["0..5.2", "0", "-5.4", "-100.76..", "..100"];

        public override MinMaxBounds.Doubles Parse(StringReader reader) => MinMaxBounds.Doubles.FromReader(reader);

        public override IReadOnlyCollection<string> Examples => ExampleValues;
    }

    /// <summary><c>RangeArgument.Ints</c>.</summary>
    public sealed class Ints : ArgumentType<MinMaxBounds.Ints> {
        private static readonly string[] ExampleValues = ["0..5", "0", "-5", "-100..", "..100"];

        public override MinMaxBounds.Ints Parse(StringReader reader) => MinMaxBounds.Ints.FromReader(reader);

        public override IReadOnlyCollection<string> Examples => ExampleValues;
    }
}
