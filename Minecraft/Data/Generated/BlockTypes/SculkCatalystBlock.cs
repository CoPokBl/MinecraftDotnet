using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SculkCatalystBlock(Identifier Identifier, bool Bloom) : IBlock {

    public uint StateId {
        get {
            return Bloom switch {
                true => 23956,
                false => 23957,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            23956 => new SculkCatalystBlock(Identifier, true),
            23957 => new SculkCatalystBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
