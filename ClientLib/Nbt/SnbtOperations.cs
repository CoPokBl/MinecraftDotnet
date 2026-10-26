using ClientLib.Brigadier;
using ClientLib.Commands;
using ClientLib.Parsing.Packrat;
using NBT;
using NBT.Tags;

namespace ClientLib.Nbt;

/// <summary>Vanilla's <c>SnbtOperations</c>: the <c>bool(...)</c> and <c>uuid(...)</c> built ins.</summary>
public static class SnbtOperations {
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedStringUuid =
        DelayedException.Create(new SimpleCommandExceptionType(Component.Translatable("snbt.parser.expected_string_uuid")));
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedNumberOrBoolean =
        DelayedException.Create(new SimpleCommandExceptionType(Component.Translatable("snbt.parser.expected_number_or_boolean")));

    public const string BuiltinTrue = "true";
    public const string BuiltinFalse = "false";

    /// <summary><c>SnbtOperations.BuiltinOperation</c>, over <c>NbtOps</c>.</summary>
    public delegate INbtTag? BuiltinOperation(List<INbtTag> arguments, IParseState<StringReader> state);

    public static readonly IReadOnlyDictionary<BuiltinKey, BuiltinOperation> BuiltinOperations = new Dictionary<BuiltinKey, BuiltinOperation> {
        [new BuiltinKey("bool", 1)] = (arguments, state) => {
            bool? result = ConvertBool(arguments[0]);
            if (result == null) {
                state.ErrorCollector.Store(state.Mark(), ErrorExpectedNumberOrBoolean);
                return null;
            }
            return new ByteTag((sbyte)(result.Value ? 1 : 0));
        },
        [new BuiltinKey("uuid", 1)] = (arguments, state) => {
            if (arguments[0] is not StringTag arg) {
                state.ErrorCollector.Store(state.Mark(), ErrorExpectedStringUuid);
                return null;
            }
            if (!TryParseJavaUuid(arg.Value, out long most, out long least)) {
                state.ErrorCollector.Store(state.Mark(), ErrorExpectedStringUuid);
                return null;
            }
            return new ArrayTag<int>((int)(most >> 32), (int)most, (int)(least >> 32), (int)least);
        }
    };

    public static readonly ISuggestionSupplier<StringReader> BuiltinIds = SuggestionSupplier.Of<StringReader>(_ =>
        new HashSet<string>([BuiltinFalse, BuiltinTrue, ..BuiltinOperations.Keys.Select(k => k.Id)]));

    /// <summary><c>NbtOps.getBooleanValue</c>, which is any non zero number, then the number fallback that it already covers.</summary>
    private static bool? ConvertBool(INbtTag arg) {
        double? number = arg switch {
            ByteTag b => b.Value,
            ShortTag s => s.Value,
            IntegerTag i => i.Value,
            LongTag l => l.Value,
            FloatTag f => f.Value,
            DoubleTag d => d.Value,
            _ => null
        };
        return number == null ? null : number.Value != 0.0;
    }

    /// <summary>
    /// <c>UUID.fromString</c>: five dash separated hex fields of any length, each masked to its width,
    /// at most 36 characters in all.
    /// </summary>
    private static bool TryParseJavaUuid(string name, out long most, out long least) {
        most = 0;
        least = 0;
        if (name.Length > 36) {
            return false;
        }
        string[] parts = name.Split('-');
        if (parts.Length != 5) {
            return false;
        }
        long[] fields = new long[5];
        for (int i = 0; i < 5; i++) {
            try {
                fields[i] = JavaNumbers.ParseLong(parts[i], 16);
            }
            catch (NumberFormatException) {
                return false;
            }
        }
        most = (fields[0] & 0xffffffffL) << 32 | (fields[1] & 0xffffL) << 16 | fields[2] & 0xffffL;
        least = (fields[3] & 0xffffL) << 48 | fields[4] & 0xffffffffffffL;
        return true;
    }

    /// <summary><c>SnbtOperations.BuiltinKey</c>.</summary>
    public sealed record BuiltinKey(string Id, int ArgCount) {
        public override string ToString() => Id + "/" + ArgCount;
    }
}
