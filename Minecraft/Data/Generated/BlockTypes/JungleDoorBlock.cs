using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

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
    public Identifier? Item => "minecraft:jungle_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12909,
                                false => 12910,
                            },
                            false => Powered switch {
                                true => 12911,
                                false => 12912,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12913,
                                false => 12914,
                            },
                            false => Powered switch {
                                true => 12915,
                                false => 12916,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12917,
                                false => 12918,
                            },
                            false => Powered switch {
                                true => 12919,
                                false => 12920,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12921,
                                false => 12922,
                            },
                            false => Powered switch {
                                true => 12923,
                                false => 12924,
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
                                true => 12925,
                                false => 12926,
                            },
                            false => Powered switch {
                                true => 12927,
                                false => 12928,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12929,
                                false => 12930,
                            },
                            false => Powered switch {
                                true => 12931,
                                false => 12932,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12933,
                                false => 12934,
                            },
                            false => Powered switch {
                                true => 12935,
                                false => 12936,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12937,
                                false => 12938,
                            },
                            false => Powered switch {
                                true => 12939,
                                false => 12940,
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
                                true => 12941,
                                false => 12942,
                            },
                            false => Powered switch {
                                true => 12943,
                                false => 12944,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12945,
                                false => 12946,
                            },
                            false => Powered switch {
                                true => 12947,
                                false => 12948,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12949,
                                false => 12950,
                            },
                            false => Powered switch {
                                true => 12951,
                                false => 12952,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12953,
                                false => 12954,
                            },
                            false => Powered switch {
                                true => 12955,
                                false => 12956,
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
                                true => 12957,
                                false => 12958,
                            },
                            false => Powered switch {
                                true => 12959,
                                false => 12960,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12961,
                                false => 12962,
                            },
                            false => Powered switch {
                                true => 12963,
                                false => 12964,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12965,
                                false => 12966,
                            },
                            false => Powered switch {
                                true => 12967,
                                false => 12968,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12969,
                                false => 12970,
                            },
                            false => Powered switch {
                                true => 12971,
                                false => 12972,
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
            12909 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            12910 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            12911 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            12912 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            12913 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            12914 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            12915 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            12916 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            12917 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            12918 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            12919 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            12920 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            12921 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            12922 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            12923 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            12924 => new JungleDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            12925 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            12926 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            12927 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            12928 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            12929 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            12930 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            12931 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            12932 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            12933 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            12934 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            12935 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            12936 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            12937 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            12938 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            12939 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            12940 => new JungleDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            12941 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            12942 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            12943 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            12944 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            12945 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            12946 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            12947 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            12948 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            12949 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            12950 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            12951 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            12952 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            12953 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            12954 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            12955 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            12956 => new JungleDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            12957 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            12958 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            12959 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            12960 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            12961 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            12962 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            12963 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            12964 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            12965 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            12966 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            12967 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            12968 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            12969 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            12970 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            12971 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            12972 => new JungleDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
