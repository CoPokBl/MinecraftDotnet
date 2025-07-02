using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SoulCampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19566,
                            false => 19567,
                        },
                        false => Waterlogged switch {
                            true => 19568,
                            false => 19569,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19570,
                            false => 19571,
                        },
                        false => Waterlogged switch {
                            true => 19572,
                            false => 19573,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19574,
                            false => 19575,
                        },
                        false => Waterlogged switch {
                            true => 19576,
                            false => 19577,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19578,
                            false => 19579,
                        },
                        false => Waterlogged switch {
                            true => 19580,
                            false => 19581,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19582,
                            false => 19583,
                        },
                        false => Waterlogged switch {
                            true => 19584,
                            false => 19585,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19586,
                            false => 19587,
                        },
                        false => Waterlogged switch {
                            true => 19588,
                            false => 19589,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19590,
                            false => 19591,
                        },
                        false => Waterlogged switch {
                            true => 19592,
                            false => 19593,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 19594,
                            false => 19595,
                        },
                        false => Waterlogged switch {
                            true => 19596,
                            false => 19597,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19566 => new SoulCampfireBlock(Identifier, Direction.North, true, true, true),
            19567 => new SoulCampfireBlock(Identifier, Direction.North, true, true, false),
            19568 => new SoulCampfireBlock(Identifier, Direction.North, true, false, true),
            19569 => new SoulCampfireBlock(Identifier, Direction.North, true, false, false),
            19570 => new SoulCampfireBlock(Identifier, Direction.North, false, true, true),
            19571 => new SoulCampfireBlock(Identifier, Direction.North, false, true, false),
            19572 => new SoulCampfireBlock(Identifier, Direction.North, false, false, true),
            19573 => new SoulCampfireBlock(Identifier, Direction.North, false, false, false),
            19574 => new SoulCampfireBlock(Identifier, Direction.South, true, true, true),
            19575 => new SoulCampfireBlock(Identifier, Direction.South, true, true, false),
            19576 => new SoulCampfireBlock(Identifier, Direction.South, true, false, true),
            19577 => new SoulCampfireBlock(Identifier, Direction.South, true, false, false),
            19578 => new SoulCampfireBlock(Identifier, Direction.South, false, true, true),
            19579 => new SoulCampfireBlock(Identifier, Direction.South, false, true, false),
            19580 => new SoulCampfireBlock(Identifier, Direction.South, false, false, true),
            19581 => new SoulCampfireBlock(Identifier, Direction.South, false, false, false),
            19582 => new SoulCampfireBlock(Identifier, Direction.West, true, true, true),
            19583 => new SoulCampfireBlock(Identifier, Direction.West, true, true, false),
            19584 => new SoulCampfireBlock(Identifier, Direction.West, true, false, true),
            19585 => new SoulCampfireBlock(Identifier, Direction.West, true, false, false),
            19586 => new SoulCampfireBlock(Identifier, Direction.West, false, true, true),
            19587 => new SoulCampfireBlock(Identifier, Direction.West, false, true, false),
            19588 => new SoulCampfireBlock(Identifier, Direction.West, false, false, true),
            19589 => new SoulCampfireBlock(Identifier, Direction.West, false, false, false),
            19590 => new SoulCampfireBlock(Identifier, Direction.East, true, true, true),
            19591 => new SoulCampfireBlock(Identifier, Direction.East, true, true, false),
            19592 => new SoulCampfireBlock(Identifier, Direction.East, true, false, true),
            19593 => new SoulCampfireBlock(Identifier, Direction.East, true, false, false),
            19594 => new SoulCampfireBlock(Identifier, Direction.East, false, true, true),
            19595 => new SoulCampfireBlock(Identifier, Direction.East, false, true, false),
            19596 => new SoulCampfireBlock(Identifier, Direction.East, false, false, true),
            19597 => new SoulCampfireBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
