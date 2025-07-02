using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record JungleFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12269,
                            false => 12270,
                        },
                        false => Powered switch {
                            true => 12271,
                            false => 12272,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12273,
                            false => 12274,
                        },
                        false => Powered switch {
                            true => 12275,
                            false => 12276,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12277,
                            false => 12278,
                        },
                        false => Powered switch {
                            true => 12279,
                            false => 12280,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12281,
                            false => 12282,
                        },
                        false => Powered switch {
                            true => 12283,
                            false => 12284,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12285,
                            false => 12286,
                        },
                        false => Powered switch {
                            true => 12287,
                            false => 12288,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12289,
                            false => 12290,
                        },
                        false => Powered switch {
                            true => 12291,
                            false => 12292,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12293,
                            false => 12294,
                        },
                        false => Powered switch {
                            true => 12295,
                            false => 12296,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12297,
                            false => 12298,
                        },
                        false => Powered switch {
                            true => 12299,
                            false => 12300,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12269 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, true),
            12270 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, false),
            12271 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, true),
            12272 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, false),
            12273 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, true),
            12274 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, false),
            12275 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, true),
            12276 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, false),
            12277 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, true),
            12278 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, false),
            12279 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, true),
            12280 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, false),
            12281 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, true),
            12282 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, false),
            12283 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, true),
            12284 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, false),
            12285 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, true),
            12286 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, false),
            12287 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, true),
            12288 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, false),
            12289 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, true),
            12290 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, false),
            12291 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, true),
            12292 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, false),
            12293 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, true),
            12294 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, false),
            12295 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, true),
            12296 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, false),
            12297 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, true),
            12298 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, false),
            12299 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, true),
            12300 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
