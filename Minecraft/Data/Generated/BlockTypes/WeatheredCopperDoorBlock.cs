using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.weathered_copper_door", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weathered_copper_door", BlockInfo.VanillaOnly, "minecraft:blocks/weathered_copper_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 56, "copper", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
    private static readonly BlockStateInfo I1 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S18, CollisionShape = BlockShapes.S18, VisualShape = BlockShapes.S18, SupportShape = BlockShapes.S18 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I3 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S18, CollisionShape = BlockShapes.S18, VisualShape = BlockShapes.S18, SupportShape = BlockShapes.S18 };
    private static readonly BlockStateInfo I5 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { PathfindableLand = false, PathfindableAir = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I1, I1, I0, I0, I1, I1, I2, I2, I1, I1, I2, I2, I3, I3, I0, I0, I3, I3, I2, I2, I3, I3, I0, I0, I3, I3, I4, I4, I5, I5, I6, I6, I5, I5, I4, I4, I5, I5, I6, I6, I5, I5, I6, I6, I7, I7, I4, I4, I7, I7, I6, I6, I7, I7, I4, I4, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 31981];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithHalf(BlockHalf half) => this with { Half = half };

    public IBlock WithHinge(LeftRight hinge) => this with { Hinge = hinge };

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 31981,
                                false => 31982,
                            },
                            false => Powered switch {
                                true => 31983,
                                false => 31984,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 31985,
                                false => 31986,
                            },
                            false => Powered switch {
                                true => 31987,
                                false => 31988,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 31989,
                                false => 31990,
                            },
                            false => Powered switch {
                                true => 31991,
                                false => 31992,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 31993,
                                false => 31994,
                            },
                            false => Powered switch {
                                true => 31995,
                                false => 31996,
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
                                true => 31997,
                                false => 31998,
                            },
                            false => Powered switch {
                                true => 31999,
                                false => 32000,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 32001,
                                false => 32002,
                            },
                            false => Powered switch {
                                true => 32003,
                                false => 32004,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 32005,
                                false => 32006,
                            },
                            false => Powered switch {
                                true => 32007,
                                false => 32008,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 32009,
                                false => 32010,
                            },
                            false => Powered switch {
                                true => 32011,
                                false => 32012,
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
                                true => 32013,
                                false => 32014,
                            },
                            false => Powered switch {
                                true => 32015,
                                false => 32016,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 32017,
                                false => 32018,
                            },
                            false => Powered switch {
                                true => 32019,
                                false => 32020,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 32021,
                                false => 32022,
                            },
                            false => Powered switch {
                                true => 32023,
                                false => 32024,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 32025,
                                false => 32026,
                            },
                            false => Powered switch {
                                true => 32027,
                                false => 32028,
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
                                true => 32029,
                                false => 32030,
                            },
                            false => Powered switch {
                                true => 32031,
                                false => 32032,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 32033,
                                false => 32034,
                            },
                            false => Powered switch {
                                true => 32035,
                                false => 32036,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 32037,
                                false => 32038,
                            },
                            false => Powered switch {
                                true => 32039,
                                false => 32040,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 32041,
                                false => 32042,
                            },
                            false => Powered switch {
                                true => 32043,
                                false => 32044,
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
            31981 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            31982 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            31983 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            31984 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            31985 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            31986 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            31987 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            31988 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            31989 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            31990 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            31991 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            31992 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            31993 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            31994 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            31995 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            31996 => new WeatheredCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            31997 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            31998 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            31999 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            32000 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            32001 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            32002 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            32003 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            32004 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            32005 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            32006 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            32007 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            32008 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            32009 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            32010 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            32011 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            32012 => new WeatheredCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            32013 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            32014 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            32015 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            32016 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            32017 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            32018 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            32019 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            32020 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            32021 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            32022 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            32023 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            32024 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            32025 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            32026 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            32027 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            32028 => new WeatheredCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            32029 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            32030 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            32031 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            32032 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            32033 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            32034 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            32035 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            32036 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            32037 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            32038 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            32039 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            32040 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            32041 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            32042 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            32043 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            32044 => new WeatheredCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
