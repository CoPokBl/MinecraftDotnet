using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MangroveTrapdoorBlock(Identifier Identifier, Direction Facing, MangroveTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6652,
                                false => 6653,
                            },
                            false => Waterlogged switch {
                                true => 6654,
                                false => 6655,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6656,
                                false => 6657,
                            },
                            false => Waterlogged switch {
                                true => 6658,
                                false => 6659,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6660,
                                false => 6661,
                            },
                            false => Waterlogged switch {
                                true => 6662,
                                false => 6663,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6664,
                                false => 6665,
                            },
                            false => Waterlogged switch {
                                true => 6666,
                                false => 6667,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6668,
                                false => 6669,
                            },
                            false => Waterlogged switch {
                                true => 6670,
                                false => 6671,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6672,
                                false => 6673,
                            },
                            false => Waterlogged switch {
                                true => 6674,
                                false => 6675,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6676,
                                false => 6677,
                            },
                            false => Waterlogged switch {
                                true => 6678,
                                false => 6679,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6680,
                                false => 6681,
                            },
                            false => Waterlogged switch {
                                true => 6682,
                                false => 6683,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6684,
                                false => 6685,
                            },
                            false => Waterlogged switch {
                                true => 6686,
                                false => 6687,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6688,
                                false => 6689,
                            },
                            false => Waterlogged switch {
                                true => 6690,
                                false => 6691,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6692,
                                false => 6693,
                            },
                            false => Waterlogged switch {
                                true => 6694,
                                false => 6695,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6696,
                                false => 6697,
                            },
                            false => Waterlogged switch {
                                true => 6698,
                                false => 6699,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6700,
                                false => 6701,
                            },
                            false => Waterlogged switch {
                                true => 6702,
                                false => 6703,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6704,
                                false => 6705,
                            },
                            false => Waterlogged switch {
                                true => 6706,
                                false => 6707,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6708,
                                false => 6709,
                            },
                            false => Waterlogged switch {
                                true => 6710,
                                false => 6711,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6712,
                                false => 6713,
                            },
                            false => Waterlogged switch {
                                true => 6714,
                                false => 6715,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            6652 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6653 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6654 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6655 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6656 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6657 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6658 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6659 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6660 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6661 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6662 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6663 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6664 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6665 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6666 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6667 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6668 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6669 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6670 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6671 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6672 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6673 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6674 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6675 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6676 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6677 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6678 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6679 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6680 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6681 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6682 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6683 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6684 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6685 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6686 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6687 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6688 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6689 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6690 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6691 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6692 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6693 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6694 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6695 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6696 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6697 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6698 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6699 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6700 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6701 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6702 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6703 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6704 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6705 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6706 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6707 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6708 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6709 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6710 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6711 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6712 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6713 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6714 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6715 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
