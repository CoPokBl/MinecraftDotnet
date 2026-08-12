using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:door";
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21514,
                                false => 21515,
                            },
                            false => Powered switch {
                                true => 21516,
                                false => 21517,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21518,
                                false => 21519,
                            },
                            false => Powered switch {
                                true => 21520,
                                false => 21521,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21522,
                                false => 21523,
                            },
                            false => Powered switch {
                                true => 21524,
                                false => 21525,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21526,
                                false => 21527,
                            },
                            false => Powered switch {
                                true => 21528,
                                false => 21529,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21530,
                                false => 21531,
                            },
                            false => Powered switch {
                                true => 21532,
                                false => 21533,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21534,
                                false => 21535,
                            },
                            false => Powered switch {
                                true => 21536,
                                false => 21537,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21538,
                                false => 21539,
                            },
                            false => Powered switch {
                                true => 21540,
                                false => 21541,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21542,
                                false => 21543,
                            },
                            false => Powered switch {
                                true => 21544,
                                false => 21545,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21546,
                                false => 21547,
                            },
                            false => Powered switch {
                                true => 21548,
                                false => 21549,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21550,
                                false => 21551,
                            },
                            false => Powered switch {
                                true => 21552,
                                false => 21553,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21554,
                                false => 21555,
                            },
                            false => Powered switch {
                                true => 21556,
                                false => 21557,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21558,
                                false => 21559,
                            },
                            false => Powered switch {
                                true => 21560,
                                false => 21561,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21562,
                                false => 21563,
                            },
                            false => Powered switch {
                                true => 21564,
                                false => 21565,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21566,
                                false => 21567,
                            },
                            false => Powered switch {
                                true => 21568,
                                false => 21569,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21570,
                                false => 21571,
                            },
                            false => Powered switch {
                                true => 21572,
                                false => 21573,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21574,
                                false => 21575,
                            },
                            false => Powered switch {
                                true => 21576,
                                false => 21577,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21514 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            21515 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            21516 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            21517 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            21518 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            21519 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            21520 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            21521 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            21522 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            21523 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            21524 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            21525 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            21526 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            21527 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            21528 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            21529 => new CrimsonDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            21530 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            21531 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            21532 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            21533 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            21534 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            21535 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            21536 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            21537 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            21538 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            21539 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            21540 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            21541 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            21542 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            21543 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            21544 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            21545 => new CrimsonDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            21546 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            21547 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            21548 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            21549 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            21550 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            21551 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            21552 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            21553 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            21554 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            21555 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            21556 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            21557 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            21558 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            21559 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            21560 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            21561 => new CrimsonDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            21562 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            21563 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            21564 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            21565 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            21566 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            21567 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            21568 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            21569 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            21570 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            21571 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            21572 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            21573 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            21574 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            21575 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            21576 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            21577 => new CrimsonDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Hinge = properties.Contains("hinge") ? LeftRightExtensions.FromString(properties["hinge"].GetString()) : Hinge,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("hinge", new StringTag(Hinge.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
