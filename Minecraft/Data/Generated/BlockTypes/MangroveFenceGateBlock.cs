using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MangroveFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12429,
                            false => 12430,
                        },
                        false => Powered switch {
                            true => 12431,
                            false => 12432,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12433,
                            false => 12434,
                        },
                        false => Powered switch {
                            true => 12435,
                            false => 12436,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12437,
                            false => 12438,
                        },
                        false => Powered switch {
                            true => 12439,
                            false => 12440,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12441,
                            false => 12442,
                        },
                        false => Powered switch {
                            true => 12443,
                            false => 12444,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12445,
                            false => 12446,
                        },
                        false => Powered switch {
                            true => 12447,
                            false => 12448,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12449,
                            false => 12450,
                        },
                        false => Powered switch {
                            true => 12451,
                            false => 12452,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12453,
                            false => 12454,
                        },
                        false => Powered switch {
                            true => 12455,
                            false => 12456,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12457,
                            false => 12458,
                        },
                        false => Powered switch {
                            true => 12459,
                            false => 12460,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12429 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, true),
            12430 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, false),
            12431 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, true),
            12432 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, false),
            12433 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, true),
            12434 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, false),
            12435 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, true),
            12436 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, false),
            12437 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, true),
            12438 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, false),
            12439 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, true),
            12440 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, false),
            12441 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, true),
            12442 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, false),
            12443 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, true),
            12444 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, false),
            12445 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, true),
            12446 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, false),
            12447 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, true),
            12448 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, false),
            12449 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, true),
            12450 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, false),
            12451 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, true),
            12452 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, false),
            12453 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, true),
            12454 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, false),
            12455 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, true),
            12456 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, false),
            12457 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, true),
            12458 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, false),
            12459 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, true),
            12460 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
