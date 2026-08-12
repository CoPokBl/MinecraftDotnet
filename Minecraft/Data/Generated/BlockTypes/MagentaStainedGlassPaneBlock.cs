using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:magenta_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.magenta_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11524,
                                false => 11525,
                            },
                            false => West switch {
                                true => 11526,
                                false => 11527,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11528,
                                false => 11529,
                            },
                            false => West switch {
                                true => 11530,
                                false => 11531,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11532,
                                false => 11533,
                            },
                            false => West switch {
                                true => 11534,
                                false => 11535,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11536,
                                false => 11537,
                            },
                            false => West switch {
                                true => 11538,
                                false => 11539,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11540,
                                false => 11541,
                            },
                            false => West switch {
                                true => 11542,
                                false => 11543,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11544,
                                false => 11545,
                            },
                            false => West switch {
                                true => 11546,
                                false => 11547,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11548,
                                false => 11549,
                            },
                            false => West switch {
                                true => 11550,
                                false => 11551,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11552,
                                false => 11553,
                            },
                            false => West switch {
                                true => 11554,
                                false => 11555,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11524 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11525 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11526 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11527 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11528 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11529 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11530 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11531 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11532 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11533 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11534 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11535 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11536 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11537 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11538 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11539 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11540 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11541 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11542 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11543 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11544 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11545 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11546 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11547 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11548 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11549 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11550 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11551 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11552 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11553 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11554 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11555 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
