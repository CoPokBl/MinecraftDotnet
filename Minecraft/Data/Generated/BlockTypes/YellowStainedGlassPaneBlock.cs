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
                                true => 11588,
                                false => 11589,
                            },
                            false => West switch {
                                true => 11590,
                                false => 11591,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11592,
                                false => 11593,
                            },
                            false => West switch {
                                true => 11594,
                                false => 11595,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11596,
                                false => 11597,
                            },
                            false => West switch {
                                true => 11598,
                                false => 11599,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11600,
                                false => 11601,
                            },
                            false => West switch {
                                true => 11602,
                                false => 11603,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11604,
                                false => 11605,
                            },
                            false => West switch {
                                true => 11606,
                                false => 11607,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11608,
                                false => 11609,
                            },
                            false => West switch {
                                true => 11610,
                                false => 11611,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11612,
                                false => 11613,
                            },
                            false => West switch {
                                true => 11614,
                                false => 11615,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11616,
                                false => 11617,
                            },
                            false => West switch {
                                true => 11618,
                                false => 11619,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11588 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11589 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11590 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11591 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11592 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11593 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11594 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11595 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11596 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11597 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11598 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11599 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11600 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11601 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11602 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11603 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11604 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11605 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11606 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11607 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11608 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11609 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11610 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11611 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11612 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11613 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11614 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11615 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11616 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11617 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11618 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11619 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
