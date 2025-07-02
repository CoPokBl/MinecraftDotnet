using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PodzolBlock(Identifier Identifier, bool Snowy) : IBlock {

    public uint StateId {
        get {
            return Snowy switch {
                true => 12,
                false => 13,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12 => new PodzolBlock(Identifier, true),
            13 => new PodzolBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
