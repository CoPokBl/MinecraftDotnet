using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using ClientLib.Brigadier;
using ClientLib.Commands;
using ClientLib.Parsing.Packrat;
using NBT;
using NBT.Tags;

namespace ClientLib.Nbt;

/// <summary>Vanilla's <c>SnbtGrammar</c> over <c>NbtOps</c>, with the ops calls written out as the tags they create.</summary>
public static class SnbtGrammar {
    private static readonly DynamicCommandExceptionType ErrorNumberParseFailure =
        new(message => Component.TranslatableEscape("snbt.parser.number_parse_failure", message));
    private static readonly DynamicCommandExceptionType ErrorExpectedHexEscape =
        new(length => Component.TranslatableEscape("snbt.parser.expected_hex_escape", length));
    private static readonly DynamicCommandExceptionType ErrorInvalidCodepoint =
        new(codepoint => Component.TranslatableEscape("snbt.parser.invalid_codepoint", codepoint));
    private static readonly DynamicCommandExceptionType ErrorNoSuchOperation =
        new(operation => Component.TranslatableEscape("snbt.parser.no_such_operation", operation));
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedIntegerType = Error("expected_integer_type");
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedFloatType = Error("expected_float_type");
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedNonNegativeNumber = Error("expected_non_negative_number");
    private static readonly IDelayedException<CommandSyntaxException> ErrorInvalidCharacterName = Error("invalid_character_name");
    private static readonly IDelayedException<CommandSyntaxException> ErrorInvalidArrayElementType = Error("invalid_array_element_type");
    private static readonly IDelayedException<CommandSyntaxException> ErrorInvalidUnquotedStart = Error("invalid_unquoted_start");
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedUnquotedString = Error("expected_unquoted_string");
    private static readonly IDelayedException<CommandSyntaxException> ErrorInvalidStringContents = Error("invalid_string_contents");
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedBinaryNumeral = Error("expected_binary_numeral");
    private static readonly IDelayedException<CommandSyntaxException> ErrorUndescoreNotAllowed = Error("underscore_not_allowed");
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedDecimalNumeral = Error("expected_decimal_numeral");
    private static readonly IDelayedException<CommandSyntaxException> ErrorExpectedHexNumeral = Error("expected_hex_numeral");
    private static readonly IDelayedException<CommandSyntaxException> ErrorEmptyKey = Error("empty_key");
    private static readonly IDelayedException<CommandSyntaxException> ErrorLeadingZeroNotAllowed = Error("leading_zero_not_allowed");
    private static readonly IDelayedException<CommandSyntaxException> ErrorInfinityNotAllowed = Error("infinity_not_allowed");

    private static IDelayedException<CommandSyntaxException> Error(string key) =>
        DelayedException.Create(new SimpleCommandExceptionType(Component.Translatable("snbt.parser." + key)));

    private static readonly NumberRunParseRule BinaryNumeral = new CharNumberRunParseRule(ErrorExpectedBinaryNumeral, ErrorUndescoreNotAllowed,
        c => c is '0' or '1' or '_');
    private static readonly NumberRunParseRule DecimalNumeral = new CharNumberRunParseRule(ErrorExpectedDecimalNumeral, ErrorUndescoreNotAllowed,
        c => c is >= '0' and <= '9' or '_');
    private static readonly NumberRunParseRule HexNumeral = new CharNumberRunParseRule(ErrorExpectedHexNumeral, ErrorUndescoreNotAllowed,
        c => c is >= '0' and <= '9' or >= 'A' and <= 'F' or '_' or >= 'a' and <= 'f');
    private static readonly GreedyPredicateParseRule PlainStringChunk = new CharGreedyPredicateParseRule(1, int.MaxValue, ErrorInvalidStringContents,
        c => c is not ('"' or '\'' or '\\'));
    private static readonly StringReaderTerms.TerminalCharacters NumberLookeahead = new LookaheadCharacters();
    private static readonly Regex UnicodeName = new("[-a-zA-Z0-9 ]+", RegexOptions.CultureInvariant);

    private sealed class CharNumberRunParseRule(
        IDelayedException<CommandSyntaxException> noValueError,
        IDelayedException<CommandSyntaxException> underscoreNotAllowedError,
        Func<char, bool> accepted) : NumberRunParseRule(noValueError, underscoreNotAllowedError) {
        protected override bool IsAccepted(char c) => accepted(c);
    }

    private class CharGreedyPredicateParseRule(int minSize, int maxSize, IDelayedException<CommandSyntaxException> error, Func<char, bool> accepted)
        : GreedyPredicateParseRule(minSize, maxSize, error) {
        protected override bool IsAccepted(char c) => accepted(c);
    }

    private sealed class LookaheadCharacters() : StringReaderTerms.TerminalCharacters([]) {
        protected override bool IsAccepted(char c) => CanStartNumber(c);
    }

    private static IDelayedException<CommandSyntaxException> CreateNumberParseError(NumberFormatException ex) =>
        DelayedException.Create(ErrorNumberParseFailure, ex.Message);

    private static bool IsAllowedToStartUnquotedString(char c) => !CanStartNumber(c);

    private static bool CanStartNumber(char c) => c is '+' or '-' or '.' or >= '0' and <= '9';

    private static bool NeedsUnderscoreRemoval(string contents) => contents.Contains('_');

    private static void CleanAndAppend(StringBuilder output, string contents) => CleanAndAppend(output, contents, NeedsUnderscoreRemoval(contents));

    private static void CleanAndAppend(StringBuilder output, string contents, bool needsUnderscoreRemoval) {
        if (!needsUnderscoreRemoval) {
            output.Append(contents);
            return;
        }
        foreach (char c in contents) {
            if (c != '_') {
                output.Append(c);
            }
        }
    }

    private static short ParseUnsignedShort(string @string, int radix) {
        int parse = JavaNumbers.ParseInt(@string, radix);
        if (parse >> 16 == 0) {
            return (short)parse;
        }
        throw new NumberFormatException("out of range: " + parse);
    }

    private static INbtTag? CreateFloat(Sign sign, string? whole, string? fraction, Signed<string>? exponent, TypeSuffix? typeSuffix,
        IParseState<StringReader> state) {
        StringBuilder result = new();
        sign.Append(result);
        if (whole != null) {
            CleanAndAppend(result, whole);
        }
        if (fraction != null) {
            result.Append('.');
            CleanAndAppend(result, fraction);
        }
        if (exponent != null) {
            result.Append('e');
            exponent.Sign.Append(result);
            CleanAndAppend(result, exponent.Value);
        }
        try {
            string contents = result.ToString();
            switch (typeSuffix) {
                case null:
                    return ConvertDouble(state, contents);
                case TypeSuffix.Float:
                    return ConvertFloat(state, contents);
                case TypeSuffix.Double:
                    return ConvertDouble(state, contents);
                default:
                    state.ErrorCollector.Store(state.Mark(), ErrorExpectedFloatType);
                    return null;
            }
        }
        catch (NumberFormatException e) {
            state.ErrorCollector.Store(state.Mark(), CreateNumberParseError(e));
            return null;
        }
    }

    private static INbtTag? ConvertFloat(IParseState<StringReader> state, string contents) {
        float value = JavaNumbers.ParseFloat(contents);
        if (!float.IsFinite(value)) {
            state.ErrorCollector.Store(state.Mark(), ErrorInfinityNotAllowed);
            return null;
        }
        return new FloatTag(value);
    }

    private static INbtTag? ConvertDouble(IParseState<StringReader> state, string contents) {
        double value = JavaNumbers.ParseDouble(contents);
        if (!double.IsFinite(value)) {
            state.ErrorCollector.Store(state.Mark(), ErrorInfinityNotAllowed);
            return null;
        }
        return new DoubleTag(value);
    }

    private static string JoinList(List<string> list) => list.Count switch {
        0 => "",
        1 => list[0],
        _ => string.Join("", list)
    };

    private static ITerm<StringReader> Marker<T>(Atom<T> name, T value) => Term.Marker<StringReader, T>(name, value);

    private static ITerm<StringReader> Cut() => Term.Cut<StringReader>();

    private static ITerm<StringReader> Character(char c) => StringReaderTerms.Character(c);

    private static ITerm<StringReader> Characters(char a, char b) => StringReaderTerms.Characters(a, b);

    /// <summary>
    /// <c>NbtOps.createList</c> in the shape <c>ListTag.write</c> gives it: a mixed list wraps each element
    /// not already a non wrapper compound, done here because the tag library's lists must be homogeneous.
    /// </summary>
    private static ListTag CreateList(List<INbtTag> entries) {
        byte homogenousType = 0;
        bool mixed = false;
        foreach (INbtTag element in entries) {
            byte elementType = element.GetPrefix();
            if (homogenousType == 0) {
                homogenousType = elementType;
            }
            else if (homogenousType != elementType) {
                mixed = true;
                break;
            }
        }
        if (!mixed) {
            return new ListTag(entries);
        }
        return new ListTag(entries.Select(e => (INbtTag)(e is CompoundTag compound && !IsWrapper(compound) ? compound : new CompoundTag(("", e)))));
    }

    private static bool IsWrapper(CompoundTag tag) => tag.ChildCount == 1 && tag.Contains("");

    /// <summary><c>SnbtGrammar.createParser</c> over <c>NbtOps</c>.</summary>
    public static Grammar<INbtTag> CreateParser() {
        Dictionary<StringReader> rules = new();
        Atom<Sign?> sign = Atom<Sign?>.Of("sign");
        rules.Put(sign,
            Term.Alternative(
                Term.Sequence(Character('+'), Marker<Sign?>(sign, Sign.Plus)),
                Term.Sequence(Character('-'), Marker<Sign?>(sign, Sign.Minus))),
            scope => scope.GetOrThrow(sign));

        Atom<IntegerSuffix> integerSuffix = Atom<IntegerSuffix>.Of("integer_suffix");
        rules.Put(integerSuffix,
            Term.Alternative(
                Term.Sequence(Characters('u', 'U'),
                    Term.Alternative(
                        Term.Sequence(Characters('b', 'B'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Unsigned, TypeSuffix.Byte))),
                        Term.Sequence(Characters('s', 'S'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Unsigned, TypeSuffix.Short))),
                        Term.Sequence(Characters('i', 'I'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Unsigned, TypeSuffix.Int))),
                        Term.Sequence(Characters('l', 'L'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Unsigned, TypeSuffix.Long))))),
                Term.Sequence(Characters('s', 'S'),
                    Term.Alternative(
                        Term.Sequence(Characters('b', 'B'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Signed, TypeSuffix.Byte))),
                        Term.Sequence(Characters('s', 'S'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Signed, TypeSuffix.Short))),
                        Term.Sequence(Characters('i', 'I'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Signed, TypeSuffix.Int))),
                        Term.Sequence(Characters('l', 'L'), Marker(integerSuffix, new IntegerSuffix(SignedPrefix.Signed, TypeSuffix.Long))))),
                Term.Sequence(Characters('b', 'B'), Marker(integerSuffix, new IntegerSuffix(null, TypeSuffix.Byte))),
                Term.Sequence(Characters('s', 'S'), Marker(integerSuffix, new IntegerSuffix(null, TypeSuffix.Short))),
                Term.Sequence(Characters('i', 'I'), Marker(integerSuffix, new IntegerSuffix(null, TypeSuffix.Int))),
                Term.Sequence(Characters('l', 'L'), Marker(integerSuffix, new IntegerSuffix(null, TypeSuffix.Long)))),
            scope => scope.GetOrThrow(integerSuffix));

        Atom<string> binaryNumeral = Atom<string>.Of("binary_numeral");
        rules.Put(binaryNumeral, BinaryNumeral);
        Atom<string> decimalNumeral = Atom<string>.Of("decimal_numeral");
        rules.Put(decimalNumeral, DecimalNumeral);
        Atom<string> hexNumeral = Atom<string>.Of("hex_numeral");
        rules.Put(hexNumeral, HexNumeral);

        Atom<IntegerLiteral> integerLiteral = Atom<IntegerLiteral>.Of("integer_literal");
        INamedRule<StringReader, IntegerLiteral> integerLiteralRule = rules.Put(integerLiteral,
            Term.Sequence(
                Term.Optional(rules.Named(sign)),
                Term.Alternative(
                    Term.Sequence(
                        Character('0'),
                        Cut(),
                        Term.Alternative(
                            Term.Sequence(Characters('x', 'X'), Cut(), rules.Named(hexNumeral)),
                            Term.Sequence(Characters('b', 'B'), rules.Named(binaryNumeral)),
                            Term.Sequence(rules.Named(decimalNumeral), Cut(), Term.Fail<StringReader>(ErrorLeadingZeroNotAllowed)),
                            Marker(decimalNumeral, "0"))),
                    rules.Named(decimalNumeral)),
                Term.Optional(rules.Named(integerSuffix))),
            scope => {
                IntegerSuffix suffix = scope.GetOrDefault(integerSuffix, IntegerSuffix.Empty);
                Sign signValue = scope.GetOrDefault(sign, Sign.Plus)!.Value;
                string? decimalContents = scope.Get(decimalNumeral);
                if (decimalContents != null) {
                    return new IntegerLiteral(signValue, Base.Decimal, decimalContents, suffix);
                }
                string? hexContents = scope.Get(hexNumeral);
                if (hexContents != null) {
                    return new IntegerLiteral(signValue, Base.Hex, hexContents, suffix);
                }
                string binaryContents = scope.GetOrThrow(binaryNumeral);
                return new IntegerLiteral(signValue, Base.Binary, binaryContents, suffix);
            });

        Atom<TypeSuffix?> floatTypeSuffix = Atom<TypeSuffix?>.Of("float_type_suffix");
        rules.Put(floatTypeSuffix,
            Term.Alternative(
                Term.Sequence(Characters('f', 'F'), Marker<TypeSuffix?>(floatTypeSuffix, TypeSuffix.Float)),
                Term.Sequence(Characters('d', 'D'), Marker<TypeSuffix?>(floatTypeSuffix, TypeSuffix.Double))),
            scope => scope.GetOrThrow(floatTypeSuffix));

        Atom<Signed<string>> floatExponentPart = Atom<Signed<string>>.Of("float_exponent_part");
        rules.Put(floatExponentPart,
            Term.Sequence(Characters('e', 'E'), Term.Optional(rules.Named(sign)), rules.Named(decimalNumeral)),
            scope => new Signed<string>(scope.GetOrDefault(sign, Sign.Plus)!.Value, scope.GetOrThrow(decimalNumeral)));

        Atom<string> floatWholePart = Atom<string>.Of("float_whole_part");
        Atom<string> floatFractionPart = Atom<string>.Of("float_fraction_part");
        Atom<INbtTag> floatLiteral = Atom<INbtTag>.Of("float_literal");
        rules.PutComplex(floatLiteral,
            Term.Sequence(
                Term.Optional(rules.Named(sign)),
                Term.Alternative(
                    Term.Sequence(
                        rules.NamedWithAlias(decimalNumeral, floatWholePart),
                        Character('.'),
                        Cut(),
                        Term.Optional(rules.NamedWithAlias(decimalNumeral, floatFractionPart)),
                        Term.Optional(rules.Named(floatExponentPart)),
                        Term.Optional(rules.Named(floatTypeSuffix))),
                    Term.Sequence(
                        Character('.'),
                        Cut(),
                        rules.NamedWithAlias(decimalNumeral, floatFractionPart),
                        Term.Optional(rules.Named(floatExponentPart)),
                        Term.Optional(rules.Named(floatTypeSuffix))),
                    Term.Sequence(
                        rules.NamedWithAlias(decimalNumeral, floatWholePart), rules.Named(floatExponentPart), Cut(), Term.Optional(rules.Named(floatTypeSuffix))),
                    Term.Sequence(rules.NamedWithAlias(decimalNumeral, floatWholePart), Term.Optional(rules.Named(floatExponentPart)),
                        rules.Named(floatTypeSuffix)))),
            state => {
                Scope scope = state.Scope;
                Sign wholeSign = scope.GetOrDefault(sign, Sign.Plus)!.Value;
                string? whole = scope.Get(floatWholePart);
                string? fraction = scope.Get(floatFractionPart);
                Signed<string>? exponent = scope.Get(floatExponentPart);
                TypeSuffix? typeSuffix = scope.Get(floatTypeSuffix);
                return CreateFloat(wholeSign, whole, fraction, exponent, typeSuffix, state);
            });

        Atom<string> stringHex2 = Atom<string>.Of("string_hex_2");
        rules.Put(stringHex2, new SimpleHexLiteralParseRule(2));
        Atom<string> stringHex4 = Atom<string>.Of("string_hex_4");
        rules.Put(stringHex4, new SimpleHexLiteralParseRule(4));
        Atom<string> stringHex8 = Atom<string>.Of("string_hex_8");
        rules.Put(stringHex8, new SimpleHexLiteralParseRule(8));
        Atom<string> stringUnicodeName = Atom<string>.Of("string_unicode_name");
        rules.Put(stringUnicodeName, new GreedyPatternParseRule(UnicodeName, ErrorInvalidCharacterName));

        Atom<string> stringEscapeSequence = Atom<string>.Of("string_escape_sequence");
        rules.PutComplex(stringEscapeSequence,
            Term.Alternative(
                Term.Sequence(Character('b'), Marker(stringEscapeSequence, "\b")),
                Term.Sequence(Character('s'), Marker(stringEscapeSequence, " ")),
                Term.Sequence(Character('t'), Marker(stringEscapeSequence, "\t")),
                Term.Sequence(Character('n'), Marker(stringEscapeSequence, "\n")),
                Term.Sequence(Character('f'), Marker(stringEscapeSequence, "\f")),
                Term.Sequence(Character('r'), Marker(stringEscapeSequence, "\r")),
                Term.Sequence(Character('\\'), Marker(stringEscapeSequence, "\\")),
                Term.Sequence(Character('\''), Marker(stringEscapeSequence, "'")),
                Term.Sequence(Character('"'), Marker(stringEscapeSequence, "\"")),
                Term.Sequence(Character('x'), rules.Named(stringHex2)),
                Term.Sequence(Character('u'), rules.Named(stringHex4)),
                Term.Sequence(Character('U'), rules.Named(stringHex8)),
                Term.Sequence(Character('N'), Character('{'), rules.Named(stringUnicodeName), Character('}'))),
            state => {
                Scope scope = state.Scope;
                string? plainEscape = scope.GetAny(stringEscapeSequence);
                if (plainEscape != null) {
                    return plainEscape;
                }
                string? hexEscape = scope.GetAny(stringHex2, stringHex4, stringHex8);
                if (hexEscape != null) {
                    int codePoint = (int)uint.Parse(hexEscape, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
                    if (codePoint is < 0 or > 0x10FFFF) {
                        state.ErrorCollector.Store(state.Mark(),
                            DelayedException.Create(ErrorInvalidCodepoint, "U+" + ((uint)codePoint).ToString("X8", CultureInfo.InvariantCulture)));
                        return null;
                    }
                    return CodePointToString(codePoint);
                }
                // Divergence: .NET has no Character.codePointOf name table, so every \N{...} escape is an unknown name.
                scope.GetOrThrow(stringUnicodeName);
                state.ErrorCollector.Store(state.Mark(), ErrorInvalidCharacterName);
                return null;
            });

        Atom<string> stringPlainContents = Atom<string>.Of("string_plain_contents");
        rules.Put(stringPlainContents, PlainStringChunk);
        Atom<List<string>> stringChunks = Atom<List<string>>.Of("string_chunks");
        Atom<string> stringContents = Atom<string>.Of("string_contents");

        Atom<string> singleQuotedStringChunk = Atom<string>.Of("single_quoted_string_chunk");
        INamedRule<StringReader, string> singleQuotedStringChunkRule = rules.Put(singleQuotedStringChunk,
            Term.Alternative(
                rules.NamedWithAlias(stringPlainContents, stringContents),
                Term.Sequence(Character('\\'), rules.NamedWithAlias(stringEscapeSequence, stringContents)),
                Term.Sequence(Character('"'), Marker(stringContents, "\""))),
            scope => scope.GetOrThrow(stringContents));
        Atom<string> singleQuotedStringContents = Atom<string>.Of("single_quoted_string_contents");
        rules.Put(singleQuotedStringContents, Term.Repeated(singleQuotedStringChunkRule, stringChunks), scope => JoinList(scope.GetOrThrow(stringChunks)));

        Atom<string> doubleQuotedStringChunk = Atom<string>.Of("double_quoted_string_chunk");
        INamedRule<StringReader, string> doubleQuotedStringChunkRule = rules.Put(doubleQuotedStringChunk,
            Term.Alternative(
                rules.NamedWithAlias(stringPlainContents, stringContents),
                Term.Sequence(Character('\\'), rules.NamedWithAlias(stringEscapeSequence, stringContents)),
                Term.Sequence(Character('\''), Marker(stringContents, "'"))),
            scope => scope.GetOrThrow(stringContents));
        Atom<string> doubleQuotedStringContents = Atom<string>.Of("double_quoted_string_contents");
        rules.Put(doubleQuotedStringContents, Term.Repeated(doubleQuotedStringChunkRule, stringChunks), scope => JoinList(scope.GetOrThrow(stringChunks)));

        Atom<string> quotedStringLiteral = Atom<string>.Of("quoted_string_literal");
        rules.Put(quotedStringLiteral,
            Term.Alternative(
                Term.Sequence(Character('"'), Cut(), Term.Optional(rules.NamedWithAlias(doubleQuotedStringContents, stringContents)), Character('"')),
                Term.Sequence(Character('\''), Term.Optional(rules.NamedWithAlias(singleQuotedStringContents, stringContents)), Character('\''))),
            scope => scope.GetOrThrow(stringContents));

        Atom<string> unquotedString = Atom<string>.Of("unquoted_string");
        rules.Put(unquotedString, new UnquotedStringParseRule(1, ErrorExpectedUnquotedString));

        Atom<INbtTag> literal = Atom<INbtTag>.Of("literal");
        Atom<List<INbtTag>> argumentList = Atom<List<INbtTag>>.Of("arguments");
        rules.Put(argumentList,
            Term.RepeatedWithTrailingSeparator(rules.Forward(literal), argumentList, Character(',')),
            scope => scope.GetOrThrow(argumentList));

        Atom<INbtTag> unquotedStringOrBuiltIn = Atom<INbtTag>.Of("unquoted_string_or_builtin");
        rules.PutComplex(unquotedStringOrBuiltIn,
            Term.Sequence(
                rules.Named(unquotedString),
                Term.Optional(Term.Sequence(Character('('), rules.Named(argumentList), Character(')')))),
            state => {
                Scope scope = state.Scope;
                string contents = scope.GetOrThrow(unquotedString);
                if (contents.Length == 0 || !IsAllowedToStartUnquotedString(contents[0])) {
                    state.ErrorCollector.Store(state.Mark(), SnbtOperations.BuiltinIds, ErrorInvalidUnquotedStart);
                    return null;
                }
                List<INbtTag>? arguments = scope.Get(argumentList);
                if (arguments != null) {
                    SnbtOperations.BuiltinKey key = new(contents, arguments.Count);
                    if (SnbtOperations.BuiltinOperations.TryGetValue(key, out SnbtOperations.BuiltinOperation? operation)) {
                        return operation(arguments, state);
                    }
                    state.ErrorCollector.Store(state.Mark(), DelayedException.Create(ErrorNoSuchOperation, key.ToString()));
                    return null;
                }
                if (contents.Equals("true", StringComparison.OrdinalIgnoreCase)) {
                    return new ByteTag(1);
                }
                return contents.Equals("false", StringComparison.OrdinalIgnoreCase) ? new ByteTag(0) : new StringTag(contents);
            });

        Atom<string> mapKey = Atom<string>.Of("map_key");
        rules.Put(mapKey,
            Term.Alternative(rules.Named(quotedStringLiteral), rules.Named(unquotedString)),
            scope => scope.GetAnyOrThrow(quotedStringLiteral, unquotedString));

        Atom<MapEntry> mapEntry = Atom<MapEntry>.Of("map_entry");
        INamedRule<StringReader, MapEntry> mapEntryRule = rules.PutComplex(mapEntry,
            Term.Sequence(rules.Named(mapKey), Character(':'), rules.Named(literal)),
            state => {
                Scope scope = state.Scope;
                string key = scope.GetOrThrow(mapKey);
                if (key.Length == 0) {
                    state.ErrorCollector.Store(state.Mark(), ErrorEmptyKey);
                    return null;
                }
                INbtTag value = scope.GetOrThrow(literal);
                return new MapEntry(key, value);
            });

        Atom<List<MapEntry>> mapEntries = Atom<List<MapEntry>>.Of("map_entries");
        rules.Put(mapEntries,
            Term.RepeatedWithTrailingSeparator(mapEntryRule, mapEntries, Character(',')),
            scope => scope.GetOrThrow(mapEntries));

        Atom<INbtTag> mapLiteral = Atom<INbtTag>.Of("map_literal");
        rules.Put(mapLiteral, Term.Sequence(Character('{'), rules.Named(mapEntries), Character('}')), scope => {
            List<MapEntry> entries = scope.GetOrThrow(mapEntries);
            if (entries.Count == 0) {
                return new CompoundTag();
            }
            // ImmutableMap.Builder.buildKeepingLast: a repeated key keeps its last value.
            OrderedDictionary<string, INbtTag> builder = new();
            foreach (MapEntry e in entries) {
                builder[e.Key] = e.Value;
            }
            return new CompoundTag(builder);
        });

        Atom<List<INbtTag>> listEntries = Atom<List<INbtTag>>.Of("list_entries");
        rules.Put(listEntries,
            Term.RepeatedWithTrailingSeparator(rules.Forward(literal), listEntries, Character(',')),
            scope => scope.GetOrThrow(listEntries));

        Atom<ArrayPrefix?> arrayPrefix = Atom<ArrayPrefix?>.Of("array_prefix");
        rules.Put(arrayPrefix,
            Term.Alternative(
                Term.Sequence(Character('B'), Marker<ArrayPrefix?>(arrayPrefix, ArrayPrefix.Byte)),
                Term.Sequence(Character('L'), Marker<ArrayPrefix?>(arrayPrefix, ArrayPrefix.Long)),
                Term.Sequence(Character('I'), Marker<ArrayPrefix?>(arrayPrefix, ArrayPrefix.Int))),
            scope => scope.GetOrThrow(arrayPrefix));

        Atom<List<IntegerLiteral>> intArrayEntries = Atom<List<IntegerLiteral>>.Of("int_array_entries");
        rules.Put(intArrayEntries,
            Term.RepeatedWithTrailingSeparator(integerLiteralRule, intArrayEntries, Character(',')),
            scope => scope.GetOrThrow(intArrayEntries));

        Atom<INbtTag> listLiteral = Atom<INbtTag>.Of("list_literal");
        rules.PutComplex(listLiteral,
            Term.Sequence(
                Character('['),
                Term.Alternative(Term.Sequence(rules.Named(arrayPrefix), Character(';'), rules.Named(intArrayEntries)), rules.Named(listEntries)),
                Character(']')),
            state => {
                Scope scope = state.Scope;
                ArrayPrefix? arrayType = scope.Get(arrayPrefix);
                if (arrayType != null) {
                    List<IntegerLiteral> entries = scope.GetOrThrow(intArrayEntries);
                    return entries.Count == 0 ? arrayType.Value.Create() : arrayType.Value.Create(entries, state);
                }
                List<INbtTag> listValues = scope.GetOrThrow(listEntries);
                return listValues.Count == 0 ? new ListTag() : CreateList(listValues);
            });

        INamedRule<StringReader, INbtTag> literalRule = rules.PutComplex(literal,
            Term.Alternative(
                Term.Sequence(Term.PositiveLookahead<StringReader>(NumberLookeahead),
                    Term.Alternative(rules.NamedWithAlias(floatLiteral, literal), rules.Named(integerLiteral))),
                Term.Sequence(Term.PositiveLookahead(Characters('"', '\'')), Cut(), rules.Named(quotedStringLiteral)),
                Term.Sequence(Term.PositiveLookahead(Character('{')), Cut(), rules.NamedWithAlias(mapLiteral, literal)),
                Term.Sequence(Term.PositiveLookahead(Character('[')), Cut(), rules.NamedWithAlias(listLiteral, literal)),
                rules.NamedWithAlias(unquotedStringOrBuiltIn, literal)),
            state => {
                Scope scope = state.Scope;
                string? quotedString = scope.Get(quotedStringLiteral);
                if (quotedString != null) {
                    return new StringTag(quotedString);
                }
                IntegerLiteral? integer = scope.Get(integerLiteral);
                return integer != null ? integer.Create(state) : scope.GetOrThrow(literal);
            });
        return new Grammar<INbtTag>(rules, literalRule);
    }

    /// <summary><c>Character.toString(int)</c>, which keeps a lone surrogate where .NET's conversion throws.</summary>
    private static string CodePointToString(int codePoint) {
        return codePoint is >= 0xD800 and <= 0xDFFF ? ((char)codePoint).ToString() : char.ConvertFromUtf32(codePoint);
    }

    private sealed record MapEntry(string Key, INbtTag Value);

    private enum ArrayPrefix {
        Byte,
        Int,
        Long
    }

    private static TypeSuffix DefaultType(this ArrayPrefix prefix) => prefix switch {
        ArrayPrefix.Byte => TypeSuffix.Byte,
        ArrayPrefix.Int => TypeSuffix.Int,
        _ => TypeSuffix.Long
    };

    private static bool IsAllowed(this ArrayPrefix prefix, TypeSuffix type) {
        return type == prefix.DefaultType() || prefix switch {
            ArrayPrefix.Byte => false,
            ArrayPrefix.Int => type is TypeSuffix.Byte or TypeSuffix.Short,
            _ => type is TypeSuffix.Byte or TypeSuffix.Short or TypeSuffix.Int
        };
    }

    private static INbtTag Create(this ArrayPrefix prefix) => prefix switch {
        ArrayPrefix.Byte => new ArrayTag<sbyte>(),
        ArrayPrefix.Int => new ArrayTag<int>(),
        _ => new ArrayTag<long>()
    };

    private static INbtTag? Create(this ArrayPrefix prefix, List<IntegerLiteral> entries, IParseState<StringReader> state) {
        List<long> values = new(entries.Count);
        foreach (IntegerLiteral entry in entries) {
            object? parsedNumber = prefix.BuildNumber(entry, state);
            if (parsedNumber == null) {
                return null;
            }
            values.Add(JavaNumbers.LongValue(parsedNumber));
        }
        return prefix switch {
            ArrayPrefix.Byte => new ArrayTag<sbyte>(values.Select(v => unchecked((sbyte)v)).ToArray()),
            ArrayPrefix.Int => new ArrayTag<int>(values.Select(v => unchecked((int)v)).ToArray()),
            _ => new ArrayTag<long>(values.ToArray())
        };
    }

    private static object? BuildNumber(this ArrayPrefix prefix, IntegerLiteral entry, IParseState<StringReader> state) {
        TypeSuffix? actualType = prefix.ComputeType(entry.Suffix);
        if (actualType == null) {
            state.ErrorCollector.Store(state.Mark(), ErrorInvalidArrayElementType);
            return null;
        }
        return entry.CreateNumber(actualType.Value, state);
    }

    private static TypeSuffix? ComputeType(this ArrayPrefix prefix, IntegerSuffix value) {
        TypeSuffix? type = value.Type;
        if (type == null) {
            return prefix.DefaultType();
        }
        return !prefix.IsAllowed(type.Value) ? null : type;
    }

    private enum Base {
        Binary,
        Decimal,
        Hex
    }

    private sealed record IntegerLiteral(Sign Sign, Base Base, string Digits, IntegerSuffix Suffix) {
        private SignedPrefix SignedOrDefault() {
            if (Suffix.Signed != null) {
                return Suffix.Signed.Value;
            }
            return Base switch {
                Base.Binary or Base.Hex => SignedPrefix.Unsigned,
                _ => SignedPrefix.Signed
            };
        }

        private string CleanupDigits(Sign sign) {
            bool needsUnderscoreRemoval = NeedsUnderscoreRemoval(Digits);
            if (sign != Sign.Minus && !needsUnderscoreRemoval) {
                return Digits;
            }
            StringBuilder result = new();
            sign.Append(result);
            CleanAndAppend(result, Digits, needsUnderscoreRemoval);
            return result.ToString();
        }

        public INbtTag? Create(IParseState<StringReader> state) => Create(Suffix.Type ?? TypeSuffix.Int, state);

        public INbtTag? Create(TypeSuffix type, IParseState<StringReader> state) {
            return CreateNumber(type, state) switch {
                sbyte b => new ByteTag(b),
                short s => new ShortTag(s),
                int i => new IntegerTag(i),
                long l => new LongTag(l),
                _ => null
            };
        }

        /// <summary>The number half of <c>IntegerLiteral.create</c>, which vanilla runs over <c>JavaOps</c> for an array element.</summary>
        public object? CreateNumber(TypeSuffix type, IParseState<StringReader> state) {
            bool isSigned = SignedOrDefault() == SignedPrefix.Signed;
            if (!isSigned && Sign == Sign.Minus) {
                state.ErrorCollector.Store(state.Mark(), ErrorExpectedNonNegativeNumber);
                return null;
            }
            string fixedDigits = CleanupDigits(Sign);
            int radix = Base switch {
                Base.Binary => 2,
                Base.Decimal => 10,
                _ => 16
            };
            try {
                if (isSigned) {
                    switch (type) {
                        case TypeSuffix.Byte:
                            return JavaNumbers.ParseByte(fixedDigits, radix);
                        case TypeSuffix.Short:
                            return JavaNumbers.ParseShort(fixedDigits, radix);
                        case TypeSuffix.Int:
                            return JavaNumbers.ParseInt(fixedDigits, radix);
                        case TypeSuffix.Long:
                            return JavaNumbers.ParseLong(fixedDigits, radix);
                        default:
                            state.ErrorCollector.Store(state.Mark(), ErrorExpectedIntegerType);
                            return null;
                    }
                }
                switch (type) {
                    case TypeSuffix.Byte:
                        return JavaNumbers.ParseUnsignedByte(fixedDigits, radix);
                    case TypeSuffix.Short:
                        return ParseUnsignedShort(fixedDigits, radix);
                    case TypeSuffix.Int:
                        return JavaNumbers.ParseUnsignedInt(fixedDigits, radix);
                    case TypeSuffix.Long:
                        return JavaNumbers.ParseUnsignedLong(fixedDigits, radix);
                    default:
                        state.ErrorCollector.Store(state.Mark(), ErrorExpectedIntegerType);
                        return null;
                }
            }
            catch (NumberFormatException e) {
                state.ErrorCollector.Store(state.Mark(), CreateNumberParseError(e));
                return null;
            }
        }
    }

    private sealed record IntegerSuffix(SignedPrefix? Signed, TypeSuffix? Type) {
        public static readonly IntegerSuffix Empty = new(null, null);
    }

    private enum Sign {
        Plus,
        Minus
    }

    private static void Append(this Sign sign, StringBuilder output) {
        if (sign == Sign.Minus) {
            output.Append('-');
        }
    }

    private sealed record Signed<T>(Sign Sign, T Value);

    private enum SignedPrefix {
        Signed,
        Unsigned
    }

    private sealed class SimpleHexLiteralParseRule(int size)
        : CharGreedyPredicateParseRule(size, size, DelayedException.Create(ErrorExpectedHexEscape, size.ToString(CultureInfo.InvariantCulture)),
            c => c is >= '0' and <= '9' or >= 'A' and <= 'F' or >= 'a' and <= 'f');

    private enum TypeSuffix {
        Float,
        Double,
        Byte,
        Short,
        Int,
        Long
    }
}

/// <summary>Java's <c>NumberFormatException</c>, carrying the message Java would give.</summary>
public sealed class NumberFormatException(string message) : Exception(message);

/// <summary>The Java and Guava number parsers <c>SnbtGrammar</c> calls, with their accepted forms and messages.</summary>
internal static class JavaNumbers {
    private static NumberFormatException ForInputString(string s, int radix) {
        return new NumberFormatException("For input string: \"" + s + "\"" + (radix == 10 ? "" : " under radix " + radix));
    }

    /// <summary>The digits of <paramref name="s"/> in <paramref name="radix"/>, with Java's optional leading sign.</summary>
    private static BigInteger ParseBig(string s, int radix, bool allowMinus) {
        if (s.Length == 0) {
            throw ForInputString(s, radix);
        }
        int i = 0;
        bool negative = false;
        if (s[0] is '-' or '+') {
            negative = s[0] == '-';
            if (negative && !allowMinus) {
                throw new NumberFormatException("Illegal leading minus sign on unsigned string " + s + ".");
            }
            i = 1;
            if (s.Length == 1) {
                throw ForInputString(s, radix);
            }
        }
        BigInteger result = BigInteger.Zero;
        for (; i < s.Length; i++) {
            int digit = HexDigit(s[i]);
            if (digit < 0 || digit >= radix) {
                throw ForInputString(s, radix);
            }
            result = result * radix + digit;
        }
        return negative ? -result : result;
    }

    private static int HexDigit(char c) => c switch {
        >= '0' and <= '9' => c - '0',
        >= 'a' and <= 'z' => c - 'a' + 10,
        >= 'A' and <= 'Z' => c - 'A' + 10,
        _ => -1
    };

    public static int ParseInt(string s, int radix) {
        BigInteger value = ParseBig(s, radix, true);
        if (value < int.MinValue || value > int.MaxValue) {
            throw ForInputString(s, radix);
        }
        return (int)value;
    }

    public static long ParseLong(string s, int radix) {
        BigInteger value = ParseBig(s, radix, true);
        if (value < long.MinValue || value > long.MaxValue) {
            throw ForInputString(s, radix);
        }
        return (long)value;
    }

    public static sbyte ParseByte(string s, int radix) {
        int i = ParseInt(s, radix);
        if (i is < sbyte.MinValue or > sbyte.MaxValue) {
            throw new NumberFormatException("Value out of range. Value:\"" + s + "\" Radix:" + radix);
        }
        return (sbyte)i;
    }

    public static short ParseShort(string s, int radix) {
        int i = ParseInt(s, radix);
        if (i is < short.MinValue or > short.MaxValue) {
            throw new NumberFormatException("Value out of range. Value:\"" + s + "\" Radix:" + radix);
        }
        return (short)i;
    }

    /// <summary>Guava's <c>UnsignedBytes.parseUnsignedByte</c>.</summary>
    public static sbyte ParseUnsignedByte(string s, int radix) {
        int parse = ParseInt(s, radix);
        if (parse >> 8 == 0) {
            return unchecked((sbyte)parse);
        }
        throw new NumberFormatException("out of range: " + parse);
    }

    public static int ParseUnsignedInt(string s, int radix) {
        BigInteger value = ParseBig(s, radix, false);
        if (value > uint.MaxValue) {
            throw new NumberFormatException("String value " + s + " exceeds range of unsigned int.");
        }
        return unchecked((int)(uint)value);
    }

    public static long ParseUnsignedLong(string s, int radix) {
        BigInteger value = ParseBig(s, radix, false);
        if (value > ulong.MaxValue) {
            throw new NumberFormatException("String value " + s + " exceeds range of unsigned long.");
        }
        return unchecked((long)(ulong)value);
    }

    public static float ParseFloat(string s) {
        if (!JavaText.TryParseFloat(s, out float value)) {
            throw new NumberFormatException("For input string: \"" + s + "\"");
        }
        return value;
    }

    public static double ParseDouble(string s) {
        if (!JavaText.TryParseDouble(s, out double value)) {
            throw new NumberFormatException("For input string: \"" + s + "\"");
        }
        return value;
    }

    /// <summary><c>Number.longValue</c> of a boxed integral number.</summary>
    public static long LongValue(object number) => number switch {
        sbyte b => b,
        short s => s,
        int i => i,
        long l => l,
        _ => throw new ArgumentException("Not an integral number: " + number)
    };
}
