using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 504;
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
    public Identifier? Item => "minecraft:pink_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.pink_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11450,
                                false => 11451,
                            },
                            false => West switch {
                                true => 11452,
                                false => 11453,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11454,
                                false => 11455,
                            },
                            false => West switch {
                                true => 11456,
                                false => 11457,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11458,
                                false => 11459,
                            },
                            false => West switch {
                                true => 11460,
                                false => 11461,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11462,
                                false => 11463,
                            },
                            false => West switch {
                                true => 11464,
                                false => 11465,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11466,
                                false => 11467,
                            },
                            false => West switch {
                                true => 11468,
                                false => 11469,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11470,
                                false => 11471,
                            },
                            false => West switch {
                                true => 11472,
                                false => 11473,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11474,
                                false => 11475,
                            },
                            false => West switch {
                                true => 11476,
                                false => 11477,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11478,
                                false => 11479,
                            },
                            false => West switch {
                                true => 11480,
                                false => 11481,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11450 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11451 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11452 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11453 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11454 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11455 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11456 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11457 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11458 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11459 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11460 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11461 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11462 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11463 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11464 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11465 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11466 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11467 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11468 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11469 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11470 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11471 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11472 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11473 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11474 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11475 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11476 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11477 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11478 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11479 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11480 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11481 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
