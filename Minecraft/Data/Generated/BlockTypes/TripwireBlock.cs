using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TripwireBlock(Identifier Identifier, bool Attached, bool Disarmed, bool East, bool North, bool Powered, bool South, bool West) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Disarmed switch {
                    true => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8321,
                                        false => 8322,
                                    },
                                    false => West switch {
                                        true => 8323,
                                        false => 8324,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8325,
                                        false => 8326,
                                    },
                                    false => West switch {
                                        true => 8327,
                                        false => 8328,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8329,
                                        false => 8330,
                                    },
                                    false => West switch {
                                        true => 8331,
                                        false => 8332,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8333,
                                        false => 8334,
                                    },
                                    false => West switch {
                                        true => 8335,
                                        false => 8336,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8337,
                                        false => 8338,
                                    },
                                    false => West switch {
                                        true => 8339,
                                        false => 8340,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8341,
                                        false => 8342,
                                    },
                                    false => West switch {
                                        true => 8343,
                                        false => 8344,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8345,
                                        false => 8346,
                                    },
                                    false => West switch {
                                        true => 8347,
                                        false => 8348,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8349,
                                        false => 8350,
                                    },
                                    false => West switch {
                                        true => 8351,
                                        false => 8352,
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
                                        true => 8353,
                                        false => 8354,
                                    },
                                    false => West switch {
                                        true => 8355,
                                        false => 8356,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8357,
                                        false => 8358,
                                    },
                                    false => West switch {
                                        true => 8359,
                                        false => 8360,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8361,
                                        false => 8362,
                                    },
                                    false => West switch {
                                        true => 8363,
                                        false => 8364,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8365,
                                        false => 8366,
                                    },
                                    false => West switch {
                                        true => 8367,
                                        false => 8368,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8369,
                                        false => 8370,
                                    },
                                    false => West switch {
                                        true => 8371,
                                        false => 8372,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8373,
                                        false => 8374,
                                    },
                                    false => West switch {
                                        true => 8375,
                                        false => 8376,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8377,
                                        false => 8378,
                                    },
                                    false => West switch {
                                        true => 8379,
                                        false => 8380,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8381,
                                        false => 8382,
                                    },
                                    false => West switch {
                                        true => 8383,
                                        false => 8384,
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
                                        true => 8385,
                                        false => 8386,
                                    },
                                    false => West switch {
                                        true => 8387,
                                        false => 8388,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8389,
                                        false => 8390,
                                    },
                                    false => West switch {
                                        true => 8391,
                                        false => 8392,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8393,
                                        false => 8394,
                                    },
                                    false => West switch {
                                        true => 8395,
                                        false => 8396,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8397,
                                        false => 8398,
                                    },
                                    false => West switch {
                                        true => 8399,
                                        false => 8400,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8401,
                                        false => 8402,
                                    },
                                    false => West switch {
                                        true => 8403,
                                        false => 8404,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8405,
                                        false => 8406,
                                    },
                                    false => West switch {
                                        true => 8407,
                                        false => 8408,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8409,
                                        false => 8410,
                                    },
                                    false => West switch {
                                        true => 8411,
                                        false => 8412,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8413,
                                        false => 8414,
                                    },
                                    false => West switch {
                                        true => 8415,
                                        false => 8416,
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
                                        true => 8417,
                                        false => 8418,
                                    },
                                    false => West switch {
                                        true => 8419,
                                        false => 8420,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8421,
                                        false => 8422,
                                    },
                                    false => West switch {
                                        true => 8423,
                                        false => 8424,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8425,
                                        false => 8426,
                                    },
                                    false => West switch {
                                        true => 8427,
                                        false => 8428,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8429,
                                        false => 8430,
                                    },
                                    false => West switch {
                                        true => 8431,
                                        false => 8432,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8433,
                                        false => 8434,
                                    },
                                    false => West switch {
                                        true => 8435,
                                        false => 8436,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8437,
                                        false => 8438,
                                    },
                                    false => West switch {
                                        true => 8439,
                                        false => 8440,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 8441,
                                        false => 8442,
                                    },
                                    false => West switch {
                                        true => 8443,
                                        false => 8444,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 8445,
                                        false => 8446,
                                    },
                                    false => West switch {
                                        true => 8447,
                                        false => 8448,
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
            8321 => new TripwireBlock(Identifier, true, true, true, true, true, true, true),
            8322 => new TripwireBlock(Identifier, true, true, true, true, true, true, false),
            8323 => new TripwireBlock(Identifier, true, true, true, true, true, false, true),
            8324 => new TripwireBlock(Identifier, true, true, true, true, true, false, false),
            8325 => new TripwireBlock(Identifier, true, true, true, true, false, true, true),
            8326 => new TripwireBlock(Identifier, true, true, true, true, false, true, false),
            8327 => new TripwireBlock(Identifier, true, true, true, true, false, false, true),
            8328 => new TripwireBlock(Identifier, true, true, true, true, false, false, false),
            8329 => new TripwireBlock(Identifier, true, true, true, false, true, true, true),
            8330 => new TripwireBlock(Identifier, true, true, true, false, true, true, false),
            8331 => new TripwireBlock(Identifier, true, true, true, false, true, false, true),
            8332 => new TripwireBlock(Identifier, true, true, true, false, true, false, false),
            8333 => new TripwireBlock(Identifier, true, true, true, false, false, true, true),
            8334 => new TripwireBlock(Identifier, true, true, true, false, false, true, false),
            8335 => new TripwireBlock(Identifier, true, true, true, false, false, false, true),
            8336 => new TripwireBlock(Identifier, true, true, true, false, false, false, false),
            8337 => new TripwireBlock(Identifier, true, true, false, true, true, true, true),
            8338 => new TripwireBlock(Identifier, true, true, false, true, true, true, false),
            8339 => new TripwireBlock(Identifier, true, true, false, true, true, false, true),
            8340 => new TripwireBlock(Identifier, true, true, false, true, true, false, false),
            8341 => new TripwireBlock(Identifier, true, true, false, true, false, true, true),
            8342 => new TripwireBlock(Identifier, true, true, false, true, false, true, false),
            8343 => new TripwireBlock(Identifier, true, true, false, true, false, false, true),
            8344 => new TripwireBlock(Identifier, true, true, false, true, false, false, false),
            8345 => new TripwireBlock(Identifier, true, true, false, false, true, true, true),
            8346 => new TripwireBlock(Identifier, true, true, false, false, true, true, false),
            8347 => new TripwireBlock(Identifier, true, true, false, false, true, false, true),
            8348 => new TripwireBlock(Identifier, true, true, false, false, true, false, false),
            8349 => new TripwireBlock(Identifier, true, true, false, false, false, true, true),
            8350 => new TripwireBlock(Identifier, true, true, false, false, false, true, false),
            8351 => new TripwireBlock(Identifier, true, true, false, false, false, false, true),
            8352 => new TripwireBlock(Identifier, true, true, false, false, false, false, false),
            8353 => new TripwireBlock(Identifier, true, false, true, true, true, true, true),
            8354 => new TripwireBlock(Identifier, true, false, true, true, true, true, false),
            8355 => new TripwireBlock(Identifier, true, false, true, true, true, false, true),
            8356 => new TripwireBlock(Identifier, true, false, true, true, true, false, false),
            8357 => new TripwireBlock(Identifier, true, false, true, true, false, true, true),
            8358 => new TripwireBlock(Identifier, true, false, true, true, false, true, false),
            8359 => new TripwireBlock(Identifier, true, false, true, true, false, false, true),
            8360 => new TripwireBlock(Identifier, true, false, true, true, false, false, false),
            8361 => new TripwireBlock(Identifier, true, false, true, false, true, true, true),
            8362 => new TripwireBlock(Identifier, true, false, true, false, true, true, false),
            8363 => new TripwireBlock(Identifier, true, false, true, false, true, false, true),
            8364 => new TripwireBlock(Identifier, true, false, true, false, true, false, false),
            8365 => new TripwireBlock(Identifier, true, false, true, false, false, true, true),
            8366 => new TripwireBlock(Identifier, true, false, true, false, false, true, false),
            8367 => new TripwireBlock(Identifier, true, false, true, false, false, false, true),
            8368 => new TripwireBlock(Identifier, true, false, true, false, false, false, false),
            8369 => new TripwireBlock(Identifier, true, false, false, true, true, true, true),
            8370 => new TripwireBlock(Identifier, true, false, false, true, true, true, false),
            8371 => new TripwireBlock(Identifier, true, false, false, true, true, false, true),
            8372 => new TripwireBlock(Identifier, true, false, false, true, true, false, false),
            8373 => new TripwireBlock(Identifier, true, false, false, true, false, true, true),
            8374 => new TripwireBlock(Identifier, true, false, false, true, false, true, false),
            8375 => new TripwireBlock(Identifier, true, false, false, true, false, false, true),
            8376 => new TripwireBlock(Identifier, true, false, false, true, false, false, false),
            8377 => new TripwireBlock(Identifier, true, false, false, false, true, true, true),
            8378 => new TripwireBlock(Identifier, true, false, false, false, true, true, false),
            8379 => new TripwireBlock(Identifier, true, false, false, false, true, false, true),
            8380 => new TripwireBlock(Identifier, true, false, false, false, true, false, false),
            8381 => new TripwireBlock(Identifier, true, false, false, false, false, true, true),
            8382 => new TripwireBlock(Identifier, true, false, false, false, false, true, false),
            8383 => new TripwireBlock(Identifier, true, false, false, false, false, false, true),
            8384 => new TripwireBlock(Identifier, true, false, false, false, false, false, false),
            8385 => new TripwireBlock(Identifier, false, true, true, true, true, true, true),
            8386 => new TripwireBlock(Identifier, false, true, true, true, true, true, false),
            8387 => new TripwireBlock(Identifier, false, true, true, true, true, false, true),
            8388 => new TripwireBlock(Identifier, false, true, true, true, true, false, false),
            8389 => new TripwireBlock(Identifier, false, true, true, true, false, true, true),
            8390 => new TripwireBlock(Identifier, false, true, true, true, false, true, false),
            8391 => new TripwireBlock(Identifier, false, true, true, true, false, false, true),
            8392 => new TripwireBlock(Identifier, false, true, true, true, false, false, false),
            8393 => new TripwireBlock(Identifier, false, true, true, false, true, true, true),
            8394 => new TripwireBlock(Identifier, false, true, true, false, true, true, false),
            8395 => new TripwireBlock(Identifier, false, true, true, false, true, false, true),
            8396 => new TripwireBlock(Identifier, false, true, true, false, true, false, false),
            8397 => new TripwireBlock(Identifier, false, true, true, false, false, true, true),
            8398 => new TripwireBlock(Identifier, false, true, true, false, false, true, false),
            8399 => new TripwireBlock(Identifier, false, true, true, false, false, false, true),
            8400 => new TripwireBlock(Identifier, false, true, true, false, false, false, false),
            8401 => new TripwireBlock(Identifier, false, true, false, true, true, true, true),
            8402 => new TripwireBlock(Identifier, false, true, false, true, true, true, false),
            8403 => new TripwireBlock(Identifier, false, true, false, true, true, false, true),
            8404 => new TripwireBlock(Identifier, false, true, false, true, true, false, false),
            8405 => new TripwireBlock(Identifier, false, true, false, true, false, true, true),
            8406 => new TripwireBlock(Identifier, false, true, false, true, false, true, false),
            8407 => new TripwireBlock(Identifier, false, true, false, true, false, false, true),
            8408 => new TripwireBlock(Identifier, false, true, false, true, false, false, false),
            8409 => new TripwireBlock(Identifier, false, true, false, false, true, true, true),
            8410 => new TripwireBlock(Identifier, false, true, false, false, true, true, false),
            8411 => new TripwireBlock(Identifier, false, true, false, false, true, false, true),
            8412 => new TripwireBlock(Identifier, false, true, false, false, true, false, false),
            8413 => new TripwireBlock(Identifier, false, true, false, false, false, true, true),
            8414 => new TripwireBlock(Identifier, false, true, false, false, false, true, false),
            8415 => new TripwireBlock(Identifier, false, true, false, false, false, false, true),
            8416 => new TripwireBlock(Identifier, false, true, false, false, false, false, false),
            8417 => new TripwireBlock(Identifier, false, false, true, true, true, true, true),
            8418 => new TripwireBlock(Identifier, false, false, true, true, true, true, false),
            8419 => new TripwireBlock(Identifier, false, false, true, true, true, false, true),
            8420 => new TripwireBlock(Identifier, false, false, true, true, true, false, false),
            8421 => new TripwireBlock(Identifier, false, false, true, true, false, true, true),
            8422 => new TripwireBlock(Identifier, false, false, true, true, false, true, false),
            8423 => new TripwireBlock(Identifier, false, false, true, true, false, false, true),
            8424 => new TripwireBlock(Identifier, false, false, true, true, false, false, false),
            8425 => new TripwireBlock(Identifier, false, false, true, false, true, true, true),
            8426 => new TripwireBlock(Identifier, false, false, true, false, true, true, false),
            8427 => new TripwireBlock(Identifier, false, false, true, false, true, false, true),
            8428 => new TripwireBlock(Identifier, false, false, true, false, true, false, false),
            8429 => new TripwireBlock(Identifier, false, false, true, false, false, true, true),
            8430 => new TripwireBlock(Identifier, false, false, true, false, false, true, false),
            8431 => new TripwireBlock(Identifier, false, false, true, false, false, false, true),
            8432 => new TripwireBlock(Identifier, false, false, true, false, false, false, false),
            8433 => new TripwireBlock(Identifier, false, false, false, true, true, true, true),
            8434 => new TripwireBlock(Identifier, false, false, false, true, true, true, false),
            8435 => new TripwireBlock(Identifier, false, false, false, true, true, false, true),
            8436 => new TripwireBlock(Identifier, false, false, false, true, true, false, false),
            8437 => new TripwireBlock(Identifier, false, false, false, true, false, true, true),
            8438 => new TripwireBlock(Identifier, false, false, false, true, false, true, false),
            8439 => new TripwireBlock(Identifier, false, false, false, true, false, false, true),
            8440 => new TripwireBlock(Identifier, false, false, false, true, false, false, false),
            8441 => new TripwireBlock(Identifier, false, false, false, false, true, true, true),
            8442 => new TripwireBlock(Identifier, false, false, false, false, true, true, false),
            8443 => new TripwireBlock(Identifier, false, false, false, false, true, false, true),
            8444 => new TripwireBlock(Identifier, false, false, false, false, true, false, false),
            8445 => new TripwireBlock(Identifier, false, false, false, false, false, true, true),
            8446 => new TripwireBlock(Identifier, false, false, false, false, false, true, false),
            8447 => new TripwireBlock(Identifier, false, false, false, false, false, false, true),
            8448 => new TripwireBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Disarmed = properties["disarmed"].GetString() == "true",
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
