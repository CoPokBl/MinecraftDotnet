using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedstoneWireBlock(Identifier Identifier, RedstoneWireConnection East, RedstoneWireConnection North, int Power, RedstoneWireConnection South, RedstoneWireConnection West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                RedstoneWireConnection.Up => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3042,
                                RedstoneWireConnection.Side => 3043,
                                RedstoneWireConnection.None => 3044,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3045,
                                RedstoneWireConnection.Side => 3046,
                                RedstoneWireConnection.None => 3047,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3048,
                                RedstoneWireConnection.Side => 3049,
                                RedstoneWireConnection.None => 3050,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3051,
                                RedstoneWireConnection.Side => 3052,
                                RedstoneWireConnection.None => 3053,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3054,
                                RedstoneWireConnection.Side => 3055,
                                RedstoneWireConnection.None => 3056,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3057,
                                RedstoneWireConnection.Side => 3058,
                                RedstoneWireConnection.None => 3059,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3060,
                                RedstoneWireConnection.Side => 3061,
                                RedstoneWireConnection.None => 3062,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3063,
                                RedstoneWireConnection.Side => 3064,
                                RedstoneWireConnection.None => 3065,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3066,
                                RedstoneWireConnection.Side => 3067,
                                RedstoneWireConnection.None => 3068,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3069,
                                RedstoneWireConnection.Side => 3070,
                                RedstoneWireConnection.None => 3071,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3072,
                                RedstoneWireConnection.Side => 3073,
                                RedstoneWireConnection.None => 3074,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3075,
                                RedstoneWireConnection.Side => 3076,
                                RedstoneWireConnection.None => 3077,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3078,
                                RedstoneWireConnection.Side => 3079,
                                RedstoneWireConnection.None => 3080,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3081,
                                RedstoneWireConnection.Side => 3082,
                                RedstoneWireConnection.None => 3083,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3084,
                                RedstoneWireConnection.Side => 3085,
                                RedstoneWireConnection.None => 3086,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3087,
                                RedstoneWireConnection.Side => 3088,
                                RedstoneWireConnection.None => 3089,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3090,
                                RedstoneWireConnection.Side => 3091,
                                RedstoneWireConnection.None => 3092,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3093,
                                RedstoneWireConnection.Side => 3094,
                                RedstoneWireConnection.None => 3095,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3096,
                                RedstoneWireConnection.Side => 3097,
                                RedstoneWireConnection.None => 3098,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3099,
                                RedstoneWireConnection.Side => 3100,
                                RedstoneWireConnection.None => 3101,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3102,
                                RedstoneWireConnection.Side => 3103,
                                RedstoneWireConnection.None => 3104,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3105,
                                RedstoneWireConnection.Side => 3106,
                                RedstoneWireConnection.None => 3107,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3108,
                                RedstoneWireConnection.Side => 3109,
                                RedstoneWireConnection.None => 3110,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3111,
                                RedstoneWireConnection.Side => 3112,
                                RedstoneWireConnection.None => 3113,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3114,
                                RedstoneWireConnection.Side => 3115,
                                RedstoneWireConnection.None => 3116,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3117,
                                RedstoneWireConnection.Side => 3118,
                                RedstoneWireConnection.None => 3119,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3120,
                                RedstoneWireConnection.Side => 3121,
                                RedstoneWireConnection.None => 3122,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3123,
                                RedstoneWireConnection.Side => 3124,
                                RedstoneWireConnection.None => 3125,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3126,
                                RedstoneWireConnection.Side => 3127,
                                RedstoneWireConnection.None => 3128,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3129,
                                RedstoneWireConnection.Side => 3130,
                                RedstoneWireConnection.None => 3131,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3132,
                                RedstoneWireConnection.Side => 3133,
                                RedstoneWireConnection.None => 3134,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3135,
                                RedstoneWireConnection.Side => 3136,
                                RedstoneWireConnection.None => 3137,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3138,
                                RedstoneWireConnection.Side => 3139,
                                RedstoneWireConnection.None => 3140,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3141,
                                RedstoneWireConnection.Side => 3142,
                                RedstoneWireConnection.None => 3143,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3144,
                                RedstoneWireConnection.Side => 3145,
                                RedstoneWireConnection.None => 3146,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3147,
                                RedstoneWireConnection.Side => 3148,
                                RedstoneWireConnection.None => 3149,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3150,
                                RedstoneWireConnection.Side => 3151,
                                RedstoneWireConnection.None => 3152,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3153,
                                RedstoneWireConnection.Side => 3154,
                                RedstoneWireConnection.None => 3155,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3156,
                                RedstoneWireConnection.Side => 3157,
                                RedstoneWireConnection.None => 3158,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3159,
                                RedstoneWireConnection.Side => 3160,
                                RedstoneWireConnection.None => 3161,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3162,
                                RedstoneWireConnection.Side => 3163,
                                RedstoneWireConnection.None => 3164,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3165,
                                RedstoneWireConnection.Side => 3166,
                                RedstoneWireConnection.None => 3167,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3168,
                                RedstoneWireConnection.Side => 3169,
                                RedstoneWireConnection.None => 3170,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3171,
                                RedstoneWireConnection.Side => 3172,
                                RedstoneWireConnection.None => 3173,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3174,
                                RedstoneWireConnection.Side => 3175,
                                RedstoneWireConnection.None => 3176,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3177,
                                RedstoneWireConnection.Side => 3178,
                                RedstoneWireConnection.None => 3179,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3180,
                                RedstoneWireConnection.Side => 3181,
                                RedstoneWireConnection.None => 3182,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3183,
                                RedstoneWireConnection.Side => 3184,
                                RedstoneWireConnection.None => 3185,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3186,
                                RedstoneWireConnection.Side => 3187,
                                RedstoneWireConnection.None => 3188,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3189,
                                RedstoneWireConnection.Side => 3190,
                                RedstoneWireConnection.None => 3191,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3192,
                                RedstoneWireConnection.Side => 3193,
                                RedstoneWireConnection.None => 3194,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3195,
                                RedstoneWireConnection.Side => 3196,
                                RedstoneWireConnection.None => 3197,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3198,
                                RedstoneWireConnection.Side => 3199,
                                RedstoneWireConnection.None => 3200,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3201,
                                RedstoneWireConnection.Side => 3202,
                                RedstoneWireConnection.None => 3203,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3204,
                                RedstoneWireConnection.Side => 3205,
                                RedstoneWireConnection.None => 3206,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3207,
                                RedstoneWireConnection.Side => 3208,
                                RedstoneWireConnection.None => 3209,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3210,
                                RedstoneWireConnection.Side => 3211,
                                RedstoneWireConnection.None => 3212,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3213,
                                RedstoneWireConnection.Side => 3214,
                                RedstoneWireConnection.None => 3215,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3216,
                                RedstoneWireConnection.Side => 3217,
                                RedstoneWireConnection.None => 3218,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3219,
                                RedstoneWireConnection.Side => 3220,
                                RedstoneWireConnection.None => 3221,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3222,
                                RedstoneWireConnection.Side => 3223,
                                RedstoneWireConnection.None => 3224,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3225,
                                RedstoneWireConnection.Side => 3226,
                                RedstoneWireConnection.None => 3227,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3228,
                                RedstoneWireConnection.Side => 3229,
                                RedstoneWireConnection.None => 3230,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3231,
                                RedstoneWireConnection.Side => 3232,
                                RedstoneWireConnection.None => 3233,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3234,
                                RedstoneWireConnection.Side => 3235,
                                RedstoneWireConnection.None => 3236,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3237,
                                RedstoneWireConnection.Side => 3238,
                                RedstoneWireConnection.None => 3239,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3240,
                                RedstoneWireConnection.Side => 3241,
                                RedstoneWireConnection.None => 3242,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3243,
                                RedstoneWireConnection.Side => 3244,
                                RedstoneWireConnection.None => 3245,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3246,
                                RedstoneWireConnection.Side => 3247,
                                RedstoneWireConnection.None => 3248,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3249,
                                RedstoneWireConnection.Side => 3250,
                                RedstoneWireConnection.None => 3251,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3252,
                                RedstoneWireConnection.Side => 3253,
                                RedstoneWireConnection.None => 3254,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3255,
                                RedstoneWireConnection.Side => 3256,
                                RedstoneWireConnection.None => 3257,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3258,
                                RedstoneWireConnection.Side => 3259,
                                RedstoneWireConnection.None => 3260,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3261,
                                RedstoneWireConnection.Side => 3262,
                                RedstoneWireConnection.None => 3263,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3264,
                                RedstoneWireConnection.Side => 3265,
                                RedstoneWireConnection.None => 3266,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3267,
                                RedstoneWireConnection.Side => 3268,
                                RedstoneWireConnection.None => 3269,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3270,
                                RedstoneWireConnection.Side => 3271,
                                RedstoneWireConnection.None => 3272,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3273,
                                RedstoneWireConnection.Side => 3274,
                                RedstoneWireConnection.None => 3275,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3276,
                                RedstoneWireConnection.Side => 3277,
                                RedstoneWireConnection.None => 3278,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3279,
                                RedstoneWireConnection.Side => 3280,
                                RedstoneWireConnection.None => 3281,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3282,
                                RedstoneWireConnection.Side => 3283,
                                RedstoneWireConnection.None => 3284,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3285,
                                RedstoneWireConnection.Side => 3286,
                                RedstoneWireConnection.None => 3287,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3288,
                                RedstoneWireConnection.Side => 3289,
                                RedstoneWireConnection.None => 3290,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3291,
                                RedstoneWireConnection.Side => 3292,
                                RedstoneWireConnection.None => 3293,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3294,
                                RedstoneWireConnection.Side => 3295,
                                RedstoneWireConnection.None => 3296,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3297,
                                RedstoneWireConnection.Side => 3298,
                                RedstoneWireConnection.None => 3299,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3300,
                                RedstoneWireConnection.Side => 3301,
                                RedstoneWireConnection.None => 3302,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3303,
                                RedstoneWireConnection.Side => 3304,
                                RedstoneWireConnection.None => 3305,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3306,
                                RedstoneWireConnection.Side => 3307,
                                RedstoneWireConnection.None => 3308,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3309,
                                RedstoneWireConnection.Side => 3310,
                                RedstoneWireConnection.None => 3311,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3312,
                                RedstoneWireConnection.Side => 3313,
                                RedstoneWireConnection.None => 3314,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3315,
                                RedstoneWireConnection.Side => 3316,
                                RedstoneWireConnection.None => 3317,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3318,
                                RedstoneWireConnection.Side => 3319,
                                RedstoneWireConnection.None => 3320,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3321,
                                RedstoneWireConnection.Side => 3322,
                                RedstoneWireConnection.None => 3323,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3324,
                                RedstoneWireConnection.Side => 3325,
                                RedstoneWireConnection.None => 3326,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3327,
                                RedstoneWireConnection.Side => 3328,
                                RedstoneWireConnection.None => 3329,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3330,
                                RedstoneWireConnection.Side => 3331,
                                RedstoneWireConnection.None => 3332,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3333,
                                RedstoneWireConnection.Side => 3334,
                                RedstoneWireConnection.None => 3335,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3336,
                                RedstoneWireConnection.Side => 3337,
                                RedstoneWireConnection.None => 3338,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3339,
                                RedstoneWireConnection.Side => 3340,
                                RedstoneWireConnection.None => 3341,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3342,
                                RedstoneWireConnection.Side => 3343,
                                RedstoneWireConnection.None => 3344,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3345,
                                RedstoneWireConnection.Side => 3346,
                                RedstoneWireConnection.None => 3347,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3348,
                                RedstoneWireConnection.Side => 3349,
                                RedstoneWireConnection.None => 3350,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3351,
                                RedstoneWireConnection.Side => 3352,
                                RedstoneWireConnection.None => 3353,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3354,
                                RedstoneWireConnection.Side => 3355,
                                RedstoneWireConnection.None => 3356,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3357,
                                RedstoneWireConnection.Side => 3358,
                                RedstoneWireConnection.None => 3359,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3360,
                                RedstoneWireConnection.Side => 3361,
                                RedstoneWireConnection.None => 3362,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3363,
                                RedstoneWireConnection.Side => 3364,
                                RedstoneWireConnection.None => 3365,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3366,
                                RedstoneWireConnection.Side => 3367,
                                RedstoneWireConnection.None => 3368,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3369,
                                RedstoneWireConnection.Side => 3370,
                                RedstoneWireConnection.None => 3371,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3372,
                                RedstoneWireConnection.Side => 3373,
                                RedstoneWireConnection.None => 3374,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3375,
                                RedstoneWireConnection.Side => 3376,
                                RedstoneWireConnection.None => 3377,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3378,
                                RedstoneWireConnection.Side => 3379,
                                RedstoneWireConnection.None => 3380,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3381,
                                RedstoneWireConnection.Side => 3382,
                                RedstoneWireConnection.None => 3383,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3384,
                                RedstoneWireConnection.Side => 3385,
                                RedstoneWireConnection.None => 3386,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3387,
                                RedstoneWireConnection.Side => 3388,
                                RedstoneWireConnection.None => 3389,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3390,
                                RedstoneWireConnection.Side => 3391,
                                RedstoneWireConnection.None => 3392,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3393,
                                RedstoneWireConnection.Side => 3394,
                                RedstoneWireConnection.None => 3395,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3396,
                                RedstoneWireConnection.Side => 3397,
                                RedstoneWireConnection.None => 3398,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3399,
                                RedstoneWireConnection.Side => 3400,
                                RedstoneWireConnection.None => 3401,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3402,
                                RedstoneWireConnection.Side => 3403,
                                RedstoneWireConnection.None => 3404,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3405,
                                RedstoneWireConnection.Side => 3406,
                                RedstoneWireConnection.None => 3407,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3408,
                                RedstoneWireConnection.Side => 3409,
                                RedstoneWireConnection.None => 3410,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3411,
                                RedstoneWireConnection.Side => 3412,
                                RedstoneWireConnection.None => 3413,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3414,
                                RedstoneWireConnection.Side => 3415,
                                RedstoneWireConnection.None => 3416,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3417,
                                RedstoneWireConnection.Side => 3418,
                                RedstoneWireConnection.None => 3419,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3420,
                                RedstoneWireConnection.Side => 3421,
                                RedstoneWireConnection.None => 3422,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3423,
                                RedstoneWireConnection.Side => 3424,
                                RedstoneWireConnection.None => 3425,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3426,
                                RedstoneWireConnection.Side => 3427,
                                RedstoneWireConnection.None => 3428,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3429,
                                RedstoneWireConnection.Side => 3430,
                                RedstoneWireConnection.None => 3431,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3432,
                                RedstoneWireConnection.Side => 3433,
                                RedstoneWireConnection.None => 3434,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3435,
                                RedstoneWireConnection.Side => 3436,
                                RedstoneWireConnection.None => 3437,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3438,
                                RedstoneWireConnection.Side => 3439,
                                RedstoneWireConnection.None => 3440,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3441,
                                RedstoneWireConnection.Side => 3442,
                                RedstoneWireConnection.None => 3443,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3444,
                                RedstoneWireConnection.Side => 3445,
                                RedstoneWireConnection.None => 3446,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3447,
                                RedstoneWireConnection.Side => 3448,
                                RedstoneWireConnection.None => 3449,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3450,
                                RedstoneWireConnection.Side => 3451,
                                RedstoneWireConnection.None => 3452,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3453,
                                RedstoneWireConnection.Side => 3454,
                                RedstoneWireConnection.None => 3455,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3456,
                                RedstoneWireConnection.Side => 3457,
                                RedstoneWireConnection.None => 3458,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3459,
                                RedstoneWireConnection.Side => 3460,
                                RedstoneWireConnection.None => 3461,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3462,
                                RedstoneWireConnection.Side => 3463,
                                RedstoneWireConnection.None => 3464,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3465,
                                RedstoneWireConnection.Side => 3466,
                                RedstoneWireConnection.None => 3467,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3468,
                                RedstoneWireConnection.Side => 3469,
                                RedstoneWireConnection.None => 3470,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3471,
                                RedstoneWireConnection.Side => 3472,
                                RedstoneWireConnection.None => 3473,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                RedstoneWireConnection.Side => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3474,
                                RedstoneWireConnection.Side => 3475,
                                RedstoneWireConnection.None => 3476,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3477,
                                RedstoneWireConnection.Side => 3478,
                                RedstoneWireConnection.None => 3479,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3480,
                                RedstoneWireConnection.Side => 3481,
                                RedstoneWireConnection.None => 3482,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3483,
                                RedstoneWireConnection.Side => 3484,
                                RedstoneWireConnection.None => 3485,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3486,
                                RedstoneWireConnection.Side => 3487,
                                RedstoneWireConnection.None => 3488,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3489,
                                RedstoneWireConnection.Side => 3490,
                                RedstoneWireConnection.None => 3491,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3492,
                                RedstoneWireConnection.Side => 3493,
                                RedstoneWireConnection.None => 3494,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3495,
                                RedstoneWireConnection.Side => 3496,
                                RedstoneWireConnection.None => 3497,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3498,
                                RedstoneWireConnection.Side => 3499,
                                RedstoneWireConnection.None => 3500,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3501,
                                RedstoneWireConnection.Side => 3502,
                                RedstoneWireConnection.None => 3503,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3504,
                                RedstoneWireConnection.Side => 3505,
                                RedstoneWireConnection.None => 3506,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3507,
                                RedstoneWireConnection.Side => 3508,
                                RedstoneWireConnection.None => 3509,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3510,
                                RedstoneWireConnection.Side => 3511,
                                RedstoneWireConnection.None => 3512,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3513,
                                RedstoneWireConnection.Side => 3514,
                                RedstoneWireConnection.None => 3515,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3516,
                                RedstoneWireConnection.Side => 3517,
                                RedstoneWireConnection.None => 3518,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3519,
                                RedstoneWireConnection.Side => 3520,
                                RedstoneWireConnection.None => 3521,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3522,
                                RedstoneWireConnection.Side => 3523,
                                RedstoneWireConnection.None => 3524,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3525,
                                RedstoneWireConnection.Side => 3526,
                                RedstoneWireConnection.None => 3527,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3528,
                                RedstoneWireConnection.Side => 3529,
                                RedstoneWireConnection.None => 3530,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3531,
                                RedstoneWireConnection.Side => 3532,
                                RedstoneWireConnection.None => 3533,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3534,
                                RedstoneWireConnection.Side => 3535,
                                RedstoneWireConnection.None => 3536,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3537,
                                RedstoneWireConnection.Side => 3538,
                                RedstoneWireConnection.None => 3539,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3540,
                                RedstoneWireConnection.Side => 3541,
                                RedstoneWireConnection.None => 3542,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3543,
                                RedstoneWireConnection.Side => 3544,
                                RedstoneWireConnection.None => 3545,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3546,
                                RedstoneWireConnection.Side => 3547,
                                RedstoneWireConnection.None => 3548,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3549,
                                RedstoneWireConnection.Side => 3550,
                                RedstoneWireConnection.None => 3551,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3552,
                                RedstoneWireConnection.Side => 3553,
                                RedstoneWireConnection.None => 3554,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3555,
                                RedstoneWireConnection.Side => 3556,
                                RedstoneWireConnection.None => 3557,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3558,
                                RedstoneWireConnection.Side => 3559,
                                RedstoneWireConnection.None => 3560,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3561,
                                RedstoneWireConnection.Side => 3562,
                                RedstoneWireConnection.None => 3563,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3564,
                                RedstoneWireConnection.Side => 3565,
                                RedstoneWireConnection.None => 3566,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3567,
                                RedstoneWireConnection.Side => 3568,
                                RedstoneWireConnection.None => 3569,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3570,
                                RedstoneWireConnection.Side => 3571,
                                RedstoneWireConnection.None => 3572,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3573,
                                RedstoneWireConnection.Side => 3574,
                                RedstoneWireConnection.None => 3575,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3576,
                                RedstoneWireConnection.Side => 3577,
                                RedstoneWireConnection.None => 3578,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3579,
                                RedstoneWireConnection.Side => 3580,
                                RedstoneWireConnection.None => 3581,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3582,
                                RedstoneWireConnection.Side => 3583,
                                RedstoneWireConnection.None => 3584,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3585,
                                RedstoneWireConnection.Side => 3586,
                                RedstoneWireConnection.None => 3587,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3588,
                                RedstoneWireConnection.Side => 3589,
                                RedstoneWireConnection.None => 3590,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3591,
                                RedstoneWireConnection.Side => 3592,
                                RedstoneWireConnection.None => 3593,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3594,
                                RedstoneWireConnection.Side => 3595,
                                RedstoneWireConnection.None => 3596,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3597,
                                RedstoneWireConnection.Side => 3598,
                                RedstoneWireConnection.None => 3599,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3600,
                                RedstoneWireConnection.Side => 3601,
                                RedstoneWireConnection.None => 3602,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3603,
                                RedstoneWireConnection.Side => 3604,
                                RedstoneWireConnection.None => 3605,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3606,
                                RedstoneWireConnection.Side => 3607,
                                RedstoneWireConnection.None => 3608,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3609,
                                RedstoneWireConnection.Side => 3610,
                                RedstoneWireConnection.None => 3611,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3612,
                                RedstoneWireConnection.Side => 3613,
                                RedstoneWireConnection.None => 3614,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3615,
                                RedstoneWireConnection.Side => 3616,
                                RedstoneWireConnection.None => 3617,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3618,
                                RedstoneWireConnection.Side => 3619,
                                RedstoneWireConnection.None => 3620,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3621,
                                RedstoneWireConnection.Side => 3622,
                                RedstoneWireConnection.None => 3623,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3624,
                                RedstoneWireConnection.Side => 3625,
                                RedstoneWireConnection.None => 3626,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3627,
                                RedstoneWireConnection.Side => 3628,
                                RedstoneWireConnection.None => 3629,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3630,
                                RedstoneWireConnection.Side => 3631,
                                RedstoneWireConnection.None => 3632,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3633,
                                RedstoneWireConnection.Side => 3634,
                                RedstoneWireConnection.None => 3635,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3636,
                                RedstoneWireConnection.Side => 3637,
                                RedstoneWireConnection.None => 3638,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3639,
                                RedstoneWireConnection.Side => 3640,
                                RedstoneWireConnection.None => 3641,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3642,
                                RedstoneWireConnection.Side => 3643,
                                RedstoneWireConnection.None => 3644,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3645,
                                RedstoneWireConnection.Side => 3646,
                                RedstoneWireConnection.None => 3647,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3648,
                                RedstoneWireConnection.Side => 3649,
                                RedstoneWireConnection.None => 3650,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3651,
                                RedstoneWireConnection.Side => 3652,
                                RedstoneWireConnection.None => 3653,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3654,
                                RedstoneWireConnection.Side => 3655,
                                RedstoneWireConnection.None => 3656,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3657,
                                RedstoneWireConnection.Side => 3658,
                                RedstoneWireConnection.None => 3659,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3660,
                                RedstoneWireConnection.Side => 3661,
                                RedstoneWireConnection.None => 3662,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3663,
                                RedstoneWireConnection.Side => 3664,
                                RedstoneWireConnection.None => 3665,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3666,
                                RedstoneWireConnection.Side => 3667,
                                RedstoneWireConnection.None => 3668,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3669,
                                RedstoneWireConnection.Side => 3670,
                                RedstoneWireConnection.None => 3671,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3672,
                                RedstoneWireConnection.Side => 3673,
                                RedstoneWireConnection.None => 3674,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3675,
                                RedstoneWireConnection.Side => 3676,
                                RedstoneWireConnection.None => 3677,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3678,
                                RedstoneWireConnection.Side => 3679,
                                RedstoneWireConnection.None => 3680,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3681,
                                RedstoneWireConnection.Side => 3682,
                                RedstoneWireConnection.None => 3683,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3684,
                                RedstoneWireConnection.Side => 3685,
                                RedstoneWireConnection.None => 3686,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3687,
                                RedstoneWireConnection.Side => 3688,
                                RedstoneWireConnection.None => 3689,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3690,
                                RedstoneWireConnection.Side => 3691,
                                RedstoneWireConnection.None => 3692,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3693,
                                RedstoneWireConnection.Side => 3694,
                                RedstoneWireConnection.None => 3695,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3696,
                                RedstoneWireConnection.Side => 3697,
                                RedstoneWireConnection.None => 3698,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3699,
                                RedstoneWireConnection.Side => 3700,
                                RedstoneWireConnection.None => 3701,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3702,
                                RedstoneWireConnection.Side => 3703,
                                RedstoneWireConnection.None => 3704,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3705,
                                RedstoneWireConnection.Side => 3706,
                                RedstoneWireConnection.None => 3707,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3708,
                                RedstoneWireConnection.Side => 3709,
                                RedstoneWireConnection.None => 3710,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3711,
                                RedstoneWireConnection.Side => 3712,
                                RedstoneWireConnection.None => 3713,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3714,
                                RedstoneWireConnection.Side => 3715,
                                RedstoneWireConnection.None => 3716,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3717,
                                RedstoneWireConnection.Side => 3718,
                                RedstoneWireConnection.None => 3719,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3720,
                                RedstoneWireConnection.Side => 3721,
                                RedstoneWireConnection.None => 3722,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3723,
                                RedstoneWireConnection.Side => 3724,
                                RedstoneWireConnection.None => 3725,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3726,
                                RedstoneWireConnection.Side => 3727,
                                RedstoneWireConnection.None => 3728,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3729,
                                RedstoneWireConnection.Side => 3730,
                                RedstoneWireConnection.None => 3731,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3732,
                                RedstoneWireConnection.Side => 3733,
                                RedstoneWireConnection.None => 3734,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3735,
                                RedstoneWireConnection.Side => 3736,
                                RedstoneWireConnection.None => 3737,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3738,
                                RedstoneWireConnection.Side => 3739,
                                RedstoneWireConnection.None => 3740,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3741,
                                RedstoneWireConnection.Side => 3742,
                                RedstoneWireConnection.None => 3743,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3744,
                                RedstoneWireConnection.Side => 3745,
                                RedstoneWireConnection.None => 3746,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3747,
                                RedstoneWireConnection.Side => 3748,
                                RedstoneWireConnection.None => 3749,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3750,
                                RedstoneWireConnection.Side => 3751,
                                RedstoneWireConnection.None => 3752,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3753,
                                RedstoneWireConnection.Side => 3754,
                                RedstoneWireConnection.None => 3755,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3756,
                                RedstoneWireConnection.Side => 3757,
                                RedstoneWireConnection.None => 3758,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3759,
                                RedstoneWireConnection.Side => 3760,
                                RedstoneWireConnection.None => 3761,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3762,
                                RedstoneWireConnection.Side => 3763,
                                RedstoneWireConnection.None => 3764,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3765,
                                RedstoneWireConnection.Side => 3766,
                                RedstoneWireConnection.None => 3767,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3768,
                                RedstoneWireConnection.Side => 3769,
                                RedstoneWireConnection.None => 3770,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3771,
                                RedstoneWireConnection.Side => 3772,
                                RedstoneWireConnection.None => 3773,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3774,
                                RedstoneWireConnection.Side => 3775,
                                RedstoneWireConnection.None => 3776,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3777,
                                RedstoneWireConnection.Side => 3778,
                                RedstoneWireConnection.None => 3779,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3780,
                                RedstoneWireConnection.Side => 3781,
                                RedstoneWireConnection.None => 3782,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3783,
                                RedstoneWireConnection.Side => 3784,
                                RedstoneWireConnection.None => 3785,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3786,
                                RedstoneWireConnection.Side => 3787,
                                RedstoneWireConnection.None => 3788,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3789,
                                RedstoneWireConnection.Side => 3790,
                                RedstoneWireConnection.None => 3791,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3792,
                                RedstoneWireConnection.Side => 3793,
                                RedstoneWireConnection.None => 3794,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3795,
                                RedstoneWireConnection.Side => 3796,
                                RedstoneWireConnection.None => 3797,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3798,
                                RedstoneWireConnection.Side => 3799,
                                RedstoneWireConnection.None => 3800,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3801,
                                RedstoneWireConnection.Side => 3802,
                                RedstoneWireConnection.None => 3803,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3804,
                                RedstoneWireConnection.Side => 3805,
                                RedstoneWireConnection.None => 3806,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3807,
                                RedstoneWireConnection.Side => 3808,
                                RedstoneWireConnection.None => 3809,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3810,
                                RedstoneWireConnection.Side => 3811,
                                RedstoneWireConnection.None => 3812,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3813,
                                RedstoneWireConnection.Side => 3814,
                                RedstoneWireConnection.None => 3815,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3816,
                                RedstoneWireConnection.Side => 3817,
                                RedstoneWireConnection.None => 3818,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3819,
                                RedstoneWireConnection.Side => 3820,
                                RedstoneWireConnection.None => 3821,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3822,
                                RedstoneWireConnection.Side => 3823,
                                RedstoneWireConnection.None => 3824,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3825,
                                RedstoneWireConnection.Side => 3826,
                                RedstoneWireConnection.None => 3827,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3828,
                                RedstoneWireConnection.Side => 3829,
                                RedstoneWireConnection.None => 3830,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3831,
                                RedstoneWireConnection.Side => 3832,
                                RedstoneWireConnection.None => 3833,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3834,
                                RedstoneWireConnection.Side => 3835,
                                RedstoneWireConnection.None => 3836,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3837,
                                RedstoneWireConnection.Side => 3838,
                                RedstoneWireConnection.None => 3839,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3840,
                                RedstoneWireConnection.Side => 3841,
                                RedstoneWireConnection.None => 3842,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3843,
                                RedstoneWireConnection.Side => 3844,
                                RedstoneWireConnection.None => 3845,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3846,
                                RedstoneWireConnection.Side => 3847,
                                RedstoneWireConnection.None => 3848,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3849,
                                RedstoneWireConnection.Side => 3850,
                                RedstoneWireConnection.None => 3851,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3852,
                                RedstoneWireConnection.Side => 3853,
                                RedstoneWireConnection.None => 3854,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3855,
                                RedstoneWireConnection.Side => 3856,
                                RedstoneWireConnection.None => 3857,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3858,
                                RedstoneWireConnection.Side => 3859,
                                RedstoneWireConnection.None => 3860,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3861,
                                RedstoneWireConnection.Side => 3862,
                                RedstoneWireConnection.None => 3863,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3864,
                                RedstoneWireConnection.Side => 3865,
                                RedstoneWireConnection.None => 3866,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3867,
                                RedstoneWireConnection.Side => 3868,
                                RedstoneWireConnection.None => 3869,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3870,
                                RedstoneWireConnection.Side => 3871,
                                RedstoneWireConnection.None => 3872,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3873,
                                RedstoneWireConnection.Side => 3874,
                                RedstoneWireConnection.None => 3875,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3876,
                                RedstoneWireConnection.Side => 3877,
                                RedstoneWireConnection.None => 3878,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3879,
                                RedstoneWireConnection.Side => 3880,
                                RedstoneWireConnection.None => 3881,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3882,
                                RedstoneWireConnection.Side => 3883,
                                RedstoneWireConnection.None => 3884,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3885,
                                RedstoneWireConnection.Side => 3886,
                                RedstoneWireConnection.None => 3887,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3888,
                                RedstoneWireConnection.Side => 3889,
                                RedstoneWireConnection.None => 3890,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3891,
                                RedstoneWireConnection.Side => 3892,
                                RedstoneWireConnection.None => 3893,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3894,
                                RedstoneWireConnection.Side => 3895,
                                RedstoneWireConnection.None => 3896,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3897,
                                RedstoneWireConnection.Side => 3898,
                                RedstoneWireConnection.None => 3899,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3900,
                                RedstoneWireConnection.Side => 3901,
                                RedstoneWireConnection.None => 3902,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3903,
                                RedstoneWireConnection.Side => 3904,
                                RedstoneWireConnection.None => 3905,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                RedstoneWireConnection.None => North switch {
                    RedstoneWireConnection.Up => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3906,
                                RedstoneWireConnection.Side => 3907,
                                RedstoneWireConnection.None => 3908,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3909,
                                RedstoneWireConnection.Side => 3910,
                                RedstoneWireConnection.None => 3911,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3912,
                                RedstoneWireConnection.Side => 3913,
                                RedstoneWireConnection.None => 3914,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3915,
                                RedstoneWireConnection.Side => 3916,
                                RedstoneWireConnection.None => 3917,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3918,
                                RedstoneWireConnection.Side => 3919,
                                RedstoneWireConnection.None => 3920,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3921,
                                RedstoneWireConnection.Side => 3922,
                                RedstoneWireConnection.None => 3923,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3924,
                                RedstoneWireConnection.Side => 3925,
                                RedstoneWireConnection.None => 3926,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3927,
                                RedstoneWireConnection.Side => 3928,
                                RedstoneWireConnection.None => 3929,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3930,
                                RedstoneWireConnection.Side => 3931,
                                RedstoneWireConnection.None => 3932,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3933,
                                RedstoneWireConnection.Side => 3934,
                                RedstoneWireConnection.None => 3935,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3936,
                                RedstoneWireConnection.Side => 3937,
                                RedstoneWireConnection.None => 3938,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3939,
                                RedstoneWireConnection.Side => 3940,
                                RedstoneWireConnection.None => 3941,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3942,
                                RedstoneWireConnection.Side => 3943,
                                RedstoneWireConnection.None => 3944,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3945,
                                RedstoneWireConnection.Side => 3946,
                                RedstoneWireConnection.None => 3947,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3948,
                                RedstoneWireConnection.Side => 3949,
                                RedstoneWireConnection.None => 3950,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3951,
                                RedstoneWireConnection.Side => 3952,
                                RedstoneWireConnection.None => 3953,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3954,
                                RedstoneWireConnection.Side => 3955,
                                RedstoneWireConnection.None => 3956,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3957,
                                RedstoneWireConnection.Side => 3958,
                                RedstoneWireConnection.None => 3959,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3960,
                                RedstoneWireConnection.Side => 3961,
                                RedstoneWireConnection.None => 3962,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3963,
                                RedstoneWireConnection.Side => 3964,
                                RedstoneWireConnection.None => 3965,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3966,
                                RedstoneWireConnection.Side => 3967,
                                RedstoneWireConnection.None => 3968,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3969,
                                RedstoneWireConnection.Side => 3970,
                                RedstoneWireConnection.None => 3971,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3972,
                                RedstoneWireConnection.Side => 3973,
                                RedstoneWireConnection.None => 3974,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3975,
                                RedstoneWireConnection.Side => 3976,
                                RedstoneWireConnection.None => 3977,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3978,
                                RedstoneWireConnection.Side => 3979,
                                RedstoneWireConnection.None => 3980,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3981,
                                RedstoneWireConnection.Side => 3982,
                                RedstoneWireConnection.None => 3983,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3984,
                                RedstoneWireConnection.Side => 3985,
                                RedstoneWireConnection.None => 3986,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3987,
                                RedstoneWireConnection.Side => 3988,
                                RedstoneWireConnection.None => 3989,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3990,
                                RedstoneWireConnection.Side => 3991,
                                RedstoneWireConnection.None => 3992,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 3993,
                                RedstoneWireConnection.Side => 3994,
                                RedstoneWireConnection.None => 3995,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 3996,
                                RedstoneWireConnection.Side => 3997,
                                RedstoneWireConnection.None => 3998,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 3999,
                                RedstoneWireConnection.Side => 4000,
                                RedstoneWireConnection.None => 4001,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4002,
                                RedstoneWireConnection.Side => 4003,
                                RedstoneWireConnection.None => 4004,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4005,
                                RedstoneWireConnection.Side => 4006,
                                RedstoneWireConnection.None => 4007,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4008,
                                RedstoneWireConnection.Side => 4009,
                                RedstoneWireConnection.None => 4010,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4011,
                                RedstoneWireConnection.Side => 4012,
                                RedstoneWireConnection.None => 4013,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4014,
                                RedstoneWireConnection.Side => 4015,
                                RedstoneWireConnection.None => 4016,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4017,
                                RedstoneWireConnection.Side => 4018,
                                RedstoneWireConnection.None => 4019,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4020,
                                RedstoneWireConnection.Side => 4021,
                                RedstoneWireConnection.None => 4022,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4023,
                                RedstoneWireConnection.Side => 4024,
                                RedstoneWireConnection.None => 4025,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4026,
                                RedstoneWireConnection.Side => 4027,
                                RedstoneWireConnection.None => 4028,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4029,
                                RedstoneWireConnection.Side => 4030,
                                RedstoneWireConnection.None => 4031,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4032,
                                RedstoneWireConnection.Side => 4033,
                                RedstoneWireConnection.None => 4034,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4035,
                                RedstoneWireConnection.Side => 4036,
                                RedstoneWireConnection.None => 4037,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4038,
                                RedstoneWireConnection.Side => 4039,
                                RedstoneWireConnection.None => 4040,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4041,
                                RedstoneWireConnection.Side => 4042,
                                RedstoneWireConnection.None => 4043,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4044,
                                RedstoneWireConnection.Side => 4045,
                                RedstoneWireConnection.None => 4046,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4047,
                                RedstoneWireConnection.Side => 4048,
                                RedstoneWireConnection.None => 4049,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.Side => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4050,
                                RedstoneWireConnection.Side => 4051,
                                RedstoneWireConnection.None => 4052,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4053,
                                RedstoneWireConnection.Side => 4054,
                                RedstoneWireConnection.None => 4055,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4056,
                                RedstoneWireConnection.Side => 4057,
                                RedstoneWireConnection.None => 4058,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4059,
                                RedstoneWireConnection.Side => 4060,
                                RedstoneWireConnection.None => 4061,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4062,
                                RedstoneWireConnection.Side => 4063,
                                RedstoneWireConnection.None => 4064,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4065,
                                RedstoneWireConnection.Side => 4066,
                                RedstoneWireConnection.None => 4067,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4068,
                                RedstoneWireConnection.Side => 4069,
                                RedstoneWireConnection.None => 4070,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4071,
                                RedstoneWireConnection.Side => 4072,
                                RedstoneWireConnection.None => 4073,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4074,
                                RedstoneWireConnection.Side => 4075,
                                RedstoneWireConnection.None => 4076,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4077,
                                RedstoneWireConnection.Side => 4078,
                                RedstoneWireConnection.None => 4079,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4080,
                                RedstoneWireConnection.Side => 4081,
                                RedstoneWireConnection.None => 4082,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4083,
                                RedstoneWireConnection.Side => 4084,
                                RedstoneWireConnection.None => 4085,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4086,
                                RedstoneWireConnection.Side => 4087,
                                RedstoneWireConnection.None => 4088,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4089,
                                RedstoneWireConnection.Side => 4090,
                                RedstoneWireConnection.None => 4091,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4092,
                                RedstoneWireConnection.Side => 4093,
                                RedstoneWireConnection.None => 4094,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4095,
                                RedstoneWireConnection.Side => 4096,
                                RedstoneWireConnection.None => 4097,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4098,
                                RedstoneWireConnection.Side => 4099,
                                RedstoneWireConnection.None => 4100,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4101,
                                RedstoneWireConnection.Side => 4102,
                                RedstoneWireConnection.None => 4103,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4104,
                                RedstoneWireConnection.Side => 4105,
                                RedstoneWireConnection.None => 4106,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4107,
                                RedstoneWireConnection.Side => 4108,
                                RedstoneWireConnection.None => 4109,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4110,
                                RedstoneWireConnection.Side => 4111,
                                RedstoneWireConnection.None => 4112,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4113,
                                RedstoneWireConnection.Side => 4114,
                                RedstoneWireConnection.None => 4115,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4116,
                                RedstoneWireConnection.Side => 4117,
                                RedstoneWireConnection.None => 4118,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4119,
                                RedstoneWireConnection.Side => 4120,
                                RedstoneWireConnection.None => 4121,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4122,
                                RedstoneWireConnection.Side => 4123,
                                RedstoneWireConnection.None => 4124,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4125,
                                RedstoneWireConnection.Side => 4126,
                                RedstoneWireConnection.None => 4127,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4128,
                                RedstoneWireConnection.Side => 4129,
                                RedstoneWireConnection.None => 4130,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4131,
                                RedstoneWireConnection.Side => 4132,
                                RedstoneWireConnection.None => 4133,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4134,
                                RedstoneWireConnection.Side => 4135,
                                RedstoneWireConnection.None => 4136,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4137,
                                RedstoneWireConnection.Side => 4138,
                                RedstoneWireConnection.None => 4139,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4140,
                                RedstoneWireConnection.Side => 4141,
                                RedstoneWireConnection.None => 4142,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4143,
                                RedstoneWireConnection.Side => 4144,
                                RedstoneWireConnection.None => 4145,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4146,
                                RedstoneWireConnection.Side => 4147,
                                RedstoneWireConnection.None => 4148,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4149,
                                RedstoneWireConnection.Side => 4150,
                                RedstoneWireConnection.None => 4151,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4152,
                                RedstoneWireConnection.Side => 4153,
                                RedstoneWireConnection.None => 4154,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4155,
                                RedstoneWireConnection.Side => 4156,
                                RedstoneWireConnection.None => 4157,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4158,
                                RedstoneWireConnection.Side => 4159,
                                RedstoneWireConnection.None => 4160,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4161,
                                RedstoneWireConnection.Side => 4162,
                                RedstoneWireConnection.None => 4163,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4164,
                                RedstoneWireConnection.Side => 4165,
                                RedstoneWireConnection.None => 4166,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4167,
                                RedstoneWireConnection.Side => 4168,
                                RedstoneWireConnection.None => 4169,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4170,
                                RedstoneWireConnection.Side => 4171,
                                RedstoneWireConnection.None => 4172,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4173,
                                RedstoneWireConnection.Side => 4174,
                                RedstoneWireConnection.None => 4175,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4176,
                                RedstoneWireConnection.Side => 4177,
                                RedstoneWireConnection.None => 4178,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4179,
                                RedstoneWireConnection.Side => 4180,
                                RedstoneWireConnection.None => 4181,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4182,
                                RedstoneWireConnection.Side => 4183,
                                RedstoneWireConnection.None => 4184,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4185,
                                RedstoneWireConnection.Side => 4186,
                                RedstoneWireConnection.None => 4187,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4188,
                                RedstoneWireConnection.Side => 4189,
                                RedstoneWireConnection.None => 4190,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4191,
                                RedstoneWireConnection.Side => 4192,
                                RedstoneWireConnection.None => 4193,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    RedstoneWireConnection.None => Power switch {
                        0 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4194,
                                RedstoneWireConnection.Side => 4195,
                                RedstoneWireConnection.None => 4196,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4197,
                                RedstoneWireConnection.Side => 4198,
                                RedstoneWireConnection.None => 4199,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4200,
                                RedstoneWireConnection.Side => 4201,
                                RedstoneWireConnection.None => 4202,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        1 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4203,
                                RedstoneWireConnection.Side => 4204,
                                RedstoneWireConnection.None => 4205,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4206,
                                RedstoneWireConnection.Side => 4207,
                                RedstoneWireConnection.None => 4208,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4209,
                                RedstoneWireConnection.Side => 4210,
                                RedstoneWireConnection.None => 4211,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        2 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4212,
                                RedstoneWireConnection.Side => 4213,
                                RedstoneWireConnection.None => 4214,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4215,
                                RedstoneWireConnection.Side => 4216,
                                RedstoneWireConnection.None => 4217,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4218,
                                RedstoneWireConnection.Side => 4219,
                                RedstoneWireConnection.None => 4220,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        3 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4221,
                                RedstoneWireConnection.Side => 4222,
                                RedstoneWireConnection.None => 4223,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4224,
                                RedstoneWireConnection.Side => 4225,
                                RedstoneWireConnection.None => 4226,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4227,
                                RedstoneWireConnection.Side => 4228,
                                RedstoneWireConnection.None => 4229,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        4 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4230,
                                RedstoneWireConnection.Side => 4231,
                                RedstoneWireConnection.None => 4232,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4233,
                                RedstoneWireConnection.Side => 4234,
                                RedstoneWireConnection.None => 4235,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4236,
                                RedstoneWireConnection.Side => 4237,
                                RedstoneWireConnection.None => 4238,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        5 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4239,
                                RedstoneWireConnection.Side => 4240,
                                RedstoneWireConnection.None => 4241,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4242,
                                RedstoneWireConnection.Side => 4243,
                                RedstoneWireConnection.None => 4244,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4245,
                                RedstoneWireConnection.Side => 4246,
                                RedstoneWireConnection.None => 4247,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        6 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4248,
                                RedstoneWireConnection.Side => 4249,
                                RedstoneWireConnection.None => 4250,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4251,
                                RedstoneWireConnection.Side => 4252,
                                RedstoneWireConnection.None => 4253,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4254,
                                RedstoneWireConnection.Side => 4255,
                                RedstoneWireConnection.None => 4256,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        7 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4257,
                                RedstoneWireConnection.Side => 4258,
                                RedstoneWireConnection.None => 4259,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4260,
                                RedstoneWireConnection.Side => 4261,
                                RedstoneWireConnection.None => 4262,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4263,
                                RedstoneWireConnection.Side => 4264,
                                RedstoneWireConnection.None => 4265,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        8 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4266,
                                RedstoneWireConnection.Side => 4267,
                                RedstoneWireConnection.None => 4268,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4269,
                                RedstoneWireConnection.Side => 4270,
                                RedstoneWireConnection.None => 4271,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4272,
                                RedstoneWireConnection.Side => 4273,
                                RedstoneWireConnection.None => 4274,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        9 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4275,
                                RedstoneWireConnection.Side => 4276,
                                RedstoneWireConnection.None => 4277,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4278,
                                RedstoneWireConnection.Side => 4279,
                                RedstoneWireConnection.None => 4280,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4281,
                                RedstoneWireConnection.Side => 4282,
                                RedstoneWireConnection.None => 4283,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        10 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4284,
                                RedstoneWireConnection.Side => 4285,
                                RedstoneWireConnection.None => 4286,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4287,
                                RedstoneWireConnection.Side => 4288,
                                RedstoneWireConnection.None => 4289,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4290,
                                RedstoneWireConnection.Side => 4291,
                                RedstoneWireConnection.None => 4292,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        11 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4293,
                                RedstoneWireConnection.Side => 4294,
                                RedstoneWireConnection.None => 4295,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4296,
                                RedstoneWireConnection.Side => 4297,
                                RedstoneWireConnection.None => 4298,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4299,
                                RedstoneWireConnection.Side => 4300,
                                RedstoneWireConnection.None => 4301,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        12 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4302,
                                RedstoneWireConnection.Side => 4303,
                                RedstoneWireConnection.None => 4304,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4305,
                                RedstoneWireConnection.Side => 4306,
                                RedstoneWireConnection.None => 4307,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4308,
                                RedstoneWireConnection.Side => 4309,
                                RedstoneWireConnection.None => 4310,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        13 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4311,
                                RedstoneWireConnection.Side => 4312,
                                RedstoneWireConnection.None => 4313,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4314,
                                RedstoneWireConnection.Side => 4315,
                                RedstoneWireConnection.None => 4316,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4317,
                                RedstoneWireConnection.Side => 4318,
                                RedstoneWireConnection.None => 4319,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        14 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4320,
                                RedstoneWireConnection.Side => 4321,
                                RedstoneWireConnection.None => 4322,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4323,
                                RedstoneWireConnection.Side => 4324,
                                RedstoneWireConnection.None => 4325,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4326,
                                RedstoneWireConnection.Side => 4327,
                                RedstoneWireConnection.None => 4328,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        15 => South switch {
                            RedstoneWireConnection.Up => West switch {
                                RedstoneWireConnection.Up => 4329,
                                RedstoneWireConnection.Side => 4330,
                                RedstoneWireConnection.None => 4331,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.Side => West switch {
                                RedstoneWireConnection.Up => 4332,
                                RedstoneWireConnection.Side => 4333,
                                RedstoneWireConnection.None => 4334,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            RedstoneWireConnection.None => West switch {
                                RedstoneWireConnection.Up => 4335,
                                RedstoneWireConnection.Side => 4336,
                                RedstoneWireConnection.None => 4337,
                                _ => throw new ArgumentOutOfRangeException(nameof(West), West, "Unknown value for property west.")
                            },
                            _ => throw new ArgumentOutOfRangeException(nameof(South), South, "Unknown value for property south.")
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(North), North, "Unknown value for property north.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(East), East, "Unknown value for property east.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3042 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3043 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3044 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3045 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3046 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3047 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3048 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3049 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3050 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3051 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3052 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3053 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3054 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3055 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3056 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3057 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3058 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3059 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3060 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3061 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3062 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3063 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3064 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3065 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3066 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3067 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3068 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3069 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3070 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3071 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3072 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3073 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3074 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3075 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3076 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3077 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3078 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3079 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3080 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3081 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3082 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3083 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3084 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3085 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3086 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3087 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3088 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3089 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3090 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3091 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3092 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3093 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3094 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3095 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3096 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3097 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3098 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3099 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3100 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3101 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3102 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3103 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3104 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3105 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3106 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3107 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3108 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3109 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3110 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3111 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3112 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3113 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3114 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3115 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3116 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3117 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3118 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3119 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3120 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3121 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3122 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3123 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3124 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3125 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3126 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3127 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3128 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3129 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3130 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3131 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3132 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3133 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3134 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3135 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3136 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3137 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3138 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3139 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3140 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3141 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3142 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3143 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3144 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3145 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3146 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3147 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3148 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3149 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3150 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3151 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3152 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3153 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3154 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3155 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3156 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3157 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3158 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3159 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3160 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3161 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3162 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3163 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3164 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3165 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3166 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3167 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3168 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3169 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3170 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3171 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3172 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3173 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3174 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3175 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3176 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3177 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3178 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3179 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3180 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3181 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3182 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3183 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3184 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3185 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3186 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3187 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3188 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3189 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3190 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3191 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3192 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3193 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3194 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3195 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3196 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3197 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3198 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3199 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3200 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3201 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3202 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3203 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3204 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3205 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3206 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3207 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3208 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3209 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3210 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3211 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3212 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3213 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3214 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3215 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3216 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3217 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3218 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3219 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3220 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3221 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3222 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3223 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3224 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3225 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3226 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3227 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3228 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3229 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3230 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3231 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3232 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3233 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3234 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3235 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3236 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3237 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3238 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3239 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3240 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3241 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3242 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3243 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3244 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3245 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3246 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3247 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3248 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3249 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3250 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3251 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3252 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3253 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3254 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3255 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3256 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3257 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3258 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3259 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3260 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3261 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3262 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3263 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3264 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3265 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3266 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3267 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3268 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3269 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3270 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3271 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3272 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3273 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3274 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3275 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3276 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3277 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3278 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3279 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3280 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3281 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3282 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3283 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3284 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3285 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3286 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3287 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3288 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3289 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3290 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3291 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3292 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3293 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3294 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3295 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3296 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3297 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3298 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3299 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3300 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3301 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3302 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3303 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3304 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3305 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3306 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3307 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3308 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3309 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3310 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3311 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3312 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3313 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3314 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3315 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3316 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3317 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3318 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3319 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3320 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3321 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3322 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3323 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3324 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3325 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3326 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3327 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3328 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3329 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3330 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3331 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3332 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3333 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3334 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3335 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3336 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3337 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3338 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3339 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3340 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3341 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3342 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3343 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3344 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3345 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3346 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3347 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3348 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3349 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3350 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3351 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3352 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3353 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3354 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3355 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3356 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3357 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3358 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3359 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3360 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3361 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3362 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3363 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3364 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3365 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3366 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3367 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3368 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3369 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3370 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3371 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3372 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3373 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3374 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3375 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3376 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3377 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3378 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3379 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3380 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3381 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3382 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3383 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3384 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3385 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3386 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3387 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3388 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3389 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3390 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3391 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3392 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3393 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3394 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3395 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3396 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3397 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3398 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3399 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3400 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3401 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3402 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3403 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3404 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3405 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3406 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3407 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3408 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3409 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3410 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3411 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3412 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3413 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3414 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3415 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3416 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3417 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3418 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3419 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3420 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3421 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3422 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3423 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3424 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3425 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3426 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3427 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3428 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3429 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3430 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3431 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3432 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3433 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3434 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3435 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3436 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3437 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3438 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3439 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3440 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3441 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3442 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3443 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3444 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3445 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3446 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3447 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3448 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3449 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3450 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3451 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3452 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3453 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3454 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3455 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3456 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3457 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3458 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3459 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3460 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3461 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3462 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3463 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3464 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3465 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3466 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3467 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3468 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3469 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3470 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3471 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3472 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3473 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Up, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3474 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3475 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3476 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3477 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3478 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3479 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3480 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3481 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3482 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3483 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3484 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3485 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3486 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3487 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3488 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3489 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3490 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3491 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3492 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3493 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3494 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3495 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3496 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3497 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3498 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3499 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3500 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3501 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3502 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3503 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3504 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3505 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3506 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3507 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3508 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3509 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3510 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3511 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3512 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3513 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3514 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3515 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3516 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3517 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3518 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3519 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3520 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3521 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3522 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3523 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3524 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3525 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3526 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3527 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3528 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3529 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3530 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3531 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3532 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3533 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3534 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3535 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3536 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3537 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3538 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3539 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3540 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3541 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3542 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3543 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3544 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3545 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3546 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3547 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3548 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3549 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3550 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3551 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3552 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3553 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3554 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3555 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3556 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3557 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3558 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3559 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3560 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3561 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3562 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3563 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3564 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3565 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3566 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3567 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3568 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3569 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3570 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3571 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3572 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3573 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3574 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3575 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3576 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3577 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3578 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3579 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3580 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3581 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3582 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3583 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3584 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3585 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3586 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3587 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3588 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3589 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3590 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3591 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3592 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3593 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3594 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3595 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3596 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3597 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3598 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3599 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3600 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3601 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3602 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3603 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3604 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3605 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3606 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3607 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3608 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3609 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3610 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3611 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3612 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3613 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3614 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3615 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3616 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3617 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3618 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3619 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3620 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3621 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3622 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3623 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3624 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3625 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3626 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3627 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3628 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3629 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3630 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3631 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3632 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3633 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3634 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3635 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3636 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3637 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3638 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3639 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3640 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3641 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3642 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3643 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3644 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3645 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3646 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3647 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3648 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3649 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3650 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3651 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3652 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3653 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3654 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3655 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3656 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3657 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3658 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3659 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3660 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3661 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3662 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3663 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3664 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3665 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3666 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3667 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3668 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3669 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3670 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3671 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3672 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3673 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3674 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3675 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3676 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3677 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3678 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3679 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3680 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3681 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3682 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3683 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3684 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3685 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3686 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3687 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3688 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3689 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3690 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3691 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3692 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3693 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3694 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3695 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3696 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3697 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3698 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3699 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3700 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3701 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3702 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3703 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3704 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3705 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3706 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3707 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3708 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3709 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3710 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3711 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3712 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3713 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3714 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3715 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3716 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3717 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3718 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3719 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3720 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3721 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3722 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3723 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3724 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3725 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3726 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3727 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3728 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3729 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3730 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3731 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3732 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3733 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3734 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3735 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3736 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3737 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3738 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3739 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3740 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3741 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3742 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3743 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3744 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3745 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3746 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3747 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3748 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3749 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3750 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3751 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3752 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3753 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3754 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3755 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3756 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3757 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3758 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3759 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3760 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3761 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3762 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3763 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3764 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3765 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3766 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3767 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3768 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3769 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3770 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3771 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3772 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3773 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3774 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3775 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3776 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3777 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3778 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3779 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3780 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3781 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3782 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3783 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3784 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3785 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3786 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3787 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3788 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3789 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3790 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3791 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3792 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3793 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3794 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3795 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3796 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3797 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3798 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3799 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3800 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3801 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3802 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3803 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3804 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3805 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3806 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3807 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3808 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3809 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3810 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3811 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3812 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3813 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3814 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3815 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3816 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3817 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3818 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3819 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3820 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3821 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3822 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3823 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3824 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3825 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3826 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3827 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3828 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3829 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3830 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3831 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3832 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3833 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3834 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3835 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3836 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3837 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3838 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3839 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3840 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3841 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3842 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3843 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3844 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3845 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3846 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3847 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3848 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3849 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3850 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3851 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3852 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3853 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3854 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3855 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3856 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3857 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3858 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3859 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3860 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3861 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3862 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3863 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3864 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3865 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3866 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3867 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3868 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3869 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3870 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3871 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3872 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3873 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3874 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3875 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3876 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3877 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3878 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3879 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3880 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3881 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3882 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3883 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3884 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3885 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3886 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3887 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3888 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3889 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3890 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3891 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3892 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3893 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3894 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3895 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3896 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3897 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3898 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3899 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3900 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3901 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3902 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3903 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3904 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3905 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.Side, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3906 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3907 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3908 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3909 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3910 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3911 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3912 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3913 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3914 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3915 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3916 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3917 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3918 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3919 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3920 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3921 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3922 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3923 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3924 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3925 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3926 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3927 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3928 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3929 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3930 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3931 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3932 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3933 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3934 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3935 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3936 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3937 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3938 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3939 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3940 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3941 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3942 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3943 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3944 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3945 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3946 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3947 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3948 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3949 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3950 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3951 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3952 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3953 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3954 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3955 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3956 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3957 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3958 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3959 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3960 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3961 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3962 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3963 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3964 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3965 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3966 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3967 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3968 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3969 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3970 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3971 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3972 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3973 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3974 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3975 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3976 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3977 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3978 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3979 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3980 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3981 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3982 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3983 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3984 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3985 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3986 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3987 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3988 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3989 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3990 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            3991 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            3992 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            3993 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            3994 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            3995 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            3996 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            3997 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            3998 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            3999 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4000 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4001 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4002 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4003 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4004 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4005 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4006 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4007 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4008 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4009 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4010 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4011 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4012 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4013 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4014 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4015 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4016 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4017 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4018 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4019 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4020 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4021 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4022 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4023 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4024 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4025 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4026 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4027 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4028 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4029 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4030 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4031 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4032 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4033 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4034 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4035 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4036 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4037 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4038 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4039 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4040 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4041 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4042 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4043 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4044 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4045 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4046 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4047 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4048 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4049 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Up, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4050 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4051 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4052 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4053 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4054 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4055 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4056 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4057 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4058 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4059 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4060 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4061 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4062 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4063 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4064 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4065 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4066 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4067 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4068 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4069 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4070 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4071 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4072 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4073 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4074 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4075 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4076 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4077 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4078 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4079 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4080 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4081 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4082 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4083 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4084 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4085 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4086 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4087 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4088 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4089 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4090 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4091 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4092 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4093 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4094 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4095 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4096 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4097 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4098 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4099 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4100 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4101 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4102 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4103 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4104 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4105 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4106 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4107 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4108 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4109 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4110 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4111 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4112 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4113 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4114 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4115 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4116 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4117 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4118 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4119 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4120 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4121 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4122 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4123 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4124 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4125 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4126 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4127 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4128 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4129 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4130 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4131 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4132 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4133 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4134 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4135 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4136 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4137 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4138 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4139 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4140 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4141 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4142 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4143 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4144 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4145 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4146 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4147 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4148 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4149 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4150 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4151 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4152 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4153 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4154 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4155 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4156 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4157 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4158 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4159 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4160 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4161 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4162 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4163 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4164 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4165 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4166 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4167 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4168 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4169 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4170 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4171 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4172 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4173 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4174 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4175 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4176 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4177 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4178 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4179 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4180 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4181 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4182 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4183 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4184 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4185 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4186 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4187 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4188 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4189 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4190 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4191 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4192 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4193 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.Side, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4194 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4195 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4196 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4197 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4198 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4199 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4200 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4201 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4202 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 0, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4203 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4204 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4205 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4206 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4207 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4208 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4209 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4210 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4211 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 1, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4212 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4213 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4214 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4215 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4216 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4217 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4218 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4219 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4220 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 2, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4221 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4222 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4223 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4224 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4225 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4226 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4227 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4228 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4229 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 3, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4230 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4231 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4232 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4233 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4234 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4235 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4236 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4237 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4238 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 4, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4239 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4240 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4241 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4242 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4243 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4244 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4245 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4246 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4247 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 5, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4248 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4249 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4250 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4251 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4252 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4253 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4254 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4255 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4256 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 6, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4257 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4258 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4259 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4260 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4261 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4262 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4263 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4264 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4265 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 7, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4266 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4267 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4268 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4269 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4270 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4271 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4272 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4273 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4274 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 8, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4275 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4276 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4277 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4278 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4279 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4280 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4281 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4282 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4283 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 9, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4284 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4285 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4286 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4287 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4288 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4289 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4290 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4291 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4292 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 10, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4293 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4294 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4295 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4296 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4297 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4298 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4299 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4300 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4301 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 11, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4302 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4303 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4304 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4305 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4306 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4307 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4308 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4309 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4310 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 12, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4311 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4312 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4313 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4314 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4315 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4316 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4317 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4318 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4319 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 13, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4320 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4321 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4322 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4323 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4324 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4325 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4326 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4327 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4328 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 14, RedstoneWireConnection.None, RedstoneWireConnection.None),
            4329 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Up),
            4330 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.Side),
            4331 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Up, RedstoneWireConnection.None),
            4332 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Up),
            4333 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.Side),
            4334 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.Side, RedstoneWireConnection.None),
            4335 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Up),
            4336 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.Side),
            4337 => new RedstoneWireBlock(Identifier, RedstoneWireConnection.None, RedstoneWireConnection.None, 15, RedstoneWireConnection.None, RedstoneWireConnection.None),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = RedstoneWireConnectionExtensions.FromString(properties["east"].GetString()),
            North = RedstoneWireConnectionExtensions.FromString(properties["north"].GetString()),
            Power = int.Parse(properties["power"].GetString()),
            South = RedstoneWireConnectionExtensions.FromString(properties["south"].GetString()),
            West = RedstoneWireConnectionExtensions.FromString(properties["west"].GetString()),
        };
    }
    
}
