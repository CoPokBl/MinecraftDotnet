using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothQuartzStairsBlock(Identifier Identifier, Direction Facing, SmoothQuartzStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 2;
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:smooth_quartz_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.smooth_quartz_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15936,
                            false => 15937,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15938,
                            false => 15939,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15940,
                            false => 15941,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15942,
                            false => 15943,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15944,
                            false => 15945,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15946,
                            false => 15947,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15948,
                            false => 15949,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15950,
                            false => 15951,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15952,
                            false => 15953,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15954,
                            false => 15955,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15956,
                            false => 15957,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15958,
                            false => 15959,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15960,
                            false => 15961,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15962,
                            false => 15963,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15964,
                            false => 15965,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15966,
                            false => 15967,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15968,
                            false => 15969,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15970,
                            false => 15971,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15972,
                            false => 15973,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15974,
                            false => 15975,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15976,
                            false => 15977,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15978,
                            false => 15979,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15980,
                            false => 15981,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15982,
                            false => 15983,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15984,
                            false => 15985,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15986,
                            false => 15987,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15988,
                            false => 15989,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15990,
                            false => 15991,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15992,
                            false => 15993,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15994,
                            false => 15995,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15996,
                            false => 15997,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15998,
                            false => 15999,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16000,
                            false => 16001,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16002,
                            false => 16003,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16004,
                            false => 16005,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16006,
                            false => 16007,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16008,
                            false => 16009,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16010,
                            false => 16011,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16012,
                            false => 16013,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16014,
                            false => 16015,
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
            15936 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15937 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15938 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15939 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15940 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15941 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15942 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15943 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15944 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15945 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15946 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15947 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15948 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15949 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15950 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15951 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15952 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15953 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15954 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15955 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15956 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15957 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15958 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15959 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15960 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15961 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15962 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15963 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15964 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15965 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15966 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15967 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15968 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15969 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15970 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15971 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15972 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15973 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15974 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15975 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15976 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15977 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15978 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15979 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15980 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15981 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15982 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15983 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15984 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15985 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15986 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15987 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15988 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15989 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15990 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15991 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15992 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15993 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15994 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15995 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15996 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15997 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15998 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15999 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16000 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16001 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16002 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16003 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16004 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16005 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16006 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16007 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16008 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16009 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16010 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16011 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16012 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16013 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16014 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16015 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
