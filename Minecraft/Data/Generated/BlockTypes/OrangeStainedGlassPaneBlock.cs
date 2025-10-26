using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 499;
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
    public Identifier? Item => "minecraft:orange_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.orange_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11290,
                                false => 11291,
                            },
                            false => West switch {
                                true => 11292,
                                false => 11293,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11294,
                                false => 11295,
                            },
                            false => West switch {
                                true => 11296,
                                false => 11297,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11298,
                                false => 11299,
                            },
                            false => West switch {
                                true => 11300,
                                false => 11301,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11302,
                                false => 11303,
                            },
                            false => West switch {
                                true => 11304,
                                false => 11305,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11306,
                                false => 11307,
                            },
                            false => West switch {
                                true => 11308,
                                false => 11309,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11310,
                                false => 11311,
                            },
                            false => West switch {
                                true => 11312,
                                false => 11313,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11314,
                                false => 11315,
                            },
                            false => West switch {
                                true => 11316,
                                false => 11317,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11318,
                                false => 11319,
                            },
                            false => West switch {
                                true => 11320,
                                false => 11321,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11290 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11291 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11292 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11293 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11294 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11295 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11296 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11297 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11298 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11299 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11300 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11301 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11302 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11303 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11304 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11305 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11306 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11307 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11308 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11309 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11310 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11311 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11312 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11313 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11314 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11315 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11316 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11317 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11318 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11319 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11320 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11321 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
