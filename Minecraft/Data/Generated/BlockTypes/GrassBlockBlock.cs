using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GrassBlockBlock(Identifier Identifier, bool Snowy) : IBlock {

    public uint StateId {
        get {
            return Snowy switch {
                true => 8,
                false => 9,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            8 => new GrassBlockBlock(Identifier, true),
            9 => new GrassBlockBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
