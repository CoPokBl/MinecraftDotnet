using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ChorusFlowerBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 13427,
                1 => 13428,
                2 => 13429,
                3 => 13430,
                4 => 13431,
                5 => 13432,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13427 => new ChorusFlowerBlock(Identifier, 0),
            13428 => new ChorusFlowerBlock(Identifier, 1),
            13429 => new ChorusFlowerBlock(Identifier, 2),
            13430 => new ChorusFlowerBlock(Identifier, 3),
            13431 => new ChorusFlowerBlock(Identifier, 4),
            13432 => new ChorusFlowerBlock(Identifier, 5),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
