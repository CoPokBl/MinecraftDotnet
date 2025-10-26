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
    public int ProtocolId => 513;
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
                                true => 11738,
                                false => 11739,
                            },
                            false => West switch {
                                true => 11740,
                                false => 11741,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11742,
                                false => 11743,
                            },
                            false => West switch {
                                true => 11744,
                                false => 11745,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11746,
                                false => 11747,
                            },
                            false => West switch {
                                true => 11748,
                                false => 11749,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11750,
                                false => 11751,
                            },
                            false => West switch {
                                true => 11752,
                                false => 11753,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11754,
                                false => 11755,
                            },
                            false => West switch {
                                true => 11756,
                                false => 11757,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11758,
                                false => 11759,
                            },
                            false => West switch {
                                true => 11760,
                                false => 11761,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11762,
                                false => 11763,
                            },
                            false => West switch {
                                true => 11764,
                                false => 11765,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11766,
                                false => 11767,
                            },
                            false => West switch {
                                true => 11768,
                                false => 11769,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11738 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11739 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11740 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11741 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11742 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11743 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11744 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11745 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11746 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11747 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11748 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11749 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11750 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11751 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11752 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11753 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11754 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11755 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11756 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11757 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11758 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11759 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11760 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11761 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11762 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11763 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11764 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11765 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11766 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11767 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11768 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11769 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
