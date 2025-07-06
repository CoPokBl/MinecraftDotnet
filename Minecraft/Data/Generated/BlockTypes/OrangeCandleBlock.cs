using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21785,
                        false => 21786,
                    },
                    false => Waterlogged switch {
                        true => 21787,
                        false => 21788,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21789,
                        false => 21790,
                    },
                    false => Waterlogged switch {
                        true => 21791,
                        false => 21792,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21793,
                        false => 21794,
                    },
                    false => Waterlogged switch {
                        true => 21795,
                        false => 21796,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21797,
                        false => 21798,
                    },
                    false => Waterlogged switch {
                        true => 21799,
                        false => 21800,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21785 => new OrangeCandleBlock(Identifier, 1, true, true),
            21786 => new OrangeCandleBlock(Identifier, 1, true, false),
            21787 => new OrangeCandleBlock(Identifier, 1, false, true),
            21788 => new OrangeCandleBlock(Identifier, 1, false, false),
            21789 => new OrangeCandleBlock(Identifier, 2, true, true),
            21790 => new OrangeCandleBlock(Identifier, 2, true, false),
            21791 => new OrangeCandleBlock(Identifier, 2, false, true),
            21792 => new OrangeCandleBlock(Identifier, 2, false, false),
            21793 => new OrangeCandleBlock(Identifier, 3, true, true),
            21794 => new OrangeCandleBlock(Identifier, 3, true, false),
            21795 => new OrangeCandleBlock(Identifier, 3, false, true),
            21796 => new OrangeCandleBlock(Identifier, 3, false, false),
            21797 => new OrangeCandleBlock(Identifier, 4, true, true),
            21798 => new OrangeCandleBlock(Identifier, 4, true, false),
            21799 => new OrangeCandleBlock(Identifier, 4, false, true),
            21800 => new OrangeCandleBlock(Identifier, 4, false, false),
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
