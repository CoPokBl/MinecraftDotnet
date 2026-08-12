using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:red_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.red_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11908,
                                false => 11909,
                            },
                            false => West switch {
                                true => 11910,
                                false => 11911,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11912,
                                false => 11913,
                            },
                            false => West switch {
                                true => 11914,
                                false => 11915,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11916,
                                false => 11917,
                            },
                            false => West switch {
                                true => 11918,
                                false => 11919,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11920,
                                false => 11921,
                            },
                            false => West switch {
                                true => 11922,
                                false => 11923,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11924,
                                false => 11925,
                            },
                            false => West switch {
                                true => 11926,
                                false => 11927,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11928,
                                false => 11929,
                            },
                            false => West switch {
                                true => 11930,
                                false => 11931,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11932,
                                false => 11933,
                            },
                            false => West switch {
                                true => 11934,
                                false => 11935,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11936,
                                false => 11937,
                            },
                            false => West switch {
                                true => 11938,
                                false => 11939,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11908 => new RedStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11909 => new RedStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11910 => new RedStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11911 => new RedStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11912 => new RedStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11913 => new RedStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11914 => new RedStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11915 => new RedStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11916 => new RedStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11917 => new RedStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11918 => new RedStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11919 => new RedStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11920 => new RedStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11921 => new RedStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11922 => new RedStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11923 => new RedStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11924 => new RedStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11925 => new RedStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11926 => new RedStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11927 => new RedStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11928 => new RedStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11929 => new RedStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11930 => new RedStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11931 => new RedStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11932 => new RedStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11933 => new RedStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11934 => new RedStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11935 => new RedStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11936 => new RedStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11937 => new RedStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11938 => new RedStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11939 => new RedStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
