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
public record BambooDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_door", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 18, "bamboo_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 16547];

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
                                true => 16547,
                                false => 16548,
                            },
                            false => Powered switch {
                                true => 16549,
                                false => 16550,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16551,
                                false => 16552,
                            },
                            false => Powered switch {
                                true => 16553,
                                false => 16554,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16555,
                                false => 16556,
                            },
                            false => Powered switch {
                                true => 16557,
                                false => 16558,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16559,
                                false => 16560,
                            },
                            false => Powered switch {
                                true => 16561,
                                false => 16562,
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
                                true => 16563,
                                false => 16564,
                            },
                            false => Powered switch {
                                true => 16565,
                                false => 16566,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16567,
                                false => 16568,
                            },
                            false => Powered switch {
                                true => 16569,
                                false => 16570,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16571,
                                false => 16572,
                            },
                            false => Powered switch {
                                true => 16573,
                                false => 16574,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16575,
                                false => 16576,
                            },
                            false => Powered switch {
                                true => 16577,
                                false => 16578,
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
                                true => 16579,
                                false => 16580,
                            },
                            false => Powered switch {
                                true => 16581,
                                false => 16582,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16583,
                                false => 16584,
                            },
                            false => Powered switch {
                                true => 16585,
                                false => 16586,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16587,
                                false => 16588,
                            },
                            false => Powered switch {
                                true => 16589,
                                false => 16590,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16591,
                                false => 16592,
                            },
                            false => Powered switch {
                                true => 16593,
                                false => 16594,
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
                                true => 16595,
                                false => 16596,
                            },
                            false => Powered switch {
                                true => 16597,
                                false => 16598,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16599,
                                false => 16600,
                            },
                            false => Powered switch {
                                true => 16601,
                                false => 16602,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16603,
                                false => 16604,
                            },
                            false => Powered switch {
                                true => 16605,
                                false => 16606,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16607,
                                false => 16608,
                            },
                            false => Powered switch {
                                true => 16609,
                                false => 16610,
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
            16547 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            16548 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            16549 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            16550 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            16551 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            16552 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            16553 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            16554 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            16555 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            16556 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            16557 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            16558 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            16559 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            16560 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            16561 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            16562 => new BambooDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            16563 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            16564 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            16565 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            16566 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            16567 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            16568 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            16569 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            16570 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            16571 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            16572 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            16573 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            16574 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            16575 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            16576 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            16577 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            16578 => new BambooDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            16579 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            16580 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            16581 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            16582 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            16583 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            16584 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            16585 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            16586 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            16587 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            16588 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            16589 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            16590 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            16591 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            16592 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            16593 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            16594 => new BambooDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            16595 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            16596 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            16597 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            16598 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            16599 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            16600 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            16601 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            16602 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            16603 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            16604 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            16605 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            16606 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            16607 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            16608 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            16609 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            16610 => new BambooDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
