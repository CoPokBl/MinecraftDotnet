using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothRedSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothRedSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public double Hardness => 2;
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
    public Identifier? Item => "minecraft:smooth_red_sandstone_stairs";
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
    public string TranslationKey => "block.minecraft.smooth_red_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14097,
                            false => 14098,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14099,
                            false => 14100,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14101,
                            false => 14102,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14103,
                            false => 14104,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14105,
                            false => 14106,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14107,
                            false => 14108,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14109,
                            false => 14110,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14111,
                            false => 14112,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14113,
                            false => 14114,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14115,
                            false => 14116,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14117,
                            false => 14118,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14119,
                            false => 14120,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14121,
                            false => 14122,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14123,
                            false => 14124,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14125,
                            false => 14126,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14127,
                            false => 14128,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14129,
                            false => 14130,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14131,
                            false => 14132,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14133,
                            false => 14134,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14135,
                            false => 14136,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14137,
                            false => 14138,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14139,
                            false => 14140,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14141,
                            false => 14142,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14143,
                            false => 14144,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14145,
                            false => 14146,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14147,
                            false => 14148,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14149,
                            false => 14150,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14151,
                            false => 14152,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14153,
                            false => 14154,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14155,
                            false => 14156,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14157,
                            false => 14158,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14159,
                            false => 14160,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14161,
                            false => 14162,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14163,
                            false => 14164,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14165,
                            false => 14166,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14167,
                            false => 14168,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14169,
                            false => 14170,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14171,
                            false => 14172,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14173,
                            false => 14174,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14175,
                            false => 14176,
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
            14097 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14098 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14099 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14100 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14101 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14102 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14103 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14104 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14105 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14106 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14107 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14108 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14109 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14110 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14111 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14112 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14113 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14114 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14115 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14116 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14117 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14118 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14119 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14120 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14121 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14122 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14123 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14124 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14125 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14126 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14127 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14128 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14129 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14130 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14131 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14132 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14133 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14134 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14135 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14136 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14137 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14138 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14139 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14140 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14141 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14142 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14143 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14144 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14145 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14146 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14147 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14148 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14149 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14150 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14151 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14152 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14153 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14154 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14155 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14156 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14157 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14158 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14159 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14160 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14161 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14162 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14163 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14164 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14165 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14166 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14167 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14168 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14169 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14170 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14171 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14172 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14173 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14174 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14175 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14176 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
