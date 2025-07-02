using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BirchHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5066,
                        false => 5067,
                    },
                    1 => Waterlogged switch {
                        true => 5068,
                        false => 5069,
                    },
                    2 => Waterlogged switch {
                        true => 5070,
                        false => 5071,
                    },
                    3 => Waterlogged switch {
                        true => 5072,
                        false => 5073,
                    },
                    4 => Waterlogged switch {
                        true => 5074,
                        false => 5075,
                    },
                    5 => Waterlogged switch {
                        true => 5076,
                        false => 5077,
                    },
                    6 => Waterlogged switch {
                        true => 5078,
                        false => 5079,
                    },
                    7 => Waterlogged switch {
                        true => 5080,
                        false => 5081,
                    },
                    8 => Waterlogged switch {
                        true => 5082,
                        false => 5083,
                    },
                    9 => Waterlogged switch {
                        true => 5084,
                        false => 5085,
                    },
                    10 => Waterlogged switch {
                        true => 5086,
                        false => 5087,
                    },
                    11 => Waterlogged switch {
                        true => 5088,
                        false => 5089,
                    },
                    12 => Waterlogged switch {
                        true => 5090,
                        false => 5091,
                    },
                    13 => Waterlogged switch {
                        true => 5092,
                        false => 5093,
                    },
                    14 => Waterlogged switch {
                        true => 5094,
                        false => 5095,
                    },
                    15 => Waterlogged switch {
                        true => 5096,
                        false => 5097,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5098,
                        false => 5099,
                    },
                    1 => Waterlogged switch {
                        true => 5100,
                        false => 5101,
                    },
                    2 => Waterlogged switch {
                        true => 5102,
                        false => 5103,
                    },
                    3 => Waterlogged switch {
                        true => 5104,
                        false => 5105,
                    },
                    4 => Waterlogged switch {
                        true => 5106,
                        false => 5107,
                    },
                    5 => Waterlogged switch {
                        true => 5108,
                        false => 5109,
                    },
                    6 => Waterlogged switch {
                        true => 5110,
                        false => 5111,
                    },
                    7 => Waterlogged switch {
                        true => 5112,
                        false => 5113,
                    },
                    8 => Waterlogged switch {
                        true => 5114,
                        false => 5115,
                    },
                    9 => Waterlogged switch {
                        true => 5116,
                        false => 5117,
                    },
                    10 => Waterlogged switch {
                        true => 5118,
                        false => 5119,
                    },
                    11 => Waterlogged switch {
                        true => 5120,
                        false => 5121,
                    },
                    12 => Waterlogged switch {
                        true => 5122,
                        false => 5123,
                    },
                    13 => Waterlogged switch {
                        true => 5124,
                        false => 5125,
                    },
                    14 => Waterlogged switch {
                        true => 5126,
                        false => 5127,
                    },
                    15 => Waterlogged switch {
                        true => 5128,
                        false => 5129,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5066 => new BirchHangingSignBlock(Identifier, true, 0, true),
            5067 => new BirchHangingSignBlock(Identifier, true, 0, false),
            5068 => new BirchHangingSignBlock(Identifier, true, 1, true),
            5069 => new BirchHangingSignBlock(Identifier, true, 1, false),
            5070 => new BirchHangingSignBlock(Identifier, true, 2, true),
            5071 => new BirchHangingSignBlock(Identifier, true, 2, false),
            5072 => new BirchHangingSignBlock(Identifier, true, 3, true),
            5073 => new BirchHangingSignBlock(Identifier, true, 3, false),
            5074 => new BirchHangingSignBlock(Identifier, true, 4, true),
            5075 => new BirchHangingSignBlock(Identifier, true, 4, false),
            5076 => new BirchHangingSignBlock(Identifier, true, 5, true),
            5077 => new BirchHangingSignBlock(Identifier, true, 5, false),
            5078 => new BirchHangingSignBlock(Identifier, true, 6, true),
            5079 => new BirchHangingSignBlock(Identifier, true, 6, false),
            5080 => new BirchHangingSignBlock(Identifier, true, 7, true),
            5081 => new BirchHangingSignBlock(Identifier, true, 7, false),
            5082 => new BirchHangingSignBlock(Identifier, true, 8, true),
            5083 => new BirchHangingSignBlock(Identifier, true, 8, false),
            5084 => new BirchHangingSignBlock(Identifier, true, 9, true),
            5085 => new BirchHangingSignBlock(Identifier, true, 9, false),
            5086 => new BirchHangingSignBlock(Identifier, true, 10, true),
            5087 => new BirchHangingSignBlock(Identifier, true, 10, false),
            5088 => new BirchHangingSignBlock(Identifier, true, 11, true),
            5089 => new BirchHangingSignBlock(Identifier, true, 11, false),
            5090 => new BirchHangingSignBlock(Identifier, true, 12, true),
            5091 => new BirchHangingSignBlock(Identifier, true, 12, false),
            5092 => new BirchHangingSignBlock(Identifier, true, 13, true),
            5093 => new BirchHangingSignBlock(Identifier, true, 13, false),
            5094 => new BirchHangingSignBlock(Identifier, true, 14, true),
            5095 => new BirchHangingSignBlock(Identifier, true, 14, false),
            5096 => new BirchHangingSignBlock(Identifier, true, 15, true),
            5097 => new BirchHangingSignBlock(Identifier, true, 15, false),
            5098 => new BirchHangingSignBlock(Identifier, false, 0, true),
            5099 => new BirchHangingSignBlock(Identifier, false, 0, false),
            5100 => new BirchHangingSignBlock(Identifier, false, 1, true),
            5101 => new BirchHangingSignBlock(Identifier, false, 1, false),
            5102 => new BirchHangingSignBlock(Identifier, false, 2, true),
            5103 => new BirchHangingSignBlock(Identifier, false, 2, false),
            5104 => new BirchHangingSignBlock(Identifier, false, 3, true),
            5105 => new BirchHangingSignBlock(Identifier, false, 3, false),
            5106 => new BirchHangingSignBlock(Identifier, false, 4, true),
            5107 => new BirchHangingSignBlock(Identifier, false, 4, false),
            5108 => new BirchHangingSignBlock(Identifier, false, 5, true),
            5109 => new BirchHangingSignBlock(Identifier, false, 5, false),
            5110 => new BirchHangingSignBlock(Identifier, false, 6, true),
            5111 => new BirchHangingSignBlock(Identifier, false, 6, false),
            5112 => new BirchHangingSignBlock(Identifier, false, 7, true),
            5113 => new BirchHangingSignBlock(Identifier, false, 7, false),
            5114 => new BirchHangingSignBlock(Identifier, false, 8, true),
            5115 => new BirchHangingSignBlock(Identifier, false, 8, false),
            5116 => new BirchHangingSignBlock(Identifier, false, 9, true),
            5117 => new BirchHangingSignBlock(Identifier, false, 9, false),
            5118 => new BirchHangingSignBlock(Identifier, false, 10, true),
            5119 => new BirchHangingSignBlock(Identifier, false, 10, false),
            5120 => new BirchHangingSignBlock(Identifier, false, 11, true),
            5121 => new BirchHangingSignBlock(Identifier, false, 11, false),
            5122 => new BirchHangingSignBlock(Identifier, false, 12, true),
            5123 => new BirchHangingSignBlock(Identifier, false, 12, false),
            5124 => new BirchHangingSignBlock(Identifier, false, 13, true),
            5125 => new BirchHangingSignBlock(Identifier, false, 13, false),
            5126 => new BirchHangingSignBlock(Identifier, false, 14, true),
            5127 => new BirchHangingSignBlock(Identifier, false, 14, false),
            5128 => new BirchHangingSignBlock(Identifier, false, 15, true),
            5129 => new BirchHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
