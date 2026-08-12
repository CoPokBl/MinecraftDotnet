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
                                true => 6797,
                                false => 6798,
                            },
                            false => Powered switch {
                                true => 6799,
                                false => 6800,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6801,
                                false => 6802,
                            },
                            false => Powered switch {
                                true => 6803,
                                false => 6804,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6805,
                                false => 6806,
                            },
                            false => Powered switch {
                                true => 6807,
                                false => 6808,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6809,
                                false => 6810,
                            },
                            false => Powered switch {
                                true => 6811,
                                false => 6812,
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
                                true => 6813,
                                false => 6814,
                            },
                            false => Powered switch {
                                true => 6815,
                                false => 6816,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6817,
                                false => 6818,
                            },
                            false => Powered switch {
                                true => 6819,
                                false => 6820,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6821,
                                false => 6822,
                            },
                            false => Powered switch {
                                true => 6823,
                                false => 6824,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6825,
                                false => 6826,
                            },
                            false => Powered switch {
                                true => 6827,
                                false => 6828,
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
                                true => 6829,
                                false => 6830,
                            },
                            false => Powered switch {
                                true => 6831,
                                false => 6832,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6833,
                                false => 6834,
                            },
                            false => Powered switch {
                                true => 6835,
                                false => 6836,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6837,
                                false => 6838,
                            },
                            false => Powered switch {
                                true => 6839,
                                false => 6840,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6841,
                                false => 6842,
                            },
                            false => Powered switch {
                                true => 6843,
                                false => 6844,
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
                                true => 6845,
                                false => 6846,
                            },
                            false => Powered switch {
                                true => 6847,
                                false => 6848,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6849,
                                false => 6850,
                            },
                            false => Powered switch {
                                true => 6851,
                                false => 6852,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 6853,
                                false => 6854,
                            },
                            false => Powered switch {
                                true => 6855,
                                false => 6856,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 6857,
                                false => 6858,
                            },
                            false => Powered switch {
                                true => 6859,
                                false => 6860,
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
            6797 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            6798 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            6799 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            6800 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            6801 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            6802 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            6803 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            6804 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            6805 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            6806 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            6807 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            6808 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            6809 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            6810 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            6811 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            6812 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            6813 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            6814 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            6815 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            6816 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            6817 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            6818 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            6819 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            6820 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            6821 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            6822 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            6823 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            6824 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            6825 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            6826 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            6827 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            6828 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            6829 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            6830 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            6831 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            6832 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            6833 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            6834 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            6835 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            6836 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            6837 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            6838 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            6839 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            6840 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            6841 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            6842 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            6843 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            6844 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            6845 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            6846 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            6847 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            6848 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            6849 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            6850 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            6851 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            6852 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            6853 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            6854 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            6855 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            6856 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            6857 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            6858 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            6859 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            6860 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
