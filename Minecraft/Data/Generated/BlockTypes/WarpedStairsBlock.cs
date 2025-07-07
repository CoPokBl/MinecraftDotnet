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
                            true => 20043,
                            false => 20044,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20045,
                            false => 20046,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20047,
                            false => 20048,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20049,
                            false => 20050,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20051,
                            false => 20052,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20053,
                            false => 20054,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20055,
                            false => 20056,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20057,
                            false => 20058,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20059,
                            false => 20060,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20061,
                            false => 20062,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20063,
                            false => 20064,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20065,
                            false => 20066,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20067,
                            false => 20068,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20069,
                            false => 20070,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20071,
                            false => 20072,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20073,
                            false => 20074,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20075,
                            false => 20076,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20077,
                            false => 20078,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20079,
                            false => 20080,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20081,
                            false => 20082,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20083,
                            false => 20084,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20085,
                            false => 20086,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20087,
                            false => 20088,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20089,
                            false => 20090,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20091,
                            false => 20092,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20093,
                            false => 20094,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20095,
                            false => 20096,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20097,
                            false => 20098,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20099,
                            false => 20100,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20101,
                            false => 20102,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20103,
                            false => 20104,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20105,
                            false => 20106,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20107,
                            false => 20108,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20109,
                            false => 20110,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20111,
                            false => 20112,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20113,
                            false => 20114,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20115,
                            false => 20116,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20117,
                            false => 20118,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20119,
                            false => 20120,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20121,
                            false => 20122,
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
            20043 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            20044 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            20045 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            20046 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            20047 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20048 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20049 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20050 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20051 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20052 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20053 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20054 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20055 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20056 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20057 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20058 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20059 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20060 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20061 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20062 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20063 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20064 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20065 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20066 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20067 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20068 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20069 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20070 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20071 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20072 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20073 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20074 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20075 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20076 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20077 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20078 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20079 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20080 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20081 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20082 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20083 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20084 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20085 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20086 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20087 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20088 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20089 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20090 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20091 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20092 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20093 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20094 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20095 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20096 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20097 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20098 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20099 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20100 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20101 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20102 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20103 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20104 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20105 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20106 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20107 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20108 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20109 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20110 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20111 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20112 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20113 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20114 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20115 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20116 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20117 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20118 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20119 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20120 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20121 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20122 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
