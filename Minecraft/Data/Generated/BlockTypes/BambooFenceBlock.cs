using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 613;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12749,
                                false => 12750,
                            },
                            false => West switch {
                                true => 12751,
                                false => 12752,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12753,
                                false => 12754,
                            },
                            false => West switch {
                                true => 12755,
                                false => 12756,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12757,
                                false => 12758,
                            },
                            false => West switch {
                                true => 12759,
                                false => 12760,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12761,
                                false => 12762,
                            },
                            false => West switch {
                                true => 12763,
                                false => 12764,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12765,
                                false => 12766,
                            },
                            false => West switch {
                                true => 12767,
                                false => 12768,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12769,
                                false => 12770,
                            },
                            false => West switch {
                                true => 12771,
                                false => 12772,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12773,
                                false => 12774,
                            },
                            false => West switch {
                                true => 12775,
                                false => 12776,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12777,
                                false => 12778,
                            },
                            false => West switch {
                                true => 12779,
                                false => 12780,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12749 => new BambooFenceBlock(Identifier, true, true, true, true, true),
            12750 => new BambooFenceBlock(Identifier, true, true, true, true, false),
            12751 => new BambooFenceBlock(Identifier, true, true, true, false, true),
            12752 => new BambooFenceBlock(Identifier, true, true, true, false, false),
            12753 => new BambooFenceBlock(Identifier, true, true, false, true, true),
            12754 => new BambooFenceBlock(Identifier, true, true, false, true, false),
            12755 => new BambooFenceBlock(Identifier, true, true, false, false, true),
            12756 => new BambooFenceBlock(Identifier, true, true, false, false, false),
            12757 => new BambooFenceBlock(Identifier, true, false, true, true, true),
            12758 => new BambooFenceBlock(Identifier, true, false, true, true, false),
            12759 => new BambooFenceBlock(Identifier, true, false, true, false, true),
            12760 => new BambooFenceBlock(Identifier, true, false, true, false, false),
            12761 => new BambooFenceBlock(Identifier, true, false, false, true, true),
            12762 => new BambooFenceBlock(Identifier, true, false, false, true, false),
            12763 => new BambooFenceBlock(Identifier, true, false, false, false, true),
            12764 => new BambooFenceBlock(Identifier, true, false, false, false, false),
            12765 => new BambooFenceBlock(Identifier, false, true, true, true, true),
            12766 => new BambooFenceBlock(Identifier, false, true, true, true, false),
            12767 => new BambooFenceBlock(Identifier, false, true, true, false, true),
            12768 => new BambooFenceBlock(Identifier, false, true, true, false, false),
            12769 => new BambooFenceBlock(Identifier, false, true, false, true, true),
            12770 => new BambooFenceBlock(Identifier, false, true, false, true, false),
            12771 => new BambooFenceBlock(Identifier, false, true, false, false, true),
            12772 => new BambooFenceBlock(Identifier, false, true, false, false, false),
            12773 => new BambooFenceBlock(Identifier, false, false, true, true, true),
            12774 => new BambooFenceBlock(Identifier, false, false, true, true, false),
            12775 => new BambooFenceBlock(Identifier, false, false, true, false, true),
            12776 => new BambooFenceBlock(Identifier, false, false, true, false, false),
            12777 => new BambooFenceBlock(Identifier, false, false, false, true, true),
            12778 => new BambooFenceBlock(Identifier, false, false, false, true, false),
            12779 => new BambooFenceBlock(Identifier, false, false, false, false, true),
            12780 => new BambooFenceBlock(Identifier, false, false, false, false, false),
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
