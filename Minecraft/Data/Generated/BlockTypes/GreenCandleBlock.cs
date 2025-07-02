using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GreenCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21977,
                        false => 21978,
                    },
                    false => Waterlogged switch {
                        true => 21979,
                        false => 21980,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21981,
                        false => 21982,
                    },
                    false => Waterlogged switch {
                        true => 21983,
                        false => 21984,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21985,
                        false => 21986,
                    },
                    false => Waterlogged switch {
                        true => 21987,
                        false => 21988,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21989,
                        false => 21990,
                    },
                    false => Waterlogged switch {
                        true => 21991,
                        false => 21992,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21977 => new GreenCandleBlock(Identifier, 1, true, true),
            21978 => new GreenCandleBlock(Identifier, 1, true, false),
            21979 => new GreenCandleBlock(Identifier, 1, false, true),
            21980 => new GreenCandleBlock(Identifier, 1, false, false),
            21981 => new GreenCandleBlock(Identifier, 2, true, true),
            21982 => new GreenCandleBlock(Identifier, 2, true, false),
            21983 => new GreenCandleBlock(Identifier, 2, false, true),
            21984 => new GreenCandleBlock(Identifier, 2, false, false),
            21985 => new GreenCandleBlock(Identifier, 3, true, true),
            21986 => new GreenCandleBlock(Identifier, 3, true, false),
            21987 => new GreenCandleBlock(Identifier, 3, false, true),
            21988 => new GreenCandleBlock(Identifier, 3, false, false),
            21989 => new GreenCandleBlock(Identifier, 4, true, true),
            21990 => new GreenCandleBlock(Identifier, 4, true, false),
            21991 => new GreenCandleBlock(Identifier, 4, false, true),
            21992 => new GreenCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
