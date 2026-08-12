using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkVeinBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:sculk_vein";
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "sculk_vein";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sculk_vein";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.sculk_vein";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27644,
                                        false => 27645,
                                    },
                                    false => West switch {
                                        true => 27646,
                                        false => 27647,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27648,
                                        false => 27649,
                                    },
                                    false => West switch {
                                        true => 27650,
                                        false => 27651,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27652,
                                        false => 27653,
                                    },
                                    false => West switch {
                                        true => 27654,
                                        false => 27655,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27656,
                                        false => 27657,
                                    },
                                    false => West switch {
                                        true => 27658,
                                        false => 27659,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27660,
                                        false => 27661,
                                    },
                                    false => West switch {
                                        true => 27662,
                                        false => 27663,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27664,
                                        false => 27665,
                                    },
                                    false => West switch {
                                        true => 27666,
                                        false => 27667,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27668,
                                        false => 27669,
                                    },
                                    false => West switch {
                                        true => 27670,
                                        false => 27671,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27672,
                                        false => 27673,
                                    },
                                    false => West switch {
                                        true => 27674,
                                        false => 27675,
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
                                        true => 27676,
                                        false => 27677,
                                    },
                                    false => West switch {
                                        true => 27678,
                                        false => 27679,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27680,
                                        false => 27681,
                                    },
                                    false => West switch {
                                        true => 27682,
                                        false => 27683,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27684,
                                        false => 27685,
                                    },
                                    false => West switch {
                                        true => 27686,
                                        false => 27687,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27688,
                                        false => 27689,
                                    },
                                    false => West switch {
                                        true => 27690,
                                        false => 27691,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27692,
                                        false => 27693,
                                    },
                                    false => West switch {
                                        true => 27694,
                                        false => 27695,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27696,
                                        false => 27697,
                                    },
                                    false => West switch {
                                        true => 27698,
                                        false => 27699,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27700,
                                        false => 27701,
                                    },
                                    false => West switch {
                                        true => 27702,
                                        false => 27703,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27704,
                                        false => 27705,
                                    },
                                    false => West switch {
                                        true => 27706,
                                        false => 27707,
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
                                        true => 27708,
                                        false => 27709,
                                    },
                                    false => West switch {
                                        true => 27710,
                                        false => 27711,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27712,
                                        false => 27713,
                                    },
                                    false => West switch {
                                        true => 27714,
                                        false => 27715,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27716,
                                        false => 27717,
                                    },
                                    false => West switch {
                                        true => 27718,
                                        false => 27719,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27720,
                                        false => 27721,
                                    },
                                    false => West switch {
                                        true => 27722,
                                        false => 27723,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27724,
                                        false => 27725,
                                    },
                                    false => West switch {
                                        true => 27726,
                                        false => 27727,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27728,
                                        false => 27729,
                                    },
                                    false => West switch {
                                        true => 27730,
                                        false => 27731,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27732,
                                        false => 27733,
                                    },
                                    false => West switch {
                                        true => 27734,
                                        false => 27735,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27736,
                                        false => 27737,
                                    },
                                    false => West switch {
                                        true => 27738,
                                        false => 27739,
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
                                        true => 27740,
                                        false => 27741,
                                    },
                                    false => West switch {
                                        true => 27742,
                                        false => 27743,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27744,
                                        false => 27745,
                                    },
                                    false => West switch {
                                        true => 27746,
                                        false => 27747,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27748,
                                        false => 27749,
                                    },
                                    false => West switch {
                                        true => 27750,
                                        false => 27751,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27752,
                                        false => 27753,
                                    },
                                    false => West switch {
                                        true => 27754,
                                        false => 27755,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27756,
                                        false => 27757,
                                    },
                                    false => West switch {
                                        true => 27758,
                                        false => 27759,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27760,
                                        false => 27761,
                                    },
                                    false => West switch {
                                        true => 27762,
                                        false => 27763,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 27764,
                                        false => 27765,
                                    },
                                    false => West switch {
                                        true => 27766,
                                        false => 27767,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 27768,
                                        false => 27769,
                                    },
                                    false => West switch {
                                        true => 27770,
                                        false => 27771,
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
            27644 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, true),
            27645 => new SculkVeinBlock(Identifier, true, true, true, true, true, true, false),
            27646 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, true),
            27647 => new SculkVeinBlock(Identifier, true, true, true, true, true, false, false),
            27648 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, true),
            27649 => new SculkVeinBlock(Identifier, true, true, true, true, false, true, false),
            27650 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, true),
            27651 => new SculkVeinBlock(Identifier, true, true, true, true, false, false, false),
            27652 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, true),
            27653 => new SculkVeinBlock(Identifier, true, true, true, false, true, true, false),
            27654 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, true),
            27655 => new SculkVeinBlock(Identifier, true, true, true, false, true, false, false),
            27656 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, true),
            27657 => new SculkVeinBlock(Identifier, true, true, true, false, false, true, false),
            27658 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, true),
            27659 => new SculkVeinBlock(Identifier, true, true, true, false, false, false, false),
            27660 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, true),
            27661 => new SculkVeinBlock(Identifier, true, true, false, true, true, true, false),
            27662 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, true),
            27663 => new SculkVeinBlock(Identifier, true, true, false, true, true, false, false),
            27664 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, true),
            27665 => new SculkVeinBlock(Identifier, true, true, false, true, false, true, false),
            27666 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, true),
            27667 => new SculkVeinBlock(Identifier, true, true, false, true, false, false, false),
            27668 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, true),
            27669 => new SculkVeinBlock(Identifier, true, true, false, false, true, true, false),
            27670 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, true),
            27671 => new SculkVeinBlock(Identifier, true, true, false, false, true, false, false),
            27672 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, true),
            27673 => new SculkVeinBlock(Identifier, true, true, false, false, false, true, false),
            27674 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, true),
            27675 => new SculkVeinBlock(Identifier, true, true, false, false, false, false, false),
            27676 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, true),
            27677 => new SculkVeinBlock(Identifier, true, false, true, true, true, true, false),
            27678 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, true),
            27679 => new SculkVeinBlock(Identifier, true, false, true, true, true, false, false),
            27680 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, true),
            27681 => new SculkVeinBlock(Identifier, true, false, true, true, false, true, false),
            27682 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, true),
            27683 => new SculkVeinBlock(Identifier, true, false, true, true, false, false, false),
            27684 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, true),
            27685 => new SculkVeinBlock(Identifier, true, false, true, false, true, true, false),
            27686 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, true),
            27687 => new SculkVeinBlock(Identifier, true, false, true, false, true, false, false),
            27688 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, true),
            27689 => new SculkVeinBlock(Identifier, true, false, true, false, false, true, false),
            27690 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, true),
            27691 => new SculkVeinBlock(Identifier, true, false, true, false, false, false, false),
            27692 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, true),
            27693 => new SculkVeinBlock(Identifier, true, false, false, true, true, true, false),
            27694 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, true),
            27695 => new SculkVeinBlock(Identifier, true, false, false, true, true, false, false),
            27696 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, true),
            27697 => new SculkVeinBlock(Identifier, true, false, false, true, false, true, false),
            27698 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, true),
            27699 => new SculkVeinBlock(Identifier, true, false, false, true, false, false, false),
            27700 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, true),
            27701 => new SculkVeinBlock(Identifier, true, false, false, false, true, true, false),
            27702 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, true),
            27703 => new SculkVeinBlock(Identifier, true, false, false, false, true, false, false),
            27704 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, true),
            27705 => new SculkVeinBlock(Identifier, true, false, false, false, false, true, false),
            27706 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, true),
            27707 => new SculkVeinBlock(Identifier, true, false, false, false, false, false, false),
            27708 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, true),
            27709 => new SculkVeinBlock(Identifier, false, true, true, true, true, true, false),
            27710 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, true),
            27711 => new SculkVeinBlock(Identifier, false, true, true, true, true, false, false),
            27712 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, true),
            27713 => new SculkVeinBlock(Identifier, false, true, true, true, false, true, false),
            27714 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, true),
            27715 => new SculkVeinBlock(Identifier, false, true, true, true, false, false, false),
            27716 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, true),
            27717 => new SculkVeinBlock(Identifier, false, true, true, false, true, true, false),
            27718 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, true),
            27719 => new SculkVeinBlock(Identifier, false, true, true, false, true, false, false),
            27720 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, true),
            27721 => new SculkVeinBlock(Identifier, false, true, true, false, false, true, false),
            27722 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, true),
            27723 => new SculkVeinBlock(Identifier, false, true, true, false, false, false, false),
            27724 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, true),
            27725 => new SculkVeinBlock(Identifier, false, true, false, true, true, true, false),
            27726 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, true),
            27727 => new SculkVeinBlock(Identifier, false, true, false, true, true, false, false),
            27728 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, true),
            27729 => new SculkVeinBlock(Identifier, false, true, false, true, false, true, false),
            27730 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, true),
            27731 => new SculkVeinBlock(Identifier, false, true, false, true, false, false, false),
            27732 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, true),
            27733 => new SculkVeinBlock(Identifier, false, true, false, false, true, true, false),
            27734 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, true),
            27735 => new SculkVeinBlock(Identifier, false, true, false, false, true, false, false),
            27736 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, true),
            27737 => new SculkVeinBlock(Identifier, false, true, false, false, false, true, false),
            27738 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, true),
            27739 => new SculkVeinBlock(Identifier, false, true, false, false, false, false, false),
            27740 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, true),
            27741 => new SculkVeinBlock(Identifier, false, false, true, true, true, true, false),
            27742 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, true),
            27743 => new SculkVeinBlock(Identifier, false, false, true, true, true, false, false),
            27744 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, true),
            27745 => new SculkVeinBlock(Identifier, false, false, true, true, false, true, false),
            27746 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, true),
            27747 => new SculkVeinBlock(Identifier, false, false, true, true, false, false, false),
            27748 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, true),
            27749 => new SculkVeinBlock(Identifier, false, false, true, false, true, true, false),
            27750 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, true),
            27751 => new SculkVeinBlock(Identifier, false, false, true, false, true, false, false),
            27752 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, true),
            27753 => new SculkVeinBlock(Identifier, false, false, true, false, false, true, false),
            27754 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, true),
            27755 => new SculkVeinBlock(Identifier, false, false, true, false, false, false, false),
            27756 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, true),
            27757 => new SculkVeinBlock(Identifier, false, false, false, true, true, true, false),
            27758 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, true),
            27759 => new SculkVeinBlock(Identifier, false, false, false, true, true, false, false),
            27760 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, true),
            27761 => new SculkVeinBlock(Identifier, false, false, false, true, false, true, false),
            27762 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, true),
            27763 => new SculkVeinBlock(Identifier, false, false, false, true, false, false, false),
            27764 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, true),
            27765 => new SculkVeinBlock(Identifier, false, false, false, false, true, true, false),
            27766 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, true),
            27767 => new SculkVeinBlock(Identifier, false, false, false, false, true, false, false),
            27768 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, true),
            27769 => new SculkVeinBlock(Identifier, false, false, false, false, false, true, false),
            27770 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, true),
            27771 => new SculkVeinBlock(Identifier, false, false, false, false, false, false, false),
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
