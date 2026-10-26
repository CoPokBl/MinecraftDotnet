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
public record PaleOakDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock, IHorizontalFacing, IDoubleHalved, IHinged, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_door", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_door", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_door");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Popped, 14, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S17, BlockShapes.S17, BlockShapes.S1, BlockShapes.S1, BlockShapes.S17, BlockShapes.S17);
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

    public BlockStateInfo StateInfo => States[StateId - 16355];

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
                                true => 16355,
                                false => 16356,
                            },
                            false => Powered switch {
                                true => 16357,
                                false => 16358,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16359,
                                false => 16360,
                            },
                            false => Powered switch {
                                true => 16361,
                                false => 16362,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16363,
                                false => 16364,
                            },
                            false => Powered switch {
                                true => 16365,
                                false => 16366,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16367,
                                false => 16368,
                            },
                            false => Powered switch {
                                true => 16369,
                                false => 16370,
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
                                true => 16371,
                                false => 16372,
                            },
                            false => Powered switch {
                                true => 16373,
                                false => 16374,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16375,
                                false => 16376,
                            },
                            false => Powered switch {
                                true => 16377,
                                false => 16378,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16379,
                                false => 16380,
                            },
                            false => Powered switch {
                                true => 16381,
                                false => 16382,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16383,
                                false => 16384,
                            },
                            false => Powered switch {
                                true => 16385,
                                false => 16386,
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
                                true => 16387,
                                false => 16388,
                            },
                            false => Powered switch {
                                true => 16389,
                                false => 16390,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16391,
                                false => 16392,
                            },
                            false => Powered switch {
                                true => 16393,
                                false => 16394,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16395,
                                false => 16396,
                            },
                            false => Powered switch {
                                true => 16397,
                                false => 16398,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16399,
                                false => 16400,
                            },
                            false => Powered switch {
                                true => 16401,
                                false => 16402,
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
                                true => 16403,
                                false => 16404,
                            },
                            false => Powered switch {
                                true => 16405,
                                false => 16406,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16407,
                                false => 16408,
                            },
                            false => Powered switch {
                                true => 16409,
                                false => 16410,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 16411,
                                false => 16412,
                            },
                            false => Powered switch {
                                true => 16413,
                                false => 16414,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 16415,
                                false => 16416,
                            },
                            false => Powered switch {
                                true => 16417,
                                false => 16418,
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
            16355 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            16356 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            16357 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            16358 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            16359 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            16360 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            16361 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            16362 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            16363 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            16364 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            16365 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            16366 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            16367 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            16368 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            16369 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            16370 => new PaleOakDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            16371 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            16372 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            16373 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            16374 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            16375 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            16376 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            16377 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            16378 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            16379 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            16380 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            16381 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            16382 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            16383 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            16384 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            16385 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            16386 => new PaleOakDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            16387 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            16388 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            16389 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            16390 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            16391 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            16392 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            16393 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            16394 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            16395 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            16396 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            16397 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            16398 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            16399 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            16400 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            16401 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            16402 => new PaleOakDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            16403 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            16404 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            16405 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            16406 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            16407 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            16408 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            16409 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            16410 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            16411 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            16412 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            16413 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            16414 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            16415 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            16416 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            16417 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            16418 => new PaleOakDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
