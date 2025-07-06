using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21961,
                        false => 21962,
                    },
                    false => Waterlogged switch {
                        true => 21963,
                        false => 21964,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21965,
                        false => 21966,
                    },
                    false => Waterlogged switch {
                        true => 21967,
                        false => 21968,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21969,
                        false => 21970,
                    },
                    false => Waterlogged switch {
                        true => 21971,
                        false => 21972,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21973,
                        false => 21974,
                    },
                    false => Waterlogged switch {
                        true => 21975,
                        false => 21976,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21961 => new BrownCandleBlock(Identifier, 1, true, true),
            21962 => new BrownCandleBlock(Identifier, 1, true, false),
            21963 => new BrownCandleBlock(Identifier, 1, false, true),
            21964 => new BrownCandleBlock(Identifier, 1, false, false),
            21965 => new BrownCandleBlock(Identifier, 2, true, true),
            21966 => new BrownCandleBlock(Identifier, 2, true, false),
            21967 => new BrownCandleBlock(Identifier, 2, false, true),
            21968 => new BrownCandleBlock(Identifier, 2, false, false),
            21969 => new BrownCandleBlock(Identifier, 3, true, true),
            21970 => new BrownCandleBlock(Identifier, 3, true, false),
            21971 => new BrownCandleBlock(Identifier, 3, false, true),
            21972 => new BrownCandleBlock(Identifier, 3, false, false),
            21973 => new BrownCandleBlock(Identifier, 4, true, true),
            21974 => new BrownCandleBlock(Identifier, 4, true, false),
            21975 => new BrownCandleBlock(Identifier, 4, false, true),
            21976 => new BrownCandleBlock(Identifier, 4, false, false),
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
