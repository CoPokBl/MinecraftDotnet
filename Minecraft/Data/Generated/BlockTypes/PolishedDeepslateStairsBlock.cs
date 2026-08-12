using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDeepslateStairsBlock(Identifier Identifier, Direction Facing, PolishedDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3.5;
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
    public string SoundType => "polished_deepslate";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_deepslate_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.polished_deepslate_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30831,
                            false => 30832,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30833,
                            false => 30834,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30835,
                            false => 30836,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30837,
                            false => 30838,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30839,
                            false => 30840,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30841,
                            false => 30842,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30843,
                            false => 30844,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30845,
                            false => 30846,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30847,
                            false => 30848,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30849,
                            false => 30850,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30851,
                            false => 30852,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30853,
                            false => 30854,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30855,
                            false => 30856,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30857,
                            false => 30858,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30859,
                            false => 30860,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30861,
                            false => 30862,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30863,
                            false => 30864,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30865,
                            false => 30866,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30867,
                            false => 30868,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30869,
                            false => 30870,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30871,
                            false => 30872,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30873,
                            false => 30874,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30875,
                            false => 30876,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30877,
                            false => 30878,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30879,
                            false => 30880,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30881,
                            false => 30882,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30883,
                            false => 30884,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30885,
                            false => 30886,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30887,
                            false => 30888,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30889,
                            false => 30890,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30891,
                            false => 30892,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30893,
                            false => 30894,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30895,
                            false => 30896,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30897,
                            false => 30898,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30899,
                            false => 30900,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30901,
                            false => 30902,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30903,
                            false => 30904,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30905,
                            false => 30906,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30907,
                            false => 30908,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30909,
                            false => 30910,
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
            30831 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            30832 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            30833 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            30834 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            30835 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            30836 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            30837 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            30838 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            30839 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            30840 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            30841 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            30842 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            30843 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            30844 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            30845 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            30846 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            30847 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            30848 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            30849 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            30850 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            30851 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            30852 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            30853 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            30854 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            30855 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            30856 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            30857 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            30858 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            30859 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            30860 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            30861 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            30862 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            30863 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            30864 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            30865 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            30866 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            30867 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            30868 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            30869 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            30870 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            30871 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            30872 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            30873 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            30874 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            30875 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            30876 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            30877 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            30878 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            30879 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            30880 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            30881 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            30882 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            30883 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            30884 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            30885 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            30886 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            30887 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            30888 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            30889 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            30890 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            30891 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            30892 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            30893 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            30894 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            30895 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            30896 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            30897 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            30898 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            30899 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            30900 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            30901 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            30902 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            30903 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            30904 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            30905 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            30906 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            30907 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            30908 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            30909 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            30910 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
