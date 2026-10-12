using System.Reflection;
using System.Runtime.CompilerServices;
using ClientLib.Brigadier;
using Minecraft.Data.Blocks;
using Minecraft.Registry.SubRegistries;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ClientLib.Commands.Arguments;

/// <summary>Vanilla's <c>Property</c> as the command parser needs it, with values as serialised names in <c>getPossibleValues</c> order.</summary>
public sealed class BlockProperty(string name, IReadOnlyList<string> possibleValueNames, bool isInteger) {
    public string Name { get; } = name;

    public IReadOnlyList<string> PossibleValueNames { get; } = possibleValueNames;

    /// <summary>Whether this is an <c>IntegerProperty</c>, whose values suggest as numbers and sort numerically.</summary>
    public bool IsInteger { get; } = isInteger;

    /// <summary><c>Property.getValue(String)</c>. An integer property parses with <c>Integer.parseInt</c>, so "05" and "+5" are both 5.</summary>
    public string? GetValue(string raw) {
        if (!IsInteger) {
            return PossibleValueNames.Contains(raw) ? raw : null;
        }
        if (!JavaText.TryParseInt(raw, out int value)) {
            return null;
        }
        string canonical = value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        return PossibleValueNames.Contains(canonical) ? canonical : null;
    }
}

/// <summary>
/// Vanilla's <c>StateDefinition</c>, read off the generated states: properties in name order, as
/// <c>ImmutableSortedMap</c> keeps them, and values in state id order, which is <c>getPossibleValues</c>'.
/// </summary>
public sealed class BlockStateDefinition {
    private static readonly ConditionalWeakTable<BlockRegistry, Dictionary<Identifier, BlockStateDefinition>> Cache = new();

    private readonly Dictionary<string, BlockProperty> _byName;

    private BlockStateDefinition(List<BlockProperty> properties) {
        Properties = properties;
        _byName = properties.ToDictionary(p => p.Name);
    }

    public IReadOnlyList<BlockProperty> Properties { get; }

    public BlockProperty? GetProperty(string name) => _byName.GetValueOrDefault(name);

    public static BlockStateDefinition Of(BlockRegistry registry, IBlock block) {
        Dictionary<Identifier, BlockStateDefinition> definitions = Cache.GetValue(registry, BuildAll);
        return definitions.TryGetValue(block.Identifier, out BlockStateDefinition? definition) ? definition : FromStates([block]);
    }

    private static Dictionary<Identifier, BlockStateDefinition> BuildAll(BlockRegistry registry) {
        Dictionary<Identifier, List<uint>> statesByBlock = new();
        foreach ((uint state, IBlock defaultBlock) in registry.StatesByStateId) {
            if (!statesByBlock.TryGetValue(defaultBlock.Identifier, out List<uint>? states)) {
                statesByBlock[defaultBlock.Identifier] = states = [];
            }
            states.Add(state);
        }

        Dictionary<Identifier, BlockStateDefinition> result = new();
        foreach ((Identifier id, List<uint> states) in statesByBlock) {
            states.Sort();
            result[id] = FromStates(states.Select(registry.GetByStateId).ToList());
        }
        return result;
    }

    private static BlockStateDefinition FromStates(IReadOnlyList<IBlock> states) {
        IBlock first = states[0];
        HashSet<string> integerProperties = IntegerPropertyNames(first);
        Dictionary<string, List<string>> values = new();
        foreach (IBlock state in states) {
            foreach ((string key, INbtTag tag) in state.ToStateNbt().Children) {
                if (!values.TryGetValue(key, out List<string>? seen)) {
                    values[key] = seen = [];
                }
                string value = ((StringTag)tag).Value;
                if (!seen.Contains(value)) {
                    seen.Add(value);
                }
            }
        }
        List<BlockProperty> properties = values
            .OrderBy(entry => entry.Key, StringComparer.Ordinal)
            .Select(entry => new BlockProperty(entry.Key, entry.Value, integerProperties.Contains(entry.Key)))
            .ToList();
        return new BlockStateDefinition(properties);
    }

    /// <summary>
    /// A generated block record's primary constructor takes its identifier then one parameter per
    /// property, in the order <c>ToStateNbt</c> writes them, and an <c>IntegerProperty</c> is an int there.
    /// </summary>
    private static HashSet<string> IntegerPropertyNames(IBlock block) {
        List<string> keys = block.ToStateNbt().Children.Select(child => child.key).ToList();
        foreach (ConstructorInfo constructor in block.GetType().GetConstructors()) {
            ParameterInfo[] parameters = constructor.GetParameters();
            if (parameters.Length != keys.Count + 1 || parameters[0].ParameterType != typeof(Identifier)) {
                continue;
            }
            HashSet<string> result = [];
            for (int i = 0; i < keys.Count; i++) {
                if (parameters[i + 1].ParameterType == typeof(int)) {
                    result.Add(keys[i]);
                }
            }
            return result;
        }
        return [];
    }
}

/// <summary>Vanilla's <c>lookupOrThrow(Registries.BLOCK)</c>: the client's block registry, with the block tags the server sent.</summary>
public sealed class BlockLookup(CommandBuildContext context) {
    public BlockRegistry Registry => context.Registry.Blocks;

    public IEnumerable<Identifier> ListElementIds() => context.Lookup(Registry.RegistryId)?.ListElementIds() ?? [];

    public IEnumerable<Identifier> ListTagIds() => context.Lookup(Registry.RegistryId)?.ListTagIds() ?? [];

    /// <summary>The block's <c>defaultBlockState</c>, or null when there is no such block.</summary>
    public IBlock? Get(Identifier id) => Registry.Contains(id) ? Registry[id] : null;

    /// <summary>The tag's blocks in the order the server sent them, or null when the server sent no such tag.</summary>
    public IReadOnlyList<IBlock>? GetTag(Identifier tag) => context.TagMembers(Registry.RegistryId, tag)?.Where(Registry.Contains).Select(id => Registry[id]).ToList();

    public BlockStateDefinition DefinitionOf(IBlock block) => BlockStateDefinition.Of(Registry, block);
}
