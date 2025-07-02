using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SmoothRedSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothRedSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14065,
                            false => 14066,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14067,
                            false => 14068,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14069,
                            false => 14070,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14071,
                            false => 14072,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14073,
                            false => 14074,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14075,
                            false => 14076,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14077,
                            false => 14078,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14079,
                            false => 14080,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14081,
                            false => 14082,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14083,
                            false => 14084,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14085,
                            false => 14086,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14087,
                            false => 14088,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14089,
                            false => 14090,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14091,
                            false => 14092,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14093,
                            false => 14094,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14095,
                            false => 14096,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14097,
                            false => 14098,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14099,
                            false => 14100,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14101,
                            false => 14102,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14103,
                            false => 14104,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14105,
                            false => 14106,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14107,
                            false => 14108,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14109,
                            false => 14110,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14111,
                            false => 14112,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14113,
                            false => 14114,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14115,
                            false => 14116,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14117,
                            false => 14118,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14119,
                            false => 14120,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14121,
                            false => 14122,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14123,
                            false => 14124,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14125,
                            false => 14126,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14127,
                            false => 14128,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14129,
                            false => 14130,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14131,
                            false => 14132,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14133,
                            false => 14134,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14135,
                            false => 14136,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14137,
                            false => 14138,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14139,
                            false => 14140,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14141,
                            false => 14142,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14143,
                            false => 14144,
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
            14065 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14066 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14067 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14068 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14069 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14070 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14071 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14072 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14073 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14074 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14075 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14076 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14077 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14078 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14079 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14080 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14081 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14082 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14083 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14084 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14085 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14086 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14087 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14088 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14089 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14090 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14091 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14092 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14093 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14094 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14095 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14096 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14097 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14098 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14099 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14100 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14101 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14102 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14103 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14104 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14105 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14106 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14107 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14108 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14109 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14110 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14111 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14112 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14113 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14114 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14115 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14116 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14117 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14118 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14119 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14120 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14121 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14122 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14123 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14124 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14125 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14126 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14127 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14128 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14129 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14130 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14131 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14132 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14133 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14134 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14135 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14136 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14137 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14138 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14139 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14140 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14141 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14142 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14143 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14144 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
