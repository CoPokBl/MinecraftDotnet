using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DioriteStairsBlock(Identifier Identifier, Direction Facing, DioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15025,
                            false => 15026,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15027,
                            false => 15028,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15029,
                            false => 15030,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15031,
                            false => 15032,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15033,
                            false => 15034,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15035,
                            false => 15036,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15037,
                            false => 15038,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15039,
                            false => 15040,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15041,
                            false => 15042,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15043,
                            false => 15044,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15045,
                            false => 15046,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15047,
                            false => 15048,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15049,
                            false => 15050,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15051,
                            false => 15052,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15053,
                            false => 15054,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15055,
                            false => 15056,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15057,
                            false => 15058,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15059,
                            false => 15060,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15061,
                            false => 15062,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15063,
                            false => 15064,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15065,
                            false => 15066,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15067,
                            false => 15068,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15069,
                            false => 15070,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15071,
                            false => 15072,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15073,
                            false => 15074,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15075,
                            false => 15076,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15077,
                            false => 15078,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15079,
                            false => 15080,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15081,
                            false => 15082,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15083,
                            false => 15084,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15085,
                            false => 15086,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15087,
                            false => 15088,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15089,
                            false => 15090,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15091,
                            false => 15092,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15093,
                            false => 15094,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15095,
                            false => 15096,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15097,
                            false => 15098,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15099,
                            false => 15100,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15101,
                            false => 15102,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15103,
                            false => 15104,
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
            15025 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15026 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15027 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15028 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15029 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15030 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15031 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15032 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15033 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15034 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15035 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15036 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15037 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15038 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15039 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15040 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15041 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15042 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15043 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15044 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15045 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15046 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15047 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15048 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15049 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15050 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15051 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15052 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15053 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15054 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15055 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15056 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15057 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15058 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15059 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15060 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15061 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15062 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15063 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15064 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15065 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15066 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15067 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15068 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15069 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15070 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15071 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15072 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15073 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15074 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15075 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15076 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15077 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15078 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15079 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15080 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15081 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15082 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15083 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15084 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15085 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15086 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15087 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15088 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15089 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15090 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15091 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15092 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15093 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15094 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15095 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15096 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15097 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15098 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15099 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15100 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15101 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15102 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15103 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15104 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
