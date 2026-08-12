using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperTrapdoorBlock(Identifier Identifier, Direction Facing, CopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_trapdoor";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29008,
                                false => 29009,
                            },
                            false => Waterlogged switch {
                                true => 29010,
                                false => 29011,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29012,
                                false => 29013,
                            },
                            false => Waterlogged switch {
                                true => 29014,
                                false => 29015,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29016,
                                false => 29017,
                            },
                            false => Waterlogged switch {
                                true => 29018,
                                false => 29019,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29020,
                                false => 29021,
                            },
                            false => Waterlogged switch {
                                true => 29022,
                                false => 29023,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29024,
                                false => 29025,
                            },
                            false => Waterlogged switch {
                                true => 29026,
                                false => 29027,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29028,
                                false => 29029,
                            },
                            false => Waterlogged switch {
                                true => 29030,
                                false => 29031,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29032,
                                false => 29033,
                            },
                            false => Waterlogged switch {
                                true => 29034,
                                false => 29035,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29036,
                                false => 29037,
                            },
                            false => Waterlogged switch {
                                true => 29038,
                                false => 29039,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29040,
                                false => 29041,
                            },
                            false => Waterlogged switch {
                                true => 29042,
                                false => 29043,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29044,
                                false => 29045,
                            },
                            false => Waterlogged switch {
                                true => 29046,
                                false => 29047,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29048,
                                false => 29049,
                            },
                            false => Waterlogged switch {
                                true => 29050,
                                false => 29051,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29052,
                                false => 29053,
                            },
                            false => Waterlogged switch {
                                true => 29054,
                                false => 29055,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29056,
                                false => 29057,
                            },
                            false => Waterlogged switch {
                                true => 29058,
                                false => 29059,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29060,
                                false => 29061,
                            },
                            false => Waterlogged switch {
                                true => 29062,
                                false => 29063,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29064,
                                false => 29065,
                            },
                            false => Waterlogged switch {
                                true => 29066,
                                false => 29067,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29068,
                                false => 29069,
                            },
                            false => Waterlogged switch {
                                true => 29070,
                                false => 29071,
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
            29008 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29009 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29010 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29011 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29012 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29013 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29014 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29015 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29016 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29017 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29018 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29019 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29020 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29021 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29022 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29023 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29024 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29025 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29026 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29027 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29028 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29029 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29030 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29031 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29032 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29033 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29034 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29035 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29036 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29037 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29038 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29039 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29040 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29041 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29042 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29043 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29044 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29045 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29046 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29047 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29048 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29049 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29050 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29051 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29052 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29053 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29054 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29055 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29056 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29057 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29058 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29059 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29060 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29061 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29062 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29063 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29064 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29065 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29066 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29067 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29068 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29069 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29070 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29071 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
