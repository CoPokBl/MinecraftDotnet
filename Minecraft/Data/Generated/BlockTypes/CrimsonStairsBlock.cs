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

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 855;
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
                            true => 19995,
                            false => 19996,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19997,
                            false => 19998,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19999,
                            false => 20000,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20001,
                            false => 20002,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20003,
                            false => 20004,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20005,
                            false => 20006,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20007,
                            false => 20008,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20009,
                            false => 20010,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20011,
                            false => 20012,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20013,
                            false => 20014,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20015,
                            false => 20016,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20017,
                            false => 20018,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20019,
                            false => 20020,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20021,
                            false => 20022,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20023,
                            false => 20024,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20025,
                            false => 20026,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20027,
                            false => 20028,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20029,
                            false => 20030,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20031,
                            false => 20032,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20033,
                            false => 20034,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20035,
                            false => 20036,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20037,
                            false => 20038,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20039,
                            false => 20040,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20041,
                            false => 20042,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20043,
                            false => 20044,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20045,
                            false => 20046,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20047,
                            false => 20048,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20049,
                            false => 20050,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20051,
                            false => 20052,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20053,
                            false => 20054,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20055,
                            false => 20056,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20057,
                            false => 20058,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20059,
                            false => 20060,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20061,
                            false => 20062,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20063,
                            false => 20064,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20065,
                            false => 20066,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20067,
                            false => 20068,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20069,
                            false => 20070,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20071,
                            false => 20072,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20073,
                            false => 20074,
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
            19995 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            19996 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            19997 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            19998 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            19999 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20000 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20001 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20002 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20003 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20004 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20005 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20006 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20007 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20008 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20009 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20010 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20011 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20012 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20013 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20014 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20015 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20016 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20017 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20018 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20019 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20020 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20021 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20022 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20023 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20024 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20025 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20026 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20027 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20028 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20029 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20030 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20031 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20032 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20033 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20034 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20035 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20036 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20037 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20038 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20039 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20040 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20041 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20042 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20043 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20044 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20045 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20046 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20047 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20048 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20049 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20050 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20051 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20052 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20053 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20054 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20055 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20056 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20057 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20058 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20059 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20060 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20061 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20062 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20063 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20064 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20065 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20066 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20067 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20068 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20069 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20070 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20071 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20072 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20073 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20074 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("shape", Shape.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
