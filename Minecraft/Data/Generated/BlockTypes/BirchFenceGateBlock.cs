using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BirchFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12237,
                            false => 12238,
                        },
                        false => Powered switch {
                            true => 12239,
                            false => 12240,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12241,
                            false => 12242,
                        },
                        false => Powered switch {
                            true => 12243,
                            false => 12244,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12245,
                            false => 12246,
                        },
                        false => Powered switch {
                            true => 12247,
                            false => 12248,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12249,
                            false => 12250,
                        },
                        false => Powered switch {
                            true => 12251,
                            false => 12252,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12253,
                            false => 12254,
                        },
                        false => Powered switch {
                            true => 12255,
                            false => 12256,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12257,
                            false => 12258,
                        },
                        false => Powered switch {
                            true => 12259,
                            false => 12260,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12261,
                            false => 12262,
                        },
                        false => Powered switch {
                            true => 12263,
                            false => 12264,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12265,
                            false => 12266,
                        },
                        false => Powered switch {
                            true => 12267,
                            false => 12268,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12237 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, true),
            12238 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, false),
            12239 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, true),
            12240 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, false),
            12241 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, true),
            12242 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, false),
            12243 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, true),
            12244 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, false),
            12245 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, true),
            12246 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, false),
            12247 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, true),
            12248 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, false),
            12249 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, true),
            12250 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, false),
            12251 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, true),
            12252 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, false),
            12253 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, true),
            12254 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, false),
            12255 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, true),
            12256 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, false),
            12257 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, true),
            12258 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, false),
            12259 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, true),
            12260 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, false),
            12261 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, true),
            12262 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, false),
            12263 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, true),
            12264 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, false),
            12265 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, true),
            12266 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, false),
            12267 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, true),
            12268 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
