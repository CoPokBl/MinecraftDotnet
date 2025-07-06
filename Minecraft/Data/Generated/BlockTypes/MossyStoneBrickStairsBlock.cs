using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MossyStoneBrickStairsBlock(Identifier Identifier, Direction Facing, MossyStoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14145,
                            false => 14146,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14147,
                            false => 14148,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14149,
                            false => 14150,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14151,
                            false => 14152,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14153,
                            false => 14154,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14155,
                            false => 14156,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14157,
                            false => 14158,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14159,
                            false => 14160,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14161,
                            false => 14162,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14163,
                            false => 14164,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14165,
                            false => 14166,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14167,
                            false => 14168,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14169,
                            false => 14170,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14171,
                            false => 14172,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14173,
                            false => 14174,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14175,
                            false => 14176,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14177,
                            false => 14178,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14179,
                            false => 14180,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14181,
                            false => 14182,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14183,
                            false => 14184,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14185,
                            false => 14186,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14187,
                            false => 14188,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14189,
                            false => 14190,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14191,
                            false => 14192,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14193,
                            false => 14194,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14195,
                            false => 14196,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14197,
                            false => 14198,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14199,
                            false => 14200,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14201,
                            false => 14202,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14203,
                            false => 14204,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14205,
                            false => 14206,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14207,
                            false => 14208,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14209,
                            false => 14210,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14211,
                            false => 14212,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14213,
                            false => 14214,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14215,
                            false => 14216,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14217,
                            false => 14218,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14219,
                            false => 14220,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14221,
                            false => 14222,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14223,
                            false => 14224,
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
            14145 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14146 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14147 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14148 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14149 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14150 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14151 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14152 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14153 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14154 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14155 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14156 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14157 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14158 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14159 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14160 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14161 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14162 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14163 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14164 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14165 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14166 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14167 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14168 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14169 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14170 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14171 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14172 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14173 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14174 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14175 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14176 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14177 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14178 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14179 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14180 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14181 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14182 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14183 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14184 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14185 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14186 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14187 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14188 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14189 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14190 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14191 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14192 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14193 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14194 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14195 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14196 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14197 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14198 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14199 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14200 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14201 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14202 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14203 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14204 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14205 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14206 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14207 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14208 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14209 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14210 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14211 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14212 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14213 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14214 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14215 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14216 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14217 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14218 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14219 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14220 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14221 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14222 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14223 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14224 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
