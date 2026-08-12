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
                                true => 11652,
                                false => 11653,
                            },
                            false => West switch {
                                true => 11654,
                                false => 11655,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11656,
                                false => 11657,
                            },
                            false => West switch {
                                true => 11658,
                                false => 11659,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11660,
                                false => 11661,
                            },
                            false => West switch {
                                true => 11662,
                                false => 11663,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11664,
                                false => 11665,
                            },
                            false => West switch {
                                true => 11666,
                                false => 11667,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11668,
                                false => 11669,
                            },
                            false => West switch {
                                true => 11670,
                                false => 11671,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11672,
                                false => 11673,
                            },
                            false => West switch {
                                true => 11674,
                                false => 11675,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11676,
                                false => 11677,
                            },
                            false => West switch {
                                true => 11678,
                                false => 11679,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11680,
                                false => 11681,
                            },
                            false => West switch {
                                true => 11682,
                                false => 11683,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11652 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11653 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11654 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11655 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11656 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11657 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11658 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11659 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11660 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11661 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11662 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11663 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11664 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11665 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11666 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11667 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11668 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11669 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11670 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11671 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11672 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11673 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11674 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11675 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11676 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11677 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11678 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11679 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11680 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11681 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11682 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11683 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
