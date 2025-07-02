using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21753,
                        false => 21754,
                    },
                    false => Waterlogged switch {
                        true => 21755,
                        false => 21756,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21757,
                        false => 21758,
                    },
                    false => Waterlogged switch {
                        true => 21759,
                        false => 21760,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21761,
                        false => 21762,
                    },
                    false => Waterlogged switch {
                        true => 21763,
                        false => 21764,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21765,
                        false => 21766,
                    },
                    false => Waterlogged switch {
                        true => 21767,
                        false => 21768,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21753 => new CandleBlock(Identifier, 1, true, true),
            21754 => new CandleBlock(Identifier, 1, true, false),
            21755 => new CandleBlock(Identifier, 1, false, true),
            21756 => new CandleBlock(Identifier, 1, false, false),
            21757 => new CandleBlock(Identifier, 2, true, true),
            21758 => new CandleBlock(Identifier, 2, true, false),
            21759 => new CandleBlock(Identifier, 2, false, true),
            21760 => new CandleBlock(Identifier, 2, false, false),
            21761 => new CandleBlock(Identifier, 3, true, true),
            21762 => new CandleBlock(Identifier, 3, true, false),
            21763 => new CandleBlock(Identifier, 3, false, true),
            21764 => new CandleBlock(Identifier, 3, false, false),
            21765 => new CandleBlock(Identifier, 4, true, true),
            21766 => new CandleBlock(Identifier, 4, true, false),
            21767 => new CandleBlock(Identifier, 4, false, true),
            21768 => new CandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
