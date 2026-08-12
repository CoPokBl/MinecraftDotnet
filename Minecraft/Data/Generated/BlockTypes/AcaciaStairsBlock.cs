using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaStairsBlock(Identifier Identifier, Direction Facing, AcaciaStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:acacia_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11972,
                            false => 11973,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11974,
                            false => 11975,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11976,
                            false => 11977,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11978,
                            false => 11979,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11980,
                            false => 11981,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11982,
                            false => 11983,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11984,
                            false => 11985,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11986,
                            false => 11987,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11988,
                            false => 11989,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11990,
                            false => 11991,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11992,
                            false => 11993,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11994,
                            false => 11995,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11996,
                            false => 11997,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11998,
                            false => 11999,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12000,
                            false => 12001,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12002,
                            false => 12003,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12004,
                            false => 12005,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12006,
                            false => 12007,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12008,
                            false => 12009,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12010,
                            false => 12011,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12012,
                            false => 12013,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12014,
                            false => 12015,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12016,
                            false => 12017,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12018,
                            false => 12019,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12020,
                            false => 12021,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12022,
                            false => 12023,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12024,
                            false => 12025,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12026,
                            false => 12027,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12028,
                            false => 12029,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12030,
                            false => 12031,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12032,
                            false => 12033,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12034,
                            false => 12035,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12036,
                            false => 12037,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12038,
                            false => 12039,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12040,
                            false => 12041,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12042,
                            false => 12043,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12044,
                            false => 12045,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12046,
                            false => 12047,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12048,
                            false => 12049,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12050,
                            false => 12051,
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
            11972 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11973 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11974 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11975 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11976 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11977 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11978 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11979 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11980 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11981 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11982 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11983 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11984 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11985 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11986 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11987 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11988 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11989 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11990 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11991 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11992 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11993 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11994 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11995 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11996 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11997 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11998 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11999 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12000 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12001 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12002 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12003 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12004 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12005 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12006 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12007 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12008 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12009 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12010 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12011 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12012 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12013 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12014 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12015 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12016 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12017 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12018 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12019 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12020 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12021 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12022 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12023 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12024 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12025 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12026 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12027 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12028 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12029 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12030 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12031 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12032 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12033 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12034 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12035 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12036 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12037 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12038 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12039 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12040 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12041 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12042 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12043 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12044 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12045 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12046 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12047 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12048 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12049 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12050 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12051 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
