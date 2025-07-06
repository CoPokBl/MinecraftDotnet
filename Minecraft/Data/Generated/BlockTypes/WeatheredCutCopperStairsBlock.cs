using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCutCopperStairsBlock(Identifier Identifier, Direction Facing, WeatheredCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24064,
                            false => 24065,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24066,
                            false => 24067,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24068,
                            false => 24069,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24070,
                            false => 24071,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24072,
                            false => 24073,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24074,
                            false => 24075,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24076,
                            false => 24077,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24078,
                            false => 24079,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24080,
                            false => 24081,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24082,
                            false => 24083,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24084,
                            false => 24085,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24086,
                            false => 24087,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24088,
                            false => 24089,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24090,
                            false => 24091,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24092,
                            false => 24093,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24094,
                            false => 24095,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24096,
                            false => 24097,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24098,
                            false => 24099,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24100,
                            false => 24101,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24102,
                            false => 24103,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24104,
                            false => 24105,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24106,
                            false => 24107,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24108,
                            false => 24109,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24110,
                            false => 24111,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24112,
                            false => 24113,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24114,
                            false => 24115,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24116,
                            false => 24117,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24118,
                            false => 24119,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24120,
                            false => 24121,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24122,
                            false => 24123,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24124,
                            false => 24125,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24126,
                            false => 24127,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24128,
                            false => 24129,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24130,
                            false => 24131,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24132,
                            false => 24133,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24134,
                            false => 24135,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24136,
                            false => 24137,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24138,
                            false => 24139,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24140,
                            false => 24141,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24142,
                            false => 24143,
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
            24064 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24065 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24066 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24067 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24068 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24069 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24070 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24071 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24072 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24073 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24074 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24075 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24076 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24077 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24078 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24079 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24080 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24081 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24082 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24083 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24084 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24085 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24086 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24087 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24088 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24089 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24090 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24091 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24092 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24093 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24094 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24095 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24096 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24097 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24098 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24099 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24100 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24101 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24102 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24103 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24104 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24105 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24106 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24107 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24108 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24109 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24110 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24111 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24112 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24113 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24114 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24115 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24116 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24117 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24118 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24119 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24120 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24121 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24122 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24123 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24124 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24125 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24126 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24127 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24128 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24129 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24130 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24131 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24132 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24133 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24134 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24135 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24136 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24137 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24138 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24139 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24140 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24141 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24142 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24143 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
