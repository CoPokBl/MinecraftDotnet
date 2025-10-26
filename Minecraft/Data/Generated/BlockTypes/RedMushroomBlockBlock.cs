using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:huge_mushroom";
    public int ProtocolId => 338;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:red_mushroom_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.red_mushroom_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7629,
                                    false => 7630,
                                },
                                false => West switch {
                                    true => 7631,
                                    false => 7632,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7633,
                                    false => 7634,
                                },
                                false => West switch {
                                    true => 7635,
                                    false => 7636,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7637,
                                    false => 7638,
                                },
                                false => West switch {
                                    true => 7639,
                                    false => 7640,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7641,
                                    false => 7642,
                                },
                                false => West switch {
                                    true => 7643,
                                    false => 7644,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7645,
                                    false => 7646,
                                },
                                false => West switch {
                                    true => 7647,
                                    false => 7648,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7649,
                                    false => 7650,
                                },
                                false => West switch {
                                    true => 7651,
                                    false => 7652,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7653,
                                    false => 7654,
                                },
                                false => West switch {
                                    true => 7655,
                                    false => 7656,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7657,
                                    false => 7658,
                                },
                                false => West switch {
                                    true => 7659,
                                    false => 7660,
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
                                    true => 7661,
                                    false => 7662,
                                },
                                false => West switch {
                                    true => 7663,
                                    false => 7664,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7665,
                                    false => 7666,
                                },
                                false => West switch {
                                    true => 7667,
                                    false => 7668,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7669,
                                    false => 7670,
                                },
                                false => West switch {
                                    true => 7671,
                                    false => 7672,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7673,
                                    false => 7674,
                                },
                                false => West switch {
                                    true => 7675,
                                    false => 7676,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7677,
                                    false => 7678,
                                },
                                false => West switch {
                                    true => 7679,
                                    false => 7680,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7681,
                                    false => 7682,
                                },
                                false => West switch {
                                    true => 7683,
                                    false => 7684,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7685,
                                    false => 7686,
                                },
                                false => West switch {
                                    true => 7687,
                                    false => 7688,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7689,
                                    false => 7690,
                                },
                                false => West switch {
                                    true => 7691,
                                    false => 7692,
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
            7629 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            7630 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            7631 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            7632 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            7633 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            7634 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            7635 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            7636 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            7637 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            7638 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            7639 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            7640 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            7641 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            7642 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            7643 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            7644 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            7645 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            7646 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            7647 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            7648 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            7649 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            7650 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            7651 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            7652 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            7653 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            7654 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            7655 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            7656 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            7657 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            7658 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            7659 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            7660 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            7661 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            7662 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            7663 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            7664 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            7665 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            7666 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            7667 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            7668 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            7669 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            7670 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            7671 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            7672 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            7673 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            7674 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            7675 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            7676 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            7677 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            7678 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            7679 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            7680 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            7681 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            7682 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            7683 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            7684 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            7685 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            7686 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            7687 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            7688 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            7689 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            7690 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            7691 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            7692 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, false),
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
