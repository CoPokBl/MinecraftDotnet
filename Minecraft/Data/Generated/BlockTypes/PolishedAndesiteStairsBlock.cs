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
    public int ProtocolId => 807;
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
                            true => 16054,
                            false => 16055,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16056,
                            false => 16057,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16058,
                            false => 16059,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16060,
                            false => 16061,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16062,
                            false => 16063,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16064,
                            false => 16065,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16066,
                            false => 16067,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16068,
                            false => 16069,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16070,
                            false => 16071,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16072,
                            false => 16073,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16074,
                            false => 16075,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16076,
                            false => 16077,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16078,
                            false => 16079,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16080,
                            false => 16081,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16082,
                            false => 16083,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16084,
                            false => 16085,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16086,
                            false => 16087,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16088,
                            false => 16089,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16090,
                            false => 16091,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16092,
                            false => 16093,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16094,
                            false => 16095,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16096,
                            false => 16097,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16098,
                            false => 16099,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16100,
                            false => 16101,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16102,
                            false => 16103,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16104,
                            false => 16105,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16106,
                            false => 16107,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16108,
                            false => 16109,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16110,
                            false => 16111,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16112,
                            false => 16113,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16114,
                            false => 16115,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16116,
                            false => 16117,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16118,
                            false => 16119,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16120,
                            false => 16121,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16122,
                            false => 16123,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16124,
                            false => 16125,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16126,
                            false => 16127,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16128,
                            false => 16129,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16130,
                            false => 16131,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16132,
                            false => 16133,
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
            16054 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16055 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16056 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16057 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16058 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16059 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16060 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16061 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16062 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16063 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16064 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16065 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16066 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16067 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16068 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16069 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16070 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16071 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16072 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16073 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16074 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16075 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16076 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16077 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16078 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16079 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16080 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16081 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16082 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16083 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16084 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16085 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16086 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16087 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16088 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16089 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16090 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16091 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16092 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16093 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16094 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16095 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16096 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16097 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16098 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16099 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16100 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16101 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16102 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16103 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16104 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16105 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16106 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16107 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16108 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16109 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16110 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16111 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16112 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16113 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16114 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16115 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16116 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16117 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16118 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16119 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16120 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16121 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16122 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16123 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16124 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16125 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16126 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16127 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16128 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16129 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16130 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16131 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16132 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16133 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
