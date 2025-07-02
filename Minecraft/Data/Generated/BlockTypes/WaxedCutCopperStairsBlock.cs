using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WaxedCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24576,
                            false => 24577,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24578,
                            false => 24579,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24580,
                            false => 24581,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24582,
                            false => 24583,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24584,
                            false => 24585,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24586,
                            false => 24587,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24588,
                            false => 24589,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24590,
                            false => 24591,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24592,
                            false => 24593,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24594,
                            false => 24595,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24596,
                            false => 24597,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24598,
                            false => 24599,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24600,
                            false => 24601,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24602,
                            false => 24603,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24604,
                            false => 24605,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24606,
                            false => 24607,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24608,
                            false => 24609,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24610,
                            false => 24611,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24612,
                            false => 24613,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24614,
                            false => 24615,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24616,
                            false => 24617,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24618,
                            false => 24619,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24620,
                            false => 24621,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24622,
                            false => 24623,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24624,
                            false => 24625,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24626,
                            false => 24627,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24628,
                            false => 24629,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24630,
                            false => 24631,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24632,
                            false => 24633,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24634,
                            false => 24635,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24636,
                            false => 24637,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24638,
                            false => 24639,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24640,
                            false => 24641,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24642,
                            false => 24643,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24644,
                            false => 24645,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24646,
                            false => 24647,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24648,
                            false => 24649,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24650,
                            false => 24651,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24652,
                            false => 24653,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24654,
                            false => 24655,
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
            24576 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24577 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24578 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24579 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24580 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24581 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24582 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24583 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24584 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24585 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24586 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24587 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24588 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24589 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24590 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24591 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24592 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24593 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24594 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24595 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24596 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24597 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24598 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24599 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24600 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24601 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24602 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24603 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24604 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24605 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24606 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24607 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24608 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24609 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24610 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24611 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24612 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24613 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24614 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24615 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24616 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24617 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24618 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24619 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24620 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24621 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24622 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24623 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24624 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24625 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24626 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24627 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24628 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24629 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24630 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24631 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24632 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24633 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24634 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24635 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24636 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24637 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24638 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24639 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24640 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24641 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24642 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24643 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24644 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24645 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24646 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24647 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24648 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24649 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24650 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24651 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24652 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24653 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24654 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24655 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
