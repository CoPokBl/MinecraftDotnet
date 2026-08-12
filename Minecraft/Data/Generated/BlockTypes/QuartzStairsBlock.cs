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
                            true => 11328,
                            false => 11329,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11330,
                            false => 11331,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11332,
                            false => 11333,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11334,
                            false => 11335,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11336,
                            false => 11337,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11338,
                            false => 11339,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11340,
                            false => 11341,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11342,
                            false => 11343,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11344,
                            false => 11345,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11346,
                            false => 11347,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11348,
                            false => 11349,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11350,
                            false => 11351,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11352,
                            false => 11353,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11354,
                            false => 11355,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11356,
                            false => 11357,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11358,
                            false => 11359,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11360,
                            false => 11361,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11362,
                            false => 11363,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11364,
                            false => 11365,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11366,
                            false => 11367,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11368,
                            false => 11369,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11370,
                            false => 11371,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11372,
                            false => 11373,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11374,
                            false => 11375,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11376,
                            false => 11377,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11378,
                            false => 11379,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11380,
                            false => 11381,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11382,
                            false => 11383,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11384,
                            false => 11385,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11386,
                            false => 11387,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11388,
                            false => 11389,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11390,
                            false => 11391,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11392,
                            false => 11393,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11394,
                            false => 11395,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11396,
                            false => 11397,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11398,
                            false => 11399,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11400,
                            false => 11401,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11402,
                            false => 11403,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11404,
                            false => 11405,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11406,
                            false => 11407,
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
            11328 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11329 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11330 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11331 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11332 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11333 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11334 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11335 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11336 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11337 => new QuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11338 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11339 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11340 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11341 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11342 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11343 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11344 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11345 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11346 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11347 => new QuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11348 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11349 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11350 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11351 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11352 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11353 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11354 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11355 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11356 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11357 => new QuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11358 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11359 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11360 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11361 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11362 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11363 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11364 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11365 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11366 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11367 => new QuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11368 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11369 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11370 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11371 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11372 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11373 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11374 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11375 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11376 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11377 => new QuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11378 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11379 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11380 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11381 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11382 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11383 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11384 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11385 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11386 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11387 => new QuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11388 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11389 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11390 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11391 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11392 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11393 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11394 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11395 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11396 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11397 => new QuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11398 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11399 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11400 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11401 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11402 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11403 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11404 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11405 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11406 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11407 => new QuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
