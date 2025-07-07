using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedNetherBrickStairsBlock(Identifier Identifier, Direction Facing, RedNetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:red_nether_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.red_nether_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14865,
                            false => 14866,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14867,
                            false => 14868,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14869,
                            false => 14870,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14871,
                            false => 14872,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14873,
                            false => 14874,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14875,
                            false => 14876,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14877,
                            false => 14878,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14879,
                            false => 14880,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14881,
                            false => 14882,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14883,
                            false => 14884,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14885,
                            false => 14886,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14887,
                            false => 14888,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14889,
                            false => 14890,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14891,
                            false => 14892,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14893,
                            false => 14894,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14895,
                            false => 14896,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14897,
                            false => 14898,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14899,
                            false => 14900,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14901,
                            false => 14902,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14903,
                            false => 14904,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14905,
                            false => 14906,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14907,
                            false => 14908,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14909,
                            false => 14910,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14911,
                            false => 14912,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14913,
                            false => 14914,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14915,
                            false => 14916,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14917,
                            false => 14918,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14919,
                            false => 14920,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14921,
                            false => 14922,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14923,
                            false => 14924,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14925,
                            false => 14926,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14927,
                            false => 14928,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14929,
                            false => 14930,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14931,
                            false => 14932,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14933,
                            false => 14934,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14935,
                            false => 14936,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14937,
                            false => 14938,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14939,
                            false => 14940,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14941,
                            false => 14942,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14943,
                            false => 14944,
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
            14865 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14866 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14867 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14868 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14869 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14870 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14871 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14872 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14873 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14874 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14875 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14876 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14877 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14878 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14879 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14880 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14881 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14882 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14883 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14884 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14885 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14886 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14887 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14888 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14889 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14890 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14891 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14892 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14893 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14894 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14895 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14896 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14897 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14898 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14899 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14900 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14901 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14902 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14903 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14904 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14905 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14906 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14907 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14908 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14909 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14910 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14911 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14912 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14913 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14914 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14915 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14916 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14917 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14918 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14919 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14920 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14921 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14922 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14923 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14924 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14925 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14926 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14927 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14928 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14929 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14930 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14931 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14932 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14933 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14934 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14935 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14936 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14937 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14938 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14939 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14940 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14941 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14942 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14943 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14944 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
