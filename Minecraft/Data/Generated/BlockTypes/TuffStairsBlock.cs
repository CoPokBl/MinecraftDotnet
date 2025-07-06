using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffStairsBlock(Identifier Identifier, Direction Facing, TuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22116,
                            false => 22117,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22118,
                            false => 22119,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22120,
                            false => 22121,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22122,
                            false => 22123,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22124,
                            false => 22125,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22126,
                            false => 22127,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22128,
                            false => 22129,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22130,
                            false => 22131,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22132,
                            false => 22133,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22134,
                            false => 22135,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22136,
                            false => 22137,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22138,
                            false => 22139,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22140,
                            false => 22141,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22142,
                            false => 22143,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22144,
                            false => 22145,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22146,
                            false => 22147,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22148,
                            false => 22149,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22150,
                            false => 22151,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22152,
                            false => 22153,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22154,
                            false => 22155,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22156,
                            false => 22157,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22158,
                            false => 22159,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22160,
                            false => 22161,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22162,
                            false => 22163,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22164,
                            false => 22165,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22166,
                            false => 22167,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22168,
                            false => 22169,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22170,
                            false => 22171,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22172,
                            false => 22173,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22174,
                            false => 22175,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22176,
                            false => 22177,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22178,
                            false => 22179,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22180,
                            false => 22181,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22182,
                            false => 22183,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22184,
                            false => 22185,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22186,
                            false => 22187,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22188,
                            false => 22189,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22190,
                            false => 22191,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22192,
                            false => 22193,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22194,
                            false => 22195,
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
            22116 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22117 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22118 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22119 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22120 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22121 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22122 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22123 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22124 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22125 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22126 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22127 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22128 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22129 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22130 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22131 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22132 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22133 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22134 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22135 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22136 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22137 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22138 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22139 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22140 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22141 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22142 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22143 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22144 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22145 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22146 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22147 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22148 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22149 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22150 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22151 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22152 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22153 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22154 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22155 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22156 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22157 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22158 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22159 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22160 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22161 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22162 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22163 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22164 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22165 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22166 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22167 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22168 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22169 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22170 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22171 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22172 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22173 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22174 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22175 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22176 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22177 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22178 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22179 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22180 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22181 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22182 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22183 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22184 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22185 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22186 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22187 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22188 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22189 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22190 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22191 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22192 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22193 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22194 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22195 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
