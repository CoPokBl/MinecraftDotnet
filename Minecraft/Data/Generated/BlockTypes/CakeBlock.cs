using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CakeBlock(Identifier Identifier, int Bites) : IBlock {

    public uint StateId {
        get {
            return Bites switch {
                0 => 6053,
                1 => 6054,
                2 => 6055,
                3 => 6056,
                4 => 6057,
                5 => 6058,
                6 => 6059,
                _ => throw new ArgumentOutOfRangeException(nameof(Bites), Bites, "Unknown value for property bites.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            6053 => new CakeBlock(Identifier, 0),
            6054 => new CakeBlock(Identifier, 1),
            6055 => new CakeBlock(Identifier, 2),
            6056 => new CakeBlock(Identifier, 3),
            6057 => new CakeBlock(Identifier, 4),
            6058 => new CakeBlock(Identifier, 5),
            6059 => new CakeBlock(Identifier, 6),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
