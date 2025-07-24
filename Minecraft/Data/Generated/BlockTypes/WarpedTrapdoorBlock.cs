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
    public int ProtocolId => 852;
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
                                true => 19867,
                                false => 19868,
                            },
                            false => Waterlogged switch {
                                true => 19869,
                                false => 19870,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19871,
                                false => 19872,
                            },
                            false => Waterlogged switch {
                                true => 19873,
                                false => 19874,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19875,
                                false => 19876,
                            },
                            false => Waterlogged switch {
                                true => 19877,
                                false => 19878,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19879,
                                false => 19880,
                            },
                            false => Waterlogged switch {
                                true => 19881,
                                false => 19882,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19883,
                                false => 19884,
                            },
                            false => Waterlogged switch {
                                true => 19885,
                                false => 19886,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19887,
                                false => 19888,
                            },
                            false => Waterlogged switch {
                                true => 19889,
                                false => 19890,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19891,
                                false => 19892,
                            },
                            false => Waterlogged switch {
                                true => 19893,
                                false => 19894,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19895,
                                false => 19896,
                            },
                            false => Waterlogged switch {
                                true => 19897,
                                false => 19898,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19899,
                                false => 19900,
                            },
                            false => Waterlogged switch {
                                true => 19901,
                                false => 19902,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19903,
                                false => 19904,
                            },
                            false => Waterlogged switch {
                                true => 19905,
                                false => 19906,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19907,
                                false => 19908,
                            },
                            false => Waterlogged switch {
                                true => 19909,
                                false => 19910,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19911,
                                false => 19912,
                            },
                            false => Waterlogged switch {
                                true => 19913,
                                false => 19914,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19915,
                                false => 19916,
                            },
                            false => Waterlogged switch {
                                true => 19917,
                                false => 19918,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19919,
                                false => 19920,
                            },
                            false => Waterlogged switch {
                                true => 19921,
                                false => 19922,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19923,
                                false => 19924,
                            },
                            false => Waterlogged switch {
                                true => 19925,
                                false => 19926,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19927,
                                false => 19928,
                            },
                            false => Waterlogged switch {
                                true => 19929,
                                false => 19930,
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
            19867 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            19868 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            19869 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            19870 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            19871 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            19872 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            19873 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            19874 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            19875 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            19876 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            19877 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            19878 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            19879 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            19880 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            19881 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            19882 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            19883 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            19884 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            19885 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            19886 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            19887 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            19888 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            19889 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            19890 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            19891 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            19892 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            19893 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            19894 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            19895 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            19896 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            19897 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            19898 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            19899 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            19900 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            19901 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            19902 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            19903 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            19904 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            19905 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            19906 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            19907 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            19908 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            19909 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            19910 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            19911 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            19912 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            19913 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            19914 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            19915 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            19916 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            19917 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            19918 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            19919 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            19920 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            19921 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            19922 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            19923 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            19924 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            19925 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            19926 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            19927 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            19928 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            19929 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            19930 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
