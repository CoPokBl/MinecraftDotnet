using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:gray_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.gray_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11684,
                                false => 11685,
                            },
                            false => West switch {
                                true => 11686,
                                false => 11687,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11688,
                                false => 11689,
                            },
                            false => West switch {
                                true => 11690,
                                false => 11691,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11692,
                                false => 11693,
                            },
                            false => West switch {
                                true => 11694,
                                false => 11695,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11696,
                                false => 11697,
                            },
                            false => West switch {
                                true => 11698,
                                false => 11699,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11700,
                                false => 11701,
                            },
                            false => West switch {
                                true => 11702,
                                false => 11703,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11704,
                                false => 11705,
                            },
                            false => West switch {
                                true => 11706,
                                false => 11707,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11708,
                                false => 11709,
                            },
                            false => West switch {
                                true => 11710,
                                false => 11711,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11712,
                                false => 11713,
                            },
                            false => West switch {
                                true => 11714,
                                false => 11715,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11684 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11685 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11686 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11687 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11688 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11689 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11690 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11691 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11692 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11693 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11694 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11695 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11696 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11697 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11698 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11699 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11700 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11701 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11702 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11703 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11704 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11705 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11706 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11707 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11708 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11709 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11710 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11711 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11712 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11713 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11714 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11715 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
