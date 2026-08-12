using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaTrapdoorBlock(Identifier Identifier, Direction Facing, AcaciaTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:acacia_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7370,
                                false => 7371,
                            },
                            false => Waterlogged switch {
                                true => 7372,
                                false => 7373,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7374,
                                false => 7375,
                            },
                            false => Waterlogged switch {
                                true => 7376,
                                false => 7377,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7378,
                                false => 7379,
                            },
                            false => Waterlogged switch {
                                true => 7380,
                                false => 7381,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7382,
                                false => 7383,
                            },
                            false => Waterlogged switch {
                                true => 7384,
                                false => 7385,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7386,
                                false => 7387,
                            },
                            false => Waterlogged switch {
                                true => 7388,
                                false => 7389,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7390,
                                false => 7391,
                            },
                            false => Waterlogged switch {
                                true => 7392,
                                false => 7393,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7394,
                                false => 7395,
                            },
                            false => Waterlogged switch {
                                true => 7396,
                                false => 7397,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7398,
                                false => 7399,
                            },
                            false => Waterlogged switch {
                                true => 7400,
                                false => 7401,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7402,
                                false => 7403,
                            },
                            false => Waterlogged switch {
                                true => 7404,
                                false => 7405,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7406,
                                false => 7407,
                            },
                            false => Waterlogged switch {
                                true => 7408,
                                false => 7409,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7410,
                                false => 7411,
                            },
                            false => Waterlogged switch {
                                true => 7412,
                                false => 7413,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7414,
                                false => 7415,
                            },
                            false => Waterlogged switch {
                                true => 7416,
                                false => 7417,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7418,
                                false => 7419,
                            },
                            false => Waterlogged switch {
                                true => 7420,
                                false => 7421,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7422,
                                false => 7423,
                            },
                            false => Waterlogged switch {
                                true => 7424,
                                false => 7425,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7426,
                                false => 7427,
                            },
                            false => Waterlogged switch {
                                true => 7428,
                                false => 7429,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7430,
                                false => 7431,
                            },
                            false => Waterlogged switch {
                                true => 7432,
                                false => 7433,
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
            7370 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7371 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7372 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7373 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7374 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7375 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7376 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7377 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7378 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7379 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7380 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7381 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7382 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7383 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7384 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7385 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7386 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7387 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7388 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7389 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7390 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7391 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7392 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7393 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7394 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7395 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7396 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7397 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7398 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7399 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7400 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7401 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7402 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7403 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7404 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7405 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7406 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7407 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7408 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7409 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7410 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7411 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7412 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7413 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7414 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7415 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7416 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7417 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7418 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7419 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7420 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7421 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7422 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7423 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7424 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7425 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7426 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7427 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7428 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7429 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7430 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7431 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7432 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7433 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
