using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedGraniteStairsBlock(Identifier Identifier, Direction Facing, PolishedGraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13985,
                            false => 13986,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13987,
                            false => 13988,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13989,
                            false => 13990,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13991,
                            false => 13992,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13993,
                            false => 13994,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13995,
                            false => 13996,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13997,
                            false => 13998,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13999,
                            false => 14000,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14001,
                            false => 14002,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14003,
                            false => 14004,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14005,
                            false => 14006,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14007,
                            false => 14008,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14009,
                            false => 14010,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14011,
                            false => 14012,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14013,
                            false => 14014,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14015,
                            false => 14016,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14017,
                            false => 14018,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14019,
                            false => 14020,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14021,
                            false => 14022,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14023,
                            false => 14024,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14025,
                            false => 14026,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14027,
                            false => 14028,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14029,
                            false => 14030,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14031,
                            false => 14032,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14033,
                            false => 14034,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14035,
                            false => 14036,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14037,
                            false => 14038,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14039,
                            false => 14040,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14041,
                            false => 14042,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14043,
                            false => 14044,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14045,
                            false => 14046,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14047,
                            false => 14048,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14049,
                            false => 14050,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14051,
                            false => 14052,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14053,
                            false => 14054,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14055,
                            false => 14056,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14057,
                            false => 14058,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14059,
                            false => 14060,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14061,
                            false => 14062,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14063,
                            false => 14064,
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
            13985 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            13986 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            13987 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            13988 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            13989 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            13990 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            13991 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            13992 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            13993 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            13994 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            13995 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            13996 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            13997 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            13998 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            13999 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14000 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14001 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14002 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14003 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14004 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14005 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14006 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14007 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14008 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14009 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14010 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14011 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14012 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14013 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14014 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14015 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14016 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14017 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14018 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14019 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14020 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14021 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14022 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14023 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14024 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14025 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14026 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14027 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14028 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14029 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14030 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14031 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14032 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14033 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14034 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14035 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14036 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14037 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14038 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14039 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14040 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14041 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14042 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14043 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14044 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14045 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14046 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14047 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14048 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14049 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14050 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14051 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14052 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14053 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14054 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14055 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14056 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14057 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14058 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14059 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14060 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14061 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14062 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14063 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14064 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
