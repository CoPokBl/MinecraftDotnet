using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5642,
                        false => 5643,
                    },
                    1 => Waterlogged switch {
                        true => 5644,
                        false => 5645,
                    },
                    2 => Waterlogged switch {
                        true => 5646,
                        false => 5647,
                    },
                    3 => Waterlogged switch {
                        true => 5648,
                        false => 5649,
                    },
                    4 => Waterlogged switch {
                        true => 5650,
                        false => 5651,
                    },
                    5 => Waterlogged switch {
                        true => 5652,
                        false => 5653,
                    },
                    6 => Waterlogged switch {
                        true => 5654,
                        false => 5655,
                    },
                    7 => Waterlogged switch {
                        true => 5656,
                        false => 5657,
                    },
                    8 => Waterlogged switch {
                        true => 5658,
                        false => 5659,
                    },
                    9 => Waterlogged switch {
                        true => 5660,
                        false => 5661,
                    },
                    10 => Waterlogged switch {
                        true => 5662,
                        false => 5663,
                    },
                    11 => Waterlogged switch {
                        true => 5664,
                        false => 5665,
                    },
                    12 => Waterlogged switch {
                        true => 5666,
                        false => 5667,
                    },
                    13 => Waterlogged switch {
                        true => 5668,
                        false => 5669,
                    },
                    14 => Waterlogged switch {
                        true => 5670,
                        false => 5671,
                    },
                    15 => Waterlogged switch {
                        true => 5672,
                        false => 5673,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5674,
                        false => 5675,
                    },
                    1 => Waterlogged switch {
                        true => 5676,
                        false => 5677,
                    },
                    2 => Waterlogged switch {
                        true => 5678,
                        false => 5679,
                    },
                    3 => Waterlogged switch {
                        true => 5680,
                        false => 5681,
                    },
                    4 => Waterlogged switch {
                        true => 5682,
                        false => 5683,
                    },
                    5 => Waterlogged switch {
                        true => 5684,
                        false => 5685,
                    },
                    6 => Waterlogged switch {
                        true => 5686,
                        false => 5687,
                    },
                    7 => Waterlogged switch {
                        true => 5688,
                        false => 5689,
                    },
                    8 => Waterlogged switch {
                        true => 5690,
                        false => 5691,
                    },
                    9 => Waterlogged switch {
                        true => 5692,
                        false => 5693,
                    },
                    10 => Waterlogged switch {
                        true => 5694,
                        false => 5695,
                    },
                    11 => Waterlogged switch {
                        true => 5696,
                        false => 5697,
                    },
                    12 => Waterlogged switch {
                        true => 5698,
                        false => 5699,
                    },
                    13 => Waterlogged switch {
                        true => 5700,
                        false => 5701,
                    },
                    14 => Waterlogged switch {
                        true => 5702,
                        false => 5703,
                    },
                    15 => Waterlogged switch {
                        true => 5704,
                        false => 5705,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5642 => new BambooHangingSignBlock(Identifier, true, 0, true),
            5643 => new BambooHangingSignBlock(Identifier, true, 0, false),
            5644 => new BambooHangingSignBlock(Identifier, true, 1, true),
            5645 => new BambooHangingSignBlock(Identifier, true, 1, false),
            5646 => new BambooHangingSignBlock(Identifier, true, 2, true),
            5647 => new BambooHangingSignBlock(Identifier, true, 2, false),
            5648 => new BambooHangingSignBlock(Identifier, true, 3, true),
            5649 => new BambooHangingSignBlock(Identifier, true, 3, false),
            5650 => new BambooHangingSignBlock(Identifier, true, 4, true),
            5651 => new BambooHangingSignBlock(Identifier, true, 4, false),
            5652 => new BambooHangingSignBlock(Identifier, true, 5, true),
            5653 => new BambooHangingSignBlock(Identifier, true, 5, false),
            5654 => new BambooHangingSignBlock(Identifier, true, 6, true),
            5655 => new BambooHangingSignBlock(Identifier, true, 6, false),
            5656 => new BambooHangingSignBlock(Identifier, true, 7, true),
            5657 => new BambooHangingSignBlock(Identifier, true, 7, false),
            5658 => new BambooHangingSignBlock(Identifier, true, 8, true),
            5659 => new BambooHangingSignBlock(Identifier, true, 8, false),
            5660 => new BambooHangingSignBlock(Identifier, true, 9, true),
            5661 => new BambooHangingSignBlock(Identifier, true, 9, false),
            5662 => new BambooHangingSignBlock(Identifier, true, 10, true),
            5663 => new BambooHangingSignBlock(Identifier, true, 10, false),
            5664 => new BambooHangingSignBlock(Identifier, true, 11, true),
            5665 => new BambooHangingSignBlock(Identifier, true, 11, false),
            5666 => new BambooHangingSignBlock(Identifier, true, 12, true),
            5667 => new BambooHangingSignBlock(Identifier, true, 12, false),
            5668 => new BambooHangingSignBlock(Identifier, true, 13, true),
            5669 => new BambooHangingSignBlock(Identifier, true, 13, false),
            5670 => new BambooHangingSignBlock(Identifier, true, 14, true),
            5671 => new BambooHangingSignBlock(Identifier, true, 14, false),
            5672 => new BambooHangingSignBlock(Identifier, true, 15, true),
            5673 => new BambooHangingSignBlock(Identifier, true, 15, false),
            5674 => new BambooHangingSignBlock(Identifier, false, 0, true),
            5675 => new BambooHangingSignBlock(Identifier, false, 0, false),
            5676 => new BambooHangingSignBlock(Identifier, false, 1, true),
            5677 => new BambooHangingSignBlock(Identifier, false, 1, false),
            5678 => new BambooHangingSignBlock(Identifier, false, 2, true),
            5679 => new BambooHangingSignBlock(Identifier, false, 2, false),
            5680 => new BambooHangingSignBlock(Identifier, false, 3, true),
            5681 => new BambooHangingSignBlock(Identifier, false, 3, false),
            5682 => new BambooHangingSignBlock(Identifier, false, 4, true),
            5683 => new BambooHangingSignBlock(Identifier, false, 4, false),
            5684 => new BambooHangingSignBlock(Identifier, false, 5, true),
            5685 => new BambooHangingSignBlock(Identifier, false, 5, false),
            5686 => new BambooHangingSignBlock(Identifier, false, 6, true),
            5687 => new BambooHangingSignBlock(Identifier, false, 6, false),
            5688 => new BambooHangingSignBlock(Identifier, false, 7, true),
            5689 => new BambooHangingSignBlock(Identifier, false, 7, false),
            5690 => new BambooHangingSignBlock(Identifier, false, 8, true),
            5691 => new BambooHangingSignBlock(Identifier, false, 8, false),
            5692 => new BambooHangingSignBlock(Identifier, false, 9, true),
            5693 => new BambooHangingSignBlock(Identifier, false, 9, false),
            5694 => new BambooHangingSignBlock(Identifier, false, 10, true),
            5695 => new BambooHangingSignBlock(Identifier, false, 10, false),
            5696 => new BambooHangingSignBlock(Identifier, false, 11, true),
            5697 => new BambooHangingSignBlock(Identifier, false, 11, false),
            5698 => new BambooHangingSignBlock(Identifier, false, 12, true),
            5699 => new BambooHangingSignBlock(Identifier, false, 12, false),
            5700 => new BambooHangingSignBlock(Identifier, false, 13, true),
            5701 => new BambooHangingSignBlock(Identifier, false, 13, false),
            5702 => new BambooHangingSignBlock(Identifier, false, 14, true),
            5703 => new BambooHangingSignBlock(Identifier, false, 14, false),
            5704 => new BambooHangingSignBlock(Identifier, false, 15, true),
            5705 => new BambooHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
