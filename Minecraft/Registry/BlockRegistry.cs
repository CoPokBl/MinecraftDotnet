using Minecraft.Data.Blocks;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class BlockRegistry {
    public readonly Dictionary<uint, IBlock> DefaultByState = new();
    public readonly Dictionary<Identifier, IBlock> DefaultByName = new();
    
    public IBlock this[Identifier name] => DefaultByName[name];
    public IBlock this[uint state] => DefaultByState[state].GetState(state);

    public void Add(IBlock defaultBlock, Identifier identifier, params uint[] states) {
        foreach (uint state in states) {
            DefaultByState.Add(state, defaultBlock);
        }
        DefaultByName.Add(identifier, defaultBlock);
    }
}
