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
    public int ProtocolId => 366;
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
                                        true => 8189,
                                        false => 8190,
                                    },
                                    false => West switch {
                                        true => 8191,
                                        false => 8192,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8193,
                                        false => 8194,
                                    },
                                    false => West switch {
                                        true => 8195,
                                        false => 8196,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8197,
                                        false => 8198,
                                    },
                                    false => West switch {
                                        true => 8199,
                                        false => 8200,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8201,
                                        false => 8202,
                                    },
                                    false => West switch {
                                        true => 8203,
                                        false => 8204,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8205,
                                        false => 8206,
                                    },
                                    false => West switch {
                                        true => 8207,
                                        false => 8208,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8209,
                                        false => 8210,
                                    },
                                    false => West switch {
                                        true => 8211,
                                        false => 8212,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8213,
                                        false => 8214,
                                    },
                                    false => West switch {
                                        true => 8215,
                                        false => 8216,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8217,
                                        false => 8218,
                                    },
                                    false => West switch {
                                        true => 8219,
                                        false => 8220,
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
                                        true => 8221,
                                        false => 8222,
                                    },
                                    false => West switch {
                                        true => 8223,
                                        false => 8224,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8225,
                                        false => 8226,
                                    },
                                    false => West switch {
                                        true => 8227,
                                        false => 8228,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8229,
                                        false => 8230,
                                    },
                                    false => West switch {
                                        true => 8231,
                                        false => 8232,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8233,
                                        false => 8234,
                                    },
                                    false => West switch {
                                        true => 8235,
                                        false => 8236,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8237,
                                        false => 8238,
                                    },
                                    false => West switch {
                                        true => 8239,
                                        false => 8240,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8241,
                                        false => 8242,
                                    },
                                    false => West switch {
                                        true => 8243,
                                        false => 8244,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8245,
                                        false => 8246,
                                    },
                                    false => West switch {
                                        true => 8247,
                                        false => 8248,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8249,
                                        false => 8250,
                                    },
                                    false => West switch {
                                        true => 8251,
                                        false => 8252,
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
                                        true => 8253,
                                        false => 8254,
                                    },
                                    false => West switch {
                                        true => 8255,
                                        false => 8256,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8257,
                                        false => 8258,
                                    },
                                    false => West switch {
                                        true => 8259,
                                        false => 8260,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8261,
                                        false => 8262,
                                    },
                                    false => West switch {
                                        true => 8263,
                                        false => 8264,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8265,
                                        false => 8266,
                                    },
                                    false => West switch {
                                        true => 8267,
                                        false => 8268,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8269,
                                        false => 8270,
                                    },
                                    false => West switch {
                                        true => 8271,
                                        false => 8272,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8273,
                                        false => 8274,
                                    },
                                    false => West switch {
                                        true => 8275,
                                        false => 8276,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8277,
                                        false => 8278,
                                    },
                                    false => West switch {
                                        true => 8279,
                                        false => 8280,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8281,
                                        false => 8282,
                                    },
                                    false => West switch {
                                        true => 8283,
                                        false => 8284,
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
                                        true => 8285,
                                        false => 8286,
                                    },
                                    false => West switch {
                                        true => 8287,
                                        false => 8288,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8289,
                                        false => 8290,
                                    },
                                    false => West switch {
                                        true => 8291,
                                        false => 8292,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8293,
                                        false => 8294,
                                    },
                                    false => West switch {
                                        true => 8295,
                                        false => 8296,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8297,
                                        false => 8298,
                                    },
                                    false => West switch {
                                        true => 8299,
                                        false => 8300,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8301,
                                        false => 8302,
                                    },
                                    false => West switch {
                                        true => 8303,
                                        false => 8304,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8305,
                                        false => 8306,
                                    },
                                    false => West switch {
                                        true => 8307,
                                        false => 8308,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8309,
                                        false => 8310,
                                    },
                                    false => West switch {
                                        true => 8311,
                                        false => 8312,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8313,
                                        false => 8314,
                                    },
                                    false => West switch {
                                        true => 8315,
                                        false => 8316,
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
            8189 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, true),
            8190 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, false),
            8191 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, true),
            8192 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, false),
            8193 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, true),
            8194 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, false),
            8195 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, true),
            8196 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, false),
            8197 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, true),
            8198 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, false),
            8199 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, true),
            8200 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, false),
            8201 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, true),
            8202 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, false),
            8203 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, true),
            8204 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, false),
            8205 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, true),
            8206 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, false),
            8207 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, true),
            8208 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, false),
            8209 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, true),
            8210 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, false),
            8211 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, true),
            8212 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, false),
            8213 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, true),
            8214 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, false),
            8215 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, true),
            8216 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, false),
            8217 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, true),
            8218 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, false),
            8219 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, true),
            8220 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, false),
            8221 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, true),
            8222 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, false),
            8223 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, true),
            8224 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, false),
            8225 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, true),
            8226 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, false),
            8227 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, true),
            8228 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, false),
            8229 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, true),
            8230 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, false),
            8231 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, true),
            8232 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, false),
            8233 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, true),
            8234 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, false),
            8235 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, true),
            8236 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, false),
            8237 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, true),
            8238 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, false),
            8239 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, true),
            8240 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, false),
            8241 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, true),
            8242 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, false),
            8243 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, true),
            8244 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, false),
            8245 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, true),
            8246 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, false),
            8247 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, true),
            8248 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, false),
            8249 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, true),
            8250 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, false),
            8251 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, true),
            8252 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, false),
            8253 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, true),
            8254 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, false),
            8255 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, true),
            8256 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, false),
            8257 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, true),
            8258 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, false),
            8259 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, true),
            8260 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, false),
            8261 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, true),
            8262 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, false),
            8263 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, true),
            8264 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, false),
            8265 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, true),
            8266 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, false),
            8267 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, true),
            8268 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, false),
            8269 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, true),
            8270 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, false),
            8271 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, true),
            8272 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, false),
            8273 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, true),
            8274 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, false),
            8275 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, true),
            8276 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, false),
            8277 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, true),
            8278 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, false),
            8279 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, true),
            8280 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, false),
            8281 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, true),
            8282 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, false),
            8283 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, true),
            8284 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, false),
            8285 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, true),
            8286 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, false),
            8287 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, true),
            8288 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, false),
            8289 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, true),
            8290 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, false),
            8291 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, true),
            8292 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, false),
            8293 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, true),
            8294 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, false),
            8295 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, true),
            8296 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, false),
            8297 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, true),
            8298 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, false),
            8299 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, true),
            8300 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, false),
            8301 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, true),
            8302 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, false),
            8303 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, true),
            8304 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, false),
            8305 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, true),
            8306 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, false),
            8307 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, true),
            8308 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, false),
            8309 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, true),
            8310 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, false),
            8311 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, true),
            8312 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, false),
            8313 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, true),
            8314 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, false),
            8315 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, true),
            8316 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.ChildrenMap.ContainsKey("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("down", Down.ToString().ToLower()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
