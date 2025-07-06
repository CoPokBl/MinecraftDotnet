using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21945,
                        false => 21946,
                    },
                    false => Waterlogged switch {
                        true => 21947,
                        false => 21948,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21949,
                        false => 21950,
                    },
                    false => Waterlogged switch {
                        true => 21951,
                        false => 21952,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21953,
                        false => 21954,
                    },
                    false => Waterlogged switch {
                        true => 21955,
                        false => 21956,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21957,
                        false => 21958,
                    },
                    false => Waterlogged switch {
                        true => 21959,
                        false => 21960,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21945 => new BlueCandleBlock(Identifier, 1, true, true),
            21946 => new BlueCandleBlock(Identifier, 1, true, false),
            21947 => new BlueCandleBlock(Identifier, 1, false, true),
            21948 => new BlueCandleBlock(Identifier, 1, false, false),
            21949 => new BlueCandleBlock(Identifier, 2, true, true),
            21950 => new BlueCandleBlock(Identifier, 2, true, false),
            21951 => new BlueCandleBlock(Identifier, 2, false, true),
            21952 => new BlueCandleBlock(Identifier, 2, false, false),
            21953 => new BlueCandleBlock(Identifier, 3, true, true),
            21954 => new BlueCandleBlock(Identifier, 3, true, false),
            21955 => new BlueCandleBlock(Identifier, 3, false, true),
            21956 => new BlueCandleBlock(Identifier, 3, false, false),
            21957 => new BlueCandleBlock(Identifier, 4, true, true),
            21958 => new BlueCandleBlock(Identifier, 4, true, false),
            21959 => new BlueCandleBlock(Identifier, 4, false, true),
            21960 => new BlueCandleBlock(Identifier, 4, false, false),
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
