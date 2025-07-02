using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record VineBlock(Identifier Identifier, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7080,
                                false => 7081,
                            },
                            false => West switch {
                                true => 7082,
                                false => 7083,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7084,
                                false => 7085,
                            },
                            false => West switch {
                                true => 7086,
                                false => 7087,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7088,
                                false => 7089,
                            },
                            false => West switch {
                                true => 7090,
                                false => 7091,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7092,
                                false => 7093,
                            },
                            false => West switch {
                                true => 7094,
                                false => 7095,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7096,
                                false => 7097,
                            },
                            false => West switch {
                                true => 7098,
                                false => 7099,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7100,
                                false => 7101,
                            },
                            false => West switch {
                                true => 7102,
                                false => 7103,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7104,
                                false => 7105,
                            },
                            false => West switch {
                                true => 7106,
                                false => 7107,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7108,
                                false => 7109,
                            },
                            false => West switch {
                                true => 7110,
                                false => 7111,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            7080 => new VineBlock(Identifier, true, true, true, true, true),
            7081 => new VineBlock(Identifier, true, true, true, true, false),
            7082 => new VineBlock(Identifier, true, true, true, false, true),
            7083 => new VineBlock(Identifier, true, true, true, false, false),
            7084 => new VineBlock(Identifier, true, true, false, true, true),
            7085 => new VineBlock(Identifier, true, true, false, true, false),
            7086 => new VineBlock(Identifier, true, true, false, false, true),
            7087 => new VineBlock(Identifier, true, true, false, false, false),
            7088 => new VineBlock(Identifier, true, false, true, true, true),
            7089 => new VineBlock(Identifier, true, false, true, true, false),
            7090 => new VineBlock(Identifier, true, false, true, false, true),
            7091 => new VineBlock(Identifier, true, false, true, false, false),
            7092 => new VineBlock(Identifier, true, false, false, true, true),
            7093 => new VineBlock(Identifier, true, false, false, true, false),
            7094 => new VineBlock(Identifier, true, false, false, false, true),
            7095 => new VineBlock(Identifier, true, false, false, false, false),
            7096 => new VineBlock(Identifier, false, true, true, true, true),
            7097 => new VineBlock(Identifier, false, true, true, true, false),
            7098 => new VineBlock(Identifier, false, true, true, false, true),
            7099 => new VineBlock(Identifier, false, true, true, false, false),
            7100 => new VineBlock(Identifier, false, true, false, true, true),
            7101 => new VineBlock(Identifier, false, true, false, true, false),
            7102 => new VineBlock(Identifier, false, true, false, false, true),
            7103 => new VineBlock(Identifier, false, true, false, false, false),
            7104 => new VineBlock(Identifier, false, false, true, true, true),
            7105 => new VineBlock(Identifier, false, false, true, true, false),
            7106 => new VineBlock(Identifier, false, false, true, false, true),
            7107 => new VineBlock(Identifier, false, false, true, false, false),
            7108 => new VineBlock(Identifier, false, false, false, true, true),
            7109 => new VineBlock(Identifier, false, false, false, true, false),
            7110 => new VineBlock(Identifier, false, false, false, false, true),
            7111 => new VineBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
