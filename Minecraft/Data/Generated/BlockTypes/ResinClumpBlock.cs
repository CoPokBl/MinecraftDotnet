using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ResinClumpBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7240,
                                        false => 7241,
                                    },
                                    false => West switch {
                                        true => 7242,
                                        false => 7243,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7244,
                                        false => 7245,
                                    },
                                    false => West switch {
                                        true => 7246,
                                        false => 7247,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7248,
                                        false => 7249,
                                    },
                                    false => West switch {
                                        true => 7250,
                                        false => 7251,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7252,
                                        false => 7253,
                                    },
                                    false => West switch {
                                        true => 7254,
                                        false => 7255,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7256,
                                        false => 7257,
                                    },
                                    false => West switch {
                                        true => 7258,
                                        false => 7259,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7260,
                                        false => 7261,
                                    },
                                    false => West switch {
                                        true => 7262,
                                        false => 7263,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7264,
                                        false => 7265,
                                    },
                                    false => West switch {
                                        true => 7266,
                                        false => 7267,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7268,
                                        false => 7269,
                                    },
                                    false => West switch {
                                        true => 7270,
                                        false => 7271,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7272,
                                        false => 7273,
                                    },
                                    false => West switch {
                                        true => 7274,
                                        false => 7275,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7276,
                                        false => 7277,
                                    },
                                    false => West switch {
                                        true => 7278,
                                        false => 7279,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7280,
                                        false => 7281,
                                    },
                                    false => West switch {
                                        true => 7282,
                                        false => 7283,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7284,
                                        false => 7285,
                                    },
                                    false => West switch {
                                        true => 7286,
                                        false => 7287,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7288,
                                        false => 7289,
                                    },
                                    false => West switch {
                                        true => 7290,
                                        false => 7291,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7292,
                                        false => 7293,
                                    },
                                    false => West switch {
                                        true => 7294,
                                        false => 7295,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7296,
                                        false => 7297,
                                    },
                                    false => West switch {
                                        true => 7298,
                                        false => 7299,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7300,
                                        false => 7301,
                                    },
                                    false => West switch {
                                        true => 7302,
                                        false => 7303,
                                    },
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7304,
                                        false => 7305,
                                    },
                                    false => West switch {
                                        true => 7306,
                                        false => 7307,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7308,
                                        false => 7309,
                                    },
                                    false => West switch {
                                        true => 7310,
                                        false => 7311,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7312,
                                        false => 7313,
                                    },
                                    false => West switch {
                                        true => 7314,
                                        false => 7315,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7316,
                                        false => 7317,
                                    },
                                    false => West switch {
                                        true => 7318,
                                        false => 7319,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7320,
                                        false => 7321,
                                    },
                                    false => West switch {
                                        true => 7322,
                                        false => 7323,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7324,
                                        false => 7325,
                                    },
                                    false => West switch {
                                        true => 7326,
                                        false => 7327,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7328,
                                        false => 7329,
                                    },
                                    false => West switch {
                                        true => 7330,
                                        false => 7331,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7332,
                                        false => 7333,
                                    },
                                    false => West switch {
                                        true => 7334,
                                        false => 7335,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7336,
                                        false => 7337,
                                    },
                                    false => West switch {
                                        true => 7338,
                                        false => 7339,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7340,
                                        false => 7341,
                                    },
                                    false => West switch {
                                        true => 7342,
                                        false => 7343,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7344,
                                        false => 7345,
                                    },
                                    false => West switch {
                                        true => 7346,
                                        false => 7347,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7348,
                                        false => 7349,
                                    },
                                    false => West switch {
                                        true => 7350,
                                        false => 7351,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7352,
                                        false => 7353,
                                    },
                                    false => West switch {
                                        true => 7354,
                                        false => 7355,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7356,
                                        false => 7357,
                                    },
                                    false => West switch {
                                        true => 7358,
                                        false => 7359,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 7360,
                                        false => 7361,
                                    },
                                    false => West switch {
                                        true => 7362,
                                        false => 7363,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 7364,
                                        false => 7365,
                                    },
                                    false => West switch {
                                        true => 7366,
                                        false => 7367,
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            7240 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, true),
            7241 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, false),
            7242 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, true),
            7243 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, false),
            7244 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, true),
            7245 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, false),
            7246 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, true),
            7247 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, false),
            7248 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, true),
            7249 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, false),
            7250 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, true),
            7251 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, false),
            7252 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, true),
            7253 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, false),
            7254 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, true),
            7255 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, false),
            7256 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, true),
            7257 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, false),
            7258 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, true),
            7259 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, false),
            7260 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, true),
            7261 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, false),
            7262 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, true),
            7263 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, false),
            7264 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, true),
            7265 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, false),
            7266 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, true),
            7267 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, false),
            7268 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, true),
            7269 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, false),
            7270 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, true),
            7271 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, false),
            7272 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, true),
            7273 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, false),
            7274 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, true),
            7275 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, false),
            7276 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, true),
            7277 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, false),
            7278 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, true),
            7279 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, false),
            7280 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, true),
            7281 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, false),
            7282 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, true),
            7283 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, false),
            7284 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, true),
            7285 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, false),
            7286 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, true),
            7287 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, false),
            7288 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, true),
            7289 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, false),
            7290 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, true),
            7291 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, false),
            7292 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, true),
            7293 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, false),
            7294 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, true),
            7295 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, false),
            7296 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, true),
            7297 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, false),
            7298 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, true),
            7299 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, false),
            7300 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, true),
            7301 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, false),
            7302 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, true),
            7303 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, false),
            7304 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, true),
            7305 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, false),
            7306 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, true),
            7307 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, false),
            7308 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, true),
            7309 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, false),
            7310 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, true),
            7311 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, false),
            7312 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, true),
            7313 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, false),
            7314 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, true),
            7315 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, false),
            7316 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, true),
            7317 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, false),
            7318 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, true),
            7319 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, false),
            7320 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, true),
            7321 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, false),
            7322 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, true),
            7323 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, false),
            7324 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, true),
            7325 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, false),
            7326 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, true),
            7327 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, false),
            7328 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, true),
            7329 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, false),
            7330 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, true),
            7331 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, false),
            7332 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, true),
            7333 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, false),
            7334 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, true),
            7335 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, false),
            7336 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, true),
            7337 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, false),
            7338 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, true),
            7339 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, false),
            7340 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, true),
            7341 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, false),
            7342 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, true),
            7343 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, false),
            7344 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, true),
            7345 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, false),
            7346 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, true),
            7347 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, false),
            7348 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, true),
            7349 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, false),
            7350 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, true),
            7351 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, false),
            7352 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, true),
            7353 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, false),
            7354 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, true),
            7355 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, false),
            7356 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, true),
            7357 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, false),
            7358 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, true),
            7359 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, false),
            7360 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, true),
            7361 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, false),
            7362 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, true),
            7363 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, false),
            7364 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, true),
            7365 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, false),
            7366 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, true),
            7367 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
