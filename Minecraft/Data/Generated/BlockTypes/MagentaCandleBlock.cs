using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21801,
                        false => 21802,
                    },
                    false => Waterlogged switch {
                        true => 21803,
                        false => 21804,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21805,
                        false => 21806,
                    },
                    false => Waterlogged switch {
                        true => 21807,
                        false => 21808,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21809,
                        false => 21810,
                    },
                    false => Waterlogged switch {
                        true => 21811,
                        false => 21812,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21813,
                        false => 21814,
                    },
                    false => Waterlogged switch {
                        true => 21815,
                        false => 21816,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21801 => new MagentaCandleBlock(Identifier, 1, true, true),
            21802 => new MagentaCandleBlock(Identifier, 1, true, false),
            21803 => new MagentaCandleBlock(Identifier, 1, false, true),
            21804 => new MagentaCandleBlock(Identifier, 1, false, false),
            21805 => new MagentaCandleBlock(Identifier, 2, true, true),
            21806 => new MagentaCandleBlock(Identifier, 2, true, false),
            21807 => new MagentaCandleBlock(Identifier, 2, false, true),
            21808 => new MagentaCandleBlock(Identifier, 2, false, false),
            21809 => new MagentaCandleBlock(Identifier, 3, true, true),
            21810 => new MagentaCandleBlock(Identifier, 3, true, false),
            21811 => new MagentaCandleBlock(Identifier, 3, false, true),
            21812 => new MagentaCandleBlock(Identifier, 3, false, false),
            21813 => new MagentaCandleBlock(Identifier, 4, true, true),
            21814 => new MagentaCandleBlock(Identifier, 4, true, false),
            21815 => new MagentaCandleBlock(Identifier, 4, false, true),
            21816 => new MagentaCandleBlock(Identifier, 4, false, false),
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
