using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
    public int ProtocolId => 358;
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
    public Identifier? Item => "minecraft:glass_pane";
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
    public string TranslationKey => "block.minecraft.glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8099,
                                false => 8100,
                            },
                            false => West switch {
                                true => 8101,
                                false => 8102,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8103,
                                false => 8104,
                            },
                            false => West switch {
                                true => 8105,
                                false => 8106,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8107,
                                false => 8108,
                            },
                            false => West switch {
                                true => 8109,
                                false => 8110,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8111,
                                false => 8112,
                            },
                            false => West switch {
                                true => 8113,
                                false => 8114,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8115,
                                false => 8116,
                            },
                            false => West switch {
                                true => 8117,
                                false => 8118,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8119,
                                false => 8120,
                            },
                            false => West switch {
                                true => 8121,
                                false => 8122,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8123,
                                false => 8124,
                            },
                            false => West switch {
                                true => 8125,
                                false => 8126,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8127,
                                false => 8128,
                            },
                            false => West switch {
                                true => 8129,
                                false => 8130,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8099 => new GlassPaneBlock(Identifier, true, true, true, true, true),
            8100 => new GlassPaneBlock(Identifier, true, true, true, true, false),
            8101 => new GlassPaneBlock(Identifier, true, true, true, false, true),
            8102 => new GlassPaneBlock(Identifier, true, true, true, false, false),
            8103 => new GlassPaneBlock(Identifier, true, true, false, true, true),
            8104 => new GlassPaneBlock(Identifier, true, true, false, true, false),
            8105 => new GlassPaneBlock(Identifier, true, true, false, false, true),
            8106 => new GlassPaneBlock(Identifier, true, true, false, false, false),
            8107 => new GlassPaneBlock(Identifier, true, false, true, true, true),
            8108 => new GlassPaneBlock(Identifier, true, false, true, true, false),
            8109 => new GlassPaneBlock(Identifier, true, false, true, false, true),
            8110 => new GlassPaneBlock(Identifier, true, false, true, false, false),
            8111 => new GlassPaneBlock(Identifier, true, false, false, true, true),
            8112 => new GlassPaneBlock(Identifier, true, false, false, true, false),
            8113 => new GlassPaneBlock(Identifier, true, false, false, false, true),
            8114 => new GlassPaneBlock(Identifier, true, false, false, false, false),
            8115 => new GlassPaneBlock(Identifier, false, true, true, true, true),
            8116 => new GlassPaneBlock(Identifier, false, true, true, true, false),
            8117 => new GlassPaneBlock(Identifier, false, true, true, false, true),
            8118 => new GlassPaneBlock(Identifier, false, true, true, false, false),
            8119 => new GlassPaneBlock(Identifier, false, true, false, true, true),
            8120 => new GlassPaneBlock(Identifier, false, true, false, true, false),
            8121 => new GlassPaneBlock(Identifier, false, true, false, false, true),
            8122 => new GlassPaneBlock(Identifier, false, true, false, false, false),
            8123 => new GlassPaneBlock(Identifier, false, false, true, true, true),
            8124 => new GlassPaneBlock(Identifier, false, false, true, true, false),
            8125 => new GlassPaneBlock(Identifier, false, false, true, false, true),
            8126 => new GlassPaneBlock(Identifier, false, false, true, false, false),
            8127 => new GlassPaneBlock(Identifier, false, false, false, true, true),
            8128 => new GlassPaneBlock(Identifier, false, false, false, true, false),
            8129 => new GlassPaneBlock(Identifier, false, false, false, false, true),
            8130 => new GlassPaneBlock(Identifier, false, false, false, false, false),
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
