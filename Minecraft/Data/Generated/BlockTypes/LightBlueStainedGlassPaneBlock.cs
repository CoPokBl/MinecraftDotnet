using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 501;
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
    public Identifier? Item => "minecraft:light_blue_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.light_blue_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11354,
                                false => 11355,
                            },
                            false => West switch {
                                true => 11356,
                                false => 11357,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11358,
                                false => 11359,
                            },
                            false => West switch {
                                true => 11360,
                                false => 11361,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11362,
                                false => 11363,
                            },
                            false => West switch {
                                true => 11364,
                                false => 11365,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11366,
                                false => 11367,
                            },
                            false => West switch {
                                true => 11368,
                                false => 11369,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11370,
                                false => 11371,
                            },
                            false => West switch {
                                true => 11372,
                                false => 11373,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11374,
                                false => 11375,
                            },
                            false => West switch {
                                true => 11376,
                                false => 11377,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11378,
                                false => 11379,
                            },
                            false => West switch {
                                true => 11380,
                                false => 11381,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11382,
                                false => 11383,
                            },
                            false => West switch {
                                true => 11384,
                                false => 11385,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11354 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11355 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11356 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11357 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11358 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11359 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11360 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11361 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11362 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11363 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11364 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11365 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11366 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11367 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11368 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11369 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11370 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11371 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11372 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11373 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11374 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11375 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11376 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11377 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11378 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11379 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11380 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11381 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11382 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11383 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11384 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11385 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
