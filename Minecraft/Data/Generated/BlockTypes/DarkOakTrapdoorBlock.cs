using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakTrapdoorBlock(Identifier Identifier, Direction Facing, DarkOakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6524,
                                false => 6525,
                            },
                            false => Waterlogged switch {
                                true => 6526,
                                false => 6527,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6528,
                                false => 6529,
                            },
                            false => Waterlogged switch {
                                true => 6530,
                                false => 6531,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6532,
                                false => 6533,
                            },
                            false => Waterlogged switch {
                                true => 6534,
                                false => 6535,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6536,
                                false => 6537,
                            },
                            false => Waterlogged switch {
                                true => 6538,
                                false => 6539,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6540,
                                false => 6541,
                            },
                            false => Waterlogged switch {
                                true => 6542,
                                false => 6543,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6544,
                                false => 6545,
                            },
                            false => Waterlogged switch {
                                true => 6546,
                                false => 6547,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6548,
                                false => 6549,
                            },
                            false => Waterlogged switch {
                                true => 6550,
                                false => 6551,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6552,
                                false => 6553,
                            },
                            false => Waterlogged switch {
                                true => 6554,
                                false => 6555,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6556,
                                false => 6557,
                            },
                            false => Waterlogged switch {
                                true => 6558,
                                false => 6559,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6560,
                                false => 6561,
                            },
                            false => Waterlogged switch {
                                true => 6562,
                                false => 6563,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6564,
                                false => 6565,
                            },
                            false => Waterlogged switch {
                                true => 6566,
                                false => 6567,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6568,
                                false => 6569,
                            },
                            false => Waterlogged switch {
                                true => 6570,
                                false => 6571,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6572,
                                false => 6573,
                            },
                            false => Waterlogged switch {
                                true => 6574,
                                false => 6575,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6576,
                                false => 6577,
                            },
                            false => Waterlogged switch {
                                true => 6578,
                                false => 6579,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6580,
                                false => 6581,
                            },
                            false => Waterlogged switch {
                                true => 6582,
                                false => 6583,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6584,
                                false => 6585,
                            },
                            false => Waterlogged switch {
                                true => 6586,
                                false => 6587,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6524 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6525 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6526 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6527 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6528 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6529 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6530 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6531 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6532 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6533 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6534 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6535 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6536 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6537 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6538 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6539 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6540 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6541 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6542 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6543 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6544 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6545 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6546 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6547 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6548 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6549 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6550 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6551 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6552 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6553 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6554 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6555 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6556 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6557 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6558 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6559 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6560 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6561 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6562 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6563 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6564 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6565 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6566 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6567 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6568 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6569 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6570 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6571 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6572 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6573 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6574 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6575 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6576 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6577 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6578 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6579 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6580 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6581 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6582 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6583 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6584 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6585 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6586 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6587 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }
}
