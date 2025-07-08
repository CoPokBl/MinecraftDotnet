using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19707,
                                false => 19708,
                            },
                            false => West switch {
                                true => 19709,
                                false => 19710,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19711,
                                false => 19712,
                            },
                            false => West switch {
                                true => 19713,
                                false => 19714,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19715,
                                false => 19716,
                            },
                            false => West switch {
                                true => 19717,
                                false => 19718,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19719,
                                false => 19720,
                            },
                            false => West switch {
                                true => 19721,
                                false => 19722,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19723,
                                false => 19724,
                            },
                            false => West switch {
                                true => 19725,
                                false => 19726,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19727,
                                false => 19728,
                            },
                            false => West switch {
                                true => 19729,
                                false => 19730,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19731,
                                false => 19732,
                            },
                            false => West switch {
                                true => 19733,
                                false => 19734,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19735,
                                false => 19736,
                            },
                            false => West switch {
                                true => 19737,
                                false => 19738,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19707 => new CrimsonFenceBlock(Identifier, true, true, true, true, true),
            19708 => new CrimsonFenceBlock(Identifier, true, true, true, true, false),
            19709 => new CrimsonFenceBlock(Identifier, true, true, true, false, true),
            19710 => new CrimsonFenceBlock(Identifier, true, true, true, false, false),
            19711 => new CrimsonFenceBlock(Identifier, true, true, false, true, true),
            19712 => new CrimsonFenceBlock(Identifier, true, true, false, true, false),
            19713 => new CrimsonFenceBlock(Identifier, true, true, false, false, true),
            19714 => new CrimsonFenceBlock(Identifier, true, true, false, false, false),
            19715 => new CrimsonFenceBlock(Identifier, true, false, true, true, true),
            19716 => new CrimsonFenceBlock(Identifier, true, false, true, true, false),
            19717 => new CrimsonFenceBlock(Identifier, true, false, true, false, true),
            19718 => new CrimsonFenceBlock(Identifier, true, false, true, false, false),
            19719 => new CrimsonFenceBlock(Identifier, true, false, false, true, true),
            19720 => new CrimsonFenceBlock(Identifier, true, false, false, true, false),
            19721 => new CrimsonFenceBlock(Identifier, true, false, false, false, true),
            19722 => new CrimsonFenceBlock(Identifier, true, false, false, false, false),
            19723 => new CrimsonFenceBlock(Identifier, false, true, true, true, true),
            19724 => new CrimsonFenceBlock(Identifier, false, true, true, true, false),
            19725 => new CrimsonFenceBlock(Identifier, false, true, true, false, true),
            19726 => new CrimsonFenceBlock(Identifier, false, true, true, false, false),
            19727 => new CrimsonFenceBlock(Identifier, false, true, false, true, true),
            19728 => new CrimsonFenceBlock(Identifier, false, true, false, true, false),
            19729 => new CrimsonFenceBlock(Identifier, false, true, false, false, true),
            19730 => new CrimsonFenceBlock(Identifier, false, true, false, false, false),
            19731 => new CrimsonFenceBlock(Identifier, false, false, true, true, true),
            19732 => new CrimsonFenceBlock(Identifier, false, false, true, true, false),
            19733 => new CrimsonFenceBlock(Identifier, false, false, true, false, true),
            19734 => new CrimsonFenceBlock(Identifier, false, false, true, false, false),
            19735 => new CrimsonFenceBlock(Identifier, false, false, false, true, true),
            19736 => new CrimsonFenceBlock(Identifier, false, false, false, true, false),
            19737 => new CrimsonFenceBlock(Identifier, false, false, false, false, true),
            19738 => new CrimsonFenceBlock(Identifier, false, false, false, false, false),
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
