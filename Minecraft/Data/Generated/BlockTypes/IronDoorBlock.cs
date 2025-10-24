using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:door";
    public int ProtocolId => 259;
    public double Hardness => 5;
    public double ExplosionResistance => 5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "iron";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:iron_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.iron_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6596,
                                false => 6597,
                            },
                            false => Powered switch {
                                true => 6598,
                                false => 6599,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6600,
                                false => 6601,
                            },
                            false => Powered switch {
                                true => 6602,
                                false => 6603,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6604,
                                false => 6605,
                            },
                            false => Powered switch {
                                true => 6606,
                                false => 6607,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6608,
                                false => 6609,
                            },
                            false => Powered switch {
                                true => 6610,
                                false => 6611,
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
                                true => 6612,
                                false => 6613,
                            },
                            false => Powered switch {
                                true => 6614,
                                false => 6615,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6616,
                                false => 6617,
                            },
                            false => Powered switch {
                                true => 6618,
                                false => 6619,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6620,
                                false => 6621,
                            },
                            false => Powered switch {
                                true => 6622,
                                false => 6623,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6624,
                                false => 6625,
                            },
                            false => Powered switch {
                                true => 6626,
                                false => 6627,
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
                                true => 6628,
                                false => 6629,
                            },
                            false => Powered switch {
                                true => 6630,
                                false => 6631,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6632,
                                false => 6633,
                            },
                            false => Powered switch {
                                true => 6634,
                                false => 6635,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6636,
                                false => 6637,
                            },
                            false => Powered switch {
                                true => 6638,
                                false => 6639,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6640,
                                false => 6641,
                            },
                            false => Powered switch {
                                true => 6642,
                                false => 6643,
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
                                true => 6644,
                                false => 6645,
                            },
                            false => Powered switch {
                                true => 6646,
                                false => 6647,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6648,
                                false => 6649,
                            },
                            false => Powered switch {
                                true => 6650,
                                false => 6651,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6652,
                                false => 6653,
                            },
                            false => Powered switch {
                                true => 6654,
                                false => 6655,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6656,
                                false => 6657,
                            },
                            false => Powered switch {
                                true => 6658,
                                false => 6659,
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
            6596 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            6597 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            6598 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            6599 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            6600 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            6601 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            6602 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            6603 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            6604 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            6605 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            6606 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            6607 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            6608 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            6609 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            6610 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            6611 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            6612 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            6613 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            6614 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            6615 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            6616 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            6617 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            6618 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            6619 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            6620 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            6621 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            6622 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            6623 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            6624 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            6625 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            6626 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            6627 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            6628 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            6629 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            6630 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            6631 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            6632 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            6633 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            6634 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            6635 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            6636 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            6637 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            6638 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            6639 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            6640 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            6641 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            6642 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            6643 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            6644 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            6645 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            6646 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            6647 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            6648 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            6649 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            6650 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            6651 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            6652 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            6653 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            6654 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            6655 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            6656 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            6657 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            6658 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            6659 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.ChildrenMap.ContainsKey("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Hinge = properties.ChildrenMap.ContainsKey("hinge") ? LeftRightExtensions.FromString(properties["hinge"].GetString()) : Hinge,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", Half.ToName()),
            new StringTag("hinge", Hinge.ToName()),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
