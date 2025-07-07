using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

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
    public Identifier? Item => "minecraft:cyan_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.cyan_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10469,
                                false => 10470,
                            },
                            false => West switch {
                                true => 10471,
                                false => 10472,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10473,
                                false => 10474,
                            },
                            false => West switch {
                                true => 10475,
                                false => 10476,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10477,
                                false => 10478,
                            },
                            false => West switch {
                                true => 10479,
                                false => 10480,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10481,
                                false => 10482,
                            },
                            false => West switch {
                                true => 10483,
                                false => 10484,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10485,
                                false => 10486,
                            },
                            false => West switch {
                                true => 10487,
                                false => 10488,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10489,
                                false => 10490,
                            },
                            false => West switch {
                                true => 10491,
                                false => 10492,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10493,
                                false => 10494,
                            },
                            false => West switch {
                                true => 10495,
                                false => 10496,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10497,
                                false => 10498,
                            },
                            false => West switch {
                                true => 10499,
                                false => 10500,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10469 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10470 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10471 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10472 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10473 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10474 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10475 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10476 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10477 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10478 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10479 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10480 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10481 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10482 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10483 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10484 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10485 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10486 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10487 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10488 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10489 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10490 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10491 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10492 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10493 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10494 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10495 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10496 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10497 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10498 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10499 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10500 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
