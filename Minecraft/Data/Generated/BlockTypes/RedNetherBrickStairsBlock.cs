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
                            true => 14897,
                            false => 14898,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14899,
                            false => 14900,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14901,
                            false => 14902,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14903,
                            false => 14904,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14905,
                            false => 14906,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14907,
                            false => 14908,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14909,
                            false => 14910,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14911,
                            false => 14912,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14913,
                            false => 14914,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14915,
                            false => 14916,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14917,
                            false => 14918,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14919,
                            false => 14920,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14921,
                            false => 14922,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14923,
                            false => 14924,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14925,
                            false => 14926,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14927,
                            false => 14928,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14929,
                            false => 14930,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14931,
                            false => 14932,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14933,
                            false => 14934,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14935,
                            false => 14936,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14937,
                            false => 14938,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14939,
                            false => 14940,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14941,
                            false => 14942,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14943,
                            false => 14944,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14945,
                            false => 14946,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14947,
                            false => 14948,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14949,
                            false => 14950,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14951,
                            false => 14952,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14953,
                            false => 14954,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14955,
                            false => 14956,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14957,
                            false => 14958,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14959,
                            false => 14960,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14961,
                            false => 14962,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14963,
                            false => 14964,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14965,
                            false => 14966,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14967,
                            false => 14968,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14969,
                            false => 14970,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14971,
                            false => 14972,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14973,
                            false => 14974,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14975,
                            false => 14976,
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
            14897 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14898 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14899 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14900 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14901 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14902 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14903 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14904 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14905 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14906 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14907 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14908 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14909 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14910 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14911 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14912 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14913 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14914 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14915 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14916 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14917 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14918 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14919 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14920 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14921 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14922 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14923 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14924 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14925 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14926 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14927 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14928 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14929 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14930 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14931 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14932 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14933 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14934 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14935 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14936 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14937 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14938 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14939 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14940 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14941 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14942 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14943 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14944 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14945 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14946 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14947 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14948 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14949 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14950 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14951 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14952 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14953 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14954 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14955 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14956 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14957 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14958 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14959 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14960 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14961 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14962 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14963 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14964 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14965 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14966 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14967 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14968 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14969 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14970 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14971 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14972 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14973 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14974 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14975 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14976 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
