using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record IronTrapdoorBlock(Identifier Identifier, Direction Facing, IronTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11288,
                                false => 11289,
                            },
                            false => Waterlogged switch {
                                true => 11290,
                                false => 11291,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11292,
                                false => 11293,
                            },
                            false => Waterlogged switch {
                                true => 11294,
                                false => 11295,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11296,
                                false => 11297,
                            },
                            false => Waterlogged switch {
                                true => 11298,
                                false => 11299,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11300,
                                false => 11301,
                            },
                            false => Waterlogged switch {
                                true => 11302,
                                false => 11303,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11304,
                                false => 11305,
                            },
                            false => Waterlogged switch {
                                true => 11306,
                                false => 11307,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11308,
                                false => 11309,
                            },
                            false => Waterlogged switch {
                                true => 11310,
                                false => 11311,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11312,
                                false => 11313,
                            },
                            false => Waterlogged switch {
                                true => 11314,
                                false => 11315,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11316,
                                false => 11317,
                            },
                            false => Waterlogged switch {
                                true => 11318,
                                false => 11319,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11320,
                                false => 11321,
                            },
                            false => Waterlogged switch {
                                true => 11322,
                                false => 11323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11324,
                                false => 11325,
                            },
                            false => Waterlogged switch {
                                true => 11326,
                                false => 11327,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11328,
                                false => 11329,
                            },
                            false => Waterlogged switch {
                                true => 11330,
                                false => 11331,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11332,
                                false => 11333,
                            },
                            false => Waterlogged switch {
                                true => 11334,
                                false => 11335,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11336,
                                false => 11337,
                            },
                            false => Waterlogged switch {
                                true => 11338,
                                false => 11339,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11340,
                                false => 11341,
                            },
                            false => Waterlogged switch {
                                true => 11342,
                                false => 11343,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11344,
                                false => 11345,
                            },
                            false => Waterlogged switch {
                                true => 11346,
                                false => 11347,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11348,
                                false => 11349,
                            },
                            false => Waterlogged switch {
                                true => 11350,
                                false => 11351,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11288 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            11289 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            11290 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            11291 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            11292 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            11293 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            11294 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            11295 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            11296 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            11297 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            11298 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            11299 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            11300 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            11301 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            11302 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            11303 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            11304 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            11305 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            11306 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            11307 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            11308 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            11309 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            11310 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            11311 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            11312 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            11313 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            11314 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            11315 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            11316 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            11317 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            11318 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            11319 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            11320 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            11321 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            11322 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            11323 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            11324 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            11325 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            11326 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            11327 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            11328 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            11329 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            11330 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            11331 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            11332 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            11333 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            11334 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            11335 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            11336 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            11337 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            11338 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            11339 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            11340 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            11341 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            11342 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            11343 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            11344 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            11345 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            11346 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            11347 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            11348 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            11349 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            11350 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            11351 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
