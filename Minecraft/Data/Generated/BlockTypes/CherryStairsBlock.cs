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
    public int ProtocolId => 515;
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
                            true => 11850,
                            false => 11851,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11852,
                            false => 11853,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11854,
                            false => 11855,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11856,
                            false => 11857,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11858,
                            false => 11859,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11860,
                            false => 11861,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11862,
                            false => 11863,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11864,
                            false => 11865,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11866,
                            false => 11867,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11868,
                            false => 11869,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11870,
                            false => 11871,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11872,
                            false => 11873,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11874,
                            false => 11875,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11876,
                            false => 11877,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11878,
                            false => 11879,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11880,
                            false => 11881,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11882,
                            false => 11883,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11884,
                            false => 11885,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11886,
                            false => 11887,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11888,
                            false => 11889,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11890,
                            false => 11891,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11892,
                            false => 11893,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11894,
                            false => 11895,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11896,
                            false => 11897,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11898,
                            false => 11899,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11900,
                            false => 11901,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11902,
                            false => 11903,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11904,
                            false => 11905,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11906,
                            false => 11907,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11908,
                            false => 11909,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11910,
                            false => 11911,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11912,
                            false => 11913,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11914,
                            false => 11915,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11916,
                            false => 11917,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11918,
                            false => 11919,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11920,
                            false => 11921,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11922,
                            false => 11923,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11924,
                            false => 11925,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11926,
                            false => 11927,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11928,
                            false => 11929,
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
            11850 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11851 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11852 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11853 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11854 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11855 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11856 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11857 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11858 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11859 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11860 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11861 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11862 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11863 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11864 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11865 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11866 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11867 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11868 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11869 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11870 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11871 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11872 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11873 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11874 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11875 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11876 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11877 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11878 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11879 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11880 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11881 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11882 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11883 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11884 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11885 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11886 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11887 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11888 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11889 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11890 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11891 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11892 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11893 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11894 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11895 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11896 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11897 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11898 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11899 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11900 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11901 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11902 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11903 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11904 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11905 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11906 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11907 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11908 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11909 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11910 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11911 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11912 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11913 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11914 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11915 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11916 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11917 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11918 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11919 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11920 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11921 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11922 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11923 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11924 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11925 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11926 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11927 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11928 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11929 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
