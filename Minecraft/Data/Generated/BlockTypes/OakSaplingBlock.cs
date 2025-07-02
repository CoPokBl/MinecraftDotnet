using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OakSaplingBlock(Identifier Identifier, int Stage) : IBlock {

    public uint StateId {
        get {
            return Stage switch {
                0 => 29,
                1 => 30,
                _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            29 => new OakSaplingBlock(Identifier, 0),
            30 => new OakSaplingBlock(Identifier, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
