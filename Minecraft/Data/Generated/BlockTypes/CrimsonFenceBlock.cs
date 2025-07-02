using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CrimsonFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19707,
                                false => 19708,
                            },
                            false => West switch {
                                true => 19709,
                                false => 19710,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19711,
                                false => 19712,
                            },
                            false => West switch {
                                true => 19713,
                                false => 19714,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19715,
                                false => 19716,
                            },
                            false => West switch {
                                true => 19717,
                                false => 19718,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19719,
                                false => 19720,
                            },
                            false => West switch {
                                true => 19721,
                                false => 19722,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19723,
                                false => 19724,
                            },
                            false => West switch {
                                true => 19725,
                                false => 19726,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19727,
                                false => 19728,
                            },
                            false => West switch {
                                true => 19729,
                                false => 19730,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19731,
                                false => 19732,
                            },
                            false => West switch {
                                true => 19733,
                                false => 19734,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19735,
                                false => 19736,
                            },
                            false => West switch {
                                true => 19737,
                                false => 19738,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19707 => new CrimsonFenceBlock(Identifier, true, true, true, true, true),
            19708 => new CrimsonFenceBlock(Identifier, true, true, true, true, false),
            19709 => new CrimsonFenceBlock(Identifier, true, true, true, false, true),
            19710 => new CrimsonFenceBlock(Identifier, true, true, true, false, false),
            19711 => new CrimsonFenceBlock(Identifier, true, true, false, true, true),
            19712 => new CrimsonFenceBlock(Identifier, true, true, false, true, false),
            19713 => new CrimsonFenceBlock(Identifier, true, true, false, false, true),
            19714 => new CrimsonFenceBlock(Identifier, true, true, false, false, false),
            19715 => new CrimsonFenceBlock(Identifier, true, false, true, true, true),
            19716 => new CrimsonFenceBlock(Identifier, true, false, true, true, false),
            19717 => new CrimsonFenceBlock(Identifier, true, false, true, false, true),
            19718 => new CrimsonFenceBlock(Identifier, true, false, true, false, false),
            19719 => new CrimsonFenceBlock(Identifier, true, false, false, true, true),
            19720 => new CrimsonFenceBlock(Identifier, true, false, false, true, false),
            19721 => new CrimsonFenceBlock(Identifier, true, false, false, false, true),
            19722 => new CrimsonFenceBlock(Identifier, true, false, false, false, false),
            19723 => new CrimsonFenceBlock(Identifier, false, true, true, true, true),
            19724 => new CrimsonFenceBlock(Identifier, false, true, true, true, false),
            19725 => new CrimsonFenceBlock(Identifier, false, true, true, false, true),
            19726 => new CrimsonFenceBlock(Identifier, false, true, true, false, false),
            19727 => new CrimsonFenceBlock(Identifier, false, true, false, true, true),
            19728 => new CrimsonFenceBlock(Identifier, false, true, false, true, false),
            19729 => new CrimsonFenceBlock(Identifier, false, true, false, false, true),
            19730 => new CrimsonFenceBlock(Identifier, false, true, false, false, false),
            19731 => new CrimsonFenceBlock(Identifier, false, false, true, true, true),
            19732 => new CrimsonFenceBlock(Identifier, false, false, true, true, false),
            19733 => new CrimsonFenceBlock(Identifier, false, false, true, false, true),
            19734 => new CrimsonFenceBlock(Identifier, false, false, true, false, false),
            19735 => new CrimsonFenceBlock(Identifier, false, false, false, true, true),
            19736 => new CrimsonFenceBlock(Identifier, false, false, false, true, false),
            19737 => new CrimsonFenceBlock(Identifier, false, false, false, false, true),
            19738 => new CrimsonFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
