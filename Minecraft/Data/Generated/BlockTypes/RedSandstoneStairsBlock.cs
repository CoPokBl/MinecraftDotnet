using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedSandstoneStairsBlock(Identifier Identifier, Direction Facing, RedSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 596;
    public double Hardness => 0.8;
    public double ExplosionResistance => 0.8;
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
    public Identifier? Item => "minecraft:red_sandstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.red_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13048,
                            false => 13049,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13050,
                            false => 13051,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13052,
                            false => 13053,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13054,
                            false => 13055,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13056,
                            false => 13057,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13058,
                            false => 13059,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13060,
                            false => 13061,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13062,
                            false => 13063,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13064,
                            false => 13065,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13066,
                            false => 13067,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13068,
                            false => 13069,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13070,
                            false => 13071,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13072,
                            false => 13073,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13074,
                            false => 13075,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13076,
                            false => 13077,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13078,
                            false => 13079,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13080,
                            false => 13081,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13082,
                            false => 13083,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13084,
                            false => 13085,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13086,
                            false => 13087,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13088,
                            false => 13089,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13090,
                            false => 13091,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13092,
                            false => 13093,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13094,
                            false => 13095,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13096,
                            false => 13097,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13098,
                            false => 13099,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13100,
                            false => 13101,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13102,
                            false => 13103,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13104,
                            false => 13105,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13106,
                            false => 13107,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13108,
                            false => 13109,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13110,
                            false => 13111,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13112,
                            false => 13113,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13114,
                            false => 13115,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13116,
                            false => 13117,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13118,
                            false => 13119,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13120,
                            false => 13121,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13122,
                            false => 13123,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13124,
                            false => 13125,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13126,
                            false => 13127,
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
            13048 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            13049 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            13050 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            13051 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            13052 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            13053 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            13054 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            13055 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            13056 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            13057 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            13058 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            13059 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            13060 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            13061 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            13062 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            13063 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            13064 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            13065 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            13066 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            13067 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            13068 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            13069 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            13070 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            13071 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            13072 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            13073 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            13074 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            13075 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            13076 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            13077 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            13078 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            13079 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            13080 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            13081 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            13082 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            13083 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            13084 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            13085 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            13086 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            13087 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            13088 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            13089 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            13090 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            13091 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            13092 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            13093 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            13094 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            13095 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            13096 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            13097 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            13098 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            13099 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            13100 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            13101 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            13102 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            13103 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            13104 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            13105 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            13106 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            13107 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            13108 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            13109 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            13110 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            13111 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            13112 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            13113 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            13114 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            13115 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            13116 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            13117 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            13118 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            13119 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            13120 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            13121 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            13122 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            13123 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            13124 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            13125 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            13126 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            13127 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
