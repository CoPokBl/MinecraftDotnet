using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class BlockRegistry {
    private readonly Dictionary<uint, IBlock> _defaultByState = new();
    private readonly Dictionary<Identifier, IBlock> _defaultByName = new();
    
    public IBlock this[Identifier name] => _defaultByName[name];
    public IBlock this[uint state] => _defaultByState[state].WithState(state);

    public void Add(IBlock defaultBlock, Identifier identifier, params uint[] states) {
        foreach (uint state in states) {
            _defaultByState.Add(state, defaultBlock);
        }
        _defaultByName.Add(identifier, defaultBlock);
    }
}
