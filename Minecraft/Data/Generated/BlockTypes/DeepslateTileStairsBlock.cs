using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateTileStairsBlock(Identifier Identifier, Direction Facing, DeepslateTileStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26790,
                            false => 26791,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26792,
                            false => 26793,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26794,
                            false => 26795,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26796,
                            false => 26797,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26798,
                            false => 26799,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26800,
                            false => 26801,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26802,
                            false => 26803,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26804,
                            false => 26805,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26806,
                            false => 26807,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26808,
                            false => 26809,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26810,
                            false => 26811,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26812,
                            false => 26813,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26814,
                            false => 26815,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26816,
                            false => 26817,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26818,
                            false => 26819,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26820,
                            false => 26821,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26822,
                            false => 26823,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26824,
                            false => 26825,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26826,
                            false => 26827,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26828,
                            false => 26829,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26830,
                            false => 26831,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26832,
                            false => 26833,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26834,
                            false => 26835,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26836,
                            false => 26837,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26838,
                            false => 26839,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26840,
                            false => 26841,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26842,
                            false => 26843,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26844,
                            false => 26845,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26846,
                            false => 26847,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26848,
                            false => 26849,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26850,
                            false => 26851,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26852,
                            false => 26853,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26854,
                            false => 26855,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26856,
                            false => 26857,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26858,
                            false => 26859,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26860,
                            false => 26861,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26862,
                            false => 26863,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26864,
                            false => 26865,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26866,
                            false => 26867,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26868,
                            false => 26869,
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
            26790 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26791 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26792 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26793 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26794 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26795 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26796 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26797 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26798 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26799 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26800 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26801 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26802 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26803 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26804 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26805 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26806 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26807 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26808 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26809 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26810 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26811 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26812 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26813 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26814 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26815 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26816 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26817 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26818 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26819 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26820 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26821 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26822 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26823 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26824 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26825 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26826 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26827 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26828 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26829 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26830 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26831 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26832 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26833 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26834 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26835 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26836 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26837 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26838 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26839 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26840 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26841 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26842 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26843 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26844 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26845 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26846 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26847 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26848 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26849 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26850 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26851 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26852 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26853 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26854 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26855 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26856 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26857 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26858 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26859 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26860 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26861 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26862 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26863 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26864 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26865 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26866 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26867 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26868 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26869 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
