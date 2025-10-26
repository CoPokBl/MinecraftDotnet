using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 506;
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
    public Identifier? Item => "minecraft:light_gray_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.light_gray_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11514,
                                false => 11515,
                            },
                            false => West switch {
                                true => 11516,
                                false => 11517,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11518,
                                false => 11519,
                            },
                            false => West switch {
                                true => 11520,
                                false => 11521,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11522,
                                false => 11523,
                            },
                            false => West switch {
                                true => 11524,
                                false => 11525,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11526,
                                false => 11527,
                            },
                            false => West switch {
                                true => 11528,
                                false => 11529,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11530,
                                false => 11531,
                            },
                            false => West switch {
                                true => 11532,
                                false => 11533,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11534,
                                false => 11535,
                            },
                            false => West switch {
                                true => 11536,
                                false => 11537,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11538,
                                false => 11539,
                            },
                            false => West switch {
                                true => 11540,
                                false => 11541,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11542,
                                false => 11543,
                            },
                            false => West switch {
                                true => 11544,
                                false => 11545,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11514 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11515 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11516 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11517 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11518 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11519 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11520 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11521 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11522 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11523 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11524 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11525 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11526 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11527 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11528 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11529 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11530 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11531 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11532 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11533 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11534 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11535 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11536 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11537 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11538 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11539 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11540 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11541 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11542 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11543 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11544 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11545 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
