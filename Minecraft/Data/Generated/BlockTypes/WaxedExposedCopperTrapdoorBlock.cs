using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WaxedExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25512,
                                false => 25513,
                            },
                            false => Waterlogged switch {
                                true => 25514,
                                false => 25515,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25516,
                                false => 25517,
                            },
                            false => Waterlogged switch {
                                true => 25518,
                                false => 25519,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25520,
                                false => 25521,
                            },
                            false => Waterlogged switch {
                                true => 25522,
                                false => 25523,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25524,
                                false => 25525,
                            },
                            false => Waterlogged switch {
                                true => 25526,
                                false => 25527,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25528,
                                false => 25529,
                            },
                            false => Waterlogged switch {
                                true => 25530,
                                false => 25531,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25532,
                                false => 25533,
                            },
                            false => Waterlogged switch {
                                true => 25534,
                                false => 25535,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25536,
                                false => 25537,
                            },
                            false => Waterlogged switch {
                                true => 25538,
                                false => 25539,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25540,
                                false => 25541,
                            },
                            false => Waterlogged switch {
                                true => 25542,
                                false => 25543,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25544,
                                false => 25545,
                            },
                            false => Waterlogged switch {
                                true => 25546,
                                false => 25547,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25548,
                                false => 25549,
                            },
                            false => Waterlogged switch {
                                true => 25550,
                                false => 25551,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25552,
                                false => 25553,
                            },
                            false => Waterlogged switch {
                                true => 25554,
                                false => 25555,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25556,
                                false => 25557,
                            },
                            false => Waterlogged switch {
                                true => 25558,
                                false => 25559,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25560,
                                false => 25561,
                            },
                            false => Waterlogged switch {
                                true => 25562,
                                false => 25563,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25564,
                                false => 25565,
                            },
                            false => Waterlogged switch {
                                true => 25566,
                                false => 25567,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25568,
                                false => 25569,
                            },
                            false => Waterlogged switch {
                                true => 25570,
                                false => 25571,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25572,
                                false => 25573,
                            },
                            false => Waterlogged switch {
                                true => 25574,
                                false => 25575,
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
            25512 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25513 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25514 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25515 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25516 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25517 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25518 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25519 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25520 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25521 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25522 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25523 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25524 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25525 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25526 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25527 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25528 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25529 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25530 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25531 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25532 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25533 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25534 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25535 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25536 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25537 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25538 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25539 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25540 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25541 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25542 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25543 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25544 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25545 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25546 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25547 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25548 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25549 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25550 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25551 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25552 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25553 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25554 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25555 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25556 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25557 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25558 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25559 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25560 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25561 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25562 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25563 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25564 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25565 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25566 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25567 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25568 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25569 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25570 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25571 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25572 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25573 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25574 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25575 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
