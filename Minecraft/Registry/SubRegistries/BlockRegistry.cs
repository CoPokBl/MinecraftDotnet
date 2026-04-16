using Minecraft.Data.Blocks;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class BlockRegistry : MappedRegistry<BlockRegistry, IBlock> {
    public override Identifier RegistryId => "minecraft:block";

    public IBlock DefaultBlock {
        get => field.ThrowIfNull();
        set;
    }

    private readonly Dictionary<uint, IBlock> _defaultByState = new();

    public long StatesCount => _defaultByState.Count;

    public IReadOnlyDictionary<uint, IBlock> StatesByStateId => _defaultByState;
    
    public IBlock GetByStateId(uint state) {
        return _defaultByState[state].WithState(state);
    }
    
    public void Add(int protocolId, IBlock defaultBlock, params uint[] states) {
        foreach (uint state in states) {
            _defaultByState.Add(state, defaultBlock);
        }
        
        // Call the base add method to add to the mapped registry
        base.Add(protocolId, defaultBlock);
    }

    public override BlockRegistry Clone() {
        BlockRegistry cl = base.Clone();
        foreach (KeyValuePair<uint, IBlock> state in _defaultByState) {
            cl._defaultByState.Add(state.Key, state.Value);
        }
        cl.DefaultBlock = DefaultBlock;

        return cl;
    }

    public override void Clear() {
        base.Clear();
        _defaultByState.Clear();
    }
}
