using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_cut_copper_stairs";
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
    public string TranslationKey => "block.minecraft.waxed_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28128,
                            false => 28129,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28130,
                            false => 28131,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28132,
                            false => 28133,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28134,
                            false => 28135,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28136,
                            false => 28137,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28138,
                            false => 28139,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28140,
                            false => 28141,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28142,
                            false => 28143,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28144,
                            false => 28145,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28146,
                            false => 28147,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28148,
                            false => 28149,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28150,
                            false => 28151,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28152,
                            false => 28153,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28154,
                            false => 28155,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28156,
                            false => 28157,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28158,
                            false => 28159,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28160,
                            false => 28161,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28162,
                            false => 28163,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28164,
                            false => 28165,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28166,
                            false => 28167,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28168,
                            false => 28169,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28170,
                            false => 28171,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28172,
                            false => 28173,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28174,
                            false => 28175,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28176,
                            false => 28177,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28178,
                            false => 28179,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28180,
                            false => 28181,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28182,
                            false => 28183,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28184,
                            false => 28185,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28186,
                            false => 28187,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28188,
                            false => 28189,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28190,
                            false => 28191,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28192,
                            false => 28193,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28194,
                            false => 28195,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28196,
                            false => 28197,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28198,
                            false => 28199,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28200,
                            false => 28201,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28202,
                            false => 28203,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28204,
                            false => 28205,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28206,
                            false => 28207,
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
            28128 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28129 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28130 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28131 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28132 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28133 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28134 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28135 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28136 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28137 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28138 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28139 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28140 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28141 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28142 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28143 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28144 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28145 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28146 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28147 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28148 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28149 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28150 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28151 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28152 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28153 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28154 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28155 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28156 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28157 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28158 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28159 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28160 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28161 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28162 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28163 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28164 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28165 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28166 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28167 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28168 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28169 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28170 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28171 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28172 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28173 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28174 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28175 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28176 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28177 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28178 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28179 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28180 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28181 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28182 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28183 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28184 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28185 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28186 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28187 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28188 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28189 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28190 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28191 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28192 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28193 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28194 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28195 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28196 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28197 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28198 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28199 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28200 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28201 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28202 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28203 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28204 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28205 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28206 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28207 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
