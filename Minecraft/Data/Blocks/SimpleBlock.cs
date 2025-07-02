using Minecraft.Schemas;

namespace Minecraft.Data.Blocks;

public record SimpleBlock(Identifier Identifier, uint StateId) : IBlock {
    
    public IBlock GetState(uint state) {
        if (state != StateId) {
            throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state ID.");
        }
        return this;
    }
}
