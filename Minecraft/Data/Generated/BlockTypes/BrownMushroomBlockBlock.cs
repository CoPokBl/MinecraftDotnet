using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:huge_mushroom";
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
    public Identifier? Item => "minecraft:brown_mushroom_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.brown_mushroom_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7766,
                                    false => 7767,
                                },
                                false => West switch {
                                    true => 7768,
                                    false => 7769,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7770,
                                    false => 7771,
                                },
                                false => West switch {
                                    true => 7772,
                                    false => 7773,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7774,
                                    false => 7775,
                                },
                                false => West switch {
                                    true => 7776,
                                    false => 7777,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7778,
                                    false => 7779,
                                },
                                false => West switch {
                                    true => 7780,
                                    false => 7781,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7782,
                                    false => 7783,
                                },
                                false => West switch {
                                    true => 7784,
                                    false => 7785,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7786,
                                    false => 7787,
                                },
                                false => West switch {
                                    true => 7788,
                                    false => 7789,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7790,
                                    false => 7791,
                                },
                                false => West switch {
                                    true => 7792,
                                    false => 7793,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7794,
                                    false => 7795,
                                },
                                false => West switch {
                                    true => 7796,
                                    false => 7797,
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
                                    true => 7798,
                                    false => 7799,
                                },
                                false => West switch {
                                    true => 7800,
                                    false => 7801,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7802,
                                    false => 7803,
                                },
                                false => West switch {
                                    true => 7804,
                                    false => 7805,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7806,
                                    false => 7807,
                                },
                                false => West switch {
                                    true => 7808,
                                    false => 7809,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7810,
                                    false => 7811,
                                },
                                false => West switch {
                                    true => 7812,
                                    false => 7813,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7814,
                                    false => 7815,
                                },
                                false => West switch {
                                    true => 7816,
                                    false => 7817,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7818,
                                    false => 7819,
                                },
                                false => West switch {
                                    true => 7820,
                                    false => 7821,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7822,
                                    false => 7823,
                                },
                                false => West switch {
                                    true => 7824,
                                    false => 7825,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7826,
                                    false => 7827,
                                },
                                false => West switch {
                                    true => 7828,
                                    false => 7829,
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
            7766 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            7767 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            7768 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            7769 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            7770 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            7771 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            7772 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            7773 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            7774 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            7775 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            7776 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            7777 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            7778 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            7779 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            7780 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            7781 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            7782 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            7783 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            7784 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            7785 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            7786 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            7787 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            7788 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            7789 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            7790 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            7791 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            7792 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            7793 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            7794 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            7795 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            7796 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            7797 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            7798 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            7799 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            7800 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            7801 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            7802 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            7803 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            7804 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            7805 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            7806 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            7807 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            7808 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            7809 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            7810 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            7811 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            7812 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            7813 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            7814 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            7815 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            7816 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            7817 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            7818 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            7819 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            7820 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            7821 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            7822 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            7823 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            7824 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            7825 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            7826 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            7827 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            7828 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            7829 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, false),
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
