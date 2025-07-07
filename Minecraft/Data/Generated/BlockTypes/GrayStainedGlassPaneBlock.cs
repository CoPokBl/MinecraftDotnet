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
                                true => 10405,
                                false => 10406,
                            },
                            false => West switch {
                                true => 10407,
                                false => 10408,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10409,
                                false => 10410,
                            },
                            false => West switch {
                                true => 10411,
                                false => 10412,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10413,
                                false => 10414,
                            },
                            false => West switch {
                                true => 10415,
                                false => 10416,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10417,
                                false => 10418,
                            },
                            false => West switch {
                                true => 10419,
                                false => 10420,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10421,
                                false => 10422,
                            },
                            false => West switch {
                                true => 10423,
                                false => 10424,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10425,
                                false => 10426,
                            },
                            false => West switch {
                                true => 10427,
                                false => 10428,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10429,
                                false => 10430,
                            },
                            false => West switch {
                                true => 10431,
                                false => 10432,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10433,
                                false => 10434,
                            },
                            false => West switch {
                                true => 10435,
                                false => 10436,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10405 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10406 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10407 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10408 => new GrayStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10409 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10410 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10411 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10412 => new GrayStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10413 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10414 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10415 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10416 => new GrayStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10417 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10418 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10419 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10420 => new GrayStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10421 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10422 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10423 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10424 => new GrayStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10425 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10426 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10427 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10428 => new GrayStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10429 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10430 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10431 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10432 => new GrayStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10433 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10434 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10435 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10436 => new GrayStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
