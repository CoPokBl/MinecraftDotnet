using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

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
    public Identifier? Item => "minecraft:acacia_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12973,
                                false => 12974,
                            },
                            false => Powered switch {
                                true => 12975,
                                false => 12976,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12977,
                                false => 12978,
                            },
                            false => Powered switch {
                                true => 12979,
                                false => 12980,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12981,
                                false => 12982,
                            },
                            false => Powered switch {
                                true => 12983,
                                false => 12984,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12985,
                                false => 12986,
                            },
                            false => Powered switch {
                                true => 12987,
                                false => 12988,
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
                                true => 12989,
                                false => 12990,
                            },
                            false => Powered switch {
                                true => 12991,
                                false => 12992,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 12993,
                                false => 12994,
                            },
                            false => Powered switch {
                                true => 12995,
                                false => 12996,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 12997,
                                false => 12998,
                            },
                            false => Powered switch {
                                true => 12999,
                                false => 13000,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13001,
                                false => 13002,
                            },
                            false => Powered switch {
                                true => 13003,
                                false => 13004,
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
                                true => 13005,
                                false => 13006,
                            },
                            false => Powered switch {
                                true => 13007,
                                false => 13008,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13009,
                                false => 13010,
                            },
                            false => Powered switch {
                                true => 13011,
                                false => 13012,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13013,
                                false => 13014,
                            },
                            false => Powered switch {
                                true => 13015,
                                false => 13016,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13017,
                                false => 13018,
                            },
                            false => Powered switch {
                                true => 13019,
                                false => 13020,
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
                                true => 13021,
                                false => 13022,
                            },
                            false => Powered switch {
                                true => 13023,
                                false => 13024,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13025,
                                false => 13026,
                            },
                            false => Powered switch {
                                true => 13027,
                                false => 13028,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13029,
                                false => 13030,
                            },
                            false => Powered switch {
                                true => 13031,
                                false => 13032,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13033,
                                false => 13034,
                            },
                            false => Powered switch {
                                true => 13035,
                                false => 13036,
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
            12973 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            12974 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            12975 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            12976 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            12977 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            12978 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            12979 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            12980 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            12981 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            12982 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            12983 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            12984 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            12985 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            12986 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            12987 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            12988 => new AcaciaDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            12989 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            12990 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            12991 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            12992 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            12993 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            12994 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            12995 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            12996 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            12997 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            12998 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            12999 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            13000 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            13001 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            13002 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            13003 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            13004 => new AcaciaDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            13005 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            13006 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            13007 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            13008 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            13009 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            13010 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            13011 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            13012 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            13013 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            13014 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            13015 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            13016 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            13017 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            13018 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            13019 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            13020 => new AcaciaDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            13021 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            13022 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            13023 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            13024 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            13025 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            13026 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            13027 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            13028 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            13029 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            13030 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            13031 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            13032 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            13033 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            13034 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            13035 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            13036 => new AcaciaDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
