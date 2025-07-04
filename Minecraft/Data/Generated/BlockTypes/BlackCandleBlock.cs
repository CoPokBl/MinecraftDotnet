using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22009,
                        false => 22010,
                    },
                    false => Waterlogged switch {
                        true => 22011,
                        false => 22012,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22013,
                        false => 22014,
                    },
                    false => Waterlogged switch {
                        true => 22015,
                        false => 22016,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22017,
                        false => 22018,
                    },
                    false => Waterlogged switch {
                        true => 22019,
                        false => 22020,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22021,
                        false => 22022,
                    },
                    false => Waterlogged switch {
                        true => 22023,
                        false => 22024,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22009 => new BlackCandleBlock(Identifier, 1, true, true),
            22010 => new BlackCandleBlock(Identifier, 1, true, false),
            22011 => new BlackCandleBlock(Identifier, 1, false, true),
            22012 => new BlackCandleBlock(Identifier, 1, false, false),
            22013 => new BlackCandleBlock(Identifier, 2, true, true),
            22014 => new BlackCandleBlock(Identifier, 2, true, false),
            22015 => new BlackCandleBlock(Identifier, 2, false, true),
            22016 => new BlackCandleBlock(Identifier, 2, false, false),
            22017 => new BlackCandleBlock(Identifier, 3, true, true),
            22018 => new BlackCandleBlock(Identifier, 3, true, false),
            22019 => new BlackCandleBlock(Identifier, 3, false, true),
            22020 => new BlackCandleBlock(Identifier, 3, false, false),
            22021 => new BlackCandleBlock(Identifier, 4, true, true),
            22022 => new BlackCandleBlock(Identifier, 4, true, false),
            22023 => new BlackCandleBlock(Identifier, 4, false, true),
            22024 => new BlackCandleBlock(Identifier, 4, false, false),
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
