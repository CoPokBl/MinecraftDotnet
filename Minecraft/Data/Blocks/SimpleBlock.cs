using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public record SimpleBlock(Identifier Identifier, uint StateId) : IBlock {
    
    public IBlock WithState(uint state) {
        if (state != StateId) {
            throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state ID.");
        }
        return this;
    }

    public IBlock WithState(CompoundTag properties) {
        return this;
    }
}
