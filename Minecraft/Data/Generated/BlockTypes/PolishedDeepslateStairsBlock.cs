using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDeepslateStairsBlock(Identifier Identifier, Direction Facing, PolishedDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1127;
    public double Hardness => 3.5;
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
    public string SoundType => "polished_deepslate";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_deepslate_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.polished_deepslate_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28136,
                            false => 28137,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28138,
                            false => 28139,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28140,
                            false => 28141,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28142,
                            false => 28143,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28144,
                            false => 28145,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28146,
                            false => 28147,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28148,
                            false => 28149,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28150,
                            false => 28151,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28152,
                            false => 28153,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28154,
                            false => 28155,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28156,
                            false => 28157,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28158,
                            false => 28159,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28160,
                            false => 28161,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28162,
                            false => 28163,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28164,
                            false => 28165,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28166,
                            false => 28167,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28168,
                            false => 28169,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28170,
                            false => 28171,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28172,
                            false => 28173,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28174,
                            false => 28175,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28176,
                            false => 28177,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28178,
                            false => 28179,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28180,
                            false => 28181,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28182,
                            false => 28183,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28184,
                            false => 28185,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28186,
                            false => 28187,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28188,
                            false => 28189,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28190,
                            false => 28191,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28192,
                            false => 28193,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28194,
                            false => 28195,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28196,
                            false => 28197,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28198,
                            false => 28199,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28200,
                            false => 28201,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28202,
                            false => 28203,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28204,
                            false => 28205,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28206,
                            false => 28207,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28208,
                            false => 28209,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28210,
                            false => 28211,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28212,
                            false => 28213,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28214,
                            false => 28215,
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
            28136 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28137 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28138 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28139 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28140 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28141 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28142 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28143 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28144 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28145 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28146 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28147 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28148 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28149 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28150 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28151 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28152 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28153 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28154 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28155 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28156 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28157 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28158 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28159 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28160 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28161 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28162 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28163 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28164 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28165 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28166 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28167 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28168 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28169 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28170 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28171 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28172 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28173 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28174 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28175 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28176 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28177 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28178 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28179 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28180 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28181 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28182 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28183 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28184 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28185 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28186 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28187 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28188 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28189 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28190 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28191 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28192 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28193 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28194 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28195 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28196 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28197 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28198 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28199 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28200 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28201 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28202 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28203 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28204 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28205 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28206 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28207 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28208 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28209 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28210 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28211 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28212 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28213 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28214 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28215 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
