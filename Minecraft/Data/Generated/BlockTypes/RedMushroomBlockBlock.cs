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
                                    true => 7830,
                                    false => 7831,
                                },
                                false => West switch {
                                    true => 7832,
                                    false => 7833,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7834,
                                    false => 7835,
                                },
                                false => West switch {
                                    true => 7836,
                                    false => 7837,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7838,
                                    false => 7839,
                                },
                                false => West switch {
                                    true => 7840,
                                    false => 7841,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7842,
                                    false => 7843,
                                },
                                false => West switch {
                                    true => 7844,
                                    false => 7845,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7846,
                                    false => 7847,
                                },
                                false => West switch {
                                    true => 7848,
                                    false => 7849,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7850,
                                    false => 7851,
                                },
                                false => West switch {
                                    true => 7852,
                                    false => 7853,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7854,
                                    false => 7855,
                                },
                                false => West switch {
                                    true => 7856,
                                    false => 7857,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7858,
                                    false => 7859,
                                },
                                false => West switch {
                                    true => 7860,
                                    false => 7861,
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
                                    true => 7862,
                                    false => 7863,
                                },
                                false => West switch {
                                    true => 7864,
                                    false => 7865,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7866,
                                    false => 7867,
                                },
                                false => West switch {
                                    true => 7868,
                                    false => 7869,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7870,
                                    false => 7871,
                                },
                                false => West switch {
                                    true => 7872,
                                    false => 7873,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7874,
                                    false => 7875,
                                },
                                false => West switch {
                                    true => 7876,
                                    false => 7877,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7878,
                                    false => 7879,
                                },
                                false => West switch {
                                    true => 7880,
                                    false => 7881,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7882,
                                    false => 7883,
                                },
                                false => West switch {
                                    true => 7884,
                                    false => 7885,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7886,
                                    false => 7887,
                                },
                                false => West switch {
                                    true => 7888,
                                    false => 7889,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7890,
                                    false => 7891,
                                },
                                false => West switch {
                                    true => 7892,
                                    false => 7893,
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
            7830 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            7831 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            7832 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            7833 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            7834 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            7835 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            7836 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            7837 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            7838 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            7839 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            7840 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            7841 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            7842 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            7843 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            7844 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            7845 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            7846 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            7847 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            7848 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            7849 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            7850 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            7851 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            7852 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            7853 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            7854 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            7855 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            7856 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            7857 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            7858 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            7859 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            7860 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            7861 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            7862 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            7863 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            7864 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            7865 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            7866 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            7867 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            7868 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            7869 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            7870 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            7871 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            7872 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            7873 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            7874 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            7875 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            7876 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            7877 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            7878 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            7879 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            7880 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            7881 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            7882 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            7883 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            7884 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            7885 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            7886 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            7887 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            7888 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            7889 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            7890 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            7891 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            7892 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            7893 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, false),
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
