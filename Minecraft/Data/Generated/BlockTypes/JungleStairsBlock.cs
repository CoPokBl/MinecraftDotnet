using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleStairsBlock(Identifier Identifier, Direction Facing, JungleStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:jungle_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9888,
                            false => 9889,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9890,
                            false => 9891,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9892,
                            false => 9893,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9894,
                            false => 9895,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9896,
                            false => 9897,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9898,
                            false => 9899,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9900,
                            false => 9901,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9902,
                            false => 9903,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9904,
                            false => 9905,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9906,
                            false => 9907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9908,
                            false => 9909,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9910,
                            false => 9911,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9912,
                            false => 9913,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9914,
                            false => 9915,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9916,
                            false => 9917,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9918,
                            false => 9919,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9920,
                            false => 9921,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9922,
                            false => 9923,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9924,
                            false => 9925,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9926,
                            false => 9927,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9928,
                            false => 9929,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9930,
                            false => 9931,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9932,
                            false => 9933,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9934,
                            false => 9935,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9936,
                            false => 9937,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9938,
                            false => 9939,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9940,
                            false => 9941,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9942,
                            false => 9943,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9944,
                            false => 9945,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9946,
                            false => 9947,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9948,
                            false => 9949,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9950,
                            false => 9951,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9952,
                            false => 9953,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9954,
                            false => 9955,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9956,
                            false => 9957,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9958,
                            false => 9959,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9960,
                            false => 9961,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9962,
                            false => 9963,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9964,
                            false => 9965,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9966,
                            false => 9967,
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
            9888 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9889 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9890 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9891 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9892 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9893 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9894 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9895 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9896 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9897 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9898 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9899 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9900 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9901 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9902 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9903 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9904 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9905 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9906 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9907 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9908 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9909 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9910 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9911 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9912 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9913 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9914 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9915 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9916 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9917 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9918 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9919 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9920 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9921 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9922 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9923 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9924 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9925 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9926 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9927 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9928 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9929 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9930 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9931 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9932 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9933 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9934 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9935 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9936 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9937 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9938 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9939 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9940 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9941 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9942 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9943 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9944 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9945 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9946 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9947 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9948 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9949 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9950 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9951 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9952 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9953 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9954 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9955 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9956 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9957 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9958 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9959 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9960 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9961 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9962 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9963 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9964 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9965 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9966 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9967 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
