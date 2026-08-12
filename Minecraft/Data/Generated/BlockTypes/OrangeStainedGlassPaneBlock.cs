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
                                true => 11492,
                                false => 11493,
                            },
                            false => West switch {
                                true => 11494,
                                false => 11495,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11496,
                                false => 11497,
                            },
                            false => West switch {
                                true => 11498,
                                false => 11499,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11500,
                                false => 11501,
                            },
                            false => West switch {
                                true => 11502,
                                false => 11503,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11504,
                                false => 11505,
                            },
                            false => West switch {
                                true => 11506,
                                false => 11507,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11508,
                                false => 11509,
                            },
                            false => West switch {
                                true => 11510,
                                false => 11511,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11512,
                                false => 11513,
                            },
                            false => West switch {
                                true => 11514,
                                false => 11515,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11516,
                                false => 11517,
                            },
                            false => West switch {
                                true => 11518,
                                false => 11519,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11520,
                                false => 11521,
                            },
                            false => West switch {
                                true => 11522,
                                false => 11523,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11492 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11493 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11494 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11495 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11496 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11497 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11498 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11499 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11500 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11501 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11502 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11503 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11504 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11505 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11506 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11507 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11508 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11509 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11510 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11511 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11512 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11513 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11514 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11515 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11516 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11517 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11518 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11519 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11520 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11521 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11522 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11523 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
