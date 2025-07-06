using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDeepslateStairsBlock(Identifier Identifier, Direction Facing, PolishedDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26379,
                            false => 26380,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26381,
                            false => 26382,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26383,
                            false => 26384,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26385,
                            false => 26386,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26387,
                            false => 26388,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26389,
                            false => 26390,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26391,
                            false => 26392,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26393,
                            false => 26394,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26395,
                            false => 26396,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26397,
                            false => 26398,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26399,
                            false => 26400,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26401,
                            false => 26402,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26403,
                            false => 26404,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26405,
                            false => 26406,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26407,
                            false => 26408,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26409,
                            false => 26410,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26411,
                            false => 26412,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26413,
                            false => 26414,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26415,
                            false => 26416,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26417,
                            false => 26418,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26419,
                            false => 26420,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26421,
                            false => 26422,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26423,
                            false => 26424,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26425,
                            false => 26426,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26427,
                            false => 26428,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26429,
                            false => 26430,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26431,
                            false => 26432,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26433,
                            false => 26434,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26435,
                            false => 26436,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26437,
                            false => 26438,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26439,
                            false => 26440,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26441,
                            false => 26442,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26443,
                            false => 26444,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26445,
                            false => 26446,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26447,
                            false => 26448,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26449,
                            false => 26450,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26451,
                            false => 26452,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26453,
                            false => 26454,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26455,
                            false => 26456,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26457,
                            false => 26458,
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
            26379 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26380 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26381 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26382 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26383 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26384 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26385 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26386 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26387 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26388 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26389 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26390 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26391 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26392 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26393 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26394 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26395 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26396 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26397 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26398 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26399 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26400 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26401 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26402 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26403 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26404 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26405 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26406 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26407 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26408 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26409 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26410 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26411 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26412 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26413 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26414 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26415 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26416 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26417 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26418 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26419 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26420 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26421 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26422 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26423 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26424 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26425 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26426 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26427 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26428 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26429 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26430 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26431 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26432 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26433 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26434 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26435 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26436 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26437 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26438 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26439 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26440 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26441 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26442 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26443 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26444 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26445 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26446 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26447 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26448 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26449 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26450 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26451 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26452 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26453 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26454 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26455 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26456 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26457 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26458 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
