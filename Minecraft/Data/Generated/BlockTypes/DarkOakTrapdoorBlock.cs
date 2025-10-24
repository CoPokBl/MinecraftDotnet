using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakTrapdoorBlock(Identifier Identifier, Direction Facing, DarkOakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 321;
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
    public Identifier? Item => "minecraft:dark_oak_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7297,
                                false => 7298,
                            },
                            false => Waterlogged switch {
                                true => 7299,
                                false => 7300,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7301,
                                false => 7302,
                            },
                            false => Waterlogged switch {
                                true => 7303,
                                false => 7304,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7305,
                                false => 7306,
                            },
                            false => Waterlogged switch {
                                true => 7307,
                                false => 7308,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7309,
                                false => 7310,
                            },
                            false => Waterlogged switch {
                                true => 7311,
                                false => 7312,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7313,
                                false => 7314,
                            },
                            false => Waterlogged switch {
                                true => 7315,
                                false => 7316,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7317,
                                false => 7318,
                            },
                            false => Waterlogged switch {
                                true => 7319,
                                false => 7320,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7321,
                                false => 7322,
                            },
                            false => Waterlogged switch {
                                true => 7323,
                                false => 7324,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7325,
                                false => 7326,
                            },
                            false => Waterlogged switch {
                                true => 7327,
                                false => 7328,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7329,
                                false => 7330,
                            },
                            false => Waterlogged switch {
                                true => 7331,
                                false => 7332,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7333,
                                false => 7334,
                            },
                            false => Waterlogged switch {
                                true => 7335,
                                false => 7336,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7337,
                                false => 7338,
                            },
                            false => Waterlogged switch {
                                true => 7339,
                                false => 7340,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7341,
                                false => 7342,
                            },
                            false => Waterlogged switch {
                                true => 7343,
                                false => 7344,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7345,
                                false => 7346,
                            },
                            false => Waterlogged switch {
                                true => 7347,
                                false => 7348,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7349,
                                false => 7350,
                            },
                            false => Waterlogged switch {
                                true => 7351,
                                false => 7352,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7353,
                                false => 7354,
                            },
                            false => Waterlogged switch {
                                true => 7355,
                                false => 7356,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7357,
                                false => 7358,
                            },
                            false => Waterlogged switch {
                                true => 7359,
                                false => 7360,
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
            7297 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7298 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7299 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7300 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7301 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7302 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7303 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7304 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7305 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7306 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7307 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7308 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7309 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7310 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7311 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7312 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7313 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7314 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7315 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7316 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7317 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7318 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7319 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7320 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7321 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7322 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7323 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7324 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7325 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7326 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7327 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7328 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7329 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7330 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7331 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7332 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7333 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7334 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7335 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7336 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7337 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7338 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7339 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7340 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7341 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7342 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7343 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7344 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7345 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7346 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7347 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7348 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7349 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7350 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7351 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7352 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7353 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7354 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7355 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7356 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7357 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7358 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7359 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7360 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
