using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleTrapdoorBlock(Identifier Identifier, Direction Facing, JungleTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 318;
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
    public Identifier? Item => "minecraft:jungle_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7105,
                                false => 7106,
                            },
                            false => Waterlogged switch {
                                true => 7107,
                                false => 7108,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7109,
                                false => 7110,
                            },
                            false => Waterlogged switch {
                                true => 7111,
                                false => 7112,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7113,
                                false => 7114,
                            },
                            false => Waterlogged switch {
                                true => 7115,
                                false => 7116,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7117,
                                false => 7118,
                            },
                            false => Waterlogged switch {
                                true => 7119,
                                false => 7120,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7121,
                                false => 7122,
                            },
                            false => Waterlogged switch {
                                true => 7123,
                                false => 7124,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7125,
                                false => 7126,
                            },
                            false => Waterlogged switch {
                                true => 7127,
                                false => 7128,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7129,
                                false => 7130,
                            },
                            false => Waterlogged switch {
                                true => 7131,
                                false => 7132,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7133,
                                false => 7134,
                            },
                            false => Waterlogged switch {
                                true => 7135,
                                false => 7136,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7137,
                                false => 7138,
                            },
                            false => Waterlogged switch {
                                true => 7139,
                                false => 7140,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7141,
                                false => 7142,
                            },
                            false => Waterlogged switch {
                                true => 7143,
                                false => 7144,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7145,
                                false => 7146,
                            },
                            false => Waterlogged switch {
                                true => 7147,
                                false => 7148,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7149,
                                false => 7150,
                            },
                            false => Waterlogged switch {
                                true => 7151,
                                false => 7152,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7153,
                                false => 7154,
                            },
                            false => Waterlogged switch {
                                true => 7155,
                                false => 7156,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7157,
                                false => 7158,
                            },
                            false => Waterlogged switch {
                                true => 7159,
                                false => 7160,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7161,
                                false => 7162,
                            },
                            false => Waterlogged switch {
                                true => 7163,
                                false => 7164,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7165,
                                false => 7166,
                            },
                            false => Waterlogged switch {
                                true => 7167,
                                false => 7168,
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
            7105 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7106 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7107 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7108 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7109 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7110 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7111 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7112 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7113 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7114 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7115 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7116 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7117 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7118 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7119 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7120 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7121 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7122 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7123 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7124 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7125 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7126 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7127 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7128 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7129 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7130 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7131 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7132 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7133 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7134 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7135 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7136 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7137 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7138 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7139 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7140 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7141 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7142 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7143 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7144 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7145 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7146 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7147 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7148 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7149 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7150 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7151 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7152 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7153 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7154 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7155 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7156 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7157 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7158 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7159 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7160 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7161 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7162 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7163 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7164 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7165 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7166 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7167 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7168 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
