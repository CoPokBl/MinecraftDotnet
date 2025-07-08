using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13037,
                                false => 13038,
                            },
                            false => Powered switch {
                                true => 13039,
                                false => 13040,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13041,
                                false => 13042,
                            },
                            false => Powered switch {
                                true => 13043,
                                false => 13044,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13045,
                                false => 13046,
                            },
                            false => Powered switch {
                                true => 13047,
                                false => 13048,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13049,
                                false => 13050,
                            },
                            false => Powered switch {
                                true => 13051,
                                false => 13052,
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
                                true => 13053,
                                false => 13054,
                            },
                            false => Powered switch {
                                true => 13055,
                                false => 13056,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13057,
                                false => 13058,
                            },
                            false => Powered switch {
                                true => 13059,
                                false => 13060,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13061,
                                false => 13062,
                            },
                            false => Powered switch {
                                true => 13063,
                                false => 13064,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13065,
                                false => 13066,
                            },
                            false => Powered switch {
                                true => 13067,
                                false => 13068,
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
                                true => 13069,
                                false => 13070,
                            },
                            false => Powered switch {
                                true => 13071,
                                false => 13072,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13073,
                                false => 13074,
                            },
                            false => Powered switch {
                                true => 13075,
                                false => 13076,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13077,
                                false => 13078,
                            },
                            false => Powered switch {
                                true => 13079,
                                false => 13080,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13081,
                                false => 13082,
                            },
                            false => Powered switch {
                                true => 13083,
                                false => 13084,
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
                                true => 13085,
                                false => 13086,
                            },
                            false => Powered switch {
                                true => 13087,
                                false => 13088,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13089,
                                false => 13090,
                            },
                            false => Powered switch {
                                true => 13091,
                                false => 13092,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13093,
                                false => 13094,
                            },
                            false => Powered switch {
                                true => 13095,
                                false => 13096,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13097,
                                false => 13098,
                            },
                            false => Powered switch {
                                true => 13099,
                                false => 13100,
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
            13037 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            13038 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            13039 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            13040 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            13041 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            13042 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            13043 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            13044 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            13045 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            13046 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            13047 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            13048 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            13049 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            13050 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            13051 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            13052 => new CherryDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            13053 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            13054 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            13055 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            13056 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            13057 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            13058 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            13059 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            13060 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            13061 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            13062 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            13063 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            13064 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            13065 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            13066 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            13067 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            13068 => new CherryDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            13069 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            13070 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            13071 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            13072 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            13073 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            13074 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            13075 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            13076 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            13077 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            13078 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            13079 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            13080 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            13081 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            13082 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            13083 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            13084 => new CherryDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            13085 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            13086 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            13087 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            13088 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            13089 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            13090 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            13091 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            13092 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            13093 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            13094 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            13095 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            13096 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            13097 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            13098 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            13099 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            13100 => new CherryDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
