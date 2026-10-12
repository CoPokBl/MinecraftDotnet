using ClientLib.Brigadier;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>Coordinates</c>, keeping only each axis' relativity: resolving against a source is the server's job.</summary>
public interface ICoordinates {
    bool IsXRelative { get; }
    bool IsYRelative { get; }
    bool IsZRelative { get; }
}

/// <summary>Vanilla's <c>WorldCoordinate</c>.</summary>
public sealed record WorldCoordinate(bool Relative, double Value) {
    private const char PrefixRelative = '~';

    public static readonly SimpleCommandExceptionType ErrorExpectedDouble = new(Component.Translatable("argument.pos.missing.double"));
    public static readonly SimpleCommandExceptionType ErrorExpectedInt = new(Component.Translatable("argument.pos.missing.int"));

    public static WorldCoordinate ParseDouble(StringReader reader, bool center) {
        if (reader.CanRead() && reader.Peek() == '^') {
            throw Vec3Argument.ErrorMixedType.CreateWithContext(reader);
        }
        if (!reader.CanRead()) {
            throw ErrorExpectedDouble.CreateWithContext(reader);
        }
        bool relative = IsRelative(reader);
        int start = reader.Cursor;
        double value = reader.CanRead() && reader.Peek() != ' ' ? reader.ReadDouble() : 0.0;
        string number = reader.String[start..reader.Cursor];
        if (relative && number.Length == 0) {
            return new WorldCoordinate(true, 0.0);
        }
        if (!number.Contains('.') && !relative && center) {
            value += 0.5;
        }
        return new WorldCoordinate(relative, value);
    }

    public static WorldCoordinate ParseInt(StringReader reader) {
        if (reader.CanRead() && reader.Peek() == '^') {
            throw Vec3Argument.ErrorMixedType.CreateWithContext(reader);
        }
        if (!reader.CanRead()) {
            throw ErrorExpectedInt.CreateWithContext(reader);
        }
        bool relative = IsRelative(reader);
        double value = reader.CanRead() && reader.Peek() != ' ' ? (relative ? reader.ReadDouble() : reader.ReadInt()) : 0.0;
        return new WorldCoordinate(relative, value);
    }

    public static bool IsRelative(StringReader reader) {
        if (reader.Peek() == PrefixRelative) {
            reader.Skip();
            return true;
        }
        return false;
    }
}

/// <summary>Vanilla's <c>WorldCoordinates</c>.</summary>
public sealed record WorldCoordinates(WorldCoordinate X, WorldCoordinate Y, WorldCoordinate Z) : ICoordinates {
    public bool IsXRelative => X.Relative;
    public bool IsYRelative => Y.Relative;
    public bool IsZRelative => Z.Relative;

    public static WorldCoordinates ParseInt(StringReader reader) {
        int start = reader.Cursor;
        WorldCoordinate x = WorldCoordinate.ParseInt(reader);
        if (reader.CanRead() && reader.Peek() == ' ') {
            reader.Skip();
            WorldCoordinate y = WorldCoordinate.ParseInt(reader);
            if (reader.CanRead() && reader.Peek() == ' ') {
                reader.Skip();
                WorldCoordinate z = WorldCoordinate.ParseInt(reader);
                return new WorldCoordinates(x, y, z);
            }
        }
        reader.Cursor = start;
        throw Vec3Argument.ErrorNotComplete.CreateWithContext(reader);
    }

    public static WorldCoordinates ParseDouble(StringReader reader, bool centerCorrect) {
        int start = reader.Cursor;
        WorldCoordinate x = WorldCoordinate.ParseDouble(reader, centerCorrect);
        if (reader.CanRead() && reader.Peek() == ' ') {
            reader.Skip();
            WorldCoordinate y = WorldCoordinate.ParseDouble(reader, false);
            if (reader.CanRead() && reader.Peek() == ' ') {
                reader.Skip();
                WorldCoordinate z = WorldCoordinate.ParseDouble(reader, centerCorrect);
                return new WorldCoordinates(x, y, z);
            }
        }
        reader.Cursor = start;
        throw Vec3Argument.ErrorNotComplete.CreateWithContext(reader);
    }
}

/// <summary>Vanilla's <c>LocalCoordinates</c>.</summary>
public sealed record LocalCoordinates(double Left, double Up, double Forwards) : ICoordinates {
    public const char PrefixLocalCoordinate = '^';

    public bool IsXRelative => true;
    public bool IsYRelative => true;
    public bool IsZRelative => true;

    public static LocalCoordinates Parse(StringReader reader) {
        int start = reader.Cursor;
        double left = ReadDouble(reader, start);
        if (reader.CanRead() && reader.Peek() == ' ') {
            reader.Skip();
            double up = ReadDouble(reader, start);
            if (reader.CanRead() && reader.Peek() == ' ') {
                reader.Skip();
                double forwards = ReadDouble(reader, start);
                return new LocalCoordinates(left, up, forwards);
            }
        }
        reader.Cursor = start;
        throw Vec3Argument.ErrorNotComplete.CreateWithContext(reader);
    }

    private static double ReadDouble(StringReader reader, int start) {
        if (!reader.CanRead()) {
            throw WorldCoordinate.ErrorExpectedDouble.CreateWithContext(reader);
        }
        if (reader.Peek() != PrefixLocalCoordinate) {
            reader.Cursor = start;
            throw Vec3Argument.ErrorMixedType.CreateWithContext(reader);
        }
        reader.Skip();
        return reader.CanRead() && reader.Peek() != ' ' ? reader.ReadDouble() : 0.0;
    }
}

internal static class Validators {
    /// <summary>Vanilla's <c>Commands.createValidator</c>.</summary>
    public static Func<string, bool> Create<T>(Func<StringReader, T> parser) {
        return value => {
            try {
                parser(new StringReader(value));
                return true;
            }
            catch (CommandSyntaxException) {
                return false;
            }
        };
    }

    /// <summary>The <c>listSuggestions</c> the position arguments share: local coordinates after a caret, else the source's.</summary>
    public static Task<Suggestions> SuggestCoordinates<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder, bool absolute, bool twoD,
        Func<StringReader, ICoordinates> parse) {
        if (context.Source is not ISharedSuggestionProvider source) {
            return Suggestions.Empty();
        }
        string remainder = builder.Remaining;
        IReadOnlyCollection<SharedSuggestionProvider.TextCoordinates> suggestedCoordinates = remainder.Length > 0 && remainder[0] == '^'
            ? [SharedSuggestionProvider.TextCoordinates.DefaultLocal]
            : absolute ? source.AbsoluteCoordinates : source.RelevantCoordinates;
        return twoD
            ? SharedSuggestionProvider.Suggest2DCoordinates(remainder, suggestedCoordinates, builder, Create(parse))
            : SharedSuggestionProvider.SuggestCoordinates(remainder, suggestedCoordinates, builder, Create(parse));
    }
}

/// <summary>Vanilla's <c>BlockPosArgument</c>.</summary>
public sealed class BlockPosArgument : ArgumentType<ICoordinates> {
    private static readonly string[] ExampleValues = ["0 0 0", "~ ~ ~", "^ ^ ^", "^1 ^ ^-5", "~0.5 ~1 ~-5"];

    public override ICoordinates Parse(StringReader reader) {
        return reader.CanRead() && reader.Peek() == '^' ? LocalCoordinates.Parse(reader) : WorldCoordinates.ParseInt(reader);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) =>
        Validators.SuggestCoordinates(context, builder, absolute: false, twoD: false, Parse);

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ColumnPosArgument</c>.</summary>
public sealed class ColumnPosArgument : ArgumentType<ICoordinates> {
    private static readonly string[] ExampleValues = ["0 0", "~ ~", "~1 ~-2", "^ ^", "^-1 ^0"];

    public static readonly SimpleCommandExceptionType ErrorNotComplete = new(Component.Translatable("argument.pos2d.incomplete"));

    public override ICoordinates Parse(StringReader reader) {
        int start = reader.Cursor;
        if (!reader.CanRead()) {
            throw ErrorNotComplete.CreateWithContext(reader);
        }
        WorldCoordinate x = WorldCoordinate.ParseInt(reader);
        if (reader.CanRead() && reader.Peek() == ' ') {
            reader.Skip();
            WorldCoordinate z = WorldCoordinate.ParseInt(reader);
            return new WorldCoordinates(x, new WorldCoordinate(true, 0.0), z);
        }
        reader.Cursor = start;
        throw ErrorNotComplete.CreateWithContext(reader);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) =>
        Validators.SuggestCoordinates(context, builder, absolute: false, twoD: true, Parse);

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>Vec3Argument</c>.</summary>
public sealed class Vec3Argument(bool centerCorrect) : ArgumentType<ICoordinates> {
    private static readonly string[] ExampleValues = ["0 0 0", "~ ~ ~", "^ ^ ^", "^1 ^ ^-5", "0.1 -0.5 .9", "~0.5 ~1 ~-5"];

    public static readonly SimpleCommandExceptionType ErrorNotComplete = new(Component.Translatable("argument.pos3d.incomplete"));
    public static readonly SimpleCommandExceptionType ErrorMixedType = new(Component.Translatable("argument.pos.mixed"));

    public override ICoordinates Parse(StringReader reader) {
        return reader.CanRead() && reader.Peek() == '^' ? LocalCoordinates.Parse(reader) : WorldCoordinates.ParseDouble(reader, centerCorrect);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) =>
        Validators.SuggestCoordinates(context, builder, absolute: true, twoD: false, Parse);

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>Vec2Argument</c>.</summary>
public sealed class Vec2Argument(bool centerCorrect) : ArgumentType<ICoordinates> {
    private static readonly string[] ExampleValues = ["0 0", "~ ~", "0.1 -0.5", "~1 ~-2"];

    public static readonly SimpleCommandExceptionType ErrorNotComplete = new(Component.Translatable("argument.pos2d.incomplete"));

    public override ICoordinates Parse(StringReader reader) {
        int start = reader.Cursor;
        if (!reader.CanRead()) {
            throw ErrorNotComplete.CreateWithContext(reader);
        }
        WorldCoordinate x = WorldCoordinate.ParseDouble(reader, centerCorrect);
        if (reader.CanRead() && reader.Peek() == ' ') {
            reader.Skip();
            WorldCoordinate z = WorldCoordinate.ParseDouble(reader, centerCorrect);
            return new WorldCoordinates(x, new WorldCoordinate(true, 0.0), z);
        }
        reader.Cursor = start;
        throw ErrorNotComplete.CreateWithContext(reader);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) =>
        Validators.SuggestCoordinates(context, builder, absolute: true, twoD: true, Parse);

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>RotationArgument</c>.</summary>
public sealed class RotationArgument : ArgumentType<ICoordinates> {
    private static readonly string[] ExampleValues = ["0 0", "~ ~", "~-5 ~5"];

    public static readonly SimpleCommandExceptionType ErrorNotComplete = new(Component.Translatable("argument.rotation.incomplete"));

    public override ICoordinates Parse(StringReader reader) {
        int start = reader.Cursor;
        if (!reader.CanRead()) {
            throw ErrorNotComplete.CreateWithContext(reader);
        }
        WorldCoordinate y = WorldCoordinate.ParseDouble(reader, false);
        if (reader.CanRead() && reader.Peek() == ' ') {
            reader.Skip();
            WorldCoordinate x = WorldCoordinate.ParseDouble(reader, false);
            return new WorldCoordinates(x, y, new WorldCoordinate(true, 0.0));
        }
        reader.Cursor = start;
        throw ErrorNotComplete.CreateWithContext(reader);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>SwizzleArgument</c>.</summary>
public sealed class SwizzleArgument : ArgumentType<IReadOnlySet<SwizzleArgument.Axis>> {
    public enum Axis { X, Y, Z }

    private static readonly string[] ExampleValues = ["xyz", "x"];
    private static readonly SimpleCommandExceptionType ErrorInvalid = new(Component.Translatable("arguments.swizzle.invalid"));

    public override IReadOnlySet<Axis> Parse(StringReader reader) {
        HashSet<Axis> result = [];
        while (reader.CanRead() && reader.Peek() != ' ') {
            char c = reader.ReadChar();
            Axis axis = c switch {
                'x' => Axis.X,
                'y' => Axis.Y,
                'z' => Axis.Z,
                _ => throw ErrorInvalid.CreateWithContext(reader)
            };
            if (!result.Add(axis)) {
                throw ErrorInvalid.CreateWithContext(reader);
            }
        }
        return result;
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>AngleArgument</c>.</summary>
public sealed class AngleArgument : ArgumentType<AngleArgument.SingleAngle> {
    private static readonly string[] ExampleValues = ["0", "~", "~-5"];

    public static readonly SimpleCommandExceptionType ErrorNotComplete = new(Component.Translatable("argument.angle.incomplete"));
    public static readonly SimpleCommandExceptionType ErrorInvalidAngle = new(Component.Translatable("argument.angle.invalid"));

    public override SingleAngle Parse(StringReader reader) {
        if (!reader.CanRead()) {
            throw ErrorNotComplete.CreateWithContext(reader);
        }
        bool isRelative = WorldCoordinate.IsRelative(reader);
        float value = reader.CanRead() && reader.Peek() != ' ' ? reader.ReadFloat() : 0.0F;
        if (float.IsNaN(value) || float.IsInfinity(value)) {
            throw ErrorInvalidAngle.CreateWithContext(reader);
        }
        return new SingleAngle(value, isRelative);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    public sealed record SingleAngle(float Angle, bool IsRelative);
}
