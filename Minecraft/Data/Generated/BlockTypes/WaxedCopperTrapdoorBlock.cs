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
    public int ProtocolId => 1021;
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
                Direction.South => HalfValue switch {
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
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25512,
                                false => 25513,
                            },
                            false => Waterlogged switch {
                                true => 25514,
                                false => 25515,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25516,
                                false => 25517,
                            },
                            false => Waterlogged switch {
                                true => 25518,
                                false => 25519,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25520,
                                false => 25521,
                            },
                            false => Waterlogged switch {
                                true => 25522,
                                false => 25523,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25524,
                                false => 25525,
                            },
                            false => Waterlogged switch {
                                true => 25526,
                                false => 25527,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25528,
                                false => 25529,
                            },
                            false => Waterlogged switch {
                                true => 25530,
                                false => 25531,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25532,
                                false => 25533,
                            },
                            false => Waterlogged switch {
                                true => 25534,
                                false => 25535,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25536,
                                false => 25537,
                            },
                            false => Waterlogged switch {
                                true => 25538,
                                false => 25539,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25540,
                                false => 25541,
                            },
                            false => Waterlogged switch {
                                true => 25542,
                                false => 25543,
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
            25480 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25481 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25482 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25483 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25484 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25485 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25486 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25487 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25488 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25489 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25490 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25491 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25492 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25493 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25494 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25495 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25496 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25497 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25498 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25499 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25500 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25501 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25502 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25503 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25504 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25505 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25506 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25507 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25508 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25509 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25510 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25511 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25512 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25513 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25514 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25515 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25516 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25517 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25518 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25519 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25520 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25521 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25522 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25523 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25524 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25525 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25526 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25527 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25528 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25529 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25530 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25531 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25532 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25533 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25534 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25535 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25536 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25537 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25538 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25539 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25540 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25541 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25542 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25543 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
