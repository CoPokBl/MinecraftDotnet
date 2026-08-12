using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryStairsBlock(Identifier Identifier, Direction Facing, CherryStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12052,
                            false => 12053,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12054,
                            false => 12055,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12056,
                            false => 12057,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12058,
                            false => 12059,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12060,
                            false => 12061,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12062,
                            false => 12063,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12064,
                            false => 12065,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12066,
                            false => 12067,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12068,
                            false => 12069,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12070,
                            false => 12071,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12072,
                            false => 12073,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12074,
                            false => 12075,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12076,
                            false => 12077,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12078,
                            false => 12079,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12080,
                            false => 12081,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12082,
                            false => 12083,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12084,
                            false => 12085,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12086,
                            false => 12087,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12088,
                            false => 12089,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12090,
                            false => 12091,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12092,
                            false => 12093,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12094,
                            false => 12095,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12096,
                            false => 12097,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12098,
                            false => 12099,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12100,
                            false => 12101,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12102,
                            false => 12103,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12104,
                            false => 12105,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12106,
                            false => 12107,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12108,
                            false => 12109,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12110,
                            false => 12111,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12112,
                            false => 12113,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12114,
                            false => 12115,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12116,
                            false => 12117,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12118,
                            false => 12119,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12120,
                            false => 12121,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12122,
                            false => 12123,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12124,
                            false => 12125,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12126,
                            false => 12127,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12128,
                            false => 12129,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12130,
                            false => 12131,
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
            12052 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12053 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12054 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12055 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12056 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12057 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12058 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12059 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12060 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12061 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12062 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12063 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12064 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12065 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12066 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12067 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12068 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12069 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12070 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12071 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12072 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12073 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12074 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12075 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12076 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12077 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12078 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12079 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12080 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12081 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12082 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12083 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12084 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12085 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12086 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12087 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12088 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12089 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12090 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12091 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12092 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12093 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12094 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12095 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12096 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12097 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12098 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12099 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12100 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12101 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12102 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12103 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12104 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12105 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12106 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12107 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12108 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12109 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12110 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12111 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12112 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12113 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12114 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12115 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12116 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12117 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12118 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12119 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12120 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12121 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12122 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12123 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12124 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12125 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12126 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12127 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12128 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12129 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12130 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12131 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
