using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PaleOakLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 448,
                        false => 449,
                    },
                    false => Waterlogged switch {
                        true => 450,
                        false => 451,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 452,
                        false => 453,
                    },
                    false => Waterlogged switch {
                        true => 454,
                        false => 455,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 456,
                        false => 457,
                    },
                    false => Waterlogged switch {
                        true => 458,
                        false => 459,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 460,
                        false => 461,
                    },
                    false => Waterlogged switch {
                        true => 462,
                        false => 463,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 464,
                        false => 465,
                    },
                    false => Waterlogged switch {
                        true => 466,
                        false => 467,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 468,
                        false => 469,
                    },
                    false => Waterlogged switch {
                        true => 470,
                        false => 471,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 472,
                        false => 473,
                    },
                    false => Waterlogged switch {
                        true => 474,
                        false => 475,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            448 => new PaleOakLeavesBlock(Identifier, 1, true, true),
            449 => new PaleOakLeavesBlock(Identifier, 1, true, false),
            450 => new PaleOakLeavesBlock(Identifier, 1, false, true),
            451 => new PaleOakLeavesBlock(Identifier, 1, false, false),
            452 => new PaleOakLeavesBlock(Identifier, 2, true, true),
            453 => new PaleOakLeavesBlock(Identifier, 2, true, false),
            454 => new PaleOakLeavesBlock(Identifier, 2, false, true),
            455 => new PaleOakLeavesBlock(Identifier, 2, false, false),
            456 => new PaleOakLeavesBlock(Identifier, 3, true, true),
            457 => new PaleOakLeavesBlock(Identifier, 3, true, false),
            458 => new PaleOakLeavesBlock(Identifier, 3, false, true),
            459 => new PaleOakLeavesBlock(Identifier, 3, false, false),
            460 => new PaleOakLeavesBlock(Identifier, 4, true, true),
            461 => new PaleOakLeavesBlock(Identifier, 4, true, false),
            462 => new PaleOakLeavesBlock(Identifier, 4, false, true),
            463 => new PaleOakLeavesBlock(Identifier, 4, false, false),
            464 => new PaleOakLeavesBlock(Identifier, 5, true, true),
            465 => new PaleOakLeavesBlock(Identifier, 5, true, false),
            466 => new PaleOakLeavesBlock(Identifier, 5, false, true),
            467 => new PaleOakLeavesBlock(Identifier, 5, false, false),
            468 => new PaleOakLeavesBlock(Identifier, 6, true, true),
            469 => new PaleOakLeavesBlock(Identifier, 6, true, false),
            470 => new PaleOakLeavesBlock(Identifier, 6, false, true),
            471 => new PaleOakLeavesBlock(Identifier, 6, false, false),
            472 => new PaleOakLeavesBlock(Identifier, 7, true, true),
            473 => new PaleOakLeavesBlock(Identifier, 7, true, false),
            474 => new PaleOakLeavesBlock(Identifier, 7, false, true),
            475 => new PaleOakLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
