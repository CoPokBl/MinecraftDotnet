using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndStoneBrickStairsBlock(Identifier Identifier, Direction Facing, EndStoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14385,
                            false => 14386,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14387,
                            false => 14388,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14389,
                            false => 14390,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14391,
                            false => 14392,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14393,
                            false => 14394,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14395,
                            false => 14396,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14397,
                            false => 14398,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14399,
                            false => 14400,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14401,
                            false => 14402,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14403,
                            false => 14404,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14405,
                            false => 14406,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14407,
                            false => 14408,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14409,
                            false => 14410,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14411,
                            false => 14412,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14413,
                            false => 14414,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14415,
                            false => 14416,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14417,
                            false => 14418,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14419,
                            false => 14420,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14421,
                            false => 14422,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14423,
                            false => 14424,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14425,
                            false => 14426,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14427,
                            false => 14428,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14429,
                            false => 14430,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14431,
                            false => 14432,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14433,
                            false => 14434,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14435,
                            false => 14436,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14437,
                            false => 14438,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14439,
                            false => 14440,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14441,
                            false => 14442,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14443,
                            false => 14444,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14445,
                            false => 14446,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14447,
                            false => 14448,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14449,
                            false => 14450,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14451,
                            false => 14452,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14453,
                            false => 14454,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14455,
                            false => 14456,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14457,
                            false => 14458,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14459,
                            false => 14460,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14461,
                            false => 14462,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14463,
                            false => 14464,
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
            14385 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14386 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14387 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14388 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14389 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14390 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14391 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14392 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14393 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14394 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14395 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14396 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14397 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14398 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14399 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14400 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14401 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14402 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14403 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14404 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14405 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14406 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14407 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14408 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14409 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14410 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14411 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14412 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14413 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14414 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14415 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14416 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14417 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14418 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14419 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14420 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14421 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14422 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14423 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14424 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14425 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14426 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14427 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14428 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14429 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14430 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14431 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14432 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14433 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14434 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14435 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14436 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14437 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14438 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14439 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14440 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14441 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14442 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14443 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14444 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14445 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14446 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14447 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14448 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14449 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14450 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14451 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14452 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14453 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14454 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14455 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14456 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14457 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14458 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14459 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14460 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14461 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14462 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14463 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14464 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
