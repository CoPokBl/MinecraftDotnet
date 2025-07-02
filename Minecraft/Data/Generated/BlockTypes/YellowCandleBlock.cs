using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record YellowCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21833,
                        false => 21834,
                    },
                    false => Waterlogged switch {
                        true => 21835,
                        false => 21836,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21837,
                        false => 21838,
                    },
                    false => Waterlogged switch {
                        true => 21839,
                        false => 21840,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21841,
                        false => 21842,
                    },
                    false => Waterlogged switch {
                        true => 21843,
                        false => 21844,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21845,
                        false => 21846,
                    },
                    false => Waterlogged switch {
                        true => 21847,
                        false => 21848,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21833 => new YellowCandleBlock(Identifier, 1, true, true),
            21834 => new YellowCandleBlock(Identifier, 1, true, false),
            21835 => new YellowCandleBlock(Identifier, 1, false, true),
            21836 => new YellowCandleBlock(Identifier, 1, false, false),
            21837 => new YellowCandleBlock(Identifier, 2, true, true),
            21838 => new YellowCandleBlock(Identifier, 2, true, false),
            21839 => new YellowCandleBlock(Identifier, 2, false, true),
            21840 => new YellowCandleBlock(Identifier, 2, false, false),
            21841 => new YellowCandleBlock(Identifier, 3, true, true),
            21842 => new YellowCandleBlock(Identifier, 3, true, false),
            21843 => new YellowCandleBlock(Identifier, 3, false, true),
            21844 => new YellowCandleBlock(Identifier, 3, false, false),
            21845 => new YellowCandleBlock(Identifier, 4, true, true),
            21846 => new YellowCandleBlock(Identifier, 4, true, false),
            21847 => new YellowCandleBlock(Identifier, 4, false, true),
            21848 => new YellowCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
