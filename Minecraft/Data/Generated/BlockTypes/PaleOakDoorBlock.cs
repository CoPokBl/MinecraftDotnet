using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_oak_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14444,
                                false => 14445,
                            },
                            false => Powered switch {
                                true => 14446,
                                false => 14447,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14448,
                                false => 14449,
                            },
                            false => Powered switch {
                                true => 14450,
                                false => 14451,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14452,
                                false => 14453,
                            },
                            false => Powered switch {
                                true => 14454,
                                false => 14455,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14456,
                                false => 14457,
                            },
                            false => Powered switch {
                                true => 14458,
                                false => 14459,
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
                                true => 14460,
                                false => 14461,
                            },
                            false => Powered switch {
                                true => 14462,
                                false => 14463,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14464,
                                false => 14465,
                            },
                            false => Powered switch {
                                true => 14466,
                                false => 14467,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14468,
                                false => 14469,
                            },
                            false => Powered switch {
                                true => 14470,
                                false => 14471,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14472,
                                false => 14473,
                            },
                            false => Powered switch {
                                true => 14474,
                                false => 14475,
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
                                true => 14476,
                                false => 14477,
                            },
                            false => Powered switch {
                                true => 14478,
                                false => 14479,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14480,
                                false => 14481,
                            },
                            false => Powered switch {
                                true => 14482,
                                false => 14483,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14484,
                                false => 14485,
                            },
                            false => Powered switch {
                                true => 14486,
                                false => 14487,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14488,
                                false => 14489,
                            },
                            false => Powered switch {
                                true => 14490,
                                false => 14491,
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
                                true => 14492,
                                false => 14493,
                            },
                            false => Powered switch {
                                true => 14494,
                                false => 14495,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14496,
                                false => 14497,
                            },
                            false => Powered switch {
                                true => 14498,
                                false => 14499,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14500,
                                false => 14501,
                            },
                            false => Powered switch {
                                true => 14502,
                                false => 14503,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14504,
                                false => 14505,
                            },
                            false => Powered switch {
                                true => 14506,
                                false => 14507,
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
            14444 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            14445 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            14446 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            14447 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            14448 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            14449 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            14450 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            14451 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            14452 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            14453 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            14454 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            14455 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            14456 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            14457 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            14458 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            14459 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            14460 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            14461 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            14462 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            14463 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            14464 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            14465 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            14466 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            14467 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            14468 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            14469 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            14470 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            14471 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            14472 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            14473 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            14474 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            14475 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            14476 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            14477 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            14478 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            14479 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            14480 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            14481 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            14482 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            14483 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            14484 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            14485 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            14486 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            14487 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            14488 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            14489 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            14490 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            14491 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            14492 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            14493 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            14494 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            14495 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            14496 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            14497 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            14498 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            14499 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            14500 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            14501 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            14502 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            14503 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            14504 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            14505 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            14506 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            14507 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
