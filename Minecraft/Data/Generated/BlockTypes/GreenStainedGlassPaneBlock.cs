using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GreenStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:green_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.green_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11876,
                                false => 11877,
                            },
                            false => West switch {
                                true => 11878,
                                false => 11879,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11880,
                                false => 11881,
                            },
                            false => West switch {
                                true => 11882,
                                false => 11883,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11884,
                                false => 11885,
                            },
                            false => West switch {
                                true => 11886,
                                false => 11887,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11888,
                                false => 11889,
                            },
                            false => West switch {
                                true => 11890,
                                false => 11891,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11892,
                                false => 11893,
                            },
                            false => West switch {
                                true => 11894,
                                false => 11895,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11896,
                                false => 11897,
                            },
                            false => West switch {
                                true => 11898,
                                false => 11899,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11900,
                                false => 11901,
                            },
                            false => West switch {
                                true => 11902,
                                false => 11903,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11904,
                                false => 11905,
                            },
                            false => West switch {
                                true => 11906,
                                false => 11907,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11876 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11877 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11878 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11879 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11880 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11881 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11882 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11883 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11884 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11885 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11886 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11887 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11888 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11889 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11890 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11891 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11892 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11893 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11894 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11895 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11896 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11897 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11898 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11899 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11900 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11901 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11902 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11903 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11904 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11905 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11906 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11907 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
