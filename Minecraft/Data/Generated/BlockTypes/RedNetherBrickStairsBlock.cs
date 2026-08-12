using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedNetherBrickStairsBlock(Identifier Identifier, Direction Facing, RedNetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:red_nether_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.red_nether_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16176,
                            false => 16177,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16178,
                            false => 16179,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16180,
                            false => 16181,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16182,
                            false => 16183,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16184,
                            false => 16185,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16186,
                            false => 16187,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16188,
                            false => 16189,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16190,
                            false => 16191,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16192,
                            false => 16193,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16194,
                            false => 16195,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16196,
                            false => 16197,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16198,
                            false => 16199,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16200,
                            false => 16201,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16202,
                            false => 16203,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16204,
                            false => 16205,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16206,
                            false => 16207,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16208,
                            false => 16209,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16210,
                            false => 16211,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16212,
                            false => 16213,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16214,
                            false => 16215,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16216,
                            false => 16217,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16218,
                            false => 16219,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16220,
                            false => 16221,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16222,
                            false => 16223,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16224,
                            false => 16225,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16226,
                            false => 16227,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16228,
                            false => 16229,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16230,
                            false => 16231,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16232,
                            false => 16233,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16234,
                            false => 16235,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16236,
                            false => 16237,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16238,
                            false => 16239,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16240,
                            false => 16241,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16242,
                            false => 16243,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16244,
                            false => 16245,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16246,
                            false => 16247,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16248,
                            false => 16249,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16250,
                            false => 16251,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16252,
                            false => 16253,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16254,
                            false => 16255,
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
            16176 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16177 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16178 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16179 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16180 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16181 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16182 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16183 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16184 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16185 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16186 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16187 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16188 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16189 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16190 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16191 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16192 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16193 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16194 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16195 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16196 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16197 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16198 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16199 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16200 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16201 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16202 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16203 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16204 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16205 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16206 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16207 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16208 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16209 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16210 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16211 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16212 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16213 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16214 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16215 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16216 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16217 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16218 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16219 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16220 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16221 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16222 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16223 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16224 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16225 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16226 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16227 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16228 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16229 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16230 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16231 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16232 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16233 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16234 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16235 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16236 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16237 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16238 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16239 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16240 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16241 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16242 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16243 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16244 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16245 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16246 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16247 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16248 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16249 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16250 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16251 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16252 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16253 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16254 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16255 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
