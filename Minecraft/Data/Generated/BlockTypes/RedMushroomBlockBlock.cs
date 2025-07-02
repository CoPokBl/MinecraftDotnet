using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record RedMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6856,
                                    false => 6857,
                                },
                                false => West switch {
                                    true => 6858,
                                    false => 6859,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6860,
                                    false => 6861,
                                },
                                false => West switch {
                                    true => 6862,
                                    false => 6863,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6864,
                                    false => 6865,
                                },
                                false => West switch {
                                    true => 6866,
                                    false => 6867,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6868,
                                    false => 6869,
                                },
                                false => West switch {
                                    true => 6870,
                                    false => 6871,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6872,
                                    false => 6873,
                                },
                                false => West switch {
                                    true => 6874,
                                    false => 6875,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6876,
                                    false => 6877,
                                },
                                false => West switch {
                                    true => 6878,
                                    false => 6879,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6880,
                                    false => 6881,
                                },
                                false => West switch {
                                    true => 6882,
                                    false => 6883,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6884,
                                    false => 6885,
                                },
                                false => West switch {
                                    true => 6886,
                                    false => 6887,
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
                                    true => 6888,
                                    false => 6889,
                                },
                                false => West switch {
                                    true => 6890,
                                    false => 6891,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6892,
                                    false => 6893,
                                },
                                false => West switch {
                                    true => 6894,
                                    false => 6895,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6896,
                                    false => 6897,
                                },
                                false => West switch {
                                    true => 6898,
                                    false => 6899,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6900,
                                    false => 6901,
                                },
                                false => West switch {
                                    true => 6902,
                                    false => 6903,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6904,
                                    false => 6905,
                                },
                                false => West switch {
                                    true => 6906,
                                    false => 6907,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6908,
                                    false => 6909,
                                },
                                false => West switch {
                                    true => 6910,
                                    false => 6911,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6912,
                                    false => 6913,
                                },
                                false => West switch {
                                    true => 6914,
                                    false => 6915,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6916,
                                    false => 6917,
                                },
                                false => West switch {
                                    true => 6918,
                                    false => 6919,
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
            6856 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            6857 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            6858 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            6859 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            6860 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            6861 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            6862 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            6863 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            6864 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            6865 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            6866 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            6867 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            6868 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            6869 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            6870 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            6871 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            6872 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            6873 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            6874 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            6875 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            6876 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            6877 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            6878 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            6879 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            6880 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            6881 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            6882 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            6883 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            6884 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            6885 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            6886 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            6887 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            6888 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            6889 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            6890 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            6891 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            6892 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            6893 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            6894 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            6895 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            6896 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            6897 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            6898 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            6899 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            6900 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            6901 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            6902 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            6903 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            6904 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            6905 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            6906 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            6907 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            6908 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            6909 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            6910 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            6911 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            6912 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            6913 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            6914 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            6915 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            6916 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            6917 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            6918 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            6919 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
