using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GraniteStairsBlock(Identifier Identifier, Direction Facing, GraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:granite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.granite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16016,
                            false => 16017,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16018,
                            false => 16019,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16020,
                            false => 16021,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16022,
                            false => 16023,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16024,
                            false => 16025,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16026,
                            false => 16027,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16028,
                            false => 16029,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16030,
                            false => 16031,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16032,
                            false => 16033,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16034,
                            false => 16035,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16036,
                            false => 16037,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16038,
                            false => 16039,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16040,
                            false => 16041,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16042,
                            false => 16043,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16044,
                            false => 16045,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16046,
                            false => 16047,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16048,
                            false => 16049,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16050,
                            false => 16051,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16052,
                            false => 16053,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16054,
                            false => 16055,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16056,
                            false => 16057,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16058,
                            false => 16059,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16060,
                            false => 16061,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16062,
                            false => 16063,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16064,
                            false => 16065,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16066,
                            false => 16067,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16068,
                            false => 16069,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16070,
                            false => 16071,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16072,
                            false => 16073,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16074,
                            false => 16075,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16076,
                            false => 16077,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16078,
                            false => 16079,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16080,
                            false => 16081,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16082,
                            false => 16083,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16084,
                            false => 16085,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16086,
                            false => 16087,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16088,
                            false => 16089,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16090,
                            false => 16091,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16092,
                            false => 16093,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16094,
                            false => 16095,
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
            16016 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16017 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16018 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16019 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16020 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16021 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16022 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16023 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16024 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16025 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16026 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16027 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16028 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16029 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16030 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16031 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16032 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16033 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16034 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16035 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16036 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16037 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16038 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16039 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16040 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16041 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16042 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16043 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16044 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16045 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16046 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16047 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16048 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16049 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16050 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16051 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16052 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16053 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16054 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16055 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16056 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16057 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16058 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16059 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16060 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16061 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16062 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16063 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16064 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16065 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16066 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16067 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16068 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16069 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16070 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16071 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16072 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16073 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16074 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16075 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16076 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16077 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16078 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16079 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16080 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16081 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16082 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16083 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16084 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16085 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16086 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16087 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16088 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16089 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16090 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16091 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16092 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16093 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16094 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16095 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
