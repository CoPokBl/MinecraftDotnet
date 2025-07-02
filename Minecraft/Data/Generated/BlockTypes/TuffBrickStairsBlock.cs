using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record TuffBrickStairsBlock(Identifier Identifier, Direction Facing, TuffBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22939,
                            false => 22940,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22941,
                            false => 22942,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22943,
                            false => 22944,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22945,
                            false => 22946,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22947,
                            false => 22948,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22949,
                            false => 22950,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22951,
                            false => 22952,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22953,
                            false => 22954,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22955,
                            false => 22956,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22957,
                            false => 22958,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22959,
                            false => 22960,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22961,
                            false => 22962,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22963,
                            false => 22964,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22965,
                            false => 22966,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22967,
                            false => 22968,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22969,
                            false => 22970,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22971,
                            false => 22972,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22973,
                            false => 22974,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22975,
                            false => 22976,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22977,
                            false => 22978,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22979,
                            false => 22980,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22981,
                            false => 22982,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22983,
                            false => 22984,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22985,
                            false => 22986,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22987,
                            false => 22988,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22989,
                            false => 22990,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22991,
                            false => 22992,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22993,
                            false => 22994,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22995,
                            false => 22996,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22997,
                            false => 22998,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22999,
                            false => 23000,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23001,
                            false => 23002,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23003,
                            false => 23004,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23005,
                            false => 23006,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23007,
                            false => 23008,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23009,
                            false => 23010,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23011,
                            false => 23012,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23013,
                            false => 23014,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23015,
                            false => 23016,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23017,
                            false => 23018,
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
            22939 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22940 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22941 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22942 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22943 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22944 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22945 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22946 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22947 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22948 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22949 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22950 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22951 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22952 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22953 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22954 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22955 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22956 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22957 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22958 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22959 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22960 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22961 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22962 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22963 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22964 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22965 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22966 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22967 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22968 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22969 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22970 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22971 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22972 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22973 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22974 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22975 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22976 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22977 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22978 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22979 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22980 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22981 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22982 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22983 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22984 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22985 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22986 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22987 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22988 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22989 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22990 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22991 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22992 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22993 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22994 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22995 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22996 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22997 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22998 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22999 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23000 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23001 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23002 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23003 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23004 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23005 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23006 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23007 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23008 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23009 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23010 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23011 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23012 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23013 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23014 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23015 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23016 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23017 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23018 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
