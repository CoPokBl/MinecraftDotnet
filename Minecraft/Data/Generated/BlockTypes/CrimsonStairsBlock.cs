using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonStairsBlock(Identifier Identifier, Direction Facing, CrimsonStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19963,
                            false => 19964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19965,
                            false => 19966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19967,
                            false => 19968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19969,
                            false => 19970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19971,
                            false => 19972,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19973,
                            false => 19974,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19975,
                            false => 19976,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19977,
                            false => 19978,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19979,
                            false => 19980,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19981,
                            false => 19982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19983,
                            false => 19984,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19985,
                            false => 19986,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19987,
                            false => 19988,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19989,
                            false => 19990,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19991,
                            false => 19992,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19993,
                            false => 19994,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19995,
                            false => 19996,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19997,
                            false => 19998,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19999,
                            false => 20000,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20001,
                            false => 20002,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20003,
                            false => 20004,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20005,
                            false => 20006,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20007,
                            false => 20008,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20009,
                            false => 20010,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20011,
                            false => 20012,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20013,
                            false => 20014,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20015,
                            false => 20016,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20017,
                            false => 20018,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20019,
                            false => 20020,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20021,
                            false => 20022,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20023,
                            false => 20024,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20025,
                            false => 20026,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20027,
                            false => 20028,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20029,
                            false => 20030,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20031,
                            false => 20032,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20033,
                            false => 20034,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20035,
                            false => 20036,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20037,
                            false => 20038,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20039,
                            false => 20040,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20041,
                            false => 20042,
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
            19963 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            19964 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            19965 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            19966 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            19967 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            19968 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            19969 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            19970 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            19971 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            19972 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            19973 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            19974 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            19975 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            19976 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            19977 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            19978 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            19979 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            19980 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            19981 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            19982 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            19983 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            19984 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            19985 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            19986 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            19987 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            19988 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            19989 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            19990 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            19991 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            19992 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            19993 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            19994 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            19995 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            19996 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            19997 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            19998 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            19999 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20000 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20001 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20002 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20003 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20004 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20005 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20006 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20007 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20008 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20009 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20010 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20011 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20012 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20013 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20014 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20015 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20016 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20017 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20018 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20019 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20020 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20021 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20022 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20023 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20024 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20025 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20026 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20027 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20028 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20029 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20030 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20031 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20032 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20033 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20034 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20035 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20036 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20037 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20038 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20039 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20040 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20041 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20042 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
