using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public double Hardness => 0.3;
    public double ExplosionResistance => 0.3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "glass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:blue_stained_glass_pane";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 1.0, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 1.0, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.blue_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11812,
                                false => 11813,
                            },
                            false => West switch {
                                true => 11814,
                                false => 11815,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11816,
                                false => 11817,
                            },
                            false => West switch {
                                true => 11818,
                                false => 11819,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11820,
                                false => 11821,
                            },
                            false => West switch {
                                true => 11822,
                                false => 11823,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11824,
                                false => 11825,
                            },
                            false => West switch {
                                true => 11826,
                                false => 11827,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11828,
                                false => 11829,
                            },
                            false => West switch {
                                true => 11830,
                                false => 11831,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11832,
                                false => 11833,
                            },
                            false => West switch {
                                true => 11834,
                                false => 11835,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11836,
                                false => 11837,
                            },
                            false => West switch {
                                true => 11838,
                                false => 11839,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11840,
                                false => 11841,
                            },
                            false => West switch {
                                true => 11842,
                                false => 11843,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11812 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11813 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11814 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11815 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11816 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11817 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11818 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11819 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11820 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11821 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11822 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11823 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11824 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11825 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11826 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11827 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11828 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11829 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11830 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11831 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11832 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11833 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11834 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11835 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11836 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11837 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11838 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11839 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11840 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11841 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11842 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11843 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
