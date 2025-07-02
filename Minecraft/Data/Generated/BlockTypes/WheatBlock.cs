using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WheatBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 4342,
                1 => 4343,
                2 => 4344,
                3 => 4345,
                4 => 4346,
                5 => 4347,
                6 => 4348,
                7 => 4349,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            4342 => new WheatBlock(Identifier, 0),
            4343 => new WheatBlock(Identifier, 1),
            4344 => new WheatBlock(Identifier, 2),
            4345 => new WheatBlock(Identifier, 3),
            4346 => new WheatBlock(Identifier, 4),
            4347 => new WheatBlock(Identifier, 5),
            4348 => new WheatBlock(Identifier, 6),
            4349 => new WheatBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
