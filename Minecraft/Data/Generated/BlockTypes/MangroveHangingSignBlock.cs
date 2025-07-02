using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MangroveHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5578,
                        false => 5579,
                    },
                    1 => Waterlogged switch {
                        true => 5580,
                        false => 5581,
                    },
                    2 => Waterlogged switch {
                        true => 5582,
                        false => 5583,
                    },
                    3 => Waterlogged switch {
                        true => 5584,
                        false => 5585,
                    },
                    4 => Waterlogged switch {
                        true => 5586,
                        false => 5587,
                    },
                    5 => Waterlogged switch {
                        true => 5588,
                        false => 5589,
                    },
                    6 => Waterlogged switch {
                        true => 5590,
                        false => 5591,
                    },
                    7 => Waterlogged switch {
                        true => 5592,
                        false => 5593,
                    },
                    8 => Waterlogged switch {
                        true => 5594,
                        false => 5595,
                    },
                    9 => Waterlogged switch {
                        true => 5596,
                        false => 5597,
                    },
                    10 => Waterlogged switch {
                        true => 5598,
                        false => 5599,
                    },
                    11 => Waterlogged switch {
                        true => 5600,
                        false => 5601,
                    },
                    12 => Waterlogged switch {
                        true => 5602,
                        false => 5603,
                    },
                    13 => Waterlogged switch {
                        true => 5604,
                        false => 5605,
                    },
                    14 => Waterlogged switch {
                        true => 5606,
                        false => 5607,
                    },
                    15 => Waterlogged switch {
                        true => 5608,
                        false => 5609,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5610,
                        false => 5611,
                    },
                    1 => Waterlogged switch {
                        true => 5612,
                        false => 5613,
                    },
                    2 => Waterlogged switch {
                        true => 5614,
                        false => 5615,
                    },
                    3 => Waterlogged switch {
                        true => 5616,
                        false => 5617,
                    },
                    4 => Waterlogged switch {
                        true => 5618,
                        false => 5619,
                    },
                    5 => Waterlogged switch {
                        true => 5620,
                        false => 5621,
                    },
                    6 => Waterlogged switch {
                        true => 5622,
                        false => 5623,
                    },
                    7 => Waterlogged switch {
                        true => 5624,
                        false => 5625,
                    },
                    8 => Waterlogged switch {
                        true => 5626,
                        false => 5627,
                    },
                    9 => Waterlogged switch {
                        true => 5628,
                        false => 5629,
                    },
                    10 => Waterlogged switch {
                        true => 5630,
                        false => 5631,
                    },
                    11 => Waterlogged switch {
                        true => 5632,
                        false => 5633,
                    },
                    12 => Waterlogged switch {
                        true => 5634,
                        false => 5635,
                    },
                    13 => Waterlogged switch {
                        true => 5636,
                        false => 5637,
                    },
                    14 => Waterlogged switch {
                        true => 5638,
                        false => 5639,
                    },
                    15 => Waterlogged switch {
                        true => 5640,
                        false => 5641,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5578 => new MangroveHangingSignBlock(Identifier, true, 0, true),
            5579 => new MangroveHangingSignBlock(Identifier, true, 0, false),
            5580 => new MangroveHangingSignBlock(Identifier, true, 1, true),
            5581 => new MangroveHangingSignBlock(Identifier, true, 1, false),
            5582 => new MangroveHangingSignBlock(Identifier, true, 2, true),
            5583 => new MangroveHangingSignBlock(Identifier, true, 2, false),
            5584 => new MangroveHangingSignBlock(Identifier, true, 3, true),
            5585 => new MangroveHangingSignBlock(Identifier, true, 3, false),
            5586 => new MangroveHangingSignBlock(Identifier, true, 4, true),
            5587 => new MangroveHangingSignBlock(Identifier, true, 4, false),
            5588 => new MangroveHangingSignBlock(Identifier, true, 5, true),
            5589 => new MangroveHangingSignBlock(Identifier, true, 5, false),
            5590 => new MangroveHangingSignBlock(Identifier, true, 6, true),
            5591 => new MangroveHangingSignBlock(Identifier, true, 6, false),
            5592 => new MangroveHangingSignBlock(Identifier, true, 7, true),
            5593 => new MangroveHangingSignBlock(Identifier, true, 7, false),
            5594 => new MangroveHangingSignBlock(Identifier, true, 8, true),
            5595 => new MangroveHangingSignBlock(Identifier, true, 8, false),
            5596 => new MangroveHangingSignBlock(Identifier, true, 9, true),
            5597 => new MangroveHangingSignBlock(Identifier, true, 9, false),
            5598 => new MangroveHangingSignBlock(Identifier, true, 10, true),
            5599 => new MangroveHangingSignBlock(Identifier, true, 10, false),
            5600 => new MangroveHangingSignBlock(Identifier, true, 11, true),
            5601 => new MangroveHangingSignBlock(Identifier, true, 11, false),
            5602 => new MangroveHangingSignBlock(Identifier, true, 12, true),
            5603 => new MangroveHangingSignBlock(Identifier, true, 12, false),
            5604 => new MangroveHangingSignBlock(Identifier, true, 13, true),
            5605 => new MangroveHangingSignBlock(Identifier, true, 13, false),
            5606 => new MangroveHangingSignBlock(Identifier, true, 14, true),
            5607 => new MangroveHangingSignBlock(Identifier, true, 14, false),
            5608 => new MangroveHangingSignBlock(Identifier, true, 15, true),
            5609 => new MangroveHangingSignBlock(Identifier, true, 15, false),
            5610 => new MangroveHangingSignBlock(Identifier, false, 0, true),
            5611 => new MangroveHangingSignBlock(Identifier, false, 0, false),
            5612 => new MangroveHangingSignBlock(Identifier, false, 1, true),
            5613 => new MangroveHangingSignBlock(Identifier, false, 1, false),
            5614 => new MangroveHangingSignBlock(Identifier, false, 2, true),
            5615 => new MangroveHangingSignBlock(Identifier, false, 2, false),
            5616 => new MangroveHangingSignBlock(Identifier, false, 3, true),
            5617 => new MangroveHangingSignBlock(Identifier, false, 3, false),
            5618 => new MangroveHangingSignBlock(Identifier, false, 4, true),
            5619 => new MangroveHangingSignBlock(Identifier, false, 4, false),
            5620 => new MangroveHangingSignBlock(Identifier, false, 5, true),
            5621 => new MangroveHangingSignBlock(Identifier, false, 5, false),
            5622 => new MangroveHangingSignBlock(Identifier, false, 6, true),
            5623 => new MangroveHangingSignBlock(Identifier, false, 6, false),
            5624 => new MangroveHangingSignBlock(Identifier, false, 7, true),
            5625 => new MangroveHangingSignBlock(Identifier, false, 7, false),
            5626 => new MangroveHangingSignBlock(Identifier, false, 8, true),
            5627 => new MangroveHangingSignBlock(Identifier, false, 8, false),
            5628 => new MangroveHangingSignBlock(Identifier, false, 9, true),
            5629 => new MangroveHangingSignBlock(Identifier, false, 9, false),
            5630 => new MangroveHangingSignBlock(Identifier, false, 10, true),
            5631 => new MangroveHangingSignBlock(Identifier, false, 10, false),
            5632 => new MangroveHangingSignBlock(Identifier, false, 11, true),
            5633 => new MangroveHangingSignBlock(Identifier, false, 11, false),
            5634 => new MangroveHangingSignBlock(Identifier, false, 12, true),
            5635 => new MangroveHangingSignBlock(Identifier, false, 12, false),
            5636 => new MangroveHangingSignBlock(Identifier, false, 13, true),
            5637 => new MangroveHangingSignBlock(Identifier, false, 13, false),
            5638 => new MangroveHangingSignBlock(Identifier, false, 14, true),
            5639 => new MangroveHangingSignBlock(Identifier, false, 14, false),
            5640 => new MangroveHangingSignBlock(Identifier, false, 15, true),
            5641 => new MangroveHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
