using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneBrickStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 931;
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
    public Identifier? Item => "minecraft:polished_blackstone_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.polished_blackstone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22050,
                            false => 22051,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22052,
                            false => 22053,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22054,
                            false => 22055,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22056,
                            false => 22057,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22058,
                            false => 22059,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22060,
                            false => 22061,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22062,
                            false => 22063,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22064,
                            false => 22065,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22066,
                            false => 22067,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22068,
                            false => 22069,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22070,
                            false => 22071,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22072,
                            false => 22073,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22074,
                            false => 22075,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22076,
                            false => 22077,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22078,
                            false => 22079,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22080,
                            false => 22081,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22082,
                            false => 22083,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22084,
                            false => 22085,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22086,
                            false => 22087,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22088,
                            false => 22089,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22090,
                            false => 22091,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22092,
                            false => 22093,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22094,
                            false => 22095,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22096,
                            false => 22097,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22098,
                            false => 22099,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22100,
                            false => 22101,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22102,
                            false => 22103,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22104,
                            false => 22105,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22106,
                            false => 22107,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22108,
                            false => 22109,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22110,
                            false => 22111,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22112,
                            false => 22113,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22114,
                            false => 22115,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22116,
                            false => 22117,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22118,
                            false => 22119,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22120,
                            false => 22121,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22122,
                            false => 22123,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22124,
                            false => 22125,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22126,
                            false => 22127,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22128,
                            false => 22129,
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
            22050 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22051 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22052 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22053 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22054 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22055 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22056 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22057 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22058 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22059 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22060 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22061 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22062 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22063 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22064 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22065 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22066 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22067 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22068 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22069 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22070 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22071 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22072 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22073 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22074 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22075 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22076 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22077 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22078 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22079 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22080 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22081 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22082 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22083 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22084 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22085 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22086 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22087 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22088 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22089 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22090 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22091 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22092 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22093 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22094 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22095 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22096 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22097 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22098 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22099 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22100 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22101 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22102 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22103 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22104 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22105 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22106 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22107 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22108 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22109 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22110 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22111 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22112 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22113 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22114 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22115 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22116 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22117 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22118 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22119 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22120 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22121 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22122 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22123 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22124 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22125 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22126 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22127 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22128 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22129 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
