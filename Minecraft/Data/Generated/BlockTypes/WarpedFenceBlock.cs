using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19739,
                                false => 19740,
                            },
                            false => West switch {
                                true => 19741,
                                false => 19742,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19743,
                                false => 19744,
                            },
                            false => West switch {
                                true => 19745,
                                false => 19746,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19747,
                                false => 19748,
                            },
                            false => West switch {
                                true => 19749,
                                false => 19750,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19751,
                                false => 19752,
                            },
                            false => West switch {
                                true => 19753,
                                false => 19754,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19755,
                                false => 19756,
                            },
                            false => West switch {
                                true => 19757,
                                false => 19758,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19759,
                                false => 19760,
                            },
                            false => West switch {
                                true => 19761,
                                false => 19762,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19763,
                                false => 19764,
                            },
                            false => West switch {
                                true => 19765,
                                false => 19766,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19767,
                                false => 19768,
                            },
                            false => West switch {
                                true => 19769,
                                false => 19770,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19739 => new WarpedFenceBlock(Identifier, true, true, true, true, true),
            19740 => new WarpedFenceBlock(Identifier, true, true, true, true, false),
            19741 => new WarpedFenceBlock(Identifier, true, true, true, false, true),
            19742 => new WarpedFenceBlock(Identifier, true, true, true, false, false),
            19743 => new WarpedFenceBlock(Identifier, true, true, false, true, true),
            19744 => new WarpedFenceBlock(Identifier, true, true, false, true, false),
            19745 => new WarpedFenceBlock(Identifier, true, true, false, false, true),
            19746 => new WarpedFenceBlock(Identifier, true, true, false, false, false),
            19747 => new WarpedFenceBlock(Identifier, true, false, true, true, true),
            19748 => new WarpedFenceBlock(Identifier, true, false, true, true, false),
            19749 => new WarpedFenceBlock(Identifier, true, false, true, false, true),
            19750 => new WarpedFenceBlock(Identifier, true, false, true, false, false),
            19751 => new WarpedFenceBlock(Identifier, true, false, false, true, true),
            19752 => new WarpedFenceBlock(Identifier, true, false, false, true, false),
            19753 => new WarpedFenceBlock(Identifier, true, false, false, false, true),
            19754 => new WarpedFenceBlock(Identifier, true, false, false, false, false),
            19755 => new WarpedFenceBlock(Identifier, false, true, true, true, true),
            19756 => new WarpedFenceBlock(Identifier, false, true, true, true, false),
            19757 => new WarpedFenceBlock(Identifier, false, true, true, false, true),
            19758 => new WarpedFenceBlock(Identifier, false, true, true, false, false),
            19759 => new WarpedFenceBlock(Identifier, false, true, false, true, true),
            19760 => new WarpedFenceBlock(Identifier, false, true, false, true, false),
            19761 => new WarpedFenceBlock(Identifier, false, true, false, false, true),
            19762 => new WarpedFenceBlock(Identifier, false, true, false, false, false),
            19763 => new WarpedFenceBlock(Identifier, false, false, true, true, true),
            19764 => new WarpedFenceBlock(Identifier, false, false, true, true, false),
            19765 => new WarpedFenceBlock(Identifier, false, false, true, false, true),
            19766 => new WarpedFenceBlock(Identifier, false, false, true, false, false),
            19767 => new WarpedFenceBlock(Identifier, false, false, false, true, true),
            19768 => new WarpedFenceBlock(Identifier, false, false, false, true, false),
            19769 => new WarpedFenceBlock(Identifier, false, false, false, false, true),
            19770 => new WarpedFenceBlock(Identifier, false, false, false, false, false),
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
