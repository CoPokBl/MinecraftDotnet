using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21913,
                        false => 21914,
                    },
                    false => Waterlogged switch {
                        true => 21915,
                        false => 21916,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21917,
                        false => 21918,
                    },
                    false => Waterlogged switch {
                        true => 21919,
                        false => 21920,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21921,
                        false => 21922,
                    },
                    false => Waterlogged switch {
                        true => 21923,
                        false => 21924,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21925,
                        false => 21926,
                    },
                    false => Waterlogged switch {
                        true => 21927,
                        false => 21928,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21913 => new CyanCandleBlock(Identifier, 1, true, true),
            21914 => new CyanCandleBlock(Identifier, 1, true, false),
            21915 => new CyanCandleBlock(Identifier, 1, false, true),
            21916 => new CyanCandleBlock(Identifier, 1, false, false),
            21917 => new CyanCandleBlock(Identifier, 2, true, true),
            21918 => new CyanCandleBlock(Identifier, 2, true, false),
            21919 => new CyanCandleBlock(Identifier, 2, false, true),
            21920 => new CyanCandleBlock(Identifier, 2, false, false),
            21921 => new CyanCandleBlock(Identifier, 3, true, true),
            21922 => new CyanCandleBlock(Identifier, 3, true, false),
            21923 => new CyanCandleBlock(Identifier, 3, false, true),
            21924 => new CyanCandleBlock(Identifier, 3, false, false),
            21925 => new CyanCandleBlock(Identifier, 4, true, true),
            21926 => new CyanCandleBlock(Identifier, 4, true, false),
            21927 => new CyanCandleBlock(Identifier, 4, false, true),
            21928 => new CyanCandleBlock(Identifier, 4, false, false),
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
