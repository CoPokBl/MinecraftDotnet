using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TripwireBlock(Identifier Identifier, bool Attached, bool Disarmed, bool East, bool North, bool Powered, bool South, bool West) : IBlock {
    public Identifier Category => "minecraft:tripwire";
    public int ProtocolId => 401;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:string";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.tripwire";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Disarmed switch {
                    true => East switch {
                        true => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9398,
                                        false => 9399,
                                    },
                                    false => West switch {
                                        true => 9400,
                                        false => 9401,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9402,
                                        false => 9403,
                                    },
                                    false => West switch {
                                        true => 9404,
                                        false => 9405,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9406,
                                        false => 9407,
                                    },
                                    false => West switch {
                                        true => 9408,
                                        false => 9409,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9410,
                                        false => 9411,
                                    },
                                    false => West switch {
                                        true => 9412,
                                        false => 9413,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9414,
                                        false => 9415,
                                    },
                                    false => West switch {
                                        true => 9416,
                                        false => 9417,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9418,
                                        false => 9419,
                                    },
                                    false => West switch {
                                        true => 9420,
                                        false => 9421,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9422,
                                        false => 9423,
                                    },
                                    false => West switch {
                                        true => 9424,
                                        false => 9425,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9426,
                                        false => 9427,
                                    },
                                    false => West switch {
                                        true => 9428,
                                        false => 9429,
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
                                        true => 9430,
                                        false => 9431,
                                    },
                                    false => West switch {
                                        true => 9432,
                                        false => 9433,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9434,
                                        false => 9435,
                                    },
                                    false => West switch {
                                        true => 9436,
                                        false => 9437,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9438,
                                        false => 9439,
                                    },
                                    false => West switch {
                                        true => 9440,
                                        false => 9441,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9442,
                                        false => 9443,
                                    },
                                    false => West switch {
                                        true => 9444,
                                        false => 9445,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9446,
                                        false => 9447,
                                    },
                                    false => West switch {
                                        true => 9448,
                                        false => 9449,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9450,
                                        false => 9451,
                                    },
                                    false => West switch {
                                        true => 9452,
                                        false => 9453,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9454,
                                        false => 9455,
                                    },
                                    false => West switch {
                                        true => 9456,
                                        false => 9457,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9458,
                                        false => 9459,
                                    },
                                    false => West switch {
                                        true => 9460,
                                        false => 9461,
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
                                        true => 9462,
                                        false => 9463,
                                    },
                                    false => West switch {
                                        true => 9464,
                                        false => 9465,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9466,
                                        false => 9467,
                                    },
                                    false => West switch {
                                        true => 9468,
                                        false => 9469,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9470,
                                        false => 9471,
                                    },
                                    false => West switch {
                                        true => 9472,
                                        false => 9473,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9474,
                                        false => 9475,
                                    },
                                    false => West switch {
                                        true => 9476,
                                        false => 9477,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9478,
                                        false => 9479,
                                    },
                                    false => West switch {
                                        true => 9480,
                                        false => 9481,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9482,
                                        false => 9483,
                                    },
                                    false => West switch {
                                        true => 9484,
                                        false => 9485,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9486,
                                        false => 9487,
                                    },
                                    false => West switch {
                                        true => 9488,
                                        false => 9489,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9490,
                                        false => 9491,
                                    },
                                    false => West switch {
                                        true => 9492,
                                        false => 9493,
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
                                        true => 9494,
                                        false => 9495,
                                    },
                                    false => West switch {
                                        true => 9496,
                                        false => 9497,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9498,
                                        false => 9499,
                                    },
                                    false => West switch {
                                        true => 9500,
                                        false => 9501,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9502,
                                        false => 9503,
                                    },
                                    false => West switch {
                                        true => 9504,
                                        false => 9505,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9506,
                                        false => 9507,
                                    },
                                    false => West switch {
                                        true => 9508,
                                        false => 9509,
                                    },
                                },
                            },
                        },
                        false => North switch {
                            true => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9510,
                                        false => 9511,
                                    },
                                    false => West switch {
                                        true => 9512,
                                        false => 9513,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9514,
                                        false => 9515,
                                    },
                                    false => West switch {
                                        true => 9516,
                                        false => 9517,
                                    },
                                },
                            },
                            false => Powered switch {
                                true => South switch {
                                    true => West switch {
                                        true => 9518,
                                        false => 9519,
                                    },
                                    false => West switch {
                                        true => 9520,
                                        false => 9521,
                                    },
                                },
                                false => South switch {
                                    true => West switch {
                                        true => 9522,
                                        false => 9523,
                                    },
                                    false => West switch {
                                        true => 9524,
                                        false => 9525,
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
            9398 => new TripwireBlock(Identifier, true, true, true, true, true, true, true),
            9399 => new TripwireBlock(Identifier, true, true, true, true, true, true, false),
            9400 => new TripwireBlock(Identifier, true, true, true, true, true, false, true),
            9401 => new TripwireBlock(Identifier, true, true, true, true, true, false, false),
            9402 => new TripwireBlock(Identifier, true, true, true, true, false, true, true),
            9403 => new TripwireBlock(Identifier, true, true, true, true, false, true, false),
            9404 => new TripwireBlock(Identifier, true, true, true, true, false, false, true),
            9405 => new TripwireBlock(Identifier, true, true, true, true, false, false, false),
            9406 => new TripwireBlock(Identifier, true, true, true, false, true, true, true),
            9407 => new TripwireBlock(Identifier, true, true, true, false, true, true, false),
            9408 => new TripwireBlock(Identifier, true, true, true, false, true, false, true),
            9409 => new TripwireBlock(Identifier, true, true, true, false, true, false, false),
            9410 => new TripwireBlock(Identifier, true, true, true, false, false, true, true),
            9411 => new TripwireBlock(Identifier, true, true, true, false, false, true, false),
            9412 => new TripwireBlock(Identifier, true, true, true, false, false, false, true),
            9413 => new TripwireBlock(Identifier, true, true, true, false, false, false, false),
            9414 => new TripwireBlock(Identifier, true, true, false, true, true, true, true),
            9415 => new TripwireBlock(Identifier, true, true, false, true, true, true, false),
            9416 => new TripwireBlock(Identifier, true, true, false, true, true, false, true),
            9417 => new TripwireBlock(Identifier, true, true, false, true, true, false, false),
            9418 => new TripwireBlock(Identifier, true, true, false, true, false, true, true),
            9419 => new TripwireBlock(Identifier, true, true, false, true, false, true, false),
            9420 => new TripwireBlock(Identifier, true, true, false, true, false, false, true),
            9421 => new TripwireBlock(Identifier, true, true, false, true, false, false, false),
            9422 => new TripwireBlock(Identifier, true, true, false, false, true, true, true),
            9423 => new TripwireBlock(Identifier, true, true, false, false, true, true, false),
            9424 => new TripwireBlock(Identifier, true, true, false, false, true, false, true),
            9425 => new TripwireBlock(Identifier, true, true, false, false, true, false, false),
            9426 => new TripwireBlock(Identifier, true, true, false, false, false, true, true),
            9427 => new TripwireBlock(Identifier, true, true, false, false, false, true, false),
            9428 => new TripwireBlock(Identifier, true, true, false, false, false, false, true),
            9429 => new TripwireBlock(Identifier, true, true, false, false, false, false, false),
            9430 => new TripwireBlock(Identifier, true, false, true, true, true, true, true),
            9431 => new TripwireBlock(Identifier, true, false, true, true, true, true, false),
            9432 => new TripwireBlock(Identifier, true, false, true, true, true, false, true),
            9433 => new TripwireBlock(Identifier, true, false, true, true, true, false, false),
            9434 => new TripwireBlock(Identifier, true, false, true, true, false, true, true),
            9435 => new TripwireBlock(Identifier, true, false, true, true, false, true, false),
            9436 => new TripwireBlock(Identifier, true, false, true, true, false, false, true),
            9437 => new TripwireBlock(Identifier, true, false, true, true, false, false, false),
            9438 => new TripwireBlock(Identifier, true, false, true, false, true, true, true),
            9439 => new TripwireBlock(Identifier, true, false, true, false, true, true, false),
            9440 => new TripwireBlock(Identifier, true, false, true, false, true, false, true),
            9441 => new TripwireBlock(Identifier, true, false, true, false, true, false, false),
            9442 => new TripwireBlock(Identifier, true, false, true, false, false, true, true),
            9443 => new TripwireBlock(Identifier, true, false, true, false, false, true, false),
            9444 => new TripwireBlock(Identifier, true, false, true, false, false, false, true),
            9445 => new TripwireBlock(Identifier, true, false, true, false, false, false, false),
            9446 => new TripwireBlock(Identifier, true, false, false, true, true, true, true),
            9447 => new TripwireBlock(Identifier, true, false, false, true, true, true, false),
            9448 => new TripwireBlock(Identifier, true, false, false, true, true, false, true),
            9449 => new TripwireBlock(Identifier, true, false, false, true, true, false, false),
            9450 => new TripwireBlock(Identifier, true, false, false, true, false, true, true),
            9451 => new TripwireBlock(Identifier, true, false, false, true, false, true, false),
            9452 => new TripwireBlock(Identifier, true, false, false, true, false, false, true),
            9453 => new TripwireBlock(Identifier, true, false, false, true, false, false, false),
            9454 => new TripwireBlock(Identifier, true, false, false, false, true, true, true),
            9455 => new TripwireBlock(Identifier, true, false, false, false, true, true, false),
            9456 => new TripwireBlock(Identifier, true, false, false, false, true, false, true),
            9457 => new TripwireBlock(Identifier, true, false, false, false, true, false, false),
            9458 => new TripwireBlock(Identifier, true, false, false, false, false, true, true),
            9459 => new TripwireBlock(Identifier, true, false, false, false, false, true, false),
            9460 => new TripwireBlock(Identifier, true, false, false, false, false, false, true),
            9461 => new TripwireBlock(Identifier, true, false, false, false, false, false, false),
            9462 => new TripwireBlock(Identifier, false, true, true, true, true, true, true),
            9463 => new TripwireBlock(Identifier, false, true, true, true, true, true, false),
            9464 => new TripwireBlock(Identifier, false, true, true, true, true, false, true),
            9465 => new TripwireBlock(Identifier, false, true, true, true, true, false, false),
            9466 => new TripwireBlock(Identifier, false, true, true, true, false, true, true),
            9467 => new TripwireBlock(Identifier, false, true, true, true, false, true, false),
            9468 => new TripwireBlock(Identifier, false, true, true, true, false, false, true),
            9469 => new TripwireBlock(Identifier, false, true, true, true, false, false, false),
            9470 => new TripwireBlock(Identifier, false, true, true, false, true, true, true),
            9471 => new TripwireBlock(Identifier, false, true, true, false, true, true, false),
            9472 => new TripwireBlock(Identifier, false, true, true, false, true, false, true),
            9473 => new TripwireBlock(Identifier, false, true, true, false, true, false, false),
            9474 => new TripwireBlock(Identifier, false, true, true, false, false, true, true),
            9475 => new TripwireBlock(Identifier, false, true, true, false, false, true, false),
            9476 => new TripwireBlock(Identifier, false, true, true, false, false, false, true),
            9477 => new TripwireBlock(Identifier, false, true, true, false, false, false, false),
            9478 => new TripwireBlock(Identifier, false, true, false, true, true, true, true),
            9479 => new TripwireBlock(Identifier, false, true, false, true, true, true, false),
            9480 => new TripwireBlock(Identifier, false, true, false, true, true, false, true),
            9481 => new TripwireBlock(Identifier, false, true, false, true, true, false, false),
            9482 => new TripwireBlock(Identifier, false, true, false, true, false, true, true),
            9483 => new TripwireBlock(Identifier, false, true, false, true, false, true, false),
            9484 => new TripwireBlock(Identifier, false, true, false, true, false, false, true),
            9485 => new TripwireBlock(Identifier, false, true, false, true, false, false, false),
            9486 => new TripwireBlock(Identifier, false, true, false, false, true, true, true),
            9487 => new TripwireBlock(Identifier, false, true, false, false, true, true, false),
            9488 => new TripwireBlock(Identifier, false, true, false, false, true, false, true),
            9489 => new TripwireBlock(Identifier, false, true, false, false, true, false, false),
            9490 => new TripwireBlock(Identifier, false, true, false, false, false, true, true),
            9491 => new TripwireBlock(Identifier, false, true, false, false, false, true, false),
            9492 => new TripwireBlock(Identifier, false, true, false, false, false, false, true),
            9493 => new TripwireBlock(Identifier, false, true, false, false, false, false, false),
            9494 => new TripwireBlock(Identifier, false, false, true, true, true, true, true),
            9495 => new TripwireBlock(Identifier, false, false, true, true, true, true, false),
            9496 => new TripwireBlock(Identifier, false, false, true, true, true, false, true),
            9497 => new TripwireBlock(Identifier, false, false, true, true, true, false, false),
            9498 => new TripwireBlock(Identifier, false, false, true, true, false, true, true),
            9499 => new TripwireBlock(Identifier, false, false, true, true, false, true, false),
            9500 => new TripwireBlock(Identifier, false, false, true, true, false, false, true),
            9501 => new TripwireBlock(Identifier, false, false, true, true, false, false, false),
            9502 => new TripwireBlock(Identifier, false, false, true, false, true, true, true),
            9503 => new TripwireBlock(Identifier, false, false, true, false, true, true, false),
            9504 => new TripwireBlock(Identifier, false, false, true, false, true, false, true),
            9505 => new TripwireBlock(Identifier, false, false, true, false, true, false, false),
            9506 => new TripwireBlock(Identifier, false, false, true, false, false, true, true),
            9507 => new TripwireBlock(Identifier, false, false, true, false, false, true, false),
            9508 => new TripwireBlock(Identifier, false, false, true, false, false, false, true),
            9509 => new TripwireBlock(Identifier, false, false, true, false, false, false, false),
            9510 => new TripwireBlock(Identifier, false, false, false, true, true, true, true),
            9511 => new TripwireBlock(Identifier, false, false, false, true, true, true, false),
            9512 => new TripwireBlock(Identifier, false, false, false, true, true, false, true),
            9513 => new TripwireBlock(Identifier, false, false, false, true, true, false, false),
            9514 => new TripwireBlock(Identifier, false, false, false, true, false, true, true),
            9515 => new TripwireBlock(Identifier, false, false, false, true, false, true, false),
            9516 => new TripwireBlock(Identifier, false, false, false, true, false, false, true),
            9517 => new TripwireBlock(Identifier, false, false, false, true, false, false, false),
            9518 => new TripwireBlock(Identifier, false, false, false, false, true, true, true),
            9519 => new TripwireBlock(Identifier, false, false, false, false, true, true, false),
            9520 => new TripwireBlock(Identifier, false, false, false, false, true, false, true),
            9521 => new TripwireBlock(Identifier, false, false, false, false, true, false, false),
            9522 => new TripwireBlock(Identifier, false, false, false, false, false, true, true),
            9523 => new TripwireBlock(Identifier, false, false, false, false, false, true, false),
            9524 => new TripwireBlock(Identifier, false, false, false, false, false, false, true),
            9525 => new TripwireBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.ChildrenMap.ContainsKey("attached") ? properties["attached"].GetString() == "true" : Attached,
            Disarmed = properties.ChildrenMap.ContainsKey("disarmed") ? properties["disarmed"].GetString() == "true" : Disarmed,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("attached", Attached.ToString().ToLower()),
            new StringTag("disarmed", Disarmed.ToString().ToLower()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
