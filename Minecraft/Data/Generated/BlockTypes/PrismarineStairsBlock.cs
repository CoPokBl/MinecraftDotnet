using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineStairsBlock(Identifier Identifier, Direction Facing, PrismarineStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:prismarine_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.prismarine_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11355,
                            false => 11356,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11357,
                            false => 11358,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11359,
                            false => 11360,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11361,
                            false => 11362,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11363,
                            false => 11364,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11365,
                            false => 11366,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11367,
                            false => 11368,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11369,
                            false => 11370,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11371,
                            false => 11372,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11373,
                            false => 11374,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11375,
                            false => 11376,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11377,
                            false => 11378,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11379,
                            false => 11380,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11381,
                            false => 11382,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11383,
                            false => 11384,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11385,
                            false => 11386,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11387,
                            false => 11388,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11389,
                            false => 11390,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11391,
                            false => 11392,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11393,
                            false => 11394,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11395,
                            false => 11396,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11397,
                            false => 11398,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11399,
                            false => 11400,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11401,
                            false => 11402,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11403,
                            false => 11404,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11405,
                            false => 11406,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11407,
                            false => 11408,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11409,
                            false => 11410,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11411,
                            false => 11412,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11413,
                            false => 11414,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11415,
                            false => 11416,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11417,
                            false => 11418,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11419,
                            false => 11420,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11421,
                            false => 11422,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11423,
                            false => 11424,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11425,
                            false => 11426,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11427,
                            false => 11428,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11429,
                            false => 11430,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11431,
                            false => 11432,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11433,
                            false => 11434,
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
            11355 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11356 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11357 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11358 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11359 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11360 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11361 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11362 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11363 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11364 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11365 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11366 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11367 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11368 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11369 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11370 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11371 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11372 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11373 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11374 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11375 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11376 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11377 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11378 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11379 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11380 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11381 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11382 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11383 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11384 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11385 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11386 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11387 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11388 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11389 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11390 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11391 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11392 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11393 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11394 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11395 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11396 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11397 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11398 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11399 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11400 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11401 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11402 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11403 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11404 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11405 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11406 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11407 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11408 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11409 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11410 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11411 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11412 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11413 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11414 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11415 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11416 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11417 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11418 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11419 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11420 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11421 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11422 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11423 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11424 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11425 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11426 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11427 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11428 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11429 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11430 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11431 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11432 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11433 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11434 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
