using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:warped_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21578,
                                false => 21579,
                            },
                            false => Powered switch {
                                true => 21580,
                                false => 21581,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21582,
                                false => 21583,
                            },
                            false => Powered switch {
                                true => 21584,
                                false => 21585,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21586,
                                false => 21587,
                            },
                            false => Powered switch {
                                true => 21588,
                                false => 21589,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21590,
                                false => 21591,
                            },
                            false => Powered switch {
                                true => 21592,
                                false => 21593,
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
                                true => 21594,
                                false => 21595,
                            },
                            false => Powered switch {
                                true => 21596,
                                false => 21597,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21598,
                                false => 21599,
                            },
                            false => Powered switch {
                                true => 21600,
                                false => 21601,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21602,
                                false => 21603,
                            },
                            false => Powered switch {
                                true => 21604,
                                false => 21605,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21606,
                                false => 21607,
                            },
                            false => Powered switch {
                                true => 21608,
                                false => 21609,
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
                                true => 21610,
                                false => 21611,
                            },
                            false => Powered switch {
                                true => 21612,
                                false => 21613,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21614,
                                false => 21615,
                            },
                            false => Powered switch {
                                true => 21616,
                                false => 21617,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21618,
                                false => 21619,
                            },
                            false => Powered switch {
                                true => 21620,
                                false => 21621,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21622,
                                false => 21623,
                            },
                            false => Powered switch {
                                true => 21624,
                                false => 21625,
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
                                true => 21626,
                                false => 21627,
                            },
                            false => Powered switch {
                                true => 21628,
                                false => 21629,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21630,
                                false => 21631,
                            },
                            false => Powered switch {
                                true => 21632,
                                false => 21633,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 21634,
                                false => 21635,
                            },
                            false => Powered switch {
                                true => 21636,
                                false => 21637,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 21638,
                                false => 21639,
                            },
                            false => Powered switch {
                                true => 21640,
                                false => 21641,
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
            21578 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            21579 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            21580 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            21581 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            21582 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            21583 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            21584 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            21585 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            21586 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            21587 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            21588 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            21589 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            21590 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            21591 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            21592 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            21593 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            21594 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            21595 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            21596 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            21597 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            21598 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            21599 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            21600 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            21601 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            21602 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            21603 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            21604 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            21605 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            21606 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            21607 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            21608 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            21609 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            21610 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            21611 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            21612 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            21613 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            21614 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            21615 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            21616 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            21617 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            21618 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            21619 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            21620 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            21621 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            21622 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            21623 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            21624 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            21625 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            21626 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            21627 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            21628 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            21629 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            21630 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            21631 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            21632 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            21633 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            21634 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            21635 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            21636 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            21637 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            21638 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            21639 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            21640 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            21641 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
