using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffBrickStairsBlock(Identifier Identifier, Direction Facing, TuffBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 993;
    public double Hardness => 1.5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "tuff_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tuff_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.tuff_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24080,
                            false => 24081,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24082,
                            false => 24083,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24084,
                            false => 24085,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24086,
                            false => 24087,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24088,
                            false => 24089,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24090,
                            false => 24091,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24092,
                            false => 24093,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24094,
                            false => 24095,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24096,
                            false => 24097,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24098,
                            false => 24099,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24100,
                            false => 24101,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24102,
                            false => 24103,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24104,
                            false => 24105,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24106,
                            false => 24107,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24108,
                            false => 24109,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24110,
                            false => 24111,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24112,
                            false => 24113,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24114,
                            false => 24115,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24116,
                            false => 24117,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24118,
                            false => 24119,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24120,
                            false => 24121,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24122,
                            false => 24123,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24124,
                            false => 24125,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24126,
                            false => 24127,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24128,
                            false => 24129,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24130,
                            false => 24131,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24132,
                            false => 24133,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24134,
                            false => 24135,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24136,
                            false => 24137,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24138,
                            false => 24139,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24140,
                            false => 24141,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24142,
                            false => 24143,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24144,
                            false => 24145,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24146,
                            false => 24147,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24148,
                            false => 24149,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24150,
                            false => 24151,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24152,
                            false => 24153,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24154,
                            false => 24155,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24156,
                            false => 24157,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24158,
                            false => 24159,
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
            24080 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24081 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24082 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24083 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24084 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24085 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24086 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24087 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24088 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24089 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24090 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24091 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24092 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24093 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24094 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24095 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24096 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24097 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24098 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24099 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24100 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24101 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24102 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24103 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24104 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24105 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24106 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24107 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24108 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24109 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24110 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24111 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24112 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24113 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24114 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24115 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24116 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24117 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24118 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24119 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24120 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24121 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24122 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24123 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24124 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24125 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24126 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24127 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24128 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24129 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24130 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24131 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24132 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24133 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24134 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24135 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24136 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24137 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24138 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24139 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24140 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24141 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24142 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24143 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24144 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24145 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24146 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24147 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24148 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24149 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24150 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24151 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24152 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24153 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24154 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24155 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24156 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24157 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24158 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24159 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.ChildrenMap.ContainsKey("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
