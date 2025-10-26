using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FireBlock(Identifier Identifier, int Age, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:fire";
    public int ProtocolId => 195;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 15;
    public bool Replaceable => true;
    public string SoundType => "wool";
    public Identifier? BlockEntity => null;
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.0625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 4;
    public string TranslationKey => "block.minecraft.fire";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3174,
                                    false => 3175,
                                },
                                false => West switch {
                                    true => 3176,
                                    false => 3177,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3178,
                                    false => 3179,
                                },
                                false => West switch {
                                    true => 3180,
                                    false => 3181,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3182,
                                    false => 3183,
                                },
                                false => West switch {
                                    true => 3184,
                                    false => 3185,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3186,
                                    false => 3187,
                                },
                                false => West switch {
                                    true => 3188,
                                    false => 3189,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3190,
                                    false => 3191,
                                },
                                false => West switch {
                                    true => 3192,
                                    false => 3193,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3194,
                                    false => 3195,
                                },
                                false => West switch {
                                    true => 3196,
                                    false => 3197,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3198,
                                    false => 3199,
                                },
                                false => West switch {
                                    true => 3200,
                                    false => 3201,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3202,
                                    false => 3203,
                                },
                                false => West switch {
                                    true => 3204,
                                    false => 3205,
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
                                    true => 3206,
                                    false => 3207,
                                },
                                false => West switch {
                                    true => 3208,
                                    false => 3209,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3210,
                                    false => 3211,
                                },
                                false => West switch {
                                    true => 3212,
                                    false => 3213,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3214,
                                    false => 3215,
                                },
                                false => West switch {
                                    true => 3216,
                                    false => 3217,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3218,
                                    false => 3219,
                                },
                                false => West switch {
                                    true => 3220,
                                    false => 3221,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3222,
                                    false => 3223,
                                },
                                false => West switch {
                                    true => 3224,
                                    false => 3225,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3226,
                                    false => 3227,
                                },
                                false => West switch {
                                    true => 3228,
                                    false => 3229,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3230,
                                    false => 3231,
                                },
                                false => West switch {
                                    true => 3232,
                                    false => 3233,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3234,
                                    false => 3235,
                                },
                                false => West switch {
                                    true => 3236,
                                    false => 3237,
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
                                    true => 3238,
                                    false => 3239,
                                },
                                false => West switch {
                                    true => 3240,
                                    false => 3241,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3242,
                                    false => 3243,
                                },
                                false => West switch {
                                    true => 3244,
                                    false => 3245,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3246,
                                    false => 3247,
                                },
                                false => West switch {
                                    true => 3248,
                                    false => 3249,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3250,
                                    false => 3251,
                                },
                                false => West switch {
                                    true => 3252,
                                    false => 3253,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3254,
                                    false => 3255,
                                },
                                false => West switch {
                                    true => 3256,
                                    false => 3257,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3258,
                                    false => 3259,
                                },
                                false => West switch {
                                    true => 3260,
                                    false => 3261,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3262,
                                    false => 3263,
                                },
                                false => West switch {
                                    true => 3264,
                                    false => 3265,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3266,
                                    false => 3267,
                                },
                                false => West switch {
                                    true => 3268,
                                    false => 3269,
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
                                    true => 3270,
                                    false => 3271,
                                },
                                false => West switch {
                                    true => 3272,
                                    false => 3273,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3274,
                                    false => 3275,
                                },
                                false => West switch {
                                    true => 3276,
                                    false => 3277,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3278,
                                    false => 3279,
                                },
                                false => West switch {
                                    true => 3280,
                                    false => 3281,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3282,
                                    false => 3283,
                                },
                                false => West switch {
                                    true => 3284,
                                    false => 3285,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3286,
                                    false => 3287,
                                },
                                false => West switch {
                                    true => 3288,
                                    false => 3289,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3290,
                                    false => 3291,
                                },
                                false => West switch {
                                    true => 3292,
                                    false => 3293,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3294,
                                    false => 3295,
                                },
                                false => West switch {
                                    true => 3296,
                                    false => 3297,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3298,
                                    false => 3299,
                                },
                                false => West switch {
                                    true => 3300,
                                    false => 3301,
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
                                    true => 3302,
                                    false => 3303,
                                },
                                false => West switch {
                                    true => 3304,
                                    false => 3305,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3306,
                                    false => 3307,
                                },
                                false => West switch {
                                    true => 3308,
                                    false => 3309,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3310,
                                    false => 3311,
                                },
                                false => West switch {
                                    true => 3312,
                                    false => 3313,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3314,
                                    false => 3315,
                                },
                                false => West switch {
                                    true => 3316,
                                    false => 3317,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3318,
                                    false => 3319,
                                },
                                false => West switch {
                                    true => 3320,
                                    false => 3321,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3322,
                                    false => 3323,
                                },
                                false => West switch {
                                    true => 3324,
                                    false => 3325,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3326,
                                    false => 3327,
                                },
                                false => West switch {
                                    true => 3328,
                                    false => 3329,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3330,
                                    false => 3331,
                                },
                                false => West switch {
                                    true => 3332,
                                    false => 3333,
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
                                    true => 3334,
                                    false => 3335,
                                },
                                false => West switch {
                                    true => 3336,
                                    false => 3337,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3338,
                                    false => 3339,
                                },
                                false => West switch {
                                    true => 3340,
                                    false => 3341,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3342,
                                    false => 3343,
                                },
                                false => West switch {
                                    true => 3344,
                                    false => 3345,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3346,
                                    false => 3347,
                                },
                                false => West switch {
                                    true => 3348,
                                    false => 3349,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3350,
                                    false => 3351,
                                },
                                false => West switch {
                                    true => 3352,
                                    false => 3353,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3354,
                                    false => 3355,
                                },
                                false => West switch {
                                    true => 3356,
                                    false => 3357,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3358,
                                    false => 3359,
                                },
                                false => West switch {
                                    true => 3360,
                                    false => 3361,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3362,
                                    false => 3363,
                                },
                                false => West switch {
                                    true => 3364,
                                    false => 3365,
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
                                    true => 3366,
                                    false => 3367,
                                },
                                false => West switch {
                                    true => 3368,
                                    false => 3369,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3370,
                                    false => 3371,
                                },
                                false => West switch {
                                    true => 3372,
                                    false => 3373,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3374,
                                    false => 3375,
                                },
                                false => West switch {
                                    true => 3376,
                                    false => 3377,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3378,
                                    false => 3379,
                                },
                                false => West switch {
                                    true => 3380,
                                    false => 3381,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3382,
                                    false => 3383,
                                },
                                false => West switch {
                                    true => 3384,
                                    false => 3385,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3386,
                                    false => 3387,
                                },
                                false => West switch {
                                    true => 3388,
                                    false => 3389,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3390,
                                    false => 3391,
                                },
                                false => West switch {
                                    true => 3392,
                                    false => 3393,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3394,
                                    false => 3395,
                                },
                                false => West switch {
                                    true => 3396,
                                    false => 3397,
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
                                    true => 3398,
                                    false => 3399,
                                },
                                false => West switch {
                                    true => 3400,
                                    false => 3401,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3402,
                                    false => 3403,
                                },
                                false => West switch {
                                    true => 3404,
                                    false => 3405,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3406,
                                    false => 3407,
                                },
                                false => West switch {
                                    true => 3408,
                                    false => 3409,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3410,
                                    false => 3411,
                                },
                                false => West switch {
                                    true => 3412,
                                    false => 3413,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3414,
                                    false => 3415,
                                },
                                false => West switch {
                                    true => 3416,
                                    false => 3417,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3418,
                                    false => 3419,
                                },
                                false => West switch {
                                    true => 3420,
                                    false => 3421,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3422,
                                    false => 3423,
                                },
                                false => West switch {
                                    true => 3424,
                                    false => 3425,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3426,
                                    false => 3427,
                                },
                                false => West switch {
                                    true => 3428,
                                    false => 3429,
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
                                    true => 3430,
                                    false => 3431,
                                },
                                false => West switch {
                                    true => 3432,
                                    false => 3433,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3434,
                                    false => 3435,
                                },
                                false => West switch {
                                    true => 3436,
                                    false => 3437,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3438,
                                    false => 3439,
                                },
                                false => West switch {
                                    true => 3440,
                                    false => 3441,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3442,
                                    false => 3443,
                                },
                                false => West switch {
                                    true => 3444,
                                    false => 3445,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3446,
                                    false => 3447,
                                },
                                false => West switch {
                                    true => 3448,
                                    false => 3449,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3450,
                                    false => 3451,
                                },
                                false => West switch {
                                    true => 3452,
                                    false => 3453,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3454,
                                    false => 3455,
                                },
                                false => West switch {
                                    true => 3456,
                                    false => 3457,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3458,
                                    false => 3459,
                                },
                                false => West switch {
                                    true => 3460,
                                    false => 3461,
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
                                    true => 3462,
                                    false => 3463,
                                },
                                false => West switch {
                                    true => 3464,
                                    false => 3465,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3466,
                                    false => 3467,
                                },
                                false => West switch {
                                    true => 3468,
                                    false => 3469,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3470,
                                    false => 3471,
                                },
                                false => West switch {
                                    true => 3472,
                                    false => 3473,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3474,
                                    false => 3475,
                                },
                                false => West switch {
                                    true => 3476,
                                    false => 3477,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3478,
                                    false => 3479,
                                },
                                false => West switch {
                                    true => 3480,
                                    false => 3481,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3482,
                                    false => 3483,
                                },
                                false => West switch {
                                    true => 3484,
                                    false => 3485,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3486,
                                    false => 3487,
                                },
                                false => West switch {
                                    true => 3488,
                                    false => 3489,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3490,
                                    false => 3491,
                                },
                                false => West switch {
                                    true => 3492,
                                    false => 3493,
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
                                    true => 3494,
                                    false => 3495,
                                },
                                false => West switch {
                                    true => 3496,
                                    false => 3497,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3498,
                                    false => 3499,
                                },
                                false => West switch {
                                    true => 3500,
                                    false => 3501,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3502,
                                    false => 3503,
                                },
                                false => West switch {
                                    true => 3504,
                                    false => 3505,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3506,
                                    false => 3507,
                                },
                                false => West switch {
                                    true => 3508,
                                    false => 3509,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3510,
                                    false => 3511,
                                },
                                false => West switch {
                                    true => 3512,
                                    false => 3513,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3514,
                                    false => 3515,
                                },
                                false => West switch {
                                    true => 3516,
                                    false => 3517,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3518,
                                    false => 3519,
                                },
                                false => West switch {
                                    true => 3520,
                                    false => 3521,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3522,
                                    false => 3523,
                                },
                                false => West switch {
                                    true => 3524,
                                    false => 3525,
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
                                    true => 3526,
                                    false => 3527,
                                },
                                false => West switch {
                                    true => 3528,
                                    false => 3529,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3530,
                                    false => 3531,
                                },
                                false => West switch {
                                    true => 3532,
                                    false => 3533,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3534,
                                    false => 3535,
                                },
                                false => West switch {
                                    true => 3536,
                                    false => 3537,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3538,
                                    false => 3539,
                                },
                                false => West switch {
                                    true => 3540,
                                    false => 3541,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3542,
                                    false => 3543,
                                },
                                false => West switch {
                                    true => 3544,
                                    false => 3545,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3546,
                                    false => 3547,
                                },
                                false => West switch {
                                    true => 3548,
                                    false => 3549,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3550,
                                    false => 3551,
                                },
                                false => West switch {
                                    true => 3552,
                                    false => 3553,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3554,
                                    false => 3555,
                                },
                                false => West switch {
                                    true => 3556,
                                    false => 3557,
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
                                    true => 3558,
                                    false => 3559,
                                },
                                false => West switch {
                                    true => 3560,
                                    false => 3561,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3562,
                                    false => 3563,
                                },
                                false => West switch {
                                    true => 3564,
                                    false => 3565,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3566,
                                    false => 3567,
                                },
                                false => West switch {
                                    true => 3568,
                                    false => 3569,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3570,
                                    false => 3571,
                                },
                                false => West switch {
                                    true => 3572,
                                    false => 3573,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3574,
                                    false => 3575,
                                },
                                false => West switch {
                                    true => 3576,
                                    false => 3577,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3578,
                                    false => 3579,
                                },
                                false => West switch {
                                    true => 3580,
                                    false => 3581,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3582,
                                    false => 3583,
                                },
                                false => West switch {
                                    true => 3584,
                                    false => 3585,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3586,
                                    false => 3587,
                                },
                                false => West switch {
                                    true => 3588,
                                    false => 3589,
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
                                    true => 3590,
                                    false => 3591,
                                },
                                false => West switch {
                                    true => 3592,
                                    false => 3593,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3594,
                                    false => 3595,
                                },
                                false => West switch {
                                    true => 3596,
                                    false => 3597,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3598,
                                    false => 3599,
                                },
                                false => West switch {
                                    true => 3600,
                                    false => 3601,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3602,
                                    false => 3603,
                                },
                                false => West switch {
                                    true => 3604,
                                    false => 3605,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3606,
                                    false => 3607,
                                },
                                false => West switch {
                                    true => 3608,
                                    false => 3609,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3610,
                                    false => 3611,
                                },
                                false => West switch {
                                    true => 3612,
                                    false => 3613,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3614,
                                    false => 3615,
                                },
                                false => West switch {
                                    true => 3616,
                                    false => 3617,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3618,
                                    false => 3619,
                                },
                                false => West switch {
                                    true => 3620,
                                    false => 3621,
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
                                    true => 3622,
                                    false => 3623,
                                },
                                false => West switch {
                                    true => 3624,
                                    false => 3625,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3626,
                                    false => 3627,
                                },
                                false => West switch {
                                    true => 3628,
                                    false => 3629,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3630,
                                    false => 3631,
                                },
                                false => West switch {
                                    true => 3632,
                                    false => 3633,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3634,
                                    false => 3635,
                                },
                                false => West switch {
                                    true => 3636,
                                    false => 3637,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3638,
                                    false => 3639,
                                },
                                false => West switch {
                                    true => 3640,
                                    false => 3641,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3642,
                                    false => 3643,
                                },
                                false => West switch {
                                    true => 3644,
                                    false => 3645,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3646,
                                    false => 3647,
                                },
                                false => West switch {
                                    true => 3648,
                                    false => 3649,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3650,
                                    false => 3651,
                                },
                                false => West switch {
                                    true => 3652,
                                    false => 3653,
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
                                    true => 3654,
                                    false => 3655,
                                },
                                false => West switch {
                                    true => 3656,
                                    false => 3657,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3658,
                                    false => 3659,
                                },
                                false => West switch {
                                    true => 3660,
                                    false => 3661,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3662,
                                    false => 3663,
                                },
                                false => West switch {
                                    true => 3664,
                                    false => 3665,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3666,
                                    false => 3667,
                                },
                                false => West switch {
                                    true => 3668,
                                    false => 3669,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3670,
                                    false => 3671,
                                },
                                false => West switch {
                                    true => 3672,
                                    false => 3673,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3674,
                                    false => 3675,
                                },
                                false => West switch {
                                    true => 3676,
                                    false => 3677,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 3678,
                                    false => 3679,
                                },
                                false => West switch {
                                    true => 3680,
                                    false => 3681,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 3682,
                                    false => 3683,
                                },
                                false => West switch {
                                    true => 3684,
                                    false => 3685,
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
            3174 => new FireBlock(Identifier, 0, true, true, true, true, true),
            3175 => new FireBlock(Identifier, 0, true, true, true, true, false),
            3176 => new FireBlock(Identifier, 0, true, true, true, false, true),
            3177 => new FireBlock(Identifier, 0, true, true, true, false, false),
            3178 => new FireBlock(Identifier, 0, true, true, false, true, true),
            3179 => new FireBlock(Identifier, 0, true, true, false, true, false),
            3180 => new FireBlock(Identifier, 0, true, true, false, false, true),
            3181 => new FireBlock(Identifier, 0, true, true, false, false, false),
            3182 => new FireBlock(Identifier, 0, true, false, true, true, true),
            3183 => new FireBlock(Identifier, 0, true, false, true, true, false),
            3184 => new FireBlock(Identifier, 0, true, false, true, false, true),
            3185 => new FireBlock(Identifier, 0, true, false, true, false, false),
            3186 => new FireBlock(Identifier, 0, true, false, false, true, true),
            3187 => new FireBlock(Identifier, 0, true, false, false, true, false),
            3188 => new FireBlock(Identifier, 0, true, false, false, false, true),
            3189 => new FireBlock(Identifier, 0, true, false, false, false, false),
            3190 => new FireBlock(Identifier, 0, false, true, true, true, true),
            3191 => new FireBlock(Identifier, 0, false, true, true, true, false),
            3192 => new FireBlock(Identifier, 0, false, true, true, false, true),
            3193 => new FireBlock(Identifier, 0, false, true, true, false, false),
            3194 => new FireBlock(Identifier, 0, false, true, false, true, true),
            3195 => new FireBlock(Identifier, 0, false, true, false, true, false),
            3196 => new FireBlock(Identifier, 0, false, true, false, false, true),
            3197 => new FireBlock(Identifier, 0, false, true, false, false, false),
            3198 => new FireBlock(Identifier, 0, false, false, true, true, true),
            3199 => new FireBlock(Identifier, 0, false, false, true, true, false),
            3200 => new FireBlock(Identifier, 0, false, false, true, false, true),
            3201 => new FireBlock(Identifier, 0, false, false, true, false, false),
            3202 => new FireBlock(Identifier, 0, false, false, false, true, true),
            3203 => new FireBlock(Identifier, 0, false, false, false, true, false),
            3204 => new FireBlock(Identifier, 0, false, false, false, false, true),
            3205 => new FireBlock(Identifier, 0, false, false, false, false, false),
            3206 => new FireBlock(Identifier, 1, true, true, true, true, true),
            3207 => new FireBlock(Identifier, 1, true, true, true, true, false),
            3208 => new FireBlock(Identifier, 1, true, true, true, false, true),
            3209 => new FireBlock(Identifier, 1, true, true, true, false, false),
            3210 => new FireBlock(Identifier, 1, true, true, false, true, true),
            3211 => new FireBlock(Identifier, 1, true, true, false, true, false),
            3212 => new FireBlock(Identifier, 1, true, true, false, false, true),
            3213 => new FireBlock(Identifier, 1, true, true, false, false, false),
            3214 => new FireBlock(Identifier, 1, true, false, true, true, true),
            3215 => new FireBlock(Identifier, 1, true, false, true, true, false),
            3216 => new FireBlock(Identifier, 1, true, false, true, false, true),
            3217 => new FireBlock(Identifier, 1, true, false, true, false, false),
            3218 => new FireBlock(Identifier, 1, true, false, false, true, true),
            3219 => new FireBlock(Identifier, 1, true, false, false, true, false),
            3220 => new FireBlock(Identifier, 1, true, false, false, false, true),
            3221 => new FireBlock(Identifier, 1, true, false, false, false, false),
            3222 => new FireBlock(Identifier, 1, false, true, true, true, true),
            3223 => new FireBlock(Identifier, 1, false, true, true, true, false),
            3224 => new FireBlock(Identifier, 1, false, true, true, false, true),
            3225 => new FireBlock(Identifier, 1, false, true, true, false, false),
            3226 => new FireBlock(Identifier, 1, false, true, false, true, true),
            3227 => new FireBlock(Identifier, 1, false, true, false, true, false),
            3228 => new FireBlock(Identifier, 1, false, true, false, false, true),
            3229 => new FireBlock(Identifier, 1, false, true, false, false, false),
            3230 => new FireBlock(Identifier, 1, false, false, true, true, true),
            3231 => new FireBlock(Identifier, 1, false, false, true, true, false),
            3232 => new FireBlock(Identifier, 1, false, false, true, false, true),
            3233 => new FireBlock(Identifier, 1, false, false, true, false, false),
            3234 => new FireBlock(Identifier, 1, false, false, false, true, true),
            3235 => new FireBlock(Identifier, 1, false, false, false, true, false),
            3236 => new FireBlock(Identifier, 1, false, false, false, false, true),
            3237 => new FireBlock(Identifier, 1, false, false, false, false, false),
            3238 => new FireBlock(Identifier, 2, true, true, true, true, true),
            3239 => new FireBlock(Identifier, 2, true, true, true, true, false),
            3240 => new FireBlock(Identifier, 2, true, true, true, false, true),
            3241 => new FireBlock(Identifier, 2, true, true, true, false, false),
            3242 => new FireBlock(Identifier, 2, true, true, false, true, true),
            3243 => new FireBlock(Identifier, 2, true, true, false, true, false),
            3244 => new FireBlock(Identifier, 2, true, true, false, false, true),
            3245 => new FireBlock(Identifier, 2, true, true, false, false, false),
            3246 => new FireBlock(Identifier, 2, true, false, true, true, true),
            3247 => new FireBlock(Identifier, 2, true, false, true, true, false),
            3248 => new FireBlock(Identifier, 2, true, false, true, false, true),
            3249 => new FireBlock(Identifier, 2, true, false, true, false, false),
            3250 => new FireBlock(Identifier, 2, true, false, false, true, true),
            3251 => new FireBlock(Identifier, 2, true, false, false, true, false),
            3252 => new FireBlock(Identifier, 2, true, false, false, false, true),
            3253 => new FireBlock(Identifier, 2, true, false, false, false, false),
            3254 => new FireBlock(Identifier, 2, false, true, true, true, true),
            3255 => new FireBlock(Identifier, 2, false, true, true, true, false),
            3256 => new FireBlock(Identifier, 2, false, true, true, false, true),
            3257 => new FireBlock(Identifier, 2, false, true, true, false, false),
            3258 => new FireBlock(Identifier, 2, false, true, false, true, true),
            3259 => new FireBlock(Identifier, 2, false, true, false, true, false),
            3260 => new FireBlock(Identifier, 2, false, true, false, false, true),
            3261 => new FireBlock(Identifier, 2, false, true, false, false, false),
            3262 => new FireBlock(Identifier, 2, false, false, true, true, true),
            3263 => new FireBlock(Identifier, 2, false, false, true, true, false),
            3264 => new FireBlock(Identifier, 2, false, false, true, false, true),
            3265 => new FireBlock(Identifier, 2, false, false, true, false, false),
            3266 => new FireBlock(Identifier, 2, false, false, false, true, true),
            3267 => new FireBlock(Identifier, 2, false, false, false, true, false),
            3268 => new FireBlock(Identifier, 2, false, false, false, false, true),
            3269 => new FireBlock(Identifier, 2, false, false, false, false, false),
            3270 => new FireBlock(Identifier, 3, true, true, true, true, true),
            3271 => new FireBlock(Identifier, 3, true, true, true, true, false),
            3272 => new FireBlock(Identifier, 3, true, true, true, false, true),
            3273 => new FireBlock(Identifier, 3, true, true, true, false, false),
            3274 => new FireBlock(Identifier, 3, true, true, false, true, true),
            3275 => new FireBlock(Identifier, 3, true, true, false, true, false),
            3276 => new FireBlock(Identifier, 3, true, true, false, false, true),
            3277 => new FireBlock(Identifier, 3, true, true, false, false, false),
            3278 => new FireBlock(Identifier, 3, true, false, true, true, true),
            3279 => new FireBlock(Identifier, 3, true, false, true, true, false),
            3280 => new FireBlock(Identifier, 3, true, false, true, false, true),
            3281 => new FireBlock(Identifier, 3, true, false, true, false, false),
            3282 => new FireBlock(Identifier, 3, true, false, false, true, true),
            3283 => new FireBlock(Identifier, 3, true, false, false, true, false),
            3284 => new FireBlock(Identifier, 3, true, false, false, false, true),
            3285 => new FireBlock(Identifier, 3, true, false, false, false, false),
            3286 => new FireBlock(Identifier, 3, false, true, true, true, true),
            3287 => new FireBlock(Identifier, 3, false, true, true, true, false),
            3288 => new FireBlock(Identifier, 3, false, true, true, false, true),
            3289 => new FireBlock(Identifier, 3, false, true, true, false, false),
            3290 => new FireBlock(Identifier, 3, false, true, false, true, true),
            3291 => new FireBlock(Identifier, 3, false, true, false, true, false),
            3292 => new FireBlock(Identifier, 3, false, true, false, false, true),
            3293 => new FireBlock(Identifier, 3, false, true, false, false, false),
            3294 => new FireBlock(Identifier, 3, false, false, true, true, true),
            3295 => new FireBlock(Identifier, 3, false, false, true, true, false),
            3296 => new FireBlock(Identifier, 3, false, false, true, false, true),
            3297 => new FireBlock(Identifier, 3, false, false, true, false, false),
            3298 => new FireBlock(Identifier, 3, false, false, false, true, true),
            3299 => new FireBlock(Identifier, 3, false, false, false, true, false),
            3300 => new FireBlock(Identifier, 3, false, false, false, false, true),
            3301 => new FireBlock(Identifier, 3, false, false, false, false, false),
            3302 => new FireBlock(Identifier, 4, true, true, true, true, true),
            3303 => new FireBlock(Identifier, 4, true, true, true, true, false),
            3304 => new FireBlock(Identifier, 4, true, true, true, false, true),
            3305 => new FireBlock(Identifier, 4, true, true, true, false, false),
            3306 => new FireBlock(Identifier, 4, true, true, false, true, true),
            3307 => new FireBlock(Identifier, 4, true, true, false, true, false),
            3308 => new FireBlock(Identifier, 4, true, true, false, false, true),
            3309 => new FireBlock(Identifier, 4, true, true, false, false, false),
            3310 => new FireBlock(Identifier, 4, true, false, true, true, true),
            3311 => new FireBlock(Identifier, 4, true, false, true, true, false),
            3312 => new FireBlock(Identifier, 4, true, false, true, false, true),
            3313 => new FireBlock(Identifier, 4, true, false, true, false, false),
            3314 => new FireBlock(Identifier, 4, true, false, false, true, true),
            3315 => new FireBlock(Identifier, 4, true, false, false, true, false),
            3316 => new FireBlock(Identifier, 4, true, false, false, false, true),
            3317 => new FireBlock(Identifier, 4, true, false, false, false, false),
            3318 => new FireBlock(Identifier, 4, false, true, true, true, true),
            3319 => new FireBlock(Identifier, 4, false, true, true, true, false),
            3320 => new FireBlock(Identifier, 4, false, true, true, false, true),
            3321 => new FireBlock(Identifier, 4, false, true, true, false, false),
            3322 => new FireBlock(Identifier, 4, false, true, false, true, true),
            3323 => new FireBlock(Identifier, 4, false, true, false, true, false),
            3324 => new FireBlock(Identifier, 4, false, true, false, false, true),
            3325 => new FireBlock(Identifier, 4, false, true, false, false, false),
            3326 => new FireBlock(Identifier, 4, false, false, true, true, true),
            3327 => new FireBlock(Identifier, 4, false, false, true, true, false),
            3328 => new FireBlock(Identifier, 4, false, false, true, false, true),
            3329 => new FireBlock(Identifier, 4, false, false, true, false, false),
            3330 => new FireBlock(Identifier, 4, false, false, false, true, true),
            3331 => new FireBlock(Identifier, 4, false, false, false, true, false),
            3332 => new FireBlock(Identifier, 4, false, false, false, false, true),
            3333 => new FireBlock(Identifier, 4, false, false, false, false, false),
            3334 => new FireBlock(Identifier, 5, true, true, true, true, true),
            3335 => new FireBlock(Identifier, 5, true, true, true, true, false),
            3336 => new FireBlock(Identifier, 5, true, true, true, false, true),
            3337 => new FireBlock(Identifier, 5, true, true, true, false, false),
            3338 => new FireBlock(Identifier, 5, true, true, false, true, true),
            3339 => new FireBlock(Identifier, 5, true, true, false, true, false),
            3340 => new FireBlock(Identifier, 5, true, true, false, false, true),
            3341 => new FireBlock(Identifier, 5, true, true, false, false, false),
            3342 => new FireBlock(Identifier, 5, true, false, true, true, true),
            3343 => new FireBlock(Identifier, 5, true, false, true, true, false),
            3344 => new FireBlock(Identifier, 5, true, false, true, false, true),
            3345 => new FireBlock(Identifier, 5, true, false, true, false, false),
            3346 => new FireBlock(Identifier, 5, true, false, false, true, true),
            3347 => new FireBlock(Identifier, 5, true, false, false, true, false),
            3348 => new FireBlock(Identifier, 5, true, false, false, false, true),
            3349 => new FireBlock(Identifier, 5, true, false, false, false, false),
            3350 => new FireBlock(Identifier, 5, false, true, true, true, true),
            3351 => new FireBlock(Identifier, 5, false, true, true, true, false),
            3352 => new FireBlock(Identifier, 5, false, true, true, false, true),
            3353 => new FireBlock(Identifier, 5, false, true, true, false, false),
            3354 => new FireBlock(Identifier, 5, false, true, false, true, true),
            3355 => new FireBlock(Identifier, 5, false, true, false, true, false),
            3356 => new FireBlock(Identifier, 5, false, true, false, false, true),
            3357 => new FireBlock(Identifier, 5, false, true, false, false, false),
            3358 => new FireBlock(Identifier, 5, false, false, true, true, true),
            3359 => new FireBlock(Identifier, 5, false, false, true, true, false),
            3360 => new FireBlock(Identifier, 5, false, false, true, false, true),
            3361 => new FireBlock(Identifier, 5, false, false, true, false, false),
            3362 => new FireBlock(Identifier, 5, false, false, false, true, true),
            3363 => new FireBlock(Identifier, 5, false, false, false, true, false),
            3364 => new FireBlock(Identifier, 5, false, false, false, false, true),
            3365 => new FireBlock(Identifier, 5, false, false, false, false, false),
            3366 => new FireBlock(Identifier, 6, true, true, true, true, true),
            3367 => new FireBlock(Identifier, 6, true, true, true, true, false),
            3368 => new FireBlock(Identifier, 6, true, true, true, false, true),
            3369 => new FireBlock(Identifier, 6, true, true, true, false, false),
            3370 => new FireBlock(Identifier, 6, true, true, false, true, true),
            3371 => new FireBlock(Identifier, 6, true, true, false, true, false),
            3372 => new FireBlock(Identifier, 6, true, true, false, false, true),
            3373 => new FireBlock(Identifier, 6, true, true, false, false, false),
            3374 => new FireBlock(Identifier, 6, true, false, true, true, true),
            3375 => new FireBlock(Identifier, 6, true, false, true, true, false),
            3376 => new FireBlock(Identifier, 6, true, false, true, false, true),
            3377 => new FireBlock(Identifier, 6, true, false, true, false, false),
            3378 => new FireBlock(Identifier, 6, true, false, false, true, true),
            3379 => new FireBlock(Identifier, 6, true, false, false, true, false),
            3380 => new FireBlock(Identifier, 6, true, false, false, false, true),
            3381 => new FireBlock(Identifier, 6, true, false, false, false, false),
            3382 => new FireBlock(Identifier, 6, false, true, true, true, true),
            3383 => new FireBlock(Identifier, 6, false, true, true, true, false),
            3384 => new FireBlock(Identifier, 6, false, true, true, false, true),
            3385 => new FireBlock(Identifier, 6, false, true, true, false, false),
            3386 => new FireBlock(Identifier, 6, false, true, false, true, true),
            3387 => new FireBlock(Identifier, 6, false, true, false, true, false),
            3388 => new FireBlock(Identifier, 6, false, true, false, false, true),
            3389 => new FireBlock(Identifier, 6, false, true, false, false, false),
            3390 => new FireBlock(Identifier, 6, false, false, true, true, true),
            3391 => new FireBlock(Identifier, 6, false, false, true, true, false),
            3392 => new FireBlock(Identifier, 6, false, false, true, false, true),
            3393 => new FireBlock(Identifier, 6, false, false, true, false, false),
            3394 => new FireBlock(Identifier, 6, false, false, false, true, true),
            3395 => new FireBlock(Identifier, 6, false, false, false, true, false),
            3396 => new FireBlock(Identifier, 6, false, false, false, false, true),
            3397 => new FireBlock(Identifier, 6, false, false, false, false, false),
            3398 => new FireBlock(Identifier, 7, true, true, true, true, true),
            3399 => new FireBlock(Identifier, 7, true, true, true, true, false),
            3400 => new FireBlock(Identifier, 7, true, true, true, false, true),
            3401 => new FireBlock(Identifier, 7, true, true, true, false, false),
            3402 => new FireBlock(Identifier, 7, true, true, false, true, true),
            3403 => new FireBlock(Identifier, 7, true, true, false, true, false),
            3404 => new FireBlock(Identifier, 7, true, true, false, false, true),
            3405 => new FireBlock(Identifier, 7, true, true, false, false, false),
            3406 => new FireBlock(Identifier, 7, true, false, true, true, true),
            3407 => new FireBlock(Identifier, 7, true, false, true, true, false),
            3408 => new FireBlock(Identifier, 7, true, false, true, false, true),
            3409 => new FireBlock(Identifier, 7, true, false, true, false, false),
            3410 => new FireBlock(Identifier, 7, true, false, false, true, true),
            3411 => new FireBlock(Identifier, 7, true, false, false, true, false),
            3412 => new FireBlock(Identifier, 7, true, false, false, false, true),
            3413 => new FireBlock(Identifier, 7, true, false, false, false, false),
            3414 => new FireBlock(Identifier, 7, false, true, true, true, true),
            3415 => new FireBlock(Identifier, 7, false, true, true, true, false),
            3416 => new FireBlock(Identifier, 7, false, true, true, false, true),
            3417 => new FireBlock(Identifier, 7, false, true, true, false, false),
            3418 => new FireBlock(Identifier, 7, false, true, false, true, true),
            3419 => new FireBlock(Identifier, 7, false, true, false, true, false),
            3420 => new FireBlock(Identifier, 7, false, true, false, false, true),
            3421 => new FireBlock(Identifier, 7, false, true, false, false, false),
            3422 => new FireBlock(Identifier, 7, false, false, true, true, true),
            3423 => new FireBlock(Identifier, 7, false, false, true, true, false),
            3424 => new FireBlock(Identifier, 7, false, false, true, false, true),
            3425 => new FireBlock(Identifier, 7, false, false, true, false, false),
            3426 => new FireBlock(Identifier, 7, false, false, false, true, true),
            3427 => new FireBlock(Identifier, 7, false, false, false, true, false),
            3428 => new FireBlock(Identifier, 7, false, false, false, false, true),
            3429 => new FireBlock(Identifier, 7, false, false, false, false, false),
            3430 => new FireBlock(Identifier, 8, true, true, true, true, true),
            3431 => new FireBlock(Identifier, 8, true, true, true, true, false),
            3432 => new FireBlock(Identifier, 8, true, true, true, false, true),
            3433 => new FireBlock(Identifier, 8, true, true, true, false, false),
            3434 => new FireBlock(Identifier, 8, true, true, false, true, true),
            3435 => new FireBlock(Identifier, 8, true, true, false, true, false),
            3436 => new FireBlock(Identifier, 8, true, true, false, false, true),
            3437 => new FireBlock(Identifier, 8, true, true, false, false, false),
            3438 => new FireBlock(Identifier, 8, true, false, true, true, true),
            3439 => new FireBlock(Identifier, 8, true, false, true, true, false),
            3440 => new FireBlock(Identifier, 8, true, false, true, false, true),
            3441 => new FireBlock(Identifier, 8, true, false, true, false, false),
            3442 => new FireBlock(Identifier, 8, true, false, false, true, true),
            3443 => new FireBlock(Identifier, 8, true, false, false, true, false),
            3444 => new FireBlock(Identifier, 8, true, false, false, false, true),
            3445 => new FireBlock(Identifier, 8, true, false, false, false, false),
            3446 => new FireBlock(Identifier, 8, false, true, true, true, true),
            3447 => new FireBlock(Identifier, 8, false, true, true, true, false),
            3448 => new FireBlock(Identifier, 8, false, true, true, false, true),
            3449 => new FireBlock(Identifier, 8, false, true, true, false, false),
            3450 => new FireBlock(Identifier, 8, false, true, false, true, true),
            3451 => new FireBlock(Identifier, 8, false, true, false, true, false),
            3452 => new FireBlock(Identifier, 8, false, true, false, false, true),
            3453 => new FireBlock(Identifier, 8, false, true, false, false, false),
            3454 => new FireBlock(Identifier, 8, false, false, true, true, true),
            3455 => new FireBlock(Identifier, 8, false, false, true, true, false),
            3456 => new FireBlock(Identifier, 8, false, false, true, false, true),
            3457 => new FireBlock(Identifier, 8, false, false, true, false, false),
            3458 => new FireBlock(Identifier, 8, false, false, false, true, true),
            3459 => new FireBlock(Identifier, 8, false, false, false, true, false),
            3460 => new FireBlock(Identifier, 8, false, false, false, false, true),
            3461 => new FireBlock(Identifier, 8, false, false, false, false, false),
            3462 => new FireBlock(Identifier, 9, true, true, true, true, true),
            3463 => new FireBlock(Identifier, 9, true, true, true, true, false),
            3464 => new FireBlock(Identifier, 9, true, true, true, false, true),
            3465 => new FireBlock(Identifier, 9, true, true, true, false, false),
            3466 => new FireBlock(Identifier, 9, true, true, false, true, true),
            3467 => new FireBlock(Identifier, 9, true, true, false, true, false),
            3468 => new FireBlock(Identifier, 9, true, true, false, false, true),
            3469 => new FireBlock(Identifier, 9, true, true, false, false, false),
            3470 => new FireBlock(Identifier, 9, true, false, true, true, true),
            3471 => new FireBlock(Identifier, 9, true, false, true, true, false),
            3472 => new FireBlock(Identifier, 9, true, false, true, false, true),
            3473 => new FireBlock(Identifier, 9, true, false, true, false, false),
            3474 => new FireBlock(Identifier, 9, true, false, false, true, true),
            3475 => new FireBlock(Identifier, 9, true, false, false, true, false),
            3476 => new FireBlock(Identifier, 9, true, false, false, false, true),
            3477 => new FireBlock(Identifier, 9, true, false, false, false, false),
            3478 => new FireBlock(Identifier, 9, false, true, true, true, true),
            3479 => new FireBlock(Identifier, 9, false, true, true, true, false),
            3480 => new FireBlock(Identifier, 9, false, true, true, false, true),
            3481 => new FireBlock(Identifier, 9, false, true, true, false, false),
            3482 => new FireBlock(Identifier, 9, false, true, false, true, true),
            3483 => new FireBlock(Identifier, 9, false, true, false, true, false),
            3484 => new FireBlock(Identifier, 9, false, true, false, false, true),
            3485 => new FireBlock(Identifier, 9, false, true, false, false, false),
            3486 => new FireBlock(Identifier, 9, false, false, true, true, true),
            3487 => new FireBlock(Identifier, 9, false, false, true, true, false),
            3488 => new FireBlock(Identifier, 9, false, false, true, false, true),
            3489 => new FireBlock(Identifier, 9, false, false, true, false, false),
            3490 => new FireBlock(Identifier, 9, false, false, false, true, true),
            3491 => new FireBlock(Identifier, 9, false, false, false, true, false),
            3492 => new FireBlock(Identifier, 9, false, false, false, false, true),
            3493 => new FireBlock(Identifier, 9, false, false, false, false, false),
            3494 => new FireBlock(Identifier, 10, true, true, true, true, true),
            3495 => new FireBlock(Identifier, 10, true, true, true, true, false),
            3496 => new FireBlock(Identifier, 10, true, true, true, false, true),
            3497 => new FireBlock(Identifier, 10, true, true, true, false, false),
            3498 => new FireBlock(Identifier, 10, true, true, false, true, true),
            3499 => new FireBlock(Identifier, 10, true, true, false, true, false),
            3500 => new FireBlock(Identifier, 10, true, true, false, false, true),
            3501 => new FireBlock(Identifier, 10, true, true, false, false, false),
            3502 => new FireBlock(Identifier, 10, true, false, true, true, true),
            3503 => new FireBlock(Identifier, 10, true, false, true, true, false),
            3504 => new FireBlock(Identifier, 10, true, false, true, false, true),
            3505 => new FireBlock(Identifier, 10, true, false, true, false, false),
            3506 => new FireBlock(Identifier, 10, true, false, false, true, true),
            3507 => new FireBlock(Identifier, 10, true, false, false, true, false),
            3508 => new FireBlock(Identifier, 10, true, false, false, false, true),
            3509 => new FireBlock(Identifier, 10, true, false, false, false, false),
            3510 => new FireBlock(Identifier, 10, false, true, true, true, true),
            3511 => new FireBlock(Identifier, 10, false, true, true, true, false),
            3512 => new FireBlock(Identifier, 10, false, true, true, false, true),
            3513 => new FireBlock(Identifier, 10, false, true, true, false, false),
            3514 => new FireBlock(Identifier, 10, false, true, false, true, true),
            3515 => new FireBlock(Identifier, 10, false, true, false, true, false),
            3516 => new FireBlock(Identifier, 10, false, true, false, false, true),
            3517 => new FireBlock(Identifier, 10, false, true, false, false, false),
            3518 => new FireBlock(Identifier, 10, false, false, true, true, true),
            3519 => new FireBlock(Identifier, 10, false, false, true, true, false),
            3520 => new FireBlock(Identifier, 10, false, false, true, false, true),
            3521 => new FireBlock(Identifier, 10, false, false, true, false, false),
            3522 => new FireBlock(Identifier, 10, false, false, false, true, true),
            3523 => new FireBlock(Identifier, 10, false, false, false, true, false),
            3524 => new FireBlock(Identifier, 10, false, false, false, false, true),
            3525 => new FireBlock(Identifier, 10, false, false, false, false, false),
            3526 => new FireBlock(Identifier, 11, true, true, true, true, true),
            3527 => new FireBlock(Identifier, 11, true, true, true, true, false),
            3528 => new FireBlock(Identifier, 11, true, true, true, false, true),
            3529 => new FireBlock(Identifier, 11, true, true, true, false, false),
            3530 => new FireBlock(Identifier, 11, true, true, false, true, true),
            3531 => new FireBlock(Identifier, 11, true, true, false, true, false),
            3532 => new FireBlock(Identifier, 11, true, true, false, false, true),
            3533 => new FireBlock(Identifier, 11, true, true, false, false, false),
            3534 => new FireBlock(Identifier, 11, true, false, true, true, true),
            3535 => new FireBlock(Identifier, 11, true, false, true, true, false),
            3536 => new FireBlock(Identifier, 11, true, false, true, false, true),
            3537 => new FireBlock(Identifier, 11, true, false, true, false, false),
            3538 => new FireBlock(Identifier, 11, true, false, false, true, true),
            3539 => new FireBlock(Identifier, 11, true, false, false, true, false),
            3540 => new FireBlock(Identifier, 11, true, false, false, false, true),
            3541 => new FireBlock(Identifier, 11, true, false, false, false, false),
            3542 => new FireBlock(Identifier, 11, false, true, true, true, true),
            3543 => new FireBlock(Identifier, 11, false, true, true, true, false),
            3544 => new FireBlock(Identifier, 11, false, true, true, false, true),
            3545 => new FireBlock(Identifier, 11, false, true, true, false, false),
            3546 => new FireBlock(Identifier, 11, false, true, false, true, true),
            3547 => new FireBlock(Identifier, 11, false, true, false, true, false),
            3548 => new FireBlock(Identifier, 11, false, true, false, false, true),
            3549 => new FireBlock(Identifier, 11, false, true, false, false, false),
            3550 => new FireBlock(Identifier, 11, false, false, true, true, true),
            3551 => new FireBlock(Identifier, 11, false, false, true, true, false),
            3552 => new FireBlock(Identifier, 11, false, false, true, false, true),
            3553 => new FireBlock(Identifier, 11, false, false, true, false, false),
            3554 => new FireBlock(Identifier, 11, false, false, false, true, true),
            3555 => new FireBlock(Identifier, 11, false, false, false, true, false),
            3556 => new FireBlock(Identifier, 11, false, false, false, false, true),
            3557 => new FireBlock(Identifier, 11, false, false, false, false, false),
            3558 => new FireBlock(Identifier, 12, true, true, true, true, true),
            3559 => new FireBlock(Identifier, 12, true, true, true, true, false),
            3560 => new FireBlock(Identifier, 12, true, true, true, false, true),
            3561 => new FireBlock(Identifier, 12, true, true, true, false, false),
            3562 => new FireBlock(Identifier, 12, true, true, false, true, true),
            3563 => new FireBlock(Identifier, 12, true, true, false, true, false),
            3564 => new FireBlock(Identifier, 12, true, true, false, false, true),
            3565 => new FireBlock(Identifier, 12, true, true, false, false, false),
            3566 => new FireBlock(Identifier, 12, true, false, true, true, true),
            3567 => new FireBlock(Identifier, 12, true, false, true, true, false),
            3568 => new FireBlock(Identifier, 12, true, false, true, false, true),
            3569 => new FireBlock(Identifier, 12, true, false, true, false, false),
            3570 => new FireBlock(Identifier, 12, true, false, false, true, true),
            3571 => new FireBlock(Identifier, 12, true, false, false, true, false),
            3572 => new FireBlock(Identifier, 12, true, false, false, false, true),
            3573 => new FireBlock(Identifier, 12, true, false, false, false, false),
            3574 => new FireBlock(Identifier, 12, false, true, true, true, true),
            3575 => new FireBlock(Identifier, 12, false, true, true, true, false),
            3576 => new FireBlock(Identifier, 12, false, true, true, false, true),
            3577 => new FireBlock(Identifier, 12, false, true, true, false, false),
            3578 => new FireBlock(Identifier, 12, false, true, false, true, true),
            3579 => new FireBlock(Identifier, 12, false, true, false, true, false),
            3580 => new FireBlock(Identifier, 12, false, true, false, false, true),
            3581 => new FireBlock(Identifier, 12, false, true, false, false, false),
            3582 => new FireBlock(Identifier, 12, false, false, true, true, true),
            3583 => new FireBlock(Identifier, 12, false, false, true, true, false),
            3584 => new FireBlock(Identifier, 12, false, false, true, false, true),
            3585 => new FireBlock(Identifier, 12, false, false, true, false, false),
            3586 => new FireBlock(Identifier, 12, false, false, false, true, true),
            3587 => new FireBlock(Identifier, 12, false, false, false, true, false),
            3588 => new FireBlock(Identifier, 12, false, false, false, false, true),
            3589 => new FireBlock(Identifier, 12, false, false, false, false, false),
            3590 => new FireBlock(Identifier, 13, true, true, true, true, true),
            3591 => new FireBlock(Identifier, 13, true, true, true, true, false),
            3592 => new FireBlock(Identifier, 13, true, true, true, false, true),
            3593 => new FireBlock(Identifier, 13, true, true, true, false, false),
            3594 => new FireBlock(Identifier, 13, true, true, false, true, true),
            3595 => new FireBlock(Identifier, 13, true, true, false, true, false),
            3596 => new FireBlock(Identifier, 13, true, true, false, false, true),
            3597 => new FireBlock(Identifier, 13, true, true, false, false, false),
            3598 => new FireBlock(Identifier, 13, true, false, true, true, true),
            3599 => new FireBlock(Identifier, 13, true, false, true, true, false),
            3600 => new FireBlock(Identifier, 13, true, false, true, false, true),
            3601 => new FireBlock(Identifier, 13, true, false, true, false, false),
            3602 => new FireBlock(Identifier, 13, true, false, false, true, true),
            3603 => new FireBlock(Identifier, 13, true, false, false, true, false),
            3604 => new FireBlock(Identifier, 13, true, false, false, false, true),
            3605 => new FireBlock(Identifier, 13, true, false, false, false, false),
            3606 => new FireBlock(Identifier, 13, false, true, true, true, true),
            3607 => new FireBlock(Identifier, 13, false, true, true, true, false),
            3608 => new FireBlock(Identifier, 13, false, true, true, false, true),
            3609 => new FireBlock(Identifier, 13, false, true, true, false, false),
            3610 => new FireBlock(Identifier, 13, false, true, false, true, true),
            3611 => new FireBlock(Identifier, 13, false, true, false, true, false),
            3612 => new FireBlock(Identifier, 13, false, true, false, false, true),
            3613 => new FireBlock(Identifier, 13, false, true, false, false, false),
            3614 => new FireBlock(Identifier, 13, false, false, true, true, true),
            3615 => new FireBlock(Identifier, 13, false, false, true, true, false),
            3616 => new FireBlock(Identifier, 13, false, false, true, false, true),
            3617 => new FireBlock(Identifier, 13, false, false, true, false, false),
            3618 => new FireBlock(Identifier, 13, false, false, false, true, true),
            3619 => new FireBlock(Identifier, 13, false, false, false, true, false),
            3620 => new FireBlock(Identifier, 13, false, false, false, false, true),
            3621 => new FireBlock(Identifier, 13, false, false, false, false, false),
            3622 => new FireBlock(Identifier, 14, true, true, true, true, true),
            3623 => new FireBlock(Identifier, 14, true, true, true, true, false),
            3624 => new FireBlock(Identifier, 14, true, true, true, false, true),
            3625 => new FireBlock(Identifier, 14, true, true, true, false, false),
            3626 => new FireBlock(Identifier, 14, true, true, false, true, true),
            3627 => new FireBlock(Identifier, 14, true, true, false, true, false),
            3628 => new FireBlock(Identifier, 14, true, true, false, false, true),
            3629 => new FireBlock(Identifier, 14, true, true, false, false, false),
            3630 => new FireBlock(Identifier, 14, true, false, true, true, true),
            3631 => new FireBlock(Identifier, 14, true, false, true, true, false),
            3632 => new FireBlock(Identifier, 14, true, false, true, false, true),
            3633 => new FireBlock(Identifier, 14, true, false, true, false, false),
            3634 => new FireBlock(Identifier, 14, true, false, false, true, true),
            3635 => new FireBlock(Identifier, 14, true, false, false, true, false),
            3636 => new FireBlock(Identifier, 14, true, false, false, false, true),
            3637 => new FireBlock(Identifier, 14, true, false, false, false, false),
            3638 => new FireBlock(Identifier, 14, false, true, true, true, true),
            3639 => new FireBlock(Identifier, 14, false, true, true, true, false),
            3640 => new FireBlock(Identifier, 14, false, true, true, false, true),
            3641 => new FireBlock(Identifier, 14, false, true, true, false, false),
            3642 => new FireBlock(Identifier, 14, false, true, false, true, true),
            3643 => new FireBlock(Identifier, 14, false, true, false, true, false),
            3644 => new FireBlock(Identifier, 14, false, true, false, false, true),
            3645 => new FireBlock(Identifier, 14, false, true, false, false, false),
            3646 => new FireBlock(Identifier, 14, false, false, true, true, true),
            3647 => new FireBlock(Identifier, 14, false, false, true, true, false),
            3648 => new FireBlock(Identifier, 14, false, false, true, false, true),
            3649 => new FireBlock(Identifier, 14, false, false, true, false, false),
            3650 => new FireBlock(Identifier, 14, false, false, false, true, true),
            3651 => new FireBlock(Identifier, 14, false, false, false, true, false),
            3652 => new FireBlock(Identifier, 14, false, false, false, false, true),
            3653 => new FireBlock(Identifier, 14, false, false, false, false, false),
            3654 => new FireBlock(Identifier, 15, true, true, true, true, true),
            3655 => new FireBlock(Identifier, 15, true, true, true, true, false),
            3656 => new FireBlock(Identifier, 15, true, true, true, false, true),
            3657 => new FireBlock(Identifier, 15, true, true, true, false, false),
            3658 => new FireBlock(Identifier, 15, true, true, false, true, true),
            3659 => new FireBlock(Identifier, 15, true, true, false, true, false),
            3660 => new FireBlock(Identifier, 15, true, true, false, false, true),
            3661 => new FireBlock(Identifier, 15, true, true, false, false, false),
            3662 => new FireBlock(Identifier, 15, true, false, true, true, true),
            3663 => new FireBlock(Identifier, 15, true, false, true, true, false),
            3664 => new FireBlock(Identifier, 15, true, false, true, false, true),
            3665 => new FireBlock(Identifier, 15, true, false, true, false, false),
            3666 => new FireBlock(Identifier, 15, true, false, false, true, true),
            3667 => new FireBlock(Identifier, 15, true, false, false, true, false),
            3668 => new FireBlock(Identifier, 15, true, false, false, false, true),
            3669 => new FireBlock(Identifier, 15, true, false, false, false, false),
            3670 => new FireBlock(Identifier, 15, false, true, true, true, true),
            3671 => new FireBlock(Identifier, 15, false, true, true, true, false),
            3672 => new FireBlock(Identifier, 15, false, true, true, false, true),
            3673 => new FireBlock(Identifier, 15, false, true, true, false, false),
            3674 => new FireBlock(Identifier, 15, false, true, false, true, true),
            3675 => new FireBlock(Identifier, 15, false, true, false, true, false),
            3676 => new FireBlock(Identifier, 15, false, true, false, false, true),
            3677 => new FireBlock(Identifier, 15, false, true, false, false, false),
            3678 => new FireBlock(Identifier, 15, false, false, true, true, true),
            3679 => new FireBlock(Identifier, 15, false, false, true, true, false),
            3680 => new FireBlock(Identifier, 15, false, false, true, false, true),
            3681 => new FireBlock(Identifier, 15, false, false, true, false, false),
            3682 => new FireBlock(Identifier, 15, false, false, false, true, true),
            3683 => new FireBlock(Identifier, 15, false, false, false, true, false),
            3684 => new FireBlock(Identifier, 15, false, false, false, false, true),
            3685 => new FireBlock(Identifier, 15, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.ChildrenMap.ContainsKey("age") ? int.Parse(properties["age"].GetString()) : Age,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("age", Age.ToString()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
