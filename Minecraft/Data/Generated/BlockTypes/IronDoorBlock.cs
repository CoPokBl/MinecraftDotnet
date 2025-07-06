using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5828,
                                false => 5829,
                            },
                            false => Powered switch {
                                true => 5830,
                                false => 5831,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5832,
                                false => 5833,
                            },
                            false => Powered switch {
                                true => 5834,
                                false => 5835,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5836,
                                false => 5837,
                            },
                            false => Powered switch {
                                true => 5838,
                                false => 5839,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5840,
                                false => 5841,
                            },
                            false => Powered switch {
                                true => 5842,
                                false => 5843,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5844,
                                false => 5845,
                            },
                            false => Powered switch {
                                true => 5846,
                                false => 5847,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5848,
                                false => 5849,
                            },
                            false => Powered switch {
                                true => 5850,
                                false => 5851,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5852,
                                false => 5853,
                            },
                            false => Powered switch {
                                true => 5854,
                                false => 5855,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5856,
                                false => 5857,
                            },
                            false => Powered switch {
                                true => 5858,
                                false => 5859,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5860,
                                false => 5861,
                            },
                            false => Powered switch {
                                true => 5862,
                                false => 5863,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5864,
                                false => 5865,
                            },
                            false => Powered switch {
                                true => 5866,
                                false => 5867,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5868,
                                false => 5869,
                            },
                            false => Powered switch {
                                true => 5870,
                                false => 5871,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5872,
                                false => 5873,
                            },
                            false => Powered switch {
                                true => 5874,
                                false => 5875,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5876,
                                false => 5877,
                            },
                            false => Powered switch {
                                true => 5878,
                                false => 5879,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5880,
                                false => 5881,
                            },
                            false => Powered switch {
                                true => 5882,
                                false => 5883,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5884,
                                false => 5885,
                            },
                            false => Powered switch {
                                true => 5886,
                                false => 5887,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5888,
                                false => 5889,
                            },
                            false => Powered switch {
                                true => 5890,
                                false => 5891,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5828 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            5829 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            5830 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            5831 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            5832 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            5833 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            5834 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            5835 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            5836 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            5837 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            5838 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            5839 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            5840 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            5841 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            5842 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            5843 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            5844 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            5845 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            5846 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            5847 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            5848 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            5849 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            5850 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            5851 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            5852 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            5853 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            5854 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            5855 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            5856 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            5857 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            5858 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            5859 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            5860 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            5861 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            5862 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            5863 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            5864 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            5865 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            5866 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            5867 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            5868 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            5869 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            5870 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            5871 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            5872 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            5873 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            5874 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            5875 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            5876 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            5877 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            5878 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            5879 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            5880 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            5881 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            5882 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            5883 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            5884 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            5885 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            5886 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            5887 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            5888 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            5889 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            5890 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            5891 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
            Hinge = LeftRightExtensions.FromString(properties["hinge"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
