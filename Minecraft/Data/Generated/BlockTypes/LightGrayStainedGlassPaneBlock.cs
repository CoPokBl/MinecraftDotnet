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
                                true => 10437,
                                false => 10438,
                            },
                            false => West switch {
                                true => 10439,
                                false => 10440,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10441,
                                false => 10442,
                            },
                            false => West switch {
                                true => 10443,
                                false => 10444,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10445,
                                false => 10446,
                            },
                            false => West switch {
                                true => 10447,
                                false => 10448,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10449,
                                false => 10450,
                            },
                            false => West switch {
                                true => 10451,
                                false => 10452,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10453,
                                false => 10454,
                            },
                            false => West switch {
                                true => 10455,
                                false => 10456,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10457,
                                false => 10458,
                            },
                            false => West switch {
                                true => 10459,
                                false => 10460,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10461,
                                false => 10462,
                            },
                            false => West switch {
                                true => 10463,
                                false => 10464,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10465,
                                false => 10466,
                            },
                            false => West switch {
                                true => 10467,
                                false => 10468,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10437 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10438 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10439 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10440 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10441 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10442 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10443 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10444 => new LightGrayStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10445 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10446 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10447 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10448 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10449 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10450 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10451 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10452 => new LightGrayStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10453 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10454 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10455 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10456 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10457 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10458 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10459 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10460 => new LightGrayStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10461 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10462 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10463 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10464 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10465 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10466 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10467 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10468 => new LightGrayStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
