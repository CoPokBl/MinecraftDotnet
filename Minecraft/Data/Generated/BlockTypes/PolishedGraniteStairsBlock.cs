using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedGraniteStairsBlock(Identifier Identifier, Direction Facing, PolishedGraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 795;
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
    public Identifier? Item => "minecraft:polished_granite_stairs";
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
    public string TranslationKey => "block.minecraft.polished_granite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15094,
                            false => 15095,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15096,
                            false => 15097,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15098,
                            false => 15099,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15100,
                            false => 15101,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15102,
                            false => 15103,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15104,
                            false => 15105,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15106,
                            false => 15107,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15108,
                            false => 15109,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15110,
                            false => 15111,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15112,
                            false => 15113,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15114,
                            false => 15115,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15116,
                            false => 15117,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15118,
                            false => 15119,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15120,
                            false => 15121,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15122,
                            false => 15123,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15124,
                            false => 15125,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15126,
                            false => 15127,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15128,
                            false => 15129,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15130,
                            false => 15131,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15132,
                            false => 15133,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15134,
                            false => 15135,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15136,
                            false => 15137,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15138,
                            false => 15139,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15140,
                            false => 15141,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15142,
                            false => 15143,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15144,
                            false => 15145,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15146,
                            false => 15147,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15148,
                            false => 15149,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15150,
                            false => 15151,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15152,
                            false => 15153,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15154,
                            false => 15155,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15156,
                            false => 15157,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15158,
                            false => 15159,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15160,
                            false => 15161,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15162,
                            false => 15163,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15164,
                            false => 15165,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15166,
                            false => 15167,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15168,
                            false => 15169,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15170,
                            false => 15171,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15172,
                            false => 15173,
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
            15094 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15095 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15096 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15097 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15098 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15099 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15100 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15101 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15102 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15103 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15104 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15105 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15106 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15107 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15108 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15109 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15110 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15111 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15112 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15113 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15114 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15115 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15116 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15117 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15118 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15119 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15120 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15121 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15122 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15123 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15124 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15125 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15126 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15127 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15128 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15129 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15130 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15131 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15132 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15133 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15134 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15135 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15136 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15137 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15138 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15139 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15140 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15141 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15142 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15143 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15144 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15145 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15146 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15147 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15148 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15149 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15150 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15151 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15152 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15153 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15154 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15155 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15156 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15157 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15158 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15159 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15160 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15161 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15162 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15163 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15164 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15165 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15166 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15167 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15168 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15169 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15170 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15171 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15172 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15173 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
