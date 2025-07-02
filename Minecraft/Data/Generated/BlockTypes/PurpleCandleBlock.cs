using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PurpleCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21929,
                        false => 21930,
                    },
                    false => Waterlogged switch {
                        true => 21931,
                        false => 21932,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21933,
                        false => 21934,
                    },
                    false => Waterlogged switch {
                        true => 21935,
                        false => 21936,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21937,
                        false => 21938,
                    },
                    false => Waterlogged switch {
                        true => 21939,
                        false => 21940,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21941,
                        false => 21942,
                    },
                    false => Waterlogged switch {
                        true => 21943,
                        false => 21944,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21929 => new PurpleCandleBlock(Identifier, 1, true, true),
            21930 => new PurpleCandleBlock(Identifier, 1, true, false),
            21931 => new PurpleCandleBlock(Identifier, 1, false, true),
            21932 => new PurpleCandleBlock(Identifier, 1, false, false),
            21933 => new PurpleCandleBlock(Identifier, 2, true, true),
            21934 => new PurpleCandleBlock(Identifier, 2, true, false),
            21935 => new PurpleCandleBlock(Identifier, 2, false, true),
            21936 => new PurpleCandleBlock(Identifier, 2, false, false),
            21937 => new PurpleCandleBlock(Identifier, 3, true, true),
            21938 => new PurpleCandleBlock(Identifier, 3, true, false),
            21939 => new PurpleCandleBlock(Identifier, 3, false, true),
            21940 => new PurpleCandleBlock(Identifier, 3, false, false),
            21941 => new PurpleCandleBlock(Identifier, 4, true, true),
            21942 => new PurpleCandleBlock(Identifier, 4, true, false),
            21943 => new PurpleCandleBlock(Identifier, 4, false, true),
            21944 => new PurpleCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
