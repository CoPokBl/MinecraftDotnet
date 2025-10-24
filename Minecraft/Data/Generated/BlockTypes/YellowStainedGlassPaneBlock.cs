using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 502;
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
    public Identifier? Item => "minecraft:yellow_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.yellow_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11386,
                                false => 11387,
                            },
                            false => West switch {
                                true => 11388,
                                false => 11389,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11390,
                                false => 11391,
                            },
                            false => West switch {
                                true => 11392,
                                false => 11393,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11394,
                                false => 11395,
                            },
                            false => West switch {
                                true => 11396,
                                false => 11397,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11398,
                                false => 11399,
                            },
                            false => West switch {
                                true => 11400,
                                false => 11401,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11402,
                                false => 11403,
                            },
                            false => West switch {
                                true => 11404,
                                false => 11405,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11406,
                                false => 11407,
                            },
                            false => West switch {
                                true => 11408,
                                false => 11409,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11410,
                                false => 11411,
                            },
                            false => West switch {
                                true => 11412,
                                false => 11413,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11414,
                                false => 11415,
                            },
                            false => West switch {
                                true => 11416,
                                false => 11417,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11386 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11387 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11388 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11389 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11390 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11391 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11392 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11393 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11394 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11395 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11396 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11397 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11398 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11399 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11400 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11401 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11402 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11403 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11404 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11405 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11406 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11407 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11408 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11409 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11410 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11411 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11412 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11413 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11414 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11415 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11416 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11417 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
