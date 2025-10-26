using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 508;
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
    public Identifier? Item => "minecraft:purple_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.purple_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11578,
                                false => 11579,
                            },
                            false => West switch {
                                true => 11580,
                                false => 11581,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11582,
                                false => 11583,
                            },
                            false => West switch {
                                true => 11584,
                                false => 11585,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11586,
                                false => 11587,
                            },
                            false => West switch {
                                true => 11588,
                                false => 11589,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11590,
                                false => 11591,
                            },
                            false => West switch {
                                true => 11592,
                                false => 11593,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11594,
                                false => 11595,
                            },
                            false => West switch {
                                true => 11596,
                                false => 11597,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11598,
                                false => 11599,
                            },
                            false => West switch {
                                true => 11600,
                                false => 11601,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11602,
                                false => 11603,
                            },
                            false => West switch {
                                true => 11604,
                                false => 11605,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11606,
                                false => 11607,
                            },
                            false => West switch {
                                true => 11608,
                                false => 11609,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11578 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11579 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11580 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11581 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11582 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11583 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11584 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11585 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11586 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11587 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11588 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11589 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11590 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11591 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11592 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11593 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11594 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11595 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11596 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11597 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11598 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11599 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11600 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11601 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11602 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11603 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11604 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11605 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11606 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11607 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11608 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11609 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
