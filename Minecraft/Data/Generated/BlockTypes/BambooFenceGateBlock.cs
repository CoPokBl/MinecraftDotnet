using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BambooFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12461,
                            false => 12462,
                        },
                        false => Powered switch {
                            true => 12463,
                            false => 12464,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12465,
                            false => 12466,
                        },
                        false => Powered switch {
                            true => 12467,
                            false => 12468,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12469,
                            false => 12470,
                        },
                        false => Powered switch {
                            true => 12471,
                            false => 12472,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12473,
                            false => 12474,
                        },
                        false => Powered switch {
                            true => 12475,
                            false => 12476,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12477,
                            false => 12478,
                        },
                        false => Powered switch {
                            true => 12479,
                            false => 12480,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12481,
                            false => 12482,
                        },
                        false => Powered switch {
                            true => 12483,
                            false => 12484,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12485,
                            false => 12486,
                        },
                        false => Powered switch {
                            true => 12487,
                            false => 12488,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12489,
                            false => 12490,
                        },
                        false => Powered switch {
                            true => 12491,
                            false => 12492,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12461 => new BambooFenceGateBlock(Identifier, Direction.North, true, true, true),
            12462 => new BambooFenceGateBlock(Identifier, Direction.North, true, true, false),
            12463 => new BambooFenceGateBlock(Identifier, Direction.North, true, false, true),
            12464 => new BambooFenceGateBlock(Identifier, Direction.North, true, false, false),
            12465 => new BambooFenceGateBlock(Identifier, Direction.North, false, true, true),
            12466 => new BambooFenceGateBlock(Identifier, Direction.North, false, true, false),
            12467 => new BambooFenceGateBlock(Identifier, Direction.North, false, false, true),
            12468 => new BambooFenceGateBlock(Identifier, Direction.North, false, false, false),
            12469 => new BambooFenceGateBlock(Identifier, Direction.South, true, true, true),
            12470 => new BambooFenceGateBlock(Identifier, Direction.South, true, true, false),
            12471 => new BambooFenceGateBlock(Identifier, Direction.South, true, false, true),
            12472 => new BambooFenceGateBlock(Identifier, Direction.South, true, false, false),
            12473 => new BambooFenceGateBlock(Identifier, Direction.South, false, true, true),
            12474 => new BambooFenceGateBlock(Identifier, Direction.South, false, true, false),
            12475 => new BambooFenceGateBlock(Identifier, Direction.South, false, false, true),
            12476 => new BambooFenceGateBlock(Identifier, Direction.South, false, false, false),
            12477 => new BambooFenceGateBlock(Identifier, Direction.West, true, true, true),
            12478 => new BambooFenceGateBlock(Identifier, Direction.West, true, true, false),
            12479 => new BambooFenceGateBlock(Identifier, Direction.West, true, false, true),
            12480 => new BambooFenceGateBlock(Identifier, Direction.West, true, false, false),
            12481 => new BambooFenceGateBlock(Identifier, Direction.West, false, true, true),
            12482 => new BambooFenceGateBlock(Identifier, Direction.West, false, true, false),
            12483 => new BambooFenceGateBlock(Identifier, Direction.West, false, false, true),
            12484 => new BambooFenceGateBlock(Identifier, Direction.West, false, false, false),
            12485 => new BambooFenceGateBlock(Identifier, Direction.East, true, true, true),
            12486 => new BambooFenceGateBlock(Identifier, Direction.East, true, true, false),
            12487 => new BambooFenceGateBlock(Identifier, Direction.East, true, false, true),
            12488 => new BambooFenceGateBlock(Identifier, Direction.East, true, false, false),
            12489 => new BambooFenceGateBlock(Identifier, Direction.East, false, true, true),
            12490 => new BambooFenceGateBlock(Identifier, Direction.East, false, true, false),
            12491 => new BambooFenceGateBlock(Identifier, Direction.East, false, false, true),
            12492 => new BambooFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
