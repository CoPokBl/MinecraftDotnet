using System.Globalization;
using System.Text.RegularExpressions;
using ClientLib.Brigadier;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;

namespace ClientLib.Commands.Arguments;

/// <summary>
/// <c>StringRepresentable.getSerializedName</c> for the vanilla enums the arguments match against,
/// whose serialised names are their constants in snake case.
/// </summary>
internal static class SerializedNames {
    private static string Snake(string pascal) {
        System.Text.StringBuilder result = new();
        for (int i = 0; i < pascal.Length; i++) {
            char c = pascal[i];
            if (char.IsUpper(c) && i > 0) {
                result.Append('_');
            }
            result.Append(char.ToLowerInvariant(c));
        }
        return result.ToString();
    }

    /// <summary>Vanilla's <c>TeamColor</c>: the sixteen colours, without the formatting codes the packet enum also holds.</summary>
    public static readonly ClientBoundUpdateTeamsPacket.TeamColor[] TeamColors = Enumerable.Range(0, 16).Select(i => (ClientBoundUpdateTeamsPacket.TeamColor)i).ToArray();

    public static string Of(ClientBoundUpdateTeamsPacket.TeamColor color) => Snake(color.ToString());
}

/// <summary>Vanilla's <c>DimensionArgument</c>.</summary>
public sealed class DimensionArgument : ArgumentType<Identifier> {
    private static readonly string[] ExampleValues = ["minecraft:overworld", "minecraft:the_nether"];

    public override Identifier Parse(StringReader reader) => Identifiers.Read(reader);

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return context.Source is ISharedSuggestionProvider source
            ? SharedSuggestionProvider.SuggestResource(source.Levels, builder)
            : Suggestions.Empty();
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>GameModeArgument</c>.</summary>
public sealed class GameModeArgument : ArgumentType<GameMode> {
    /// <summary><c>GameType.values()</c>, in ordinal order.</summary>
    public static readonly GameMode[] Values = [GameMode.Survival, GameMode.Creative, GameMode.Adventure, GameMode.Spectator];
    private static readonly string[] ExampleValues = [NameOf(GameMode.Survival), NameOf(GameMode.Creative)];

    private static readonly DynamicCommandExceptionType ErrorInvalid = new(value => Component.TranslatableEscape("argument.gamemode.invalid", value));

    /// <summary><c>GameType.getName</c>.</summary>
    public static string NameOf(GameMode mode) => mode.ToString().ToLowerInvariant();

    /// <summary><c>GameType.byName(name, null)</c>.</summary>
    public static GameMode? ByName(string name) {
        int index = Array.FindIndex(Values, mode => NameOf(mode) == name);
        return index >= 0 ? Values[index] : null;
    }

    public override GameMode Parse(StringReader reader) {
        string gameTypeString = reader.ReadUnquotedString();
        return ByName(gameTypeString) ?? throw ErrorInvalid.CreateWithContext(reader, gameTypeString);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return context.Source is ISharedSuggestionProvider
            ? SharedSuggestionProvider.Suggest(Values.Select(NameOf), builder)
            : Suggestions.Empty();
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>TeamColorArgument</c>.</summary>
public sealed class TeamColorArgument : ArgumentType<ClientBoundUpdateTeamsPacket.TeamColor> {
    private static readonly string[] ExampleValues = ["red", "green"];

    public static readonly DynamicCommandExceptionType ErrorInvalidValue = new(value => Component.TranslatableEscape("argument.color.invalid", value));

    public override ClientBoundUpdateTeamsPacket.TeamColor Parse(StringReader reader) {
        string id = reader.ReadUnquotedString();
        int index = Array.FindIndex(SerializedNames.TeamColors, color => SerializedNames.Of(color) == id);
        return index >= 0 ? SerializedNames.TeamColors[index] : throw ErrorInvalidValue.CreateWithContext(reader, id);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(SerializedNames.TeamColors.Select(SerializedNames.Of), builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>HexColorArgument</c>.</summary>
public sealed class HexColorArgument : ArgumentType<int> {
    private static readonly string[] ExampleValues = ["F00", "FF0000"];

    public static readonly DynamicCommandExceptionType ErrorInvalidHex = new(value => Component.TranslatableEscape("argument.hexcolor.invalid", value));

    public override int Parse(StringReader reader) {
        string colorString = reader.ReadUnquotedString();
        return colorString.Length switch {
            3 => Color(DuplicateDigit(ParseHex(colorString, 0, 1)), DuplicateDigit(ParseHex(colorString, 1, 2)), DuplicateDigit(ParseHex(colorString, 2, 3))),
            6 => Color(ParseHex(colorString, 0, 2), ParseHex(colorString, 2, 4), ParseHex(colorString, 4, 6)),
            _ => throw ErrorInvalidHex.CreateWithContext(reader, colorString)
        };
    }

    /// <summary><c>ARGB.color(r, g, b)</c>, opaque.</summary>
    private static int Color(int r, int g, int b) => unchecked((int)0xFF000000) | r << 16 | g << 8 | b;

    private static int DuplicateDigit(int digit) => digit * 17;

    /// <summary>
    /// <c>Integer.parseInt(s, begin, end, 16)</c>. A non-hex character the unquoted string allows throws
    /// a non-syntax exception, which the dispatcher reports as <c>command.exception</c>, as vanilla's does.
    /// </summary>
    private static int ParseHex(string s, int begin, int end) {
        string digits = s[begin..end];
        int start = digits.Length > 1 && digits[0] is '+' or '-' ? 1 : 0;
        for (int i = start; i < digits.Length; i++) {
            if (!char.IsAsciiHexDigit(digits[i])) {
                throw new FormatException($"Error at index {i} in: \"{digits}\"");
            }
        }
        if (start == digits.Length || digits.Length == 1 && digits[0] is '+' or '-') {
            throw new FormatException($"Error at index 0 in: \"{digits}\"");
        }
        int value = int.Parse(digits[start..], NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
        return digits[0] == '-' ? -value : value;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(ExampleValues, builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>UuidArgument</c>.</summary>
public sealed partial class UuidArgument : ArgumentType<Guid> {
    private static readonly string[] ExampleValues = ["dd12be42-52a9-4a91-a8a1-11c01849e498"];

    public static readonly SimpleCommandExceptionType ErrorInvalidUuid = new(Component.Translatable("argument.uuid.invalid"));

    [GeneratedRegex("^([-A-Fa-f0-9]+)")]
    private static partial Regex AllowedCharacters();

    public override Guid Parse(StringReader reader) {
        string remaining = reader.Remaining;
        Match matcher = AllowedCharacters().Match(remaining);
        if (matcher.Success) {
            string maybeUuid = matcher.Groups[1].Value;
            if (JavaUuid.TryParse(maybeUuid, out Guid result)) {
                reader.Cursor += maybeUuid.Length;
                return result;
            }
        }
        throw ErrorInvalidUuid.CreateWithContext(reader);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>IdentifierArgument</c>.</summary>
public sealed class IdentifierArgument : ArgumentType<Identifier> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012"];

    public override Identifier Parse(StringReader reader) => Identifiers.Read(reader);

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>EntityAnchorArgument</c>.</summary>
public sealed class EntityAnchorArgument : ArgumentType<EntityAnchorArgument.Anchor> {
    public enum Anchor { Feet, Eyes }

    private static readonly string[] ExampleValues = ["eyes", "feet"];

    private static readonly DynamicCommandExceptionType ErrorInvalid = new(name => Component.TranslatableEscape("argument.anchor.invalid", name));

    public static string NameOf(Anchor anchor) => anchor == Anchor.Feet ? "feet" : "eyes";

    public static Anchor? GetByName(string name) => name switch {
        "feet" => Anchor.Feet,
        "eyes" => Anchor.Eyes,
        _ => null
    };

    public override Anchor Parse(StringReader reader) {
        int start = reader.Cursor;
        string name = reader.ReadUnquotedString();
        if (GetByName(name) is not { } anchor) {
            reader.Cursor = start;
            throw ErrorInvalid.CreateWithContext(reader, name);
        }
        return anchor;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest([NameOf(Anchor.Feet), NameOf(Anchor.Eyes)], builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>TeamArgument</c>.</summary>
public sealed class TeamArgument : ArgumentType<string> {
    private static readonly string[] ExampleValues = ["foo", "123"];

    public override string Parse(StringReader reader) => reader.ReadUnquotedString();

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return context.Source is ISharedSuggestionProvider source
            ? SharedSuggestionProvider.Suggest(source.AllTeams, builder)
            : Suggestions.Empty();
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ObjectiveArgument</c>. A client source never holds the scoreboard's objective names, so it always asks the server.</summary>
public sealed class ObjectiveArgument : ArgumentType<string> {
    private static readonly string[] ExampleValues = ["foo", "*", "012"];

    public override string Parse(StringReader reader) => reader.ReadUnquotedString();

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return context.Source is ISharedSuggestionProvider source ? source.CustomSuggestion(context) : Suggestions.Empty();
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>OperationArgument</c>. The operation itself is the server's; the parse keeps its symbol.</summary>
public sealed class OperationArgument : ArgumentType<string> {
    private static readonly string[] ExampleValues = ["=", ">", "<"];
    private static readonly string[] Operations = ["=", "+=", "-=", "*=", "/=", "%=", "<", ">", "><"];

    private static readonly SimpleCommandExceptionType ErrorInvalidOperation = new(Component.Translatable("arguments.operation.invalid"));

    public override string Parse(StringReader reader) {
        if (!reader.CanRead()) {
            throw ErrorInvalidOperation.CreateWithContext(reader);
        }
        return GetOperation(ParserUtils.ReadWhile(reader, c => c != ' '));
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(Operations, builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;

    /// <summary><c>getOperation</c>, whose error has no context: vanilla creates it without the reader.</summary>
    private static string GetOperation(string op) => Operations.Contains(op) ? op : throw ErrorInvalidOperation.Create();
}

/// <summary>Vanilla's <c>ScoreboardSlotArgument</c>.</summary>
public sealed class ScoreboardSlotArgument : ArgumentType<ClientBoundDisplayObjectivePacket.DisplayPosition> {
    private static readonly string[] ExampleValues = ["sidebar", "foo.bar"];

    public static readonly DynamicCommandExceptionType ErrorInvalidValue = new(value => Component.TranslatableEscape("argument.scoreboardDisplaySlot.invalid", value));

    private static readonly ClientBoundDisplayObjectivePacket.DisplayPosition[] Values =
        Enumerable.Range(0, 19).Select(i => (ClientBoundDisplayObjectivePacket.DisplayPosition)i).ToArray();

    /// <summary><c>DisplaySlot.getSerializedName</c>.</summary>
    public static string NameOf(ClientBoundDisplayObjectivePacket.DisplayPosition slot) {
        return slot switch {
            ClientBoundDisplayObjectivePacket.DisplayPosition.List => "list",
            ClientBoundDisplayObjectivePacket.DisplayPosition.Sidebar => "sidebar",
            ClientBoundDisplayObjectivePacket.DisplayPosition.BelowName => "below_name",
            _ => "sidebar.team." + SerializedNames.Of((ClientBoundUpdateTeamsPacket.TeamColor)((int)slot - 3))
        };
    }

    public override ClientBoundDisplayObjectivePacket.DisplayPosition Parse(StringReader reader) {
        string name = reader.ReadUnquotedString();
        int index = Array.FindIndex(Values, slot => NameOf(slot) == name);
        return index >= 0 ? Values[index] : throw ErrorInvalidValue.CreateWithContext(reader, name);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(Values.Select(NameOf), builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>TimeArgument</c>.</summary>
public sealed class TimeArgument(int minimum) : ArgumentType<int> {
    private static readonly string[] ExampleValues = ["0d", "0s", "0t", "0"];

    private static readonly SimpleCommandExceptionType ErrorInvalidUnit = new(Component.Translatable("argument.time.invalid_unit"));
    private static readonly Dynamic2CommandExceptionType ErrorTickCountTooLow =
        new((value, limit) => Component.TranslatableEscape("argument.time.tick_count_too_low", limit, value));

    private static readonly Dictionary<string, int> Units = new() {
        ["d"] = 24000,
        ["s"] = 20,
        ["t"] = 1,
        [""] = 1
    };

    public int Minimum { get; } = minimum;

    public override int Parse(StringReader reader) {
        float value = reader.ReadFloat();
        string unit = reader.ReadUnquotedString();
        int factor = Units.GetValueOrDefault(unit, 0);
        if (factor == 0) {
            throw ErrorInvalidUnit.CreateWithContext(reader);
        }
        int ticks = JavaText.Round(value * factor);
        if (ticks < Minimum) {
            throw ErrorTickCountTooLow.CreateWithContext(reader, ticks, Minimum);
        }
        return ticks;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        StringReader reader = new(builder.Remaining);
        try {
            reader.ReadFloat();
        }
        catch (CommandSyntaxException) {
            return builder.BuildFuture();
        }
        return SharedSuggestionProvider.Suggest(Units.Keys, builder.CreateOffset(builder.Start + reader.Cursor));
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>SlotRange</c>: a slot name and the slot ids it covers.</summary>
public sealed record SlotRange(string Name, IReadOnlyList<int> Slots) {
    public int Size => Slots.Count;
}

/// <summary>Vanilla's <c>SlotRanges</c>.</summary>
public static class SlotRanges {
    private static readonly List<SlotRange> Slots = Build();

    /// <summary><c>EquipmentSlot.getIndex(base)</c> is the base plus the slot's index within its type.</summary>
    private static List<SlotRange> Build() {
        List<SlotRange> values = [];
        AddSingleSlot(values, "contents", 0);
        AddSlotRange(values, "container.", 0, 54);
        AddSlotRange(values, "hotbar.", 0, 9);
        AddSlotRange(values, "inventory.", 9, 27);
        AddSlotRange(values, "enderchest.", 200, 27);
        AddSlotRange(values, "mob.inventory.", 300, 8);
        AddSlotRange(values, "horse.", 500, 15);
        const int mainhand = 98 + 0, offhand = 98 + 1;
        AddSingleSlot(values, "weapon", mainhand);
        AddSingleSlot(values, "weapon.mainhand", mainhand);
        AddSingleSlot(values, "weapon.offhand", offhand);
        AddSlots(values, "weapon.*", mainhand, offhand);
        const int head = 100 + 3, chest = 100 + 2, legs = 100 + 1, feet = 100 + 0, body = 105 + 0;
        AddSingleSlot(values, "armor.head", head);
        AddSingleSlot(values, "armor.chest", chest);
        AddSingleSlot(values, "armor.legs", legs);
        AddSingleSlot(values, "armor.feet", feet);
        AddSingleSlot(values, "armor.body", body);
        AddSlots(values, "armor.*", head, chest, legs, feet, body);
        AddSingleSlot(values, "saddle", 106 + 0);
        AddSingleSlot(values, "horse.chest", 499);
        AddSingleSlot(values, "player.cursor", 499);
        AddSlotRange(values, "player.crafting.", 500, 4);
        return values;
    }

    private static void AddSingleSlot(List<SlotRange> output, string name, int id) => output.Add(new SlotRange(name, [id]));

    private static void AddSlotRange(List<SlotRange> output, string prefix, int offset, int size) {
        List<int> allSlots = new(size);
        for (int i = 0; i < size; i++) {
            int slotId = offset + i;
            output.Add(new SlotRange(prefix + i, [slotId]));
            allSlots.Add(slotId);
        }
        output.Add(new SlotRange(prefix + "*", allSlots));
    }

    private static void AddSlots(List<SlotRange> output, string name, params int[] values) => output.Add(new SlotRange(name, values));

    public static SlotRange? NameToIds(string name) => Slots.FirstOrDefault(s => s.Name == name);

    public static IEnumerable<string> AllNames() => Slots.Select(s => s.Name);

    public static IEnumerable<string> SingleSlotNames() => Slots.Where(e => e.Size == 1).Select(s => s.Name);
}

/// <summary>Vanilla's <c>ParserUtils.readWhile</c>.</summary>
internal static class ParserUtils {
    public static string ReadWhile(StringReader reader, Func<char, bool> predicate) {
        int start = reader.Cursor;
        while (reader.CanRead() && predicate(reader.Peek())) {
            reader.Skip();
        }
        return reader.String[start..reader.Cursor];
    }
}

/// <summary>Vanilla's <c>SlotArgument</c>.</summary>
public sealed class SlotArgument : ArgumentType<int> {
    private static readonly string[] ExampleValues = ["container.5", "weapon"];

    private static readonly DynamicCommandExceptionType ErrorUnknownSlot = new(id => Component.TranslatableEscape("slot.unknown", id));
    private static readonly DynamicCommandExceptionType ErrorOnlySingleSlotAllowed = new(id => Component.TranslatableEscape("slot.only_single_allowed", id));

    public override int Parse(StringReader reader) {
        string name = ParserUtils.ReadWhile(reader, c => c != ' ');
        SlotRange? result = SlotRanges.NameToIds(name);
        if (result == null) {
            throw ErrorUnknownSlot.CreateWithContext(reader, name);
        }
        if (result.Size != 1) {
            throw ErrorOnlySingleSlotAllowed.CreateWithContext(reader, name);
        }
        return result.Slots[0];
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(SlotRanges.SingleSlotNames(), builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>SlotsArgument</c>.</summary>
public sealed class SlotsArgument : ArgumentType<SlotRange> {
    private static readonly string[] ExampleValues = ["container.*", "container.5", "weapon"];

    private static readonly DynamicCommandExceptionType ErrorUnknownSlot = new(id => Component.TranslatableEscape("slot.unknown", id));

    public override SlotRange Parse(StringReader reader) {
        string name = ParserUtils.ReadWhile(reader, c => c != ' ');
        return SlotRanges.NameToIds(name) ?? throw ErrorUnknownSlot.CreateWithContext(reader, name);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(SlotRanges.AllNames(), builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>
/// Vanilla's <c>SlotSourceArgument</c>: a slot range by name, or failing that a <c>slot_source</c> by id or
/// inline.
/// </summary>
public sealed class SlotSourceArgument(CommandBuildContext context) : ArgumentType<object?> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "012", "{}", "true", "container.*", "container.5", "weapon"];

    private readonly ResourceOrIdArgument _holder = ResourceOrIdArgument.SlotSource(context);

    /// <returns>The <see cref="SlotRange"/> named, or what the holder argument read.</returns>
    public override object? Parse(StringReader reader) {
        int start = reader.Cursor;
        if (SlotRanges.NameToIds(ParserUtils.ReadWhile(reader, c => c != ' ')) is { } range) {
            return range;
        }
        reader.Cursor = start;
        return _holder.Parse(reader);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        SuggestionsBuilder sub = builder.CreateOffset(builder.Start);
        SharedSuggestionProvider.Suggest(SlotRanges.AllNames(), sub);
        builder.Add(sub);
        return _holder.ListSuggestions(context, builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>SwingAnimationArgument</c>.</summary>
public sealed class SwingAnimationArgument : ArgumentType<SwingAnimationType> {
    private static readonly (SwingAnimationType Value, string Name)[] Values =
        [(SwingAnimationType.None, "none"), (SwingAnimationType.Whack, "whack"), (SwingAnimationType.Stab, "stab")];
    private static readonly string[] ExampleValues = ["whack", "stab"];

    private static readonly DynamicCommandExceptionType ErrorInvalid = new(value => Component.TranslatableEscape("argument.swing_animation.invalid", value));

    public override SwingAnimationType Parse(StringReader reader) {
        string name = reader.ReadUnquotedString();
        foreach ((SwingAnimationType value, string valueName) in Values) {
            if (valueName == name) {
                return value;
            }
        }
        throw ErrorInvalid.CreateWithContext(reader, name);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return context.Source is ISharedSuggestionProvider
            ? SharedSuggestionProvider.Suggest(Values.Select(v => v.Name), builder)
            : Suggestions.Empty();
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>FunctionArgument</c>. Functions live on the server, so the result is the id read and whether it named a tag.</summary>
public sealed class FunctionArgument : ArgumentType<FunctionArgument.Result> {
    private static readonly string[] ExampleValues = ["foo", "foo:bar", "#foo"];

    public sealed record Result(Identifier Id, bool IsTag);

    public override Result Parse(StringReader reader) {
        bool isTag = reader.CanRead() && reader.Peek() == '#';
        if (isTag) {
            reader.Skip();
        }
        return new Result(Identifiers.Read(reader), isTag);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>ObjectiveCriteriaArgument</c>, with <c>ObjectiveCriteria.byName</c> and the stat names it suggests.</summary>
public sealed class ObjectiveCriteriaArgument : ArgumentType<string> {
    private static readonly string[] ExampleValues = ["foo", "foo.bar.baz", "minecraft:foo"];

    public static readonly DynamicCommandExceptionType ErrorInvalidValue = new(value => Component.TranslatableEscape("argument.criteria.invalid", value));

    private static readonly string[] CustomCriteriaNames = BuildCustomCriteriaNames();

    private static string[] BuildCustomCriteriaNames() {
        List<string> names = ["dummy", "trigger", "deathCount", "playerKillCount", "totalKillCount", "health", "food", "air", "armor", "xp", "level"];
        names.AddRange(SerializedNames.TeamColors.Select(c => "teamkill." + SerializedNames.Of(c)));
        names.AddRange(SerializedNames.TeamColors.Select(c => "killedByTeam." + SerializedNames.Of(c)));
        return names.ToArray();
    }

    /// <summary><c>StatType.getRegistry</c>; built in registries match between client and server, so the generated ones answer.</summary>
    private static IProtocolTypeRegistry RegistryOf(Minecraft.Data.StatisticTypes.IStatisticType type) {
        MinecraftRegistry registry = VanillaRegistry.Data;
        Identifier id = type.Identifier;
        if (id == StatisticType.Mined.Identifier) {
            return registry.Blocks;
        }
        if (id == StatisticType.Killed.Identifier || id == StatisticType.KilledBy.Identifier) {
            return registry.EntityTypes;
        }
        if (id == StatisticType.Custom.Identifier) {
            return registry.CustomStatistics;
        }
        return registry.Items;
    }

    private static IEnumerable<Identifier> ElementsOf(IProtocolTypeRegistry registry) {
        return registry is IProtocolTypeRegistry<Minecraft.Data.IProtocolType> typed
            ? typed.All.Select(t => t.Identifier).OrderBy(registry.GetProtocolId)
            : [];
    }

    private static string LocationToKey(Identifier location) => location.ToString().Replace(':', '.');

    /// <summary><c>ObjectiveCriteria.byName</c>, reduced to whether the name resolves.</summary>
    public static bool Exists(string name) {
        if (CustomCriteriaNames.Contains(name)) {
            return true;
        }
        int colonPos = name.IndexOf(':');
        if (colonPos < 0) {
            return false;
        }
        Identifier typeId = Identifiers.BySeparator(name[..colonPos], '.');
        if (!VanillaRegistry.Data.StatisticTypes.Contains(typeId)) {
            return false;
        }
        Identifier key = Identifiers.BySeparator(name[(colonPos + 1)..], '.');
        return RegistryOf(VanillaRegistry.Data.StatisticTypes.Get(typeId)).Contains(key);
    }

    public override string Parse(StringReader reader) {
        int start = reader.Cursor;
        string id = ParserUtils.ReadWhile(reader, c => c != ' ');
        if (!Exists(id)) {
            reader.Cursor = start;
            throw ErrorInvalidValue.CreateWithContext(reader, id);
        }
        return id;
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        List<string> ids = [..CustomCriteriaNames];
        IProtocolTypeRegistry statTypes = VanillaRegistry.Data.StatisticTypes;
        foreach (Identifier typeId in ElementsOf(statTypes)) {
            IProtocolTypeRegistry values = RegistryOf(VanillaRegistry.Data.StatisticTypes.Get(typeId));
            foreach (Identifier value in ElementsOf(values)) {
                ids.Add(LocationToKey(typeId) + ":" + LocationToKey(value));
            }
        }
        return SharedSuggestionProvider.Suggest(ids, builder);
    }

    public override IReadOnlyCollection<string> Examples => ExampleValues;
}

/// <summary>Vanilla's <c>StringRepresentableArgument</c>, over the serialised names of a fixed enum.</summary>
public class StringRepresentableArgument<T>(IReadOnlyList<(T Value, string Name)> values) : ArgumentType<T> {
    private static readonly DynamicCommandExceptionType ErrorInvalidValue = new(value => Component.TranslatableEscape("argument.enum.invalid", value));

    public override T Parse(StringReader reader) {
        string id = reader.ReadUnquotedString();
        foreach ((T value, string name) in values) {
            if (name == id) {
                return value;
            }
        }
        throw ErrorInvalidValue.CreateWithContext(reader, id);
    }

    public override Task<Suggestions> ListSuggestions<TSource>(CommandContext<TSource> context, SuggestionsBuilder builder) {
        return SharedSuggestionProvider.Suggest(values.Select(v => ConvertId(v.Name)).ToList(), builder);
    }

    public override IReadOnlyCollection<string> Examples => values.Select(v => ConvertId(v.Name)).Take(2).ToList();

    protected virtual string ConvertId(string id) => id;
}

/// <summary>Vanilla's <c>Mirror</c>.</summary>
public enum TemplateMirror { None, LeftRight, FrontBack }

/// <summary>Vanilla's <c>Rotation</c>.</summary>
public enum TemplateRotation { None, Clockwise90, Clockwise180, Counterclockwise90 }

/// <summary>Vanilla's <c>TemplateMirrorArgument</c>.</summary>
public sealed class TemplateMirrorArgument() : StringRepresentableArgument<TemplateMirror>([
    (TemplateMirror.None, "none"),
    (TemplateMirror.LeftRight, "left_right"),
    (TemplateMirror.FrontBack, "front_back")
]);

/// <summary>Vanilla's <c>TemplateRotationArgument</c>.</summary>
public sealed class TemplateRotationArgument() : StringRepresentableArgument<TemplateRotation>([
    (TemplateRotation.None, "none"),
    (TemplateRotation.Clockwise90, "clockwise_90"),
    (TemplateRotation.Clockwise180, "180"),
    (TemplateRotation.Counterclockwise90, "counterclockwise_90")
]);

/// <summary>Vanilla's <c>HeightmapTypeArgument</c>: the types kept after world generation, by their lower cased serialised names.</summary>
public sealed class HeightmapTypeArgument() : StringRepresentableArgument<HeightmapType>([
    (HeightmapType.WorldSurface, "world_surface"),
    (HeightmapType.OceanFloor, "ocean_floor"),
    (HeightmapType.MotionBlocking, "motion_blocking"),
    (HeightmapType.MotionBlockingNoLeaves, "motion_blocking_no_leaves")
]) {
    protected override string ConvertId(string id) => JavaText.ToLowerRoot(id);
}
