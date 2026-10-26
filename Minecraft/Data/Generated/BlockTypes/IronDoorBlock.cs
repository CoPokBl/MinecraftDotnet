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
public record IronDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.iron_door", 5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:iron_door", BlockInfo.VanillaOnly, "minecraft:blocks/iron_door");
    private static readonly BlockStateInfo I0 = new(5f, 0, 0, PushReaction.Popped, 6, "iron", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 8465];

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
                                true => 8465,
                                false => 8466,
                            },
                            false => Powered switch {
                                true => 8467,
                                false => 8468,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8469,
                                false => 8470,
                            },
                            false => Powered switch {
                                true => 8471,
                                false => 8472,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 8473,
                                false => 8474,
                            },
                            false => Powered switch {
                                true => 8475,
                                false => 8476,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8477,
                                false => 8478,
                            },
                            false => Powered switch {
                                true => 8479,
                                false => 8480,
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
                                true => 8481,
                                false => 8482,
                            },
                            false => Powered switch {
                                true => 8483,
                                false => 8484,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8485,
                                false => 8486,
                            },
                            false => Powered switch {
                                true => 8487,
                                false => 8488,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 8489,
                                false => 8490,
                            },
                            false => Powered switch {
                                true => 8491,
                                false => 8492,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8493,
                                false => 8494,
                            },
                            false => Powered switch {
                                true => 8495,
                                false => 8496,
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
                                true => 8497,
                                false => 8498,
                            },
                            false => Powered switch {
                                true => 8499,
                                false => 8500,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8501,
                                false => 8502,
                            },
                            false => Powered switch {
                                true => 8503,
                                false => 8504,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 8505,
                                false => 8506,
                            },
                            false => Powered switch {
                                true => 8507,
                                false => 8508,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8509,
                                false => 8510,
                            },
                            false => Powered switch {
                                true => 8511,
                                false => 8512,
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
                                true => 8513,
                                false => 8514,
                            },
                            false => Powered switch {
                                true => 8515,
                                false => 8516,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8517,
                                false => 8518,
                            },
                            false => Powered switch {
                                true => 8519,
                                false => 8520,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 8521,
                                false => 8522,
                            },
                            false => Powered switch {
                                true => 8523,
                                false => 8524,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 8525,
                                false => 8526,
                            },
                            false => Powered switch {
                                true => 8527,
                                false => 8528,
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
            8465 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            8466 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            8467 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            8468 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            8469 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            8470 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            8471 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            8472 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            8473 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            8474 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            8475 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            8476 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            8477 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            8478 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            8479 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            8480 => new IronDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            8481 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            8482 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            8483 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            8484 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            8485 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            8486 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            8487 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            8488 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            8489 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            8490 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            8491 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            8492 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            8493 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            8494 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            8495 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            8496 => new IronDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            8497 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            8498 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            8499 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            8500 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            8501 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            8502 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            8503 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            8504 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            8505 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            8506 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            8507 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            8508 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            8509 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            8510 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            8511 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            8512 => new IronDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            8513 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            8514 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            8515 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            8516 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            8517 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            8518 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            8519 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            8520 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            8521 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            8522 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            8523 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            8524 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            8525 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            8526 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            8527 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            8528 => new IronDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
