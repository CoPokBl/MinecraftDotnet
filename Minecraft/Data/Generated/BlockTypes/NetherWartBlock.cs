using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record NetherWartBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 8169,
                1 => 8170,
                2 => 8171,
                3 => 8172,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            8169 => new NetherWartBlock(Identifier, 0),
            8170 => new NetherWartBlock(Identifier, 1),
            8171 => new NetherWartBlock(Identifier, 2),
            8172 => new NetherWartBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
