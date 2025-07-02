using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PaleOakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 4590,
                    false => 4591,
                },
                1 => Waterlogged switch {
                    true => 4592,
                    false => 4593,
                },
                2 => Waterlogged switch {
                    true => 4594,
                    false => 4595,
                },
                3 => Waterlogged switch {
                    true => 4596,
                    false => 4597,
                },
                4 => Waterlogged switch {
                    true => 4598,
                    false => 4599,
                },
                5 => Waterlogged switch {
                    true => 4600,
                    false => 4601,
                },
                6 => Waterlogged switch {
                    true => 4602,
                    false => 4603,
                },
                7 => Waterlogged switch {
                    true => 4604,
                    false => 4605,
                },
                8 => Waterlogged switch {
                    true => 4606,
                    false => 4607,
                },
                9 => Waterlogged switch {
                    true => 4608,
                    false => 4609,
                },
                10 => Waterlogged switch {
                    true => 4610,
                    false => 4611,
                },
                11 => Waterlogged switch {
                    true => 4612,
                    false => 4613,
                },
                12 => Waterlogged switch {
                    true => 4614,
                    false => 4615,
                },
                13 => Waterlogged switch {
                    true => 4616,
                    false => 4617,
                },
                14 => Waterlogged switch {
                    true => 4618,
                    false => 4619,
                },
                15 => Waterlogged switch {
                    true => 4620,
                    false => 4621,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            4590 => new PaleOakSignBlock(Identifier, 0, true),
            4591 => new PaleOakSignBlock(Identifier, 0, false),
            4592 => new PaleOakSignBlock(Identifier, 1, true),
            4593 => new PaleOakSignBlock(Identifier, 1, false),
            4594 => new PaleOakSignBlock(Identifier, 2, true),
            4595 => new PaleOakSignBlock(Identifier, 2, false),
            4596 => new PaleOakSignBlock(Identifier, 3, true),
            4597 => new PaleOakSignBlock(Identifier, 3, false),
            4598 => new PaleOakSignBlock(Identifier, 4, true),
            4599 => new PaleOakSignBlock(Identifier, 4, false),
            4600 => new PaleOakSignBlock(Identifier, 5, true),
            4601 => new PaleOakSignBlock(Identifier, 5, false),
            4602 => new PaleOakSignBlock(Identifier, 6, true),
            4603 => new PaleOakSignBlock(Identifier, 6, false),
            4604 => new PaleOakSignBlock(Identifier, 7, true),
            4605 => new PaleOakSignBlock(Identifier, 7, false),
            4606 => new PaleOakSignBlock(Identifier, 8, true),
            4607 => new PaleOakSignBlock(Identifier, 8, false),
            4608 => new PaleOakSignBlock(Identifier, 9, true),
            4609 => new PaleOakSignBlock(Identifier, 9, false),
            4610 => new PaleOakSignBlock(Identifier, 10, true),
            4611 => new PaleOakSignBlock(Identifier, 10, false),
            4612 => new PaleOakSignBlock(Identifier, 11, true),
            4613 => new PaleOakSignBlock(Identifier, 11, false),
            4614 => new PaleOakSignBlock(Identifier, 12, true),
            4615 => new PaleOakSignBlock(Identifier, 12, false),
            4616 => new PaleOakSignBlock(Identifier, 13, true),
            4617 => new PaleOakSignBlock(Identifier, 13, false),
            4618 => new PaleOakSignBlock(Identifier, 14, true),
            4619 => new PaleOakSignBlock(Identifier, 14, false),
            4620 => new PaleOakSignBlock(Identifier, 15, true),
            4621 => new PaleOakSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
