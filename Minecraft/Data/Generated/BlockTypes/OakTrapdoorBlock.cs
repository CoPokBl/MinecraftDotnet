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
                                true => 7114,
                                false => 7115,
                            },
                            false => Waterlogged switch {
                                true => 7116,
                                false => 7117,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7118,
                                false => 7119,
                            },
                            false => Waterlogged switch {
                                true => 7120,
                                false => 7121,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7122,
                                false => 7123,
                            },
                            false => Waterlogged switch {
                                true => 7124,
                                false => 7125,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7126,
                                false => 7127,
                            },
                            false => Waterlogged switch {
                                true => 7128,
                                false => 7129,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7130,
                                false => 7131,
                            },
                            false => Waterlogged switch {
                                true => 7132,
                                false => 7133,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7134,
                                false => 7135,
                            },
                            false => Waterlogged switch {
                                true => 7136,
                                false => 7137,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7138,
                                false => 7139,
                            },
                            false => Waterlogged switch {
                                true => 7140,
                                false => 7141,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7142,
                                false => 7143,
                            },
                            false => Waterlogged switch {
                                true => 7144,
                                false => 7145,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7146,
                                false => 7147,
                            },
                            false => Waterlogged switch {
                                true => 7148,
                                false => 7149,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7150,
                                false => 7151,
                            },
                            false => Waterlogged switch {
                                true => 7152,
                                false => 7153,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7154,
                                false => 7155,
                            },
                            false => Waterlogged switch {
                                true => 7156,
                                false => 7157,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7158,
                                false => 7159,
                            },
                            false => Waterlogged switch {
                                true => 7160,
                                false => 7161,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7162,
                                false => 7163,
                            },
                            false => Waterlogged switch {
                                true => 7164,
                                false => 7165,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7166,
                                false => 7167,
                            },
                            false => Waterlogged switch {
                                true => 7168,
                                false => 7169,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7170,
                                false => 7171,
                            },
                            false => Waterlogged switch {
                                true => 7172,
                                false => 7173,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7174,
                                false => 7175,
                            },
                            false => Waterlogged switch {
                                true => 7176,
                                false => 7177,
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
            7114 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7115 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7116 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7117 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7118 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7119 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7120 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7121 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7122 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7123 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7124 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7125 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7126 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7127 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7128 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7129 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7130 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7131 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7132 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7133 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7134 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7135 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7136 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7137 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7138 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7139 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7140 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7141 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7142 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7143 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7144 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7145 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7146 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7147 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7148 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7149 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7150 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7151 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7152 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7153 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7154 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7155 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7156 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7157 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7158 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7159 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7160 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7161 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7162 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7163 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7164 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7165 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7166 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7167 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7168 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7169 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7170 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7171 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7172 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7173 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7174 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7175 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7176 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7177 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
