using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AndesiteStairsBlock(Identifier Identifier, Direction Facing, AndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 805;
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:andesite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.andesite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15894,
                            false => 15895,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15896,
                            false => 15897,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15898,
                            false => 15899,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15900,
                            false => 15901,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15902,
                            false => 15903,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15904,
                            false => 15905,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15906,
                            false => 15907,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15908,
                            false => 15909,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15910,
                            false => 15911,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15912,
                            false => 15913,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15914,
                            false => 15915,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15916,
                            false => 15917,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15918,
                            false => 15919,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15920,
                            false => 15921,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15922,
                            false => 15923,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15924,
                            false => 15925,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15926,
                            false => 15927,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15928,
                            false => 15929,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15930,
                            false => 15931,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15932,
                            false => 15933,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15934,
                            false => 15935,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15936,
                            false => 15937,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15938,
                            false => 15939,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15940,
                            false => 15941,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15942,
                            false => 15943,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15944,
                            false => 15945,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15946,
                            false => 15947,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15948,
                            false => 15949,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15950,
                            false => 15951,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15952,
                            false => 15953,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15954,
                            false => 15955,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15956,
                            false => 15957,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15958,
                            false => 15959,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15960,
                            false => 15961,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15962,
                            false => 15963,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15964,
                            false => 15965,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15966,
                            false => 15967,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15968,
                            false => 15969,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15970,
                            false => 15971,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15972,
                            false => 15973,
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
            15894 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15895 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15896 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15897 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15898 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15899 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15900 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15901 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15902 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15903 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15904 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15905 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15906 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15907 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15908 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15909 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15910 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15911 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15912 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15913 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15914 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15915 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15916 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15917 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15918 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15919 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15920 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15921 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15922 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15923 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15924 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15925 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15926 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15927 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15928 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15929 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15930 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15931 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15932 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15933 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15934 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15935 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15936 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15937 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15938 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15939 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15940 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15941 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15942 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15943 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15944 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15945 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15946 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15947 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15948 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15949 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15950 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15951 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15952 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15953 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15954 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15955 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15956 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15957 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15958 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15959 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15960 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15961 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15962 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15963 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15964 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15965 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15966 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15967 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15968 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15969 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15970 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15971 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15972 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15973 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
