using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedWeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25640,
                                false => 25641,
                            },
                            false => Waterlogged switch {
                                true => 25642,
                                false => 25643,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25644,
                                false => 25645,
                            },
                            false => Waterlogged switch {
                                true => 25646,
                                false => 25647,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25648,
                                false => 25649,
                            },
                            false => Waterlogged switch {
                                true => 25650,
                                false => 25651,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25652,
                                false => 25653,
                            },
                            false => Waterlogged switch {
                                true => 25654,
                                false => 25655,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25656,
                                false => 25657,
                            },
                            false => Waterlogged switch {
                                true => 25658,
                                false => 25659,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25660,
                                false => 25661,
                            },
                            false => Waterlogged switch {
                                true => 25662,
                                false => 25663,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25664,
                                false => 25665,
                            },
                            false => Waterlogged switch {
                                true => 25666,
                                false => 25667,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25668,
                                false => 25669,
                            },
                            false => Waterlogged switch {
                                true => 25670,
                                false => 25671,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25672,
                                false => 25673,
                            },
                            false => Waterlogged switch {
                                true => 25674,
                                false => 25675,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25676,
                                false => 25677,
                            },
                            false => Waterlogged switch {
                                true => 25678,
                                false => 25679,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25680,
                                false => 25681,
                            },
                            false => Waterlogged switch {
                                true => 25682,
                                false => 25683,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25684,
                                false => 25685,
                            },
                            false => Waterlogged switch {
                                true => 25686,
                                false => 25687,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25688,
                                false => 25689,
                            },
                            false => Waterlogged switch {
                                true => 25690,
                                false => 25691,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25692,
                                false => 25693,
                            },
                            false => Waterlogged switch {
                                true => 25694,
                                false => 25695,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25696,
                                false => 25697,
                            },
                            false => Waterlogged switch {
                                true => 25698,
                                false => 25699,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25700,
                                false => 25701,
                            },
                            false => Waterlogged switch {
                                true => 25702,
                                false => 25703,
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
            25640 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25641 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25642 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25643 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25644 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25645 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25646 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25647 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25648 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25649 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25650 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25651 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25652 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25653 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25654 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25655 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25656 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25657 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25658 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25659 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25660 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25661 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25662 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25663 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25664 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25665 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25666 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25667 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25668 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25669 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25670 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25671 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25672 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25673 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25674 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25675 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25676 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25677 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25678 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25679 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25680 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25681 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25682 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25683 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25684 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25685 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25686 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25687 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25688 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25689 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25690 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25691 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25692 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25693 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25694 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25695 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25696 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25697 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25698 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25699 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25700 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25701 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25702 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25703 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
