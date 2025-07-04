using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobblestoneStairsBlock(Identifier Identifier, Direction Facing, CobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4778,
                            false => 4779,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4780,
                            false => 4781,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4782,
                            false => 4783,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4784,
                            false => 4785,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4786,
                            false => 4787,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4788,
                            false => 4789,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4790,
                            false => 4791,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4792,
                            false => 4793,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4794,
                            false => 4795,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4796,
                            false => 4797,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4798,
                            false => 4799,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4800,
                            false => 4801,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4802,
                            false => 4803,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4804,
                            false => 4805,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4806,
                            false => 4807,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4808,
                            false => 4809,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4810,
                            false => 4811,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4812,
                            false => 4813,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4814,
                            false => 4815,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4816,
                            false => 4817,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4818,
                            false => 4819,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4820,
                            false => 4821,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4822,
                            false => 4823,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4824,
                            false => 4825,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4826,
                            false => 4827,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4828,
                            false => 4829,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4830,
                            false => 4831,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4832,
                            false => 4833,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4834,
                            false => 4835,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4836,
                            false => 4837,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4838,
                            false => 4839,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4840,
                            false => 4841,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4842,
                            false => 4843,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4844,
                            false => 4845,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4846,
                            false => 4847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 4848,
                            false => 4849,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 4850,
                            false => 4851,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 4852,
                            false => 4853,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 4854,
                            false => 4855,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 4856,
                            false => 4857,
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
            4778 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            4779 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            4780 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            4781 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            4782 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            4783 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            4784 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            4785 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            4786 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            4787 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            4788 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            4789 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            4790 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            4791 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            4792 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            4793 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            4794 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            4795 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            4796 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            4797 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            4798 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            4799 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            4800 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            4801 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            4802 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            4803 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            4804 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            4805 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            4806 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            4807 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            4808 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            4809 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            4810 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            4811 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            4812 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            4813 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            4814 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            4815 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            4816 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            4817 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            4818 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            4819 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            4820 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            4821 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            4822 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            4823 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            4824 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            4825 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            4826 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            4827 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            4828 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            4829 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            4830 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            4831 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            4832 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            4833 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            4834 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            4835 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            4836 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            4837 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            4838 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            4839 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            4840 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            4841 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            4842 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            4843 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            4844 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            4845 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            4846 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            4847 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            4848 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            4849 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            4850 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            4851 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            4852 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            4853 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            4854 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            4855 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            4856 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            4857 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
