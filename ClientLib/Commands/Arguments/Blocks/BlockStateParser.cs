using ClientLib.Brigadier;
using ClientLib.Nbt;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using NBT.Tags;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>BlockStateParser</c>.</summary>
public sealed class BlockStateParser {
    public static readonly SimpleCommandExceptionType ErrorNoTagsAllowed = new(Component.Translatable("argument.block.tag.disallowed"));
    public static readonly DynamicCommandExceptionType ErrorUnknownBlock = new(id => Component.TranslatableEscape("argument.block.id.invalid", id));
    public static readonly Dynamic2CommandExceptionType ErrorUnknownProperty = new((block, property) => Component.TranslatableEscape("argument.block.property.unknown", block, property));
    public static readonly Dynamic2CommandExceptionType ErrorDuplicateProperty = new((block, property) => Component.TranslatableEscape("argument.block.property.duplicate", property, block));
    public static readonly Dynamic3CommandExceptionType ErrorInvalidValue = new((block, property, value) => Component.TranslatableEscape("argument.block.property.invalid", block, value, property));
    public static readonly Dynamic2CommandExceptionType ErrorExpectedValue = new((block, property) => Component.TranslatableEscape("argument.block.property.novalue", property, block));
    public static readonly SimpleCommandExceptionType ErrorExpectedEndOfProperties = new(Component.Translatable("argument.block.property.unclosed"));
    public static readonly DynamicCommandExceptionType ErrorUnknownTag = new(tag => Component.TranslatableEscape("arguments.block.tag.unknown", tag));

    private const char SyntaxStartProperties = '[';
    private const char SyntaxStartNbt = '{';
    private const char SyntaxEndProperties = ']';
    private const char SyntaxEquals = '=';
    private const char SyntaxPropertySeparator = ',';
    private const char SyntaxTag = '#';

    private static readonly Func<SuggestionsBuilder, Task<Suggestions>> SuggestNothing = builder => builder.BuildFuture();

    private readonly BlockLookup _blocks;
    private readonly StringReader _reader;
    private readonly bool _forTesting;
    private readonly bool _allowNbt;

    /// <summary>Keyed by property name: one block's properties are unique by name, which is all vanilla's map by property relies on.</summary>
    private readonly Dictionary<string, string> _properties = new();

    private readonly Dictionary<string, string> _vagueProperties = new();
    private Identifier _id = new(Identifiers.DefaultNamespace, "");
    private BlockStateDefinition? _definition;
    private IBlock? _state;
    private CompoundTag? _nbt;
    private IReadOnlyList<IBlock>? _tag;
    private Func<SuggestionsBuilder, Task<Suggestions>> _suggestions = SuggestNothing;

    private BlockStateParser(BlockLookup blocks, StringReader reader, bool forTesting, bool allowNbt) {
        _blocks = blocks;
        _reader = reader;
        _forTesting = forTesting;
        _allowNbt = allowNbt;
    }

    public static BlockResult ParseForBlock(BlockLookup blocks, StringReader reader, bool allowNbt) {
        BlockStateParser parser = ParseRewinding(new BlockStateParser(blocks, reader, false, allowNbt));
        return new BlockResult(parser._state!, parser._properties, parser._nbt);
    }

    /// <returns>A <see cref="BlockResult"/> or a <see cref="TagResult"/>, vanilla's <c>Either</c>.</returns>
    public static object ParseForTesting(BlockLookup blocks, StringReader reader, bool allowNbt) {
        BlockStateParser parser = ParseRewinding(new BlockStateParser(blocks, reader, true, allowNbt));
        return parser._tag != null
            ? new TagResult(parser._tag, parser._vagueProperties, parser._nbt)
            : new BlockResult(parser._state!, parser._properties, parser._nbt);
    }

    private static BlockStateParser ParseRewinding(BlockStateParser parser) {
        int cursor = parser._reader.Cursor;
        try {
            parser.Parse();
            return parser;
        }
        catch (CommandSyntaxException) {
            parser._reader.Cursor = cursor;
            throw;
        }
    }

    public static Task<Suggestions> FillSuggestions(BlockLookup blocks, SuggestionsBuilder builder, bool forTesting, bool allowNbt) {
        StringReader reader = new(builder.Input) { Cursor = builder.Start };
        BlockStateParser parser = new(blocks, reader, forTesting, allowNbt);
        try {
            parser.Parse();
        }
        catch (CommandSyntaxException) {
        }
        return parser._suggestions(builder.CreateOffset(reader.Cursor));
    }

    private void Parse() {
        _suggestions = _forTesting ? SuggestBlockIdOrTag : SuggestItem;

        if (_reader.CanRead() && _reader.Peek() == SyntaxTag) {
            ReadTag();
            _suggestions = SuggestOpenVaguePropertiesOrNbt;
            if (_reader.CanRead() && _reader.Peek() == SyntaxStartProperties) {
                ReadVagueProperties();
                _suggestions = SuggestOpenNbt;
            }
        }
        else {
            ReadBlock();
            _suggestions = SuggestOpenPropertiesOrNbt;
            if (_reader.CanRead() && _reader.Peek() == SyntaxStartProperties) {
                ReadProperties();
                _suggestions = SuggestOpenNbt;
            }
        }

        if (_allowNbt && _reader.CanRead() && _reader.Peek() == SyntaxStartNbt) {
            _suggestions = SuggestNothing;
            ReadNbt();
        }
    }

    private Task<Suggestions> SuggestPropertyNameOrEnd(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0) {
            builder.Suggest(SyntaxEndProperties.ToString());
        }
        return SuggestPropertyName(builder);
    }

    private Task<Suggestions> SuggestVaguePropertyNameOrEnd(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0) {
            builder.Suggest(SyntaxEndProperties.ToString());
        }
        return SuggestVaguePropertyName(builder);
    }

    private Task<Suggestions> SuggestPropertyName(SuggestionsBuilder builder) {
        string prefix = JavaText.ToLowerRoot(builder.Remaining);
        foreach (BlockProperty property in _definition!.Properties) {
            if (!_properties.ContainsKey(property.Name) && property.Name.StartsWith(prefix, StringComparison.Ordinal)) {
                builder.Suggest(property.Name + SyntaxEquals);
            }
        }
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestVaguePropertyName(SuggestionsBuilder builder) {
        string prefix = JavaText.ToLowerRoot(builder.Remaining);
        if (_tag != null) {
            foreach (IBlock block in _tag) {
                foreach (BlockProperty property in _blocks.DefinitionOf(block).Properties) {
                    if (!_vagueProperties.ContainsKey(property.Name) && property.Name.StartsWith(prefix, StringComparison.Ordinal)) {
                        builder.Suggest(property.Name + SyntaxEquals);
                    }
                }
            }
        }
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOpenNbt(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0 && HasBlockEntity()) {
            builder.Suggest(SyntaxStartNbt.ToString());
        }
        return builder.BuildFuture();
    }

    private bool HasBlockEntity() => _state != null ? _state.BlockEntity != null : _tag?.Any(block => block.BlockEntity != null) == true;

    private Task<Suggestions> SuggestEquals(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0) {
            builder.Suggest(SyntaxEquals.ToString());
        }
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestNextPropertyOrEnd(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0) {
            builder.Suggest(SyntaxEndProperties.ToString());
        }
        if (builder.Remaining.Length == 0 && _properties.Count < _definition!.Properties.Count) {
            builder.Suggest(SyntaxPropertySeparator.ToString());
        }
        return builder.BuildFuture();
    }

    private static SuggestionsBuilder AddSuggestions(SuggestionsBuilder builder, BlockProperty property) {
        foreach (string value in property.PossibleValueNames) {
            if (property.IsInteger) {
                builder.Suggest(int.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
            }
            else {
                builder.Suggest(value);
            }
        }
        return builder;
    }

    private Task<Suggestions> SuggestVaguePropertyValue(SuggestionsBuilder builder, string key) {
        bool hasMoreProperties = false;
        if (_tag != null) {
            foreach (IBlock block in _tag) {
                BlockStateDefinition definition = _blocks.DefinitionOf(block);
                BlockProperty? property = definition.GetProperty(key);
                if (property != null) {
                    AddSuggestions(builder, property);
                }
                hasMoreProperties = hasMoreProperties || definition.Properties.Any(prop => !_vagueProperties.ContainsKey(prop.Name));
            }
        }
        if (hasMoreProperties) {
            builder.Suggest(SyntaxPropertySeparator.ToString());
        }
        builder.Suggest(SyntaxEndProperties.ToString());
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOpenVaguePropertiesOrNbt(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0 && _tag != null) {
            bool hasProperties = false;
            bool hasEntity = false;
            foreach (IBlock block in _tag) {
                hasProperties |= _blocks.DefinitionOf(block).Properties.Count > 0;
                hasEntity |= block.BlockEntity != null;
                if (hasProperties && hasEntity) {
                    break;
                }
            }
            if (hasProperties) {
                builder.Suggest(SyntaxStartProperties.ToString());
            }
            if (hasEntity) {
                builder.Suggest(SyntaxStartNbt.ToString());
            }
        }
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestOpenPropertiesOrNbt(SuggestionsBuilder builder) {
        if (builder.Remaining.Length == 0) {
            if (_definition!.Properties.Count > 0) {
                builder.Suggest(SyntaxStartProperties.ToString());
            }
            if (_state!.BlockEntity != null) {
                builder.Suggest(SyntaxStartNbt.ToString());
            }
        }
        return builder.BuildFuture();
    }

    private Task<Suggestions> SuggestTag(SuggestionsBuilder builder) => SharedSuggestionProvider.SuggestResource(_blocks.ListTagIds(), builder, SyntaxTag.ToString());

    private Task<Suggestions> SuggestItem(SuggestionsBuilder builder) => SharedSuggestionProvider.SuggestResource(_blocks.ListElementIds(), builder);

    private Task<Suggestions> SuggestBlockIdOrTag(SuggestionsBuilder builder) {
        SuggestTag(builder);
        SuggestItem(builder);
        return builder.BuildFuture();
    }

    private void ReadBlock() {
        int start = _reader.Cursor;
        _id = Identifiers.Read(_reader);
        IBlock? block = _blocks.Get(_id);
        if (block == null) {
            _reader.Cursor = start;
            throw ErrorUnknownBlock.CreateWithContext(_reader, _id.ToString());
        }
        _definition = _blocks.DefinitionOf(block);
        _state = block;
    }

    private void ReadTag() {
        if (!_forTesting) {
            throw ErrorNoTagsAllowed.CreateWithContext(_reader);
        }
        int start = _reader.Cursor;
        _reader.Expect(SyntaxTag);
        _suggestions = SuggestTag;
        Identifier id = Identifiers.Read(_reader);
        _tag = _blocks.GetTag(id);
        if (_tag == null) {
            _reader.Cursor = start;
            throw ErrorUnknownTag.CreateWithContext(_reader, id.ToString());
        }
    }

    private void ReadProperties() {
        _reader.Skip();
        _suggestions = SuggestPropertyNameOrEnd;
        _reader.SkipWhitespace();

        while (_reader.CanRead() && _reader.Peek() != SyntaxEndProperties) {
            _reader.SkipWhitespace();
            int keyStart = _reader.Cursor;
            string key = _reader.ReadString();
            BlockProperty? property = _definition!.GetProperty(key);
            if (property == null) {
                _reader.Cursor = keyStart;
                throw ErrorUnknownProperty.CreateWithContext(_reader, _id.ToString(), key);
            }
            if (_properties.ContainsKey(property.Name)) {
                _reader.Cursor = keyStart;
                throw ErrorDuplicateProperty.CreateWithContext(_reader, _id.ToString(), key);
            }

            _reader.SkipWhitespace();
            _suggestions = SuggestEquals;
            if (!_reader.CanRead() || _reader.Peek() != SyntaxEquals) {
                throw ErrorExpectedValue.CreateWithContext(_reader, _id.ToString(), key);
            }

            _reader.Skip();
            _reader.SkipWhitespace();
            _suggestions = builder => AddSuggestions(builder, property).BuildFuture();
            int start = _reader.Cursor;
            SetValue(property, _reader.ReadString(), start);
            _suggestions = SuggestNextPropertyOrEnd;
            _reader.SkipWhitespace();
            if (!_reader.CanRead()) {
                continue;
            }
            if (_reader.Peek() != SyntaxPropertySeparator) {
                if (_reader.Peek() != SyntaxEndProperties) {
                    throw ErrorExpectedEndOfProperties.CreateWithContext(_reader);
                }
                break;
            }
            _reader.Skip();
            _suggestions = SuggestPropertyName;
        }

        if (!_reader.CanRead()) {
            throw ErrorExpectedEndOfProperties.CreateWithContext(_reader);
        }
        _reader.Skip();
    }

    private void ReadVagueProperties() {
        _reader.Skip();
        _suggestions = SuggestVaguePropertyNameOrEnd;
        int valueStart = -1;
        _reader.SkipWhitespace();

        while (_reader.CanRead() && _reader.Peek() != SyntaxEndProperties) {
            _reader.SkipWhitespace();
            int keyStart = _reader.Cursor;
            string key = _reader.ReadString();
            if (_vagueProperties.ContainsKey(key)) {
                _reader.Cursor = keyStart;
                throw ErrorDuplicateProperty.CreateWithContext(_reader, _id.ToString(), key);
            }

            _reader.SkipWhitespace();
            if (!_reader.CanRead() || _reader.Peek() != SyntaxEquals) {
                _reader.Cursor = keyStart;
                throw ErrorExpectedValue.CreateWithContext(_reader, _id.ToString(), key);
            }

            _reader.Skip();
            _reader.SkipWhitespace();
            _suggestions = builder => SuggestVaguePropertyValue(builder, key);
            valueStart = _reader.Cursor;
            string value = _reader.ReadString();
            _vagueProperties[key] = value;
            _reader.SkipWhitespace();
            if (!_reader.CanRead()) {
                continue;
            }
            valueStart = -1;
            if (_reader.Peek() != SyntaxPropertySeparator) {
                if (_reader.Peek() != SyntaxEndProperties) {
                    throw ErrorExpectedEndOfProperties.CreateWithContext(_reader);
                }
                break;
            }
            _reader.Skip();
            _suggestions = SuggestVaguePropertyName;
        }

        if (_reader.CanRead()) {
            _reader.Skip();
            return;
        }
        if (valueStart >= 0) {
            _reader.Cursor = valueStart;
        }
        throw ErrorExpectedEndOfProperties.CreateWithContext(_reader);
    }

    private void ReadNbt() => _nbt = TagParser.ParseCompoundAsArgument(_reader);

    private void SetValue(BlockProperty property, string raw, int start) {
        string? value = property.GetValue(raw);
        if (value == null) {
            _reader.Cursor = start;
            throw ErrorInvalidValue.CreateWithContext(_reader, _id.ToString(), property.Name, raw);
        }
        _state = _state!.WithState(new CompoundTag((property.Name, new StringTag(value))));
        _properties[property.Name] = value;
    }

    /// <summary><c>BlockStateParser.BlockResult</c>. The properties are by name, with their values' serialised names.</summary>
    public sealed record BlockResult(IBlock BlockState, IReadOnlyDictionary<string, string> Properties, CompoundTag? Nbt);

    /// <summary><c>BlockStateParser.TagResult</c>.</summary>
    public sealed record TagResult(IReadOnlyList<IBlock> Tag, IReadOnlyDictionary<string, string> VagueProperties, CompoundTag? Nbt);
}
