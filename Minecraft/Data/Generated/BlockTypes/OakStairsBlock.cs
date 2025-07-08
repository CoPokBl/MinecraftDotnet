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
                            true => 2938,
                            false => 2939,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2940,
                            false => 2941,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2942,
                            false => 2943,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2944,
                            false => 2945,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2946,
                            false => 2947,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2948,
                            false => 2949,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2950,
                            false => 2951,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2952,
                            false => 2953,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2954,
                            false => 2955,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2956,
                            false => 2957,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2958,
                            false => 2959,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2960,
                            false => 2961,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2962,
                            false => 2963,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2964,
                            false => 2965,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2966,
                            false => 2967,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2968,
                            false => 2969,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2970,
                            false => 2971,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2972,
                            false => 2973,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2974,
                            false => 2975,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2976,
                            false => 2977,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2978,
                            false => 2979,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2980,
                            false => 2981,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2982,
                            false => 2983,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2984,
                            false => 2985,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2986,
                            false => 2987,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2988,
                            false => 2989,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2990,
                            false => 2991,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2992,
                            false => 2993,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2994,
                            false => 2995,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2996,
                            false => 2997,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2998,
                            false => 2999,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3000,
                            false => 3001,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3002,
                            false => 3003,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3004,
                            false => 3005,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3006,
                            false => 3007,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3008,
                            false => 3009,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3010,
                            false => 3011,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3012,
                            false => 3013,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3014,
                            false => 3015,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3016,
                            false => 3017,
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
            2938 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            2939 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            2940 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            2941 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            2942 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            2943 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            2944 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            2945 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            2946 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            2947 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            2948 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            2949 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            2950 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            2951 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            2952 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            2953 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            2954 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            2955 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            2956 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            2957 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            2958 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            2959 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            2960 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            2961 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            2962 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            2963 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            2964 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            2965 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            2966 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            2967 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            2968 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            2969 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            2970 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            2971 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            2972 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            2973 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            2974 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            2975 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            2976 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            2977 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            2978 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            2979 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            2980 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            2981 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            2982 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            2983 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            2984 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            2985 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            2986 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            2987 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            2988 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            2989 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            2990 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            2991 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            2992 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            2993 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            2994 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            2995 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            2996 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            2997 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            2998 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            2999 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            3000 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            3001 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            3002 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            3003 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            3004 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            3005 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            3006 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            3007 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            3008 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            3009 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            3010 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            3011 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            3012 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            3013 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            3014 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            3015 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            3016 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            3017 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
