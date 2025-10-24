using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DioriteStairsBlock(Identifier Identifier, Direction Facing, DioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 808;
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
    public Identifier? Item => "minecraft:diorite_stairs";
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
    public string TranslationKey => "block.minecraft.diorite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16134,
                            false => 16135,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16136,
                            false => 16137,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16138,
                            false => 16139,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16140,
                            false => 16141,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16142,
                            false => 16143,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16144,
                            false => 16145,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16146,
                            false => 16147,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16148,
                            false => 16149,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16150,
                            false => 16151,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16152,
                            false => 16153,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16154,
                            false => 16155,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16156,
                            false => 16157,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16158,
                            false => 16159,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16160,
                            false => 16161,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16162,
                            false => 16163,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16164,
                            false => 16165,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16166,
                            false => 16167,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16168,
                            false => 16169,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16170,
                            false => 16171,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16172,
                            false => 16173,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16174,
                            false => 16175,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16176,
                            false => 16177,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16178,
                            false => 16179,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16180,
                            false => 16181,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16182,
                            false => 16183,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16184,
                            false => 16185,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16186,
                            false => 16187,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16188,
                            false => 16189,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16190,
                            false => 16191,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16192,
                            false => 16193,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16194,
                            false => 16195,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16196,
                            false => 16197,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16198,
                            false => 16199,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16200,
                            false => 16201,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16202,
                            false => 16203,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16204,
                            false => 16205,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16206,
                            false => 16207,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16208,
                            false => 16209,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16210,
                            false => 16211,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16212,
                            false => 16213,
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
            16134 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16135 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16136 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16137 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16138 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16139 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16140 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16141 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16142 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16143 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16144 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16145 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16146 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16147 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16148 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16149 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16150 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16151 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16152 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16153 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16154 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16155 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16156 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16157 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16158 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16159 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16160 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16161 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16162 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16163 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16164 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16165 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16166 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16167 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16168 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16169 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16170 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16171 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16172 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16173 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16174 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16175 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16176 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16177 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16178 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16179 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16180 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16181 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16182 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16183 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16184 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16185 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16186 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16187 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16188 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16189 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16190 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16191 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16192 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16193 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16194 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16195 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16196 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16197 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16198 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16199 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16200 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16201 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16202 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16203 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16204 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16205 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16206 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16207 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16208 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16209 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16210 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16211 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16212 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16213 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
