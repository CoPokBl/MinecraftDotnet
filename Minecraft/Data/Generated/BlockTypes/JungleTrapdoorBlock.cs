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
                                true => 7306,
                                false => 7307,
                            },
                            false => Waterlogged switch {
                                true => 7308,
                                false => 7309,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7310,
                                false => 7311,
                            },
                            false => Waterlogged switch {
                                true => 7312,
                                false => 7313,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7314,
                                false => 7315,
                            },
                            false => Waterlogged switch {
                                true => 7316,
                                false => 7317,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7318,
                                false => 7319,
                            },
                            false => Waterlogged switch {
                                true => 7320,
                                false => 7321,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7322,
                                false => 7323,
                            },
                            false => Waterlogged switch {
                                true => 7324,
                                false => 7325,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7326,
                                false => 7327,
                            },
                            false => Waterlogged switch {
                                true => 7328,
                                false => 7329,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7330,
                                false => 7331,
                            },
                            false => Waterlogged switch {
                                true => 7332,
                                false => 7333,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7334,
                                false => 7335,
                            },
                            false => Waterlogged switch {
                                true => 7336,
                                false => 7337,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7338,
                                false => 7339,
                            },
                            false => Waterlogged switch {
                                true => 7340,
                                false => 7341,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7342,
                                false => 7343,
                            },
                            false => Waterlogged switch {
                                true => 7344,
                                false => 7345,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7346,
                                false => 7347,
                            },
                            false => Waterlogged switch {
                                true => 7348,
                                false => 7349,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7350,
                                false => 7351,
                            },
                            false => Waterlogged switch {
                                true => 7352,
                                false => 7353,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7354,
                                false => 7355,
                            },
                            false => Waterlogged switch {
                                true => 7356,
                                false => 7357,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7358,
                                false => 7359,
                            },
                            false => Waterlogged switch {
                                true => 7360,
                                false => 7361,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7362,
                                false => 7363,
                            },
                            false => Waterlogged switch {
                                true => 7364,
                                false => 7365,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7366,
                                false => 7367,
                            },
                            false => Waterlogged switch {
                                true => 7368,
                                false => 7369,
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
            7306 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7307 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7308 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7309 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7310 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7311 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7312 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7313 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7314 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7315 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7316 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7317 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7318 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7319 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7320 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7321 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7322 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7323 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7324 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7325 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7326 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7327 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7328 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7329 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7330 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7331 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7332 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7333 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7334 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7335 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7336 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7337 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7338 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7339 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7340 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7341 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7342 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7343 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7344 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7345 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7346 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7347 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7348 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7349 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7350 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7351 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7352 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7353 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7354 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7355 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7356 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7357 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7358 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7359 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7360 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7361 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7362 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7363 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7364 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7365 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7366 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7367 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7368 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7369 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
