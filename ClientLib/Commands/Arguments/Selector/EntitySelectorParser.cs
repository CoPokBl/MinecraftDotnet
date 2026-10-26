using ClientLib.Brigadier;
using ClientLib.Maths;
using Minecraft.Data.Entities;
using Minecraft.Schemas;
using EntityTypes = Minecraft.Data.Generated.EntityType;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>EntitySelectorParser</c>.</summary>
public sealed class EntitySelectorParser {
    public const char SyntaxSelectorStart = '@';
    private const char SyntaxOptionsStart = '[';
    private const char SyntaxOptionsEnd = ']';
    public const char SyntaxOptionsKeyValueSeparator = '=';
    private const char SyntaxOptionsSeparator = ',';
    public const char SyntaxNot = '!';
    public const char SyntaxTag = '#';
    private const char SelectorNearestPlayer = 'p';
    private const char SelectorAllPlayers = 'a';
    private const char SelectorRandomPlayers = 'r';
    private const char SelectorCurrentEntity = 's';
    private const char SelectorAllEntities = 'e';
    private const char SelectorNearestEntity = 'n';

    public static readonly SimpleCommandExceptionType ErrorInvalidNameOrUuid = new(Component.Translatable("argument.entity.invalid"));
    public static readonly DynamicCommandExceptionType ErrorUnknownSelectorType = new(type => Component.TranslatableEscape("argument.entity.selector.unknown", type));
    public static readonly SimpleCommandExceptionType ErrorSelectorsNotAllowed = new(Component.Translatable("argument.entity.selector.not_allowed"));
    public static readonly SimpleCommandExceptionType ErrorMissingSelectorType = new(Component.Translatable("argument.entity.selector.missing"));
    public static readonly SimpleCommandExceptionType ErrorExpectedEndOfOptions = new(Component.Translatable("argument.entity.options.unterminated"));
    public static readonly DynamicCommandExceptionType ErrorExpectedOptionValue = new(name => Component.TranslatableEscape("argument.entity.options.valueless", name));

    /// <summary>Vanilla's <c>BiFunction&lt;SuggestionsBuilder, Consumer&lt;SuggestionsBuilder&gt;, CompletableFuture&lt;Suggestions&gt;&gt;</c>.</summary>
    public delegate Task<Suggestions> SuggestionsFunction(SuggestionsBuilder builder, Action<SuggestionsBuilder> names);

    public static readonly SuggestionsFunction SuggestNothing = (b, _) => b.BuildFuture();

    private readonly StringReader _reader;
    private readonly bool _allowSelectors;
    private bool _worldLimited;
    private string? _playerName;
    private int _startPosition;
    private Guid? _entityUuid;
    private SuggestionsFunction _suggestions = SuggestNothing;
    private IEntityType? _type;
    private bool _usesSelectors;

    public EntitySelectorParser(StringReader reader, bool allowSelectors) {
        _reader = reader;
        _allowSelectors = allowSelectors;
    }

    /// <summary>
    /// The entity type tags the <c>type</c> option suggests. Vanilla reads them off the client's
    /// registry, which the parser cannot reach, so the argument type sets them; null suggests none.
    /// </summary>
    public IEnumerable<Identifier>? EntityTypeTags { get; set; }

    public StringReader Reader => _reader;
    public MinMaxBounds.Doubles? Distance { get; set; }
    public MinMaxBounds.Ints? Level { get; set; }
    public MinMaxBounds.FloatDegrees? RotX { get; set; }
    public MinMaxBounds.FloatDegrees? RotY { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }
    public double? Z { get; set; }
    public double? DeltaX { get; set; }
    public double? DeltaY { get; set; }
    public double? DeltaZ { get; set; }
    public int MaxResults { get; set; }
    public bool IncludesEntities { get; set; }
    public EntitySelectorOrder Order { get; set; } = EntitySelectorOrder.Arbitrary;
    public bool IsCurrentEntity { get; private set; }

    public InvertableSetOptionState NameOption { get; } = new();
    public SetOnceOptionState LimitedOption { get; } = new();
    public SetOnceOptionState SortedOption { get; } = new();
    public InvertableSetOptionState GamemodeOption { get; } = new();
    public InvertableSetOptionState TeamOption { get; } = new();
    public InvertableSetOptionState TypeOption { get; } = new();
    public SetOnceOptionState ScoresOption { get; } = new();
    public SetOnceOptionState AdvancementsOption { get; } = new();

    public static bool AllowSelectors<TSource>(TSource source) =>
        source is ISharedSuggestionProvider sender && sender.Permissions.HasPermission(Permissions.CommandsEntitySelectors);

    public void SetWorldLimited() => _worldLimited = true;

    public void LimitToType(IEntityType type) => _type = type;

    public void SetSuggestions(SuggestionsFunction suggestions) => _suggestions = suggestions;

    private EntitySelector GetSelector() {
        EntitySelector.Box? aabb;
        if (DeltaX == null && DeltaY == null && DeltaZ == null) {
            aabb = Distance?.Max is { } maxRange
                ? new EntitySelector.Box(-maxRange, -maxRange, -maxRange, maxRange + 1.0, maxRange + 1.0, maxRange + 1.0)
                : null;
        }
        else {
            aabb = CreateAabb(DeltaX ?? 0.0, DeltaY ?? 0.0, DeltaZ ?? 0.0);
        }

        Func<Vec3d, Vec3d> position;
        if (X == null && Y == null && Z == null) {
            position = o => o;
        }
        else {
            double? x = X, y = Y, z = Z;
            position = o => new Vec3d(x ?? o.X, y ?? o.Y, z ?? o.Z);
        }

        return new EntitySelector(MaxResults, IncludesEntities, _worldLimited, Distance, position, aabb, Order, IsCurrentEntity, _playerName,
            _entityUuid, _type, _usesSelectors);
    }

    private static EntitySelector.Box CreateAabb(double x, double y, double z) {
        bool xNeg = x < 0.0;
        bool yNeg = y < 0.0;
        bool zNeg = z < 0.0;
        double xMin = xNeg ? x : 0.0;
        double yMin = yNeg ? y : 0.0;
        double zMin = zNeg ? z : 0.0;
        double xMax = (xNeg ? 0.0 : x) + 1.0;
        double yMax = (yNeg ? 0.0 : y) + 1.0;
        double zMax = (zNeg ? 0.0 : z) + 1.0;
        return new EntitySelector.Box(xMin, yMin, zMin, xMax, yMax, zMax);
    }

    private void ParseSelector() {
        _usesSelectors = true;
        _suggestions = SuggestSelector;
        if (!_reader.CanRead()) {
            throw ErrorMissingSelectorType.CreateWithContext(_reader);
        }
        int start = _reader.Cursor;
        char type = _reader.ReadChar();
        switch (type) {
            case SelectorAllPlayers:
                MaxResults = int.MaxValue;
                IncludesEntities = false;
                Order = EntitySelectorOrder.Arbitrary;
                LimitToType(EntityTypes.Player);
                break;
            case SelectorAllEntities:
                MaxResults = int.MaxValue;
                IncludesEntities = true;
                Order = EntitySelectorOrder.Arbitrary;
                break;
            case SelectorNearestEntity:
                MaxResults = 1;
                IncludesEntities = true;
                Order = EntitySelectorOrder.Nearest;
                break;
            case SelectorNearestPlayer:
                MaxResults = 1;
                IncludesEntities = false;
                Order = EntitySelectorOrder.Nearest;
                LimitToType(EntityTypes.Player);
                break;
            case SelectorRandomPlayers:
                MaxResults = 1;
                IncludesEntities = false;
                Order = EntitySelectorOrder.Random;
                LimitToType(EntityTypes.Player);
                break;
            case SelectorCurrentEntity:
                MaxResults = 1;
                IncludesEntities = true;
                IsCurrentEntity = true;
                break;
            default:
                _reader.Cursor = start;
                throw ErrorUnknownSelectorType.CreateWithContext(_reader, "@" + type);
        }

        _suggestions = SuggestOpenOptions;
        if (_reader.CanRead() && _reader.Peek() == SyntaxOptionsStart) {
            _reader.Skip();
            _suggestions = SuggestOptionsKeyOrClose;
            ParseOptions();
        }
    }

    private void ParseNameOrUuid() {
        if (_reader.CanRead()) {
            _suggestions = SuggestName;
        }
        int start = _reader.Cursor;
        string name = _reader.ReadString();
        if (JavaUuid.TryParse(name, out Guid uuid)) {
            _entityUuid = uuid;
            IncludesEntities = true;
        }
        else {
            if (name.Length == 0 || name.Length > 16) {
                _reader.Cursor = start;
                throw ErrorInvalidNameOrUuid.CreateWithContext(_reader);
            }
            IncludesEntities = false;
            _playerName = name;
        }
        MaxResults = 1;
    }

    private void ParseOptions() {
        _suggestions = SuggestOptionsKey;
        _reader.SkipWhitespace();
        while (_reader.CanRead() && _reader.Peek() != SyntaxOptionsEnd) {
            _reader.SkipWhitespace();
            int start = _reader.Cursor;
            string key = _reader.ReadString();
            EntitySelectorOptions.Modifier modifier = EntitySelectorOptions.Get(this, key, start);
            _reader.SkipWhitespace();
            if (!_reader.CanRead() || _reader.Peek() != SyntaxOptionsKeyValueSeparator) {
                _reader.Cursor = start;
                throw ErrorExpectedOptionValue.CreateWithContext(_reader, key);
            }
            _reader.Skip();
            _reader.SkipWhitespace();
            _suggestions = SuggestNothing;
            modifier(this);
            _reader.SkipWhitespace();
            _suggestions = SuggestOptionsNextOrClose;
            if (_reader.CanRead()) {
                if (_reader.Peek() != SyntaxOptionsSeparator) {
                    if (_reader.Peek() != SyntaxOptionsEnd) {
                        throw ErrorExpectedEndOfOptions.CreateWithContext(_reader);
                    }
                    break;
                }
                _reader.Skip();
                _suggestions = SuggestOptionsKey;
            }
        }

        if (!_reader.CanRead()) {
            throw ErrorExpectedEndOfOptions.CreateWithContext(_reader);
        }
        _reader.Skip();
        _suggestions = SuggestNothing;
    }

    public bool ShouldInvertValue() {
        _reader.SkipWhitespace();
        if (_reader.CanRead() && _reader.Peek() == SyntaxNot) {
            _reader.Skip();
            _reader.SkipWhitespace();
            return true;
        }
        return false;
    }

    public bool IsTag() {
        _reader.SkipWhitespace();
        if (_reader.CanRead() && _reader.Peek() == SyntaxTag) {
            _reader.Skip();
            _reader.SkipWhitespace();
            return true;
        }
        return false;
    }

    public EntitySelector Parse() {
        _startPosition = _reader.Cursor;
        _suggestions = SuggestNameOrSelector;
        if (_reader.CanRead() && _reader.Peek() == SyntaxSelectorStart) {
            if (!_allowSelectors) {
                throw ErrorSelectorsNotAllowed.CreateWithContext(_reader);
            }
            _reader.Skip();
            ParseSelector();
        }
        else {
            ParseNameOrUuid();
        }
        return GetSelector();
    }

    private static void FillSelectorSuggestions(SuggestionsBuilder builder) {
        builder.Suggest("@p", Component.Translatable("argument.entity.selector.nearestPlayer"));
        builder.Suggest("@a", Component.Translatable("argument.entity.selector.allPlayers"));
        builder.Suggest("@r", Component.Translatable("argument.entity.selector.randomPlayer"));
        builder.Suggest("@s", Component.Translatable("argument.entity.selector.self"));
        builder.Suggest("@e", Component.Translatable("argument.entity.selector.allEntities"));
        builder.Suggest("@n", Component.Translatable("argument.entity.selector.nearestEntity"));
    }

    private Task<Suggestions> SuggestNameOrSelector(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        names(builder);
        if (_allowSelectors) {
            FillSelectorSuggestions(builder);
        }
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestName(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        SuggestionsBuilder sub = builder.CreateOffset(_startPosition);
        names(sub);
        return builder.Add(sub).BuildFuture();
    }

    private Task<Suggestions> SuggestSelector(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        SuggestionsBuilder sub = builder.CreateOffset(builder.Start - 1);
        FillSelectorSuggestions(sub);
        builder.Add(sub);
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOpenOptions(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        builder.Suggest(SyntaxOptionsStart.ToString());
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOptionsKeyOrClose(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        builder.Suggest(SyntaxOptionsEnd.ToString());
        EntitySelectorOptions.SuggestNames(this, builder);
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOptionsKey(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        EntitySelectorOptions.SuggestNames(this, builder);
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOptionsNextOrClose(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) {
        builder.Suggest(SyntaxOptionsSeparator.ToString());
        builder.Suggest(SyntaxOptionsEnd.ToString());
        return builder.BuildFuture();
    }

    public Task<Suggestions> FillSuggestions(SuggestionsBuilder builder, Action<SuggestionsBuilder> names) => _suggestions(builder.CreateOffset(_reader.Cursor), names);
}
