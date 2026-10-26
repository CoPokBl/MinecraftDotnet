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
public record PoplarDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.poplar_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:poplar_door", BlockInfo.VanillaOnly, "minecraft:blocks/poplar_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 22, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 16483];

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
                                true => 16483,
                                false => 16484,
                            },
                            false => Powered switch {
                                true => 16485,
                                false => 16486,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16487,
                                false => 16488,
                            },
                            false => Powered switch {
                                true => 16489,
                                false => 16490,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16491,
                                false => 16492,
                            },
                            false => Powered switch {
                                true => 16493,
                                false => 16494,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16495,
                                false => 16496,
                            },
                            false => Powered switch {
                                true => 16497,
                                false => 16498,
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
                                true => 16499,
                                false => 16500,
                            },
                            false => Powered switch {
                                true => 16501,
                                false => 16502,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16503,
                                false => 16504,
                            },
                            false => Powered switch {
                                true => 16505,
                                false => 16506,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16507,
                                false => 16508,
                            },
                            false => Powered switch {
                                true => 16509,
                                false => 16510,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16511,
                                false => 16512,
                            },
                            false => Powered switch {
                                true => 16513,
                                false => 16514,
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
                                true => 16515,
                                false => 16516,
                            },
                            false => Powered switch {
                                true => 16517,
                                false => 16518,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16519,
                                false => 16520,
                            },
                            false => Powered switch {
                                true => 16521,
                                false => 16522,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16523,
                                false => 16524,
                            },
                            false => Powered switch {
                                true => 16525,
                                false => 16526,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16527,
                                false => 16528,
                            },
                            false => Powered switch {
                                true => 16529,
                                false => 16530,
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
                                true => 16531,
                                false => 16532,
                            },
                            false => Powered switch {
                                true => 16533,
                                false => 16534,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16535,
                                false => 16536,
                            },
                            false => Powered switch {
                                true => 16537,
                                false => 16538,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16539,
                                false => 16540,
                            },
                            false => Powered switch {
                                true => 16541,
                                false => 16542,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16543,
                                false => 16544,
                            },
                            false => Powered switch {
                                true => 16545,
                                false => 16546,
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
            16483 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            16484 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            16485 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            16486 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            16487 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            16488 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            16489 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            16490 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            16491 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            16492 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            16493 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            16494 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            16495 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            16496 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            16497 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            16498 => new PoplarDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            16499 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            16500 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            16501 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            16502 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            16503 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            16504 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            16505 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            16506 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            16507 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            16508 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            16509 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            16510 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            16511 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            16512 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            16513 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            16514 => new PoplarDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            16515 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            16516 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            16517 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            16518 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            16519 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            16520 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            16521 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            16522 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            16523 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            16524 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            16525 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            16526 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            16527 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            16528 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            16529 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            16530 => new PoplarDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            16531 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            16532 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            16533 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            16534 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            16535 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            16536 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            16537 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            16538 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            16539 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            16540 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            16541 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            16542 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            16543 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            16544 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            16545 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            16546 => new PoplarDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
