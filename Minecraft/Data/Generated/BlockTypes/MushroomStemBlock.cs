using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MushroomStemBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:huge_mushroom";
    public int ProtocolId => 339;
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
    public Identifier? Item => "minecraft:mushroom_stem";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 3;
    public string TranslationKey => "block.minecraft.mushroom_stem";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7693,
                                    false => 7694,
                                },
                                false => West switch {
                                    true => 7695,
                                    false => 7696,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7697,
                                    false => 7698,
                                },
                                false => West switch {
                                    true => 7699,
                                    false => 7700,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7701,
                                    false => 7702,
                                },
                                false => West switch {
                                    true => 7703,
                                    false => 7704,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7705,
                                    false => 7706,
                                },
                                false => West switch {
                                    true => 7707,
                                    false => 7708,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7709,
                                    false => 7710,
                                },
                                false => West switch {
                                    true => 7711,
                                    false => 7712,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7713,
                                    false => 7714,
                                },
                                false => West switch {
                                    true => 7715,
                                    false => 7716,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7717,
                                    false => 7718,
                                },
                                false => West switch {
                                    true => 7719,
                                    false => 7720,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7721,
                                    false => 7722,
                                },
                                false => West switch {
                                    true => 7723,
                                    false => 7724,
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
                                    true => 7725,
                                    false => 7726,
                                },
                                false => West switch {
                                    true => 7727,
                                    false => 7728,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7729,
                                    false => 7730,
                                },
                                false => West switch {
                                    true => 7731,
                                    false => 7732,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7733,
                                    false => 7734,
                                },
                                false => West switch {
                                    true => 7735,
                                    false => 7736,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7737,
                                    false => 7738,
                                },
                                false => West switch {
                                    true => 7739,
                                    false => 7740,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7741,
                                    false => 7742,
                                },
                                false => West switch {
                                    true => 7743,
                                    false => 7744,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7745,
                                    false => 7746,
                                },
                                false => West switch {
                                    true => 7747,
                                    false => 7748,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7749,
                                    false => 7750,
                                },
                                false => West switch {
                                    true => 7751,
                                    false => 7752,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7753,
                                    false => 7754,
                                },
                                false => West switch {
                                    true => 7755,
                                    false => 7756,
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
            7693 => new MushroomStemBlock(Identifier, true, true, true, true, true, true),
            7694 => new MushroomStemBlock(Identifier, true, true, true, true, true, false),
            7695 => new MushroomStemBlock(Identifier, true, true, true, true, false, true),
            7696 => new MushroomStemBlock(Identifier, true, true, true, true, false, false),
            7697 => new MushroomStemBlock(Identifier, true, true, true, false, true, true),
            7698 => new MushroomStemBlock(Identifier, true, true, true, false, true, false),
            7699 => new MushroomStemBlock(Identifier, true, true, true, false, false, true),
            7700 => new MushroomStemBlock(Identifier, true, true, true, false, false, false),
            7701 => new MushroomStemBlock(Identifier, true, true, false, true, true, true),
            7702 => new MushroomStemBlock(Identifier, true, true, false, true, true, false),
            7703 => new MushroomStemBlock(Identifier, true, true, false, true, false, true),
            7704 => new MushroomStemBlock(Identifier, true, true, false, true, false, false),
            7705 => new MushroomStemBlock(Identifier, true, true, false, false, true, true),
            7706 => new MushroomStemBlock(Identifier, true, true, false, false, true, false),
            7707 => new MushroomStemBlock(Identifier, true, true, false, false, false, true),
            7708 => new MushroomStemBlock(Identifier, true, true, false, false, false, false),
            7709 => new MushroomStemBlock(Identifier, true, false, true, true, true, true),
            7710 => new MushroomStemBlock(Identifier, true, false, true, true, true, false),
            7711 => new MushroomStemBlock(Identifier, true, false, true, true, false, true),
            7712 => new MushroomStemBlock(Identifier, true, false, true, true, false, false),
            7713 => new MushroomStemBlock(Identifier, true, false, true, false, true, true),
            7714 => new MushroomStemBlock(Identifier, true, false, true, false, true, false),
            7715 => new MushroomStemBlock(Identifier, true, false, true, false, false, true),
            7716 => new MushroomStemBlock(Identifier, true, false, true, false, false, false),
            7717 => new MushroomStemBlock(Identifier, true, false, false, true, true, true),
            7718 => new MushroomStemBlock(Identifier, true, false, false, true, true, false),
            7719 => new MushroomStemBlock(Identifier, true, false, false, true, false, true),
            7720 => new MushroomStemBlock(Identifier, true, false, false, true, false, false),
            7721 => new MushroomStemBlock(Identifier, true, false, false, false, true, true),
            7722 => new MushroomStemBlock(Identifier, true, false, false, false, true, false),
            7723 => new MushroomStemBlock(Identifier, true, false, false, false, false, true),
            7724 => new MushroomStemBlock(Identifier, true, false, false, false, false, false),
            7725 => new MushroomStemBlock(Identifier, false, true, true, true, true, true),
            7726 => new MushroomStemBlock(Identifier, false, true, true, true, true, false),
            7727 => new MushroomStemBlock(Identifier, false, true, true, true, false, true),
            7728 => new MushroomStemBlock(Identifier, false, true, true, true, false, false),
            7729 => new MushroomStemBlock(Identifier, false, true, true, false, true, true),
            7730 => new MushroomStemBlock(Identifier, false, true, true, false, true, false),
            7731 => new MushroomStemBlock(Identifier, false, true, true, false, false, true),
            7732 => new MushroomStemBlock(Identifier, false, true, true, false, false, false),
            7733 => new MushroomStemBlock(Identifier, false, true, false, true, true, true),
            7734 => new MushroomStemBlock(Identifier, false, true, false, true, true, false),
            7735 => new MushroomStemBlock(Identifier, false, true, false, true, false, true),
            7736 => new MushroomStemBlock(Identifier, false, true, false, true, false, false),
            7737 => new MushroomStemBlock(Identifier, false, true, false, false, true, true),
            7738 => new MushroomStemBlock(Identifier, false, true, false, false, true, false),
            7739 => new MushroomStemBlock(Identifier, false, true, false, false, false, true),
            7740 => new MushroomStemBlock(Identifier, false, true, false, false, false, false),
            7741 => new MushroomStemBlock(Identifier, false, false, true, true, true, true),
            7742 => new MushroomStemBlock(Identifier, false, false, true, true, true, false),
            7743 => new MushroomStemBlock(Identifier, false, false, true, true, false, true),
            7744 => new MushroomStemBlock(Identifier, false, false, true, true, false, false),
            7745 => new MushroomStemBlock(Identifier, false, false, true, false, true, true),
            7746 => new MushroomStemBlock(Identifier, false, false, true, false, true, false),
            7747 => new MushroomStemBlock(Identifier, false, false, true, false, false, true),
            7748 => new MushroomStemBlock(Identifier, false, false, true, false, false, false),
            7749 => new MushroomStemBlock(Identifier, false, false, false, true, true, true),
            7750 => new MushroomStemBlock(Identifier, false, false, false, true, true, false),
            7751 => new MushroomStemBlock(Identifier, false, false, false, true, false, true),
            7752 => new MushroomStemBlock(Identifier, false, false, false, true, false, false),
            7753 => new MushroomStemBlock(Identifier, false, false, false, false, true, true),
            7754 => new MushroomStemBlock(Identifier, false, false, false, false, true, false),
            7755 => new MushroomStemBlock(Identifier, false, false, false, false, false, true),
            7756 => new MushroomStemBlock(Identifier, false, false, false, false, false, false),
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
