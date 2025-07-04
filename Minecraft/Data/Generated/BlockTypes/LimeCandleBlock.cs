using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21849,
                        false => 21850,
                    },
                    false => Waterlogged switch {
                        true => 21851,
                        false => 21852,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21853,
                        false => 21854,
                    },
                    false => Waterlogged switch {
                        true => 21855,
                        false => 21856,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21857,
                        false => 21858,
                    },
                    false => Waterlogged switch {
                        true => 21859,
                        false => 21860,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21861,
                        false => 21862,
                    },
                    false => Waterlogged switch {
                        true => 21863,
                        false => 21864,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21849 => new LimeCandleBlock(Identifier, 1, true, true),
            21850 => new LimeCandleBlock(Identifier, 1, true, false),
            21851 => new LimeCandleBlock(Identifier, 1, false, true),
            21852 => new LimeCandleBlock(Identifier, 1, false, false),
            21853 => new LimeCandleBlock(Identifier, 2, true, true),
            21854 => new LimeCandleBlock(Identifier, 2, true, false),
            21855 => new LimeCandleBlock(Identifier, 2, false, true),
            21856 => new LimeCandleBlock(Identifier, 2, false, false),
            21857 => new LimeCandleBlock(Identifier, 3, true, true),
            21858 => new LimeCandleBlock(Identifier, 3, true, false),
            21859 => new LimeCandleBlock(Identifier, 3, false, true),
            21860 => new LimeCandleBlock(Identifier, 3, false, false),
            21861 => new LimeCandleBlock(Identifier, 4, true, true),
            21862 => new LimeCandleBlock(Identifier, 4, true, false),
            21863 => new LimeCandleBlock(Identifier, 4, false, true),
            21864 => new LimeCandleBlock(Identifier, 4, false, false),
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
