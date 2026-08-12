using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedTuffStairsBlock(Identifier Identifier, Direction Facing, PolishedTuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "polished_tuff";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_tuff_stairs";
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
    public string TranslationKey => "block.minecraft.polished_tuff_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23870,
                            false => 23871,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23872,
                            false => 23873,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23874,
                            false => 23875,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23876,
                            false => 23877,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23878,
                            false => 23879,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23880,
                            false => 23881,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23882,
                            false => 23883,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23884,
                            false => 23885,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23886,
                            false => 23887,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23888,
                            false => 23889,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23890,
                            false => 23891,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23892,
                            false => 23893,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23894,
                            false => 23895,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23896,
                            false => 23897,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23898,
                            false => 23899,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23900,
                            false => 23901,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23902,
                            false => 23903,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23904,
                            false => 23905,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23906,
                            false => 23907,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23908,
                            false => 23909,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23910,
                            false => 23911,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23912,
                            false => 23913,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23914,
                            false => 23915,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23916,
                            false => 23917,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23918,
                            false => 23919,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23920,
                            false => 23921,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23922,
                            false => 23923,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23924,
                            false => 23925,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23926,
                            false => 23927,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23928,
                            false => 23929,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23930,
                            false => 23931,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23932,
                            false => 23933,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23934,
                            false => 23935,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23936,
                            false => 23937,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23938,
                            false => 23939,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23940,
                            false => 23941,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23942,
                            false => 23943,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23944,
                            false => 23945,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23946,
                            false => 23947,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23948,
                            false => 23949,
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
            23870 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            23871 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            23872 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            23873 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            23874 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            23875 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            23876 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            23877 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            23878 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            23879 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            23880 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            23881 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            23882 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            23883 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            23884 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            23885 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            23886 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            23887 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            23888 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            23889 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            23890 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            23891 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            23892 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            23893 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            23894 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            23895 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            23896 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            23897 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            23898 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            23899 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            23900 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            23901 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            23902 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            23903 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            23904 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            23905 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            23906 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            23907 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            23908 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            23909 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            23910 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            23911 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            23912 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            23913 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            23914 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            23915 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            23916 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            23917 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            23918 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            23919 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            23920 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            23921 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            23922 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            23923 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            23924 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            23925 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            23926 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            23927 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            23928 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            23929 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            23930 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23931 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23932 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23933 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23934 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23935 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23936 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23937 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23938 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23939 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23940 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23941 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23942 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23943 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23944 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23945 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23946 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23947 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23948 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23949 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
