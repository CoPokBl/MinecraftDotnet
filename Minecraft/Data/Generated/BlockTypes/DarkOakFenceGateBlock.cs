using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12365,
                            false => 12366,
                        },
                        false => Powered switch {
                            true => 12367,
                            false => 12368,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12369,
                            false => 12370,
                        },
                        false => Powered switch {
                            true => 12371,
                            false => 12372,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12373,
                            false => 12374,
                        },
                        false => Powered switch {
                            true => 12375,
                            false => 12376,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12377,
                            false => 12378,
                        },
                        false => Powered switch {
                            true => 12379,
                            false => 12380,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12381,
                            false => 12382,
                        },
                        false => Powered switch {
                            true => 12383,
                            false => 12384,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12385,
                            false => 12386,
                        },
                        false => Powered switch {
                            true => 12387,
                            false => 12388,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12389,
                            false => 12390,
                        },
                        false => Powered switch {
                            true => 12391,
                            false => 12392,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12393,
                            false => 12394,
                        },
                        false => Powered switch {
                            true => 12395,
                            false => 12396,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12365 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            12366 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            12367 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            12368 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            12369 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            12370 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            12371 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            12372 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            12373 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            12374 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            12375 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            12376 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            12377 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            12378 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            12379 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            12380 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            12381 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            12382 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            12383 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            12384 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            12385 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            12386 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            12387 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            12388 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            12389 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            12390 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            12391 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            12392 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            12393 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            12394 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            12395 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            12396 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            InWall = properties["in_wall"].GetString() == "true",
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
