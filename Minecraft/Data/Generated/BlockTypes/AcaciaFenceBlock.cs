using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:acacia_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13868,
                                false => 13869,
                            },
                            false => West switch {
                                true => 13870,
                                false => 13871,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13872,
                                false => 13873,
                            },
                            false => West switch {
                                true => 13874,
                                false => 13875,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13876,
                                false => 13877,
                            },
                            false => West switch {
                                true => 13878,
                                false => 13879,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13880,
                                false => 13881,
                            },
                            false => West switch {
                                true => 13882,
                                false => 13883,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13884,
                                false => 13885,
                            },
                            false => West switch {
                                true => 13886,
                                false => 13887,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13888,
                                false => 13889,
                            },
                            false => West switch {
                                true => 13890,
                                false => 13891,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13892,
                                false => 13893,
                            },
                            false => West switch {
                                true => 13894,
                                false => 13895,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13896,
                                false => 13897,
                            },
                            false => West switch {
                                true => 13898,
                                false => 13899,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13868 => new AcaciaFenceBlock(Identifier, true, true, true, true, true),
            13869 => new AcaciaFenceBlock(Identifier, true, true, true, true, false),
            13870 => new AcaciaFenceBlock(Identifier, true, true, true, false, true),
            13871 => new AcaciaFenceBlock(Identifier, true, true, true, false, false),
            13872 => new AcaciaFenceBlock(Identifier, true, true, false, true, true),
            13873 => new AcaciaFenceBlock(Identifier, true, true, false, true, false),
            13874 => new AcaciaFenceBlock(Identifier, true, true, false, false, true),
            13875 => new AcaciaFenceBlock(Identifier, true, true, false, false, false),
            13876 => new AcaciaFenceBlock(Identifier, true, false, true, true, true),
            13877 => new AcaciaFenceBlock(Identifier, true, false, true, true, false),
            13878 => new AcaciaFenceBlock(Identifier, true, false, true, false, true),
            13879 => new AcaciaFenceBlock(Identifier, true, false, true, false, false),
            13880 => new AcaciaFenceBlock(Identifier, true, false, false, true, true),
            13881 => new AcaciaFenceBlock(Identifier, true, false, false, true, false),
            13882 => new AcaciaFenceBlock(Identifier, true, false, false, false, true),
            13883 => new AcaciaFenceBlock(Identifier, true, false, false, false, false),
            13884 => new AcaciaFenceBlock(Identifier, false, true, true, true, true),
            13885 => new AcaciaFenceBlock(Identifier, false, true, true, true, false),
            13886 => new AcaciaFenceBlock(Identifier, false, true, true, false, true),
            13887 => new AcaciaFenceBlock(Identifier, false, true, true, false, false),
            13888 => new AcaciaFenceBlock(Identifier, false, true, false, true, true),
            13889 => new AcaciaFenceBlock(Identifier, false, true, false, true, false),
            13890 => new AcaciaFenceBlock(Identifier, false, true, false, false, true),
            13891 => new AcaciaFenceBlock(Identifier, false, true, false, false, false),
            13892 => new AcaciaFenceBlock(Identifier, false, false, true, true, true),
            13893 => new AcaciaFenceBlock(Identifier, false, false, true, true, false),
            13894 => new AcaciaFenceBlock(Identifier, false, false, true, false, true),
            13895 => new AcaciaFenceBlock(Identifier, false, false, true, false, false),
            13896 => new AcaciaFenceBlock(Identifier, false, false, false, true, true),
            13897 => new AcaciaFenceBlock(Identifier, false, false, false, true, false),
            13898 => new AcaciaFenceBlock(Identifier, false, false, false, false, true),
            13899 => new AcaciaFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
