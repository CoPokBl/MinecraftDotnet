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
                                true => 11556,
                                false => 11557,
                            },
                            false => West switch {
                                true => 11558,
                                false => 11559,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11560,
                                false => 11561,
                            },
                            false => West switch {
                                true => 11562,
                                false => 11563,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11564,
                                false => 11565,
                            },
                            false => West switch {
                                true => 11566,
                                false => 11567,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11568,
                                false => 11569,
                            },
                            false => West switch {
                                true => 11570,
                                false => 11571,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11572,
                                false => 11573,
                            },
                            false => West switch {
                                true => 11574,
                                false => 11575,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11576,
                                false => 11577,
                            },
                            false => West switch {
                                true => 11578,
                                false => 11579,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11580,
                                false => 11581,
                            },
                            false => West switch {
                                true => 11582,
                                false => 11583,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11584,
                                false => 11585,
                            },
                            false => West switch {
                                true => 11586,
                                false => 11587,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11556 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11557 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11558 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11559 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11560 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11561 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11562 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11563 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11564 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11565 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11566 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11567 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11568 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11569 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11570 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11571 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11572 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11573 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11574 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11575 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11576 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11577 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11578 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11579 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11580 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11581 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11582 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11583 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11584 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11585 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11586 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11587 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
