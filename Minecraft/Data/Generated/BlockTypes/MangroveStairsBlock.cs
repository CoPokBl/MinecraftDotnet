using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveStairsBlock(Identifier Identifier, Direction Facing, MangroveStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 518;
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mangrove_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12090,
                            false => 12091,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12092,
                            false => 12093,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12094,
                            false => 12095,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12096,
                            false => 12097,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12098,
                            false => 12099,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12100,
                            false => 12101,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12102,
                            false => 12103,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12104,
                            false => 12105,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12106,
                            false => 12107,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12108,
                            false => 12109,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12110,
                            false => 12111,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12112,
                            false => 12113,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12114,
                            false => 12115,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12116,
                            false => 12117,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12118,
                            false => 12119,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12120,
                            false => 12121,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12122,
                            false => 12123,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12124,
                            false => 12125,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12126,
                            false => 12127,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12128,
                            false => 12129,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12130,
                            false => 12131,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12132,
                            false => 12133,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12134,
                            false => 12135,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12136,
                            false => 12137,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12138,
                            false => 12139,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12140,
                            false => 12141,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12142,
                            false => 12143,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12144,
                            false => 12145,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12146,
                            false => 12147,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12148,
                            false => 12149,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12150,
                            false => 12151,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12152,
                            false => 12153,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12154,
                            false => 12155,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12156,
                            false => 12157,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12158,
                            false => 12159,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12160,
                            false => 12161,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12162,
                            false => 12163,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12164,
                            false => 12165,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12166,
                            false => 12167,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12168,
                            false => 12169,
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
            12090 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12091 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12092 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12093 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12094 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12095 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12096 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12097 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12098 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12099 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12100 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12101 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12102 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12103 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12104 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12105 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12106 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12107 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12108 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12109 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12110 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12111 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12112 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12113 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12114 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12115 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12116 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12117 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12118 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12119 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12120 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12121 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12122 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12123 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12124 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12125 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12126 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12127 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12128 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12129 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12130 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12131 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12132 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12133 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12134 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12135 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12136 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12137 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12138 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12139 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12140 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12141 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12142 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12143 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12144 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12145 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12146 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12147 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12148 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12149 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12150 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12151 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12152 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12153 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12154 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12155 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12156 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12157 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12158 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12159 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12160 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12161 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12162 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12163 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12164 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12165 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12166 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12167 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12168 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12169 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
