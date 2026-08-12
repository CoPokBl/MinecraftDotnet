using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakStairsBlock(Identifier Identifier, Direction Facing, OakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:oak_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3907,
                            false => 3908,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3909,
                            false => 3910,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3911,
                            false => 3912,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3913,
                            false => 3914,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3915,
                            false => 3916,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3917,
                            false => 3918,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3919,
                            false => 3920,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3921,
                            false => 3922,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3923,
                            false => 3924,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3925,
                            false => 3926,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3927,
                            false => 3928,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3929,
                            false => 3930,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3931,
                            false => 3932,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3933,
                            false => 3934,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3935,
                            false => 3936,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3937,
                            false => 3938,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3939,
                            false => 3940,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3941,
                            false => 3942,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3943,
                            false => 3944,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3945,
                            false => 3946,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3947,
                            false => 3948,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3949,
                            false => 3950,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3951,
                            false => 3952,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3953,
                            false => 3954,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3955,
                            false => 3956,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3957,
                            false => 3958,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3959,
                            false => 3960,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3961,
                            false => 3962,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3963,
                            false => 3964,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3965,
                            false => 3966,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3967,
                            false => 3968,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3969,
                            false => 3970,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3971,
                            false => 3972,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3973,
                            false => 3974,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3975,
                            false => 3976,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3977,
                            false => 3978,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3979,
                            false => 3980,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3981,
                            false => 3982,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3983,
                            false => 3984,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3985,
                            false => 3986,
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
            3907 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            3908 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            3909 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            3910 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            3911 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            3912 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            3913 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            3914 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            3915 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            3916 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            3917 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            3918 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            3919 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            3920 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            3921 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            3922 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            3923 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            3924 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            3925 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            3926 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            3927 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            3928 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            3929 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            3930 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            3931 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            3932 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            3933 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            3934 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            3935 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            3936 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            3937 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            3938 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            3939 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            3940 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            3941 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            3942 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            3943 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            3944 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            3945 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            3946 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            3947 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            3948 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            3949 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            3950 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            3951 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            3952 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            3953 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            3954 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            3955 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            3956 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            3957 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            3958 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            3959 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            3960 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            3961 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            3962 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            3963 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            3964 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            3965 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            3966 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            3967 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            3968 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            3969 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            3970 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            3971 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            3972 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            3973 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            3974 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            3975 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            3976 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            3977 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            3978 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            3979 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            3980 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            3981 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            3982 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            3983 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            3984 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            3985 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            3986 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
