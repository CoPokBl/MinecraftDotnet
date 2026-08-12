using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedOxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29456,
                                false => 29457,
                            },
                            false => Waterlogged switch {
                                true => 29458,
                                false => 29459,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29460,
                                false => 29461,
                            },
                            false => Waterlogged switch {
                                true => 29462,
                                false => 29463,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29464,
                                false => 29465,
                            },
                            false => Waterlogged switch {
                                true => 29466,
                                false => 29467,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29468,
                                false => 29469,
                            },
                            false => Waterlogged switch {
                                true => 29470,
                                false => 29471,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29472,
                                false => 29473,
                            },
                            false => Waterlogged switch {
                                true => 29474,
                                false => 29475,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29476,
                                false => 29477,
                            },
                            false => Waterlogged switch {
                                true => 29478,
                                false => 29479,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29480,
                                false => 29481,
                            },
                            false => Waterlogged switch {
                                true => 29482,
                                false => 29483,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29484,
                                false => 29485,
                            },
                            false => Waterlogged switch {
                                true => 29486,
                                false => 29487,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29488,
                                false => 29489,
                            },
                            false => Waterlogged switch {
                                true => 29490,
                                false => 29491,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29492,
                                false => 29493,
                            },
                            false => Waterlogged switch {
                                true => 29494,
                                false => 29495,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29496,
                                false => 29497,
                            },
                            false => Waterlogged switch {
                                true => 29498,
                                false => 29499,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29500,
                                false => 29501,
                            },
                            false => Waterlogged switch {
                                true => 29502,
                                false => 29503,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29504,
                                false => 29505,
                            },
                            false => Waterlogged switch {
                                true => 29506,
                                false => 29507,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29508,
                                false => 29509,
                            },
                            false => Waterlogged switch {
                                true => 29510,
                                false => 29511,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29512,
                                false => 29513,
                            },
                            false => Waterlogged switch {
                                true => 29514,
                                false => 29515,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29516,
                                false => 29517,
                            },
                            false => Waterlogged switch {
                                true => 29518,
                                false => 29519,
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
            29456 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29457 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29458 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29459 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29460 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29461 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29462 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29463 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29464 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29465 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29466 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29467 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29468 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29469 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29470 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29471 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29472 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29473 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29474 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29475 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29476 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29477 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29478 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29479 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29480 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29481 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29482 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29483 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29484 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29485 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29486 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29487 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29488 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29489 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29490 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29491 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29492 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29493 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29494 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29495 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29496 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29497 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29498 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29499 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29500 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29501 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29502 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29503 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29504 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29505 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29506 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29507 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29508 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29509 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29510 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29511 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29512 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29513 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29514 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29515 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29516 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29517 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29518 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29519 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
