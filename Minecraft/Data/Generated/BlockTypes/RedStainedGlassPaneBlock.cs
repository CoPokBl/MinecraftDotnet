using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

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
    public Identifier? Item => "minecraft:red_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.red_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10629,
                                false => 10630,
                            },
                            false => West switch {
                                true => 10631,
                                false => 10632,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10633,
                                false => 10634,
                            },
                            false => West switch {
                                true => 10635,
                                false => 10636,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10637,
                                false => 10638,
                            },
                            false => West switch {
                                true => 10639,
                                false => 10640,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10641,
                                false => 10642,
                            },
                            false => West switch {
                                true => 10643,
                                false => 10644,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10645,
                                false => 10646,
                            },
                            false => West switch {
                                true => 10647,
                                false => 10648,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10649,
                                false => 10650,
                            },
                            false => West switch {
                                true => 10651,
                                false => 10652,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10653,
                                false => 10654,
                            },
                            false => West switch {
                                true => 10655,
                                false => 10656,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10657,
                                false => 10658,
                            },
                            false => West switch {
                                true => 10659,
                                false => 10660,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10629 => new RedStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10630 => new RedStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10631 => new RedStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10632 => new RedStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10633 => new RedStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10634 => new RedStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10635 => new RedStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10636 => new RedStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10637 => new RedStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10638 => new RedStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10639 => new RedStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10640 => new RedStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10641 => new RedStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10642 => new RedStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10643 => new RedStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10644 => new RedStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10645 => new RedStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10646 => new RedStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10647 => new RedStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10648 => new RedStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10649 => new RedStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10650 => new RedStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10651 => new RedStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10652 => new RedStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10653 => new RedStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10654 => new RedStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10655 => new RedStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10656 => new RedStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10657 => new RedStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10658 => new RedStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10659 => new RedStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10660 => new RedStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
