using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_weathered_copper_door";
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
    public string TranslationKey => "block.minecraft.waxed_weathered_copper_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28880,
                                false => 28881,
                            },
                            false => Powered switch {
                                true => 28882,
                                false => 28883,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28884,
                                false => 28885,
                            },
                            false => Powered switch {
                                true => 28886,
                                false => 28887,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28888,
                                false => 28889,
                            },
                            false => Powered switch {
                                true => 28890,
                                false => 28891,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28892,
                                false => 28893,
                            },
                            false => Powered switch {
                                true => 28894,
                                false => 28895,
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
                                true => 28896,
                                false => 28897,
                            },
                            false => Powered switch {
                                true => 28898,
                                false => 28899,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28900,
                                false => 28901,
                            },
                            false => Powered switch {
                                true => 28902,
                                false => 28903,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28904,
                                false => 28905,
                            },
                            false => Powered switch {
                                true => 28906,
                                false => 28907,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28908,
                                false => 28909,
                            },
                            false => Powered switch {
                                true => 28910,
                                false => 28911,
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
                                true => 28912,
                                false => 28913,
                            },
                            false => Powered switch {
                                true => 28914,
                                false => 28915,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28916,
                                false => 28917,
                            },
                            false => Powered switch {
                                true => 28918,
                                false => 28919,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28920,
                                false => 28921,
                            },
                            false => Powered switch {
                                true => 28922,
                                false => 28923,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28924,
                                false => 28925,
                            },
                            false => Powered switch {
                                true => 28926,
                                false => 28927,
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
                                true => 28928,
                                false => 28929,
                            },
                            false => Powered switch {
                                true => 28930,
                                false => 28931,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28932,
                                false => 28933,
                            },
                            false => Powered switch {
                                true => 28934,
                                false => 28935,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28936,
                                false => 28937,
                            },
                            false => Powered switch {
                                true => 28938,
                                false => 28939,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28940,
                                false => 28941,
                            },
                            false => Powered switch {
                                true => 28942,
                                false => 28943,
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
            28880 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            28881 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            28882 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            28883 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            28884 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            28885 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            28886 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            28887 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            28888 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            28889 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            28890 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            28891 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            28892 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            28893 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            28894 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            28895 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            28896 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            28897 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            28898 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            28899 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            28900 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            28901 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            28902 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            28903 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            28904 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            28905 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            28906 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            28907 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            28908 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            28909 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            28910 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            28911 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            28912 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            28913 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            28914 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            28915 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            28916 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            28917 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            28918 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            28919 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            28920 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            28921 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            28922 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            28923 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            28924 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            28925 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            28926 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            28927 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            28928 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            28929 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            28930 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            28931 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            28932 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            28933 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            28934 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            28935 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            28936 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            28937 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            28938 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            28939 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            28940 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            28941 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            28942 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            28943 => new WaxedWeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
