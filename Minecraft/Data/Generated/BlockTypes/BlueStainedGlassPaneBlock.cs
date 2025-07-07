using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

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
    public Identifier? Item => "minecraft:blue_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.blue_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10533,
                                false => 10534,
                            },
                            false => West switch {
                                true => 10535,
                                false => 10536,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10537,
                                false => 10538,
                            },
                            false => West switch {
                                true => 10539,
                                false => 10540,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10541,
                                false => 10542,
                            },
                            false => West switch {
                                true => 10543,
                                false => 10544,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10545,
                                false => 10546,
                            },
                            false => West switch {
                                true => 10547,
                                false => 10548,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10549,
                                false => 10550,
                            },
                            false => West switch {
                                true => 10551,
                                false => 10552,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10553,
                                false => 10554,
                            },
                            false => West switch {
                                true => 10555,
                                false => 10556,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10557,
                                false => 10558,
                            },
                            false => West switch {
                                true => 10559,
                                false => 10560,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10561,
                                false => 10562,
                            },
                            false => West switch {
                                true => 10563,
                                false => 10564,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10533 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10534 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10535 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10536 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10537 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10538 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10539 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10540 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10541 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10542 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10543 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10544 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10545 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10546 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10547 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10548 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10549 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10550 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10551 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10552 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10553 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10554 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10555 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10556 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10557 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10558 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10559 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10560 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10561 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10562 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10563 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10564 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
