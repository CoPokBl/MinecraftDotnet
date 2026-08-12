using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_door";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:copper_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.copper_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28496,
                                false => 28497,
                            },
                            false => Powered switch {
                                true => 28498,
                                false => 28499,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28500,
                                false => 28501,
                            },
                            false => Powered switch {
                                true => 28502,
                                false => 28503,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28504,
                                false => 28505,
                            },
                            false => Powered switch {
                                true => 28506,
                                false => 28507,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28508,
                                false => 28509,
                            },
                            false => Powered switch {
                                true => 28510,
                                false => 28511,
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
                                true => 28512,
                                false => 28513,
                            },
                            false => Powered switch {
                                true => 28514,
                                false => 28515,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28516,
                                false => 28517,
                            },
                            false => Powered switch {
                                true => 28518,
                                false => 28519,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28520,
                                false => 28521,
                            },
                            false => Powered switch {
                                true => 28522,
                                false => 28523,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28524,
                                false => 28525,
                            },
                            false => Powered switch {
                                true => 28526,
                                false => 28527,
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
                                true => 28528,
                                false => 28529,
                            },
                            false => Powered switch {
                                true => 28530,
                                false => 28531,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28532,
                                false => 28533,
                            },
                            false => Powered switch {
                                true => 28534,
                                false => 28535,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28536,
                                false => 28537,
                            },
                            false => Powered switch {
                                true => 28538,
                                false => 28539,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28540,
                                false => 28541,
                            },
                            false => Powered switch {
                                true => 28542,
                                false => 28543,
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
                                true => 28544,
                                false => 28545,
                            },
                            false => Powered switch {
                                true => 28546,
                                false => 28547,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28548,
                                false => 28549,
                            },
                            false => Powered switch {
                                true => 28550,
                                false => 28551,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28552,
                                false => 28553,
                            },
                            false => Powered switch {
                                true => 28554,
                                false => 28555,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28556,
                                false => 28557,
                            },
                            false => Powered switch {
                                true => 28558,
                                false => 28559,
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
            28496 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            28497 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            28498 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            28499 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            28500 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            28501 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            28502 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            28503 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            28504 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            28505 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            28506 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            28507 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            28508 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            28509 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            28510 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            28511 => new CopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            28512 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            28513 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            28514 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            28515 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            28516 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            28517 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            28518 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            28519 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            28520 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            28521 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            28522 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            28523 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            28524 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            28525 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            28526 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            28527 => new CopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            28528 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            28529 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            28530 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            28531 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            28532 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            28533 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            28534 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            28535 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            28536 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            28537 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            28538 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            28539 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            28540 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            28541 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            28542 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            28543 => new CopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            28544 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            28545 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            28546 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            28547 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            28548 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            28549 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            28550 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            28551 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            28552 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            28553 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            28554 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            28555 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            28556 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            28557 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            28558 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            28559 => new CopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
