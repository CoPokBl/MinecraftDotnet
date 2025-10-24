using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateBrickStairsBlock(Identifier Identifier, Direction Facing, DeepslateBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1135;
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
    public string SoundType => "deepslate_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:deepslate_brick_stairs";
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
    public string TranslationKey => "block.minecraft.deepslate_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28958,
                            false => 28959,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28960,
                            false => 28961,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28962,
                            false => 28963,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28964,
                            false => 28965,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28966,
                            false => 28967,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28968,
                            false => 28969,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28970,
                            false => 28971,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28972,
                            false => 28973,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28974,
                            false => 28975,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28976,
                            false => 28977,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28978,
                            false => 28979,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28980,
                            false => 28981,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28982,
                            false => 28983,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28984,
                            false => 28985,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28986,
                            false => 28987,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28988,
                            false => 28989,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28990,
                            false => 28991,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28992,
                            false => 28993,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28994,
                            false => 28995,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28996,
                            false => 28997,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28998,
                            false => 28999,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29000,
                            false => 29001,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29002,
                            false => 29003,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29004,
                            false => 29005,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29006,
                            false => 29007,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29008,
                            false => 29009,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29010,
                            false => 29011,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29012,
                            false => 29013,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29014,
                            false => 29015,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29016,
                            false => 29017,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29018,
                            false => 29019,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29020,
                            false => 29021,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29022,
                            false => 29023,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29024,
                            false => 29025,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29026,
                            false => 29027,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29028,
                            false => 29029,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29030,
                            false => 29031,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29032,
                            false => 29033,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29034,
                            false => 29035,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29036,
                            false => 29037,
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
            28958 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28959 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28960 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28961 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28962 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28963 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28964 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28965 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28966 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28967 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28968 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28969 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28970 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28971 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28972 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28973 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28974 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28975 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28976 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28977 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28978 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28979 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28980 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28981 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28982 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28983 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28984 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28985 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28986 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28987 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28988 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28989 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28990 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28991 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28992 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28993 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28994 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28995 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28996 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28997 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28998 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28999 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            29000 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            29001 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            29002 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            29003 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            29004 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            29005 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            29006 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            29007 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            29008 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            29009 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            29010 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            29011 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            29012 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            29013 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            29014 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            29015 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            29016 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            29017 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            29018 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            29019 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            29020 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            29021 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            29022 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            29023 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            29024 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            29025 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            29026 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            29027 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            29028 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            29029 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            29030 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            29031 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            29032 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            29033 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            29034 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            29035 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            29036 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            29037 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
