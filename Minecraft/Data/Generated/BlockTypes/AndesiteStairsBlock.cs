using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AndesiteStairsBlock(Identifier Identifier, Direction Facing, AndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:andesite_stairs";
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
    public string TranslationKey => "block.minecraft.andesite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16096,
                            false => 16097,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16098,
                            false => 16099,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16100,
                            false => 16101,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16102,
                            false => 16103,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16104,
                            false => 16105,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16106,
                            false => 16107,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16108,
                            false => 16109,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16110,
                            false => 16111,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16112,
                            false => 16113,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16114,
                            false => 16115,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16116,
                            false => 16117,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16118,
                            false => 16119,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16120,
                            false => 16121,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16122,
                            false => 16123,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16124,
                            false => 16125,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16126,
                            false => 16127,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16128,
                            false => 16129,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16130,
                            false => 16131,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16132,
                            false => 16133,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16134,
                            false => 16135,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16136,
                            false => 16137,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16138,
                            false => 16139,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16140,
                            false => 16141,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16142,
                            false => 16143,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16144,
                            false => 16145,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16146,
                            false => 16147,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16148,
                            false => 16149,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16150,
                            false => 16151,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16152,
                            false => 16153,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16154,
                            false => 16155,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16156,
                            false => 16157,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16158,
                            false => 16159,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16160,
                            false => 16161,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16162,
                            false => 16163,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16164,
                            false => 16165,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16166,
                            false => 16167,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16168,
                            false => 16169,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16170,
                            false => 16171,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16172,
                            false => 16173,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16174,
                            false => 16175,
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
            16096 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16097 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16098 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16099 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16100 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16101 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16102 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16103 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16104 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16105 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16106 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16107 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16108 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16109 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16110 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16111 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16112 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16113 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16114 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16115 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16116 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16117 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16118 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16119 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16120 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16121 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16122 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16123 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16124 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16125 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16126 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16127 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16128 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16129 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16130 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16131 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16132 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16133 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16134 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16135 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16136 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16137 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16138 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16139 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16140 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16141 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16142 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16143 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16144 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16145 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16146 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16147 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16148 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16149 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16150 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16151 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16152 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16153 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16154 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16155 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16156 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16157 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16158 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16159 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16160 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16161 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16162 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16163 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16164 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16165 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16166 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16167 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16168 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16169 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16170 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16171 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16172 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16173 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16174 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16175 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
