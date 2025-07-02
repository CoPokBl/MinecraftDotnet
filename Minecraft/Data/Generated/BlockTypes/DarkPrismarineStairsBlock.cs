using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DarkPrismarineStairsBlock(Identifier Identifier, Direction Facing, DarkPrismarineStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11515,
                            false => 11516,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11517,
                            false => 11518,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11519,
                            false => 11520,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11521,
                            false => 11522,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11523,
                            false => 11524,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11525,
                            false => 11526,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11527,
                            false => 11528,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11529,
                            false => 11530,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11531,
                            false => 11532,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11533,
                            false => 11534,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11535,
                            false => 11536,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11537,
                            false => 11538,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11539,
                            false => 11540,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11541,
                            false => 11542,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11543,
                            false => 11544,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11545,
                            false => 11546,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11547,
                            false => 11548,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11549,
                            false => 11550,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11551,
                            false => 11552,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11553,
                            false => 11554,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11555,
                            false => 11556,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11557,
                            false => 11558,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11559,
                            false => 11560,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11561,
                            false => 11562,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11563,
                            false => 11564,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11565,
                            false => 11566,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11567,
                            false => 11568,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11569,
                            false => 11570,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11571,
                            false => 11572,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11573,
                            false => 11574,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11575,
                            false => 11576,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11577,
                            false => 11578,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11579,
                            false => 11580,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11581,
                            false => 11582,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11583,
                            false => 11584,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11585,
                            false => 11586,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11587,
                            false => 11588,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11589,
                            false => 11590,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11591,
                            false => 11592,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11593,
                            false => 11594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11515 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11516 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11517 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11518 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11519 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11520 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11521 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11522 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11523 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11524 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11525 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11526 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11527 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11528 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11529 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11530 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11531 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11532 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11533 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11534 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11535 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11536 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11537 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11538 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11539 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11540 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11541 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11542 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11543 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11544 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11545 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11546 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11547 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11548 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11549 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11550 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11551 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11552 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11553 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11554 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11555 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11556 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11557 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11558 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11559 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11560 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11561 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11562 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11563 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11564 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11565 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11566 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11567 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11568 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11569 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11570 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11571 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11572 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11573 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11574 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11575 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11576 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11577 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11578 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11579 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11580 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11581 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11582 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11583 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11584 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11585 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11586 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11587 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11588 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11589 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11590 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11591 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11592 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11593 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11594 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
