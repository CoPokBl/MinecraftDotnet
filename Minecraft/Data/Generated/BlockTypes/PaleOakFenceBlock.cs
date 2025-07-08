using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
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
    public Identifier? Item => "minecraft:pale_oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12685,
                                false => 12686,
                            },
                            false => West switch {
                                true => 12687,
                                false => 12688,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12689,
                                false => 12690,
                            },
                            false => West switch {
                                true => 12691,
                                false => 12692,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12693,
                                false => 12694,
                            },
                            false => West switch {
                                true => 12695,
                                false => 12696,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12697,
                                false => 12698,
                            },
                            false => West switch {
                                true => 12699,
                                false => 12700,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12701,
                                false => 12702,
                            },
                            false => West switch {
                                true => 12703,
                                false => 12704,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12705,
                                false => 12706,
                            },
                            false => West switch {
                                true => 12707,
                                false => 12708,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12709,
                                false => 12710,
                            },
                            false => West switch {
                                true => 12711,
                                false => 12712,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12713,
                                false => 12714,
                            },
                            false => West switch {
                                true => 12715,
                                false => 12716,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12685 => new PaleOakFenceBlock(Identifier, true, true, true, true, true),
            12686 => new PaleOakFenceBlock(Identifier, true, true, true, true, false),
            12687 => new PaleOakFenceBlock(Identifier, true, true, true, false, true),
            12688 => new PaleOakFenceBlock(Identifier, true, true, true, false, false),
            12689 => new PaleOakFenceBlock(Identifier, true, true, false, true, true),
            12690 => new PaleOakFenceBlock(Identifier, true, true, false, true, false),
            12691 => new PaleOakFenceBlock(Identifier, true, true, false, false, true),
            12692 => new PaleOakFenceBlock(Identifier, true, true, false, false, false),
            12693 => new PaleOakFenceBlock(Identifier, true, false, true, true, true),
            12694 => new PaleOakFenceBlock(Identifier, true, false, true, true, false),
            12695 => new PaleOakFenceBlock(Identifier, true, false, true, false, true),
            12696 => new PaleOakFenceBlock(Identifier, true, false, true, false, false),
            12697 => new PaleOakFenceBlock(Identifier, true, false, false, true, true),
            12698 => new PaleOakFenceBlock(Identifier, true, false, false, true, false),
            12699 => new PaleOakFenceBlock(Identifier, true, false, false, false, true),
            12700 => new PaleOakFenceBlock(Identifier, true, false, false, false, false),
            12701 => new PaleOakFenceBlock(Identifier, false, true, true, true, true),
            12702 => new PaleOakFenceBlock(Identifier, false, true, true, true, false),
            12703 => new PaleOakFenceBlock(Identifier, false, true, true, false, true),
            12704 => new PaleOakFenceBlock(Identifier, false, true, true, false, false),
            12705 => new PaleOakFenceBlock(Identifier, false, true, false, true, true),
            12706 => new PaleOakFenceBlock(Identifier, false, true, false, true, false),
            12707 => new PaleOakFenceBlock(Identifier, false, true, false, false, true),
            12708 => new PaleOakFenceBlock(Identifier, false, true, false, false, false),
            12709 => new PaleOakFenceBlock(Identifier, false, false, true, true, true),
            12710 => new PaleOakFenceBlock(Identifier, false, false, true, true, false),
            12711 => new PaleOakFenceBlock(Identifier, false, false, true, false, true),
            12712 => new PaleOakFenceBlock(Identifier, false, false, true, false, false),
            12713 => new PaleOakFenceBlock(Identifier, false, false, false, true, true),
            12714 => new PaleOakFenceBlock(Identifier, false, false, false, true, false),
            12715 => new PaleOakFenceBlock(Identifier, false, false, false, false, true),
            12716 => new PaleOakFenceBlock(Identifier, false, false, false, false, false),
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
