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
    public int ProtocolId => 503;
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
                                true => 11418,
                                false => 11419,
                            },
                            false => West switch {
                                true => 11420,
                                false => 11421,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11422,
                                false => 11423,
                            },
                            false => West switch {
                                true => 11424,
                                false => 11425,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11426,
                                false => 11427,
                            },
                            false => West switch {
                                true => 11428,
                                false => 11429,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11430,
                                false => 11431,
                            },
                            false => West switch {
                                true => 11432,
                                false => 11433,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11434,
                                false => 11435,
                            },
                            false => West switch {
                                true => 11436,
                                false => 11437,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11438,
                                false => 11439,
                            },
                            false => West switch {
                                true => 11440,
                                false => 11441,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11442,
                                false => 11443,
                            },
                            false => West switch {
                                true => 11444,
                                false => 11445,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11446,
                                false => 11447,
                            },
                            false => West switch {
                                true => 11448,
                                false => 11449,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11418 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11419 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11420 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11421 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11422 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11423 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11424 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11425 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11426 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11427 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11428 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11429 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11430 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11431 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11432 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11433 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11434 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11435 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11436 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11437 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11438 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11439 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11440 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11441 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11442 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11443 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11444 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11445 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11446 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11447 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11448 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11449 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
