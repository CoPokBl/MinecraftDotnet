using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CinnabarStairsBlock(Identifier Identifier, Direction Facing, CinnabarStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public string SoundType => "cinnabar";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cinnabar_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.cinnabar_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25933,
                            false => 25934,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25935,
                            false => 25936,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25937,
                            false => 25938,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25939,
                            false => 25940,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25941,
                            false => 25942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25943,
                            false => 25944,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25945,
                            false => 25946,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25947,
                            false => 25948,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25949,
                            false => 25950,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25951,
                            false => 25952,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25953,
                            false => 25954,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25955,
                            false => 25956,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25957,
                            false => 25958,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25959,
                            false => 25960,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25961,
                            false => 25962,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25963,
                            false => 25964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25965,
                            false => 25966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25967,
                            false => 25968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25969,
                            false => 25970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25971,
                            false => 25972,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25973,
                            false => 25974,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25975,
                            false => 25976,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25977,
                            false => 25978,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25979,
                            false => 25980,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25981,
                            false => 25982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25983,
                            false => 25984,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25985,
                            false => 25986,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25987,
                            false => 25988,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25989,
                            false => 25990,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25991,
                            false => 25992,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25993,
                            false => 25994,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25995,
                            false => 25996,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25997,
                            false => 25998,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25999,
                            false => 26000,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26001,
                            false => 26002,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26003,
                            false => 26004,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26005,
                            false => 26006,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26007,
                            false => 26008,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26009,
                            false => 26010,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26011,
                            false => 26012,
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
            25933 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25934 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25935 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25936 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25937 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25938 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25939 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25940 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25941 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25942 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25943 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25944 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25945 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25946 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25947 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25948 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25949 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25950 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25951 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25952 => new CinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25953 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25954 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25955 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25956 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25957 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25958 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25959 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25960 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25961 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25962 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25963 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25964 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25965 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25966 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25967 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25968 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25969 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25970 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25971 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25972 => new CinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25973 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25974 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25975 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25976 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25977 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25978 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25979 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25980 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25981 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25982 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25983 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25984 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25985 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25986 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25987 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25988 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25989 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25990 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25991 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25992 => new CinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25993 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25994 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25995 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25996 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25997 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25998 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25999 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26000 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26001 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26002 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26003 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26004 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26005 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26006 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26007 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26008 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26009 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26010 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26011 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26012 => new CinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
