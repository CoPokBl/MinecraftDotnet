using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedStairsBlock(Identifier Identifier, Direction Facing, WarpedStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 856;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20075,
                            false => 20076,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20077,
                            false => 20078,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20079,
                            false => 20080,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20081,
                            false => 20082,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20083,
                            false => 20084,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20085,
                            false => 20086,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20087,
                            false => 20088,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20089,
                            false => 20090,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20091,
                            false => 20092,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20093,
                            false => 20094,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20095,
                            false => 20096,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20097,
                            false => 20098,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20099,
                            false => 20100,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20101,
                            false => 20102,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20103,
                            false => 20104,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20105,
                            false => 20106,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20107,
                            false => 20108,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20109,
                            false => 20110,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20111,
                            false => 20112,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20113,
                            false => 20114,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20115,
                            false => 20116,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20117,
                            false => 20118,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20119,
                            false => 20120,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20121,
                            false => 20122,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20123,
                            false => 20124,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20125,
                            false => 20126,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20127,
                            false => 20128,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20129,
                            false => 20130,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20131,
                            false => 20132,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20133,
                            false => 20134,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20135,
                            false => 20136,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20137,
                            false => 20138,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20139,
                            false => 20140,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20141,
                            false => 20142,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20143,
                            false => 20144,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20145,
                            false => 20146,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20147,
                            false => 20148,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20149,
                            false => 20150,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20151,
                            false => 20152,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20153,
                            false => 20154,
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
            20075 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            20076 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            20077 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            20078 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            20079 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20080 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20081 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20082 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20083 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20084 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20085 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20086 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20087 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20088 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20089 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20090 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20091 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20092 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20093 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20094 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20095 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20096 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20097 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20098 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20099 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20100 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20101 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20102 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20103 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20104 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20105 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20106 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20107 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20108 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20109 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20110 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20111 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20112 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20113 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20114 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20115 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20116 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20117 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20118 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20119 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20120 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20121 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20122 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20123 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20124 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20125 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20126 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20127 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20128 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20129 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20130 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20131 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20132 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20133 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20134 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20135 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20136 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20137 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20138 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20139 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20140 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20141 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20142 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20143 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20144 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20145 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20146 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20147 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20148 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20149 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20150 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20151 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20152 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20153 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20154 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("shape", Shape.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
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

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
