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
    public int ProtocolId => 474;
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
                                true => 10373,
                                false => 10374,
                            },
                            false => West switch {
                                true => 10375,
                                false => 10376,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10377,
                                false => 10378,
                            },
                            false => West switch {
                                true => 10379,
                                false => 10380,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10381,
                                false => 10382,
                            },
                            false => West switch {
                                true => 10383,
                                false => 10384,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10385,
                                false => 10386,
                            },
                            false => West switch {
                                true => 10387,
                                false => 10388,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10389,
                                false => 10390,
                            },
                            false => West switch {
                                true => 10391,
                                false => 10392,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10393,
                                false => 10394,
                            },
                            false => West switch {
                                true => 10395,
                                false => 10396,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10397,
                                false => 10398,
                            },
                            false => West switch {
                                true => 10399,
                                false => 10400,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10401,
                                false => 10402,
                            },
                            false => West switch {
                                true => 10403,
                                false => 10404,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10373 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10374 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10375 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10376 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10377 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10378 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10379 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10380 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10381 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10382 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10383 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10384 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10385 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10386 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10387 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10388 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10389 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10390 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10391 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10392 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10393 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10394 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10395 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10396 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10397 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10398 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10399 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10400 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10401 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10402 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10403 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10404 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
