using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BrownMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6792,
                                    false => 6793,
                                },
                                false => West switch {
                                    true => 6794,
                                    false => 6795,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6796,
                                    false => 6797,
                                },
                                false => West switch {
                                    true => 6798,
                                    false => 6799,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6800,
                                    false => 6801,
                                },
                                false => West switch {
                                    true => 6802,
                                    false => 6803,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6804,
                                    false => 6805,
                                },
                                false => West switch {
                                    true => 6806,
                                    false => 6807,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6808,
                                    false => 6809,
                                },
                                false => West switch {
                                    true => 6810,
                                    false => 6811,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6812,
                                    false => 6813,
                                },
                                false => West switch {
                                    true => 6814,
                                    false => 6815,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6816,
                                    false => 6817,
                                },
                                false => West switch {
                                    true => 6818,
                                    false => 6819,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6820,
                                    false => 6821,
                                },
                                false => West switch {
                                    true => 6822,
                                    false => 6823,
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6824,
                                    false => 6825,
                                },
                                false => West switch {
                                    true => 6826,
                                    false => 6827,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6828,
                                    false => 6829,
                                },
                                false => West switch {
                                    true => 6830,
                                    false => 6831,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6832,
                                    false => 6833,
                                },
                                false => West switch {
                                    true => 6834,
                                    false => 6835,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6836,
                                    false => 6837,
                                },
                                false => West switch {
                                    true => 6838,
                                    false => 6839,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6840,
                                    false => 6841,
                                },
                                false => West switch {
                                    true => 6842,
                                    false => 6843,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6844,
                                    false => 6845,
                                },
                                false => West switch {
                                    true => 6846,
                                    false => 6847,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6848,
                                    false => 6849,
                                },
                                false => West switch {
                                    true => 6850,
                                    false => 6851,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6852,
                                    false => 6853,
                                },
                                false => West switch {
                                    true => 6854,
                                    false => 6855,
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            6792 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            6793 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            6794 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            6795 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            6796 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            6797 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            6798 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            6799 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            6800 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            6801 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            6802 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            6803 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            6804 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            6805 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            6806 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            6807 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            6808 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            6809 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            6810 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            6811 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            6812 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            6813 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            6814 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            6815 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            6816 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            6817 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            6818 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            6819 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            6820 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            6821 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            6822 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            6823 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            6824 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            6825 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            6826 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            6827 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            6828 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            6829 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            6830 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            6831 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            6832 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            6833 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            6834 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            6835 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            6836 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            6837 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            6838 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            6839 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            6840 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            6841 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            6842 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            6843 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            6844 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            6845 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            6846 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            6847 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            6848 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            6849 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            6850 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            6851 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            6852 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            6853 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            6854 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            6855 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
