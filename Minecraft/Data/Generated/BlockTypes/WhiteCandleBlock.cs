using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21769,
                        false => 21770,
                    },
                    false => Waterlogged switch {
                        true => 21771,
                        false => 21772,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21773,
                        false => 21774,
                    },
                    false => Waterlogged switch {
                        true => 21775,
                        false => 21776,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21777,
                        false => 21778,
                    },
                    false => Waterlogged switch {
                        true => 21779,
                        false => 21780,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21781,
                        false => 21782,
                    },
                    false => Waterlogged switch {
                        true => 21783,
                        false => 21784,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21769 => new WhiteCandleBlock(Identifier, 1, true, true),
            21770 => new WhiteCandleBlock(Identifier, 1, true, false),
            21771 => new WhiteCandleBlock(Identifier, 1, false, true),
            21772 => new WhiteCandleBlock(Identifier, 1, false, false),
            21773 => new WhiteCandleBlock(Identifier, 2, true, true),
            21774 => new WhiteCandleBlock(Identifier, 2, true, false),
            21775 => new WhiteCandleBlock(Identifier, 2, false, true),
            21776 => new WhiteCandleBlock(Identifier, 2, false, false),
            21777 => new WhiteCandleBlock(Identifier, 3, true, true),
            21778 => new WhiteCandleBlock(Identifier, 3, true, false),
            21779 => new WhiteCandleBlock(Identifier, 3, false, true),
            21780 => new WhiteCandleBlock(Identifier, 3, false, false),
            21781 => new WhiteCandleBlock(Identifier, 4, true, true),
            21782 => new WhiteCandleBlock(Identifier, 4, true, false),
            21783 => new WhiteCandleBlock(Identifier, 4, false, true),
            21784 => new WhiteCandleBlock(Identifier, 4, false, false),
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
