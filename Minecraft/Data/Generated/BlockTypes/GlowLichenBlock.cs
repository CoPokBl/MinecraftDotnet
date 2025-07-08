using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GlowLichenBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:glow_lichen";
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "glow_lichen";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:glow_lichen";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 61;
    public string TranslationKey => "block.minecraft.glow_lichen";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7112,
                                        false => 7113,
                                    },
                                    false => West switch {
                                        true => 7114,
                                        false => 7115,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7116,
                                        false => 7117,
                                    },
                                    false => West switch {
                                        true => 7118,
                                        false => 7119,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7120,
                                        false => 7121,
                                    },
                                    false => West switch {
                                        true => 7122,
                                        false => 7123,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7124,
                                        false => 7125,
                                    },
                                    false => West switch {
                                        true => 7126,
                                        false => 7127,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7128,
                                        false => 7129,
                                    },
                                    false => West switch {
                                        true => 7130,
                                        false => 7131,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7132,
                                        false => 7133,
                                    },
                                    false => West switch {
                                        true => 7134,
                                        false => 7135,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7136,
                                        false => 7137,
                                    },
                                    false => West switch {
                                        true => 7138,
                                        false => 7139,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7140,
                                        false => 7141,
                                    },
                                    false => West switch {
                                        true => 7142,
                                        false => 7143,
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
                                        true => 7144,
                                        false => 7145,
                                    },
                                    false => West switch {
                                        true => 7146,
                                        false => 7147,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7148,
                                        false => 7149,
                                    },
                                    false => West switch {
                                        true => 7150,
                                        false => 7151,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7152,
                                        false => 7153,
                                    },
                                    false => West switch {
                                        true => 7154,
                                        false => 7155,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7156,
                                        false => 7157,
                                    },
                                    false => West switch {
                                        true => 7158,
                                        false => 7159,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7160,
                                        false => 7161,
                                    },
                                    false => West switch {
                                        true => 7162,
                                        false => 7163,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7164,
                                        false => 7165,
                                    },
                                    false => West switch {
                                        true => 7166,
                                        false => 7167,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7168,
                                        false => 7169,
                                    },
                                    false => West switch {
                                        true => 7170,
                                        false => 7171,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7172,
                                        false => 7173,
                                    },
                                    false => West switch {
                                        true => 7174,
                                        false => 7175,
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
                                        true => 7176,
                                        false => 7177,
                                    },
                                    false => West switch {
                                        true => 7178,
                                        false => 7179,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7180,
                                        false => 7181,
                                    },
                                    false => West switch {
                                        true => 7182,
                                        false => 7183,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7184,
                                        false => 7185,
                                    },
                                    false => West switch {
                                        true => 7186,
                                        false => 7187,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7188,
                                        false => 7189,
                                    },
                                    false => West switch {
                                        true => 7190,
                                        false => 7191,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7192,
                                        false => 7193,
                                    },
                                    false => West switch {
                                        true => 7194,
                                        false => 7195,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7196,
                                        false => 7197,
                                    },
                                    false => West switch {
                                        true => 7198,
                                        false => 7199,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7200,
                                        false => 7201,
                                    },
                                    false => West switch {
                                        true => 7202,
                                        false => 7203,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7204,
                                        false => 7205,
                                    },
                                    false => West switch {
                                        true => 7206,
                                        false => 7207,
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
                                        true => 7208,
                                        false => 7209,
                                    },
                                    false => West switch {
                                        true => 7210,
                                        false => 7211,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7212,
                                        false => 7213,
                                    },
                                    false => West switch {
                                        true => 7214,
                                        false => 7215,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7216,
                                        false => 7217,
                                    },
                                    false => West switch {
                                        true => 7218,
                                        false => 7219,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7220,
                                        false => 7221,
                                    },
                                    false => West switch {
                                        true => 7222,
                                        false => 7223,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7224,
                                        false => 7225,
                                    },
                                    false => West switch {
                                        true => 7226,
                                        false => 7227,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7228,
                                        false => 7229,
                                    },
                                    false => West switch {
                                        true => 7230,
                                        false => 7231,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7232,
                                        false => 7233,
                                    },
                                    false => West switch {
                                        true => 7234,
                                        false => 7235,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7236,
                                        false => 7237,
                                    },
                                    false => West switch {
                                        true => 7238,
                                        false => 7239,
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
            7112 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, true),
            7113 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, false),
            7114 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, true),
            7115 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, false),
            7116 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, true),
            7117 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, false),
            7118 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, true),
            7119 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, false),
            7120 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, true),
            7121 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, false),
            7122 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, true),
            7123 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, false),
            7124 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, true),
            7125 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, false),
            7126 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, true),
            7127 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, false),
            7128 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, true),
            7129 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, false),
            7130 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, true),
            7131 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, false),
            7132 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, true),
            7133 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, false),
            7134 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, true),
            7135 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, false),
            7136 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, true),
            7137 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, false),
            7138 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, true),
            7139 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, false),
            7140 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, true),
            7141 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, false),
            7142 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, true),
            7143 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, false),
            7144 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, true),
            7145 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, false),
            7146 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, true),
            7147 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, false),
            7148 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, true),
            7149 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, false),
            7150 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, true),
            7151 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, false),
            7152 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, true),
            7153 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, false),
            7154 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, true),
            7155 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, false),
            7156 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, true),
            7157 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, false),
            7158 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, true),
            7159 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, false),
            7160 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, true),
            7161 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, false),
            7162 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, true),
            7163 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, false),
            7164 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, true),
            7165 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, false),
            7166 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, true),
            7167 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, false),
            7168 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, true),
            7169 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, false),
            7170 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, true),
            7171 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, false),
            7172 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, true),
            7173 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, false),
            7174 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, true),
            7175 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, false),
            7176 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, true),
            7177 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, false),
            7178 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, true),
            7179 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, false),
            7180 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, true),
            7181 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, false),
            7182 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, true),
            7183 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, false),
            7184 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, true),
            7185 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, false),
            7186 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, true),
            7187 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, false),
            7188 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, true),
            7189 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, false),
            7190 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, true),
            7191 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, false),
            7192 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, true),
            7193 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, false),
            7194 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, true),
            7195 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, false),
            7196 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, true),
            7197 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, false),
            7198 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, true),
            7199 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, false),
            7200 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, true),
            7201 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, false),
            7202 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, true),
            7203 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, false),
            7204 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, true),
            7205 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, false),
            7206 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, true),
            7207 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, false),
            7208 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, true),
            7209 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, false),
            7210 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, true),
            7211 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, false),
            7212 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, true),
            7213 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, false),
            7214 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, true),
            7215 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, false),
            7216 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, true),
            7217 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, false),
            7218 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, true),
            7219 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, false),
            7220 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, true),
            7221 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, false),
            7222 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, true),
            7223 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, false),
            7224 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, true),
            7225 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, false),
            7226 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, true),
            7227 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, false),
            7228 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, true),
            7229 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, false),
            7230 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, true),
            7231 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, false),
            7232 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, true),
            7233 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, false),
            7234 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, true),
            7235 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, false),
            7236 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, true),
            7237 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, false),
            7238 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, true),
            7239 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties["down"].GetString() == "true",
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Up = properties["up"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
