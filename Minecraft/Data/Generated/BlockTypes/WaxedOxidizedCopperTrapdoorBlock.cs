using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedOxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25576,
                                false => 25577,
                            },
                            false => Waterlogged switch {
                                true => 25578,
                                false => 25579,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25580,
                                false => 25581,
                            },
                            false => Waterlogged switch {
                                true => 25582,
                                false => 25583,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25584,
                                false => 25585,
                            },
                            false => Waterlogged switch {
                                true => 25586,
                                false => 25587,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25588,
                                false => 25589,
                            },
                            false => Waterlogged switch {
                                true => 25590,
                                false => 25591,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25592,
                                false => 25593,
                            },
                            false => Waterlogged switch {
                                true => 25594,
                                false => 25595,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25596,
                                false => 25597,
                            },
                            false => Waterlogged switch {
                                true => 25598,
                                false => 25599,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25600,
                                false => 25601,
                            },
                            false => Waterlogged switch {
                                true => 25602,
                                false => 25603,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25604,
                                false => 25605,
                            },
                            false => Waterlogged switch {
                                true => 25606,
                                false => 25607,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25608,
                                false => 25609,
                            },
                            false => Waterlogged switch {
                                true => 25610,
                                false => 25611,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25612,
                                false => 25613,
                            },
                            false => Waterlogged switch {
                                true => 25614,
                                false => 25615,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25616,
                                false => 25617,
                            },
                            false => Waterlogged switch {
                                true => 25618,
                                false => 25619,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25620,
                                false => 25621,
                            },
                            false => Waterlogged switch {
                                true => 25622,
                                false => 25623,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25624,
                                false => 25625,
                            },
                            false => Waterlogged switch {
                                true => 25626,
                                false => 25627,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25628,
                                false => 25629,
                            },
                            false => Waterlogged switch {
                                true => 25630,
                                false => 25631,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25632,
                                false => 25633,
                            },
                            false => Waterlogged switch {
                                true => 25634,
                                false => 25635,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25636,
                                false => 25637,
                            },
                            false => Waterlogged switch {
                                true => 25638,
                                false => 25639,
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
            25576 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25577 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25578 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25579 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25580 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25581 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25582 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25583 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25584 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25585 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25586 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25587 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25588 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25589 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25590 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25591 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25592 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25593 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25594 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25595 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25596 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25597 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25598 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25599 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25600 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25601 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25602 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25603 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25604 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25605 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25606 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25607 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25608 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25609 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25610 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25611 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25612 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25613 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25614 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25615 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25616 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25617 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25618 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25619 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25620 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25621 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25622 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25623 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25624 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25625 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25626 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25627 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25628 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25629 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25630 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25631 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25632 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25633 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25634 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25635 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25636 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25637 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25638 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25639 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
