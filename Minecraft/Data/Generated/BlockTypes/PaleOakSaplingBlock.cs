using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakSaplingBlock(Identifier Identifier, int Stage) : IBlock {

    public uint StateId {
        get {
            return Stage switch {
                0 => 43,
                1 => 44,
                _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            43 => new PaleOakSaplingBlock(Identifier, 0),
            44 => new PaleOakSaplingBlock(Identifier, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Stage = int.Parse(properties["stage"].GetString()),
        };
    }
    
}
