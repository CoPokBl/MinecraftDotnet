using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakTrapdoorBlock(Identifier Identifier, Direction Facing, OakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 315;
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
    public Identifier? Item => "minecraft:oak_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6913,
                                false => 6914,
                            },
                            false => Waterlogged switch {
                                true => 6915,
                                false => 6916,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6917,
                                false => 6918,
                            },
                            false => Waterlogged switch {
                                true => 6919,
                                false => 6920,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6921,
                                false => 6922,
                            },
                            false => Waterlogged switch {
                                true => 6923,
                                false => 6924,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6925,
                                false => 6926,
                            },
                            false => Waterlogged switch {
                                true => 6927,
                                false => 6928,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6929,
                                false => 6930,
                            },
                            false => Waterlogged switch {
                                true => 6931,
                                false => 6932,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6933,
                                false => 6934,
                            },
                            false => Waterlogged switch {
                                true => 6935,
                                false => 6936,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6937,
                                false => 6938,
                            },
                            false => Waterlogged switch {
                                true => 6939,
                                false => 6940,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6941,
                                false => 6942,
                            },
                            false => Waterlogged switch {
                                true => 6943,
                                false => 6944,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6945,
                                false => 6946,
                            },
                            false => Waterlogged switch {
                                true => 6947,
                                false => 6948,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6949,
                                false => 6950,
                            },
                            false => Waterlogged switch {
                                true => 6951,
                                false => 6952,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6953,
                                false => 6954,
                            },
                            false => Waterlogged switch {
                                true => 6955,
                                false => 6956,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6957,
                                false => 6958,
                            },
                            false => Waterlogged switch {
                                true => 6959,
                                false => 6960,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6961,
                                false => 6962,
                            },
                            false => Waterlogged switch {
                                true => 6963,
                                false => 6964,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6965,
                                false => 6966,
                            },
                            false => Waterlogged switch {
                                true => 6967,
                                false => 6968,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6969,
                                false => 6970,
                            },
                            false => Waterlogged switch {
                                true => 6971,
                                false => 6972,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6973,
                                false => 6974,
                            },
                            false => Waterlogged switch {
                                true => 6975,
                                false => 6976,
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
            6913 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6914 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6915 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6916 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6917 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6918 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6919 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6920 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6921 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6922 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6923 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6924 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6925 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6926 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6927 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6928 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6929 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6930 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6931 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6932 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6933 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6934 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6935 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6936 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6937 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6938 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6939 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6940 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6941 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6942 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6943 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6944 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6945 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6946 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6947 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6948 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6949 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6950 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6951 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6952 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6953 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6954 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6955 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6956 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6957 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6958 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6959 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6960 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6961 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6962 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6963 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6964 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6965 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6966 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6967 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6968 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6969 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6970 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6971 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6972 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6973 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6974 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6975 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6976 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
