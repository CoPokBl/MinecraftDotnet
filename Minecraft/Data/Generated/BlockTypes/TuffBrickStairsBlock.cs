using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffBrickStairsBlock(Identifier Identifier, Direction Facing, TuffBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 955;
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
    public string SoundType => "tuff_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tuff_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.tuff_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22971,
                            false => 22972,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22973,
                            false => 22974,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22975,
                            false => 22976,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22977,
                            false => 22978,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22979,
                            false => 22980,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22981,
                            false => 22982,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22983,
                            false => 22984,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22985,
                            false => 22986,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22987,
                            false => 22988,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22989,
                            false => 22990,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22991,
                            false => 22992,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22993,
                            false => 22994,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22995,
                            false => 22996,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22997,
                            false => 22998,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22999,
                            false => 23000,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23001,
                            false => 23002,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23003,
                            false => 23004,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23005,
                            false => 23006,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23007,
                            false => 23008,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23009,
                            false => 23010,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23011,
                            false => 23012,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23013,
                            false => 23014,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23015,
                            false => 23016,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23017,
                            false => 23018,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23019,
                            false => 23020,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23021,
                            false => 23022,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23023,
                            false => 23024,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23025,
                            false => 23026,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23027,
                            false => 23028,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23029,
                            false => 23030,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23031,
                            false => 23032,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23033,
                            false => 23034,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23035,
                            false => 23036,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23037,
                            false => 23038,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23039,
                            false => 23040,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23041,
                            false => 23042,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23043,
                            false => 23044,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23045,
                            false => 23046,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23047,
                            false => 23048,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23049,
                            false => 23050,
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
            22971 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22972 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22973 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22974 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22975 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22976 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22977 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22978 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22979 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22980 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22981 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22982 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22983 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22984 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22985 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22986 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22987 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22988 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22989 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22990 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22991 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22992 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22993 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22994 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22995 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22996 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22997 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22998 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22999 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            23000 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            23001 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            23002 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            23003 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            23004 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            23005 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            23006 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            23007 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            23008 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            23009 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            23010 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            23011 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            23012 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            23013 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            23014 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            23015 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            23016 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            23017 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            23018 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            23019 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            23020 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            23021 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            23022 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            23023 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            23024 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            23025 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            23026 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            23027 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            23028 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            23029 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            23030 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            23031 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23032 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23033 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23034 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23035 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23036 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23037 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23038 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23039 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23040 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23041 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23042 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23043 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23044 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23045 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23046 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23047 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23048 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23049 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23050 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
