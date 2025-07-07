using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveStairsBlock(Identifier Identifier, Direction Facing, MangroveStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:mangrove_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11013,
                            false => 11014,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11015,
                            false => 11016,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11017,
                            false => 11018,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11019,
                            false => 11020,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11021,
                            false => 11022,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11023,
                            false => 11024,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11025,
                            false => 11026,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11027,
                            false => 11028,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11029,
                            false => 11030,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11031,
                            false => 11032,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11033,
                            false => 11034,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11035,
                            false => 11036,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11037,
                            false => 11038,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11039,
                            false => 11040,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11041,
                            false => 11042,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11043,
                            false => 11044,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11045,
                            false => 11046,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11047,
                            false => 11048,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11049,
                            false => 11050,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11051,
                            false => 11052,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11053,
                            false => 11054,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11055,
                            false => 11056,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11057,
                            false => 11058,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11059,
                            false => 11060,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11061,
                            false => 11062,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11063,
                            false => 11064,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11065,
                            false => 11066,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11067,
                            false => 11068,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11069,
                            false => 11070,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11071,
                            false => 11072,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11073,
                            false => 11074,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11075,
                            false => 11076,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11077,
                            false => 11078,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11079,
                            false => 11080,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11081,
                            false => 11082,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11083,
                            false => 11084,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11085,
                            false => 11086,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11087,
                            false => 11088,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11089,
                            false => 11090,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11091,
                            false => 11092,
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
            11013 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11014 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11015 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11016 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11017 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11018 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11019 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11020 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11021 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11022 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11023 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11024 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11025 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11026 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11027 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11028 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11029 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11030 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11031 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11032 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11033 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11034 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11035 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11036 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11037 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11038 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11039 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11040 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11041 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11042 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11043 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11044 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11045 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11046 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11047 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11048 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11049 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11050 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11051 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11052 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11053 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11054 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11055 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11056 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11057 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11058 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11059 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11060 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11061 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11062 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11063 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11064 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11065 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11066 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11067 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11068 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11069 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11070 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11071 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11072 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11073 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11074 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11075 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11076 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11077 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11078 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11079 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11080 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11081 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11082 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11083 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11084 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11085 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11086 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11087 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11088 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11089 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11090 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11091 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11092 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
