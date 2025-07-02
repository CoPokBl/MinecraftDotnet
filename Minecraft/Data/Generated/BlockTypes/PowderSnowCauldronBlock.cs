using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PowderSnowCauldronBlock(Identifier Identifier, int Level) : IBlock {

    public uint StateId {
        get {
            return Level switch {
                1 => 8187,
                2 => 8188,
                3 => 8189,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            8187 => new PowderSnowCauldronBlock(Identifier, 1),
            8188 => new PowderSnowCauldronBlock(Identifier, 2),
            8189 => new PowderSnowCauldronBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
