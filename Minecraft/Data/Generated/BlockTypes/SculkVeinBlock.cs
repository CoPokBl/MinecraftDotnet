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
    public int ProtocolId => 1002;
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
                                        true => 24969,
                                        false => 24970,
                                    },
                                    false => West switch {
                                        true => 24971,
                                        false => 24972,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 24973,
                                        false => 24974,
                                    },
                                    false => West switch {
                                        true => 24975,
                                        false => 24976,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 24977,
                                        false => 24978,
                                    },
                                    false => West switch {
                                        true => 24979,
                                        false => 24980,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 24981,
                                        false => 24982,
                                    },
                                    false => West switch {
                                        true => 24983,
                                        false => 24984,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 24985,
                                        false => 24986,
                                    },
                                    false => West switch {
                                        true => 24987,
                                        false => 24988,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 24989,
                                        false => 24990,
                                    },
                                    false => West switch {
                                        true => 24991,
                                        false => 24992,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 24993,
                                        false => 24994,
                                    },
                                    false => West switch {
                                        true => 24995,
                                        false => 24996,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 24997,
                                        false => 24998,
                                    },
                                    false => West switch {
                                        true => 24999,
                                        false => 25000,
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
                                        true => 25001,
                                        false => 25002,
                                    },
                                    false => West switch {
                                        true => 25003,
                                        false => 25004,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25005,
                                        false => 25006,
                                    },
                                    false => West switch {
                                        true => 25007,
                                        false => 25008,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25009,
                                        false => 25010,
                                    },
                                    false => West switch {
                                        true => 25011,
                                        false => 25012,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25013,
                                        false => 25014,
                                    },
                                    false => West switch {
                                        true => 25015,
                                        false => 25016,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25017,
                                        false => 25018,
                                    },
                                    false => West switch {
                                        true => 25019,
                                        false => 25020,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25021,
                                        false => 25022,
                                    },
                                    false => West switch {
                                        true => 25023,
                                        false => 25024,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25025,
                                        false => 25026,
                                    },
                                    false => West switch {
                                        true => 25027,
                                        false => 25028,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25029,
                                        false => 25030,
                                    },
                                    false => West switch {
                                        true => 25031,
                                        false => 25032,
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
                                        true => 25033,
                                        false => 25034,
                                    },
                                    false => West switch {
                                        true => 25035,
                                        false => 25036,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25037,
                                        false => 25038,
                                    },
                                    false => West switch {
                                        true => 25039,
                                        false => 25040,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25041,
                                        false => 25042,
                                    },
                                    false => West switch {
                                        true => 25043,
                                        false => 25044,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25045,
                                        false => 25046,
                                    },
                                    false => West switch {
                                        true => 25047,
                                        false => 25048,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25049,
                                        false => 25050,
                                    },
                                    false => West switch {
                                        true => 25051,
                                        false => 25052,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25053,
                                        false => 25054,
                                    },
                                    false => West switch {
                                        true => 25055,
                                        false => 25056,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25057,
                                        false => 25058,
                                    },
                                    false => West switch {
                                        true => 25059,
                                        false => 25060,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25061,
                                        false => 25062,
                                    },
                                    false => West switch {
                                        true => 25063,
                                        false => 25064,
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
                                        true => 25065,
                                        false => 25066,
                                    },
                                    false => West switch {
                                        true => 25067,
                                        false => 25068,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25069,
                                        false => 25070,
                                    },
                                    false => West switch {
                                        true => 25071,
                                        false => 25072,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25073,
                                        false => 25074,
                                    },
                                    false => West switch {
                                        true => 25075,
                                        false => 25076,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25077,
                                        false => 25078,
                                    },
                                    false => West switch {
                                        true => 25079,
                                        false => 25080,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25081,
                                        false => 25082,
                                    },
                                    false => West switch {
                                        true => 25083,
                                        false => 25084,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25085,
                                        false => 25086,
                                    },
                                    false => West switch {
                                        true => 25087,
                                        false => 25088,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 25089,
                                        false => 25090,
                                    },
                                    false => West switch {
                                        true => 25091,
                                        false => 25092,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 25093,
                                        false => 25094,
                                    },
                                    false => West switch {
                                        true => 25095,
                                        false => 25096,
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
            24969 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, true),
            24970 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, false),
            24971 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, true),
            24972 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, false),
            24973 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, true),
            24974 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, false),
            24975 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, true),
            24976 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, false),
            24977 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, true),
            24978 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, false),
            24979 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, true),
            24980 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, false),
            24981 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, true),
            24982 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, false),
            24983 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, true),
            24984 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, false),
            24985 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, true),
            24986 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, false),
            24987 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, true),
            24988 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, false),
            24989 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, true),
            24990 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, false),
            24991 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, true),
            24992 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, false),
            24993 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, true),
            24994 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, false),
            24995 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, true),
            24996 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, false),
            24997 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, true),
            24998 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, false),
            24999 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, true),
            25000 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, false),
            25001 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, true),
            25002 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, false),
            25003 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, true),
            25004 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, false),
            25005 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, true),
            25006 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, false),
            25007 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, true),
            25008 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, false),
            25009 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, true),
            25010 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, false),
            25011 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, true),
            25012 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, false),
            25013 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, true),
            25014 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, false),
            25015 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, true),
            25016 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, false),
            25017 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, true),
            25018 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, false),
            25019 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, true),
            25020 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, false),
            25021 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, true),
            25022 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, false),
            25023 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, true),
            25024 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, false),
            25025 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, true),
            25026 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, false),
            25027 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, true),
            25028 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, false),
            25029 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, true),
            25030 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, false),
            25031 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, true),
            25032 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, false),
            25033 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, true),
            25034 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, false),
            25035 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, true),
            25036 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, false),
            25037 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, true),
            25038 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, false),
            25039 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, true),
            25040 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, false),
            25041 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, true),
            25042 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, false),
            25043 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, true),
            25044 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, false),
            25045 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, true),
            25046 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, false),
            25047 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, true),
            25048 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, false),
            25049 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, true),
            25050 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, false),
            25051 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, true),
            25052 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, false),
            25053 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, true),
            25054 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, false),
            25055 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, true),
            25056 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, false),
            25057 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, true),
            25058 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, false),
            25059 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, true),
            25060 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, false),
            25061 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, true),
            25062 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, false),
            25063 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, true),
            25064 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, false),
            25065 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, true),
            25066 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, false),
            25067 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, true),
            25068 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, false),
            25069 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, true),
            25070 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, false),
            25071 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, true),
            25072 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, false),
            25073 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, true),
            25074 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, false),
            25075 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, true),
            25076 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, false),
            25077 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, true),
            25078 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, false),
            25079 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, true),
            25080 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, false),
            25081 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, true),
            25082 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, false),
            25083 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, true),
            25084 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, false),
            25085 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, true),
            25086 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, false),
            25087 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, true),
            25088 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, false),
            25089 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, true),
            25090 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, false),
            25091 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, true),
            25092 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, false),
            25093 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, true),
            25094 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, false),
            25095 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, true),
            25096 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.ChildrenMap.ContainsKey("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
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
