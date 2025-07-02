using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WeepingVinesBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 19634,
                1 => 19635,
                2 => 19636,
                3 => 19637,
                4 => 19638,
                5 => 19639,
                6 => 19640,
                7 => 19641,
                8 => 19642,
                9 => 19643,
                10 => 19644,
                11 => 19645,
                12 => 19646,
                13 => 19647,
                14 => 19648,
                15 => 19649,
                16 => 19650,
                17 => 19651,
                18 => 19652,
                19 => 19653,
                20 => 19654,
                21 => 19655,
                22 => 19656,
                23 => 19657,
                24 => 19658,
                25 => 19659,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19634 => new WeepingVinesBlock(Identifier, 0),
            19635 => new WeepingVinesBlock(Identifier, 1),
            19636 => new WeepingVinesBlock(Identifier, 2),
            19637 => new WeepingVinesBlock(Identifier, 3),
            19638 => new WeepingVinesBlock(Identifier, 4),
            19639 => new WeepingVinesBlock(Identifier, 5),
            19640 => new WeepingVinesBlock(Identifier, 6),
            19641 => new WeepingVinesBlock(Identifier, 7),
            19642 => new WeepingVinesBlock(Identifier, 8),
            19643 => new WeepingVinesBlock(Identifier, 9),
            19644 => new WeepingVinesBlock(Identifier, 10),
            19645 => new WeepingVinesBlock(Identifier, 11),
            19646 => new WeepingVinesBlock(Identifier, 12),
            19647 => new WeepingVinesBlock(Identifier, 13),
            19648 => new WeepingVinesBlock(Identifier, 14),
            19649 => new WeepingVinesBlock(Identifier, 15),
            19650 => new WeepingVinesBlock(Identifier, 16),
            19651 => new WeepingVinesBlock(Identifier, 17),
            19652 => new WeepingVinesBlock(Identifier, 18),
            19653 => new WeepingVinesBlock(Identifier, 19),
            19654 => new WeepingVinesBlock(Identifier, 20),
            19655 => new WeepingVinesBlock(Identifier, 21),
            19656 => new WeepingVinesBlock(Identifier, 22),
            19657 => new WeepingVinesBlock(Identifier, 23),
            19658 => new WeepingVinesBlock(Identifier, 24),
            19659 => new WeepingVinesBlock(Identifier, 25),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
