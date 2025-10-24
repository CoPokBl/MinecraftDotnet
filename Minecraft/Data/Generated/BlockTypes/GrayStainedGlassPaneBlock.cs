using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 505;
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
    public Identifier? Item => "minecraft:gray_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.gray_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11482,
                                false => 11483,
                            },
                            false => West switch {
                                true => 11484,
                                false => 11485,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11486,
                                false => 11487,
                            },
                            false => West switch {
                                true => 11488,
                                false => 11489,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11490,
                                false => 11491,
                            },
                            false => West switch {
                                true => 11492,
                                false => 11493,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11494,
                                false => 11495,
                            },
                            false => West switch {
                                true => 11496,
                                false => 11497,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11498,
                                false => 11499,
                            },
                            false => West switch {
                                true => 11500,
                                false => 11501,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11502,
                                false => 11503,
                            },
                            false => West switch {
                                true => 11504,
                                false => 11505,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11506,
                                false => 11507,
                            },
                            false => West switch {
                                true => 11508,
                                false => 11509,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11510,
                                false => 11511,
                            },
                            false => West switch {
                                true => 11512,
                                false => 11513,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11482 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11483 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11484 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11485 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11486 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11487 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11488 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11489 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11490 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11491 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11492 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11493 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11494 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11495 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11496 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11497 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11498 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11499 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11500 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11501 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11502 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11503 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11504 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11505 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11506 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11507 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11508 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11509 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11510 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11511 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11512 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11513 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
