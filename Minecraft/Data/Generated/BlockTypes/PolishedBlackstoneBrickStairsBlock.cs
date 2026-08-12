using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneBrickStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:polished_blackstone_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.polished_blackstone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22252,
                            false => 22253,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22254,
                            false => 22255,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22256,
                            false => 22257,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22258,
                            false => 22259,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22260,
                            false => 22261,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22262,
                            false => 22263,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22264,
                            false => 22265,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22266,
                            false => 22267,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22268,
                            false => 22269,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22270,
                            false => 22271,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22272,
                            false => 22273,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22274,
                            false => 22275,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22276,
                            false => 22277,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22278,
                            false => 22279,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22280,
                            false => 22281,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22282,
                            false => 22283,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22284,
                            false => 22285,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22286,
                            false => 22287,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22288,
                            false => 22289,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22290,
                            false => 22291,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22292,
                            false => 22293,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22294,
                            false => 22295,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22296,
                            false => 22297,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22298,
                            false => 22299,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22300,
                            false => 22301,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22302,
                            false => 22303,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22304,
                            false => 22305,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22306,
                            false => 22307,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22308,
                            false => 22309,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22310,
                            false => 22311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22312,
                            false => 22313,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22314,
                            false => 22315,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22316,
                            false => 22317,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22318,
                            false => 22319,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22320,
                            false => 22321,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22322,
                            false => 22323,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22324,
                            false => 22325,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22326,
                            false => 22327,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22328,
                            false => 22329,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22330,
                            false => 22331,
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
            22252 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22253 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22254 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22255 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22256 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22257 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22258 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22259 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22260 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22261 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22262 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22263 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22264 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22265 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22266 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22267 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22268 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22269 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22270 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22271 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22272 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22273 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22274 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22275 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22276 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22277 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22278 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22279 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22280 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22281 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22282 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22283 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22284 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22285 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22286 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22287 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22288 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22289 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22290 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22291 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22292 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22293 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22294 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22295 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22296 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22297 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22298 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22299 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22300 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22301 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22302 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22303 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22304 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22305 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22306 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22307 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22308 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22309 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22310 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22311 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22312 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22313 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22314 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22315 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22316 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22317 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22318 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22319 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22320 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22321 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22322 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22323 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22324 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22325 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22326 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22327 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22328 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22329 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22330 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22331 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
