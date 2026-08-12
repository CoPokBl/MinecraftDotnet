using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:oak_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5655,
                                false => 5656,
                            },
                            false => Powered switch {
                                true => 5657,
                                false => 5658,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5659,
                                false => 5660,
                            },
                            false => Powered switch {
                                true => 5661,
                                false => 5662,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5663,
                                false => 5664,
                            },
                            false => Powered switch {
                                true => 5665,
                                false => 5666,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5667,
                                false => 5668,
                            },
                            false => Powered switch {
                                true => 5669,
                                false => 5670,
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
                                true => 5671,
                                false => 5672,
                            },
                            false => Powered switch {
                                true => 5673,
                                false => 5674,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5675,
                                false => 5676,
                            },
                            false => Powered switch {
                                true => 5677,
                                false => 5678,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5679,
                                false => 5680,
                            },
                            false => Powered switch {
                                true => 5681,
                                false => 5682,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5683,
                                false => 5684,
                            },
                            false => Powered switch {
                                true => 5685,
                                false => 5686,
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
                                true => 5687,
                                false => 5688,
                            },
                            false => Powered switch {
                                true => 5689,
                                false => 5690,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5691,
                                false => 5692,
                            },
                            false => Powered switch {
                                true => 5693,
                                false => 5694,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5695,
                                false => 5696,
                            },
                            false => Powered switch {
                                true => 5697,
                                false => 5698,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5699,
                                false => 5700,
                            },
                            false => Powered switch {
                                true => 5701,
                                false => 5702,
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
                                true => 5703,
                                false => 5704,
                            },
                            false => Powered switch {
                                true => 5705,
                                false => 5706,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5707,
                                false => 5708,
                            },
                            false => Powered switch {
                                true => 5709,
                                false => 5710,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 5711,
                                false => 5712,
                            },
                            false => Powered switch {
                                true => 5713,
                                false => 5714,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 5715,
                                false => 5716,
                            },
                            false => Powered switch {
                                true => 5717,
                                false => 5718,
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
            5655 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            5656 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            5657 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            5658 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            5659 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            5660 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            5661 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            5662 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            5663 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            5664 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            5665 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            5666 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            5667 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            5668 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            5669 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            5670 => new OakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            5671 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            5672 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            5673 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            5674 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            5675 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            5676 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            5677 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            5678 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            5679 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            5680 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            5681 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            5682 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            5683 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            5684 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            5685 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            5686 => new OakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            5687 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            5688 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            5689 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            5690 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            5691 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            5692 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            5693 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            5694 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            5695 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            5696 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            5697 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            5698 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            5699 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            5700 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            5701 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            5702 => new OakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            5703 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            5704 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            5705 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            5706 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            5707 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            5708 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            5709 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            5710 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            5711 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            5712 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            5713 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            5714 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            5715 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            5716 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            5717 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            5718 => new OakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
