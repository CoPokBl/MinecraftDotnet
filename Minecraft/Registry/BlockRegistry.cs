using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class BlockRegistry {
    private readonly Dictionary<uint, IBlock> _defaultByState = new();
    private readonly Dictionary<Identifier, IBlock> _defaultByName = new();
    private readonly Dictionary<int, IBlock> _defaultById = new();
    
    public IBlock this[Identifier name] => _defaultByName[name];
    
    /// <summary>
    /// Gets the default block by its protocol ID (NOT THE STATE ID).
    /// </summary>
    /// <param name="id"></param>
    public IBlock this[int id] => _defaultById[id];

    public long Count => _defaultByState.Count;
    
    public IBlock GetByStateId(uint state) {
        return _defaultByState[state].WithState(state);
    }
    
    public void Add(IBlock defaultBlock, params uint[] states) {
        foreach (uint state in states) {
            _defaultByState.Add(state, defaultBlock);
        }
        _defaultByName.Add(defaultBlock.Identifier, defaultBlock);
        _defaultById.Add(defaultBlock.ProtocolId, defaultBlock);
    }
}
