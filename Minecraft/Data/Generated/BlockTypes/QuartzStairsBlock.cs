using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record QuartzStairsBlock(Identifier Identifier, Direction Facing, QuartzStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10049,
                            false => 10050,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10051,
                            false => 10052,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10053,
                            false => 10054,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10055,
                            false => 10056,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10057,
                            false => 10058,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10059,
                            false => 10060,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10061,
                            false => 10062,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10063,
                            false => 10064,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10065,
                            false => 10066,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10067,
                            false => 10068,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10069,
                            false => 10070,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10071,
                            false => 10072,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10073,
                            false => 10074,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10075,
                            false => 10076,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10077,
                            false => 10078,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10079,
                            false => 10080,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10081,
                            false => 10082,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10083,
                            false => 10084,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10085,
                            false => 10086,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10087,
                            false => 10088,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10089,
                            false => 10090,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10091,
                            false => 10092,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10093,
                            false => 10094,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10095,
                            false => 10096,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10097,
                            false => 10098,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10099,
                            false => 10100,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10101,
                            false => 10102,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10103,
                            false => 10104,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10105,
                            false => 10106,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10107,
                            false => 10108,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10109,
                            false => 10110,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10111,
                            false => 10112,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10113,
                            false => 10114,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10115,
                            false => 10116,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10117,
                            false => 10118,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10119,
                            false => 10120,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10121,
                            false => 10122,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10123,
                            false => 10124,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10125,
                            false => 10126,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10127,
                            false => 10128,
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
            10049 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            10050 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            10051 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            10052 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            10053 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            10054 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            10055 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            10056 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            10057 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            10058 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            10059 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            10060 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            10061 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            10062 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            10063 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            10064 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            10065 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            10066 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            10067 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            10068 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            10069 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            10070 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            10071 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            10072 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            10073 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            10074 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            10075 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            10076 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            10077 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            10078 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            10079 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            10080 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            10081 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            10082 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            10083 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            10084 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            10085 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            10086 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            10087 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            10088 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            10089 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            10090 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            10091 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            10092 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            10093 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            10094 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            10095 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            10096 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            10097 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            10098 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            10099 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            10100 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            10101 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            10102 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            10103 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            10104 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            10105 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            10106 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            10107 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            10108 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            10109 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            10110 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            10111 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            10112 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            10113 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            10114 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            10115 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            10116 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            10117 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            10118 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            10119 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            10120 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            10121 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            10122 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            10123 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            10124 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            10125 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            10126 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            10127 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            10128 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
