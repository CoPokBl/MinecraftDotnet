using Minecraft.Data.Blocks;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class BlockRegistry : MappedRegistry<BlockRegistry, IBlock> {
    public override Identifier RegistryId => "minecraft:block";

    /// <summary>
    /// Backs <see cref="DefaultBlock"/> explicitly rather than through <c>field</c>, so
    /// <see cref="Clone"/> can carry it across without reading it. A registry that never had one set
    /// is still worth copying, and the getter's throw is for a consumer asking for a default that
    /// does not exist rather than for the copy.
    /// </summary>
    private IBlock? _defaultBlock;

    public IBlock DefaultBlock {
        get => _defaultBlock.ThrowIfNull();
        set => _defaultBlock = value;
    }

    private readonly Dictionary<uint, IBlock> _defaultByState = new();

    /// <summary>
    /// One instance per state, so <see cref="GetByStateId"/> is an array read rather than a lookup
    /// and an allocation.
    /// </summary>
    /// <remarks>
    /// <c>WithState</c> builds a new record every call, and the callers that want a state are loops:
    /// the surface rules ask once per block of a column, serialising a section asks per palette
    /// entry, and lighting and the heightmaps ask per position. An <see cref="IBlock"/> is an
    /// immutable record, so one instance answers all of them.
    /// <p/>
    /// Built whole on first use rather than per entry, since a half filled table would need a null
    /// check on the hot path and a memory barrier per read. Dropped by any mutation, because a state
    /// id can be reassigned to another block.
    /// </remarks>
    private IBlock[]? _byState;

    // An object rather than a Lock: this project multi-targets net8.0, which does not have one.
    private readonly object _byStateLock = new();

    public long StatesCount => _defaultByState.Count;

    public IReadOnlyDictionary<uint, IBlock> StatesByStateId => _defaultByState;

    public IBlock GetByStateId(uint state) {
        IBlock[] table = _byState ?? BuildStateTable();

        // A registry with gaps in its state ids leaves nulls behind, so those fall back rather than
        // forcing every read through a bounds-and-null pair the vanilla registry never needs.
        if (state < (uint)table.Length) {
            IBlock? block = table[state];
            if (block != null) {
                return block;
            }
        }

        return _defaultByState[state].WithState(state);
    }

    private IBlock[] BuildStateTable() {
        lock (_byStateLock) {
            if (_byState != null) {
                return _byState;
            }

            uint highest = 0;
            foreach (uint state in _defaultByState.Keys) {
                if (state > highest) {
                    highest = state;
                }
            }

            IBlock[] table = new IBlock[_defaultByState.Count == 0 ? 0 : highest + 1];
            foreach ((uint state, IBlock block) in _defaultByState) {
                table[state] = block.WithState(state);
            }

            _byState = table;
            return table;
        }
    }

    public void Add(int protocolId, IBlock defaultBlock, params uint[] states) {
        foreach (uint state in states) {
            _defaultByState.Add(state, defaultBlock);
        }

        _byState = null;

        // Call the base add method to add to the mapped registry
        base.Add(protocolId, defaultBlock);
    }

    public override BlockRegistry Clone() {
        BlockRegistry cl = base.Clone();
        foreach (KeyValuePair<uint, IBlock> state in _defaultByState) {
            cl._defaultByState.Add(state.Key, state.Value);
        }
        cl._defaultBlock = _defaultBlock;

        return cl;
    }

    public override void Clear() {
        base.Clear();
        _defaultByState.Clear();
        _byState = null;
    }
}
