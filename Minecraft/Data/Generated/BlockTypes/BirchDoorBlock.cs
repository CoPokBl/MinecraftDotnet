using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

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
    public Identifier? Item => "minecraft:birch_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12845,
                                false => 12846,
                            },
                            false => Powered switch {
                                true => 12847,
                                false => 12848,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12849,
                                false => 12850,
                            },
                            false => Powered switch {
                                true => 12851,
                                false => 12852,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12853,
                                false => 12854,
                            },
                            false => Powered switch {
                                true => 12855,
                                false => 12856,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12857,
                                false => 12858,
                            },
                            false => Powered switch {
                                true => 12859,
                                false => 12860,
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
                                true => 12861,
                                false => 12862,
                            },
                            false => Powered switch {
                                true => 12863,
                                false => 12864,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12865,
                                false => 12866,
                            },
                            false => Powered switch {
                                true => 12867,
                                false => 12868,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12869,
                                false => 12870,
                            },
                            false => Powered switch {
                                true => 12871,
                                false => 12872,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12873,
                                false => 12874,
                            },
                            false => Powered switch {
                                true => 12875,
                                false => 12876,
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
                                true => 12877,
                                false => 12878,
                            },
                            false => Powered switch {
                                true => 12879,
                                false => 12880,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12881,
                                false => 12882,
                            },
                            false => Powered switch {
                                true => 12883,
                                false => 12884,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12885,
                                false => 12886,
                            },
                            false => Powered switch {
                                true => 12887,
                                false => 12888,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12889,
                                false => 12890,
                            },
                            false => Powered switch {
                                true => 12891,
                                false => 12892,
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
                                true => 12893,
                                false => 12894,
                            },
                            false => Powered switch {
                                true => 12895,
                                false => 12896,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12897,
                                false => 12898,
                            },
                            false => Powered switch {
                                true => 12899,
                                false => 12900,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12901,
                                false => 12902,
                            },
                            false => Powered switch {
                                true => 12903,
                                false => 12904,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12905,
                                false => 12906,
                            },
                            false => Powered switch {
                                true => 12907,
                                false => 12908,
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
            12845 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            12846 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            12847 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            12848 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            12849 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            12850 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            12851 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            12852 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            12853 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            12854 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            12855 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            12856 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            12857 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            12858 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            12859 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            12860 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            12861 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            12862 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            12863 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            12864 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            12865 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            12866 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            12867 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            12868 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            12869 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            12870 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            12871 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            12872 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            12873 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            12874 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            12875 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            12876 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            12877 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            12878 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            12879 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            12880 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            12881 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            12882 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            12883 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            12884 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            12885 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            12886 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            12887 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            12888 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            12889 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            12890 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            12891 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            12892 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            12893 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            12894 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            12895 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            12896 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            12897 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            12898 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            12899 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            12900 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            12901 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            12902 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            12903 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            12904 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            12905 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            12906 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            12907 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            12908 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
