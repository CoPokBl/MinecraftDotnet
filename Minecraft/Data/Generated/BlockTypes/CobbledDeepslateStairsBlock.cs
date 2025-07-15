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
                            true => 26000,
                            false => 26001,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26002,
                            false => 26003,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26004,
                            false => 26005,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26006,
                            false => 26007,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26008,
                            false => 26009,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26010,
                            false => 26011,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26012,
                            false => 26013,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26014,
                            false => 26015,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26016,
                            false => 26017,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26018,
                            false => 26019,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26020,
                            false => 26021,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26022,
                            false => 26023,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26024,
                            false => 26025,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26026,
                            false => 26027,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26028,
                            false => 26029,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26030,
                            false => 26031,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26032,
                            false => 26033,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26034,
                            false => 26035,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26036,
                            false => 26037,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26038,
                            false => 26039,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26040,
                            false => 26041,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26042,
                            false => 26043,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26044,
                            false => 26045,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26046,
                            false => 26047,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26048,
                            false => 26049,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26050,
                            false => 26051,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26052,
                            false => 26053,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26054,
                            false => 26055,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26056,
                            false => 26057,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26058,
                            false => 26059,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26060,
                            false => 26061,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26062,
                            false => 26063,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26064,
                            false => 26065,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26066,
                            false => 26067,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26068,
                            false => 26069,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26070,
                            false => 26071,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26072,
                            false => 26073,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26074,
                            false => 26075,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26076,
                            false => 26077,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26078,
                            false => 26079,
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
            26000 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26001 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26002 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26003 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26004 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26005 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26006 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26007 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26008 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26009 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26010 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26011 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26012 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26013 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26014 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26015 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26016 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26017 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26018 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26019 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26020 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26021 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26022 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26023 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26024 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26025 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26026 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26027 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26028 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26029 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26030 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26031 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26032 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26033 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26034 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26035 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26036 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26037 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26038 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26039 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26040 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26041 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26042 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26043 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26044 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26045 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26046 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26047 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26048 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26049 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26050 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26051 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26052 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26053 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26054 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26055 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26056 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26057 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26058 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26059 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26060 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26061 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26062 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26063 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26064 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26065 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26066 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26067 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26068 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26069 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26070 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26071 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26072 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26073 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26074 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26075 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26076 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26077 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26078 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26079 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
