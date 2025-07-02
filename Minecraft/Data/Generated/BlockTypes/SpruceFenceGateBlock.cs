using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SpruceFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12205,
                            false => 12206,
                        },
                        false => Powered switch {
                            true => 12207,
                            false => 12208,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12209,
                            false => 12210,
                        },
                        false => Powered switch {
                            true => 12211,
                            false => 12212,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12213,
                            false => 12214,
                        },
                        false => Powered switch {
                            true => 12215,
                            false => 12216,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12217,
                            false => 12218,
                        },
                        false => Powered switch {
                            true => 12219,
                            false => 12220,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12221,
                            false => 12222,
                        },
                        false => Powered switch {
                            true => 12223,
                            false => 12224,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12225,
                            false => 12226,
                        },
                        false => Powered switch {
                            true => 12227,
                            false => 12228,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12229,
                            false => 12230,
                        },
                        false => Powered switch {
                            true => 12231,
                            false => 12232,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12233,
                            false => 12234,
                        },
                        false => Powered switch {
                            true => 12235,
                            false => 12236,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12205 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, true),
            12206 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, false),
            12207 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, true),
            12208 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, false),
            12209 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, true),
            12210 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, false),
            12211 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, true),
            12212 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, false),
            12213 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, true),
            12214 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, false),
            12215 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, true),
            12216 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, false),
            12217 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, true),
            12218 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, false),
            12219 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, true),
            12220 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, false),
            12221 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, true),
            12222 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, false),
            12223 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, true),
            12224 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, false),
            12225 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, true),
            12226 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, false),
            12227 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, true),
            12228 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, false),
            12229 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, true),
            12230 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, false),
            12231 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, true),
            12232 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, false),
            12233 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, true),
            12234 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, false),
            12235 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, true),
            12236 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
