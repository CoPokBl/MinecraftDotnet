using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record LavaBlock(Identifier Identifier, int Level) : IBlock {

    public uint StateId {
        get {
            return Level switch {
                0 => 102,
                1 => 103,
                2 => 104,
                3 => 105,
                4 => 106,
                5 => 107,
                6 => 108,
                7 => 109,
                8 => 110,
                9 => 111,
                10 => 112,
                11 => 113,
                12 => 114,
                13 => 115,
                14 => 116,
                15 => 117,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            102 => new LavaBlock(Identifier, 0),
            103 => new LavaBlock(Identifier, 1),
            104 => new LavaBlock(Identifier, 2),
            105 => new LavaBlock(Identifier, 3),
            106 => new LavaBlock(Identifier, 4),
            107 => new LavaBlock(Identifier, 5),
            108 => new LavaBlock(Identifier, 6),
            109 => new LavaBlock(Identifier, 7),
            110 => new LavaBlock(Identifier, 8),
            111 => new LavaBlock(Identifier, 9),
            112 => new LavaBlock(Identifier, 10),
            113 => new LavaBlock(Identifier, 11),
            114 => new LavaBlock(Identifier, 12),
            115 => new LavaBlock(Identifier, 13),
            116 => new LavaBlock(Identifier, 14),
            117 => new LavaBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
