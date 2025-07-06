using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 4430,
                    false => 4431,
                },
                1 => Waterlogged switch {
                    true => 4432,
                    false => 4433,
                },
                2 => Waterlogged switch {
                    true => 4434,
                    false => 4435,
                },
                3 => Waterlogged switch {
                    true => 4436,
                    false => 4437,
                },
                4 => Waterlogged switch {
                    true => 4438,
                    false => 4439,
                },
                5 => Waterlogged switch {
                    true => 4440,
                    false => 4441,
                },
                6 => Waterlogged switch {
                    true => 4442,
                    false => 4443,
                },
                7 => Waterlogged switch {
                    true => 4444,
                    false => 4445,
                },
                8 => Waterlogged switch {
                    true => 4446,
                    false => 4447,
                },
                9 => Waterlogged switch {
                    true => 4448,
                    false => 4449,
                },
                10 => Waterlogged switch {
                    true => 4450,
                    false => 4451,
                },
                11 => Waterlogged switch {
                    true => 4452,
                    false => 4453,
                },
                12 => Waterlogged switch {
                    true => 4454,
                    false => 4455,
                },
                13 => Waterlogged switch {
                    true => 4456,
                    false => 4457,
                },
                14 => Waterlogged switch {
                    true => 4458,
                    false => 4459,
                },
                15 => Waterlogged switch {
                    true => 4460,
                    false => 4461,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4430 => new BirchSignBlock(Identifier, 0, true),
            4431 => new BirchSignBlock(Identifier, 0, false),
            4432 => new BirchSignBlock(Identifier, 1, true),
            4433 => new BirchSignBlock(Identifier, 1, false),
            4434 => new BirchSignBlock(Identifier, 2, true),
            4435 => new BirchSignBlock(Identifier, 2, false),
            4436 => new BirchSignBlock(Identifier, 3, true),
            4437 => new BirchSignBlock(Identifier, 3, false),
            4438 => new BirchSignBlock(Identifier, 4, true),
            4439 => new BirchSignBlock(Identifier, 4, false),
            4440 => new BirchSignBlock(Identifier, 5, true),
            4441 => new BirchSignBlock(Identifier, 5, false),
            4442 => new BirchSignBlock(Identifier, 6, true),
            4443 => new BirchSignBlock(Identifier, 6, false),
            4444 => new BirchSignBlock(Identifier, 7, true),
            4445 => new BirchSignBlock(Identifier, 7, false),
            4446 => new BirchSignBlock(Identifier, 8, true),
            4447 => new BirchSignBlock(Identifier, 8, false),
            4448 => new BirchSignBlock(Identifier, 9, true),
            4449 => new BirchSignBlock(Identifier, 9, false),
            4450 => new BirchSignBlock(Identifier, 10, true),
            4451 => new BirchSignBlock(Identifier, 10, false),
            4452 => new BirchSignBlock(Identifier, 11, true),
            4453 => new BirchSignBlock(Identifier, 11, false),
            4454 => new BirchSignBlock(Identifier, 12, true),
            4455 => new BirchSignBlock(Identifier, 12, false),
            4456 => new BirchSignBlock(Identifier, 13, true),
            4457 => new BirchSignBlock(Identifier, 13, false),
            4458 => new BirchSignBlock(Identifier, 14, true),
            4459 => new BirchSignBlock(Identifier, 14, false),
            4460 => new BirchSignBlock(Identifier, 15, true),
            4461 => new BirchSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
