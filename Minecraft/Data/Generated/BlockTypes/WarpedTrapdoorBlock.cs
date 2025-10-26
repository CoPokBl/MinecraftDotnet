using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedTrapdoorBlock(Identifier Identifier, Direction Facing, WarpedTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 890;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20976,
                                false => 20977,
                            },
                            false => Waterlogged switch {
                                true => 20978,
                                false => 20979,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20980,
                                false => 20981,
                            },
                            false => Waterlogged switch {
                                true => 20982,
                                false => 20983,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20984,
                                false => 20985,
                            },
                            false => Waterlogged switch {
                                true => 20986,
                                false => 20987,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20988,
                                false => 20989,
                            },
                            false => Waterlogged switch {
                                true => 20990,
                                false => 20991,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20992,
                                false => 20993,
                            },
                            false => Waterlogged switch {
                                true => 20994,
                                false => 20995,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20996,
                                false => 20997,
                            },
                            false => Waterlogged switch {
                                true => 20998,
                                false => 20999,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21000,
                                false => 21001,
                            },
                            false => Waterlogged switch {
                                true => 21002,
                                false => 21003,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21004,
                                false => 21005,
                            },
                            false => Waterlogged switch {
                                true => 21006,
                                false => 21007,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21008,
                                false => 21009,
                            },
                            false => Waterlogged switch {
                                true => 21010,
                                false => 21011,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21012,
                                false => 21013,
                            },
                            false => Waterlogged switch {
                                true => 21014,
                                false => 21015,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21016,
                                false => 21017,
                            },
                            false => Waterlogged switch {
                                true => 21018,
                                false => 21019,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21020,
                                false => 21021,
                            },
                            false => Waterlogged switch {
                                true => 21022,
                                false => 21023,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21024,
                                false => 21025,
                            },
                            false => Waterlogged switch {
                                true => 21026,
                                false => 21027,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21028,
                                false => 21029,
                            },
                            false => Waterlogged switch {
                                true => 21030,
                                false => 21031,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21032,
                                false => 21033,
                            },
                            false => Waterlogged switch {
                                true => 21034,
                                false => 21035,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21036,
                                false => 21037,
                            },
                            false => Waterlogged switch {
                                true => 21038,
                                false => 21039,
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
            20976 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            20977 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            20978 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            20979 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            20980 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            20981 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            20982 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            20983 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            20984 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            20985 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            20986 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            20987 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            20988 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            20989 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            20990 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            20991 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            20992 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            20993 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            20994 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            20995 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            20996 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            20997 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            20998 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            20999 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            21000 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            21001 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            21002 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            21003 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            21004 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            21005 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            21006 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            21007 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            21008 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            21009 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            21010 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            21011 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            21012 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            21013 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            21014 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            21015 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            21016 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            21017 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            21018 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            21019 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            21020 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            21021 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            21022 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            21023 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            21024 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            21025 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            21026 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            21027 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            21028 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            21029 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            21030 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            21031 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            21032 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            21033 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            21034 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            21035 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            21036 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            21037 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            21038 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            21039 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
