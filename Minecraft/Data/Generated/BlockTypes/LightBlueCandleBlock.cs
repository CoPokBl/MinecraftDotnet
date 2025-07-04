using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21817,
                        false => 21818,
                    },
                    false => Waterlogged switch {
                        true => 21819,
                        false => 21820,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21821,
                        false => 21822,
                    },
                    false => Waterlogged switch {
                        true => 21823,
                        false => 21824,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21825,
                        false => 21826,
                    },
                    false => Waterlogged switch {
                        true => 21827,
                        false => 21828,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21829,
                        false => 21830,
                    },
                    false => Waterlogged switch {
                        true => 21831,
                        false => 21832,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21817 => new LightBlueCandleBlock(Identifier, 1, true, true),
            21818 => new LightBlueCandleBlock(Identifier, 1, true, false),
            21819 => new LightBlueCandleBlock(Identifier, 1, false, true),
            21820 => new LightBlueCandleBlock(Identifier, 1, false, false),
            21821 => new LightBlueCandleBlock(Identifier, 2, true, true),
            21822 => new LightBlueCandleBlock(Identifier, 2, true, false),
            21823 => new LightBlueCandleBlock(Identifier, 2, false, true),
            21824 => new LightBlueCandleBlock(Identifier, 2, false, false),
            21825 => new LightBlueCandleBlock(Identifier, 3, true, true),
            21826 => new LightBlueCandleBlock(Identifier, 3, true, false),
            21827 => new LightBlueCandleBlock(Identifier, 3, false, true),
            21828 => new LightBlueCandleBlock(Identifier, 3, false, false),
            21829 => new LightBlueCandleBlock(Identifier, 4, true, true),
            21830 => new LightBlueCandleBlock(Identifier, 4, true, false),
            21831 => new LightBlueCandleBlock(Identifier, 4, false, true),
            21832 => new LightBlueCandleBlock(Identifier, 4, false, false),
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
