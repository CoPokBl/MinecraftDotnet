using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 4462,
                    false => 4463,
                },
                1 => Waterlogged switch {
                    true => 4464,
                    false => 4465,
                },
                2 => Waterlogged switch {
                    true => 4466,
                    false => 4467,
                },
                3 => Waterlogged switch {
                    true => 4468,
                    false => 4469,
                },
                4 => Waterlogged switch {
                    true => 4470,
                    false => 4471,
                },
                5 => Waterlogged switch {
                    true => 4472,
                    false => 4473,
                },
                6 => Waterlogged switch {
                    true => 4474,
                    false => 4475,
                },
                7 => Waterlogged switch {
                    true => 4476,
                    false => 4477,
                },
                8 => Waterlogged switch {
                    true => 4478,
                    false => 4479,
                },
                9 => Waterlogged switch {
                    true => 4480,
                    false => 4481,
                },
                10 => Waterlogged switch {
                    true => 4482,
                    false => 4483,
                },
                11 => Waterlogged switch {
                    true => 4484,
                    false => 4485,
                },
                12 => Waterlogged switch {
                    true => 4486,
                    false => 4487,
                },
                13 => Waterlogged switch {
                    true => 4488,
                    false => 4489,
                },
                14 => Waterlogged switch {
                    true => 4490,
                    false => 4491,
                },
                15 => Waterlogged switch {
                    true => 4492,
                    false => 4493,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4462 => new AcaciaSignBlock(Identifier, 0, true),
            4463 => new AcaciaSignBlock(Identifier, 0, false),
            4464 => new AcaciaSignBlock(Identifier, 1, true),
            4465 => new AcaciaSignBlock(Identifier, 1, false),
            4466 => new AcaciaSignBlock(Identifier, 2, true),
            4467 => new AcaciaSignBlock(Identifier, 2, false),
            4468 => new AcaciaSignBlock(Identifier, 3, true),
            4469 => new AcaciaSignBlock(Identifier, 3, false),
            4470 => new AcaciaSignBlock(Identifier, 4, true),
            4471 => new AcaciaSignBlock(Identifier, 4, false),
            4472 => new AcaciaSignBlock(Identifier, 5, true),
            4473 => new AcaciaSignBlock(Identifier, 5, false),
            4474 => new AcaciaSignBlock(Identifier, 6, true),
            4475 => new AcaciaSignBlock(Identifier, 6, false),
            4476 => new AcaciaSignBlock(Identifier, 7, true),
            4477 => new AcaciaSignBlock(Identifier, 7, false),
            4478 => new AcaciaSignBlock(Identifier, 8, true),
            4479 => new AcaciaSignBlock(Identifier, 8, false),
            4480 => new AcaciaSignBlock(Identifier, 9, true),
            4481 => new AcaciaSignBlock(Identifier, 9, false),
            4482 => new AcaciaSignBlock(Identifier, 10, true),
            4483 => new AcaciaSignBlock(Identifier, 10, false),
            4484 => new AcaciaSignBlock(Identifier, 11, true),
            4485 => new AcaciaSignBlock(Identifier, 11, false),
            4486 => new AcaciaSignBlock(Identifier, 12, true),
            4487 => new AcaciaSignBlock(Identifier, 12, false),
            4488 => new AcaciaSignBlock(Identifier, 13, true),
            4489 => new AcaciaSignBlock(Identifier, 13, false),
            4490 => new AcaciaSignBlock(Identifier, 14, true),
            4491 => new AcaciaSignBlock(Identifier, 14, false),
            4492 => new AcaciaSignBlock(Identifier, 15, true),
            4493 => new AcaciaSignBlock(Identifier, 15, false),
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
