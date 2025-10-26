using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 498;
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
    public Identifier? Item => "minecraft:white_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.white_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11258,
                                false => 11259,
                            },
                            false => West switch {
                                true => 11260,
                                false => 11261,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11262,
                                false => 11263,
                            },
                            false => West switch {
                                true => 11264,
                                false => 11265,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11266,
                                false => 11267,
                            },
                            false => West switch {
                                true => 11268,
                                false => 11269,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11270,
                                false => 11271,
                            },
                            false => West switch {
                                true => 11272,
                                false => 11273,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11274,
                                false => 11275,
                            },
                            false => West switch {
                                true => 11276,
                                false => 11277,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11278,
                                false => 11279,
                            },
                            false => West switch {
                                true => 11280,
                                false => 11281,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11282,
                                false => 11283,
                            },
                            false => West switch {
                                true => 11284,
                                false => 11285,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11286,
                                false => 11287,
                            },
                            false => West switch {
                                true => 11288,
                                false => 11289,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11258 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11259 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11260 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11261 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11262 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11263 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11264 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11265 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11266 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11267 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11268 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11269 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11270 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11271 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11272 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11273 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11274 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11275 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11276 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11277 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11278 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11279 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11280 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11281 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11282 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11283 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11284 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11285 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11286 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11287 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11288 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11289 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
