using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14545,
                            false => 14546,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14547,
                            false => 14548,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14549,
                            false => 14550,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14551,
                            false => 14552,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14553,
                            false => 14554,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14555,
                            false => 14556,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14557,
                            false => 14558,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14559,
                            false => 14560,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14561,
                            false => 14562,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14563,
                            false => 14564,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14565,
                            false => 14566,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14567,
                            false => 14568,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14569,
                            false => 14570,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14571,
                            false => 14572,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14573,
                            false => 14574,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14575,
                            false => 14576,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14577,
                            false => 14578,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14579,
                            false => 14580,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14581,
                            false => 14582,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14583,
                            false => 14584,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14585,
                            false => 14586,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14587,
                            false => 14588,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14589,
                            false => 14590,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14591,
                            false => 14592,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14593,
                            false => 14594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14595,
                            false => 14596,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14597,
                            false => 14598,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14599,
                            false => 14600,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14601,
                            false => 14602,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14603,
                            false => 14604,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14605,
                            false => 14606,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14607,
                            false => 14608,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14609,
                            false => 14610,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14611,
                            false => 14612,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14613,
                            false => 14614,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14615,
                            false => 14616,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14617,
                            false => 14618,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14619,
                            false => 14620,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14621,
                            false => 14622,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14623,
                            false => 14624,
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
            14545 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14546 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14547 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14548 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14549 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14550 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14551 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14552 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14553 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14554 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14555 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14556 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14557 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14558 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14559 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14560 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14561 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14562 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14563 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14564 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14565 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14566 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14567 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14568 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14569 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14570 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14571 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14572 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14573 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14574 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14575 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14576 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14577 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14578 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14579 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14580 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14581 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14582 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14583 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14584 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14585 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14586 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14587 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14588 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14589 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14590 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14591 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14592 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14593 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14594 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14595 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14596 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14597 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14598 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14599 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14600 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14601 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14602 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14603 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14604 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14605 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14606 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14607 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14608 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14609 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14610 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14611 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14612 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14613 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14614 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14615 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14616 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14617 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14618 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14619 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14620 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14621 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14622 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14623 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14624 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
