using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record TntBlock(Identifier Identifier, bool Unstable) : IBlock {

    public uint StateId {
        get {
            return Unstable switch {
                true => 2140,
                false => 2141,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            2140 => new TntBlock(Identifier, true),
            2141 => new TntBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
