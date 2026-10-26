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
public record SpruceDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.spruce_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_door", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 34, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 15971];

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
                                true => 15971,
                                false => 15972,
                            },
                            false => Powered switch {
                                true => 15973,
                                false => 15974,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 15975,
                                false => 15976,
                            },
                            false => Powered switch {
                                true => 15977,
                                false => 15978,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 15979,
                                false => 15980,
                            },
                            false => Powered switch {
                                true => 15981,
                                false => 15982,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 15983,
                                false => 15984,
                            },
                            false => Powered switch {
                                true => 15985,
                                false => 15986,
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
                                true => 15987,
                                false => 15988,
                            },
                            false => Powered switch {
                                true => 15989,
                                false => 15990,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 15991,
                                false => 15992,
                            },
                            false => Powered switch {
                                true => 15993,
                                false => 15994,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 15995,
                                false => 15996,
                            },
                            false => Powered switch {
                                true => 15997,
                                false => 15998,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 15999,
                                false => 16000,
                            },
                            false => Powered switch {
                                true => 16001,
                                false => 16002,
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
                                true => 16003,
                                false => 16004,
                            },
                            false => Powered switch {
                                true => 16005,
                                false => 16006,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16007,
                                false => 16008,
                            },
                            false => Powered switch {
                                true => 16009,
                                false => 16010,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16011,
                                false => 16012,
                            },
                            false => Powered switch {
                                true => 16013,
                                false => 16014,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16015,
                                false => 16016,
                            },
                            false => Powered switch {
                                true => 16017,
                                false => 16018,
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
                                true => 16019,
                                false => 16020,
                            },
                            false => Powered switch {
                                true => 16021,
                                false => 16022,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16023,
                                false => 16024,
                            },
                            false => Powered switch {
                                true => 16025,
                                false => 16026,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16027,
                                false => 16028,
                            },
                            false => Powered switch {
                                true => 16029,
                                false => 16030,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16031,
                                false => 16032,
                            },
                            false => Powered switch {
                                true => 16033,
                                false => 16034,
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
            15971 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            15972 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            15973 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            15974 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            15975 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            15976 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            15977 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            15978 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            15979 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            15980 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            15981 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            15982 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            15983 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            15984 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            15985 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            15986 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            15987 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            15988 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            15989 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            15990 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            15991 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            15992 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            15993 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            15994 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            15995 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            15996 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            15997 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            15998 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            15999 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            16000 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            16001 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            16002 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            16003 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            16004 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            16005 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            16006 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            16007 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            16008 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            16009 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            16010 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            16011 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            16012 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            16013 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            16014 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            16015 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            16016 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            16017 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            16018 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            16019 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            16020 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            16021 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            16022 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            16023 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            16024 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            16025 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            16026 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            16027 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            16028 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            16029 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            16030 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            16031 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            16032 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            16033 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            16034 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
