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
    public int ProtocolId => 306;
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
                                true => 6460,
                                false => 6461,
                            },
                            false => Waterlogged switch {
                                true => 6462,
                                false => 6463,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6464,
                                false => 6465,
                            },
                            false => Waterlogged switch {
                                true => 6466,
                                false => 6467,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6468,
                                false => 6469,
                            },
                            false => Waterlogged switch {
                                true => 6470,
                                false => 6471,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6472,
                                false => 6473,
                            },
                            false => Waterlogged switch {
                                true => 6474,
                                false => 6475,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6476,
                                false => 6477,
                            },
                            false => Waterlogged switch {
                                true => 6478,
                                false => 6479,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6480,
                                false => 6481,
                            },
                            false => Waterlogged switch {
                                true => 6482,
                                false => 6483,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6484,
                                false => 6485,
                            },
                            false => Waterlogged switch {
                                true => 6486,
                                false => 6487,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6488,
                                false => 6489,
                            },
                            false => Waterlogged switch {
                                true => 6490,
                                false => 6491,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6492,
                                false => 6493,
                            },
                            false => Waterlogged switch {
                                true => 6494,
                                false => 6495,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6496,
                                false => 6497,
                            },
                            false => Waterlogged switch {
                                true => 6498,
                                false => 6499,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6500,
                                false => 6501,
                            },
                            false => Waterlogged switch {
                                true => 6502,
                                false => 6503,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6504,
                                false => 6505,
                            },
                            false => Waterlogged switch {
                                true => 6506,
                                false => 6507,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6508,
                                false => 6509,
                            },
                            false => Waterlogged switch {
                                true => 6510,
                                false => 6511,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6512,
                                false => 6513,
                            },
                            false => Waterlogged switch {
                                true => 6514,
                                false => 6515,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6516,
                                false => 6517,
                            },
                            false => Waterlogged switch {
                                true => 6518,
                                false => 6519,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6520,
                                false => 6521,
                            },
                            false => Waterlogged switch {
                                true => 6522,
                                false => 6523,
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
            6460 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6461 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6462 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6463 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6464 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6465 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6466 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6467 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6468 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6469 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6470 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6471 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6472 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6473 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6474 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6475 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6476 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6477 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6478 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6479 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6480 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6481 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6482 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6483 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6484 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6485 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6486 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6487 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6488 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6489 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6490 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6491 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6492 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6493 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6494 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6495 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6496 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6497 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6498 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6499 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6500 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6501 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6502 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6503 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6504 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6505 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6506 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6507 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6508 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6509 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6510 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6511 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6512 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6513 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6514 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6515 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6516 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6517 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6518 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6519 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6520 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6521 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6522 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6523 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
