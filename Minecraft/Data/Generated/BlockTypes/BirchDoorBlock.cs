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
    public Identifier Category => "minecraft:door";
    public int ProtocolId => 645;
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
                                true => 13922,
                                false => 13923,
                            },
                            false => Powered switch {
                                true => 13924,
                                false => 13925,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13926,
                                false => 13927,
                            },
                            false => Powered switch {
                                true => 13928,
                                false => 13929,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13930,
                                false => 13931,
                            },
                            false => Powered switch {
                                true => 13932,
                                false => 13933,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13934,
                                false => 13935,
                            },
                            false => Powered switch {
                                true => 13936,
                                false => 13937,
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
                                true => 13938,
                                false => 13939,
                            },
                            false => Powered switch {
                                true => 13940,
                                false => 13941,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13942,
                                false => 13943,
                            },
                            false => Powered switch {
                                true => 13944,
                                false => 13945,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13946,
                                false => 13947,
                            },
                            false => Powered switch {
                                true => 13948,
                                false => 13949,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13950,
                                false => 13951,
                            },
                            false => Powered switch {
                                true => 13952,
                                false => 13953,
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
                                true => 13954,
                                false => 13955,
                            },
                            false => Powered switch {
                                true => 13956,
                                false => 13957,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13958,
                                false => 13959,
                            },
                            false => Powered switch {
                                true => 13960,
                                false => 13961,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13962,
                                false => 13963,
                            },
                            false => Powered switch {
                                true => 13964,
                                false => 13965,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13966,
                                false => 13967,
                            },
                            false => Powered switch {
                                true => 13968,
                                false => 13969,
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
                                true => 13970,
                                false => 13971,
                            },
                            false => Powered switch {
                                true => 13972,
                                false => 13973,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13974,
                                false => 13975,
                            },
                            false => Powered switch {
                                true => 13976,
                                false => 13977,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13978,
                                false => 13979,
                            },
                            false => Powered switch {
                                true => 13980,
                                false => 13981,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13982,
                                false => 13983,
                            },
                            false => Powered switch {
                                true => 13984,
                                false => 13985,
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
            13922 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            13923 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            13924 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            13925 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            13926 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            13927 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            13928 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            13929 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            13930 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            13931 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            13932 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            13933 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            13934 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            13935 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            13936 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            13937 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            13938 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            13939 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            13940 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            13941 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            13942 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            13943 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            13944 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            13945 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            13946 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            13947 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            13948 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            13949 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            13950 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            13951 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            13952 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            13953 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            13954 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            13955 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            13956 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            13957 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            13958 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            13959 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            13960 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            13961 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            13962 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            13963 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            13964 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            13965 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            13966 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            13967 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            13968 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            13969 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            13970 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            13971 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            13972 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            13973 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            13974 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            13975 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            13976 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            13977 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            13978 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            13979 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            13980 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            13981 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            13982 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            13983 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            13984 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            13985 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
