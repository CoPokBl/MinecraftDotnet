using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 5996,
                                false => 5997,
                            },
                            false => West switch {
                                true => 5998,
                                false => 5999,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6000,
                                false => 6001,
                            },
                            false => West switch {
                                true => 6002,
                                false => 6003,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6004,
                                false => 6005,
                            },
                            false => West switch {
                                true => 6006,
                                false => 6007,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6008,
                                false => 6009,
                            },
                            false => West switch {
                                true => 6010,
                                false => 6011,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6012,
                                false => 6013,
                            },
                            false => West switch {
                                true => 6014,
                                false => 6015,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6016,
                                false => 6017,
                            },
                            false => West switch {
                                true => 6018,
                                false => 6019,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6020,
                                false => 6021,
                            },
                            false => West switch {
                                true => 6022,
                                false => 6023,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6024,
                                false => 6025,
                            },
                            false => West switch {
                                true => 6026,
                                false => 6027,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            5996 => new OakFenceBlock(Identifier, true, true, true, true, true),
            5997 => new OakFenceBlock(Identifier, true, true, true, true, false),
            5998 => new OakFenceBlock(Identifier, true, true, true, false, true),
            5999 => new OakFenceBlock(Identifier, true, true, true, false, false),
            6000 => new OakFenceBlock(Identifier, true, true, false, true, true),
            6001 => new OakFenceBlock(Identifier, true, true, false, true, false),
            6002 => new OakFenceBlock(Identifier, true, true, false, false, true),
            6003 => new OakFenceBlock(Identifier, true, true, false, false, false),
            6004 => new OakFenceBlock(Identifier, true, false, true, true, true),
            6005 => new OakFenceBlock(Identifier, true, false, true, true, false),
            6006 => new OakFenceBlock(Identifier, true, false, true, false, true),
            6007 => new OakFenceBlock(Identifier, true, false, true, false, false),
            6008 => new OakFenceBlock(Identifier, true, false, false, true, true),
            6009 => new OakFenceBlock(Identifier, true, false, false, true, false),
            6010 => new OakFenceBlock(Identifier, true, false, false, false, true),
            6011 => new OakFenceBlock(Identifier, true, false, false, false, false),
            6012 => new OakFenceBlock(Identifier, false, true, true, true, true),
            6013 => new OakFenceBlock(Identifier, false, true, true, true, false),
            6014 => new OakFenceBlock(Identifier, false, true, true, false, true),
            6015 => new OakFenceBlock(Identifier, false, true, true, false, false),
            6016 => new OakFenceBlock(Identifier, false, true, false, true, true),
            6017 => new OakFenceBlock(Identifier, false, true, false, true, false),
            6018 => new OakFenceBlock(Identifier, false, true, false, false, true),
            6019 => new OakFenceBlock(Identifier, false, true, false, false, false),
            6020 => new OakFenceBlock(Identifier, false, false, true, true, true),
            6021 => new OakFenceBlock(Identifier, false, false, true, true, false),
            6022 => new OakFenceBlock(Identifier, false, false, true, false, true),
            6023 => new OakFenceBlock(Identifier, false, false, true, false, false),
            6024 => new OakFenceBlock(Identifier, false, false, false, true, true),
            6025 => new OakFenceBlock(Identifier, false, false, false, true, false),
            6026 => new OakFenceBlock(Identifier, false, false, false, false, true),
            6027 => new OakFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
