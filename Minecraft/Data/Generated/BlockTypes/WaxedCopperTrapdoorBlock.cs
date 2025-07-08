using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
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
    public Identifier? Item => "minecraft:waxed_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.waxed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
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
                Direction.South => HalfValue switch {
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
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25480,
                                false => 25481,
                            },
                            false => Waterlogged switch {
                                true => 25482,
                                false => 25483,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25484,
                                false => 25485,
                            },
                            false => Waterlogged switch {
                                true => 25486,
                                false => 25487,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25488,
                                false => 25489,
                            },
                            false => Waterlogged switch {
                                true => 25490,
                                false => 25491,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25492,
                                false => 25493,
                            },
                            false => Waterlogged switch {
                                true => 25494,
                                false => 25495,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25496,
                                false => 25497,
                            },
                            false => Waterlogged switch {
                                true => 25498,
                                false => 25499,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25500,
                                false => 25501,
                            },
                            false => Waterlogged switch {
                                true => 25502,
                                false => 25503,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25504,
                                false => 25505,
                            },
                            false => Waterlogged switch {
                                true => 25506,
                                false => 25507,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25508,
                                false => 25509,
                            },
                            false => Waterlogged switch {
                                true => 25510,
                                false => 25511,
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
            25448 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25449 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25450 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25451 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25452 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25453 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25454 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25455 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25456 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25457 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25458 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25459 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25460 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25461 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25462 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25463 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25464 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25465 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25466 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25467 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25468 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25469 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25470 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25471 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25472 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25473 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25474 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25475 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25476 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25477 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25478 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25479 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25480 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25481 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25482 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25483 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25484 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25485 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25486 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25487 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25488 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25489 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25490 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25491 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25492 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25493 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25494 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25495 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25496 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25497 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25498 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25499 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25500 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25501 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25502 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25503 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25504 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25505 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25506 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25507 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25508 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25509 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25510 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25511 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
}
