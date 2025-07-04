using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19534,
                            false => 19535,
                        },
                        false => Waterlogged switch {
                            true => 19536,
                            false => 19537,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19538,
                            false => 19539,
                        },
                        false => Waterlogged switch {
                            true => 19540,
                            false => 19541,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19542,
                            false => 19543,
                        },
                        false => Waterlogged switch {
                            true => 19544,
                            false => 19545,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19546,
                            false => 19547,
                        },
                        false => Waterlogged switch {
                            true => 19548,
                            false => 19549,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19550,
                            false => 19551,
                        },
                        false => Waterlogged switch {
                            true => 19552,
                            false => 19553,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19554,
                            false => 19555,
                        },
                        false => Waterlogged switch {
                            true => 19556,
                            false => 19557,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19558,
                            false => 19559,
                        },
                        false => Waterlogged switch {
                            true => 19560,
                            false => 19561,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19562,
                            false => 19563,
                        },
                        false => Waterlogged switch {
                            true => 19564,
                            false => 19565,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19534 => new CampfireBlock(Identifier, Direction.North, true, true, true),
            19535 => new CampfireBlock(Identifier, Direction.North, true, true, false),
            19536 => new CampfireBlock(Identifier, Direction.North, true, false, true),
            19537 => new CampfireBlock(Identifier, Direction.North, true, false, false),
            19538 => new CampfireBlock(Identifier, Direction.North, false, true, true),
            19539 => new CampfireBlock(Identifier, Direction.North, false, true, false),
            19540 => new CampfireBlock(Identifier, Direction.North, false, false, true),
            19541 => new CampfireBlock(Identifier, Direction.North, false, false, false),
            19542 => new CampfireBlock(Identifier, Direction.South, true, true, true),
            19543 => new CampfireBlock(Identifier, Direction.South, true, true, false),
            19544 => new CampfireBlock(Identifier, Direction.South, true, false, true),
            19545 => new CampfireBlock(Identifier, Direction.South, true, false, false),
            19546 => new CampfireBlock(Identifier, Direction.South, false, true, true),
            19547 => new CampfireBlock(Identifier, Direction.South, false, true, false),
            19548 => new CampfireBlock(Identifier, Direction.South, false, false, true),
            19549 => new CampfireBlock(Identifier, Direction.South, false, false, false),
            19550 => new CampfireBlock(Identifier, Direction.West, true, true, true),
            19551 => new CampfireBlock(Identifier, Direction.West, true, true, false),
            19552 => new CampfireBlock(Identifier, Direction.West, true, false, true),
            19553 => new CampfireBlock(Identifier, Direction.West, true, false, false),
            19554 => new CampfireBlock(Identifier, Direction.West, false, true, true),
            19555 => new CampfireBlock(Identifier, Direction.West, false, true, false),
            19556 => new CampfireBlock(Identifier, Direction.West, false, false, true),
            19557 => new CampfireBlock(Identifier, Direction.West, false, false, false),
            19558 => new CampfireBlock(Identifier, Direction.East, true, true, true),
            19559 => new CampfireBlock(Identifier, Direction.East, true, true, false),
            19560 => new CampfireBlock(Identifier, Direction.East, true, false, true),
            19561 => new CampfireBlock(Identifier, Direction.East, true, false, false),
            19562 => new CampfireBlock(Identifier, Direction.East, false, true, true),
            19563 => new CampfireBlock(Identifier, Direction.East, false, true, false),
            19564 => new CampfireBlock(Identifier, Direction.East, false, false, true),
            19565 => new CampfireBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Lit = properties["lit"].GetString() == "true",
            SignalFire = properties["signal_fire"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
