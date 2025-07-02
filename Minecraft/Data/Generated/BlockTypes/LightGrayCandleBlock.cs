using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record LightGrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21897,
                        false => 21898,
                    },
                    false => Waterlogged switch {
                        true => 21899,
                        false => 21900,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21901,
                        false => 21902,
                    },
                    false => Waterlogged switch {
                        true => 21903,
                        false => 21904,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21905,
                        false => 21906,
                    },
                    false => Waterlogged switch {
                        true => 21907,
                        false => 21908,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21909,
                        false => 21910,
                    },
                    false => Waterlogged switch {
                        true => 21911,
                        false => 21912,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21897 => new LightGrayCandleBlock(Identifier, 1, true, true),
            21898 => new LightGrayCandleBlock(Identifier, 1, true, false),
            21899 => new LightGrayCandleBlock(Identifier, 1, false, true),
            21900 => new LightGrayCandleBlock(Identifier, 1, false, false),
            21901 => new LightGrayCandleBlock(Identifier, 2, true, true),
            21902 => new LightGrayCandleBlock(Identifier, 2, true, false),
            21903 => new LightGrayCandleBlock(Identifier, 2, false, true),
            21904 => new LightGrayCandleBlock(Identifier, 2, false, false),
            21905 => new LightGrayCandleBlock(Identifier, 3, true, true),
            21906 => new LightGrayCandleBlock(Identifier, 3, true, false),
            21907 => new LightGrayCandleBlock(Identifier, 3, false, true),
            21908 => new LightGrayCandleBlock(Identifier, 3, false, false),
            21909 => new LightGrayCandleBlock(Identifier, 4, true, true),
            21910 => new LightGrayCandleBlock(Identifier, 4, true, false),
            21911 => new LightGrayCandleBlock(Identifier, 4, false, true),
            21912 => new LightGrayCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
