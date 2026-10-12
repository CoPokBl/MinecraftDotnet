using ClientLib.Brigadier;
using ClientLib.Nbt;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Text;
using EntityTypes = Minecraft.Data.Generated.EntityType;

namespace ClientLib.Commands.Arguments;

/// <summary>
/// Vanilla's <c>EntitySelectorOptions</c>, reading, recording and raising what vanilla's do, without the
/// entity predicates, since the client never evaluates a selector. Entity types come from the generated
/// registry, as vanilla reads <c>BuiltInRegistries.ENTITY_TYPE</c>.
/// </summary>
public static class EntitySelectorOptions {
    private static readonly Dictionary<string, Option> Options = new();
    private static readonly Func<EntitySelectorParser, bool> AlwaysAvailable = _ => true;

    public static readonly DynamicCommandExceptionType ErrorUnknownOption = new(name => Component.TranslatableEscape("argument.entity.options.unknown", name));
    public static readonly DynamicCommandExceptionType ErrorInapplicableOption = new(name => Component.TranslatableEscape("argument.entity.options.inapplicable", name));
    public static readonly SimpleCommandExceptionType ErrorRangeNegative = new(Component.Translatable("argument.entity.options.distance.negative"));
    public static readonly SimpleCommandExceptionType ErrorLevelNegative = new(Component.Translatable("argument.entity.options.level.negative"));
    public static readonly SimpleCommandExceptionType ErrorLimitTooSmall = new(Component.Translatable("argument.entity.options.limit.toosmall"));
    public static readonly DynamicCommandExceptionType ErrorSortUnknown = new(name => Component.TranslatableEscape("argument.entity.options.sort.irreversible", name));
    public static readonly DynamicCommandExceptionType ErrorGameModeInvalid = new(name => Component.TranslatableEscape("argument.entity.options.mode.invalid", name));
    public static readonly DynamicCommandExceptionType ErrorEntityTypeInvalid = new(type => Component.TranslatableEscape("argument.entity.options.type.invalid", type));

    private static readonly string[] SortNames = ["nearest", "furthest", "random", "arbitrary"];

    public delegate void Modifier(EntitySelectorParser parser);

    private sealed record Option(Modifier Modifier, Func<EntitySelectorParser, bool> CanUse, TextComponent Description);

    private static void Register(string name, Modifier modifier, Func<EntitySelectorParser, bool> predicate) {
        Options[name] = new Option(modifier, predicate, Component.Translatable($"argument.entity.options.{name}.description"));
    }

    private static void RegisterCoordinate(string name, Func<EntitySelectorParser, double?> get, Action<EntitySelectorParser, double> set) {
        Register(name, parser => {
            parser.SetWorldLimited();
            set(parser, parser.Reader.ReadDouble());
        }, s => get(s) == null);
    }

    static EntitySelectorOptions() {
        Register("name", parser => {
            int start = parser.Reader.Cursor;
            bool inverted = parser.ShouldInvertValue();
            parser.Reader.ReadString();
            InvertableSetOptionState state = parser.NameOption;
            if (!state.CanParseElement(inverted)) {
                throw RollbackAndThrow(parser, start, ErrorInapplicableOption, "name");
            }
            state.MarkParsedElement(inverted);
        }, s => s.NameOption.CanParseAny());
        Register("distance", parser => {
            int start = parser.Reader.Cursor;
            MinMaxBounds.Doubles value = MinMaxBounds.Doubles.FromReader(parser.Reader);
            if (value.Min is < 0.0 || value.Max is < 0.0) {
                throw RollbackAndThrow(parser, start, ErrorRangeNegative);
            }
            parser.Distance = value;
            parser.SetWorldLimited();
        }, s => s.Distance == null);
        Register("level", parser => {
            int start = parser.Reader.Cursor;
            MinMaxBounds.Ints value = MinMaxBounds.Ints.FromReader(parser.Reader);
            if (value.Min is < 0 || value.Max is < 0) {
                throw RollbackAndThrow(parser, start, ErrorLevelNegative);
            }
            parser.Level = value;
            parser.IncludesEntities = false;
        }, s => s.Level == null);
        RegisterCoordinate("x", s => s.X, (s, v) => s.X = v);
        RegisterCoordinate("y", s => s.Y, (s, v) => s.Y = v);
        RegisterCoordinate("z", s => s.Z, (s, v) => s.Z = v);
        RegisterCoordinate("dx", s => s.DeltaX, (s, v) => s.DeltaX = v);
        RegisterCoordinate("dy", s => s.DeltaY, (s, v) => s.DeltaY = v);
        RegisterCoordinate("dz", s => s.DeltaZ, (s, v) => s.DeltaZ = v);
        Register("x_rotation", parser => parser.RotX = MinMaxBounds.FloatDegrees.FromReader(parser.Reader), s => s.RotX == null);
        Register("y_rotation", parser => parser.RotY = MinMaxBounds.FloatDegrees.FromReader(parser.Reader), s => s.RotY == null);
        Register("limit", parser => {
            int start = parser.Reader.Cursor;
            int count = parser.Reader.ReadInt();
            if (count < 1) {
                throw RollbackAndThrow(parser, start, ErrorLimitTooSmall);
            }
            parser.MaxResults = count;
            parser.LimitedOption.MarkParsed();
        }, s => !s.IsCurrentEntity && s.LimitedOption.CanParse());
        Register("sort", parser => {
            int start = parser.Reader.Cursor;
            string name = parser.Reader.ReadUnquotedString();
            parser.SetSuggestions((b, _) => SharedSuggestionProvider.Suggest(SortNames, b));
            parser.Order = name switch {
                "nearest" => EntitySelectorOrder.Nearest,
                "furthest" => EntitySelectorOrder.Furthest,
                "random" => EntitySelectorOrder.Random,
                "arbitrary" => EntitySelectorOrder.Arbitrary,
                _ => throw RollbackAndThrow(parser, start, ErrorSortUnknown, name)
            };
            parser.SortedOption.MarkParsed();
        }, s => !s.IsCurrentEntity && s.SortedOption.CanParse());
        Register("gamemode", parser => {
            InvertableSetOptionState state = parser.GamemodeOption;
            parser.SetSuggestions((b, _) => {
                string prefix = JavaText.ToLowerRoot(b.Remaining);
                bool addNormal = state.CanParsePositiveElement();
                bool addInverted = state.CanParseNegativeElement();
                if (prefix.Length > 0) {
                    if (prefix[0] == EntitySelectorParser.SyntaxNot) {
                        addNormal = false;
                        prefix = prefix[1..];
                    }
                    else {
                        addInverted = false;
                    }
                }
                foreach (string typeName in GameModeArgument.Values.Select(GameModeArgument.NameOf)) {
                    if (JavaText.ToLowerRoot(typeName).StartsWith(prefix, StringComparison.Ordinal)) {
                        if (addInverted) {
                            b.Suggest("!" + typeName);
                        }
                        if (addNormal) {
                            b.Suggest(typeName);
                        }
                    }
                }
                return b.BuildFuture();
            });
            int start = parser.Reader.Cursor;
            bool inverted = parser.ShouldInvertValue();
            if (!state.CanParseElement(inverted)) {
                throw RollbackAndThrow(parser, start, ErrorInapplicableOption, "gamemode");
            }
            string name = parser.Reader.ReadUnquotedString();
            if (GameModeArgument.ByName(name) == null) {
                throw RollbackAndThrow(parser, start, ErrorGameModeInvalid, name);
            }
            parser.IncludesEntities = false;
            state.MarkParsedElement(inverted);
        }, s => s.GamemodeOption.CanParseAny());
        Register("team", parser => {
            InvertableSetOptionState state = parser.TeamOption;
            int start = parser.Reader.Cursor;
            bool inverted = parser.ShouldInvertValue();
            parser.Reader.ReadUnquotedString();
            if (!state.CanParseElement(inverted)) {
                throw RollbackAndThrow(parser, start, ErrorInapplicableOption, "team");
            }
            state.MarkParsedElement(inverted);
        }, s => s.TeamOption.CanParseAny());
        Register("type", parser => {
            InvertableSetOptionState state = parser.TypeOption;
            parser.SetSuggestions((b, _) => {
                IEnumerable<Identifier> keys = VanillaRegistry.Data.EntityTypes.All.Select(t => t.Identifier);
                if (state.CanParseNegativeElement()) {
                    SharedSuggestionProvider.SuggestResource(keys, b, EntitySelectorParser.SyntaxNot.ToString());
                }
                if (state.CanParsePositiveElement()) {
                    SharedSuggestionProvider.SuggestResource(keys, b);
                }
                if (state.CanParseAnyTag()) {
                    List<Identifier> allowedTags = (parser.EntityTypeTags ?? []).Where(state.CanParseTag).ToList();
                    if (allowedTags.Count > 0) {
                        SharedSuggestionProvider.SuggestResource(allowedTags, b, EntitySelectorParser.SyntaxTag.ToString());
                        SharedSuggestionProvider.SuggestResource(allowedTags, b, "!#");
                    }
                }
                return b.BuildFuture();
            });
            int start = parser.Reader.Cursor;
            bool inverted = parser.ShouldInvertValue();
            if (parser.IsTag()) {
                if (!state.CanParseAnyTag()) {
                    throw RollbackAndThrow(parser, start, ErrorInapplicableOption, "type");
                }
                Identifier id = Identifiers.Read(parser.Reader);
                if (!state.CanParseTag(id)) {
                    throw RollbackAndThrow(parser, start, ErrorInapplicableOption, "type");
                }
                state.MarkParsedTag(id);
            }
            else {
                if (!state.CanParseElement(inverted)) {
                    throw RollbackAndThrow(parser, start, ErrorInapplicableOption, "type");
                }
                Identifier id = Identifiers.Read(parser.Reader);
                if (!VanillaRegistry.Data.EntityTypes.Contains(id)) {
                    throw RollbackAndThrow(parser, start, ErrorEntityTypeInvalid, id.ToString());
                }
                IEntityType type = VanillaRegistry.Data.EntityTypes.Get(id);
                if (type.Identifier == EntityTypes.Player.Identifier && !inverted) {
                    parser.IncludesEntities = false;
                }
                if (!inverted) {
                    parser.LimitToType(type);
                }
                state.MarkParsedElement(inverted);
            }
        }, s => s.TypeOption.CanParseAny());
        Register("tag", parser => {
            parser.ShouldInvertValue();
            parser.Reader.ReadUnquotedString();
        }, AlwaysAvailable);
        Register("nbt", parser => {
            parser.ShouldInvertValue();
            TagParser.ParseCompoundAsArgument(parser.Reader);
        }, AlwaysAvailable);
        Register("scores", parser => {
            StringReader reader = parser.Reader;
            reader.Expect('{');
            reader.SkipWhitespace();
            while (reader.CanRead() && reader.Peek() != '}') {
                reader.SkipWhitespace();
                reader.ReadUnquotedString();
                reader.SkipWhitespace();
                reader.Expect('=');
                reader.SkipWhitespace();
                MinMaxBounds.Ints.FromReader(reader);
                reader.SkipWhitespace();
                if (reader.CanRead() && reader.Peek() == ',') {
                    reader.Skip();
                }
            }
            reader.Expect('}');
            parser.ScoresOption.MarkParsed();
        }, s => s.ScoresOption.CanParse());
        Register("advancements", parser => {
            StringReader reader = parser.Reader;
            bool any = false;
            reader.Expect('{');
            reader.SkipWhitespace();
            while (reader.CanRead() && reader.Peek() != '}') {
                reader.SkipWhitespace();
                Identifiers.Read(reader);
                reader.SkipWhitespace();
                reader.Expect('=');
                reader.SkipWhitespace();
                if (reader.CanRead() && reader.Peek() == '{') {
                    reader.SkipWhitespace();
                    reader.Expect('{');
                    reader.SkipWhitespace();
                    while (reader.CanRead() && reader.Peek() != '}') {
                        reader.SkipWhitespace();
                        reader.ReadUnquotedString();
                        reader.SkipWhitespace();
                        reader.Expect('=');
                        reader.SkipWhitespace();
                        reader.ReadBoolean();
                        reader.SkipWhitespace();
                        if (reader.CanRead() && reader.Peek() == ',') {
                            reader.Skip();
                        }
                    }
                    reader.SkipWhitespace();
                    reader.Expect('}');
                    reader.SkipWhitespace();
                }
                else {
                    reader.ReadBoolean();
                }
                any = true;
                reader.SkipWhitespace();
                if (reader.CanRead() && reader.Peek() == ',') {
                    reader.Skip();
                }
            }
            reader.Expect('}');
            if (any) {
                parser.IncludesEntities = false;
            }
            parser.AdvancementsOption.MarkParsed();
        }, s => s.AdvancementsOption.CanParse());
        Register("predicate", parser => {
            parser.ShouldInvertValue();
            Identifiers.Read(parser.Reader);
        }, AlwaysAvailable);
    }

    private static CommandSyntaxException RollbackAndThrow(EntitySelectorParser parser, int start, SimpleCommandExceptionType type) {
        parser.Reader.Cursor = start;
        return type.CreateWithContext(parser.Reader);
    }

    private static CommandSyntaxException RollbackAndThrow(EntitySelectorParser parser, int start, DynamicCommandExceptionType type, string argument) {
        parser.Reader.Cursor = start;
        return type.CreateWithContext(parser.Reader, argument);
    }

    public static Modifier Get(EntitySelectorParser parser, string key, int start) {
        if (!Options.TryGetValue(key, out Option? option)) {
            throw RollbackAndThrow(parser, start, ErrorUnknownOption, key);
        }
        if (!option.CanUse(parser)) {
            throw RollbackAndThrow(parser, start, ErrorInapplicableOption, key);
        }
        return option.Modifier;
    }

    /// <summary>Iterates a hash map in vanilla, which only orders the suggestions before they are sorted.</summary>
    public static void SuggestNames(EntitySelectorParser parser, SuggestionsBuilder builder) {
        string lowerPrefix = JavaText.ToLowerRoot(builder.Remaining);
        foreach ((string key, Option option) in Options) {
            if (option.CanUse(parser) && JavaText.ToLowerRoot(key).StartsWith(lowerPrefix, StringComparison.Ordinal)) {
                builder.Suggest(key + "=", option.Description);
            }
        }
    }
}
