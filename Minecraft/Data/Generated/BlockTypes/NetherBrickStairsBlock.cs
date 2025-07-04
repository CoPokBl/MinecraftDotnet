using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickStairsBlock(Identifier Identifier, Direction Facing, NetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8089,
                            false => 8090,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8091,
                            false => 8092,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8093,
                            false => 8094,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8095,
                            false => 8096,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8097,
                            false => 8098,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8099,
                            false => 8100,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8101,
                            false => 8102,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8103,
                            false => 8104,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8105,
                            false => 8106,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8107,
                            false => 8108,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8109,
                            false => 8110,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8111,
                            false => 8112,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8113,
                            false => 8114,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8115,
                            false => 8116,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8117,
                            false => 8118,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8119,
                            false => 8120,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8121,
                            false => 8122,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8123,
                            false => 8124,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8125,
                            false => 8126,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8127,
                            false => 8128,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8129,
                            false => 8130,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8131,
                            false => 8132,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8133,
                            false => 8134,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8135,
                            false => 8136,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8137,
                            false => 8138,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8139,
                            false => 8140,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8141,
                            false => 8142,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8143,
                            false => 8144,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8145,
                            false => 8146,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8147,
                            false => 8148,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8149,
                            false => 8150,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8151,
                            false => 8152,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8153,
                            false => 8154,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8155,
                            false => 8156,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8157,
                            false => 8158,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8159,
                            false => 8160,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8161,
                            false => 8162,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8163,
                            false => 8164,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8165,
                            false => 8166,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8167,
                            false => 8168,
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
            8089 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8090 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8091 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8092 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8093 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8094 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8095 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8096 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8097 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8098 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8099 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8100 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8101 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8102 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8103 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8104 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8105 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8106 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8107 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8108 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8109 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8110 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8111 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8112 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8113 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8114 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8115 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8116 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8117 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8118 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8119 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8120 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8121 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8122 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8123 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8124 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8125 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8126 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8127 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8128 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8129 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8130 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8131 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8132 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8133 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8134 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8135 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8136 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8137 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8138 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8139 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8140 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8141 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8142 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8143 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8144 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8145 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8146 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8147 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8148 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8149 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8150 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8151 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8152 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8153 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8154 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8155 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8156 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8157 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8158 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8159 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8160 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8161 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8162 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8163 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8164 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8165 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8166 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8167 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8168 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
