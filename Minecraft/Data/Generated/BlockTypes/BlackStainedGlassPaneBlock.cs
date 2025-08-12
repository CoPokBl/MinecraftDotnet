using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 483;
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
    public Identifier? Item => "minecraft:black_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.black_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10661,
                                false => 10662,
                            },
                            false => West switch {
                                true => 10663,
                                false => 10664,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10665,
                                false => 10666,
                            },
                            false => West switch {
                                true => 10667,
                                false => 10668,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10669,
                                false => 10670,
                            },
                            false => West switch {
                                true => 10671,
                                false => 10672,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10673,
                                false => 10674,
                            },
                            false => West switch {
                                true => 10675,
                                false => 10676,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10677,
                                false => 10678,
                            },
                            false => West switch {
                                true => 10679,
                                false => 10680,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10681,
                                false => 10682,
                            },
                            false => West switch {
                                true => 10683,
                                false => 10684,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10685,
                                false => 10686,
                            },
                            false => West switch {
                                true => 10687,
                                false => 10688,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10689,
                                false => 10690,
                            },
                            false => West switch {
                                true => 10691,
                                false => 10692,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10661 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10662 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10663 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10664 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10665 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10666 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10667 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10668 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10669 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10670 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10671 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10672 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10673 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10674 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10675 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10676 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10677 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10678 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10679 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10680 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10681 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10682 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10683 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10684 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10685 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10686 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10687 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10688 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10689 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10690 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10691 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10692 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
