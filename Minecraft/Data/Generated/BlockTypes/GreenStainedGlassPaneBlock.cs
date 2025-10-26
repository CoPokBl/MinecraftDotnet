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
    public int ProtocolId => 511;
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
                                true => 11674,
                                false => 11675,
                            },
                            false => West switch {
                                true => 11676,
                                false => 11677,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11678,
                                false => 11679,
                            },
                            false => West switch {
                                true => 11680,
                                false => 11681,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11682,
                                false => 11683,
                            },
                            false => West switch {
                                true => 11684,
                                false => 11685,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11686,
                                false => 11687,
                            },
                            false => West switch {
                                true => 11688,
                                false => 11689,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11690,
                                false => 11691,
                            },
                            false => West switch {
                                true => 11692,
                                false => 11693,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11694,
                                false => 11695,
                            },
                            false => West switch {
                                true => 11696,
                                false => 11697,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11698,
                                false => 11699,
                            },
                            false => West switch {
                                true => 11700,
                                false => 11701,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11702,
                                false => 11703,
                            },
                            false => West switch {
                                true => 11704,
                                false => 11705,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11674 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11675 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11676 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11677 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11678 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11679 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11680 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11681 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11682 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11683 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11684 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11685 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11686 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11687 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11688 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11689 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11690 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11691 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11692 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11693 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11694 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11695 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11696 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11697 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11698 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11699 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11700 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11701 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11702 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11703 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11704 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11705 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
