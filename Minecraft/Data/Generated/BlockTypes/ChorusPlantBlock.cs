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
                                    true => 14642,
                                    false => 14643,
                                },
                                false => West switch {
                                    true => 14644,
                                    false => 14645,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14646,
                                    false => 14647,
                                },
                                false => West switch {
                                    true => 14648,
                                    false => 14649,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14650,
                                    false => 14651,
                                },
                                false => West switch {
                                    true => 14652,
                                    false => 14653,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14654,
                                    false => 14655,
                                },
                                false => West switch {
                                    true => 14656,
                                    false => 14657,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14658,
                                    false => 14659,
                                },
                                false => West switch {
                                    true => 14660,
                                    false => 14661,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14662,
                                    false => 14663,
                                },
                                false => West switch {
                                    true => 14664,
                                    false => 14665,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14666,
                                    false => 14667,
                                },
                                false => West switch {
                                    true => 14668,
                                    false => 14669,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14670,
                                    false => 14671,
                                },
                                false => West switch {
                                    true => 14672,
                                    false => 14673,
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
                                    true => 14674,
                                    false => 14675,
                                },
                                false => West switch {
                                    true => 14676,
                                    false => 14677,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14678,
                                    false => 14679,
                                },
                                false => West switch {
                                    true => 14680,
                                    false => 14681,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14682,
                                    false => 14683,
                                },
                                false => West switch {
                                    true => 14684,
                                    false => 14685,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14686,
                                    false => 14687,
                                },
                                false => West switch {
                                    true => 14688,
                                    false => 14689,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14690,
                                    false => 14691,
                                },
                                false => West switch {
                                    true => 14692,
                                    false => 14693,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14694,
                                    false => 14695,
                                },
                                false => West switch {
                                    true => 14696,
                                    false => 14697,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14698,
                                    false => 14699,
                                },
                                false => West switch {
                                    true => 14700,
                                    false => 14701,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14702,
                                    false => 14703,
                                },
                                false => West switch {
                                    true => 14704,
                                    false => 14705,
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
            14642 => new ChorusPlantBlock(Identifier, true, true, true, true, true, true),
            14643 => new ChorusPlantBlock(Identifier, true, true, true, true, true, false),
            14644 => new ChorusPlantBlock(Identifier, true, true, true, true, false, true),
            14645 => new ChorusPlantBlock(Identifier, true, true, true, true, false, false),
            14646 => new ChorusPlantBlock(Identifier, true, true, true, false, true, true),
            14647 => new ChorusPlantBlock(Identifier, true, true, true, false, true, false),
            14648 => new ChorusPlantBlock(Identifier, true, true, true, false, false, true),
            14649 => new ChorusPlantBlock(Identifier, true, true, true, false, false, false),
            14650 => new ChorusPlantBlock(Identifier, true, true, false, true, true, true),
            14651 => new ChorusPlantBlock(Identifier, true, true, false, true, true, false),
            14652 => new ChorusPlantBlock(Identifier, true, true, false, true, false, true),
            14653 => new ChorusPlantBlock(Identifier, true, true, false, true, false, false),
            14654 => new ChorusPlantBlock(Identifier, true, true, false, false, true, true),
            14655 => new ChorusPlantBlock(Identifier, true, true, false, false, true, false),
            14656 => new ChorusPlantBlock(Identifier, true, true, false, false, false, true),
            14657 => new ChorusPlantBlock(Identifier, true, true, false, false, false, false),
            14658 => new ChorusPlantBlock(Identifier, true, false, true, true, true, true),
            14659 => new ChorusPlantBlock(Identifier, true, false, true, true, true, false),
            14660 => new ChorusPlantBlock(Identifier, true, false, true, true, false, true),
            14661 => new ChorusPlantBlock(Identifier, true, false, true, true, false, false),
            14662 => new ChorusPlantBlock(Identifier, true, false, true, false, true, true),
            14663 => new ChorusPlantBlock(Identifier, true, false, true, false, true, false),
            14664 => new ChorusPlantBlock(Identifier, true, false, true, false, false, true),
            14665 => new ChorusPlantBlock(Identifier, true, false, true, false, false, false),
            14666 => new ChorusPlantBlock(Identifier, true, false, false, true, true, true),
            14667 => new ChorusPlantBlock(Identifier, true, false, false, true, true, false),
            14668 => new ChorusPlantBlock(Identifier, true, false, false, true, false, true),
            14669 => new ChorusPlantBlock(Identifier, true, false, false, true, false, false),
            14670 => new ChorusPlantBlock(Identifier, true, false, false, false, true, true),
            14671 => new ChorusPlantBlock(Identifier, true, false, false, false, true, false),
            14672 => new ChorusPlantBlock(Identifier, true, false, false, false, false, true),
            14673 => new ChorusPlantBlock(Identifier, true, false, false, false, false, false),
            14674 => new ChorusPlantBlock(Identifier, false, true, true, true, true, true),
            14675 => new ChorusPlantBlock(Identifier, false, true, true, true, true, false),
            14676 => new ChorusPlantBlock(Identifier, false, true, true, true, false, true),
            14677 => new ChorusPlantBlock(Identifier, false, true, true, true, false, false),
            14678 => new ChorusPlantBlock(Identifier, false, true, true, false, true, true),
            14679 => new ChorusPlantBlock(Identifier, false, true, true, false, true, false),
            14680 => new ChorusPlantBlock(Identifier, false, true, true, false, false, true),
            14681 => new ChorusPlantBlock(Identifier, false, true, true, false, false, false),
            14682 => new ChorusPlantBlock(Identifier, false, true, false, true, true, true),
            14683 => new ChorusPlantBlock(Identifier, false, true, false, true, true, false),
            14684 => new ChorusPlantBlock(Identifier, false, true, false, true, false, true),
            14685 => new ChorusPlantBlock(Identifier, false, true, false, true, false, false),
            14686 => new ChorusPlantBlock(Identifier, false, true, false, false, true, true),
            14687 => new ChorusPlantBlock(Identifier, false, true, false, false, true, false),
            14688 => new ChorusPlantBlock(Identifier, false, true, false, false, false, true),
            14689 => new ChorusPlantBlock(Identifier, false, true, false, false, false, false),
            14690 => new ChorusPlantBlock(Identifier, false, false, true, true, true, true),
            14691 => new ChorusPlantBlock(Identifier, false, false, true, true, true, false),
            14692 => new ChorusPlantBlock(Identifier, false, false, true, true, false, true),
            14693 => new ChorusPlantBlock(Identifier, false, false, true, true, false, false),
            14694 => new ChorusPlantBlock(Identifier, false, false, true, false, true, true),
            14695 => new ChorusPlantBlock(Identifier, false, false, true, false, true, false),
            14696 => new ChorusPlantBlock(Identifier, false, false, true, false, false, true),
            14697 => new ChorusPlantBlock(Identifier, false, false, true, false, false, false),
            14698 => new ChorusPlantBlock(Identifier, false, false, false, true, true, true),
            14699 => new ChorusPlantBlock(Identifier, false, false, false, true, true, false),
            14700 => new ChorusPlantBlock(Identifier, false, false, false, true, false, true),
            14701 => new ChorusPlantBlock(Identifier, false, false, false, true, false, false),
            14702 => new ChorusPlantBlock(Identifier, false, false, false, false, true, true),
            14703 => new ChorusPlantBlock(Identifier, false, false, false, false, true, false),
            14704 => new ChorusPlantBlock(Identifier, false, false, false, false, false, true),
            14705 => new ChorusPlantBlock(Identifier, false, false, false, false, false, false),
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
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
