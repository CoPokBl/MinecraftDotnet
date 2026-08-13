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
public record FireBlock(Identifier Identifier, int Age, bool East, bool North, bool South, bool Up, bool West) : IBlock, IFaceConnected {
    private static readonly BlockInfo Data = new("minecraft:fire", "block.minecraft.fire", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, null, BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 15, 0, PushReaction.Destroy, 4, "wool", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S529, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 3375];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public bool HasFace(BlockFace face) => face is BlockFace.PosY or BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.PosY => Up,
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.PosY => this with { Up = connected },
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return Age switch {
                0 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3375,
                                    false => 3376,
                                },
                                false => West switch {
                                    true => 3377,
                                    false => 3378,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3379,
                                    false => 3380,
                                },
                                false => West switch {
                                    true => 3381,
                                    false => 3382,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3383,
                                    false => 3384,
                                },
                                false => West switch {
                                    true => 3385,
                                    false => 3386,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3387,
                                    false => 3388,
                                },
                                false => West switch {
                                    true => 3389,
                                    false => 3390,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3391,
                                    false => 3392,
                                },
                                false => West switch {
                                    true => 3393,
                                    false => 3394,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3395,
                                    false => 3396,
                                },
                                false => West switch {
                                    true => 3397,
                                    false => 3398,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3399,
                                    false => 3400,
                                },
                                false => West switch {
                                    true => 3401,
                                    false => 3402,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3403,
                                    false => 3404,
                                },
                                false => West switch {
                                    true => 3405,
                                    false => 3406,
                                },
                            },
                        },
                    },
                },
                1 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3407,
                                    false => 3408,
                                },
                                false => West switch {
                                    true => 3409,
                                    false => 3410,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3411,
                                    false => 3412,
                                },
                                false => West switch {
                                    true => 3413,
                                    false => 3414,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3415,
                                    false => 3416,
                                },
                                false => West switch {
                                    true => 3417,
                                    false => 3418,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3419,
                                    false => 3420,
                                },
                                false => West switch {
                                    true => 3421,
                                    false => 3422,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3423,
                                    false => 3424,
                                },
                                false => West switch {
                                    true => 3425,
                                    false => 3426,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3427,
                                    false => 3428,
                                },
                                false => West switch {
                                    true => 3429,
                                    false => 3430,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3431,
                                    false => 3432,
                                },
                                false => West switch {
                                    true => 3433,
                                    false => 3434,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3435,
                                    false => 3436,
                                },
                                false => West switch {
                                    true => 3437,
                                    false => 3438,
                                },
                            },
                        },
                    },
                },
                2 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3439,
                                    false => 3440,
                                },
                                false => West switch {
                                    true => 3441,
                                    false => 3442,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3443,
                                    false => 3444,
                                },
                                false => West switch {
                                    true => 3445,
                                    false => 3446,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3447,
                                    false => 3448,
                                },
                                false => West switch {
                                    true => 3449,
                                    false => 3450,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3451,
                                    false => 3452,
                                },
                                false => West switch {
                                    true => 3453,
                                    false => 3454,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3455,
                                    false => 3456,
                                },
                                false => West switch {
                                    true => 3457,
                                    false => 3458,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3459,
                                    false => 3460,
                                },
                                false => West switch {
                                    true => 3461,
                                    false => 3462,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3463,
                                    false => 3464,
                                },
                                false => West switch {
                                    true => 3465,
                                    false => 3466,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3467,
                                    false => 3468,
                                },
                                false => West switch {
                                    true => 3469,
                                    false => 3470,
                                },
                            },
                        },
                    },
                },
                3 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3471,
                                    false => 3472,
                                },
                                false => West switch {
                                    true => 3473,
                                    false => 3474,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3475,
                                    false => 3476,
                                },
                                false => West switch {
                                    true => 3477,
                                    false => 3478,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3479,
                                    false => 3480,
                                },
                                false => West switch {
                                    true => 3481,
                                    false => 3482,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3483,
                                    false => 3484,
                                },
                                false => West switch {
                                    true => 3485,
                                    false => 3486,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3487,
                                    false => 3488,
                                },
                                false => West switch {
                                    true => 3489,
                                    false => 3490,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3491,
                                    false => 3492,
                                },
                                false => West switch {
                                    true => 3493,
                                    false => 3494,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3495,
                                    false => 3496,
                                },
                                false => West switch {
                                    true => 3497,
                                    false => 3498,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3499,
                                    false => 3500,
                                },
                                false => West switch {
                                    true => 3501,
                                    false => 3502,
                                },
                            },
                        },
                    },
                },
                4 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3503,
                                    false => 3504,
                                },
                                false => West switch {
                                    true => 3505,
                                    false => 3506,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3507,
                                    false => 3508,
                                },
                                false => West switch {
                                    true => 3509,
                                    false => 3510,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3511,
                                    false => 3512,
                                },
                                false => West switch {
                                    true => 3513,
                                    false => 3514,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3515,
                                    false => 3516,
                                },
                                false => West switch {
                                    true => 3517,
                                    false => 3518,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3519,
                                    false => 3520,
                                },
                                false => West switch {
                                    true => 3521,
                                    false => 3522,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3523,
                                    false => 3524,
                                },
                                false => West switch {
                                    true => 3525,
                                    false => 3526,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3527,
                                    false => 3528,
                                },
                                false => West switch {
                                    true => 3529,
                                    false => 3530,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3531,
                                    false => 3532,
                                },
                                false => West switch {
                                    true => 3533,
                                    false => 3534,
                                },
                            },
                        },
                    },
                },
                5 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3535,
                                    false => 3536,
                                },
                                false => West switch {
                                    true => 3537,
                                    false => 3538,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3539,
                                    false => 3540,
                                },
                                false => West switch {
                                    true => 3541,
                                    false => 3542,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3543,
                                    false => 3544,
                                },
                                false => West switch {
                                    true => 3545,
                                    false => 3546,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3547,
                                    false => 3548,
                                },
                                false => West switch {
                                    true => 3549,
                                    false => 3550,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3551,
                                    false => 3552,
                                },
                                false => West switch {
                                    true => 3553,
                                    false => 3554,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3555,
                                    false => 3556,
                                },
                                false => West switch {
                                    true => 3557,
                                    false => 3558,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3559,
                                    false => 3560,
                                },
                                false => West switch {
                                    true => 3561,
                                    false => 3562,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3563,
                                    false => 3564,
                                },
                                false => West switch {
                                    true => 3565,
                                    false => 3566,
                                },
                            },
                        },
                    },
                },
                6 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3567,
                                    false => 3568,
                                },
                                false => West switch {
                                    true => 3569,
                                    false => 3570,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3571,
                                    false => 3572,
                                },
                                false => West switch {
                                    true => 3573,
                                    false => 3574,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3575,
                                    false => 3576,
                                },
                                false => West switch {
                                    true => 3577,
                                    false => 3578,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3579,
                                    false => 3580,
                                },
                                false => West switch {
                                    true => 3581,
                                    false => 3582,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3583,
                                    false => 3584,
                                },
                                false => West switch {
                                    true => 3585,
                                    false => 3586,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3587,
                                    false => 3588,
                                },
                                false => West switch {
                                    true => 3589,
                                    false => 3590,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3591,
                                    false => 3592,
                                },
                                false => West switch {
                                    true => 3593,
                                    false => 3594,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3595,
                                    false => 3596,
                                },
                                false => West switch {
                                    true => 3597,
                                    false => 3598,
                                },
                            },
                        },
                    },
                },
                7 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3599,
                                    false => 3600,
                                },
                                false => West switch {
                                    true => 3601,
                                    false => 3602,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3603,
                                    false => 3604,
                                },
                                false => West switch {
                                    true => 3605,
                                    false => 3606,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3607,
                                    false => 3608,
                                },
                                false => West switch {
                                    true => 3609,
                                    false => 3610,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3611,
                                    false => 3612,
                                },
                                false => West switch {
                                    true => 3613,
                                    false => 3614,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3615,
                                    false => 3616,
                                },
                                false => West switch {
                                    true => 3617,
                                    false => 3618,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3619,
                                    false => 3620,
                                },
                                false => West switch {
                                    true => 3621,
                                    false => 3622,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3623,
                                    false => 3624,
                                },
                                false => West switch {
                                    true => 3625,
                                    false => 3626,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3627,
                                    false => 3628,
                                },
                                false => West switch {
                                    true => 3629,
                                    false => 3630,
                                },
                            },
                        },
                    },
                },
                8 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3631,
                                    false => 3632,
                                },
                                false => West switch {
                                    true => 3633,
                                    false => 3634,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3635,
                                    false => 3636,
                                },
                                false => West switch {
                                    true => 3637,
                                    false => 3638,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3639,
                                    false => 3640,
                                },
                                false => West switch {
                                    true => 3641,
                                    false => 3642,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3643,
                                    false => 3644,
                                },
                                false => West switch {
                                    true => 3645,
                                    false => 3646,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3647,
                                    false => 3648,
                                },
                                false => West switch {
                                    true => 3649,
                                    false => 3650,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3651,
                                    false => 3652,
                                },
                                false => West switch {
                                    true => 3653,
                                    false => 3654,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3655,
                                    false => 3656,
                                },
                                false => West switch {
                                    true => 3657,
                                    false => 3658,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3659,
                                    false => 3660,
                                },
                                false => West switch {
                                    true => 3661,
                                    false => 3662,
                                },
                            },
                        },
                    },
                },
                9 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3663,
                                    false => 3664,
                                },
                                false => West switch {
                                    true => 3665,
                                    false => 3666,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3667,
                                    false => 3668,
                                },
                                false => West switch {
                                    true => 3669,
                                    false => 3670,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3671,
                                    false => 3672,
                                },
                                false => West switch {
                                    true => 3673,
                                    false => 3674,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3675,
                                    false => 3676,
                                },
                                false => West switch {
                                    true => 3677,
                                    false => 3678,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3679,
                                    false => 3680,
                                },
                                false => West switch {
                                    true => 3681,
                                    false => 3682,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3683,
                                    false => 3684,
                                },
                                false => West switch {
                                    true => 3685,
                                    false => 3686,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3687,
                                    false => 3688,
                                },
                                false => West switch {
                                    true => 3689,
                                    false => 3690,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3691,
                                    false => 3692,
                                },
                                false => West switch {
                                    true => 3693,
                                    false => 3694,
                                },
                            },
                        },
                    },
                },
                10 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3695,
                                    false => 3696,
                                },
                                false => West switch {
                                    true => 3697,
                                    false => 3698,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3699,
                                    false => 3700,
                                },
                                false => West switch {
                                    true => 3701,
                                    false => 3702,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3703,
                                    false => 3704,
                                },
                                false => West switch {
                                    true => 3705,
                                    false => 3706,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3707,
                                    false => 3708,
                                },
                                false => West switch {
                                    true => 3709,
                                    false => 3710,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3711,
                                    false => 3712,
                                },
                                false => West switch {
                                    true => 3713,
                                    false => 3714,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3715,
                                    false => 3716,
                                },
                                false => West switch {
                                    true => 3717,
                                    false => 3718,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3719,
                                    false => 3720,
                                },
                                false => West switch {
                                    true => 3721,
                                    false => 3722,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3723,
                                    false => 3724,
                                },
                                false => West switch {
                                    true => 3725,
                                    false => 3726,
                                },
                            },
                        },
                    },
                },
                11 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3727,
                                    false => 3728,
                                },
                                false => West switch {
                                    true => 3729,
                                    false => 3730,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3731,
                                    false => 3732,
                                },
                                false => West switch {
                                    true => 3733,
                                    false => 3734,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3735,
                                    false => 3736,
                                },
                                false => West switch {
                                    true => 3737,
                                    false => 3738,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3739,
                                    false => 3740,
                                },
                                false => West switch {
                                    true => 3741,
                                    false => 3742,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3743,
                                    false => 3744,
                                },
                                false => West switch {
                                    true => 3745,
                                    false => 3746,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3747,
                                    false => 3748,
                                },
                                false => West switch {
                                    true => 3749,
                                    false => 3750,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3751,
                                    false => 3752,
                                },
                                false => West switch {
                                    true => 3753,
                                    false => 3754,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3755,
                                    false => 3756,
                                },
                                false => West switch {
                                    true => 3757,
                                    false => 3758,
                                },
                            },
                        },
                    },
                },
                12 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3759,
                                    false => 3760,
                                },
                                false => West switch {
                                    true => 3761,
                                    false => 3762,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3763,
                                    false => 3764,
                                },
                                false => West switch {
                                    true => 3765,
                                    false => 3766,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3767,
                                    false => 3768,
                                },
                                false => West switch {
                                    true => 3769,
                                    false => 3770,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3771,
                                    false => 3772,
                                },
                                false => West switch {
                                    true => 3773,
                                    false => 3774,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3775,
                                    false => 3776,
                                },
                                false => West switch {
                                    true => 3777,
                                    false => 3778,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3779,
                                    false => 3780,
                                },
                                false => West switch {
                                    true => 3781,
                                    false => 3782,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3783,
                                    false => 3784,
                                },
                                false => West switch {
                                    true => 3785,
                                    false => 3786,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3787,
                                    false => 3788,
                                },
                                false => West switch {
                                    true => 3789,
                                    false => 3790,
                                },
                            },
                        },
                    },
                },
                13 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3791,
                                    false => 3792,
                                },
                                false => West switch {
                                    true => 3793,
                                    false => 3794,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3795,
                                    false => 3796,
                                },
                                false => West switch {
                                    true => 3797,
                                    false => 3798,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3799,
                                    false => 3800,
                                },
                                false => West switch {
                                    true => 3801,
                                    false => 3802,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3803,
                                    false => 3804,
                                },
                                false => West switch {
                                    true => 3805,
                                    false => 3806,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3807,
                                    false => 3808,
                                },
                                false => West switch {
                                    true => 3809,
                                    false => 3810,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3811,
                                    false => 3812,
                                },
                                false => West switch {
                                    true => 3813,
                                    false => 3814,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3815,
                                    false => 3816,
                                },
                                false => West switch {
                                    true => 3817,
                                    false => 3818,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3819,
                                    false => 3820,
                                },
                                false => West switch {
                                    true => 3821,
                                    false => 3822,
                                },
                            },
                        },
                    },
                },
                14 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3823,
                                    false => 3824,
                                },
                                false => West switch {
                                    true => 3825,
                                    false => 3826,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3827,
                                    false => 3828,
                                },
                                false => West switch {
                                    true => 3829,
                                    false => 3830,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3831,
                                    false => 3832,
                                },
                                false => West switch {
                                    true => 3833,
                                    false => 3834,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3835,
                                    false => 3836,
                                },
                                false => West switch {
                                    true => 3837,
                                    false => 3838,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3839,
                                    false => 3840,
                                },
                                false => West switch {
                                    true => 3841,
                                    false => 3842,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3843,
                                    false => 3844,
                                },
                                false => West switch {
                                    true => 3845,
                                    false => 3846,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3847,
                                    false => 3848,
                                },
                                false => West switch {
                                    true => 3849,
                                    false => 3850,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3851,
                                    false => 3852,
                                },
                                false => West switch {
                                    true => 3853,
                                    false => 3854,
                                },
                            },
                        },
                    },
                },
                15 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3855,
                                    false => 3856,
                                },
                                false => West switch {
                                    true => 3857,
                                    false => 3858,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3859,
                                    false => 3860,
                                },
                                false => West switch {
                                    true => 3861,
                                    false => 3862,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3863,
                                    false => 3864,
                                },
                                false => West switch {
                                    true => 3865,
                                    false => 3866,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3867,
                                    false => 3868,
                                },
                                false => West switch {
                                    true => 3869,
                                    false => 3870,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3871,
                                    false => 3872,
                                },
                                false => West switch {
                                    true => 3873,
                                    false => 3874,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3875,
                                    false => 3876,
                                },
                                false => West switch {
                                    true => 3877,
                                    false => 3878,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3879,
                                    false => 3880,
                                },
                                false => West switch {
                                    true => 3881,
                                    false => 3882,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3883,
                                    false => 3884,
                                },
                                false => West switch {
                                    true => 3885,
                                    false => 3886,
                                },
                            },
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3375 => new FireBlock(Identifier, 0, true, true, true, true, true),
            3376 => new FireBlock(Identifier, 0, true, true, true, true, false),
            3377 => new FireBlock(Identifier, 0, true, true, true, false, true),
            3378 => new FireBlock(Identifier, 0, true, true, true, false, false),
            3379 => new FireBlock(Identifier, 0, true, true, false, true, true),
            3380 => new FireBlock(Identifier, 0, true, true, false, true, false),
            3381 => new FireBlock(Identifier, 0, true, true, false, false, true),
            3382 => new FireBlock(Identifier, 0, true, true, false, false, false),
            3383 => new FireBlock(Identifier, 0, true, false, true, true, true),
            3384 => new FireBlock(Identifier, 0, true, false, true, true, false),
            3385 => new FireBlock(Identifier, 0, true, false, true, false, true),
            3386 => new FireBlock(Identifier, 0, true, false, true, false, false),
            3387 => new FireBlock(Identifier, 0, true, false, false, true, true),
            3388 => new FireBlock(Identifier, 0, true, false, false, true, false),
            3389 => new FireBlock(Identifier, 0, true, false, false, false, true),
            3390 => new FireBlock(Identifier, 0, true, false, false, false, false),
            3391 => new FireBlock(Identifier, 0, false, true, true, true, true),
            3392 => new FireBlock(Identifier, 0, false, true, true, true, false),
            3393 => new FireBlock(Identifier, 0, false, true, true, false, true),
            3394 => new FireBlock(Identifier, 0, false, true, true, false, false),
            3395 => new FireBlock(Identifier, 0, false, true, false, true, true),
            3396 => new FireBlock(Identifier, 0, false, true, false, true, false),
            3397 => new FireBlock(Identifier, 0, false, true, false, false, true),
            3398 => new FireBlock(Identifier, 0, false, true, false, false, false),
            3399 => new FireBlock(Identifier, 0, false, false, true, true, true),
            3400 => new FireBlock(Identifier, 0, false, false, true, true, false),
            3401 => new FireBlock(Identifier, 0, false, false, true, false, true),
            3402 => new FireBlock(Identifier, 0, false, false, true, false, false),
            3403 => new FireBlock(Identifier, 0, false, false, false, true, true),
            3404 => new FireBlock(Identifier, 0, false, false, false, true, false),
            3405 => new FireBlock(Identifier, 0, false, false, false, false, true),
            3406 => new FireBlock(Identifier, 0, false, false, false, false, false),
            3407 => new FireBlock(Identifier, 1, true, true, true, true, true),
            3408 => new FireBlock(Identifier, 1, true, true, true, true, false),
            3409 => new FireBlock(Identifier, 1, true, true, true, false, true),
            3410 => new FireBlock(Identifier, 1, true, true, true, false, false),
            3411 => new FireBlock(Identifier, 1, true, true, false, true, true),
            3412 => new FireBlock(Identifier, 1, true, true, false, true, false),
            3413 => new FireBlock(Identifier, 1, true, true, false, false, true),
            3414 => new FireBlock(Identifier, 1, true, true, false, false, false),
            3415 => new FireBlock(Identifier, 1, true, false, true, true, true),
            3416 => new FireBlock(Identifier, 1, true, false, true, true, false),
            3417 => new FireBlock(Identifier, 1, true, false, true, false, true),
            3418 => new FireBlock(Identifier, 1, true, false, true, false, false),
            3419 => new FireBlock(Identifier, 1, true, false, false, true, true),
            3420 => new FireBlock(Identifier, 1, true, false, false, true, false),
            3421 => new FireBlock(Identifier, 1, true, false, false, false, true),
            3422 => new FireBlock(Identifier, 1, true, false, false, false, false),
            3423 => new FireBlock(Identifier, 1, false, true, true, true, true),
            3424 => new FireBlock(Identifier, 1, false, true, true, true, false),
            3425 => new FireBlock(Identifier, 1, false, true, true, false, true),
            3426 => new FireBlock(Identifier, 1, false, true, true, false, false),
            3427 => new FireBlock(Identifier, 1, false, true, false, true, true),
            3428 => new FireBlock(Identifier, 1, false, true, false, true, false),
            3429 => new FireBlock(Identifier, 1, false, true, false, false, true),
            3430 => new FireBlock(Identifier, 1, false, true, false, false, false),
            3431 => new FireBlock(Identifier, 1, false, false, true, true, true),
            3432 => new FireBlock(Identifier, 1, false, false, true, true, false),
            3433 => new FireBlock(Identifier, 1, false, false, true, false, true),
            3434 => new FireBlock(Identifier, 1, false, false, true, false, false),
            3435 => new FireBlock(Identifier, 1, false, false, false, true, true),
            3436 => new FireBlock(Identifier, 1, false, false, false, true, false),
            3437 => new FireBlock(Identifier, 1, false, false, false, false, true),
            3438 => new FireBlock(Identifier, 1, false, false, false, false, false),
            3439 => new FireBlock(Identifier, 2, true, true, true, true, true),
            3440 => new FireBlock(Identifier, 2, true, true, true, true, false),
            3441 => new FireBlock(Identifier, 2, true, true, true, false, true),
            3442 => new FireBlock(Identifier, 2, true, true, true, false, false),
            3443 => new FireBlock(Identifier, 2, true, true, false, true, true),
            3444 => new FireBlock(Identifier, 2, true, true, false, true, false),
            3445 => new FireBlock(Identifier, 2, true, true, false, false, true),
            3446 => new FireBlock(Identifier, 2, true, true, false, false, false),
            3447 => new FireBlock(Identifier, 2, true, false, true, true, true),
            3448 => new FireBlock(Identifier, 2, true, false, true, true, false),
            3449 => new FireBlock(Identifier, 2, true, false, true, false, true),
            3450 => new FireBlock(Identifier, 2, true, false, true, false, false),
            3451 => new FireBlock(Identifier, 2, true, false, false, true, true),
            3452 => new FireBlock(Identifier, 2, true, false, false, true, false),
            3453 => new FireBlock(Identifier, 2, true, false, false, false, true),
            3454 => new FireBlock(Identifier, 2, true, false, false, false, false),
            3455 => new FireBlock(Identifier, 2, false, true, true, true, true),
            3456 => new FireBlock(Identifier, 2, false, true, true, true, false),
            3457 => new FireBlock(Identifier, 2, false, true, true, false, true),
            3458 => new FireBlock(Identifier, 2, false, true, true, false, false),
            3459 => new FireBlock(Identifier, 2, false, true, false, true, true),
            3460 => new FireBlock(Identifier, 2, false, true, false, true, false),
            3461 => new FireBlock(Identifier, 2, false, true, false, false, true),
            3462 => new FireBlock(Identifier, 2, false, true, false, false, false),
            3463 => new FireBlock(Identifier, 2, false, false, true, true, true),
            3464 => new FireBlock(Identifier, 2, false, false, true, true, false),
            3465 => new FireBlock(Identifier, 2, false, false, true, false, true),
            3466 => new FireBlock(Identifier, 2, false, false, true, false, false),
            3467 => new FireBlock(Identifier, 2, false, false, false, true, true),
            3468 => new FireBlock(Identifier, 2, false, false, false, true, false),
            3469 => new FireBlock(Identifier, 2, false, false, false, false, true),
            3470 => new FireBlock(Identifier, 2, false, false, false, false, false),
            3471 => new FireBlock(Identifier, 3, true, true, true, true, true),
            3472 => new FireBlock(Identifier, 3, true, true, true, true, false),
            3473 => new FireBlock(Identifier, 3, true, true, true, false, true),
            3474 => new FireBlock(Identifier, 3, true, true, true, false, false),
            3475 => new FireBlock(Identifier, 3, true, true, false, true, true),
            3476 => new FireBlock(Identifier, 3, true, true, false, true, false),
            3477 => new FireBlock(Identifier, 3, true, true, false, false, true),
            3478 => new FireBlock(Identifier, 3, true, true, false, false, false),
            3479 => new FireBlock(Identifier, 3, true, false, true, true, true),
            3480 => new FireBlock(Identifier, 3, true, false, true, true, false),
            3481 => new FireBlock(Identifier, 3, true, false, true, false, true),
            3482 => new FireBlock(Identifier, 3, true, false, true, false, false),
            3483 => new FireBlock(Identifier, 3, true, false, false, true, true),
            3484 => new FireBlock(Identifier, 3, true, false, false, true, false),
            3485 => new FireBlock(Identifier, 3, true, false, false, false, true),
            3486 => new FireBlock(Identifier, 3, true, false, false, false, false),
            3487 => new FireBlock(Identifier, 3, false, true, true, true, true),
            3488 => new FireBlock(Identifier, 3, false, true, true, true, false),
            3489 => new FireBlock(Identifier, 3, false, true, true, false, true),
            3490 => new FireBlock(Identifier, 3, false, true, true, false, false),
            3491 => new FireBlock(Identifier, 3, false, true, false, true, true),
            3492 => new FireBlock(Identifier, 3, false, true, false, true, false),
            3493 => new FireBlock(Identifier, 3, false, true, false, false, true),
            3494 => new FireBlock(Identifier, 3, false, true, false, false, false),
            3495 => new FireBlock(Identifier, 3, false, false, true, true, true),
            3496 => new FireBlock(Identifier, 3, false, false, true, true, false),
            3497 => new FireBlock(Identifier, 3, false, false, true, false, true),
            3498 => new FireBlock(Identifier, 3, false, false, true, false, false),
            3499 => new FireBlock(Identifier, 3, false, false, false, true, true),
            3500 => new FireBlock(Identifier, 3, false, false, false, true, false),
            3501 => new FireBlock(Identifier, 3, false, false, false, false, true),
            3502 => new FireBlock(Identifier, 3, false, false, false, false, false),
            3503 => new FireBlock(Identifier, 4, true, true, true, true, true),
            3504 => new FireBlock(Identifier, 4, true, true, true, true, false),
            3505 => new FireBlock(Identifier, 4, true, true, true, false, true),
            3506 => new FireBlock(Identifier, 4, true, true, true, false, false),
            3507 => new FireBlock(Identifier, 4, true, true, false, true, true),
            3508 => new FireBlock(Identifier, 4, true, true, false, true, false),
            3509 => new FireBlock(Identifier, 4, true, true, false, false, true),
            3510 => new FireBlock(Identifier, 4, true, true, false, false, false),
            3511 => new FireBlock(Identifier, 4, true, false, true, true, true),
            3512 => new FireBlock(Identifier, 4, true, false, true, true, false),
            3513 => new FireBlock(Identifier, 4, true, false, true, false, true),
            3514 => new FireBlock(Identifier, 4, true, false, true, false, false),
            3515 => new FireBlock(Identifier, 4, true, false, false, true, true),
            3516 => new FireBlock(Identifier, 4, true, false, false, true, false),
            3517 => new FireBlock(Identifier, 4, true, false, false, false, true),
            3518 => new FireBlock(Identifier, 4, true, false, false, false, false),
            3519 => new FireBlock(Identifier, 4, false, true, true, true, true),
            3520 => new FireBlock(Identifier, 4, false, true, true, true, false),
            3521 => new FireBlock(Identifier, 4, false, true, true, false, true),
            3522 => new FireBlock(Identifier, 4, false, true, true, false, false),
            3523 => new FireBlock(Identifier, 4, false, true, false, true, true),
            3524 => new FireBlock(Identifier, 4, false, true, false, true, false),
            3525 => new FireBlock(Identifier, 4, false, true, false, false, true),
            3526 => new FireBlock(Identifier, 4, false, true, false, false, false),
            3527 => new FireBlock(Identifier, 4, false, false, true, true, true),
            3528 => new FireBlock(Identifier, 4, false, false, true, true, false),
            3529 => new FireBlock(Identifier, 4, false, false, true, false, true),
            3530 => new FireBlock(Identifier, 4, false, false, true, false, false),
            3531 => new FireBlock(Identifier, 4, false, false, false, true, true),
            3532 => new FireBlock(Identifier, 4, false, false, false, true, false),
            3533 => new FireBlock(Identifier, 4, false, false, false, false, true),
            3534 => new FireBlock(Identifier, 4, false, false, false, false, false),
            3535 => new FireBlock(Identifier, 5, true, true, true, true, true),
            3536 => new FireBlock(Identifier, 5, true, true, true, true, false),
            3537 => new FireBlock(Identifier, 5, true, true, true, false, true),
            3538 => new FireBlock(Identifier, 5, true, true, true, false, false),
            3539 => new FireBlock(Identifier, 5, true, true, false, true, true),
            3540 => new FireBlock(Identifier, 5, true, true, false, true, false),
            3541 => new FireBlock(Identifier, 5, true, true, false, false, true),
            3542 => new FireBlock(Identifier, 5, true, true, false, false, false),
            3543 => new FireBlock(Identifier, 5, true, false, true, true, true),
            3544 => new FireBlock(Identifier, 5, true, false, true, true, false),
            3545 => new FireBlock(Identifier, 5, true, false, true, false, true),
            3546 => new FireBlock(Identifier, 5, true, false, true, false, false),
            3547 => new FireBlock(Identifier, 5, true, false, false, true, true),
            3548 => new FireBlock(Identifier, 5, true, false, false, true, false),
            3549 => new FireBlock(Identifier, 5, true, false, false, false, true),
            3550 => new FireBlock(Identifier, 5, true, false, false, false, false),
            3551 => new FireBlock(Identifier, 5, false, true, true, true, true),
            3552 => new FireBlock(Identifier, 5, false, true, true, true, false),
            3553 => new FireBlock(Identifier, 5, false, true, true, false, true),
            3554 => new FireBlock(Identifier, 5, false, true, true, false, false),
            3555 => new FireBlock(Identifier, 5, false, true, false, true, true),
            3556 => new FireBlock(Identifier, 5, false, true, false, true, false),
            3557 => new FireBlock(Identifier, 5, false, true, false, false, true),
            3558 => new FireBlock(Identifier, 5, false, true, false, false, false),
            3559 => new FireBlock(Identifier, 5, false, false, true, true, true),
            3560 => new FireBlock(Identifier, 5, false, false, true, true, false),
            3561 => new FireBlock(Identifier, 5, false, false, true, false, true),
            3562 => new FireBlock(Identifier, 5, false, false, true, false, false),
            3563 => new FireBlock(Identifier, 5, false, false, false, true, true),
            3564 => new FireBlock(Identifier, 5, false, false, false, true, false),
            3565 => new FireBlock(Identifier, 5, false, false, false, false, true),
            3566 => new FireBlock(Identifier, 5, false, false, false, false, false),
            3567 => new FireBlock(Identifier, 6, true, true, true, true, true),
            3568 => new FireBlock(Identifier, 6, true, true, true, true, false),
            3569 => new FireBlock(Identifier, 6, true, true, true, false, true),
            3570 => new FireBlock(Identifier, 6, true, true, true, false, false),
            3571 => new FireBlock(Identifier, 6, true, true, false, true, true),
            3572 => new FireBlock(Identifier, 6, true, true, false, true, false),
            3573 => new FireBlock(Identifier, 6, true, true, false, false, true),
            3574 => new FireBlock(Identifier, 6, true, true, false, false, false),
            3575 => new FireBlock(Identifier, 6, true, false, true, true, true),
            3576 => new FireBlock(Identifier, 6, true, false, true, true, false),
            3577 => new FireBlock(Identifier, 6, true, false, true, false, true),
            3578 => new FireBlock(Identifier, 6, true, false, true, false, false),
            3579 => new FireBlock(Identifier, 6, true, false, false, true, true),
            3580 => new FireBlock(Identifier, 6, true, false, false, true, false),
            3581 => new FireBlock(Identifier, 6, true, false, false, false, true),
            3582 => new FireBlock(Identifier, 6, true, false, false, false, false),
            3583 => new FireBlock(Identifier, 6, false, true, true, true, true),
            3584 => new FireBlock(Identifier, 6, false, true, true, true, false),
            3585 => new FireBlock(Identifier, 6, false, true, true, false, true),
            3586 => new FireBlock(Identifier, 6, false, true, true, false, false),
            3587 => new FireBlock(Identifier, 6, false, true, false, true, true),
            3588 => new FireBlock(Identifier, 6, false, true, false, true, false),
            3589 => new FireBlock(Identifier, 6, false, true, false, false, true),
            3590 => new FireBlock(Identifier, 6, false, true, false, false, false),
            3591 => new FireBlock(Identifier, 6, false, false, true, true, true),
            3592 => new FireBlock(Identifier, 6, false, false, true, true, false),
            3593 => new FireBlock(Identifier, 6, false, false, true, false, true),
            3594 => new FireBlock(Identifier, 6, false, false, true, false, false),
            3595 => new FireBlock(Identifier, 6, false, false, false, true, true),
            3596 => new FireBlock(Identifier, 6, false, false, false, true, false),
            3597 => new FireBlock(Identifier, 6, false, false, false, false, true),
            3598 => new FireBlock(Identifier, 6, false, false, false, false, false),
            3599 => new FireBlock(Identifier, 7, true, true, true, true, true),
            3600 => new FireBlock(Identifier, 7, true, true, true, true, false),
            3601 => new FireBlock(Identifier, 7, true, true, true, false, true),
            3602 => new FireBlock(Identifier, 7, true, true, true, false, false),
            3603 => new FireBlock(Identifier, 7, true, true, false, true, true),
            3604 => new FireBlock(Identifier, 7, true, true, false, true, false),
            3605 => new FireBlock(Identifier, 7, true, true, false, false, true),
            3606 => new FireBlock(Identifier, 7, true, true, false, false, false),
            3607 => new FireBlock(Identifier, 7, true, false, true, true, true),
            3608 => new FireBlock(Identifier, 7, true, false, true, true, false),
            3609 => new FireBlock(Identifier, 7, true, false, true, false, true),
            3610 => new FireBlock(Identifier, 7, true, false, true, false, false),
            3611 => new FireBlock(Identifier, 7, true, false, false, true, true),
            3612 => new FireBlock(Identifier, 7, true, false, false, true, false),
            3613 => new FireBlock(Identifier, 7, true, false, false, false, true),
            3614 => new FireBlock(Identifier, 7, true, false, false, false, false),
            3615 => new FireBlock(Identifier, 7, false, true, true, true, true),
            3616 => new FireBlock(Identifier, 7, false, true, true, true, false),
            3617 => new FireBlock(Identifier, 7, false, true, true, false, true),
            3618 => new FireBlock(Identifier, 7, false, true, true, false, false),
            3619 => new FireBlock(Identifier, 7, false, true, false, true, true),
            3620 => new FireBlock(Identifier, 7, false, true, false, true, false),
            3621 => new FireBlock(Identifier, 7, false, true, false, false, true),
            3622 => new FireBlock(Identifier, 7, false, true, false, false, false),
            3623 => new FireBlock(Identifier, 7, false, false, true, true, true),
            3624 => new FireBlock(Identifier, 7, false, false, true, true, false),
            3625 => new FireBlock(Identifier, 7, false, false, true, false, true),
            3626 => new FireBlock(Identifier, 7, false, false, true, false, false),
            3627 => new FireBlock(Identifier, 7, false, false, false, true, true),
            3628 => new FireBlock(Identifier, 7, false, false, false, true, false),
            3629 => new FireBlock(Identifier, 7, false, false, false, false, true),
            3630 => new FireBlock(Identifier, 7, false, false, false, false, false),
            3631 => new FireBlock(Identifier, 8, true, true, true, true, true),
            3632 => new FireBlock(Identifier, 8, true, true, true, true, false),
            3633 => new FireBlock(Identifier, 8, true, true, true, false, true),
            3634 => new FireBlock(Identifier, 8, true, true, true, false, false),
            3635 => new FireBlock(Identifier, 8, true, true, false, true, true),
            3636 => new FireBlock(Identifier, 8, true, true, false, true, false),
            3637 => new FireBlock(Identifier, 8, true, true, false, false, true),
            3638 => new FireBlock(Identifier, 8, true, true, false, false, false),
            3639 => new FireBlock(Identifier, 8, true, false, true, true, true),
            3640 => new FireBlock(Identifier, 8, true, false, true, true, false),
            3641 => new FireBlock(Identifier, 8, true, false, true, false, true),
            3642 => new FireBlock(Identifier, 8, true, false, true, false, false),
            3643 => new FireBlock(Identifier, 8, true, false, false, true, true),
            3644 => new FireBlock(Identifier, 8, true, false, false, true, false),
            3645 => new FireBlock(Identifier, 8, true, false, false, false, true),
            3646 => new FireBlock(Identifier, 8, true, false, false, false, false),
            3647 => new FireBlock(Identifier, 8, false, true, true, true, true),
            3648 => new FireBlock(Identifier, 8, false, true, true, true, false),
            3649 => new FireBlock(Identifier, 8, false, true, true, false, true),
            3650 => new FireBlock(Identifier, 8, false, true, true, false, false),
            3651 => new FireBlock(Identifier, 8, false, true, false, true, true),
            3652 => new FireBlock(Identifier, 8, false, true, false, true, false),
            3653 => new FireBlock(Identifier, 8, false, true, false, false, true),
            3654 => new FireBlock(Identifier, 8, false, true, false, false, false),
            3655 => new FireBlock(Identifier, 8, false, false, true, true, true),
            3656 => new FireBlock(Identifier, 8, false, false, true, true, false),
            3657 => new FireBlock(Identifier, 8, false, false, true, false, true),
            3658 => new FireBlock(Identifier, 8, false, false, true, false, false),
            3659 => new FireBlock(Identifier, 8, false, false, false, true, true),
            3660 => new FireBlock(Identifier, 8, false, false, false, true, false),
            3661 => new FireBlock(Identifier, 8, false, false, false, false, true),
            3662 => new FireBlock(Identifier, 8, false, false, false, false, false),
            3663 => new FireBlock(Identifier, 9, true, true, true, true, true),
            3664 => new FireBlock(Identifier, 9, true, true, true, true, false),
            3665 => new FireBlock(Identifier, 9, true, true, true, false, true),
            3666 => new FireBlock(Identifier, 9, true, true, true, false, false),
            3667 => new FireBlock(Identifier, 9, true, true, false, true, true),
            3668 => new FireBlock(Identifier, 9, true, true, false, true, false),
            3669 => new FireBlock(Identifier, 9, true, true, false, false, true),
            3670 => new FireBlock(Identifier, 9, true, true, false, false, false),
            3671 => new FireBlock(Identifier, 9, true, false, true, true, true),
            3672 => new FireBlock(Identifier, 9, true, false, true, true, false),
            3673 => new FireBlock(Identifier, 9, true, false, true, false, true),
            3674 => new FireBlock(Identifier, 9, true, false, true, false, false),
            3675 => new FireBlock(Identifier, 9, true, false, false, true, true),
            3676 => new FireBlock(Identifier, 9, true, false, false, true, false),
            3677 => new FireBlock(Identifier, 9, true, false, false, false, true),
            3678 => new FireBlock(Identifier, 9, true, false, false, false, false),
            3679 => new FireBlock(Identifier, 9, false, true, true, true, true),
            3680 => new FireBlock(Identifier, 9, false, true, true, true, false),
            3681 => new FireBlock(Identifier, 9, false, true, true, false, true),
            3682 => new FireBlock(Identifier, 9, false, true, true, false, false),
            3683 => new FireBlock(Identifier, 9, false, true, false, true, true),
            3684 => new FireBlock(Identifier, 9, false, true, false, true, false),
            3685 => new FireBlock(Identifier, 9, false, true, false, false, true),
            3686 => new FireBlock(Identifier, 9, false, true, false, false, false),
            3687 => new FireBlock(Identifier, 9, false, false, true, true, true),
            3688 => new FireBlock(Identifier, 9, false, false, true, true, false),
            3689 => new FireBlock(Identifier, 9, false, false, true, false, true),
            3690 => new FireBlock(Identifier, 9, false, false, true, false, false),
            3691 => new FireBlock(Identifier, 9, false, false, false, true, true),
            3692 => new FireBlock(Identifier, 9, false, false, false, true, false),
            3693 => new FireBlock(Identifier, 9, false, false, false, false, true),
            3694 => new FireBlock(Identifier, 9, false, false, false, false, false),
            3695 => new FireBlock(Identifier, 10, true, true, true, true, true),
            3696 => new FireBlock(Identifier, 10, true, true, true, true, false),
            3697 => new FireBlock(Identifier, 10, true, true, true, false, true),
            3698 => new FireBlock(Identifier, 10, true, true, true, false, false),
            3699 => new FireBlock(Identifier, 10, true, true, false, true, true),
            3700 => new FireBlock(Identifier, 10, true, true, false, true, false),
            3701 => new FireBlock(Identifier, 10, true, true, false, false, true),
            3702 => new FireBlock(Identifier, 10, true, true, false, false, false),
            3703 => new FireBlock(Identifier, 10, true, false, true, true, true),
            3704 => new FireBlock(Identifier, 10, true, false, true, true, false),
            3705 => new FireBlock(Identifier, 10, true, false, true, false, true),
            3706 => new FireBlock(Identifier, 10, true, false, true, false, false),
            3707 => new FireBlock(Identifier, 10, true, false, false, true, true),
            3708 => new FireBlock(Identifier, 10, true, false, false, true, false),
            3709 => new FireBlock(Identifier, 10, true, false, false, false, true),
            3710 => new FireBlock(Identifier, 10, true, false, false, false, false),
            3711 => new FireBlock(Identifier, 10, false, true, true, true, true),
            3712 => new FireBlock(Identifier, 10, false, true, true, true, false),
            3713 => new FireBlock(Identifier, 10, false, true, true, false, true),
            3714 => new FireBlock(Identifier, 10, false, true, true, false, false),
            3715 => new FireBlock(Identifier, 10, false, true, false, true, true),
            3716 => new FireBlock(Identifier, 10, false, true, false, true, false),
            3717 => new FireBlock(Identifier, 10, false, true, false, false, true),
            3718 => new FireBlock(Identifier, 10, false, true, false, false, false),
            3719 => new FireBlock(Identifier, 10, false, false, true, true, true),
            3720 => new FireBlock(Identifier, 10, false, false, true, true, false),
            3721 => new FireBlock(Identifier, 10, false, false, true, false, true),
            3722 => new FireBlock(Identifier, 10, false, false, true, false, false),
            3723 => new FireBlock(Identifier, 10, false, false, false, true, true),
            3724 => new FireBlock(Identifier, 10, false, false, false, true, false),
            3725 => new FireBlock(Identifier, 10, false, false, false, false, true),
            3726 => new FireBlock(Identifier, 10, false, false, false, false, false),
            3727 => new FireBlock(Identifier, 11, true, true, true, true, true),
            3728 => new FireBlock(Identifier, 11, true, true, true, true, false),
            3729 => new FireBlock(Identifier, 11, true, true, true, false, true),
            3730 => new FireBlock(Identifier, 11, true, true, true, false, false),
            3731 => new FireBlock(Identifier, 11, true, true, false, true, true),
            3732 => new FireBlock(Identifier, 11, true, true, false, true, false),
            3733 => new FireBlock(Identifier, 11, true, true, false, false, true),
            3734 => new FireBlock(Identifier, 11, true, true, false, false, false),
            3735 => new FireBlock(Identifier, 11, true, false, true, true, true),
            3736 => new FireBlock(Identifier, 11, true, false, true, true, false),
            3737 => new FireBlock(Identifier, 11, true, false, true, false, true),
            3738 => new FireBlock(Identifier, 11, true, false, true, false, false),
            3739 => new FireBlock(Identifier, 11, true, false, false, true, true),
            3740 => new FireBlock(Identifier, 11, true, false, false, true, false),
            3741 => new FireBlock(Identifier, 11, true, false, false, false, true),
            3742 => new FireBlock(Identifier, 11, true, false, false, false, false),
            3743 => new FireBlock(Identifier, 11, false, true, true, true, true),
            3744 => new FireBlock(Identifier, 11, false, true, true, true, false),
            3745 => new FireBlock(Identifier, 11, false, true, true, false, true),
            3746 => new FireBlock(Identifier, 11, false, true, true, false, false),
            3747 => new FireBlock(Identifier, 11, false, true, false, true, true),
            3748 => new FireBlock(Identifier, 11, false, true, false, true, false),
            3749 => new FireBlock(Identifier, 11, false, true, false, false, true),
            3750 => new FireBlock(Identifier, 11, false, true, false, false, false),
            3751 => new FireBlock(Identifier, 11, false, false, true, true, true),
            3752 => new FireBlock(Identifier, 11, false, false, true, true, false),
            3753 => new FireBlock(Identifier, 11, false, false, true, false, true),
            3754 => new FireBlock(Identifier, 11, false, false, true, false, false),
            3755 => new FireBlock(Identifier, 11, false, false, false, true, true),
            3756 => new FireBlock(Identifier, 11, false, false, false, true, false),
            3757 => new FireBlock(Identifier, 11, false, false, false, false, true),
            3758 => new FireBlock(Identifier, 11, false, false, false, false, false),
            3759 => new FireBlock(Identifier, 12, true, true, true, true, true),
            3760 => new FireBlock(Identifier, 12, true, true, true, true, false),
            3761 => new FireBlock(Identifier, 12, true, true, true, false, true),
            3762 => new FireBlock(Identifier, 12, true, true, true, false, false),
            3763 => new FireBlock(Identifier, 12, true, true, false, true, true),
            3764 => new FireBlock(Identifier, 12, true, true, false, true, false),
            3765 => new FireBlock(Identifier, 12, true, true, false, false, true),
            3766 => new FireBlock(Identifier, 12, true, true, false, false, false),
            3767 => new FireBlock(Identifier, 12, true, false, true, true, true),
            3768 => new FireBlock(Identifier, 12, true, false, true, true, false),
            3769 => new FireBlock(Identifier, 12, true, false, true, false, true),
            3770 => new FireBlock(Identifier, 12, true, false, true, false, false),
            3771 => new FireBlock(Identifier, 12, true, false, false, true, true),
            3772 => new FireBlock(Identifier, 12, true, false, false, true, false),
            3773 => new FireBlock(Identifier, 12, true, false, false, false, true),
            3774 => new FireBlock(Identifier, 12, true, false, false, false, false),
            3775 => new FireBlock(Identifier, 12, false, true, true, true, true),
            3776 => new FireBlock(Identifier, 12, false, true, true, true, false),
            3777 => new FireBlock(Identifier, 12, false, true, true, false, true),
            3778 => new FireBlock(Identifier, 12, false, true, true, false, false),
            3779 => new FireBlock(Identifier, 12, false, true, false, true, true),
            3780 => new FireBlock(Identifier, 12, false, true, false, true, false),
            3781 => new FireBlock(Identifier, 12, false, true, false, false, true),
            3782 => new FireBlock(Identifier, 12, false, true, false, false, false),
            3783 => new FireBlock(Identifier, 12, false, false, true, true, true),
            3784 => new FireBlock(Identifier, 12, false, false, true, true, false),
            3785 => new FireBlock(Identifier, 12, false, false, true, false, true),
            3786 => new FireBlock(Identifier, 12, false, false, true, false, false),
            3787 => new FireBlock(Identifier, 12, false, false, false, true, true),
            3788 => new FireBlock(Identifier, 12, false, false, false, true, false),
            3789 => new FireBlock(Identifier, 12, false, false, false, false, true),
            3790 => new FireBlock(Identifier, 12, false, false, false, false, false),
            3791 => new FireBlock(Identifier, 13, true, true, true, true, true),
            3792 => new FireBlock(Identifier, 13, true, true, true, true, false),
            3793 => new FireBlock(Identifier, 13, true, true, true, false, true),
            3794 => new FireBlock(Identifier, 13, true, true, true, false, false),
            3795 => new FireBlock(Identifier, 13, true, true, false, true, true),
            3796 => new FireBlock(Identifier, 13, true, true, false, true, false),
            3797 => new FireBlock(Identifier, 13, true, true, false, false, true),
            3798 => new FireBlock(Identifier, 13, true, true, false, false, false),
            3799 => new FireBlock(Identifier, 13, true, false, true, true, true),
            3800 => new FireBlock(Identifier, 13, true, false, true, true, false),
            3801 => new FireBlock(Identifier, 13, true, false, true, false, true),
            3802 => new FireBlock(Identifier, 13, true, false, true, false, false),
            3803 => new FireBlock(Identifier, 13, true, false, false, true, true),
            3804 => new FireBlock(Identifier, 13, true, false, false, true, false),
            3805 => new FireBlock(Identifier, 13, true, false, false, false, true),
            3806 => new FireBlock(Identifier, 13, true, false, false, false, false),
            3807 => new FireBlock(Identifier, 13, false, true, true, true, true),
            3808 => new FireBlock(Identifier, 13, false, true, true, true, false),
            3809 => new FireBlock(Identifier, 13, false, true, true, false, true),
            3810 => new FireBlock(Identifier, 13, false, true, true, false, false),
            3811 => new FireBlock(Identifier, 13, false, true, false, true, true),
            3812 => new FireBlock(Identifier, 13, false, true, false, true, false),
            3813 => new FireBlock(Identifier, 13, false, true, false, false, true),
            3814 => new FireBlock(Identifier, 13, false, true, false, false, false),
            3815 => new FireBlock(Identifier, 13, false, false, true, true, true),
            3816 => new FireBlock(Identifier, 13, false, false, true, true, false),
            3817 => new FireBlock(Identifier, 13, false, false, true, false, true),
            3818 => new FireBlock(Identifier, 13, false, false, true, false, false),
            3819 => new FireBlock(Identifier, 13, false, false, false, true, true),
            3820 => new FireBlock(Identifier, 13, false, false, false, true, false),
            3821 => new FireBlock(Identifier, 13, false, false, false, false, true),
            3822 => new FireBlock(Identifier, 13, false, false, false, false, false),
            3823 => new FireBlock(Identifier, 14, true, true, true, true, true),
            3824 => new FireBlock(Identifier, 14, true, true, true, true, false),
            3825 => new FireBlock(Identifier, 14, true, true, true, false, true),
            3826 => new FireBlock(Identifier, 14, true, true, true, false, false),
            3827 => new FireBlock(Identifier, 14, true, true, false, true, true),
            3828 => new FireBlock(Identifier, 14, true, true, false, true, false),
            3829 => new FireBlock(Identifier, 14, true, true, false, false, true),
            3830 => new FireBlock(Identifier, 14, true, true, false, false, false),
            3831 => new FireBlock(Identifier, 14, true, false, true, true, true),
            3832 => new FireBlock(Identifier, 14, true, false, true, true, false),
            3833 => new FireBlock(Identifier, 14, true, false, true, false, true),
            3834 => new FireBlock(Identifier, 14, true, false, true, false, false),
            3835 => new FireBlock(Identifier, 14, true, false, false, true, true),
            3836 => new FireBlock(Identifier, 14, true, false, false, true, false),
            3837 => new FireBlock(Identifier, 14, true, false, false, false, true),
            3838 => new FireBlock(Identifier, 14, true, false, false, false, false),
            3839 => new FireBlock(Identifier, 14, false, true, true, true, true),
            3840 => new FireBlock(Identifier, 14, false, true, true, true, false),
            3841 => new FireBlock(Identifier, 14, false, true, true, false, true),
            3842 => new FireBlock(Identifier, 14, false, true, true, false, false),
            3843 => new FireBlock(Identifier, 14, false, true, false, true, true),
            3844 => new FireBlock(Identifier, 14, false, true, false, true, false),
            3845 => new FireBlock(Identifier, 14, false, true, false, false, true),
            3846 => new FireBlock(Identifier, 14, false, true, false, false, false),
            3847 => new FireBlock(Identifier, 14, false, false, true, true, true),
            3848 => new FireBlock(Identifier, 14, false, false, true, true, false),
            3849 => new FireBlock(Identifier, 14, false, false, true, false, true),
            3850 => new FireBlock(Identifier, 14, false, false, true, false, false),
            3851 => new FireBlock(Identifier, 14, false, false, false, true, true),
            3852 => new FireBlock(Identifier, 14, false, false, false, true, false),
            3853 => new FireBlock(Identifier, 14, false, false, false, false, true),
            3854 => new FireBlock(Identifier, 14, false, false, false, false, false),
            3855 => new FireBlock(Identifier, 15, true, true, true, true, true),
            3856 => new FireBlock(Identifier, 15, true, true, true, true, false),
            3857 => new FireBlock(Identifier, 15, true, true, true, false, true),
            3858 => new FireBlock(Identifier, 15, true, true, true, false, false),
            3859 => new FireBlock(Identifier, 15, true, true, false, true, true),
            3860 => new FireBlock(Identifier, 15, true, true, false, true, false),
            3861 => new FireBlock(Identifier, 15, true, true, false, false, true),
            3862 => new FireBlock(Identifier, 15, true, true, false, false, false),
            3863 => new FireBlock(Identifier, 15, true, false, true, true, true),
            3864 => new FireBlock(Identifier, 15, true, false, true, true, false),
            3865 => new FireBlock(Identifier, 15, true, false, true, false, true),
            3866 => new FireBlock(Identifier, 15, true, false, true, false, false),
            3867 => new FireBlock(Identifier, 15, true, false, false, true, true),
            3868 => new FireBlock(Identifier, 15, true, false, false, true, false),
            3869 => new FireBlock(Identifier, 15, true, false, false, false, true),
            3870 => new FireBlock(Identifier, 15, true, false, false, false, false),
            3871 => new FireBlock(Identifier, 15, false, true, true, true, true),
            3872 => new FireBlock(Identifier, 15, false, true, true, true, false),
            3873 => new FireBlock(Identifier, 15, false, true, true, false, true),
            3874 => new FireBlock(Identifier, 15, false, true, true, false, false),
            3875 => new FireBlock(Identifier, 15, false, true, false, true, true),
            3876 => new FireBlock(Identifier, 15, false, true, false, true, false),
            3877 => new FireBlock(Identifier, 15, false, true, false, false, true),
            3878 => new FireBlock(Identifier, 15, false, true, false, false, false),
            3879 => new FireBlock(Identifier, 15, false, false, true, true, true),
            3880 => new FireBlock(Identifier, 15, false, false, true, true, false),
            3881 => new FireBlock(Identifier, 15, false, false, true, false, true),
            3882 => new FireBlock(Identifier, 15, false, false, true, false, false),
            3883 => new FireBlock(Identifier, 15, false, false, false, true, true),
            3884 => new FireBlock(Identifier, 15, false, false, false, true, false),
            3885 => new FireBlock(Identifier, 15, false, false, false, false, true),
            3886 => new FireBlock(Identifier, 15, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
