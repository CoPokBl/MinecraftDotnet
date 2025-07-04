using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneBrickStairsBlock(Identifier Identifier, Direction Facing, StoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7480,
                            false => 7481,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7482,
                            false => 7483,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7484,
                            false => 7485,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7486,
                            false => 7487,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7488,
                            false => 7489,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7490,
                            false => 7491,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7492,
                            false => 7493,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7494,
                            false => 7495,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7496,
                            false => 7497,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7498,
                            false => 7499,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7500,
                            false => 7501,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7502,
                            false => 7503,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7504,
                            false => 7505,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7506,
                            false => 7507,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7508,
                            false => 7509,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7510,
                            false => 7511,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7512,
                            false => 7513,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7514,
                            false => 7515,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7516,
                            false => 7517,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7518,
                            false => 7519,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7520,
                            false => 7521,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7522,
                            false => 7523,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7524,
                            false => 7525,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7526,
                            false => 7527,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7528,
                            false => 7529,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7530,
                            false => 7531,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7532,
                            false => 7533,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7534,
                            false => 7535,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7536,
                            false => 7537,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7538,
                            false => 7539,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7540,
                            false => 7541,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7542,
                            false => 7543,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7544,
                            false => 7545,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7546,
                            false => 7547,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7548,
                            false => 7549,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7550,
                            false => 7551,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7552,
                            false => 7553,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7554,
                            false => 7555,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7556,
                            false => 7557,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7558,
                            false => 7559,
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
            7480 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            7481 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            7482 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            7483 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            7484 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            7485 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            7486 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            7487 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            7488 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            7489 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            7490 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            7491 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            7492 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            7493 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            7494 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            7495 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            7496 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            7497 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            7498 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            7499 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            7500 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            7501 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            7502 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            7503 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            7504 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            7505 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            7506 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            7507 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            7508 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            7509 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            7510 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            7511 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            7512 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            7513 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            7514 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            7515 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            7516 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            7517 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            7518 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            7519 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            7520 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            7521 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            7522 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            7523 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            7524 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            7525 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            7526 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            7527 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            7528 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            7529 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            7530 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            7531 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            7532 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            7533 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            7534 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            7535 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            7536 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            7537 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            7538 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            7539 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            7540 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            7541 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            7542 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            7543 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            7544 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            7545 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            7546 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            7547 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            7548 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            7549 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            7550 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            7551 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            7552 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            7553 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            7554 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            7555 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            7556 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            7557 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            7558 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            7559 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
