using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkVeinBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:sculk_vein";
    public int ProtocolId => 964;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "sculk_vein";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sculk_vein";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.sculk_vein";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23860,
                                        false => 23861,
                                    },
                                    false => West switch {
                                        true => 23862,
                                        false => 23863,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23864,
                                        false => 23865,
                                    },
                                    false => West switch {
                                        true => 23866,
                                        false => 23867,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23868,
                                        false => 23869,
                                    },
                                    false => West switch {
                                        true => 23870,
                                        false => 23871,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23872,
                                        false => 23873,
                                    },
                                    false => West switch {
                                        true => 23874,
                                        false => 23875,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23876,
                                        false => 23877,
                                    },
                                    false => West switch {
                                        true => 23878,
                                        false => 23879,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23880,
                                        false => 23881,
                                    },
                                    false => West switch {
                                        true => 23882,
                                        false => 23883,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23884,
                                        false => 23885,
                                    },
                                    false => West switch {
                                        true => 23886,
                                        false => 23887,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23888,
                                        false => 23889,
                                    },
                                    false => West switch {
                                        true => 23890,
                                        false => 23891,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23892,
                                        false => 23893,
                                    },
                                    false => West switch {
                                        true => 23894,
                                        false => 23895,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23896,
                                        false => 23897,
                                    },
                                    false => West switch {
                                        true => 23898,
                                        false => 23899,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23900,
                                        false => 23901,
                                    },
                                    false => West switch {
                                        true => 23902,
                                        false => 23903,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23904,
                                        false => 23905,
                                    },
                                    false => West switch {
                                        true => 23906,
                                        false => 23907,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23908,
                                        false => 23909,
                                    },
                                    false => West switch {
                                        true => 23910,
                                        false => 23911,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23912,
                                        false => 23913,
                                    },
                                    false => West switch {
                                        true => 23914,
                                        false => 23915,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23916,
                                        false => 23917,
                                    },
                                    false => West switch {
                                        true => 23918,
                                        false => 23919,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23920,
                                        false => 23921,
                                    },
                                    false => West switch {
                                        true => 23922,
                                        false => 23923,
                                    },
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23924,
                                        false => 23925,
                                    },
                                    false => West switch {
                                        true => 23926,
                                        false => 23927,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23928,
                                        false => 23929,
                                    },
                                    false => West switch {
                                        true => 23930,
                                        false => 23931,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23932,
                                        false => 23933,
                                    },
                                    false => West switch {
                                        true => 23934,
                                        false => 23935,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23936,
                                        false => 23937,
                                    },
                                    false => West switch {
                                        true => 23938,
                                        false => 23939,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23940,
                                        false => 23941,
                                    },
                                    false => West switch {
                                        true => 23942,
                                        false => 23943,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23944,
                                        false => 23945,
                                    },
                                    false => West switch {
                                        true => 23946,
                                        false => 23947,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23948,
                                        false => 23949,
                                    },
                                    false => West switch {
                                        true => 23950,
                                        false => 23951,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23952,
                                        false => 23953,
                                    },
                                    false => West switch {
                                        true => 23954,
                                        false => 23955,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23956,
                                        false => 23957,
                                    },
                                    false => West switch {
                                        true => 23958,
                                        false => 23959,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23960,
                                        false => 23961,
                                    },
                                    false => West switch {
                                        true => 23962,
                                        false => 23963,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23964,
                                        false => 23965,
                                    },
                                    false => West switch {
                                        true => 23966,
                                        false => 23967,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23968,
                                        false => 23969,
                                    },
                                    false => West switch {
                                        true => 23970,
                                        false => 23971,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23972,
                                        false => 23973,
                                    },
                                    false => West switch {
                                        true => 23974,
                                        false => 23975,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23976,
                                        false => 23977,
                                    },
                                    false => West switch {
                                        true => 23978,
                                        false => 23979,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 23980,
                                        false => 23981,
                                    },
                                    false => West switch {
                                        true => 23982,
                                        false => 23983,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 23984,
                                        false => 23985,
                                    },
                                    false => West switch {
                                        true => 23986,
                                        false => 23987,
                                    },
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
            23860 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, true),
            23861 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, false),
            23862 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, true),
            23863 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, false),
            23864 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, true),
            23865 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, false),
            23866 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, true),
            23867 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, false),
            23868 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, true),
            23869 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, false),
            23870 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, true),
            23871 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, false),
            23872 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, true),
            23873 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, false),
            23874 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, true),
            23875 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, false),
            23876 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, true),
            23877 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, false),
            23878 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, true),
            23879 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, false),
            23880 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, true),
            23881 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, false),
            23882 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, true),
            23883 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, false),
            23884 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, true),
            23885 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, false),
            23886 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, true),
            23887 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, false),
            23888 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, true),
            23889 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, false),
            23890 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, true),
            23891 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, false),
            23892 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, true),
            23893 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, false),
            23894 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, true),
            23895 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, false),
            23896 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, true),
            23897 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, false),
            23898 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, true),
            23899 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, false),
            23900 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, true),
            23901 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, false),
            23902 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, true),
            23903 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, false),
            23904 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, true),
            23905 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, false),
            23906 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, true),
            23907 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, false),
            23908 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, true),
            23909 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, false),
            23910 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, true),
            23911 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, false),
            23912 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, true),
            23913 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, false),
            23914 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, true),
            23915 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, false),
            23916 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, true),
            23917 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, false),
            23918 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, true),
            23919 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, false),
            23920 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, true),
            23921 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, false),
            23922 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, true),
            23923 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, false),
            23924 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, true),
            23925 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, false),
            23926 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, true),
            23927 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, false),
            23928 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, true),
            23929 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, false),
            23930 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, true),
            23931 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, false),
            23932 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, true),
            23933 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, false),
            23934 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, true),
            23935 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, false),
            23936 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, true),
            23937 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, false),
            23938 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, true),
            23939 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, false),
            23940 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, true),
            23941 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, false),
            23942 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, true),
            23943 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, false),
            23944 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, true),
            23945 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, false),
            23946 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, true),
            23947 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, false),
            23948 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, true),
            23949 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, false),
            23950 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, true),
            23951 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, false),
            23952 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, true),
            23953 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, false),
            23954 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, true),
            23955 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, false),
            23956 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, true),
            23957 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, false),
            23958 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, true),
            23959 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, false),
            23960 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, true),
            23961 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, false),
            23962 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, true),
            23963 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, false),
            23964 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, true),
            23965 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, false),
            23966 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, true),
            23967 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, false),
            23968 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, true),
            23969 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, false),
            23970 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, true),
            23971 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, false),
            23972 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, true),
            23973 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, false),
            23974 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, true),
            23975 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, false),
            23976 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, true),
            23977 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, false),
            23978 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, true),
            23979 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, false),
            23980 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, true),
            23981 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, false),
            23982 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, true),
            23983 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, false),
            23984 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, true),
            23985 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, false),
            23986 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, true),
            23987 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, false),
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
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("down", Down.ToString().ToLower()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
