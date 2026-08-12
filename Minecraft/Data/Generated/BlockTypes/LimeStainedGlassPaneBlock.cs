using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:lime_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.lime_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11620,
                                false => 11621,
                            },
                            false => West switch {
                                true => 11622,
                                false => 11623,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11624,
                                false => 11625,
                            },
                            false => West switch {
                                true => 11626,
                                false => 11627,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11628,
                                false => 11629,
                            },
                            false => West switch {
                                true => 11630,
                                false => 11631,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11632,
                                false => 11633,
                            },
                            false => West switch {
                                true => 11634,
                                false => 11635,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11636,
                                false => 11637,
                            },
                            false => West switch {
                                true => 11638,
                                false => 11639,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11640,
                                false => 11641,
                            },
                            false => West switch {
                                true => 11642,
                                false => 11643,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11644,
                                false => 11645,
                            },
                            false => West switch {
                                true => 11646,
                                false => 11647,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11648,
                                false => 11649,
                            },
                            false => West switch {
                                true => 11650,
                                false => 11651,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11620 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11621 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11622 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11623 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11624 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11625 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11626 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11627 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11628 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11629 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11630 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11631 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11632 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11633 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11634 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11635 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11636 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11637 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11638 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11639 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11640 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11641 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11642 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11643 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11644 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11645 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11646 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11647 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11648 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11649 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11650 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11651 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
