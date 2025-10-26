using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChorusPlantBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:chorus_plant";
    public int ProtocolId => 654;
    public double Hardness => 0.4;
    public double ExplosionResistance => 0.4;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:chorus_plant";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.1875, 0.1875] -> [0.8125, 0.8125, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.1875, 0.1875] -> [0.8125, 0.8125, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.1875, 0.1875] -> [0.8125, 0.8125, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.chorus_plant";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14440,
                                    false => 14441,
                                },
                                false => West switch {
                                    true => 14442,
                                    false => 14443,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14444,
                                    false => 14445,
                                },
                                false => West switch {
                                    true => 14446,
                                    false => 14447,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14448,
                                    false => 14449,
                                },
                                false => West switch {
                                    true => 14450,
                                    false => 14451,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14452,
                                    false => 14453,
                                },
                                false => West switch {
                                    true => 14454,
                                    false => 14455,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14456,
                                    false => 14457,
                                },
                                false => West switch {
                                    true => 14458,
                                    false => 14459,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14460,
                                    false => 14461,
                                },
                                false => West switch {
                                    true => 14462,
                                    false => 14463,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14464,
                                    false => 14465,
                                },
                                false => West switch {
                                    true => 14466,
                                    false => 14467,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14468,
                                    false => 14469,
                                },
                                false => West switch {
                                    true => 14470,
                                    false => 14471,
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
                                    true => 14472,
                                    false => 14473,
                                },
                                false => West switch {
                                    true => 14474,
                                    false => 14475,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14476,
                                    false => 14477,
                                },
                                false => West switch {
                                    true => 14478,
                                    false => 14479,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14480,
                                    false => 14481,
                                },
                                false => West switch {
                                    true => 14482,
                                    false => 14483,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14484,
                                    false => 14485,
                                },
                                false => West switch {
                                    true => 14486,
                                    false => 14487,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14488,
                                    false => 14489,
                                },
                                false => West switch {
                                    true => 14490,
                                    false => 14491,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14492,
                                    false => 14493,
                                },
                                false => West switch {
                                    true => 14494,
                                    false => 14495,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14496,
                                    false => 14497,
                                },
                                false => West switch {
                                    true => 14498,
                                    false => 14499,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14500,
                                    false => 14501,
                                },
                                false => West switch {
                                    true => 14502,
                                    false => 14503,
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
            14440 => new ChorusPlantBlock(Identifier, true, true, true, true, true, true),
            14441 => new ChorusPlantBlock(Identifier, true, true, true, true, true, false),
            14442 => new ChorusPlantBlock(Identifier, true, true, true, true, false, true),
            14443 => new ChorusPlantBlock(Identifier, true, true, true, true, false, false),
            14444 => new ChorusPlantBlock(Identifier, true, true, true, false, true, true),
            14445 => new ChorusPlantBlock(Identifier, true, true, true, false, true, false),
            14446 => new ChorusPlantBlock(Identifier, true, true, true, false, false, true),
            14447 => new ChorusPlantBlock(Identifier, true, true, true, false, false, false),
            14448 => new ChorusPlantBlock(Identifier, true, true, false, true, true, true),
            14449 => new ChorusPlantBlock(Identifier, true, true, false, true, true, false),
            14450 => new ChorusPlantBlock(Identifier, true, true, false, true, false, true),
            14451 => new ChorusPlantBlock(Identifier, true, true, false, true, false, false),
            14452 => new ChorusPlantBlock(Identifier, true, true, false, false, true, true),
            14453 => new ChorusPlantBlock(Identifier, true, true, false, false, true, false),
            14454 => new ChorusPlantBlock(Identifier, true, true, false, false, false, true),
            14455 => new ChorusPlantBlock(Identifier, true, true, false, false, false, false),
            14456 => new ChorusPlantBlock(Identifier, true, false, true, true, true, true),
            14457 => new ChorusPlantBlock(Identifier, true, false, true, true, true, false),
            14458 => new ChorusPlantBlock(Identifier, true, false, true, true, false, true),
            14459 => new ChorusPlantBlock(Identifier, true, false, true, true, false, false),
            14460 => new ChorusPlantBlock(Identifier, true, false, true, false, true, true),
            14461 => new ChorusPlantBlock(Identifier, true, false, true, false, true, false),
            14462 => new ChorusPlantBlock(Identifier, true, false, true, false, false, true),
            14463 => new ChorusPlantBlock(Identifier, true, false, true, false, false, false),
            14464 => new ChorusPlantBlock(Identifier, true, false, false, true, true, true),
            14465 => new ChorusPlantBlock(Identifier, true, false, false, true, true, false),
            14466 => new ChorusPlantBlock(Identifier, true, false, false, true, false, true),
            14467 => new ChorusPlantBlock(Identifier, true, false, false, true, false, false),
            14468 => new ChorusPlantBlock(Identifier, true, false, false, false, true, true),
            14469 => new ChorusPlantBlock(Identifier, true, false, false, false, true, false),
            14470 => new ChorusPlantBlock(Identifier, true, false, false, false, false, true),
            14471 => new ChorusPlantBlock(Identifier, true, false, false, false, false, false),
            14472 => new ChorusPlantBlock(Identifier, false, true, true, true, true, true),
            14473 => new ChorusPlantBlock(Identifier, false, true, true, true, true, false),
            14474 => new ChorusPlantBlock(Identifier, false, true, true, true, false, true),
            14475 => new ChorusPlantBlock(Identifier, false, true, true, true, false, false),
            14476 => new ChorusPlantBlock(Identifier, false, true, true, false, true, true),
            14477 => new ChorusPlantBlock(Identifier, false, true, true, false, true, false),
            14478 => new ChorusPlantBlock(Identifier, false, true, true, false, false, true),
            14479 => new ChorusPlantBlock(Identifier, false, true, true, false, false, false),
            14480 => new ChorusPlantBlock(Identifier, false, true, false, true, true, true),
            14481 => new ChorusPlantBlock(Identifier, false, true, false, true, true, false),
            14482 => new ChorusPlantBlock(Identifier, false, true, false, true, false, true),
            14483 => new ChorusPlantBlock(Identifier, false, true, false, true, false, false),
            14484 => new ChorusPlantBlock(Identifier, false, true, false, false, true, true),
            14485 => new ChorusPlantBlock(Identifier, false, true, false, false, true, false),
            14486 => new ChorusPlantBlock(Identifier, false, true, false, false, false, true),
            14487 => new ChorusPlantBlock(Identifier, false, true, false, false, false, false),
            14488 => new ChorusPlantBlock(Identifier, false, false, true, true, true, true),
            14489 => new ChorusPlantBlock(Identifier, false, false, true, true, true, false),
            14490 => new ChorusPlantBlock(Identifier, false, false, true, true, false, true),
            14491 => new ChorusPlantBlock(Identifier, false, false, true, true, false, false),
            14492 => new ChorusPlantBlock(Identifier, false, false, true, false, true, true),
            14493 => new ChorusPlantBlock(Identifier, false, false, true, false, true, false),
            14494 => new ChorusPlantBlock(Identifier, false, false, true, false, false, true),
            14495 => new ChorusPlantBlock(Identifier, false, false, true, false, false, false),
            14496 => new ChorusPlantBlock(Identifier, false, false, false, true, true, true),
            14497 => new ChorusPlantBlock(Identifier, false, false, false, true, true, false),
            14498 => new ChorusPlantBlock(Identifier, false, false, false, true, false, true),
            14499 => new ChorusPlantBlock(Identifier, false, false, false, true, false, false),
            14500 => new ChorusPlantBlock(Identifier, false, false, false, false, true, true),
            14501 => new ChorusPlantBlock(Identifier, false, false, false, false, true, false),
            14502 => new ChorusPlantBlock(Identifier, false, false, false, false, false, true),
            14503 => new ChorusPlantBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.ChildrenMap.ContainsKey("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("down", Down.ToString().ToLower()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
