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
public record TripwireBlock(Identifier Identifier, bool Attached, bool Disarmed, bool East, bool North, bool Powered, bool South, bool West) : IBlock, IAttached, IPowered, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.tripwire", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:string", BlockInfo.VanillaOnly, "minecraft:blocks/tripwire");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S938, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 11341];

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

    public IBlock WithAttached(bool attached) => this with { Attached = attached };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public bool HasFace(BlockFace face) => face is BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return Attached switch {
                true => Disarmed switch {
                    true => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11341,
                                        false => 11342,
                                    },
                                    false => West switch {
                                        true => 11343,
                                        false => 11344,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11345,
                                        false => 11346,
                                    },
                                    false => West switch {
                                        true => 11347,
                                        false => 11348,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11349,
                                        false => 11350,
                                    },
                                    false => West switch {
                                        true => 11351,
                                        false => 11352,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11353,
                                        false => 11354,
                                    },
                                    false => West switch {
                                        true => 11355,
                                        false => 11356,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11357,
                                        false => 11358,
                                    },
                                    false => West switch {
                                        true => 11359,
                                        false => 11360,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11361,
                                        false => 11362,
                                    },
                                    false => West switch {
                                        true => 11363,
                                        false => 11364,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11365,
                                        false => 11366,
                                    },
                                    false => West switch {
                                        true => 11367,
                                        false => 11368,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11369,
                                        false => 11370,
                                    },
                                    false => West switch {
                                        true => 11371,
                                        false => 11372,
                                    },
                                },
                            },
                        },
                    },
                    false => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11373,
                                        false => 11374,
                                    },
                                    false => West switch {
                                        true => 11375,
                                        false => 11376,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11377,
                                        false => 11378,
                                    },
                                    false => West switch {
                                        true => 11379,
                                        false => 11380,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11381,
                                        false => 11382,
                                    },
                                    false => West switch {
                                        true => 11383,
                                        false => 11384,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11385,
                                        false => 11386,
                                    },
                                    false => West switch {
                                        true => 11387,
                                        false => 11388,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11389,
                                        false => 11390,
                                    },
                                    false => West switch {
                                        true => 11391,
                                        false => 11392,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11393,
                                        false => 11394,
                                    },
                                    false => West switch {
                                        true => 11395,
                                        false => 11396,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11397,
                                        false => 11398,
                                    },
                                    false => West switch {
                                        true => 11399,
                                        false => 11400,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11401,
                                        false => 11402,
                                    },
                                    false => West switch {
                                        true => 11403,
                                        false => 11404,
                                    },
                                },
                            },
                        },
                    },
                },
                false => Disarmed switch {
                    true => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11405,
                                        false => 11406,
                                    },
                                    false => West switch {
                                        true => 11407,
                                        false => 11408,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11409,
                                        false => 11410,
                                    },
                                    false => West switch {
                                        true => 11411,
                                        false => 11412,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11413,
                                        false => 11414,
                                    },
                                    false => West switch {
                                        true => 11415,
                                        false => 11416,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11417,
                                        false => 11418,
                                    },
                                    false => West switch {
                                        true => 11419,
                                        false => 11420,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11421,
                                        false => 11422,
                                    },
                                    false => West switch {
                                        true => 11423,
                                        false => 11424,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11425,
                                        false => 11426,
                                    },
                                    false => West switch {
                                        true => 11427,
                                        false => 11428,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11429,
                                        false => 11430,
                                    },
                                    false => West switch {
                                        true => 11431,
                                        false => 11432,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11433,
                                        false => 11434,
                                    },
                                    false => West switch {
                                        true => 11435,
                                        false => 11436,
                                    },
                                },
                            },
                        },
                    },
                    false => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11437,
                                        false => 11438,
                                    },
                                    false => West switch {
                                        true => 11439,
                                        false => 11440,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11441,
                                        false => 11442,
                                    },
                                    false => West switch {
                                        true => 11443,
                                        false => 11444,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11445,
                                        false => 11446,
                                    },
                                    false => West switch {
                                        true => 11447,
                                        false => 11448,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11449,
                                        false => 11450,
                                    },
                                    false => West switch {
                                        true => 11451,
                                        false => 11452,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11453,
                                        false => 11454,
                                    },
                                    false => West switch {
                                        true => 11455,
                                        false => 11456,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11457,
                                        false => 11458,
                                    },
                                    false => West switch {
                                        true => 11459,
                                        false => 11460,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 11461,
                                        false => 11462,
                                    },
                                    false => West switch {
                                        true => 11463,
                                        false => 11464,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 11465,
                                        false => 11466,
                                    },
                                    false => West switch {
                                        true => 11467,
                                        false => 11468,
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11341 => new TripwireBlock(Identifier, true, true, true, true, true, true, true),
            11342 => new TripwireBlock(Identifier, true, true, true, true, true, true, false),
            11343 => new TripwireBlock(Identifier, true, true, true, true, true, false, true),
            11344 => new TripwireBlock(Identifier, true, true, true, true, true, false, false),
            11345 => new TripwireBlock(Identifier, true, true, true, true, false, true, true),
            11346 => new TripwireBlock(Identifier, true, true, true, true, false, true, false),
            11347 => new TripwireBlock(Identifier, true, true, true, true, false, false, true),
            11348 => new TripwireBlock(Identifier, true, true, true, true, false, false, false),
            11349 => new TripwireBlock(Identifier, true, true, true, false, true, true, true),
            11350 => new TripwireBlock(Identifier, true, true, true, false, true, true, false),
            11351 => new TripwireBlock(Identifier, true, true, true, false, true, false, true),
            11352 => new TripwireBlock(Identifier, true, true, true, false, true, false, false),
            11353 => new TripwireBlock(Identifier, true, true, true, false, false, true, true),
            11354 => new TripwireBlock(Identifier, true, true, true, false, false, true, false),
            11355 => new TripwireBlock(Identifier, true, true, true, false, false, false, true),
            11356 => new TripwireBlock(Identifier, true, true, true, false, false, false, false),
            11357 => new TripwireBlock(Identifier, true, true, false, true, true, true, true),
            11358 => new TripwireBlock(Identifier, true, true, false, true, true, true, false),
            11359 => new TripwireBlock(Identifier, true, true, false, true, true, false, true),
            11360 => new TripwireBlock(Identifier, true, true, false, true, true, false, false),
            11361 => new TripwireBlock(Identifier, true, true, false, true, false, true, true),
            11362 => new TripwireBlock(Identifier, true, true, false, true, false, true, false),
            11363 => new TripwireBlock(Identifier, true, true, false, true, false, false, true),
            11364 => new TripwireBlock(Identifier, true, true, false, true, false, false, false),
            11365 => new TripwireBlock(Identifier, true, true, false, false, true, true, true),
            11366 => new TripwireBlock(Identifier, true, true, false, false, true, true, false),
            11367 => new TripwireBlock(Identifier, true, true, false, false, true, false, true),
            11368 => new TripwireBlock(Identifier, true, true, false, false, true, false, false),
            11369 => new TripwireBlock(Identifier, true, true, false, false, false, true, true),
            11370 => new TripwireBlock(Identifier, true, true, false, false, false, true, false),
            11371 => new TripwireBlock(Identifier, true, true, false, false, false, false, true),
            11372 => new TripwireBlock(Identifier, true, true, false, false, false, false, false),
            11373 => new TripwireBlock(Identifier, true, false, true, true, true, true, true),
            11374 => new TripwireBlock(Identifier, true, false, true, true, true, true, false),
            11375 => new TripwireBlock(Identifier, true, false, true, true, true, false, true),
            11376 => new TripwireBlock(Identifier, true, false, true, true, true, false, false),
            11377 => new TripwireBlock(Identifier, true, false, true, true, false, true, true),
            11378 => new TripwireBlock(Identifier, true, false, true, true, false, true, false),
            11379 => new TripwireBlock(Identifier, true, false, true, true, false, false, true),
            11380 => new TripwireBlock(Identifier, true, false, true, true, false, false, false),
            11381 => new TripwireBlock(Identifier, true, false, true, false, true, true, true),
            11382 => new TripwireBlock(Identifier, true, false, true, false, true, true, false),
            11383 => new TripwireBlock(Identifier, true, false, true, false, true, false, true),
            11384 => new TripwireBlock(Identifier, true, false, true, false, true, false, false),
            11385 => new TripwireBlock(Identifier, true, false, true, false, false, true, true),
            11386 => new TripwireBlock(Identifier, true, false, true, false, false, true, false),
            11387 => new TripwireBlock(Identifier, true, false, true, false, false, false, true),
            11388 => new TripwireBlock(Identifier, true, false, true, false, false, false, false),
            11389 => new TripwireBlock(Identifier, true, false, false, true, true, true, true),
            11390 => new TripwireBlock(Identifier, true, false, false, true, true, true, false),
            11391 => new TripwireBlock(Identifier, true, false, false, true, true, false, true),
            11392 => new TripwireBlock(Identifier, true, false, false, true, true, false, false),
            11393 => new TripwireBlock(Identifier, true, false, false, true, false, true, true),
            11394 => new TripwireBlock(Identifier, true, false, false, true, false, true, false),
            11395 => new TripwireBlock(Identifier, true, false, false, true, false, false, true),
            11396 => new TripwireBlock(Identifier, true, false, false, true, false, false, false),
            11397 => new TripwireBlock(Identifier, true, false, false, false, true, true, true),
            11398 => new TripwireBlock(Identifier, true, false, false, false, true, true, false),
            11399 => new TripwireBlock(Identifier, true, false, false, false, true, false, true),
            11400 => new TripwireBlock(Identifier, true, false, false, false, true, false, false),
            11401 => new TripwireBlock(Identifier, true, false, false, false, false, true, true),
            11402 => new TripwireBlock(Identifier, true, false, false, false, false, true, false),
            11403 => new TripwireBlock(Identifier, true, false, false, false, false, false, true),
            11404 => new TripwireBlock(Identifier, true, false, false, false, false, false, false),
            11405 => new TripwireBlock(Identifier, false, true, true, true, true, true, true),
            11406 => new TripwireBlock(Identifier, false, true, true, true, true, true, false),
            11407 => new TripwireBlock(Identifier, false, true, true, true, true, false, true),
            11408 => new TripwireBlock(Identifier, false, true, true, true, true, false, false),
            11409 => new TripwireBlock(Identifier, false, true, true, true, false, true, true),
            11410 => new TripwireBlock(Identifier, false, true, true, true, false, true, false),
            11411 => new TripwireBlock(Identifier, false, true, true, true, false, false, true),
            11412 => new TripwireBlock(Identifier, false, true, true, true, false, false, false),
            11413 => new TripwireBlock(Identifier, false, true, true, false, true, true, true),
            11414 => new TripwireBlock(Identifier, false, true, true, false, true, true, false),
            11415 => new TripwireBlock(Identifier, false, true, true, false, true, false, true),
            11416 => new TripwireBlock(Identifier, false, true, true, false, true, false, false),
            11417 => new TripwireBlock(Identifier, false, true, true, false, false, true, true),
            11418 => new TripwireBlock(Identifier, false, true, true, false, false, true, false),
            11419 => new TripwireBlock(Identifier, false, true, true, false, false, false, true),
            11420 => new TripwireBlock(Identifier, false, true, true, false, false, false, false),
            11421 => new TripwireBlock(Identifier, false, true, false, true, true, true, true),
            11422 => new TripwireBlock(Identifier, false, true, false, true, true, true, false),
            11423 => new TripwireBlock(Identifier, false, true, false, true, true, false, true),
            11424 => new TripwireBlock(Identifier, false, true, false, true, true, false, false),
            11425 => new TripwireBlock(Identifier, false, true, false, true, false, true, true),
            11426 => new TripwireBlock(Identifier, false, true, false, true, false, true, false),
            11427 => new TripwireBlock(Identifier, false, true, false, true, false, false, true),
            11428 => new TripwireBlock(Identifier, false, true, false, true, false, false, false),
            11429 => new TripwireBlock(Identifier, false, true, false, false, true, true, true),
            11430 => new TripwireBlock(Identifier, false, true, false, false, true, true, false),
            11431 => new TripwireBlock(Identifier, false, true, false, false, true, false, true),
            11432 => new TripwireBlock(Identifier, false, true, false, false, true, false, false),
            11433 => new TripwireBlock(Identifier, false, true, false, false, false, true, true),
            11434 => new TripwireBlock(Identifier, false, true, false, false, false, true, false),
            11435 => new TripwireBlock(Identifier, false, true, false, false, false, false, true),
            11436 => new TripwireBlock(Identifier, false, true, false, false, false, false, false),
            11437 => new TripwireBlock(Identifier, false, false, true, true, true, true, true),
            11438 => new TripwireBlock(Identifier, false, false, true, true, true, true, false),
            11439 => new TripwireBlock(Identifier, false, false, true, true, true, false, true),
            11440 => new TripwireBlock(Identifier, false, false, true, true, true, false, false),
            11441 => new TripwireBlock(Identifier, false, false, true, true, false, true, true),
            11442 => new TripwireBlock(Identifier, false, false, true, true, false, true, false),
            11443 => new TripwireBlock(Identifier, false, false, true, true, false, false, true),
            11444 => new TripwireBlock(Identifier, false, false, true, true, false, false, false),
            11445 => new TripwireBlock(Identifier, false, false, true, false, true, true, true),
            11446 => new TripwireBlock(Identifier, false, false, true, false, true, true, false),
            11447 => new TripwireBlock(Identifier, false, false, true, false, true, false, true),
            11448 => new TripwireBlock(Identifier, false, false, true, false, true, false, false),
            11449 => new TripwireBlock(Identifier, false, false, true, false, false, true, true),
            11450 => new TripwireBlock(Identifier, false, false, true, false, false, true, false),
            11451 => new TripwireBlock(Identifier, false, false, true, false, false, false, true),
            11452 => new TripwireBlock(Identifier, false, false, true, false, false, false, false),
            11453 => new TripwireBlock(Identifier, false, false, false, true, true, true, true),
            11454 => new TripwireBlock(Identifier, false, false, false, true, true, true, false),
            11455 => new TripwireBlock(Identifier, false, false, false, true, true, false, true),
            11456 => new TripwireBlock(Identifier, false, false, false, true, true, false, false),
            11457 => new TripwireBlock(Identifier, false, false, false, true, false, true, true),
            11458 => new TripwireBlock(Identifier, false, false, false, true, false, true, false),
            11459 => new TripwireBlock(Identifier, false, false, false, true, false, false, true),
            11460 => new TripwireBlock(Identifier, false, false, false, true, false, false, false),
            11461 => new TripwireBlock(Identifier, false, false, false, false, true, true, true),
            11462 => new TripwireBlock(Identifier, false, false, false, false, true, true, false),
            11463 => new TripwireBlock(Identifier, false, false, false, false, true, false, true),
            11464 => new TripwireBlock(Identifier, false, false, false, false, true, false, false),
            11465 => new TripwireBlock(Identifier, false, false, false, false, false, true, true),
            11466 => new TripwireBlock(Identifier, false, false, false, false, false, true, false),
            11467 => new TripwireBlock(Identifier, false, false, false, false, false, false, true),
            11468 => new TripwireBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Disarmed = properties.Contains("disarmed") ? properties["disarmed"].GetString() == "true" : Disarmed,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("disarmed", new StringTag(Disarmed.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
