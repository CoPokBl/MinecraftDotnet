using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:cyan_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.cyan_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11748,
                                false => 11749,
                            },
                            false => West switch {
                                true => 11750,
                                false => 11751,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11752,
                                false => 11753,
                            },
                            false => West switch {
                                true => 11754,
                                false => 11755,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11756,
                                false => 11757,
                            },
                            false => West switch {
                                true => 11758,
                                false => 11759,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11760,
                                false => 11761,
                            },
                            false => West switch {
                                true => 11762,
                                false => 11763,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11764,
                                false => 11765,
                            },
                            false => West switch {
                                true => 11766,
                                false => 11767,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11768,
                                false => 11769,
                            },
                            false => West switch {
                                true => 11770,
                                false => 11771,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11772,
                                false => 11773,
                            },
                            false => West switch {
                                true => 11774,
                                false => 11775,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11776,
                                false => 11777,
                            },
                            false => West switch {
                                true => 11778,
                                false => 11779,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11748 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11749 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11750 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11751 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11752 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11753 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11754 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11755 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11756 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11757 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11758 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11759 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11760 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11761 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11762 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11763 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11764 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11765 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11766 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11767 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11768 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11769 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11770 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11771 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11772 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11773 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11774 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11775 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11776 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11777 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11778 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11779 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
