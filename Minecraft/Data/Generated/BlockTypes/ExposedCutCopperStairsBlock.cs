using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCutCopperStairsBlock(Identifier Identifier, Direction Facing, ExposedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:exposed_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.exposed_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27888,
                            false => 27889,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27890,
                            false => 27891,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27892,
                            false => 27893,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27894,
                            false => 27895,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27896,
                            false => 27897,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27898,
                            false => 27899,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27900,
                            false => 27901,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27902,
                            false => 27903,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27904,
                            false => 27905,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27906,
                            false => 27907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27908,
                            false => 27909,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27910,
                            false => 27911,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27912,
                            false => 27913,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27914,
                            false => 27915,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27916,
                            false => 27917,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27918,
                            false => 27919,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27920,
                            false => 27921,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27922,
                            false => 27923,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27924,
                            false => 27925,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27926,
                            false => 27927,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27928,
                            false => 27929,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27930,
                            false => 27931,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27932,
                            false => 27933,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27934,
                            false => 27935,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27936,
                            false => 27937,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27938,
                            false => 27939,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27940,
                            false => 27941,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27942,
                            false => 27943,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27944,
                            false => 27945,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27946,
                            false => 27947,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27948,
                            false => 27949,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27950,
                            false => 27951,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27952,
                            false => 27953,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27954,
                            false => 27955,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27956,
                            false => 27957,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27958,
                            false => 27959,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27960,
                            false => 27961,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27962,
                            false => 27963,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27964,
                            false => 27965,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27966,
                            false => 27967,
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
            27888 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            27889 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            27890 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            27891 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            27892 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            27893 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            27894 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            27895 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            27896 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            27897 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            27898 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            27899 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            27900 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            27901 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            27902 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            27903 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            27904 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            27905 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            27906 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            27907 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            27908 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            27909 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            27910 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            27911 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            27912 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            27913 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            27914 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            27915 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            27916 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            27917 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            27918 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            27919 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            27920 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            27921 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            27922 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            27923 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            27924 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            27925 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            27926 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            27927 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            27928 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            27929 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            27930 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            27931 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            27932 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            27933 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            27934 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            27935 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            27936 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            27937 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            27938 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            27939 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            27940 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            27941 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            27942 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            27943 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            27944 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            27945 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            27946 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            27947 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            27948 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            27949 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            27950 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            27951 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            27952 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            27953 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            27954 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            27955 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            27956 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            27957 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            27958 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            27959 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            27960 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            27961 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            27962 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            27963 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            27964 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            27965 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            27966 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            27967 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
