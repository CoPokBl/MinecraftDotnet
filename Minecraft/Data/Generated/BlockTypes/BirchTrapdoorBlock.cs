using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchTrapdoorBlock(Identifier Identifier, Direction Facing, BirchTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 317;
    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:birch_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7041,
                                false => 7042,
                            },
                            false => Waterlogged switch {
                                true => 7043,
                                false => 7044,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7045,
                                false => 7046,
                            },
                            false => Waterlogged switch {
                                true => 7047,
                                false => 7048,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7049,
                                false => 7050,
                            },
                            false => Waterlogged switch {
                                true => 7051,
                                false => 7052,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7053,
                                false => 7054,
                            },
                            false => Waterlogged switch {
                                true => 7055,
                                false => 7056,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7057,
                                false => 7058,
                            },
                            false => Waterlogged switch {
                                true => 7059,
                                false => 7060,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7061,
                                false => 7062,
                            },
                            false => Waterlogged switch {
                                true => 7063,
                                false => 7064,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7065,
                                false => 7066,
                            },
                            false => Waterlogged switch {
                                true => 7067,
                                false => 7068,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7069,
                                false => 7070,
                            },
                            false => Waterlogged switch {
                                true => 7071,
                                false => 7072,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7073,
                                false => 7074,
                            },
                            false => Waterlogged switch {
                                true => 7075,
                                false => 7076,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7077,
                                false => 7078,
                            },
                            false => Waterlogged switch {
                                true => 7079,
                                false => 7080,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7081,
                                false => 7082,
                            },
                            false => Waterlogged switch {
                                true => 7083,
                                false => 7084,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7085,
                                false => 7086,
                            },
                            false => Waterlogged switch {
                                true => 7087,
                                false => 7088,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7089,
                                false => 7090,
                            },
                            false => Waterlogged switch {
                                true => 7091,
                                false => 7092,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7093,
                                false => 7094,
                            },
                            false => Waterlogged switch {
                                true => 7095,
                                false => 7096,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7097,
                                false => 7098,
                            },
                            false => Waterlogged switch {
                                true => 7099,
                                false => 7100,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7101,
                                false => 7102,
                            },
                            false => Waterlogged switch {
                                true => 7103,
                                false => 7104,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7041 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7042 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7043 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7044 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7045 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7046 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7047 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7048 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7049 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7050 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7051 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7052 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7053 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7054 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7055 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7056 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7057 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7058 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7059 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7060 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7061 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7062 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7063 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7064 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7065 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7066 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7067 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7068 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7069 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7070 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7071 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7072 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7073 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7074 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7075 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7076 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7077 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7078 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7079 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7080 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7081 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7082 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7083 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7084 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7085 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7086 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7087 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7088 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7089 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7090 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7091 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7092 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7093 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7094 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7095 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7096 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7097 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7098 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7099 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7100 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7101 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7102 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7103 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7104 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
