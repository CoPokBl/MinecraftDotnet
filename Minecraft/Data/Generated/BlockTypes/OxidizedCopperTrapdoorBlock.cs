using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, OxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public int ProtocolId => 1057;
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
    public Identifier? Item => "minecraft:oxidized_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.oxidized_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26461,
                                false => 26462,
                            },
                            false => Waterlogged switch {
                                true => 26463,
                                false => 26464,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26465,
                                false => 26466,
                            },
                            false => Waterlogged switch {
                                true => 26467,
                                false => 26468,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26469,
                                false => 26470,
                            },
                            false => Waterlogged switch {
                                true => 26471,
                                false => 26472,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26473,
                                false => 26474,
                            },
                            false => Waterlogged switch {
                                true => 26475,
                                false => 26476,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26477,
                                false => 26478,
                            },
                            false => Waterlogged switch {
                                true => 26479,
                                false => 26480,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26481,
                                false => 26482,
                            },
                            false => Waterlogged switch {
                                true => 26483,
                                false => 26484,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26485,
                                false => 26486,
                            },
                            false => Waterlogged switch {
                                true => 26487,
                                false => 26488,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26489,
                                false => 26490,
                            },
                            false => Waterlogged switch {
                                true => 26491,
                                false => 26492,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26493,
                                false => 26494,
                            },
                            false => Waterlogged switch {
                                true => 26495,
                                false => 26496,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26497,
                                false => 26498,
                            },
                            false => Waterlogged switch {
                                true => 26499,
                                false => 26500,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26501,
                                false => 26502,
                            },
                            false => Waterlogged switch {
                                true => 26503,
                                false => 26504,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26505,
                                false => 26506,
                            },
                            false => Waterlogged switch {
                                true => 26507,
                                false => 26508,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26509,
                                false => 26510,
                            },
                            false => Waterlogged switch {
                                true => 26511,
                                false => 26512,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26513,
                                false => 26514,
                            },
                            false => Waterlogged switch {
                                true => 26515,
                                false => 26516,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26517,
                                false => 26518,
                            },
                            false => Waterlogged switch {
                                true => 26519,
                                false => 26520,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26521,
                                false => 26522,
                            },
                            false => Waterlogged switch {
                                true => 26523,
                                false => 26524,
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
            26461 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26462 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26463 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26464 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26465 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26466 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26467 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26468 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26469 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26470 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26471 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26472 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26473 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26474 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26475 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26476 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26477 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26478 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26479 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26480 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26481 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26482 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26483 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26484 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26485 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26486 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26487 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26488 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26489 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26490 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26491 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26492 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26493 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26494 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26495 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26496 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26497 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26498 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26499 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26500 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26501 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26502 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26503 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26504 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26505 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26506 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26507 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26508 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26509 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26510 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26511 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26512 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26513 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26514 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26515 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26516 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26517 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26518 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26519 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26520 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26521 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26522 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26523 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26524 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
