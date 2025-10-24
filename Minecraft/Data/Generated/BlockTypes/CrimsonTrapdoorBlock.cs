using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonTrapdoorBlock(Identifier Identifier, Direction Facing, CrimsonTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 889;
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
    public Identifier? Item => "minecraft:crimson_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20912,
                                false => 20913,
                            },
                            false => Waterlogged switch {
                                true => 20914,
                                false => 20915,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20916,
                                false => 20917,
                            },
                            false => Waterlogged switch {
                                true => 20918,
                                false => 20919,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20920,
                                false => 20921,
                            },
                            false => Waterlogged switch {
                                true => 20922,
                                false => 20923,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20924,
                                false => 20925,
                            },
                            false => Waterlogged switch {
                                true => 20926,
                                false => 20927,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20928,
                                false => 20929,
                            },
                            false => Waterlogged switch {
                                true => 20930,
                                false => 20931,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20932,
                                false => 20933,
                            },
                            false => Waterlogged switch {
                                true => 20934,
                                false => 20935,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20936,
                                false => 20937,
                            },
                            false => Waterlogged switch {
                                true => 20938,
                                false => 20939,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20940,
                                false => 20941,
                            },
                            false => Waterlogged switch {
                                true => 20942,
                                false => 20943,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20944,
                                false => 20945,
                            },
                            false => Waterlogged switch {
                                true => 20946,
                                false => 20947,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20948,
                                false => 20949,
                            },
                            false => Waterlogged switch {
                                true => 20950,
                                false => 20951,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20952,
                                false => 20953,
                            },
                            false => Waterlogged switch {
                                true => 20954,
                                false => 20955,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20956,
                                false => 20957,
                            },
                            false => Waterlogged switch {
                                true => 20958,
                                false => 20959,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20960,
                                false => 20961,
                            },
                            false => Waterlogged switch {
                                true => 20962,
                                false => 20963,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20964,
                                false => 20965,
                            },
                            false => Waterlogged switch {
                                true => 20966,
                                false => 20967,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 20968,
                                false => 20969,
                            },
                            false => Waterlogged switch {
                                true => 20970,
                                false => 20971,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 20972,
                                false => 20973,
                            },
                            false => Waterlogged switch {
                                true => 20974,
                                false => 20975,
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
            20912 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            20913 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            20914 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            20915 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            20916 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            20917 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            20918 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            20919 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            20920 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            20921 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            20922 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            20923 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            20924 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            20925 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            20926 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            20927 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            20928 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            20929 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            20930 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            20931 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            20932 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            20933 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            20934 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            20935 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            20936 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            20937 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            20938 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            20939 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            20940 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            20941 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            20942 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            20943 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            20944 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            20945 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            20946 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            20947 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            20948 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            20949 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            20950 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            20951 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            20952 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            20953 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            20954 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            20955 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            20956 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            20957 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            20958 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            20959 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            20960 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            20961 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            20962 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            20963 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            20964 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            20965 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            20966 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            20967 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            20968 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            20969 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            20970 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            20971 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            20972 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            20973 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            20974 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            20975 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
