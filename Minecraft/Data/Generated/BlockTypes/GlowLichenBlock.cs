using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GlowLichenBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:glow_lichen";
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "glow_lichen";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:glow_lichen";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 61;
    public string TranslationKey => "block.minecraft.glow_lichen";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8390,
                                        false => 8391,
                                    },
                                    false => West switch {
                                        true => 8392,
                                        false => 8393,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8394,
                                        false => 8395,
                                    },
                                    false => West switch {
                                        true => 8396,
                                        false => 8397,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8398,
                                        false => 8399,
                                    },
                                    false => West switch {
                                        true => 8400,
                                        false => 8401,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8402,
                                        false => 8403,
                                    },
                                    false => West switch {
                                        true => 8404,
                                        false => 8405,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8406,
                                        false => 8407,
                                    },
                                    false => West switch {
                                        true => 8408,
                                        false => 8409,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8410,
                                        false => 8411,
                                    },
                                    false => West switch {
                                        true => 8412,
                                        false => 8413,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8414,
                                        false => 8415,
                                    },
                                    false => West switch {
                                        true => 8416,
                                        false => 8417,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8418,
                                        false => 8419,
                                    },
                                    false => West switch {
                                        true => 8420,
                                        false => 8421,
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
                                        true => 8422,
                                        false => 8423,
                                    },
                                    false => West switch {
                                        true => 8424,
                                        false => 8425,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8426,
                                        false => 8427,
                                    },
                                    false => West switch {
                                        true => 8428,
                                        false => 8429,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8430,
                                        false => 8431,
                                    },
                                    false => West switch {
                                        true => 8432,
                                        false => 8433,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8434,
                                        false => 8435,
                                    },
                                    false => West switch {
                                        true => 8436,
                                        false => 8437,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8438,
                                        false => 8439,
                                    },
                                    false => West switch {
                                        true => 8440,
                                        false => 8441,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8442,
                                        false => 8443,
                                    },
                                    false => West switch {
                                        true => 8444,
                                        false => 8445,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8446,
                                        false => 8447,
                                    },
                                    false => West switch {
                                        true => 8448,
                                        false => 8449,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8450,
                                        false => 8451,
                                    },
                                    false => West switch {
                                        true => 8452,
                                        false => 8453,
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
                                        true => 8454,
                                        false => 8455,
                                    },
                                    false => West switch {
                                        true => 8456,
                                        false => 8457,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8458,
                                        false => 8459,
                                    },
                                    false => West switch {
                                        true => 8460,
                                        false => 8461,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8462,
                                        false => 8463,
                                    },
                                    false => West switch {
                                        true => 8464,
                                        false => 8465,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8466,
                                        false => 8467,
                                    },
                                    false => West switch {
                                        true => 8468,
                                        false => 8469,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8470,
                                        false => 8471,
                                    },
                                    false => West switch {
                                        true => 8472,
                                        false => 8473,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8474,
                                        false => 8475,
                                    },
                                    false => West switch {
                                        true => 8476,
                                        false => 8477,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8478,
                                        false => 8479,
                                    },
                                    false => West switch {
                                        true => 8480,
                                        false => 8481,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8482,
                                        false => 8483,
                                    },
                                    false => West switch {
                                        true => 8484,
                                        false => 8485,
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
                                        true => 8486,
                                        false => 8487,
                                    },
                                    false => West switch {
                                        true => 8488,
                                        false => 8489,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8490,
                                        false => 8491,
                                    },
                                    false => West switch {
                                        true => 8492,
                                        false => 8493,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8494,
                                        false => 8495,
                                    },
                                    false => West switch {
                                        true => 8496,
                                        false => 8497,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8498,
                                        false => 8499,
                                    },
                                    false => West switch {
                                        true => 8500,
                                        false => 8501,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8502,
                                        false => 8503,
                                    },
                                    false => West switch {
                                        true => 8504,
                                        false => 8505,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8506,
                                        false => 8507,
                                    },
                                    false => West switch {
                                        true => 8508,
                                        false => 8509,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8510,
                                        false => 8511,
                                    },
                                    false => West switch {
                                        true => 8512,
                                        false => 8513,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8514,
                                        false => 8515,
                                    },
                                    false => West switch {
                                        true => 8516,
                                        false => 8517,
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
            8390 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, true),
            8391 => new GlowLichenBlock(Identifier, true, true, true, true, true, true, false),
            8392 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, true),
            8393 => new GlowLichenBlock(Identifier, true, true, true, true, true, false, false),
            8394 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, true),
            8395 => new GlowLichenBlock(Identifier, true, true, true, true, false, true, false),
            8396 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, true),
            8397 => new GlowLichenBlock(Identifier, true, true, true, true, false, false, false),
            8398 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, true),
            8399 => new GlowLichenBlock(Identifier, true, true, true, false, true, true, false),
            8400 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, true),
            8401 => new GlowLichenBlock(Identifier, true, true, true, false, true, false, false),
            8402 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, true),
            8403 => new GlowLichenBlock(Identifier, true, true, true, false, false, true, false),
            8404 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, true),
            8405 => new GlowLichenBlock(Identifier, true, true, true, false, false, false, false),
            8406 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, true),
            8407 => new GlowLichenBlock(Identifier, true, true, false, true, true, true, false),
            8408 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, true),
            8409 => new GlowLichenBlock(Identifier, true, true, false, true, true, false, false),
            8410 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, true),
            8411 => new GlowLichenBlock(Identifier, true, true, false, true, false, true, false),
            8412 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, true),
            8413 => new GlowLichenBlock(Identifier, true, true, false, true, false, false, false),
            8414 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, true),
            8415 => new GlowLichenBlock(Identifier, true, true, false, false, true, true, false),
            8416 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, true),
            8417 => new GlowLichenBlock(Identifier, true, true, false, false, true, false, false),
            8418 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, true),
            8419 => new GlowLichenBlock(Identifier, true, true, false, false, false, true, false),
            8420 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, true),
            8421 => new GlowLichenBlock(Identifier, true, true, false, false, false, false, false),
            8422 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, true),
            8423 => new GlowLichenBlock(Identifier, true, false, true, true, true, true, false),
            8424 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, true),
            8425 => new GlowLichenBlock(Identifier, true, false, true, true, true, false, false),
            8426 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, true),
            8427 => new GlowLichenBlock(Identifier, true, false, true, true, false, true, false),
            8428 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, true),
            8429 => new GlowLichenBlock(Identifier, true, false, true, true, false, false, false),
            8430 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, true),
            8431 => new GlowLichenBlock(Identifier, true, false, true, false, true, true, false),
            8432 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, true),
            8433 => new GlowLichenBlock(Identifier, true, false, true, false, true, false, false),
            8434 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, true),
            8435 => new GlowLichenBlock(Identifier, true, false, true, false, false, true, false),
            8436 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, true),
            8437 => new GlowLichenBlock(Identifier, true, false, true, false, false, false, false),
            8438 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, true),
            8439 => new GlowLichenBlock(Identifier, true, false, false, true, true, true, false),
            8440 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, true),
            8441 => new GlowLichenBlock(Identifier, true, false, false, true, true, false, false),
            8442 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, true),
            8443 => new GlowLichenBlock(Identifier, true, false, false, true, false, true, false),
            8444 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, true),
            8445 => new GlowLichenBlock(Identifier, true, false, false, true, false, false, false),
            8446 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, true),
            8447 => new GlowLichenBlock(Identifier, true, false, false, false, true, true, false),
            8448 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, true),
            8449 => new GlowLichenBlock(Identifier, true, false, false, false, true, false, false),
            8450 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, true),
            8451 => new GlowLichenBlock(Identifier, true, false, false, false, false, true, false),
            8452 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, true),
            8453 => new GlowLichenBlock(Identifier, true, false, false, false, false, false, false),
            8454 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, true),
            8455 => new GlowLichenBlock(Identifier, false, true, true, true, true, true, false),
            8456 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, true),
            8457 => new GlowLichenBlock(Identifier, false, true, true, true, true, false, false),
            8458 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, true),
            8459 => new GlowLichenBlock(Identifier, false, true, true, true, false, true, false),
            8460 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, true),
            8461 => new GlowLichenBlock(Identifier, false, true, true, true, false, false, false),
            8462 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, true),
            8463 => new GlowLichenBlock(Identifier, false, true, true, false, true, true, false),
            8464 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, true),
            8465 => new GlowLichenBlock(Identifier, false, true, true, false, true, false, false),
            8466 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, true),
            8467 => new GlowLichenBlock(Identifier, false, true, true, false, false, true, false),
            8468 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, true),
            8469 => new GlowLichenBlock(Identifier, false, true, true, false, false, false, false),
            8470 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, true),
            8471 => new GlowLichenBlock(Identifier, false, true, false, true, true, true, false),
            8472 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, true),
            8473 => new GlowLichenBlock(Identifier, false, true, false, true, true, false, false),
            8474 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, true),
            8475 => new GlowLichenBlock(Identifier, false, true, false, true, false, true, false),
            8476 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, true),
            8477 => new GlowLichenBlock(Identifier, false, true, false, true, false, false, false),
            8478 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, true),
            8479 => new GlowLichenBlock(Identifier, false, true, false, false, true, true, false),
            8480 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, true),
            8481 => new GlowLichenBlock(Identifier, false, true, false, false, true, false, false),
            8482 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, true),
            8483 => new GlowLichenBlock(Identifier, false, true, false, false, false, true, false),
            8484 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, true),
            8485 => new GlowLichenBlock(Identifier, false, true, false, false, false, false, false),
            8486 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, true),
            8487 => new GlowLichenBlock(Identifier, false, false, true, true, true, true, false),
            8488 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, true),
            8489 => new GlowLichenBlock(Identifier, false, false, true, true, true, false, false),
            8490 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, true),
            8491 => new GlowLichenBlock(Identifier, false, false, true, true, false, true, false),
            8492 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, true),
            8493 => new GlowLichenBlock(Identifier, false, false, true, true, false, false, false),
            8494 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, true),
            8495 => new GlowLichenBlock(Identifier, false, false, true, false, true, true, false),
            8496 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, true),
            8497 => new GlowLichenBlock(Identifier, false, false, true, false, true, false, false),
            8498 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, true),
            8499 => new GlowLichenBlock(Identifier, false, false, true, false, false, true, false),
            8500 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, true),
            8501 => new GlowLichenBlock(Identifier, false, false, true, false, false, false, false),
            8502 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, true),
            8503 => new GlowLichenBlock(Identifier, false, false, false, true, true, true, false),
            8504 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, true),
            8505 => new GlowLichenBlock(Identifier, false, false, false, true, true, false, false),
            8506 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, true),
            8507 => new GlowLichenBlock(Identifier, false, false, false, true, false, true, false),
            8508 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, true),
            8509 => new GlowLichenBlock(Identifier, false, false, false, true, false, false, false),
            8510 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, true),
            8511 => new GlowLichenBlock(Identifier, false, false, false, false, true, true, false),
            8512 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, true),
            8513 => new GlowLichenBlock(Identifier, false, false, false, false, true, false, false),
            8514 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, true),
            8515 => new GlowLichenBlock(Identifier, false, false, false, false, false, true, false),
            8516 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, true),
            8517 => new GlowLichenBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.Contains("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("down", new StringTag(Down.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
