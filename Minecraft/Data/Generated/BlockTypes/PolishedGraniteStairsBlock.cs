using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedGraniteStairsBlock(Identifier Identifier, Direction Facing, PolishedGraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_granite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.polished_granite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14017,
                            false => 14018,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14019,
                            false => 14020,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14021,
                            false => 14022,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14023,
                            false => 14024,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14025,
                            false => 14026,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14027,
                            false => 14028,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14029,
                            false => 14030,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14031,
                            false => 14032,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14033,
                            false => 14034,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14035,
                            false => 14036,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14037,
                            false => 14038,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14039,
                            false => 14040,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14041,
                            false => 14042,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14043,
                            false => 14044,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14045,
                            false => 14046,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14047,
                            false => 14048,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14049,
                            false => 14050,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14051,
                            false => 14052,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14053,
                            false => 14054,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14055,
                            false => 14056,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14057,
                            false => 14058,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14059,
                            false => 14060,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14061,
                            false => 14062,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14063,
                            false => 14064,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14065,
                            false => 14066,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14067,
                            false => 14068,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14069,
                            false => 14070,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14071,
                            false => 14072,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14073,
                            false => 14074,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14075,
                            false => 14076,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14077,
                            false => 14078,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14079,
                            false => 14080,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14081,
                            false => 14082,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14083,
                            false => 14084,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14085,
                            false => 14086,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14087,
                            false => 14088,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14089,
                            false => 14090,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14091,
                            false => 14092,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14093,
                            false => 14094,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14095,
                            false => 14096,
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
            14017 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14018 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14019 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14020 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14021 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14022 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14023 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14024 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14025 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14026 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14027 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14028 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14029 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14030 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14031 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14032 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14033 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14034 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14035 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14036 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14037 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14038 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14039 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14040 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14041 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14042 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14043 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14044 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14045 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14046 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14047 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14048 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14049 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14050 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14051 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14052 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14053 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14054 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14055 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14056 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14057 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14058 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14059 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14060 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14061 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14062 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14063 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14064 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14065 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14066 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14067 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14068 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14069 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14070 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14071 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14072 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14073 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14074 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14075 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14076 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14077 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14078 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14079 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14080 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14081 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14082 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14083 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14084 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14085 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14086 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14087 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14088 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14089 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14090 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14091 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14092 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14093 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14094 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14095 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14096 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
