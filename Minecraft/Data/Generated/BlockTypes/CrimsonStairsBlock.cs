using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonStairsBlock(Identifier Identifier, Direction Facing, CrimsonStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 893;
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21104,
                            false => 21105,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21106,
                            false => 21107,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21108,
                            false => 21109,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21110,
                            false => 21111,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21112,
                            false => 21113,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21114,
                            false => 21115,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21116,
                            false => 21117,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21118,
                            false => 21119,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21120,
                            false => 21121,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21122,
                            false => 21123,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21124,
                            false => 21125,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21126,
                            false => 21127,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21128,
                            false => 21129,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21130,
                            false => 21131,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21132,
                            false => 21133,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21134,
                            false => 21135,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21136,
                            false => 21137,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21138,
                            false => 21139,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21140,
                            false => 21141,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21142,
                            false => 21143,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21144,
                            false => 21145,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21146,
                            false => 21147,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21148,
                            false => 21149,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21150,
                            false => 21151,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21152,
                            false => 21153,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21154,
                            false => 21155,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21156,
                            false => 21157,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21158,
                            false => 21159,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21160,
                            false => 21161,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21162,
                            false => 21163,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21164,
                            false => 21165,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21166,
                            false => 21167,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21168,
                            false => 21169,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21170,
                            false => 21171,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21172,
                            false => 21173,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21174,
                            false => 21175,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21176,
                            false => 21177,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21178,
                            false => 21179,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21180,
                            false => 21181,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21182,
                            false => 21183,
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
            21104 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21105 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21106 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21107 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21108 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21109 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21110 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21111 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21112 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21113 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21114 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21115 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21116 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21117 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21118 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21119 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21120 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21121 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21122 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21123 => new CrimsonStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21124 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21125 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21126 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21127 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21128 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21129 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21130 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21131 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21132 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21133 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21134 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21135 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21136 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21137 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21138 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21139 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21140 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21141 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21142 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21143 => new CrimsonStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21144 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21145 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21146 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21147 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21148 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21149 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21150 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21151 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21152 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21153 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21154 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21155 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21156 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21157 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21158 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21159 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21160 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21161 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21162 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21163 => new CrimsonStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21164 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21165 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21166 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21167 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21168 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21169 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21170 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21171 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21172 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21173 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21174 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21175 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21176 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21177 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21178 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21179 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21180 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21181 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21182 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21183 => new CrimsonStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
