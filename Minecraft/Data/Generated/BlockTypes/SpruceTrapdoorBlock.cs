using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceTrapdoorBlock(Identifier Identifier, Direction Facing, SpruceTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 316;
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
    public Identifier? Item => "minecraft:spruce_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6977,
                                false => 6978,
                            },
                            false => Waterlogged switch {
                                true => 6979,
                                false => 6980,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6981,
                                false => 6982,
                            },
                            false => Waterlogged switch {
                                true => 6983,
                                false => 6984,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6985,
                                false => 6986,
                            },
                            false => Waterlogged switch {
                                true => 6987,
                                false => 6988,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6989,
                                false => 6990,
                            },
                            false => Waterlogged switch {
                                true => 6991,
                                false => 6992,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6993,
                                false => 6994,
                            },
                            false => Waterlogged switch {
                                true => 6995,
                                false => 6996,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6997,
                                false => 6998,
                            },
                            false => Waterlogged switch {
                                true => 6999,
                                false => 7000,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7001,
                                false => 7002,
                            },
                            false => Waterlogged switch {
                                true => 7003,
                                false => 7004,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7005,
                                false => 7006,
                            },
                            false => Waterlogged switch {
                                true => 7007,
                                false => 7008,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7009,
                                false => 7010,
                            },
                            false => Waterlogged switch {
                                true => 7011,
                                false => 7012,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7013,
                                false => 7014,
                            },
                            false => Waterlogged switch {
                                true => 7015,
                                false => 7016,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7017,
                                false => 7018,
                            },
                            false => Waterlogged switch {
                                true => 7019,
                                false => 7020,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7021,
                                false => 7022,
                            },
                            false => Waterlogged switch {
                                true => 7023,
                                false => 7024,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7025,
                                false => 7026,
                            },
                            false => Waterlogged switch {
                                true => 7027,
                                false => 7028,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7029,
                                false => 7030,
                            },
                            false => Waterlogged switch {
                                true => 7031,
                                false => 7032,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7033,
                                false => 7034,
                            },
                            false => Waterlogged switch {
                                true => 7035,
                                false => 7036,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7037,
                                false => 7038,
                            },
                            false => Waterlogged switch {
                                true => 7039,
                                false => 7040,
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
            6977 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6978 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6979 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6980 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6981 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6982 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6983 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6984 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6985 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6986 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6987 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6988 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6989 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6990 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6991 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6992 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6993 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6994 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6995 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6996 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6997 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6998 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6999 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7000 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7001 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7002 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7003 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7004 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7005 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7006 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7007 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7008 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7009 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7010 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7011 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7012 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7013 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7014 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7015 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7016 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7017 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7018 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7019 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7020 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7021 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7022 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7023 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7024 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7025 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7026 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7027 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7028 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7029 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7030 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7031 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7032 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7033 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7034 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7035 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7036 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7037 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7038 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7039 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7040 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
