using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MangrovePropaguleBlock(Identifier Identifier, int Age, bool Hanging, int Stage, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 45,
                            false => 46,
                        },
                        1 => Waterlogged switch {
                            true => 47,
                            false => 48,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 49,
                            false => 50,
                        },
                        1 => Waterlogged switch {
                            true => 51,
                            false => 52,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                1 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 53,
                            false => 54,
                        },
                        1 => Waterlogged switch {
                            true => 55,
                            false => 56,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 57,
                            false => 58,
                        },
                        1 => Waterlogged switch {
                            true => 59,
                            false => 60,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                2 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 61,
                            false => 62,
                        },
                        1 => Waterlogged switch {
                            true => 63,
                            false => 64,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 65,
                            false => 66,
                        },
                        1 => Waterlogged switch {
                            true => 67,
                            false => 68,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                3 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 69,
                            false => 70,
                        },
                        1 => Waterlogged switch {
                            true => 71,
                            false => 72,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 73,
                            false => 74,
                        },
                        1 => Waterlogged switch {
                            true => 75,
                            false => 76,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                4 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 77,
                            false => 78,
                        },
                        1 => Waterlogged switch {
                            true => 79,
                            false => 80,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 81,
                            false => 82,
                        },
                        1 => Waterlogged switch {
                            true => 83,
                            false => 84,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            45 => new MangrovePropaguleBlock(Identifier, 0, true, 0, true),
            46 => new MangrovePropaguleBlock(Identifier, 0, true, 0, false),
            47 => new MangrovePropaguleBlock(Identifier, 0, true, 1, true),
            48 => new MangrovePropaguleBlock(Identifier, 0, true, 1, false),
            49 => new MangrovePropaguleBlock(Identifier, 0, false, 0, true),
            50 => new MangrovePropaguleBlock(Identifier, 0, false, 0, false),
            51 => new MangrovePropaguleBlock(Identifier, 0, false, 1, true),
            52 => new MangrovePropaguleBlock(Identifier, 0, false, 1, false),
            53 => new MangrovePropaguleBlock(Identifier, 1, true, 0, true),
            54 => new MangrovePropaguleBlock(Identifier, 1, true, 0, false),
            55 => new MangrovePropaguleBlock(Identifier, 1, true, 1, true),
            56 => new MangrovePropaguleBlock(Identifier, 1, true, 1, false),
            57 => new MangrovePropaguleBlock(Identifier, 1, false, 0, true),
            58 => new MangrovePropaguleBlock(Identifier, 1, false, 0, false),
            59 => new MangrovePropaguleBlock(Identifier, 1, false, 1, true),
            60 => new MangrovePropaguleBlock(Identifier, 1, false, 1, false),
            61 => new MangrovePropaguleBlock(Identifier, 2, true, 0, true),
            62 => new MangrovePropaguleBlock(Identifier, 2, true, 0, false),
            63 => new MangrovePropaguleBlock(Identifier, 2, true, 1, true),
            64 => new MangrovePropaguleBlock(Identifier, 2, true, 1, false),
            65 => new MangrovePropaguleBlock(Identifier, 2, false, 0, true),
            66 => new MangrovePropaguleBlock(Identifier, 2, false, 0, false),
            67 => new MangrovePropaguleBlock(Identifier, 2, false, 1, true),
            68 => new MangrovePropaguleBlock(Identifier, 2, false, 1, false),
            69 => new MangrovePropaguleBlock(Identifier, 3, true, 0, true),
            70 => new MangrovePropaguleBlock(Identifier, 3, true, 0, false),
            71 => new MangrovePropaguleBlock(Identifier, 3, true, 1, true),
            72 => new MangrovePropaguleBlock(Identifier, 3, true, 1, false),
            73 => new MangrovePropaguleBlock(Identifier, 3, false, 0, true),
            74 => new MangrovePropaguleBlock(Identifier, 3, false, 0, false),
            75 => new MangrovePropaguleBlock(Identifier, 3, false, 1, true),
            76 => new MangrovePropaguleBlock(Identifier, 3, false, 1, false),
            77 => new MangrovePropaguleBlock(Identifier, 4, true, 0, true),
            78 => new MangrovePropaguleBlock(Identifier, 4, true, 0, false),
            79 => new MangrovePropaguleBlock(Identifier, 4, true, 1, true),
            80 => new MangrovePropaguleBlock(Identifier, 4, true, 1, false),
            81 => new MangrovePropaguleBlock(Identifier, 4, false, 0, true),
            82 => new MangrovePropaguleBlock(Identifier, 4, false, 0, false),
            83 => new MangrovePropaguleBlock(Identifier, 4, false, 1, true),
            84 => new MangrovePropaguleBlock(Identifier, 4, false, 1, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
