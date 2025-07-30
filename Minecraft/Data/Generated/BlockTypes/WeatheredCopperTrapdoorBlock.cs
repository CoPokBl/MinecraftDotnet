using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public int ProtocolId => 1020;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:weathered_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.weathered_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25416,
                                false => 25417,
                            },
                            false => Waterlogged switch {
                                true => 25418,
                                false => 25419,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25420,
                                false => 25421,
                            },
                            false => Waterlogged switch {
                                true => 25422,
                                false => 25423,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25424,
                                false => 25425,
                            },
                            false => Waterlogged switch {
                                true => 25426,
                                false => 25427,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25428,
                                false => 25429,
                            },
                            false => Waterlogged switch {
                                true => 25430,
                                false => 25431,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25432,
                                false => 25433,
                            },
                            false => Waterlogged switch {
                                true => 25434,
                                false => 25435,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25436,
                                false => 25437,
                            },
                            false => Waterlogged switch {
                                true => 25438,
                                false => 25439,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25440,
                                false => 25441,
                            },
                            false => Waterlogged switch {
                                true => 25442,
                                false => 25443,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25444,
                                false => 25445,
                            },
                            false => Waterlogged switch {
                                true => 25446,
                                false => 25447,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25448,
                                false => 25449,
                            },
                            false => Waterlogged switch {
                                true => 25450,
                                false => 25451,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25452,
                                false => 25453,
                            },
                            false => Waterlogged switch {
                                true => 25454,
                                false => 25455,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25456,
                                false => 25457,
                            },
                            false => Waterlogged switch {
                                true => 25458,
                                false => 25459,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25460,
                                false => 25461,
                            },
                            false => Waterlogged switch {
                                true => 25462,
                                false => 25463,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25464,
                                false => 25465,
                            },
                            false => Waterlogged switch {
                                true => 25466,
                                false => 25467,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25468,
                                false => 25469,
                            },
                            false => Waterlogged switch {
                                true => 25470,
                                false => 25471,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25472,
                                false => 25473,
                            },
                            false => Waterlogged switch {
                                true => 25474,
                                false => 25475,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25476,
                                false => 25477,
                            },
                            false => Waterlogged switch {
                                true => 25478,
                                false => 25479,
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
            25416 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25417 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25418 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25419 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25420 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25421 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25422 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25423 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25424 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25425 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25426 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25427 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25428 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25429 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25430 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25431 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25432 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25433 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25434 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25435 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25436 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25437 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25438 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25439 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25440 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25441 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25442 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25443 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25444 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25445 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25446 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25447 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25448 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25449 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25450 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25451 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25452 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25453 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25454 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25455 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25456 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25457 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25458 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25459 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25460 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25461 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25462 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25463 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25464 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25465 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25466 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25467 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25468 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25469 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25470 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25471 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25472 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25473 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25474 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25475 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25476 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25477 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25478 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25479 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
