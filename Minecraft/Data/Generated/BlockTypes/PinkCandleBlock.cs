using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21865,
                        false => 21866,
                    },
                    false => Waterlogged switch {
                        true => 21867,
                        false => 21868,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21869,
                        false => 21870,
                    },
                    false => Waterlogged switch {
                        true => 21871,
                        false => 21872,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21873,
                        false => 21874,
                    },
                    false => Waterlogged switch {
                        true => 21875,
                        false => 21876,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21877,
                        false => 21878,
                    },
                    false => Waterlogged switch {
                        true => 21879,
                        false => 21880,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21865 => new PinkCandleBlock(Identifier, 1, true, true),
            21866 => new PinkCandleBlock(Identifier, 1, true, false),
            21867 => new PinkCandleBlock(Identifier, 1, false, true),
            21868 => new PinkCandleBlock(Identifier, 1, false, false),
            21869 => new PinkCandleBlock(Identifier, 2, true, true),
            21870 => new PinkCandleBlock(Identifier, 2, true, false),
            21871 => new PinkCandleBlock(Identifier, 2, false, true),
            21872 => new PinkCandleBlock(Identifier, 2, false, false),
            21873 => new PinkCandleBlock(Identifier, 3, true, true),
            21874 => new PinkCandleBlock(Identifier, 3, true, false),
            21875 => new PinkCandleBlock(Identifier, 3, false, true),
            21876 => new PinkCandleBlock(Identifier, 3, false, false),
            21877 => new PinkCandleBlock(Identifier, 4, true, true),
            21878 => new PinkCandleBlock(Identifier, 4, true, false),
            21879 => new PinkCandleBlock(Identifier, 4, false, true),
            21880 => new PinkCandleBlock(Identifier, 4, false, false),
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
