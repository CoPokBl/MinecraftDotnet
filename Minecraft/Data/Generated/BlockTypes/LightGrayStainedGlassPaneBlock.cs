using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:light_gray_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.light_gray_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11716,
                                false => 11717,
                            },
                            false => West switch {
                                true => 11718,
                                false => 11719,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11720,
                                false => 11721,
                            },
                            false => West switch {
                                true => 11722,
                                false => 11723,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11724,
                                false => 11725,
                            },
                            false => West switch {
                                true => 11726,
                                false => 11727,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11728,
                                false => 11729,
                            },
                            false => West switch {
                                true => 11730,
                                false => 11731,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11732,
                                false => 11733,
                            },
                            false => West switch {
                                true => 11734,
                                false => 11735,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11736,
                                false => 11737,
                            },
                            false => West switch {
                                true => 11738,
                                false => 11739,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11740,
                                false => 11741,
                            },
                            false => West switch {
                                true => 11742,
                                false => 11743,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11744,
                                false => 11745,
                            },
                            false => West switch {
                                true => 11746,
                                false => 11747,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11716 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11717 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11718 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11719 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11720 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11721 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11722 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11723 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11724 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11725 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11726 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11727 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11728 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11729 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11730 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11731 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11732 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11733 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11734 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11735 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11736 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11737 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11738 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11739 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11740 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11741 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11742 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11743 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11744 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11745 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11746 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11747 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
