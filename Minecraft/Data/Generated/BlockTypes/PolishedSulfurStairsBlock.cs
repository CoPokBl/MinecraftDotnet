using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedSulfurStairsBlock(Identifier Identifier, Direction Facing, PolishedSulfurStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "sulfur";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_sulfur_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.polished_sulfur_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25110,
                            false => 25111,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25112,
                            false => 25113,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25114,
                            false => 25115,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25116,
                            false => 25117,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25118,
                            false => 25119,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25120,
                            false => 25121,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25122,
                            false => 25123,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25124,
                            false => 25125,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25126,
                            false => 25127,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25128,
                            false => 25129,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25130,
                            false => 25131,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25132,
                            false => 25133,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25134,
                            false => 25135,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25136,
                            false => 25137,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25138,
                            false => 25139,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25140,
                            false => 25141,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25142,
                            false => 25143,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25144,
                            false => 25145,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25146,
                            false => 25147,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25148,
                            false => 25149,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25150,
                            false => 25151,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25152,
                            false => 25153,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25154,
                            false => 25155,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25156,
                            false => 25157,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25158,
                            false => 25159,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25160,
                            false => 25161,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25162,
                            false => 25163,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25164,
                            false => 25165,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25166,
                            false => 25167,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25168,
                            false => 25169,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25170,
                            false => 25171,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25172,
                            false => 25173,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25174,
                            false => 25175,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25176,
                            false => 25177,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25178,
                            false => 25179,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25180,
                            false => 25181,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25182,
                            false => 25183,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25184,
                            false => 25185,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25186,
                            false => 25187,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25188,
                            false => 25189,
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
            25110 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25111 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25112 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25113 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25114 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25115 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25116 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25117 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25118 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25119 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25120 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25121 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25122 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25123 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25124 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25125 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25126 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25127 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25128 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25129 => new PolishedSulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25130 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25131 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25132 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25133 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25134 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25135 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25136 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25137 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25138 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25139 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25140 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25141 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25142 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25143 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25144 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25145 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25146 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25147 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25148 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25149 => new PolishedSulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25150 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25151 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25152 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25153 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25154 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25155 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25156 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25157 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25158 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25159 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25160 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25161 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25162 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25163 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25164 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25165 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25166 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25167 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25168 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25169 => new PolishedSulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25170 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25171 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25172 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25173 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25174 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25175 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25176 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            25177 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            25178 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            25179 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            25180 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            25181 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            25182 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            25183 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            25184 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            25185 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            25186 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            25187 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            25188 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            25189 => new PolishedSulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
