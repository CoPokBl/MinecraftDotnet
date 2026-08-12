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
                                true => 11460,
                                false => 11461,
                            },
                            false => West switch {
                                true => 11462,
                                false => 11463,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11464,
                                false => 11465,
                            },
                            false => West switch {
                                true => 11466,
                                false => 11467,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11468,
                                false => 11469,
                            },
                            false => West switch {
                                true => 11470,
                                false => 11471,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11472,
                                false => 11473,
                            },
                            false => West switch {
                                true => 11474,
                                false => 11475,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11476,
                                false => 11477,
                            },
                            false => West switch {
                                true => 11478,
                                false => 11479,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11480,
                                false => 11481,
                            },
                            false => West switch {
                                true => 11482,
                                false => 11483,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11484,
                                false => 11485,
                            },
                            false => West switch {
                                true => 11486,
                                false => 11487,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11488,
                                false => 11489,
                            },
                            false => West switch {
                                true => 11490,
                                false => 11491,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11460 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11461 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11462 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11463 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11464 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11465 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11466 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11467 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11468 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11469 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11470 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11471 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11472 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11473 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11474 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11475 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11476 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11477 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11478 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11479 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11480 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11481 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11482 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11483 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11484 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11485 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11486 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11487 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11488 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11489 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11490 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11491 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
