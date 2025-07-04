using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedTuffStairsBlock(Identifier Identifier, Direction Facing, PolishedTuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22527,
                            false => 22528,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22529,
                            false => 22530,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22531,
                            false => 22532,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22533,
                            false => 22534,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22535,
                            false => 22536,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22537,
                            false => 22538,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22539,
                            false => 22540,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22541,
                            false => 22542,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22543,
                            false => 22544,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22545,
                            false => 22546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22547,
                            false => 22548,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22549,
                            false => 22550,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22551,
                            false => 22552,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22553,
                            false => 22554,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22555,
                            false => 22556,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22557,
                            false => 22558,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22559,
                            false => 22560,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22561,
                            false => 22562,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22563,
                            false => 22564,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22565,
                            false => 22566,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22567,
                            false => 22568,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22569,
                            false => 22570,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22571,
                            false => 22572,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22573,
                            false => 22574,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22575,
                            false => 22576,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22577,
                            false => 22578,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22579,
                            false => 22580,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22581,
                            false => 22582,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22583,
                            false => 22584,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22585,
                            false => 22586,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22587,
                            false => 22588,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22589,
                            false => 22590,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22591,
                            false => 22592,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22593,
                            false => 22594,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22595,
                            false => 22596,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22597,
                            false => 22598,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22599,
                            false => 22600,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22601,
                            false => 22602,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22603,
                            false => 22604,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22605,
                            false => 22606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22527 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22528 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22529 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22530 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22531 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22532 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22533 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22534 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22535 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22536 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22537 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22538 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22539 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22540 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22541 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22542 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22543 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22544 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22545 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22546 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22547 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22548 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22549 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22550 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22551 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22552 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22553 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22554 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22555 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22556 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22557 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22558 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22559 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22560 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22561 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22562 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22563 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22564 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22565 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22566 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22567 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22568 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22569 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22570 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22571 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22572 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22573 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22574 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22575 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22576 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22577 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22578 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22579 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22580 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22581 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22582 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22583 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22584 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22585 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22586 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22587 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22588 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22589 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22590 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22591 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22592 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22593 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22594 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22595 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22596 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22597 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22598 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22599 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22600 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22601 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22602 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22603 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22604 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22605 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22606 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
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
