using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 500;
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
    public Identifier? Item => "minecraft:magenta_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.magenta_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11322,
                                false => 11323,
                            },
                            false => West switch {
                                true => 11324,
                                false => 11325,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11326,
                                false => 11327,
                            },
                            false => West switch {
                                true => 11328,
                                false => 11329,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11330,
                                false => 11331,
                            },
                            false => West switch {
                                true => 11332,
                                false => 11333,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11334,
                                false => 11335,
                            },
                            false => West switch {
                                true => 11336,
                                false => 11337,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11338,
                                false => 11339,
                            },
                            false => West switch {
                                true => 11340,
                                false => 11341,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11342,
                                false => 11343,
                            },
                            false => West switch {
                                true => 11344,
                                false => 11345,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11346,
                                false => 11347,
                            },
                            false => West switch {
                                true => 11348,
                                false => 11349,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11350,
                                false => 11351,
                            },
                            false => West switch {
                                true => 11352,
                                false => 11353,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11322 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11323 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11324 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11325 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11326 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11327 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11328 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11329 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11330 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11331 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11332 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11333 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11334 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11335 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11336 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11337 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11338 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11339 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11340 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11341 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11342 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11343 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11344 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11345 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11346 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11347 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11348 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11349 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11350 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11351 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11352 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11353 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
