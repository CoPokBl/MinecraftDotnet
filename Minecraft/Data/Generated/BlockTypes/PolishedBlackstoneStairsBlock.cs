using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PolishedBlackstoneStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21314,
                            false => 21315,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21316,
                            false => 21317,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21318,
                            false => 21319,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21320,
                            false => 21321,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21322,
                            false => 21323,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21324,
                            false => 21325,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21326,
                            false => 21327,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21328,
                            false => 21329,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21330,
                            false => 21331,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21332,
                            false => 21333,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21334,
                            false => 21335,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21336,
                            false => 21337,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21338,
                            false => 21339,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21340,
                            false => 21341,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21342,
                            false => 21343,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21344,
                            false => 21345,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21346,
                            false => 21347,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21348,
                            false => 21349,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21350,
                            false => 21351,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21352,
                            false => 21353,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21354,
                            false => 21355,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21356,
                            false => 21357,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21358,
                            false => 21359,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21360,
                            false => 21361,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21362,
                            false => 21363,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21364,
                            false => 21365,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21366,
                            false => 21367,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21368,
                            false => 21369,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21370,
                            false => 21371,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21372,
                            false => 21373,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21374,
                            false => 21375,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21376,
                            false => 21377,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21378,
                            false => 21379,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21380,
                            false => 21381,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21382,
                            false => 21383,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21384,
                            false => 21385,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21386,
                            false => 21387,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21388,
                            false => 21389,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21390,
                            false => 21391,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21392,
                            false => 21393,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21314 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21315 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21316 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21317 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21318 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21319 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21320 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21321 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21322 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21323 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21324 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21325 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21326 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21327 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21328 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21329 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21330 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21331 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21332 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21333 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21334 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21335 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21336 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21337 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21338 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21339 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21340 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21341 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21342 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21343 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21344 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21345 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21346 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21347 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21348 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21349 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21350 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21351 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21352 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21353 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21354 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21355 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21356 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21357 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21358 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21359 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21360 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21361 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21362 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21363 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21364 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21365 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21366 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21367 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21368 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21369 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21370 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21371 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21372 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21373 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21374 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21375 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21376 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21377 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21378 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21379 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21380 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21381 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21382 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21383 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21384 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21385 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21386 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21387 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21388 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21389 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21390 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21391 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21392 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21393 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
