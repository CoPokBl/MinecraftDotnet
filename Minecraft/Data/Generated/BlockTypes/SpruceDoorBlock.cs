using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

    public Identifier Category => "minecraft:door";
    public int ProtocolId => 614;
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
    public Identifier? Item => "minecraft:spruce_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12781,
                                false => 12782,
                            },
                            false => Powered switch {
                                true => 12783,
                                false => 12784,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12785,
                                false => 12786,
                            },
                            false => Powered switch {
                                true => 12787,
                                false => 12788,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12789,
                                false => 12790,
                            },
                            false => Powered switch {
                                true => 12791,
                                false => 12792,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12793,
                                false => 12794,
                            },
                            false => Powered switch {
                                true => 12795,
                                false => 12796,
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
                                true => 12797,
                                false => 12798,
                            },
                            false => Powered switch {
                                true => 12799,
                                false => 12800,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12801,
                                false => 12802,
                            },
                            false => Powered switch {
                                true => 12803,
                                false => 12804,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12805,
                                false => 12806,
                            },
                            false => Powered switch {
                                true => 12807,
                                false => 12808,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12809,
                                false => 12810,
                            },
                            false => Powered switch {
                                true => 12811,
                                false => 12812,
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
                                true => 12813,
                                false => 12814,
                            },
                            false => Powered switch {
                                true => 12815,
                                false => 12816,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12817,
                                false => 12818,
                            },
                            false => Powered switch {
                                true => 12819,
                                false => 12820,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12821,
                                false => 12822,
                            },
                            false => Powered switch {
                                true => 12823,
                                false => 12824,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12825,
                                false => 12826,
                            },
                            false => Powered switch {
                                true => 12827,
                                false => 12828,
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
                                true => 12829,
                                false => 12830,
                            },
                            false => Powered switch {
                                true => 12831,
                                false => 12832,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12833,
                                false => 12834,
                            },
                            false => Powered switch {
                                true => 12835,
                                false => 12836,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12837,
                                false => 12838,
                            },
                            false => Powered switch {
                                true => 12839,
                                false => 12840,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12841,
                                false => 12842,
                            },
                            false => Powered switch {
                                true => 12843,
                                false => 12844,
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
            12781 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            12782 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            12783 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            12784 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            12785 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            12786 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            12787 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            12788 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            12789 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            12790 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            12791 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            12792 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            12793 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            12794 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            12795 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            12796 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            12797 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            12798 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            12799 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            12800 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            12801 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            12802 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            12803 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            12804 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            12805 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            12806 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            12807 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            12808 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            12809 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            12810 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            12811 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            12812 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            12813 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            12814 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            12815 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            12816 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            12817 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            12818 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            12819 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            12820 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            12821 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            12822 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            12823 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            12824 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            12825 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            12826 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            12827 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            12828 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            12829 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            12830 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            12831 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            12832 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            12833 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            12834 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            12835 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            12836 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            12837 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            12838 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            12839 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            12840 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            12841 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            12842 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            12843 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            12844 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
            Hinge = LeftRightExtensions.FromString(properties["hinge"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
