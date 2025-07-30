using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedAndesiteStairsBlock(Identifier Identifier, Direction Facing, PolishedAndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 777;
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
    public Identifier? Item => "minecraft:polished_andesite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.polished_andesite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14977,
                            false => 14978,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14979,
                            false => 14980,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14981,
                            false => 14982,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14983,
                            false => 14984,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14985,
                            false => 14986,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14987,
                            false => 14988,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14989,
                            false => 14990,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14991,
                            false => 14992,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14993,
                            false => 14994,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14995,
                            false => 14996,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14997,
                            false => 14998,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14999,
                            false => 15000,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15001,
                            false => 15002,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15003,
                            false => 15004,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15005,
                            false => 15006,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15007,
                            false => 15008,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15009,
                            false => 15010,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15011,
                            false => 15012,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15013,
                            false => 15014,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15015,
                            false => 15016,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15017,
                            false => 15018,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15019,
                            false => 15020,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15021,
                            false => 15022,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15023,
                            false => 15024,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15025,
                            false => 15026,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15027,
                            false => 15028,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15029,
                            false => 15030,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15031,
                            false => 15032,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15033,
                            false => 15034,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15035,
                            false => 15036,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15037,
                            false => 15038,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15039,
                            false => 15040,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15041,
                            false => 15042,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15043,
                            false => 15044,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15045,
                            false => 15046,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15047,
                            false => 15048,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15049,
                            false => 15050,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15051,
                            false => 15052,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15053,
                            false => 15054,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15055,
                            false => 15056,
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
            14977 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14978 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14979 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14980 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14981 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14982 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14983 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14984 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14985 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14986 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14987 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14988 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14989 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14990 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14991 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14992 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14993 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14994 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14995 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14996 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14997 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14998 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14999 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15000 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15001 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15002 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15003 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15004 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15005 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15006 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15007 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15008 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15009 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15010 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15011 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15012 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15013 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15014 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15015 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15016 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15017 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15018 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15019 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15020 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15021 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15022 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15023 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15024 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15025 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15026 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15027 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15028 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15029 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15030 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15031 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15032 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15033 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15034 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15035 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15036 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15037 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15038 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15039 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15040 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15041 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15042 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15043 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15044 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15045 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15046 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15047 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15048 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15049 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15050 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15051 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15052 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15053 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15054 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15055 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15056 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
