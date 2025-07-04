using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21881,
                        false => 21882,
                    },
                    false => Waterlogged switch {
                        true => 21883,
                        false => 21884,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21885,
                        false => 21886,
                    },
                    false => Waterlogged switch {
                        true => 21887,
                        false => 21888,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21889,
                        false => 21890,
                    },
                    false => Waterlogged switch {
                        true => 21891,
                        false => 21892,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21893,
                        false => 21894,
                    },
                    false => Waterlogged switch {
                        true => 21895,
                        false => 21896,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21881 => new GrayCandleBlock(Identifier, 1, true, true),
            21882 => new GrayCandleBlock(Identifier, 1, true, false),
            21883 => new GrayCandleBlock(Identifier, 1, false, true),
            21884 => new GrayCandleBlock(Identifier, 1, false, false),
            21885 => new GrayCandleBlock(Identifier, 2, true, true),
            21886 => new GrayCandleBlock(Identifier, 2, true, false),
            21887 => new GrayCandleBlock(Identifier, 2, false, true),
            21888 => new GrayCandleBlock(Identifier, 2, false, false),
            21889 => new GrayCandleBlock(Identifier, 3, true, true),
            21890 => new GrayCandleBlock(Identifier, 3, true, false),
            21891 => new GrayCandleBlock(Identifier, 3, false, true),
            21892 => new GrayCandleBlock(Identifier, 3, false, false),
            21893 => new GrayCandleBlock(Identifier, 4, true, true),
            21894 => new GrayCandleBlock(Identifier, 4, true, false),
            21895 => new GrayCandleBlock(Identifier, 4, false, true),
            21896 => new GrayCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = int.Parse(properties["candles"].GetString()),
            Lit = properties["lit"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
