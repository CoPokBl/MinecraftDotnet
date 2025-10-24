using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakStairsBlock(Identifier Identifier, Direction Facing, DarkOakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 516;
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
    public Identifier? Item => "minecraft:dark_oak_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11930,
                            false => 11931,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11932,
                            false => 11933,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11934,
                            false => 11935,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11936,
                            false => 11937,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11938,
                            false => 11939,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11940,
                            false => 11941,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11942,
                            false => 11943,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11944,
                            false => 11945,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11946,
                            false => 11947,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11948,
                            false => 11949,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11950,
                            false => 11951,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11952,
                            false => 11953,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11954,
                            false => 11955,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11956,
                            false => 11957,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11958,
                            false => 11959,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11960,
                            false => 11961,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11962,
                            false => 11963,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11964,
                            false => 11965,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11966,
                            false => 11967,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11968,
                            false => 11969,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11970,
                            false => 11971,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11972,
                            false => 11973,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11974,
                            false => 11975,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11976,
                            false => 11977,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11978,
                            false => 11979,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11980,
                            false => 11981,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11982,
                            false => 11983,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11984,
                            false => 11985,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11986,
                            false => 11987,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11988,
                            false => 11989,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11990,
                            false => 11991,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11992,
                            false => 11993,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11994,
                            false => 11995,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11996,
                            false => 11997,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11998,
                            false => 11999,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12000,
                            false => 12001,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12002,
                            false => 12003,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12004,
                            false => 12005,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12006,
                            false => 12007,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12008,
                            false => 12009,
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
            11930 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11931 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11932 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11933 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11934 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11935 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11936 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11937 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11938 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11939 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11940 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11941 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11942 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11943 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11944 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11945 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11946 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11947 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11948 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11949 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11950 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11951 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11952 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11953 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11954 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11955 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11956 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11957 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11958 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11959 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11960 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11961 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11962 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11963 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11964 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11965 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11966 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11967 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11968 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11969 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11970 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11971 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11972 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11973 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11974 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11975 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11976 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11977 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11978 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11979 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11980 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11981 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11982 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11983 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11984 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11985 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11986 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11987 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11988 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11989 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11990 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11991 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11992 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11993 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11994 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11995 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11996 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11997 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11998 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11999 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12000 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12001 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12002 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12003 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12004 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12005 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12006 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12007 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12008 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12009 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.ChildrenMap.ContainsKey("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
