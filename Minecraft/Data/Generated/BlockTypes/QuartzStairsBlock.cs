using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record QuartzStairsBlock(Identifier Identifier, Direction Facing, QuartzStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 479;
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
    public Identifier? Item => "minecraft:quartz_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.quartz_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11126,
                            false => 11127,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11128,
                            false => 11129,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11130,
                            false => 11131,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11132,
                            false => 11133,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11134,
                            false => 11135,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11136,
                            false => 11137,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11138,
                            false => 11139,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11140,
                            false => 11141,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11142,
                            false => 11143,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11144,
                            false => 11145,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11146,
                            false => 11147,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11148,
                            false => 11149,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11150,
                            false => 11151,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11152,
                            false => 11153,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11154,
                            false => 11155,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11156,
                            false => 11157,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11158,
                            false => 11159,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11160,
                            false => 11161,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11162,
                            false => 11163,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11164,
                            false => 11165,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11166,
                            false => 11167,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11168,
                            false => 11169,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11170,
                            false => 11171,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11172,
                            false => 11173,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11174,
                            false => 11175,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11176,
                            false => 11177,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11178,
                            false => 11179,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11180,
                            false => 11181,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11182,
                            false => 11183,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11184,
                            false => 11185,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11186,
                            false => 11187,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11188,
                            false => 11189,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11190,
                            false => 11191,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11192,
                            false => 11193,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11194,
                            false => 11195,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11196,
                            false => 11197,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11198,
                            false => 11199,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11200,
                            false => 11201,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11202,
                            false => 11203,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11204,
                            false => 11205,
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
            11126 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11127 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11128 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11129 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11130 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11131 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11132 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11133 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11134 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11135 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11136 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11137 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11138 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11139 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11140 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11141 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11142 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11143 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11144 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11145 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11146 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11147 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11148 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11149 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11150 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11151 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11152 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11153 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11154 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11155 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11156 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11157 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11158 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11159 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11160 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11161 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11162 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11163 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11164 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11165 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11166 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11167 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11168 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11169 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11170 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11171 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11172 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11173 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11174 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11175 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11176 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11177 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11178 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11179 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11180 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11181 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11182 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11183 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11184 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11185 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11186 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11187 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11188 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11189 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11190 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11191 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11192 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11193 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11194 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11195 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11196 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11197 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11198 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11199 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11200 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11201 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11202 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11203 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11204 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11205 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
