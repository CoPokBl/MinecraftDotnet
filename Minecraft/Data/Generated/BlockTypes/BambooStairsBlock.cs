using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooStairsBlock(Identifier Identifier, Direction Facing, BambooStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11093,
                            false => 11094,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11095,
                            false => 11096,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11097,
                            false => 11098,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11099,
                            false => 11100,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11101,
                            false => 11102,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11103,
                            false => 11104,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11105,
                            false => 11106,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11107,
                            false => 11108,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11109,
                            false => 11110,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11111,
                            false => 11112,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11113,
                            false => 11114,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11115,
                            false => 11116,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11117,
                            false => 11118,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11119,
                            false => 11120,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11121,
                            false => 11122,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11123,
                            false => 11124,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11125,
                            false => 11126,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11127,
                            false => 11128,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11129,
                            false => 11130,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11131,
                            false => 11132,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11133,
                            false => 11134,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11135,
                            false => 11136,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11137,
                            false => 11138,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11139,
                            false => 11140,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11141,
                            false => 11142,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11143,
                            false => 11144,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11145,
                            false => 11146,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11147,
                            false => 11148,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11149,
                            false => 11150,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11151,
                            false => 11152,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11153,
                            false => 11154,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11155,
                            false => 11156,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11157,
                            false => 11158,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11159,
                            false => 11160,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11161,
                            false => 11162,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11163,
                            false => 11164,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11165,
                            false => 11166,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11167,
                            false => 11168,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11169,
                            false => 11170,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11171,
                            false => 11172,
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
            11093 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11094 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11095 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11096 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11097 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11098 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11099 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11100 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11101 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11102 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11103 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11104 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11105 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11106 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11107 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11108 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11109 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11110 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11111 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11112 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11113 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11114 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11115 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11116 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11117 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11118 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11119 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11120 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11121 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11122 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11123 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11124 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11125 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11126 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11127 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11128 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11129 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11130 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11131 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11132 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11133 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11134 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11135 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11136 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11137 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11138 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11139 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11140 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11141 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11142 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11143 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11144 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11145 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11146 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11147 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11148 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11149 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11150 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11151 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11152 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11153 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11154 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11155 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11156 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11157 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11158 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11159 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11160 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11161 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11162 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11163 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11164 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11165 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11166 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11167 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11168 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11169 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11170 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11171 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11172 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
