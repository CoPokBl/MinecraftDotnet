using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedNetherBrickStairsBlock(Identifier Identifier, Direction Facing, RedNetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 806;
    public double Hardness => 2;
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
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:red_nether_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.red_nether_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15974,
                            false => 15975,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15976,
                            false => 15977,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15978,
                            false => 15979,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15980,
                            false => 15981,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15982,
                            false => 15983,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15984,
                            false => 15985,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15986,
                            false => 15987,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15988,
                            false => 15989,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15990,
                            false => 15991,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15992,
                            false => 15993,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15994,
                            false => 15995,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15996,
                            false => 15997,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15998,
                            false => 15999,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16000,
                            false => 16001,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16002,
                            false => 16003,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16004,
                            false => 16005,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16006,
                            false => 16007,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16008,
                            false => 16009,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16010,
                            false => 16011,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16012,
                            false => 16013,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16014,
                            false => 16015,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16016,
                            false => 16017,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16018,
                            false => 16019,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16020,
                            false => 16021,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16022,
                            false => 16023,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16024,
                            false => 16025,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16026,
                            false => 16027,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16028,
                            false => 16029,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16030,
                            false => 16031,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16032,
                            false => 16033,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16034,
                            false => 16035,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16036,
                            false => 16037,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16038,
                            false => 16039,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16040,
                            false => 16041,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16042,
                            false => 16043,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16044,
                            false => 16045,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16046,
                            false => 16047,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16048,
                            false => 16049,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16050,
                            false => 16051,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16052,
                            false => 16053,
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
            15974 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15975 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15976 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15977 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15978 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15979 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15980 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15981 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15982 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15983 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15984 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15985 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15986 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15987 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15988 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15989 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15990 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15991 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15992 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15993 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15994 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15995 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15996 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15997 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15998 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15999 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16000 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16001 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16002 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16003 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16004 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16005 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16006 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16007 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16008 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16009 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16010 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16011 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16012 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16013 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16014 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16015 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16016 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16017 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16018 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16019 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16020 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16021 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16022 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16023 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16024 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16025 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16026 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16027 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16028 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16029 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16030 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16031 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16032 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16033 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16034 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16035 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16036 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16037 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16038 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16039 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16040 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16041 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16042 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16043 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16044 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16045 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16046 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16047 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16048 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16049 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16050 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16051 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16052 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16053 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
