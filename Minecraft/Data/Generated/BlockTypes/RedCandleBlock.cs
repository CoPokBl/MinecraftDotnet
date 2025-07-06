using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21993,
                        false => 21994,
                    },
                    false => Waterlogged switch {
                        true => 21995,
                        false => 21996,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21997,
                        false => 21998,
                    },
                    false => Waterlogged switch {
                        true => 21999,
                        false => 22000,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22001,
                        false => 22002,
                    },
                    false => Waterlogged switch {
                        true => 22003,
                        false => 22004,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22005,
                        false => 22006,
                    },
                    false => Waterlogged switch {
                        true => 22007,
                        false => 22008,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21993 => new RedCandleBlock(Identifier, 1, true, true),
            21994 => new RedCandleBlock(Identifier, 1, true, false),
            21995 => new RedCandleBlock(Identifier, 1, false, true),
            21996 => new RedCandleBlock(Identifier, 1, false, false),
            21997 => new RedCandleBlock(Identifier, 2, true, true),
            21998 => new RedCandleBlock(Identifier, 2, true, false),
            21999 => new RedCandleBlock(Identifier, 2, false, true),
            22000 => new RedCandleBlock(Identifier, 2, false, false),
            22001 => new RedCandleBlock(Identifier, 3, true, true),
            22002 => new RedCandleBlock(Identifier, 3, true, false),
            22003 => new RedCandleBlock(Identifier, 3, false, true),
            22004 => new RedCandleBlock(Identifier, 3, false, false),
            22005 => new RedCandleBlock(Identifier, 4, true, true),
            22006 => new RedCandleBlock(Identifier, 4, true, false),
            22007 => new RedCandleBlock(Identifier, 4, false, true),
            22008 => new RedCandleBlock(Identifier, 4, false, false),
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
