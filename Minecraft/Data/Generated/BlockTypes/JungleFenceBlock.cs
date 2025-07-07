using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:jungle_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12557,
                                false => 12558,
                            },
                            false => West switch {
                                true => 12559,
                                false => 12560,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12561,
                                false => 12562,
                            },
                            false => West switch {
                                true => 12563,
                                false => 12564,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12565,
                                false => 12566,
                            },
                            false => West switch {
                                true => 12567,
                                false => 12568,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12569,
                                false => 12570,
                            },
                            false => West switch {
                                true => 12571,
                                false => 12572,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12573,
                                false => 12574,
                            },
                            false => West switch {
                                true => 12575,
                                false => 12576,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12577,
                                false => 12578,
                            },
                            false => West switch {
                                true => 12579,
                                false => 12580,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12581,
                                false => 12582,
                            },
                            false => West switch {
                                true => 12583,
                                false => 12584,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12585,
                                false => 12586,
                            },
                            false => West switch {
                                true => 12587,
                                false => 12588,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12557 => new JungleFenceBlock(Identifier, true, true, true, true, true),
            12558 => new JungleFenceBlock(Identifier, true, true, true, true, false),
            12559 => new JungleFenceBlock(Identifier, true, true, true, false, true),
            12560 => new JungleFenceBlock(Identifier, true, true, true, false, false),
            12561 => new JungleFenceBlock(Identifier, true, true, false, true, true),
            12562 => new JungleFenceBlock(Identifier, true, true, false, true, false),
            12563 => new JungleFenceBlock(Identifier, true, true, false, false, true),
            12564 => new JungleFenceBlock(Identifier, true, true, false, false, false),
            12565 => new JungleFenceBlock(Identifier, true, false, true, true, true),
            12566 => new JungleFenceBlock(Identifier, true, false, true, true, false),
            12567 => new JungleFenceBlock(Identifier, true, false, true, false, true),
            12568 => new JungleFenceBlock(Identifier, true, false, true, false, false),
            12569 => new JungleFenceBlock(Identifier, true, false, false, true, true),
            12570 => new JungleFenceBlock(Identifier, true, false, false, true, false),
            12571 => new JungleFenceBlock(Identifier, true, false, false, false, true),
            12572 => new JungleFenceBlock(Identifier, true, false, false, false, false),
            12573 => new JungleFenceBlock(Identifier, false, true, true, true, true),
            12574 => new JungleFenceBlock(Identifier, false, true, true, true, false),
            12575 => new JungleFenceBlock(Identifier, false, true, true, false, true),
            12576 => new JungleFenceBlock(Identifier, false, true, true, false, false),
            12577 => new JungleFenceBlock(Identifier, false, true, false, true, true),
            12578 => new JungleFenceBlock(Identifier, false, true, false, true, false),
            12579 => new JungleFenceBlock(Identifier, false, true, false, false, true),
            12580 => new JungleFenceBlock(Identifier, false, true, false, false, false),
            12581 => new JungleFenceBlock(Identifier, false, false, true, true, true),
            12582 => new JungleFenceBlock(Identifier, false, false, true, true, false),
            12583 => new JungleFenceBlock(Identifier, false, false, true, false, true),
            12584 => new JungleFenceBlock(Identifier, false, false, true, false, false),
            12585 => new JungleFenceBlock(Identifier, false, false, false, true, true),
            12586 => new JungleFenceBlock(Identifier, false, false, false, true, false),
            12587 => new JungleFenceBlock(Identifier, false, false, false, false, true),
            12588 => new JungleFenceBlock(Identifier, false, false, false, false, false),
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
