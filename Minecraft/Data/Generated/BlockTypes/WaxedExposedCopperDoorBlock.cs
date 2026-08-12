using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:door";
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28816,
                                false => 28817,
                            },
                            false => Powered switch {
                                true => 28818,
                                false => 28819,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28820,
                                false => 28821,
                            },
                            false => Powered switch {
                                true => 28822,
                                false => 28823,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28824,
                                false => 28825,
                            },
                            false => Powered switch {
                                true => 28826,
                                false => 28827,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28828,
                                false => 28829,
                            },
                            false => Powered switch {
                                true => 28830,
                                false => 28831,
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
                                true => 28832,
                                false => 28833,
                            },
                            false => Powered switch {
                                true => 28834,
                                false => 28835,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28836,
                                false => 28837,
                            },
                            false => Powered switch {
                                true => 28838,
                                false => 28839,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28840,
                                false => 28841,
                            },
                            false => Powered switch {
                                true => 28842,
                                false => 28843,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28844,
                                false => 28845,
                            },
                            false => Powered switch {
                                true => 28846,
                                false => 28847,
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
                                true => 28848,
                                false => 28849,
                            },
                            false => Powered switch {
                                true => 28850,
                                false => 28851,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28852,
                                false => 28853,
                            },
                            false => Powered switch {
                                true => 28854,
                                false => 28855,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28856,
                                false => 28857,
                            },
                            false => Powered switch {
                                true => 28858,
                                false => 28859,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28860,
                                false => 28861,
                            },
                            false => Powered switch {
                                true => 28862,
                                false => 28863,
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
                                true => 28864,
                                false => 28865,
                            },
                            false => Powered switch {
                                true => 28866,
                                false => 28867,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28868,
                                false => 28869,
                            },
                            false => Powered switch {
                                true => 28870,
                                false => 28871,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28872,
                                false => 28873,
                            },
                            false => Powered switch {
                                true => 28874,
                                false => 28875,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28876,
                                false => 28877,
                            },
                            false => Powered switch {
                                true => 28878,
                                false => 28879,
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
            28816 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            28817 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            28818 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            28819 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            28820 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            28821 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            28822 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            28823 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            28824 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            28825 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            28826 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            28827 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            28828 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            28829 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            28830 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            28831 => new WaxedExposedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            28832 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            28833 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            28834 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            28835 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            28836 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            28837 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            28838 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            28839 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            28840 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            28841 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            28842 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            28843 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            28844 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            28845 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            28846 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            28847 => new WaxedExposedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            28848 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            28849 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            28850 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            28851 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            28852 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            28853 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            28854 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            28855 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            28856 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            28857 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            28858 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            28859 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            28860 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            28861 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            28862 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            28863 => new WaxedExposedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            28864 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            28865 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            28866 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            28867 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            28868 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            28869 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            28870 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            28871 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            28872 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            28873 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            28874 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            28875 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            28876 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            28877 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            28878 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            28879 => new WaxedExposedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
