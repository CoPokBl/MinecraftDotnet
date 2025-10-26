using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryTrapdoorBlock(Identifier Identifier, Direction Facing, CherryTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 320;
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7233,
                                false => 7234,
                            },
                            false => Waterlogged switch {
                                true => 7235,
                                false => 7236,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7237,
                                false => 7238,
                            },
                            false => Waterlogged switch {
                                true => 7239,
                                false => 7240,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7241,
                                false => 7242,
                            },
                            false => Waterlogged switch {
                                true => 7243,
                                false => 7244,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7245,
                                false => 7246,
                            },
                            false => Waterlogged switch {
                                true => 7247,
                                false => 7248,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7249,
                                false => 7250,
                            },
                            false => Waterlogged switch {
                                true => 7251,
                                false => 7252,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7253,
                                false => 7254,
                            },
                            false => Waterlogged switch {
                                true => 7255,
                                false => 7256,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7257,
                                false => 7258,
                            },
                            false => Waterlogged switch {
                                true => 7259,
                                false => 7260,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7261,
                                false => 7262,
                            },
                            false => Waterlogged switch {
                                true => 7263,
                                false => 7264,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7265,
                                false => 7266,
                            },
                            false => Waterlogged switch {
                                true => 7267,
                                false => 7268,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7269,
                                false => 7270,
                            },
                            false => Waterlogged switch {
                                true => 7271,
                                false => 7272,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7273,
                                false => 7274,
                            },
                            false => Waterlogged switch {
                                true => 7275,
                                false => 7276,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7277,
                                false => 7278,
                            },
                            false => Waterlogged switch {
                                true => 7279,
                                false => 7280,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7281,
                                false => 7282,
                            },
                            false => Waterlogged switch {
                                true => 7283,
                                false => 7284,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7285,
                                false => 7286,
                            },
                            false => Waterlogged switch {
                                true => 7287,
                                false => 7288,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7289,
                                false => 7290,
                            },
                            false => Waterlogged switch {
                                true => 7291,
                                false => 7292,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7293,
                                false => 7294,
                            },
                            false => Waterlogged switch {
                                true => 7295,
                                false => 7296,
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
            7233 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7234 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7235 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7236 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7237 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7238 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7239 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7240 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7241 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7242 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7243 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7244 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7245 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7246 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7247 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7248 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7249 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7250 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7251 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7252 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7253 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7254 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7255 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7256 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7257 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7258 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7259 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7260 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7261 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7262 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7263 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7264 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7265 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7266 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7267 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7268 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7269 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7270 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7271 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7272 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7273 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7274 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7275 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7276 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7277 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7278 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7279 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7280 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7281 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7282 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7283 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7284 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7285 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7286 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7287 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7288 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7289 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7290 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7291 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7292 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7293 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7294 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7295 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7296 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
