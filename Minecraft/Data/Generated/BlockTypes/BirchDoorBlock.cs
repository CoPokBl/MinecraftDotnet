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
public record BirchDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.birch_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_door", BlockInfo.VanillaOnly, "minecraft:blocks/birch_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 2, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 16035];

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
                                true => 16035,
                                false => 16036,
                            },
                            false => Powered switch {
                                true => 16037,
                                false => 16038,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16039,
                                false => 16040,
                            },
                            false => Powered switch {
                                true => 16041,
                                false => 16042,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16043,
                                false => 16044,
                            },
                            false => Powered switch {
                                true => 16045,
                                false => 16046,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16047,
                                false => 16048,
                            },
                            false => Powered switch {
                                true => 16049,
                                false => 16050,
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
                                true => 16051,
                                false => 16052,
                            },
                            false => Powered switch {
                                true => 16053,
                                false => 16054,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16055,
                                false => 16056,
                            },
                            false => Powered switch {
                                true => 16057,
                                false => 16058,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16059,
                                false => 16060,
                            },
                            false => Powered switch {
                                true => 16061,
                                false => 16062,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16063,
                                false => 16064,
                            },
                            false => Powered switch {
                                true => 16065,
                                false => 16066,
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
                                true => 16067,
                                false => 16068,
                            },
                            false => Powered switch {
                                true => 16069,
                                false => 16070,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16071,
                                false => 16072,
                            },
                            false => Powered switch {
                                true => 16073,
                                false => 16074,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16075,
                                false => 16076,
                            },
                            false => Powered switch {
                                true => 16077,
                                false => 16078,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16079,
                                false => 16080,
                            },
                            false => Powered switch {
                                true => 16081,
                                false => 16082,
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
                                true => 16083,
                                false => 16084,
                            },
                            false => Powered switch {
                                true => 16085,
                                false => 16086,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16087,
                                false => 16088,
                            },
                            false => Powered switch {
                                true => 16089,
                                false => 16090,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16091,
                                false => 16092,
                            },
                            false => Powered switch {
                                true => 16093,
                                false => 16094,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16095,
                                false => 16096,
                            },
                            false => Powered switch {
                                true => 16097,
                                false => 16098,
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
            16035 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            16036 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            16037 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            16038 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            16039 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            16040 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            16041 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            16042 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            16043 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            16044 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            16045 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            16046 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            16047 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            16048 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            16049 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            16050 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            16051 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            16052 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            16053 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            16054 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            16055 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            16056 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            16057 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            16058 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            16059 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            16060 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            16061 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            16062 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            16063 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            16064 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            16065 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            16066 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            16067 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            16068 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            16069 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            16070 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            16071 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            16072 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            16073 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            16074 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            16075 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            16076 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            16077 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            16078 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            16079 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            16080 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            16081 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            16082 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            16083 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            16084 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            16085 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            16086 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            16087 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            16088 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            16089 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            16090 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            16091 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            16092 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            16093 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            16094 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            16095 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            16096 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            16097 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            16098 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
