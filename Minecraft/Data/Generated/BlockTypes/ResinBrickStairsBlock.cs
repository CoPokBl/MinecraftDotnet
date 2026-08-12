using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinBrickStairsBlock(Identifier Identifier, Direction Facing, ResinBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "resin_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:resin_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 37;
    public string TranslationKey => "block.minecraft.resin_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8923,
                            false => 8924,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8925,
                            false => 8926,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8927,
                            false => 8928,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8929,
                            false => 8930,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8931,
                            false => 8932,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8933,
                            false => 8934,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8935,
                            false => 8936,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8937,
                            false => 8938,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8939,
                            false => 8940,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8941,
                            false => 8942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8943,
                            false => 8944,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8945,
                            false => 8946,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8947,
                            false => 8948,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8949,
                            false => 8950,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8951,
                            false => 8952,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8953,
                            false => 8954,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8955,
                            false => 8956,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8957,
                            false => 8958,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8959,
                            false => 8960,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8961,
                            false => 8962,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8963,
                            false => 8964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8965,
                            false => 8966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8967,
                            false => 8968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8969,
                            false => 8970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8971,
                            false => 8972,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8973,
                            false => 8974,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8975,
                            false => 8976,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8977,
                            false => 8978,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8979,
                            false => 8980,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8981,
                            false => 8982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8983,
                            false => 8984,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8985,
                            false => 8986,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8987,
                            false => 8988,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8989,
                            false => 8990,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8991,
                            false => 8992,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8993,
                            false => 8994,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8995,
                            false => 8996,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8997,
                            false => 8998,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8999,
                            false => 9000,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9001,
                            false => 9002,
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
            8923 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8924 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8925 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8926 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8927 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8928 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8929 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8930 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8931 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8932 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8933 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8934 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8935 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8936 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8937 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8938 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8939 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8940 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8941 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8942 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8943 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8944 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8945 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8946 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8947 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8948 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8949 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8950 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8951 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8952 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8953 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8954 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8955 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8956 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8957 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8958 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8959 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8960 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8961 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8962 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8963 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8964 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8965 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8966 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8967 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8968 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8969 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8970 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8971 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8972 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8973 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8974 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8975 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8976 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8977 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8978 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8979 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8980 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8981 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8982 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8983 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8984 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8985 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8986 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8987 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8988 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8989 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8990 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8991 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8992 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8993 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8994 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8995 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8996 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8997 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8998 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8999 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9000 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9001 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9002 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
