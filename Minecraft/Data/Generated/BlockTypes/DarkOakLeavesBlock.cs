using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DarkOakLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 420,
                        false => 421,
                    },
                    false => Waterlogged switch {
                        true => 422,
                        false => 423,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 424,
                        false => 425,
                    },
                    false => Waterlogged switch {
                        true => 426,
                        false => 427,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 428,
                        false => 429,
                    },
                    false => Waterlogged switch {
                        true => 430,
                        false => 431,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 432,
                        false => 433,
                    },
                    false => Waterlogged switch {
                        true => 434,
                        false => 435,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 436,
                        false => 437,
                    },
                    false => Waterlogged switch {
                        true => 438,
                        false => 439,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 440,
                        false => 441,
                    },
                    false => Waterlogged switch {
                        true => 442,
                        false => 443,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 444,
                        false => 445,
                    },
                    false => Waterlogged switch {
                        true => 446,
                        false => 447,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            420 => new DarkOakLeavesBlock(Identifier, 1, true, true),
            421 => new DarkOakLeavesBlock(Identifier, 1, true, false),
            422 => new DarkOakLeavesBlock(Identifier, 1, false, true),
            423 => new DarkOakLeavesBlock(Identifier, 1, false, false),
            424 => new DarkOakLeavesBlock(Identifier, 2, true, true),
            425 => new DarkOakLeavesBlock(Identifier, 2, true, false),
            426 => new DarkOakLeavesBlock(Identifier, 2, false, true),
            427 => new DarkOakLeavesBlock(Identifier, 2, false, false),
            428 => new DarkOakLeavesBlock(Identifier, 3, true, true),
            429 => new DarkOakLeavesBlock(Identifier, 3, true, false),
            430 => new DarkOakLeavesBlock(Identifier, 3, false, true),
            431 => new DarkOakLeavesBlock(Identifier, 3, false, false),
            432 => new DarkOakLeavesBlock(Identifier, 4, true, true),
            433 => new DarkOakLeavesBlock(Identifier, 4, true, false),
            434 => new DarkOakLeavesBlock(Identifier, 4, false, true),
            435 => new DarkOakLeavesBlock(Identifier, 4, false, false),
            436 => new DarkOakLeavesBlock(Identifier, 5, true, true),
            437 => new DarkOakLeavesBlock(Identifier, 5, true, false),
            438 => new DarkOakLeavesBlock(Identifier, 5, false, true),
            439 => new DarkOakLeavesBlock(Identifier, 5, false, false),
            440 => new DarkOakLeavesBlock(Identifier, 6, true, true),
            441 => new DarkOakLeavesBlock(Identifier, 6, true, false),
            442 => new DarkOakLeavesBlock(Identifier, 6, false, true),
            443 => new DarkOakLeavesBlock(Identifier, 6, false, false),
            444 => new DarkOakLeavesBlock(Identifier, 7, true, true),
            445 => new DarkOakLeavesBlock(Identifier, 7, true, false),
            446 => new DarkOakLeavesBlock(Identifier, 7, false, true),
            447 => new DarkOakLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
