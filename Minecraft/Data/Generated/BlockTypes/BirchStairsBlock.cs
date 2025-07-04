using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchStairsBlock(Identifier Identifier, Direction Facing, BirchStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8530,
                            false => 8531,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8532,
                            false => 8533,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8534,
                            false => 8535,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8536,
                            false => 8537,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8538,
                            false => 8539,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8540,
                            false => 8541,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8542,
                            false => 8543,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8544,
                            false => 8545,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8546,
                            false => 8547,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8548,
                            false => 8549,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8550,
                            false => 8551,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8552,
                            false => 8553,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8554,
                            false => 8555,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8556,
                            false => 8557,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8558,
                            false => 8559,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8560,
                            false => 8561,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8562,
                            false => 8563,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8564,
                            false => 8565,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8566,
                            false => 8567,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8568,
                            false => 8569,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8570,
                            false => 8571,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8572,
                            false => 8573,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8574,
                            false => 8575,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8576,
                            false => 8577,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8578,
                            false => 8579,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8580,
                            false => 8581,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8582,
                            false => 8583,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8584,
                            false => 8585,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8586,
                            false => 8587,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8588,
                            false => 8589,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8590,
                            false => 8591,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8592,
                            false => 8593,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8594,
                            false => 8595,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8596,
                            false => 8597,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8598,
                            false => 8599,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8600,
                            false => 8601,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8602,
                            false => 8603,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8604,
                            false => 8605,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8606,
                            false => 8607,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8608,
                            false => 8609,
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
            8530 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8531 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8532 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8533 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8534 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8535 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8536 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8537 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8538 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8539 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8540 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8541 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8542 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8543 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8544 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8545 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8546 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8547 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8548 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8549 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8550 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8551 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8552 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8553 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8554 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8555 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8556 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8557 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8558 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8559 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8560 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8561 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8562 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8563 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8564 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8565 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8566 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8567 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8568 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8569 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8570 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8571 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8572 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8573 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8574 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8575 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8576 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8577 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8578 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8579 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8580 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8581 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8582 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8583 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8584 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8585 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8586 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8587 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8588 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8589 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8590 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8591 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8592 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8593 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8594 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8595 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8596 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8597 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8598 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8599 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8600 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8601 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8602 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8603 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8604 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8605 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8606 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8607 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8608 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8609 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
