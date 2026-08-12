using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinClumpBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:multiface";
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
    public bool Replaceable => true;
    public string SoundType => "resin";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:resin_clump";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 37;
    public string TranslationKey => "block.minecraft.resin_clump";
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
                                        true => 8518,
                                        false => 8519,
                                    },
                                    false => West switch {
                                        true => 8520,
                                        false => 8521,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8522,
                                        false => 8523,
                                    },
                                    false => West switch {
                                        true => 8524,
                                        false => 8525,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8526,
                                        false => 8527,
                                    },
                                    false => West switch {
                                        true => 8528,
                                        false => 8529,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8530,
                                        false => 8531,
                                    },
                                    false => West switch {
                                        true => 8532,
                                        false => 8533,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8534,
                                        false => 8535,
                                    },
                                    false => West switch {
                                        true => 8536,
                                        false => 8537,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8538,
                                        false => 8539,
                                    },
                                    false => West switch {
                                        true => 8540,
                                        false => 8541,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8542,
                                        false => 8543,
                                    },
                                    false => West switch {
                                        true => 8544,
                                        false => 8545,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8546,
                                        false => 8547,
                                    },
                                    false => West switch {
                                        true => 8548,
                                        false => 8549,
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
                                        true => 8550,
                                        false => 8551,
                                    },
                                    false => West switch {
                                        true => 8552,
                                        false => 8553,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8554,
                                        false => 8555,
                                    },
                                    false => West switch {
                                        true => 8556,
                                        false => 8557,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8558,
                                        false => 8559,
                                    },
                                    false => West switch {
                                        true => 8560,
                                        false => 8561,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8562,
                                        false => 8563,
                                    },
                                    false => West switch {
                                        true => 8564,
                                        false => 8565,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8566,
                                        false => 8567,
                                    },
                                    false => West switch {
                                        true => 8568,
                                        false => 8569,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8570,
                                        false => 8571,
                                    },
                                    false => West switch {
                                        true => 8572,
                                        false => 8573,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8574,
                                        false => 8575,
                                    },
                                    false => West switch {
                                        true => 8576,
                                        false => 8577,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8578,
                                        false => 8579,
                                    },
                                    false => West switch {
                                        true => 8580,
                                        false => 8581,
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
                                        true => 8582,
                                        false => 8583,
                                    },
                                    false => West switch {
                                        true => 8584,
                                        false => 8585,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8586,
                                        false => 8587,
                                    },
                                    false => West switch {
                                        true => 8588,
                                        false => 8589,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8590,
                                        false => 8591,
                                    },
                                    false => West switch {
                                        true => 8592,
                                        false => 8593,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8594,
                                        false => 8595,
                                    },
                                    false => West switch {
                                        true => 8596,
                                        false => 8597,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8598,
                                        false => 8599,
                                    },
                                    false => West switch {
                                        true => 8600,
                                        false => 8601,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8602,
                                        false => 8603,
                                    },
                                    false => West switch {
                                        true => 8604,
                                        false => 8605,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8606,
                                        false => 8607,
                                    },
                                    false => West switch {
                                        true => 8608,
                                        false => 8609,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8610,
                                        false => 8611,
                                    },
                                    false => West switch {
                                        true => 8612,
                                        false => 8613,
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
                                        true => 8614,
                                        false => 8615,
                                    },
                                    false => West switch {
                                        true => 8616,
                                        false => 8617,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8618,
                                        false => 8619,
                                    },
                                    false => West switch {
                                        true => 8620,
                                        false => 8621,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8622,
                                        false => 8623,
                                    },
                                    false => West switch {
                                        true => 8624,
                                        false => 8625,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8626,
                                        false => 8627,
                                    },
                                    false => West switch {
                                        true => 8628,
                                        false => 8629,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8630,
                                        false => 8631,
                                    },
                                    false => West switch {
                                        true => 8632,
                                        false => 8633,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8634,
                                        false => 8635,
                                    },
                                    false => West switch {
                                        true => 8636,
                                        false => 8637,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8638,
                                        false => 8639,
                                    },
                                    false => West switch {
                                        true => 8640,
                                        false => 8641,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8642,
                                        false => 8643,
                                    },
                                    false => West switch {
                                        true => 8644,
                                        false => 8645,
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
            8518 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, true),
            8519 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, false),
            8520 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, true),
            8521 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, false),
            8522 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, true),
            8523 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, false),
            8524 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, true),
            8525 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, false),
            8526 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, true),
            8527 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, false),
            8528 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, true),
            8529 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, false),
            8530 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, true),
            8531 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, false),
            8532 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, true),
            8533 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, false),
            8534 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, true),
            8535 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, false),
            8536 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, true),
            8537 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, false),
            8538 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, true),
            8539 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, false),
            8540 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, true),
            8541 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, false),
            8542 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, true),
            8543 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, false),
            8544 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, true),
            8545 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, false),
            8546 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, true),
            8547 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, false),
            8548 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, true),
            8549 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, false),
            8550 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, true),
            8551 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, false),
            8552 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, true),
            8553 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, false),
            8554 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, true),
            8555 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, false),
            8556 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, true),
            8557 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, false),
            8558 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, true),
            8559 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, false),
            8560 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, true),
            8561 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, false),
            8562 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, true),
            8563 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, false),
            8564 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, true),
            8565 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, false),
            8566 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, true),
            8567 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, false),
            8568 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, true),
            8569 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, false),
            8570 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, true),
            8571 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, false),
            8572 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, true),
            8573 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, false),
            8574 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, true),
            8575 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, false),
            8576 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, true),
            8577 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, false),
            8578 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, true),
            8579 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, false),
            8580 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, true),
            8581 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, false),
            8582 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, true),
            8583 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, false),
            8584 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, true),
            8585 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, false),
            8586 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, true),
            8587 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, false),
            8588 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, true),
            8589 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, false),
            8590 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, true),
            8591 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, false),
            8592 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, true),
            8593 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, false),
            8594 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, true),
            8595 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, false),
            8596 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, true),
            8597 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, false),
            8598 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, true),
            8599 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, false),
            8600 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, true),
            8601 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, false),
            8602 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, true),
            8603 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, false),
            8604 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, true),
            8605 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, false),
            8606 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, true),
            8607 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, false),
            8608 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, true),
            8609 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, false),
            8610 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, true),
            8611 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, false),
            8612 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, true),
            8613 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, false),
            8614 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, true),
            8615 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, false),
            8616 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, true),
            8617 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, false),
            8618 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, true),
            8619 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, false),
            8620 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, true),
            8621 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, false),
            8622 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, true),
            8623 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, false),
            8624 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, true),
            8625 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, false),
            8626 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, true),
            8627 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, false),
            8628 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, true),
            8629 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, false),
            8630 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, true),
            8631 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, false),
            8632 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, true),
            8633 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, false),
            8634 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, true),
            8635 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, false),
            8636 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, true),
            8637 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, false),
            8638 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, true),
            8639 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, false),
            8640 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, true),
            8641 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, false),
            8642 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, true),
            8643 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, false),
            8644 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, true),
            8645 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, false),
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
