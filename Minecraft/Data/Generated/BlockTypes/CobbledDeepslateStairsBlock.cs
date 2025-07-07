using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobbledDeepslateStairsBlock(Identifier Identifier, Direction Facing, CobbledDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public string SoundType => "deepslate";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cobbled_deepslate_stairs";
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
    public string TranslationKey => "block.minecraft.cobbled_deepslate_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25968,
                            false => 25969,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25970,
                            false => 25971,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25972,
                            false => 25973,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25974,
                            false => 25975,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25976,
                            false => 25977,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25978,
                            false => 25979,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25980,
                            false => 25981,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25982,
                            false => 25983,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25984,
                            false => 25985,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25986,
                            false => 25987,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25988,
                            false => 25989,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25990,
                            false => 25991,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25992,
                            false => 25993,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25994,
                            false => 25995,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25996,
                            false => 25997,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25998,
                            false => 25999,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26000,
                            false => 26001,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26002,
                            false => 26003,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26004,
                            false => 26005,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26006,
                            false => 26007,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26008,
                            false => 26009,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26010,
                            false => 26011,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26012,
                            false => 26013,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26014,
                            false => 26015,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26016,
                            false => 26017,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26018,
                            false => 26019,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26020,
                            false => 26021,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26022,
                            false => 26023,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26024,
                            false => 26025,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26026,
                            false => 26027,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26028,
                            false => 26029,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26030,
                            false => 26031,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26032,
                            false => 26033,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26034,
                            false => 26035,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26036,
                            false => 26037,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26038,
                            false => 26039,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26040,
                            false => 26041,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26042,
                            false => 26043,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26044,
                            false => 26045,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26046,
                            false => 26047,
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
            25968 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25969 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25970 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25971 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25972 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25973 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25974 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25975 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25976 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25977 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25978 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25979 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25980 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25981 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25982 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25983 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25984 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25985 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25986 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25987 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25988 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25989 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25990 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25991 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25992 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25993 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25994 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25995 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25996 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25997 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25998 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25999 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26000 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26001 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26002 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26003 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26004 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26005 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26006 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26007 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26008 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26009 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26010 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26011 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26012 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26013 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26014 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26015 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26016 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26017 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26018 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26019 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26020 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26021 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26022 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26023 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26024 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26025 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26026 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26027 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26028 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26029 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26030 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26031 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26032 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26033 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26034 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26035 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26036 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26037 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26038 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26039 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26040 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26041 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26042 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26043 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26044 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26045 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26046 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26047 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
