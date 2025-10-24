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
    public int ProtocolId => 644;
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
                                true => 13858,
                                false => 13859,
                            },
                            false => Powered switch {
                                true => 13860,
                                false => 13861,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13862,
                                false => 13863,
                            },
                            false => Powered switch {
                                true => 13864,
                                false => 13865,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13866,
                                false => 13867,
                            },
                            false => Powered switch {
                                true => 13868,
                                false => 13869,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13870,
                                false => 13871,
                            },
                            false => Powered switch {
                                true => 13872,
                                false => 13873,
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
                                true => 13874,
                                false => 13875,
                            },
                            false => Powered switch {
                                true => 13876,
                                false => 13877,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13878,
                                false => 13879,
                            },
                            false => Powered switch {
                                true => 13880,
                                false => 13881,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13882,
                                false => 13883,
                            },
                            false => Powered switch {
                                true => 13884,
                                false => 13885,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13886,
                                false => 13887,
                            },
                            false => Powered switch {
                                true => 13888,
                                false => 13889,
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
                                true => 13890,
                                false => 13891,
                            },
                            false => Powered switch {
                                true => 13892,
                                false => 13893,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13894,
                                false => 13895,
                            },
                            false => Powered switch {
                                true => 13896,
                                false => 13897,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13898,
                                false => 13899,
                            },
                            false => Powered switch {
                                true => 13900,
                                false => 13901,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13902,
                                false => 13903,
                            },
                            false => Powered switch {
                                true => 13904,
                                false => 13905,
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
                                true => 13906,
                                false => 13907,
                            },
                            false => Powered switch {
                                true => 13908,
                                false => 13909,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13910,
                                false => 13911,
                            },
                            false => Powered switch {
                                true => 13912,
                                false => 13913,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13914,
                                false => 13915,
                            },
                            false => Powered switch {
                                true => 13916,
                                false => 13917,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13918,
                                false => 13919,
                            },
                            false => Powered switch {
                                true => 13920,
                                false => 13921,
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
            13858 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            13859 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            13860 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            13861 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            13862 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            13863 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            13864 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            13865 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            13866 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            13867 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            13868 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            13869 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            13870 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            13871 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            13872 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            13873 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            13874 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            13875 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            13876 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            13877 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            13878 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            13879 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            13880 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            13881 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            13882 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            13883 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            13884 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            13885 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            13886 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            13887 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            13888 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            13889 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            13890 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            13891 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            13892 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            13893 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            13894 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            13895 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            13896 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            13897 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            13898 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            13899 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            13900 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            13901 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            13902 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            13903 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            13904 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            13905 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            13906 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            13907 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            13908 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            13909 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            13910 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            13911 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            13912 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            13913 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            13914 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            13915 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            13916 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            13917 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            13918 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            13919 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            13920 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            13921 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
