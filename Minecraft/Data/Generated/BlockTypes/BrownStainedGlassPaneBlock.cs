using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:brown_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.brown_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11844,
                                false => 11845,
                            },
                            false => West switch {
                                true => 11846,
                                false => 11847,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11848,
                                false => 11849,
                            },
                            false => West switch {
                                true => 11850,
                                false => 11851,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11852,
                                false => 11853,
                            },
                            false => West switch {
                                true => 11854,
                                false => 11855,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11856,
                                false => 11857,
                            },
                            false => West switch {
                                true => 11858,
                                false => 11859,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11860,
                                false => 11861,
                            },
                            false => West switch {
                                true => 11862,
                                false => 11863,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11864,
                                false => 11865,
                            },
                            false => West switch {
                                true => 11866,
                                false => 11867,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11868,
                                false => 11869,
                            },
                            false => West switch {
                                true => 11870,
                                false => 11871,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11872,
                                false => 11873,
                            },
                            false => West switch {
                                true => 11874,
                                false => 11875,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11844 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11845 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11846 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11847 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11848 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11849 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11850 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11851 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11852 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11853 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11854 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11855 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11856 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11857 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11858 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11859 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11860 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11861 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11862 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11863 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11864 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11865 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11866 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11867 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11868 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11869 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11870 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11871 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11872 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11873 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11874 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11875 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
