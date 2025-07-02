using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MossyCobblestoneStairsBlock(Identifier Identifier, Direction Facing, MossyCobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14305,
                            false => 14306,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14307,
                            false => 14308,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14309,
                            false => 14310,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14311,
                            false => 14312,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14313,
                            false => 14314,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14315,
                            false => 14316,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14317,
                            false => 14318,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14319,
                            false => 14320,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14321,
                            false => 14322,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14323,
                            false => 14324,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14325,
                            false => 14326,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14327,
                            false => 14328,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14329,
                            false => 14330,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14331,
                            false => 14332,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14333,
                            false => 14334,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14335,
                            false => 14336,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14337,
                            false => 14338,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14339,
                            false => 14340,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14341,
                            false => 14342,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14343,
                            false => 14344,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14345,
                            false => 14346,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14347,
                            false => 14348,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14349,
                            false => 14350,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14351,
                            false => 14352,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14353,
                            false => 14354,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14355,
                            false => 14356,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14357,
                            false => 14358,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14359,
                            false => 14360,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14361,
                            false => 14362,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14363,
                            false => 14364,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14365,
                            false => 14366,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14367,
                            false => 14368,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14369,
                            false => 14370,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14371,
                            false => 14372,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14373,
                            false => 14374,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14375,
                            false => 14376,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14377,
                            false => 14378,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14379,
                            false => 14380,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14381,
                            false => 14382,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14383,
                            false => 14384,
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
            14305 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14306 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14307 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14308 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14309 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14310 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14311 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14312 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14313 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14314 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14315 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14316 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14317 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14318 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14319 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14320 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14321 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14322 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14323 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14324 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14325 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14326 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14327 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14328 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14329 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14330 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14331 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14332 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14333 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14334 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14335 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14336 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14337 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14338 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14339 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14340 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14341 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14342 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14343 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14344 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14345 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14346 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14347 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14348 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14349 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14350 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14351 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14352 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14353 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14354 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14355 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14356 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14357 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14358 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14359 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14360 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14361 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14362 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14363 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14364 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14365 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14366 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14367 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14368 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14369 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14370 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14371 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14372 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14373 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14374 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14375 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14376 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14377 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14378 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14379 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14380 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14381 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14382 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14383 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14384 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
