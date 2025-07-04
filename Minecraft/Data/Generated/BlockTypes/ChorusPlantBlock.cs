using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChorusPlantBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13363,
                                    false => 13364,
                                },
                                false => West switch {
                                    true => 13365,
                                    false => 13366,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13367,
                                    false => 13368,
                                },
                                false => West switch {
                                    true => 13369,
                                    false => 13370,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13371,
                                    false => 13372,
                                },
                                false => West switch {
                                    true => 13373,
                                    false => 13374,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13375,
                                    false => 13376,
                                },
                                false => West switch {
                                    true => 13377,
                                    false => 13378,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13379,
                                    false => 13380,
                                },
                                false => West switch {
                                    true => 13381,
                                    false => 13382,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13383,
                                    false => 13384,
                                },
                                false => West switch {
                                    true => 13385,
                                    false => 13386,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13387,
                                    false => 13388,
                                },
                                false => West switch {
                                    true => 13389,
                                    false => 13390,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13391,
                                    false => 13392,
                                },
                                false => West switch {
                                    true => 13393,
                                    false => 13394,
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13395,
                                    false => 13396,
                                },
                                false => West switch {
                                    true => 13397,
                                    false => 13398,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13399,
                                    false => 13400,
                                },
                                false => West switch {
                                    true => 13401,
                                    false => 13402,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13403,
                                    false => 13404,
                                },
                                false => West switch {
                                    true => 13405,
                                    false => 13406,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13407,
                                    false => 13408,
                                },
                                false => West switch {
                                    true => 13409,
                                    false => 13410,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13411,
                                    false => 13412,
                                },
                                false => West switch {
                                    true => 13413,
                                    false => 13414,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13415,
                                    false => 13416,
                                },
                                false => West switch {
                                    true => 13417,
                                    false => 13418,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 13419,
                                    false => 13420,
                                },
                                false => West switch {
                                    true => 13421,
                                    false => 13422,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 13423,
                                    false => 13424,
                                },
                                false => West switch {
                                    true => 13425,
                                    false => 13426,
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
            13363 => new ChorusPlantBlock(Identifier, true, true, true, true, true, true),
            13364 => new ChorusPlantBlock(Identifier, true, true, true, true, true, false),
            13365 => new ChorusPlantBlock(Identifier, true, true, true, true, false, true),
            13366 => new ChorusPlantBlock(Identifier, true, true, true, true, false, false),
            13367 => new ChorusPlantBlock(Identifier, true, true, true, false, true, true),
            13368 => new ChorusPlantBlock(Identifier, true, true, true, false, true, false),
            13369 => new ChorusPlantBlock(Identifier, true, true, true, false, false, true),
            13370 => new ChorusPlantBlock(Identifier, true, true, true, false, false, false),
            13371 => new ChorusPlantBlock(Identifier, true, true, false, true, true, true),
            13372 => new ChorusPlantBlock(Identifier, true, true, false, true, true, false),
            13373 => new ChorusPlantBlock(Identifier, true, true, false, true, false, true),
            13374 => new ChorusPlantBlock(Identifier, true, true, false, true, false, false),
            13375 => new ChorusPlantBlock(Identifier, true, true, false, false, true, true),
            13376 => new ChorusPlantBlock(Identifier, true, true, false, false, true, false),
            13377 => new ChorusPlantBlock(Identifier, true, true, false, false, false, true),
            13378 => new ChorusPlantBlock(Identifier, true, true, false, false, false, false),
            13379 => new ChorusPlantBlock(Identifier, true, false, true, true, true, true),
            13380 => new ChorusPlantBlock(Identifier, true, false, true, true, true, false),
            13381 => new ChorusPlantBlock(Identifier, true, false, true, true, false, true),
            13382 => new ChorusPlantBlock(Identifier, true, false, true, true, false, false),
            13383 => new ChorusPlantBlock(Identifier, true, false, true, false, true, true),
            13384 => new ChorusPlantBlock(Identifier, true, false, true, false, true, false),
            13385 => new ChorusPlantBlock(Identifier, true, false, true, false, false, true),
            13386 => new ChorusPlantBlock(Identifier, true, false, true, false, false, false),
            13387 => new ChorusPlantBlock(Identifier, true, false, false, true, true, true),
            13388 => new ChorusPlantBlock(Identifier, true, false, false, true, true, false),
            13389 => new ChorusPlantBlock(Identifier, true, false, false, true, false, true),
            13390 => new ChorusPlantBlock(Identifier, true, false, false, true, false, false),
            13391 => new ChorusPlantBlock(Identifier, true, false, false, false, true, true),
            13392 => new ChorusPlantBlock(Identifier, true, false, false, false, true, false),
            13393 => new ChorusPlantBlock(Identifier, true, false, false, false, false, true),
            13394 => new ChorusPlantBlock(Identifier, true, false, false, false, false, false),
            13395 => new ChorusPlantBlock(Identifier, false, true, true, true, true, true),
            13396 => new ChorusPlantBlock(Identifier, false, true, true, true, true, false),
            13397 => new ChorusPlantBlock(Identifier, false, true, true, true, false, true),
            13398 => new ChorusPlantBlock(Identifier, false, true, true, true, false, false),
            13399 => new ChorusPlantBlock(Identifier, false, true, true, false, true, true),
            13400 => new ChorusPlantBlock(Identifier, false, true, true, false, true, false),
            13401 => new ChorusPlantBlock(Identifier, false, true, true, false, false, true),
            13402 => new ChorusPlantBlock(Identifier, false, true, true, false, false, false),
            13403 => new ChorusPlantBlock(Identifier, false, true, false, true, true, true),
            13404 => new ChorusPlantBlock(Identifier, false, true, false, true, true, false),
            13405 => new ChorusPlantBlock(Identifier, false, true, false, true, false, true),
            13406 => new ChorusPlantBlock(Identifier, false, true, false, true, false, false),
            13407 => new ChorusPlantBlock(Identifier, false, true, false, false, true, true),
            13408 => new ChorusPlantBlock(Identifier, false, true, false, false, true, false),
            13409 => new ChorusPlantBlock(Identifier, false, true, false, false, false, true),
            13410 => new ChorusPlantBlock(Identifier, false, true, false, false, false, false),
            13411 => new ChorusPlantBlock(Identifier, false, false, true, true, true, true),
            13412 => new ChorusPlantBlock(Identifier, false, false, true, true, true, false),
            13413 => new ChorusPlantBlock(Identifier, false, false, true, true, false, true),
            13414 => new ChorusPlantBlock(Identifier, false, false, true, true, false, false),
            13415 => new ChorusPlantBlock(Identifier, false, false, true, false, true, true),
            13416 => new ChorusPlantBlock(Identifier, false, false, true, false, true, false),
            13417 => new ChorusPlantBlock(Identifier, false, false, true, false, false, true),
            13418 => new ChorusPlantBlock(Identifier, false, false, true, false, false, false),
            13419 => new ChorusPlantBlock(Identifier, false, false, false, true, true, true),
            13420 => new ChorusPlantBlock(Identifier, false, false, false, true, true, false),
            13421 => new ChorusPlantBlock(Identifier, false, false, false, true, false, true),
            13422 => new ChorusPlantBlock(Identifier, false, false, false, true, false, false),
            13423 => new ChorusPlantBlock(Identifier, false, false, false, false, true, true),
            13424 => new ChorusPlantBlock(Identifier, false, false, false, false, true, false),
            13425 => new ChorusPlantBlock(Identifier, false, false, false, false, false, true),
            13426 => new ChorusPlantBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties["down"].GetString() == "true",
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Up = properties["up"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
