using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MushroomStemBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6920,
                                    false => 6921,
                                },
                                false => West switch {
                                    true => 6922,
                                    false => 6923,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6924,
                                    false => 6925,
                                },
                                false => West switch {
                                    true => 6926,
                                    false => 6927,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6928,
                                    false => 6929,
                                },
                                false => West switch {
                                    true => 6930,
                                    false => 6931,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6932,
                                    false => 6933,
                                },
                                false => West switch {
                                    true => 6934,
                                    false => 6935,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6936,
                                    false => 6937,
                                },
                                false => West switch {
                                    true => 6938,
                                    false => 6939,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6940,
                                    false => 6941,
                                },
                                false => West switch {
                                    true => 6942,
                                    false => 6943,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6944,
                                    false => 6945,
                                },
                                false => West switch {
                                    true => 6946,
                                    false => 6947,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6948,
                                    false => 6949,
                                },
                                false => West switch {
                                    true => 6950,
                                    false => 6951,
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
                                    true => 6952,
                                    false => 6953,
                                },
                                false => West switch {
                                    true => 6954,
                                    false => 6955,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6956,
                                    false => 6957,
                                },
                                false => West switch {
                                    true => 6958,
                                    false => 6959,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6960,
                                    false => 6961,
                                },
                                false => West switch {
                                    true => 6962,
                                    false => 6963,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6964,
                                    false => 6965,
                                },
                                false => West switch {
                                    true => 6966,
                                    false => 6967,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6968,
                                    false => 6969,
                                },
                                false => West switch {
                                    true => 6970,
                                    false => 6971,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6972,
                                    false => 6973,
                                },
                                false => West switch {
                                    true => 6974,
                                    false => 6975,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 6976,
                                    false => 6977,
                                },
                                false => West switch {
                                    true => 6978,
                                    false => 6979,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 6980,
                                    false => 6981,
                                },
                                false => West switch {
                                    true => 6982,
                                    false => 6983,
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6920 => new MushroomStemBlock(Identifier, true, true, true, true, true, true),
            6921 => new MushroomStemBlock(Identifier, true, true, true, true, true, false),
            6922 => new MushroomStemBlock(Identifier, true, true, true, true, false, true),
            6923 => new MushroomStemBlock(Identifier, true, true, true, true, false, false),
            6924 => new MushroomStemBlock(Identifier, true, true, true, false, true, true),
            6925 => new MushroomStemBlock(Identifier, true, true, true, false, true, false),
            6926 => new MushroomStemBlock(Identifier, true, true, true, false, false, true),
            6927 => new MushroomStemBlock(Identifier, true, true, true, false, false, false),
            6928 => new MushroomStemBlock(Identifier, true, true, false, true, true, true),
            6929 => new MushroomStemBlock(Identifier, true, true, false, true, true, false),
            6930 => new MushroomStemBlock(Identifier, true, true, false, true, false, true),
            6931 => new MushroomStemBlock(Identifier, true, true, false, true, false, false),
            6932 => new MushroomStemBlock(Identifier, true, true, false, false, true, true),
            6933 => new MushroomStemBlock(Identifier, true, true, false, false, true, false),
            6934 => new MushroomStemBlock(Identifier, true, true, false, false, false, true),
            6935 => new MushroomStemBlock(Identifier, true, true, false, false, false, false),
            6936 => new MushroomStemBlock(Identifier, true, false, true, true, true, true),
            6937 => new MushroomStemBlock(Identifier, true, false, true, true, true, false),
            6938 => new MushroomStemBlock(Identifier, true, false, true, true, false, true),
            6939 => new MushroomStemBlock(Identifier, true, false, true, true, false, false),
            6940 => new MushroomStemBlock(Identifier, true, false, true, false, true, true),
            6941 => new MushroomStemBlock(Identifier, true, false, true, false, true, false),
            6942 => new MushroomStemBlock(Identifier, true, false, true, false, false, true),
            6943 => new MushroomStemBlock(Identifier, true, false, true, false, false, false),
            6944 => new MushroomStemBlock(Identifier, true, false, false, true, true, true),
            6945 => new MushroomStemBlock(Identifier, true, false, false, true, true, false),
            6946 => new MushroomStemBlock(Identifier, true, false, false, true, false, true),
            6947 => new MushroomStemBlock(Identifier, true, false, false, true, false, false),
            6948 => new MushroomStemBlock(Identifier, true, false, false, false, true, true),
            6949 => new MushroomStemBlock(Identifier, true, false, false, false, true, false),
            6950 => new MushroomStemBlock(Identifier, true, false, false, false, false, true),
            6951 => new MushroomStemBlock(Identifier, true, false, false, false, false, false),
            6952 => new MushroomStemBlock(Identifier, false, true, true, true, true, true),
            6953 => new MushroomStemBlock(Identifier, false, true, true, true, true, false),
            6954 => new MushroomStemBlock(Identifier, false, true, true, true, false, true),
            6955 => new MushroomStemBlock(Identifier, false, true, true, true, false, false),
            6956 => new MushroomStemBlock(Identifier, false, true, true, false, true, true),
            6957 => new MushroomStemBlock(Identifier, false, true, true, false, true, false),
            6958 => new MushroomStemBlock(Identifier, false, true, true, false, false, true),
            6959 => new MushroomStemBlock(Identifier, false, true, true, false, false, false),
            6960 => new MushroomStemBlock(Identifier, false, true, false, true, true, true),
            6961 => new MushroomStemBlock(Identifier, false, true, false, true, true, false),
            6962 => new MushroomStemBlock(Identifier, false, true, false, true, false, true),
            6963 => new MushroomStemBlock(Identifier, false, true, false, true, false, false),
            6964 => new MushroomStemBlock(Identifier, false, true, false, false, true, true),
            6965 => new MushroomStemBlock(Identifier, false, true, false, false, true, false),
            6966 => new MushroomStemBlock(Identifier, false, true, false, false, false, true),
            6967 => new MushroomStemBlock(Identifier, false, true, false, false, false, false),
            6968 => new MushroomStemBlock(Identifier, false, false, true, true, true, true),
            6969 => new MushroomStemBlock(Identifier, false, false, true, true, true, false),
            6970 => new MushroomStemBlock(Identifier, false, false, true, true, false, true),
            6971 => new MushroomStemBlock(Identifier, false, false, true, true, false, false),
            6972 => new MushroomStemBlock(Identifier, false, false, true, false, true, true),
            6973 => new MushroomStemBlock(Identifier, false, false, true, false, true, false),
            6974 => new MushroomStemBlock(Identifier, false, false, true, false, false, true),
            6975 => new MushroomStemBlock(Identifier, false, false, true, false, false, false),
            6976 => new MushroomStemBlock(Identifier, false, false, false, true, true, true),
            6977 => new MushroomStemBlock(Identifier, false, false, false, true, true, false),
            6978 => new MushroomStemBlock(Identifier, false, false, false, true, false, true),
            6979 => new MushroomStemBlock(Identifier, false, false, false, true, false, false),
            6980 => new MushroomStemBlock(Identifier, false, false, false, false, true, true),
            6981 => new MushroomStemBlock(Identifier, false, false, false, false, true, false),
            6982 => new MushroomStemBlock(Identifier, false, false, false, false, false, true),
            6983 => new MushroomStemBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties["down"].GetString() == "true",
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Up = properties["up"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
