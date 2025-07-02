using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SnifferEggBlock(Identifier Identifier, int Hatch) : IBlock {

    public uint StateId {
        get {
            return Hatch switch {
                0 => 13823,
                1 => 13824,
                2 => 13825,
                _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13823 => new SnifferEggBlock(Identifier, 0),
            13824 => new SnifferEggBlock(Identifier, 1),
            13825 => new SnifferEggBlock(Identifier, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
