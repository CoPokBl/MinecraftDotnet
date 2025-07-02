using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlackstoneStairsBlock(Identifier Identifier, Direction Facing, BlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20489,
                            false => 20490,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20491,
                            false => 20492,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20493,
                            false => 20494,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20495,
                            false => 20496,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20497,
                            false => 20498,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20499,
                            false => 20500,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20501,
                            false => 20502,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20503,
                            false => 20504,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20505,
                            false => 20506,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20507,
                            false => 20508,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20509,
                            false => 20510,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20511,
                            false => 20512,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20513,
                            false => 20514,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20515,
                            false => 20516,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20517,
                            false => 20518,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20519,
                            false => 20520,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20521,
                            false => 20522,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20523,
                            false => 20524,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20525,
                            false => 20526,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20527,
                            false => 20528,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20529,
                            false => 20530,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20531,
                            false => 20532,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20533,
                            false => 20534,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20535,
                            false => 20536,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20537,
                            false => 20538,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20539,
                            false => 20540,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20541,
                            false => 20542,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20543,
                            false => 20544,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20545,
                            false => 20546,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20547,
                            false => 20548,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20549,
                            false => 20550,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20551,
                            false => 20552,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20553,
                            false => 20554,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20555,
                            false => 20556,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20557,
                            false => 20558,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20559,
                            false => 20560,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20561,
                            false => 20562,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20563,
                            false => 20564,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20565,
                            false => 20566,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20567,
                            false => 20568,
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
            20489 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            20490 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            20491 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            20492 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            20493 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20494 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20495 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20496 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20497 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20498 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20499 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20500 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20501 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20502 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20503 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20504 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20505 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20506 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20507 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20508 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20509 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20510 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20511 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20512 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20513 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20514 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20515 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20516 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20517 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20518 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20519 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20520 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20521 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20522 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20523 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20524 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20525 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20526 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20527 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20528 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20529 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20530 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20531 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20532 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20533 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20534 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20535 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20536 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20537 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20538 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20539 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20540 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20541 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20542 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20543 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20544 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20545 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20546 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20547 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20548 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20549 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20550 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20551 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20552 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20553 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20554 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20555 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20556 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20557 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20558 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20559 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20560 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20561 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20562 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20563 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20564 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20565 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20566 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20567 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20568 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
