using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SeaPickleBlock(Identifier Identifier, int Pickles, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Pickles switch {
                1 => Waterlogged switch {
                    true => 13956,
                    false => 13957,
                },
                2 => Waterlogged switch {
                    true => 13958,
                    false => 13959,
                },
                3 => Waterlogged switch {
                    true => 13960,
                    false => 13961,
                },
                4 => Waterlogged switch {
                    true => 13962,
                    false => 13963,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Pickles), Pickles, "Unknown value for property pickles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13956 => new SeaPickleBlock(Identifier, 1, true),
            13957 => new SeaPickleBlock(Identifier, 1, false),
            13958 => new SeaPickleBlock(Identifier, 2, true),
            13959 => new SeaPickleBlock(Identifier, 2, false),
            13960 => new SeaPickleBlock(Identifier, 3, true),
            13961 => new SeaPickleBlock(Identifier, 3, false),
            13962 => new SeaPickleBlock(Identifier, 4, true),
            13963 => new SeaPickleBlock(Identifier, 4, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Pickles = int.Parse(properties["pickles"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
