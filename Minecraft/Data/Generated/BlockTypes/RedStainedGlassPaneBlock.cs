using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 512;
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
    public Identifier? Item => "minecraft:red_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.red_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11706,
                                false => 11707,
                            },
                            false => West switch {
                                true => 11708,
                                false => 11709,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11710,
                                false => 11711,
                            },
                            false => West switch {
                                true => 11712,
                                false => 11713,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11714,
                                false => 11715,
                            },
                            false => West switch {
                                true => 11716,
                                false => 11717,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11718,
                                false => 11719,
                            },
                            false => West switch {
                                true => 11720,
                                false => 11721,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11722,
                                false => 11723,
                            },
                            false => West switch {
                                true => 11724,
                                false => 11725,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11726,
                                false => 11727,
                            },
                            false => West switch {
                                true => 11728,
                                false => 11729,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11730,
                                false => 11731,
                            },
                            false => West switch {
                                true => 11732,
                                false => 11733,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11734,
                                false => 11735,
                            },
                            false => West switch {
                                true => 11736,
                                false => 11737,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11706 => new RedStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11707 => new RedStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11708 => new RedStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11709 => new RedStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11710 => new RedStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11711 => new RedStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11712 => new RedStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11713 => new RedStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11714 => new RedStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11715 => new RedStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11716 => new RedStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11717 => new RedStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11718 => new RedStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11719 => new RedStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11720 => new RedStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11721 => new RedStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11722 => new RedStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11723 => new RedStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11724 => new RedStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11725 => new RedStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11726 => new RedStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11727 => new RedStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11728 => new RedStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11729 => new RedStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11730 => new RedStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11731 => new RedStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11732 => new RedStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11733 => new RedStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11734 => new RedStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11735 => new RedStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11736 => new RedStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11737 => new RedStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
